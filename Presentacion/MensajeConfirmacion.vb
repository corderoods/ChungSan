Public Class MensajeConfirmacion

    Public Sub New()
        decision = False

        InitializeComponent()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        decision = True
        Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        decision = False
        Close()
    End Sub
End Class