Imports SunChangSystem

Public Class Session
    Private empleado As Empleado
    Private hora_inicio, hora_primer_ingreso As String

    Public Property EmpleadoSG As Empleado
        Get
            Return empleado
        End Get
        Set(value As Empleado)
            empleado = value
        End Set
    End Property

    Public Property Hora_inicioSG As String
        Get
            Return hora_inicio
        End Get
        Set(value As String)
            hora_inicio = value
        End Set
    End Property

    Public Property Hora_primer_ingresoSG As String
        Get
            Return hora_primer_ingreso
        End Get
        Set(value As String)
            hora_primer_ingreso = value
        End Set
    End Property

    Public Sub Session()

    End Sub

End Class
