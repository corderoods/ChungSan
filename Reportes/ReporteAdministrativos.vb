Imports CrystalDecisions.Shared

Public Class ReporteAdministrativos

    Dim movimiento_cajas As MovimientoCajaDatos
    ' variable que tendra los datos
    Dim datos As New DataTable
    ' variable que tendra el valor final del todas las ventas consultadas
    Dim monto_final As Double = 0
    ' variables que indicaran el tipo de reporte que se quiere
    Public ventas_dia As Boolean = False
    Public impvtas As Boolean = False

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If (ventas_dia) Then
            validarTipoReporte()
        ElseIf impvtas Then
            cargarReporteImpVtas()
        End If
    End Sub

    ' metodo que obtiene y muestra los datos del reporte para las ventas por rango de dias
    Private Sub validarTipoReporte()
        ' fecha de inicio y fin
        Dim fecha_inicio As String = DateTime.Parse(FechaInicio.Text).ToString("yyyy-MM-dd")
        Dim fecha_final As String = DateTime.Parse(FechaFin.Text).ToString("yyyy-MM-dd")
        ' usuario a consultar
        Dim usuario As String = Nothing
        ' tipo de pago
        Dim tarjeta As Boolean = False
        Dim efectivo As Boolean = False
        ' lugar de la orden
        Dim salon As Boolean = False
        Dim llevar As Boolean = False
        Dim express As Boolean = False

        ' valida si se quiere obtere por usuario y obtiene el cod
        If cbxUsuario.Checked Then
            usuario = txtCodUsuario.Text
        End If

        ' valida los tipos de pago a filtrar
        If cbxEfectivo.Checked Then
            efectivo = True
        End If
        If cbxTarjeta.Checked Then
            tarjeta = True
        End If

        ' valida la ubicacion de la orden a filtrar
        If cbxSalon.Checked Then
            salon = True
        End If
        If cbxLlevar.Checked Then
            llevar = True
        End If
        If cbxExpress.Checked Then
            express = True
        End If

        ' instancia a la clase que trae los datos desde la base de datos
        movimiento_cajas = New MovimientoCajaDatos

        ' se obtienen los datos
        datos = movimiento_cajas.reporteVentasRangoFechas(fecha_inicio, fecha_final, usuario, 0)

        monto_final = 0
        ' se asigna el lugar para donde se pidio la orden
        For i = 0 To datos.Rows.Count - 1
            ' se obtiene el monto de la venta y se va sumando el de cada una de ellas
            If datos.Rows(i).Item(7) = "Facturada" Then
                monto_final += CDbl(datos.Rows(i).Item(5))
            End If
        Next

        ' se asigna el monto total de las ventas
        lblMontoTotal.Text = monto_final.ToString("C")

        ' se asignan los datos
        dgvVentas.DataSource = datos

    End Sub

    ' metodo que se encarga de obtener4 los datos y mostrar lo concerniente a los ingresos pòr impuesto de ventas
    Private Sub cargarReporteImpVtas()
        ' fecha de inicio y fin
        Dim fecha_inicio As String = DateTime.Parse(FechaInicio.Text).ToString("yyyy-MM-dd")
        Dim fecha_final As String = DateTime.Parse(FechaFin.Text).ToString("yyyy-MM-dd")
        ' instancia
        movimiento_cajas = New MovimientoCajaDatos
        ' llama al metodo para obtener el reporte de impuesto de ventas
        datos = movimiento_cajas.reporteImpuestoVentas(fecha_inicio, fecha_final, 0)

        ' se asignan los datos
        dgvVentas.DataSource = datos
    End Sub

    ' evento de cuando se selecciona el check del usuario
    Private Sub cbxUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles cbxUsuario.CheckedChanged
        ' valida si esta solicitando el codigo de usuario
        ' muestra u oculta la caja de texto
        If cbxUsuario.Checked Then
            txtCodUsuario.Visible = True
        Else
            txtCodUsuario.Visible = False
        End If
    End Sub

    ' evento del boton para mostrar el reporte en crystal reports
    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ' valida que se este preguntando por el reporte de ventas por dia
        If (ventas_dia) Then
            ' form donde se va a mostrar el reporte
            Dim reporte_ventas As New Reporte_Admin_Ventas
            Dim reporte As New Reportes

            Try
                'asigna y muestra el reporte
                reporte.VistaReportes.ReportSource = reporte_ventas
                reporte.VistaReportes.RefreshReport()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            ' se muestra el reporte
            reporte.ShowDialog()
            ' se elimina el archivo xml generado
            Try
                Dim url As String = "C:\XML\ventas.xml"
                My.Computer.FileSystem.DeleteFile(url)
            Catch ex As System.IO.FileNotFoundException

            End Try


            ' valida que se este preguntando por el reporte de impuesto de servicios
        ElseIf impvtas Then

            Try
                Dim reporte_impuesto_ventas As New Reporte_Imp_Ventas
                Dim reporte As New Reportes
                reporte.VistaReportes.ReportSource = reporte_impuesto_ventas
                reporte.VistaReportes.RefreshReport()
                ' se muestra el reporte
                reporte.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            ' se elimina el archivo xml generado
            Try
                Dim url As String = "C:\XML\impuestoventas.xml"
                My.Computer.FileSystem.DeleteFile(url)
            Catch ex As System.IO.FileNotFoundException

            End Try

        End If


    End Sub

    ' evento poarea cuando se cierra la ventana
    Private Sub ReporteAdministrativos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            ' se elimina el archivo
            Dim url As String = "C:\XML\ventas.xml"
            My.Computer.FileSystem.DeleteFile(url)
        Catch ex As System.IO.FileNotFoundException

        End Try

    End Sub

    ' evento para cuando se cara elo formulario
    Private Sub ReporteAdministrativos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' muestra las fechas del dia
        FechaInicio.Text = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        FechaFin.Text = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
    End Sub
End Class