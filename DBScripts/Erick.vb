'CREATE PROCEDURE [FAC].[sp_almacena_factura_m](
'	@num_Factura decimal(5,0),
'	@fecha_factura datetime,
'	@cod_estado_factura varchar(1),
'	@descuento decimal(6,2),
'	@num_orden decimal(16,0),
'	@mto_total decimal(16,2)
'	)
'  AS
'	BEGIN TRAN
'BEGIN TRY
'			INSERT INTO FAC.factura_m VALUES(@num_Factura,@fecha_factura,@cod_estado_factura,@descuento,@num_orden,@mto_total)
'			COMMIT
'Return 1
'End Try
'BEGIN CATCH
'		ROLLBACK
'Return 0
'End Catch;



'	CREATE TABLE [FAC].[factura_d](
'		num_factura Decimal(5, 0) Not null, 
'		cod_estado_factura varchar(1) Not null,
'		num_orden Decimal(16, 0) Not null,
'        cod_producto Decimal(10, 0) Not null, 
'        cantidad Decimal(5, 0) Default 0 Not null,
'        sub_total Decimal(12, 4) default 0 Not null)

'		ALTER TABLE [FAC].[factura_d] ADD CONSTRAINT PK_factura_d PRIMARY KEY CLUSTERED(num_factura,cod_producto)

'		ALTER TABLE [FAC].[factura_d]  With CHECK ADD  CONSTRAINT [FK_factura_d_producto] 
'		FOREIGN KEY([cod_producto])REFERENCES [INV].[productos] ([cod_producto])

'		ALTER TABLE [FAC].[factura_d] With CHECK ADD CONSTRAINT [FK_factura_d_factura_m]
'		FOREIGN KEY([num_factura], [num_orden], [cod_estado_factura]) 
'		REFERENCES [FAC].[factura_m]([num_factura],[num_orden], [cod_estado_factura])

'		ALTER TABLE [FAC].[factura_d] ADD CONSTRAINT FK_factura_d_producto FOREIGN KEY([cod_producto]) REFERENCES [INV].[productos]([cod_producto])

'		GO

'CREATE PROCEDURE [FAC].[sp_almacena_factura_d](
'	@num_Factura decimal(5,0),
'	@cod_estado_factura varchar(1),
'	@num_orden decimal(16,0),
'	@cod_producto decimal(10,0),
'	@cantidad decimal(5,0),
'	@subTotal decimal (12,4)
'	)
'  AS
'	BEGIN TRAN
'BEGIN TRY
'			INSERT INTO FAC.factura_d VALUES(@num_Factura,@cod_estado_factura,@num_orden,@cod_producto,@cantidad,@subTotal)
'			COMMIT
'Return 1
'End Try
'BEGIN CATCH
'		ROLLBACK
'Return 0
'End Catch;

'	CREATE TABLE [FAC].[factura_p](
'		num_pago Decimal(5, 0) Not null,
'        num_factura Decimal(5, 0) Not null, 
'		cod_estado_factura varchar(1) Not null,
'		num_orden Decimal(16, 0) Not null,       
'		tipo_pago varchar(1) Not null,
'		monto Decimal(12, 4) Not null,
'        vuelto Decimal(12, 4) default 0 Not null
'	)

'	ALTER TABLE [FAC].[factura_p] ADD CONSTRAINT PK_factura_p PRIMARY KEY CLUSTERED(num_pago, num_factura)

'	ALTER TABLE [FAC].[factura_p] With CHECK ADD CONSTRAINT [FK_factura_p_factura_m]
'	FOREIGN KEY([num_factura], [num_orden], [cod_estado_factura]) 
'	REFERENCES [FAC].[factura_m]([num_factura],[num_orden], [cod_estado_factura])

'	GO


'CREATE PROCEDURE [FAC].[sp_almacena_factura_p](
'		@num_pago decimal(5,0),
'		@num_factura decimal(5,0),
'		@cod_estado_factura varchar(1),
'		@num_orden decimal(16,0),
'		@tipo_pago varchar(1),
'		@monto decimal(12,4),
'		@vuelto decimal(12,4)
'	)
'	AS
'Declare @w_tran INT
'If @@TRANCOUNT <> 0
'	BEGIN 
'		COMMIT TRAN
'If @@ERROR <> 0
'		BEGIN
'GoTo continuar
'End
'Select Case Case@w_tran = 1
'	End
'Else
'Select Case Case@w_tran = 0
'	CONTINUAR:

'    BEGIN TRAN ingresar_factura_p
'	INSERT INTO FAC.factura_p VALUES (@num_pago, @num_factura, @cod_estado_factura, @num_orden, 
'		@tipo_pago, @monto, @vuelto)
'	If @@ERROR <> 0 
'		BEGIN
'PRINT 'No se pudo insertar'
'ROLLBACK
'End
'	COMMIT TRANSACTION eliminarOrden
'	If @w_tran  = 1
'		BEGIN TRAN
'GO
