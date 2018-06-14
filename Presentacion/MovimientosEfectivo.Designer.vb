<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MovimientosEfectivo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTipoMovimiento = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAdminPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxAdministrador = New System.Windows.Forms.ComboBox()
        Me.rbDolares = New System.Windows.Forms.RadioButton()
        Me.rbColones = New System.Windows.Forms.RadioButton()
        Me.pnlDenominacionesDolares = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lbl21 = New System.Windows.Forms.Label()
        Me.pnlDenominacionesColones = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblCambio = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PanelSalidas = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblSalidaCajaTotal = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblSalidaCajaDolares = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblSalidaCajaColones = New System.Windows.Forms.Label()
        Me.PanelIntroducciones = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblIntroduccionCajaTotal = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblIntroduccionCajaDolares = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblIntroduccionCajaColones = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PanelFondos = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblFonfoCajaTotal = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFonfoCajaDolares = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFonfoCajaColones = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlDatafonos = New System.Windows.Forms.Panel()
        Me.rbDatafono = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.mskExpress = New System.Windows.Forms.MaskedTextBox()
        Me.mskSalon = New System.Windows.Forms.MaskedTextBox()
        Me.pnlDenominacionesDolares.SuspendLayout()
        Me.pnlDenominacionesColones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.PanelSalidas.SuspendLayout()
        Me.PanelIntroducciones.SuspendLayout()
        Me.PanelFondos.SuspendLayout()
        Me.pnlDatafonos.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTipoMovimiento
        '
        Me.lblTipoMovimiento.AutoSize = True
        Me.lblTipoMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoMovimiento.Location = New System.Drawing.Point(12, 15)
        Me.lblTipoMovimiento.Name = "lblTipoMovimiento"
        Me.lblTipoMovimiento.Size = New System.Drawing.Size(0, 29)
        Me.lblTipoMovimiento.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(295, 29)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Contraseña administrador:"
        '
        'txtAdminPassword
        '
        Me.txtAdminPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdminPassword.Location = New System.Drawing.Point(253, 55)
        Me.txtAdminPassword.Name = "txtAdminPassword"
        Me.txtAdminPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtAdminPassword.Size = New System.Drawing.Size(189, 34)
        Me.txtAdminPassword.TabIndex = 5
        Me.txtAdminPassword.Text = "gidcasaw"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Recibe:"
        '
        'cbxAdministrador
        '
        Me.cbxAdministrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAdministrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAdministrador.FormattingEnabled = True
        Me.cbxAdministrador.Location = New System.Drawing.Point(108, 14)
        Me.cbxAdministrador.Name = "cbxAdministrador"
        Me.cbxAdministrador.Size = New System.Drawing.Size(334, 37)
        Me.cbxAdministrador.TabIndex = 0
        '
        'rbDolares
        '
        Me.rbDolares.AutoSize = True
        Me.rbDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDolares.ForeColor = System.Drawing.Color.White
        Me.rbDolares.Location = New System.Drawing.Point(168, 12)
        Me.rbDolares.Name = "rbDolares"
        Me.rbDolares.Size = New System.Drawing.Size(118, 33)
        Me.rbDolares.TabIndex = 13
        Me.rbDolares.TabStop = True
        Me.rbDolares.Text = "Dólares"
        Me.rbDolares.UseVisualStyleBackColor = True
        '
        'rbColones
        '
        Me.rbColones.AutoSize = True
        Me.rbColones.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbColones.ForeColor = System.Drawing.Color.White
        Me.rbColones.Location = New System.Drawing.Point(30, 12)
        Me.rbColones.Name = "rbColones"
        Me.rbColones.Size = New System.Drawing.Size(124, 33)
        Me.rbColones.TabIndex = 14
        Me.rbColones.TabStop = True
        Me.rbColones.Text = "Colones"
        Me.rbColones.UseVisualStyleBackColor = True
        '
        'pnlDenominacionesDolares
        '
        Me.pnlDenominacionesDolares.Controls.Add(Me.Label23)
        Me.pnlDenominacionesDolares.Controls.Add(Me.Label22)
        Me.pnlDenominacionesDolares.Controls.Add(Me.lbl21)
        Me.pnlDenominacionesDolares.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDenominacionesDolares.Location = New System.Drawing.Point(442, 30)
        Me.pnlDenominacionesDolares.Name = "pnlDenominacionesDolares"
        Me.pnlDenominacionesDolares.Size = New System.Drawing.Size(374, 326)
        Me.pnlDenominacionesDolares.TabIndex = 16
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(277, 8)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 25)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "Subtotal"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(163, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(91, 25)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Cantidad"
        '
        'lbl21
        '
        Me.lbl21.AutoSize = True
        Me.lbl21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl21.ForeColor = System.Drawing.Color.White
        Me.lbl21.Location = New System.Drawing.Point(22, 8)
        Me.lbl21.Name = "lbl21"
        Me.lbl21.Size = New System.Drawing.Size(137, 25)
        Me.lbl21.TabIndex = 0
        Me.lbl21.Text = "Denominación"
        '
        'pnlDenominacionesColones
        '
        Me.pnlDenominacionesColones.Controls.Add(Me.Label25)
        Me.pnlDenominacionesColones.Controls.Add(Me.Label21)
        Me.pnlDenominacionesColones.Controls.Add(Me.Label24)
        Me.pnlDenominacionesColones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDenominacionesColones.Location = New System.Drawing.Point(0, 30)
        Me.pnlDenominacionesColones.Name = "pnlDenominacionesColones"
        Me.pnlDenominacionesColones.Size = New System.Drawing.Size(442, 326)
        Me.pnlDenominacionesColones.TabIndex = 16
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(22, 8)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(137, 25)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "Denominación"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(277, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(84, 25)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Subtotal"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(163, 8)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(91, 25)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "Cantidad"
        '
        'lblCambio
        '
        Me.lblCambio.AutoSize = True
        Me.lblCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambio.ForeColor = System.Drawing.Color.White
        Me.lblCambio.Location = New System.Drawing.Point(281, 0)
        Me.lblCambio.Name = "lblCambio"
        Me.lblCambio.Size = New System.Drawing.Size(80, 25)
        Me.lblCambio.TabIndex = 20
        Me.lblCambio.Text = "Cambio"
        Me.lblCambio.Visible = False
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.Location = New System.Drawing.Point(367, 0)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(71, 27)
        Me.txtTipoCambio.TabIndex = 21
        Me.txtTipoCambio.Text = "0.0"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbxAdministrador)
        Me.Panel1.Controls.Add(Me.btnAccept)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.txtAdminPassword)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 649)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(479, 157)
        Me.Panel1.TabIndex = 22
        '
        'btnAccept
        '
        Me.btnAccept.AutoSize = True
        Me.btnAccept.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAccept.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAccept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAccept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccept.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccept.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAccept.Image = Global.SunChangSystem.My.Resources.Resources.btnAceptar
        Me.btnAccept.Location = New System.Drawing.Point(24, 95)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(161, 51)
        Me.btnAccept.TabIndex = 2
        Me.btnAccept.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.Image = Global.SunChangSystem.My.Resources.Resources.btnCancelar
        Me.btnCancel.Location = New System.Drawing.Point(274, 94)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(160, 51)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbDatafono)
        Me.Panel2.Controls.Add(Me.rbDolares)
        Me.Panel2.Controls.Add(Me.rbColones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(479, 52)
        Me.Panel2.TabIndex = 23
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneda.ForeColor = System.Drawing.Color.White
        Me.lblMoneda.Location = New System.Drawing.Point(26, 3)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(96, 29)
        Me.lblMoneda.TabIndex = 7
        Me.lblMoneda.Text = "Recibe:"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pnlDenominacionesDolares)
        Me.Panel3.Controls.Add(Me.pnlDenominacionesColones)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 52)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(479, 356)
        Me.Panel3.TabIndex = 24
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblMoneda)
        Me.Panel4.Controls.Add(Me.lblCambio)
        Me.Panel4.Controls.Add(Me.txtTipoCambio)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(479, 30)
        Me.Panel4.TabIndex = 17
        '
        'PanelSalidas
        '
        Me.PanelSalidas.Controls.Add(Me.Label8)
        Me.PanelSalidas.Controls.Add(Me.lblSalidaCajaTotal)
        Me.PanelSalidas.Controls.Add(Me.Label20)
        Me.PanelSalidas.Controls.Add(Me.Label19)
        Me.PanelSalidas.Controls.Add(Me.lblSalidaCajaDolares)
        Me.PanelSalidas.Controls.Add(Me.Label18)
        Me.PanelSalidas.Controls.Add(Me.lblSalidaCajaColones)
        Me.PanelSalidas.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelSalidas.Location = New System.Drawing.Point(825, 0)
        Me.PanelSalidas.Name = "PanelSalidas"
        Me.PanelSalidas.Size = New System.Drawing.Size(337, 120)
        Me.PanelSalidas.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(23, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 29)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Salidas"
        '
        'lblSalidaCajaTotal
        '
        Me.lblSalidaCajaTotal.AutoSize = True
        Me.lblSalidaCajaTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalidaCajaTotal.ForeColor = System.Drawing.Color.White
        Me.lblSalidaCajaTotal.Location = New System.Drawing.Point(155, 84)
        Me.lblSalidaCajaTotal.Name = "lblSalidaCajaTotal"
        Me.lblSalidaCajaTotal.Size = New System.Drawing.Size(26, 29)
        Me.lblSalidaCajaTotal.TabIndex = 5
        Me.lblSalidaCajaTotal.Text = "0"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(22, 35)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(148, 25)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Salida Caja (c):"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(22, 58)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(149, 25)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Salida Caja ($):"
        '
        'lblSalidaCajaDolares
        '
        Me.lblSalidaCajaDolares.AutoSize = True
        Me.lblSalidaCajaDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalidaCajaDolares.ForeColor = System.Drawing.Color.White
        Me.lblSalidaCajaDolares.Location = New System.Drawing.Point(156, 58)
        Me.lblSalidaCajaDolares.Name = "lblSalidaCajaDolares"
        Me.lblSalidaCajaDolares.Size = New System.Drawing.Size(23, 25)
        Me.lblSalidaCajaDolares.TabIndex = 4
        Me.lblSalidaCajaDolares.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(21, 84)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(154, 29)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Salidas Total"
        '
        'lblSalidaCajaColones
        '
        Me.lblSalidaCajaColones.AutoSize = True
        Me.lblSalidaCajaColones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalidaCajaColones.ForeColor = System.Drawing.Color.White
        Me.lblSalidaCajaColones.Location = New System.Drawing.Point(156, 35)
        Me.lblSalidaCajaColones.Name = "lblSalidaCajaColones"
        Me.lblSalidaCajaColones.Size = New System.Drawing.Size(23, 25)
        Me.lblSalidaCajaColones.TabIndex = 3
        Me.lblSalidaCajaColones.Text = "0"
        '
        'PanelIntroducciones
        '
        Me.PanelIntroducciones.Controls.Add(Me.Label7)
        Me.PanelIntroducciones.Controls.Add(Me.lblIntroduccionCajaTotal)
        Me.PanelIntroducciones.Controls.Add(Me.Label14)
        Me.PanelIntroducciones.Controls.Add(Me.lblIntroduccionCajaDolares)
        Me.PanelIntroducciones.Controls.Add(Me.Label13)
        Me.PanelIntroducciones.Controls.Add(Me.lblIntroduccionCajaColones)
        Me.PanelIntroducciones.Controls.Add(Me.Label12)
        Me.PanelIntroducciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelIntroducciones.Location = New System.Drawing.Point(0, 0)
        Me.PanelIntroducciones.Name = "PanelIntroducciones"
        Me.PanelIntroducciones.Size = New System.Drawing.Size(405, 120)
        Me.PanelIntroducciones.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(18, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(170, 29)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Introducciones"
        '
        'lblIntroduccionCajaTotal
        '
        Me.lblIntroduccionCajaTotal.AutoSize = True
        Me.lblIntroduccionCajaTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntroduccionCajaTotal.ForeColor = System.Drawing.Color.White
        Me.lblIntroduccionCajaTotal.Location = New System.Drawing.Point(219, 84)
        Me.lblIntroduccionCajaTotal.Name = "lblIntroduccionCajaTotal"
        Me.lblIntroduccionCajaTotal.Size = New System.Drawing.Size(26, 29)
        Me.lblIntroduccionCajaTotal.TabIndex = 5
        Me.lblIntroduccionCajaTotal.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(16, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(199, 25)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Introducción Caja (c):"
        '
        'lblIntroduccionCajaDolares
        '
        Me.lblIntroduccionCajaDolares.AutoSize = True
        Me.lblIntroduccionCajaDolares.ForeColor = System.Drawing.Color.White
        Me.lblIntroduccionCajaDolares.Location = New System.Drawing.Point(219, 58)
        Me.lblIntroduccionCajaDolares.Name = "lblIntroduccionCajaDolares"
        Me.lblIntroduccionCajaDolares.Size = New System.Drawing.Size(23, 25)
        Me.lblIntroduccionCajaDolares.TabIndex = 4
        Me.lblIntroduccionCajaDolares.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(16, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(200, 25)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Introducción Caja ($):"
        '
        'lblIntroduccionCajaColones
        '
        Me.lblIntroduccionCajaColones.AutoSize = True
        Me.lblIntroduccionCajaColones.ForeColor = System.Drawing.Color.White
        Me.lblIntroduccionCajaColones.Location = New System.Drawing.Point(219, 35)
        Me.lblIntroduccionCajaColones.Name = "lblIntroduccionCajaColones"
        Me.lblIntroduccionCajaColones.Size = New System.Drawing.Size(23, 25)
        Me.lblIntroduccionCajaColones.TabIndex = 3
        Me.lblIntroduccionCajaColones.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(16, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(246, 29)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Fondo Introducciones"
        '
        'PanelFondos
        '
        Me.PanelFondos.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PanelFondos.Controls.Add(Me.Label9)
        Me.PanelFondos.Controls.Add(Me.lblFonfoCajaTotal)
        Me.PanelFondos.Controls.Add(Me.Label16)
        Me.PanelFondos.Controls.Add(Me.Label3)
        Me.PanelFondos.Controls.Add(Me.lblFonfoCajaDolares)
        Me.PanelFondos.Controls.Add(Me.Label11)
        Me.PanelFondos.Controls.Add(Me.Label4)
        Me.PanelFondos.Controls.Add(Me.lblFonfoCajaColones)
        Me.PanelFondos.Controls.Add(Me.Label5)
        Me.PanelFondos.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelFondos.Location = New System.Drawing.Point(405, 0)
        Me.PanelFondos.Name = "PanelFondos"
        Me.PanelFondos.Size = New System.Drawing.Size(420, 120)
        Me.PanelFondos.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(19, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 29)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Montos"
        '
        'lblFonfoCajaTotal
        '
        Me.lblFonfoCajaTotal.AutoSize = True
        Me.lblFonfoCajaTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFonfoCajaTotal.ForeColor = System.Drawing.Color.White
        Me.lblFonfoCajaTotal.Location = New System.Drawing.Point(152, 84)
        Me.lblFonfoCajaTotal.Name = "lblFonfoCajaTotal"
        Me.lblFonfoCajaTotal.Size = New System.Drawing.Size(26, 29)
        Me.lblFonfoCajaTotal.TabIndex = 5
        Me.lblFonfoCajaTotal.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(19, 38)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(149, 25)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Fondo Caja (c):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(19, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 25)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fondo Caja (c):"
        '
        'lblFonfoCajaDolares
        '
        Me.lblFonfoCajaDolares.AutoSize = True
        Me.lblFonfoCajaDolares.ForeColor = System.Drawing.Color.White
        Me.lblFonfoCajaDolares.Location = New System.Drawing.Point(153, 61)
        Me.lblFonfoCajaDolares.Name = "lblFonfoCajaDolares"
        Me.lblFonfoCajaDolares.Size = New System.Drawing.Size(23, 25)
        Me.lblFonfoCajaDolares.TabIndex = 4
        Me.lblFonfoCajaDolares.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(18, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(150, 25)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Fondo Caja ($):"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(18, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 25)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Fondo Caja ($):"
        '
        'lblFonfoCajaColones
        '
        Me.lblFonfoCajaColones.AutoSize = True
        Me.lblFonfoCajaColones.ForeColor = System.Drawing.Color.White
        Me.lblFonfoCajaColones.Location = New System.Drawing.Point(153, 38)
        Me.lblFonfoCajaColones.Name = "lblFonfoCajaColones"
        Me.lblFonfoCajaColones.Size = New System.Drawing.Size(23, 25)
        Me.lblFonfoCajaColones.TabIndex = 3
        Me.lblFonfoCajaColones.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(18, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 29)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Fondo Total"
        '
        'pnlDatafonos
        '
        Me.pnlDatafonos.Controls.Add(Me.mskSalon)
        Me.pnlDatafonos.Controls.Add(Me.mskExpress)
        Me.pnlDatafonos.Controls.Add(Me.Label17)
        Me.pnlDatafonos.Controls.Add(Me.Label15)
        Me.pnlDatafonos.Controls.Add(Me.Label10)
        Me.pnlDatafonos.Controls.Add(Me.Label6)
        Me.pnlDatafonos.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDatafonos.Location = New System.Drawing.Point(0, 528)
        Me.pnlDatafonos.Name = "pnlDatafonos"
        Me.pnlDatafonos.Size = New System.Drawing.Size(488, 121)
        Me.pnlDatafonos.TabIndex = 18
        Me.pnlDatafonos.Visible = False
        '
        'rbDatafono
        '
        Me.rbDatafono.AutoSize = True
        Me.rbDatafono.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.rbDatafono.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.rbDatafono.Location = New System.Drawing.Point(292, 12)
        Me.rbDatafono.Name = "rbDatafono"
        Me.rbDatafono.Size = New System.Drawing.Size(142, 33)
        Me.rbDatafono.TabIndex = 22
        Me.rbDatafono.TabStop = True
        Me.rbDatafono.Text = "Datafonos"
        Me.rbDatafono.UseVisualStyleBackColor = True
        Me.rbDatafono.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.Location = New System.Drawing.Point(38, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 25)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Datafono"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label10.Location = New System.Drawing.Point(292, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 25)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Subtotal"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.PanelSalidas)
        Me.Panel5.Controls.Add(Me.PanelFondos)
        Me.Panel5.Controls.Add(Me.PanelIntroducciones)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 408)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(479, 120)
        Me.Panel5.TabIndex = 25
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label15.Location = New System.Drawing.Point(22, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(167, 25)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Datafono Express"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label17.Location = New System.Drawing.Point(26, 96)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(147, 25)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Datafono Salon"
        '
        'mskExpress
        '
        Me.mskExpress.Location = New System.Drawing.Point(274, 44)
        Me.mskExpress.Mask = "999,999.999"
        Me.mskExpress.Name = "mskExpress"
        Me.mskExpress.Size = New System.Drawing.Size(189, 30)
        Me.mskExpress.TabIndex = 4
        '
        'mskSalon
        '
        Me.mskSalon.Location = New System.Drawing.Point(274, 93)
        Me.mskSalon.Mask = "999,999.999"
        Me.mskSalon.Name = "mskSalon"
        Me.mskSalon.Size = New System.Drawing.Size(189, 30)
        Me.mskSalon.TabIndex = 5
        '
        'MovimientosEfectivo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(479, 806)
        Me.Controls.Add(Me.pnlDatafonos)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTipoMovimiento)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "MovimientosEfectivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos de Efectivo"
        Me.pnlDenominacionesDolares.ResumeLayout(False)
        Me.pnlDenominacionesDolares.PerformLayout()
        Me.pnlDenominacionesColones.ResumeLayout(False)
        Me.pnlDenominacionesColones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.PanelSalidas.ResumeLayout(False)
        Me.PanelSalidas.PerformLayout()
        Me.PanelIntroducciones.ResumeLayout(False)
        Me.PanelIntroducciones.PerformLayout()
        Me.PanelFondos.ResumeLayout(False)
        Me.PanelFondos.PerformLayout()
        Me.pnlDatafonos.ResumeLayout(False)
        Me.pnlDatafonos.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTipoMovimiento As Label
    Friend WithEvents btnAccept As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAdminPassword As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxAdministrador As ComboBox
    Friend WithEvents rbDolares As RadioButton
    Friend WithEvents rbColones As RadioButton

    Dim lblDenominacion As Label
    Dim txtCantidad As TextBox
    Dim txtValorDenominacion As TextBox
    Dim etiquetasValores(15) As Label
    Dim cajasTextoCantidad(15) As TextBox
    Dim cajasValorDenominacion(15) As TextBox
    Friend WithEvents pnlDenominacionesDolares As Panel
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents lbl21 As Label
    Friend WithEvents pnlDenominacionesColones As Panel
    Friend WithEvents Label21 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents lblCambio As Label
    Friend WithEvents txtTipoCambio As TextBox
    Friend WithEvents lblMoneda As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PanelSalidas As Panel
    Friend WithEvents PanelIntroducciones As Panel
    Friend WithEvents PanelFondos As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents lblFonfoCajaTotal As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblFonfoCajaDolares As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblFonfoCajaColones As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblIntroduccionCajaTotal As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblIntroduccionCajaDolares As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblIntroduccionCajaColones As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblSalidaCajaTotal As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblSalidaCajaDolares As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblSalidaCajaColones As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rbDatafono As RadioButton
    Friend WithEvents pnlDatafonos As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents mskSalon As MaskedTextBox
    Friend WithEvents mskExpress As MaskedTextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label15 As Label
End Class
