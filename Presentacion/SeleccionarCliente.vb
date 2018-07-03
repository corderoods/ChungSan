Public Class SeleccionarCliente

    Dim clienteDatos As New ClienteDatos
    Dim clientes As New List(Of Cliente)
    Dim facturacion As Facturacion

    Public Sub New(ByVal facturacion As Facturacion)
        Me.facturacion = facturacion
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

    End Sub

    Private Sub SeleccionarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarClientes()

    End Sub

    Public Sub cargarClientes()
        clientes = clienteDatos.obtenerClientes()

        Dim dt As New DataTable
        dt.Columns.Add("Codigo", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Nombre", System.Type.GetType("System.String"))

        Dim dr As DataRow = dt.NewRow
        Dim a As Integer = 0
        For i = 0 To clientes.Count - 1
            dr = dt.NewRow
            dr("Codigo") = clientes(i).CodClienteSG
            dr("Nombre") = clientes(i).NombreClienteSG '& " " & clientes(i).ApellidoSG
            dt.Rows.Add(dr)
            cbxClientes.ValueMember = "Codigo"
            cbxClientes.DisplayMember = "Nombre"
            cbxClientes.DataSource = dt
        Next i
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim nuevoCliente As New NuevoCliente(Nothing, Me)
        nuevoCliente.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Facturacion.cod_cliente = CDbl(Me.cbxClientes.SelectedValue)
        facturacion.txtNombre.Text = Me.cbxClientes.Text
        'Me.Close()
    End Sub

End Class
