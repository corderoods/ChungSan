Imports SunChangSystem

Public Class InicioSesion

    Public Shared session As New Session

    Public Property SessionSG As Session
        Get
            Return session
        End Get
        Set(value As Session)
            session = value
        End Set
    End Property

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        ' inicializa las variables a utilizar
        Dim codigo_usuario, contrasenna As String
        ' se obtiene el codigo del usuario y la contrasenna para comparar en la base
        codigo_usuario = txtCodigo.Text
        contrasenna = txtContrasenna.Text
        ' instancia de la clase UsuariosDatos para validar en la base de datos
        Dim usuario_sesion As New UsuariosDatos
        ' se obtiene el empleado
        Dim session_a_iniciar As Session = usuario_sesion.validarSesion(codigo_usuario, contrasenna)
        ' se valida que haya una sesion creada
        If session_a_iniciar Is (Nothing) Then
            Dim mensaje As New Mensaje
            mensaje.tipoMensaje("error")
            mensaje.lblMensaje.Text = "No se encuentra registrado!"
            mensaje.ShowDialog()
        Else
            ' se asigna el objeto se session creado al objeto de session a compartir
            Me.SessionSG = session_a_iniciar
            ' se valida que sea el primer ingreso del usuario
            If UsuariosDatos.inicio Then
                'Instancia a la ventana de movimientos de efectivo
                Dim fondoInicial As New MovimientosEfectivo
                ' coloca la variable de fondoInicial en true para saber que es la accion que se va a realizar
                fondoInicial.fondoInicial = True
                ' llama al metodo para cargar y mostrar las nominaciones
                fondoInicial.cargarDenominaciones()
                ' se oculta esta ventana de inicio de sesion
                Me.Hide()
                ' llama a la ventana del fondo inicial
                fondoInicial.ShowDialog()
                ' coloca la variable de fondoInicial en false para saber que la accion ya se realizo
                fondoInicial.fondoInicial = False
            Else
                Me.Hide()
                Ordenes.FondoInicialToolStripMenuItem.Enabled = False
                Ordenes.Show()
            End If
        End If
    End Sub

    Public Shared Sub cerrarConexion()
        InicioSesion.Close()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class