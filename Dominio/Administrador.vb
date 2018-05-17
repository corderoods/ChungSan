Public Class Administrador
    Private cod_empleado As String
    Private nombre As String

    Public Sub New()

    End Sub

    Public Property Codigo_empleado As String
        Get
            Return cod_empleado
        End Get
        Set(value As String)
            cod_empleado = value
        End Set
    End Property

    Public Property NombreEmpleado As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property
End Class
