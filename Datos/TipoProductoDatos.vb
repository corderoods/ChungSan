Imports System.Data.SqlClient
Public Class TipoProductoDatos
    ' variables locales y publicas
    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD
    Dim msj As Mensaje

    Public Sub New()
        conexionDB = New ConexionBD
    End Sub

    ' metodo que se encarga de obtener todos los tipos de producto en la base ddatos
    Public Function obtenerTiposProducto() As List(Of TipoProducto)
        ' lista que obtendrá todos los tipos de producto
        Dim listaTiposProdcuto As List(Of TipoProducto) = New List(Of TipoProducto)
        ' objeto que obtendrá a los tipos de producto
        Dim tipoProducto As TipoProducto
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los tipos de producto de la base de datos
                cmd = New SqlCommand("SELECT INV.tipo_producto.* FROM INV.tipo_producto where id_tipo_producto in (select INV.productos.id_tipo_producto  from inv.productos) order by descripcion asc")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    tipoProducto = New TipoProducto
                    ' se asignan los datos del tipo de producto
                    tipoProducto.IdTipoProductoSG = ConversionDatosDB.VerificarNulo(lector(0), -1)
                    tipoProducto.DescripcionSG = ConversionDatosDB.VerificarNulo(lector(1), "Desconocido")
                    tipoProducto.BebidaSG = ConversionDatosDB.VerificarNulo(lector(2), "")
                    ' se agrega a la lista de tipos de producto
                    listaTiposProdcuto.Add(tipoProducto)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaTiposProdcuto
    End Function

    ' metodo que se encarga de obtener todos los tipos de producto en la base de datos
    Public Function obtenerTodasCategorias() As DataTable
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' consulta a la base de datos por todos los tipos de producto de la base de datos
            cmd = New SqlCommand("SELECT id_tipo_producto AS Codigo, descripcion AS Nombre, CASE WHEN bebida = 'S' THEN 'Si' WHEN bebida = 'N' THEN 'No' END AS Bebida FROM INV.tipo_producto")
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.Text
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion

            ' se ejecuta la consulta y se valida que todo este bien
            If cmd.ExecuteNonQuery Then
                '' datatable que guardara todas las categorias o tipos de productos para mostrarlas en la ventana
                Using nuevatabla As New DataTable
                    Using adaptador As New SqlDataAdapter(cmd)
                        '' se llena la tabla con todas las categorias o tipos de productos
                        adaptador.Fill(nuevatabla)
                        '' se cierra la conexion con la base de datos
                        conexionDB.cerrarConexion()
                        ' retorna las categorias
                        Return nuevatabla
                    End Using
                End Using
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    ' metodo que se encarga de obtener todos los tipos de producto en la base de datos
    Public Function obtenerCategoriaPorId(id_tipo_producto As Int16) As TipoProducto
        Try
            ' donde se almacenan los datos de la consulta
            Dim lector As SqlDataReader
            ' objeto que retornara el tipo de producto consultado
            Dim tipo_producto As New TipoProducto
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' consulta a la base de datos por todos los tipos de producto de la base de datos
            cmd = New SqlCommand("SELECT id_tipo_producto, descripcion, bebida FROM INV.tipo_producto WHERE id_tipo_producto =" & id_tipo_producto)
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.Text
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion

            ' se ejecuta la consulta y se valida que todo este bien
            lector = cmd.ExecuteReader

            ' se recorre hasta obtener todos los registros
            While lector.Read
                ' se asignan los datos del producto
                tipo_producto.IdTipoProductoSG = ConversionDatosDB.VerificarNulo(lector(0), -1)
                tipo_producto.DescripcionSG = ConversionDatosDB.VerificarNulo(lector(1), "Desconocido")
                tipo_producto.BebidaSG = ConversionDatosDB.VerificarNulo(lector(2), False)

                Return tipo_producto
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return Nothing
    End Function

    ' metodo que se encarga de ingresar una nueva categoria
    Public Function ingresarTipoProducto(categoria As TipoProducto) As Boolean
        Dim lector As SqlDataReader
        Try
            Using (conexion)
                ' se abre la conexion
                conexion = conexionDB.abrirConexion()
                ' se especifica la consulta
                cmd = New SqlCommand("INSERT INTO INV.tipo_producto (id_tipo_producto, descripcion, bebida) VALUES((SELECT (MAX(id_tipo_producto)+1) FROM INV.tipo_producto), '" & categoria.DescripcionSG & "', '" & categoria.BebidaSG & "')")
                ' se declara el tipo de consulta
                cmd.CommandType = CommandType.Text
                'se asigna la conexion
                cmd.Connection = conexion
                ' se ejecuta la consulta
                lector = cmd.ExecuteReader
                ' se cierra la conexion
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    ' metodo que se encarga de modificar una categoria
    Public Function modificarTipoProducto(categoria As TipoProducto) As Boolean
        Dim lector As SqlDataReader
        Try
            Using (conexion)
                ' se abre la conexion
                conexion = conexionDB.abrirConexion()
                ' se especifica la consulta
                cmd = New SqlCommand("UPDATE INV.tipo_producto SET descripcion = '" & categoria.DescripcionSG & "', bebida = '" & categoria.BebidaSG & "' WHERE id_tipo_producto = " & categoria.IdTipoProductoSG)
                ' se declara el tipo de consulta
                cmd.CommandType = CommandType.Text
                'se asigna la conexion
                cmd.Connection = conexion
                ' se ejecuta la consulta
                lector = cmd.ExecuteReader
                ' se cierra la conexion
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    ' metodo que se encarga de eliminar una categoria
    Public Function eliminarTipoProducto(id_categoria As Int16) As Boolean
        Dim lector As SqlDataReader
        Try
            Using (conexion)
                ' se abre la conexion
                conexion = conexionDB.abrirConexion()
                ' se especifica la consulta
                cmd = New SqlCommand("DELETE INV.tipo_producto WHERE id_tipo_producto = " & id_categoria)
                ' se declara el tipo de consulta
                cmd.CommandType = CommandType.Text
                'se asigna la conexion
                cmd.Connection = conexion
                ' se ejecuta la consulta
                lector = cmd.ExecuteReader
                ' se cierra la conexion
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            msj = New Mensaje
            msj.lblMensaje.Text = "Hay productos que dependen de esta categoria. No se puede eliminar"
            msj.tipoMensaje("error")
            msj.ShowDialog()
            'MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

End Class
