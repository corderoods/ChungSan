Imports System.Data.SqlClient

Public Class MenuDatos
    ' variables locales y publicas
    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD

    Public Sub New()
        conexionDB = New ConexionBD
    End Sub

    ' metodo que se encargar de almacenar el fondo inicial asignado al cajero
    Public Function almacenarProductos(ByVal producto As Producto) As Boolean
        ' se obtiene la fecha actual del sistema para enviarla como la hora de ingreso del fondo inicial
        Dim fecha As DateTime = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' valida que se haya almacenado el flujo de caja multiple
        'If almacenarFlujocajaMultiple(denominacionesMonedas) Then
        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "INV.sp_almacena_producto"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        With cmd.Parameters
            .AddWithValue("@nombre", producto.Nombre_)






        End With
        Try

            ' ejecuta la consulta a la base
            cmd.ExecuteNonQuery()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return False
        End Try

        ' limpia los parametros del comando
        cmd.Parameters.Clear()
        'cierra la conexion
        conexionDB.cerrarConexion()

        Return True

    End Function

    ' metodo que se encargar de almacenar el fondo inicial asignado al cajero
    Public Function almacenarCategorias(ByVal denominacionesMonedas As DenominacionMonedas) As Boolean
        ' se obtiene la fecha actual del sistema para enviarla como la hora de ingreso del fondo inicial
        Dim fecha As DateTime = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' valida que se haya almacenado el flujo de caja multiple
        'If almacenarFlujocajaMultiple(denominacionesMonedas) Then
        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_almacena_fondo_inicial_flujocaja_d"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' variable que obtendrá la lista de denominaciones de las monedas
        Dim listaDenominaciones As List(Of Monedas) = denominacionesMonedas.ListaDenominacionesSG

        ' recorre la lista de monedas en colones y las inserta en la base de datos
        For i As Integer = 0 To listaDenominaciones.Count - 1
            ' asigna los parametros a enviar al procedimiento
            With cmd.Parameters
                .AddWithValue("@codigo_usuario_asigna", denominacionesMonedas.Codigo_usuario_asignaSG)
                .AddWithValue("@codigo_usuario_recibe", denominacionesMonedas.Codigo_usuario_recibeSG)
                .AddWithValue("@fecha", fecha)
                .AddWithValue("@tipo_moneda", listaDenominaciones(i).Tipo_monedaSG)
                .AddWithValue("@cod_moneda", listaDenominaciones(i).Codigo_monedaSG)
                .AddWithValue("@cantidad", listaDenominaciones(i).CantidadSG)
                .AddWithValue("@subtotal", listaDenominaciones(i).SubtotalSG)
                'valida si es la primer iteracion (i=0) para indicar en la bandera
                .AddWithValue("@flag", IIf(i = 0, 1, 0))
                .AddWithValue("@tipo_cambio", listaDenominaciones(i).Tipo_cambioSG)
                '.AddWithValue("@cantidad_cierre", 0)
                '.AddWithValue("@subtotal_cierre", 0)
            End With
            'MsgBox(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Try

                ' ejecuta la consulta a la base
                cmd.ExecuteNonQuery()
                ' limpia los parametros del comando
                cmd.Parameters.Clear()

            Catch ex As Exception
                MsgBox(ex.Message)
                ' limpia los parametros del comando
                cmd.Parameters.Clear()
                'cierra la conexion
                conexionDB.cerrarConexion()
                Return False
            End Try
        Next

        conexionDB.cerrarConexion()
        'Else
        'Return False
        'End If

        Return True

    End Function


End Class
