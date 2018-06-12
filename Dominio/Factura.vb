Public Class Factura
    Private num_factura, num_orden, monto_total, cod_Datafono As Integer
    Private fecha_factura As DateTime
    Private cod_estado_factura, nombreCliente, estado As String
    Private descuento As Double

    Private subtotal, monto_descuento, porcentaje_descuento, impserv, impvtas, express As Double


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

    Public Property FechaFactura As Date
        Get
            Return fecha_factura
        End Get
        Set(value As Date)
            fecha_factura = value
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

    Public Property Descuento_ As Double
        Get
            Return descuento
        End Get
        Set(value As Double)
            descuento = value
        End Set
    End Property

    Public Property MontoTotal As Integer
        Get
            Return monto_total
        End Get
        Set(value As Integer)
            monto_total = value
        End Set
    End Property

    Public Property NombreCliente_ As String
        Get
            Return nombreCliente
        End Get
        Set(value As String)
            nombreCliente = value
        End Set
    End Property

    Public Property Estado_ As String
        Get
            Return estado
        End Get
        Set(value As String)
            estado = value
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

    Public Property Monto_descuentoSG As Double
        Get
            Return monto_descuento
        End Get
        Set(value As Double)
            monto_descuento = value
        End Set
    End Property

    Public Property Porcentaje_descuentoSG As Double
        Get
            Return porcentaje_descuento
        End Get
        Set(value As Double)
            porcentaje_descuento = value
        End Set
    End Property

    Public Property ImpservSG As Double
        Get
            Return impserv
        End Get
        Set(value As Double)
            impserv = value
        End Set
    End Property

    Public Property ImpvtasSG As Double
        Get
            Return impvtas
        End Get
        Set(value As Double)
            impvtas = value
        End Set
    End Property

    Public Property ExpressSG As Double
        Get
            Return express
        End Get
        Set(value As Double)
            express = value
        End Set
    End Property

    Public Property cod_DatafonoSG As Integer
        Get
            Return cod_Datafono
        End Get
        Set(value As Integer)
            cod_Datafono = value
        End Set
    End Property


End Class
