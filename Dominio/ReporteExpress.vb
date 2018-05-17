Public Class ReporteExpress
    Public _empleado, _cliente, _direccion, _telefono, _fecha As String
    Private _monto_express As Double

    Public Property ClienteSG As String
        Get
            Return _cliente
        End Get
        Set(value As String)
            _cliente = value
        End Set
    End Property

    Public Property DireccionSG As String
        Get
            Return _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property

    Public Property EmpleadoSG As String
        Get
            Return _empleado
        End Get
        Set(value As String)
            _empleado = value
        End Set
    End Property

    Public Property FechaSG As String
        Get
            Return _fecha
        End Get
        Set(value As String)
            _fecha = value
        End Set
    End Property

    Public Property Monto_expressSG As Double
        Get
            Return _monto_express
        End Get
        Set(value As Double)
            _monto_express = value
        End Set
    End Property

    Public Property TelefonoSG As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property
End Class
