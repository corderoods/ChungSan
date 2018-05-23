Imports CrystalDecisions.Shared

Public Class Facturacion
    'establece el numero de orden
    Dim numOrdenFacturar As Integer
    'declara la lista de los productos en la factura
    Dim productosFactura As List(Of Object)
    'declara la lista de los productos en la orden
    Dim productosOrden As List(Of Object)
    'declara la lista de pagos
    Dim pagosFactura As List(Of Pago)
    'declara el total de la factura
    Dim totalFactura As Integer
    'declara el saldo de la factura
    Dim saldoFactura As Integer
    'declara el total del monto que lleva pagado
    Dim totalPagos As Integer
    'declara la ventana de mensaje
    Dim mensaje As Mensaje
    'declara las variables de los pagos
    Dim pagoEfectivo = False, pagoTarjeta = True, pagoUber = False
    'variable de la capa de datos
    Dim facturaDatos As FacturacionDatos
    'declara el objeto de la orden a pagar
    Dim ordenAPagar As Orden
    'declara el objeto parametro para usarlo en la factura
    Dim parametros As Parametros
    'declara el objeto de ordenes para recargar la pagina
    Dim ordenes1 As Ordenes
    ' declara la variable que almacenara el codigo del cliente
    Public Shared cod_cliente As Double = 0
    ' variable que obtendra el valor del monto del descuento
    Dim monto_descuento As Double = 0, monto_express As Double = 0

    Public Sub New(numOrdenTemp As Integer, ByVal ordenes As Ordenes)
        numOrdenFacturar = numOrdenTemp
        Me.ordenes1 = ordenes

        'instancia de la capa de datos
        facturaDatos = New FacturacionDatos
        'llama al metodo que devuelve el objeto de la orden
        ordenAPagar = facturaDatos.obtenerOrdenPorNumero(numOrdenFacturar)

        parametros = facturaDatos.obtenerParametros

        productosFactura = New List(Of Object)
        productosOrden = New List(Of Object)
        pagosFactura = New List(Of Pago)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        txtEfectivo.Text = 0.ToString("C")
        txtExpress.Text = parametros.Express_.ToString("C")
        'txtDescuento.Text = 0.ToString("P")

        mostrarProductosFactura()
        obtenerEncabezadoFactura()

        mensaje = New Mensaje()

        btnAgregarPago.Visible = False

        If ordenAPagar.Ubicacion_ = "S" Then
            cbProforma.Visible = True
        Else
            cbProforma.Visible = False
        End If
    End Sub

    'METODO QUE CARGA LOS PRODUCTOS EN LA FACTURA A PAGAR
    Private Sub mostrarProductosFactura()
        'Instancia de la capa de datos
        Dim facturacionDatos As New FacturacionDatos
        'Define los atributos de las posiciones de los controles
        Dim posYEtiqueta = 5, posYBoton = 0
        'le asigna los valores traidos de la consulta a la lista
        'productosOrden = facturacionDatos.obtenerProductosPorOrden(numOrdenFacturar)
        Dim productosFacturaTemp = facturacionDatos.obtenerProductosPorOrden(numOrdenFacturar)

        'obtiene los productos que se han pagado
        Dim productosPagados = facturacionDatos.obtenerProductosFacturaDetalle(numOrdenFacturar)

        'verifica si hay productos en la lista de productos pagados de esta orden
        If (productosPagados.Count <> 0) Then
            'si hay productos en la lista de pagados
            'recorre la lista de los productos de la orden para compararla con los productos pagados
            For Each productoFactura In productosFacturaTemp
                Dim existe = False
                'recorre la lista de productos pagados y verifica si ese producto ya se pago
                For Each productoPagado In productosPagados
                    If (productoFactura(1).CodProducto = productoPagado.CodProducto) Then
                        existe = True
                    End If
                Next
                'si ese producto no se ha pagado lo agrega a la lista de productos disponibles 
                'de la orden
                If (existe = False) Then
                    productosFactura.Add(productoFactura)
                Else
                    'contador que lleva la cantidad de producto que se ha pagado
                    Dim cantidadProducto = 0
                    For Each productoPagado In productosPagados
                        'veerifica que sea el producto y aumenta la cantidad de producto en el contador
                        If (productoFactura(1).CodProducto = productoPagado.CodProducto And productoFactura(0)) Then
                            cantidadProducto = cantidadProducto + productoPagado.Cantidad_
                        End If
                    Next
                    'valida si se no ha pagado la totalidad de productos, y lo agrega a la lista
                    'la cantidad de productos disponibles a pagar
                    If (productoFactura(0) > cantidadProducto) Then
                        Dim productoTemporal = {(productoFactura(0) - cantidadProducto), productoFactura(1), productoFactura(2)}
                        productosFactura.Add(productoTemporal)
                    End If
                End If
            Next
        Else
            productosFactura = productosFacturaTemp
        End If

        If (productosFactura.Count = 0) Then
            'marca la orden como cancelada en su totalidad
            facturacionDatos.modificaIndicadorPagoOrden(numOrdenFacturar, 1)
            ordenes1.mostrarOrdenes(0)
            Me.Dispose()
        Else
            'Recorre el resultado para crear los controles
            For Each lineaFactura As Object In productosFactura
                agregarControlesFactura(lineaFactura(1).CodProducto, lineaFactura(0), lineaFactura(1).Nombre_,
                    (lineaFactura(1).PrecioVenta * lineaFactura(0)), posYEtiqueta, posYBoton)

                'aumenta las posiciones de los controles
                posYEtiqueta = posYEtiqueta + 50
                posYBoton = posYBoton + 50
            Next
            calcularTotal()
        End If
    End Sub

    'METODO QUE CARGA LOS PRODUCTOS DE LA ORDEN
    Public Sub mostrarProductosOrden()
        'instancia de la capa de datos
        Dim facturacionDatos As New FacturacionDatos
        'elimina todos los registros de la orden en proceso para volverlos a cargar
        'limpia los objetos
        productosOrden.Clear()
        'limpia los controles
        For Each control In detalleFacturaControl
            pnlProductoFactura.Controls.Remove(control(0))
            pnlProductoFactura.Controls.Remove(control(1))
            pnlProductoFactura.Controls.Remove(control(2))
            pnlProductoFactura.Controls.Remove(control(3))
        Next
        'limpia los productos de la factura
        detalleFacturaControl.Clear()

        'elimina todos los registros de la factura en proceso
        'limpia los objetos
        productosFactura.Clear()
        'limpia los controles
        detalleFacturaControl.Clear()

        'define las posiciones de los controles
        Dim posYCantidad = 4, posYDescripcion = 3, posYAGregar = 1

        'le asigna los valores traidos de la consulta a la lista
        'productosOrden = facturacionDatos.obtenerProductosPorOrden(numOrdenFacturar)
        Dim productosOrdenTemp = facturacionDatos.obtenerProductosPorOrden(numOrdenFacturar)

        'obtiene los productos que se han pagado
        Dim productosPagados = facturacionDatos.obtenerProductosFacturaDetalle(numOrdenFacturar)

        'verifica si hay productos en la lista de productos pagados de esta orden
        If (productosPagados.Count <> 0) Then
            'si hay productos en la lista de pagados
            'recorre la lista de los productos de la orden para compararla con los productos pagados
            For Each productoOrden In productosOrdenTemp
                Dim existe = False
                'recorre la lista de productos pagados y verifica si ese producto ya se pago
                For Each productoPagado In productosPagados
                    If (productoOrden(1).CodProducto = productoPagado.CodProducto) Then
                        existe = True
                    End If
                Next
                'si ese producto no se ha pagado lo agrega a la lista de productos disponibles 
                'de la orden
                If (existe = False) Then
                    productosOrden.Add(productoOrden)
                Else
                    'contador que lleva la cantidad de producto que se ha pagado
                    Dim cantidadProducto = 0
                    For Each productoPagado In productosPagados
                        'veerifica que sea el producto y aumenta la cantidad de producto en el contador
                        If (productoOrden(1).CodProducto = productoPagado.CodProducto And productoOrden(0)) Then
                            cantidadProducto = cantidadProducto + productoPagado.Cantidad_
                        End If
                    Next
                    'valida si se no ha pagado la totalidad de productos, y lo agrega a la lista
                    'la cantidad de productos disponibles a pagar
                    If (productoOrden(0) > cantidadProducto) Then
                        Dim productoTemporal = {(productoOrden(0) - cantidadProducto), productoOrden(1), productoOrden(2)}
                        productosOrden.Add(productoTemporal)
                    End If
                End If
            Next
        Else
            productosOrden = productosOrdenTemp
        End If

        'recorre los registros para agregarlos a los controles
        For Each lineaOrden As Object In productosOrden
            'genera las posiciones de cada control a agregar
            Dim etiquetasYBotonY = generarPosicionYOrden()
            'llama al metodo que agrega los controles
            agregarControlesOrden(lineaOrden(1).CodProducto, lineaOrden(0), lineaOrden(1).Nombre_, etiquetasYBotonY(0), etiquetasYBotonY(1), etiquetasYBotonY(2))
        Next

    End Sub

    'METODO QUE AGREGA UN PRODUCTO A LA FACTURA
    Public Sub agregarProductoFactura(ByVal sender As Object, ByVal e As EventArgs)
        'Captura el nombre del boton que lanzo el evento, y que sirve como ID del producto
        Dim button = DirectCast(sender, Button)
        Dim id = button.Name
        'Se declara la cantidad de productos a agregar a la factura
        Dim cantidad As Integer = Nothing
        'variable que guarda la posicion del control en la lista
        Dim posControl As Integer = Nothing
        'obtiene el valor de la cantidad de productos a agregar
        For i As Integer = 0 To detalleProductoControl.Count - 1
            If (detalleProductoControl(i)(2).Name = id) Then
                cantidad = detalleProductoControl(i)(0).Value
                posControl = i
            End If
        Next
        'realiza la busqueda del producto en la orden
        Dim lineaOrden = obtenerProductoYOrden(id, productosOrden)
        'llama al metodo que insertar un producto en la lista de factura
        insertarProductoListaFactura(cantidad, lineaOrden(1), lineaOrden(2))
        'llama al metodo que elimina un producto en la lista de orden
        eliminarProductoListaOrden(cantidad, lineaOrden(1), lineaOrden(2))

        'imprimirLista(productosOrden)
        'imprimirLista(productosFactura)
        calcularTotal()
    End Sub

    'METODO QUE ELIMINA PRODUCTO DE LA FACTURA Y LO AGREGA A LA LISTA DE PRODUCTOS DE LA ORDEN
    Public Sub eliminarProductoFactura(ByVal sender As Object, ByVal e As EventArgs)
        'Captura el nombre del boton que lanzo el evento, y que sirve como ID del producto
        Dim button = DirectCast(sender, Button)
        Dim id = button.Name
        'posicion del elemento a eliminar
        Dim posicionEliminar As Integer
        'recorre los registros para capturar la posicion a eliminar
        For i As Integer = 0 To productosFactura.Count - 1
            If (productosFactura(i)(1).CodProducto = id) Then
                posicionEliminar = i
            End If
        Next

        insertarProductoListaOrden(productosFactura(posicionEliminar)(0),
            productosFactura(posicionEliminar)(1), productosFactura(posicionEliminar)(2))

        eliminarProductoListaFactura(productosFactura(posicionEliminar)(0), productosFactura(posicionEliminar)(1), productosFactura(posicionEliminar)(2))
        calcularTotal()
    End Sub

    'METODO QUE DIVIDE LA FACTURA (CARGA LOS PRODUCTOS EN LA LISTA PARA AGREGARLOS A LA FACTURA)
    Private Sub btnDividirFactura_Click(sender As Object, e As EventArgs) Handles btnDividirFactura.Click
        'limpia del panel todos los controles de los productos de la orden
        For Each control In detalleProductoControl
            pnlProductos.Controls.Remove(control(0))
            pnlProductos.Controls.Remove(control(1))
            pnlProductos.Controls.Remove(control(2))
        Next
        'limpia las listas de los productos de la orden
        'limpia la lista de controles
        detalleProductoControl.Clear()
        'limpia la lista de los objetos
        productosOrden.Clear()

        'pnlProductos.Visible = True
        mostrarProductosOrden()

        'limpia los controles de la factura
        For Each control In detalleFacturaControl
            pnlProductoFactura.Controls.Remove(control(0))
            pnlProductoFactura.Controls.Remove(control(1))
            pnlProductoFactura.Controls.Remove(control(2))
            pnlProductoFactura.Controls.Remove(control(3))
        Next
        'limpia los productos de la factura
        detalleFacturaControl.Clear()
        productosFactura.Clear()

        calcularTotal()

        limpiarPagos()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        pnlProductos.Visible = True
        pnlProductoFactura.Visible = False
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        mostrarProductosFactura()
    End Sub

    Private Sub btnAgregarPago_Click(sender As Object, e As EventArgs) Handles btnAgregarPago.Click
        agregarPago()

        If (pagoEfectivo = True) Then
            pagoEfectivo = False
            pnlEfectivo.Visible = False
            txtMontoPagar.Text = 0.ToString("C")
            txtEfectivo.Text = 0.ToString("C")
        ElseIf (pagoTarjeta = True) Then
            pagoTarjeta = False
            pnlTarjeta.Visible = False
            txtTarjeta.Text = 0.ToString("C")
        ElseIf (pagoUber = True) Then
            pagoUber = False
            pnlEfectivo.Visible = False
            pnlTarjeta.Visible = False
            txtUber.Text = 0.ToString("C")

        End If
        btnAgregarPago.Visible = False
    End Sub

    'METODO QUE AGREGA LOS CONTROLES A LA FACTURA
    Private Sub agregarControlesFactura(codProducto As Integer, cantidad As String, descripcion As String, monto As Integer, posYEtiquetas As Integer, posYBoton As Integer)
        Dim montoEtiqueta As Label = New Label
        montoEtiqueta.AutoSize = True
        montoEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        montoEtiqueta.Location = New System.Drawing.Point(285, posYEtiquetas)
        montoEtiqueta.Name = "Label15"
        montoEtiqueta.Size = New System.Drawing.Size(49, 20)
        montoEtiqueta.TabIndex = 35
        montoEtiqueta.Text = monto.ToString("C")
        '
        'Button9
        '
        Dim eliminarBoton As Button = New Button
        'eliminarBoton.AutoSize = True
        eliminarBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        eliminarBoton.FlatAppearance.BorderSize = 0
        eliminarBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        eliminarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        eliminarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        eliminarBoton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        eliminarBoton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        eliminarBoton.Image = Global.SunChangSystem.My.Resources.Resources.btnEliminarPeq
        eliminarBoton.Location = New System.Drawing.Point(370, posYBoton)
        eliminarBoton.Name = codProducto
        eliminarBoton.Size = New System.Drawing.Size(70, 38)
        eliminarBoton.TabIndex = 34
        eliminarBoton.UseVisualStyleBackColor = True
        AddHandler eliminarBoton.Click, AddressOf eliminarProductoFactura
        '
        'Label14
        '
        Dim descripcionEtiqueta As Label = New Label
        'descripcion.AutoSize = True
        descripcionEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        descripcionEtiqueta.Location = New System.Drawing.Point(50, posYEtiquetas)
        descripcionEtiqueta.Name = "Label14"
        descripcionEtiqueta.Size = New System.Drawing.Size(235, 35)
        descripcionEtiqueta.TabIndex = 30
        descripcionEtiqueta.Text = descripcion
        'descripcionEtiqueta.Height = ( Height * 7) / 100
        'descripcionEtiqueta.Width = ( Width * 16) / 100
        'descripcionEtiqueta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
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
        Dim linea() As Object = {cantidadEtiqueta, descripcionEtiqueta, montoEtiqueta, eliminarBoton}
        'agrega a la lista el vector de controles
        detalleFacturaControl.Add(linea)
        'agrega al panel los controles
        pnlProductoFactura.Controls.Add(cantidadEtiqueta)
        pnlProductoFactura.Controls.Add(descripcionEtiqueta)
        pnlProductoFactura.Controls.Add(montoEtiqueta)
        pnlProductoFactura.Controls.Add(eliminarBoton)
    End Sub

    'METODO QUE AGREGA LOS CONTROLES A LA ORDEN
    Private Sub agregarControlesOrden(codProducto As Integer, cantidad As String, descripcion As String,
            posYCantidad As Integer, posYDescripcion As Integer, posYBoton As Integer)

        'NumericUpDown1
        '
        Dim cantidadNumeric As NumericUpDown
        cantidadNumeric = New NumericUpDown
        cantidadNumeric.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cantidadNumeric.Location = New System.Drawing.Point(3, posYCantidad)
        cantidadNumeric.Name = codProducto
        cantidadNumeric.Size = New System.Drawing.Size(45, 35)
        cantidadNumeric.TabIndex = 0
        cantidadNumeric.Value = cantidad
        cantidadNumeric.Minimum = 1
        cantidadNumeric.Maximum = cantidad

        'Label54
        '
        Dim nombre As Label
        nombre = New Label
        'nombre.AutoSize = True
        nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        nombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        nombre.Location = New System.Drawing.Point(50, posYDescripcion)
        nombre.Name = codProducto
        nombre.Size = New System.Drawing.Size(200, 20)
        nombre.TabIndex = 12
        nombre.Text = descripcion
        nombre.Height = (Height * 7) / 100
        nombre.Width = (Width * 15) / 100
        'Button8
        '
        Dim agregar As Button
        agregar = New Button
        agregar.AutoSize = True
        agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        agregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        agregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        agregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        agregar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        agregar.Image = Global.SunChangSystem.My.Resources.Resources.btnAgregar1
        agregar.Location = New System.Drawing.Point(260, posYBoton)
        agregar.Name = codProducto
        agregar.Size = New System.Drawing.Size(101, 43)
        agregar.TabIndex = 13
        agregar.UseVisualStyleBackColor = True

        AddHandler agregar.Click, AddressOf agregarProductoFactura

        'agrega al vector los controles   
        Dim detalle() As Object = {cantidadNumeric, nombre, agregar}
        'agrega el vector a la lista de controles
        detalleProductoControl.Add(detalle)
        'agrega los controles al panel
        pnlProductos.Controls.Add(cantidadNumeric)
        pnlProductos.Controls.Add(nombre)
        pnlProductos.Controls.Add(agregar)

    End Sub

    'METODO QUE DEVUELVE UNA LINEA DE LA ORDEN PARA AGREGARLA A LA FACTURA
    Public Function obtenerProductoYOrden(id As Integer, lista As List(Of Object)) As Object()
        Dim resultado() As Object = Nothing
        'Declara los objetos de producto y orden para agregarlos a la factura
        Dim productoAgregar As Producto
        Dim ordenAgregar As OrdenTemporal
        'Recorre los productos de la orden
        For Each detalle In lista
            'busca el producto y orden dentro de la lista de objetos
            If (StrComp(id, detalle(1).CodProducto) = 0) Then
                productoAgregar = detalle(1)
                ordenAgregar = detalle(2)
                resultado = {detalle(0), productoAgregar, ordenAgregar}
            End If
        Next
        Return resultado
    End Function

    'METODO ENCARGADO DE GENERAR UNA POSICION ACTUALIZADA A LOS CONTROLES
    Public Function generarPosicionYFactura() As Integer()
        If (detalleFacturaControl.Count = 0) Then
            Return {5, 0}
        Else
            Dim ultimoControl = detalleFacturaControl(detalleFacturaControl.Count - 1)
            Dim posYEtiqueta = ultimoControl(0).Location.Y + 50
            Dim posYBoton = ultimoControl(3).Location.Y + 50
            Return {posYEtiqueta, posYBoton}
        End If
    End Function

    'METODO ENCARGADO DE GENERAR UNA POSICION ACTUALIZADA A LOS CONTROLES
    Public Function generarPosicionYOrden() As Integer()
        If (detalleProductoControl.Count = 0) Then
            Return {4, 3, 1}
        Else
            Dim ultimoControl = detalleProductoControl(detalleProductoControl.Count - 1)
            Dim posYCantidad = ultimoControl(0).Location.Y + 50
            Dim posYDescripcion = ultimoControl(1).Location.Y + 50
            Dim posYBoton = ultimoControl(2).Location.Y + 50
            Return {posYCantidad, posYDescripcion, posYBoton}
        End If
    End Function

    'METODO ENCARGADO DE GENERAR UNA POSICION ACTUALIZADA A LOS CONTROLES
    Public Function generarPosicionYPago() As Integer()
        If (pagosFacturaControl.Count = 0) Then
            Return {9, -3}
        Else
            Dim ultimoControl = pagosFacturaControl(pagosFacturaControl.Count - 1)
            Dim posYEtiqueta = ultimoControl(0).Location.Y + 50
            Dim posYBoton = ultimoControl(4).Location.Y + 50
            Return {posYEtiqueta, posYBoton}
        End If
    End Function

    'METODO QUE AGREGA O AUMENTA LA CANTIDAD DE PRODUCTOS EN UNA LISTA
    Public Sub insertarProductoListaFactura(cantidad As Integer, producto As Producto, orden As OrdenTemporal)
        'llama al metodo que retorna el resultado de la busqueda o nothing si no lo encuentra
        Dim lineaFactura = obtenerProductoYOrden(producto.CodProducto, productosFactura)
        'si no se enuentra en la lista entonces se agrega
        If (lineaFactura Is Nothing) Then
            'se agrega a la lista de objetos
            Dim detalleFactura = {cantidad, producto, orden}
            productosFactura.Add(detalleFactura)
            'se agrega a la lista de controles
            Dim posicionesY = generarPosicionYFactura()
            agregarControlesFactura(producto.CodProducto, cantidad, producto.Nombre_,
                (producto.PrecioVenta * cantidad), posicionesY(0), posicionesY(1))
        Else
            'se modifica la lista
            For i As Integer = 0 To productosFactura.Count - 1
                If (productosFactura(i)(1).CodProducto = producto.CodProducto) Then
                    'disminuye la cantidad de productos en la lista
                    productosFactura(i)(0) = lineaFactura(0) + cantidad
                    'actualiza el control del producto de la factura
                    detalleFacturaControl(i)(0).Text = detalleFacturaControl(i)(0).Text + cantidad
                    'Monto de la linea de la factura
                    Dim monto As Integer = detalleFacturaControl(i)(2).Text + (productosFactura(i)(1).PrecioVenta * cantidad)
                    detalleFacturaControl(i)(2).Text = monto.ToString("C")
                End If
            Next
        End If
    End Sub

    'METODO QUE ELIMINA O DISMINUYE LA CANTIDAD DE PRODUCTOS EN LA LISTA DE FACTURA
    Public Sub eliminarProductoListaFactura(cantidad As Integer, producto As Producto, orden As OrdenTemporal)
        Dim posicionEliminar = -1
        'recorre la lista para obtener la posicion para eliminar de la lista
        For i As Integer = 0 To productosFactura.Count - 1
            If (productosFactura(i)(1).CodProducto = producto.CodProducto) Then
                posicionEliminar = i
            End If
        Next

        'elimina el objeto de la lista
        If (posicionEliminar <> -1) Then
            'elimina el objeto de la lista de productos
            productosFactura.RemoveAt(posicionEliminar)
            'elimina los controles del panel
            pnlProductoFactura.Controls.Remove(detalleFacturaControl(posicionEliminar)(0))
            pnlProductoFactura.Controls.Remove(detalleFacturaControl(posicionEliminar)(1))
            pnlProductoFactura.Controls.Remove(detalleFacturaControl(posicionEliminar)(2))
            pnlProductoFactura.Controls.Remove(detalleFacturaControl(posicionEliminar)(3))
            'actualiza las posiciones de los controles de abajo
            For i As Integer = (posicionEliminar + 1) To detalleFacturaControl.Count - 1
                detalleFacturaControl(i)(0).Location = New System.Drawing.Point(detalleFacturaControl(i)(0).Location.X, detalleFacturaControl(i)(0).Location.Y - 50)
                detalleFacturaControl(i)(1).Location = New System.Drawing.Point(detalleFacturaControl(i)(1).Location.X, detalleFacturaControl(i)(1).Location.Y - 50)
                detalleFacturaControl(i)(2).Location = New System.Drawing.Point(detalleFacturaControl(i)(2).Location.X, detalleFacturaControl(i)(2).Location.Y - 50)
                detalleFacturaControl(i)(3).Location = New System.Drawing.Point(detalleFacturaControl(i)(3).Location.X, detalleFacturaControl(i)(3).Location.Y - 50)
            Next
            'elimina el control de la lista
            detalleFacturaControl.RemoveAt(posicionEliminar)
            'limpia la lista de pagos
            limpiarPagos()
        End If
    End Sub

    'METODO QUE AGREGA PRODUCTO A LA LISTA DE ORDEN
    Public Sub insertarProductoListaOrden(cantidad As Integer, producto As Producto, orden As OrdenTemporal)
        'llama al metodo que retorna el resultado de la busqueda o nothing si no lo encuentra
        Dim lineaFactura = obtenerProductoYOrden(producto.CodProducto, productosOrden)
        'si no se enuentra en la lista entonces se agrega
        If (lineaFactura Is Nothing) Then
            'se agrega a la lista de objetos
            Dim detalleOrden = {cantidad, producto, orden}
            productosOrden.Add(detalleOrden)
            'se agrega a la lista de controles
            Dim posicionesY = generarPosicionYOrden()
            agregarControlesOrden(producto.CodProducto, cantidad, producto.Nombre_,
                posicionesY(0), posicionesY(1), posicionesY(2))
        Else
            'se modifica la lista
            For i As Integer = 0 To productosOrden.Count - 1
                If (productosOrden(i)(1).CodProducto = producto.CodProducto) Then
                    'disminuye la cantidad de productos en la lista
                    productosOrden(i)(0) = lineaFactura(0) + cantidad
                    'actualiza el control del producto de la orden
                    detalleProductoControl(i)(0).Maximum = detalleProductoControl(i)(0).Maximum + cantidad
                    detalleProductoControl(i)(0).Value = detalleProductoControl(i)(0).Maximum
                End If
            Next
        End If
    End Sub

    'METODO QUE ELIMINA O DISMINUYE LA CANTIDAD DE PRODUCTOS EN LA LISTA DE ORDEN
    Public Sub eliminarProductoListaOrden(cantidad As Integer, producto As Producto, orden As OrdenTemporal)
        Dim posicionEliminar = -1
        'recorre la lista para eliminar o disminuir el producto
        For i As Integer = 0 To productosOrden.Count - 1
            If (productosOrden(i)(1).CodProducto = producto.CodProducto) Then
                'si solo va a disminuir la cantidad
                If ((productosOrden(i)(0) - cantidad) > 0) Then
                    productosOrden(i)(0) = productosOrden(i)(0) - cantidad
                    detalleProductoControl(i)(0).Maximum = detalleProductoControl(i)(0).Maximum - cantidad
                    detalleProductoControl(i)(0).Value = detalleProductoControl(i)(0).Maximum
                Else
                    'si va a eliminar el producto guarda la posicion para removerlo de la lista
                    posicionEliminar = i
                End If
            End If
        Next
        'elimina el objeto de la lista
        If (posicionEliminar <> -1) Then
            'elimina el objeto de la lista de productos
            productosOrden.RemoveAt(posicionEliminar)
            'elimina los controles del panel
            pnlProductos.Controls.Remove(detalleProductoControl(posicionEliminar)(0))
            pnlProductos.Controls.Remove(detalleProductoControl(posicionEliminar)(1))
            pnlProductos.Controls.Remove(detalleProductoControl(posicionEliminar)(2))
            'actualiza las posiciones de los controles de abajo
            For i As Integer = posicionEliminar To detalleProductoControl.Count - 1
                detalleProductoControl(i)(0).Location = New System.Drawing.Point(detalleProductoControl(i)(0).Location.X, detalleProductoControl(i)(0).Location.Y - 50)
                detalleProductoControl(i)(1).Location = New System.Drawing.Point(detalleProductoControl(i)(1).Location.X, detalleProductoControl(i)(1).Location.Y - 50)
                detalleProductoControl(i)(2).Location = New System.Drawing.Point(detalleProductoControl(i)(2).Location.X, detalleProductoControl(i)(2).Location.Y - 50)
            Next
            'elimina el control de la lista
            detalleProductoControl.RemoveAt(posicionEliminar)
        End If
    End Sub

    'METODO QUE CALCULA EL SUBTOTAL, IMPUESTO Y TOTAL
    Public Sub calcularTotal()
        'oculta los paneles de las opciones de tipo de orden
        pnlOrdExpress.Visible = False
        pnlOrdSalon.Visible = False
        'variables para calcular el total se inicializan
        Dim subTotal = 0, total = 0, impuesto = 0, servicio = 0, express = 0
        Dim descuento As Double
        'recorre el arreglo del detalle de la factura para obtener el subtotal
        For Each lineaFactura In detalleFacturaControl
            subTotal = subTotal + lineaFactura(2).Text
        Next
        'valida que el texto de descuento no venga vacio, si viene vacio, le pone un 0
        If (txtDescuento.Text.CompareTo("") = 0) Then
            descuento = (Double.Parse(0) / 100)
        Else
            descuento = (Double.Parse(txtDescuento.Text.Trim()) / 100)
        End If

        'calcula el total
        total = subTotal
        total = total - (total * descuento)
        lblDescuento.Text = (subTotal * descuento).ToString("C")

        'verifica de que tipo es el orden para aplicarle impuesto o el express
        If (ordenAPagar.Ubicacion_.CompareTo("S") = 0) Then
            servicio = total * (parametros.PorcImpServ / 100)
            lblImpServicio.Text = servicio.ToString("C")

            pnlOrdSalon.Visible = True
        ElseIf (ordenAPagar.Ubicacion_.CompareTo("E") = 0) Then
            'valida que el texto de descuento no venga vacio, si viene vacio, le pone un 0
            If (txtExpress.Text.CompareTo("") = 0) Then
                txtExpress.Text = 0.ToString("C")
            End If
            Dim valor_express As String = txtExpress.Text.ToString.TrimStart("₡")
            servicio = valor_express.ToString.TrimStart(".")

            pnlOrdExpress.Visible = True
        End If

        'calcula el impuesto de ventas
        impuesto = total * (parametros.PorcImpVtas / 100)
        lblImpVentas.Text = impuesto.ToString("C")
        ' se le suma el impuesto de servicio al total
        total += servicio + impuesto
        'total = total + servicio + express + impuesto
        'pone los valores en las etiquetas
        lblTotal.Text = total.ToString("C")
        lblSubTotal.Text = subTotal.ToString("C")
        ' lblSubtotalDesc.Text = IIf(descuento > 0, (subTotal - (subTotal * descuento)).ToString("C"), 0.ToString("C"))
        lblSubtotalDesc.Text = (subTotal - (subTotal * descuento)).ToString("C")
        ' txtDescuento.Text = descuento.ToString("P")


        'establece el valor de la variable global del total
        totalFactura = total
        'calcula el saldo de la factura
        calcularSaldoFactura()
    End Sub

    'METODO QUE OBTIENE LOS DETALLES DE ENCABEZADO FACTURA
    Public Sub obtenerEncabezadoFactura()
        'Instancia de la clase de datos
        Dim facturacionDatos As New FacturacionDatos
        'hace el llamado al metodo que obtiene el encabezado
        Dim encabezado = facturacionDatos.obtenerEncabezadoFactura(numOrdenFacturar)
        Dim empleados = facturacionDatos.obtenerEmpledosFactura(numOrdenFacturar)
        Dim numFactura = parametros.NumFactura + 1
        lblCajero.Text = InicioSesion.session.EmpleadoSG.NombreSG + " " + InicioSesion.session.EmpleadoSG.Apellido1SG 'empleado.NombreSG & " " & empleado.Apellido1SG

        For Each empleado In empleados
            'If (empleado.Cod_empleadoSG = encabezado(0).CodEmpleado) Then
            '    lblCajero.Text = empleado.NombreSG & " " & empleado.Apellido1SG
            'End If
            If (empleado.Cod_empleadoSG = encabezado(0).CodSalonero) Then
                lblSalonero.Text = empleado.NombreSG & " " & empleado.Apellido1SG
            End If
        Next

        lblNumFactura.Text = numFactura
        txtNombre.Text = encabezado(1).NombreClienteSG
        lblMesa.Text = encabezado(0).NumMesa
        lblNumMesa.Text = encabezado(0).NumMesa
        lblFecha.Text = DateTime.Now.ToString
    End Sub

    'METODO QUE AGREGA PAGOS DE LA FACTURA
    Public Sub agregarPago()
        If (txtTarjeta.Text <> "" Or txtEfectivo.Text <> "" Or txtMontoPagar.Text <> "" Or txtUber.Text <> "") Then
            'declara las variables que conforman el vector de pago            
            Dim efectivo = 0
            Dim tarjeta = 0
            Dim vuelto = 0
            Dim montoAPagar = 0
            Dim totalPagoUnitario = 0
            Dim uber = 0
            Dim pago As New Pago
            'obtiene el numero de pago, recorriendo la lista
            Dim id = pagosFactura.Count + 1

            If (pagoTarjeta = True) Then
                tarjeta = If(txtTarjeta.Text = "", 0, txtTarjeta.Text)
                totalPagoUnitario = tarjeta
                'declara el tipo de pago
                pago.TipoPago = "T"
            ElseIf (pagoUber = True) Then
                uber = If(txtUber.Text = "", 0, txtUber.Text)
                totalPagoUnitario = uber
                'declara el tipo de pago
                pago.TipoPago = "U"
            ElseIf (pagoEfectivo = True) Then
                Try
                    efectivo = If(txtEfectivo.Text = "", 0, txtEfectivo.Text)
                Catch ex As OverflowException

                End Try

                vuelto = 0
                montoAPagar = If(txtMontoPagar.Text = "", totalFactura, txtMontoPagar.Text)
                vuelto = efectivo - montoAPagar
                totalPagoUnitario = efectivo - vuelto
                'declara el tipo de pago
                pago.TipoPago = "E"

            End If

            pago.NumPago = id
            pago.NumFactura = lblNumFactura.Text
            pago.CodEstadoFactura = "A"
            pago.NumOrden = numOrdenFacturar
            pago.Monto_ = totalPagoUnitario
            pago.Vuelto_ = vuelto

            If (validarPagos(tarjeta, efectivo, montoAPagar)) Then
                'hace el llamado al metodo que genera las posiciones de la lista de controles de los pagos
                Dim posYControles = generarPosicionYPago()
                'agrega los controles del pago
                agregarControlesPago(id, pago.TipoPago, pago.Monto_, pago.Vuelto_, posYControles(0), posYControles(1))
                'agrega la informacion del pago en la lista de objetos
                pagosFactura.Add(pago)
                'llama al metodo de calcular el saldo de la factura
                calcularSaldoFactura()
            End If
        Else
            mensaje.tipoMensaje("error")
            mensaje.lblMensaje.Text = "Ingrese datos en el campo de texto"
            mensaje.ShowDialog()
        End If
    End Sub

    'METODO QUE REALIZA LAS VALIDACIONES DE PAGO
    Public Function validarPagos(tarjeta As Integer, efectivo As Integer, montoPagar As Integer) As Boolean
        Dim textoMensaje = ""
        Dim validacionEfectivo = True
        Dim validacionTarjeta = True
        'Dim validacionAmbos = True
        'validacion con ambos tipos de pago
        'If (chTarjeta.Checked = True And chEfectivo.Checked = True) Then
        '    If (tarjeta > (saldoFactura - montoPagar)) Then
        '        textoMensaje = "Verifique el monto de la tarjeta"
        '        validacionAmbos = False
        '    End If
        'validaciones de efectivo
        If (pagoEfectivo = True And (efectivo < montoPagar Or montoPagar > saldoFactura Or efectivo <= 0)) Then
            textoMensaje = "Verifique que el monto recibido en efectivo y el monto a pagar sean correctos"
            validacionEfectivo = False
            'validcion tarjeta
        ElseIf (pagoTarjeta = True And (tarjeta > saldoFactura Or tarjeta <= 0)) Then
            textoMensaje = "Verifique que el monto de la tarjeta no sea superior al saldo de la factura"
            validacionTarjeta = False
        End If
        'verifica los resultados de las validaciones para retornar si puede o no pagar
        If (validacionEfectivo And validacionTarjeta) Then
            Return True
        Else
            mensaje.tipoMensaje("error")
            mensaje.lblMensaje.Text = textoMensaje
            mensaje.ShowDialog()
            Return False
        End If
    End Function

    'METODO QUE ELIMINA UN PAGO
    Public Sub eliminarPago(ByVal sender As Object, ByVal e As EventArgs)
        'Captura el nombre del boton que lanzo el evento, y que sirve como ID del producto
        Dim button = DirectCast(sender, Button)
        'establece la posicion a eliminar
        Dim posicionEliminar = (button.Name) - 1
        'elimina el objeto de la lista
        pagosFactura.RemoveAt(posicionEliminar)
        'elimina los controles del panel
        pnlPagos.Controls.Remove(pagosFacturaControl(posicionEliminar)(0))
        pnlPagos.Controls.Remove(pagosFacturaControl(posicionEliminar)(1))
        pnlPagos.Controls.Remove(pagosFacturaControl(posicionEliminar)(2))
        pnlPagos.Controls.Remove(pagosFacturaControl(posicionEliminar)(3))
        pnlPagos.Controls.Remove(pagosFacturaControl(posicionEliminar)(4))
        'actualiza las posiciones de los controles de abajo
        For i As Integer = (posicionEliminar + 1) To pagosFacturaControl.Count - 1
            pagosFacturaControl(i)(0).Location = New System.Drawing.Point(pagosFacturaControl(i)(0).Location.X, pagosFacturaControl(i)(0).Location.Y - 50)
            pagosFacturaControl(i)(1).Location = New System.Drawing.Point(pagosFacturaControl(i)(1).Location.X, pagosFacturaControl(i)(1).Location.Y - 50)
            pagosFacturaControl(i)(2).Location = New System.Drawing.Point(pagosFacturaControl(i)(2).Location.X, pagosFacturaControl(i)(2).Location.Y - 50)
            pagosFacturaControl(i)(3).Location = New System.Drawing.Point(pagosFacturaControl(i)(3).Location.X, pagosFacturaControl(i)(3).Location.Y - 50)
            pagosFacturaControl(i)(4).Location = New System.Drawing.Point(pagosFacturaControl(i)(4).Location.X, pagosFacturaControl(i)(4).Location.Y - 50)
        Next
        'elimina el control de la lista
        pagosFacturaControl.RemoveAt(posicionEliminar)

        'reestablece el id
        For i As Integer = 0 To pagosFactura.Count - 1
            pagosFactura(i).NumPago = i + 1
            pagosFacturaControl(i)(0).Text = i + 1
            pagosFacturaControl(i)(4).Name = i + 1

            'saldoFactura = saldoFactura + pagosFactura(i).Vuelto_
        Next
        calcularSaldoFactura()

        If (pagoEfectivo) Then
            txtMontoPagar.Text = saldoFactura.ToString("C")
        End If

        If (pagoTarjeta) Then
            txtTarjeta.Text = saldoFactura.ToString("C")
        End If


    End Sub

    'METODO QUE LIMPIA TODOS LOS PAGOS
    Public Sub limpiarPagos()
        pnlPagos.Controls.Clear()
        pagosFacturaControl.Clear()
        pagosFactura.Clear()

        calcularSaldoFactura()
    End Sub

    'METODO QUE CALCULA EL SALDO DE LA FACTURA
    Public Sub calcularSaldoFactura()
        'inicializa el saldo como el total de la factura
        totalPagos = 0
        saldoFactura = totalFactura
        'recorre la lista de pagos para sumar el monto
        For Each pago In pagosFactura
            totalPagos = totalPagos + pago.Monto_
        Next
        'actualiza los datos
        saldoFactura = saldoFactura - totalPagos
        lblTotalPagos.Text = totalPagos.ToString("C")
        lblSaldoFactura.Text = saldoFactura.ToString("C") 'If(saldoFactura > 0, saldoFactura.ToString("C"), 0.ToString("C"))

        txtMontoPagar.Text = saldoFactura.ToString("C")
        'condiciones para habilitar o deshabilitar botones
        If (saldoFactura = 0) Then
            btnAgregarPago.Visible = False
            btnConfirmar.Visible = True
        ElseIf (saldoFactura > 0 And btnAgregarPago.Visible = False) Then
            'btnAgregarPago.Visible = True
        End If
        If ((saldoFactura > 0 And totalFactura > 0) Or (saldoFactura = 0 And totalFactura = 0)) Then
            btnConfirmar.Visible = False
        End If
    End Sub

    'METODO QUE AGREGA LOS CONTROLES DE LOS PAGOS
    Public Sub agregarControlesPago(idPago As Integer, medio As String, monto As Integer, vuelto As Integer, posYEtiquetas As Integer, posYBoton As Integer)
        '
        'lblNumPago
        '
        Dim lblNumPago As New Label
        lblNumPago.AutoSize = True
        lblNumPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblNumPago.ForeColor = System.Drawing.Color.White
        lblNumPago.Location = New System.Drawing.Point(15, posYEtiquetas)
        lblNumPago.Name = "lblNumPago"
        lblNumPago.Size = New System.Drawing.Size(18, 20)
        lblNumPago.TabIndex = 4
        lblNumPago.Text = idPago
        '
        'lblEfectivo
        '
        Dim lblMedio As New Label
        lblMedio.AutoSize = True
        lblMedio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblMedio.ForeColor = System.Drawing.Color.White
        lblMedio.Location = New System.Drawing.Point(70, posYEtiquetas)
        lblMedio.Name = "lblEfectivo"
        lblMedio.Size = New System.Drawing.Size(49, 20)
        lblMedio.TabIndex = 5
        If (medio.CompareTo("T") = 0) Then
            lblMedio.Text = "Tarjeta"
        ElseIf (medio.CompareTo("E") = 0) Then
            lblMedio.Text = "Efectivo"
        ElseIf (medio.CompareTo("U") = 0) Then
            lblMedio.Text = "Uber Eats"
        End If
        '
        'lblVuelto
        '
        Dim lblMonto As New Label
        lblMonto.AutoSize = True
        lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblMonto.ForeColor = System.Drawing.Color.White
        lblMonto.Location = New System.Drawing.Point(140, posYEtiquetas)
        lblMonto.Name = "lblVuelto"
        lblMonto.Size = New System.Drawing.Size(18, 20)
        lblMonto.TabIndex = 34
        lblMonto.Text = monto.ToString("C")
        '
        'lblTarjeta
        '
        Dim lblVuelto As New Label
        lblVuelto.AutoSize = True
        lblVuelto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblVuelto.ForeColor = System.Drawing.Color.White
        lblVuelto.Location = New System.Drawing.Point(240, posYEtiquetas)
        lblVuelto.Name = "lblTarjeta"
        lblVuelto.Size = New System.Drawing.Size(18, 20)
        lblVuelto.TabIndex = 6
        lblVuelto.Text = vuelto.ToString("C")
        '
        'lblUber
        '
        Dim lblUber As New Label
        lblUber.AutoSize = True
        lblUber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblUber.ForeColor = System.Drawing.Color.White
        lblUber.Location = New System.Drawing.Point(240, posYEtiquetas)
        lblUber.Name = "lblUber"
        lblUber.Size = New System.Drawing.Size(18, 20)
        lblUber.TabIndex = 6
        lblUber.Text = vuelto.ToString("C")

        '
        'btnEliminarPago
        '
        Dim btnEliminarPago As New Button
        btnEliminarPago.AutoSize = True
        btnEliminarPago.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        btnEliminarPago.FlatAppearance.BorderSize = 0
        btnEliminarPago.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        btnEliminarPago.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        btnEliminarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnEliminarPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        btnEliminarPago.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        btnEliminarPago.Image = Global.SunChangSystem.My.Resources.Resources.btnBorrar
        btnEliminarPago.Location = New System.Drawing.Point(320, posYBoton)
        btnEliminarPago.Name = idPago
        btnEliminarPago.Size = New System.Drawing.Size(48, 43)
        btnEliminarPago.TabIndex = 33
        btnEliminarPago.UseVisualStyleBackColor = True
        AddHandler btnEliminarPago.Click, AddressOf eliminarPago

        'agrega los controles a la lista
        Dim pagoControles = {lblNumPago, lblMedio, lblMonto, lblVuelto, btnEliminarPago}
        pagosFacturaControl.Add(pagoControles)

        pnlPagos.Controls.Add(lblNumPago)
        pnlPagos.Controls.Add(lblMedio)
        pnlPagos.Controls.Add(lblMonto)
        pnlPagos.Controls.Add(lblVuelto)
        pnlPagos.Controls.Add(btnEliminarPago)
    End Sub

    'METODO QUE VALIDA QUE SOLO INGRESEN NUMEROS EN EL CAMPO DE TEXTO
    Private Sub txtTarjeta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarjeta.KeyPress
        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'METODO QUE VALIDA QUE SOLO INGRESEN NUMEROS EN EL CAMPO DE TEXTO
    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'METODO QUE VALIDA QUE SOLO INGRESEN NUMEROS EN EL CAMPO DE TEXTO
    Private Sub txtMontoPagar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoPagar.KeyPress
        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'METODO QUE INSERTAR UNA FACTURA EN LA BASE DE DATOS
    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        'nueva instancia de la clase de datos
        Dim facturaDatos = New FacturacionDatos
        Dim desc As Double
        If (txtDescuento.Text.CompareTo("") = 0) Then
            desc = 0
        Else
            desc = txtDescuento.Text.Trim()
        End If
        'declara una nueva factura
        Dim factura As New Factura
        factura.NumFactura = lblNumFactura.Text
        factura.FechaFactura = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        factura.CodEstadoFactura = "A"
        factura.Descuento_ = Double.Parse(desc)
        factura.NumOrden = numOrdenFacturar
        factura.MontoTotal = totalFactura
        factura.NombreCliente_ = txtNombre.Text

        factura.Monto_descuentoSG = CDbl(lblDescuento.Text)
        factura.Porcentaje_descuentoSG = Double.Parse(desc)
        factura.ImpservSG = CDbl(lblImpServicio.Text)
        factura.ImpvtasSG = CDbl(lblImpVentas.Text)

        If (ordenAPagar.Ubicacion_.CompareTo("E") = 0) Then
            factura.ExpressSG = CDbl(txtExpress.Text)
        Else
            factura.ExpressSG = 0
        End If

        ' objeto de orden
        Dim orden As New Orden
        'subtotal
        Dim subTotal = lblSubTotal.Text

        orden.ImpServ_ = 0
        orden.ImpVtas_ = 0
        orden.Express_ = 0

        If (ordenAPagar.Ubicacion_.CompareTo("S") = 0) Then
            ' se le hace el descuento al subtotal
            subTotal -= subTotal * (orden.Descuento_ / 100)
            ' se calcula el el impuesto de servicio
            orden.ImpServ_ = subTotal * (parametros.PorcImpServ / 100)


        ElseIf (ordenAPagar.Ubicacion_.CompareTo("E") = 0) Then
            orden.Express_ = txtExpress.Text
        End If

        ' se calcula el impuesta de ventas
        orden.ImpVtas_ = subTotal * (parametros.PorcImpVtas / 100) '0.13
        subTotal += orden.ImpVtas_

        factura.SubtotalSG = (CDbl(lblSubTotal.Text) - factura.Monto_descuentoSG)
        'guarda la factura en la base de datos
        Dim result = facturaDatos.ingresarFactura(factura)
        'si pudo ingresar la factura ingresa el detalle de la factura en la base
        If (result) Then
            'recorre la lista de los productos que pago en la factura
            For Each productoFactura In productosFactura
                Dim facturaDetalle As New FacturaDetalle
                facturaDetalle.NumFactura = lblNumFactura.Text
                facturaDetalle.CodEstadoFactura = "A"
                facturaDetalle.NumOrden = numOrdenFacturar
                facturaDetalle.CodProducto = productoFactura(1).CodProducto
                facturaDetalle.Cantidad_ = productoFactura(0)
                facturaDetalle.SubTotal = productoFactura(0) * productoFactura(1).PrecioVenta
                'agrega el producto a la lista de productos pagados
                facturaDatos.ingresarFacturaDetalle(facturaDetalle)
            Next

            'declara la variable a guardar la totalidad de montos pagados en efectivo, uber y tarjeta
            Dim totalEfectivo = 0, totalTarjeta = 0, totalUber = 0
            'recorre todos los pagos de la factura y hace el llamado al metodo que lo ingresa en la BD
            For Each pago In pagosFactura
                facturaDatos.ingresarPagoFactura(pago)
                If (pago.TipoPago.CompareTo("E") = 0) Then
                    totalEfectivo = totalEfectivo + pago.Monto_
                ElseIf (pago.TipoPago.CompareTo("T") = 0) Then
                    totalTarjeta = totalTarjeta + pago.Monto_
                ElseIf (pago.TipoPago.CompareTo("U") = 0) Then
                    totalUber = totalTarjeta + pago.Monto_
                End If
            Next

            'crea el objeto orden para actualizarlo en la BD (actualiza los montos)
            orden.NumOrden = numOrdenFacturar
            orden.Total_ = totalFactura
            orden.CodCliente = cod_cliente
            orden.Efectivo_ = totalEfectivo

            orden.Descuento_ = Double.Parse(desc)
            orden.Tarjeta_ = totalTarjeta

            orden.Uber_ = totalUber

            'ingresa los datos de la factura en la orden_m
            facturaDatos.ingresarDatosFacturaEnOrden(orden)

            'obtiene los parametros actualizados
            parametros = facturaDatos.obtenerParametros

            'actualiza las etiquetas con el numero de factura y fecha
            lblNumFactura.Text = parametros.NumFactura + 1
            lblFecha.Text = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            'limpia los controles de pagos
            limpiarPagos()

            'limpia los controles de la factura
            For Each control In detalleFacturaControl
                pnlProductoFactura.Controls.Remove(control(0))
                pnlProductoFactura.Controls.Remove(control(1))
                pnlProductoFactura.Controls.Remove(control(2))
                pnlProductoFactura.Controls.Remove(control(3))
            Next
            'limpia los controles de la orden
            For Each productoOrden In detalleProductoControl
                pnlProductos.Controls.Remove(productoOrden(0))
                pnlProductos.Controls.Remove(productoOrden(1))
                pnlProductos.Controls.Remove(productoOrden(2))
            Next
            'borra los productos de la orden
            productosOrden.Clear()
            'borra los controles de la orden
            detalleProductoControl.Clear()
            'borra los productos de la factura
            productosFactura.Clear()
            'borra los productos de los controles de la factura
            detalleFacturaControl.Clear()

            imprimirFactura(factura.NumFactura)

            'muestra los productos de la factura
            mostrarProductosFactura()
        Else
            mensaje.tipoMensaje("error")
            mensaje.lblMensaje.Text = "Ha ocurrido un error, realice el pago nuevamente."
            mensaje.ShowDialog()
        End If
    End Sub

    Public Sub imprimirLista(lista As List(Of Object))
        Dim cadena = ""
        For Each list In lista
            cadena = cadena & list(0) & "  " & list(1).Nombre_ & vbCr & vbCr
        Next

    End Sub

    Private Sub btnEfectivo_Click(sender As Object, e As EventArgs) Handles btnEfectivo.Click
        mostrarPagoEfectivo()
        Me.btnDividirFactura.Enabled = True
        btnAgregarPago.Visible = True
    End Sub

    Private Sub btnTarjeta_Click(sender As Object, e As EventArgs) Handles btnTarjeta.Click
        mostrarPagoTarjeta()
        Me.btnDividirFactura.Enabled = True
        btnAgregarPago.Visible = True
    End Sub

    Public Sub mostrarPagoEfectivo()
        pnlEfectivo.Visible = True
        Me.pnlUber.Visible = False
        txtMontoPagar.Text = saldoFactura.ToString("C")

        pagoEfectivo = True
        pagoTarjeta = False
        pagoUber = False

        pnlTarjeta.Visible = False
        txtTarjeta.Text = 0.ToString("C")
    End Sub

    Private Sub txtExpress_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExpress.KeyPress
        If e.KeyChar.IsDigit(e.KeyChar) Then
            Dim valor_express As String = txtExpress.Text.ToString.TrimStart("₡")
            monto_express = CDbl(valor_express.TrimStart("."))
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'Private Sub txtDescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuento.KeyPress
    '    If e.KeyChar.IsDigit(e.KeyChar) Then
    '        monto_descuento = CDbl(sender.Text.ToString.TrimEnd("%"c))
    '        If saldoFactura > 0 Then
    '            e.Handled = False
    '        Else
    '            e.Handled = True
    '            mensaje.lblMensaje.Text = "No se puede realizar el descuento. Factura lista para procesar"
    '            mensaje.ShowDialog()
    '        End If

    '    ElseIf e.KeyChar.IsControl(e.KeyChar) Then
    '        e.Handled = False
    '    Else
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub txtDescuento_TextChanged(sender As Object, e As EventArgs) Handles txtDescuento.TextChanged
        Try
            If Not txtDescuento.Text.Equals("") Then
                If (CDbl(txtDescuento.Text.Trim()) <= 100) Then
                    calcularTotal()
                Else
                    'txtDescuento.Text = monto_descuento
                    mensaje.lblMensaje.Text = "Monto no puede ser superior al 100%"
                    mensaje.ShowDialog()
                End If
            Else
                'txtDescuento.Text = 0.ToString("P")
                calcularTotal()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtExpress_TextChanged(sender As Object, e As EventArgs) Handles txtExpress.TextChanged
        Dim express As String = txtExpress.Text.ToString.TrimStart("₡")
        Try
            Try
                If (Not express = "") Then
                    If (CDbl(express.ToString.TrimStart(".")) >= 0) Then
                        calcularTotal()
                    Else
                        txtExpress.Text = monto_express
                        mensaje.lblMensaje.Text = "Monto debe ser superior a 0"
                        mensaje.ShowDialog()
                    End If
                Else
                    txtExpress.Text = 0.ToString("C")
                End If

            Catch ex As OverflowException

            End Try

        Catch ex As System.InvalidCastException
            txtExpress.Text = monto_express.ToString("C")
        End Try


    End Sub

    Private Sub Facturacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ordenes1.mostrarOrdenes(0)
    End Sub

    Public Sub mostrarPagoTarjeta()
        pnlTarjeta.Visible = True
        txtTarjeta.Text = saldoFactura.ToString("C")
        Me.pnlUber.Visible = False
        pagoTarjeta = True
        pagoEfectivo = False
        pagoUber = False

        pnlEfectivo.Visible = False

        txtMontoPagar.Text = 0.ToString("C")
        txtEfectivo.Text = 0.ToString("C")
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cliente As New SeleccionarCliente(Me)
        cliente.ShowDialog()
        'Dim nuevoCliente As New NuevoCliente
        'nuevoCliente.ShowDialog()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles cbProforma.CheckedChanged
        If cbProforma.Checked Then
            imprimirFacturaProforma()
        End If
    End Sub

    ' metodo para imprimir la factura
    ' llama al reporte de Factura2 que obtiene los datos de la base de datos
    Public Function imprimirFacturaProforma() As Boolean
        Try
            ' se crear la factura proforma
            facturaDatos = New FacturacionDatos
            facturaDatos.crearFacturaProforma(ordenAPagar.NumOrden)

            Dim usuario As New ParameterValues
            Dim numero_factura As New ParameterValues

            Dim pvisualizar As New ParameterDiscreteValue

            If ordenAPagar.Ubicacion_ = "S" Then
                Dim factura As New FacturaProforma

                pvisualizar.Value = lblNumFactura.Text
                numero_factura.Add(pvisualizar)
                factura.DataDefinition.ParameterFields("NumeroFactura").ApplyCurrentValues(numero_factura)

                pvisualizar.Value = txtNombre.Text
                usuario.Add(pvisualizar)
                factura.DataDefinition.ParameterFields("Cliente").ApplyCurrentValues(usuario)

                pvisualizar.Value = "Salon"
                usuario.Add(pvisualizar)
                factura.DataDefinition.ParameterFields("Ubicacion").ApplyCurrentValues(usuario)

                pvisualizar.Value = (InicioSesion.session.EmpleadoSG.NombreSG + " " + InicioSesion.session.EmpleadoSG.Apellido1SG)
                usuario.Add(pvisualizar)
                factura.DataDefinition.ParameterFields("Cajero").ApplyCurrentValues(usuario)

                pvisualizar.Value = ordenAPagar.NumMesa
                usuario.Add(pvisualizar)
                factura.DataDefinition.ParameterFields("Mesa").ApplyCurrentValues(usuario)

                pvisualizar.Value = lblSubTotal.Text
                usuario.Add(pvisualizar)
                factura.DataDefinition.ParameterFields("subtotal").ApplyCurrentValues(usuario)

                pvisualizar.Value = lblDescuento.Text
                usuario.Add(pvisualizar)
                factura.DataDefinition.ParameterFields("descuento").ApplyCurrentValues(usuario)

                pvisualizar.Value = lblImpVentas.Text
                usuario.Add(pvisualizar)
                factura.DataDefinition.ParameterFields("impvtas").ApplyCurrentValues(usuario)

                pvisualizar.Value = lblImpServicio.Text
                usuario.Add(pvisualizar)
                factura.DataDefinition.ParameterFields("impserv").ApplyCurrentValues(usuario)

                pvisualizar.Value = lblTotal.Text
                usuario.Add(pvisualizar)
                factura.DataDefinition.ParameterFields("total").ApplyCurrentValues(usuario)

                Dim reporte As New Reportes
                reporte.VistaReportes.ReportSource = factura
                'reporte.ShowDialog()
                reporte.VistaReportes.PrintReport()

            End If

            Dim mensaje_confirmacion As New MensajeConfirmacion
            mensaje_confirmacion.lblMensaje.Text = "¿Se imprimió corectamente la factura?"
            mensaje_confirmacion.ShowDialog()

            ' se eliminan los archivos
            Dim url As String = "C:\XML\detalleProforma.xml"
            My.Computer.FileSystem.DeleteFile(url)

            If Not mensaje_confirmacion.decision Then
                imprimirFacturaProforma()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return True
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnUber.Click

        Me.btnDividirFactura.Enabled = False
        Me.btnAgregarPago.Visible = True
        mostrarPagoUber()



    End Sub



    Public Sub mostrarPagoUber()
        Me.pnlUber.Visible = True
        txtUber.Text = saldoFactura.ToString("C")
        'txtTarjeta.Text = saldoFactura.ToString("C")

        pagoTarjeta = False
        pagoEfectivo = False
        pagoUber = True
        Me.pnlTarjeta.Visible = False
        Me.pnlEfectivo.Visible = False
        txtMontoPagar.Text = 0.ToString("C")
        txtEfectivo.Text = 0.ToString("C")
    End Sub


    ' metodo para imprimir la factura
    ' llama al reporte de Facturas que obtiene los datos de la base de datos
    Public Function imprimirFactura(num_factura As Double) As Boolean
        Try

            Dim facturaDatos = New FacturacionDatos
            facturaDatos.crearFactura(CInt(num_factura), InicioSesion.session.EmpleadoSG.Cod_usuarioSG)

            Dim factura As New Factura2

            ' imprime
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = factura
            reporte.VistaReportes.RefreshReport()
            'reporte.ShowDialog()
            reporte.VistaReportes.PrintReport()

            Dim mensaje_confirmacion As New MensajeConfirmacion
            mensaje_confirmacion.lblMensaje.Text = "¿Se imprimió corectamente la factura?"
            mensaje_confirmacion.ShowDialog()

            ' se eliminan los archivos
            Dim url As String = "C:\XML\factura.xml"
            My.Computer.FileSystem.DeleteFile(url)
            url = "C:\XML\detallefactura.xml"
            My.Computer.FileSystem.DeleteFile(url)
            url = "C:\XML\montofactura.xml"
            My.Computer.FileSystem.DeleteFile(url)

            ' valida si seimprimio o no la factura
            If Not mensaje_confirmacion.decision Then
                imprimirFactura(num_factura)
            End If

            If ordenAPagar.Ubicacion_ = "E" Then
                ' imprimirFacturaCocina(num_factura)
                imprimirFacturaCocina(num_factura)
            ElseIf ordenAPagar.Ubicacion_ = "L" Then
                imprimirFacturaCocina(num_factura)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return True
    End Function

    ' metodo que se encarga de imprimir las facturas para la cocina
    Public Sub imprimirFacturaCocina(num_factura As Double)

        Dim facturaDatos = New FacturacionDatos
        facturaDatos.crearFacturaCocina(CInt(num_factura), InicioSesion.session.EmpleadoSG.Cod_usuarioSG)

        Dim factura As New FacturaExpress

        ' imprime
        Dim reporte As New Reportes
        reporte.VistaReportes.ReportSource = factura
        reporte.VistaReportes.RefreshReport()
        'reporte.ShowDialog()
        reporte.VistaReportes.PrintReport()

        Dim mensaje_confirmacion As New MensajeConfirmacion
        mensaje_confirmacion.lblMensaje.Text = "¿Se imprimió corectamente la factura?"
        mensaje_confirmacion.ShowDialog()

        ' valida si seimprimio o no la factura
        If Not mensaje_confirmacion.decision Then
            imprimirFacturaCocina(num_factura)
        End If

    End Sub
End Class