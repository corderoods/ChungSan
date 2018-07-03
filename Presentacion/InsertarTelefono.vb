Public Class InsertarTelefono

    Dim cliente As Cliente
    Dim telefonoDatos As New ClienteTelefonoDatos
    Dim accion As String
    Dim telefonoActivo As ClienteTelefono

    Public Sub New(ByVal cliente As Cliente)
        Me.cliente = cliente
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub InsertarTelefono_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtNombre.Text = cliente.NombreClienteSG

        cargarTelefonos()
        txtTelefono.Text = ""
        accion = "I"

    End Sub

    Public Sub cargarTelefonos()
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("Cod", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Telefono", System.Type.GetType("System.String"))

        Dim dr As DataRow = dt.NewRow
        dr = dt.NewRow
        For i = 0 To cliente.Telefonos_.Count - 1
            If cliente.Telefonos_(i).Telefono_.Trim.Length <> 0 Then
                dr = dt.NewRow
                dr("Cod") = cliente.Telefonos_(i).CodTelefono_
                dr("telefono") = cliente.Telefonos_(i).Telefono_
                dt.Rows.Add(dr)
            End If

        Next i
        dtgTelefonos.DataSource = dt
        dtgTelefonos.Columns(0).Width = 50
        dtgTelefonos.Columns(1).Width = 100
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If accion = "I" Then
            telefonoDatos.insertarTelefono(cliente, txtTelefono.Text)
        ElseIf accion = "M" Then
            telefonoDatos.actualizarTelefono(telefonoActivo.CodTelefono_, txtTelefono.Text)
        End If
        cliente.Telefonos_ = telefonoDatos.obtenerTelefonosPorCliente(cliente)
        cargarTelefonos()

        txtTelefono.Text = ""
        accion = "I"
    End Sub

    Private Sub dtgClientes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtgTelefonos.CellEnter
        accion = "M"
        If (e.RowIndex > -1) Then
            Dim cod = dtgTelefonos.Item(0, e.RowIndex).Value
            telefonoActivo = telefonoDatos.obtenerTelefonoPorId(cod)
            txtTelefono.Text = telefonoActivo.Telefono_
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cargarTelefonos()
        txtTelefono.Text = ""
        accion = "I"
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        telefonoDatos.eliminarTelefono(telefonoActivo)
        'dtgClientes.Columns.Clear()
        cliente.Telefonos_ = telefonoDatos.obtenerTelefonosPorCliente(cliente)
        cargarTelefonos()

        txtTelefono.Text = ""
        accion = "I"
    End Sub

    Private Sub txtTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono.TextChanged

    End Sub
End Class