<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Anular
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
        Me.pnlFacturas = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.pnlFactura = New System.Windows.Forms.Panel()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblSalonero = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblMesa = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblCajero = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblNumFactura = New System.Windows.Forms.Label()
        Me.pnlProductoFactura = New System.Windows.Forms.Panel()
        Me.lblTextSalonero = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlFactura.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlFacturas
        '
        Me.pnlFacturas.Location = New System.Drawing.Point(0, 36)
        Me.pnlFacturas.Name = "pnlFacturas"
        Me.pnlFacturas.Size = New System.Drawing.Size(303, 659)
        Me.pnlFacturas.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(137, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Monto"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(23, 13)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(64, 20)
        Me.Label52.TabIndex = 11
        Me.Label52.Text = "Factura"
        '
        'pnlFactura
        '
        Me.pnlFactura.BackColor = System.Drawing.Color.White
        Me.pnlFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlFactura.Controls.Add(Me.lblCliente)
        Me.pnlFactura.Controls.Add(Me.Button1)
        Me.pnlFactura.Controls.Add(Me.Panel11)
        Me.pnlFactura.Controls.Add(Me.lblSalonero)
        Me.pnlFactura.Controls.Add(Me.lblFecha)
        Me.pnlFactura.Controls.Add(Me.lblMesa)
        Me.pnlFactura.Controls.Add(Me.Label18)
        Me.pnlFactura.Controls.Add(Me.lblCajero)
        Me.pnlFactura.Controls.Add(Me.Label17)
        Me.pnlFactura.Controls.Add(Me.Label16)
        Me.pnlFactura.Controls.Add(Me.Label15)
        Me.pnlFactura.Controls.Add(Me.Label14)
        Me.pnlFactura.Controls.Add(Me.Label10)
        Me.pnlFactura.Controls.Add(Me.lblNumFactura)
        Me.pnlFactura.Controls.Add(Me.pnlProductoFactura)
        Me.pnlFactura.Controls.Add(Me.lblTextSalonero)
        Me.pnlFactura.Controls.Add(Me.Label11)
        Me.pnlFactura.Controls.Add(Me.Label9)
        Me.pnlFactura.Controls.Add(Me.Label8)
        Me.pnlFactura.Controls.Add(Me.Label7)
        Me.pnlFactura.Controls.Add(Me.Label5)
        Me.pnlFactura.Controls.Add(Me.Label13)
        Me.pnlFactura.Controls.Add(Me.lblCantidad)
        Me.pnlFactura.Controls.Add(Me.PictureBox1)
        Me.pnlFactura.Controls.Add(Me.Label3)
        Me.pnlFactura.Location = New System.Drawing.Point(301, 0)
        Me.pnlFactura.Name = "pnlFactura"
        Me.pnlFactura.Size = New System.Drawing.Size(524, 704)
        Me.pnlFactura.TabIndex = 3
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(107, 226)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(0, 20)
        Me.lblCliente.TabIndex = 44
        '
        'Button1
        '
        Me.Button1.AutoSize = True
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.SunChangSystem.My.Resources.Resources.btnAnular
        Me.Button1.Location = New System.Drawing.Point(195, 611)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 70)
        Me.Button1.TabIndex = 43
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.PictureBox2)
        Me.Panel11.Controls.Add(Me.Label22)
        Me.Panel11.Controls.Add(Me.lblTotal)
        Me.Panel11.Location = New System.Drawing.Point(149, 558)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(364, 47)
        Me.Panel11.TabIndex = 4
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SunChangSystem.My.Resources.Resources.separador
        Me.PictureBox2.Location = New System.Drawing.Point(70, 11)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(290, 4)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 43
        Me.PictureBox2.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(70, 18)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 24)
        Me.Label22.TabIndex = 23
        Me.Label22.Text = "Total:"
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(189, 18)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(171, 24)
        Me.lblTotal.TabIndex = 24
        Me.lblTotal.Text = "0,00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSalonero
        '
        Me.lblSalonero.AutoSize = True
        Me.lblSalonero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalonero.Location = New System.Drawing.Point(113, 181)
        Me.lblSalonero.Name = "lblSalonero"
        Me.lblSalonero.Size = New System.Drawing.Size(0, 20)
        Me.lblSalonero.TabIndex = 38
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(287, 160)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(0, 20)
        Me.lblFecha.TabIndex = 37
        '
        'lblMesa
        '
        Me.lblMesa.AutoSize = True
        Me.lblMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMesa.Location = New System.Drawing.Point(454, 181)
        Me.lblMesa.Name = "lblMesa"
        Me.lblMesa.Size = New System.Drawing.Size(0, 20)
        Me.lblMesa.TabIndex = 36
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(90, 223)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(0, 20)
        Me.Label18.TabIndex = 35
        '
        'lblCajero
        '
        Me.lblCajero.AutoSize = True
        Me.lblCajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajero.Location = New System.Drawing.Point(101, 203)
        Me.lblCajero.Name = "lblCajero"
        Me.lblCajero.Size = New System.Drawing.Size(0, 20)
        Me.lblCajero.TabIndex = 35
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(87, 246)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(0, 20)
        Me.Label17.TabIndex = 34
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(63, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(181, 16)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Momentum Pinares 2do piso."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(261, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(156, 16)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "TeleFax: (506) 2271-4556"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(261, 129)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 16)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Céd: 3-101-201359"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(102, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(142, 16)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Hermanos Casaw S.A."
        '
        'lblNumFactura
        '
        Me.lblNumFactura.AutoSize = True
        Me.lblNumFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFactura.Location = New System.Drawing.Point(144, 156)
        Me.lblNumFactura.Name = "lblNumFactura"
        Me.lblNumFactura.Size = New System.Drawing.Size(0, 25)
        Me.lblNumFactura.TabIndex = 29
        '
        'pnlProductoFactura
        '
        Me.pnlProductoFactura.AutoScroll = True
        Me.pnlProductoFactura.Location = New System.Drawing.Point(21, 284)
        Me.pnlProductoFactura.Name = "pnlProductoFactura"
        Me.pnlProductoFactura.Size = New System.Drawing.Size(488, 253)
        Me.pnlProductoFactura.TabIndex = 28
        '
        'lblTextSalonero
        '
        Me.lblTextSalonero.AutoSize = True
        Me.lblTextSalonero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextSalonero.Location = New System.Drawing.Point(30, 181)
        Me.lblTextSalonero.Name = "lblTextSalonero"
        Me.lblTextSalonero.Size = New System.Drawing.Size(77, 20)
        Me.lblTextSalonero.TabIndex = 17
        Me.lblTextSalonero.Text = "Salonero:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(383, 181)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 20)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Mesa: #"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(30, 226)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 20)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Cliente:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(418, 259)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 18)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Monto."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(72, 259)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 18)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Descripción."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(223, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Fecha:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(30, 203)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 20)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Cajero:"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.Location = New System.Drawing.Point(18, 259)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(48, 18)
        Me.lblCantidad.TabIndex = 0
        Me.lblCantidad.Text = "Cant."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SunChangSystem.My.Resources.Resources.Logo_Chung_San_Logo
        Me.PictureBox1.Location = New System.Drawing.Point(149, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(182, 95)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 25)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Factura: #"
        '
        'Anular
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(822, 695)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlFactura)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.pnlFacturas)
        Me.Location = New System.Drawing.Point(250, 0)
        Me.Name = "Anular"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Anular"
        Me.pnlFactura.ResumeLayout(False)
        Me.pnlFactura.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlFacturas As Panel
    Friend WithEvents pnlFactura As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Label22 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblSalonero As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents lblMesa As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblCajero As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblNumFactura As Label
    Friend WithEvents pnlProductoFactura As Panel
    Friend WithEvents lblTextSalonero As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblCantidad As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label52 As Label

    Dim lblNumeroFactura As Label
    Dim listaEtiquetasNumeroFactura As New List(Of Label)

    Dim lblMontoTotal As Label
    Dim listaEtiquetasMontoTotal As New List(Of Label)



    Dim lblMontoFactura As Label
    Dim listaEtiquetasMontoFactura As New List(Of Label)

    Dim btnAnular As Button
    Dim listaBotones As New List(Of Button)

    Dim listaControles As New List(Of Object)

    Dim NumFactPosX, montoFacturaPosX As Double
    Dim NumFactPosY, montoFacturaPosY As Double
    Dim BotonAnularFactPosX, BotonAnularFactPosY As Double
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblCliente As Label
End Class
