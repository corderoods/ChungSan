﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NuevaOrden
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
        Me.pnlPricipal = New System.Windows.Forms.Panel()
        Me.pnlExpress = New System.Windows.Forms.Panel()
        Me.btnSigTelefono = New System.Windows.Forms.Button()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.btnSigDireccion = New System.Windows.Forms.Button()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.cbxCliente = New System.Windows.Forms.ComboBox()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.pnlSalon = New System.Windows.Forms.Panel()
        Me.btnMesa = New System.Windows.Forms.Button()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxSalonero = New System.Windows.Forms.ComboBox()
        Me.lblSalonero = New System.Windows.Forms.Label()
        Me.S = New System.Windows.Forms.Label()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.btnExpress = New System.Windows.Forms.Button()
        Me.btnLlevar = New System.Windows.Forms.Button()
        Me.btnSalon = New System.Windows.Forms.Button()
        Me.pnlPricipal.SuspendLayout()
        Me.pnlExpress.SuspendLayout()
        Me.pnlSalon.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPricipal
        '
        Me.pnlPricipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlPricipal.Controls.Add(Me.pnlExpress)
        Me.pnlPricipal.Controls.Add(Me.pnlSalon)
        Me.pnlPricipal.Location = New System.Drawing.Point(12, 82)
        Me.pnlPricipal.Name = "pnlPricipal"
        Me.pnlPricipal.Size = New System.Drawing.Size(869, 293)
        Me.pnlPricipal.TabIndex = 5
        '
        'pnlExpress
        '
        Me.pnlExpress.Controls.Add(Me.btnSigTelefono)
        Me.pnlExpress.Controls.Add(Me.txtTelefono)
        Me.pnlExpress.Controls.Add(Me.txtDireccion)
        Me.pnlExpress.Controls.Add(Me.btnSigDireccion)
        Me.pnlExpress.Controls.Add(Me.lblDireccion)
        Me.pnlExpress.Controls.Add(Me.btnNuevo)
        Me.pnlExpress.Controls.Add(Me.cbxCliente)
        Me.pnlExpress.Controls.Add(Me.lblTelefono)
        Me.pnlExpress.Controls.Add(Me.lblCliente)
        Me.pnlExpress.Location = New System.Drawing.Point(13, 15)
        Me.pnlExpress.Name = "pnlExpress"
        Me.pnlExpress.Size = New System.Drawing.Size(842, 279)
        Me.pnlExpress.TabIndex = 9
        Me.pnlExpress.Visible = False
        '
        'btnSigTelefono
        '
        Me.btnSigTelefono.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSigTelefono.Location = New System.Drawing.Point(363, 78)
        Me.btnSigTelefono.Name = "btnSigTelefono"
        Me.btnSigTelefono.Size = New System.Drawing.Size(70, 33)
        Me.btnSigTelefono.TabIndex = 21
        Me.btnSigTelefono.Text = ">"
        Me.btnSigTelefono.UseVisualStyleBackColor = True
        Me.btnSigTelefono.Visible = False
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.SystemColors.Menu
        Me.txtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(107, 80)
        Me.txtTelefono.Multiline = True
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(233, 32)
        Me.txtTelefono.TabIndex = 19
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.SystemColors.Menu
        Me.txtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(109, 137)
        Me.txtDireccion.Multiline = True
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(619, 121)
        Me.txtDireccion.TabIndex = 20
        '
        'btnSigDireccion
        '
        Me.btnSigDireccion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSigDireccion.Location = New System.Drawing.Point(734, 137)
        Me.btnSigDireccion.Name = "btnSigDireccion"
        Me.btnSigDireccion.Size = New System.Drawing.Size(88, 121)
        Me.btnSigDireccion.TabIndex = 9
        Me.btnSigDireccion.Text = ">"
        Me.btnSigDireccion.UseVisualStyleBackColor = True
        Me.btnSigDireccion.Visible = False
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.Color.White
        Me.lblDireccion.Location = New System.Drawing.Point(8, 137)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(95, 24)
        Me.lblDireccion.TabIndex = 7
        Me.lblDireccion.Text = "Dirección:"
        '
        'btnNuevo
        '
        Me.btnNuevo.AutoSize = True
        Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevo.Image = Global.SunChangSystem.My.Resources.Resources.btnNuevoCliente1
        Me.btnNuevo.Location = New System.Drawing.Point(344, 4)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(103, 45)
        Me.btnNuevo.TabIndex = 4
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'cbxCliente
        '
        Me.cbxCliente.AccessibleName = "Me.cbxCliente"
        Me.cbxCliente.BackColor = System.Drawing.SystemColors.Control
        Me.cbxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCliente.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbxCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCliente.FormattingEnabled = True
        Me.cbxCliente.IntegralHeight = False
        Me.cbxCliente.Location = New System.Drawing.Point(107, 9)
        Me.cbxCliente.MaxDropDownItems = 15
        Me.cbxCliente.Name = "cbxCliente"
        Me.cbxCliente.Size = New System.Drawing.Size(221, 32)
        Me.cbxCliente.TabIndex = 3
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefono.ForeColor = System.Drawing.Color.White
        Me.lblTelefono.Location = New System.Drawing.Point(8, 83)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(90, 24)
        Me.lblTelefono.TabIndex = 6
        Me.lblTelefono.Text = "Teléfono:"
        '
        'lblCliente
        '
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.White
        Me.lblCliente.Location = New System.Drawing.Point(9, 17)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(89, 24)
        Me.lblCliente.TabIndex = 2
        Me.lblCliente.Text = "Cliente:"
        '
        'pnlSalon
        '
        Me.pnlSalon.Controls.Add(Me.btnMesa)
        Me.pnlSalon.Controls.Add(Me.txtNombre)
        Me.pnlSalon.Controls.Add(Me.Label3)
        Me.pnlSalon.Controls.Add(Me.cbxSalonero)
        Me.pnlSalon.Controls.Add(Me.lblSalonero)
        Me.pnlSalon.Location = New System.Drawing.Point(13, 15)
        Me.pnlSalon.Name = "pnlSalon"
        Me.pnlSalon.Size = New System.Drawing.Size(688, 133)
        Me.pnlSalon.TabIndex = 5
        '
        'btnMesa
        '
        Me.btnMesa.AutoSize = True
        Me.btnMesa.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMesa.FlatAppearance.BorderSize = 0
        Me.btnMesa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnMesa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnMesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMesa.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnMesa.Image = Global.SunChangSystem.My.Resources.Resources.btnProducto
        Me.btnMesa.Location = New System.Drawing.Point(363, 24)
        Me.btnMesa.Name = "btnMesa"
        Me.btnMesa.Size = New System.Drawing.Size(161, 70)
        Me.btnMesa.TabIndex = 18
        Me.btnMesa.Text = "Elegir Mesa:"
        Me.btnMesa.UseVisualStyleBackColor = False
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Menu
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(97, 12)
        Me.txtNombre.Multiline = True
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(233, 32)
        Me.txtNombre.TabIndex = 17
        Me.txtNombre.Text = "CONTADO"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(5, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 24)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Cliente:"
        '
        'cbxSalonero
        '
        Me.cbxSalonero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSalonero.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbxSalonero.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSalonero.FormattingEnabled = True
        Me.cbxSalonero.Location = New System.Drawing.Point(97, 77)
        Me.cbxSalonero.Name = "cbxSalonero"
        Me.cbxSalonero.Size = New System.Drawing.Size(233, 32)
        Me.cbxSalonero.TabIndex = 7
        '
        'lblSalonero
        '
        Me.lblSalonero.AutoSize = True
        Me.lblSalonero.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalonero.ForeColor = System.Drawing.Color.White
        Me.lblSalonero.Location = New System.Drawing.Point(3, 80)
        Me.lblSalonero.Name = "lblSalonero"
        Me.lblSalonero.Size = New System.Drawing.Size(91, 24)
        Me.lblSalonero.TabIndex = 6
        Me.lblSalonero.Text = "Salonero:"
        '
        'S
        '
        Me.S.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.S.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.S.Location = New System.Drawing.Point(723, 30)
        Me.S.Name = "S"
        Me.S.Size = New System.Drawing.Size(158, 24)
        Me.S.TabIndex = 14
        Me.S.Text = "Orden Salon"
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConfirmar.AutoSize = True
        Me.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.Image = Global.SunChangSystem.My.Resources.Resources.btnConfirmar2
        Me.btnConfirmar.Location = New System.Drawing.Point(388, 396)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(161, 51)
        Me.btnConfirmar.TabIndex = 11
        Me.btnConfirmar.UseVisualStyleBackColor = False
        '
        'btnExpress
        '
        Me.btnExpress.AutoSize = True
        Me.btnExpress.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnExpress.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExpress.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnExpress.FlatAppearance.BorderSize = 0
        Me.btnExpress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnExpress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnExpress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExpress.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnExpress.Image = Global.SunChangSystem.My.Resources.Resources.btnExpress1
        Me.btnExpress.Location = New System.Drawing.Point(321, 10)
        Me.btnExpress.Name = "btnExpress"
        Me.btnExpress.Size = New System.Drawing.Size(156, 63)
        Me.btnExpress.TabIndex = 11
        Me.btnExpress.UseVisualStyleBackColor = False
        '
        'btnLlevar
        '
        Me.btnLlevar.AutoSize = True
        Me.btnLlevar.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnLlevar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLlevar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnLlevar.FlatAppearance.BorderSize = 0
        Me.btnLlevar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnLlevar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnLlevar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLlevar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLlevar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnLlevar.Image = Global.SunChangSystem.My.Resources.Resources.btnLlevar1
        Me.btnLlevar.Location = New System.Drawing.Point(558, 10)
        Me.btnLlevar.Name = "btnLlevar"
        Me.btnLlevar.Size = New System.Drawing.Size(155, 63)
        Me.btnLlevar.TabIndex = 10
        Me.btnLlevar.UseVisualStyleBackColor = False
        '
        'btnSalon
        '
        Me.btnSalon.AutoSize = True
        Me.btnSalon.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSalon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSalon.FlatAppearance.BorderSize = 0
        Me.btnSalon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSalon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSalon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalon.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSalon.Image = Global.SunChangSystem.My.Resources.Resources.btnSalon1
        Me.btnSalon.Location = New System.Drawing.Point(78, 10)
        Me.btnSalon.Name = "btnSalon"
        Me.btnSalon.Size = New System.Drawing.Size(155, 63)
        Me.btnSalon.TabIndex = 0
        Me.btnSalon.UseVisualStyleBackColor = False
        '
        'NuevaOrden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(952, 459)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.S)
        Me.Controls.Add(Me.btnExpress)
        Me.Controls.Add(Me.btnLlevar)
        Me.Controls.Add(Me.pnlPricipal)
        Me.Controls.Add(Me.btnSalon)
        Me.Name = "NuevaOrden"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NuevaOrden"
        Me.pnlPricipal.ResumeLayout(False)
        Me.pnlExpress.ResumeLayout(False)
        Me.pnlExpress.PerformLayout()
        Me.pnlSalon.ResumeLayout(False)
        Me.pnlSalon.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSalon As Button
    Friend WithEvents pnlPricipal As Panel
    Friend WithEvents btnNuevo As Button
    Friend WithEvents cbxCliente As ComboBox
    Friend WithEvents lblCliente As Label
    Friend WithEvents pnlExpress As Panel
    Friend WithEvents lblDireccion As Label
    Friend WithEvents lblTelefono As Label
    Friend WithEvents pnlSalon As Panel
    Friend WithEvents cbxSalonero As ComboBox
    Friend WithEvents lblSalonero As Label
    Friend WithEvents btnLlevar As Button
    Friend WithEvents btnExpress As Button
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents S As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnMesa As Button
    Friend WithEvents btnSigDireccion As Button
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents btnSigTelefono As Button
End Class
