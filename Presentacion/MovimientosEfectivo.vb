Imports System.Data.SqlClient

Public Class MovimientosEfectivo

    'variables globales para saber que tipo de movimineto se va a arealizar'
    Public fondoInicial As Boolean = False
    Public fondoFinal As Boolean = False
    Public introducciones As Boolean = False
    Public salidasEfectivo As Boolean = False
    Public arqueo As Boolean = False
    Public arqueo_diseno As New Arqueo
    Public denominacionesColones As DataTable
    Public denominacionesDolares As DataTable
    Public usuariosDatos As New UsuariosDatos
    ' instancia a la clase que conecta con la base de datos
    Dim denominacionMonedasDatos As MovimientoCajaDatos

    Dim cierre_caja_diseno As CierreCaja
    ' instancia a la clase que conecta con la base de datos
    Dim denominacionesAEntregar As New List(Of Monedas)
    ' variable que tendra el valor del cambio de la moneda (cambio de dolar)
    Dim tipo_cambio As Double
    ' instancia al formulario de mensaje para mostrar errores   
    Dim mensaje As New Mensaje
    ' variable que tendra el valor de las denominaciones del cierre de caja
    Dim cantidades_cierre As DataTable
    ' constructor
    Public Sub New()
        Try
            If CierreCaja.modificar_cierre Then
                CierreCaja.Close()
            End If
        Catch ex As InvalidOperationException
        End Try

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' coloca los colones como por defecto
        rbColones.Checked = True
        lblMoneda.Text = "Colones"

        ' carga la lista de administradores
        Dim administrador As New UsuariosDatos
        Dim listaAdministradores As New List(Of Administrador)
        listaAdministradores = administrador.obtenerAdministradores

        ' datatable para ir agregando los proveedores
        Dim data_table_administradores As New DataTable
        data_table_administradores.Columns.Add("Codigo", System.Type.GetType("System.String"))
        data_table_administradores.Columns.Add("Nombre", System.Type.GetType("System.String"))

        ' Se llenan los datos del combo
        Dim i As Int32
        For i = 0 To (listaAdministradores.Count - 1)
            cbxAdministrador.Items.Add(listaAdministradores(i).NombreEmpleado)
            Dim data_row_proveedores As DataRow = data_table_administradores.NewRow
            data_row_proveedores = data_table_administradores.NewRow
            data_row_proveedores("Codigo") = listaAdministradores(i).Codigo_empleado
            data_row_proveedores("Nombre") = listaAdministradores(i).NombreEmpleado
            data_table_administradores.Rows.Add(data_row_proveedores)
            cbxAdministrador.ValueMember = "Codigo"
            cbxAdministrador.DisplayMember = "Nombre"
        Next

        ' se agregan los items al combobox
        cbxAdministrador.DataSource = data_table_administradores

    End Sub

    ' metodo que obtendra las denominaciones que hay en la base de datos y las mostrara en la pantalla
    Public Sub cargarDenominaciones()
        If fondoInicial Then
            lblTipoMovimiento.Text = "Apertura de caja"
            PanelIntroducciones.Hide()
            PanelSalidas.Hide()
            PanelFondos.Show()
        ElseIf fondoFinal Then
            lblTipoMovimiento.Text = "Cierre de caja"
            PanelIntroducciones.Hide()
            PanelSalidas.Hide()
            PanelFondos.Show()
        ElseIf introducciones Then
            lblTipoMovimiento.Text = "Introducciones"
            PanelFondos.Hide()
            PanelSalidas.Hide()
            PanelIntroducciones.Show()
        ElseIf salidasEfectivo Then
            lblTipoMovimiento.Text = "Salidas de Efectivo"
            PanelFondos.Hide()
            PanelIntroducciones.Hide()
            PanelSalidas.Show()
        ElseIf arqueo Then
            lblTipoMovimiento.Text = "Arqueo de Caja"
            PanelIntroducciones.Hide()
            PanelSalidas.Hide()
            PanelFondos.Show()
        End If

        ' instancia a la clase que conecta con la base de datos
        denominacionMonedasDatos = New MovimientoCajaDatos

        ' variable que obtendra la lista de denominaciones de la base de datos
        Dim listaDenominaciones As New List(Of DataTable)
        ' se asigna a la variable las denominaciones despues de que se llama al metodo que las obtiene de la base de datos
        listaDenominaciones = denominacionMonedasDatos.obtenerDenominacionesMonedas()

        ' variable que tendra las denominaciones a obtener
        denominacionesColones = listaDenominaciones(0)
        denominacionesDolares = listaDenominaciones(1)

        If fondoFinal Or arqueo Then
            Dim cantidades_cierre_datos = New MovimientoCajaDatos
            cantidades_cierre = cantidades_cierre_datos.obtenerDenominacionesCierreCaja(InicioSesion.session.EmpleadoSG.Cod_usuarioSG, InicioSesion.session.Hora_primer_ingresoSG)
        End If


        ' se valida que hayan denominaciones
        If listaDenominaciones.Count > 0 Then
            mostrarValoresDenominaciones(pnlDenominacionesColones, denominacionesColones)
            'mostrarValoresDenominaciones(pnlDenominacionesDolares, denominacionesDolares)
        Else
            mensaje.tipoMensaje("error")
            mensaje.lblMensaje.Text = "No se encontraron Datos"
            mensaje.ShowDialog()
        End If

        Try
            cajasTextoCantidad(0).Text = (CInt(cajasTextoCantidad(0).Text) * 1)
        Catch ex As InvalidCastException
            cajasTextoCantidad(0).Text = 0
        End Try


    End Sub

    ' metodo que carga las cajas de texto de cantidad a digitar
    Private Sub mostrarCajasTextoCantidad(panel As Panel, tipoDenominacion As DataTable)
        ' posiciones donde se van a mostrar las cajas de texto de la cantidad a digitar
        Dim posX = 170
        Dim posY = 15
        If IsNothing(tipoDenominacion) Then
            ' el valor es null
        Else
            ' se obtiene el tamaño de la cantidad de denominaciones segun su tipo y que hay en la base de datos
            Dim tamannoDenominaciones As Integer = tipoDenominacion.Rows.Count

            ' se redimenciona el tamaño del arreglo que contendrá las cajas de texto
            ReDim cajasTextoCantidad(tamannoDenominaciones)

            ' se recorre la cantidad de denominaciones para crear las cajas de texto
            For i = 0 To tamannoDenominaciones - 1
                'se aumenta la posicion para la siguiente caja de texto
                posY += 24

                ' se crean las cajas de texto y sus atributos
                txtCantidad = New TextBox
                txtCantidad.Name = ("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString)
                If fondoFinal Or arqueo Then
                    txtCantidad.Text = cantidades_cierre.Rows(i).Item(0)
                End If

                txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
                txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                txtCantidad.Location = New Point(posX, posY)
                txtCantidad.Size() = New Size(70, 20)
                cajasTextoCantidad(i) = txtCantidad
                ' se agregan al panel
                panel.Controls.Add(cajasTextoCantidad(i))
                'se le asigna el evento
                AddHandler txtCantidad.TextChanged, AddressOf txtValorCantidad__TextChanged
                AddHandler txtCantidad.KeyPress, AddressOf txtValorDenominacion_KeyPress
                AddHandler txtCantidad.MouseClick, AddressOf txtCantidad_MouseClick
            Next i

            mostrarCajasTextoSubTotal(panel, tipoDenominacion)
        End If
    End Sub

    ' metodo que carga las cajas de texto del subtotal
    Private Sub mostrarCajasTextoSubTotal(panel As Panel, tipoDenominacion As DataTable)
        ' posiciones donde se van a mostrar las cajas de texto de la cantidad a digitar
        Dim posX = 280
        Dim posY = 15
        If IsNothing(tipoDenominacion) Then
            ' el valor es null
        Else
            ' se obtiene el tamaño de la cantidad de denominaciones segun su tipo y que hay en la base de datos
            Dim tamannoDenominaciones As Integer = tipoDenominacion.Rows.Count

            ' se redimenciona el tamaño del arreglo que contendrá las cajas de texto
            ReDim cajasTextoCantidad(tamannoDenominaciones)

            ' se recorre la cantidad de denominaciones para crear las cajas de texto
            For i = 0 To tamannoDenominaciones - 1
                'se aumenta la posicion para la siguiente caja de texto
                posY += 24

                ' se crean las cajas de texto y sus atributos
                txtValorDenominacion = New TextBox
                txtValorDenominacion.Name = ("txtValorDenominacion" + tipoDenominacion.Rows(i).Item(0).ToString)
                If fondoFinal Or arqueo Then
                    txtValorDenominacion.Text = cantidades_cierre.Rows(i).Item(1)

                End If
                'txtValorDenominacion.ReadOnly = True
                txtValorDenominacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                txtValorDenominacion.Location = New Point(posX, posY)
                txtValorDenominacion.Size() = New Size(90, 20)
                cajasTextoCantidad(i) = txtValorDenominacion
                ' se agregan al panel
                panel.Controls.Add(cajasTextoCantidad(i))
                'se le asigna el evento
                AddHandler txtValorDenominacion.TextChanged, AddressOf txtValorDenominacion__TextChanged
                AddHandler txtValorDenominacion.KeyPress, AddressOf txtValorDenominacion_KeyPress
            Next i
        End If
    End Sub

    ' metodo que muestra los valores de las denominaciones
    Private Sub mostrarValoresDenominaciones(panel As Panel, tipoDenominacion As DataTable)
        ' posiciones donde se van a mostrar las cajas de texto de la cantidad a digitar
        Dim posX = 50
        Dim posY = 15
        If IsNothing(tipoDenominacion) Then
            ' el valor es null
        Else
            ' se obtiene el tamaño de la cantidad de denominaciones segun su tipo y que hay en la base de datos
            Dim tamannoDenominaciones As Integer = tipoDenominacion.Rows.Count

            ' se redimenciona el tamaño del arreglo que contendrá las cajas de texto
            ReDim etiquetasValores(tamannoDenominaciones)

            ' se recorre la cantidad de denominaciones para crear las cajas de texto
            For i = 0 To tamannoDenominaciones - 1
                'se aumenta la posicion para la siguiente caja de texto
                posY += 24

                ' se crean las cajas de texto y sus atributos
                lblDenominacion = New Label
                lblDenominacion.Name = ("lblDenominacion" + tipoDenominacion.Rows(i).Item(0).ToString)
                lblDenominacion.Text = tipoDenominacion.Rows(i).Item(1).ToString
                lblDenominacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                lblDenominacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
                lblDenominacion.Location = New Point(posX, posY)
                ' lblDenominacion.Size() = New Size(90, 20)
                etiquetasValores(i) = lblDenominacion
                ' se agregan al panel
                panel.Controls.Add(etiquetasValores(i))
            Next i

            ' llama al metodo para mostrar las demas cajas de texto
            mostrarCajasTextoCantidad(panel, tipoDenominacion)
        End If
    End Sub

    ' funcion del boton aceptar. Comunica con datos para almacenar los montos
    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        If txtAdminPassword.TextLength > 0 Then

            denominacionesAEntregar.Clear()
            'valida en la base de datos si es correcta la contraseña
            If usuariosDatos.validarAdministador(cbxAdministrador.SelectedValue, txtAdminPassword.Text) Then
                ' se valida cual movimiento es el que se está haciendo
                If fondoInicial Then
                    ' se valida que se agregue el monto de los colones para almacenarlos en la base de datos
                    If agregarDenominacionesALista(pnlDenominacionesColones, denominacionesColones, 0, 0) Then
                        ' valida que se haya ingresado correctamente
                        If denominacionMonedasDatos.almacenarFondoInicial(New DenominacionMonedas(denominacionesAEntregar, cbxAdministrador.SelectedValue, InicioSesion.session.EmpleadoSG.Cod_usuarioSG)) Then
                            denominacionesAEntregar.Clear()
                            ' se valida que se agregue el monto de los dolares y se almacena en la base de datos
                            'If agregarDenominacionesALista(pnlDenominacionesDolares, denominacionesDolares, 1, tipo_cambio) Then
                            ' valida que se haya ingresado correctamente
                            'If denominacionMonedasDatos.almacenarFondoInicial(New DenominacionMonedas(denominacionesAEntregar, cbxAdministrador.SelectedValue, InicioSesion.session.EmpleadoSG.Cod_usuarioSG)) Then
                            '                   MsgBox("Se almacenó correctamente el fondo inicial")
                            ' se desabilita la opcion de ingresar el fondo inicial
                            Ordenes.FondoInicialToolStripMenuItem.Enabled = False
                            ' se muestra la ventana de ordenes
                            Ordenes.Show()
                            ' una vez realizado el ingreso. Se coloca la variable inicio de UsuarioDatos como 
                            ' false para saber que ya hizo su primer asignacion del fondo inicial
                            UsuariosDatos.inicio = False
                            ' se cierra esta ventana
                            Close()
                            'Else
                            'mensaje.lblMensaje.Text = "Error al almacenar el fondo inicial de dólares"
                            'mensaje.ShowDialog()
                            'End If
                            'End If
                        Else
                            mensaje.tipoMensaje("error")
                            mensaje.lblMensaje.Text = "Error al almacenar el fondo inicial de colones"
                            mensaje.ShowDialog()
                        End If
                    End If
                ElseIf fondoFinal Then
                    ' se agrega el monto de los colones y se almacena en la base de datos
                    If agregarDenominacionesALista(pnlDenominacionesColones, denominacionesColones, 0, 0) Then
                        ' valida que se haya ingresado correctamente
                        If denominacionMonedasDatos.almacenarFondoFinal(New DenominacionMonedas(denominacionesAEntregar, cbxAdministrador.SelectedValue, InicioSesion.session.EmpleadoSG.Cod_usuarioSG)) Then
                            denominacionesAEntregar.Clear()
                            ' se agrega el monto de los dolares y se almacena en la base de datos
                            'If agregarDenominacionesALista(pnlDenominacionesDolares, denominacionesDolares, 1, tipo_cambio) Then
                            ' valida que se haya ingresado correctamente
                            'If denominacionMonedasDatos.almacenarFondoFinal(New DenominacionMonedas(denominacionesAEntregar, cbxAdministrador.SelectedValue, InicioSesion.session.EmpleadoSG.Cod_usuarioSG)) Then
                            '                   MsgBox("Se almacenó correctamente el fondo final")
                            ' instancia para ir a la ventana de cierre de caja
                            'cierre_caja_diseno = New CierreCaja
                            'Dim cierre_caja As New CierreCaja
                            '' muestra la ventana
                            'cierre_caja.ShowDialog()
                            Close()
                            'If cierre_caja_diseno.modificar_cierre Then
                            '    MsgBox("cerrar")
                            '    Ordenes.Close()
                            '    InicioSesion.Show()
                            '    cierre_caja_diseno.modificar_cierre = False
                            'End If

                            '    Else
                            'mensaje.lblMensaje.Text = "Error al almacenar el fondo final de dólares"
                            'mensaje.ShowDialog()
                            '    End If
                            'End If
                        Else
                            mensaje.tipoMensaje("error")
                            mensaje.lblMensaje.Text = "Error al almacenar el fondo final de colones"
                            mensaje.ShowDialog()
                        End If
                    End If
                ElseIf salidasEfectivo Then
                    ' se agrega el monto de los colones y se almacena en la base de datos
                    If agregarDenominacionesALista(pnlDenominacionesColones, denominacionesColones, 0, 0) Then
                        ' valida que se haya almacenado la salida de efectivo de colones
                        If denominacionMonedasDatos.almacenarIntroduccionesSalidasEfectivo(New DenominacionMonedas(denominacionesAEntregar, cbxAdministrador.SelectedValue, InicioSesion.session.EmpleadoSG.Cod_usuarioSG), InicioSesion.session.EmpleadoSG.ContrasennaSG, 1) Then
                            denominacionesAEntregar.Clear()
                            ' se agrega el monto de los dolares y se almacena en la base de datos
                            'If agregarDenominacionesALista(pnlDenominacionesDolares, denominacionesDolares, 1, tipo_cambio) Then
                            ' valida que se haya ingresado correctamente
                            'If denominacionMonedasDatos.almacenarIntroduccionesSalidasEfectivo(New DenominacionMonedas(denominacionesAEntregar, cbxAdministrador.SelectedValue, InicioSesion.session.EmpleadoSG.Cod_usuarioSG), InicioSesion.session.EmpleadoSG.ContrasennaSG, 1) Then
                            '                   MsgBox("Se almacenó correctamente la salida de efectivo")
                            Close()
                            'Else
                            ''mensaje.lblMensaje.Text = "Error al almacenar la salida de efectivo de dólares"
                            ''mensaje.ShowDialog()
                            ''End If
                            'End If
                        Else
                            mensaje.tipoMensaje("error")
                            mensaje.lblMensaje.Text = "Error al almacenar la salida de efectivo de colones"
                            mensaje.ShowDialog()
                        End If
                    End If
                ElseIf introducciones Then
                    ' se agrega el monto de los colones y se almacena en la base de datos
                    If agregarDenominacionesALista(pnlDenominacionesColones, denominacionesColones, 0, 0) Then
                        If denominacionMonedasDatos.almacenarIntroduccionesSalidasEfectivo(New DenominacionMonedas(denominacionesAEntregar, cbxAdministrador.SelectedValue, InicioSesion.session.EmpleadoSG.Cod_usuarioSG), InicioSesion.session.EmpleadoSG.ContrasennaSG, 0) Then
                            denominacionesAEntregar.Clear()
                            ' se agrega el monto de los dolares y se almacena en la base de datos
                            '                          If agregarDenominacionesALista(pnlDenominacionesDolares, denominacionesDolares, 1, tipo_cambio) Then
                            ' valida que se haya ingresado correctamente
                            '                               If denominacionMonedasDatos.almacenarIntroduccionesSalidasEfectivo(New DenominacionMonedas(denominacionesAEntregar, cbxAdministrador.SelectedValue, InicioSesion.session.EmpleadoSG.Cod_usuarioSG), InicioSesion.session.EmpleadoSG.ContrasennaSG, 0) Then
                            '                   MsgBox("Se almacenó correctamente la introducción de efectivo")
                            Close()
                            '                                Else
                            '     mensaje.lblMensaje.Text = "Error al almacenar la introducción de efectivo de dólares"
                            '      mensaje.ShowDialog()
                            '   End If
                            'End If
                        Else
                            mensaje.tipoMensaje("error")
                            mensaje.lblMensaje.Text = "Error al almacenar la introducción de efectivo de colones"
                            mensaje.ShowDialog()
                        End If
                    End If
                ElseIf arqueo Then
                    ' se agrega el monto de los colones y se almacena en la base de datos
                    If agregarDenominacionesALista(pnlDenominacionesColones, denominacionesColones, 0, 0) Then
                        ' valida que se haya ingresado correctamente
                        If denominacionMonedasDatos.almacenarArqueoDeCaja(New DenominacionMonedas(denominacionesAEntregar, cbxAdministrador.SelectedValue, InicioSesion.session.EmpleadoSG.Cod_usuarioSG)) Then
                            denominacionesAEntregar.Clear()
                            arqueo_diseno.arqueo = True
                            Close()
                        Else
                            mensaje.tipoMensaje("error")
                            mensaje.lblMensaje.Text = "Error al almacenar el arqueo de caja"
                            mensaje.ShowDialog()
                        End If
                    End If
                End If
            Else
                mensaje.tipoMensaje("error")
                mensaje.lblMensaje.Text = "Contraseña o usuario inválido"
                mensaje.ShowDialog()
            End If
        Else
            mensaje.tipoMensaje("error")
            mensaje.lblMensaje.Text = "Administrador no ingresó la contraseña"
            mensaje.ShowDialog()
        End If
    End Sub

    ' metodo que se encarga de agregar las denominaciones a una lista para mandarla a almacenar en la base
    Public Function agregarDenominacionesALista(ByVal panel As Panel, ByVal tipoDenominacion As DataTable, ByVal tipoMoneda As Integer, ByVal tipoCambio As Double) As Boolean
        Dim monto, subtotal As Double
        Dim cantidad As Integer

        validarCajas()
        ' se agregan los valores para las denominaciones de colones
        For i As Integer = 0 To tipoDenominacion.Rows.Count - 1
            Try
                ' se obtiene el codigo de la moneda
                Dim cod_moneda As Integer = CInt(tipoDenominacion.Rows(i).Item(0).ToString)
                ' se obtiene el valor de la moneda
                Try
                    If panel.Controls.Item("lblDenominacion" + tipoDenominacion.Rows(i).Item(0).ToString).Text <> "" Then
                        ' se valida que la cantidad no este sin valor
                        If panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text <> "" Or
                            Not IsNothing(panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text) Then
                            monto = CDbl(panel.Controls.Item("lblDenominacion" + tipoDenominacion.Rows(i).Item(0).ToString).Text)
                            ' se obtiene la cantidad de esa moneda
                            cantidad = CInt(panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text)
                            ' se calcula el subtotal de esa moneda especifica
                            subtotal = monto * cantidad
                            ' se agrega a la lista
                            denominacionesAEntregar.Add(New Monedas(cod_moneda, Nothing, monto, tipoMoneda, cantidad, subtotal, tipoCambio))
                        Else
                            mensaje.tipoMensaje("error")
                            mensaje.lblMensaje.Text = "Dato erróneo en la cantidad asignada a la denominación: " + monto
                            mensaje.ShowDialog()
                            Return False
                        End If
                    Else
                        mensaje.tipoMensaje("error")
                        mensaje.lblMensaje.Text = "Dato erróneo en el monto"
                        mensaje.ShowDialog()
                        Return False
                    End If

                Catch ex As InvalidCastException
                    mensaje.tipoMensaje("error")
                    mensaje.lblMensaje.Text = "No se pueden dejar datos en blancos"
                    mensaje.ShowDialog()
                    Return False
                End Try
            Catch ex As NullReferenceException
                mensaje.tipoMensaje("error")
                mensaje.lblMensaje.Text = "¡Valor vacío!"
                mensaje.ShowDialog()
                Return False
            End Try
        Next
        Return True
    End Function

    ' evento del boton de cancelar
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If fondoInicial Then
            If UsuariosDatos.inicio Then
                Close()
                InicioSesion.Show()
            End If
        End If
    End Sub

    ' evento del radio button de colones
    Private Sub rbColones_CheckedChanged(sender As Object, e As EventArgs) Handles rbColones.CheckedChanged
        lblCambio.Hide()
        txtTipoCambio.Hide()
        mostrarValoresDenominaciones(pnlDenominacionesColones, denominacionesColones)
        lblMoneda.Text = "Colones"
        pnlDenominacionesColones.Visible = True
        pnlDenominacionesDolares.Visible = False
    End Sub

    ' evento del radio button de delares
    Private Sub rbDolares_CheckedChanged(sender As Object, e As EventArgs) Handles rbDolares.CheckedChanged
        mostrarValoresDenominaciones(pnlDenominacionesDolares, denominacionesDolares)
        lblCambio.Show()
        txtTipoCambio.Show()
        lblMoneda.Text = "Dólares"
        pnlDenominacionesDolares.Visible = True
        pnlDenominacionesColones.Visible = False
    End Sub

    ' metodo que valida que lo digitado en la cantidad sea un numero
    Private Sub txtValorDenominacion_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' valida que sea un digito
        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            'CType(sender, TextBox).Text = CType(sender, TextBox).Text.Substring(0, CType(sender, TextBox).Text.Length)
            e.Handled = True
        End If
    End Sub

    ' evento de la caja de texto de cantidad de monedas cuando cambia los valores
    Private Sub txtValorCantidad__TextChanged(ByVal sender As Object, ByVal e As EventArgs)

        Dim tipoDenominacion As New DataTable
        Dim panel As New Panel
        Dim fondo As Double = 0

        ' valida para que tipo de denominacion es
        If (rbColones.Checked) Then
            tipoDenominacion = denominacionesColones
            panel = pnlDenominacionesColones
        Else
            tipoDenominacion = denominacionesDolares
            panel = pnlDenominacionesDolares
        End If


        For i As Integer = 0 To tipoDenominacion.Rows.Count - 1
            If CType(sender, TextBox).Name = ("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString) Then
                'If panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text.Trim.Length > 0 Then
                'If panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text(0) = "0" Then
                '    panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text = panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text.TrimStart("0")
                'End If
                'End If


                ' se obtiene el valor de la moneda
                Dim monto As Double = CDbl(panel.Controls.Item("lblDenominacion" + tipoDenominacion.Rows(i).Item(0).ToString).Text)

                Dim cantidad As Double = 0
                Try
                    ' se obtiene la cantidad de esa moneda
                    cantidad = CDbl(panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text)
                    If (CInt(cantidad) = cantidad) Then
                        ' se realiza el calculo total
                        Dim subtotal As Double = monto * cantidad
                        ' se muestra el resultado en el campo de subtotal
                        panel.Controls.Item("txtValorDenominacion" + tipoDenominacion.Rows(i).Item(0).ToString).Text = subtotal '.ToString("C")
                    Else
                        panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text = ""
                    End If

                Catch exic As InvalidCastException

                Catch exof As OverflowException

                End Try


            End If
            ' se realiza el calculo del fondo
            Try
                If (Not ((panel.Controls.Item("txtValorDenominacion" + tipoDenominacion.Rows(i).Item(0).ToString).Text)) = "") Then
                    fondo += CDbl((panel.Controls.Item("txtValorDenominacion" + tipoDenominacion.Rows(i).Item(0).ToString).Text))
                End If


            Catch ex As InvalidCastException
                MsgBox("Error de conversion")
            End Try
        Next

        ' variables que tendrán el valor de fondo en colones y dolares
        Dim colones As Double = 0
        Dim dolares As Double = 0
        ' se valida el tipo de movimineto que sea
        If fondoInicial Or fondoFinal Or arqueo Then
            If (rbColones.Checked) Then
                ' se muestra el fondo en colones 
                lblFonfoCajaColones.Text = fondo.ToString("C")
            Else
                ' se muestra el fondo en dolares 
                lblFonfoCajaDolares.Text = fondo.ToString("C")
            End If
            ' se obtiene los valores de fondo en colones y en dolares y se realiza la suma para mostrar el subtotal
            colones = CDbl(lblFonfoCajaColones.Text)
            dolares = CDbl(lblFonfoCajaDolares.Text)
            lblFonfoCajaTotal.Text = (colones + (dolares * tipo_cambio)).ToString("C")

        ElseIf salidasEfectivo Then
            If (rbColones.Checked) Then
                ' se muestra el fondo en colones 
                lblSalidaCajaColones.Text = fondo.ToString("C")
            Else
                ' se muestra el fondo en dolares 
                lblSalidaCajaDolares.Text = fondo.ToString("C")
            End If
            ' se obtiene los valores de salidas en colones y en dolares y se realiza la suma para mostrar el subtotal
            colones = CDbl(lblSalidaCajaColones.Text)
            dolares = CDbl(lblSalidaCajaDolares.Text)
            lblSalidaCajaTotal.Text = (colones + (dolares * tipo_cambio)).ToString("C")

        ElseIf introducciones Then
            If (rbColones.Checked) Then
                ' se muestra el fondo en colones 
                lblIntroduccionCajaColones.Text = fondo.ToString("C")
            Else
                ' se muestra el fondo en dolares 
                lblIntroduccionCajaDolares.Text = fondo.ToString("C")
            End If
            ' se obtiene los valores de las introdicciones en colones y en dolares y se realiza la suma para mostrar el subtotal
            colones = CDbl(lblIntroduccionCajaColones.Text)
            dolares = CDbl(lblIntroduccionCajaDolares.Text)
            lblIntroduccionCajaTotal.Text = (colones + (dolares * tipo_cambio)).ToString("C")

        End If
    End Sub

    ' evento de la caja de texto del subtotal de cada moneda cuando cambia los valores
    Private Sub txtValorDenominacion__TextChanged(ByVal sender As Object, ByVal e As EventArgs)


        Dim tipoDenominacion As New DataTable
        Dim panel As New Panel
        Dim fondo As Double = 0

        ' valida para que tipo de denominacion es
        If (rbColones.Checked) Then
            tipoDenominacion = denominacionesColones
            panel = pnlDenominacionesColones
        Else
            tipoDenominacion = denominacionesDolares
            panel = pnlDenominacionesDolares
        End If

        ' recorre las denominaciones
        For i As Integer = 0 To tipoDenominacion.Rows.Count - 1
            If CType(sender, TextBox).Name = ("txtValorDenominacion" + tipoDenominacion.Rows(i).Item(0).ToString) Then
                ' se obtiene el valor de la moneda
                Dim monto As Double = CDbl(panel.Controls.Item("lblDenominacion" + tipoDenominacion.Rows(i).Item(0).ToString).Text)

                Dim subtotal As Double = 0
                Try
                    ' se obtiene la cantidad de esa moneda
                    subtotal = CDbl(panel.Controls.Item("txtValorDenominacion" + tipoDenominacion.Rows(i).Item(0).ToString).Text)

                Catch ex As InvalidCastException

                End Try
                ' se realiza el calculo total
                Dim cantidad As Double = subtotal / monto
                ' se muestra el resultado en el campo de subtotal
                'MsgBox("antes")
                panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text = cantidad
            End If
            ' se realiza el calculo del fondo
            Try
                Dim cantidad = panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text
                If (CInt(cantidad) = cantidad) Then
                    fondo += CDbl((panel.Controls.Item("txtValorDenominacion" + tipoDenominacion.Rows(i).Item(0).ToString).Text))
                End If
            Catch ex As InvalidCastException

            End Try

        Next

        ' variables que tendrán el valor de fondo en colones y dolares
        Dim colones As Double = 0
        Dim dolares As Double = 0
        ' se valida el tipo de movimineto que sea
        If fondoInicial Or fondoFinal Or arqueo Then
            If (rbColones.Checked) Then
                ' se muestra el fondo en colones 
                lblFonfoCajaColones.Text = fondo.ToString("C")
            Else
                ' se muestra el fondo en dolares 
                lblFonfoCajaDolares.Text = fondo.ToString("C")
            End If
            ' se obtiene los valores de fondo en colones y en dolares y se realiza la suma para mostrar el subtotal
            colones = CDbl(lblFonfoCajaColones.Text)
            dolares = CDbl(lblFonfoCajaDolares.Text)
            lblFonfoCajaTotal.Text = (colones + (dolares * tipo_cambio)).ToString("C")

        ElseIf salidasEfectivo Then
            If (rbColones.Checked) Then
                ' se muestra el fondo en colones 
                lblSalidaCajaColones.Text = fondo.ToString("C")
            Else
                ' se muestra el fondo en dolares 
                lblSalidaCajaDolares.Text = fondo.ToString("C")
            End If
            ' se obtiene los valores de salidas en colones y en dolares y se realiza la suma para mostrar el subtotal
            colones = CDbl(lblSalidaCajaColones.Text)
            dolares = CDbl(lblSalidaCajaDolares.Text)
            lblSalidaCajaTotal.Text = (colones + (dolares * tipo_cambio)).ToString("C")

        ElseIf introducciones Then
            If (rbColones.Checked) Then
                ' se muestra el fondo en colones 
                lblIntroduccionCajaColones.Text = fondo
            Else
                ' se muestra el fondo en dolares 
                lblIntroduccionCajaDolares.Text = fondo
            End If
            ' se obtiene los valores de las introdicciones en colones y en dolares y se realiza la suma para mostrar el subtotal
            colones = CDbl(lblIntroduccionCajaColones.Text)
            dolares = CDbl(lblIntroduccionCajaDolares.Text)
            lblIntroduccionCajaTotal.Text = colones + (dolares * tipo_cambio)

        End If
    End Sub

    ' asigna el valor del tipo de cambio
    Private Sub txtTipoCambio_TextChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.TextChanged

        If (rbDolares.Checked) Then
            ' variables que tendrán el valor de fondo en colones y dolares
            Dim colones As Double = 0
            Dim dolares As Double = 0
            ' obtiene el valor del cambio de dolar
            Try
                tipo_cambio = CInt(txtTipoCambio.Text)

            Catch ex As InvalidCastException
                tipo_cambio = 0
            Catch over As OverflowException
                tipo_cambio = 0
            End Try

            ' valida que sea el fondo inicial o fondo final
            If fondoInicial Or fondoFinal Or arqueo Then
                ' se obtiene los valores de fondo en colones y en dolares y se realiza la suma para mostrar el subtotal
                colones = CDbl(lblFonfoCajaColones.Text)
                dolares = CDbl(lblFonfoCajaDolares.Text)
                lblFonfoCajaTotal.Text = (colones + (dolares * tipo_cambio)).ToString("C")

                ' valida que sean salidas de efectivo
            ElseIf salidasEfectivo Then
                ' se obtiene los valores de salidas colones y en dolares y se realiza la suma para mostrar el subtotal
                colones = CDbl(lblSalidaCajaColones.Text)
                dolares = CDbl(lblSalidaCajaDolares.Text)
                lblSalidaCajaTotal.Text = (colones + (dolares * tipo_cambio)).ToString("C")

                ' valida que sean introducciones de efectivo
            ElseIf introducciones Then
                ' se obtiene los valores de introducciones en colones y en dolares y se realiza la suma para mostrar el subtotal
                colones = CDbl(lblIntroduccionCajaColones.Text)
                dolares = CDbl(lblIntroduccionCajaDolares.Text)
                lblIntroduccionCajaTotal.Text = (colones + (dolares * tipo_cambio)).ToString("C")
            End If
            InitializeComponent()
        End If

    End Sub

    Private Sub MovimientosEfectivo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' valida si se esta ingresando el fondo inicial
        If fondoInicial Then
            ' valida que sea el primer ingreso
            If UsuariosDatos.inicio Then
                ' cierra la ventana y muestra la ventana de inicio de sesion
                Close()
                InicioSesion.Show()
            End If
        End If
    End Sub

    Private Sub txtCantidad_MouseClick(sender As Object, e As MouseEventArgs)
        Dim tipoDenominacion As New DataTable
        Dim panel As New Panel
        Dim fondo As Double = 0

        ' valida para que tipo de denominacion es
        If (rbColones.Checked) Then
            tipoDenominacion = denominacionesColones
            panel = pnlDenominacionesColones
        Else
            tipoDenominacion = denominacionesDolares
            panel = pnlDenominacionesDolares
        End If

        For i As Integer = 0 To tipoDenominacion.Rows.Count - 1
            If CType(sender, TextBox).Name = ("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString) Then
                If panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text.Length > 0 Then
                    If panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text(0) = "0" Then
                        panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text = ""
                    End If
                End If
            End If
        Next

    End Sub

    Private Sub validarCajas()
        Dim tipoDenominacion As New DataTable
        Dim panel As New Panel
        Dim fondo As Double = 0

        ' valida para que tipo de denominacion es
        If (rbColones.Checked) Then
            tipoDenominacion = denominacionesColones
            panel = pnlDenominacionesColones
        Else
            tipoDenominacion = denominacionesDolares
            panel = pnlDenominacionesDolares
        End If


        For i As Integer = 0 To tipoDenominacion.Rows.Count - 1
            If Not panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text.Trim.Length > 0 Then
                panel.Controls.Item("txtCantidad" + tipoDenominacion.Rows(i).Item(0).ToString).Text = 0
            End If
        Next

    End Sub
End Class