Public Class ClienteEmail
    Private cod_Email As Integer
    Private correo_Electronico As String

    Public Sub New()

    End Sub

    Public Property cod_EmailSG() As Integer
        Get
            Return cod_Email
        End Get
        Set(value As Integer)
            Me.cod_Email = value
        End Set
    End Property

    Public Property correo_ElectronicoSG As String
        Get
            Return correo_Electronico
        End Get
        Set(value As String)
            Me.correo_Electronico = value
        End Set
    End Property

End Class
