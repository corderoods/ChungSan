Public Class FacturaDetalle
    Private num_factura, num_orden, cod_producto, cantidad, sub_total As Integer
    Private cod_estado_factura As String

    Public Sub New()
    End Sub

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

    Public Property CodProducto As Integer
        Get
            Return cod_producto
        End Get
        Set(value As Integer)
            cod_producto = value
        End Set
    End Property

    Public Property Cantidad_ As Integer
        Get
            Return cantidad
        End Get
        Set(value As Integer)
            cantidad = value
        End Set
    End Property

    Public Property SubTotal As Integer
        Get
            Return sub_total
        End Get
        Set(value As Integer)
            sub_total = value
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
End Class