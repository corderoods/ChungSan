Imports SunChangSystem
Imports System.Data.SqlClient

Public Class ClienteDireccionDatos

    Public conexion As SqlConnection
    Public cmd As New SqlCommand
    Public conexionDB As New ConexionBD

    Public Sub New()

    End Sub

    Public Function obtenerDireccionesPorCliente(ByVal cliente As Cliente) As LinkedList(Of ClienteDireccion)
        ' lista que obtendrá todos los clientes
        Dim direcciones As LinkedList(Of ClienteDireccion) = New LinkedList(Of ClienteDireccion)
        ' objeto que obtendrá a los clientes
        Dim direccion As ClienteDireccion
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "FAC.sp_obtener_direcciones_por_cliente"
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                cmd.Parameters.Clear()
                ' se asignan los parametros a enviar en el procedimiento almacenado
                With cmd.Parameters
                    .AddWithValue("@codCliente", cliente.CodClienteSG)
                End With
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    direccion = New ClienteDireccion
                    ' se asignan los datos del cliente
                    direccion.CodDireccion_ = ConversionDatosDB.VerificarNulo(lector("cod_direccion"), "Desconocida")
                    direccion.Direccion_ = ConversionDatosDB.VerificarNulo(lector("direccion"), "Desconocida")

                    direcciones.AddLast(direccion)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return direcciones
    End Function

    Public Sub insertarDireccion(ByVal cliente As Cliente, ByVal direccion As String)
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                cmd = New SqlCommand("INSERT INTO FAC.clientes_direcciones (cod_cliente, direccion) VALUES (" & cliente.CodClienteSG & ", '" & direccion & "')")
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

    Public Sub actualizarDireccion(ByVal codigo As Integer, ByVal direccion As String)
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                cmd = New SqlCommand("UPDATE FAC.clientes_direcciones SET direccion = '" & direccion & "'  WHERE cod_direccion = " & codigo)
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

    Public Function obtenerDireccionPorId(ByVal codCliente As Integer) As ClienteDireccion
        ' lista que obtendrá todos los clientes
        ' objeto que obtendrá a los clientes
        Dim direccion As New ClienteDireccion
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los meseros de la base de datos
                cmd = New SqlCommand("SELECT * FROM FAC.clientes_direcciones where cod_cliente = " & codCliente)
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
                    direccion.CodDireccion_ = ConversionDatosDB.VerificarNulo(lector("cod_direccion"), -1)
                    direccion.Direccion_ = ConversionDatosDB.VerificarNulo(lector("direccion"), "")
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return direccion
    End Function

    Public Sub eliminarDireccion(ByVal direccion As ClienteDireccion)
        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                cmd = New SqlCommand("DELETE FROM FAC.clientes_direcciones where cod_direccion = " & direccion.CodDireccion_)
                cmd.CommandType = CommandType.Text
                cmd.Connection = conexion
                cmd.ExecuteReader()

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class
