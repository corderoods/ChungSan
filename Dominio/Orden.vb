Public Class Orden
    Private num_orden, num_mesa, cod_empleado, cod_cliente, descuento, ind_pago, orden_dia,
        express, cod_salonero As Integer
    Private total, efectivo, tarjeta, cheque, impserv, impvtas, paga_con As Decimal
    Private telefono, ubicacion, direccion, nombreCliente As String
    Private fecha As DateTime

    Public Sub New()

    End Sub

    Public Property NumOrden As Integer
        Get
            Return num_orden
        End Get
        Set(value As Integer)
            num_orden = value
        End Set
    End Property

    Public Property NumMesa As Integer
        Get
            Return num_mesa
        End Get
        Set(value As Integer)
            num_mesa = value
        End Set
    End Property

    Public Property CodEmpleado As Integer
        Get
            Return cod_empleado
        End Get
        Set(value As Integer)
            cod_empleado = value
        End Set
    End Property

    Public Property CodCliente As Integer
        Get
            Return cod_cliente
        End Get
        Set(value As Integer)
            cod_cliente = value
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

    Public Property IndPago As Integer
        Get
            Return ind_pago
        End Get
        Set(value As Integer)
            ind_pago = value
        End Set
    End Property

    Public Property OrdenDia As Integer
        Get
            Return orden_dia
        End Get
        Set(value As Integer)
            orden_dia = value
        End Set
    End Property

    Public Property Express_ As Integer
        Get
            Return express
        End Get
        Set(value As Integer)
            express = value
        End Set
    End Property

    Public Property CodSalonero As Integer
        Get
            Return cod_salonero
        End Get
        Set(value As Integer)
            cod_salonero = value
        End Set
    End Property

    Public Property Total_ As Decimal
        Get
            Return total
        End Get
        Set(value As Decimal)
            total = value
        End Set
    End Property

    Public Property Efectivo_ As Decimal
        Get
            Return efectivo
        End Get
        Set(value As Decimal)
            efectivo = value
        End Set
    End Property

    Public Property Tarjeta_ As Decimal
        Get
            Return tarjeta
        End Get
        Set(value As Decimal)
            tarjeta = value
        End Set
    End Property

    Public Property Cheque_ As Decimal
        Get
            Return cheque
        End Get
        Set(value As Decimal)
            cheque = value
        End Set
    End Property

    Public Property ImpServ_ As Decimal
        Get
            Return impserv
        End Get
        Set(value As Decimal)
            impserv = value
        End Set
    End Property

    Public Property ImpVtas_ As Decimal
        Get
            Return impvtas
        End Get
        Set(value As Decimal)
            impvtas = value
        End Set
    End Property

    Public Property PagaCon As Decimal
        Get
            Return paga_con
        End Get
        Set(value As Decimal)
            paga_con = value
        End Set
    End Property

    Public Property Telefono_ As String
        Get
            Return telefono
        End Get
        Set(value As String)
            telefono = value
        End Set
    End Property

    Public Property Ubicacion_ As String
        Get
            Return ubicacion
        End Get
        Set(value As String)
            ubicacion = value
        End Set
    End Property

    Public Property Direccion_ As String
        Get
            Return direccion
        End Get
        Set(value As String)
            direccion = value
        End Set
    End Property

    Public Property Fecha_ As DateTime
        Get
            Return fecha
        End Get
        Set(value As DateTime)
            fecha = value
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
End Class
