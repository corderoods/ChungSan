<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NuevoCliente
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.btnNuevoTelefono = New System.Windows.Forms.Button()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.btnNuevaDireccion = New System.Windows.Forms.Button()
        Me.dtgClientes = New System.Windows.Forms.DataGridView()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIdentificacion = New System.Windows.Forms.TextBox()
        Me.Identificacion = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOtrasSenas = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbTipoIden = New System.Windows.Forms.ComboBox()
        Me.checkDiplomatico = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtApellido1 = New System.Windows.Forms.TextBox()
        Me.txtApellido2 = New System.Windows.Forms.TextBox()
        Me.dtgTelefonos = New System.Windows.Forms.DataGridView()
        Me.dtgDirecciones = New System.Windows.Forms.DataGridView()
        CType(Me.dtgClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgTelefonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgDirecciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(27, 27)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 29)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Nombre:"
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.txtNombre.Location = New System.Drawing.Point(312, 24)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(372, 34)
        Me.txtNombre.TabIndex = 1
        '
        'btnNuevoTelefono
        '
        Me.btnNuevoTelefono.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevoTelefono.FlatAppearance.BorderSize = 0
        Me.btnNuevoTelefono.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevoTelefono.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevoTelefono.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevoTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoTelefono.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnNuevoTelefono.Image = Global.SunChangSystem.My.Resources.Resources.btnOrden2
        Me.btnNuevoTelefono.Location = New System.Drawing.Point(401, 688)
        Me.btnNuevoTelefono.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNuevoTelefono.Name = "btnNuevoTelefono"
        Me.btnNuevoTelefono.Size = New System.Drawing.Size(133, 60)
        Me.btnNuevoTelefono.TabIndex = 28
        Me.btnNuevoTelefono.Text = "Telefonos"
        Me.btnNuevoTelefono.UseVisualStyleBackColor = True
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConfirmar.AutoSize = True
        Me.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmar.Image = Global.SunChangSystem.My.Resources.Resources.btnGuardar
        Me.btnConfirmar.Location = New System.Drawing.Point(555, 685)
        Me.btnConfirmar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(215, 63)
        Me.btnConfirmar.TabIndex = 22
        Me.btnConfirmar.UseVisualStyleBackColor = False
        '
        'btnNuevaDireccion
        '
        Me.btnNuevaDireccion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevaDireccion.FlatAppearance.BorderSize = 0
        Me.btnNuevaDireccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevaDireccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevaDireccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevaDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevaDireccion.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnNuevaDireccion.Image = Global.SunChangSystem.My.Resources.Resources.btnOrden2
        Me.btnNuevaDireccion.Location = New System.Drawing.Point(29, 688)
        Me.btnNuevaDireccion.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNuevaDireccion.Name = "btnNuevaDireccion"
        Me.btnNuevaDireccion.Size = New System.Drawing.Size(133, 60)
        Me.btnNuevaDireccion.TabIndex = 32
        Me.btnNuevaDireccion.Text = "Direcciones"
        Me.btnNuevaDireccion.UseVisualStyleBackColor = True
        '
        'dtgClientes
        '
        Me.dtgClientes.AllowUserToResizeColumns = False
        Me.dtgClientes.AllowUserToResizeRows = False
        Me.dtgClientes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.dtgClientes.ColumnHeadersHeight = 25
        Me.dtgClientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgClientes.GridColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.dtgClientes.Location = New System.Drawing.Point(927, 13)
        Me.dtgClientes.Margin = New System.Windows.Forms.Padding(4)
        Me.dtgClientes.Name = "dtgClientes"
        Me.dtgClientes.RowHeadersVisible = False
        Me.dtgClientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtgClientes.Size = New System.Drawing.Size(404, 208)
        Me.dtgClientes.TabIndex = 33
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnNuevo.Image = Global.SunChangSystem.My.Resources.Resources.btnOrden2
        Me.btnNuevo.Location = New System.Drawing.Point(703, 24)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(133, 63)
        Me.btnNuevo.TabIndex = 34
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.FlatAppearance.BorderSize = 0
        Me.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnEliminar.Image = Global.SunChangSystem.My.Resources.Resources.btnOrden2
        Me.btnEliminar.Location = New System.Drawing.Point(228, 688)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(133, 60)
        Me.btnEliminar.TabIndex = 35
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'txtTelefono
        '
        Me.txtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.txtTelefono.Location = New System.Drawing.Point(312, 203)
        Me.txtTelefono.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(372, 34)
        Me.txtTelefono.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(27, 205)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 30)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Telefono:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(27, 453)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 29)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Direccion:"
        '
        'txtIdentificacion
        '
        Me.txtIdentificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.txtIdentificacion.Location = New System.Drawing.Point(312, 265)
        Me.txtIdentificacion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdentificacion.Multiline = True
        Me.txtIdentificacion.Name = "txtIdentificacion"
        Me.txtIdentificacion.Size = New System.Drawing.Size(372, 32)
        Me.txtIdentificacion.TabIndex = 5
        '
        'Identificacion
        '
        Me.Identificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Identificacion.ForeColor = System.Drawing.Color.White
        Me.Identificacion.Location = New System.Drawing.Point(27, 267)
        Me.Identificacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Identificacion.Name = "Identificacion"
        Me.Identificacion.Size = New System.Drawing.Size(175, 30)
        Me.Identificacion.TabIndex = 54
        Me.Identificacion.Text = "Identificacion:"
        '
        'txtCorreo
        '
        Me.txtCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.txtCorreo.Location = New System.Drawing.Point(312, 391)
        Me.txtCorreo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(372, 34)
        Me.txtCorreo.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(27, 395)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(229, 30)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Correo electronico:"
        '
        'txtOtrasSenas
        '
        Me.txtOtrasSenas.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.txtOtrasSenas.Location = New System.Drawing.Point(312, 448)
        Me.txtOtrasSenas.Multiline = True
        Me.txtOtrasSenas.Name = "txtOtrasSenas"
        Me.txtOtrasSenas.Size = New System.Drawing.Size(372, 132)
        Me.txtOtrasSenas.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(27, 326)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(263, 29)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Tipo de Indentificacion:"
        '
        'cbTipoIden
        '
        Me.cbTipoIden.AccessibleName = "me.cbTipoIden"
        Me.cbTipoIden.BackColor = System.Drawing.SystemColors.Control
        Me.cbTipoIden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoIden.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbTipoIden.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.cbTipoIden.FormattingEnabled = True
        Me.cbTipoIden.IntegralHeight = False
        Me.cbTipoIden.Items.AddRange(New Object() {"Seleccione un tipo", "Cédula Fisica", "Cédula Juridica", "DIMEX", "Asignado Tributario", "Pasaporte"})
        Me.cbTipoIden.Location = New System.Drawing.Point(312, 323)
        Me.cbTipoIden.Name = "cbTipoIden"
        Me.cbTipoIden.Size = New System.Drawing.Size(372, 37)
        Me.cbTipoIden.TabIndex = 6
        '
        'checkDiplomatico
        '
        Me.checkDiplomatico.AutoSize = True
        Me.checkDiplomatico.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.checkDiplomatico.ForeColor = System.Drawing.Color.White
        Me.checkDiplomatico.Location = New System.Drawing.Point(703, 327)
        Me.checkDiplomatico.Name = "checkDiplomatico"
        Me.checkDiplomatico.Size = New System.Drawing.Size(163, 33)
        Me.checkDiplomatico.TabIndex = 61
        Me.checkDiplomatico.Text = "Diplomatico"
        Me.checkDiplomatico.UseVisualStyleBackColor = True
        Me.checkDiplomatico.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(27, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 29)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "1er Apellido"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(27, 146)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 29)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "2do Apellido"
        '
        'txtApellido1
        '
        Me.txtApellido1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.txtApellido1.Location = New System.Drawing.Point(312, 84)
        Me.txtApellido1.Name = "txtApellido1"
        Me.txtApellido1.Size = New System.Drawing.Size(372, 34)
        Me.txtApellido1.TabIndex = 2
        '
        'txtApellido2
        '
        Me.txtApellido2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.txtApellido2.Location = New System.Drawing.Point(312, 143)
        Me.txtApellido2.Name = "txtApellido2"
        Me.txtApellido2.Size = New System.Drawing.Size(372, 34)
        Me.txtApellido2.TabIndex = 3
        '
        'dtgTelefonos
        '
        Me.dtgTelefonos.AllowUserToResizeColumns = False
        Me.dtgTelefonos.AllowUserToResizeRows = False
        Me.dtgTelefonos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dtgTelefonos.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgTelefonos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dtgTelefonos.ColumnHeadersHeight = 35
        Me.dtgTelefonos.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgTelefonos.DefaultCellStyle = DataGridViewCellStyle6
        Me.dtgTelefonos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgTelefonos.GridColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.dtgTelefonos.Location = New System.Drawing.Point(927, 229)
        Me.dtgTelefonos.Margin = New System.Windows.Forms.Padding(4)
        Me.dtgTelefonos.Name = "dtgTelefonos"
        Me.dtgTelefonos.RowHeadersVisible = False
        Me.dtgTelefonos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtgTelefonos.Size = New System.Drawing.Size(404, 142)
        Me.dtgTelefonos.TabIndex = 64
        '
        'dtgDirecciones
        '
        Me.dtgDirecciones.AllowUserToResizeColumns = False
        Me.dtgDirecciones.AllowUserToResizeRows = False
        Me.dtgDirecciones.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dtgDirecciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgDirecciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dtgDirecciones.ColumnHeadersHeight = 35
        Me.dtgDirecciones.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDirecciones.DefaultCellStyle = DataGridViewCellStyle8
        Me.dtgDirecciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgDirecciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.dtgDirecciones.Location = New System.Drawing.Point(802, 378)
        Me.dtgDirecciones.Margin = New System.Windows.Forms.Padding(4)
        Me.dtgDirecciones.Name = "dtgDirecciones"
        Me.dtgDirecciones.RowHeadersVisible = False
        Me.dtgDirecciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtgDirecciones.Size = New System.Drawing.Size(541, 370)
        Me.dtgDirecciones.TabIndex = 65
        '
        'NuevoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1344, 761)
        Me.Controls.Add(Me.dtgDirecciones)
        Me.Controls.Add(Me.dtgTelefonos)
        Me.Controls.Add(Me.txtApellido2)
        Me.Controls.Add(Me.txtApellido1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.checkDiplomatico)
        Me.Controls.Add(Me.cbTipoIden)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOtrasSenas)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtIdentificacion)
        Me.Controls.Add(Me.Identificacion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.dtgClientes)
        Me.Controls.Add(Me.btnNuevaDireccion)
        Me.Controls.Add(Me.btnNuevoTelefono)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.Label6)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "NuevoCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NuevoCliente"
        CType(Me.dtgClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgTelefonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgDirecciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As Label
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents btnNuevoTelefono As Button
    Friend WithEvents btnNuevaDireccion As Button
    Friend WithEvents dtgClientes As DataGridView
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtIdentificacion As TextBox
    Friend WithEvents Identificacion As Label
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtOtrasSenas As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbTipoIden As ComboBox
    Friend WithEvents checkDiplomatico As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtApellido1 As TextBox
    Friend WithEvents txtApellido2 As TextBox
    Friend WithEvents dtgTelefonos As DataGridView
    Friend WithEvents dtgDirecciones As DataGridView
End Class
