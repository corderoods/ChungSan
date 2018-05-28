Public Class Ordenes

    'instancias a datos
    Dim tipoProductoDatos As TipoProductoDatos
    Dim productoDatos As ProductoDatos = New ProductoDatos
    Dim ordenDatos As OrdenDatos
    Dim clienteDatos As ClienteDatos
    Dim facturacionDatos As FacturacionDatos
    Public EsUber As Boolean

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        facturacionDatos = New FacturacionDatos
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    'Metodo que se ejecuta automaticamente cuando se carga el form 
    Private Sub Ordenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'llama a cargar todas las ordnes y las categorias existentes
        mostrarOrdenes(0, EsUber)
        timerLlamaMesero.Enabled = True
    End Sub

    Private Sub mostrarCategoriasProductos()

        'obtiene todas las categorias
        tipoProductoDatos = New TipoProductoDatos
        Dim tiposProducto = tipoProductoDatos.obtenerTiposProducto()

        'limpia el panel de categorias elimianndo todos los controles
        pnlCategorias.Controls.Clear()
        'controla la poscicion X de cada boton de categoria
        Dim posX = 0
        Dim posY = 0
        Dim cont As Integer

        'recorre la lista de categorias y va creando un boton para cada una y agregandolo
        'al panel de las categias
        For i = 0 To tiposProducto.Count - 1
            'crea el boton de las categoria y establece las propiedades de cada uno
            btnCategoria = New Button
            btnCategoria.Image = Global.SunChangSystem.My.Resources.Resources.btnOrden2
            'texto que se muestra en el boton el nombre de la categoria
            btnCategoria.Text = tiposProducto(i).DescripcionSG
            btnCategoria.Location = New Point(posX, posY)
            btnCategoria.Size() = New Size(150, 60)
            btnCategoria.AutoSize = True
            'cada boton tiene en el name el codigo de la categoria
            btnCategoria.Name = tiposProducto(i).IdTipoProductoSG

            btnCategoria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btnCategoria.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            btnCategoria.FlatAppearance.BorderSize = 0
            btnCategoria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            btnCategoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
            If tiposProducto(i).DescripcionSG.Length > 10 Then
                btnCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Else
                btnCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            End If
            btnCategoria.UseVisualStyleBackColor = False
            btnCategoria.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
            btnCategoria.Cursor = Cursors.Hand

            'cuando ya el boton esta creado con todas las caracteristicas se agrega al panel de categorias
            pnlCategorias.Controls.Add(btnCategoria)

            'se agrega el evento para cuando se le da click a una categoria
            AddHandler btnCategoria.Click, AddressOf btnCategoria_Click

            'se actualiza posX para darle ubicacion al siguiente boton para calcularlo se suma
            'la ubicacion X del ultimo boton + el largo que tiene ese mismo y se le suman 10 mas
            'para dejar un espacio entre ambos

            'posX = btnCategoria.Location.X + btnCategoria.Size.Width +

            posY = posY + 75
            cont = cont + 1

            If cont = 5 Then
                posY = 0
                posX = posX + 170
                cont = 0
            End If
        Next i

        'activa el primer boton de las categorias dandole click
        'CType(pnlProductos.Controls(0), Button).PerformClick()
    End Sub

    Public Sub mostrarOrdenes(ByVal indice As Integer, ByVal EsUber As Boolean)
        'poscision en el eje Y de cada boton por ordenes
        Dim posY = 0
        Me.EsUber = EsUber
        'inicializa variables y obtiene todas las ordenes sin pagar
        clienteDatos = New ClienteDatos
        ordenDatos = New OrdenDatos
        Dim ordenes = ordenDatos.obtenerOrdenSinPagar()

        'limpia el panel de ordenes y el que contiene el detalle de pedidos de cada orden
        'elimianndo todos los botones y demas controles que tenia
        pnlOrdenes.Controls.Clear()
        pnlDetalle.Controls.Clear()

        'si existen ordenes entonces se ponen los paneles y los botones como visibles
        If (ordenes.Count <> 0) Then
            pnlCategorias.Visible = True
            btnBorrar.Visible = True
            pnlPrinCategorias.Visible = True
            pnlPrinOrdenes.Visible = True
            pnlPrinProd.Visible = True

            'redimensiona el tamaño del vector de botones segun la cantidad de ordenes que existen
            ReDim botonesOrdenes(ordenes.Count)
            'variable text para ponerle texto al boton ya sea si es salon express o llevar
            Dim text As String = ""

            'recorre todas las ordenes para ir creando los botones
            For i = 0 To ordenes.Count - 1
                'crea nuevo boton
                btnOrden = New Button

                If ordenes(i).Ubicacion_ = "S" Then
                    Dim cant = 0
                    'cuando la orden es de salon verifica si hay solo una orden para la mesa
                    'recorriendo las ordenes y preguntando por el numero de mesa
                    For j = 0 To ordenes.Count - 1
                        If ordenes(i).NumMesa = ordenes(j).NumMesa And ordenes(i).NombreCliente_ = "CONTADO" And ordenes(i).Ubicacion_ = ordenes(j).Ubicacion_ Then
                            'si hay dos ordenes para la misma mesa se aumenta la cantidad
                            cant = cant + 1
                        End If
                    Next j
                    'si hay mas de una orden para la misma mesa, se asigna el numero de mesa y el
                    'numero de orden al boton, sino se le pone solo el numero de la mesa
                    If cant > 1 Then
                        If ordenes(i).NombreCliente_ = "CONTADO" Then
                            text = "Mesa " & ordenes(i).NumMesa & " Orden " & ordenes(i).NumOrden
                        Else
                            text = "Mesa " & ordenes(i).NumMesa & "  " & ordenes(i).NombreCliente_
                        End If
                    Else
                        If ordenes(i).NombreCliente_ = "CONTADO" Then
                            text = "Mesa " & ordenes(i).NumMesa
                        Else
                            text = "Mesa " & ordenes(i).NumMesa & "  " & ordenes(i).NombreCliente_
                        End If
                    End If 'fin del salon

                ElseIf ordenes(i).Ubicacion_ = "E" Then
                    'si la orden es express, va a buscar el nombre 
                    'del Cliente al que pertenece la orden para ponerle el nombre
                    If ordenes(i).NombreCliente_ = "" Then
                        text = "Express " & clienteDatos.obtenerClientePorId(ordenes(i).CodCliente).NombreClienteSG
                    Else
                        text = "Express " & ordenes(i).NombreCliente_
                    End If ' fin delexpress

                ElseIf ordenes(i).Ubicacion_ = "L" Then
                    'si la orden es para llevar, le pone el numero de la orden
                    If ordenes(i).NombreCliente_ = "CONTADO" Then
                        text = "Llevar " & ordenes(i).NumOrden
                    Else
                        text = "Llevar " & ordenes(i).NombreCliente_
                    End If 'Fin de llevar

                ElseIf ordenes(i).Ubicacion_ = "U" Then
                    'si la orden es para Uber, le pone el numero de la orden
                    If ordenes(i).NombreCliente_ = "UBER" Then
                        text = "Uber Eats " & ordenes(i).NumOrden
                    Else
                        text = "Uber Eats " & ordenes(i).NombreCliente_
                    End If

                End If

                'se le pone al boton el nombre calculado anteriormente
                btnOrden.Text = text
                'se agregan al boton el resto de caracteristicas
                btnOrden.Location = New Point(0, posY)
                btnOrden.Size() = New Size(140, 60)
                'el name del boton tiene el numero de la orden
                btnOrden.Name = ordenes(i).NumOrden
                btnOrden.Image = Global.SunChangSystem.My.Resources.Resources.btnOrden2
                btnOrden.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
                btnOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
                btnOrden.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
                btnOrden.FlatAppearance.BorderSize = 0
                btnOrden.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
                btnOrden.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
                btnOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                btnOrden.UseVisualStyleBackColor = False
                btnOrden.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
                btnOrden.Cursor = Cursors.Hand


                'se agrega el boton creado al arreglo que tiene los botones
                botonesOrdenes(i) = btnOrden
                'Se agrega al panel el boton creado anteriormente
                pnlOrdenes.Controls.Add(botonesOrdenes(i))
                'se agrega el evebto para cuando se le da click a una orden especifica
                AddHandler btnOrden.Click, AddressOf btnOrden_Click
                'la poscision del siguiente boton se mantiene con la mism X y la poscision'
                'Y se aumenta en 65, 60 del alto del boton y 5 de espacio para el siguiente
                posY = posY + 65
            Next i

            'pregunta si hay botones creados en el panel
            If pnlOrdenes.Controls.Count <> 0 Then
                'el indice es para saber a cual boton de los que se crearon hay que darle click
                If indice = 0 Then
                    'si el indice es 0 entonces se le da click a la primera orden de la lista
                    'la que esta en la ubicacion 0
                    CType(pnlOrdenes.Controls(indice), Button).PerformClick()
                Else
                    'si el infice es distinto de 0 es porqe se le va a dar click a una orden
                    'que acaba de ser creada entonces se le da click al ultimo boton de la lista
                    'de controles del panel
                    CType(pnlOrdenes.Controls(pnlOrdenes.Controls.Count - 1), Button).PerformClick()
                End If
            End If
        Else
            'si no existian ordenes creadas entonces se 
            'bloquean todos los botones y paneles para que no pueda hacer nunguna accion
            btnImprimir.Visible = False
            btnBorrar.Visible = False
            pnlCategorias.Visible = False
            pnlPrinCategorias.Visible = False
            pnlPrinOrdenes.Visible = False
            pnlPrinProd.Visible = False
        End If
        mostrarCategoriasProductos()
        cargarProductos()
    End Sub

    'el panel detalle es donde estan contenida toda la lista de pedidos para una orden,
    'este metodo lo que hace es poner el scroll en la poscicion de arriba y eliminar 
    'todos los controles que tenia el panel
    Private Sub RemoverListaDetalle()
        pnlDetalle.AutoScrollPosition = New Point(0, 0)
        pnlDetalle.Controls.Clear()
    End Sub

    'una vez que se actualiza algun control en la lista de detalles de la orden,
    'se llama este metodo para agregar todos los controles que tiene la lista de detalle al panel
    Private Sub AgregarListaDetalle()
        'recorre toda la lista de controles para agregarlos al panel
        For i = 0 To listaControlesDetalle.Count - 1
            pnlDetalle.Controls.Add(listaControlesDetalle(i)(0))
            pnlDetalle.Controls.Add(listaControlesDetalle(i)(1))
            pnlDetalle.Controls.Add(listaControlesDetalle(i)(2))
        Next i
    End Sub

    Private Sub btnOrden_Click(sender As Object, e As EventArgs)
        'Pregunta si el boton al que se le dio click cambia de color la letra para saber si esta notificando algo al mesero
        If CType(sender, Button).ForeColor = Color.Red Or CType(sender, Button).ForeColor = Color.White Then
            'si es una notificacion entonces envia a modificar la notificacion como recibida
            ordenDatos.actualizarLlamadaMesero(CType(sender, Button).Name)
            'pone el color normal del boton
            CType(sender, Button).ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        End If
        ordenDatos = New OrdenDatos
        ' el ciclo busca la orden que ha dejado de estar seleccionada para ponerle
        ' diferente color al boton
        For i As Integer = 0 To botonesOrdenes.Count - 2
            If (botonesOrdenes(i).Name = ordenActiva) Then
                botonesOrdenes(i).Image = Global.SunChangSystem.My.Resources.Resources.btnOrden2
            End If
        Next i
        'orden con la que estoy trabajando actualmente
        ordenActiva = CType(sender, Button).Name
        'cambia el texto de la etiqueta que muestra el nombre de la orden al lado arriba del detalle
        lblDetalleOrden.Text = "Detalle de " & CType(sender, Button).Text & ":"

        'pone de diferente color al boton que se selecciono
        CType(sender, Button).Image = Global.SunChangSystem.My.Resources.Resources.btnSeleccionado

        'lista de todos los detalles de una orden especifica
        Dim listaDetallesOrdenTemp = ordenDatos.obtenerPedidosPorOrden(ordenActiva)
        'lista de todos los detalles de una orden especifica pero de la tabla de facturacion
        Dim productosPagados = facturacionDatos.obtenerProductosFacturaDetalle(ordenActiva)

        'reinicializa la lista de ordenes temporales
        listaDetallesOrden = New List(Of OrdenTemporal)
        Dim var = 0
        'pregunta si existe algun objeto en la lista de productos pagados
        If productosPagados.Count <> 0 Then
            'recorre la lista de ordenes para verificar si ya hay productos cancelados
            For Each ordenTemporal In listaDetallesOrdenTemp
                'cuanod "var" esta en 1 es porque se tiene que agregar el objeto a la lista
                'si esta en 0 es porque el producto ya fue pagado completo
                var = 0
                For Each productoPagado In productosPagados
                    'pregunta si el producto de la orden ya esta pagado
                    If (ordenTemporal.CodProducto = productoPagado.CodProducto) Then
                        'si esta pagado pregunta si la cantidad del producto se pago en su totalidad
                        If ordenTemporal.Cantidad_ <> productoPagado.Cantidad_ Then
                            'si no se pago completa la cantidad del producto, 
                            'le resta la cantidad pagada al producto original
                            ordenTemporal.Cantidad_ = ordenTemporal.Cantidad_ - productoPagado.Cantidad_
                            var = 1
                        Else
                            var = 0
                            Exit For
                        End If
                    Else
                        var = 1
                    End If
                Next
                If var = 1 Then
                    'agrega la orden a la lista
                    listaDetallesOrden.Add(ordenTemporal)
                End If
            Next
        Else
            listaDetallesOrden = listaDetallesOrdenTemp
        End If

        'si la orden no tiene ningun pedido entonces se oculta el boton de imprimir
        If (listaDetallesOrden.Count = 0) Then
            btnImprimir.Visible = False
        Else
            btnImprimir.Visible = True
        End If
        btnBorrar.Visible = True
        pnlPrinCategorias.Visible = True
        pnlPrinProd.Visible = True

        'eliminar todos los controles del panel de detalle
        RemoverListaDetalle()

        listaControlesDetalle = New LinkedList(Of Object)
        'posciciones en el eje Y de cada control, el boton es un poco mas grande por lo que
        'se maneja una variable solo para el boton con un valor de 5 menos
        posYDetalle = 5
        posYBoton = 0

        'recorre la lista para crear los controles y agregarlos al panel
        For i = 0 To listaDetallesOrden.Count - 1
            Dim arreglo(3) As Object
            'crea la etiqueta que contiene la cantidad del producto
            arreglo(0) = crearEtiquetaCantidad(listaDetallesOrden(i).CodProducto, listaDetallesOrden(i).Cantidad_)
            'crea la etiqueta con el nombre del producto
            arreglo(1) = crearEtiquetaNombre(listaDetallesOrden(i).CodProducto)
            'crea el boton que se usa para editar un producto pedido
            arreglo(2) = crearBotonEditar(listaDetallesOrden(i).CodProducto)

            'agregar a la ListaDetalle el arreglo con los controles a la lista de controles
            listaControlesDetalle.AddLast(arreglo)

            'actualiza estas variables para poder poner los siguientes controles en el lugar correcto
            posYDetalle = listaControlesDetalle(i)(0).Location.Y + listaControlesDetalle(i)(0).Size.Height + 10
            posYBoton = listaControlesDetalle(i)(2).Location.Y + listaControlesDetalle(i)(2).Size.Height + 10

            'agrega los controles del arreglo al panel
            pnlDetalle.Controls.Add(arreglo(0))
            pnlDetalle.Controls.Add(arreglo(1))
            pnlDetalle.Controls.Add(arreglo(2))
        Next i

        'vuelve a poner las variables reinicializadas
        posYDetalle = 5
        posYBoton = 0
        alertaProductosListos(ordenActiva)
    End Sub

    'cuando se le da click a una categoria, muestra la lista de productos
    Private Sub btnCategoria_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim seleccionarProducto As SeleccionarSubcategoria = New SeleccionarSubcategoria(Me, CType(sender, Button).Name, CType(sender, Button).Text)
        seleccionarProducto.ShowDialog()

    End Sub

    'si se le da click a un producto que ya existe dentro del pedido, se busca en la lista de controles
    'y se actualiza la cantidad sumandole uno
    Private Function existeProducto(ByVal idProducto As Integer) As Boolean
        For i = 0 To listaControlesDetalle.Count - 1
            If (listaControlesDetalle(i)(1).Name = idProducto) Then
                'aumente la cantidad del producto en uno y lo muestra en la etiqueta
                listaControlesDetalle(i)(0).Text = listaControlesDetalle(i)(0).Text + 1
                ordenDatos = New OrdenDatos
                'obtiene el pedido de la orden y la envia a actualizar la cantidad
                Dim ordenTemporal = ordenDatos.obtenerDetalleOrdenTemporal(ordenActiva, idProducto)
                ordenDatos.modificarCantidadDetalleOrden(ordenActiva, ordenTemporal.NumLinea, listaControlesDetalle(i)(0).Text)
                Return True
            End If
        Next i
        Return False
    End Function

    Public Sub cargarProductos()
        productoDatos = New ProductoDatos()
        Dim totalProductos = productoDatos.obtenerProductos()

        Dim dtCodigo As New DataTable
        dtCodigo.Columns.Add("Codigo", System.Type.GetType("System.Int32"))
        dtCodigo.Columns.Add("Nombre", System.Type.GetType("System.String"))

        For i = 0 To totalProductos.Count - 1
            Dim dr As DataRow = dtCodigo.NewRow
            dr = dtCodigo.NewRow
            dr("Codigo") = totalProductos(i).CodProducto
            dr("Nombre") = totalProductos(i).Nombre_
            dtCodigo.Rows.Add(dr)
        Next i
        cbxProducto.ValueMember = "Codigo"
        cbxProducto.DisplayMember = "Nombre"
        cbxProducto.DataSource = dtCodigo
    End Sub

    Public Sub agregarProductoADetalleOrden(ByVal idproducto As Integer)
        btnImprimir.Visible = True

        pnlDetalle.AutoScrollPosition = New Point(0, 0)

        'si no hay ningun producto agregado, se ponen las variables en el valor inicial
        If pnlDetalle.Controls.Count = 0 Then
            posYDetalle = 5
            posYBoton = 0
        End If

        'si el producto no existe entonces lo crea y lo agrega al panel
        If (existeProducto(idproducto) = False) Then

            'limpia el panel
            RemoverListaDetalle()

            Dim arreglo(3) As Object
            'crear el arreglo y lo llena con los controles (etiqueta de cantidad, etiqueta de nombre y boton de editar)
            arreglo(0) = crearEtiquetaCantidad(idproducto, 1)
            arreglo(1) = crearEtiquetaNombre(idproducto)
            arreglo(2) = crearBotonEditar(idproducto)
            'agrega el arreglo a la lista de controles
            listaControlesDetalle.AddLast(arreglo)

            Dim location = listaControlesDetalle(0)(0).Location
            'recorre la lista de controles para modificar las ubicaciones de cada control
            For i = 0 To listaControlesDetalle.Count - 1
                If listaControlesDetalle.Count <> 1 Then
                    'Si hay mas un elemento en la lista, pregunta si no esta en el ultimo valor de la lista
                    If (i + 1) < listaControlesDetalle.Count Then
                        'si no esta en el ultimo valor corre 47px hacia abajo cada uno de los controles
                        'al correrlos, se pone en la primera fila el ultimo producto agregado
                        '47 px es el alto de cada control mas el magen que hay entre el siguiente control
                        location = listaControlesDetalle(i)(0).Location
                        location.Y = location.Y + 47
                        listaControlesDetalle(i)(0).Location = location

                        location = listaControlesDetalle(i)(1).Location
                        location.Y = location.Y + 47
                        listaControlesDetalle(i)(1).Location = location

                        location = listaControlesDetalle(i)(2).Location
                        location.Y = location.Y + 47
                        listaControlesDetalle(i)(2).Location = location
                    Else
                        'si esta en el ultimo valor, pone las variables "x" y "y" en el valor inicial
                        'de esta manera los ultimos controles creados quedan en la primera linea
                        location.X = 0
                        location.Y = 5
                        listaControlesDetalle(listaControlesDetalle.Count - 1)(0).Location = location
                        location.X = 60
                        location.Y = 5
                        listaControlesDetalle(listaControlesDetalle.Count - 1)(1).Location = location
                        location.X = 460
                        location.Y = 0
                        listaControlesDetalle(listaControlesDetalle.Count - 1)(2).Location = location
                    End If
                End If
            Next i

            'se agreagan los controles al panel
            AgregarListaDetalle()

            'se actualizan las variables "Y" para la ubicacion del siguiente boton
            posYDetalle = listaControlesDetalle(0)(0).Location.Y + listaControlesDetalle(0)(0).Size.Height + 10
            posYBoton = listaControlesDetalle(0)(1).Location.Y + listaControlesDetalle(0)(1).Size.Height + 10

            'inserta el pedido de la orden
            ordenDatos = New OrdenDatos
            ordenDatos.InsertarDetalleOrden(idproducto, ordenActiva)

            listaDetallesOrden = ordenDatos.obtenerPedidosPorOrden(ordenActiva)

        End If
    End Sub

    'muestra la pantalla para editar un producto en especifico en el pedido de una orden
    Private Sub btnEditar_Click(sender As Object, e As EventArgs)
        'obtiene todos controles del panel de detalle que tengan en el name el cod del producto a actualizar
        Dim arregloBusqueda = pnlDetalle.Controls.Find(CType(sender, Button).Name, True)
        'recorre la lista de los controles encontrados
        For i = 0 To botonesOrdenes.Length - 1
            'recorre la lista de ordenes para encontrar el indice del boton de la orden seleccionada
            'el indice se va a usar para saber a cual orden darle click una vez que se actualizo el producto
            If botonesOrdenes(i).Name = ordenActiva Then
                'crea la instancia a la pantalla de la orden
                Dim modificarOrden As ModificarDetalleOrden = New ModificarDetalleOrden(CType(sender, Button).Name, ordenActiva, i, arregloBusqueda(0).Text, Me)
                'llama la ventana para modificar la orden
                modificarOrden.ShowDialog()
                Exit For
            End If
        Next
    End Sub

    Private Sub lblNombre_Click(sender As Object, e As EventArgs) Handles lblNombre.Click
        Dim productoDatos As New ProductoDatos
        Dim producto = productoDatos.obtenerProductoPorCod(CType(sender, Label).Name)
        Dim msj As New Mensaje
        msj.lblMensaje.Text = producto.Nombre_ & "  -  ₡" & CType(producto.PrecioVenta, Integer) & " -"
        msj.tipoMensaje("")
        msj.ShowDialog()
    End Sub

    'crea la etiqueta que se usa para mostrar el nombre del producto
    Private Function crearEtiquetaNombre(ByVal idProducto As Integer) As Label

        Dim lblNombre = New Label
        'el name de la etiqueta es el cod del producto y el texto es el nombre
        lblNombre.Name = idProducto
        lblNombre.Text = productoDatos.obtenerProductoPorCod(idProducto).Nombre_
        'caracteristicas de la etiqueta
        lblNombre.MaximumSize = New Size(New Point(500, 500))
        lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblNombre.Location = New Point(60, posYDetalle)
        lblNombre.Size() = New Size(390, 32)
        lblNombre.Cursor = Cursors.Hand
        lblNombre.ForeColor = Color.White

        AddHandler lblNombre.Click, AddressOf lblNombre_Click

        'retorna la etiqueta creada
        Return lblNombre
    End Function

    'Crea la etiqueta que contiene la cantidad de productos para una orden
    Private Function crearEtiquetaCantidad(ByVal idProducto As Integer, ByVal cantidad As Integer) As Label
        Dim lblCantidad = New Label
        'el nombre de la etiqueta es el id del producto y el texto que muestra es la cantidad que se recibio
        lblCantidad.Name = idProducto
        lblCantidad.Text = cantidad
        'agrega las demas caracteristicas a la etiqueta
        lblCantidad.MaximumSize = New Size(New Point(500, 500))
        lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblCantidad.Location = New Point(0, posYDetalle)
        lblCantidad.Size() = New Size(50, 32)
        lblCantidad.ForeColor = Color.White

        'retorna la etiqueta creada
        Return lblCantidad
    End Function

    'Crea el boton que se usa para editar los productos de una orden, recibe el id del producto que la orden
    Private Function crearBotonEditar(ByVal idProducto As Integer) As Button
        btnEditar = New Button
        'agrega al boton la imagen de editar
        btnEditar.Image = Global.SunChangSystem.My.Resources.Resources.btnEditar
        'el nombre del boton es el id del producto
        btnEditar.Name = idProducto
        'agrega al boton el resto de caracteristicas
        btnEditar.Location = New Point(460, posYBoton)
        btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        btnEditar.Size() = New Size(38, 32)
        btnEditar.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        btnEditar.FlatAppearance.BorderSize = 0
        btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnEditar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        btnEditar.AutoSize = True
        btnEditar.Cursor = Cursors.Hand

        'agrega el evento para cuando se le de click al boton
        AddHandler btnEditar.Click, AddressOf btnEditar_Click

        'retorna el boton creado
        Return btnEditar
    End Function

    'llama la pantalla para facturar una orden
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim factura As New Facturacion(ordenActiva, Me, EsUber)
        factura.ShowDialog()
    End Sub

    Private Sub FondoInicialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FondoInicialToolStripMenuItem.Click
        ''Instancia a la ventana de movimientos de efectivo
        Dim fondoInicial As New MovimientosEfectivo
        '' coloca la variable de fondoInicial en true para saber que es la accion que se va a realizar
        fondoInicial.fondoInicial = True
        '' llama al metodo para cargar y mostrar las nominaciones
        fondoInicial.cargarDenominaciones()
        fondoInicial.ShowDialog()
        '' coloca la variable de fondoInicial en false para saber que la accion ya se realizo
        fondoInicial.fondoInicial = False
    End Sub

    Private Sub CierreCajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CierreCajaToolStripMenuItem.Click
        ''Instancia a la ventana de movimientos de efectivo
        Dim fondoFinal As New MovimientosEfectivo
        '' coloca la variable de fondoFinal en true para saber que es la accion que se va a realizar
        fondoFinal.fondoFinal = True
        '' llama al metodo para cargar y mostrar las nominaciones
        fondoFinal.cargarDenominaciones()
        fondoFinal.ShowDialog()
        '' coloca la variable de fondoFinal en false para saber que la accion ya se realizo
        fondoFinal.fondoFinal = False


    End Sub

    Private Sub PagoDeFacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagoDeFacturasToolStripMenuItem.Click
        Dim pagoFacturas As New PagoFactura
        pagoFacturas.ShowDialog()
    End Sub

    Private Sub SalidasDeEfectivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalidasDeEfectivoToolStripMenuItem.Click
        ''Instancia a la ventana de movimientos de efectivo
        Dim salidaEfectivo As New MovimientosEfectivo
        '' coloca la variable de salidasEfectivo en true para saber que es la accion que se va a realizar
        salidaEfectivo.salidasEfectivo = True
        '' llama al metodo para cargar y mostrar las nominaciones
        salidaEfectivo.cargarDenominaciones()
        salidaEfectivo.ShowDialog()
        '' coloca la variable de salidasEfectivo en false para saber que la accion ya se realizo
        salidaEfectivo.salidasEfectivo = False
    End Sub

    Private Sub IntroduccionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IntroduccionesToolStripMenuItem.Click
        ''Instancia a la ventana de movimientos de efectivo
        Dim introduccionesEfectivo As New MovimientosEfectivo
        '' coloca la variable de introducciones en true para saber que es la accion que se va a realizar
        introduccionesEfectivo.introducciones = True
        '' llama al metodo para cargar y mostrar las nominaciones
        introduccionesEfectivo.cargarDenominaciones()
        introduccionesEfectivo.ShowDialog()
        '' coloca la variable de introducciones en false para saber que la accion ya se realizo
        introduccionesEfectivo.introducciones = False
    End Sub

    'llama la pantalla para crear una nueva orden
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnNuevaOrden.Click
        Dim nuevaOrden As New NuevaOrden(Me)
        'muestra la ventana
        nuevaOrden.ShowDialog()
    End Sub

    'metodo para eliminar una orden
    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        ordenDatos = New OrdenDatos
        'envia la orden a eliminar a la capa de datos
        ordenDatos.eliminarOrden(ordenActiva)
        'carga las ordenes para actualizar la pantalla
        mostrarOrdenes(0, EsUber)
    End Sub

    'metodo para cerrar la sesion
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        'cierra la ventana acatual
        Me.Close()
        'muestra la ventana de inicio de sesion
        InicioSesion.Show()
    End Sub

    'este metodo se llama desde ModificarDetalleOrden para seleccionar la orden que se esta
    'modificando actualmente, darle click y actualizar la pantalla
    Public Sub clickBoton(ByVal indice As Integer)
        'recibe el id de la orden a mostrar y le invoca un evento click
        botonesOrdenes(indice).PerformClick()
    End Sub

    'mueve los productos hacia la derecha
    Private Sub Button3_Click_1(sender As Object, e As EventArgs)
        'cuando se mueve hacia la derecha se corren 2 columnas de categorias (340 px)
        pnlCategorias.AutoScrollPosition = New Point(-pnlCategorias.AutoScrollPosition.X + 340, 0)
    End Sub

    'mueve los productos hacia la izquierda
    Private Sub Button4_Click(sender As Object, e As EventArgs)
        'cuando se mueve hacia la izquierda se corren 2 columnas de categorias (340 px)
        pnlCategorias.AutoScrollPosition = New Point(-pnlCategorias.AutoScrollPosition.X - 340, 0)
    End Sub

    'El timer se usa para mostrar la fecha en la pantalla, se actualiza cada segundo
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Obtiene la fecha actual de la maquina
        Dim dateValue As Date = DateTime.Now.ToString()
        'a la fecha obtenida le da el formato necesario para mostrar la fecha y la pone en la etiqueta
        txtHora.Text = dateValue.ToString("F")
        'muestra el nombre del cajero activo en la sesion
        txtNombreCajero.Text = InicioSesion.session.EmpleadoSG.NombreSG & " " & InicioSesion.session.EmpleadoSG.Apellido1SG
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        agregarProductoADetalleOrden(cbxProducto.SelectedValue)
    End Sub

    Private Sub ARQUEOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ARQUEOToolStripMenuItem.Click
        Dim CierreFinal As New Arqueo
        CierreFinal.Show()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        pnlDetalle.Controls.Clear()
        btnBorrar.Visible = False
        btnImprimir.Visible = False
        pnlPrinCategorias.Visible = False
        pnlPrinProd.Visible = False

    End Sub

    Private Sub AnularFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularFacturaToolStripMenuItem.Click
        Dim anular_factura As New Anular
        anular_factura.ShowDialog()
    End Sub

    Private Sub VentasXDíaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasXDíaToolStripMenuItem.Click
        Dim reporte As New ReporteAdministrativos
        reporte.ventas_dia = True
        reporte.ShowDialog()
        reporte.ventas_dia = False

    End Sub

    Private Sub Ordenes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        InicioSesion.Show()
    End Sub

    Private Sub CategoríaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoríaToolStripMenuItem.Click
        Dim categorias As New Categorias
        categorias.ShowDialog()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim productos As New Productos
        productos.ShowDialog()
    End Sub

    Private Sub timerLlamaMesero_Tick(sender As Object, e As EventArgs) Handles timerLlamaMesero.Tick
        ordenDatos = New OrdenDatos
        Try
            Dim ordenesMesero = ordenDatos.verificaLlamadaMesero()
            If ordenesMesero.Count <> 0 Then
                TimerReproduceSonido.Enabled = True
                For i = 0 To ordenesMesero.Count - 1
                    Dim boton = CType((pnlOrdenes.Controls.Find(ordenesMesero(i).NumOrden, True)(0)), Button)
                    If boton.ForeColor = Color.Red Then
                        boton.ForeColor = Color.White
                    Else
                        boton.ForeColor = Color.Red
                    End If
                Next i
            Else
                TimerReproduceSonido.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TimerReproduceSonido_Tick(sender As Object, e As EventArgs) Handles TimerReproduceSonido.Tick

        Dim ruta = My.Application.Info.DirectoryPath
        Dim s As New System.Media.SoundPlayer(ruta + "\Windows Proximity Notification.WAV")
        s.Play()
    End Sub

    Private Sub ImpuestoDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpuestoDeVentasToolStripMenuItem.Click
        Dim reporte_admin As New ReporteAdministrativos

        reporte_admin.cbxUsuario.Visible = False
        reporte_admin.txtCodUsuario.Visible = False
        reporte_admin.impvtas = True
        reporte_admin.ShowDialog()
        reporte_admin.impvtas = False

    End Sub

    Private Sub alertaProductosListos(ByVal idOrden As Integer)
        Dim pedidosListos = ordenDatos.obtenerProductosPreparados(idOrden)
        For i = 0 To pedidosListos.Count - 1
            For j = 0 To pnlDetalle.Controls.Count - 1
                If pnlDetalle.Controls(j).Name = pedidosListos(i).CodProducto Then
                    pnlDetalle.Controls(j).ForeColor = Color.Green
                    j = j + 1
                    pnlDetalle.Controls(j).ForeColor = Color.Green
                    j = j + 1
                End If
            Next j
        Next i

    End Sub

    Private Sub ValesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValesToolStripMenuItem.Click
        Dim vales As New Vales
        vales.ShowDialog()
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        Dim proveedor As New NuevoProveedor()
        proveedor.ShowDialog()
    End Sub

    Private Sub ModificarFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarFacturaToolStripMenuItem.Click
        Dim ordenesFacturadas As New ModificarOrdenesFacturadas
        ordenesFacturadas.ShowDialog()
    End Sub

    Private Sub CierreDeCajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CierreDeCajaToolStripMenuItem.Click
        Dim formularioDeVenta As New CierreCaja
        formularioDeVenta.ShowDialog()
    End Sub
End Class
