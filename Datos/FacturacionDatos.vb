Imports System.Data.SqlClient
Public Class FacturacionDatos
    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD
    Public Shared tablas As DataSet

    Public Sub New()
        conexionDB = New ConexionBD
        cmd = New SqlCommand
    End Sub

    Public Function obtenerProductosPorOrden(orden As Integer) As List(Of Object)
        'lista de los productos de la orden
        Dim detalleOrden As New List(Of Object)
        'Lector de los resultados
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                'se abre la conexion
                conexion = conexionDB.abrirConexion()
                'consulta que se va a hacer a la BD
                cmd = New SqlCommand("SELECT FAC.orden_d.*, INV.productos.* FROM INV.productos, FAC.orden_d WHERE FAC.orden_d.cod_producto=INV.productos.cod_producto  AND FAC.orden_d.num_orden=" & orden)
                'especifica el tipo de consulta
                cmd.CommandType = CommandType.Text
                'se asigna la conexion a la BD
                cmd.Connection = conexion
                'se ejecuta la consulta
                lector = cmd.ExecuteReader
                'se recorre para obtener los registros
                While lector.Read
                    'detalle de orden
                    Dim ordenDetalle As OrdenTemporal = New OrdenTemporal
                    'producto dentro de la orden
                    Dim producto As Producto = New Producto
                    'se asignan los datos

                    ordenDetalle.NumOrden = ConversionDatosDB.VerificarNulo(lector("num_orden"), 0)
                    ordenDetalle.NumLinea = ConversionDatosDB.VerificarNulo(lector("num_linea"), 0)
                    ordenDetalle.CodProducto = ConversionDatosDB.VerificarNulo(lector("cod_producto"), 0)
                    ordenDetalle.Cantidad_ = ConversionDatosDB.VerificarNulo(lector("cantidad"), 0)
                    ordenDetalle.SubTotal_ = ConversionDatosDB.VerificarNulo(lector("subtotal"), 0)
                    ordenDetalle.Llevar_ = ConversionDatosDB.VerificarNulo(lector("llevar"), 0)
                    ordenDetalle.Descuento_ = ConversionDatosDB.VerificarNulo(lector("descuento"), 0)
                    ordenDetalle.IndRepetidos = ConversionDatosDB.VerificarNulo(lector("ind_repetidos"), 0)
                    ordenDetalle.IndCantidad = ConversionDatosDB.VerificarNulo(lector("ind_cantidad"), 0)
                    ordenDetalle.Impreso_ = ConversionDatosDB.VerificarNulo(lector("impreso"), 0)
                    ordenDetalle.CantImpreso = ConversionDatosDB.VerificarNulo(lector("cant_impreso"), 0)

                    producto.CodProducto = ConversionDatosDB.VerificarNulo(lector("cod_producto"), 0)
                    producto.Nombre_ = ConversionDatosDB.VerificarNulo(lector("nombre"), "Desconocido")
                    producto.PrecioVenta = ConversionDatosDB.VerificarNulo(lector("precio_venta"), 0)
                    producto.Promocion_ = ConversionDatosDB.VerificarNulo(lector("promocion"), 0)
                    producto.Descuento_ = ConversionDatosDB.VerificarNulo(lector("descuento"), 0)
                    producto.AfectaInventario = ConversionDatosDB.VerificarNulo(lector("afecta_inventario"), 0)
                    producto.CodBarra = ConversionDatosDB.VerificarNulo(lector("cod_barra"), 0)
                    producto.CantDisponible = ConversionDatosDB.VerificarNulo(lector("cant_disponible"), 0)
                    producto.IdTipoProducto = ConversionDatosDB.VerificarNulo(lector("id_tipo_producto"), 0)
                    producto.Compuesto_ = ConversionDatosDB.VerificarNulo(lector("compuesto"), 0)
                    'vector que contiene el producto con la orden
                    Dim detalle() As Object = {ordenDetalle.Cantidad_, producto, ordenDetalle}
                    detalleOrden.Add(detalle)

                End While

            End Using
        Catch ex As Exception

        End Try
        Return detalleOrden
    End Function

    ' metodo que se encarga de obtener las facturas canceladas para poder ser anuladas
    Public Function obtenerFacturasAnular(ByVal cod_usuario As String, ByVal fecha_inicio As String) As List(Of Factura)
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        Dim factura As Factura
        Dim lector As SqlDataReader
        Dim listaFacturas As New List(Of Factura)
        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_facturas_para_anular"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento

            While lector.Read
                'instancia del objeto
                factura = New Factura
                factura.NumFactura = lector(0)
                factura.MontoTotal = lector(1)

                listaFacturas.Add(factura)
            End While

            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()

        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
        End Try

        Return listaFacturas

    End Function

    Public Function obtenerFacturasProveedoresAnular(ByVal cod_usuario As String, ByVal fecha_inicio As String) As List(Of Factura)
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        Dim factura As Factura
        Dim lector As SqlDataReader
        Dim listaFacturas As New List(Of Factura)
        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_facturas_proveedores_para_anular"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento

            While lector.Read
                'instancia del objeto
                factura = New Factura
                factura.NumFactura = lector(0)
                factura.MontoTotal = lector(1)

                listaFacturas.Add(factura)
            End While

            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()

        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
        End Try

        Return listaFacturas

    End Function

    Public Function obtenerEncabezadoFactura(numeroOrden As Integer) As Object
        'lista de los productos de la orden
        Dim detalle As New Object()
        'Lector de los resultados
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                'se abre la conexion
                conexion = conexionDB.abrirConexion()
                'consulta que se va a hacer a la BD
                cmd = New SqlCommand("SELECT * FROM FAC.orden_m, FAC.clientes WHERE FAC.clientes.cod_cliente=FAC.orden_m.cod_cliente AND FAC.orden_m.num_orden=" & numeroOrden)
                'especifica el tipo de consulta
                cmd.CommandType = CommandType.Text
                'se asigna la conexion a la BD
                cmd.Connection = conexion
                'se ejecuta la consulta
                lector = cmd.ExecuteReader
                'se recorre para obtener los registros
                While lector.Read
                    'detalle de orden
                    Dim orden As Orden = New Orden
                    'producto dentro de la orden
                    Dim cliente As Cliente = New Cliente
                    'se asignan los datos

                    orden.NumOrden = ConversionDatosDB.VerificarNulo(lector(0), 0)
                    orden.NumMesa = ConversionDatosDB.VerificarNulo(lector(1), 0)
                    orden.Fecha_ = ConversionDatosDB.VerificarNulo(lector(2), "")
                    orden.CodEmpleado = ConversionDatosDB.VerificarNulo(lector(3), 0)
                    orden.CodCliente = ConversionDatosDB.VerificarNulo(lector(5), 0)
                    orden.OrdenDia = ConversionDatosDB.VerificarNulo(lector(11), 0)
                    orden.Ubicacion_ = ConversionDatosDB.VerificarNulo(lector(21), 0)
                    orden.CodSalonero = ConversionDatosDB.VerificarNulo(lector(27), 0)

                    cliente.CodClienteSG = ConversionDatosDB.VerificarNulo(lector(29), 0)
                    cliente.NombreClienteSG = ConversionDatosDB.VerificarNulo(lector(28), ConversionDatosDB.VerificarNulo(lector(30), "CLIENTE CONTADO"))

                    'vector que contiene el producto con la orden
                    detalle = {orden, cliente}
                End While

            End Using
        Catch ex As Exception
            'MsgBox(ex)
        End Try
        Return detalle
    End Function

    Public Function obtenerEmpledosFactura(numeroOrden As Integer) As List(Of Empleado)
        'lista de los productos de la orden
        Dim empleados As New List(Of Empleado)
        'Lector de los resultados
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                'se abre la conexion
                conexion = conexionDB.abrirConexion()
                'consulta que se va a hacer a la BD
                cmd = New SqlCommand("SELECT empleado.* FROM RRHH.empleados as empleado, FAC.orden_m as orden WHERE (empleado.cod_empleado=orden.cod_empleado OR empleado.cod_empleado=orden.cod_salonero) AND orden.num_orden=" & numeroOrden)
                'especifica el tipo de consulta
                cmd.CommandType = CommandType.Text
                'se asigna la conexion a la BD
                cmd.Connection = conexion
                'se ejecuta la consulta
                lector = cmd.ExecuteReader
                'se recorre para obtener los registros
                While lector.Read
                    'empleado
                    Dim empleado As Empleado = New Empleado

                    empleado.Cod_empleadoSG = ConversionDatosDB.VerificarNulo(lector(0), 0)
                    empleado.NombreSG = ConversionDatosDB.VerificarNulo(lector(1), "Desconocido")
                    empleado.Apellido1SG = ConversionDatosDB.VerificarNulo(lector(2), "Desconocido")
                    empleado.Apellido2SG = ConversionDatosDB.VerificarNulo(lector(3), "Desconocido")

                    empleados.Add(empleado)

                End While

            End Using
        Catch ex As Exception

        End Try
        Return empleados
    End Function

    'METODO QUE OBTIENE EL ULTIMO NUMERO DE FACTURA
    Public Function ultimoNumFactura() As Integer
        'lista de los productos de la orden
        Dim ultimoNum As Integer
        'Lector de los resultados
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                'se abre la conexion
                conexion = conexionDB.abrirConexion()
                'consulta que se va a hacer a la BD
                cmd = New SqlCommand("SELECT MAX(num_factura) as num_factura FROM FAC.factura_m")
                'especifica el tipo de consulta
                cmd.CommandType = CommandType.Text
                'se asigna la conexion a la BD
                cmd.Connection = conexion
                'se ejecuta la consulta
                lector = cmd.ExecuteReader
                'se recorre para obtener los registros
                While lector.Read
                    ultimoNum = lector(0)
                End While

            End Using
        Catch ex As Exception

        End Try
        Return ultimoNum
    End Function

    'METODO QUE INGRESA UNA NUEVA FACTURA EN LA BASE
    Public Function ingresarFactura(nuevaFactura As Factura) As Boolean
        'abre la conexion
        conexion = conexionDB.abrirConexion
        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_almacena_factura_m"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion
        ' asigna los parametros a enviar al procedimiento
        With cmd.Parameters
            .AddWithValue("@num_factura", nuevaFactura.NumFactura)
            .AddWithValue("@fecha_factura", nuevaFactura.FechaFactura)
            .AddWithValue("@cod_estado_factura", nuevaFactura.CodEstadoFactura)
            .AddWithValue("@descuento", nuevaFactura.Descuento_)
            .AddWithValue("@num_orden", nuevaFactura.NumOrden)
            .AddWithValue("@mto_total", nuevaFactura.MontoTotal)
            .AddWithValue("@nombre_cliente", nuevaFactura.NombreCliente_)

            .AddWithValue("@subtotal", nuevaFactura.SubtotalSG)
            .AddWithValue("@monto_descuento", nuevaFactura.Monto_descuentoSG)
            .AddWithValue("@porcentaje_descuento", nuevaFactura.Porcentaje_descuentoSG)
            .AddWithValue("@impserv", nuevaFactura.ImpservSG)
            .AddWithValue("@impvtas", nuevaFactura.ImpvtasSG)
            .AddWithValue("@express", nuevaFactura.ExpressSG)

        End With
        Try
            ' ejecuta la consulta a la base
            cmd.ExecuteNonQuery()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return True
        Catch ex As Exception
            ' cierra la conexion
            conexionDB.cerrarConexion()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return False
        End Try
    End Function

    'METODO QUE INGRESA EN EL DETALLE DE LA FACTURA
    Public Function ingresarFacturaDetalle(facturaDetalle As FacturaDetalle) As Boolean
        'abre la conexion
        conexion = conexionDB.abrirConexion
        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_almacena_factura_d"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion
        ' asigna los parametros a enviar al procedimiento
        With cmd.Parameters
            .AddWithValue("@num_factura", facturaDetalle.NumFactura)
            .AddWithValue("@cod_producto", facturaDetalle.CodProducto)
            .AddWithValue("@cantidad", facturaDetalle.Cantidad_)
            .AddWithValue("@subTotal", facturaDetalle.SubTotal)

        End With
        Try
            ' ejecuta la consulta a la base
            cmd.ExecuteNonQuery()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return True
        Catch ex As Exception
            ' cierra la conexion
            conexionDB.cerrarConexion()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return False
        End Try
    End Function

    'METODO QUE INGRESA LOS PAGOS DE LA FACTURA A LA BD
    Public Function ingresarPagoFactura(pago As Pago) As Boolean
        'abre la conexion
        conexion = conexionDB.abrirConexion
        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_almacena_factura_p"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion
        ' asigna los parametros a enviar al procedimiento
        With cmd.Parameters
            .AddWithValue("@num_pago", pago.NumPago)
            .AddWithValue("@num_factura", pago.NumFactura)
            .AddWithValue("@tipo_pago", pago.TipoPago)
            .AddWithValue("@monto", pago.Monto_)

        End With
        Try
            ' ejecuta la consulta a la base
            cmd.ExecuteNonQuery()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return ingresarDatosEnFacturaCajero(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, pago.NumFactura)
        Catch ex As Exception
            ' cierra la conexion
            conexionDB.cerrarConexion()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return False
        End Try
    End Function

    'METODO QUE OBTIENE LOS PRODUCTOS QUE SE HAN PAGADO
    Public Function obtenerProductosFacturaDetalle(numOrden As Integer) As List(Of FacturaDetalle)
        'lista de los productos de la orden
        Dim productosPagados As New List(Of FacturaDetalle)
        'Lector de los resultados
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                'se abre la conexion
                conexion = conexionDB.abrirConexion()
                'consulta que se va a hacer a la BD
                cmd = New SqlCommand("SELECT FAC.factura_d.* FROM FAC.factura_d, FAC.factura_m WHERE FAC.factura_d.num_factura=FAC.factura_m.num_factura AND FAC.factura_m.num_orden=" & numOrden)
                'especifica el tipo de consulta
                cmd.CommandType = CommandType.Text
                'se asigna la conexion a la BD
                cmd.Connection = conexion
                'se ejecuta la consulta
                lector = cmd.ExecuteReader
                'se recorre para obtener los registros
                While lector.Read
                    Dim facturaDetalle As New FacturaDetalle
                    facturaDetalle.NumFactura = lector(0)
                    facturaDetalle.CodProducto = lector(1)
                    facturaDetalle.Cantidad_ = lector(2)
                    facturaDetalle.SubTotal = lector(3)

                    productosPagados.Add(facturaDetalle)
                End While

            End Using
        Catch ex As Exception

        End Try
        Return productosPagados
    End Function

    ' METODO QUE INSERTA EL CODIGO DEL CAJERO Y EL NUMERO DE FACTURA QUE REALIZAO
    Public Function ingresarDatosEnFacturaCajero(cod_usuario As String, num_factura As Integer) As Boolean

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_almacena_factura_cajero"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion
        ' asigna los parametros a enviar al procedimiento
        With cmd.Parameters
            .AddWithValue("@num_factura", num_factura)
            .AddWithValue("@cod_usuario", cod_usuario)
        End With
        Try
            ' ejecuta la consulta a la base
            cmd.ExecuteNonQuery()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return True
        Catch ex As Exception
            ' cierra la conexion
            conexionDB.cerrarConexion()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
        End Try
        Return False
    End Function

    'METODO QUE INGRESA LOS DATOS DE LA FACTURA EN LA ORDEN
    Public Function ingresarDatosFacturaEnOrden(orden As Orden) As Boolean
        'abre la conexion
        conexion = conexionDB.abrirConexion
        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_actualizar_orden_m"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion
        ' asigna los parametros a enviar al procedimiento
        With cmd.Parameters
            .AddWithValue("@numeroOrden", orden.NumOrden)
            .AddWithValue("@total", orden.Total_)
            .AddWithValue("@cod_cliente", orden.CodCliente)
            .AddWithValue("@efectivo", orden.Efectivo_)
            .AddWithValue("@descuento", orden.Descuento_)
            .AddWithValue("@tarjeta", orden.Tarjeta_)
            .AddWithValue("@impserv", orden.ImpServ_)
            .AddWithValue("@impvtas", orden.ImpVtas_)
            .AddWithValue("@express", orden.Express_)
        End With
        Try
            ' ejecuta la consulta a la base
            cmd.ExecuteNonQuery()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return True
        Catch ex As Exception
            ' cierra la conexion
            conexionDB.cerrarConexion()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return False
        End Try
    End Function

    'METODO QUE OBTIENE LA ORDEN POR EL NUMERO DE ORDEN
    Public Function obtenerOrdenPorNumero(numOrden As Integer) As Orden
        'lista de los productos de la orden
        Dim orden = New Orden
        'Lector de los resultados
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                'se abre la conexion
                conexion = conexionDB.abrirConexion()
                'consulta que se va a hacer a la BD
                cmd = New SqlCommand("SELECT * FROM FAC.orden_m WHERE FAC.orden_m.num_orden=" & numOrden)
                'especifica el tipo de consulta
                cmd.CommandType = CommandType.Text
                'se asigna la conexion a la BD
                cmd.Connection = conexion
                'se ejecuta la consulta
                lector = cmd.ExecuteReader
                'se recorre para obtener los registros
                While lector.Read
                    orden.NumOrden = ConversionDatosDB.VerificarNulo(lector(0), 0)
                    orden.NumMesa = ConversionDatosDB.VerificarNulo(lector(1), 0)
                    orden.Fecha_ = lector(2)
                    orden.CodEmpleado = ConversionDatosDB.VerificarNulo(lector(4), 0)
                    orden.Total_ = ConversionDatosDB.VerificarNulo(lector(5), 0)
                    orden.CodCliente = ConversionDatosDB.VerificarNulo(lector(6), 0)
                    orden.Efectivo_ = ConversionDatosDB.VerificarNulo(lector(7), 0)
                    orden.Descuento_ = ConversionDatosDB.VerificarNulo(lector(7), 0)
                    orden.IndPago = ConversionDatosDB.VerificarNulo(lector(8), 0)
                    orden.Tarjeta_ = ConversionDatosDB.VerificarNulo(lector(9), 0)
                    orden.Cheque_ = ConversionDatosDB.VerificarNulo(lector(10), 0)
                    orden.OrdenDia = ConversionDatosDB.VerificarNulo(lector(11), 0)
                    orden.ImpServ_ = ConversionDatosDB.VerificarNulo(lector(12), 0)
                    orden.ImpVtas_ = ConversionDatosDB.VerificarNulo(lector(13), 0)
                    orden.Ubicacion_ = ConversionDatosDB.VerificarNulo(lector(21), "")
                    orden.Direccion_ = ConversionDatosDB.VerificarNulo(lector(22), "")
                    orden.Telefono_ = ConversionDatosDB.VerificarNulo(lector(23), "")
                    orden.PagaCon = ConversionDatosDB.VerificarNulo(lector(24), 0)
                    orden.Express_ = ConversionDatosDB.VerificarNulo(lector(26), 0)
                    orden.CodSalonero = ConversionDatosDB.VerificarNulo(lector(27), 0)
                End While
            End Using
        Catch ex As Exception

        End Try
        Return orden
    End Function

    'METODO QUE OBTIENE LA ORDEN POR EL NUMERO DE ORDEN
    Public Function obtenerFacturaPorNumero(numFactura As Integer) As Factura
        'lista de los productos de la orden
        Dim factura = New Factura
        'Lector de los resultados
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                'se abre la conexion
                conexion = conexionDB.abrirConexion()
                'consulta que se va a hacer a la BD
                cmd = New SqlCommand("SELECT * FROM FAC.factura_m WHERE num_factura =" & numFactura)
                'especifica el tipo de consulta
                cmd.CommandType = CommandType.Text
                'se asigna la conexion a la BD
                cmd.Connection = conexion
                'se ejecuta la consulta
                lector = cmd.ExecuteReader
                'se recorre para obtener los registros
                While lector.Read
                    factura.NumFactura = ConversionDatosDB.VerificarNulo(lector(0), 0)
                    factura.FechaFactura = ConversionDatosDB.VerificarNulo(lector(1), 0)
                    factura.CodEstadoFactura = ConversionDatosDB.VerificarNulo(lector(2), 0)
                    factura.Descuento_ = ConversionDatosDB.VerificarNulo(lector(3), 0)
                    factura.NumOrden = ConversionDatosDB.VerificarNulo(lector(4), 0)
                    factura.MontoTotal = ConversionDatosDB.VerificarNulo(lector(5), 0)
                    factura.NombreCliente_ = ConversionDatosDB.VerificarNulo(lector(6), 0)
                End While
            End Using
        Catch ex As Exception

        End Try
        Return factura
    End Function

    'METODO QUE OBTIENE LA ORDEN POR EL NUMERO DE ORDEN
    Public Function obtenerParametros() As Parametros
        'objeto de parametros
        Dim parametros = New Parametros
        'Lector de los resultados
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                'se abre la conexion
                conexion = conexionDB.abrirConexion()
                'consulta que se va a hacer a la BD
                cmd = New SqlCommand("SELECT * FROM DBA.parametros")
                'especifica el tipo de consulta
                cmd.CommandType = CommandType.Text
                'se asigna la conexion a la BD
                cmd.Connection = conexion
                'se ejecuta la consulta
                lector = cmd.ExecuteReader
                'se recorre para obtener los registros
                While lector.Read
                    parametros.NumFactura = ConversionDatosDB.VerificarNulo(lector(0), 0)
                    parametros.PorcImpVtas = ConversionDatosDB.VerificarNulo(lector(3), 0)
                    parametros.PorcImpServ = ConversionDatosDB.VerificarNulo(lector(4), 0)
                    parametros.Express_ = ConversionDatosDB.VerificarNulo(lector(5), 0)
                End While
            End Using
        Catch ex As Exception

        End Try
        Return parametros
    End Function 'METODO QUE OBTIENE LOS PRODUCTOS PAGADOS DE UNA FACTURA

    Public Function obtenerproductosFacturaPagada(ByVal numFactura As Integer) As List(Of FacturaDetalle)
        'objeto de parametros
        Dim lista = New List(Of FacturaDetalle)
        'Lector de los resultados
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                'se abre la conexion
                conexion = conexionDB.abrirConexion()
                'consulta que se va a hacer a la BD
                cmd = New SqlCommand("select * from fac.factura_d WHERE num_factura = " & numFactura)
                'especifica el tipo de consulta
                cmd.CommandType = CommandType.Text
                'se asigna la conexion a la BD
                cmd.Connection = conexion
                'se ejecuta la consulta
                lector = cmd.ExecuteReader
                'se recorre para obtener los registros
                While lector.Read
                    Dim detalle As New FacturaDetalle
                    detalle.NumFactura = ConversionDatosDB.VerificarNulo(lector(0), 0)
                    detalle.CodProducto = ConversionDatosDB.VerificarNulo(lector(1), 0)
                    detalle.Cantidad_ = ConversionDatosDB.VerificarNulo(lector(2), 0)
                    detalle.SubTotal = ConversionDatosDB.VerificarNulo(lector(3), 0)
                    lista.Add(detalle)
                End While
            End Using
        Catch ex As Exception

        End Try
        Return lista
    End Function

    'METODO QUE ACTUALIZA LA ORDEN COMO CANCELADA EN SU TOTALIDAD
    Public Function modificaIndicadorPagoOrden(numOrden As Integer, indPago As Integer) As Boolean
        'abre la conexion
        conexion = conexionDB.abrirConexion
        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_modifica_ind_pago_orden_m"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion
        ' asigna los parametros a enviar al procedimiento
        With cmd.Parameters
            .AddWithValue("@num_orden", numOrden)
            .AddWithValue("@ind_pago", indPago)

        End With
        Try
            ' ejecuta la consulta a la base
            cmd.ExecuteNonQuery()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return True
        Catch ex As Exception
            ' cierra la conexion
            conexionDB.cerrarConexion()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return False
        End Try
    End Function

    'METODO QUE ANULA UNA FACTURA
    Public Function AnularFactura(numFactura As Integer) As Boolean
        'abre la conexion
        conexion = conexionDB.abrirConexion
        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_anular_factura"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion
        ' asigna los parametros a enviar al procedimiento
        With cmd.Parameters
            .AddWithValue("@num_factura", numFactura)

        End With
        Try
            ' ejecuta la consulta a la base
            cmd.ExecuteNonQuery()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return True
        Catch ex As Exception
            ' cierra la conexion
            conexionDB.cerrarConexion()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return False
        End Try
    End Function

    'METODO PARA CREAR LOS ARCHIVOS XML DE LA FACTURA A PAGAR
    Public Sub crearFactura(num_factura As Integer, cod_usuario As String)
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_factura"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@num_factura", num_factura)
                .AddWithValue("@cod_usuario", cod_usuario)
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\factura.xml", "factura", cmd)

            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            ' llama al metodo que consulta por el detalle de la factura
            crearDetalleFactura(num_factura)

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
    End Sub

    'METODO PARA CREAR LOS ARCHIVOS XML DE LA FACTURA A PAGAR
    Public Sub crearDetalleFactura(num_factura As Integer)
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_detalle_factura"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@num_factura", num_factura)
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\detallefactura.xml", "detallefactura", cmd)
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()

            'llama al metodo que consulta los montos de la facturas
            crearMontoFactura(num_factura)

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
    End Sub

    'METODO PARA CREAR LOS ARCHIVOS XML DE LA FACTURA A PAGAR
    Public Sub crearMontoFactura(num_factura As Integer)
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_montos_factura"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@num_factura", num_factura)
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\montofactura.xml", "montofactura", cmd)

            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
    End Sub

    'METODO PARA CREAR LOS ARCHIVOS XML DE LA FACTURA PROFORMA
    Public Sub crearFacturaProforma(num_orden As Integer)
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consultar_productos"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@num_orden", num_orden)
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\detalleProforma.xml", "detalleProforma", cmd)

            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
    End Sub

    'METODO PARA CREAR LOS ARCHIVOS XML DE LA FACTURA PARA LA COCINA
    Public Sub crearFacturaCocina(num_factura As Integer, cod_usuario As String)
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_factura_express"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@num_factura", num_factura)
                .AddWithValue("@cod_usuario", cod_usuario)
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\facturaExpress.xml", "facturaExpress", cmd)

            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()

            ' llama al metodo que consulta por el detalle de la factura
            crearDetalleFacturaCocina(num_factura)
        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
    End Sub

    'METODO PARA CREAR LOS ARCHIVOS XML DE LA FACTURA A PAGAR
    Public Sub crearDetalleFacturaCocina(num_factura As Integer)
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_detalle_factura"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@num_factura", num_factura)
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\detallefacturaexpress.xml", "detallefacturaexpress", cmd)
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()

            'llama al metodo que consulta los montos de la facturas
            crearMontoFacturaCocina(num_factura)

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
    End Sub

    'METODO PARA CREAR LOS ARCHIVOS XML DE LA FACTURA EXPRESS O COCINA A PAGAR
    Public Sub crearMontoFacturaCocina(num_factura As Integer)
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_montos_factura_express"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@num_factura", num_factura)
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\montofacturaespress.xml", "montofacturaespress", cmd)

            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub crearXML(tablas As DataSet, url As String, nombre As String, cmd As SqlCommand)
        Using adaptador As New SqlDataAdapter(cmd)
            ' se asigna el nombre al dataset
            tablas = New DataSet(nombre)
            ' llena el data set
            adaptador.Fill(tablas, nombre)
            ' se crea el archivo XML en la tuta especificada
            My.Computer.FileSystem.CreateDirectory("C:\XML")
            tablas.WriteXml(url, XmlWriteMode.WriteSchema)
        End Using
    End Sub

    Public Function obtenerFacturasPagadas(ByVal cod_usuario As String, ByVal fecha_inicio As String) As List(Of List(Of String))
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        Dim factura As List(Of String)
        Dim lector As SqlDataReader
        Dim listaFacturas As New List(Of List(Of String))
        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_facturas_pagadas"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento

            While lector.Read
                'instancia del objeto
                factura = New List(Of String)
                factura.Add(lector(0))
                factura.Add(lector(1))
                factura.Add(lector(2))
                factura.Add(lector(3))
                factura.Add(lector(4))
                factura.Add(lector(5))
                factura.Add(lector(6))

                listaFacturas.Add(factura)
            End While

            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()

        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
        End Try

        Return listaFacturas

    End Function

    Public Function modificarTipoOrden(factura As Integer, tipo As String, monto As Double) As Boolean
        'abre la conexion
        conexion = conexionDB.abrirConexion
        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_modificar_tipo_orden"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion
        ' asigna los parametros a enviar al procedimiento
        With cmd.Parameters
            .AddWithValue("@numFactura", factura)
            .AddWithValue("@tipo", tipo)
            .AddWithValue("@monto", monto)
        End With
        Try
            ' ejecuta la consulta a la base
            cmd.ExecuteNonQuery()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return True
        Catch ex As Exception
            ' cierra la conexion
            conexionDB.cerrarConexion()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            Return False
        End Try
    End Function

End Class
