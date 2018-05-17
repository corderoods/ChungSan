Public Class ClienteTelefono

    Private codTelefono As Int32
    Private telefono As String

    Public Property CodTelefono_ As Integer
        Get
            Return codTelefono
        End Get
        Set(value As Integer)
            codTelefono = value
        End Set
    End Property

    Public Property Telefono_ As String
        Get
            Return telefono
        End Get
        Set(value As String)
            telefono = value
        End Set
    End Property
End Class
