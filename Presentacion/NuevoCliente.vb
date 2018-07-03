Public Class NuevoCliente

    Dim clienteDatos As ClienteDatos
    Dim direccionDatos As New ClienteDireccionDatos
    Dim telefonoDatos As New ClienteTelefonoDatos
    Dim emailDatos As New ClienteEmailDatos
    Dim clientes As List(Of Cliente)

    Dim accion As String
    Dim clienteActivo As Cliente
    Dim direc As ClienteDireccion
    Dim tele As ClienteTelefono
    Dim email As ClienteEmail

    Dim nuevaOrden As NuevaOrden
    Dim seleccionarCliente As SeleccionarCliente

    Public Sub New(ByVal nuevaOrden As NuevaOrden, ByVal seleccionarCliente As SeleccionarCliente)
        Me.nuevaOrden = nuevaOrden
        Me.seleccionarCliente = seleccionarCliente

        accion = "I"
        clienteDatos = New ClienteDatos
        direccionDatos = New ClienteDireccionDatos
        telefonoDatos = New ClienteTelefonoDatos
        emailDatos = New ClienteEmailDatos

        'checkDiplomatico.Visible = False
        ' checkDiplomatico.Checked = False
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

        txtApellido1.Text = ""
        txtApellido2.Text = ""
        txtCorreo.Text = ""
        txtIdentificacion.Text = ""
        txtOtrasSenas.Text = ""
        txtTelefono.Text = ""
        cbTipoIden.SelectedIndex = 0
    End Sub


    Private Sub dtgClientes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtgClientes.CellEnter
        Try
            accion = "M"
            btnNuevaDireccion.Enabled = True
            btnNuevoTelefono.Enabled = True
            btnEliminar.Enabled = True
            If (e.RowIndex > -1) Then
                Dim cod = dtgClientes.Item(0, e.RowIndex).Value
                'Carga los objetos
                clienteActivo = clienteDatos.obtenerClientePorId(cod)
                tele = telefonoDatos.obtenerTelefonoPorId(cod)
                direc = direccionDatos.obtenerDireccionPorId(cod)
                email = emailDatos.obtenerEmailPorId(cod)

                'Asigna la informacion
                txtNombre.Text = clienteActivo.NombreClienteSG
                txtIdentificacion.Text = clienteActivo.identificacionSG
                cbTipoIden.SelectedIndex = clienteActivo.tipoIdentSG
                If cbTipoIden.SelectedIndex = 5 Then
                    checkDiplomatico.Visible = True
                    If clienteActivo.diplomaticoSG = 1 Then
                        checkDiplomatico.Checked = True
                    Else
                        checkDiplomatico.Checked = False
                    End If
                Else
                    checkDiplomatico.Visible = False
                End If

                txtTelefono.Text = tele.Telefono_
                txtOtrasSenas.Text = direc.Direccion_
                txtCorreo.Text = email.correo_ElectronicoSG
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        accion = "I"
        txtNombre.Text = ""
        txtApellido1.Text = ""
        txtApellido2.Text = ""
        txtCorreo.Text = ""
        txtIdentificacion.Text = ""
        txtOtrasSenas.Text = ""
        txtTelefono.Text = ""
        cbTipoIden.SelectedIndex = 0
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
        ElseIf txtApellido1.Text = "" Then
            MsgBox("Debe ingresar el primer apellido")
            Exit Sub
        ElseIf txtApellido2.Text = "" Then
            MsgBox("Debe ingresar el segundo apellido")
            Exit Sub
        ElseIf txtIdentificacion.Text = "" Then
            MsgBox("Debe ingresar el numero de identificacion")
            Exit Sub
        ElseIf txtTelefono.Text = "" Then
            MsgBox("Debe ingresar el numero de telefono")
            Exit Sub
        ElseIf txtCorreo.Text = "" Then
            MsgBox("Debe ingresar un correo electronico")
            Exit Sub
        ElseIf txtOtrasSenas.Text = "" Then
            MsgBox("Debe ingresar la direccion")
            Exit Sub
        End If

        Dim cliente = New Cliente
        Dim telefono = New ClienteTelefono
        Dim direccion = New ClienteDireccion
        Dim email = New ClienteEmail
        cliente.NombreClienteSG = txtNombre.Text.Trim.ToUpper
        cliente.Apellido1SG = txtApellido1.Text.ToUpper
        cliente.Apellido2SG = txtApellido2.Text.ToUpper
        cliente.tipoIdentSG = cbTipoIden.SelectedIndex
        If checkDiplomatico.Checked Then
            cliente.diplomaticoSG = 1
        Else
            cliente.diplomaticoSG = 0
        End If
        cliente.identificacionSG = txtIdentificacion.Text
        cliente.CodClienteSG = clienteDatos.codigoCliente
        telefono.Telefono_ = txtTelefono.Text
        email.correo_ElectronicoSG = txtCorreo.Text
        direccion.Direccion_ = txtOtrasSenas.Text.ToUpper




        If accion = "I" Then
            If clienteDatos.InsertarCliente(cliente) Then
                ' limpia los campos de texto
                direccionDatos.insertarDireccion(cliente, direccion.Direccion_)
                telefonoDatos.insertarTelefono(cliente, telefono.Telefono_)
                emailDatos.InsertarEmail(cliente, email.correo_ElectronicoSG)
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

    Private Sub txtTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono.TextChanged

    End Sub

    Private Sub cbTipoIden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoIden.SelectedIndexChanged
        If cbTipoIden.SelectedIndex = 5 Then
            checkDiplomatico.Visible = True
        Else
            checkDiplomatico.Visible = False
        End If
    End Sub

    Private Sub dtgClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgClientes.CellContentClick

    End Sub
End Class