Public Class Productos

    Dim productos_datos As New ProductoDatos
    Dim subcategoriaDatos As New SubcategoriaDatos
    Dim categorias As New TipoProductoDatos
    Dim modificando As Boolean = False
    Dim id_producto_modifica As Int16 = 0
    Dim msj As Mensaje

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' se obtiene la lista de todos los proveedores en la base de datos
        Dim listaCategorias As New DataTable
        listaCategorias = categorias.obtenerTodasCategorias()

        ' datatable para ir agregando los proveedores
        Dim data_table_proveedores As New DataTable
        data_table_proveedores.Columns.Add("Codigo", System.Type.GetType("System.Int32"))
        data_table_proveedores.Columns.Add("Nombre", System.Type.GetType("System.String"))

        ' Se llenan los datos del combo
        Dim i As Int32
        For i = 0 To (listaCategorias.Rows.Count - 1)
            cbxCategoria.Items.Add(listaCategorias.Rows(i))
            Dim data_row_proveedores As DataRow = data_table_proveedores.NewRow
            data_row_proveedores = data_table_proveedores.NewRow
            data_row_proveedores("Codigo") = listaCategorias.Rows(i).Item(0)
            data_row_proveedores("Nombre") = listaCategorias.Rows(i).Item(1)
            data_table_proveedores.Rows.Add(data_row_proveedores)
            cbxCategoria.ValueMember = "Codigo"
            cbxCategoria.DisplayMember = "Nombre"
        Next

        cbxCategoria.DataSource = data_table_proveedores

        limpiarCampos()
        'llama al metodo que carga los productos
        cargarProductos()

        lblSubcategoria.Visible = False
        cbxSubcategoria.Visible = False
    End Sub

    Private Sub cargarProductos()

        ' se obtiene y se asigna la lista de productos
        dgvProductos.DataSource = productos_datos.obtenerTodosProductos()


    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        ' se obtienen los datos de la interfaz
        Dim nombreProducto As String = txtNombre.Text
        If nombreProducto.Trim.Length > 1 Then
            Try
                Dim precioProducto As Double = CDbl(txtPrecio.Text.Trim)
                Dim categoria As Integer = cbxCategoria.SelectedValue

                ' se crea el obj de producto
                Dim producto As New Producto
                producto.Nombre_ = nombreProducto
                producto.PrecioVenta = precioProducto
                producto.IdTipoProducto = categoria
                producto.Promocion_ = 0
                producto.AfectaInventario = 0
                producto.CantDisponible = 0
                producto.Descuento_ = 0
                producto.CodBarra = 0
                producto.Compuesto_ = 0

                If cbSubcategoria.Checked Then
                    producto.Subcategoria_ = cbxSubcategoria.SelectedValue
                Else
                    producto.Subcategoria_ = -1
                End If


                ' instancia a la clase para ingresar
                Dim productos_datos As New ProductoDatos

                If precioProducto < 1 Then
                    msj = New Mensaje
                    msj.lblMensaje.Text = "Ingrese un precio correcto"
                    msj.tipoMensaje("error")
                    msj.ShowDialog()
                Else
                    If modificando Then
                        producto.CodProducto = id_producto_modifica
                        If (productos_datos.modificarProducto(producto)) Then
                            modificando = False
                            'llama al metodo que limpiar los campos
                            limpiarCampos()
                            'llama al metodo que carga los productos
                            cargarProductos()

                        End If
                    Else
                        If productos_datos.ingresarProducto(producto) Then
                            'llama al metodo que limpiar los campos
                            limpiarCampos()
                            'llama al metodo que carga los productos
                            cargarProductos()

                        End If
                    End If
                End If
            Catch ex As InvalidCastException
                msj = New Mensaje
                msj.lblMensaje.Text = "Ingrese un monto para el precio"
                msj.tipoMensaje("error")
                msj.ShowDialog()
            End Try
        Else
            msj = New Mensaje
            msj.lblMensaje.Text = "Ingrese un nombre para el producto"
            msj.tipoMensaje("error")
            msj.ShowDialog()
        End If

    End Sub

    Private Sub limpiarCampos()
        ' se limpian los espacios
        txtNombre.Text = ""
        txtPrecio.Text = ""
        cbxCategoria.SelectedValue = 1
        btnEliminar.Visible = False
        btnNuevo.Visible = False
        cbSubcategoria.Checked = False
        cbxSubcategoria.Visible = False
        lblSubcategoria.Visible = False
    End Sub

    Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        If (e.RowIndex > -1) Then
            Dim producto_id = dgvProductos.Item(0, e.RowIndex).Value
            Dim producto As Producto
            producto = productos_datos.obtenerProductoPorCod(producto_id)
            If Not IsNothing(producto) Then
                btnEliminar.Visible = True
                btnNuevo.Visible = True
                modificando = True
                id_producto_modifica = producto_id
                txtNombre.Text = producto.Nombre_
                txtPrecio.Text = producto.PrecioVenta.ToString()
                cbxCategoria.SelectedValue = producto.IdTipoProducto

                If producto.Subcategoria_ <> 0 Then
                    lblSubcategoria.Visible = True
                    cbxSubcategoria.Visible = True
                    cbSubcategoria.Checked = True
                    cbxSubcategoria.SelectedValue = producto.Subcategoria_
                Else
                    lblSubcategoria.Visible = False
                    cbxSubcategoria.Visible = False
                    cbSubcategoria.Checked = False
                End If
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim id_producto_eliminar As Int16 = dgvProductos.Item(0, dgvProductos.CurrentRow.Index).Value
        If productos_datos.eliminarProducto(id_producto_eliminar) Then
            limpiarCampos()
            cargarProductos()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiarCampos()
        modificando = False
    End Sub


    Private Sub cbSubcategoria_CheckedChanged(sender As Object, e As EventArgs) Handles cbSubcategoria.CheckedChanged
        If cbSubcategoria.Checked Then
            If cbxSubcategoria.Items.Count = 0 Then
                cbSubcategoria.Checked = False
                lblSubcategoria.Visible = False
                cbxSubcategoria.Visible = False
                msj = New Mensaje
                msj.lblMensaje.Text = "Este Tipo de Producto no tiene Subcategorias"
                msj.tipoMensaje("error")
                msj.ShowDialog()
            Else
                lblSubcategoria.Visible = True
                cbxSubcategoria.Visible = True
            End If
        Else
            lblSubcategoria.Visible = False
            cbxSubcategoria.Visible = False
        End If
    End Sub

    Private Sub cbxCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCategoria.SelectedIndexChanged
        Dim categoria = CType(sender, ComboBox).SelectedValue
        cbxSubcategoria.DataSource = subcategoriaDatos.obtenerSubcategoriasPorTipoProducto(categoria)
        cbxSubcategoria.DisplayMember = "Nombre"
        cbxSubcategoria.ValueMember = "Codigo"

        If cbxSubcategoria.Items.Count = 0 Then
            If cbSubcategoria.Checked Then
                cbSubcategoria.Checked = False
                lblSubcategoria.Visible = False
                cbxSubcategoria.Visible = False
            End If
        End If
    End Sub

End Class