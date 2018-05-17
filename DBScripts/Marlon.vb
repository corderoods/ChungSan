'GO
'  CREATE PROCEDURE FAC.sp_inserta_flujocaja_d(
'  @codigo_usuario_asigna VARCHAR(30),
'  @codigo_usuario_recibe VARCHAR(30),
'  @fecha DATETIME,
'  @tipo_moneda DECIMAL(5,0),
'  @cod_moneda DECIMAL(5,0),
'  @cantidad DECIMAL(5,0),
'  @subtotal DECIMAL(16,2),
'  @cantidad_cierre DECIMAL(5,0),
'  @subtotal_cierre DECIMAL(5,0)
'  )
'  AS
'  BEGIN TRAN
'BEGIN TRY
'		INSERT INTO FAC.flujocaja_d VALUES (@codigo_usuario_asigna, @codigo_usuario_recibe, @fecha, @tipo_moneda, @cod_moneda, @cantidad, @subtotal, @cantidad_cierre, @subtotal_cierre)
'		COMMIT
'End Try
'BEGIN CATCH
'		ROLLBACK
'End Catch; 




'USE [Restaurante_Produccion]
'GO
'/****** Object:  StoredProcedure [FAC].[sp_inserta_flujocaja_d]    Script Date: 16/08/2016 9:22:28 ******/
'Set ANSI_NULLS On
'GO
'Set QUOTED_IDENTIFIER On
'GO
'  ALTER PROCEDURE [FAC].[sp_inserta_flujocaja_d](
'  @codigo_usuario_asigna VARCHAR(30),
'  @codigo_usuario_recibe VARCHAR(30),
'  @fecha DATETIME,
'  @tipo_moneda DECIMAL(5,0),
'  @cod_moneda DECIMAL(5,0),
'  @cantidad DECIMAL(5,0),
'  @subtotal DECIMAL(16,2),
'  @cantidad_cierre DECIMAL(5,0),
'  @subtotal_cierre DECIMAL(5,0)
'  )
'  AS
'  BEGIN TRAN
'BEGIN TRY
'	--IF EXISTS (SELECT tipo_moneda FROM FAC.flujocaja_m WHERE cod_usuario_asigna = @codigo_usuario_asigna And cod_usuario_recibe = @codigo_usuario_recibe And tipo_moneda = @tipo_moneda And fecha = @fecha) BEGIN
'		--INSERT INTO FAC.flujocaja_d VALUES (@codigo_usuario_asigna, @codigo_usuario_recibe, @fecha, @tipo_moneda, @cod_moneda, @cantidad, @subtotal, @cantidad_cierre, @subtotal_cierre)
'	--END 
'	--ELSE
'	--BEGIN
'		--INSERT INTO FAC.flujocaja_m VALUES (@codigo_usuario_asigna, @codigo_usuario_recibe, @tipo_moneda, @fecha, 'A', /*TIPOCAMBIO*/ 0, 0, 1)
'		INSERT INTO FAC.flujocaja_d VALUES (@codigo_usuario_asigna, @codigo_usuario_recibe, @fecha, @tipo_moneda, @cod_moneda, @cantidad, @subtotal, @cantidad_cierre, @subtotal_cierre)
'		COMMIT
'	--END 

'		--INSERT INTO FAC.flujocaja_m VALUES (@codigo_usuario_asigna, @codigo_usuario_recibe, @tipo_moneda, @fecha, 'A', /*TIPOCAMBIO*/ 0, 0, 1)
'		--INSERT INTO FAC.flujocaja_d VALUES (@codigo_usuario_asigna, @codigo_usuario_recibe, @fecha, @tipo_moneda, @cod_moneda, @cantidad, @subtotal, @cantidad_cierre, @subtotal_cierre)

'		Return 1
'End Try
'BEGIN CATCH
'		ROLLBACK
'Return 0
'End Catch;

'	go
'	exec FAC.sp_inserta_flujocaja_d 'administrador', 'caja7' , '2016/08/08 16:06:40', 0, 7, 1, 5, 0,0


'Select Case* From FAC.flujocaja_d Where cod_usuario_asigna = 'administrador' and cod_usuario_recibe = 'caja2' order by fecha asc
'Select * From FAC.flujocaja_m Where cod_usuario_asigna = 'administrador' and cod_usuario_recibe = 'caja2' order by fecha asc

'Select Case* From FAC.flujocaja_d Where cod_usuario_asigna = 'administrador' and cod_usuario_recibe = 'caja2' order by fecha asc
'Select * From FAC.flujocaja_m Where cod_usuario_asigna = 'administrador' and cod_usuario_recibe = 'caja2' order by fecha asc
'Select * From FAC.flujocaja Order By fecha asc
'Select * From FAC.intro_sale

