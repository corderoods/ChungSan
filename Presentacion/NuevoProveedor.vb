Public Class NuevoProveedor
    Dim proveedorDatos As ProveedorDatos
    Dim proveedores As List(Of Proveedor)

    Dim accion As String
    Dim proveedorActivo As Proveedor

    Dim nuevaOrden As NuevaOrden

    Public Sub New()
        Me.nuevaOrden = nuevaOrden

        accion = "I"
        proveedorDatos = New ProveedorDatos
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
    End Sub

    Private Sub NuevoProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarProveedores()
        btnNuevo.PerformClick()
    End Sub


    Public Sub cargarProveedores()
        Me.proveedores = proveedorDatos.obtenerProveedores()
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("Codigo", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Nombre", System.Type.GetType("System.String"))
        dt.Columns.Add("Telefono", System.Type.GetType("System.String"))

        Dim dr As DataRow = dt.NewRow
        dr = dt.NewRow
        For i = 0 To proveedores.Count - 1
            If proveedores(i).NombreProveedor.Trim.Length <> 0 Then
                dr = dt.NewRow
                dr("Codigo") = proveedores(i).CodigoProveedor
                dr("Nombre") = proveedores(i).NombreProveedor
                dr("Telefono") = proveedores(i).TelefonoProveedor
                dt.Rows.Add(dr)
            End If

        Next i
        dtgProveedores.DataSource = dt
        dtgProveedores.Columns(0).Width = 50
        dtgProveedores.Columns(1).Width = 230
    End Sub


    Private Sub dtgProveedores_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtgProveedores.CellEnter
        Try
            accion = "M"
            btnEliminar.Enabled = True
            btnGuardar.Enabled = True
            If (e.RowIndex > -1) Then
                Dim cod = dtgProveedores.Item(0, e.RowIndex).Value
                proveedorActivo = proveedorDatos.obtenerProveedorPorId(cod)
                txtNombre.Text = proveedorActivo.NombreProveedor
                txtTelefono.Text = proveedorActivo.TelefonoProveedor
                txtDireccion.Text = proveedorActivo.DireccionProveedor
                txtObservaciones.Text = proveedorActivo.ObservacionesProveedor
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        accion = "I"
        txtNombre.Text = ""
        txtTelefono.Text = ""
        txtDireccion.Text = ""
        txtObservaciones.Text = ""
        btnEliminar.Enabled = False
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        proveedorDatos.EliminarProveedor(proveedorActivo)
        cargarProveedores()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If txtNombre.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar un Nombre")
            Exit Sub
        End If

        Dim proveedor = New Proveedor
        proveedor.NombreProveedor = txtNombre.Text.Trim
        proveedor.TelefonoProveedor = txtTelefono.Text.Trim
        proveedor.DireccionProveedor = txtDireccion.Text.Trim
        proveedor.ObservacionesProveedor = txtObservaciones.Text.Trim

        If accion = "I" Then
            If proveedorDatos.InsertarProveedor(proveedor) Then
                ' limpia los campos de texto
                'btnNuevo.PerformClick()
            Else
                Dim mensaje As New Mensaje
                mensaje.lblMensaje.Text = "Proveedor no ingresado"
                mensaje.ShowDialog()
            End If
        Else
            proveedor.CodigoProveedor = proveedorActivo.CodigoProveedor
            If proveedorDatos.actualizarProveedor(proveedor) Then
                'btnNuevo.PerformClick()
            Else
                Dim mensaje As New Mensaje
                mensaje.lblMensaje.Text = "Proveedor no actualizado"
                mensaje.ShowDialog()
            End If
        End If
        cargarProveedores()
        btnNuevo.PerformClick()
    End Sub

End Class