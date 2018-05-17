Imports System.Data.SqlClient
Public Class OrdenDatos
    ' variables locales y publicas
    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD
    Public productoDatos As ProductoDatos

    Public Sub New()
        conexionDB = New ConexionBD
        cmd = New SqlCommand
        productoDatos = New ProductoDatos
    End Sub

    ' metodo que se encarga de obtener todas las ordenes en la base de datos
    Public Function obtenerOrdenSinPagar() As List(Of Orden)
        ' lista que obtendrá todas las ordenes segun el tipo
        Dim listaOrdenes As List(Of Orden) = New List(Of Orden)
        ' objeto que obtendrá todas las ordenes
        Dim orden As Orden
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()

                cmd.CommandText = "FAC.sp_obtener_ordenes_sin_pagar"
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.StoredProcedure
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                cmd.Parameters.Clear()
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    orden = New Orden

                    ' se asignan todas las ordenes
                    orden.NumOrden = ConversionDatosDB.VerificarNulo(lector("num_orden"), -1)
                    orden.NumMesa = ConversionDatosDB.VerificarNulo(lector("num_mesa"), -1)
                    orden.CodCliente = ConversionDatosDB.VerificarNulo(lector("cod_cliente"), -1)
                    orden.Ubicacion_ = ConversionDatosDB.VerificarNulo(lector("ubicacion"), -1)
                    orden.NombreCliente_ = ConversionDatosDB.VerificarNulo(lector("nombre"), "")

                    ' se agrega a la lista de todas las ordenes
                    listaOrdenes.Add(orden)
                End While
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaOrdenes
    End Function

    Public Function obtenerPedidosPorOrden(ByVal idOrden As Integer) As List(Of OrdenTemporal)
        ' lista que obtendrá todos los pedidos de una orden
        Dim listaOrdenes As List(Of OrdenTemporal) = New List(Of OrdenTemporal)
        ' objeto que obtendrá todos los pedidos de una orden
        Dim detalleOrden As OrdenTemporal
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los pedidos de una orden de la base de datos
                cmd.CommandText = "FAC.sp_obtener_detalle_orden"
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.StoredProcedure
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                cmd.Parameters.Clear()
                With cmd.Parameters
                    .AddWithValue("@idOrden", idOrden)
                End With
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    detalleOrden = New OrdenTemporal
                    ' se asignan todos los pedidos de una orden

                    detalleOrden.NumLinea = ConversionDatosDB.VerificarNulo(lector("num_linea"), -1)
                    detalleOrden.Cantidad_ = ConversionDatosDB.VerificarNulo(lector("cantidad"), -1)
                    detalleOrden.CodProducto = ConversionDatosDB.VerificarNulo(lector("cod_producto"), -1)
                    detalleOrden.NombreProducto_ = ConversionDatosDB.VerificarNulo(lector("nombre"), "Desconocido")
                    ' se agrega a la lista de todos los pedidos de una orden
                    listaOrdenes.Add(detalleOrden)
                End While
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaOrdenes
    End Function

    Public Function insertarOrden(ByVal tipo As String, ByVal salonero As Integer, ByVal mesa As Integer, ByVal empleado As Integer, ByVal clienteId As Integer, ByVal direccion As String, ByVal telefono As String, ByVal nombreCliente As String) As Boolean
        Dim lector As SqlDataReader
        Try
            Using (conexion)
                conexion = conexionDB.abrirConexion()
                cmd.CommandText = "FAC.sp_insertar_orden"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = conexion
                cmd.Parameters.Clear()
                With cmd.Parameters
                    .AddWithValue("@tipo", tipo)
                    .AddWithValue("@salonero", salonero)
                    .AddWithValue("@mesa", mesa)
                    .AddWithValue("@empleado", empleado)
                    .AddWithValue("@clienteId", clienteId)
                    .AddWithValue("@direccion", direccion)
                    .AddWithValue("@telefono", telefono)
                    .AddWithValue("@nombreCliente", nombreCliente)
                End With
                lector = cmd.ExecuteReader
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Function InsertarDetalleOrden(ByVal codProducto As Integer, ByVal orden As Integer) As Boolean
        Try
            Using (conexion)

                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todas las ordenes de la base de datos
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "FAC.sp_insertar_detalle_orden"
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                With cmd.Parameters
                    .AddWithValue("@idOrden", orden)
                    .AddWithValue("@producto", codProducto)
                End With
                cmd.ExecuteReader()
                cmd.Parameters.Clear()

                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Function eliminarOrden(ByVal numOrden As Integer) As Boolean
        conexion = conexionDB.abrirConexion()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_eliminarOrden_m"
        cmd.Connection = conexion

        With cmd.Parameters
            .AddWithValue("@numeroOrden", numOrden)
        End With

        Try
            cmd.ExecuteScalar()
            cmd.Parameters.Clear()
            conexionDB.cerrarConexion()
            Return True
        Catch ex As Exception
            cmd.Parameters.Clear()
            conexionDB.cerrarConexion()
            Return 0
        End Try

    End Function

    Public Function eliminarDetalleOrden(ByVal numOrden As Integer, ByVal linea As Integer) As Boolean
        conexion = conexionDB.abrirConexion()
        Try
            Using (conexion)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "FAC.sp_eliminar_detalle_orden"
                cmd.Connection = conexion

                cmd.Parameters.Clear()
                With cmd.Parameters
                    .AddWithValue("@idOrden", numOrden)
                    .AddWithValue("@linea", linea)
                End With

                cmd.ExecuteScalar()
                conexionDB.cerrarConexion()
                Return 0
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Function modificarCantidadDetalleOrden(ByVal numOrden As Integer, ByVal linea As Integer, ByVal cantidad As Integer) As Boolean
        Try
            Using (conexion)
                conexion = conexionDB.abrirConexion()

                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "FAC.sp_modificar_cantidad_detalle"
                cmd.Connection = conexion

                cmd.Parameters.Clear()
                With cmd.Parameters
                    .AddWithValue("@idOrden", numOrden)
                    .AddWithValue("@linea", linea)
                    .AddWithValue("@cantidad", cantidad)
                End With
                cmd.ExecuteScalar()
            End Using
        Catch ex As Exception
            conexionDB.cerrarConexion()
            Return False
        End Try
        conexionDB.cerrarConexion()
        Return True
    End Function

    Public Function modificarObservacionesDetalleOrden(ByVal numOrden As Integer, ByVal linea As Integer, ByVal observaciones As String) As Boolean
        conexion = conexionDB.abrirConexion()

        Dim lector As SqlDataReader
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_modificar_observaciones_detalle"
        cmd.Connection = conexion

        With cmd.Parameters
            .AddWithValue("@idOrden", numOrden)
            .AddWithValue("@linea", linea)
            .AddWithValue("@observaciones", observaciones)
        End With

        Try
            lector = cmd.ExecuteReader()
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read
                    ' se limpian los parametros
                    cmd.Parameters.Clear()
                    ' retorna el monto
                    Dim resultado = lector(0).ToString()
                    If resultado = "PEDIDO LISTO" Then
                        Return False
                    Else
                        Return True
                    End If
                End While
            End If
            conexionDB.cerrarConexion()
            Return True
        Catch ex As Exception
            cmd.Parameters.Clear()
            conexionDB.cerrarConexion()
            Return False
        End Try
        Return True
    End Function

    Public Function obtenerDetalleOrdenTemporal(ByVal orden As Integer, ByVal producto As Integer) As OrdenTemporal
        ' objeto que obtendrá a los productos 
        Dim ordenTemporal As OrdenTemporal = New OrdenTemporal
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los productos de la base de datos
                cmd.CommandText = "FAC.sp_obtener_detalle_producto_orden"
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.StoredProcedure
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                cmd.Parameters.Clear()
                With cmd.Parameters
                    .AddWithValue("@idOrden", orden)
                    .AddWithValue("@producto", producto)
                End With
                ' se ejecuta la consulta
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    ' se asignan los datos del producto
                    ordenTemporal.NumOrden = ConversionDatosDB.VerificarNulo(lector(0), -1)
                    ordenTemporal.NumLinea = ConversionDatosDB.VerificarNulo(lector(1), -1)
                    ordenTemporal.Cantidad_ = ConversionDatosDB.VerificarNulo(lector(3), -1)
                    ordenTemporal.CodProducto = ConversionDatosDB.VerificarNulo(lector(2), -1)
                    ordenTemporal.Observaciones_ = ConversionDatosDB.VerificarNulo(lector(11), "")
                    ordenTemporal.NombreProducto_ = productoDatos.obtenerProductoPorCod(producto).Nombre_
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return ordenTemporal
    End Function

    Public Function obtenerOrdenPorId(ByVal numorden As Integer) As Orden
        ' objeto que obtendrá a los productos 
        Dim orden As Orden = New Orden
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los productos de la base de datos
                cmd.CommandText = "FAC.sp_obtener_orden_por_id"
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.StoredProcedure
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                cmd.Parameters.Clear()
                With cmd.Parameters
                    .AddWithValue("@idOrden", numorden)
                End With
                ' se ejecuta la consulta
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    ' se asignan los datos del producto
                    orden.NumOrden = ConversionDatosDB.VerificarNulo(lector("num_orden"), -1)
                    orden.NumMesa = ConversionDatosDB.VerificarNulo(lector("num_mesa"), -1)
                    orden.CodEmpleado = ConversionDatosDB.VerificarNulo(lector("cod_empleado"), -1)
                    orden.CodCliente = ConversionDatosDB.VerificarNulo(lector("cod_cliente"), -1)
                    orden.CodSalonero = ConversionDatosDB.VerificarNulo(lector("cod_salonero"), -1)
                    orden.NombreCliente_ = ConversionDatosDB.VerificarNulo(lector("nombre"), -1)
                    orden.Fecha_ = ConversionDatosDB.VerificarNulo(lector("fecha"), -1)
                    orden.Ubicacion_ = ConversionDatosDB.VerificarNulo(lector("ubicacion"), -1)

                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return orden
    End Function

    Public Function verificaLlamadaMesero() As List(Of Orden)
        ' lista que obtendrá todas las ordenes segun el tipo
        Dim listaOrdenes As List(Of Orden) = New List(Of Orden)
        ' objeto que obtendrá todas las ordenes
        Dim orden As Orden
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todas las ordenes de la base de datos
                'cmd = New SqlCommand("select * from fac.orden_m where num_orden NOT IN (select num_orden from fac.factura_m) order by FAC.orden_m.num_orden asc")
                cmd.CommandText = "FAC.sp_verifica_llamada_mesero"
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.StoredProcedure
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                cmd.Parameters.Clear()
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    orden = New Orden
                    ' se asignan todas las ordenes

                    orden.NumOrden = ConversionDatosDB.VerificarNulo(lector("num_orden"), -1)
                    orden.NumMesa = ConversionDatosDB.VerificarNulo(lector("num_mesa"), -1)
                    orden.CodCliente = ConversionDatosDB.VerificarNulo(lector("cod_cliente"), -1)
                    orden.Ubicacion_ = ConversionDatosDB.VerificarNulo(lector("ubicacion"), -1)
                    orden.NombreCliente_ = ConversionDatosDB.VerificarNulo(lector("nombre"), -1)
                    ' se agrega a la lista de todas las ordenes
                    listaOrdenes.Add(orden)
                End While
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaOrdenes
    End Function

    Public Sub actualizarLlamadaMesero(ByVal idOrden As Integer)
        Try
            Using (conexion)
                conexion = conexionDB.abrirConexion()
                cmd.CommandText = "FAC.sp_actualiza_llamada_mesero"

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = conexion
                cmd.Parameters.Clear()

                With cmd.Parameters
                    .AddWithValue("@idOrden", idOrden)
                End With
                cmd.ExecuteReader()
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function obtenerProductosPreparados(ByVal orden As Integer) As List(Of OrdenTemporal)
        Dim lista As List(Of OrdenTemporal) = New List(Of OrdenTemporal)
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los productos de la base de datos
                cmd.CommandText = "FAC.sp_obtener_productos_preparados"
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.StoredProcedure
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                cmd.Parameters.Clear()
                With cmd.Parameters
                    .AddWithValue("@idOrden", orden)
                End With
                ' se ejecuta la consulta
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    Dim ordenTemporal As OrdenTemporal = New OrdenTemporal
                    ' se asignan los datos del producto
                    ordenTemporal.CodProducto = ConversionDatosDB.VerificarNulo(lector("cod_producto"), -1)
                    lista.Add(ordenTemporal)
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return lista
    End Function

End Class