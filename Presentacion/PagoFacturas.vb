Public Class PagoFactura

    Public listaPagoFacturas As New List(Of FacturaPago)

    Public proveedores As New UsuariosDatos
    Public movimientoCaja As New MovimientoCajaDatos
    Public indexModificar As Integer = 0
    ' variable que indica que se esta modificando una factura por pagar
    Public modificando As Boolean = False
    Public agregar As Boolean = True
    ' instancia al formulario de mensaje para mostrar errores   
    Dim mensaje As New Mensaje

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' se obtiene la lista de todos los proveedores en la base de datos
        Dim listaProveedores As New List(Of Proveedor)
        listaProveedores = proveedores.obtenerProveedores()

        ' datatable para ir agregando los proveedores
        Dim data_table_proveedores As New DataTable
        data_table_proveedores.Columns.Add("Codigo", System.Type.GetType("System.Int32"))
        data_table_proveedores.Columns.Add("Nombre", System.Type.GetType("System.String"))

        ' Se llenan los datos del combo
        Dim i As Int32
        For i = 0 To (listaProveedores.Count - 1)
            cbxProveedor.Items.Add(listaProveedores(i).NombreProveedor)
            Dim data_row_proveedores As DataRow = data_table_proveedores.NewRow
            data_row_proveedores = data_table_proveedores.NewRow
            data_row_proveedores("Codigo") = listaProveedores(i).CodigoProveedor
            data_row_proveedores("Nombre") = listaProveedores(i).NombreProveedor
            data_table_proveedores.Rows.Add(data_row_proveedores)
            cbxProveedor.ValueMember = "Codigo"
            cbxProveedor.DisplayMember = "Nombre"
        Next

        cbxProveedor.DataSource = data_table_proveedores

        ' se colocan los valores de las fechas
        txtFechaActual.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        txtFechaActual.ReadOnly = True
        txtFechaFactura.Text = DateTime.Today.ToString(DateTime.Today.ToString("yyyy/MM/dd"))

    End Sub

    ' metodo que se encarga de validar si el numero de factura y el proveedor a ingresar ya existe en la lista
    ' de facturas a ingresar en el pago. Si retorna un true es porque lo encontró, un false si no lo encuentra
    Private Function validar_existe_factura_pagar(ByVal factura_pago As FacturaPago) As Boolean

        ' valida que hayan facturas ingresadas en la lista. Si no hay retorna
        ' false para dar permiso a ingresar. Sí hay, valida que ya no esté ingresada. 

        If listaPagoFacturas.Count > 0 Then
            ' recorre la lista de facturas por pagar
            For i As Integer = 0 To listaPagoFacturas.Count - 1
                ' se valida el numero de factura y el proveedor a ingresar con el que ya esta ingresado en la lista
                If listaPagoFacturas(i).Cod_proveedorSG = factura_pago.Cod_proveedorSG And listaPagoFacturas(i).Numero_facturaSG = factura_pago.Numero_facturaSG Then
                    ' valida si se está modificando o es la primer inserción
                    If modificando = False Then
                        Return True
                    ElseIf i <> indexModificar Then
                        Return True
                    End If
                End If
            Next
        Else
            Return False
        End If

        Return False

    End Function

    ' metodo que se encarga de mostrar en el segundo form, las cajas de texto
    ' correspondiente a la fecha de la factura que se paga
    Public Sub mostrarCajasTextoFechasPagoFacturas()
        ' se obtiene la ultima posicion en la lista de facturas
        Dim posicion As Integer = listaPagoFacturas.Count - 1

        ' se crean las cajas de texto y sus atributos
        txtFecha = New TextBox
        txtFecha.Name = ("txtFecha" + listaPagoFacturas(posicion).Numero_facturaSG.ToString)
        txtFecha.Text = listaPagoFacturas(posicion).Fecha_facturaSG.ToString
        txtFecha.ReadOnly = True
        txtFecha.Cursor = System.Windows.Forms.Cursors.Hand
        txtFecha.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtFecha.Location = New Point(fechaPosX, fechaPosY)
        txtFecha.Size() = New System.Drawing.Size(124, 28)
        AddHandler txtFecha.Click, AddressOf txtFecha_Click
        ' se agrega a la lista de texbox
        listaCajasTextoFecha.Add(txtFecha)
        ' se agregan al panel en la pantalla
        pnlListaFacturas.Controls.Add(txtFecha)

        'se aumenta la posicion para la siguiente caja de texto
        'Me.fechaPosY += 35

    End Sub

    ' metodo que se encarga de mostrar en el segundo form, las cajas de texto
    ' correspondiente a al núumero de la factura que se paga
    Public Sub mostrarCajasTextoFacturaPagoFacturas()
        ' se obtiene la ultima posicion en la lista de facturas
        Dim posicion As Integer = listaPagoFacturas.Count - 1

        ' se crean las cajas de texto y sus atributos
        txtFactura = New TextBox
        txtFactura.Name = ("txtFactura" + listaPagoFacturas(posicion).Numero_facturaSG.ToString)
        txtFactura.Text = listaPagoFacturas(posicion).Numero_facturaSG.ToString
        txtFactura.ReadOnly = True
        txtFactura.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtFactura.Location = New Point(facturaPosX, facturaPosY)
        txtFactura.Size() = New System.Drawing.Size(101, 28)
        txtFactura.Cursor = System.Windows.Forms.Cursors.Hand
        AddHandler txtFactura.Click, AddressOf txtFactura_Click

        ' se agrega a la lista de texbox
        listaCajasTextoFactura.Add(txtFactura)
        ' se agregan al panel en la pantalla
        pnlListaFacturas.Controls.Add(txtFactura)

        'se aumenta la posicion para la siguiente caja de texto
        'Me.facturaPosY += 35

    End Sub

    ' metodo que se encarga de mostrar en el segundo form, las cajas de texto
    ' correspondiente al proveedor al que se le paga la factura

    Public Sub mostrarCajasTextoProveedorPagoFacturas()
        ' se obtiene la ultima posicion en la lista de facturas
        Dim posicion As Integer = listaPagoFacturas.Count - 1

        ' se crean las cajas de texto y sus atributos
        txtProveedor = New TextBox
        txtProveedor.Name = ("txtProveedor" + listaPagoFacturas(posicion).Numero_facturaSG.ToString)
        txtProveedor.ReadOnly = True
        'Dim index As Integer = cbxProveedor.SelectedValue.FindStringExact(listaPagoFacturas(posicion).Cod_proveedorSG.ToString)
        'cbxProveedor.SelectedIndex = index
        txtProveedor.Text = cbxProveedor.SelectedItem.Row(1) 'listaPagoFacturas(posicion).Cod_proveedorSG.ToString 'cbxProveedor.SelectedText

        txtProveedor.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtProveedor.Location = New Point(proveedorPosX, proveedorPosY)
        txtProveedor.Size() = New System.Drawing.Size(220, 28)
        txtProveedor.Cursor = System.Windows.Forms.Cursors.Hand
        AddHandler txtProveedor.Click, AddressOf txtProveedor_Click

        ' se agrega a la lista de texbox
        listaCajasTextoProveedor.Add(txtProveedor)
        ' se agregan al panel en la pantalla
        pnlListaFacturas.Controls.Add(txtProveedor)

        'se aumenta la posicion para la siguiente caja de texto
        'Me.proveedorPosY += 35

    End Sub

    ' metodo que se encarga de mostrar en el segundo form, las cajas de texto
    ' correspondiente al tipo de pago de la factura que se paga
    Public Function mostrarCajasTextoTipoPagoFacturas()
        ' se obtiene la ultima posicion en la lista de facturas
        Dim posicion As Integer = listaPagoFacturas.Count - 1

        ' se crean las cajas de texto y sus atributos
        txtTipo = New TextBox
        txtTipo.Name = ("txtTipo" + listaPagoFacturas(posicion).Numero_facturaSG.ToString)
        txtTipo.Text = listaPagoFacturas(posicion).TipoSG.ToString
        txtTipo.ReadOnly = True
        txtTipo.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtTipo.Location = New Point(tipoPosX, tipoPosY)
        txtTipo.Size() = New System.Drawing.Size(117, 28)
        txtTipo.Cursor = System.Windows.Forms.Cursors.Hand
        AddHandler txtTipo.Click, AddressOf txtTipo_Click
        ' se agrega a la lista de texbox
        listaCajasTextoTipo.Add(txtTipo)
        ' se agregan al panel en la pantalla
        pnlListaFacturas.Controls.Add(txtTipo)

        'se aumenta la posicion para la siguiente caja de texto
        ' Me.tipoPosY += 35
        Return Nothing
    End Function

    ' metodo que se encarga de ir agregando los botones de eliminar factura de la lista por pagar
    Public Sub mostrarBotonesEliminar()
        ' se obtiene la ultima posicion en la lista de facturas
        Dim posicion As Integer = listaPagoFacturas.Count - 1
        ' se crean las cajas de texto y sus atributos
        btnEliminar = New Button
        btnEliminar.Name = ("btnEliminar" + listaPagoFacturas(posicion).Numero_facturaSG.ToString + listaPagoFacturas(posicion).Cod_proveedorSG.ToString)
        'btnEliminar.BackgroundImage = Global.SunChangSystem.My.Resources.Resources.btnBorrar
        btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        btnEliminar.FlatAppearance.BorderSize = 0
        btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        btnEliminar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        btnEliminar.Image = Global.SunChangSystem.My.Resources.Resources.btnBorrar
        btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        btnEliminar.Location = New Point(botonEliminarPosX, botonEliminarPosY)
        btnEliminar.Size() = New System.Drawing.Size(32, 28)

        'se le asigna el evento
        AddHandler btnEliminar.Click, AddressOf btnEliminar_Click
        btnEliminar.UseVisualStyleBackColor = True

        ' se agrega a la lista de botones
        listaBotones.Add(btnEliminar)
        ' se agregan al panel en la pantalla
        pnlListaFacturas.Controls.Add(btnEliminar)

        'se aumenta la posicion para la siguiente caja de texto
        Me.botonEliminarPosY += 35
    End Sub

    ' metodo que se encarga de mostrar en el primer form los datos de la factura que se va a modificar
    Public Sub mostrarDatosParaModificar(sender As Object, posicionControl As Integer)
        ' recorre la lista de controles
        For i = 0 To listaControles.Count - 1
            ' valida que el control que se envió exista en la lista de los controles
            If (listaControles(i)(posicionControl).Equals(sender)) Then
                ' se actualiza el indice de la factura que se va a actualizar
                indexModificar = i
                ' se muestran los datos de la fsactura que se quiere modificar


                txtConceptoPago.Text = listaPagoFacturas(i).ConceptoSG
                cbxProveedor.SelectedIndex = cbxProveedor.FindStringExact(listaControles(i)(3).Text)
                'cbxTipoPago.SelectedItem = 4
                txtFechaFactura.Text = listaPagoFacturas(i).Fecha_facturaSG.ToString
                txtNumeroFactura.Text = listaPagoFacturas(i).Numero_facturaSG
                txtMontoPago.Text = listaPagoFacturas(i).Monto_facturaSG
                'cbxElementoPago.SelectedItem = 4
                txtObservaciones.Text = listaPagoFacturas(i).ObservacionesSG

                ' se actualiza la variable que indica que esta modificando los valores de una factura
                modificando = True

                Exit For
            End If
        Next
    End Sub


    ' **********************************************************************
    ' *                         EVENTOS                                    *
    ' **********************************************************************

    Private Sub txtFecha_Click(sender As Object, e As EventArgs)
        mostrarDatosParaModificar(sender, 1)
    End Sub


    Private Sub txtFactura_Click(sender As Object, e As EventArgs)
        mostrarDatosParaModificar(sender, 2)
    End Sub


    Private Sub txtProveedor_Click(sender As Object, e As EventArgs)
        mostrarDatosParaModificar(sender, 3)
    End Sub


    Private Sub txtTipo_Click(sender As Object, e As EventArgs)
        mostrarDatosParaModificar(sender, 4)
    End Sub


    Private Sub btnEliminar_Click(sender As Object, e As EventArgs)

        'Dim nombre_boton() As String
        'nombre_boton = CType(sender, Button).Name.Split("-")
        'Dim numero_factura_borrar As String = nombre_boton(1)

        For i = 0 To listaControles.Count - 1
            If (listaControles(i)(0).Equals(CType(sender, Button))) Then
                Dim controles() As Object = listaControles(i)



                pnlListaFacturas.Controls.Remove(listaControles(i)(0))
                pnlListaFacturas.Controls.Remove(listaControles(i)(1))
                pnlListaFacturas.Controls.Remove(listaControles(i)(2))
                pnlListaFacturas.Controls.Remove(listaControles(i)(3))
                pnlListaFacturas.Controls.Remove(listaControles(i)(4))

                For j As Integer = i To listaControles.Count - 1
                    listaControles(j)(0).Location = New System.Drawing.Point((listaControles(j)(0).Location.X), (listaControles(j)(0).Location.Y - 35))
                    listaControles(j)(1).Location = New System.Drawing.Point((listaControles(j)(1).Location.X), (listaControles(j)(1).Location.Y - 35))
                    listaControles(j)(2).Location = New System.Drawing.Point((listaControles(j)(2).Location.X), (listaControles(j)(2).Location.Y - 35))
                    listaControles(j)(3).Location = New System.Drawing.Point((listaControles(j)(3).Location.X), (listaControles(j)(3).Location.Y - 35))
                    listaControles(j)(4).Location = New System.Drawing.Point((listaControles(j)(4).Location.X), (listaControles(j)(4).Location.Y - 35))
                Next

                listaPagoFacturas.RemoveAt(i)
                listaControles.RemoveAt(i)

                Exit For
            End If
        Next
    End Sub


    Private Sub btnHistorico_Click(sender As Object, e As EventArgs) Handles btnHistorico.Click
        Dim historicoFacturas As New HistoricoFacturas
        historicoFacturas.ShowDialog()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' se coloca  la variable que indica si se puede agregar la factura en true
        agregar = True

        Try
            ' instancia del  objeto
            Dim factura_pago As New FacturaPago
            ' se agrega el codigo dekl usuario a realizar el pago
            factura_pago.Cod_UsuarioSG = InicioSesion.session.EmpleadoSG.Cod_usuarioSG

            ' se obtienen los datos del pago de las facturas
            factura_pago.ConceptoSG = txtConceptoPago.Text

            factura_pago.ObservacionesSG = txtObservaciones.Text

            Try
                factura_pago.Fecha_facturaSG = txtFechaFactura.Text

                factura_pago.Fecha_pagoSG = txtFechaActual.Text

                Try
                    factura_pago.Cod_proveedorSG = CDbl(cbxProveedor.SelectedValue)

                    Try
                        ' valida que se haya seleccionado algun tipo de pago
                        If Not cbxTipoPago.SelectedItem = "" Then
                            factura_pago.TipoSG = cbxTipoPago.SelectedItem
                        Else
                            mensaje.lblMensaje.Text = "Seleccione el tipo de pago"
                            mensaje.ShowDialog()
                            agregar = False
                        End If

                        Try
                            factura_pago.Numero_facturaSG = CDbl(txtNumeroFactura.Text)

                            Try
                                factura_pago.Monto_facturaSG = CDbl(txtMontoPago.Text)

                                Try
                                    ' valida que se haya seleccionado algun elemento de pago
                                    If Not cbxElementoPago.SelectedItem = "" Then
                                        factura_pago.ElementoSG = cbxElementoPago.SelectedItem
                                    Else
                                        agregar = False
                                        mensaje.lblMensaje.Text = "Seleccione el elemento de pago"
                                        mensaje.ShowDialog()
                                    End If
                                    ' valida si se puede agregar la factura por pagar
                                    If agregar Then
                                        'valida que no se haya ingresado la misma factura para el mismo proveedor
                                        If validar_existe_factura_pagar(factura_pago) Then
                                            mensaje.lblMensaje.Text = "Ya se ingresó la factura: " + factura_pago.Numero_facturaSG.ToString + " para este proveedor."
                                            mensaje.ShowDialog()
                                        Else

                                            ' valida si se esta modificando alguna actura o si se va a insertar
                                            If modificando Then

                                                listaPagoFacturas(indexModificar) = factura_pago

                                                ' se le cambia el nombre al boton de eliminar
                                                listaControles(indexModificar)(0).Name = ("btnEliminar" + listaPagoFacturas(indexModificar).Numero_facturaSG.ToString + listaPagoFacturas(indexModificar).Cod_proveedorSG.ToString)
                                                listaControles(indexModificar)(1).Text = factura_pago.Fecha_facturaSG
                                                listaControles(indexModificar)(2).Text = factura_pago.Numero_facturaSG
                                                listaControles(indexModificar)(3).Text = cbxProveedor.SelectedItem.Row(1)
                                                listaControles(indexModificar)(4).Text = factura_pago.TipoSG

                                                ' coloca la variable que indica que ya no esta modificando
                                                modificando = False
                                                ' coloca la variable para indicar que ya se puede agregar la factura
                                                agregar = True

                                            Else
                                                ' agrega a la lista de facturas a pagar
                                                listaPagoFacturas.Add(factura_pago)
                                                ' coloca la variable para indicar que ya se puede agregar la factura
                                                agregar = True

                                                'posiciones iniciales 
                                                If listaControles.Count > 0 Then
                                                    ' boton de eliminar factura de la lista
                                                    botonEliminarPosX = listaControles(listaControles.Count - 1)(0).Location.X
                                                    botonEliminarPosY = listaControles(listaControles.Count - 1)(0).Location.Y + 35
                                                    ' fecha
                                                    fechaPosX = listaControles(listaControles.Count - 1)(1).Location.X
                                                    fechaPosY = listaControles(listaControles.Count - 1)(1).Location.Y + 35
                                                    ' factura
                                                    facturaPosX = listaControles(listaControles.Count - 1)(2).Location.X
                                                    facturaPosY = listaControles(listaControles.Count - 1)(2).Location.Y + 35
                                                    'proveedor
                                                    proveedorPosX = listaControles(listaControles.Count - 1)(3).Location.X
                                                    proveedorPosY = listaControles(listaControles.Count - 1)(3).Location.Y + 35
                                                    'tipo
                                                    tipoPosX = listaControles(listaControles.Count - 1)(4).Location.X
                                                    tipoPosY = listaControles(listaControles.Count - 1)(4).Location.Y + 35

                                                Else
                                                    ' fecha
                                                    fechaPosX = 66
                                                    fechaPosY = 84
                                                    ' factura
                                                    facturaPosX = 195
                                                    facturaPosY = 84
                                                    'proveedor
                                                    proveedorPosX = 300
                                                    proveedorPosY = 84
                                                    'tipo
                                                    tipoPosX = 523
                                                    tipoPosY = 84
                                                    ' boton de eliminar factura de la lista
                                                    botonEliminarPosX = 27
                                                    botonEliminarPosY = 84
                                                End If


                                                ' llama a los metodos que se encargan de mostrar los valores de la lista de facturas a tramitar
                                                mostrarBotonesEliminar()
                                                mostrarCajasTextoFechasPagoFacturas()
                                                mostrarCajasTextoFacturaPagoFacturas()
                                                mostrarCajasTextoProveedorPagoFacturas()
                                                mostrarCajasTextoTipoPagoFacturas()

                                                '********************************************
                                                Dim controles() As Object = {btnEliminar, txtFecha, txtFactura, txtProveedor, txtTipo}

                                                listaControles.Add(controles)

                                                ' se limpian los espacios del formulario
                                                txtConceptoPago.Text = ""
                                                txtNumeroFactura.Text = ""
                                                txtMontoPago.Text = ""
                                                txtObservaciones.Text = ""

                                            End If
                                        End If
                                    End If
                                Catch ex As Exception
                                    mensaje.lblMensaje.Text = "Debe de seleccionar el elemento de pago"
                                    mensaje.ShowDialog()
                                End Try
                            Catch ex As Exception
                                mensaje.lblMensaje.Text = "Debe de ingresar el monto de la factura a pagar"
                                mensaje.ShowDialog()
                            End Try
                        Catch ex As Exception
                            mensaje.lblMensaje.Text = "Debe de ingresar el número de factura"
                            mensaje.ShowDialog()
                        End Try
                    Catch ex As Exception
                        mensaje.lblMensaje.Text = "Error seleccionando el tipo de pago"
                        mensaje.ShowDialog()
                    End Try
                Catch ex As InvalidCastException
                    mensaje.lblMensaje.Text = "Error seleccionando el proveedor"
                    mensaje.ShowDialog()
                End Try
            Catch ex As InvalidCastException
                mensaje.lblMensaje.Text = "Formato de la fecha de pago incorrecta"
                mensaje.ShowDialog()
            End Try
        Catch ex As InvalidCastException
            mensaje.lblMensaje.Text = ex.Message
            mensaje.ShowDialog()
        End Try

        txtConceptoPago.Text = ""
        txtNumeroFactura.Text = ""
        txtMontoPago.Text = ""
        txtObservaciones.Text = ""
    End Sub

    Private Sub btnAlmacenar_Click(sender As Object, e As EventArgs) Handles btnAlmacenar.Click
        If movimientoCaja.almacenarPagoFacturaProveedor(listaPagoFacturas) Then
            For i As Integer = 0 To listaPagoFacturas.Count - 1
                For j As Integer = 0 To listaControles(i).Length - 1
                    pnlListaFacturas.Controls.Remove(listaControles(i)(j))
                Next
            Next

            listaPagoFacturas.Clear()
            listaControles.Clear()
            mensaje.tipoMensaje("success")
            mensaje.lblMensaje.Text = "Facturas ingresadas correctamente"
            mensaje.ShowDialog()
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub txtNumeroFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroFactura.KeyPress
        ' valida que sea un digito
        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtMontoPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoPago.KeyPress
        ' valida que sea un digito
        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim eliminarFactura As New EliminarFacturaProveedor
        eliminarFactura.ShowDialog()
    End Sub
End Class