'delete FAC.flujocaja_d where cod_usuario_asigna = 'administrador' and cod_usuario_recibe = 'caja2'
'delete FAC.flujocaja_m where cod_usuario_asigna = 'administrador' and cod_usuario_recibe = 'caja2'





'GO
'  CREATE PROCEDURE FAC.sp_inserta_flujocaja_m(
'  @codigo_usuario_asigna VARCHAR(30),
'  @codigo_usuario_recibe VARCHAR(30),
'  @tipo_moneda DECIMAL(16,2),
'  @fecha DATETIME,
'  @estado_caja VARCHAR(1),
'  @tipo_cambio DECIMAL(16,2),
'  @aprobada DECIMAL(5,0),
'  @asignado INTEGER
'  )
'  AS
'  BEGIN TRAN
'BEGIN TRY
'		INSERT INTO FAC.flujocaja_M VALUES (@codigo_usuario_asigna, @codigo_usuario_recibe, @tipo_moneda,@fecha, @estado_caja, @tipo_cambio, @aprobada, @asignado)
'		--INSERT INTO FAC.flujocaja_M VALUES (@codigo_usuario_asigna, @codigo_usuario_recibe, @tipo_moneda,@fecha, @estado_caja, @tipo_cambio, 'A', 1)
'		COMMIT
'End Try
'BEGIN CATCH
'		ROLLBACK
'End Catch; 



'USE [Restaurante_Produccion]
'GO
'/****** Object:  StoredProcedure [FAC].[sp_inserta_intro_sale]    Script Date: 16/08/2016 9:51:03 ******/
'Set ANSI_NULLS On
'GO
'Set QUOTED_IDENTIFIER On
'GO
'  ALTER PROCEDURE [FAC].[sp_inserta_intro_sale](
'  @cod_usuario VARCHAR(30), 
'  @fecha DATETIME,
'  @cod_moneda DECIMAL(5,0),
'  @cantidad DECIMAL(8,0),
'  @subtotal DECIMAL(16,2), 
'  @tipo_moneda DECIMAL(8,0),
'  @tipo_cambio DECIMAL(16,2),
'  @pass_user VARCHAR(8),
'  @aprobado DECIMAL(8),
'  @tipo_evento DECIMAL(5,0)
'  )
'  AS
'  BEGIN TRAN
'BEGIN TRY
'		If EXISTS(SELECT * FROM RRHH.usuarios AS us WHERE us.cod_usuario = @cod_usuario And us.contrasena = @pass_user)
'BEGIN
'			INSERT INTO FAC.intro_sale VALUES (@cod_usuario, @fecha, @cod_moneda, @cantidad, @subtotal, @tipo_moneda, @tipo_cambio,@pass_user,@aprobado,@tipo_evento)
'			COMMIT
'Return 1
'End
'Else
'BEGIN
'ROLLBACK
'Return 0
'			--PRINT 'ERROR'
'		End
'End Try
'BEGIN CATCH
'		ROLLBACK
'Return 0
'End Catch;
'	GO




'CREATE TABLE FAC.pago_facturas (
'cod_usuario VARCHAR(30) Not NULL,
'fecha_pago DATETIME Not NULL,
'concepto VARCHAR(60) Not NULL,
'cod_proveedor Decimal(10, 0) Not NULL,
'tipo VARCHAR(30) Not NULL,
'fecha_factura DATETIME Not NULL,
'num_factura Decimal(16, 2) Not NULL,
'monto_factura Decimal(16, 2) Not NULL,
'elemento VARCHAR(25) Not NULL,
'observaciones TEXT NULL
'CONSTRAINT [PK_pago_factura] PRIMARY KEY CLUSTERED 
'(
'	cod_usuario ASC,
'    fecha_pago ASC,
'    cod_proveedor ASC,
'    num_factura ASC
')WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
') ON [PRIMARY]

'ALTER TABLE [FAC].pago_facturas With CHECK ADD CONSTRAINT [fk_pago_facturas_usuario]
'FOREIGN KEY([cod_usuario])
'REFERENCES [RRHH].[usuarios] (cod_usuario)
'GO
'ALTER TABLE [FAC].pago_facturas CHECK CONSTRAINT [fk_pago_facturas_usuario]
'GO
'ALTER TABLE [FAC].pago_facturas With CHECK ADD CONSTRAINT [fk_pago_facturas_proveedor]
'FOREIGN KEY([cod_proveedor])
'REFERENCES [PRO].[proveedores] (cod_proveedor)
'GO
'ALTER TABLE [FAC].pago_facturas CHECK CONSTRAINT [fk_pago_facturas_proveedor]
'GO




