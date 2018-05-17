Public Class ReporteFondos
    Dim empleado_asignan, moneda, denominacion As String
    Dim fecha As DateTime
    Dim cantidad, subtotal As Double

    Public Property Empleado_asignanSG As String
        Get
            Return empleado_asignan
        End Get
        Set(value As String)
            empleado_asignan = value
        End Set
    End Property

    Public Property MonedaSG As String
        Get
            Return moneda
        End Get
        Set(value As String)
            moneda = value
        End Set
    End Property

    Public Property DenominacionSG As String
        Get
            Return denominacion
        End Get
        Set(value As String)
            denominacion = value
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

    Public Property CantidadSG As Double
        Get
            Return cantidad
        End Get
        Set(value As Double)
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
End Class
