USE [Restaurante_V4_Produccion]
GO
/****** Object:  StoredProcedure [DBA].[sp_consulta_productos_x_tipo]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [DBA].[sp_consulta_productos_x_tipo]
as

select *
from dba.vw_productos_x_tipo
order by descripcion, nombre asc


GO
/****** Object:  StoredProcedure [FAC].[sp_actualizar_orden_m]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_actualizar_orden_m](
    @numeroOrden decimal(16,0),
	@total decimal(12,4),
	@cod_cliente decimal(10,0),
	@efectivo decimal(12,4),
	@descuento decimal(3,0),
	@tarjeta decimal(12,4),
	@impserv decimal(12,2),
	@impvtas decimal(12,2),
	@express money

)AS
Declare @w_tran INT
If @@TRANCOUNT <> 0
	BEGIN 
		COMMIT TRAN
If @@ERROR <> 0
		BEGIN
GoTo continuar
End
Select @w_tran = 1
	End
Else
Select @w_tran = 0
	CONTINUAR:
    BEGIN TRAN actualizar_orden_m
	UPDATE FAC.orden_m SET FAC.orden_m.total=(FAC.orden_m.total+@total), 
	FAC.orden_m.cod_cliente=@cod_cliente,
		FAC.orden_m.efectivo=(FAC.orden_m.efectivo+@efectivo), 
		FAC.orden_m.descuento=(FAC.orden_m.descuento+@descuento),
		FAC.orden_m.tarjeta=(FAC.orden_m.tarjeta+@tarjeta),
		 FAC.orden_m.impserv=(FAC.orden_m.impserv+@impserv),
		FAC.orden_m.impvtas= @impvtas,
		 FAC.orden_m.express=(FAC.orden_m.express+@express)
	WHERE num_orden=@numeroOrden
	IF @@ERROR <> 0 
		BEGIN
			PRINT 'No se pudo actualizar'
			ROLLBACK
		END
	COMMIT TRANSACTION actualizar_orden_m
	IF @w_tran  = 1
		BEGIN TRAN

--//****************************************************************************************//
--//****************************************************************************************//
--//****************************************************************************************//
--//*******************************ALMACENA FACTURA M***************************************//
--//****************************************************************************************//
--//****************************************************************************************//
--//****************************************************************************************//

/****** Object:  StoredProcedure [FAC].[sp_almacena_factura_d]    Script Date: 31/08/2016 03:13:30 p.m. ******/
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [FAC].[sp_almacena_factura_cajero]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_almacena_factura_cajero](
	@num_Factura decimal(5,0),
	@cod_usuario VARCHAR(30)
	)
  AS
	BEGIN TRAN
		BEGIN TRY
			if not exists(select * from FAC.factura_c where num_factura=@num_Factura and cod_usuario=@cod_usuario)
			begin
				INSERT INTO FAC.factura_c VALUES(@num_factura,@cod_usuario)
				COMMIT
				Return 1
			end
		End Try
	BEGIN CATCH
		ROLLBACK
		Return 0
	End Catch;
	

GO
/****** Object:  StoredProcedure [FAC].[sp_almacena_factura_d]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_almacena_factura_d](
	@num_Factura decimal(5,0),
	@cod_producto decimal(10,0),
	@cantidad decimal(5,0),
	@subTotal decimal (12,4)
	)
  AS
	BEGIN TRAN
		BEGIN TRY
			INSERT INTO FAC.factura_d VALUES(@num_Factura,@cod_producto,@cantidad,@subTotal)
			COMMIT
			Return 1
		End Try
	BEGIN CATCH
		ROLLBACK
		Return 0
	End Catch;
	

GO
/****** Object:  StoredProcedure [FAC].[sp_almacena_factura_m]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_almacena_factura_m](
	@num_Factura decimal(5,0),
	@fecha_factura datetime,
	@cod_estado_factura varchar(1),
	@descuento decimal(6,2),
	@num_orden decimal(16,0),
	@mto_total decimal(16,2)
	)
  AS
	BEGIN TRAN
		BEGIN TRY
			INSERT INTO FAC.factura_m VALUES(@num_Factura,@fecha_factura,@cod_estado_factura,@descuento,@num_orden,@mto_total)
			UPDATE DBA.parametros SET DBA.parametros.num_factura= @num_Factura
			COMMIT
			Return 1
		End Try
	BEGIN CATCH
		ROLLBACK
		Return 0
	End Catch;


GO
/****** Object:  StoredProcedure [FAC].[sp_almacena_factura_p]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_almacena_factura_p](
		@num_pago decimal(5,0),
		@num_factura decimal(5,0),
		@tipo_pago varchar(1),
		@monto decimal(12,4)
	)
	AS
DECLARE @w_tran INT
IF @@TRANCOUNT <> 0
	BEGIN 
		COMMIT TRAN
		if @@ERROR <> 0
		BEGIN
			GOTO continuar
		END
		SELECT @w_tran = 1
	END
ELSE
	SELECT @w_tran = 0
	CONTINUAR:
	
    BEGIN TRAN ingresar_factura_p
	INSERT INTO FAC.factura_p VALUES (@num_pago, @num_factura, @tipo_pago, @monto)
	IF @@ERROR <> 0 
		BEGIN
			PRINT 'No se pudo insertar'
			ROLLBACK
		END
	COMMIT TRANSACTION ingresar_factura_p
	IF @w_tran  = 1
		BEGIN TRAN




GO
/****** Object:  StoredProcedure [FAC].[sp_almacena_fondo_final_flujocaja_d]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [FAC].[sp_almacena_fondo_final_flujocaja_d](
  --@codigo_usuario_asigna VARCHAR(30),
  @codigo_usuario_recibe VARCHAR(30),
  @tipo_moneda DECIMAL(5,0),
  @cod_moneda DECIMAL(5,0),
  @cantidad_cierre DECIMAL(5,0),
  @subtotal_cierre DECIMAL(16,2),
  @flag bit
  )
  AS
  BEGIN TRAN
	BEGIN TRY
		-- valida si la bandera es 1 (primera vez que se ejecuta) para actualizar en flujocaja_m
		IF (@flag = 1) BEGIN
			UPDATE FAC.flujocaja_M SET estado_caja = 'C', aprobada = 1
			WHERE cod_usuario_recibe = @codigo_usuario_recibe 
			AND tipo_moneda = @tipo_moneda
		END

		UPDATE FAC.flujocaja_d SET cantidad_cierre = @cantidad_cierre, subtotal_cierre = @subtotal_cierre
		WHERE cod_usuario_recibe = @codigo_usuario_recibe 
		AND tipo_moneda = @tipo_moneda AND cod_moneda = @cod_moneda
		COMMIT
		return 1
	END TRY
	BEGIN CATCH
		ROLLBACK
		return 0
	END CATCH;


GO
/****** Object:  StoredProcedure [FAC].[sp_almacena_fondo_inicial_flujocaja_d]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [FAC].[sp_almacena_fondo_inicial_flujocaja_d](
  @codigo_usuario_asigna VARCHAR(30),
  @codigo_usuario_recibe VARCHAR(30),
  @fecha DATETIME,
  @tipo_moneda DECIMAL(5,0),
  @cod_moneda DECIMAL(5,0),
  @cantidad DECIMAL(5,0),
  @subtotal DECIMAL(16,2),
  @flag bit,
  @tipo_cambio DECIMAL(16,2)
  )
  AS
  BEGIN TRAN
	BEGIN TRY
	/*
	valida si es la primera vez que se va a insertar para almacenar en flujo de caja m y 
	asi asignar la apertura de caja
	*/
	IF (@flag = 1) BEGIN
		INSERT INTO FAC.flujocaja_m VALUES (@codigo_usuario_asigna, @codigo_usuario_recibe, @tipo_moneda, @fecha, 'A', @tipo_cambio, 0, 1)
	END 

		INSERT INTO FAC.flujocaja_d VALUES (@codigo_usuario_asigna, @codigo_usuario_recibe, @fecha, @tipo_moneda, @cod_moneda, @cantidad, @subtotal, 0,0)--@cantidad_cierre, @subtotal_cierre)
		COMMIT	
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH;


