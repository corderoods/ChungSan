Public Class ClienteDireccion

    Private codDireccion As Int32
    Private direccion As String

    Public Property CodDireccion_ As Integer
        Get
            Return codDireccion
        End Get
        Set(value As Integer)
            codDireccion = value
        End Set
    End Property

    Public Property Direccion_ As String
        Get
            Return direccion
        End Get
        Set(value As String)
            direccion = value
        End Set
    End Property
End Class
