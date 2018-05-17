Public Class Producto
    Private cod_producto, descuento, afecta_inventario, cod_barra, cant_disponible, id_tipo_producto, compuesto, subcategoria As Integer?
    Private nombre As String
    Private precio_venta, promocion As Decimal

    Public Sub New()

    End Sub

    Public Property AfectaInventario As Integer
        Get
            Return afecta_inventario
        End Get
        Set(value As Integer)
            afecta_inventario = value
        End Set
    End Property

    Public Property CantDisponible As Integer
        Get
            Return cant_disponible
        End Get
        Set(value As Integer)
            cant_disponible = value
        End Set
    End Property

    Public Property CodBarra As Integer
        Get
            Return cod_barra
        End Get
        Set(value As Integer)
            cod_barra = value
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

    Public Property Compuesto_ As Integer
        Get
            Return compuesto
        End Get
        Set(value As Integer)
            compuesto = value
        End Set
    End Property

    Public Property Descuento_ As Integer
        Get
            Return descuento
        End Get
        Set(value As Integer)
            descuento = value
        End Set
    End Property

    Public Property IdTipoProducto As Integer
        Get
            Return id_tipo_producto
        End Get
        Set(value As Integer)
            id_tipo_producto = value
        End Set
    End Property

    Public Property Nombre_ As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property PrecioVenta As Decimal
        Get
            Return precio_venta
        End Get
        Set(value As Decimal)
            precio_venta = value
        End Set
    End Property

    Public Property Promocion_ As Decimal
        Get
            Return promocion
        End Get
        Set(value As Decimal)
            promocion = value
        End Set
    End Property

    Public Property Subcategoria_ As Integer?
        Get
            Return subcategoria
        End Get
        Set(value As Integer?)
            subcategoria = value
        End Set
    End Property
End Class
