﻿
Imports System.Data.SqlClient

Public Class NuevaOrden

    Dim empleadoDatos As EmpleadoDatos
    Dim clienteDatos As ClienteDatos
    Dim ordenDatos As OrdenDatos
    Dim ordenes1 As Ordenes
    Dim clientes As New List(Of Cliente)

    Dim clienteActivo As New Cliente
    Public EsUber As Boolean = False
    Dim fono As String


    Dim mesa As Integer = 0
    Dim contado As Integer = 0

    Public Sub New(ByVal ordenes As Ordenes)
        Me.clienteDatos = New ClienteDatos
        Me.clientes = New List(Of Cliente)
        InitializeComponent()
        Me.ordenes1 = ordenes
    End Sub

    Private Sub NuevaOrden_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDireccion.Name = 0
        cargarMeseros()
        cargarClientes()
        cbxCliente.SelectedIndex = contado
        txtDireccion.Text = ""
        maskTelefono.Text = ""
        Me.pnlExpress.Visible = True
        Me.pnlSalon.Visible = False


    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btnSalon.Click
        Me.pnlExpress.Visible = True
        Me.pnlSalon.Visible = False
        'Me.txtNombre.Text = "CONTADO"
        'Me.txtNombre.Enabled = True
        Me.lblSalonero.Visible = True
        Me.cbxSalonero.Visible = True
        Me.btnMesa.Visible = True
        S.Text = "Orden Salon"
        S.Name = "S"

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnExpress.Click
        Me.pnlExpress.Visible = True
        Me.pnlSalon.Visible = False
        Me.lblSalonero.Visible = False
        Me.cbxSalonero.Visible = False
        Me.btnMesa.Visible = False
        S.Text = "Orden Express"
        S.Name = "E"


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnLlevar.Click
        Me.pnlExpress.Visible = True
        Me.pnlSalon.Visible = False
        Me.lblSalonero.Visible = False
        Me.cbxSalonero.Visible = False
        Me.btnMesa.Visible = False
        'Me.txtNombre.Text = "CONTADO"
        'Me.txtNombre.Enabled = True

        S.Text = "Orden Llevar"
        S.Name = "L"
    End Sub

    Public Sub cargarClientes()

        clientes = clienteDatos.obtenerClientes()

        Dim dt As DataTable = New DataTable
        dt.Columns.Add("Codigo", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Nombre", System.Type.GetType("System.String"))

        Dim dr As DataRow = dt.NewRow
        For i = 0 To clientes.Count - 1
            dr = dt.NewRow
            dr("Codigo") = clientes(i).CodClienteSG
            dr("Nombre") = clientes(i).NombreClienteSG ' & " " & clientes(i).ApellidoSG
            dt.Rows.Add(dr)
            If clientes(i).CodClienteSG = 0 Then
                contado = i
            End If
        Next i
        cbxCliente.ValueMember = "Codigo"
        cbxCliente.DisplayMember = "Nombre"
        cbxCliente.DataSource = dt
    End Sub

    Private Sub cargarMeseros()
        empleadoDatos = New EmpleadoDatos
        Dim meseros As New List(Of Empleado)

        meseros = empleadoDatos.obtenerMeseros()
        Dim dtMeseros As New DataTable
        dtMeseros.Columns.Add("Codigo", System.Type.GetType("System.Int32"))
        dtMeseros.Columns.Add("Nombre", System.Type.GetType("System.String"))

        Dim dr As DataRow = dtMeseros.NewRow
        For i = 0 To meseros.Count - 1
            dr = dtMeseros.NewRow
            dr("Codigo") = meseros(i).Cod_empleadoSG
            dr("Nombre") = meseros(i).NombreSG & " " & meseros(i).Apellido1SG & " " & meseros(i).Apellido2SG
            dtMeseros.Rows.Add(dr)
            cbxSalonero.ValueMember = "Codigo"
            cbxSalonero.DisplayMember = "Nombre"
            cbxSalonero.DataSource = dtMeseros
        Next i
    End Sub

    Private Sub cbxSalonero_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSalonero.SelectedIndexChanged
        empleadoDatos = New EmpleadoDatos
        Dim meseros As New List(Of Empleado)
        meseros = empleadoDatos.obtenerMeseros()
    End Sub

    Private Sub cbxCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCliente.SelectedIndexChanged

        txtDireccion.Text = ""
        maskTelefono.Text = ""
        Try
            clienteActivo = clienteDatos.obtenerClientePorId(cbxCliente.SelectedValue)
            maskTelefono.Text = clienteActivo.Telefonos_(0).Telefono_
            maskTelefono.Name = clienteActivo.Telefonos_(0).CodTelefono_

            txtDireccion.Text = clienteActivo.Direcciones_(0).Direccion_
            txtDireccion.Name = clienteActivo.Direcciones_(0).CodDireccion_

        Catch ex As Exception
        End Try

        If clienteActivo.Direcciones_.Count > 1 Then
            btnSigDireccion.Visible = True
        Else
            btnSigDireccion.Visible = False
        End If
        If clienteActivo.Telefonos_.Count > 1 Then
            btnSigTelefono.Visible = True
        Else
            btnSigTelefono.Visible = False
        End If

    End Sub

    Private Sub btnConfirmar_Click_1(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        ordenDatos = New OrdenDatos
        Dim mensaje As Mensaje = New Mensaje

        If S.Name = "S" Then
            If mesa = 0 Then
                mensaje.lblMensaje.Text = "Debe seleccionar una mesa"
                mensaje.ShowDialog()
            Else
                insertarSalon()
            End If 'Fin del salon
        ElseIf S.Name = "E" Then
            If txtDireccion.Text.Trim.Length = 0 Then
                mensaje.lblMensaje.Text = "Debe ingesar una direccion"
                mensaje.ShowDialog()
            ElseIf maskTelefono.Text.Trim.Length < 8 Then
                mensaje.lblMensaje.Text = "Debe ingesar un telefono"
                mensaje.ShowDialog()
            Else
                insertarExpress()
            End If 'Express
        ElseIf S.Name = "L" Then
            If txtNombre.Text.Trim.Length = 0 Then
                mensaje.lblMensaje.Text = "Debe ingresar el nombre"
                mensaje.ShowDialog()
            Else
                insertarLlevar()
            End If 'llevar
        ElseIf S.Name = "U" Then
            If txtNombre.Text.Trim.Length = 0 Then
                mensaje.lblMensaje.Text = "Debe ingresar el nombre"
                mensaje.ShowDialog()

            Else
                Me.EsUber = True
                insertarUber(Me.EsUber)

            End If 'llevar



        End If
    End Sub

    Public Sub insertarSalon()
        ordenDatos.insertarOrden(S.Name, cbxSalonero.SelectedValue, mesa,
                                 InicioSesion.session.EmpleadoSG.Cod_empleadoSG,
                                 clienteActivo.CodClienteSG, txtDireccion.Text, maskTelefono.Text.Trim("-"), clienteActivo.NombreClienteSG)

        ordenes1.mostrarOrdenes(1, EsUber)
        Me.Close()
    End Sub

    Public Sub insertarExpress()

        ordenDatos.insertarOrden(S.Name, cbxSalonero.SelectedValue, mesa,
                                 InicioSesion.session.EmpleadoSG.Cod_empleadoSG,
                                 clienteActivo.CodClienteSG, txtDireccion.Text, maskTelefono.Text.Trim, clienteActivo.NombreClienteSG)
        ordenes1.mostrarOrdenes(1, EsUber)
        Me.Close()

    End Sub

    Public Sub insertarLlevar()
        ordenDatos.insertarOrden(S.Name, cbxSalonero.SelectedValue, mesa,
                                 InicioSesion.session.EmpleadoSG.Cod_empleadoSG,
                                 clienteActivo.CodClienteSG, txtDireccion.Text, maskTelefono.Text.Trim("-"), clienteActivo.NombreClienteSG)
        ordenes1.mostrarOrdenes(1, EsUber)
        Me.Close()

    End Sub

    Public Sub insertarUber(EsUber As Boolean)
        ordenDatos.insertarOrden(S.Name, cbxSalonero.SelectedValue, mesa,
                                 InicioSesion.session.EmpleadoSG.Cod_empleadoSG,
                                 clienteActivo.CodClienteSG, txtDireccion.Text, maskTelefono.Text.Trim("-"), txtNombre.Text)
        ordenes1.mostrarOrdenes(1, EsUber)
        Me.Close()
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim nuevoCliente As New NuevoCliente(Me, Nothing)
        nuevoCliente.ShowDialog()
    End Sub

    Public Sub modificaMesa(ByVal mesa As Integer)
        Me.mesa = mesa
        btnMesa.Text = "Mesa " & mesa
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMesa.Click
        Dim seleccionarMesa As SeleccionarMesa = New SeleccionarMesa(Me)
        seleccionarMesa.Show()
    End Sub

    Private Sub btnSigDireccion_Click(sender As Object, e As EventArgs) Handles btnSigDireccion.Click

        For i = 0 To clienteActivo.Direcciones_.Count - 1
            If txtDireccion.Name = clienteActivo.Direcciones_(i).CodDireccion_ Then
                If (i + 1) = clienteActivo.Direcciones_.Count Then
                    txtDireccion.Text = clienteActivo.Direcciones_(0).Direccion_
                    txtDireccion.Name = clienteActivo.Direcciones_(0).CodDireccion_
                Else
                    txtDireccion.Text = clienteActivo.Direcciones_(i + 1).Direccion_
                    txtDireccion.Name = clienteActivo.Direcciones_(i + 1).CodDireccion_
                End If
                Exit Sub
            End If
        Next i
    End Sub


    Private Sub btnSigTelefono_Click(sender As Object, e As EventArgs) Handles btnSigTelefono.Click
        For i = 0 To clienteActivo.Telefonos_.Count - 1
            If maskTelefono.Name = clienteActivo.Telefonos_(i).CodTelefono_ Then
                If (i + 1) = clienteActivo.Telefonos_.Count Then
                    maskTelefono.Text = clienteActivo.Telefonos_(0).Telefono_
                    maskTelefono.Name = clienteActivo.Telefonos_(0).CodTelefono_

                Else
                    maskTelefono.Text = clienteActivo.Telefonos_(i + 1).Telefono_
                    maskTelefono.Name = clienteActivo.Telefonos_(i + 1).CodTelefono_
                End If
                Exit Sub
            End If
        Next i
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles UberEats.Click
        Me.txtNombre.Text = "UBER"
        Me.txtNombre.Enabled = False
        Me.pnlExpress.Visible = False
        Me.pnlSalon.Visible = True
        Me.lblSalonero.Visible = False

        Me.cbxSalonero.Visible = False
        Me.btnMesa.Visible = False
        S.Text = "Uber Eats"
        S.Name = "U"
    End Sub

    Private Sub txtTelefono_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub maskTelefono_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles maskTelefono.MaskInputRejected


    End Sub

    Private Sub maskTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles maskTelefono.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Dim Clie As Cliente

            Dim cadena As String = Trim(maskTelefono.Text.Trim("-"))
            While cadena.Contains("-")
                cadena = cadena.Replace("-", "")
            End While
            Clie = clienteDatos.obtenerClientePorTelefono2(cadena)
            'txtDireccion.Text = Clie.DireccionSG
            Me.cbxCliente.SelectedValue = Clie.CodClienteSG

        End If

    End Sub

    Private Sub lblSalonero_Click(sender As Object, e As EventArgs) Handles lblSalonero.Click

    End Sub



    'Private Sub txtTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono.TextChanged
    '    If txtTelefono.Text.Trim.Length > 7 And var Then
    '        clienteDatos = New ClienteDatos
    '        Dim cliente = clienteDatos.obtenerClientePorTelefono(txtTelefono.Text.Trim)
    '        For i = 0 To cbxCliente.Items.Count - 1
    '            If cbxCliente.Items(i).Item(0) = cliente.CodClienteSG Then
    '                cbxCliente.SelectedIndex = i
    '            End If
    '        Next i
    '    End If
    'End Sub

End Class