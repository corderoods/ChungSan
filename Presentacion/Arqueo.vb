Public Class Arqueo
    ' variables publicas a utilizar
    Public subtotalIngresos, subtotalEgresos, ventasBrutas, ventasEfectivo, express, ventasTarjeta, impuestoVentas, introducciones, fondoInicial, fondoFinal, pagosFacturas, salidasEfectivo, impuestosServicio, bonos, vales As Double

    'declaracion de instancia
    Public movimiento_caja As New MovimientoCajaDatos

    ' variable que indica si se hizo un cierre de caja para el arqueo
    Public arqueo As Boolean = False

    ' instancia de la clase que se encarga de llamara los metodos que comuinican con la base de datos para crear los xml
    Public crear_reportes As New CrearReportes

    'costructor
    Public Sub New()
        'inicializacion de variables
        subtotalEgresos = fondoFinal = ventasBrutas = ventasEfectivo = express = ventasTarjeta = impuestoVentas = introducciones = fondoInicial = pagosFacturas = salidasEfectivo = impuestosServicio = bonos = vales = 0

        ' llama al metodo que se encarga de cargar todos los montos que corresponden a la seccion de ingresos
        cargarIngresos()
        ' llama al metodo que se encarga de cargar todos los montos que corresponden a la seccion de egresos
        cargarEgresos()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

    End Sub

    '********************************************************************
    '***************************** INGRESOS *****************************
    '********************************************************************

    ' metodo que se encarga de llamar a los metodos para cargar los datos que corresponden a los ingresos'
    Public Sub cargarIngresos()
        ' se obtienen los valores de los montos llamando a los metodos que consultan en la base de datos
        ' monto total de ventas en brutas
        ventasBrutas = Me.cargarVentasBrutas()
        ' monto de los impuestos de ventas
        impuestoVentas = Me.cargarImpuestoVentas()
        ' monto total de introducciones realizadas a la caja
        introducciones = Me.cargarIntroducciones()
        ' monto total de introducciones realizadas a la caja
        bonos = Me.cargarBonos()
        ' monto total de la apertura de la caja
        fondoInicial = Me.cargarFondoInicial()
        ' monto total de los express
        express = Me.cargarMontoExpress()

    End Sub



    'metodo que obtiene el monto de la suma de las ventas que se pagaron en efectivo
    'Public Function cargarVentasEfectivo() As Double
    '    Return movimiento_caja.obtenerIngresosVentas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)
    'End Function

    'metodo que obtiene el monto de la suma de las ventas que se pagaron con tarjeta
    Public Function cargarVentasBrutas() As Double
        Return movimiento_caja.obtenerIngresosVentasBrutas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)
    End Function

    ' metodo que obtiene el monto de la suma de los impuestos de ventas
    Public Function cargarImpuestoVentas()
        Return movimiento_caja.obtenerMontoImpuestoVentas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)
    End Function

    'metodo que obtiene el monto de la suma de introducciones a la caja
    Public Function cargarIntroducciones() As Double
        Return movimiento_caja.obtenerMontoIntroduccionesSalidas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)
    End Function

    'metodo que obtiene el monto de la suma de los bonos a la caja
    Public Function cargarBonos() As Double
        Return movimiento_caja.obtenerMontoAbonos(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
    End Function

    'metodo que obtiene el monto de efectivo asignado al iniciar la caja
    Public Function cargarFondoInicial() As Double
        Return movimiento_caja.obtenerMontoFondoInicial(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
    End Function

    ' metodo que obtiene el monto de los servicios por express
    Public Function cargarMontoExpress()
        Return movimiento_caja.obtenerMontoServiciosExpress(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
    End Function

    '*******************************************************************
    '***************************** EGRESOS *****************************
    '*******************************************************************

    ' metodo que se encarga de llamar a los metodos para cargar los datos que corresponden a los egresos'
    Public Sub cargarEgresos()
        ' se obtienen los valores de los montos llamando a los metodos que consultan en la base de datos
        ' monto total del pago de facturas realizadas por el cajero
        pagosFacturas = Me.cargarPagoFacturas()
        ' monto total de las salidas realizadas por el cajero
        salidasEfectivo = Me.cargarSalidasEfectivo()
        ' monto total de los vales realizadas por el cajero
        vales = Me.cargarVales()
        ' monto total correspondiente a los impuestos de servicios 
        impuestosServicio = Me.cargarImpuestoServicio()

    End Sub

    ' metodo que se encarga de consultar el monto total correspondiente a los pagos de las facturas realizadas por el cajero
    Public Function cargarPagoFacturas() As Double
        Return movimiento_caja.obtenerMontoPagoFacturas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
    End Function

    ' metodo que se encarga de consultar el monto total correspondiente a las salidas realizadas por el cajero
    Public Function cargarSalidasEfectivo() As Double
        Return movimiento_caja.obtenerMontoIntroduccionesSalidas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 1)
    End Function

    ' metodo que se encarga de consultar el monto total correspondiente a los vales realizadas por el cajero
    Public Function cargarVales() As Double
        Return movimiento_caja.obtenerMontoVales(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
    End Function

    ' metodo que se encarga de consultar el monto total correspondiente a los impuestos por servicios
    Public Function cargarImpuestoServicio() As Double
        Return movimiento_caja.obtenerMontoImpuestoServicios(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)
    End Function

    'metodo que obtiene el monto de efectivo almacenado por el cajero
    Public Function cargarFondoFinal() As Double
        Return movimiento_caja.obtenerMontoArqueoCaja(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
    End Function



    '*******************************************************************
    '***************************** EVENTOS *****************************
    '*******************************************************************

    Private Sub lblTotalVentasEfectivo_Click(sender As Object, e As EventArgs) Handles lblExpress.Click
        ' llama al metodo para crear el reporte de las ventas por express
        crear_reportes.reporteExpress()
    End Sub

    Private Sub lblTotalVtasBrutas_Click(sender As Object, e As EventArgs) Handles lblTotalVtasBrutas.Click
        ' llama al metodo para crear el reporte de las ventas brutas totales
        crear_reportes.reporteVentasBrutasTotales()
    End Sub

    Private Sub lblImpVtas_Click(sender As Object, e As EventArgs) Handles lblImpVtas.Click
        ' llama al metodo para crear el reporte de los impuesto de ventas totales
        crear_reportes.reporteImpVtas()
    End Sub

    Private Sub lblTotalVentasTarjeta_Click(sender As Object, e As EventArgs)
        'cargarDesgloceFondosIntroduccionesSalidas(0)
        movimiento_caja.obtenerReporteVentas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.EmpleadoSG.Cod_empleadoSG, InicioSesion.session.Hora_primer_ingresoSG, 1)

        Try
            Dim reporte_ventas_tarjeta As New Reporte_de_Ventas
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = reporte_ventas_tarjeta
            reporte.VistaReportes.RefreshReport()
            reporte.ShowDialog()
            Dim url As String = "C:\XML\venta.xml"
            My.Computer.FileSystem.DeleteFile(url)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub lblTotalImpuestosServicio_Click(sender As Object, e As EventArgs) Handles lblTotalImpuestosServicio.Click
        ' llama al metodo para crear el reporte de los impuestos de servicio
        crear_reportes.reporteImpServ()
    End Sub

    ' accion de la etiqueta del monto de introducciones
    Private Sub lblTotalIntroducciones_Click(sender As Object, e As EventArgs) Handles lblTotalIntroducciones.Click
        ' llama al metodo para crear el reporte de las introducciones de efectivo
        crear_reportes.reporteIntroducciones()
    End Sub

    ' accion de la etiqueta del monto de bonos
    Private Sub lblTotalBonos_Click(sender As Object, e As EventArgs) Handles lblTotalBonos.Click
        ' llama al metodo para crear el reporte de los bonos
        crear_reportes.reporteBonos()
    End Sub


    ' accion de la etiqueta del monto de salidas
    Private Sub lblTotalSalidasEfectivo_Click(sender As Object, e As EventArgs) Handles lblTotalSalidasEfectivo.Click
        ' llama al metodo para crear el reporte de las salidas de efectivo
        crear_reportes.reporteSalidas()
    End Sub

    ' accion de la etiqueta del monto inicial
    Private Sub lblTotalFondoInicial_Click(sender As Object, e As EventArgs) Handles lblTotalFondoInicial.Click
        ' llama al metodo para crear el reporte del fondo inicial
        crear_reportes.reporteFondoInicial()
    End Sub

    ' accion de la etiqueta del monto final
    Private Sub lblMontoSubtotalFondoFinal_Click(sender As Object, e As EventArgs) Handles lblMontoSubtotalFondoFinal.Click
        ' llama al metodo para crear el reporte del fondo final
        crear_reportes.reporteFondoFinal()
    End Sub

    ' accion de la etiqueta del monto de pago de facturas
    Private Sub lblTotalPagoFacturas_Click(sender As Object, e As EventArgs) Handles lblTotalPagoFacturas.Click
        ' valida que hayan pagos de facturas realizados
        If pagosFacturas > 0 Then
            ' instancia de la clase
            Dim historicoFacturas As New HistoricoFacturas
            ' se desabilitan los controles de la fecha y el boton para buscar
            historicoFacturas.txtFechaFinal.Enabled = False
            historicoFacturas.txtFechaInicio.Enabled = False
            historicoFacturas.btnConfirmar.Enabled = False
            ' llama al metodo para mostrar el reporte
            historicoFacturas.ShowDialog()
        End If
    End Sub

    Private Sub Arqueo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Me.arqueo Then
            Dim revertir_arqueo As New MovimientoCajaDatos
            revertir_arqueo.revertirArqueoDeCaja(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
        End If
    End Sub

    ' page load
    Private Sub CierreFinal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' se colocan los valores correspondientes en la pantalla
        lblTotalVtasBrutas.Text = ventasBrutas.ToString("C")
        lblExpress.Text = express.ToString("C")
        lblImpVtas.Text = impuestoVentas.ToString("C")
        lblTotalIntroducciones.Text = introducciones.ToString("C")
        lblTotalFondoInicial.Text = fondoInicial.ToString("C")
        lblTotalBonos.Text = bonos.ToString("C")

        ' se muestran los valores en la pantalla en la seccion del resultado del cierre de la caja
        subtotalIngresos = (ventasBrutas + express + introducciones + fondoInicial + impuestoVentas + bonos).ToString("C")
        lblMontoSubtotalIngresos.Text = subtotalIngresos.ToString("C")
        lblMontoTotalIngresos.Text = subtotalIngresos.ToString("C")

        ' se colocan los valores correspondientes en la pantalla
        lblTotalSalidasEfectivo.Text = salidasEfectivo.ToString("C")
        lblTotalVales.Text = vales.ToString("C")
        lblTotalPagoFacturas.Text = pagosFacturas.ToString("C")
        lblTotalImpuestosServicio.Text = impuestosServicio.ToString("C")

        ' se muestran los valores en la pantalla en la seccion del resultado del cierre de la caja
        subtotalEgresos = (pagosFacturas + salidasEfectivo + impuestosServicio + vales).ToString("C")
        lblMontoSubtotalEgresos.Text = subtotalEgresos.ToString("C")
        lblMontoTotalEgresos.Text = subtotalEgresos.ToString("C")

        ' se muestra el valor del monto que se tiene registrado el sistema como final
        lblTotalFondoFinalSistema.Text = (subtotalIngresos - subtotalEgresos).ToString("C")
    End Sub

    ' metodo que se encarga de mostrar la ventana para agregar los montos del foindo final del cajero
    Private Sub btnAgregarFondoFinal_Click(sender As Object, e As EventArgs) Handles btnAgregarFondoFinal.Click
        ' Instancia a la ventana de movimientos de efectivo
        Dim fondoFinal As New MovimientosEfectivo
        ' coloca la variable de fondoFinal en true para saber que es la accion que se va a realizar
        fondoFinal.arqueo = True
        ' llama al metodo para cargar y mostrar las nominaciones
        fondoFinal.cargarDenominaciones()
        fondoFinal.ShowDialog()

        ' coloca la variable de fondoFinal en false para saber que la accion ya se realizo
        fondoFinal.arqueo = False

        ' se llama al metodo que se encarga de obtener el monto del fondo final de la caja
        Me.fondoFinal = cargarFondoFinal()
        ' se realizan los calculos y se muestran en la pantalla los resultados
        lblMontoSubtotalFondoFinal.Text = Me.fondoFinal.ToString("C")
        lblTotalFondoFinalCaja.Text = Me.fondoFinal.ToString("C")
        ' se hace el calculo de la diferencia que hay entre el monto final en la caja y el monto que calcula el sistema
        lblTotalDiferenciaFondos.Text = (Me.fondoFinal - (subtotalIngresos - subtotalEgresos)).ToString("C")
        ' se desabilita el boton para agregar mas al fondo final
        btnAgregarFondoFinal.Enabled = False
    End Sub


    Private Sub btnImprimirCierreCaja_Click(sender As Object, e As EventArgs) Handles btnImprimirCierreCaja.Click
        Dim cierre_caja As New CierreCaja
        cierre_caja.Show()
    End Sub
End Class