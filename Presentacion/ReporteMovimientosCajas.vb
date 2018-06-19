Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports CrystalDecisions.Shared

Public Class ReporteMovimientosCajas
    Private printFont As Font
    Private streamToPrint As StreamReader
    Private Shared filePath As String

    Public Sub New()
        InitializeComponent()
        pbSegundaOpcion.Hide()
        lblOpcion2.Hide()

        ' posiciones iniciales para reporte de introducciones y salidas
        fechaPosY = denominacionPosY = cantidadPosY = subtotalPosY = cambioPosY = 15

        fechaPosX = 38
        denominacionPosX = 234
        cantidadPosX = 463
        subtotalPosX = 594
        cambioPosX = 749

        ' posiciones iniciales para reporte de fondo inical o final
        usuarioPosY = fechaFondosPosY = cantidadFondosPosY = subtotalFondosPosY = monedaPosY = denominacionFondosPosY = 15

        usuarioPosX = 13
        fechaFondosPosX = 199
        monedaPosX = 371
        denominacionFondosPosX = 494
        cantidadFondosPosX = 666
        subtotalFondosPosX = 762

    End Sub

    ' se llama los metodos para mostrar las cajas de texto y mostrar los datos
    Public Sub mostrarCajasTextoIntroSale(lista As List(Of ReporteIntroSale), posY_inicial As Integer, panel As Panel)
        Me.lblReporte.Location = New System.Drawing.Point(325, 30)
        ' se llama el metodo para crear las etiquetas
        crearEtiquetasIntroSale(posY_inicial, panel)
        ' se recorre la lista de los reportes
        For i = 0 To lista.Count - 1
            mostrarCajasTextoFechaIntroSale(lista(i))
            mostrarCajasTextoDenominacionIntroSale(lista(i))
            mostrarCajasTextoCantidadIntroSale(lista(i))
            mostrarCajasTextoSubtotalIntroSale(lista(i))
            mostrarCajasTextoCambioIntroSale(lista(i))
        Next
    End Sub

    ' se crean las etiquetas de la pantalla
    Public Sub crearEtiquetasIntroSale(posY_inicial As Integer, panel As Panel)
        Me.lblEvento.AutoSize = True
        Me.lblEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvento.ForeColor = System.Drawing.Color.White
        Me.lblEvento.Location = New System.Drawing.Point(60, posY_inicial)
        Me.lblEvento.Name = "lblEvento"
        Me.lblEvento.Size = New System.Drawing.Size(130, 20)
        Me.lblEvento.TabIndex = 2
        Me.lblEvento.Text = "Fecha de Evento"
        '
        'lblCambio
        '
        Me.lblCambio.AutoSize = True
        Me.lblCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambio.ForeColor = System.Drawing.Color.White
        Me.lblCambio.Location = New System.Drawing.Point(746, posY_inicial)
        Me.lblCambio.Name = "lblCambio"
        Me.lblCambio.Size = New System.Drawing.Size(127, 20)
        Me.lblCambio.TabIndex = 4
        Me.lblCambio.Text = "Cambio de Dólar"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.ForeColor = System.Drawing.Color.White
        Me.lblSubtotal.Location = New System.Drawing.Point(616, posY_inicial)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(69, 20)
        Me.lblSubtotal.TabIndex = 5
        Me.lblSubtotal.Text = "Subtotal"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.ForeColor = System.Drawing.Color.White
        Me.lblCantidad.Location = New System.Drawing.Point(475, posY_inicial)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(73, 20)
        Me.lblCantidad.TabIndex = 6
        Me.lblCantidad.Text = "Cantidad"
        '
        'lblDenominacion
        '
        Me.lblDenominacion.AutoSize = True
        Me.lblDenominacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDenominacion.ForeColor = System.Drawing.Color.White
        Me.lblDenominacion.Location = New System.Drawing.Point(283, posY_inicial)
        Me.lblDenominacion.Name = "lblDenominacion"
        Me.lblDenominacion.Size = New System.Drawing.Size(111, 20)
        Me.lblDenominacion.TabIndex = 7
        Me.lblDenominacion.Text = "Denominación"

        ' se agregan los controles al panel especificado
        panel.Controls.Add(Me.lblEvento)
        panel.Controls.Add(Me.lblDenominacion)
        panel.Controls.Add(Me.lblCantidad)
        panel.Controls.Add(Me.lblCambio)
        panel.Controls.Add(Me.lblSubtotal)
    End Sub

    ' MOSTRAR CAJAS DE TEXTO DE LAS FECHAS
    Public Sub mostrarCajasTextoFechaIntroSale(lista As ReporteIntroSale)
        ' se crean las cajas de texto y sus atributos
        txtFecha = New TextBox
        txtFecha.Name = ("txtFecha" + (lista.DescripcionSG.ToString) + lista.FechaSG)
        txtFecha.Text = lista.FechaSG.ToString
        txtFecha.ReadOnly = True
        txtFecha.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtFecha.Location = New Point(fechaPosX, fechaPosY)
        txtFecha.Size() = New System.Drawing.Size(165, 20)
        txtFecha.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoFecha.Add(txtFecha)
        ' se agregan al panel en la pantalla
        pnlLista.Controls.Add(txtFecha)
        'se aumenta la posicion para la siguiente caja de texto
        fechaPosY += 25
    End Sub

    ' MOSTRAR CAJAS DE TEXTO DE LAS denominaciones de las monedas
    Public Sub mostrarCajasTextoDenominacionIntroSale(lista As ReporteIntroSale)
        ' se crean las cajas de texto y sus atributos
        txtDenominacion = New TextBox
        txtDenominacion.Name = ("txtDenominacion" + (lista.DescripcionSG.ToString) + lista.FechaSG)
        txtDenominacion.Text = lista.DescripcionSG
        txtDenominacion.ReadOnly = True
        txtDenominacion.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtDenominacion.Location = New Point(denominacionPosX, denominacionPosY)
        txtDenominacion.Size() = New System.Drawing.Size(202, 20)
        txtDenominacion.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoDenominacion.Add(txtDenominacion)
        ' se agregan al panel en la pantalla
        pnlLista.Controls.Add(txtDenominacion)
        'se aumenta la posicion para la siguiente caja de texto
        denominacionPosY += 25
    End Sub

    ' MOSTRAR CAJAS DE TEXTO DE LAS cantidades
    Public Sub mostrarCajasTextoCantidadIntroSale(lista As ReporteIntroSale)
        ' se crean las cajas de texto y sus atributos
        txtCantidad = New TextBox
        txtCantidad.Name = ("txtCantidad" + (lista.DescripcionSG.ToString) + lista.FechaSG)
        txtCantidad.Text = lista.CantidadSG.ToString
        txtCantidad.ReadOnly = True
        txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        txtCantidad.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtCantidad.Location = New Point(cantidadPosX, cantidadPosY)
        txtCantidad.Size() = New System.Drawing.Size(100, 20)
        txtCantidad.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoCantidad.Add(txtCantidad)
        ' se agregan al panel en la pantalla
        pnlLista.Controls.Add(txtCantidad)
        'se aumenta la posicion para la siguiente caja de texto
        cantidadPosY += 25
    End Sub

    ' MOSTRAR CAJAS DE TEXTO DEL subtotal
    Public Sub mostrarCajasTextoSubtotalIntroSale(lista As ReporteIntroSale)
        ' se crean las cajas de texto y sus atributos
        txtSubtotal = New TextBox
        txtSubtotal.Name = ("txtSubtotal" + (lista.DescripcionSG.ToString) + lista.FechaSG)
        txtSubtotal.Text = lista.SubtotalSG.ToString("C")
        txtSubtotal.ReadOnly = True
        txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        txtSubtotal.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtSubtotal.Location = New Point(subtotalPosX, subtotalPosY)
        txtSubtotal.Size() = New System.Drawing.Size(125, 20)
        txtSubtotal.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoSubtotal.Add(txtSubtotal)
        ' se agregan al panel en la pantalla
        pnlLista.Controls.Add(txtSubtotal)
        'se aumenta la posicion para la siguiente caja de texto
        subtotalPosY += 25
    End Sub

    ' MOSTRAR CAJAS DE TEXTO DEL cambio del dolar
    Public Sub mostrarCajasTextoCambioIntroSale(lista As ReporteIntroSale)
        ' se crean las cajas de texto y sus atributos
        txtTipoCambio = New TextBox
        txtTipoCambio.Name = ("txtTipoCambio" + (lista.DescripcionSG.ToString) + lista.FechaSG)
        txtTipoCambio.Text = lista.tipocambio.ToString("C")
        txtTipoCambio.ReadOnly = True
        txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        txtTipoCambio.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtTipoCambio.Location = New Point(cambioPosX, cambioPosY)
        txtTipoCambio.Size() = New System.Drawing.Size(123, 20)
        txtTipoCambio.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoTipoCambio.Add(txtTipoCambio)
        ' se agregan al panel en la pantalla
        pnlLista.Controls.Add(txtTipoCambio)
        'se aumenta la posicion para la siguiente caja de texto
        cambioPosY += 25
    End Sub

    '***********************************************************
    '*************** Fondo inicial o fondo final ***************
    '***********************************************************

    ' se llama los metodos para mostrar las cajas de texto y mostrar los datos
    Public Sub mostrarCajasTextoFondos(lista As List(Of ReporteFondos))
        Me.lblReporte.Location = New System.Drawing.Point(380, 30)
        ' se llama el metodo para crear las etiquetas
        crearEtiquetasFondos()
        ' se recorre la lista de los reportes
        For i = 0 To lista.Count - 1
            mostrarCajasTextoUsuarioFondos(lista(i))
            mostrarCajasTextoFechaFondos(lista(i))
            mostrarCajasTextoMonedaFondos(lista(i))
            mostrarCajasTextoDenominacionFondos(lista(i))
            mostrarCajasTextoCantidadFondos(lista(i))
            mostrarCajasTextoSubtotalFondos(lista(i))
        Next
    End Sub

    ' metodo que cre las etiquetas para el reporte de fondo inicial o fondo final
    Public Sub crearEtiquetasFondos()
        '
        'lblEmpleadoRecibeFondo
        '
        Me.lblEmpleadoRecibeFondo.AutoSize = True
        Me.lblEmpleadoRecibeFondo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpleadoRecibeFondo.ForeColor = System.Drawing.Color.White
        Me.lblEmpleadoRecibeFondo.Location = New System.Drawing.Point(34, 122)
        Me.lblEmpleadoRecibeFondo.Name = "lblEmpleadoRecibeFondo"
        Me.lblEmpleadoRecibeFondo.Size = New System.Drawing.Size(135, 20)
        Me.lblEmpleadoRecibeFondo.TabIndex = 10
        Me.lblEmpleadoRecibeFondo.Text = "Empleado Recibe"
        '
        'lblFechaInicioFondo
        '
        Me.lblFechaInicioFondo.AutoSize = True
        Me.lblFechaInicioFondo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicioFondo.ForeColor = System.Drawing.Color.White
        Me.lblFechaInicioFondo.Location = New System.Drawing.Point(220, 122)
        Me.lblFechaInicioFondo.Name = "lblFechaInicioFondo"
        Me.lblFechaInicioFondo.Size = New System.Drawing.Size(117, 20)
        Me.lblFechaInicioFondo.TabIndex = 11
        Me.lblFechaInicioFondo.Text = "Fecha de Inicio"
        '
        'lblDenominacionFondo
        '
        Me.lblDenominacionFondo.AutoSize = True
        Me.lblDenominacionFondo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDenominacionFondo.ForeColor = System.Drawing.Color.White
        Me.lblDenominacionFondo.Location = New System.Drawing.Point(520, 122)
        Me.lblDenominacionFondo.Name = "lblDenominacionFondo"
        Me.lblDenominacionFondo.Size = New System.Drawing.Size(111, 20)
        Me.lblDenominacionFondo.TabIndex = 13
        Me.lblDenominacionFondo.Text = "Denominación"
        '
        'lblMonedaFondo
        '
        Me.lblMonedaFondo.AutoSize = True
        Me.lblMonedaFondo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonedaFondo.ForeColor = System.Drawing.Color.White
        Me.lblMonedaFondo.Location = New System.Drawing.Point(393, 122)
        Me.lblMonedaFondo.Name = "lblMonedaFondo"
        Me.lblMonedaFondo.Size = New System.Drawing.Size(67, 20)
        Me.lblMonedaFondo.TabIndex = 12
        Me.lblMonedaFondo.Text = "Moneda"
        '
        'lblCantidadFondo
        '
        Me.lblCantidadFondo.AutoSize = True
        Me.lblCantidadFondo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadFondo.ForeColor = System.Drawing.Color.White
        Me.lblCantidadFondo.Location = New System.Drawing.Point(673, 122)
        Me.lblCantidadFondo.Name = "lblCantidadFondo"
        Me.lblCantidadFondo.Size = New System.Drawing.Size(73, 20)
        Me.lblCantidadFondo.TabIndex = 14
        Me.lblCantidadFondo.Text = "Cantidad"
        '
        'lblSubtotalFondo
        '
        Me.lblSubtotalFondo.AutoSize = True
        Me.lblSubtotalFondo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotalFondo.ForeColor = System.Drawing.Color.White
        Me.lblSubtotalFondo.Location = New System.Drawing.Point(787, 122)
        Me.lblSubtotalFondo.Name = "lblSubtotalFondo"
        Me.lblSubtotalFondo.Size = New System.Drawing.Size(69, 20)
        Me.lblSubtotalFondo.TabIndex = 15
        Me.lblSubtotalFondo.Text = "Subtotal"
    End Sub

    ' MOSTRAR CAJAS DE TEXTO DEL USUARIO QUE ASIGNO EL FONDO INICIAL
    Public Sub mostrarCajasTextoUsuarioFondos(lista As ReporteFondos)
        ' se crean las cajas de texto y sus atributos
        txtUsuarioAsignaFondos = New TextBox
        txtUsuarioAsignaFondos.Name = ("txtUsuarioAsignaFondos" + (lista.DenominacionSG.ToString) + lista.FechaSG)
        txtUsuarioAsignaFondos.Text = lista.Empleado_asignanSG.ToString
        txtUsuarioAsignaFondos.ReadOnly = True
        txtUsuarioAsignaFondos.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtUsuarioAsignaFondos.Location = New Point(usuarioPosX, usuarioPosY)
        txtUsuarioAsignaFondos.Size() = New System.Drawing.Size(180, 20)
        txtUsuarioAsignaFondos.TabIndex = 0
        'txtUsuarioAsignaFondos.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoUsuarioAsignaFondos.Add(txtUsuarioAsignaFondos)
        ' se agregan al panel en la pantalla
        pnlLista.Controls.Add(txtUsuarioAsignaFondos)
        'se aumenta la posicion para la siguiente caja de texto
        usuarioPosY += 25
    End Sub

    ' MOSTRAR CAJAS DE TEXTO DE LAS FECHAS
    Public Sub mostrarCajasTextoFechaFondos(lista As ReporteFondos)
        ' se crean las cajas de texto y sus atributos
        txtFechaFondos = New TextBox
        txtFechaFondos.Name = ("txtFechaFondos" + (lista.DenominacionSG.ToString) + lista.FechaSG)
        txtFechaFondos.Text = lista.FechaSG.ToString
        txtFechaFondos.ReadOnly = True
        txtFechaFondos.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtFechaFondos.Location = New Point(fechaFondosPosX, fechaFondosPosY)
        txtFechaFondos.Size() = New System.Drawing.Size(166, 20)
        txtFechaFondos.TabIndex = 1
        'txtFecha.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoFechaFondos.Add(txtFechaFondos)
        ' se agregan al panel en la pantalla
        pnlLista.Controls.Add(txtFechaFondos)
        'se aumenta la posicion para la siguiente caja de texto
        fechaFondosPosY += 25
    End Sub

    ' MOSTRAR CAJAS DE TEXTO DEL TIPO de las monedas
    Public Sub mostrarCajasTextoMonedaFondos(lista As ReporteFondos)
        ' se crean las cajas de texto y sus atributos
        txtTipoMonedaFondos = New TextBox
        txtTipoMonedaFondos.Name = ("txtTipoMonedaFondos" + (lista.MonedaSG.ToString) + lista.FechaSG)
        txtTipoMonedaFondos.Text = lista.MonedaSG
        txtTipoMonedaFondos.ReadOnly = True
        txtTipoMonedaFondos.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtTipoMonedaFondos.Location = New Point(monedaPosX, monedaPosY)
        txtTipoMonedaFondos.Size() = New System.Drawing.Size(117, 20)
        txtTipoMonedaFondos.TabIndex = 2
        'txtTipoMonedaFondos.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoTipoMonedaFondos.Add(txtTipoMonedaFondos)
        ' se agregan al panel en la pantalla
        pnlLista.Controls.Add(txtTipoMonedaFondos)
        'se aumenta la posicion para la siguiente caja de texto
        monedaPosY += 25
    End Sub

    ' MOSTRAR CAJAS DE TEXTO DE LAS denominaciones de las monedas
    Public Sub mostrarCajasTextoDenominacionFondos(lista As ReporteFondos)
        ' se crean las cajas de texto y sus atributos
        txtDenominacionFondos = New TextBox
        txtDenominacionFondos.Name = ("txtDenominacionFondos" + (lista.DenominacionSG.ToString) + lista.FechaSG)
        txtDenominacionFondos.Text = lista.DenominacionSG
        txtDenominacionFondos.ReadOnly = True
        txtDenominacionFondos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        txtDenominacionFondos.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtDenominacionFondos.Location = New Point(denominacionFondosPosX, denominacionFondosPosY)
        txtDenominacionFondos.Size() = New System.Drawing.Size(166, 20)
        txtDenominacionFondos.TabIndex = 3
        'txtDenominacionFondos.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoDenominacion.Add(txtDenominacionFondos)
        ' se agregan al panel en la pantalla
        pnlLista.Controls.Add(txtDenominacionFondos)
        'se aumenta la posicion para la siguiente caja de texto
        denominacionFondosPosY += 25
    End Sub

    ' MOSTRAR CAJAS DE TEXTO DE LAS cantidades
    Public Sub mostrarCajasTextoCantidadFondos(lista As ReporteFondos)
        ' se crean las cajas de texto y sus atributos
        txtCantidadFondos = New TextBox
        txtCantidadFondos.Name = ("txtCantidadFondos" + (lista.DenominacionSG.ToString) + lista.FechaSG)
        txtCantidadFondos.Text = lista.CantidadSG.ToString
        txtCantidadFondos.ReadOnly = True
        txtCantidadFondos.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtCantidadFondos.Location = New Point(cantidadFondosPosX, cantidadFondosPosY)
        txtCantidadFondos.Size() = New System.Drawing.Size(90, 20)
        txtCantidadFondos.TabIndex = 4
        'txtCantidadFondos.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoCantidadFondos.Add(txtCantidadFondos)
        ' se agregan al panel en la pantalla
        pnlLista.Controls.Add(txtCantidadFondos)
        'se aumenta la posicion para la siguiente caja de texto
        cantidadFondosPosY += 25
    End Sub

    ' MOSTRAR CAJAS DE TEXTO DEL subtotal
    Public Sub mostrarCajasTextoSubtotalFondos(lista As ReporteFondos)
        ' se crean las cajas de texto y sus atributos
        txtSubtotalFondos = New TextBox
        txtSubtotalFondos.Name = ("txtSubtotalFondos" + (lista.DenominacionSG.ToString) + lista.FechaSG)
        txtSubtotalFondos.Text = lista.SubtotalSG.ToString("C")
        txtSubtotalFondos.ReadOnly = True
        txtSubtotalFondos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        txtSubtotalFondos.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtSubtotalFondos.Location = New Point(subtotalFondosPosX, subtotalFondosPosY)
        txtSubtotalFondos.Size() = New System.Drawing.Size(134, 20)
        txtSubtotalFondos.TabIndex = 5
        'txtSubtotal.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoSubtotalFondos.Add(txtSubtotalFondos)
        ' se agregan al panel en la pantalla
        pnlLista.Controls.Add(txtSubtotalFondos)
        'se aumenta la posicion para la siguiente caja de texto
        subtotalFondosPosY += 25
    End Sub


    '********************************************************
    '************ Fondo inicial e introducciones ************
    '********************************************************

    ' metodo que se encarga de mostrar el reporte para fondo inicial junto a las introducciones de efectivo
    Public Sub mostrarFondoInicialIntroducciones(fondo_inicial As List(Of ReporteFondos), introducciones As List(Of ReporteIntroSale))
        ' valida que la lista de fondo inicial no este vacia
        If Not IsNothing(fondo_inicial) And fondo_inicial.Count > 0 Then
            ' se llama al metodo que muestra el detalle del fondo inicial
            mostrarCajasTextoFondos(fondo_inicial)
        End If

        ' valida que la lista de introducciones no este vacia
        If Not IsNothing(introducciones) And introducciones.Count > 0 Then
            ' se asignan las posiciones a inciar del reporte de la seccion de introducciones

            pbSegundaOpcion.Location = New System.Drawing.Point(276, (subtotalFondosPosY + 30))
            lblOpcion2.Location = New System.Drawing.Point(325, (subtotalFondosPosY + 44))
            pbSegundaOpcion.Show()
            lblOpcion2.Show()
            'Me.pbSegundaOpcion.Location = New System.Drawing.Point(276, 18)
            'Me.lblOpcion2.Location = New System.Drawing.Point(347, 38)
            fechaPosY = fechaFondosPosY + 140
            denominacionPosY = fechaFondosPosY + 140
            cantidadPosY = fechaFondosPosY + 140
            subtotalPosY = fechaFondosPosY + 140
            cambioPosY = fechaFondosPosY + 140

            ' se llama al metodo que muestra el detalle de las introducciones
            mostrarCajasTextoIntroSale(introducciones, (fechaFondosPosY + 100), pnlLista)

        End If
    End Sub

    Private Sub ReporteMovimientosCajas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class