Imports System.Data.SqlClient
Public Class ClienteEmailDatos
    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD


    Dim clienteTelefono As New ClienteTelefonoDatos
    Dim clienteDireccion As New ClienteDireccionDatos
    Dim clienteDa As New ClienteDatos
    Dim clientex As New Cliente

    Public Sub New()
        conexionDB = New ConexionBD

    End Sub

    Public Sub InsertarEmail(ByVal cliente As Cliente, ByVal correo As String)
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)

                cmd = New SqlCommand("INSERT INTO FAC.clientes_email(cod_cliente, correo_electronico) VALUES (" & cliente.CodClienteSG & ", '" & correo & "')")
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

    Public Function obtenerEmailPorId(ByVal cod_cliente As Integer) As ClienteEmail
        ' lista que obtendrá todos los clientes
        ' objeto que obtendrá a los clientes
        Dim email As New ClienteEmail
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los meseros de la base de datos
                cmd = New SqlCommand("SELECT * FROM FAC.clientes_email where cod_cliente = " & cod_cliente)
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
                    email.cod_EmailSG = ConversionDatosDB.VerificarNulo(lector("cod_correo"), -1)
                    email.correo_ElectronicoSG = ConversionDatosDB.VerificarNulo(lector("correo_electronico"), "")
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return email
    End Function


End Class