GO
/****** Object:  StoredProcedure [FAC].[sp_almacena_intro_sale]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [FAC].[sp_almacena_intro_sale](
  @cod_usuario VARCHAR(30), 
  @fecha DATETIME,
  @cod_moneda DECIMAL(5,0),
  @cantidad DECIMAL(8,0),
  @subtotal DECIMAL(16,2), 
  @tipo_moneda DECIMAL(8,0),
  @tipo_cambio DECIMAL(16,2),
  @pass_user VARCHAR(8),
  @aprobado DECIMAL(8),
  @tipo_evento DECIMAL(5,0)
  )
  AS
  BEGIN TRAN
	BEGIN TRY
		IF EXISTS (SELECT * FROM RRHH.usuarios AS us WHERE us.cod_usuario = @cod_usuario AND us.contrasena = @pass_user)
		BEGIN
			INSERT INTO FAC.intro_sale VALUES (@cod_usuario, @fecha, @cod_moneda, @cantidad, @subtotal, @tipo_moneda, @tipo_cambio,@pass_user,@aprobado,@tipo_evento)
			COMMIT
			RETURN 1
		END
		ELSE
		BEGIN
			ROLLBACK
			RETURN 0
			--PRINT 'ERROR'
		END
	END TRY
	BEGIN CATCH
		ROLLBACK
		RETURN 0
	END CATCH;



GO
/****** Object:  StoredProcedure [FAC].[sp_almacena_pago_facturas]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [FAC].[sp_almacena_pago_facturas](
	@cod_usuario VARCHAR(30),
	@fecha_pago DATETIME,
	@concepto VARCHAR(60),
	@cod_proveedor DECIMAL(10,0),
	@tipo VARCHAR(30),
	@fecha_factura DATETIME,
	@num_factura DECIMAL(16,2),
	@monto_factura DECIMAL(16,2),
	@elemento VARCHAR(25),
	@observaciones TEXT
  )
  AS
  BEGIN TRAN
BEGIN TRY
		INSERT INTO FAC.pago_facturas VALUES (@cod_usuario, @fecha_pago, @concepto, @cod_proveedor, @tipo, @fecha_factura, @num_factura, @monto_factura,@elemento,@observaciones)
		COMMIT
Return 1
End Try
BEGIN CATCH
		ROLLBACK
Return 0
End Catch;


GO
/****** Object:  StoredProcedure [FAC].[sp_cliente_por_nombre]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FAC].[sp_cliente_por_nombre](
	@nombre varchar(50),
	@apellido varchar(50)
	)
  AS
	BEGIN TRAN
		BEGIN TRY
			If (@apellido = null Or len(@apellido)<1) 
				begin
					Select * From fac.clientes Where nombre_cliente = @nombre and (apellido is null or  apellido = '') 
				End
			Else
				begin
					Select * From fac.clientes Where nombre_cliente = @nombre And apellido = @apellido
				End
			COMMIT
			Return 1
		End Try
	BEGIN CATCH
		ROLLBACK
		Return 0
	End Catch

GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_detalle_factura]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_consulta_detalle_factura](
@num_factura decimal(5,0)
)
as
begin
begin tran
begin try
		select fd.num_factura, fd.cantidad,p.nombre, fd.sub_total
		from fac.factura_d as fd
		inner join inv.productos as p on p.cod_producto = fd.cod_producto
		where fd.num_factura = @num_factura

		commit
	End Try
	begin catch
		PRINT 'ERROR'
		ROLLBACK
	End Catch
End

GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_expres]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*prueba datos en la base*/
CREATE PROCEDURE [FAC].[sp_consulta_expres](
@cod_usuario VARCHAR(30),
@fecha_inicio VARCHAR(30),
@fecha_fin VARCHAR(30)
)
AS
BEGIN
	BEGIN TRAN
		BEGIN TRY
			 /*
			 se obtiene el monto final de los express.
			 facturados por un empleado en especifico durante su servicio en la caja
			 */
			select isnull(sum(express),0) 
			from FAC.orden_m as om
			inner join fac.factura_m as fm on fm.num_orden = om.num_orden
			INNER JOIN fac.factura_c AS fc ON fc.cod_usuario=@cod_usuario AND fc.num_factura=fm.num_factura
			/*se valida que sean del cajero en el momento*/
			--where om.cod_empleado = @cod_empleado and 
			/*se comparan la fecha, en la que a la factura se le realizo el pago, con las fecha de inicio y fin*/
			where om.ubicacion = 'E' AND
			concat(datepart(year,fm.fecha_factura), '-', right(CONCAT('0',datepart(month, fm.fecha_factura)),2), '-', right(CONCAT('0',datepart(day, fm.fecha_factura)),2), ' ', right(CONCAT('0',datepart(HOUR, fm.fecha_factura)),2), ':',right(CONCAT('0',datepart(minute, fm.fecha_factura)),2), ':', right(CONCAT('0',datepart(second, fm.fecha_factura)),2)) 
			between concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':', right(CONCAT('0',datepart(second, @fecha_inicio)),2))  And 
			concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))
			commit
			
	END TRY
	BEGIN CATCH
		PRINT 'algun error'
		ROLLBACK
	END CATCH
