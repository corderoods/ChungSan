Public Class NuevoCliente

    Dim clienteDatos As ClienteDatos
    Dim clientes As List(Of Cliente)

    Dim accion As String
    Dim clienteActivo As Cliente

    Dim nuevaOrden As NuevaOrden
    Dim seleccionarCliente As SeleccionarCliente

    Public Sub New(ByVal nuevaOrden As NuevaOrden, ByVal seleccionarCliente As SeleccionarCliente)
        Me.nuevaOrden = nuevaOrden
        Me.seleccionarCliente = seleccionarCliente

        accion = "I"
        clienteDatos = New ClienteDatos
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

    End Sub

    Private Sub NuevoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarClientes()
    End Sub

    Public Sub cargarClientes()
        Me.clientes = clienteDatos.obtenerClientes
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("Codigo", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Nombre", System.Type.GetType("System.String"))

        Dim dr As DataRow = dt.NewRow
        dr = dt.NewRow
        For i = 0 To clientes.Count - 1
            If clientes(i).NombreClienteSG.Trim.Length <> 0 Then
                dr = dt.NewRow
                dr("Codigo") = clientes(i).CodClienteSG
                dr("Nombre") = clientes(i).NombreClienteSG
                dt.Rows.Add(dr)
            End If

        Next i
        dtgClientes.DataSource = dt
        dtgClientes.Columns(0).Width = 50
        dtgClientes.Columns(1).Width = 230
    End Sub


    Private Sub dtgClientes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtgClientes.CellEnter
        Try
            accion = "M"
            btnNuevaDireccion.Enabled = True
            btnNuevoTelefono.Enabled = True
            btnEliminar.Enabled = True
            If (e.RowIndex > -1) Then
                Dim cod = dtgClientes.Item(0, e.RowIndex).Value
                clienteActivo = clienteDatos.obtenerClientePorId(cod)
                txtNombre.Text = clienteActivo.NombreClienteSG
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        accion = "I"
        txtNombre.Text = ""
        btnNuevoTelefono.Enabled = False
        btnNuevaDireccion.Enabled = False
        btnEliminar.Enabled = False
    End Sub

    Private Sub btnNuevoTelefono_Click(sender As Object, e As EventArgs) Handles btnNuevoTelefono.Click
        Dim insertarTelefono As New InsertarTelefono(clienteActivo)
        insertarTelefono.ShowDialog()
    End Sub

    Private Sub btnNuevaDireccion_Click(sender As Object, e As EventArgs) Handles btnNuevaDireccion.Click
        Dim insertarDireccion As New InsertarDireccion(clienteActivo)
        insertarDireccion.ShowDialog()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        If txtNombre.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar un Nombre")
            Exit Sub
        End If

        Dim cliente = New Cliente
        cliente.NombreClienteSG = txtNombre.Text.Trim

        If accion = "I" Then
            If clienteDatos.InsertarCliente(cliente) Then
                ' limpia los campos de texto
                txtNombre.Text = ""
                accion = "I"
            Else
                Dim mensaje As New Mensaje
                mensaje.lblMensaje.Text = "Cliente no ingresado"
                mensaje.ShowDialog()
            End If
        Else
            cliente.CodClienteSG = clienteActivo.CodClienteSG
            If clienteDatos.actualizarCliente(cliente) Then
                ' limpia los campos de texto
                txtNombre.Text = ""
                accion = "I"
            Else
                Dim mensaje As New Mensaje
                mensaje.lblMensaje.Text = "Cliente no actualizado"
                mensaje.ShowDialog()
            End If
        End If
        cargarClientes()
    End Sub

    Private Sub NuevoCliente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Me.nuevaOrden Is Nothing Then
            Me.seleccionarCliente.cargarClientes()
        Else
            Me.nuevaOrden.cargarClientes()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        clienteDatos.eliminarCliente(clienteActivo.CodClienteSG)
        cargarClientes()
    End Sub
End Class