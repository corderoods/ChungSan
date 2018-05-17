Public Class HistoricoFacturas
    ' lista que alacenara la lista de los pagos de facturas a mostrar para el historico
    Public lista_pagos As New List(Of ReportePagoFactura)
    ' instancia al formulario de mensaje para mostrar errores
    Dim mensaje As New Mensaje

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' se muestran las fechas actuales para iniciar la busqueda del reporte
        txtFechaInicio.Text = InicioSesion.session.Hora_inicioSG 'DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
        txtFechaFinal.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") 'ObtenerHora.obtenerHoraActual.ToString

        ' llama al metodo que asigna las posiciones iniciales
        asignarPosiciones()

        mostrarFacturas()

    End Sub

    Public Sub mostrarFacturas()
        Dim fechaActual As DateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

        ' intancia a la clase que trae la lista de la base de datos
        Dim pago_facturas As New MovimientoCajaDatos
        ' se obtiene la lista
        lista_pagos = pago_facturas.obtenerHistoricoPagoFacturas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG, fechaActual)

        ' valida que la lista no este vacía
        If Not IsNothing(lista_pagos) And lista_pagos.Count > 0 Then
            ' se recorre la lista y se llaman a los metodos para crear las cajas de texto y mostrar la informacion
            For i As Integer = 0 To lista_pagos.Count - 1
                ' se llama al metodo para crear las cajas de texto y mostrar la informacion
                mostrarCajasTexto(i)
            Next
        Else
            mensaje.tipoMensaje("error")
            mensaje.lblMensaje.Text = "No hay datos que mostrar"
            mensaje.ShowDialog()
        End If
    End Sub

    ' metodo para asignar las posiciones iniciales
    Public Sub asignarPosiciones()
        ' se asignan las posiciones iniciales para cada caja de texto
        fecha_pagoPosY = 10
        proveedorPosY = 10
        tipoPosY = 10
        numeroPosY = 10
        montoPosY = 10

        fecha_pagoPosX = 11
        proveedorPosX = 200
        tipoPosX = 474
        numeroPosX = 615
        montoPosX = 773
    End Sub

    ' metodo que se encarga de llamar a los metodos para mostrar las cajas de texto
    Public Sub mostrarCajasTexto(pos As Integer)
        mostrarCajasTextoFechaPagoFacturas(pos)
        mostrarCajasTextoProveedor(pos)
        mostrarCajasTextoTipo(pos)

        mostrarCajasTextoNumeroFactura(pos)

        mostrarCajasTextoMontoFactura(pos)

    End Sub

    ' metodo que se encarga de mostrar la informacion de la fecha en que se realizaron los pagos de las facturas
    Public Sub mostrarCajasTextoFechaPagoFacturas(pos As Integer)
        ' se crean las cajas de texto y sus atributos
        txtFechaPago = New TextBox
        txtFechaPago.Name = ("txtFechaPago" + lista_pagos(pos).FacturaSG.Numero_facturaSG.ToString + lista_pagos(pos).FacturaSG.Numero_facturaSG.ToString)
        txtFechaPago.Text = lista_pagos(pos).FacturaSG.Fecha_pagoSG.ToString
        txtFechaPago.ReadOnly = True
        txtFechaPago.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtFechaPago.Location = New Point(fecha_pagoPosX, fecha_pagoPosY)
        txtFechaPago.Size() = New System.Drawing.Size(165, 20)
        txtFechaPago.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoFecha.Add(txtFechaPago)
        ' se agregan al panel en la pantalla
        pnlListaPagos.Controls.Add(txtFechaPago)
        'se aumenta la posicion para la siguiente caja de texto
        fecha_pagoPosY += 35
    End Sub

    ' metodo que se encarga de mostrar la informacion de los proveedores de los pagos de las facturas
    Public Sub mostrarCajasTextoProveedor(pos As Integer)
        ' se crean las cajas de texto y sus atributos
        txtProveedor = New TextBox
        txtProveedor.Name = ("txtProveedor" + lista_pagos(pos).FacturaSG.Numero_facturaSG.ToString + lista_pagos(pos).FacturaSG.Numero_facturaSG.ToString)
        txtProveedor.Text = lista_pagos(pos).Nombre_proveedorSG.ToString
        txtProveedor.ReadOnly = True
        txtProveedor.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtProveedor.Location = New Point(proveedorPosX, proveedorPosY)
        txtProveedor.Size() = New System.Drawing.Size(247, 20)
        txtProveedor.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoProveedor.Add(txtProveedor)
        ' se agregan al panel en la pantalla
        pnlListaPagos.Controls.Add(txtProveedor)
        'se aumenta la posicion para la siguiente caja de texto
        proveedorPosY += 35
    End Sub

    ' metodo que se encarga de mostrar la informacion de los tipos de pagos de los pagos de las facturas
    Public Sub mostrarCajasTextoTipo(pos As Integer)
        ' se crean las cajas de texto y sus atributos
        txtTipo = New TextBox
        txtTipo.Name = ("txtTipo" + lista_pagos(pos).FacturaSG.Numero_facturaSG.ToString + lista_pagos(pos).FacturaSG.Numero_facturaSG.ToString)
        txtTipo.Text = lista_pagos(pos).FacturaSG.TipoSG.ToString
        txtTipo.ReadOnly = True
        txtTipo.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtTipo.Location = New Point(tipoPosX, tipoPosY)
        txtTipo.Size() = New System.Drawing.Size(119, 20)
        txtTipo.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoTipo.Add(txtTipo)
        ' se agregan al panel en la pantalla
        pnlListaPagos.Controls.Add(txtTipo)
        'se aumenta la posicion para la siguiente caja de texto
        tipoPosY += 35
    End Sub

    ' metodo que se encarga de mostrar la informacion del número de la factura que se pagó
    Public Sub mostrarCajasTextoNumeroFactura(pos As Integer)
        ' se crean las cajas de texto y sus atributos
        txtNumero = New TextBox
        txtNumero.Name = ("txtNumero" + lista_pagos(pos).FacturaSG.Numero_facturaSG.ToString + lista_pagos(pos).FacturaSG.Numero_facturaSG.ToString)
        txtNumero.Text = lista_pagos(pos).FacturaSG.Numero_facturaSG.ToString
        txtNumero.ReadOnly = True
        txtNumero.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtNumero.Location = New Point(numeroPosX, numeroPosY)
        txtNumero.Size() = New System.Drawing.Size(131, 20)
        txtNumero.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoNumero.Add(txtNumero)
        ' se agregan al panel en la pantalla
        pnlListaPagos.Controls.Add(txtNumero)
        'se aumenta la posicion para la siguiente caja de texto
        numeroPosY += 35
    End Sub

    ' metodo que se encarga de mostrar la informacion del monto de la factura que se pagó
    Public Sub mostrarCajasTextoMontoFactura(pos As Integer)
        ' se crean las cajas de texto y sus atributos
        txtMonto = New TextBox
        txtMonto.Name = ("txtMonto" + lista_pagos(pos).FacturaSG.Numero_facturaSG.ToString + lista_pagos(pos).FacturaSG.Numero_facturaSG.ToString)
        txtMonto.Text = lista_pagos(pos).FacturaSG.Monto_facturaSG.ToString("C")
        txtMonto.ReadOnly = True
        txtMonto.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtMonto.Location = New Point(montoPosX, montoPosY)
        txtMonto.Size() = New System.Drawing.Size(119, 20)
        txtMonto.Cursor = System.Windows.Forms.Cursors.Hand
        ' se agrega a la lista de texbox
        listaCajasTextoMonto.Add(txtMonto)
        ' se agregan al panel en la pantalla
        pnlListaPagos.Controls.Add(txtMonto)
        'se aumenta la posicion para la siguiente caja de texto
        montoPosY += 35
    End Sub

    ' accion del boton para realizar la consulta
    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        ' se quitan los datos que habian en la pantalla
        pnlListaPagos.Controls.Clear()
        listaControles.Clear()
        ' llama al metodo que asigna las posiciones iniciales
        asignarPosiciones()
        ' se inicializa la variable y se asigna el valor de la hora actual del sistema
        Dim fechaActual As DateTime = (DateTime.Parse(DateTime.Now))

        ' valida que se esten ingresando las fechas
        If txtFechaInicio.Text <> "" And txtFechaFinal.Text <> "" Then
            ' valida que el formato de las fechas esten bien
            If IsDate(txtFechaInicio.Text) And IsDate(txtFechaFinal.Text) Then
                ' validar que la fecha de inicio no pase de la fecha actual
                If ((DateTime.Parse(txtFechaInicio.Text) <= fechaActual)) Then
                    ' se valida que la fecha de inicio no sea mayor que la fecha final
                    If ((DateTime.Parse(txtFechaInicio.Text) <= (DateTime.Parse(txtFechaFinal.Text)))) Then
                        ' intancia a la clase que trae la lista de la base de datos
                        Dim pago_facturas As New MovimientoCajaDatos
                        ' se obtiene la lista
                        lista_pagos = pago_facturas.obtenerHistoricoPagoFacturas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, txtFechaInicio.Text, txtFechaFinal.Text)

                        ' valida que la lista no este vacía
                        If Not IsNothing(lista_pagos) And lista_pagos.Count > 0 Then
                            ' se recorre la lista y se llaman a los metodos para crear las cajas de texto y mostrar la informacion
                            For i As Integer = 0 To lista_pagos.Count - 1
                                ' se llama al metodo para crear las cajas de texto y mostrar la informacion
                                mostrarCajasTexto(i)
                            Next
                        Else
                            mensaje.tipoMensaje("error")
                            mensaje.lblMensaje.Text = "No hay datos que mostrar"
                            mensaje.ShowDialog()
                        End If
                    Else
                        mensaje.tipoMensaje("error")
                        mensaje.lblMensaje.Text = "Fecha de inicio no puede ser mayor que la fecha final"
                        mensaje.ShowDialog()
                    End If
                Else
                    mensaje.tipoMensaje("error")
                    mensaje.lblMensaje.Text = "Fecha de Inicio no puede ser mayor a la fecha actual"
                    mensaje.ShowDialog()
                End If
            Else
                mensaje.tipoMensaje("error")
                mensaje.lblMensaje.Text = "Formato de fecha inválido"
                mensaje.ShowDialog()
            End If
        Else
            mensaje.tipoMensaje("error")
            mensaje.lblMensaje.Text = "Fecha inválida"
            mensaje.ShowDialog()
        End If
    End Sub

    ' evento para cuando se digita la fecha inicial
    Private Sub txtFechaInicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFechaInicio.KeyPress
        validarFormatoFecha(sender, e)
    End Sub

    ' evento para cuando se digita la fecha final
    Private Sub txtFechaFinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFechaFinal.KeyPress
        validarFormatoFecha(sender, e)
    End Sub

    ' validar si se esta insertando digitos que pertenezcan al formato de fecha
    Public Sub validarFormatoFecha(sender As Object, e As KeyPressEventArgs)
        ' valida que sea un digito
        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "/" Or e.KeyChar = "-" Or e.KeyChar = ":" Or e.KeyChar = " " Then
            e.Handled = False
        Else
            'CType(sender, TextBox).Text = CType(sender, TextBox).Text.Substring(0, CType(sender, TextBox).Text.Length)
            e.Handled = True
        End If
    End Sub

    Public Sub mostrarReporteFacturasPagadasProveedor(fecha_inicio As String, fecha_final As String)
        ' se quitan los datos que habian en la pantalla
        pnlListaPagos.Controls.Clear()
        listaControles.Clear()
        ' llama al metodo que asigna las posiciones iniciales
        asignarPosiciones()

        ' intancia a la clase que trae la lista de la base de datos
        Dim pago_facturas As New MovimientoCajaDatos
        ' se obtiene la lista
        lista_pagos = pago_facturas.obtenerHistoricoPagoFacturas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, txtFechaInicio.Text, txtFechaFinal.Text)
        ' valida que la lista no este vacía
        If Not IsNothing(lista_pagos) And lista_pagos.Count > 0 Then
            ' se recorre la lista y se llaman a los metodos para crear las cajas de texto y mostrar la informacion
            For i As Integer = 0 To lista_pagos.Count - 1
                ' se llama al metodo para crear las cajas de texto y mostrar la informacion
                mostrarCajasTexto(i)
            Next
        Else
            mensaje.tipoMensaje("error")
            mensaje.lblMensaje.Text = "No hay datos que mostrar"
            mensaje.ShowDialog()
        End If
    End Sub

End Class