Public Class InsertarDireccion

    Dim cliente As Cliente
    Dim direccionDatos As New ClienteDireccionDatos
    Dim accion As String
    Dim direccionActiva As ClienteDireccion

    Public Sub New(ByVal cliente As Cliente)
        Me.cliente = cliente
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub InsertarDireccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtNombre.Text = cliente.NombreClienteSG

        cargarDirecciones()
        txtDireccion.Text = ""
        accion = "I"

    End Sub

    Public Sub cargarDirecciones()
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("Cod", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Direccion", System.Type.GetType("System.String"))

        Dim dr As DataRow = dt.NewRow
        dr = dt.NewRow
        For i = 0 To cliente.Direcciones_.Count - 1
            If cliente.Direcciones_(i).Direccion_.Trim.Length <> 0 Then
                dr = dt.NewRow
                dr("Cod") = cliente.Direcciones_(i).CodDireccion_
                dr("Direccion") = cliente.Direcciones_(i).Direccion_
                dt.Rows.Add(dr)
            End If

        Next i
        dtgDirecciones.DataSource = dt
        dtgDirecciones.Columns(0).Width = 50
        dtgDirecciones.Columns(1).Width = 355
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If accion = "I" Then
            direccionDatos.insertarDireccion(cliente, txtDireccion.Text)
        ElseIf accion = "M" Then
            direccionDatos.actualizarDireccion(direccionActiva.CodDireccion_, txtDireccion.Text)
        End If
        cliente.Direcciones_ = direccionDatos.obtenerDireccionesPorCliente(cliente)
        cargarDirecciones()

        txtDireccion.Text = ""
        accion = "I"
    End Sub

    Private Sub dtgClientes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDirecciones.CellEnter
        Try
            accion = "M"
            If (e.RowIndex > -1) Then
                Dim cod = dtgDirecciones.Item(0, e.RowIndex).Value
                direccionActiva = direccionDatos.obtenerDireccionPorId(cod)
                txtDireccion.Text = direccionActiva.Direccion_
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cargarDirecciones()
        txtDireccion.Text = ""
        accion = "I"
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        direccionDatos.eliminarDireccion(direccionActiva)
        'dtgClientes.Columns.Clear()
        cliente.Direcciones_ = direccionDatos.obtenerDireccionesPorCliente(cliente)
        cargarDirecciones()

        txtDireccion.Text = ""
        accion = "I"
    End Sub
End Class