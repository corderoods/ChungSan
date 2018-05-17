Public Class Subcategorias

    Dim modificando As Boolean = False
    Dim subcategoriaActiva As New Subcategoria
    ' instancia de la clase a datos
    Dim subcategoriaDatos As SubcategoriaDatos
    Dim msj As Mensaje
    Dim tipoProducto As TipoProducto

    Public Sub New(ByVal tipoProducto As TipoProducto)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.tipoProducto = tipoProducto
        btnEliminar.Visible = False
        btnNuevo.Visible = False

        ' llama al metodo que varga todas las categorias existentes
        cargarSubcategorias()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        lblTitulo.Text = "Subcategorias de " & tipoProducto.DescripcionSG
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        ' instancia de la clase a datos
        subcategoriaDatos = New SubcategoriaDatos
        ' se valida que se este ingresando texto

        Dim subcategoria As New Subcategoria
        subcategoria.IdSubcategoria_ = subcategoriaActiva.IdSubcategoria_
        subcategoria.Nombre_ = txtNombre.Text.Trim
        subcategoria.Categoria_ = tipoProducto.IdTipoProductoSG

        If txtNombre.Text.Trim.Length > 0 Then
            If modificando Then
                If subcategoriaDatos.modificarSubcategoria(subcategoria) Then
                    modificando = False
                    'llama al metodo que limpiar los campos
                    limpiarEspacios()
                    'llama al metodo que carga las categorias
                    cargarSubcategorias()
                End If
            Else
                If subcategoriaDatos.ingresarSubcategoria(subcategoria) Then
                    'llama al metodo que limpiar los campos
                    limpiarEspacios()
                    'llama al metodo que carga las categorias
                    cargarSubcategorias()
                End If
            End If
        Else
            msj = New Mensaje
            msj.lblMensaje.Text = "Ingrese un nombre para la Subcategoria"
            msj.tipoMensaje("error")
            msj.ShowDialog()
        End If
    End Sub

    Private Sub cargarSubcategorias()
        ' instancia de la clase a datos
        subcategoriaDatos = New SubcategoriaDatos
        ' se asignan la informacion al data grid view
        dgvCategorias.DataSource = subcategoriaDatos.obtenerSubcategoriasPorTipoProducto(tipoProducto.IdTipoProductoSG)
    End Sub

    ' metodo para limpiar los espacios del form
    Private Sub limpiarEspacios()
        txtNombre.Text = ""
        btnEliminar.Visible = False
        btnNuevo.Visible = False
    End Sub

    Private Sub dgvCategorias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategorias.CellClick
        If (e.RowIndex > -1) Then
            Dim categoria_id = dgvCategorias.Item(0, e.RowIndex).Value

            subcategoriaActiva = subcategoriaDatos.obtenerSubategoriaPorId(categoria_id)
            If Not IsNothing(subcategoriaActiva) Then
                btnEliminar.Visible = True
                btnNuevo.Visible = True
                modificando = True

                txtNombre.Text = subcategoriaActiva.Nombre_
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim id_categoria_eliminar As Int16 = dgvCategorias.Item(0, dgvCategorias.CurrentRow.Index).Value
        If subcategoriaDatos.eliminarSubcategoria(id_categoria_eliminar) Then
            'llama al metodo que limpiar los campos
            limpiarEspacios()
            'llama al metodo que carga las categorias
            cargarSubcategorias()
        End If
    End Sub


    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        'llama al metodo que limpiar los campos
        limpiarEspacios()
        modificando = False
    End Sub

End Class