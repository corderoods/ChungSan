﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Ordenes
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ordenes))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrarSesion = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnNuevaOrden = New System.Windows.Forms.Button()
        Me.txtHora = New System.Windows.Forms.Label()
        Me.btnProducto = New System.Windows.Forms.Button()
        Me.pnlPrinOrdenes = New System.Windows.Forms.Panel()
        Me.pnlOrdenes = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlPrinProd = New System.Windows.Forms.Panel()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.lblDetalleOrden = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlPrinCategorias = New System.Windows.Forms.Panel()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxProducto = New System.Windows.Forms.ComboBox()
        Me.lblCategorias = New System.Windows.Forms.Label()
        Me.pnlCategorias = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContabilidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FondoInicialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CierreCajaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ARQUEOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PagoDeFacturasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalidasDeEfectivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IntroduccionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministradorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasXDíaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpuestoDeVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CategoríaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtNombreCajero = New System.Windows.Forms.Label()
        Me.timerLlamaMesero = New System.Windows.Forms.Timer(Me.components)
        Me.TimerReproduceSonido = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrinOrdenes.SuspendLayout()
        Me.pnlPrinProd.SuspendLayout()
        Me.pnlPrinCategorias.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.btnCerrarSesion)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.btnImprimir)
        Me.Panel1.Controls.Add(Me.btnBorrar)
        Me.Panel1.Controls.Add(Me.btnNuevaOrden)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1352, 83)
        Me.Panel1.TabIndex = 0
        '
        'btnLimpiar
        '
        Me.btnLimpiar.AutoSize = True
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnLimpiar.Image = Global.SunChangSystem.My.Resources.Resources.btnOcultar
        Me.btnLimpiar.Location = New System.Drawing.Point(548, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(157, 64)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrarSesion
        '
        Me.btnCerrarSesion.AutoSize = True
        Me.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCerrarSesion.FlatAppearance.BorderSize = 0
        Me.btnCerrarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrarSesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCerrarSesion.Image = Global.SunChangSystem.My.Resources.Resources.btnLogout1
        Me.btnCerrarSesion.Location = New System.Drawing.Point(980, 8)
        Me.btnCerrarSesion.Name = "btnCerrarSesion"
        Me.btnCerrarSesion.Size = New System.Drawing.Size(159, 62)
        Me.btnCerrarSesion.TabIndex = 5
        Me.btnCerrarSesion.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SunChangSystem.My.Resources.Resources.cover21
        Me.PictureBox1.Location = New System.Drawing.Point(1157, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(192, 76)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'btnImprimir
        '
        Me.btnImprimir.AutoSize = True
        Me.btnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnImprimir.Image = Global.SunChangSystem.My.Resources.Resources.btnImprimirOrden1
        Me.btnImprimir.Location = New System.Drawing.Point(376, 8)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(155, 62)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'btnBorrar
        '
        Me.btnBorrar.AutoSize = True
        Me.btnBorrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBorrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnBorrar.FlatAppearance.BorderSize = 0
        Me.btnBorrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnBorrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnBorrar.Image = Global.SunChangSystem.My.Resources.Resources.btnBorrarOrden1
        Me.btnBorrar.Location = New System.Drawing.Point(197, 8)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(155, 63)
        Me.btnBorrar.TabIndex = 1
        Me.btnBorrar.UseVisualStyleBackColor = False
        '
        'btnNuevaOrden
        '
        Me.btnNuevaOrden.AutoSize = True
        Me.btnNuevaOrden.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevaOrden.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevaOrden.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevaOrden.FlatAppearance.BorderSize = 0
        Me.btnNuevaOrden.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevaOrden.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevaOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevaOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevaOrden.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevaOrden.Image = Global.SunChangSystem.My.Resources.Resources.btnNuevaOrden2
        Me.btnNuevaOrden.Location = New System.Drawing.Point(16, 7)
        Me.btnNuevaOrden.Name = "btnNuevaOrden"
        Me.btnNuevaOrden.Size = New System.Drawing.Size(155, 64)
        Me.btnNuevaOrden.TabIndex = 0
        Me.btnNuevaOrden.UseVisualStyleBackColor = False
        '
        'txtHora
        '
        Me.txtHora.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtHora.Location = New System.Drawing.Point(925, 4)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(419, 29)
        Me.txtHora.TabIndex = 6
        Me.txtHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnProducto
        '
        Me.btnProducto.Location = New System.Drawing.Point(0, 0)
        Me.btnProducto.Name = "btnProducto"
        Me.btnProducto.Size = New System.Drawing.Size(75, 23)
        Me.btnProducto.TabIndex = 0
        '
        'pnlPrinOrdenes
        '
        Me.pnlPrinOrdenes.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlPrinOrdenes.Controls.Add(Me.pnlOrdenes)
        Me.pnlPrinOrdenes.Controls.Add(Me.Label1)
        Me.pnlPrinOrdenes.Location = New System.Drawing.Point(0, 122)
        Me.pnlPrinOrdenes.Name = "pnlPrinOrdenes"
        Me.pnlPrinOrdenes.Size = New System.Drawing.Size(178, 603)
        Me.pnlPrinOrdenes.TabIndex = 3
        '
        'pnlOrdenes
        '
        Me.pnlOrdenes.AutoScroll = True
        Me.pnlOrdenes.BackColor = System.Drawing.Color.Transparent
        Me.pnlOrdenes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnlOrdenes.Location = New System.Drawing.Point(12, 39)
        Me.pnlOrdenes.Name = "pnlOrdenes"
        Me.pnlOrdenes.Size = New System.Drawing.Size(163, 530)
        Me.pnlOrdenes.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ordenes Actuales"
        '
        'pnlPrinProd
        '
        Me.pnlPrinProd.AutoScroll = True
        Me.pnlPrinProd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlPrinProd.Controls.Add(Me.pnlDetalle)
        Me.pnlPrinProd.Controls.Add(Me.lblDetalleOrden)
        Me.pnlPrinProd.Controls.Add(Me.Label14)
        Me.pnlPrinProd.Controls.Add(Me.Label13)
        Me.pnlPrinProd.Location = New System.Drawing.Point(181, 114)
        Me.pnlPrinProd.Name = "pnlPrinProd"
        Me.pnlPrinProd.Size = New System.Drawing.Size(530, 603)
        Me.pnlPrinProd.TabIndex = 5
        '
        'pnlDetalle
        '
        Me.pnlDetalle.AutoScroll = True
        Me.pnlDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlDetalle.Location = New System.Drawing.Point(3, 61)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(527, 508)
        Me.pnlDetalle.TabIndex = 8
        '
        'lblDetalleOrden
        '
        Me.lblDetalleOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetalleOrden.ForeColor = System.Drawing.Color.White
        Me.lblDetalleOrden.Location = New System.Drawing.Point(6, 7)
        Me.lblDetalleOrden.Name = "lblDetalleOrden"
        Me.lblDetalleOrden.Size = New System.Drawing.Size(483, 24)
        Me.lblDetalleOrden.TabIndex = 3
        Me.lblDetalleOrden.Text = "Detalle de la orden:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(6, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 24)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Cant"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(160, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 24)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Nombre" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pnlPrinCategorias
        '
        Me.pnlPrinCategorias.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlPrinCategorias.Controls.Add(Me.btnAgregar)
        Me.pnlPrinCategorias.Controls.Add(Me.Label2)
        Me.pnlPrinCategorias.Controls.Add(Me.cbxProducto)
        Me.pnlPrinCategorias.Controls.Add(Me.lblCategorias)
        Me.pnlPrinCategorias.Controls.Add(Me.pnlCategorias)
        Me.pnlPrinCategorias.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlPrinCategorias.Location = New System.Drawing.Point(714, 116)
        Me.pnlPrinCategorias.Name = "pnlPrinCategorias"
        Me.pnlPrinCategorias.Size = New System.Drawing.Size(638, 613)
        Me.pnlPrinCategorias.TabIndex = 6
        '
        'btnAgregar
        '
        Me.btnAgregar.AutoSize = True
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Image = Global.SunChangSystem.My.Resources.Resources.btnAgregar1
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.Location = New System.Drawing.Point(531, 27)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(100, 45)
        Me.btnAgregar.TabIndex = 13
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 24)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Producto:"
        '
        'cbxProducto
        '
        Me.cbxProducto.BackColor = System.Drawing.SystemColors.MenuBar
        Me.cbxProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxProducto.FormattingEnabled = True
        Me.cbxProducto.IntegralHeight = False
        Me.cbxProducto.Location = New System.Drawing.Point(109, 32)
        Me.cbxProducto.MaxDropDownItems = 15
        Me.cbxProducto.Name = "cbxProducto"
        Me.cbxProducto.Size = New System.Drawing.Size(400, 32)
        Me.cbxProducto.TabIndex = 11
        '
        'lblCategorias
        '
        Me.lblCategorias.AutoSize = True
        Me.lblCategorias.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategorias.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCategorias.Location = New System.Drawing.Point(12, 95)
        Me.lblCategorias.Name = "lblCategorias"
        Me.lblCategorias.Size = New System.Drawing.Size(104, 24)
        Me.lblCategorias.TabIndex = 10
        Me.lblCategorias.Text = "Categorías:"
        '
        'pnlCategorias
        '
        Me.pnlCategorias.AutoScroll = True
        Me.pnlCategorias.Location = New System.Drawing.Point(16, 122)
        Me.pnlCategorias.Name = "pnlCategorias"
        Me.pnlCategorias.Size = New System.Drawing.Size(615, 447)
        Me.pnlCategorias.TabIndex = 9
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.ContabilidadToolStripMenuItem, Me.AdministradorToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1352, 33)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArchivoToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(88, 29)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'ContabilidadToolStripMenuItem
        '
        Me.ContabilidadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FondoInicialToolStripMenuItem, Me.CierreCajaToolStripMenuItem, Me.ARQUEOToolStripMenuItem, Me.MovimientosToolStripMenuItem, Me.AnularFacturaToolStripMenuItem, Me.ModificarFacturaToolStripMenuItem})
        Me.ContabilidadToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContabilidadToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ContabilidadToolStripMenuItem.Name = "ContabilidadToolStripMenuItem"
        Me.ContabilidadToolStripMenuItem.Size = New System.Drawing.Size(132, 29)
        Me.ContabilidadToolStripMenuItem.Text = "Contabilidad"
        '
        'FondoInicialToolStripMenuItem
        '
        Me.FondoInicialToolStripMenuItem.Name = "FondoInicialToolStripMenuItem"
        Me.FondoInicialToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.FondoInicialToolStripMenuItem.Text = "Fondo Inicial"
        '
        'CierreCajaToolStripMenuItem
        '
        Me.CierreCajaToolStripMenuItem.Name = "CierreCajaToolStripMenuItem"
        Me.CierreCajaToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.CierreCajaToolStripMenuItem.Text = "Cierre Caja"
        '
        'ARQUEOToolStripMenuItem
        '
        Me.ARQUEOToolStripMenuItem.Name = "ARQUEOToolStripMenuItem"
        Me.ARQUEOToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.ARQUEOToolStripMenuItem.Text = "Arqueo"
        '
        'MovimientosToolStripMenuItem
        '
        Me.MovimientosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PagoDeFacturasToolStripMenuItem, Me.SalidasDeEfectivoToolStripMenuItem, Me.IntroduccionesToolStripMenuItem, Me.ValesToolStripMenuItem})
        Me.MovimientosToolStripMenuItem.Name = "MovimientosToolStripMenuItem"
        Me.MovimientosToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.MovimientosToolStripMenuItem.Text = "Movimientos"
        '
        'PagoDeFacturasToolStripMenuItem
        '
        Me.PagoDeFacturasToolStripMenuItem.Name = "PagoDeFacturasToolStripMenuItem"
        Me.PagoDeFacturasToolStripMenuItem.Size = New System.Drawing.Size(240, 30)
        Me.PagoDeFacturasToolStripMenuItem.Text = "Pago de Facturas"
        '
        'SalidasDeEfectivoToolStripMenuItem
        '
        Me.SalidasDeEfectivoToolStripMenuItem.Name = "SalidasDeEfectivoToolStripMenuItem"
        Me.SalidasDeEfectivoToolStripMenuItem.Size = New System.Drawing.Size(240, 30)
        Me.SalidasDeEfectivoToolStripMenuItem.Text = "Salidas de Efectivo"
        '
        'IntroduccionesToolStripMenuItem
        '
        Me.IntroduccionesToolStripMenuItem.Name = "IntroduccionesToolStripMenuItem"
        Me.IntroduccionesToolStripMenuItem.Size = New System.Drawing.Size(240, 30)
        Me.IntroduccionesToolStripMenuItem.Text = "Introducciones"
        '
        'ValesToolStripMenuItem
        '
        Me.ValesToolStripMenuItem.Name = "ValesToolStripMenuItem"
        Me.ValesToolStripMenuItem.Size = New System.Drawing.Size(240, 30)
        Me.ValesToolStripMenuItem.Text = "Vales Y Bonos"
        '
        'AnularFacturaToolStripMenuItem
        '
        Me.AnularFacturaToolStripMenuItem.Name = "AnularFacturaToolStripMenuItem"
        Me.AnularFacturaToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.AnularFacturaToolStripMenuItem.Text = "Anular Factura"
        '
        'ModificarFacturaToolStripMenuItem
        '
        Me.ModificarFacturaToolStripMenuItem.Name = "ModificarFacturaToolStripMenuItem"
        Me.ModificarFacturaToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.ModificarFacturaToolStripMenuItem.Text = "Modificar Factura"
        '
        'AdministradorToolStripMenuItem
        '
        Me.AdministradorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportesToolStripMenuItem, Me.MenuToolStripMenuItem, Me.ProveedoresToolStripMenuItem})
        Me.AdministradorToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.AdministradorToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.AdministradorToolStripMenuItem.Name = "AdministradorToolStripMenuItem"
        Me.AdministradorToolStripMenuItem.Size = New System.Drawing.Size(151, 29)
        Me.AdministradorToolStripMenuItem.Text = "Administración"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VentasXDíaToolStripMenuItem, Me.ImpuestoDeVentasToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(189, 30)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'VentasXDíaToolStripMenuItem
        '
        Me.VentasXDíaToolStripMenuItem.Name = "VentasXDíaToolStripMenuItem"
        Me.VentasXDíaToolStripMenuItem.Size = New System.Drawing.Size(249, 30)
        Me.VentasXDíaToolStripMenuItem.Text = "Ventas x día"
        '
        'ImpuestoDeVentasToolStripMenuItem
        '
        Me.ImpuestoDeVentasToolStripMenuItem.Name = "ImpuestoDeVentasToolStripMenuItem"
        Me.ImpuestoDeVentasToolStripMenuItem.Size = New System.Drawing.Size(249, 30)
        Me.ImpuestoDeVentasToolStripMenuItem.Text = "Impuesto de Ventas"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CategoríaToolStripMenuItem, Me.ProductosToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(189, 30)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'CategoríaToolStripMenuItem
        '
        Me.CategoríaToolStripMenuItem.Name = "CategoríaToolStripMenuItem"
        Me.CategoríaToolStripMenuItem.Size = New System.Drawing.Size(174, 30)
        Me.CategoríaToolStripMenuItem.Text = "Categorías"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(174, 30)
        Me.ProductosToolStripMenuItem.Text = "Productos"
        '
        'ProveedoresToolStripMenuItem
        '
        Me.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem"
        Me.ProveedoresToolStripMenuItem.Size = New System.Drawing.Size(189, 30)
        Me.ProveedoresToolStripMenuItem.Text = "Proveedores"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'txtNombreCajero
        '
        Me.txtNombreCajero.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNombreCajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCajero.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtNombreCajero.Location = New System.Drawing.Point(500, 4)
        Me.txtNombreCajero.Name = "txtNombreCajero"
        Me.txtNombreCajero.Size = New System.Drawing.Size(419, 29)
        Me.txtNombreCajero.TabIndex = 8
        Me.txtNombreCajero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'timerLlamaMesero
        '
        Me.timerLlamaMesero.Interval = 5000
        '
        'TimerReproduceSonido
        '
        Me.TimerReproduceSonido.Interval = 5000
        '
        'Ordenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1352, 729)
        Me.Controls.Add(Me.txtNombreCajero)
        Me.Controls.Add(Me.txtHora)
        Me.Controls.Add(Me.pnlPrinCategorias)
        Me.Controls.Add(Me.pnlPrinProd)
        Me.Controls.Add(Me.pnlPrinOrdenes)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Ordenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Órdenes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrinOrdenes.ResumeLayout(False)
        Me.pnlPrinOrdenes.PerformLayout()
        Me.pnlPrinProd.ResumeLayout(False)
        Me.pnlPrinProd.PerformLayout()
        Me.pnlPrinCategorias.ResumeLayout(False)
        Me.pnlPrinCategorias.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnNuevaOrden As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents btnBorrar As Button
    Friend WithEvents pnlPrinOrdenes As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlPrinProd As Panel
    Friend WithEvents lblDetalleOrden As Label
    Friend WithEvents pnlPrinCategorias As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents pnlDetalle As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContabilidadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FondoInicialToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CierreCajaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlCategorias As Panel
    Friend WithEvents btnCategoria As Button
    Friend WithEvents btnProducto As Button
    Friend WithEvents btnOrden As Button
    Friend WithEvents lblCategorias As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents nupCantidad As NumericUpDown
    Friend WithEvents btnEditar As Button
    Dim posYDetalle = 5
    Dim posYBoton = 0
    Dim ordenActiva = 0
    Dim botonesProductos(10) As Button
    Public botonesOrdenes(10) As Button
    Dim listaDetallesOrden As List(Of OrdenTemporal) = New List(Of OrdenTemporal)
    Dim listaControlesDetalle As LinkedList(Of Object) = New LinkedList(Of Object)
    Friend WithEvents MovimientosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PagoDeFacturasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalidasDeEfectivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IntroduccionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pnlOrdenes As Panel
    Friend WithEvents btnCerrarSesion As Button
    Friend WithEvents txtHora As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txtNombreCajero As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbxProducto As ComboBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents ARQUEOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents AnularFacturaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AdministradorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentasXDíaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CategoríaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents timerLlamaMesero As Timer
    Friend WithEvents TimerReproduceSonido As Timer
    Friend WithEvents ImpuestoDeVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ValesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProveedoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificarFacturaToolStripMenuItem As ToolStripMenuItem
End Class