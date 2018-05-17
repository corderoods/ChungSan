Public Class Proveedor
    Private codigo As Int32
    Private nombre As String
    Private telefono As String
    Private contacto As String
    Private email As String
    Private direccion As String
    Private observaciones As String
    Private credito As Boolean
    Private dias_credito As Int32

    Public Property CodigoProveedor As Integer
        Get
            Return codigo
        End Get
        Set(value As Integer)
            codigo = value
        End Set
    End Property

    Public Property NombreProveedor As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property TelefonoProveedor As String
        Get
            Return telefono
        End Get
        Set(value As String)
            telefono = value
        End Set
    End Property

    Public Property ContactoProveedor As String
        Get
            Return contacto
        End Get
        Set(value As String)
            contacto = value
        End Set
    End Property

    Public Property EmailProveedor As String
        Get
            Return email
        End Get
        Set(value As String)
            email = value
        End Set
    End Property

    Public Property DireccionProveedor As String
        Get
            Return direccion
        End Get
        Set(value As String)
            direccion = value
        End Set
    End Property

    Public Property ObservacionesProveedor As String
        Get
            Return observaciones
        End Get
        Set(value As String)
            observaciones = value
        End Set
    End Property

    Public Property CreditoProveedor As Boolean
        Get
            Return credito
        End Get
        Set(value As Boolean)
            credito = value
        End Set
    End Property

    Public Property Dias_creditoProveedor As Integer
        Get
            Return dias_credito
        End Get
        Set(value As Integer)
            dias_credito = value
        End Set
    End Property

    Public Sub New()

    End Sub
End Class
