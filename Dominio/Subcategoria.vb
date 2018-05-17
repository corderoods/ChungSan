Public Class Subcategoria

    Private idSubcategoria As Decimal
    Private nombre As String
    Private categoria As Integer

    Public Sub New()

    End Sub

    Public Property IdSubcategoria_ As Decimal
        Get
            Return idSubcategoria
        End Get
        Set(value As Decimal)
            idSubcategoria = value
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

    Public Property Categoria_ As Integer
        Get
            Return categoria
        End Get
        Set(value As Integer)
            categoria = value
        End Set
    End Property
End Class
