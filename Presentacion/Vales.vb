Public Class Vales

    Dim valesDatos As New ValesDatos
    Dim empleadosDatos As New EmpleadoDatos
    Dim valeActivo As Vale

    Private Sub ValesYBonos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarVales()
        cargarEmpleados()
    End Sub

    Public Sub cargarVales()

        dtgVales.DataSource = valesDatos.obtenerVales()
        dtgVales.Columns(0).Width = 45
        dtgVales.Columns(1).Width = 140
        dtgVales.Columns(2).Width = 175
        dtgVales.Columns(3).Width = 75
        dtgVales.Columns(4).Width = 240
    End Sub

    Public Sub cargarEmpleados()
        Dim meseros As New List(Of Empleado)

        meseros = empleadosDatos.obtenerEmpelados()
        Dim dtMeseros As New DataTable
        dtMeseros.Columns.Add("Codigo", System.Type.GetType("System.Int32"))
        dtMeseros.Columns.Add("Nombre", System.Type.GetType("System.String"))

        Dim dr As DataRow = dtMeseros.NewRow
        For i = 0 To meseros.Count - 1
            dr = dtMeseros.NewRow
            dr("Codigo") = meseros(i).Cod_empleadoSG
            dr("Nombre") = meseros(i).NombreSG & " " & meseros(i).Apellido1SG & " " & meseros(i).Apellido2SG
            dtMeseros.Rows.Add(dr)
            cbxEmpleados.ValueMember = "Codigo"
            cbxEmpleados.DisplayMember = "Nombre"
            cbxEmpleados.DataSource = dtMeseros
        Next i
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Dim vale As New Vale
        If IsNumeric(txtMonto.Text.Trim) Then
            vale.Monto_ = txtMonto.Text.Trim
            vale.CodEmpleado_ = cbxEmpleados.SelectedValue
            vale.Cajero_ = InicioSesion.session.EmpleadoSG.Cod_usuarioSG
            valesDatos.ingresarVale(vale)
            facturavale()
        Else
            MsgBox("Digite un monto correcto")
        End If
        cargarVales()
    End Sub

    Public Sub facturavale()
        Try
            Dim factura_vale As New Factura_Vale
            Dim reporte As New Reportes
            reporte.VistaReportes.ReportSource = factura_vale
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
            Dim url As String = "C:\XML\factura_vale.xml"
            My.Computer.FileSystem.DeleteFile(url)
        Catch ex As System.IO.FileNotFoundException

        End Try
    End Sub

    Private Sub dtgVales_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtgVales.CellEnter
        Try
            If (e.RowIndex > -1) Then
                Dim cod = dtgVales.Item(0, e.RowIndex).Value
                valeActivo = valesDatos.obtenerValePorCod(cod)
                btnAbonos.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAbonos_Click(sender As Object, e As EventArgs) Handles btnAbonos.Click
        If valeActivo Is Nothing Then
            MsgBox("Seleccione un vale")
        Else
            Dim abonos As New Abonos(valeActivo, Me)
            abonos.ShowDialog()
        End If
    End Sub
End Class