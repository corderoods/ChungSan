Public Class Parametros
    Private num_factura, porc_impvtas, porc_impserv, express As Integer

    Public Sub New()

    End Sub

    Public Property Express_ As Integer
        Get
            Return express
        End Get
        Set(value As Integer)
            express = value
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

    Public Property PorcImpServ As Integer
        Get
            Return porc_impserv
        End Get
        Set(value As Integer)
            porc_impserv = value
        End Set
    End Property

    Public Property PorcImpVtas As Integer
        Get
            Return porc_impvtas
        End Get
        Set(value As Integer)
            porc_impvtas = value
        End Set
    End Property
End Class
