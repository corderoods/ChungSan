Public Class Anular
    Dim listaFacturas As List(Of Factura)
    Dim facturas As New FacturacionDatos
    Dim ordenDatos As New OrdenDatos
    Dim empleadoDatos As New EmpleadoDatos
    Dim productoDatos As New ProductoDatos
    Dim facturaActiva As Integer = 0


    Public Sub New()
        InitializeComponent()

    End Sub

    Private Sub Anular_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrarFacturas()
    End Sub

    Private Sub mostrarFacturas()

        pnlFacturas.Controls.Clear()
        pnlProductoFactura.Controls.Clear()
        lblCajero.Text = ""
        lblNumFactura.Text = ""
        lblFecha.Text = ""
        lblTotal.Text = ""
        lblMesa.Text = ""
        lblCliente.Text = ""
        lblTextSalonero.Text = "Salonero: "
        lblSalonero.Text = ""

        listaFacturas = facturas.obtenerFacturasAnular(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)

        Me.NumFactPosX = 26
        Me.NumFactPosY = 15
        Me.montoFacturaPosX = 120
        Me.montoFacturaPosY = 15

        Me.BotonAnularFactPosX = 210
        Me.BotonAnularFactPosY = 40

        For i As Integer = 0 To listaFacturas.Count - 1

            ' se crean las cajas de texto y sus atributos
            lblNumeroFactura = New Label
            lblNumeroFactura.AutoSize = True
            lblNumeroFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            lblNumeroFactura.ForeColor = System.Drawing.Color.White
            lblNumeroFactura.Name = (listaFacturas(i).NumFactura.ToString)
            lblNumeroFactura.Text = listaFacturas(i).NumFactura.ToString
            lblNumeroFactura.Cursor = System.Windows.Forms.Cursors.Hand
            lblNumeroFactura.Location = New Point(NumFactPosX, NumFactPosY)
            'lblNumeroFactura.Size() = New System.Drawing.Size(124, 28)
            AddHandler lblNumeroFactura.Click, AddressOf lblNumeroFactura_Click
            ' se agrega a la lista de texbox
            listaEtiquetasNumeroFactura.Add(lblNumeroFactura)
            ' se agregan al panel en la pantalla
            pnlFacturas.Controls.Add(lblNumeroFactura)

            'se aumenta la posicion para la siguiente caja de texto
            Me.NumFactPosY += 35


            ' se crean las cajas de texto y sus atributos
            lblMontoFactura = New Label
            lblMontoFactura.AutoSize = True
            lblMontoFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            lblMontoFactura.ForeColor = System.Drawing.Color.White
            lblMontoFactura.Name = (listaFacturas(i).NumFactura.ToString)
            lblMontoFactura.Text = listaFacturas(i).MontoTotal.ToString("C")
            'lblMontoFactura.Cursor = System.Windows.Forms.Cursors.Hand
            lblMontoFactura.Location = New Point(montoFacturaPosX, montoFacturaPosY)

            ' se agrega a la lista de texbox
            listaEtiquetasMontoFactura.Add(lblMontoFactura)
            ' se agregan al panel en la pantalla
            pnlFacturas.Controls.Add(lblMontoFactura)

            'se aumenta la posicion para la siguiente caja de texto
            Me.montoFacturaPosY += 35
        Next i


    End Sub

    Private Sub lblNumeroFactura_Click(sender As Object, e As EventArgs)

        pnlProductoFactura.Controls.Clear()


        facturaActiva = CType(sender, Label).Name

        Dim factura = facturas.obtenerFacturaPorNumero(CType(sender, Label).Name)
        Dim orden = ordenDatos.obtenerOrdenPorId(factura.NumOrden)
        Dim detalleFactura = facturas.obtenerproductosFacturaPagada(factura.NumFactura)
        Dim cajero = empleadoDatos.obtenerEmpleadoPorCod(orden.CodEmpleado)

        lblCajero.Text = cajero.NombreSG & " " & cajero.Apellido1SG
        lblNumFactura.Text = factura.NumFactura
        lblFecha.Text = factura.FechaFactura
        lblTotal.Text = factura.MontoTotal.ToString("C")
        lblMesa.Text = orden.NumMesa
        lblCliente.Text = orden.NombreCliente_


        If orden.Ubicacion_ = "S" Then
            Dim salonero = empleadoDatos.obtenerEmpleadoPorCod(orden.CodSalonero)
            lblSalonero.Text = salonero.NombreSG
        ElseIf orden.Ubicacion_ = "E" Then
            lblTextSalonero.Text = "Orden Express"

        ElseIf orden.Ubicacion_ = "L" Then
            lblTextSalonero.Text = "Orden Llevar"
        End If

        Dim posYEtiqueta = 5, posYBoton = 0

        For Each lineaFactura As FacturaDetalle In detalleFactura
            Dim producto = productoDatos.obtenerProductoPorCod(lineaFactura.CodProducto)
            agregarControlesFactura(lineaFactura.Cantidad_, producto.Nombre_, producto.PrecioVenta, posYEtiqueta)

            'aumenta las posiciones de los controles
            posYEtiqueta = posYEtiqueta + 50
        Next

    End Sub

    Private Sub agregarControlesFactura(cantidad As String, descripcion As String, monto As Integer, posYEtiquetas As Integer)

        Dim montoEtiqueta As Label = New Label
        montoEtiqueta.AutoSize = True
        montoEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        montoEtiqueta.Location = New System.Drawing.Point(380, posYEtiquetas)
        montoEtiqueta.Name = "Label15"
        montoEtiqueta.Size = New System.Drawing.Size(49, 20)
        montoEtiqueta.TabIndex = 35
        montoEtiqueta.Text = (monto * cantidad).ToString("C")

        '
        'Label14
        '
        Dim descripcionEtiqueta As Label = New Label
        'descripcion.AutoSize = True
        descripcionEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        descripcionEtiqueta.Location = New System.Drawing.Point(50, posYEtiquetas)
        descripcionEtiqueta.Name = "Label14"
        descripcionEtiqueta.Size = New System.Drawing.Size(300, 35)
        descripcionEtiqueta.TabIndex = 30
        descripcionEtiqueta.Text = descripcion

        '
        'Label13
        '
        Dim cantidadEtiqueta As Label = New Label
        cantidadEtiqueta.AutoSize = True
        cantidadEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cantidadEtiqueta.Location = New System.Drawing.Point(9, posYEtiquetas)
        cantidadEtiqueta.Name = "Label13"
        cantidadEtiqueta.Size = New System.Drawing.Size(18, 20)
        cantidadEtiqueta.TabIndex = 29
        cantidadEtiqueta.Text = cantidad
        'agrega al vector los controles

        'agrega al panel los controles
        pnlProductoFactura.Controls.Add(cantidadEtiqueta)
        pnlProductoFactura.Controls.Add(descripcionEtiqueta)
        pnlProductoFactura.Controls.Add(montoEtiqueta)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' se obtiene el numero de la factura

        'instancias
        Dim facturacion As New FacturacionDatos
        Dim mensaje As New Mensaje
        Dim mensaje_confirmacion As New MensajeConfirmacion

        mensaje_confirmacion.lblMensaje.Text = "Desea Anular esta factura"
        mensaje_confirmacion.ShowDialog()

        If mensaje_confirmacion.decision Then
            If facturacion.AnularFactura(facturaActiva) Then
                mensaje.tipoMensaje("Success")
                mensaje.lblMensaje.Text = "Anulada correctamente"
                mensaje.ShowDialog()
            Else
                mensaje.tipoMensaje("error")
                mensaje.lblMensaje.Text = "Factura no anulada"
                mensaje.ShowDialog()
            End If
        Else
            mensaje.tipoMensaje("error")
            mensaje.lblMensaje.Text = "Anulación cancelada por el usuario"
            mensaje.ShowDialog()
        End If
        mostrarFacturas()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        mostrarFacturas()
    End Sub
End Class