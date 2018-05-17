Public Class Monedas
    Private cod_moneda As Integer
    Private desc_moneda As String
    Private valor As Double
    Private tipo_moneda As Integer
    Private cantidad As Integer
    Private subtotal As Double
    Private tipo_cambio As Double

    Public Sub New()

    End Sub

    Public Sub New(ByVal cod_moneda_ As Integer, ByVal desc_moneda_ As String, ByVal valor_ As Double, ByVal tipo_moneda_ As Integer, ByVal cantidad_ As Integer, ByVal subtotal_ As Double, ByVal tipo_cambio_ As Double)
        cod_moneda = cod_moneda_
        desc_moneda = desc_moneda_
        valor = valor_
        tipo_moneda = tipo_moneda_
        cantidad = cantidad_
        subtotal = subtotal_
        tipo_cambio = tipo_cambio_
    End Sub

    Public Property Codigo_monedaSG As Integer
        Get
            Return cod_moneda
        End Get
        Set(value As Integer)
            cod_moneda = value
        End Set
    End Property

    Public Property Descripcion_monedaSG As String
        Get
            Return desc_moneda
        End Get
        Set(value As String)
            desc_moneda = value
        End Set
    End Property

    Public Property ValorSG As Double
        Get
            Return valor
        End Get
        Set(value As Double)
            valor = value
        End Set
    End Property

    Public Property Tipo_monedaSG As Integer
        Get
            Return tipo_moneda
        End Get
        Set(value As Integer)
            tipo_moneda = value
        End Set
    End Property

    Public Property CantidadSG As Integer
        Get
            Return cantidad
        End Get
        Set(value As Integer)
            cantidad = value
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

    Public Property Tipo_cambioSG As Double
        Get
            Return tipo_cambio
        End Get
        Set(value As Double)
            tipo_cambio = value
        End Set
    End Property
End Class
