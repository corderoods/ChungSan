Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class MovimientoCajaDatos

    ' variables locales y publicas
    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD
    Public Shared tablas As DataSet

    ' constructor
    Public Sub New()
        conexionDB = New ConexionBD
        cmd = New SqlCommand
    End Sub

    '********************************************************
    '******************** ALMACENA DATOS ********************
    '********************************************************

    ' metodo que se encargar de almacenar el fondo inicial asignado al cajero
    Public Function almacenarFondoInicial(ByVal denominacionesMonedas As DenominacionMonedas) As Boolean
        ' se obtiene la fecha actual del sistema para enviarla como la hora de ingreso del fondo inicial
        Dim fecha As DateTime = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' valida que se haya almacenado el flujo de caja multiple
        'If almacenarFlujocajaMultiple(denominacionesMonedas) Then
        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_almacena_fondo_inicial_flujocaja_d"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' variable que obtendrá la lista de denominaciones de las monedas
        Dim listaDenominaciones As List(Of Monedas) = denominacionesMonedas.ListaDenominacionesSG

        ' recorre la lista de monedas en colones y las inserta en la base de datos
        For i As Integer = 0 To listaDenominaciones.Count - 1
            ' asigna los parametros a enviar al procedimiento
            With cmd.Parameters
                .AddWithValue("@codigo_usuario_asigna", denominacionesMonedas.Codigo_usuario_asignaSG)
                .AddWithValue("@codigo_usuario_recibe", denominacionesMonedas.Codigo_usuario_recibeSG)
                .AddWithValue("@fecha", fecha)
                .AddWithValue("@tipo_moneda", listaDenominaciones(i).Tipo_monedaSG)
                .AddWithValue("@cod_moneda", listaDenominaciones(i).Codigo_monedaSG)
                .AddWithValue("@cantidad", listaDenominaciones(i).CantidadSG)
                .AddWithValue("@subtotal", listaDenominaciones(i).SubtotalSG)
                'valida si es la primer iteracion (i=0) para indicar en la bandera
                .AddWithValue("@flag", IIf(i = 0, 1, 0))
                .AddWithValue("@tipo_cambio", listaDenominaciones(i).Tipo_cambioSG)
                '.AddWithValue("@cantidad_cierre", 0)
                '.AddWithValue("@subtotal_cierre", 0)
            End With
            'MsgBox(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Try

                ' ejecuta la consulta a la base
                cmd.ExecuteNonQuery()
                ' limpia los parametros del comando
                cmd.Parameters.Clear()

            Catch ex As Exception
                MsgBox(ex.Message)
                ' limpia los parametros del comando
                cmd.Parameters.Clear()
                'cierra la conexion
                conexionDB.cerrarConexion()
                Return False
            End Try
        Next

        conexionDB.cerrarConexion()
        'Else
        'Return False
        'End If

        Return True

    End Function

    ' metodo que se encargar de almacenar el fondo final obtenido por el cajero
    Public Function almacenarFondoFinal(ByVal denominacionesMonedas As DenominacionMonedas, dataExPpress As Double, dataSalon As Double) As Boolean
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' valida que se haya almacenado el flujo de caja multiple
        'If asignarCierreCaja(denominacionesMonedas) Then
        ' se asigna el tipo de consulta que es. Si es para llamar a procedimiento almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_almacena_fondo_final_flujocaja_d"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' variable que obtendrá la lista de denominaciones de las monedas
        Dim listaDenominaciones As List(Of Monedas) = denominacionesMonedas.ListaDenominacionesSG

        ' recorre la lista de monedas en colones y las inserta en la base de datos
        For i As Integer = 0 To listaDenominaciones.Count - 1
            ' asigna los parametros a enviar al procedimiento
            With cmd.Parameters
                '.AddWithValue("@codigo_usuario_asigna", denominacionesMonedas.Codigo_usuario_asignaSG)
                .AddWithValue("@codigo_usuario_recibe", denominacionesMonedas.Codigo_usuario_recibeSG)
                .AddWithValue("@tipo_moneda", listaDenominaciones(i).Tipo_monedaSG)
                .AddWithValue("@cod_moneda", listaDenominaciones(i).Codigo_monedaSG)
                .AddWithValue("@cantidad_cierre", listaDenominaciones(i).CantidadSG)
                .AddWithValue("@subtotal_cierre", listaDenominaciones(i).SubtotalSG)
                .AddWithValue("@fonoExpress", dataExPpress)
                .AddWithValue("@fonoSalon", dataSalon)
                .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                'valida si es la primer iteracion (i=0) para indicar en la bandera
                .AddWithValue("@flag", IIf(i = 0, 1, 0))
            End With
            'MsgBox(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Try

                ' ejecuta la consulta a la base
                cmd.ExecuteNonQuery()
                ' limpia los parametros del comando
                cmd.Parameters.Clear()

            Catch ex As Exception
                MsgBox(ex.Message)
                ' limpia los parametros del comando
                cmd.Parameters.Clear()
                'cierra la conexion
                conexionDB.cerrarConexion()
                Return False
            End Try
        Next

        conexionDB.cerrarConexion()
        'Else
        '    Return False
        'End If

        Return True

    End Function

    ' metodo que se encargar de almacenar el arqueo de caja realizado
    Public Function almacenarArqueoDeCaja(ByVal denominacionesMonedas As DenominacionMonedas, ByVal fonoExpres As Double, ByVal fonoSalon As Double) As Boolean
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()
        ' se asigna el tipo de consulta que es. Si es para llamar a procedimiento almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_almacena_arqueo_caja"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' variable que obtendrá la lista de denominaciones de las monedas
        Dim listaDenominaciones As List(Of Monedas) = denominacionesMonedas.ListaDenominacionesSG

        ' recorre la lista de monedas en colones y las inserta en la base de datos
        For i As Integer = 0 To listaDenominaciones.Count - 1
            ' asigna los parametros a enviar al procedimiento
            With cmd.Parameters
                '.AddWithValue("@codigo_usuario_asigna", denominacionesMonedas.Codigo_usuario_asignaSG)
                .AddWithValue("@codigo_usuario_recibe", denominacionesMonedas.Codigo_usuario_recibeSG)
                .AddWithValue("@tipo_moneda", listaDenominaciones(i).Tipo_monedaSG)
                .AddWithValue("@cod_moneda", listaDenominaciones(i).Codigo_monedaSG)
                .AddWithValue("@cantidad_cierre", listaDenominaciones(i).CantidadSG)
                .AddWithValue("@subtotal_cierre", listaDenominaciones(i).SubtotalSG)
                'valida si es la primer iteracion (i=0) para indicar en la bandera
                .AddWithValue("@flag", IIf(i = 0, 1, 0))
                .AddWithValue("@fecha_inicio", InicioSesion.session.Hora_primer_ingresoSG)
                .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
            End With
            'MsgBox(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Try

                ' ejecuta la consulta a la base
                cmd.ExecuteNonQuery()
                ' limpia los parametros del comando
                cmd.Parameters.Clear()

            Catch ex As Exception
                MsgBox(ex.Message)
                ' limpia los parametros del comando
                cmd.Parameters.Clear()
                'cierra la conexion
                conexionDB.cerrarConexion()
                Return False
            End Try
        Next

        conexionDB.cerrarConexion()
        'Else
        '    Return False
        'End If

        Return True

    End Function

    ' metodo que se encargar de revertir el arqueo de caja realizado
    Public Function revertirArqueoDeCaja(cod_usuario As String, fecha_inicio As String) As Boolean
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()
        ' se asigna el tipo de consulta que es. Si es para llamar a procedimiento almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_revertir_arqueo_caja"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' asigna los parametros a enviar al procedimiento
        With cmd.Parameters
            '.AddWithValue("@codigo_usuario_asigna", denominacionesMonedas.Codigo_usuario_asignaSG)
            .AddWithValue("@codigo_usuario_recibe", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        End With

        Try
            ' ejecuta la consulta a la base
            cmd.ExecuteNonQuery()
            ' limpia los parametros del comando
            cmd.Parameters.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return False
        End Try

        conexionDB.cerrarConexion()

        Return True

    End Function

    ' metodo que se encarga de obtener todas las denominaciones de monedas de colones en la base de datos
    Public Function revertirCierreCaja(ByVal cod_usuario As String, ByVal fecha_inicio As String) As Boolean
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' consulta a la base de datos por todas las denominaciones de colones de efectivo de la base de datos
            cmd = New SqlCommand("UPDATE FAC.flujocaja_m SET estado_caja = 'R' FROM FAC.flujocaja_m AS fd WHERE FD.cod_usuario_recibe = @cod_usuario AND
                                CONCAT(DATEPART(YEAR,fd.fecha), '-', RIGHT(CONCAT('0',DATEPART(MONTH, fd.fecha)),2), '-', RIGHT(CONCAT('0',DATEPART(DAY, fd.fecha)),2), ' ', RIGHT(CONCAT('0',DATEPART(HOUR, fd.fecha)),2), ':',RIGHT(CONCAT('0',DATEPART(MINUTE, fd.fecha)),2), ':', RIGHT(CONCAT('0',DATEPART(SECOND, fd.fecha)),2)) 
                                BETWEEN CONCAT(DATEPART(YEAR,@fecha_inicio), '-', RIGHT(CONCAT('0',DATEPART(MONTH, @fecha_inicio)),2), '-', RIGHT(CONCAT('0',DATEPART(DAY, @fecha_inicio)),2), ' ', RIGHT(CONCAT('0',DATEPART(HOUR, @fecha_inicio)),2), ':',RIGHT(CONCAT('0',DATEPART(MINUTE, @fecha_inicio)),2), ':', RIGHT(CONCAT('0',DATEPART(SECOND, @fecha_inicio)),2))  AND 
                                CONCAT(DATEPART(YEAR,@fecha_fin), '-', RIGHT(CONCAT('0',DATEPART(MONTH, @fecha_fin)),2), '-', RIGHT(CONCAT('0',DATEPART(DAY, @fecha_fin)),2), ' ', RIGHT(CONCAT('0',DATEPART(HOUR, @fecha_fin)),2), ':',RIGHT(CONCAT('0',DATEPART(MINUTE, @fecha_fin)),2), ':', RIGHT(CONCAT('0',DATEPART(SECOND, @fecha_fin)),2))")
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.Text

            ' se asignan los parametros a enviar en el procedimiento almacenado
            With cmd.Parameters
                .AddWithValue("@cod_usuario", cod_usuario)
                .AddWithValue("@fecha_inicio", fecha_inicio)
                .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                '.AddWithValue("@flag", bandera)
            End With

            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion



            ' ejecuta la consulta a la base
            cmd.ExecuteNonQuery()
                ' limpia los parametros del comando
                cmd.Parameters.Clear()

            Catch ex As Exception
                MsgBox(ex.Message)
                ' limpia los parametros del comando
                cmd.Parameters.Clear()
                'cierra la conexion
                conexionDB.cerrarConexion()
                Return False
            End Try
        Return True
    End Function
    ' metodo que se encargar de almacenar las salidas o introduciones de efectivo realizadas por el cajero (tipoEvento)
    Public Function almacenarIntroduccionesSalidasEfectivo(ByVal denominacionesMonedas As DenominacionMonedas, ByVal contrasennaUsuario As String, ByVal tipoEvento As Integer) As Boolean
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_almacena_intro_sale"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' variable que obtendrá la lista de denominaciones de las monedas
        Dim listaDenominaciones As List(Of Monedas) = denominacionesMonedas.ListaDenominacionesSG

        ' recorre la lista de monedas en colones y las inserta en la base de datos
        For i As Integer = 0 To listaDenominaciones.Count - 1
            ' valida que se vaya a enviar alguna cantidad de la nominacion que se esta procesando en ese momento
            If listaDenominaciones(i).CantidadSG > 0 Then
                ' asigna los parametros a enviar al procedimiento
                With cmd.Parameters
                    .AddWithValue("@cod_usuario", denominacionesMonedas.Codigo_usuario_recibeSG)
                    .AddWithValue("@fecha", DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")))
                    .AddWithValue("@cod_moneda", listaDenominaciones(i).Codigo_monedaSG)
                    .AddWithValue("@cantidad", listaDenominaciones(i).CantidadSG)
                    .AddWithValue("@subtotal", listaDenominaciones(i).SubtotalSG)
                    .AddWithValue("@tipo_moneda", listaDenominaciones(i).Tipo_monedaSG)
                    .AddWithValue("@tipo_cambio", listaDenominaciones(i).Tipo_cambioSG)
                    .AddWithValue("@pass_user", contrasennaUsuario)
                    .AddWithValue("@aprobado", 0)
                    .AddWithValue("@tipo_evento", tipoEvento)
                End With

                'MsgBox(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                Try
                    ' ejecuta la consulta a la base
                    cmd.ExecuteNonQuery()
                    ' limpia los parametros del comando
                    cmd.Parameters.Clear()

                Catch ex As Exception
                    MsgBox(ex.Message)
                    ' limpia los parametros del comando
                    cmd.Parameters.Clear()
                    ' cierra la conexion
                    conexionDB.cerrarConexion()
                    Return False
                End Try
            End If
        Next

        ' cierra la conexion
        conexionDB.cerrarConexion()

        Return True

    End Function

    ' metodo que se encarga de almacenar el pago de facturas a los proveedores
    Public Function almacenarPagoFacturaProveedor(ByVal lista_factura_a_pagar As List(Of FacturaPago)) As Boolean

        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_almacena_pago_facturas"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' recorre la lista de facturas a pagars y las inserta en la base de datos
        For i As Integer = 0 To lista_factura_a_pagar.Count - 1
            ' asigna los parametros a enviar al procedimiento
            With cmd.Parameters
                .AddWithValue("@cod_usuario", lista_factura_a_pagar(i).Cod_UsuarioSG)
                .AddWithValue("@fecha_pago", lista_factura_a_pagar(i).Fecha_pagoSG)
                .AddWithValue("@concepto", lista_factura_a_pagar(i).ConceptoSG)
                .AddWithValue("@cod_proveedor", lista_factura_a_pagar(i).Cod_proveedorSG)
                .AddWithValue("@tipo", lista_factura_a_pagar(i).TipoSG)
                .AddWithValue("@fecha_factura", lista_factura_a_pagar(i).Fecha_facturaSG)
                .AddWithValue("@num_factura", lista_factura_a_pagar(i).Numero_facturaSG)
                .AddWithValue("@monto_factura", lista_factura_a_pagar(i).Monto_facturaSG)
                .AddWithValue("@elemento", lista_factura_a_pagar(i).ElementoSG)
                .AddWithValue("@observaciones", lista_factura_a_pagar(i).ObservacionesSG)
            End With

            Try
                ' ejecuta la consulta a la base
                cmd.ExecuteNonQuery()
                ' limpia los parametros del comando
                cmd.Parameters.Clear()

            Catch ex As Exception
                MsgBox("Ha ocurrido un error, verifique los datos a ingresar")
                ' limpia los parametros del comando
                cmd.Parameters.Clear()
                ' cierra la conexion
                conexionDB.cerrarConexion()
                Return False
            End Try
        Next

        ' cierra la conexion
        conexionDB.cerrarConexion()

        Return True

    End Function


    '********************************************************
    '******************** CONSULTA DATOS ********************
    '********************************************************

    ' metodo que se encarga de obtener las denominaciones de colones y de dolares llamando a los dos metodos
    ' para obtenerlos de la base
    Public Function obtenerDenominacionesMonedas() As List(Of DataTable)
        ' lista que contendra las denominaciones 
        Dim denominaciones As New List(Of DataTable)
        ' agrega a la lista las denominaciones de colones al llamar al metodo que las obtiene de la base de datos
        denominaciones.Add(obtenerDenominacionesColones)
        ' agrega a la lista las denominaciones de dolares al llamar al metodo que las obtiene de la base de datos
        denominaciones.Add(obtenerDenominacionesDolares)


        Return denominaciones

    End Function

    ' metodo que se encarga de obtener todas las denominaciones de monedas de colones en la base de datos
    Public Function obtenerDenominacionesColones() As DataTable
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' consulta a la base de datos por todas las denominaciones de colones de efectivo de la base de datos
            cmd = New SqlCommand("SELECT cod_moneda, valor FROM FAC.monedas WHERE tipo_moneda = 0 ORDER BY valor ASC")
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.Text
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion

            ' se ejecuta la consulta y se valida que todo este bien
            If cmd.ExecuteNonQuery Then
                '' datatable que guardara todas las denominaciones de coloones para mostrarlas en la ventana
                Using nuevatabla As New DataTable
                    Using adaptador As New SqlDataAdapter(cmd)
                        '' se llena la tabla con todas la denominaciones de colones de las monedas
                        adaptador.Fill(nuevatabla)
                        '' se cierra la conexion con la base de datos
                        conexionDB.cerrarConexion()
                        ' retorna las denominaciones
                        Return nuevatabla
                    End Using
                End Using
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    ' metodo que se encarga de obtener LOS VALORES DEL CIERRE DE CAJA QUE SE HABIA HECHO Y SE QUIERE MODIFICAR
    Public Function obtenerDenominacionesCierreCaja(ByVal cod_usuario As String, ByVal fecha_inicio As String) As DataTable
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' consulta a la base de datos por todas las denominaciones de colones de efectivo de la base de datos
            cmd = New SqlCommand("SELECT fd.cantidad_cierre, fd.subtotal_cierre FROM FAC.flujocaja_d as fd
                                INNER JOIN fac.monedas AS m ON m.cod_moneda = fd.cod_moneda
                                WHERE FD.cod_usuario_recibe = @cod_usuario AND
                                CONCAT(DATEPART(YEAR,fd.fecha), '-', RIGHT(CONCAT('0',DATEPART(MONTH, fd.fecha)),2), '-', RIGHT(CONCAT('0',DATEPART(DAY, fd.fecha)),2), ' ', RIGHT(CONCAT('0',DATEPART(HOUR, fd.fecha)),2), ':',RIGHT(CONCAT('0',DATEPART(MINUTE, fd.fecha)),2), ':', RIGHT(CONCAT('0',DATEPART(SECOND, fd.fecha)),2)) 
                                BETWEEN CONCAT(DATEPART(YEAR,@fecha_inicio), '-', RIGHT(CONCAT('0',DATEPART(MONTH, @fecha_inicio)),2), '-', RIGHT(CONCAT('0',DATEPART(DAY, @fecha_inicio)),2), ' ', RIGHT(CONCAT('0',DATEPART(HOUR, @fecha_inicio)),2), ':',RIGHT(CONCAT('0',DATEPART(MINUTE, @fecha_inicio)),2), ':', RIGHT(CONCAT('0',DATEPART(SECOND, @fecha_inicio)),2))  AND 
                                CONCAT(DATEPART(YEAR,@fecha_fin), '-', RIGHT(CONCAT('0',DATEPART(MONTH, @fecha_fin)),2), '-', RIGHT(CONCAT('0',DATEPART(DAY, @fecha_fin)),2), ' ', RIGHT(CONCAT('0',DATEPART(HOUR, @fecha_fin)),2), ':',RIGHT(CONCAT('0',DATEPART(MINUTE, @fecha_fin)),2), ':', RIGHT(CONCAT('0',DATEPART(SECOND, @fecha_fin)),2))
                                ORDER BY m.valor ASC")
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.Text

            ' se asignan los parametros a enviar en el procedimiento almacenado
            With cmd.Parameters
                .AddWithValue("@cod_usuario", cod_usuario)
                .AddWithValue("@fecha_inicio", fecha_inicio)
                .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                '.AddWithValue("@flag", bandera)
            End With

            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion

            ' se ejecuta la consulta y se valida que todo este bien
            If cmd.ExecuteNonQuery Then
                '' datatable que guardara todas las denominaciones de coloones para mostrarlas en la ventana
                Using nuevatabla As New DataTable
                    Using adaptador As New SqlDataAdapter(cmd)
                        '' se llena la tabla con todas la denominaciones de colones de las monedas
                        adaptador.Fill(nuevatabla)
                        '' se cierra la conexion con la base de datos
                        conexionDB.cerrarConexion()
                        ' retorna las denominaciones
                        Return nuevatabla
                    End Using
                End Using
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    ' metodo que se encarga de obtener todas las denominaciones de monedas de dolares en la base de datos
    Public Function obtenerDenominacionesDolares() As DataTable
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' consulta a la base de datos por todas las denominaciones de dolares de efectivo de la base de datos
            cmd = New SqlCommand("SELECT cod_moneda, valor FROM FAC.monedas WHERE tipo_moneda = 1 ORDER BY valor ASC")
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.Text
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion

            ' se ejecuta la consulta y se valida que todo este bien
            If cmd.ExecuteNonQuery Then
                '' datatable que guardara todas las denominaciones de dolares para mostrarlas en la ventana
                Using nuevatabla As New DataTable
                    Using adaptador As New SqlDataAdapter(cmd)
                        '' se llena la tabla con todas la denominaciones de dolares de las monedas
                        adaptador.Fill(nuevatabla)
                        '' se cierra la conexion con la base de datos
                        conexionDB.cerrarConexion()
                        ' retorna las denominaciones
                        Return nuevatabla
                    End Using
                End Using
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    ' metodo que se encarga de obtener el monto que corresponde al total de las ventas sea en efectivo o en tarjeta para el cajero a consultar
    ' se determina cual segun la bandera. 0 para efectivo y 1 para tarjeta
    Public Function obtenerIngresosVentas(ByVal cod_usuario As String, ByVal fecha_inicio As String, ByVal bandera As Int16) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_ingreso_ventas"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .AddWithValue("@flag", bandera)
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read
                    ' se limpian los parametros
                    cmd.Parameters.Clear()
                    ' retorna el monto
                    Return Double.Parse(lector(0).ToString())
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()

        Return 0
    End Function

    ' metodo que se encarga de obtener el monto que corresponde al total de las ventas sea en efectivo o en tarjeta para el cajero a consultar
    ' El monto es de lñas ventas brutas (Subtotal de cada factura)
    Public Function obtenerIngresosVentasBrutas(ByVal cod_usuario As String, ByVal fecha_inicio As String, ByVal bandera As Int16) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()
        'Para el efectivo
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_ingreso_ventas_burtas"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .AddWithValue("@flag", bandera)
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read
                    ' se limpian los parametros
                    cmd.Parameters.Clear()
                    ' retorna el monto
                    Return Double.Parse(lector(0).ToString())
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try
        ' limpia los parametros del comando
        cmd.Parameters.Clear()
        'cierra la conexion
        conexionDB.cerrarConexion()

        Return 0
    End Function

    ' metodo que se encarga de obtener el monto total que corresponde a las introducciones o salidas segun el movimiento a realizar
    ' Movimiento: "0" Introducciones, "1" Salidas
    Public Function obtenerMontoIntroduccionesSalidas(ByVal cod_usuario As String, ByVal fecha_inicio As String, ByVal movimiento As Integer) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_introducciones_salidas"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        Dim fecha_actual As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", fecha_actual)
            .AddWithValue("@movimiento", movimiento)
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read
                    ' se limpian los parametros
                    cmd.Parameters.Clear()
                    ' retorna el monto
                    Return Double.Parse(lector(0).ToString())
                End While
            End If
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()

            Return 0
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try
    End Function

    Public Function obtenerMontoAbonos(ByVal cod_usuario As String, ByVal fecha_inicio As String) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_abonos"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        Dim fecha_actual As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", fecha_actual)
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read
                    ' se limpian los parametros
                    cmd.Parameters.Clear()
                    ' retorna el monto
                    Return Double.Parse(lector(0).ToString())
                End While
            End If
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()

            Return 0
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try
    End Function
    Public Function obtenerMontoVales(ByVal cod_usuario As String, ByVal fecha_inicio As String) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_vales"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        Dim fecha_actual As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", fecha_actual)
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read
                    ' se limpian los parametros
                    cmd.Parameters.Clear()
                    ' retorna el monto
                    Return Double.Parse(lector(0).ToString())
                End While
            End If
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()

            Return 0
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try
    End Function

    ' metodo que se encarga de obtener el monto que corresponde al fondo inicial para el cajero a consultar
    Public Function obtenerMontoFondoInicial(ByVal cod_usuario_recibe As String, ByVal fecha_inicio As String) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        'variable en la que se lamacenará el valor del monto
        Dim monto_fondo_inicial As Decimal = 0

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_fondo_inicial"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario_recibe", cod_usuario_recibe)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
            .AddWithValue("@monto_total", monto_fondo_inicial).Direction = ParameterDirection.Output
        End With

        Try
            ' ejecuta la consulta a la base
            cmd.ExecuteScalar()
            ' se obtiene el valor que retorna el procedimiento
            'monto_fondo_inicial = (cmd.Parameters("@monto_total").Value)
            monto_fondo_inicial = ConversionDatosDB.VerificarNulo((cmd.Parameters("@monto_total").Value), 0)

            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()

            Return monto_fondo_inicial
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try

    End Function

    ' metodo que se encarga de obtener el monto que corresponde al fondo final para el cajero a consultar
    Public Function obtenerMontoFondoFinal(ByVal cod_usuario_recibe As String, ByVal fecha_inicio As String) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        'variable en la que se lamacenará el valor del monto
        Dim monto_fondo_final As Decimal = 0

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_fondo_final"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario_recibe", cod_usuario_recibe)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")))
            .AddWithValue("@monto_total", monto_fondo_final).Direction = ParameterDirection.Output
        End With

        Try
            ' ejecuta la consulta a la base
            cmd.ExecuteScalar()
            ' se obtiene el valor que retorna el procedimiento
            'monto_fondo_final = (cmd.Parameters("@monto_total").Value)
            monto_fondo_final = ConversionDatosDB.VerificarNulo((cmd.Parameters("@monto_total").Value), 0)

            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()

            Return monto_fondo_final
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try

    End Function

    ' metodo que se encarga de obtener el monto que corresponde al fondo final para el cajero a consultar
    Public Function obtenerMontoArqueoCaja(ByVal cod_usuario_recibe As String, ByVal fecha_inicio As String) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        'variable en la que se lamacenará el valor del monto
        Dim monto_fondo_final As Decimal = 0

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_arqueo_caja"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario_recibe", cod_usuario_recibe)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .AddWithValue("@monto_total", monto_fondo_final).Direction = ParameterDirection.Output
        End With

        Try
            ' ejecuta la consulta a la base
            cmd.ExecuteScalar()
            ' se obtiene el valor que retorna el procedimiento
            'monto_fondo_final = (cmd.Parameters("@monto_total").Value)
            monto_fondo_final = ConversionDatosDB.VerificarNulo((cmd.Parameters("@monto_total").Value), 0)

            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()

            Return monto_fondo_final
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try

    End Function

    ' metodo que se encarga de obtener el monto total que corresponde a los pagos de la factura realizados por el usuario
    Public Function obtenerMontoPagoFacturas(ByVal cod_usuario As String, ByVal fecha_inicio As String) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        'variable en la que se lamacenará el valor del monto
        Dim monto_total As Decimal = 0

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_pago_facturas"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
            .AddWithValue("@monto_total", monto_total).Direction = ParameterDirection.Output
        End With

        Try
            ' ejecuta la consulta a la base
            cmd.ExecuteScalar()
            ' se obtiene el valor que retorna el procedimiento
            'monto_total = (cmd.Parameters("@monto_total").Value)
            monto_total = ConversionDatosDB.VerificarNulo((cmd.Parameters("@monto_total").Value), 0)

            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()

            Return monto_total
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try

    End Function

    ' metodo que se encarga de obtener el monto total que corresponde a los impuestos por servicios 
    Public Function obtenerMontoImpuestoServicios(ByVal cod_usuario As String, ByVal fecha_inicio As String, tipo As Int16) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_impuesto_servicios"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
            .AddWithValue("@flag", tipo)
            '.AddWithValue("@monto_total", monto_total).Direction = ParameterDirection.Output
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read
                    ' se limpian los parametros
                    cmd.Parameters.Clear()
                    ' retorna el monto
                    Return Double.Parse(lector(0).ToString())
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try
        cmd.Parameters.Clear()
        'cierra la conexion
        conexionDB.cerrarConexion()
        Return 0
    End Function

    ' metodo que se encarga de obtener el monto total que corresponde a los impuestos de ventas
    Public Function obtenerMontoImpuestoVentas(ByVal cod_usuario As String, ByVal fecha_inicio As String, ByVal bandera As Int16) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_impuesto_ventas"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .AddWithValue("@flag", bandera)
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read
                    ' se limpian los parametros
                    cmd.Parameters.Clear()
                    ' retorna el monto
                    Return Double.Parse(lector(0).ToString())
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try
        cmd.Parameters.Clear()
        'cierra la conexion
        conexionDB.cerrarConexion()
        Return 0
    End Function

    ' metodo que se encarga de obtener el monto total que corresponde a los servicios por express
    Public Function obtenerMontoServiciosExpress(ByVal cod_usuario As String, ByVal fecha_inicio As String) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_expres"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            '.AddWithValue("@monto_total", monto_total).Direction = ParameterDirection.Output
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read
                    ' se limpian los parametros
                    cmd.Parameters.Clear()
                    ' retorna el monto

                    Return Double.Parse(lector(0).ToString())
                End While

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try
        cmd.Parameters.Clear()
        'cierra la conexion
        conexionDB.cerrarConexion()
        Return 0
    End Function

    ' metodo que se encarga de obtener el monto total que corresponde a los servicios por express cuando se pagaron ene efectivo
    Public Function obtenerMontoServiciosExpressEfectivo(ByVal cod_usuario As String, ByVal fecha_inicio As String) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_expres_efectivo"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read
                    ' se limpian los parametros
                    cmd.Parameters.Clear()
                    ' retorna el monto

                    Return Double.Parse(lector(0).ToString())
                End While

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try
        cmd.Parameters.Clear()
        'cierra la conexion
        conexionDB.cerrarConexion()
        Return 0
    End Function

    '********************************************************
    '******************** REPORTE DATOS ********************
    '********************************************************

    ' metodo para consultar los pagos realizados en una rango de fechas (historico de pagos)
    Public Function obtenerHistoricoPagoFacturas(ByVal cod_usuario As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime) As List(Of ReportePagoFactura)
        ' lista que obtendrá todos los pagos de las facturas
        Dim lista_pagos As List(Of ReportePagoFactura) = New List(Of ReportePagoFactura)
        ' objeto que obtendrá a los pagos de las facturas
        Dim factura_pago As New FacturaPago
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Dim pago_facturas As ReportePagoFactura


        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "FAC.sp_reporte_pago_facturas"
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se agregan los parametros
                With cmd.Parameters
                    .AddWithValue("@cod_usuario", cod_usuario)
                    .AddWithValue("@fecha_inicio", fecha_inicio)
                    .AddWithValue("@fecha_fin", fecha_fin)
                End With

                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    pago_facturas = New ReportePagoFactura
                    factura_pago = New FacturaPago
                    ' se asigna el codigo del proveedor y el nombre
                    pago_facturas.Nombre_cajeroSG = lector(0)
                    pago_facturas.Nombre_proveedorSG = lector(1)
                    factura_pago.Fecha_pagoSG = lector(2)
                    factura_pago.Numero_facturaSG = lector(3)
                    factura_pago.Monto_facturaSG = lector(4)
                    factura_pago.TipoSG = lector(5)
                    pago_facturas.FacturaSG = factura_pago
                    'pago_facturas.Fecha_facturaSG = lector(5)
                    'pago_facturas.Numero_facturaSG = lector(6)
                    'pago_facturas.Monto_facturaSG = lector(7)
                    'pago_facturas.ElementoSG = lector(8)
                    'pago_facturas.ObservacionesSG = lector(9)
                    'pago_facturas.Nombre_ProveedorSG = lector(10)
                    ' se agrega a la lista de proveedores
                    lista_pagos.Add(pago_facturas)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        ' limpia los parametros del comando
        cmd.Parameters.Clear()
        'cierra la conexion
        conexionDB.cerrarConexion()

        Return lista_pagos

    End Function

    ' metodo que obtiene el detalle de las introducciones o salidas realizadas por un usuario durante su servicio
    Public Sub obtenerReporteIntroduccionesSalidas(ByVal cod_usuario As String, ByVal fecha As DateTime, ByVal tipo_evento As Int16)
        ' variable que tndra cada linea del reporte
        Dim lista_introducciones As New List(Of ReporteIntroSale)

        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_reporte_intro_sale"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@cod_usuario_recibe", cod_usuario)
                .AddWithValue("@fecha_inicio", fecha)
                .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .AddWithValue("@movimiento", tipo_evento)
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\intro_sale.xml", "intro_sale", cmd)

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()
        ' retorna la lista
    End Sub

    Public Sub obtenerReporteAbonos(ByVal cod_usuario As String, ByVal fecha As DateTime)
        ' variable que tndra cada linea del reporte
        Dim lista_introducciones As New List(Of ReporteIntroSale)

        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_reporte_abonos"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@cod_usuario_recibe", cod_usuario)
                .AddWithValue("@fecha_inicio", fecha)
                .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\reporte_abonos.xml", "reporte_abonos", cmd)

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()
        ' retorna la lista
    End Sub

    Public Sub obtenerReporteVales(ByVal cod_usuario As String, ByVal fecha As DateTime)
        ' variable que tndra cada linea del reporte
        Dim lista_introducciones As New List(Of ReporteIntroSale)

        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_reporte_vales"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@cod_usuario_recibe", cod_usuario)
                .AddWithValue("@fecha_inicio", fecha)
                .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\reporte_vales.xml", "reporte_vales", cmd)

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()
        ' retorna la lista
    End Sub


    ' metodo que obtiene el detalle del fondo inicial o fondo final realizado por un usuario durante su servicio
    Public Sub obtenerReporteFondos(ByVal cod_usuario As String, ByVal fecha As DateTime, ByVal tipo_evento As Int16)
        ' variable que tndra cada linea del reporte
        Dim lista_fondos As New List(Of ReporteFondos)

        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_reporte_fondos"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@cod_usuario_recibe", cod_usuario)
                .AddWithValue("@fecha_inicio", fecha)
                .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .AddWithValue("@movimiento", tipo_evento)
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\fondos.xml", "fondos", cmd)

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()
    End Sub

    ' metodo que obtiene el detalle de las ventas por tipo de pago segun el tipo_venta
    ' 0 para pagos en efectivo y 1 para pagos con tarjeta
    Public Sub obtenerReporteVentas(ByVal cod_usuario As String, ByVal cod_empleado As String, ByVal fecha As String, ByVal tipo_venta As Int16)
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_reporte_ventas"
            'cmd.CommandText = "sp_consulta_ingreso_ventas_burtas"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@cod_usuario", cod_usuario)
                .AddWithValue("@cod_empleado", cod_empleado)
                .AddWithValue("@fecha_inicio", fecha)
                .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .AddWithValue("@flag", tipo_venta)
            End With

            Using adaptador As New SqlDataAdapter(cmd)
                tablas = New DataSet("venta")
                ' llena el data set
                adaptador.Fill(tablas, "venta")

                ' crea el xml
                My.Computer.FileSystem.CreateDirectory("C:\XML")
                tablas.WriteXml("C:\XML\venta.xml", XmlWriteMode.WriteSchema)

            End Using
        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()
    End Sub

    ' metodo que obtiene el detalle de las ventas por express
    Public Sub obtenerReporteExpres(ByVal cod_usuario As String, ByVal fecha As String, tipo As Int16)

        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_reporte_express"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@cod_usuario", cod_usuario)
                .AddWithValue("@fecha_inicio", fecha)
                .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .AddWithValue("@flag", tipo)
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\ventasExpress.xml", "ventasExpress", cmd)

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
            Return
        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()
    End Sub

    ' metodo que obtiene el detalle de lo ganado por los meseros con los impuestos de servicio
    Public Sub obtenerReporteImpServicio(ByVal cod_usuario As String, ByVal fecha As String, tipo As Int16)
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_reporte_impuesto_servicios"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@cod_usuario", cod_usuario)
                .AddWithValue("@fecha_inicio", fecha)
                .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .AddWithValue("@flag", tipo)
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\servicio.xml", "servicio", cmd)

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
            Return
        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()
    End Sub

    ' metodo que obtiene el detalle del ingreso por impuestos de ventas
    Public Function reporteImpuestoVentasCajero(ByVal cod_usuario As String, ByVal fecha_inicio As String, ByVal fecha_fin As String, tipo As Int16) As DataTable
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_reporte_impuesto_ventas"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@fecha_inicio", fecha_inicio)
                .AddWithValue("@fecha_fin", fecha_fin)
                .AddWithValue("@cod_usuario", cod_usuario)
                .AddWithValue("@flag", tipo)
            End With

            If cmd.ExecuteNonQuery Then
                '' datatable que guardara todas las denominaciones de coloones para mostrarlas en la ventana
                Using nuevatabla As New DataTable
                    Using adaptador As New SqlDataAdapter(cmd)
                        tablas = New DataSet("impuestoventas")

                        ' se llena la tabla con todas la denominaciones de colones de las monedas
                        adaptador.Fill(nuevatabla)
                        ' llena el data set
                        adaptador.Fill(tablas, "impuestoventas")

                        ' crea el xml
                        My.Computer.FileSystem.CreateDirectory("C:\XML")
                        tablas.WriteXml("C:\XML\impuestoventas.xml", XmlWriteMode.WriteSchema)
                        ' limpia los pararmetros
                        cmd.Parameters.Clear()
                        ' cierra la conexion
                        conexionDB.cerrarConexion()
                        ' retorna las denominaciones
                        Return nuevatabla
                    End Using
                End Using
            End If

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()

        Return Nothing
    End Function

    '********************************************************
    '************ REPORTE DATOS ADMINISTRATIVOS *************
    '********************************************************

    ' metodo que obtiene el reporte que corresponde a las ventas realizadas por cajeros en un rango de fechas
    Public Function reporteVentasRangoFechas(fecha_inicio As String, fecha_fin As String, usuario As String, tipo As Int16) As DataTable
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_reporte_ventas_x_dia"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@cod_usuario", usuario)
                .AddWithValue("@fecha_inicio", fecha_inicio)
                .AddWithValue("@fecha_fin", fecha_fin)
                .AddWithValue("@flag", tipo)
            End With

            If cmd.ExecuteNonQuery Then
                '' datatable que guardara todas las denominaciones de coloones para mostrarlas en la ventana
                Using nuevatabla As New DataTable
                    Using adaptador As New SqlDataAdapter(cmd)
                        tablas = New DataSet("tablas1")

                        '' se llena la tabla con todas la denominaciones de colones de las monedas
                        adaptador.Fill(nuevatabla)
                        ' llena el data set
                        adaptador.Fill(tablas, "ventas")
                        ' crea el xml
                        My.Computer.FileSystem.CreateDirectory("C:\XML")
                        tablas.WriteXml("C:\XML\ventas.xml", XmlWriteMode.WriteSchema)
                        ' limpia los pararmetros
                        cmd.Parameters.Clear()
                        ' cierra la conexion
                        conexionDB.cerrarConexion()
                        ' retorna las denominaciones
                        Return nuevatabla
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()

        Return Nothing
    End Function

    ' metodo que obtiene el detalle del ingreso por impuestos de ventas
    Public Function reporteImpuestoVentas(ByVal fecha_inicio As String, ByVal fecha_fin As String, tipo As Int16) As DataTable
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_reporte_impuesto_ventas"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@fecha_inicio", fecha_inicio)
                .AddWithValue("@fecha_fin", fecha_fin)
                .AddWithValue("@flag", tipo)
            End With

            If cmd.ExecuteNonQuery Then
                '' datatable que guardara todas las denominaciones de coloones para mostrarlas en la ventana
                Using nuevatabla As New DataTable
                    Using adaptador As New SqlDataAdapter(cmd)
                        tablas = New DataSet("impuestoventas")

                        ' se llena la tabla con todas la denominaciones de colones de las monedas
                        adaptador.Fill(nuevatabla)
                        ' llena el data set
                        adaptador.Fill(tablas, "impuestoventas")

                        ' crea el xml
                        My.Computer.FileSystem.CreateDirectory("C:\XML")
                        tablas.WriteXml("C:\XML\impuestoventas.xml", XmlWriteMode.WriteSchema)
                        ' limpia los pararmetros
                        cmd.Parameters.Clear()
                        ' cierra la conexion
                        conexionDB.cerrarConexion()
                        ' retorna las denominaciones
                        Return nuevatabla
                    End Using
                End Using
            End If

        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()

        Return Nothing
    End Function

    ' metodo para crear el archivo XML desde donde consumiran los crystal reports
    Public Sub crearXML(tablas As DataSet, url As String, nombre As String, cmd As SqlCommand)
        Using adaptador As New SqlDataAdapter(cmd)
            ' se asigna el nombre al dataset
            tablas = New DataSet(nombre)
            ' llena el data set
            adaptador.Fill(tablas, nombre)
            ' se crea el archivo XML en la tuta especificada
            My.Computer.FileSystem.CreateDirectory("C:\XML")
            tablas.WriteXml(url, XmlWriteMode.WriteSchema)
        End Using
    End Sub


    Public Function obtenerListaPagoFacturas(ByVal cod_usuario As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime) As List(Of ReportePagoFactura)
        ' lista que obtendrá todos los pagos de las facturas
        Dim lista_pagos As List(Of ReportePagoFactura) = New List(Of ReportePagoFactura)
        ' objeto que obtendrá a los pagos de las facturas
        Dim factura_pago As New FacturaPago
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Dim pago_facturas As ReportePagoFactura

        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT CONCAT(em.nombre, ' ', em.apellido1) AS Cajero, 
		                                pf.cod_usuario as Usuario,
		                                pr.nombre AS Proveedor, 
		                                pr.cod_proveedor AS CodProveedor,
		                                CONCAT(DATEPART(year,pf.fecha_pago), '-', 
			                                right(CONCAT('0',DATEPART(month, pf.fecha_pago)),2), '-', 
			                                right(CONCAT('0',DATEPART(day, pf.fecha_pago)),2), ' ', 
			                                right(CONCAT('0',DATEPART(HOUR, pf.fecha_pago)),2), ':',
			                                right(CONCAT('0',DATEPART(minute, pf.fecha_pago)),2), ':', 
			                                right(CONCAT('0',DATEPART(second, pf.fecha_pago)),2)) AS FechaPago,
		                                pf.num_factura, 
		                                pf.monto_factura, 
		                                pf.tipo 
                                FROM FAC.pago_facturas As pf
	                                INNER JOIN RRHH.empleados AS em ON em.cod_usuario = pf.cod_usuario
	                                INNER JOIN PRO.proveedores AS pr ON pr.cod_proveedor = pf.cod_proveedor
                                WHERE pf.cod_usuario = @cod_usuario AND 
                                CONCAT(DATEPART(YEAR,pf.fecha_pago), '-', RIGHT(CONCAT('0',DATEPART(MONTH, pf.fecha_pago)),2), '-', RIGHT(CONCAT('0',DATEPART(DAY, pf.fecha_pago)),2), ' ', RIGHT(CONCAT('0',DATEPART(HOUR, pf.fecha_pago)),2), ':',RIGHT(CONCAT('0',DATEPART(MINUTE, pf.fecha_pago)),2), ':', RIGHT(CONCAT('0',DATEPART(SECOND, pf.fecha_pago)),2)) 
                                BETWEEN CONCAT(DATEPART(YEAR, @fecha_inicio), '-', RIGHT(CONCAT('0',DATEPART(MONTH, @fecha_inicio)),2), '-', RIGHT(CONCAT('0',DATEPART(DAY, @fecha_inicio)),2), ' ', RIGHT(CONCAT('0',DATEPART(HOUR, @fecha_inicio)),2), ':',RIGHT(CONCAT('0',DATEPART(MINUTE, @fecha_inicio)),2), ':', RIGHT(CONCAT('0',DATEPART(SECOND, @fecha_inicio)),2))  AND 
                                CONCAT(DATEPART(YEAR, @fecha_fin), '-', RIGHT(CONCAT('0',DATEPART(MONTH, @fecha_fin)),2), '-', RIGHT(CONCAT('0',DATEPART(DAY, @fecha_fin)),2), ' ', RIGHT(CONCAT('0',DATEPART(HOUR, @fecha_fin)),2), ':',RIGHT(CONCAT('0',DATEPART(MINUTE, @fecha_fin)),2), ':', RIGHT(CONCAT('0',DATEPART(SECOND, @fecha_fin)),2))	
                                "
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se agregan los parametros
                With cmd.Parameters
                    .AddWithValue("@cod_usuario", cod_usuario)
                    .AddWithValue("@fecha_inicio", fecha_inicio)
                    .AddWithValue("@fecha_fin", fecha_fin)
                End With

                ' se ejecuta la consulta 
                lector = cmd.ExecuteReader
                ' se recorre hasta obtener todos los registros
                While lector.Read
                    'instancia del objeto
                    pago_facturas = New ReportePagoFactura
                    factura_pago = New FacturaPago
                    ' se asigna el codigo del proveedor y el nombre

                    pago_facturas.Nombre_cajeroSG = lector("Cajero")
                    pago_facturas.Nombre_proveedorSG = lector("Proveedor")
                    factura_pago.Fecha_pagoSG = lector("FechaPago")
                    factura_pago.Cod_UsuarioSG = lector("Usuario")
                    factura_pago.Cod_proveedorSG = lector("CodProveedor")
                    factura_pago.Numero_facturaSG = lector("num_factura")
                    factura_pago.Monto_facturaSG = lector("monto_factura")
                    factura_pago.TipoSG = lector("tipo")
                    pago_facturas.FacturaSG = factura_pago
                    'se agrega a la lista de proveedores
                    lista_pagos.Add(pago_facturas)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        ' limpia los parametros del comando
        cmd.Parameters.Clear()
        'cierra la conexion
        conexionDB.cerrarConexion()

        Return lista_pagos

    End Function

    Public Sub eliminarPagoFacturas(ByVal llaves As String())
        'poscisiones que trae el arreglo
        'llaves(0) = codUsuario
        'llaves(1) = codProveedor
        'llaves(2) = fechaPago
        'llaves(3) = numeroFactura
        Try
            Using (conexion)
                ' se llama al metodo que abre la conexion con la base de datos
                conexion = conexionDB.abrirConexion()
                ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
                cmd.CommandType = CommandType.Text

                'Dim fecha As Date = DateTime.ParseExact(llaves(2), "yyyy/mm/dd h:m:s tt", Nothing)

                cmd.CommandText = "delete from fac.pago_facturas 
                                    where cod_usuario = '" & llaves(0) & "'
		                                and cod_proveedor = " & llaves(1) & "
		                                and fecha_pago = '" & llaves(2) & "'
		                                and num_factura = " & llaves(3) & ""
                ' se le asigna la conexion al sqlCommand
                cmd.Connection = conexion
                ' se ejecuta la consulta 
                cmd.ExecuteReader()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' limpia los parametros del comando
        cmd.Parameters.Clear()
        'cierra la conexion
        conexionDB.cerrarConexion()

    End Sub

    'Este metodo devuelve los totales de UBER eats
    Public Sub obtenerReporteUberEats(ByVal cod_usuario As String, ByVal fecha As String)

        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FAC.sp_consulta_reporte_Uber_Eats"
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion
            ' se agregan los parametros
            With cmd.Parameters
                .AddWithValue("@cod_usuario", cod_usuario)
                .AddWithValue("@fecha_inicio", fecha)
                .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            End With

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\uberEats.xml", "uberEats", cmd)


        Catch ex As Exception
            ' limpia los pararmetros
            cmd.Parameters.Clear()
            ' cierra la conexion
            conexionDB.cerrarConexion()
            MsgBox(ex.Message)
            Return
        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()
    End Sub


    ' metodo que se encarga de obtener el monto total que corresponde a los servicios por UBER EATS
    Public Function obtenerMontoServiciosUberEats(ByVal cod_usuario As String, ByVal fecha_inicio As String) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_UberEats"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            '.AddWithValue("@monto_total", monto_total).Direction = ParameterDirection.Output
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read
                    ' se limpian los parametros
                    cmd.Parameters.Clear()
                    ' retorna el monto

                    Return Double.Parse(lector(0).ToString())
                End While

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try
        cmd.Parameters.Clear()
        'cierra la conexion
        conexionDB.cerrarConexion()
        Return 0
    End Function


    ' metodo que se encarga de obtener el monto que corresponde al total de las ventas sea en efectivo o en tarjeta para el cajero a consultar
    ' El monto es de lñas ventas brutas (Subtotal de cada factura)
    Public Function obtenerIngresosVentasSoloEfectivo(ByVal cod_usuario As String, ByVal fecha_inicio As String, ByVal bandera As Int16) As Double
        'Ventas X Sistema - Tarjetas
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()
        'Para el efectivo
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        'cmd.CommandText = "FAC.sp_consulta_ingreso_ventas_burtas2"
        cmd.CommandText = "FAC.sp_consulta_reporte_ventas"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .AddWithValue("@flag", bandera)
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read
                    ' se limpian los parametros
                    cmd.Parameters.Clear()
                    ' retorna el monto
                    Return Double.Parse(lector(0).ToString())
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try
        ' limpia los parametros del comando
        cmd.Parameters.Clear()
        'cierra la conexion
        conexionDB.cerrarConexion()

        Return 0
    End Function


    Public Function obtenerVentasPorDatafono(ByVal cod_usuario As String, ByVal fecha_inicio As String, ByVal bandera As Int16) As Double
        ' se llama al metodo que abre la conexion con la base de datos
        conexion = conexionDB.abrirConexion()

        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_Ventas_Por_Datafono"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@cod_usuario", cod_usuario)
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .AddWithValue("@flag", bandera)
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read
                    ' se limpian los parametros
                    cmd.Parameters.Clear()

                    ' retorna el monto
                    Return Double.Parse(lector(0).ToString())
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()
            Return 0
        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()

        Return 0
    End Function

    Public Function consultaFlujoCajaDetalle(factura As Facturas, parametro As ParameterValues, pvisualizar As ParameterDiscreteValue) As Facturas
        Dim fecha_inicio As String = InicioSesion.session.Hora_primer_ingresoSG
        conexion = conexionDB.abrirConexion()

        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "FAC.sp_consulta_Flujo_de_Caja"
        ' se le asigna la conexion al sqlCommand
        cmd.Connection = conexion

        ' se asignan los parametros a enviar en el procedimiento almacenado
        With cmd.Parameters
            .AddWithValue("@fecha_inicio", fecha_inicio)
            .AddWithValue("@fecha_fin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        End With

        Try
            ' ejecuta la consulta a la base
            lector = cmd.ExecuteReader
            ' se obtiene el valor que retorna el procedimiento
            If lector.HasRows Then
                ' se recorre hasta obtener todos los registros necesarios
                While lector.Read


                    pvisualizar.Value = lector("subtotal").ToString(0)


                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@valor5").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector(1).ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@valor10").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector(2).ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@valor25").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotal50").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@valor50").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotal100").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@valor100").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotal500").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@valor500").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotal1000").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@valor1000").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotal2000").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@valor2000").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotal5000").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@valor5000").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotal10000").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@valor10000").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotal20000").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@valor20000").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotal50000").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@valor50000").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotalCi5").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@cierre5").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotalCi10").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@cierre10").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotalCi25").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@cierre25").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotalCi50").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@cierre50").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotalCi100").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@cierre100").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotalCi500").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@cierre500").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotalCi1000").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@cierre1000").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotalCi2000").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@cierre2000").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotalCi5000").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@cierre5000").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotalCi10000").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@cierre10000").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotalCi20000").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@cierre20000").ApplyCurrentValues(parametro)

                    pvisualizar.Value = lector("subtotalCi50000").ToString("C")
                    parametro.Add(pvisualizar)
                    factura.DataDefinition.ParameterFields("@cierre50000").ApplyCurrentValues(parametro)




                    'pvisualizar.Value = lector("subtotal_cierre")
                    'parametro.Add(pvisualizar)
                    'factura.DataDefinition.ParameterFields("@datafono_Salon").ApplyCurrentValues(parametro)


                End While
                Return factura
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ' limpia los parametros del comando
            cmd.Parameters.Clear()
            'cierra la conexion
            conexionDB.cerrarConexion()

        End Try
        ' limpia los pararmetros
        cmd.Parameters.Clear()
        ' cierra la conexion
        conexionDB.cerrarConexion()
        Return factura
    End Function






End Class