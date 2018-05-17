Public Class FacturaPago
    Private concepto, tipo, elemento, observaciones, cod_usuario, nombre_proveedor As String
    Private fecha_factura, fecha_pago As String
    Private monto_factura, cod_proveedor, numero_factura As Double

    Public Sub New()

    End Sub

    Public Property Nombre_ProveedorSG As String
        Get
            Return nombre_proveedor
        End Get
        Set(value As String)
            nombre_proveedor = value
        End Set
    End Property

    Public Property Cod_UsuarioSG As String
        Get
            Return cod_usuario
        End Get
        Set(value As String)
            cod_usuario = value
        End Set
    End Property

    Public Property ConceptoSG As String
        Get
            Return concepto
        End Get
        Set(value As String)
            concepto = value
        End Set
    End Property

    Public Property TipoSG As String
        Get
            Return tipo
        End Get
        Set(value As String)
            tipo = value
        End Set
    End Property

    Public Property ElementoSG As String
        Get
            Return elemento
        End Get
        Set(value As String)
            elemento = value
        End Set
    End Property

    Public Property ObservacionesSG As String
        Get
            Return observaciones
        End Get
        Set(value As String)
            observaciones = value
        End Set
    End Property

    Public Property Fecha_facturaSG As String
        Get
            Return fecha_factura
        End Get
        Set(value As String)
            fecha_factura = value
        End Set
    End Property

    Public Property Fecha_pagoSG As String
        Get
            Return fecha_pago
        End Get
        Set(value As String)
            fecha_pago = value
        End Set
    End Property

    Public Property Monto_facturaSG As Double
        Get
            Return monto_factura
        End Get
        Set(value As Double)
            monto_factura = value
        End Set
    End Property

    Public Property Cod_proveedorSG As Double
        Get
            Return cod_proveedor
        End Get
        Set(value As Double)
            cod_proveedor = value
        End Set
    End Property

    Public Property Numero_facturaSG As Double
        Get
            Return numero_factura
        End Get
        Set(value As Double)
            numero_factura = value
        End Set
    End Property
End Class
