Imports SunChangSystem

Public Class Abono

    Private codAbono As Integer
    Private vale As Vale
    Private cajero As String
    Private fecha As String
    Private monto As Decimal

    Public Property CodAbono_ As Integer
        Get
            Return codAbono
        End Get
        Set(value As Integer)
            codAbono = value
        End Set
    End Property

    Public Property Vale_ As Vale
        Get
            Return vale
        End Get
        Set(value As Vale)
            vale = value
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

End Class
