Imports System.Data.SqlClient

Public Class ConexionBD
    ' variables locales y publicas
    Public conexion As SqlConnection
    Public cadenaConexion As String

    Public Sub New()
        'Me.cadenaConexion = "Data Source=WIN-DTO4BTFAAR3;Initial Catalog=Restaurante_V4_Produccion;Integrated Security = True"
        'Me.cadenaConexion = "Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Restaurante_V4_Produccion;Integrated Security = True"
        'Me.cadenaConexion = "Data Source=JC-TOSHIBA\SQLEXPRESS2012;Initial Catalog=Restaurante_V4_C:\Users\ODS\Desktop\2018-05-29 SunChangSystem\SunChangSystem\Datos\ConexionBD.vbProduccion;User ID=sa;Password=racoton"
        'Me.cadenaConexion = "Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Restaurante_V4_Produccion;Integrated Security = True"
        'Me.cadenaConexion = "Data Source=CCASAW\SQLEXPRESS;Initial Catalog=Restaurante_V4_Produccion;Integrated Security = True"
        'Me.cadenaConexion = "Data Source=10.188.225.137;Initial Catalog=Restaurante_V4_Produccion;User ID=marlon;Password=racoton"
        'Me.cadenaConexion = "Data Source=DESKTOP-VQ0OCGJ\SQLEXPRESS;Initial Catalog=Restaurante_V4_Produccion;Integrated Security = True"
        'Me.cadenaConexion = "Data Source=PC1-PC\SQLEXPRESS;Initial Catalog=Restaurante_V4_Produccion;User ID=sa;Password=racoton"
        'Me.cadenaConexion = "Data Source=ODS06\ODSSQLSERVER2016;Initial Catalog=Restaurante_V4_Produccion;Integrated Security = True"

        Me.cadenaConexion = "Data Source=localhost\SQLEXPRESS01;Initial Catalog=Restaurante_V4_Produccion;Integrated Security = True;"

    End Sub

    'Metodo donde se abren las conexiones
    Public Function abrirConexion() As SqlConnection
        Try
            '' comando para establecer la coneccion a la base de datos
            conexion = New SqlConnection(Me.cadenaConexion)
            '' se abre la coneccion con la base de datos
            conexion.Open()
            Return conexion
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    ' metodo que se encarga de cerrar la conexion
    Public Sub cerrarConexion()
        conexion.Close()
    End Sub

    ' metodo que devuelve el strinf¡g de conexion
    Public Function obtenerCadenaConexion() As String
        Return Me.cadenaConexion
    End Function
End Class