'CREATE TABLE FAC.pago_facturas (
'fecha_pago DATETIME Not NULL,
'concepto VARCHAR(60) Not NULL,
'cod_proveedor Decimal(10, 0) Not NULL,
'tipo VARCHAR(30) Not NULL,
'fecha_factura DATETIME Not NULL,
'num_factura Decimal(16, 2) Not NULL,
'monto_factura Decimal(16, 2) Not NULL,
'elemento VARCHAR(25) Not NULL,
'observaciones TEXT NULL
'CONSTRAINT [PK_pago_factura] PRIMARY KEY CLUSTERED 
'(
'	fecha_pago ASC,
'    cod_proveedor ASC,
'	num_factura ASC
')WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
') ON [PRIMARY]

'ALTER TABLE [FAC].pago_facturas With CHECK ADD CONSTRAINT [fk_pago_facturas_proveedor]
'FOREIGN KEY([cod_proveedor])
'REFERENCES [PRO].[proveedores] (cod_proveedor)
'GO
'ALTER TABLE [FAC].pago_facturas CHECK CONSTRAINT [fk_pago_facturas_proveedor]
'GO


'Set ANSI_NULLS On
'GO
'Set QUOTED_IDENTIFIER On
'GO
'  CREATE PROCEDURE [FAC].[sp_inserta_pago_facturas](
'	@cod_usuario VARCHAR(30),
'	@fecha_pago DATETIME,
'	@concepto VARCHAR(60),
'	@cod_proveedor DECIMAL(10,0),
'	@tipo VARCHAR(30),
'	@fecha_factura DATETIME,
'	@num_factura DECIMAL(16,2),
'	@monto_factura DECIMAL(16,2),
'	@elemento VARCHAR(25),
'	@observaciones TEXT
'  )
'  AS
'  BEGIN TRAN
'BEGIN TRY
'		INSERT INTO FAC.pago_facturas VALUES (@cod_usuario, @fecha_pago, @concepto, @cod_proveedor, @tipo, @fecha_factura, @num_factura, @monto_factura,@elemento,@observaciones)
'		COMMIT
'Return 1
'End Try
'BEGIN CATCH
'		ROLLBACK
'Return 0
'End Catch;




'Select Case sum(fd.subtotal) As Total from FAC.orden_d As fd
'inner join FAC.orden_m As fm On fm.num_orden = fd.num_orden
'where fm.cod_empleado = 110240075 And fm.fecha between convert(datetime,'25/06/2016 12:15:00') and convert(datetime,'25/06/2016 12:16:00')


'110240075
'112345678




'Select Case sum(subtotal) As total from FAC.orden_d   --where num_orden = 100


'Select Case sum(fd.subtotal) As Total from FAC.orden_d As fd
'inner join FAC.orden_m As fm On fm.num_orden = fd.num_orden
'where fm.cod_empleado = 110240075

'Select Case sum(fd.subtotal) As Total from FAC.orden_d As fd
'inner join FAC.orden_m As fm On fm.num_orden = fd.num_orden
'where fm.cod_empleado = 110240075 And fm.fecha between convert(datetime,'25/06/2016 12:15:00') and convert(datetime,'25/06/2016 12:16:00')

'Select Case convert(datetime,'11/08/2016 11:46:00')

'Select Case* From FAC.orden_m as fm Where fm.cod_empleado = 110240075
'             Select count(*)
'             From FAC.orden_m as fm 
'Where fm.cod_empleado = 110240075













'go
'create procedure sp_consulta_ingresos_efectivos(
'@cod_usuario varchar(30),
'@cod_empleado decimal(16,0),
'--@fecha_inicio datetime,
'@fecha_fin datetime
')
'as
'Declare 
'@fecha_inicio datetime
'/*@total decimal(5,0),
'@impserv decimal(5,0),
'@total_efectivo decimal(5,0),
'@subtotal decimal(5,0)
'*/begin
'	begin tran
'begin try
'		/*set @total = (select sum(mto_total) from [FAC].[factura_m] as fm, FAC.orden_m as om
'		where om.cod_empleado = 110240075 And fm.num_orden = om.num_orden
'		And om.fecha between convert(datetime,'25/06/2016 22:34:00') and convert(datetime,'25/06/2016 22:34:00'))
'		*/

'		/*se toma la fecha y hora del cajero cyando realizo la apertura de caja*/
'			Set @fecha_inicio = (Select fecha from FAC.flujocaja_m 
'			where cod_usuario_recibe = @cod_usuario And estado_caja = 'A')
'		/*muestra lo que se pago en orden_m con efectivo*/

'		/*set @total_efectivo = */


'			(select sum(efectivo) from FAC.orden_m as om
'			where om.cod_empleado = @cod_empleado And 
'			om.fecha between @fecha_inicio And @fecha_fin)
'			commit
'End Try
'begin catch
'		print 'algun error'
'rollback
'End Catch
'End

'exec sp_consulta_ingresos_efectivos 'caja3', 110240075, '25/06/2016 22:34:00'





