Public Class Abonos

    Dim vale As Vale
    Dim valeDatos As New ValesDatos
    Dim empleadoDatos As New EmpleadoDatos
    Dim valeForm As Vales

    Public Sub New(ByVal vale As Vale, ByVal valeForm As Vales)
        Me.vale = vale
        Me.valeForm = valeForm
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Abonos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEmpleado.Text = empleadoDatos.obtenerEmpleadoPorCod(vale.CodEmpleado_).NombreSG & " " & empleadoDatos.obtenerEmpleadoPorCod(vale.CodEmpleado_).Apellido1SG & " " & empleadoDatos.obtenerEmpleadoPorCod(vale.CodEmpleado_).Apellido2SG
        txtMontoTotal.Text = vale.Monto_
        txtSaldo.Text = valeDatos.obtenerSaldoPorVale(vale)
        cargarSaldo()
        cargarAbonos()
    End Sub

    Public Sub cargarAbonos()
        dtgAbonos.DataSource = valeDatos.obtenerAbonosPorVale(vale.CodVale_)
        dtgAbonos.Columns(0).Width = 140
        dtgAbonos.Columns(1).Width = 175
        dtgAbonos.Columns(2).Width = 100
    End Sub

    Public Sub cargarSaldo()
        txtSaldo.Text = valeDatos.obtenerSaldoPorVale(vale)
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If IsNumeric(txtDepositar.Text.Trim) And txtDepositar.Text.Trim <> "0" Then
            If CType(txtDepositar.Text.Trim, Decimal) <= CType(txtSaldo.Text.Trim, Decimal) Then
                Dim abono As New Abono
                abono.Cajero_ = InicioSesion.session.EmpleadoSG.Cod_usuarioSG
                abono.Monto_ = txtDepositar.Text.Trim
                abono.Vale_ = vale
                valeDatos.ingresarAbono(abono)
                facturaAbono()
                If CType(txtDepositar.Text.Trim, Decimal) = CType(txtSaldo.Text.Trim, Decimal) Then
                    valeDatos.cancelarVale(vale)
                    MsgBox("El vale ha sido cancelado totalmente")
                    Me.valeForm.cargarVales()
                    Me.Close()
                End If
                cargarAbonos()
                cargarSaldo()
                txtDepositar.Text = ""
            Else
                MsgBox("Ingrese un monto menor o igual al saldo")
            End If
        Else
            MsgBox("Ingrese un monto valido")
        End If
    End Sub

    Public Sub facturaAbono()
        Try
            Dim facturaAbono As New Factura_Abono
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = facturaAbono
            reporte.VistaReportes.RefreshReport()
            'reporte.ShowDialog()
            reporte.VistaReportes.PrintReport()

            'Dim mensaje_confirmacion As New MensajeConfirmacion
            'mensaje_confirmacion.lblMensaje.Text = "¿Se imprimió corectamente la factura?"
            'mensaje_confirmacion.ShowDialog()

            '' se eliminan los archivos
            'Dim url As String = "C:\XML\factura.xml"
            'My.Computer.FileSystem.DeleteFile(url)
            'url = "C:\XML\detallefactura.xml"
            'My.Computer.FileSystem.DeleteFile(url)
            'url = "C:\XML\montofactura.xml"
            'My.Computer.FileSystem.DeleteFile(url)

            '' valida si seimprimio o no la factura
            'If Not mensaje_confirmacion.decision Then
            '    facturavale()
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' se elimina el archivo xml generado
        Try
            Dim url As String = "C:\XML\factura_abono.xml"
            My.Computer.FileSystem.DeleteFile(url)
        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub

End Class