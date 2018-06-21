Imports CrystalDecisions.Shared

Imports System.Data.SqlClient
Imports ReporteCierredeCaja

Public Class CierreCaja
    ' variables publicas a utilizar
    Public subtotalIngresos, subtotalEgresos, ventasTarjeta, introducciones, pagosFacturas, impuestosServicio, impuestoVentas, express, uber As Double
    Public ventasEfectivo, fondoInicial, impuestoVentasEfectivo, expressEfectivo, salidasEfectivo, impuestosServicioEfectivo, fondoFinal, ventasSoloEfec As Double
    Public ventasBrutas As Double
    Public monto_total_efectivo As Double = 0
    Public diferencia As Double = 0
    Public monto_total As Double = 0
    Public ventas_sistema As Double = 0
    Public diferenciaVentas As Double = 0
    Public dataExpress, dataSalon, salonBD, expressBD As Double
    Dim ventasefectivassistema As Double
    'declaracion de instancia
    Public movimiento_caja As New MovimientoCajaDatos
    ' instancia de la clase que se encarga de llamara los metodos que comuinican con la base de datos para crear los xml
    Public crear_reportes As New CrearReportes

    Dim mensaje As New Mensaje
    ' indica si se cambia el cierre de caja
    Public modificar_cierre As Boolean = False


    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD


    ' constructor
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' llama al metodo que se encarga de cargar toda la informaacion para poder mostrarlas
        cargarInformacion()

        conexionDB = New ConexionBD
        cmd = New SqlCommand
    End Sub

    'metodo que se encarga de cargar toda la informaacion para poder mostrarla
    Public Sub cargarInformacion()

        '  MovimientosEfectivo.Close()
        'inicializacion de variables
        subtotalEgresos = fondoFinal = ventasEfectivo = ventasTarjeta = introducciones = fondoInicial = pagosFacturas = uber = salidasEfectivo = impuestosServicio = impuestosServicioEfectivo = impuestoVentas = impuestoVentasEfectivo = expressEfectivo = express = ventasBrutas = ventasSoloEfec = dataSalon = dataExpress = 0

        ' llama al metodo que se encarga de cargar todos los montos que corresponden a la seccion de ingresos
        cargarEfectivos()
        ' llama al metodo que se encarga de cargar todos los montos que corresponden a la seccion de egresos
        cargarEgresos()

        ventasBrutas = Me.cargarVentasBrutas

        ' **************************************
        ' ********COMPROBACION EFECTIVO*********
        ' **************************************


        lblFondoInicialCompEfec.Text = fondoInicial.ToString("C")
        lblIntroduccionesCompEfec.Text = introducciones.ToString("C")
        lblExpressCompEfec.Text = express.ToString("C")

        ventasSoloEfec = ventasEfectivo - ventasTarjeta
        'lblVentasEfectivoCompEfec.Text = ventasSoloEfec.ToString("C")
        ventasefectivassistema = ventas_sistema - ventasTarjeta + impuestosServicio
        lblVentasEfectivoCompEfec.Text = ventasefectivassistema.ToString("C")
        lblImpServicioCompEfec.Text = impuestosServicio.ToString("C")
        lblCuentasCanceladasCompEfec.Text = (pagosFacturas + salidasEfectivo).ToString("C")
        lblFondoFinalCompEfec.Text = fondoFinal.ToString("C")
        lblImpVtasCompEfec.Text = impuestoVentasEfectivo.ToString("C")

        lblDataExpress.Text = dataExpress.ToString("C")
        lblDataSalon.Text = dataSalon.ToString("C")

        'lblValesTotalesEfectivo.Text = vales.ToString("C")
        'lblBonosTotalesEfectivo.Text = bonos.ToString("C")


        'monto_total_efectivo = ((fondoInicial + introducciones + expressEfectivo + ventasEfectivo) - (impuestosServicioEfectivo + pagosFacturas + salidasEfectivo + impuestoVentasEfectivo))

        'JC
        monto_total_efectivo = fondoInicial + introducciones + expressEfectivo + ventasefectivassistema - impuestosServicio - pagosFacturas - salidasEfectivo + impuestoVentas - uber
        'JC

        diferencia = fondoFinal - monto_total_efectivo
        lblDiferenciaCompEfec.Text = (diferencia).ToString("C")

        expressBD = movimiento_caja.obtenerMontoDatafono(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, 1)
        salonBD = movimiento_caja.obtenerMontoDatafono(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, 0)
        If dataExpress <> expressBD Then
            mensaje.lblMensaje.Text = "Hay una diferencia entre el datafono del express."
            mensaje.tipoMensaje("Error")
            mensaje.ShowDialog()
        ElseIf dataSalon <> salonBD Then
            mensaje.lblMensaje.Text = "Hay una diferencia entre el datafono del salon."
            mensaje.tipoMensaje("Error")
            mensaje.ShowDialog()
        End If


        If diferencia > 5000 Or diferencia < -5000 Then
            mensaje.lblMensaje.Text = "Hay una gran diferencia. Verifique los montos."
            mensaje.tipoMensaje("Error")
            mensaje.ShowDialog()
        End If
        lblMontoTotalCompEfec.Text = monto_total_efectivo.ToString("C")

        ' **************************************
        ' ********COMPROBACION VENTAS***********
        ' **************************************

        lblFondoInicialCompVtas.Text = fondoInicial.ToString("C")
        lblVentasCompVtas.Text = ventasTarjeta.ToString("C")
        lblImpVtasCompVtas.Text = impuestoVentas.ToString("C")
        lblExpresCompVtas.Text = express.ToString("C")
        lblIntroduccionesCompVtas.Text = introducciones.ToString("C")
        lblCuentasCanceladasCompVtas.Text = (pagosFacturas + salidasEfectivo).ToString("C")
        lblUber.Text = uber.ToString("C")

        lblFondoFinalCompVtas.Text = fondoFinal.ToString("C")



        ' fondo final - fondo inicial + cuentas - express en efectivo - impuesto de servicio + ventas conm tarjetas sin express - introducciones

        '**********************************************************************
        ' esta da como en el excel
        'lblTotalVentasCompVtas.Text = ((fondoFinal + pagosFacturas + salidasEfectivo + ventasTarjeta) - (fondoInicial + expressEfectivo + introducciones)).ToString("C")

        ' monto_total = (fondoFinal - fondoInicial + pagosFacturas + salidasEfectivo - expressEfectivo - impuestosServicio + ventasTarjeta - introducciones)

        'monto_total = (fondoFinal - impuestoVentas + ventasTarjeta + pagosFacturas - express - fondoInicial - introducciones)

        'JC
        monto_total = fondoFinal - impuestoVentas + ventasTarjeta + pagosFacturas - express - fondoInicial - introducciones + uber
        'JC

        ventas_sistema = ventasBrutas + (impuestoVentas - impuestoVentasEfectivo)
        diferenciaVentas = monto_total - ventas_sistema

        lblTotalVentasCompVtas.Text = monto_total.ToString("C")
        lblTotalVtasSistCompVtas.Text = ventas_sistema.ToString("C")
        lblDiferenciaCompVtas.Text = (diferenciaVentas).ToString("C")


        '**********************************************************************

        'lblTotalVentasCompVtas.Text = ((fondoInicial + introducciones + ventasTarjeta + pagosFacturas + salidasEfectivo) - (fondoFinal + impuestosServicio + impuestoVentas + expressEfectivo)).ToString("C")
        'lblTotalVentasCompVtas.Text = ((fondoFinal + ventasTarjeta + (pagosFacturas + salidasEfectivo) + impuestoVentas + express + impuestosServicio) - (fondoInicial + introducciones)).ToString("C")
        'lblTotalVentasCompVtas.Text = ((fondoInicial + introducciones + ventasTarjeta + pagosFacturas + salidasEfectivo + express) - fondoFinal - impuestosServicio).ToString("C")
        'lblTotalVentasCompVtas.Text = ((fondoInicial + introducciones + ventasTarjeta + pagosFacturas + salidasEfectivo + express) - (fondoFinal + impuestosServicio + impuestoVentas)).ToString("C")

    End Sub

    'metodo que obtiene el monto de la suma de las ventas brutas
    Public Function cargarVentasBrutas() As Double
        Return movimiento_caja.obtenerIngresosVentasBrutas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)
    End Function

    '********************************************************************
    '***************************** EFECTIVOS ****************************
    '********************************************************************

    ' metodo que se encarga de llamar a los metodos para cargar los datos que corresponden a los ingresos'
    Public Sub cargarEfectivos()
        ' se obtienen los valores de los montos llamando a los metodos que consultan en la base de datos

        ' monto total de ventas en efectivo
        ventasEfectivo = Me.cargarVentasEfectivo
        ' monto total de ventas
        ventasTarjeta = Me.cargarVentasTarjetas
        ' monto total de introducciones realizadas a la caja
        introducciones = Me.cargarIntroducciones
        ' monto total de la apertura de la caja
        fondoInicial = Me.cargarFondoInicial
        ' monto total del servicio de express
        expressEfectivo = Me.cargarServicioExpress
        ' monto total correspondiente a los impuestos de servicios pagados 
        impuestosServicioEfectivo = Me.cargarImpuestoServicio
        ' monto total correspondiente al impuesto de ventas 
        impuestoVentasEfectivo = Me.cargarImpuestoVentas(0)
        'Ventas por datafono
        dataExpress = Me.cargarVentasDatafonoExpress()
        dataSalon = Me.cargarVentasDatafonoSalon()

    End Sub

    ' metodo que se encarga de cargar el monto de las ventas brutas ya sea por efectivo o por tarjeta
    Public Function cargarVentasTarjetas()
        Return movimiento_caja.obtenerIngresosVentas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 1)
    End Function

    ' metodo que se encarga de cargar el monto de las ventas brutas ya sea por efectivo o por tarjeta
    Public Function cargarVentasDatafonoExpress()
        Return movimiento_caja.obtenerVentasPorDatafono(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 1)
    End Function

    ' metodo que se encarga de cargar el monto de las ventas brutas ya sea por efectivo o por tarjeta
    Public Function cargarVentasDatafonoSalon()
        Return movimiento_caja.obtenerVentasPorDatafono(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)
    End Function

    'metodo que obtiene el monto de la suma de las ventas que se pagaron en efectivo
    Public Function cargarVentasEfectivo() As Double
        Return movimiento_caja.obtenerIngresosVentasSoloEfectivo(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 1)
    End Function

    'metodo que obtiene el monto de la suma de las ventas que se pagaron
    Public Function cargarVentas() As Double
        Return movimiento_caja.obtenerIngresosVentas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)
    End Function

    'metodo que obtiene el monto de la suma de introducciones a la caja
    Public Function cargarIntroducciones() As Double
        Return movimiento_caja.obtenerMontoIntroduccionesSalidas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)
    End Function

    'metodo que obtiene el monto de efectivo asignado al iniciar la caja
    Public Function cargarFondoInicial() As Double
        Return movimiento_caja.obtenerMontoFondoInicial(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
    End Function

    'metodo que obtiene el monto del servicio de express
    Public Function cargarServicioExpress() As Double
        Return movimiento_caja.obtenerMontoServiciosExpress(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
    End Function

    'metodo que obtiene el monto del servicio de express en efectivo
    Public Function cargarServicioExpressEfectivo() As Double
        Return movimiento_caja.obtenerMontoServiciosExpressEfectivo(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
    End Function

    '*******************************************************************
    '***************************** EGRESOS *****************************
    '*******************************************************************

    ' metodo que se encarga de llamar a los metodos para cargar los datos que corresponden a los egresos'

    Public Sub cargarEgresos()
        ' se obtienen los valores de los montos llamando a los metodos que consultan en la base de datos
        ' monto total del pago de facturas realizadas por el cajero
        pagosFacturas = Me.cargarPagoFacturas
        ' monto total de las salidas realizadas por el cajero
        salidasEfectivo = Me.cargarSalidasEfectivo
        uber = Me.cargarUber

        ' monto total correspondiente a los impuestos de servicios 
        impuestosServicio = Me.cargarImpuestoServicio
        ' monto total de los impuestos de ventas realizadas por el cajero si se pone 1 agarra regresa solo en efectivo, con el 0 agarra todos
        impuestoVentas = Me.cargarImpuestoVentas(0)
        ' monto total de los impuestos de express
        express = Me.cargarServicioExpress
        ' se llama al metodo que se encarga de obtener el monto del fondo final de la caja
        fondoFinal = cargarFondoFinal()

    End Sub

    ' metodo que obtiene el monto de la suma de los impuestos de ventas
    Public Function cargarImpuestoVentas(tipo As Int16)
        Return movimiento_caja.obtenerMontoImpuestoVentas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, tipo)
    End Function

    ' metodo que se encarga de consultar el monto total correspondiente a los pagos de las facturas realizadas por el cajero
    Public Function cargarPagoFacturas() As Double
        Return movimiento_caja.obtenerMontoPagoFacturas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
    End Function

    ' metodo que se encarga de consultar el monto total correspondiente a las salidas realizadas por el cajero
    Public Function cargarSalidasEfectivo() As Double
        Return movimiento_caja.obtenerMontoIntroduccionesSalidas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 1)
    End Function




    Public Function cargarUber() As Double
        Return movimiento_caja.obtenerMontoServiciosUberEats(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
    End Function



    Public Function cargarBonos() As Double
        Return movimiento_caja.obtenerMontoAbonos(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
    End Function

    ' metodo que se encarga de consultar el monto total correspondiente a los impuestos por servicios
    Public Function cargarImpuestoServicio() As Double
        Return movimiento_caja.obtenerMontoImpuestoServicios(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 0)
    End Function

    ' metodo que se encarga de consultar el monto total en efectivo correspondiente a los impuestos por servicios
    Public Function cargarImpuestoServicioEfectivo() As Double
        Return movimiento_caja.obtenerMontoImpuestoServicios(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, 1)
    End Function

    'metodo que obtiene el monto de efectivo almacenado por el cajero
    Public Function cargarFondoFinal() As Double
        Return movimiento_caja.obtenerMontoFondoFinal(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
    End Function

    'metodo que se encarga de imprimir el cierre de caja
    Public Sub imprimirCierre()
        Try
            Dim parametro As New ParameterValues
            Dim numero_factura As New ParameterValues

            Dim pvisualizar As New ParameterDiscreteValue


            Dim factura As New Facturas

            pvisualizar.Value = fondoInicial.ToString("C")
            numero_factura.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@fondo_inicial").ApplyCurrentValues(numero_factura) 's

            pvisualizar.Value = introducciones.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@Introducciones").ApplyCurrentValues(parametro) 's

            pvisualizar.Value = ventasEfectivo.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@ventas_efectivo").ApplyCurrentValues(parametro) 's

            pvisualizar.Value = expressEfectivo.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@express_efectivo").ApplyCurrentValues(parametro) 's

            pvisualizar.Value = impuestosServicioEfectivo.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@imp_serv_efec").ApplyCurrentValues(parametro) 's

            pvisualizar.Value = impuestoVentasEfectivo.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@imp_vtas_efec").ApplyCurrentValues(parametro) 's

            pvisualizar.Value = salidasEfectivo.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@salidas").ApplyCurrentValues(parametro) 's


            pvisualizar.Value = monto_total_efectivo.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@total_efec").ApplyCurrentValues(parametro) 's

            pvisualizar.Value = fondoFinal.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@fondo_final").ApplyCurrentValues(parametro) 's

            pvisualizar.Value = diferencia.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@diferencia_efec").ApplyCurrentValues(parametro) 's

            pvisualizar.Value = ventasTarjeta.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@vtas_tarjeta").ApplyCurrentValues(parametro) 's

            pvisualizar.Value = impuestoVentas.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@imp_vtas").ApplyCurrentValues(parametro) 's

            pvisualizar.Value = impuestosServicio.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@imp_serv").ApplyCurrentValues(parametro) 's

            pvisualizar.Value = express.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@express").ApplyCurrentValues(parametro) 's

            pvisualizar.Value = monto_total.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@total_vtas").ApplyCurrentValues(parametro)

            pvisualizar.Value = ventas_sistema.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@vtas_sist").ApplyCurrentValues(parametro)

            pvisualizar.Value = diferenciaVentas.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@diferencia_vtas").ApplyCurrentValues(parametro)
            
            pvisualizar.Value = (InicioSesion.session.EmpleadoSG.NombreSG + " " + InicioSesion.session.EmpleadoSG.Apellido1SG)
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@usuario").ApplyCurrentValues(parametro) 's

            pvisualizar.Value = dataExpress.ToString("c")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@datafono_Express").ApplyCurrentValues(parametro)

            pvisualizar.Value = dataSalon.ToString("C")
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@datafono_Salon").ApplyCurrentValues(parametro)


            pvisualizar.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@fecha_fin").ApplyCurrentValues(parametro)

            pvisualizar.Value = Convert.ToDateTime(InicioSesion.session.Hora_primer_ingresoSG)
            parametro.Add(pvisualizar)
            factura.DataDefinition.ParameterFields("@fecha_inicio").ApplyCurrentValues(parametro)
            'Dim fechaini As String = InicioSesion.session.Hora_primer_ingresoSG
            'Dim fechaFin As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

            'Dim rep As New ReporteCierredeCaja

            'pvisualizar.Value = fechaFin
            'parametro.Add(pvisualizar)
            'rep.DataDefinition.ParameterFields("@fechaFin").ApplyCurrentValues(parametro)

            'pvisualizar.Value = fechaini
            'parametro.Add(pvisualizar)
            'rep.DataDefinition.ParameterFields("@fechaInc").ApplyCurrentValues(parametro)



            'rep.SetParameterValue("@fecha_inicio", fechaini)
            'rep.SetParameterValue("@fecha_fin", fechaFin)

            'pvisualizar.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            'parametro.Add(pvisualizar)
            'factura.DataDefinition.ParameterFields("Parameter_ReporteCierredeCajarpt_fecha_fin").ApplyCurrentValues(parametro)


            'pvisualizar.Value = InicioSesion.session.Hora_primer_ingresoSG
            'parametro.Add(pvisualizar)
            'factura.DataDefinition.ParameterFields("Parameter_ReporteCierredeCajarpt_fecha_inicio").ApplyCurrentValues(parametro)
            ''factura.DataDefinition.ParameterFields("").ApplyCurrentValues(parametro)

            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = factura
            'reporte.ShowDialog()
            reporte.VistaReportes.PrintReport()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '***************************** EVENTOS *****************************
    '********************************************************************

    ' evento parar cuando se seleccione el monto de introducciones para ver el reporte de estos en la seccion de cuadro de comparacion
    Private Sub lblFondoInicialIntroduccionesComp_Click(sender As Object, e As EventArgs) Handles lblFondoInicialCompEfec.Click
        ' llama al metodo para crear el reporte del fondo inicial
        crear_reportes.reporteFondoInicial()
    End Sub

    ' evento parar cuando se seleccione el monto de introducciones para ver el reporte de estos en la seccion de calculo de ventas
    Private Sub lblIntroduccionesComp_Click(sender As Object, e As EventArgs) Handles lblIntroduccionesCompEfec.Click
        ' llama al metodo para crear el reporte de las introducciones de efectivo
        crear_reportes.reporteIntroducciones()
    End Sub

    ' evento para cuando se seleccione el monto de ventas x sistema - tarjeta
    Private Sub lblVentasXSistemaTarjeta_Click(sender As Object, e As EventArgs) Handles lblVentasEfectivoCompEfec.Click
        ' llama al metodo para crear el reporte de las ventas por sistema en efectivo
        crear_reportes.reporteVentasBrutasEfectivo()
    End Sub

    ' evento del boton de imprimir
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        imprimirCierre()
    End Sub

    Private Sub lblExpressCompEfec_Click(sender As Object, e As EventArgs) Handles lblExpressCompEfec.Click
        ' llama al metodo para crear el reporte de las por express en efectivo
        crear_reportes.reporteExpressEfectivo()
    End Sub

    Private Sub lblUer_Click(sender As Object, e As EventArgs) Handles lblUber.Click
        'llama al metodo para crear el reporte de Uber Eats
        crear_reportes.reporteUberEats()
    End Sub

    Private Sub lblTotalVtasSistCompVtas_Click(sender As Object, e As EventArgs) Handles lblTotalVtasSistCompVtas.Click

    End Sub

    Private Sub lblImpuestoServicio_Click(sender As Object, e As EventArgs) Handles lblImpServicioCompEfec.Click
        ' llama al metodo para crear el reporte de los impuestos de servicio ya INICIO
        ' crear_reportes.reporteImpServEfectivo()
        crear_reportes.reporteImpServ()
    End Sub

    Private Sub CierreCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarInformacion()

    End Sub




    Private Sub lblImpVtasCompEfec_Click(sender As Object, e As EventArgs) Handles lblImpVtasCompEfec.Click
        ' llama al metodo para crear el reporte de los impuestos por ventas en efectivo
        crear_reportes.reporteImpVtasEfectivo()
    End Sub

    Private Sub lblCuentasCanceladasComprobacion_Click(sender As Object, e As EventArgs) Handles lblCuentasCanceladasCompEfec.Click
        ' llama al metodo para crear el reporte de las salidas de efectivo
        crear_reportes.reporteSalidas()
    End Sub

    Private Sub lblFondoInicialCompVtas_Click(sender As Object, e As EventArgs) Handles lblFondoInicialCompVtas.Click
        ' llama al metodo para crear el reporte del fondo inicial
        crear_reportes.reporteFondoInicial()
    End Sub

    Private Sub lblVentasTarjetas_Click(sender As Object, e As EventArgs) Handles lblVentasCompVtas.Click
        ' llama al metodo para crear el reporte de las ventas por sistema en tarjeta
        'crear_reportes.reporteVentasTarjeta()
    End Sub

    Private Sub lblImpVtasCompVtas_Click(sender As Object, e As EventArgs) Handles lblImpVtasCompVtas.Click
        ' llama al metodo para crear el reporte de los impuestos por ventas totales
        crear_reportes.reporteImpVtas()
    End Sub

    Private Sub lblImpServCompVtas_Click(sender As Object, e As EventArgs)
        ' llama al metodo para crear el reporte de los impuestos de servicio
        crear_reportes.reporteImpServ()
    End Sub

    Private Sub lblExpresCompVtas_Click(sender As Object, e As EventArgs) Handles lblExpresCompVtas.Click
        ' llama al metodo para crear el reporte de las ventas por express
        crear_reportes.reporteExpress()
    End Sub

    Private Sub lblIntroduccionesCompVtas_Click(sender As Object, e As EventArgs) Handles lblIntroduccionesCompVtas.Click
        ' llama al metodo para crear el reporte de las introducciones de efectivo
        crear_reportes.reporteIntroducciones()
    End Sub

    Private Sub lblCuentasCanceladasCalculo_Click(sender As Object, e As EventArgs) Handles lblCuentasCanceladasCompVtas.Click
        ' llama al metodo para crear el reporte de las salidas de efectivo
        crear_reportes.reporteSalidas()
    End Sub



    Private Sub lblBonosTotalesEfectivo_Click(sender As Object, e As EventArgs)
        ' llama al metodo para crear el reporte del fondo final
        crear_reportes.reporteBonos()
    End Sub



    Private Sub lblBonosCanceladosCampVentas_Click(sender As Object, e As EventArgs)
        ' llama al metodo para crear el reporte del fondo final
        crear_reportes.reporteBonos()
    End Sub

    Private Sub lblFondoFinal_Click(sender As Object, e As EventArgs) Handles lblFondoFinalCompVtas.Click
        ' llama al metodo para crear el reporte del fondo final
        crear_reportes.reporteFondoFinal()
    End Sub

    ' boton modificar
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        ' indica que se esta modificando el cierre
        modificar_cierre = True
        Dim movimientos_datos As New MovimientoCajaDatos
        ' llama al metodo que revierte el cierre de caja
        movimientos_datos.revertirCierreCaja(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
        'Instancia a la ventana de movimientos de efectivo
        Dim fondoFinal As New MovimientosEfectivo
        ' coloca la variable de fondoFinal en true para saber que es la accion que se va a realizar
        fondoFinal.fondoFinal = True
        ' llama al metodo para cargar y mostrar las nominaciones
        fondoFinal.cargarDenominaciones()

        fondoFinal.ShowDialog()
        ' coloca la variable de fondoFinal en false para saber que la accion ya se realizo
        fondoFinal.fondoFinal = False

        ' llama al metodo que se encarga de cargar toda la informaacion para poder mostrarlas
        cargarInformacion()
    End Sub

End Class