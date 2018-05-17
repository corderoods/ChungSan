Imports System.Data.SqlClient
Public Class FechaDatos
    Public Shared Function obtenerFechaActual()
        Dim conexion As SqlConnection
        Dim cmd As New SqlCommand
        Dim conexionDB As New ConexionBD

        conexion = conexionDB.abrirConexion()

        ' lista que obtendrá todos los pagos de las facturas
        Dim lista_pagos As List(Of FacturaPago) = New List(Of FacturaPago)
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Dim fecha As DateTime

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' consulta a la base de datos por todos los proveedores de la base de datos
                cmd = New SqlCommand("SELECT getdate()")
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    fecha = DateTime.Parse(lector(0))

                    Return fecha
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        Return fecha
    End Function
End Class
