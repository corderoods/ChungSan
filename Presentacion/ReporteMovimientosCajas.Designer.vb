<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReporteMovimientosCajas
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
    Public components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlLista = New System.Windows.Forms.Panel()
        Me.lblOpcion2 = New System.Windows.Forms.Label()
        Me.pbSegundaOpcion = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.pbPrimerOpcion = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblEvento = New System.Windows.Forms.Label()
        Me.lblCambio = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.lblDenominacion = New System.Windows.Forms.Label()
        Me.pnlSuperior = New System.Windows.Forms.Panel()
        Me.lblSubtotalFondo = New System.Windows.Forms.Label()
        Me.lblCantidadFondo = New System.Windows.Forms.Label()
        Me.lblDenominacionFondo = New System.Windows.Forms.Label()
        Me.lblMonedaFondo = New System.Windows.Forms.Label()
        Me.lblFechaInicioFondo = New System.Windows.Forms.Label()
        Me.lblEmpleadoRecibeFondo = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.pnlLista.SuspendLayout()
        CType(Me.pbSegundaOpcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.pbPrimerOpcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSuperior.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLista
        '
        Me.pnlLista.AutoScroll = True
        Me.pnlLista.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlLista.Controls.Add(Me.lblOpcion2)
        Me.pnlLista.Controls.Add(Me.pbSegundaOpcion)
        Me.pnlLista.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlLista.Location = New System.Drawing.Point(0, 171)
        Me.pnlLista.Name = "pnlLista"
        Me.pnlLista.Size = New System.Drawing.Size(927, 378)
        Me.pnlLista.TabIndex = 0
        '
        'lblOpcion2
        '
        Me.lblOpcion2.AutoSize = True
        Me.lblOpcion2.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.lblOpcion2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpcion2.ForeColor = System.Drawing.Color.White
        Me.lblOpcion2.Location = New System.Drawing.Point(33, 22)
        Me.lblOpcion2.Name = "lblOpcion2"
        Me.lblOpcion2.Size = New System.Drawing.Size(77, 25)
        Me.lblOpcion2.TabIndex = 0
        Me.lblOpcion2.Text = "Label1"
        '
        'pbSegundaOpcion
        '
        Me.pbSegundaOpcion.Image = Global.SunChangSystem.My.Resources.Resources.btnOrden2
        Me.pbSegundaOpcion.Location = New System.Drawing.Point(12, 12)
        Me.pbSegundaOpcion.Name = "pbSegundaOpcion"
        Me.pbSegundaOpcion.Size = New System.Drawing.Size(350, 47)
        Me.pbSegundaOpcion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSegundaOpcion.TabIndex = 23
        Me.pbSegundaOpcion.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblReporte)
        Me.Panel2.Controls.Add(Me.pbPrimerOpcion)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.btnImprimir)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(927, 83)
        Me.Panel2.TabIndex = 3
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.lblReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.ForeColor = System.Drawing.Color.White
        Me.lblReporte.Location = New System.Drawing.Point(298, 30)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(0, 25)
        Me.lblReporte.TabIndex = 22
        '
        'pbPrimerOpcion
        '
        Me.pbPrimerOpcion.Image = Global.SunChangSystem.My.Resources.Resources.btnOrden2
        Me.pbPrimerOpcion.Location = New System.Drawing.Point(276, 22)
        Me.pbPrimerOpcion.Name = "pbPrimerOpcion"
        Me.pbPrimerOpcion.Size = New System.Drawing.Size(350, 47)
        Me.pbPrimerOpcion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPrimerOpcion.TabIndex = 21
        Me.pbPrimerOpcion.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SunChangSystem.My.Resources.Resources.cover2
        Me.PictureBox2.Location = New System.Drawing.Point(709, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(193, 76)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SunChangSystem.My.Resources.Resources.cover2
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
        Me.btnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnImprimir.Image = Global.SunChangSystem.My.Resources.Resources.btnImprimirOrden1
        Me.btnImprimir.Location = New System.Drawing.Point(38, 9)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(155, 62)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'lblEvento
        '
        Me.lblEvento.Location = New System.Drawing.Point(0, 0)
        Me.lblEvento.Name = "lblEvento"
        Me.lblEvento.Size = New System.Drawing.Size(100, 23)
        Me.lblEvento.TabIndex = 1
        '
        'lblCambio
        '
        Me.lblCambio.Location = New System.Drawing.Point(0, 0)
        Me.lblCambio.Name = "lblCambio"
        Me.lblCambio.Size = New System.Drawing.Size(100, 23)
        Me.lblCambio.TabIndex = 3
        '
        'lblSubtotal
        '
        Me.lblSubtotal.Location = New System.Drawing.Point(0, 0)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(100, 23)
        Me.lblSubtotal.TabIndex = 4
        '
        'lblCantidad
        '
        Me.lblCantidad.Location = New System.Drawing.Point(0, 0)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(100, 23)
        Me.lblCantidad.TabIndex = 2
        '
        'lblDenominacion
        '
        Me.lblDenominacion.Location = New System.Drawing.Point(0, 0)
        Me.lblDenominacion.Name = "lblDenominacion"
        Me.lblDenominacion.Size = New System.Drawing.Size(100, 23)
        Me.lblDenominacion.TabIndex = 0
        '
        'pnlSuperior
        '
        Me.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlSuperior.Controls.Add(Me.lblSubtotalFondo)
        Me.pnlSuperior.Controls.Add(Me.lblCantidadFondo)
        Me.pnlSuperior.Controls.Add(Me.lblDenominacionFondo)
        Me.pnlSuperior.Controls.Add(Me.lblMonedaFondo)
        Me.pnlSuperior.Controls.Add(Me.lblFechaInicioFondo)
        Me.pnlSuperior.Controls.Add(Me.lblEmpleadoRecibeFondo)
        Me.pnlSuperior.Controls.Add(Me.lblDenominacion)
        Me.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSuperior.Location = New System.Drawing.Point(0, 0)
        Me.pnlSuperior.Name = "pnlSuperior"
        Me.pnlSuperior.Size = New System.Drawing.Size(927, 549)
        Me.pnlSuperior.TabIndex = 12
        '
        'lblSubtotalFondo
        '
        Me.lblSubtotalFondo.Location = New System.Drawing.Point(0, 0)
        Me.lblSubtotalFondo.Name = "lblSubtotalFondo"
        Me.lblSubtotalFondo.Size = New System.Drawing.Size(100, 23)
        Me.lblSubtotalFondo.TabIndex = 0
        '
        'lblCantidadFondo
        '
        Me.lblCantidadFondo.Location = New System.Drawing.Point(0, 0)
        Me.lblCantidadFondo.Name = "lblCantidadFondo"
        Me.lblCantidadFondo.Size = New System.Drawing.Size(100, 23)
        Me.lblCantidadFondo.TabIndex = 1
        '
        'lblDenominacionFondo
        '
        Me.lblDenominacionFondo.Location = New System.Drawing.Point(0, 0)
        Me.lblDenominacionFondo.Name = "lblDenominacionFondo"
        Me.lblDenominacionFondo.Size = New System.Drawing.Size(100, 23)
        Me.lblDenominacionFondo.TabIndex = 2
        '
        'lblMonedaFondo
        '
        Me.lblMonedaFondo.Location = New System.Drawing.Point(0, 0)
        Me.lblMonedaFondo.Name = "lblMonedaFondo"
        Me.lblMonedaFondo.Size = New System.Drawing.Size(100, 23)
        Me.lblMonedaFondo.TabIndex = 3
        '
        'lblFechaInicioFondo
        '
        Me.lblFechaInicioFondo.Location = New System.Drawing.Point(0, 0)
        Me.lblFechaInicioFondo.Name = "lblFechaInicioFondo"
        Me.lblFechaInicioFondo.Size = New System.Drawing.Size(100, 23)
        Me.lblFechaInicioFondo.TabIndex = 4
        '
        'lblEmpleadoRecibeFondo
        '
        Me.lblEmpleadoRecibeFondo.Location = New System.Drawing.Point(0, 0)
        Me.lblEmpleadoRecibeFondo.Name = "lblEmpleadoRecibeFondo"
        Me.lblEmpleadoRecibeFondo.Size = New System.Drawing.Size(100, 23)
        Me.lblEmpleadoRecibeFondo.TabIndex = 5
        '
        'ReporteMovimientosCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 549)
        Me.Controls.Add(Me.pnlLista)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlSuperior)
        Me.MaximizeBox = False
        Me.Name = "ReporteMovimientosCajas"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Movimientos de Cajas"
        Me.pnlLista.ResumeLayout(False)
        Me.pnlLista.PerformLayout()
        CType(Me.pbSegundaOpcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbPrimerOpcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSuperior.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlLista As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnImprimir As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents pnlSuperior As Panel

    ' LABELS DE REPORTE DE INTRODUCCIONES Y SALIDAS DE EFECTIVO
    Dim lblEvento As Label
    Dim lblDenominacion As Label
    Dim lblCantidad As Label
    Dim lblSubtotal As Label
    Dim lblCambio As Label

    ' VARIABLES PARA EL MANEJO DE LAS POSICIONES DE LAS CAJAS DE TEXTO PARA 
    ' EL REPORTE DE INTRODUCCIONES Y SALIDAS DE EFECTIVO
    Dim fechaPosX, denominacionPosX, cantidadPosX, subtotalPosX, cambioPosX As Double
    Dim fechaPosY, denominacionPosY, cantidadPosY, subtotalPosY, cambioPosY As Double

    ' CAJAS DE TEXTO PARA EL REPORTE DE INTRODUCCIONES Y SALIDAS DE EFECTIVO
    Dim txtFecha As TextBox
    Dim listaCajasTextoFecha As New List(Of TextBox)
    Dim txtDenominacion As TextBox
    Dim listaCajasTextoDenominacion As New List(Of TextBox)
    Dim txtCantidad As TextBox
    Dim listaCajasTextoCantidad As New List(Of TextBox)
    Dim txtSubtotal As TextBox
    Dim listaCajasTextoSubtotal As New List(Of TextBox)
    Dim txtTipoCambio As TextBox
    Dim listaCajasTextoTipoCambio As New List(Of TextBox)

    ' LISTA QUE CONTENDRA TODOS LOS ELEMENTOS DE LA PANTALLA
    Dim listaControles As New List(Of Object)

    ' LABELS DE REPORTE DE INTRODUCCIONES Y SALIDAS DE EFECTIVO
    Dim lblSubtotalFondo As Label
    Dim lblCantidadFondo As Label
    Dim lblDenominacionFondo As Label
    Dim lblMonedaFondo As Label
    Dim lblFechaInicioFondo As Label
    Dim lblEmpleadoRecibeFondo As Label

    ' VARIABLES PARA EL MANEJO DE LAS POSICIONES DE LAS CAJAS DE TEXTO PARA 
    ' EL REPORTE DE FONDO INICIAL Y FONDO FINAL
    Dim usuarioPosX, fechaFondosPosX, denominacionFondosPosX, cantidadFondosPosX, subtotalFondosPosX, monedaPosX As Double
    Dim usuarioPosY, fechaFondosPosY, denominacionFondosPosY, cantidadFondosPosY, subtotalFondosPosY, monedaPosY As Double

    ' CAJAS DE TEXTO PARA EL REPORTE DE FONDO DE INICIO Y DE CIERRE
    Dim txtFechaFondos As TextBox
    Dim listaCajasTextoFechaFondos As New List(Of TextBox)
    Dim txtDenominacionFondos As TextBox
    Dim listaCajasTextoDenominacionFondos As New List(Of TextBox)
    Dim txtCantidadFondos As TextBox
    Dim listaCajasTextoCantidadFondos As New List(Of TextBox)
    Dim txtSubtotalFondos As TextBox
    Dim listaCajasTextoSubtotalFondos As New List(Of TextBox)
    Dim txtUsuarioAsignaFondos As TextBox
    Dim listaCajasTextoUsuarioAsignaFondos As New List(Of TextBox)
    Dim txtTipoMonedaFondos As TextBox
    Dim listaCajasTextoTipoMonedaFondos As New List(Of TextBox)
    Friend WithEvents pbPrimerOpcion As PictureBox
    Friend WithEvents lblReporte As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents lblOpcion2 As Label
    Friend WithEvents pbSegundaOpcion As PictureBox
End Class
