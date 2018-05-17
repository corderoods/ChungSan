Imports System.Data.SqlClient

Public Class ProveedorDatos

    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD

    Public Sub New()
        conexionDB = New ConexionBD
    End Sub

    ' metodo que se encarga de obtener todos los meseros en la base de datos
    Public Function obtenerProveedores() As List(Of Proveedor)
        ' lista que obtendrá todos los clientes
        Dim listaProveedores As List(Of Proveedor) = New List(Of Proveedor)
        ' objeto que obtendrá a los clientes
        Dim proveedor As Proveedor
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los meseros de la base de datos
                cmd = New SqlCommand("SELECT * FROM PRO.proveedores OrdER BY nombre ASC")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                ' conexionDB.cerrarConexion()
                While lector.Read
                    'instancia del objeto
                    proveedor = New Proveedor
                    ' se asignan los datos del cliente
                    proveedor.CodigoProveedor = ConversionDatosDB.VerificarNulo(lector("cod_proveedor"), -1)
                    proveedor.NombreProveedor = ConversionDatosDB.VerificarNulo(lector("nombre"), "Desconocido")
                    proveedor.TelefonoProveedor = ConversionDatosDB.VerificarNulo(lector("telefono"), "Desconocido") ' se agrega a la lista de clientes
                    listaProveedores.Add(proveedor)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaProveedores
    End Function

    Public Function obtenerProveedorPorId(ByVal codProveedor As Integer) As Proveedor
        ' lista que obtendrá todos los clientes
        ' objeto que obtendrá a los clientes
        Dim cliente As Proveedor = New Proveedor
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los meseros de la base de datos
                cmd = New SqlCommand("select * from PRO.proveedores where cod_proveedor = " & codProveedor)
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    ' se asignan los datos del cliente
                    cliente.CodigoProveedor = ConversionDatosDB.VerificarNulo(lector("cod_proveedor"), -1)
                    cliente.NombreProveedor = ConversionDatosDB.VerificarNulo(lector("nombre"), "Desconocido")
                    cliente.TelefonoProveedor = ConversionDatosDB.VerificarNulo(lector("telefono"), "")
                    cliente.DireccionProveedor = ConversionDatosDB.VerificarNulo(lector("direccion"), "")
                    cliente.ObservacionesProveedor = ConversionDatosDB.VerificarNulo(lector("observaciones"), "")
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        Return cliente
    End Function

    Public Function InsertarProveedor(ByVal proveedor As Proveedor) As Boolean
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)

                cmd = New SqlCommand("INSERT INTO PRO.proveedores(cod_proveedor,nombre,telefono,fax,contacto,e_mail,direccion,observaciones,credito,dias_credito)
                                     VALUES(ISNULL((SELECT MAX(cod_proveedor) + 1 FROM PRO.proveedores) ,0), '" & proveedor.NombreProveedor & "', '" & proveedor.TelefonoProveedor & "', NULL, NULL, NULL, '" & proveedor.DireccionProveedor & "', '" & proveedor.ObservacionesProveedor & "', NULL, NULL)")
                cmd.CommandType = CommandType.Text

                conexion = conexionDB.abrirConexion()
                cmd.Connection = conexion
                lector = cmd.ExecuteReader
                conexionDB.cerrarConexion()

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return True
    End Function

    Public Function actualizarProveedor(ByVal proveedor As Proveedor) As Boolean
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)

                cmd = New SqlCommand("UPDATE PRO.proveedores 
                                        set nombre = '" & proveedor.NombreProveedor & "',
                                            telefono = '" & proveedor.TelefonoProveedor & "',
                                            direccion = '" & proveedor.DireccionProveedor & "',
                                            observaciones = '" & proveedor.ObservacionesProveedor & "'
                                        WHERE cod_proveedor = " & proveedor.CodigoProveedor)
                cmd.CommandType = CommandType.Text

                conexion = conexionDB.abrirConexion()
                cmd.Connection = conexion
                lector = cmd.ExecuteReader
                conexionDB.cerrarConexion()

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return True
    End Function

    Public Function EliminarProveedor(ByVal proveedor As Proveedor) As Boolean
        conexion = conexionDB.abrirConexion()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_eliminar_proveedor"
        cmd.Connection = conexion

        With cmd.Parameters
            .AddWithValue("@idProveedor", proveedor.CodigoProveedor)
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
