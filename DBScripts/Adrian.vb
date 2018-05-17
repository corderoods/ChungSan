'CREATE PROCEDURE FAC.sp_eliminarOrden_m(
'    @numeroOrden DECIMAL(16,0)
')AS
'Declare @w_tran INT
'If @@TRANCOUNT <> 0
'	BEGIN 
'		COMMIT TRAN
'If @@ERROR <> 0
'		BEGIN
'GoTo continuar
'End
'Select @w_tran = 1
'	End
'Else
'Select @w_tran = 0
'	CONTINUAR:
'    BEGIN TRAN eliminarOrden
'	DELETE FROM fac.orden_d WHERE num_orden = @numeroOrden
'	If @@ERROR <> 0 
'		BEGIN
'PRINT 'No se elimino el detalle de orden'
'			ROLLBACK TRANSACTION eliminarOrden
'		End
'	DELETE FROM fac.orden_m WHERE num_orden = @numeroOrden
'	If @@ERROR <> 0 
'		BEGIN
'PRINT 'No se elimino la orden'
'			ROLLBACK TRANSACTION eliminarOrden
'		End
'	COMMIT TRANSACTION eliminarOrden
'	If @w_tran  = 1
'		BEGIN TRAN
'GO


'Alter table FAC.clientes
'alter column direccion VARCHAR(max)
'GO

'alter table FAC.orden_m
'add nombre VARCHAR(100)
'GO

'alter table FAC.factura_m
'add nombre VARCHAR(100)
'GO

'alter table FAC.orden_d
'add Observaciones VARCHAR(MAX)
'GO


'CREATE PROCEDURE FAC.sp_cliente_por_nombre(
'	@nombre VARCHAR(50),
'	@apellido VARCHAR(50)
'	)
'  AS
'	BEGIN TRAN
'		BEGIN TRY
'			IF (@apellido = null Or LEN(@apellido)<1) 
'				BEGIN
'					SELECT * FROM fac.clientes WHERE nombre_cliente = @nombre and (apellido is null or  apellido = '') 
'				END
'			ELSE
'				BEGIN
'					SELECT * FROM fac.clientes WHERE nombre_cliente = @nombre And apellido = @apellido
'				END
'			COMMIT
'			RETURN 1
'		END TRY
'	BEGIN CATCH
'		ROLLBACK
'		RETURN 0
'	END CATCH
'GO


'alter table FAC.factura_m
'add estado VARCHAR(1)
'GO