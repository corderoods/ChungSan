Imports SunChangSystem

Public Class ReportePagoFactura
    Private nombre_cajero, nombre_proveedor As String
    Private factura As FacturaPago

    Public Property Nombre_cajeroSG As String
        Get
            Return nombre_cajero
        End Get
        Set(value As String)
            nombre_cajero = value
        End Set
    End Property

    Public Property Nombre_proveedorSG As String
        Get
            Return nombre_proveedor
        End Get
        Set(value As String)
            nombre_proveedor = value
        End Set
    End Property

    Public Property FacturaSG As FacturaPago
        Get
            Return factura
        End Get
        Set(value As FacturaPago)
            factura = value
        End Set
    End Property

    Public Sub New()

    End Sub


End Class
