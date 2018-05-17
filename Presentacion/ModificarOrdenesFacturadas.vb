Public Class ModificarOrdenesFacturadas

    ' lista que alacenara la lista de los pagos de facturas a mostrar para el historico
    Public listaFacturas As New List(Of List(Of String))
    Dim mensaje As New Mensaje
    Dim facturacionDatos As New FacturacionDatos

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' llama al metodo que asigna las posiciones iniciales
        asignarPosiciones()

        mostrarFacturas()
    End Sub

    Public Sub mostrarFacturas()
        pnlfacturas.Controls.Clear()

        ' intancia a la clase que trae la lista de la base de datos
        Dim pago_facturas As New MovimientoCajaDatos
        ' se obtiene la lista

        listaFacturas = facturacionDatos.obtenerFacturasPagadas(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)

        ' valida que la lista no este vacía
        If Not IsNothing(listaFacturas) And listaFacturas.Count > 0 Then
            ' se recorre la lista y se llaman a los metodos para crear las cajas de texto y mostrar la informacion
            For i As Integer = 0 To listaFacturas.Count - 1
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
        numFacturaPosY = 10
        numOrdenPosY = 10
        fechaPosY = 10
        clientePosY = 10
        montoPosY = 10
        pagoPosY = 10
        tipoPosY = 10

        numFacturaPosX = 12
        numOrdenPosX = 106
        fechaPosX = 183
        clientePosX = 389
        montoPosX = 578
        pagoPosX = 810
        tipoPosX = 694
    End Sub

    ' metodo que se encarga de llamar a los metodos para mostrar las cajas de texto
    Public Sub mostrarCajasTexto(pos As Integer)
        mostrarCajasTextoNumFactura(pos)
        mostrarCajasTextoNumOrden(pos)
        mostrarCajasTextoFecha(pos)
        mostrarCajasTextoCliente(pos)

        mostrarCajasTextoMontoFactura(pos)

        mostrarCajasTextoTipo(pos)
        mostrarcomboPagoFactura(pos)


    End Sub

    ' metodo que se encarga de mostrar la informacion de la fecha en que se realizaron los pagos de las facturas
    Public Sub mostrarCajasTextoNumFactura(pos As Integer)
        ' se crean las cajas de texto y sus atributos
        txtNumFactura = New TextBox
        txtNumFactura.Name = (listaFacturas(pos)(0).ToString)
        txtNumFactura.Text = listaFacturas(pos)(0)
        txtNumFactura.ReadOnly = True
        txtNumFactura.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtNumFactura.Location = New Point(numFacturaPosX, numFacturaPosY)
        txtNumFactura.Size() = New System.Drawing.Size(64, 20)
        txtNumFactura.Cursor = System.Windows.Forms.Cursors.Hand
        txtNumFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' se agregan al panel en la pantalla
        pnlfacturas.Controls.Add(txtNumFactura)
        'se aumenta la posicion para la siguiente caja de texto
        numFacturaPosY += 35
    End Sub

    Public Sub mostrarCajasTextoNumOrden(pos As Integer)
        ' se crean las cajas de texto y sus atributos
        txtNumOrden = New TextBox
        txtNumOrden.Name = (listaFacturas(pos)(0).ToString)
        txtNumOrden.Text = listaFacturas(pos)(2)
        txtNumOrden.ReadOnly = True
        txtNumOrden.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtNumOrden.Location = New Point(numOrdenPosX, numOrdenPosY)
        txtNumOrden.Size() = New System.Drawing.Size(53, 20)
        txtNumOrden.Cursor = System.Windows.Forms.Cursors.Hand
        txtNumOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' se agregan al panel en la pantalla
        pnlfacturas.Controls.Add(txtNumOrden)
        'se aumenta la posicion para la siguiente caja de texto
        numOrdenPosY += 35
    End Sub

    ' metodo que se encarga de mostrar la informacion de los proveedores de los pagos de las facturas
    Public Sub mostrarCajasTextoFecha(pos As Integer)
        ' se crean las cajas de texto y sus atributos
        txtFecha = New TextBox
        txtFecha.Name = (listaFacturas(pos)(0).ToString)
        txtFecha.Text = listaFacturas(pos)(1).ToString
        txtFecha.ReadOnly = True
        txtFecha.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtFecha.Location = New Point(fechaPosX, fechaPosY)
        txtFecha.Size() = New System.Drawing.Size(200, 20)
        txtFecha.Cursor = System.Windows.Forms.Cursors.Hand
        txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' se agregan al panel en la pantalla
        pnlfacturas.Controls.Add(txtFecha)
        'se aumenta la posicion para la siguiente caja de texto
        fechaPosY += 35
    End Sub

    ' metodo que se encarga de mostrar la informacion de los tipos de pagos de los pagos de las facturas
    Public Sub mostrarCajasTextoCliente(pos As Integer)
        ' se crean las cajas de texto y sus atributos
        txtCliente = New TextBox
        txtCliente.Name = (listaFacturas(pos)(0).ToString)
        txtCliente.Text = listaFacturas(pos)(4).ToString
        txtCliente.ReadOnly = True
        txtCliente.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtCliente.Location = New Point(clientePosX, clientePosY)
        txtCliente.Size() = New System.Drawing.Size(183, 20)
        txtCliente.Cursor = System.Windows.Forms.Cursors.Hand
        txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' se agregan al panel en la pantalla
        pnlfacturas.Controls.Add(txtCliente)
        'se aumenta la posicion para la siguiente caja de texto
        clientePosY += 35
    End Sub

    ' metodo que se encarga de mostrar la informacion del número de la factura que se pagó
    Public Sub mostrarCajasTextoMontoFactura(pos As Integer)
        ' se crean las cajas de texto y sus atributos
        txtMonto = New TextBox
        txtMonto.Name = (listaFacturas(pos)(0).ToString)
        txtMonto.Text = listaFacturas(pos)(3).ToString
        txtMonto.ReadOnly = True
        txtMonto.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtMonto.Location = New Point(montoPosX, montoPosY)
        txtMonto.Size() = New System.Drawing.Size(110, 20)
        txtMonto.Cursor = System.Windows.Forms.Cursors.Hand
        txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' se agregan al panel en la pantalla
        pnlfacturas.Controls.Add(txtMonto)
        'se aumenta la posicion para la siguiente caja de texto
        montoPosY += 35

    End Sub

    Public Sub mostrarCajasTextoTipo(pos As Integer)
        ' se crean las cajas de texto y sus atributos
        txtTipo = New TextBox
        txtTipo.Name = (listaFacturas(pos)(0).ToString)
        If listaFacturas(pos)(6).ToString = "E" Then
            txtTipo.Text = "Express"
        ElseIf listaFacturas(pos)(6).ToString = "S" Then
            txtTipo.Text = "Salon"
        Else
            txtTipo.Text = "Llevar"
        End If
        txtTipo.ReadOnly = True
        txtTipo.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtTipo.Location = New Point(tipoPosX, tipoPosY)
        txtTipo.Size() = New System.Drawing.Size(110, 20)
        txtTipo.Cursor = System.Windows.Forms.Cursors.Hand
        txtTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' se agregan al panel en la pantalla
        pnlfacturas.Controls.Add(txtTipo)
        'se aumenta la posicion para la siguiente caja de texto
        tipoPosY += 35

    End Sub

    Public Sub mostrarcomboPagoFactura(pos As Integer)
        ' se crean las cajas de texto y sus atributos
        Dim combo As New ComboBox
        combo.Name = (listaFacturas(pos)(0).ToString)
        If listaFacturas(pos)(5).ToString() = "T" Then
            combo.DataSource = {"Tarjeta", "Efectivo"}
        Else
            combo.DataSource = {"Efectivo", "Tarjeta"}
        End If
        combo.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        combo.Location = New Point(pagoPosX, pagoPosY)
        combo.Size() = New System.Drawing.Size(122, 20)
        combo.DropDownStyle = ComboBoxStyle.DropDownList
        ' se agrega a la lista de texbox
        ' se agregan al panel en la pantalla
        pnlfacturas.Controls.Add(combo)
        'se aumenta la posicion para la siguiente caja de texto
        pagoPosY += 35

        AddHandler combo.SelectedIndexChanged, AddressOf ComboBox1_SelectedIndexChanged
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim a = pnlfacturas.Controls.Find(sender.Name, True)
        Dim mensaje As String
        If CType(sender, ComboBox).SelectedValue = "Efectivo" Then
            mensaje = "Desea modificar el tipo de pago de la factura numero " & CType(sender, ComboBox).Name & " a Efectivo"
        Else
            mensaje = "Desea modificar el tipo de pago de la factura numero " & CType(sender, ComboBox).Name & " a Tarjeta"
        End If

        Dim result As Integer = MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then

        ElseIf result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then
            If CType(sender, ComboBox).SelectedValue = "Efectivo" Then
                facturacionDatos.modificarTipoOrden(CType(sender, ComboBox).Name, "E", a(4).Text)
            Else
                facturacionDatos.modificarTipoOrden(CType(sender, ComboBox).Name, "T", a(4).Text)
            End If
            MsgBox("La factura ha sido modificada correctamente")
            asignarPosiciones()

            mostrarFacturas()
        End If


    End Sub

    Private Sub ModificarOrdenesFacturadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class