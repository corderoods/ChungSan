Imports SunChangSystem
Imports System.Data.SqlClient

Public Class ClienteTelefonoDatos

    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As New ConexionBD

    Public Sub New()

    End Sub

    Public Function obtenerTelefonosPorCliente(ByVal cliente As Cliente) As LinkedList(Of ClienteTelefono)
        Dim listaTelefonos As LinkedList(Of ClienteTelefono) = New LinkedList(Of ClienteTelefono)
        Dim telefono As ClienteTelefono
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los meseros de la base de datos
                cmd = New SqlCommand("select * from fac.clientes_telefonos where cod_cliente = " & cliente.CodClienteSG)
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    telefono = New ClienteTelefono
                    ' se asignan los datos del cliente
                    telefono.CodTelefono_ = ConversionDatosDB.VerificarNulo(lector("cod_telefono"), -1)
                    telefono.Telefono_ = ConversionDatosDB.VerificarNulo(lector("telefono"), "")
                    ' se agrega a la lista de clientes
                    listaTelefonos.AddLast(telefono)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaTelefonos
    End Function

    Public Sub insertarTelefono(ByVal cliente As Cliente, ByVal telefono As String)
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                cmd = New SqlCommand("INSERT INTO FAC.clientes_telefonos (cod_cliente, telefono) VALUES (" & cliente.CodClienteSG & ", '" & telefono & "')")
                cmd.CommandType = CommandType.Text

                conexion = conexionDB.abrirConexion()
                cmd.Connection = conexion
                lector = cmd.ExecuteReader
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub actualizarTelefono(ByVal codigo As Integer, ByVal telefono As String)
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                cmd = New SqlCommand("UPDATE FAC.clientes_telefonos SET telefono = " & telefono & "  WHERE cod_telefono = " & codigo)
                cmd.CommandType = CommandType.Text

                conexion = conexionDB.abrirConexion()
                cmd.Connection = conexion
                lector = cmd.ExecuteReader
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function obtenerTelefonoPorId(ByVal codCliente As Integer) As ClienteTelefono
        ' lista que obtendrá todos los clientes
        ' objeto que obtendrá a los clientes
        Dim telefono As New ClienteTelefono
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los meseros de la base de datos
                cmd = New SqlCommand("SELECT * FROM FAC.clientes_telefonos where cod_cliente = " & codCliente)
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
                    telefono.CodTelefono_ = ConversionDatosDB.VerificarNulo(lector("cod_telefono"), -1)
                    telefono.Telefono_ = ConversionDatosDB.VerificarNulo(lector("telefono"), "")
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return telefono
    End Function

    Public Sub eliminarTelefono(ByVal telefono As ClienteTelefono)
        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                cmd = New SqlCommand("DELETE FROM FAC.clientes_telefonos where cod_telefono = " & telefono.CodTelefono_)
                cmd.CommandType = CommandType.Text
                cmd.Connection = conexion
                cmd.ExecuteReader()

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class

