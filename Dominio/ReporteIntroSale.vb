Public Class ReporteIntroSale
    Private descripcion As String
    Private fecha As DateTime
    Private cantidad As Int16
    Public subtotal, tipocambio As Double

    Public Sub New()

    End Sub

    Public Property DescripcionSG As String
        Get
            Return descripcion
        End Get
        Set(value As String)
            descripcion = value
        End Set
    End Property

    Public Property FechaSG As Date
        Get
            Return fecha
        End Get
        Set(value As Date)
            fecha = value
        End Set
    End Property

    Public Property CantidadSG As Short
        Get
            Return cantidad
        End Get
        Set(value As Short)
            cantidad = value
        End Set
    End Property

    Public Property SubtotalSG As Double
        Get
            Return subtotal
        End Get
        Set(value As Double)
            subtotal = value
        End Set
    End Property

    Public Property TipocambioSG As Double
        Get
            Return tipocambio
        End Get
        Set(value As Double)
            tipocambio = value
        End Set
    End Property
End Class