END


GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_factura]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_consulta_factura](
@num_factura decimal(5,0),
@cod_usuario varchar(30)
)
as
begin
begin tran
begin try
		select fm.num_factura, concat(cl.nombre_cliente, ' ', cl.apellido) as Cliente, om.ubicacion,concat(em.nombre, ' ', em.apellido1) as Cajero, om.num_mesa, fm.num_orden
		from fac.orden_m as om
		inner join FAC.clientes as cl on cl.cod_cliente = om.cod_cliente
		inner join FAC.factura_m as fm on fm.num_orden = om.num_orden
		inner join RRHH.empleados as em on em.cod_usuario = @cod_usuario
		inner join FAC.factura_c as fc on fc.num_factura=fm.num_factura AND fc.cod_usuario=em.cod_usuario
		where fm.num_factura = @num_factura 

		commit
	End Try
	begin catch
		PRINT 'ERROR'
		ROLLBACK
	End Catch
End

GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_fondo_final]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_consulta_fondo_final](
@cod_usuario_recibe varchar(30),
@fecha_inicio varchar(30),
@fecha_fin varchar(30),
@monto_total decimal(16,0) output
)
as
begin
begin tran
begin try
		Select @monto_total = isnull(sum(subtotal_cierre),0) 
		from FAC.flujocaja_d As fd
		inner join FAC.flujocaja_m As fm on fd.cod_usuario_asigna = fm.cod_usuario_asigna 
		and fd.cod_usuario_recibe = fm.cod_usuario_recibe 
		and fd.fecha = fm.fecha
		and fd.tipo_moneda = fm.tipo_moneda
		--usuarios
		where fd.cod_usuario_recibe = @cod_usuario_recibe 
		/*fechas */
		And concat(datepart(year,fm.fecha), '-', right(CONCAT('0',datepart(month, fm.fecha)),2), '-', right(CONCAT('0',datepart(day, fm.fecha)),2), ' ', right(CONCAT('0',datepart(HOUR, fm.fecha)),2), ':',right(CONCAT('0',datepart(minute, fm.fecha)),2), ':', right(CONCAT('0',datepart(second, fm.fecha)),2)) 
		between concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':00')  And 
		concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))
		/*estado caja*/
		And fm.estado_caja = 'C'
		commit
		Return @monto_total
	End Try
	begin catch
		PRINT 'ERROR'
		ROLLBACK
		Return @monto_total
	End Catch
End


GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_fondo_inicial]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_consulta_fondo_inicial](
@cod_usuario_recibe varchar(30),
@fecha_inicio varchar(30),
@fecha_fin varchar(30),
@monto_total decimal(16,0) output
)
as
begin
begin tran
begin try
		Select @monto_total = isnull(sum(subtotal),0) 
		from FAC.flujocaja_d As fd
		inner join FAC.flujocaja_m As fm on fd.cod_usuario_asigna = fm.cod_usuario_asigna 
		and fd.cod_usuario_recibe = fm.cod_usuario_recibe 
		and fd.fecha = fm.fecha
		and fd.tipo_moneda = fm.tipo_moneda
		/* usuarios */
		where fd.cod_usuario_recibe = @cod_usuario_recibe 
		/*fechas */
		And concat(datepart(year,fm.fecha), '-', right(CONCAT('0',datepart(month, fm.fecha)),2), '-', right(CONCAT('0',datepart(day, fm.fecha)),2), ' ', right(CONCAT('0',datepart(HOUR, fm.fecha)),2), ':',right(CONCAT('0',datepart(minute, fm.fecha)),2), ':', right(CONCAT('0',datepart(second, fm.fecha)),2)) 
		between concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':00')  And 
		concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))
		/*estado caja*/
		And fm.estado_caja = 'A'
		commit
		Return @monto_total
	End Try
	begin catch
		PRINT 'ERROR'
		ROLLBACK
		Return @monto_total
	End Catch
End


GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_historico_pago_facturas]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_consulta_historico_pago_facturas](
@cod_usuario varchar(30),
@fecha_inicio varchar(30),
@fecha_fin varchar(30))
as
begin
begin tran
	begin try
		Select *
		from FAC.pago_facturas As pf
		where pf.cod_usuario = @cod_usuario and 
		concat(datepart(year,pf.fecha_pago), '-', right(CONCAT('0',datepart(month, pf.fecha_pago)),2), '-', right(CONCAT('0',datepart(day, pf.fecha_pago)),2), ' ', right(CONCAT('0',datepart(HOUR, pf.fecha_pago)),2), ':',right(CONCAT('0',datepart(minute, pf.fecha_pago)),2), ':', right(CONCAT('0',datepart(second, pf.fecha_pago)),2)) 
		between concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':', right(CONCAT('0',datepart(second, @fecha_inicio)),2))  And 
		concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))
		/*concat(datepart(year,pf.fecha_pago), '/', right(CONCAT('0',datepart(month, pf.fecha_pago)),2), '/', right(CONCAT('0',datepart(day, pf.fecha_pago)),2)) 
		between concat(datepart(year,@fecha_inicio), '/', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '/', right(CONCAT('0',datepart(day, @fecha_inicio)),2)) 
		And 
		concat(datepart(year,@fecha_fin), '/', right(CONCAT('0',datepart(month, @fecha_fin)),2), '/', right(CONCAT('0',datepart(day, @fecha_fin)),2))
		*/
			--pf.fecha_pago between convert(datetime, @fecha_inicio) and convert(datetime,@fecha_fin)
		commit
	End Try
	begin catch
		PRINT 'ERROR'
		ROLLBACK
	End Catch
