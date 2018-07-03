Public Class CrearReportes
    'declaracion de instancia
    Public movimiento_caja As New MovimientoCajaDatos

    Public Sub reporteVentasBrutasEfectivo()
        'cargarDesgloceFondosIntroduccionesSalidas(0)
        movimiento_caja.obtenerReporteVentas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.EmpleadoSG.Cod_empleadoSG, InicioSesion.session.Hora_primer_ingresoSG, 0)

        Try
            Dim reporte_ventas_efectivo As New Reporte_de_Ventas
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_ventas_efectivo
            reporte.VistaReportes.RefreshReport()
            reporte.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' se elimina el archivo xml generado
        Try
            Dim url As String = "C:\XML\venta.xml"
            My.Computer.FileSystem.DeleteFile(url)
        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub

    Public Sub reporteVentasTarjeta()
        'cargarDesgloceFondosIntroduccionesSalidas(0)
        movimiento_caja.obtenerReporteVentas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.EmpleadoSG.Cod_empleadoSG, InicioSesion.session.Hora_primer_ingresoSG, 1)

        Try
            Dim reporte_ventas_efectivo As New Reporte_de_Ventas
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_ventas_efectivo
            reporte.VistaReportes.RefreshReport()
            reporte.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' se elimina el archivo xml generado
        Try
            Dim url As String = "C:\XML\venta.xml"
            My.Computer.FileSystem.DeleteFile(url)
        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub

    Public Sub reporteVentasBrutasTotales()
        Dim salonStr As String = "S"
        Dim llevarStr As String = "L"
        Dim expressStr As String = "E"
        Dim uberStr As String = "U"
        Dim tarjetaStr As String = "T"
        Dim efectivoStr As String = "E"
        movimiento_caja.reporteVentasRangoFechas(InicioSesion.session.Hora_primer_ingresoSG, DateTime.Now.ToString("yyyy-MM-dd"), InicioSesion.session.EmpleadoSG.Cod_usuarioSG, 1, salonStr, llevarStr, expressStr, uberStr, efectivoStr, tarjetaStr)
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

    End Sub

    Public Sub reporteFondoInicial()
        movimiento_caja.obtenerReporteFondos(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 1)

        Try
            Dim reporte_fondo_inicial As New Reporte_de_Fondos
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_fondo_inicial
            reporte.VistaReportes.RefreshReport()
            reporte.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' se elimina el archivo xml generado
        Try
            Dim url As String = "C:\XML\fondos.xml"
            My.Computer.FileSystem.DeleteFile(url)
        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub

    Public Sub reporteFondoFinal()
        movimiento_caja.obtenerReporteFondos(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)

        Try
            Dim reporte_fondo_inicial As New Reporte_de_Fondos
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_fondo_inicial
            reporte.VistaReportes.RefreshReport()
            reporte.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' se elimina el archivo xml generado
        Try
            Dim url As String = "C:\XML\fondos.xml"
            My.Computer.FileSystem.DeleteFile(url)
        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub

    Public Sub reporteIntroducciones()
        movimiento_caja.obtenerReporteIntroduccionesSalidas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)
        Try
            Dim reporte_intro_sale As New Reporte_Movimiento_Efectivos
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_intro_sale
            reporte.VistaReportes.RefreshReport()
            reporte.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' se elimina el archivo xml generado
        Try
            Dim url As String = "C:\XML\intro_sale.xml"
            My.Computer.FileSystem.DeleteFile(url)
        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub

    Public Sub reporteBonos()
        movimiento_caja.obtenerReporteAbonos(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
        Try
            Dim reporte_bonos As New Reporte_Abonos
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_bonos
            reporte.VistaReportes.RefreshReport()
            reporte.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' se elimina el archivo xml generado
        Try
            Dim url As String = "C:\XML\reporte_abonos.xml"
            My.Computer.FileSystem.DeleteFile(url)
        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub



    Public Sub reporteSalidas()
        movimiento_caja.obtenerReporteIntroduccionesSalidas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 1)
        Try
            Dim reporte_intro_sale As New Reporte_Movimiento_Efectivos
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_intro_sale
            reporte.VistaReportes.RefreshReport()
            reporte.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' se elimina el archivo xml generado
        Try
            Dim url As String = "C:\XML\intro_sale.xml"
            My.Computer.FileSystem.DeleteFile(url)

        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub

    Public Sub reporteExpressEfectivo()
        movimiento_caja.obtenerReporteExpres(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 1)

        Try
            Dim reporte_ventas_efectivo As New Reporte_Ventas_Express
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_ventas_efectivo
            reporte.VistaReportes.RefreshReport()
            reporte.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' se elimina el archivo xml generado
        Try
            Dim url As String = "C:\XML\ventasExpress.xml"
            My.Computer.FileSystem.DeleteFile(url)
        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub

    Public Sub reporteExpress()
        movimiento_caja.obtenerReporteExpres(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)

        Try
            Dim reporte_ventas_efectivo As New Reporte_Ventas_Express
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_ventas_efectivo
            reporte.VistaReportes.RefreshReport()
            reporte.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' se elimina el archivo xml generado
        Try
            Dim url As String = "C:\XML\ventasExpress.xml"
            My.Computer.FileSystem.DeleteFile(url)
        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub

    Public Sub reporteImpServ()
        movimiento_caja.obtenerReporteImpServicio(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)

        Try
            Dim reporte_impuesto_servicios As New Reporte_Imp_Servicios
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_impuesto_servicios
            reporte.VistaReportes.RefreshReport()
            reporte.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' se elimina el archivo xml generado
        Try
            Dim url As String = "C:\XML\servicio.xml"
            My.Computer.FileSystem.DeleteFile(url)

        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub

    Public Sub reporteImpServEfectivo()
        movimiento_caja.obtenerReporteImpServicio(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 1)

        Try
            Dim reporte_impuesto_servicios As New Reporte_Imp_Servicios
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_impuesto_servicios
            reporte.VistaReportes.RefreshReport()
            reporte.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' se elimina el archivo xml generado
        Try
            Dim url As String = "C:\XML\servicio.xml"
            My.Computer.FileSystem.DeleteFile(url)
        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub

    Public Sub reporteImpVtasEfectivo()
        movimiento_caja.reporteImpuestoVentasCajero(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 0)

        Try
            Dim reporte_impuesto_ventas As New Reporte_Imp_Ventas
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_impuesto_ventas
            reporte.VistaReportes.RefreshReport()
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
    End Sub

    Public Sub reporteImpVtas()
        'cargarDesgloceFondosIntroduccionesSalidas(0)
        movimiento_caja.reporteImpuestoVentasCajero(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 1)

        Try
            Dim reporte_impuesto_ventas As New Reporte_Imp_Ventas
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_impuesto_ventas
            reporte.VistaReportes.RefreshReport()
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
    End Sub

    Public Sub reporteUberEats()
        movimiento_caja.obtenerReporteUberEats(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)

        Try
            Dim reporte_de_Uber As New Reporte_de_UBER_EATS
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_de_Uber
            reporte.VistaReportes.RefreshReport()
            reporte.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' se elimina el archivo xml generado
        Try
            Dim url As String = "C:\XML\uberEats.xml"
            My.Computer.FileSystem.DeleteFile(url)
        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub





End Class
