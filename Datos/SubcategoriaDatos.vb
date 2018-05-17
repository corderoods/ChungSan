Imports System.Data.SqlClient
Public Class SubcategoriaDatos

    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD
    Dim msj As Mensaje

    Public Sub New()
        conexionDB = New ConexionBD
    End Sub

    Public Function obtenerSubcategoriasPorTipo(ByVal codTipoProducto As Integer) As List(Of Subcategoria)
        ' lista que obtendrá todos los productos segun el tipo
        Dim subcategorias As List(Of Subcategoria) = New List(Of Subcategoria)
        ' objeto que obtendrá a los productos segun el tipo
        Dim subcategoria As Subcategoria
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los productos segun el tipo de la base de datos
                cmd = New SqlCommand("SELECT * FROM INV.subcategorias where tipo_producto = " & codTipoProducto & " order by nombre ASC")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    subcategoria = New Subcategoria
                    ' se asignan los datos del producto segun el tipo
                    subcategoria.IdSubcategoria_ = ConversionDatosDB.VerificarNulo(lector("id_subcategoria"), -1)
                    subcategoria.Nombre_ = ConversionDatosDB.VerificarNulo(lector("nombre"), "Desconocido")
                    subcategoria.Categoria_ = ConversionDatosDB.VerificarNulo(lector("tipo_producto"), "Desconocido")
                    ' se agrega a la lista de productos segun el tipo
                    subcategorias.Add(subcategoria)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return subcategorias
    End Function

    ' metodo que se encarga de obtener todos los tipos de producto en la base de datos
    Public Function obtenerSubcategoriasPorTipoProducto(ByVal tipoProducto As Integer) As DataTable
        ' lista que obtendrá todos los tipos de producto
        Dim listaTiposProdcuto As List(Of Subcategoria) = New List(Of Subcategoria)
        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los tipos de producto de la base de datos
                cmd = New SqlCommand("SELECT id_subcategoria AS Codigo, nombre AS Nombre FROM INV.subcategorias where tipo_producto = " & tipoProducto & " order by nombre asc")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se recorre hasta obtener todos los registros
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

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        Return Nothing
    End Function

    ' metodo que se encarga de obtener todos los tipos de producto en la base de datos
    Public Function obtenerSubategoriaPorId(ByVal idSubcategoria As Integer) As Subcategoria
        Try
            ' donde se almacenan los datos de la consulta
            Dim lector As SqlDataReader
            ' objeto que retornara el tipo de producto consultado
            Dim subcategoria As New Subcategoria
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' consulta a la base de datos por todos los tipos de producto de la base de datos
            cmd = New SqlCommand("SELECT * FROM INV.subcategorias WHERE id_subcategoria = " & idSubcategoria)
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.Text
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion

            ' se ejecuta la consulta y se valida que todo este bien
            lector = cmd.ExecuteReader

            ' se recorre hasta obtener todos los registros
            While lector.Read
                ' se asignan los datos del producto
                subcategoria.IdSubcategoria_ = ConversionDatosDB.VerificarNulo(lector("id_subcategoria"), -1)
                subcategoria.Nombre_ = ConversionDatosDB.VerificarNulo(lector("nombre"), "Desconocido")
                subcategoria.Categoria_ = ConversionDatosDB.VerificarNulo(lector("tipo_producto"), False)

                Return subcategoria
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return Nothing
    End Function

    ' metodo que se encarga de ingresar una nueva categoria
    Public Function ingresarSubcategoria(ByVal subCategoria As Subcategoria) As Boolean
        Dim lector As SqlDataReader
        Try
            Using (conexion)
                ' se abre la conexion
                conexion = conexionDB.abrirConexion()
                ' se especifica la consulta
                cmd = New SqlCommand("INSERT INTO INV.subcategorias (nombre, tipo_producto) VALUES('" & subCategoria.Nombre_ & "', " & subCategoria.Categoria_ & ")")
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
    Public Function modificarSubcategoria(ByVal subcategoria As Subcategoria) As Boolean
        Dim lector As SqlDataReader
        Try
            Using (conexion)
                ' se abre la conexion
                conexion = conexionDB.abrirConexion()
                ' se especifica la consulta
                cmd = New SqlCommand("UPDATE INV.subcategorias SET nombre = '" & subcategoria.Nombre_ & "' WHERE id_subcategoria = " & subcategoria.IdSubcategoria_)
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
    Public Function eliminarSubcategoria(ByVal subategoriaId As Integer) As Boolean
        conexion = conexionDB.abrirConexion()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_eliminar_subcategoria"
        cmd.Connection = conexion

        With cmd.Parameters
            .AddWithValue("@idSubcategoria", subategoriaId)
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

End Class
