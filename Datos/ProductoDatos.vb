Imports System.Data.SqlClient
Public Class ProductoDatos
    ' variables locales y publicas
    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD
    Dim msj As Mensaje

    Public Sub New()
        conexionDB = New ConexionBD
    End Sub

    ' metodo que se encarga de obtener todos los productos en la base de datos
    Public Function obtenerProductoPorTipo(ByVal codTipoProducto As Integer) As List(Of Producto)
        ' lista que obtendrá todos los productos segun el tipo
        Dim listaProductos As List(Of Producto) = New List(Of Producto)
        ' objeto que obtendrá a los productos segun el tipo
        Dim producto As Producto
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los productos segun el tipo de la base de datos
                cmd = New SqlCommand("SELECT * FROM INV.productos where id_tipo_producto = " & codTipoProducto & " and eliminado = 0 order by nombre ASC")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    producto = New Producto
                    ' se asignan los datos del producto segun el tipo
                    producto.CodProducto = ConversionDatosDB.VerificarNulo(lector(0), -1)
                    producto.Nombre_ = ConversionDatosDB.VerificarNulo(lector(1), "Desconocido")
                    ' se agrega a la lista de productos segun el tipo
                    listaProductos.Add(producto)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaProductos
    End Function

    Public Function obtenerProductoPorSubcategoria(ByVal codSubcategoria As Integer) As List(Of Producto)
        ' lista que obtendrá todos los productos segun el tipo
        Dim listaProductos As List(Of Producto) = New List(Of Producto)
        ' objeto que obtendrá a los productos segun el tipo
        Dim producto As Producto
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los productos segun el tipo de la base de datos
                cmd = New SqlCommand("SELECT * FROM INV.productos where subcategoria = " & codSubcategoria & " and eliminado = 0 order by nombre ASC")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    producto = New Producto
                    ' se asignan los datos del producto segun el tipo
                    producto.CodProducto = ConversionDatosDB.VerificarNulo(lector(0), -1)
                    producto.Nombre_ = ConversionDatosDB.VerificarNulo(lector(1), "Desconocido")
                    ' se agrega a la lista de productos segun el tipo
                    listaProductos.Add(producto)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaProductos
    End Function

    Public Function obtenerProductoPorTipoSinSubcategoria(ByVal codTipoProducto As Integer) As List(Of Producto)
        ' lista que obtendrá todos los productos segun el tipo
        Dim listaProductos As List(Of Producto) = New List(Of Producto)
        ' objeto que obtendrá a los productos segun el tipo
        Dim producto As Producto
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los productos segun el tipo de la base de datos
                cmd = New SqlCommand("select inv.productos.* 
                                        from inv.productos inner join inv.tipo_producto on inv.tipo_producto.id_tipo_producto = inv.productos.id_tipo_producto
                                        where inv.tipo_producto.id_tipo_producto = " & codTipoProducto & "
	                                        AND ( INV.productos.subcategoria not in(
											                                        select INV.subcategorias.id_subcategoria 
											                                        from INV.subcategorias inner join inv.tipo_producto 
												                                        on inv.tipo_producto.id_tipo_producto = inv.subcategorias.tipo_producto
											                                        where inv.tipo_producto.id_tipo_producto = " & codTipoProducto & " ) 
		                                        OR subcategoria is null)
                                            AND eliminado = 0 
                                        ORDER BY nombre asc")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    producto = New Producto
                    ' se asignan los datos del producto segun el tipo
                    producto.CodProducto = ConversionDatosDB.VerificarNulo(lector(0), -1)
                    producto.Nombre_ = ConversionDatosDB.VerificarNulo(lector(1), "Desconocido")
                    ' se agrega a la lista de productos segun el tipo
                    listaProductos.Add(producto)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaProductos
    End Function

    Public Function obtenerProductos() As List(Of Producto)
        ' lista que obtendrá todos los productos 
        Dim listaProductos As List(Of Producto) = New List(Of Producto)
        ' objeto que obtendrá a los productos 
        Dim producto As Producto
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los productos de la base de datos
                cmd = New SqlCommand("SELECT * FROM INV.productos where eliminado = 0 order by nombre ASC")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    producto = New Producto
                    ' se asignan los datos del producto
                    producto.CodProducto = ConversionDatosDB.VerificarNulo(lector(0), -1)
                    producto.Nombre_ = ConversionDatosDB.VerificarNulo(lector(1), "Desconocido")
                    ' se agrega a la lista de productos
                    listaProductos.Add(producto)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaProductos
    End Function

    Public Function obtenerProductoPorCod(ByVal cod As Integer) As Producto
        ' objeto que obtendrá a los productos 
        Dim producto As Producto = New Producto
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los productos de la base de datos
                cmd = New SqlCommand("SELECT * FROM INV.productos WHERE cod_producto = " & cod)
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    ' se asignan los datos del producto
                    producto.CodProducto = ConversionDatosDB.VerificarNulo(lector(0), -1)
                    producto.Nombre_ = ConversionDatosDB.VerificarNulo(lector(1), "Desconocido")
                    producto.PrecioVenta = ConversionDatosDB.VerificarNulo(lector(2), 0)
                    producto.IdTipoProducto = ConversionDatosDB.VerificarNulo(lector(8), 0)
                    producto.Subcategoria_ = ConversionDatosDB.VerificarNulo(lector("subcategoria"), 0)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return producto
    End Function

    ' metodo que se encarga de obtener todos los tipos de producto en la base de datos
    Public Function obtenerTodosProductos() As DataTable
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' consulta a la base de datos por todos los producto de la base de datos
            cmd = New SqlCommand("SELECT pr.cod_producto AS Codigo, pr.nombre AS Nombre, pr.precio_venta AS Precio, tp.descripcion AS Categoria 
                                    FROM INV.productos AS pr, inv.tipo_producto AS tp 
                                    WHERE pr.id_tipo_producto = tp.id_tipo_producto AND eliminado = 0
                                    ORDER BY tp.descripcion, pr.nombre ASC")
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

    ' metodo que se encarga de ingresar un nuevo producto
    Public Function ingresarProducto(producto As Producto) As Boolean
        Dim lector As SqlDataReader
        Try
            Using (conexion)
                ' se abre la conexion
                conexion = conexionDB.abrirConexion()
                If producto.Subcategoria_ = -1 Then
                    cmd = New SqlCommand("INSERT INTO INV.productos (cod_producto, nombre, precio_venta, promocion,descuento, afecta_inventario, cod_barra, cant_disponible, id_tipo_producto,compuesto, subcategoria,eliminado ) VALUES((SELECT (MAX(cod_producto)+1) FROM INV.productos), '" &
                                     producto.Nombre_ & "', " & producto.PrecioVenta & "," & producto.Promocion_ & "," & producto.Descuento_ & "," & producto.AfectaInventario & "," & producto.CodBarra & "," & producto.CantDisponible & "," & producto.IdTipoProducto & "," & producto.Compuesto_ & ", NULL,0)")
                Else
                    cmd = New SqlCommand("INSERT INTO INV.productos (cod_producto, nombre, precio_venta, promocion,descuento, afecta_inventario, cod_barra, cant_disponible, id_tipo_producto,compuesto, subcategoria,eliminado ) VALUES((SELECT (MAX(cod_producto)+1) FROM INV.productos), '" &
                                     producto.Nombre_ & "', " & producto.PrecioVenta & "," & producto.Promocion_ & "," & producto.Descuento_ & "," & producto.AfectaInventario & "," & producto.CodBarra & "," & producto.CantDisponible & "," & producto.IdTipoProducto & "," & producto.Compuesto_ & ", " & producto.Subcategoria_ & ",0)")
                End If
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

    ' metodo que se encarga de actualizar un producto
    Public Function modificarProducto(producto As Producto) As Boolean
        Dim lector As SqlDataReader
        Try
            Using (conexion)
                ' se abre la conexion
                conexion = conexionDB.abrirConexion()
                If producto.Subcategoria_ = -1 Then
                    cmd = New SqlCommand("UPDATE INV.productos 
                                    SET nombre = '" & producto.Nombre_ & "', 
                                        precio_venta = " & producto.PrecioVenta & ", 
                                        id_tipo_producto =" & producto.IdTipoProducto & ",
                                        subcategoria = NULL 
                                    WHERE cod_producto =  " & producto.CodProducto)
                Else
                    cmd = New SqlCommand("UPDATE INV.productos 
                                    SET nombre = '" & producto.Nombre_ & "', 
                                        precio_venta = " & producto.PrecioVenta & ", 
                                        id_tipo_producto =" & producto.IdTipoProducto & ",
                                        subcategoria = " & producto.Subcategoria_ & " 
                                    WHERE cod_producto =  " & producto.CodProducto)
                End If
                ' se especifica la consulta

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

    ' metodo que se encarga de eliminar un producto
    Public Function eliminarProducto(id_producto As Int16) As Boolean
        Dim lector As SqlDataReader
        Try
            Using (conexion)
                ' se abre la conexion
                conexion = conexionDB.abrirConexion()
                ' se especifica la consulta
                cmd = New SqlCommand("UPDATE INV.productos set eliminado = 1 WHERE cod_producto = " & id_producto)
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
            msj.lblMensaje.Text = "No se puede eliminar"
            msj.tipoMensaje("error")
            msj.ShowDialog()
            'MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function
End Class
