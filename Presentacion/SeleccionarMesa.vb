Public Class SeleccionarMesa

    Dim nuevaOrden As NuevaOrden
    Dim mesa As Integer = 0

    Public Sub New(nuevaOrden As NuevaOrden)
        Me.nuevaOrden = nuevaOrden
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub enviaMesa()
        nuevaOrden.modificaMesa(mesa)
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mesa = 1
        enviaMesa()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mesa = 2
        enviaMesa()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        mesa = 3
        enviaMesa()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        mesa = 4
        enviaMesa()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        mesa = 5
        enviaMesa()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        mesa = 6
        enviaMesa()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        mesa = 7
        enviaMesa()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        mesa = 8
        enviaMesa()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        mesa = 9
        enviaMesa()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        mesa = 10
        enviaMesa()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        mesa = 11
        enviaMesa()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        mesa = 12
        enviaMesa()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        mesa = 13
        enviaMesa()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        mesa = 14
        enviaMesa()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        mesa = 15
        enviaMesa()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        mesa = 16
        enviaMesa()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        mesa = 17
        enviaMesa()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        mesa = 18
        enviaMesa()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If IsNumeric(txtMesa.Text.Trim) Then
            mesa = txtMesa.Text.Trim
            enviaMesa()
        Else
            MsgBox("Ingrese un numero")
            txtMesa.Text = ""
        End If
    End Sub

End Class