Public Class Empleado
    Private cod_empleado, cod_puesto, estado_civil, sexo, telefono, cod_barra, celular, tel_fijo As Decimal
    Private nombre, apellido1, apellido2, email, direccion, cod_usuario, contrasenna As String
    Private fecha_nacimiento As Date 'Time
    Private fecha_ingreso As DateTime

    Public Property Cod_empleadoSG As Decimal
        Get
            Return cod_empleado
        End Get
        Set(value As Decimal)
            cod_empleado = value
        End Set
    End Property

    Public Property Cod_puestoSG As Decimal
        Get
            Return cod_puesto
        End Get
        Set(value As Decimal)
            cod_puesto = value
        End Set
    End Property

    Public Property Estado_civilSG As Decimal
        Get
            Return estado_civil
        End Get
        Set(value As Decimal)
            estado_civil = value
        End Set
    End Property

    Public Property SexoSG As Decimal
        Get
            Return sexo
        End Get
        Set(value As Decimal)
            sexo = value
        End Set
    End Property

    Public Property TelefonoSG As Decimal
        Get
            Return telefono
        End Get
        Set(value As Decimal)
            telefono = value
        End Set
    End Property

    Public Property Cod_barraSG As Decimal
        Get
            Return cod_barra
        End Get
        Set(value As Decimal)
            cod_barra = value
        End Set
    End Property

    Public Property CelularSG As Decimal
        Get
            Return celular
        End Get
        Set(value As Decimal)
            celular = value
        End Set
    End Property

    Public Property Tel_fijoSG As Decimal
        Get
            Return tel_fijo
        End Get
        Set(value As Decimal)
            tel_fijo = value
        End Set
    End Property

    Public Property NombreSG As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property Apellido1SG As String
        Get
            Return apellido1
        End Get
        Set(value As String)
            apellido1 = value
        End Set
    End Property

    Public Property Apellido2SG As String
        Get
            Return apellido2
        End Get
        Set(value As String)
            apellido2 = value
        End Set
    End Property

    Public Property EmailSG As String
        Get
            Return email
        End Get
        Set(value As String)
            email = value
        End Set
    End Property

    Public Property DireccionSG As String
        Get
            Return direccion
        End Get
        Set(value As String)
            direccion = value
        End Set
    End Property

    Public Property Cod_usuarioSG As String
        Get
            Return cod_usuario
        End Get
        Set(value As String)
            cod_usuario = value
        End Set
    End Property

    Public Property ContrasennaSG As String
        Get
            Return contrasenna
        End Get
        Set(value As String)
            contrasenna = value
        End Set
    End Property

    Public Property Fecha_nacimientoSG As Date
        Get
            Return fecha_nacimiento
        End Get
        Set(value As Date)
            fecha_nacimiento = value
        End Set
    End Property

    Public Property Fecha_ingresoSG As Date
        Get
            Return fecha_ingreso
        End Get
        Set(value As Date)
            fecha_ingreso = value
        End Set
    End Property

    Public Sub New()

    End Sub

End Class