'go
'create procedure sp_consulta_ingresos_tarjetas(
'@cod_usuario varchar(30),
'@cod_empleado decimal(16,0),
'--@fecha_inicio datetime,
'@fecha_fin datetime
')
'as
'Declare 
'@fecha_inicio datetime
'/*@total decimal(5,0),
'@impserv decimal(5,0),
'@total_efectivo decimal(5,0),
'@subtotal decimal(5,0)
'*/begin
'	begin tran
'begin try
'		/*set @total = (select sum(mto_total) from [FAC].[factura_m] as fm, FAC.orden_m as om
'		where om.cod_empleado = 110240075 And fm.num_orden = om.num_orden
'		And om.fecha between convert(datetime,'25/06/2016 22:34:00') and convert(datetime,'25/06/2016 22:34:00'))
'		*/

'		/*se toma la fecha y hora del cajero cyando realizo la apertura de caja*/
'			Set @fecha_inicio = (Select fecha from FAC.flujocaja_m 
'			where cod_usuario_recibe = @cod_usuario And estado_caja = 'A')
'		/*muestra lo que se pago en orden_m con efectivo*/

'		/*set @total_efectivo = */


'			(select sum(tarjeta) from FAC.orden_m as om
'			where om.cod_empleado = @cod_empleado And 
'			om.fecha between @fecha_inicio And convert(datetime,@fecha_fin))
'			commit
'End Try
'begin catch
'		print 'algun error'
'rollback
'End Catch
'End

'exec sp_consulta_ingresos_tarjetas 'caja3', 110240075, '25/06/2016 22:34:00'



'****************************************************************
'*******************pruebas*************************************

'/*prueba datos en la base*/
'create procedure sp_consulta_ingresos_efectivos2(
'@cod_usuario varchar(30),
'@cod_empleado decimal(16,0),
'@fecha_inicio datetime,
'@fecha_fin datetime
')
'as
'begin
'	begin tran
'begin try

'			(select sum(tarjeta) from FAC.orden_m as om
'			where om.cod_empleado = @cod_empleado And 
'			om.fecha between convert(datetime, @fecha_inicio) And convert(datetime,@fecha_fin))
'			commit
'End Try
'begin catch
'		print 'algun error'
'rollback
'End Catch
'End

'exec sp_consulta_ingresos_efectivos2 'caja3', 110240075, '25/06/2016 22:34:00','25/06/2016 23:34:00'




'/*prueba datos en la base*/
'USE [Restaurante_V4_Produccion]
'GO
'/****** Object:  StoredProcedure [dbo].[sp_consulta_ingresos_tarjeta2]    Script Date: 16/08/2016 14:53:51 ******/
'Set ANSI_NULLS On
'GO
'Set QUOTED_IDENTIFIER On
'GO
'/*prueba datos en la base*/
'create procedure [FAC].[sp_consulta_ingresos_tarjeta2](
'@cod_usuario varchar(30),
'@cod_empleado decimal(16,0),
'@fecha_inicio datetime,
'@fecha_fin datetime,
'@monto_total decimal(16,0) output
')
'as
'begin
'	begin tran
'begin try

'			Select Case@monto_total = (select sum(tarjeta) from FAC.orden_m as om
'			where om.cod_empleado = @cod_empleado And 
'			om.fecha between convert(datetime, @fecha_inicio) And convert(datetime,@fecha_fin))
'			commit
'Return @monto_total
'	End Try
'begin catch
'		print 'algun error'
'rollback
'Return @monto_total
'	End Catch
'End

'exec sp_consulta_ingresos_tarjeta2 'caja3', 110240075, '25/06/2016 22:34:00','25/06/2016 23:34:00'
'*****************************************************************************************
'USE [Restaurante_V4_Produccion]
'Declare @a decimal(16,0)
'Declare @FECHA DATETIME
'Set @FECHA = CONVERT(DATETIME, GETDATE())
'exec FAC.sp_consulta_ingresos_tarjeta2 'caja3', 112345678, '26/07/2016 22:59:00', @FECHA,@monto_total=@a output
'Select @a
'*****************************************************************************************



''go
'CREATE PROCEDURE FAC.sp_consulta_introducciones_salidas(
'@cod_usuario varchar(30),
'@fecha_inicio datetime,
'@fecha_fin datetime,
'@movimiento int,
'@monto_total decimal(16,0) output
')
'as
'begin
'begin tran
'begin try
'		Select Case@monto_total = (select sum(subtotal) 
'		from FAC.intro_sale As insa 
'		where insa.cod_usuario = @cod_usuario And 
'			insa.fecha between convert(datetime, @fecha_inicio) And convert(datetime,@fecha_fin)
'			And insa.tipo_evento = @movimiento)
'		commit
'Return @monto_total
'	End Try
'begin catch
'		PRINT 'ERROR'
'ROLLBACK
'Return @monto_total
'	End Catch
'End