End


GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_impuesto_servicios]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [FAC].[sp_consulta_impuesto_servicios](
@cod_usuario varchar(30),
@fecha_inicio varchar(30),
@fecha_fin varchar(30)--,
--@monto_total decimal(16,0) output
)
as
begin
	begin tran
	begin try
		select isnull(sum(impserv),0) 
		--SELECT *
			from FAC.orden_m as om
			inner join fac.factura_m as fm on fm.num_orden = om.num_orden
			INNER JOIN fac.factura_c AS fc ON fc.cod_usuario=@cod_usuario AND fc.num_factura=fm.num_factura
			/*se valida que sean del cajero en el momento*/
			--where om.cod_empleado = @cod_empleado and 
			/*se comparan la fecha, en la que a la factura se le realizo el pago, con las fecha de inicio y fin*/
			where om.ind_pago = 1 AND concat(datepart(year,fm.fecha_factura), '-', right(CONCAT('0',datepart(month, fm.fecha_factura)),2), '-', right(CONCAT('0',datepart(day, fm.fecha_factura)),2), ' ', right(CONCAT('0',datepart(HOUR, fm.fecha_factura)),2), ':',right(CONCAT('0',datepart(minute, fm.fecha_factura)),2), ':', right(CONCAT('0',datepart(second, fm.fecha_factura)),2)) 
			between concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':', right(CONCAT('0',datepart(second, @fecha_inicio)),2))  And 
			concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))
			commit
	end try
	begin catch
		print 'algun error'
		rollback
		
	end catch
end

GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_ingreso_ventas]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [FAC].[sp_consulta_ingreso_ventas](
@cod_usuario varchar(30),
--@cod_empleado decimal(16,0),
@fecha_inicio varchar(30),
@fecha_fin varchar(30),
@flag BIT--,
--@monto_total decimal(16,0) output
)
as
begin
	begin tran
	begin try
		IF @flag = 0 BEGIN
			select isnull(sum(efectivo),0) 
			from FAC.orden_m as om
			inner join fac.factura_m as fm on fm.num_orden = om.num_orden
			INNER JOIN fac.factura_c AS fc ON fc.cod_usuario=@cod_usuario AND fc.num_factura=fm.num_factura
			/*se valida que sean del cajero en el momento*/
			--where om.cod_empleado = @cod_empleado and 
			/*se comparan la fecha, en la que a la factura se le realizo el pago, con las fecha de inicio y fin*/
			where om.ind_pago = 1 AND concat(datepart(year,fm.fecha_factura), '-', right(CONCAT('0',datepart(month, fm.fecha_factura)),2), '-', right(CONCAT('0',datepart(day, fm.fecha_factura)),2), ' ', right(CONCAT('0',datepart(HOUR, fm.fecha_factura)),2), ':',right(CONCAT('0',datepart(minute, fm.fecha_factura)),2), ':', right(CONCAT('0',datepart(second, fm.fecha_factura)),2)) 
			between concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':', right(CONCAT('0',datepart(second, @fecha_inicio)),2))  And 
			concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))
			commit
		END
		ELSE
		BEGIN
			select isnull(sum(tarjeta),0) 
			from FAC.orden_m as om
			inner join fac.factura_m as fm on fm.num_orden = om.num_orden
			INNER JOIN fac.factura_c AS fc ON fc.cod_usuario=@cod_usuario AND fc.num_factura=fm.num_factura
			/*se valida que sean del cajero en el momento*/
			--where om.cod_empleado = @cod_empleado and 
			/*se comparan la fecha, en la que a la factura se le realizo el pago, con las fecha de inicio y fin*/
			where om.ind_pago = 1 AND concat(datepart(year,fm.fecha_factura), '-', right(CONCAT('0',datepart(month, fm.fecha_factura)),2), '-', right(CONCAT('0',datepart(day, fm.fecha_factura)),2), ' ', right(CONCAT('0',datepart(HOUR, fm.fecha_factura)),2), ':',right(CONCAT('0',datepart(minute, fm.fecha_factura)),2), ':', right(CONCAT('0',datepart(second, fm.fecha_factura)),2)) 
			between concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':', right(CONCAT('0',datepart(second, @fecha_inicio)),2))  And 
			concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))
			commit
		END
	end try
	begin catch
		print 'algun error'
		rollback
	end catch
end
GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_introducciones_salidas]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_consulta_introducciones_salidas](
@cod_usuario varchar(30),
@fecha_inicio varchar(30),
@fecha_fin varchar(30),
@movimiento int
)
as
begin
begin tran
	begin try
		select isnull(sum(subtotal),0) 
		from FAC.intro_sale as insa 
		where insa.cod_usuario = @cod_usuario and 
			concat(datepart(year,insa.fecha), '-', right(CONCAT('0',datepart(month, insa.fecha)),2), '-', right(CONCAT('0',datepart(day, insa.fecha)),2), ' ', right(CONCAT('0',datepart(HOUR, insa.fecha)),2), ':',right(CONCAT('0',datepart(minute, insa.fecha)),2), ':', right(CONCAT('0',datepart(second, insa.fecha)),2)) 
		between concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':', right(CONCAT('0',datepart(second, @fecha_inicio)),2))  And 
		concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))
			--insa.fecha between convert(datetime, @fecha_inicio) and convert(datetime,@fecha_fin)
			and insa.tipo_evento = @movimiento
		commit
		return 1
	end try
	begin catch
		PRINT 'ERROR'
		ROLLBACK
		RETURN 0
	end catch
end

GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_montos_factura]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_consulta_montos_factura](
@num_factura decimal(5,0)
)
as
begin
declare 
	@SubTotal decimal(16,2),
	@descuento decimal(16,2),
	@porcentaje_descuento decimal(16,2),
	@num_orden decimal(16,0),
	@imp_ventas decimal(12,2),
	@imp_serv decimal(12,2),
	@total decimal (16,2)
