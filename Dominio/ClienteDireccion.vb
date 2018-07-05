Public Class ClienteDireccion

    Private codDireccion As Int32
    Private direccion As String
    Private provincia, canton, distrito, barrio As Integer


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

    Public Property provinciaSG As Integer
        Get
            Return provincia
        End Get
        Set(value As Integer)
            Me.provincia = value
        End Set
    End Property

    Public Property cantonSG As Integer
        Get
            Return canton
        End Get
        Set(value As Integer)
            Me.canton = value
        End Set
    End Property

    Public Property distritoSG As Integer
        Get
            Return distrito
        End Get
        Set(value As Integer)
            Me.distrito = value
        End Set
    End Property

    Public Property barrioSG As Integer
        Get
            Return barrio
        End Get
        Set(value As Integer)
            Me.barrio = value
        End Set
    End Property
End Class