'Declare @fechaI datetime
'Declare @fechaF datetime
'	Select Case@fechaI = convert(datetime,'Ago 16 2016 11:14AM')
'	Select Case@fechaF = convert(datetime,'Ago 16 2016 11:22AM')

'	print @fechaI
'	print @fechaF
'	--exec [FAC].[sp_inserta_intro_sale] 'TITA', @fechaI,1,2,200,0,0,'TITA1079',0,0

'EXEC sp_consulta_introducciones_salidas 'TITA', @fechaI, @fechaF, 0

'Select Case sum(subtotal) from FAC.intro_sale where tipo_evento = 0





'go
'CREATE PROCEDURE FAC.sp_consulta_fondo_inicial(
'@cod_usuario_asigna varchar(30),
'@cod_usuario_recibe varchar(30),
'@fecha_inicio datetime,
'@fecha_fin datetime,
'--@movimiento int,
'@monto_total decimal(16,0) output
')
'as
'begin
'begin tran
'begin try
'		Select Case@monto_total = (select sum(subtotal) 
'		from FAC.flujocaja_d As fd, FAC.flujocaja_m As fm
'		--usuarios
'		where fd.cod_usuario_recibe = @cod_usuario_recibe And fd.cod_usuario_asigna = @cod_usuario_asigna And
'			--fechas
'			fd.fecha between convert(datetime, @fecha_inicio) And convert(datetime,@fecha_fin)
'			--estado caja
'			And fm.estado_caja = 'A' and
'			--join
'			fd.cod_usuario_asigna = fm.cod_usuario_asigna And fd.cod_usuario_recibe = fm.cod_usuario_recibe And fd.fecha = fm.fecha
'			)
'		commit
'Return @monto_total
'	End Try
'begin catch
'		PRINT 'ERROR'
'ROLLBACK
'Return @monto_total
'	End Catch
'End

'Declare @fechaI datetime
'	Declare @fechaF datetime
'	Select Case Case@fechaI = convert(datetime,'Jul 26 2016 11:14AM')
'	Select Case Case@fechaF = convert(datetime,getdate())

'	--exec [FAC].[sp_inserta_intro_sale] 'TITA', @fechaI,1,2,200,0,0,'TITA1079',0,0
'	Declare @a decimal(16,0)
'--EXEC fac.sp_consulta_introducciones_salidas 'TITA', @fechaI, @fechaF, 0, @monto_total=@a output
'--select @a

'exec FAC.sp_consulta_fondo_inicial 'administrador','caja2', @fechaI, @fechaF, @monto_total=@a output
'Select Case Case@a


'delete select sum(subtotal) from FAC.flujocaja_d where cod_usuario_asigna = 'administrador' and cod_usuario_recibe = 'caja2'
'delete FAC.flujocaja_m where cod_usuario_asigna = 'administrador' and cod_usuario_recibe = 'caja2'



'go
'CREATE PROCEDURE FAC.sp_consulta_fondo_inicial(
'@cod_usuario_asigna varchar(30),
'@cod_usuario_recibe varchar(30),
'@fecha_inicio datetime,
'@fecha_fin datetime,
'--@movimiento int,
'@monto_total decimal(16,0) output
')
'as
'begin
'begin tran
'begin try
'		Select Case@monto_total = isnull(sum(subtotal),0) 
'		from FAC.flujocaja_d As fd
'		inner join FAC.flujocaja_m As fm On fd.cod_usuario_asigna = fm.cod_usuario_asigna 
'		And fd.cod_usuario_recibe = fm.cod_usuario_recibe 
'		And fd.fecha = fm.fecha
'		And fd.tipo_moneda = fm.tipo_moneda

'		--usuarios
'		where fd.cod_usuario_recibe = @cod_usuario_recibe 
'		And fd.cod_usuario_asigna = @cod_usuario_asigna 
'		And
'		/*se construyen las fechas con solo año, mes y dia */
'		concat(datepart(year, fd.fecha), '/', right(CONCAT('0',datepart(month, fd.fecha)),2), '/', right(CONCAT('0',datepart(day, fd.fecha)),2)) 
'        between concat(datepart(year,@fecha_inicio), '/', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '/', right(CONCAT('0',datepart(day, @fecha_inicio)),2)) And 
'		concat(datepart(year,@fecha_fin), '/', right(CONCAT('0',datepart(month, @fecha_fin)),2), '/', right(CONCAT('0',datepart(day, @fecha_fin)),2))
'        /* estado caja*/And fm.estado_caja = 'A'
'		commit
'Return @monto_total
'	End Try
'begin catch
'		PRINT 'ERROR'
'ROLLBACK
'Return @monto_total
'	End Catch
'End



