Imports SunChangSystem

Public Class DenominacionMonedas
    Private listaDenominaciones As List(Of Monedas)
    Private codigo_usuario_asigna As String
    Private codigo_usuario_recibe As String

    Public Sub New(ByVal listaDenominaciones_ As List(Of Monedas), ByVal codigo_usuario_asigna_ As String, ByVal codigo_usuario_recibe_ As String)
        listaDenominaciones = listaDenominaciones_
        codigo_usuario_asigna = codigo_usuario_asigna_
        codigo_usuario_recibe = codigo_usuario_recibe_
    End Sub

    Public Sub New()

    End Sub

    Public Property Codigo_usuario_asignaSG As String
        Get
            Return codigo_usuario_asigna
        End Get
        Set(value As String)
            codigo_usuario_asigna = value
        End Set
    End Property

    Public Property Codigo_usuario_recibeSG As String
        Get
            Return codigo_usuario_recibe
        End Get
        Set(value As String)
            codigo_usuario_recibe = value
        End Set
    End Property

    Public Property ListaDenominacionesSG As List(Of Monedas)
        Get
            Return listaDenominaciones
        End Get
        Set(value As List(Of Monedas))
            listaDenominaciones = value
        End Set
    End Property
End Class
