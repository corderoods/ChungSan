Public Class Mensaje
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Public Sub tipoMensaje(tipoMensaje As String)
        If (tipoMensaje = "error") Then
            Me.imageIcon.Image = Global.SunChangSystem.My.Resources.Resources.iconAdvertencia
        Else
            Me.imageIcon.Image = Global.SunChangSystem.My.Resources.Resources.iconExito
        End If
    End Sub
End Class