'USE [Restaurante_V4_Produccion]
'GO
'Set ANSI_NULLS On
'GO
'Set QUOTED_IDENTIFIER On
'GO
'ALTER PROCEDURE [FAC].[sp_consulta_fondo_final](
'@cod_usuario_asigna varchar(30),
'@cod_usuario_recibe varchar(30),
'@fecha_inicio datetime,
'@fecha_fin datetime,
'--@movimiento int,
'@monto_total decimal(16,0) output
')
'as
'begin
'begin tran
'begin try
'		Select Case@monto_total = isnull(sum(subtotal_cierre),0) 
'		from FAC.flujocaja_d As fd
'		inner join FAC.flujocaja_m As fm On fd.cod_usuario_asigna = fm.cod_usuario_asigna 
'		And fd.cod_usuario_recibe = fm.cod_usuario_recibe 
'		And fd.fecha = fm.fecha
'		And fd.tipo_moneda = fm.tipo_moneda

'		--usuarios
'		where fd.cod_usuario_recibe = @cod_usuario_recibe 
'		And fd.cod_usuario_asigna = @cod_usuario_asigna 
'		And/*fechas */

'		concat(datepart(year, fd.fecha), '/', right(CONCAT('0',datepart(month, fd.fecha)),2), '/', right(CONCAT('0',datepart(day, fd.fecha)),2)) 
'        between concat(datepart(year,@fecha_inicio), '/', right(CONCAT('0',datepart(month, @fecha_inicio)),2), '/', right(CONCAT('0',datepart(day, @fecha_inicio)),2)) And 
'		concat(datepart(year,@fecha_fin), '/', right(CONCAT('0',datepart(month, @fecha_fin)),2), '/', right(CONCAT('0',datepart(day, @fecha_fin)),2))
'        /* estado caja*/And fm.estado_caja = 'C'
'		commit
'Return @monto_total
'	End Try
'begin catch
'		PRINT 'ERROR'
'ROLLBACK
'Return @monto_total
'	End Catch
'End


'use Restaurante_V4_Produccion
'Select Case* From FAC.flujocaja_d Where cod_usuario_asigna = 'administrador' and cod_usuario_recibe = 'caja2'
' Select * From FAC.flujocaja_m Where cod_usuario_asigna = 'administrador' and cod_usuario_recibe = 'caja2'

'Declare @fechaI datetime
'	Declare @fechaF datetime
'	Select Case@fechaI = convert(datetime,'26/07/2016 22:59:00')
'	Select Case@fechaF = convert(datetime,getdate())

'	--exec [FAC].[sp_inserta_intro_sale] 'TITA', @fechaI,1,2,200,0,0,'TITA1079',0,0
'	Declare @a decimal(16,0)
'--EXEC fac.sp_consulta_introducciones_salidas 'TITA', @fechaI, @fechaF, 0, @monto_total=@a output
'--select @a

'exec FAC.sp_consulta_fondo_inicial 'administrador','caja2', @fechaI, @fechaF, @monto_total=@a output
'Select Case@a
'go

'Declare @fechaI datetime
'Select Case@fechaI = convert(datetime,'26/07/2016 22:59:00')

'Select Case concat(datepart(year,@fechaI), '/', right(CONCAT('0',datepart(month, @fechaI)),2), '/', right(CONCAT('0',datepart(day, @fechaI)),2))





'USE [Restaurante_V4_Produccion]
'GO
'/****** Object:  StoredProcedure [FAC].[sp_consulta_pago_facturas]    Script Date: 17/08/2016 11:02:28 ******/
'Set ANSI_NULLS On
'GO
'Set QUOTED_IDENTIFIER On
'GO
'CREATE PROCEDURE [FAC].[sp_consulta_pago_facturas](
'@cod_usuario varchar(30),
'@fecha_inicio datetime,
'@fecha_fin datetime,
'--@movimiento int,
'@monto_total decimal(16,0) output
')
'as
'begin
'begin tran
'begin try
'		Select Case@monto_total = isnull(sum(monto_factura),0) 
'		from FAC.pago_facturas As pf
'		where pf.cod_usuario = @cod_usuario And 
'			pf.fecha_pago between convert(datetime, @fecha_inicio) And convert(datetime,@fecha_fin)
'		commit
'Return @monto_total
'	End Try
'begin catch
'		PRINT 'ERROR'
'ROLLBACK
'Return @monto_total
'	End Catch
'End


'--exec [FAC].[sp_consulta_introducciones_salidas] 'pruebasCajas', '2016-08-17 00:00:00', getdate(),

'	Declare @fechaI datetime
'	Declare @fechaF datetime
'	Select Case Case@fechaI = convert(datetime,'Jul 26 2016 11:14AM')
'	Select Case Case@fechaF = convert(datetime,getdate())

