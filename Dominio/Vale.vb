Public Class Vale
    Private codVale As Integer
    Private cajero As String
    Private fecha As String
    Private monto As Decimal
    Private cancelado As String
    Private codEmpleado As Decimal


    Public Sub New()

    End Sub

    Public Property CodVale_ As Integer
        Get
            Return codVale
        End Get
        Set(value As Integer)
            codVale = value
        End Set
    End Property

    Public Property Cajero_ As String
        Get
            Return cajero
        End Get
        Set(value As String)
            cajero = value
        End Set
    End Property

    Public Property Fecha_ As String
        Get
            Return fecha
        End Get
        Set(value As String)
            fecha = value
        End Set
    End Property

    Public Property Monto_ As Decimal
        Get
            Return monto
        End Get
        Set(value As Decimal)
            monto = value
        End Set
    End Property

    Public Property Cancelado_ As String
        Get
            Return cancelado
        End Get
        Set(value As String)
            cancelado = value
        End Set
    End Property

    Public Property CodEmpleado_ As Decimal
        Get
            Return codEmpleado
        End Get
        Set(value As Decimal)
            codEmpleado = value
        End Set
    End Property
End Class
