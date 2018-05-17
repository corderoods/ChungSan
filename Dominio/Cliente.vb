Imports SunChangSystem

Public Class Cliente
    Private codCliente As Int32
    Private nombreCliente As String
    Private apellido As String
    Private direccion As String
    Private eMail As String
    Private telefono As String
    Private credito As Int32
    Private direcciones As LinkedList(Of ClienteDireccion)
    Private telefonos As LinkedList(Of ClienteTelefono)

    Public Property CodClienteSG As Integer
        Get
            Return codCliente
        End Get
        Set(value As Integer)
            codCliente = value
        End Set
    End Property

    Public Property NombreClienteSG As String
        Get
            Return nombreCliente
        End Get
        Set(value As String)
            nombreCliente = value
        End Set
    End Property

    Public Property DireccionSG As String
        Get
            Return direccion
        End Get
        Set(value As String)
            direccion = value
        End Set
    End Property

    Public Property EMailSG As String
        Get
            Return eMail
        End Get
        Set(value As String)
            eMail = value
        End Set
    End Property

    Public Property TelefonoSG As String
        Get
            Return telefono
        End Get
        Set(value As String)
            telefono = value
        End Set
    End Property

    Public Property ApellidoSG As String
        Get
            Return apellido
        End Get
        Set(value As String)
            apellido = value
        End Set
    End Property

    Public Property CreditoSG As String
        Get
            Return credito
        End Get
        Set(value As String)
            credito = value
        End Set
    End Property

    Public Property Direcciones_ As LinkedList(Of ClienteDireccion)
        Get
            Return direcciones
        End Get
        Set(value As LinkedList(Of ClienteDireccion))
            direcciones = value
        End Set
    End Property

    Public Property Telefonos_ As LinkedList(Of ClienteTelefono)
        Get
            Return telefonos
        End Get
        Set(value As LinkedList(Of ClienteTelefono))
            telefonos = value
        End Set
    End Property

    Public Sub New()

    End Sub

End Class