'	--exec [FAC].[sp_inserta_intro_sale] 'TITA', @fechaI,1,2,200,0,0,'TITA1079',0,0
'	Declare @a decimal(16,0)
'--EXEC fac.sp_consulta_introducciones_salidas 'TITA', @fechaI, @fechaF, 0, @monto_total=@a output
'--select @a

'exec FAC.[sp_consulta_pago_facturas] 'pruebasCajas', @fechaI, @fechaF, @monto_total=@a output
'Select Case Case@a


















'USE [Restaurante_V4_Produccion]
'GO
'/****** Object:  StoredProcedure [FAC].[sp_consulta_ingresos_efectivos2]    Script Date: 17/08/2016 11:32:40 ******/
'Set ANSI_NULLS On
'GO
'Set QUOTED_IDENTIFIER On
'GO
'create procedure [FAC].[sp_consulta_impuesto_servicios](
'@cod_usuario varchar(30),
'@fecha_inicio datetime,
'@fecha_fin datetime, 
'@monto_total decimal(16,0) output
')
'as
'/*declare 
'@fecha_inicio datetime
'@total decimal(5,0),
'@impserv decimal(5,0),
'@total_efectivo decimal(5,0),
'@subtotal decimal(5,0)
'*/begin
'	begin tran
'begin try
'		/*set @total = (select sum(mto_total) from [FAC].[factura_m] as fm, FAC.orden_m as om
'		where om.cod_empleado = 110240075 And fm.num_orden = om.num_orden
'		And om.fecha between convert(datetime,'25/06/2016 22:34:00') and convert(datetime,'25/06/2016 22:34:00'))
'		*/

'		/*se toma la fecha y hora del cajero cyando realizo la apertura de caja*
'			Set @fecha_inicio = (Select fecha from FAC.flujocaja_m 
'			where cod_usuario_recibe = @cod_usuario And estado_caja = 'A')
'		/*muestra lo que se pago en orden_m con efectivo*/

'		/set @total_efectivo = */


'			Select Case@monto_total = (select sum(om.impserv) from FAC.factura_m as fm, FAC.orden_m as om
'			inner join FAC.orden_d As od On om.num_orden = od.num_orden

'			where om.cod_empleado = @cod_usuario And FM.num_orden = om.num_orden And
'			om.fecha between convert(datetime, @fecha_inicio) And convert(datetime,@fecha_fin))
'			commit
'Return @monto_total
'	End Try
'begin catch
'		print 'algun error'
'rollback
'Return @monto_total
'	End Catch
'End

'Declare @FECHA DATETIME
'Set @FECHA = CONVERT(DATETIME, GETDATE())

'--Declare @a decimal(16,0)
'--exec fac.sp_consulta_impuesto_servicios '110240075', '25/06/2016 22:34:00', @FECHA, @monto_total=@a output
'--select @a

'--select sum(impserv) from fac.orden_m

'Select Case* From fac.orden_m as m Where m.cod_empleado = 110240075 And m.fecha between '26-07-2016 22:53:00' and @FECHA











'USE [Restaurante_V4_Produccion]
'GO
'/****** Object:  StoredProcedure [FAC].[sp_almacena_fondo_final_flujocaja_m]    Script Date: 17/08/2016 15:21:05 ******/
'Set ANSI_NULLS On
'GO
'Set QUOTED_IDENTIFIER On
'GO
'  ALTER PROCEDURE [FAC].[sp_almacena_fondo_final_flujocaja_m](
'  @codigo_usuario_asigna VARCHAR(30),
'  @codigo_usuario_recibe VARCHAR(30),
'  @tipo_moneda DECIMAL(5,0),
'  @estado_caja VARCHAR(1),
'  @aprobada DECIMAL(5,0)
'  )
'  AS
'  BEGIN TRAN

'BEGIN TRY
'		UPDATE FAC.flujocaja_M Set estado_caja = @estado_caja, aprobada = @aprobada
'		WHERE cod_usuario_asigna = @codigo_usuario_asigna And cod_usuario_recibe = @codigo_usuario_recibe 
'		And tipo_moneda = @tipo_moneda
'		COMMIT
'Return 1
'End Try
'BEGIN CATCH
'	print 'error'
'ROLLBACK
'Return 0
'End Catch;
''	go
'Declare @FECHA DATETIME
'	Set @FECHA = CONVERT(DATETIME, GETDATE())
'	print @fecha
'	exec [FAC].[sp_almacena_fondo_final_flujocaja_m] 'pruebasAdmin', 'pruebasCajas',1, @FECHA, 'C',1


