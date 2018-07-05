Imports SunChangSystem

Public Class Cliente
    Private codCliente As Int32
    Private nombreCliente As String
    Private apellido1, apellido2 As String
    Private credito As Int32
    Private tipoIdent As Integer
    Private identificacion As Int64
    Private diplomatico As Integer
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

    Public Property Apellido1SG As String
        Get
            Return apellido1
        End Get
        Set(value As String)
            apellido1 = value
        End Set
    End Property

    Public Property Apellido2SG As String
        Get
            Return apellido2
        End Get
        Set(value As String)
            apellido2 = value
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

    Public Property tipoIdentSG As Integer
        Get
            Return Me.tipoIdent
        End Get
        Set(value As Integer)
            Me.tipoIdent = value
        End Set
    End Property

    Public Property identificacionSG As Int64
        Get
            Return Me.identificacion
        End Get
        Set(value As Int64)
            Me.identificacion = value
        End Set
    End Property

    Public Property diplomaticoSG As Integer
        Get
            Return diplomatico
        End Get
        Set(value As Integer)
            Me.diplomatico = value
        End Set
    End Property

    Public Sub New()

    End Sub

End Class
