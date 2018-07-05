Imports System.Data.SqlClient
Public Class ClienteDatos
    ' variables locales y publicas
    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD

    Dim clienteTelefono As New ClienteTelefonoDatos
    Dim clienteDireccion As New ClienteDireccionDatos
    Dim clientex As New Cliente

    Public Sub New()
        conexionDB = New ConexionBD

    End Sub

    ' metodo que se encarga de obtener todos los meseros en la base de datos
    Public Function obtenerClientes() As List(Of Cliente)
        ' lista que obtendrá todos los clientes
        Dim listaClientes As List(Of Cliente) = New List(Of Cliente)
        ' objeto que obtendrá a los clientes
        Dim cliente As Cliente
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los meseros de la base de datos
                cmd = New SqlCommand("SELECT * FROM FAC.clientes OrdER BY nombre_cliente ASC")
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
                    cliente = New Cliente
                    ' se asignan los datos del cliente
                    cliente.CodClienteSG = ConversionDatosDB.VerificarNulo(lector("cod_cliente"), -1)
                    cliente.NombreClienteSG = ConversionDatosDB.VerificarNulo(lector("nombre_cliente"), "Desconocido")
                    ' se agrega a la lista de clientes
                    listaClientes.Add(cliente)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaClientes
    End Function

    Public Function obtenerClientePorId(ByVal codCliente As Integer) As Cliente
        ' lista que obtendrá todos los clientes
        ' objeto que obtendrá a los clientes
        Dim cliente As Cliente = New Cliente
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los meseros de la base de datos
                cmd = New SqlCommand("select * from fac.clientes where cod_cliente = " & codCliente)
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
                    cliente.CodClienteSG = ConversionDatosDB.VerificarNulo(lector("cod_cliente"), -1)
                    cliente.NombreClienteSG = ConversionDatosDB.VerificarNulo(lector("nombre_cliente"), "Desconocido")
                    cliente.tipoIdentSG = ConversionDatosDB.VerificarNulo(lector("tipoIdentificacion"), 0)
                    cliente.identificacionSG = ConversionDatosDB.VerificarNulo(lector("identificacion"), 0)
                    cliente.Apellido1SG = ConversionDatosDB.VerificarNulo(lector("apellido1"), "Desconocido")
                    cliente.Apellido2SG = ConversionDatosDB.VerificarNulo(lector("apellido2"), "Desconocido")
                    cliente.diplomaticoSG = ConversionDatosDB.VerificarNulo(lector("diplomatico"), 0)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        cliente.Telefonos_ = clienteTelefono.obtenerTelefonosPorCliente(cliente)
        cliente.Direcciones_ = clienteDireccion.obtenerDireccionesPorCliente(cliente)
        Return cliente
    End Function

    Public Function obtenerClientePorTelefono(ByVal telefono As String) As Cliente
        ' lista que obtendrá todos los clientes
        ' objeto que obtendrá a los clientes
        Dim cliente As Cliente = New Cliente
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los meseros de la base de datos
                cmd = New SqlCommand("select * from fac.clientes where telefono like '%" & telefono & "%'")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    cliente = New Cliente
                    ' se asignan los datos del cliente
                    cliente.CodClienteSG = ConversionDatosDB.VerificarNulo(lector(0), -1)
                    cliente.NombreClienteSG = ConversionDatosDB.VerificarNulo(lector(1), "Desconocido")
                    cliente.CreditoSG = ConversionDatosDB.VerificarNulo(lector(2), 0)
                    cliente.tipoIdentSG = ConversionDatosDB.VerificarNulo(lector(5), 0)
                    cliente.identificacionSG = ConversionDatosDB.VerificarNulo(lector(6), 0)
                    cliente.Apellido1SG = ConversionDatosDB.VerificarNulo(lector(7), "")
                    cliente.Apellido2SG = ConversionDatosDB.VerificarNulo(lector(8), "")
                    cliente.diplomaticoSG = ConversionDatosDB.VerificarNulo(lector(9), 0)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return cliente
    End Function

    Public Function InsertarCliente(ByVal cliente As Cliente) As Boolean
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)

                cmd = New SqlCommand("INSERT INTO FAC.clientes(cod_cliente, nombre_cliente,credito, cheque, tipoIdentificacion, identificacion, apellido1, apellido2, diplomatico) VALUES (" & codigoCliente() & ", '" & cliente.NombreClienteSG & "', NULL, NULL," & cliente.tipoIdentSG & ", " & cliente.identificacionSG & ", '" & cliente.Apellido1SG & "', '" & cliente.Apellido2SG & "' ," & cliente.diplomaticoSG & ")")

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

    Public Function actualizarCliente(ByVal cliente As Cliente) As Boolean
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)

                'cmd = New SqlCommand("INSERT INTO FAC.clientes(cod_cliente, nombre_cliente, e_mail, telefono, credito, cheque, padre, apellido, madre, encargado, num_emergencia, foto, nivel) VALUES (" & codigoCliente() & ", '" & cliente.NombreClienteSG & "', " & cliente.EMailSG & ", '" & cliente.TelefonoSG & "', " & cliente.CreditoSG & ", 0, NULL, '" & cliente.ApellidoSG & "' , NULL, NULL, NULL, NULL, NULL)")
                cmd = New SqlCommand("UPDATE FAC.clientes set nombre_cliente = '" & cliente.NombreClienteSG & "', apellido1 = '" & cliente.Apellido1SG & "', apellido2 = '" & cliente.Apellido2SG & "', tipoIdentificacion = " & cliente.tipoIdentSG & ", identificacion = " & cliente.identificacionSG & ", diplomatico = " & cliente.diplomaticoSG & " WHERE cod_cliente = " & cliente.CodClienteSG)
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

    Public Function codigoCliente() As Integer
        Dim lector As SqlDataReader
        Dim codCliente As Integer = 0
        Dim cmd2 As SqlCommand
        Try
            Using (conexion)
                conexion = conexionDB.abrirConexion()
                cmd2 = New SqlCommand("SELECT MAX(cod_cliente) + 1 FROM FAC.clientes")
                cmd2.CommandType = CommandType.Text
                cmd2.Connection = conexion
                lector = cmd2.ExecuteReader
                While lector.Read
                    codCliente = ConversionDatosDB.VerificarNulo(lector(0), 0)
                End While
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return codCliente
        End Try
        Return codCliente
    End Function

    Public Function eliminarCliente(ByVal clienteID As Integer) As Boolean
        conexion = conexionDB.abrirConexion()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_eliminar_cliente"
        cmd.Connection = conexion

        With cmd.Parameters
            .AddWithValue("@idCliente", clienteID)
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




    Public Function obtenerClientePorTelefono2(ByVal telefono As String) As Cliente
        ' lista que obtendrá todos los clientes
        ' objeto que obtendrá a los clientes
        Dim cliente As Cliente = New Cliente
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los meseros de la base de datos
                cmd = New SqlCommand("select c.cod_cliente,  c.nombre_cliente from fac.clientes c
                                      INNER JOIN [FAC].[clientes_telefonos] t ON c.cod_cliente = t.cod_cliente
                                      INNER JOIN FAC.clientes_direcciones d ON c.cod_cliente = d.cod_cliente
                                      WHERE t.telefono = '" & telefono & "'")

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
                    cliente.CodClienteSG = ConversionDatosDB.VerificarNulo(lector("cod_cliente"), -1)
                    cliente.NombreClienteSG = ConversionDatosDB.VerificarNulo(lector("nombre_cliente"), "Desconocido")

                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        cliente.Telefonos_ = clienteTelefono.obtenerTelefonosPorCliente(cliente)

        Return cliente
    End Function

End Class