begin tran
begin try
	-- se obtiene el numero de orden
	select @num_orden = om.num_orden, @porcentaje_descuento = fm.descuento from fac.orden_m as om, fac.factura_m as fm where om.num_orden = fm.num_orden and fm.num_factura = @num_factura
	
	-- se obtiene el subtotal a pagar
	set @SubTotal = (select sum(fd.sub_total) from fac.factura_d as fd where fd.num_factura = @num_factura)
	
	-- se asigna el valor del descuento, imnpesto de ventas y el impuesto de servicio
	select @descuento  = (@SubTotal * (@porcentaje_descuento/100)), @imp_ventas = om.impvtas,@imp_serv = om.impserv from fac.orden_m as om where om.num_orden = @num_orden and (om.ind_pago = 1 or om.ind_pago = 0)
	
	-- se asigna el monto final
	set @total = (@SubTotal - @descuento + @imp_serv + @imp_ventas) 
	-- se muestran los datos
	select @num_factura AS Num_factura ,@SubTotal as SubTotal, @descuento as Descuento, @imp_ventas as Imp_Ventas, @imp_serv as Imp_Servicio, @total as Total
	
	commit
End Try
begin catch
	PRINT 'ERROR'
	ROLLBACK
End Catch
End

GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_pago_facturas]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_consulta_pago_facturas](
@cod_usuario varchar(30),
@fecha_inicio varchar(30),
@fecha_fin varchar(30),
@monto_total decimal(16,0) output
)
as
begin
begin tran
begin try
		Select @monto_total = isnull(sum(monto_factura),0) 
		from FAC.pago_facturas As pf
		where pf.cod_usuario = @cod_usuario and 
		concat(datepart(year,pf.fecha_pago), '-', right(CONCAT('0',datepart(month, pf.fecha_pago)),2), '-', right(CONCAT('0',datepart(day, pf.fecha_pago)),2), ' ', right(CONCAT('0',datepart(HOUR, pf.fecha_pago)),2), ':',right(CONCAT('0',datepart(minute, pf.fecha_pago)),2), ':', right(CONCAT('0',datepart(second, pf.fecha_pago)),2)) 
		between concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':', right(CONCAT('0',datepart(second, @fecha_inicio)),2))  And 
		concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))	
			--pf.fecha_pago between convert(datetime, @fecha_inicio) and convert(datetime,@fecha_fin)
		commit
Return @monto_total
	End Try
begin catch
		PRINT 'ERROR'
ROLLBACK
Return @monto_total
	End Catch
End


GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_reporte_express]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_consulta_reporte_express](
@cod_usuario varchar(30),
@fecha_inicio varchar(30),
@fecha_fin varchar(30)
)
AS
BEGIN
	BEGIN TRAN
	BEGIN TRY
				--fecha, empleado, cliente, efectivo, ubicacion venta, salonero
		SELECT fm.fecha_factura, OM.num_orden, CONCAT(em.nombre, ' ', em.apellido1) AS Cajero, CONCAT(cl.nombre_cliente, ' ', cl.apellido) AS Cliente, om.direccion, om.telefono, om.express
		FROM FAC.orden_m as om
		INNER JOIN fac.factura_m AS fm ON fm.num_orden = om.num_orden
		INNER JOIN RRHH.empleados AS em ON em.cod_usuario = @cod_usuario
		INNER JOIN FAC.clientes AS cl ON cl.cod_cliente = om.cod_cliente
		INNER JOIN fac.factura_c AS fc ON fc.cod_usuario=@cod_usuario AND fc.num_factura=fm.num_factura
		/*se valida que sean del cajero en el momento*/
		WHERE om.ubicacion = 'E' AND
		/*se comparan la fecha, en la que a la factura se le realizo el pago, con las fecha de inicio y fin*/
		concat(datepart(year,fm.fecha_factura), '-', right(CONCAT('0',datepart(month, fm.fecha_factura)),2), '-', right(CONCAT('0',datepart(day, fm.fecha_factura)),2), ' ', right(CONCAT('0',datepart(HOUR, fm.fecha_factura)),2), ':',right(CONCAT('0',datepart(minute, fm.fecha_factura)),2), ':', right(CONCAT('0',datepart(second, fm.fecha_factura)),2)) 
		BETWEEN concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':', right(CONCAT('0',datepart(second, @fecha_inicio)),2))  And 
		concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))
		COMMIT
	END TRY
	BEGIN CATCH
		print 'algun error'
		ROLLBACK
	END CATCH
END

GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_reporte_fondos]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [FAC].[sp_consulta_reporte_fondos](
	--@cod_usuario_asigna varchar(30),
	@cod_usuario_recibe VARCHAR(30),
	@fecha_inicio VARCHAR(30),
	@fecha_fin VARCHAR(30),
	-- bandera. Si es 1 es para fondo inicial, si es 0 es para fondo final
	@movimiento INT
	)
	AS
	BEGIN
	DECLARE @reporte VARCHAR(70)
	BEGIN TRAN
		BEGIN TRY
			-- cantidad fondo final
			IF @movimiento > 0 BEGIN
				SET @reporte = 'Reporte del desgloce del Fondo Final'
				SELECT @reporte AS Reporte,CONCAT(em.nombre, ' ', em.apellido1) AS Recibe, /*concat(emp.nombre, ' ', emp.apellido1),*/ 
				fd.fecha, 'Colones' AS Moneda, mo.desc_moneda, fd.cantidad_cierre , fd.subtotal_cierre 
				FROM FAC.flujocaja_d AS fd
				INNER JOIN RRHH.empleados AS em ON fd.cod_usuario_asigna = em.cod_usuario
				--INNER JOIN RRHH.empleados AS emp ON fd.cod_usuario_recibe = emp.cod_usuario
				INNER JOIN FAC.monedas AS mo ON fd.cod_moneda = mo.cod_moneda
				WHERE fd.cod_usuario_recibe = @cod_usuario_recibe
				AND 
				concat(datepart(year,fd.fecha), '-', right(CONCAT('0',datepart(month, fd.fecha)),2), '-', right(CONCAT('0',datepart(day, fd.fecha)),2), ' ', right(CONCAT('0',datepart(HOUR, fd.fecha)),2), ':',right(CONCAT('0',datepart(minute, fd.fecha)),2), ':', right(CONCAT('0',datepart(second, fd.fecha)),2)) 
				between concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':', right(CONCAT('0',datepart(second, @fecha_inicio)),2))  And 
				concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))	
				--order by mo.valor
				--fd.fecha BETWEEN convert(datetime,@fecha_inicio) AND convert(datetime,@fecha_fin)
				ORDER BY mo.valor ASC
			END
			-- cantidad fondo inicial
			ELSE
			BEGIN
				SET @reporte = 'Reporte del desgloce del Fondo Inicial'
				SELECT @reporte AS Reporte,CONCAT(em.nombre, ' ', em.apellido1) AS Recibe, /*concat(emp.nombre, ' ', emp.apellido1),*/ 
				fd.fecha, 'Colones' AS Moneda, mo.desc_moneda, fd.cantidad , fd.subtotal 
				FROM FAC.flujocaja_d AS fd
				INNER JOIN RRHH.empleados AS em ON fd.cod_usuario_asigna = em.cod_usuario
				--INNER JOIN RRHH.empleados AS emp ON fd.cod_usuario_recibe = emp.cod_usuario
				INNER JOIN FAC.monedas AS mo ON fd.cod_moneda = mo.cod_moneda
				WHERE fd.cod_usuario_recibe = @cod_usuario_recibe
				AND concat(datepart(year,fd.fecha), '-', right(CONCAT('0',datepart(month, fd.fecha)),2), '-', right(CONCAT('0',datepart(day, fd.fecha)),2), ' ', right(CONCAT('0',datepart(HOUR, fd.fecha)),2), ':',right(CONCAT('0',datepart(minute, fd.fecha)),2), ':', right(CONCAT('0',datepart(second, fd.fecha)),2)) 
				between concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':', right(CONCAT('0',datepart(second, @fecha_inicio)),2))  And 
				concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))	
				--fd.fecha BETWEEN convert(datetime,@fecha_inicio) AND convert(datetime,@fecha_fin)
				ORDER BY mo.valor ASC
			END
			COMMIT
		END TRY
		BEGIN CATCH
			PRINT 'ERROR'
			ROLLBACK
		END CATCH
	END



GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_reporte_intro_sale]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_consulta_reporte_intro_sale](
--@cod_usuario_asigna varchar(30),
@cod_usuario_recibe varchar(30),
@fecha_inicio varchar(30),
@fecha_fin varchar(30),
@movimiento int
)
as
begin
declare @reporte varchar(55)
begin tran
	begin try

		if @movimiento = 0
		begin
			set @reporte = 'Reporte de Introducciones de efectivo'
		end
		else
		begin
			set @reporte = 'Reporte de Salidas de efectivo'
		end

		SELECT @reporte as Reporte, insa.fecha, mo.desc_moneda, insa.cantidad, insa.subtotal,  insa.tipo_cambio
		FROM FAC.intro_sale AS insa
		INNER JOIN fac.monedas AS mo ON insa.cod_moneda = mo.cod_moneda
		WHERE (insa.cod_usuario = @cod_usuario_recibe AND insa.tipo_evento = @movimiento 
		--AND insa.fecha BETWEEN convert(datetime,@fecha_inicio) AND convert(datetime,@fecha_fin))
		AND
		concat(datepart(year,insa.fecha), '-', right(CONCAT('0',datepart(month, insa.fecha)),2), '-', right(CONCAT('0',datepart(day, insa.fecha)),2), ' ', right(CONCAT('0',datepart(HOUR, insa.fecha)),2), ':',right(CONCAT('0',datepart(minute, insa.fecha)),2), ':', right(CONCAT('0',datepart(second, insa.fecha)),2)) 
			BETWEEN concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':', right(CONCAT('0',datepart(second, @fecha_inicio)),2))  And 
			concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))
		)
		order by mo.valor asc
		COMMIT
	End Try
	begin catch
		PRINT 'ERROR'
		ROLLBACK
	End Catch
End

