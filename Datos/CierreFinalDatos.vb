Imports System.Data.SqlClient
Public Class CierreFinalDatos
    ' variables locales y publicas
    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD

    Public Sub New()
        conexionDB = New ConexionBD
        cmd = New SqlCommand
    End Sub



    ' cntAffectedRecords = CType(OleDbCommand1.Parameters("retvalue").Value, Integer)
    'MessageBox.Show("Affected records = " & cntAffectedRecords.ToString)
End Class
