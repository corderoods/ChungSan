Public Class TipoProducto
    Private idTipoProducto As Decimal
    Private descripcion As String
    Private bebida As Char

    Public Property IdTipoProductoSG As Decimal
        Get
            Return idTipoProducto
        End Get
        Set(value As Decimal)
            idTipoProducto = value
        End Set
    End Property

    Public Property DescripcionSG As String
        Get
            Return descripcion
        End Get
        Set(value As String)
            descripcion = value
        End Set
    End Property

    Public Property BebidaSG As Char
        Get
            Return bebida
        End Get
        Set(value As Char)
            bebida = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(id_categoria_ As Int16, descripcion_ As String, bebida_ As Char)
        idTipoProducto = id_categoria_
        descripcion = descripcion_
        bebida = bebida_
    End Sub

End Class
