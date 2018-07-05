Imports Newtonsoft.Json

Public Class Organizacion
    Private clave, nombre, nombreComer, otrasSenas, correoElectronico As String
    Private tipoIdent, numeroIdent, provincia, canton, distrito, barrio, codTelefono, telefono, codFax, fax As Integer

    Public Sub New()

    End Sub

    'Public Property claveSG As String
    '    Get
    '        Return Me.clave
    '    End Get
    '    Set(value As String)
    '        Me.clave = value
    '    End Set
    'End Property

    <JsonProperty("clave")>
    Public Property claveSG As String



    'Public Property nombreSG As String
    '    Get
    '        Return Me.nombre
    '    End Get
    '    Set(value As String)
    '        Me.nombre = value
    '    End Set
    'End Property

    <JsonProperty("nombre")>
    Public Property nombreSG As String

    'Public Property nombreComerSG As String
    '    Get
    '        Return Me.nombreComer
    '    End Get
    '    Set(value As String)
    '        Me.nombreComer = value
    '    End Set
    'End Property

    <JsonProperty("nombreComer")>
    Public Property nombreComerSG As String

    'Public Property otrasSenasSG As String
    '    Get
    '        Return Me.otrasSenas
    '    End Get
    '    Set(value As String)
    '        Me.otrasSenas = value
    '    End Set
    'End Property

    <JsonProperty("otrasSenas")>
    Public Property OtrasSenasSG As String

    'Public Property correoElectronicoSG As String
    '    Get
    '        Return Me.correoElectronico
    '    End Get
    '    Set(value As String)
    '        Me.correoElectronico = value
    '    End Set
    'End Property

    <JsonProperty("correoElectronico")>
    Public Property correoElectronicoSG As String

    'Public Property tipoIdentSG As Integer
    '    Get
    '        Return Me.tipoIdent
    '    End Get
    '    Set(value As Integer)
    '        Me.tipoIdent = value
    '    End Set
    'End Property

    <JsonProperty("tipoIdent")>
    Public Property tipoIdentSG As Integer

    'Public Property numeroIdentSG As Integer
    '    Get
    '        Return Me.numeroIdent
    '    End Get
    '    Set(value As Integer)
    '        Me.numeroIdent = value
    '    End Set
    'End Property

    <JsonProperty("numeroIdent")>
    Public Property numeroIdentSG As Integer

    'Public Property provinciaSG As Integer
    '    Get
    '        Return Me.provincia
    '    End Get
    '    Set(value As Integer)
    '        Me.provincia = value
    '    End Set
    'End Property

    <JsonProperty("provincia")>
    Public Property provinciaSG As Integer



    <JsonProperty("canton")>
    Public Property cantonSG As Integer
    'Public Property distritoSG As Integer
    '    Get
    '        Return Me.distrito
    '    End Get
    '    Set(value As Integer)
    '        Me.distrito = value
    '    End Set
    'End Property

    <JsonProperty("distrito")>
    Public Property distritoSG As Integer

    'Public Property barrioSG As Integer
    '    Get
    '        Return Me.barrio
    '    End Get
    '    Set(value As Integer)
    '        Me.barrio = value
    '    End Set
    'End Property

    <JsonProperty("barrio")>
    Public Property barrioSG As Integer

    'Public Property codTelefonoSG As Integer
    '    Get
    '        Return Me.codTelefono
    '    End Get
    '    Set(value As Integer)
    '        Me.codTelefono = value
    '    End Set
    'End Property

    <JsonProperty("codTelefono")>
    Public Property codTelefonoSG As Integer

    'Public Property telefonoSG As Integer
    '    Get
    '        Return Me.telefono
    '    End Get
    '    Set(value As Integer)
    '        Me.telefono = value
    '    End Set
    'End Property

    <JsonProperty("telefono")>
    Public Property telefonoSG As Integer

    'Public Property codFaxSG As Integer
    '    Get
    '        Return Me.codFax
    '    End Get
    '    Set(value As Integer)
    '        Me.codFax = value
    '    End Set
    'End Property

    <JsonProperty("codFax")>
    Public Property codFaxSG As Integer

    'Public Property faxSG As Integer
    '    Get
    '        Return Me.fax
    '    End Get
    '    Set(value As Integer)
    '        Me.fax = value
    '    End Set
    'End Property

    <JsonProperty("fax")>
    Public Property faxSG As Integer


End Class
