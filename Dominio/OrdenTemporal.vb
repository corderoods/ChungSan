Public Class OrdenTemporal
    Private num_orden, num_linea, cod_producto, cantidad, llevar, ind_repetidos,
        ind_cantidad, impreso, cant_impreso As Integer
    Private subTotal, descuento As Decimal
    Private nombreProducto, observaciones As String

    Public Sub New()

    End Sub

    Public Property CantImpreso As Integer
        Get
            Return cant_impreso
        End Get
        Set(value As Integer)
            cant_impreso = value
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

    Public Property CodProducto As Integer
        Get
            Return cod_producto
        End Get
        Set(value As Integer)
            cod_producto = value
        End Set
    End Property

    Public Property Descuento_ As Decimal
        Get
            Return descuento
        End Get
        Set(value As Decimal)
            descuento = value
        End Set
    End Property

    Public Property Impreso_ As Integer
        Get
            Return impreso
        End Get
        Set(value As Integer)
            impreso = value
        End Set
    End Property

    Public Property IndCantidad As Integer
        Get
            Return ind_cantidad
        End Get
        Set(value As Integer)
            ind_cantidad = value
        End Set
    End Property

    Public Property IndRepetidos As Integer
        Get
            Return ind_repetidos
        End Get
        Set(value As Integer)
            ind_repetidos = value
        End Set
    End Property

    Public Property Llevar_ As Integer
        Get
            Return llevar
        End Get
        Set(value As Integer)
            llevar = value
        End Set
    End Property

    Public Property NumLinea As Integer
        Get
            Return num_linea
        End Get
        Set(value As Integer)
            num_linea = value
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

    Public Property SubTotal_ As Decimal
        Get
            Return subTotal
        End Get
        Set(value As Decimal)
            subTotal = value
        End Set
    End Property

    Public Property NombreProducto_ As String
        Get
            Return nombreProducto
        End Get
        Set(value As String)
            nombreProducto = value
        End Set
    End Property

    Public Property Observaciones_ As String
        Get
            Return observaciones
        End Get
        Set(value As String)
            observaciones = value
        End Set
    End Property
End Class
