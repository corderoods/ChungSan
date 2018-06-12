Imports System.Data.SqlClient
Public Class Datafono
    Private cod_Datafono As Int32
    Private nombre_Datafono As String
    ' variables locales y publicas
    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD

    Public Property cod_DatafonoSG As Int32
        Get
            Return cod_Datafono
        End Get
        Set(value As Int32)
            cod_Datafono = value
        End Set
    End Property

    Public Property nombre_DatafonoSG As String
        Get
            Return nombre_Datafono
        End Get
        Set(value As String)
            nombre_Datafono = value
        End Set
    End Property


    Public Sub New()
        conexionDB = New ConexionBD

    End Sub

    Public Function cargaDatafonos() As List(Of Datafono)
        Dim listaDafonos As List(Of Datafono) = New List(Of Datafono)
        Dim data As Datafono
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                conexion = conexionDB.abrirConexion()

                cmd = New SqlCommand("SELECT * FROM FAC.datafonos")
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                While lector.Read
                    data = New Datafono
                    data.cod_DatafonoSG = ConversionDatosDB.VerificarNulo(lector("cod_Datafono"), -1)
                    data.nombre_DatafonoSG = ConversionDatosDB.VerificarNulo(lector("nombre_Datafono"), "Desconocido")
                    listaDafonos.Add(data)
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return listaDafonos
    End Function



End Class
