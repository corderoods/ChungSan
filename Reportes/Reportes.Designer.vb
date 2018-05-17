<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reportes
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
        Me.VistaReportes = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'VistaReportes
        '
        Me.VistaReportes.ActiveViewIndex = -1
        Me.VistaReportes.AutoScroll = True
        Me.VistaReportes.AutoSize = True
        Me.VistaReportes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VistaReportes.Cursor = System.Windows.Forms.Cursors.Default
        Me.VistaReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VistaReportes.Location = New System.Drawing.Point(0, 0)
        Me.VistaReportes.Name = "VistaReportes"
        Me.VistaReportes.Size = New System.Drawing.Size(813, 517)
        Me.VistaReportes.TabIndex = 0
        '
        'Reportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 517)
        Me.Controls.Add(Me.VistaReportes)
        Me.Name = "Reportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents VistaReportes As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
