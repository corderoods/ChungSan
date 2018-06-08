Imports System.Data.SqlClient
Public Class UsuariosDatos
    ' variables locales y publicas
    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD
    ' variable que indicará si es el primer ingreso del usuario
    Public Shared inicio As Boolean

    ' CONSTRUCTOR
    Public Sub New()
        conexionDB = New ConexionBD
        inicio = True
    End Sub

    ' metodo que se encarga de obtener todos los proveedores en la base de datos
    Public Function obtenerProveedores() As List(Of Proveedor)
        ' lista que obtendrá todos los proveedores
        Dim listaProveedores As List(Of Proveedor) = New List(Of Proveedor)
        ' objeto que obtendrá a los proveedores
        Dim proveedor As Proveedor
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los proveedores de la base de datos
                cmd = New SqlCommand("SELECT cod_proveedor, nombre FROM PRO.proveedores ORDER BY nombre ASC")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    proveedor = New Proveedor
                    ' se asigna el codigo del proveedor y el nombre
                    proveedor.CodigoProveedor = lector(0)
                    proveedor.NombreProveedor = lector(1)
                    ' se agrega a la lista de proveedores
                    listaProveedores.Add(proveedor)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaProveedores
    End Function

    ' metodo que se encarga de obtener todos los administradores en la base de datos
    Public Function obtenerAdministradores() As List(Of Administrador)
        ' lista que obtendrá todos los administradores
        Dim listaAdministradores As List(Of Administrador) = New List(Of Administrador)
        ' objeto que obtendrá a los administradores
        Dim administradores As Administrador
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los administradores de la base de datos
                cmd = New SqlCommand("SELECT * FROM RRHH.empleados AS e INNER JOIN RRHH.puestos AS p ON p.cod_puesto = e.cod_puesto where p.nombre = 'GERENTE' OR p.nombre = 'SUB-GERENTE'")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    administradores = New Administrador
                    ' se asigna el codigo del administrador y el nombre
                    administradores.Codigo_empleado = lector(13)
                    administradores.NombreEmpleado = lector(1)
                    ' se agrega a la lista de administradores
                    listaAdministradores.Add(administradores)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaAdministradores
    End Function

    ' metodo que se encarga de obtener todos los proveedores en la base de datos
    Public Function validarSesion(ByVal cod_usuario As String, ByVal contrasenna As String) As Session
        ' objeto que obtendrá a los empleados
        Dim empleado As New Empleado
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos po el empleado que cumpla con las credenciales proporcionadas al iniciar la sesion
                cmd = New SqlCommand("SELECT em.* FROM RRHH.empleados AS em, RRHH.usuarios AS us WHERE em.cod_usuario = us.cod_usuario
                                   And us.cod_usuario = '" + cod_usuario + "' AND us.contrasena = '" + contrasenna + "'")



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
                    ' se asignan los atributos al objeto Empleado
                    empleado.Cod_empleadoSG = ConversionDatosDB.VerificarNulo(lector(0), -1)
                    empleado.NombreSG = ConversionDatosDB.VerificarNulo(lector(1), "No disponible")
                    empleado.Apellido1SG = ConversionDatosDB.VerificarNulo(lector(2), "No disponible")
                    empleado.Apellido2SG = ConversionDatosDB.VerificarNulo(lector(3), "No disponible")
                    empleado.TelefonoSG = ConversionDatosDB.VerificarNulo(lector(4), -1)
                    empleado.EmailSG = ConversionDatosDB.VerificarNulo(lector(5), "No disponible")
                    empleado.DireccionSG = ConversionDatosDB.VerificarNulo(lector(6), "No disponible")
                    empleado.Fecha_nacimientoSG = ConversionDatosDB.VerificarNulo(lector(7), Date.Now)
                    empleado.Fecha_ingresoSG = ConversionDatosDB.VerificarNulo(lector(8), Date.Now)
                    empleado.Cod_puestoSG = ConversionDatosDB.VerificarNulo(lector(9), -1)
                    empleado.Estado_civilSG = ConversionDatosDB.VerificarNulo(lector(10), -1)
                    empleado.SexoSG = ConversionDatosDB.VerificarNulo(lector(11), -1)
                    empleado.Cod_barraSG = ConversionDatosDB.VerificarNulo(lector(12), -1)
                    empleado.Cod_usuarioSG = ConversionDatosDB.VerificarNulo(lector(13), "No disponible")
                    empleado.CelularSG = ConversionDatosDB.VerificarNulo(lector(14), -1)
                    empleado.Tel_fijoSG = ConversionDatosDB.VerificarNulo(lector(15), -1)
                    empleado.ContrasennaSG = ConversionDatosDB.VerificarNulo(lector(16), "No disponible")

                    ' llama al método que valida si ya el usuario tiene una apertura de caja sin cerrar 
                    ' (inició el fondo inicial pero no realizó el cierre de caja). Esto pasa por si cerró sesión
                    ' y luego vuelve otra vez. Se retorna la sesion ya creada
                    Return validarAperturaSesion(empleado)
                End While
            End Using
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return Nothing
        End Try
        Return Nothing
    End Function

    ' metodo que se encarga de validar si el usuario tiene una apertura de caja sin finalizar
    ' si es asi, devuelve la fecha en que se abrio, sino entonces retorna la fecha y hora actual
    Public Function validarAperturaSesion(ByVal empleado As Empleado) As Session
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader
        ' se obtiene la fecha y la hora actual del sistema
        Dim fecha_actual As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        ' se crea el nuevo objeto de session
        Dim session_a_iniciar As New Session
        ' se agrega el empleado a la sesion
        session_a_iniciar.EmpleadoSG = empleado
        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos po el empleado que cumpla con las credenciales proporcionadas al iniciar la sesion
                cmd = New SqlCommand("SELECT TOP 1 concat(datepart(year,fecha), '-', right(CONCAT('0',datepart(month, fecha)),2), '-', right(CONCAT('0',datepart(day, fecha)),2), ' ', datepart(hour, fecha), ':', datepart(minute, fecha), ':', datepart(second, fecha)) FROM fac.flujocaja_m WHERE (estado_caja = 'A' OR estado_caja = 'R') AND cod_usuario_recibe = '" + empleado.Cod_usuarioSG +
                                     "' AND concat(datepart(year,fecha), '-', right(CONCAT('0',datepart(month, fecha)),2), '-', right(CONCAT('0',datepart(day, fecha)),2)) = concat(datepart(year,'" + fecha_actual + "'), '-', right(CONCAT('0',datepart(month, '" + fecha_actual + "')),2), '-', right(CONCAT('0',datepart(day, '" + fecha_actual + "')),2)) order by fecha desc")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' valida que haya obtenido datos
                If lector.HasRows Then
                    ' se recorre hasta obtener todos los registros necesarios
                    While lector.Read
                        ' se asignan los atributos al objeto session
                        session_a_iniciar.Hora_primer_ingresoSG = lector(0).ToString
                        session_a_iniciar.Hora_inicioSG = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                        ' declara la variable de primer ingreso en false
                        inicio = False
                        ' retorna la sesion
                        Return session_a_iniciar
                    End While
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            ' se asignan los atributos al objeto session
            session_a_iniciar.Hora_inicioSG = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            session_a_iniciar.Hora_primer_ingresoSG = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            ' retorna la sesion
            Return session_a_iniciar
        End Try
        ' se asignan los atributos al objeto session
        session_a_iniciar.Hora_inicioSG = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        session_a_iniciar.Hora_primer_ingresoSG = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        ' retorna la sesion
        Return session_a_iniciar
    End Function

    ' metodo que se encarga de validar que el codigo del usuario y la contraseña correspondan a un administrador
    Public Function validarAdministador(ByVal cod_usuario As String, ByVal contrasenna As String) As Boolean
        ' objeto que obtendrá a los empleados
        Dim empleado As New Empleado

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos po el empleado que cumpla con las credenciales proporcionadas al iniciar la sesion
                cmd = New SqlCommand("SELECT us.cod_usuario FROM RRHH.usuarios AS us WHERE us.cod_usuario = '" + cod_usuario + "' AND us.contrasena = '" + contrasenna + "'")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' donde se almacenan los datos de la consulta
                Dim lector As SqlDataReader
                ' se ejecuta la consulta y se valida que todo este bien
                lector = cmd.ExecuteReader()

                If lector.HasRows Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return False
    End Function



End Class