GO
/****** Object:  StoredProcedure [FAC].[sp_consulta_reporte_ventas]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [FAC].[sp_consulta_reporte_ventas](
@cod_usuario varchar(30),
@cod_empleado decimal(16,0),
@fecha_inicio varchar(30),
@fecha_fin varchar(30),
@flag BIT
)
as
begin
	declare @reporte varchar(55)
	begin tran
	begin try
		IF @flag = 0 BEGIN
			set @reporte = 'Reporte de Ventas en efectivo'
				  --fecha, empleado, cliente, efectivo, ubicacion venta, salonero
			SELECT @reporte AS Reporte, om.num_orden, om.fecha, CONCAT(em.nombre, ' ', em.apellido1) AS Cajero, CONCAT(cl.nombre_cliente, ' ', cl.apellido) AS Cliente, om.ubicacion, om.efectivo AS Monto, CONCAT(sal.nombre, ' ', sal.apellido1) AS Salonero
			FROM FAC.orden_m as om
			INNER JOIN fac.factura_m AS fm ON fm.num_orden = om.num_orden
			INNER JOIN RRHH.empleados AS em ON em.cod_usuario = @cod_usuario AND em.cod_empleado = @cod_empleado
			INNER JOIN FAC.clientes AS cl ON cl.cod_cliente = om.cod_cliente
			INNER JOIN RRHH.empleados AS sal ON sal.cod_empleado = om.cod_salonero
			/*se valida que sean del cajero en el momento*/
			WHERE om.cod_empleado = @cod_empleado 
			/*se valida que tenga un valor para ser tomado en cuenta*/
			AND om.efectivo > 0
			/*se valida que sean ordenes canceladas o en proceso*/
			AND (om.ind_pago = 1 OR om.ind_pago = 0) AND
			/*se comparan la fecha, en la que a la factura se le realizo el pago, con las fecha de inicio y fin*/
			concat(datepart(year,fm.fecha_factura), '-', right(CONCAT('0',datepart(month, fm.fecha_factura)),2), '-', right(CONCAT('0',datepart(day, fm.fecha_factura)),2), ' ', right(CONCAT('0',datepart(HOUR, fm.fecha_factura)),2), ':',right(CONCAT('0',datepart(minute, fm.fecha_factura)),2), ':', right(CONCAT('0',datepart(second, fm.fecha_factura)),2)) 
			BETWEEN concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':', right(CONCAT('0',datepart(second, @fecha_inicio)),2))  And 
			concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))
			commit
		END
		ELSE
		BEGIN
			set @reporte = 'Reporte de Ventas con tarjetas'
			SELECT @reporte AS Reporte, om.num_orden, om.fecha, CONCAT(em.nombre, ' ', em.apellido1) AS Cajero, CONCAT(cl.nombre_cliente, ' ', cl.apellido) AS Cliente, om.ubicacion, om.tarjeta AS Monto, CONCAT(sal.nombre, ' ', sal.apellido1) AS Salonero
			FROM FAC.orden_m as om
			INNER JOIN fac.factura_m AS fm ON fm.num_orden = om.num_orden
			INNER JOIN RRHH.empleados AS em ON em.cod_usuario = @cod_usuario AND em.cod_empleado = @cod_empleado
			INNER JOIN FAC.clientes AS cl ON cl.cod_cliente = om.cod_cliente
			INNER JOIN RRHH.empleados AS sal ON sal.cod_empleado = om.cod_salonero
			/*se valida que sean del cajero en el momento*/
			WHERE om.cod_empleado = @cod_empleado 
			/*se valida que tenga un valor para ser tomado en cuenta*/
			AND om.tarjeta > 0
			/*se valida que sean ordenes canceladas*/
			AND (om.ind_pago = 1 OR om.ind_pago = 0) AND
			/*se comparan la fecha, en la que a la factura se le realizo el pago, con las fecha de inicio y fin*/
			concat(datepart(year,fm.fecha_factura), '-', right(CONCAT('0',datepart(month, fm.fecha_factura)),2), '-', right(CONCAT('0',datepart(day, fm.fecha_factura)),2), ' ', right(CONCAT('0',datepart(HOUR, fm.fecha_factura)),2), ':',right(CONCAT('0',datepart(minute, fm.fecha_factura)),2), ':', right(CONCAT('0',datepart(second, fm.fecha_factura)),2)) 
			BETWEEN concat(datepart(year,@fecha_inicio), '-', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '-', right(CONCAT('0',datepart(day, @fecha_inicio)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_inicio)),2), ':',right(CONCAT('0',datepart(minute, @fecha_inicio)),2), ':', right(CONCAT('0',datepart(second, @fecha_inicio)),2))  And 
			concat(datepart(year,@fecha_fin), '-', right(CONCAT('0',datepart(month, @fecha_fin)),2), '-', right(CONCAT('0',datepart(day, @fecha_fin)),2), ' ', right(CONCAT('0',datepart(HOUR, @fecha_fin)),2), ':',right(CONCAT('0',datepart(minute, @fecha_fin)),2), ':', right(CONCAT('0',datepart(second, @fecha_fin)),2))
			commit
		END
	end try
	begin catch
		print 'algun error'
		rollback
	end catch
end

GO
/****** Object:  StoredProcedure [FAC].[sp_desgloce_fondo_final]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [FAC].[sp_desgloce_fondo_final](
	@fecha_consulta as datetime,
	@usuario as varchar(30),
	@moneda as decimal
) as
	/***********************************************************************
	Procedumiento almacenado: sp_desgloce_fondo_final
	Descripcion: Generar el registro de consulta del fondo final de cajas
	Programador: Jherom Steven Chacon Vega
	Fecha: 19 de Mayo del 2015
	************************************************************************/
	declare @fondo_inicial as numeric(12,2)
	declare @fondo_final as numeric(12,2)
	declare @ventas_brutas_efectivo as numeric(12,2) 
	declare @total_compras as numeric(12,2)
	declare @total_gastos as numeric(12,2)
	declare @total_salarios as numeric(12,2)
	declare @impuesto_servicio as numeric(12,2)
	declare @introducciones as numeric(12,2)
	declare @salidas as numeric(12,2)

	select @fondo_inicial = isnull(sum(b.subtotal),0),
		@fondo_final = isnull(sum(b.subtotal_cierre),0) 
	from FAC.flujocaja_m a inner join
	FAC.flujocaja_d b on a.cod_usuario_asigna = b.cod_usuario_asigna
		and a.cod_usuario_recibe = b.cod_usuario_recibe
		and a.fecha = b.fecha
		and a.tipo_moneda = b.tipo_moneda
	where datepart(day,a.fecha) = datepart(day,@fecha_consulta)
	and datepart(month,a.fecha) = datepart(month,@fecha_consulta)
	and datepart(year,a.fecha) = datepart(year,@fecha_consulta)
	and a.cod_usuario_recibe = @usuario
	and a.tipo_moneda = @moneda

	select @ventas_brutas_efectivo = isnull(sum(efectivo),0) 
	from FAC.orden_m a inner join
		RRHH.empleados b on a.cod_empleado = b.cod_empleado 
	where datepart(day,fecha) = datepart(day,@fecha_consulta)
	and datepart(month,fecha) = datepart(month,@fecha_consulta)
	and datepart(year,fecha) = datepart(year,@fecha_consulta)
	and b.cod_usuario = @usuario

	select @impuesto_servicio = isnull(sum(impserv),0) 
	from FAC.orden_m a inner join
		RRHH.empleados b on a.cod_empleado = b.cod_empleado
	where datepart(day,fecha) = datepart(day,@fecha_consulta)
	and datepart(month,fecha) = datepart(month,@fecha_consulta)
	and datepart(year,fecha) = datepart(year,@fecha_consulta)
	and b.cod_usuario = @usuario

	select @introducciones = isnull(sum(subtotal),0) 
	from FAC.intro_sale
	where datepart(day,fecha) = datepart(day,@fecha_consulta)
	and datepart(month,fecha) = datepart(month,@fecha_consulta)
	and datepart(year,fecha) = datepart(year,@fecha_consulta) 
	and tipo_evento = 0
	and cod_usuario = @usuario

	select @salidas = isnull(sum(subtotal),0) 
	from FAC.intro_sale
	where datepart(year,fecha) = datepart(year,@fecha_consulta)
	and datepart(month,fecha) = datepart(month,@fecha_consulta)
	and datepart(day,fecha) = datepart(day,@fecha_consulta)
	and tipo_evento = 1
	and cod_usuario = @usuario

	select @total_compras = isnull(sum(a.monto),0) 
	from PRO.compgast a inner join
		PRO.compgast_d b on a.cod_proveedor = b.cod_proveedor and 
			a.num_factura = b.num_factura inner join
		PRO.compgast_pago c on b.cod_proveedor = c.cod_proveedor and 
			b.num_factura = c.num_factura and 
			b.cod_material = c.cod_material and 
			b.num_linea = c.num_linea
	where datepart(day,a.fecha) = datepart(day,@fecha_consulta)
	and datepart(month,a.fecha) = datepart(month,@fecha_consulta)
	and datepart(year,a.fecha) = datepart(year,@fecha_consulta)
	and c.cod_usuario = @usuario
	and tipo = 1;

	select @total_gastos = isnull(sum(a.monto),0) 
	from PRO.compgast a inner join
		PRO.compgast_d b on a.cod_proveedor = b.cod_proveedor and 
			a.num_factura = b.num_factura inner join
		PRO.compgast_pago c on b.cod_proveedor = c.cod_proveedor and 
			b.num_factura = c.num_factura and 
			b.cod_material = c.cod_material and 
			b.num_linea = c.num_linea
	where datepart(day,a.fecha) = datepart(day,@fecha_consulta)
	and datepart(month,a.fecha) = datepart(month,@fecha_consulta)
	and datepart(year,a.fecha) = datepart(year,@fecha_consulta)
	and c.cod_usuario = @usuario
	and tipo = 2;

	select @total_salarios = isnull(sum(a.monto),0) 
	from PRO.compgast a inner join
		PRO.compgast_d b on a.cod_proveedor = b.cod_proveedor and 
			a.num_factura = b.num_factura inner join
		PRO.compgast_pago c on b.cod_proveedor = c.cod_proveedor and 
			b.num_factura = c.num_factura and 
			b.cod_material = c.cod_material and 
			b.num_linea = c.num_linea
	where datepart(day,a.fecha) = datepart(day,@fecha_consulta)
	and datepart(month,a.fecha) = datepart(month,@fecha_consulta)
	and datepart(year,a.fecha) = datepart(year,@fecha_consulta)
	and c.cod_usuario = @usuario
	and tipo = 3;

	select @fondo_inicial as total_fondo_inicial, 
	@fondo_final as total_fondo_final,
	@ventas_brutas_efectivo as total_ventas_brutas_efectivo, 
	@impuesto_servicio as total_impuesto_servicio,
	@introducciones as total_introducciones,
	@salidas as total_salidas,
	@total_compras as total_compras,
	@total_gastos as total_gastos,
	@total_salarios as total_salarios


