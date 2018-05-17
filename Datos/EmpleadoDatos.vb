Imports System.Data.SqlClient
Public Class EmpleadoDatos
    ' variables locales y publicas
    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD

    Public Sub New()
        conexionDB = New ConexionBD
    End Sub

    ' metodo que se encarga de obtener todos los meseros en la base de datos
    Public Function obtenerMeseros() As List(Of Empleado)
        ' lista que obtendrá todos los meseros
        Dim listaMeseros As List(Of Empleado) = New List(Of Empleado)
        ' objeto que obtendrá a los meseros
        Dim mesero As Empleado
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los meseros de la base de datos
                cmd = New SqlCommand("SELECT * FROM RRHH.empleados where cod_puesto = 4")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    mesero = New Empleado
                    ' se asignan los datos del mesero
                    ConversionDatosDB.VerificarNulo(lector(0), -1)
                    mesero.Cod_empleadoSG = ConversionDatosDB.VerificarNulo(lector(0), -1)
                    mesero.NombreSG = ConversionDatosDB.VerificarNulo(lector(1), "No disponible")
                    mesero.Apellido1SG = ConversionDatosDB.VerificarNulo(lector(2), "")
                    mesero.Apellido2SG = ConversionDatosDB.VerificarNulo(lector(3), "")
                    mesero.TelefonoSG = ConversionDatosDB.VerificarNulo(lector(4), 0)
                    mesero.EmailSG = ConversionDatosDB.VerificarNulo(lector(5), "")
                    mesero.DireccionSG = ConversionDatosDB.VerificarNulo(lector(6), "")
                    ' se agrega a la lista de meseros
                    listaMeseros.Add(mesero)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaMeseros
    End Function
    Public Function obtenerEmpelados() As List(Of Empleado)
        ' lista que obtendrá todos los meseros
        Dim listaMeseros As List(Of Empleado) = New List(Of Empleado)
        ' objeto que obtendrá a los meseros
        Dim mesero As Empleado
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los meseros de la base de datos
                cmd = New SqlCommand("SELECT * FROM RRHH.empleados")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    mesero = New Empleado
                    ' se asignan los datos del mesero
                    ConversionDatosDB.VerificarNulo(lector(0), -1)
                    mesero.Cod_empleadoSG = ConversionDatosDB.VerificarNulo(lector(0), -1)
                    mesero.NombreSG = ConversionDatosDB.VerificarNulo(lector(1), "No disponible")
                    mesero.Apellido1SG = ConversionDatosDB.VerificarNulo(lector(2), "")
                    mesero.Apellido2SG = ConversionDatosDB.VerificarNulo(lector(3), "")
                    mesero.TelefonoSG = ConversionDatosDB.VerificarNulo(lector(4), 0)
                    mesero.EmailSG = ConversionDatosDB.VerificarNulo(lector(5), "")
                    mesero.DireccionSG = ConversionDatosDB.VerificarNulo(lector(6), "")
                    ' se agrega a la lista de meseros
                    listaMeseros.Add(mesero)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaMeseros
    End Function

    Public Function obtenerEmpleadoPorCod(ByVal cod As Integer) As Empleado
        ' lista que obtendrá todos los meseros
        ' objeto que obtendrá a los meseros
        Dim empleado As New Empleado
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los meseros de la base de datos
                cmd = New SqlCommand("SELECT * FROM RRHH.empleados where cod_empleado = " & cod)
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    empleado = New Empleado
                    ' se asignan los datos del mesero
                    ConversionDatosDB.VerificarNulo(lector(0), -1)
                    empleado.Cod_empleadoSG = ConversionDatosDB.VerificarNulo(lector(0), -1)
                    empleado.NombreSG = ConversionDatosDB.VerificarNulo(lector(1), "No disponible")
                    empleado.Apellido1SG = ConversionDatosDB.VerificarNulo(lector(2), "")
                    empleado.Apellido2SG = ConversionDatosDB.VerificarNulo(lector(3), "")
                    empleado.TelefonoSG = ConversionDatosDB.VerificarNulo(lector(4), 0)
                    empleado.EmailSG = ConversionDatosDB.VerificarNulo(lector(5), "")
                    empleado.DireccionSG = ConversionDatosDB.VerificarNulo(lector(6), "")
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return empleado
    End Function

End Class
