Public Class Categorias
    Dim modificando As Boolean = False
    Dim id_categoria_modifica As Int16 = 0
    ' instancia de la clase a datos
    Dim categoria_datos As TipoProductoDatos
    Dim msj As Mensaje


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        btnEliminar.Enabled = False
        btnNuevo.Enabled = False
        btnSubcategorias.Enabled = False

        ' llama al metodo que varga todas las categorias existentes
        cargarCategorias()

    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        ' se obtiene el nombre de la categoria
        Dim nombre As String = txtNombre.Text
        ' se obtiene si es bebida o no
        Dim bebida As Char = IIf(cbxBebida.Checked, "S", "N")
        ' instancia de la clase a datos
        categoria_datos = New TipoProductoDatos
        ' se valida que se este ingresando texto
        If nombre.Trim.Length > 0 Then
            If modificando Then
                If categoria_datos.modificarTipoProducto(New TipoProducto(id_categoria_modifica, nombre, bebida)) Then
                    modificando = False
                    'llama al metodo que limpiar los campos
                    limpiarEspacios()
                    'llama al metodo que carga las categorias
                    cargarCategorias()
                End If
            Else
                If categoria_datos.ingresarTipoProducto(New TipoProducto(0, nombre, bebida)) Then
                    'llama al metodo que limpiar los campos
                    limpiarEspacios()
                    'llama al metodo que carga las categorias
                    cargarCategorias()
                End If
            End If
        Else
            msj = New Mensaje
            msj.lblMensaje.Text = "Ingrese un nombre para la categoria"
            msj.tipoMensaje("error")
            msj.ShowDialog()
        End If
    End Sub

    Private Sub cargarCategorias()
        ' instancia de la clase a datos
        categoria_datos = New TipoProductoDatos
        ' se asignan la informacion al data grid view
        dgvCategorias.DataSource = categoria_datos.obtenerTodasCategorias
    End Sub

    ' metodo para limpiar los espacios del form
    Private Sub limpiarEspacios()
        txtNombre.Text = ""
        cbxBebida.Checked = False
        btnEliminar.Enabled = False
        btnSubcategorias.Enabled = False
        btnNuevo.Enabled = False
    End Sub

    Private Sub dgvCategorias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategorias.CellClick
        If (e.RowIndex > -1) Then
            Dim categoria_id = dgvCategorias.Item(0, e.RowIndex).Value

            Dim tipo_producto As TipoProducto
            tipo_producto = categoria_datos.obtenerCategoriaPorId(categoria_id)
            If Not IsNothing(tipo_producto) Then
                btnEliminar.Enabled = True
                btnSubcategorias.Enabled = True
                btnNuevo.Enabled = True
                modificando = True
                id_categoria_modifica = tipo_producto.IdTipoProductoSG
                txtNombre.Text = tipo_producto.DescripcionSG
                cbxBebida.Checked = IIf(tipo_producto.BebidaSG = "S", True, False)
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim id_categoria_eliminar As Int16 = dgvCategorias.Item(0, dgvCategorias.CurrentRow.Index).Value
        If categoria_datos.eliminarTipoProducto(id_categoria_eliminar) Then
            'llama al metodo que limpiar los campos
            limpiarEspacios()
            'llama al metodo que carga las categorias
            cargarCategorias()
        End If
    End Sub


    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        'llama al metodo que limpiar los campos
        limpiarEspacios()
        modificando = False
    End Sub

    Private Sub btnSubcategorias_Click(sender As Object, e As EventArgs) Handles btnSubcategorias.Click
        Dim categ = categoria_datos.obtenerCategoriaPorId(id_categoria_modifica)
        Dim subcategorias As New Subcategorias(categ)
        subcategorias.ShowDialog()
    End Sub

End Class