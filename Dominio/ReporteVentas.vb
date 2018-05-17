Public Class ReporteVentas
    Private empleado, fecha, cliente, salonero, ubicacion As String
    Private monto As Double

    Public Property ClienteSG As String
        Get
            Return cliente
        End Get
        Set(value As String)
            cliente = value
        End Set
    End Property

    Public Property EmpleadoSG As String
        Get
            Return empleado
        End Get
        Set(value As String)
            empleado = value
        End Set
    End Property

    Public Property FechaSG As String
        Get
            Return fecha
        End Get
        Set(value As String)
            fecha = value
        End Set
    End Property

    Public Property MontoSG As Double
        Get
            Return monto
        End Get
        Set(value As Double)
            monto = value
        End Set
    End Property

    Public Property SaloneroSG As String
        Get
            Return salonero
        End Get
        Set(value As String)
            salonero = value
        End Set
    End Property

    Public Property UbicacionSG As String
        Get
            Return ubicacion
        End Get
        Set(value As String)
            ubicacion = value
        End Set
    End Property

    Public Sub New()

    End Sub
End Class
