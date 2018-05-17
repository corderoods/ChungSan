Public Class Pago
    Private num_pago, num_factura, num_orden, monto, vuelto As Integer
    Private cod_estado_factura, tipo_pago As String

    Public Sub New()

    End Sub

    Public Property NumPago As Integer
        Get
            Return num_pago
        End Get
        Set(value As Integer)
            num_pago = value
        End Set
    End Property

    Public Property NumFactura As Integer
        Get
            Return num_factura
        End Get
        Set(value As Integer)
            num_factura = value
        End Set
    End Property

    Public Property NumOrden As Integer
        Get
            Return num_orden
        End Get
        Set(value As Integer)
            num_orden = value
        End Set
    End Property

    Public Property Monto_ As Integer
        Get
            Return monto
        End Get
        Set(value As Integer)
            monto = value
        End Set
    End Property

    Public Property Vuelto_ As Integer
        Get
            Return vuelto
        End Get
        Set(value As Integer)
            vuelto = value
        End Set
    End Property

    Public Property CodEstadoFactura As String
        Get
            Return cod_estado_factura
        End Get
        Set(value As String)
            cod_estado_factura = value
        End Set
    End Property

    Public Property TipoPago As String
        Get
            Return tipo_pago
        End Get
        Set(value As String)
            tipo_pago = value
        End Set
    End Property
End Class