GO
/****** Object:  StoredProcedure [FAC].[sp_eliminarOrden_m]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_eliminarOrden_m](
    @numeroOrden DECIMAL(16,0)
)AS
DECLARE @w_tran INT
IF @@TRANCOUNT <> 0
	BEGIN 
		COMMIT TRAN
		if @@ERROR <> 0
		BEGIN
			GOTO CONTINUAR
		END
		SELECT @w_tran = 1
	END
ELSE
	SELECT @w_tran = 0
	CONTINUAR:
	
    BEGIN TRAN eliminarOrden
	DELETE FROM fac.orden_d WHERE num_orden = @numeroOrden
	IF @@ERROR <> 0 
		BEGIN
			PRINT 'No se elimino el detalle de orden'
			ROLLBACK TRANSACTION eliminarOrden
		END
	DELETE FROM fac.orden_m WHERE num_orden = @numeroOrden
	IF @@ERROR <> 0 
		BEGIN
			PRINT 'No se elimino la orden'
			ROLLBACK TRANSACTION eliminarOrden
		END
	COMMIT TRANSACTION eliminarOrden

	IF @w_tran  = 1
		BEGIN TRAN


GO
/****** Object:  StoredProcedure [FAC].[sp_modifica_ind_pago_orden_m]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [FAC].[sp_modifica_ind_pago_orden_m](
    @num_orden decimal(16,0),
	@ind_pago decimal(1,0)
)AS
Declare @w_tran INT
If @@TRANCOUNT <> 0
	BEGIN 
		COMMIT TRAN
If @@ERROR <> 0
		BEGIN
GoTo CONTINUAR
End
Select @w_tran = 1
	End
Else
Select @w_tran = 0
	CONTINUAR:
    BEGIN TRAN actualizar_orden_m
	UPDATE FAC.orden_m SET ind_pago =@ind_pago
	WHERE num_orden=@num_orden
	IF @@ERROR <> 0 
		BEGIN
			PRINT 'No se pudo actualizar'
			ROLLBACK
		END
	COMMIT TRANSACTION actualizar_orden_m
	IF @w_tran  = 1
		BEGIN TRAN

--//****************************************************************************************//
--//****************************************************************************************//
--//****************************************************************************************//
--//*******************************ALMACENA FACTURA M***************************************//
--//****************************************************************************************//
--//****************************************************************************************//
--//****************************************************************************************//

/****** Object:  StoredProcedure [FAC].[sp_almacena_factura_d]    Script Date: 31/08/2016 03:13:30 p.m. ******/
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [RRHH].[sp_consulta_fondo_inicial_x_sesion_usuario]    Script Date: 19/09/2016 04:48:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [RRHH].[sp_consulta_fondo_inicial_x_sesion_usuario](
@cod_usuario varchar(30),
@fecha varchar(30)--,
--@fecha_inicial varchar(30) output
)
as
begin
	
		
	begin try
		-- selecciona de flujocaja_m para ver si hay alguna apertura de caja por parte del usuario a
		-- consultar durante cierta fecha
		select top 1 fecha from fac.flujocaja_m where estado_caja = 'A' and cod_usuario_recibe = @cod_usuario and
		-- compara la fecha por año, mes y dia
		concat(datepart(year,fecha), '-', right(CONCAT('0',datepart(month, fecha)),2), '-', right(CONCAT('0',datepart(day, fecha)),2))
		= concat(datepart(year,@fecha), '-', right(CONCAT('0',datepart(month, @fecha)),2), '-', right(CONCAT('0',datepart(day, @fecha)),2)) 
		-- se ordena de ultimo a primero. 
		order by fecha desc
		
		--return @fecha_inicial 
	end try
	begin catch
		print 'algun error'
		
		return 0
	end catch
end


GO