'USE [Restaurante_V4_Produccion]
'GO
'/****** Object:  StoredProcedure [FAC].[sp_almacena_fondo_final_flujocaja_d]    Script Date: 17/08/2016 15:19:57 ******/
'Set ANSI_NULLS On
'GO
'Set QUOTED_IDENTIFIER On
'GO
'  ALTER PROCEDURE [FAC].[sp_almacena_fondo_final_flujocaja_d](
'  @codigo_usuario_asigna VARCHAR(30),
'  @codigo_usuario_recibe VARCHAR(30),
'  @tipo_moneda DECIMAL(5,0),
'  @cod_moneda DECIMAL(5,0),
'  @cantidad_cierre DECIMAL(5,0),
'  @subtotal_cierre DECIMAL(16,2)
'  )
'  AS
'  BEGIN TRAN
'BEGIN TRY
'		UPDATE FAC.flujocaja_d Set cantidad_cierre = @cantidad_cierre, subtotal_cierre = @subtotal_cierre
'		WHERE cod_usuario_asigna = @codigo_usuario_asigna And cod_usuario_recibe = @codigo_usuario_recibe 
'		And tipo_moneda = @tipo_moneda And cod_moneda = @cod_moneda
'		COMMIT
'Return 1
'End Try
'BEGIN CATCH
'		ROLLBACK
'Return 0
'End Catch;



'CREATE PROCEDURE [RRHH].[sp_validar_sesion](
'@cod_usuario VARCHAR(30),
'@contrasenna VARCHAR(30)
')
'AS
'BEGIN
'BEGIN TRY
'		If EXISTS(SELECT * FROM RRHH.usuarios AS us WHERE us.cod_usuario = @cod_usuario And us.contrasena = @contrasenna)
'BEGIN
'Select Case em.* From RRHH.empleados AS em, RRHH.usuarios AS us Where em.cod_usuario = us.cod_usuario
'			And us.cod_usuario = @cod_usuario And us.contrasena = @contrasenna 
'			--And em.password = us.contrasena
'		End
'End Try
'BEGIN CATCH		
'		Select Case NULL
'End Catch
'End

'EXEC [RRHH].[sp_validar_sesion] 'historico', '123'






'USE [Restaurante_V4_Produccion]
'GO
'/****** Object:  StoredProcedure [FAC].[sp_consulta_reporte_fondos]    Script Date: 24/08/2016 8:48:00 ******/
'Set ANSI_NULLS On
'GO
'Set QUOTED_IDENTIFIER On
'GO
'CREATE PROCEDURE [FAC].[sp_consulta_reporte_fondos](
'--@cod_usuario_asigna varchar(30),
'@cod_usuario_recibe VARCHAR(30),
'@fecha_inicio DATETIME,
'@fecha_fin DATETIME,
'-- bandera. Si es 1 es para fondo inicial, si es 0 es para fondo final
'@movimiento INT
')
'AS
'BEGIN
'BEGIN TRAN
'BEGIN TRY
'		If @movimiento > 1 BEGIN
'			Select Case CONCAT(em.nombre, ' ', em.apellido1) AS Recibe, /*concat(emp.nombre, ' ', emp.apellido1),*/ fd.fecha, 'Colones' AS Moneda, mo.desc_moneda, fd.cantidad_cierre , fd.subtotal_cierre 
'            From FAC.flujocaja_d AS fd
'			INNER JOIN RRHH.empleados As em On fd.cod_usuario_asigna = em.cod_usuario
'			--INNER JOIN RRHH.empleados AS emp ON fd.cod_usuario_recibe = emp.cod_usuario
'			INNER JOIN FAC.monedas As mo On fd.cod_moneda = mo.cod_moneda
'			WHERE fd.cod_usuario_recibe = @cod_usuario_recibe
'			And fd.fecha BETWEEN convert(datetime,@fecha_inicio) And convert(datetime,@fecha_fin)
'		End
'Else
'BEGIN
'Select Case CONCAT(em.nombre, ' ', em.apellido1) AS Recibe, /*concat(emp.nombre, ' ', emp.apellido1),*/ fd.fecha, 'Dólares' AS Moneda, mo.desc_moneda, fd.cantidad , fd.subtotal 
'            From FAC.flujocaja_d AS fd
'			INNER JOIN RRHH.empleados As em On fd.cod_usuario_asigna = em.cod_usuario
'			--INNER JOIN RRHH.empleados AS emp ON fd.cod_usuario_recibe = emp.cod_usuario
'			INNER JOIN FAC.monedas As mo On fd.cod_moneda = mo.cod_moneda
'			WHERE fd.cod_usuario_recibe = @cod_usuario_recibe
'			And fd.fecha BETWEEN convert(datetime,@fecha_inicio) And convert(datetime,@fecha_fin)
'		End
'COMMIT
'End Try
'BEGIN CATCH
'		PRINT 'ERROR'
'ROLLBACK
'End Catch
'End










