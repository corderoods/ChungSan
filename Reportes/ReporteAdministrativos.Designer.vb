<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteAdministrativos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblMontoTotal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.cbxSalon = New System.Windows.Forms.CheckBox()
        Me.cbxLlevar = New System.Windows.Forms.CheckBox()
        Me.cbxExpress = New System.Windows.Forms.CheckBox()
        Me.cbxTarjeta = New System.Windows.Forms.CheckBox()
        Me.cbxEfectivo = New System.Windows.Forms.CheckBox()
        Me.txtCodUsuario = New System.Windows.Forms.TextBox()
        Me.cbxUsuario = New System.Windows.Forms.CheckBox()
        Me.dgvVentas = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FechaFin = New System.Windows.Forms.DateTimePicker()
        Me.FechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnImprimir)
        Me.Panel1.Controls.Add(Me.lblMontoTotal)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnConfirmar)
        Me.Panel1.Controls.Add(Me.cbxSalon)
        Me.Panel1.Controls.Add(Me.cbxLlevar)
        Me.Panel1.Controls.Add(Me.cbxExpress)
        Me.Panel1.Controls.Add(Me.cbxTarjeta)
        Me.Panel1.Controls.Add(Me.cbxEfectivo)
        Me.Panel1.Controls.Add(Me.txtCodUsuario)
        Me.Panel1.Controls.Add(Me.cbxUsuario)
        Me.Panel1.Controls.Add(Me.dgvVentas)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.FechaFin)
        Me.Panel1.Controls.Add(Me.FechaInicio)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(745, 557)
        Me.Panel1.TabIndex = 6
        '
        'btnImprimir
        '
        Me.btnImprimir.AutoSize = True
        Me.btnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnImprimir.Image = Global.SunChangSystem.My.Resources.Resources.btnImprimirOrden1
        Me.btnImprimir.Location = New System.Drawing.Point(212, 478)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(157, 64)
        Me.btnImprimir.TabIndex = 12
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'lblMontoTotal
        '
        Me.lblMontoTotal.AutoSize = True
        Me.lblMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotal.ForeColor = System.Drawing.Color.White
        Me.lblMontoTotal.Location = New System.Drawing.Point(570, 478)
        Me.lblMontoTotal.Name = "lblMontoTotal"
        Me.lblMontoTotal.Size = New System.Drawing.Size(0, 24)
        Me.lblMontoTotal.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(493, 478)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 24)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Total: "
        '
        'btnConfirmar
        '
        Me.btnConfirmar.AutoSize = True
        Me.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.Image = Global.SunChangSystem.My.Resources.Resources.btnConfirmar1
        Me.btnConfirmar.Location = New System.Drawing.Point(29, 478)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(177, 64)
        Me.btnConfirmar.TabIndex = 9
        Me.btnConfirmar.UseVisualStyleBackColor = False
        '
        'cbxSalon
        '
        Me.cbxSalon.AutoSize = True
        Me.cbxSalon.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.cbxSalon.ForeColor = System.Drawing.Color.White
        Me.cbxSalon.Location = New System.Drawing.Point(253, 95)
        Me.cbxSalon.Name = "cbxSalon"
        Me.cbxSalon.Size = New System.Drawing.Size(77, 28)
        Me.cbxSalon.TabIndex = 6
        Me.cbxSalon.Text = "Salón"
        Me.cbxSalon.UseVisualStyleBackColor = True
        Me.cbxSalon.Visible = False
        '
        'cbxLlevar
        '
        Me.cbxLlevar.AutoSize = True
        Me.cbxLlevar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.cbxLlevar.ForeColor = System.Drawing.Color.White
        Me.cbxLlevar.Location = New System.Drawing.Point(336, 95)
        Me.cbxLlevar.Name = "cbxLlevar"
        Me.cbxLlevar.Size = New System.Drawing.Size(79, 28)
        Me.cbxLlevar.TabIndex = 7
        Me.cbxLlevar.Text = "Llevar"
        Me.cbxLlevar.UseVisualStyleBackColor = True
        Me.cbxLlevar.Visible = False
        '
        'cbxExpress
        '
        Me.cbxExpress.AutoSize = True
        Me.cbxExpress.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.cbxExpress.ForeColor = System.Drawing.Color.White
        Me.cbxExpress.Location = New System.Drawing.Point(421, 95)
        Me.cbxExpress.Name = "cbxExpress"
        Me.cbxExpress.Size = New System.Drawing.Size(98, 28)
        Me.cbxExpress.TabIndex = 8
        Me.cbxExpress.Text = "Express"
        Me.cbxExpress.UseVisualStyleBackColor = True
        Me.cbxExpress.Visible = False
        '
        'cbxTarjeta
        '
        Me.cbxTarjeta.AutoSize = True
        Me.cbxTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.cbxTarjeta.ForeColor = System.Drawing.Color.White
        Me.cbxTarjeta.Location = New System.Drawing.Point(143, 95)
        Me.cbxTarjeta.Name = "cbxTarjeta"
        Me.cbxTarjeta.Size = New System.Drawing.Size(86, 28)
        Me.cbxTarjeta.TabIndex = 5
        Me.cbxTarjeta.Text = "Tarjeta"
        Me.cbxTarjeta.UseVisualStyleBackColor = True
        Me.cbxTarjeta.Visible = False
        '
        'cbxEfectivo
        '
        Me.cbxEfectivo.AutoSize = True
        Me.cbxEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.cbxEfectivo.ForeColor = System.Drawing.Color.White
        Me.cbxEfectivo.Location = New System.Drawing.Point(28, 95)
        Me.cbxEfectivo.Name = "cbxEfectivo"
        Me.cbxEfectivo.Size = New System.Drawing.Size(95, 28)
        Me.cbxEfectivo.TabIndex = 4
        Me.cbxEfectivo.Text = "Efectivo"
        Me.cbxEfectivo.UseVisualStyleBackColor = True
        Me.cbxEfectivo.Visible = False
        '
        'txtCodUsuario
        '
        Me.txtCodUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodUsuario.Location = New System.Drawing.Point(487, 47)
        Me.txtCodUsuario.Name = "txtCodUsuario"
        Me.txtCodUsuario.Size = New System.Drawing.Size(221, 29)
        Me.txtCodUsuario.TabIndex = 3
        Me.txtCodUsuario.Visible = False
        '
        'cbxUsuario
        '
        Me.cbxUsuario.AutoSize = True
        Me.cbxUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.cbxUsuario.ForeColor = System.Drawing.Color.White
        Me.cbxUsuario.Location = New System.Drawing.Point(544, 16)
        Me.cbxUsuario.Name = "cbxUsuario"
        Me.cbxUsuario.Size = New System.Drawing.Size(93, 28)
        Me.cbxUsuario.TabIndex = 2
        Me.cbxUsuario.Text = "Usuario"
        Me.cbxUsuario.UseVisualStyleBackColor = True
        '
        'dgvVentas
        '
        Me.dgvVentas.AllowUserToAddRows = False
        Me.dgvVentas.AllowUserToDeleteRows = False
        Me.dgvVentas.AllowUserToOrderColumns = True
        Me.dgvVentas.AllowUserToResizeRows = False
        Me.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvVentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvVentas.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(49, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVentas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(49, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVentas.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVentas.Location = New System.Drawing.Point(28, 148)
        Me.dgvVentas.Name = "dgvVentas"
        Me.dgvVentas.ReadOnly = True
        Me.dgvVentas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(49, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVentas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVentas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.dgvVentas.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvVentas.Size = New System.Drawing.Size(690, 326)
        Me.dgvVentas.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(303, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha Fin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(69, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha Inicio"
        '
        'FechaFin
        '
        Me.FechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.FechaFin.Location = New System.Drawing.Point(253, 47)
        Me.FechaFin.Name = "FechaFin"
        Me.FechaFin.Size = New System.Drawing.Size(200, 29)
        Me.FechaFin.TabIndex = 1
        Me.FechaFin.Value = New Date(2016, 10, 5, 0, 0, 0, 0)
        '
        'FechaInicio
        '
        Me.FechaInicio.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.FechaInicio.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FechaInicio.CalendarTitleForeColor = System.Drawing.Color.White
        Me.FechaInicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.FechaInicio.Location = New System.Drawing.Point(29, 47)
        Me.FechaInicio.MaxDate = New Date(2017, 12, 31, 0, 0, 0, 0)
        Me.FechaInicio.MinDate = New Date(2016, 1, 1, 0, 0, 0, 0)
        Me.FechaInicio.Name = "FechaInicio"
        Me.FechaInicio.Size = New System.Drawing.Size(200, 29)
        Me.FechaInicio.TabIndex = 0
        Me.FechaInicio.Value = New Date(2016, 10, 6, 0, 0, 0, 0)
        '
        'ReporteAdministrativos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 560)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ReporteAdministrativos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Ventas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents FechaFin As DateTimePicker
    Friend WithEvents FechaInicio As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxUsuario As CheckBox
    Friend WithEvents dgvVentas As DataGridView
    Friend WithEvents cbxEfectivo As CheckBox
    Friend WithEvents txtCodUsuario As TextBox
    Friend WithEvents cbxTarjeta As CheckBox
    Friend WithEvents cbxSalon As CheckBox
    Friend WithEvents cbxLlevar As CheckBox
    Friend WithEvents cbxExpress As CheckBox
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents lblMontoTotal As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnImprimir As Button
End Class
