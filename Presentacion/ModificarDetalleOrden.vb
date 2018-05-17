Public Class ModificarDetalleOrden

    Dim ordenDatos As OrdenDatos
    Dim codProducto As Integer
    Dim ordenesForm As Ordenes
    Dim ordenTemporal As OrdenTemporal
    Dim orden As Integer
    Dim indice As Integer
    Dim cantidad As Integer
    Dim observaciones As String

    Public Sub New(ByVal idProducto As Integer, ByVal orden As Integer, ByVal indice As Integer, ByVal cantidad As Integer, ByVal ordenes As Ordenes)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ordenDatos = New OrdenDatos
        Me.codProducto = idProducto
        Me.ordenesForm = ordenes
        Me.orden = orden
        Me.indice = indice
        Me.cantidad = cantidad

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub ModificarDetalleOrden_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ordenTemporal = ordenDatos.obtenerDetalleOrdenTemporal(orden, codProducto)
        lblCantidad.Text = cantidad
        lblNombreProducto.Text = ordenTemporal.NombreProducto_
        txtObservaciones.Text = ordenTemporal.Observaciones_
        observaciones = ordenTemporal.Observaciones_
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMenos.Click
        If lblCantidad.Text - 1 > 0 Then
            lblCantidad.Text = lblCantidad.Text - 1
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnMas.Click
        lblCantidad.Text = lblCantidad.Text + 1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ordenDatos.eliminarDetalleOrden(ordenTemporal.NumOrden, ordenTemporal.NumLinea)
        ordenesForm.clickBoton(indice)
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If lblCantidad.Text <> cantidad Then
            ordenDatos.modificarCantidadDetalleOrden(ordenTemporal.NumOrden, ordenTemporal.NumLinea, lblCantidad.Text)
        End If

        If txtObservaciones.Text.Trim <> observaciones Then
            Dim result = ordenDatos.modificarObservacionesDetalleOrden(ordenTemporal.NumOrden, ordenTemporal.NumLinea, txtObservaciones.Text)
            If result = False Then
                Mensaje.tipoMensaje("error")
                Mensaje.lblMensaje.Text = "EL PEDIDO YA ESTA LISTO, NO SE PUEDEN AGREGAR OBSERVACIONES"
                Mensaje.ShowDialog()
            End If
        End If
        ordenesForm.clickBoton(indice)
        Me.Close()
    End Sub

End Class