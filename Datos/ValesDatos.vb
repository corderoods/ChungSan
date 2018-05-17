Imports System.Data.SqlClient

Public Class ValesDatos

    Public conexion As SqlConnection
    Public cmd As SqlCommand
    Public conexionDB As ConexionBD
    Public Shared tablas As DataSet

    Public Sub New()
        conexionDB = New ConexionBD
        cmd = New SqlCommand
    End Sub


    Public Function obtenerVales() As DataTable
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' consulta a la base de datos por todos los producto de la base de datos
            cmd = New SqlCommand("select cod_vale as Cod, 
                                        cod_cajero as Cajero, 
		                                CONCAT(DATEPART(year, fecha), '-', 
			                                right(CONCAT('0',DATEPART(month, fecha)),2), '-', 
			                                right(CONCAT('0',DATEPART(day, fecha)),2), ' ', 
			                                right(CONCAT('0',DATEPART(HOUR, fecha)),2), ':',
			                                right(CONCAT('0',DATEPART(minute, fecha)),2), ':', 
			                                right(CONCAT('0',DATEPART(second, fecha)),2)) as Fecha, 
		                                concat('₡', monto) as Cantidad, 
		                                concat(RRHH.empleados.nombre, ' ', RRHH.empleados.apellido1, ' ', RRHH.empleados.apellido2) as Empleado
                                from fac.vales inner join RRHH.empleados on fac.vales.cod_empleado = RRHH.empleados.cod_empleado
                                where cancelado = 'N'")
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.Text
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion

            ' se ejecuta la consulta y se valida que todo este bien
            If cmd.ExecuteNonQuery Then
                '' datatable que guardara todas las categorias o tipos de productos para mostrarlas en la ventana
                Using nuevatabla As New DataTable
                    Using adaptador As New SqlDataAdapter(cmd)
                        '' se llena la tabla con todas las categorias o tipos de productos
                        adaptador.Fill(nuevatabla)
                        '' se cierra la conexion con la base de datos
                        conexionDB.cerrarConexion()
                        ' retorna las categorias
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

    Public Sub ingresarVale(ByVal vale As Vale)
        Dim lector As SqlDataReader
        Try
            Using (conexion)
                ' se abre la conexion
                conexion = conexionDB.abrirConexion()
                ' se declara el tipo de consulta
                cmd.CommandType = CommandType.StoredProcedure
                ' se especifica la consulta
                cmd.CommandText = "FAC.sp_insertar_vale"
                'se asigna la conexion
                With cmd.Parameters
                    .AddWithValue("@cajero", vale.Cajero_)
                    .AddWithValue("@monto", vale.Monto_)
                    .AddWithValue("@empleado", vale.CodEmpleado_)
                End With
                cmd.Connection = conexion
                ' se ejecuta la consulta
                lector = cmd.ExecuteReader
                While lector.Read
                    vale.CodVale_ = lector(0)
                End While
                crearFacturaVale(vale)
                ' se cierra la conexion
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub crearFacturaVale(ByVal vale As Vale)
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            cmd = New SqlCommand("select cod_vale, cod_cajero, CONCAT(DATEPART(year, fecha), '-', right(CONCAT('0',DATEPART(month, fecha)),2), '-', right(CONCAT('0',DATEPART(day, fecha)),2), ' ', right(CONCAT('0',DATEPART(HOUR, fecha)),2), ':', right(CONCAT('0',DATEPART(minute, fecha)),2), ':', right(CONCAT('0',DATEPART(second, fecha)),2)), 
		                                concat('₡', monto) as Cantidad, 
		                                concat(RRHH.empleados.nombre, ' ', RRHH.empleados.apellido1, ' ', RRHH.empleados.apellido2) as Empleado
                                    from fac.vales inner join RRHH.empleados on fac.vales.cod_empleado = RRHH.empleados.cod_empleado
                                    where cod_vale = " & vale.CodVale_)
            cmd.CommandType = CommandType.Text
            cmd.Connection = conexion

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\factura_vale.xml", "factura_vale", cmd)

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

    Public Function obtenerValePorCod(ByVal cod As Integer) As Vale
        ' lista que obtendrá todos los meseros
        ' objeto que obtendrá a los meseros
        Dim vale As New Vale
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                conexion = conexionDB.abrirConexion()
                cmd = New SqlCommand("select cod_vale, cod_cajero, CONCAT(DATEPART(year, fecha), '-', right(CONCAT('0',DATEPART(month, fecha)),2), '-', right(CONCAT('0',DATEPART(day, fecha)),2), ' ', right(CONCAT('0',DATEPART(HOUR, fecha)),2), ':', right(CONCAT('0',DATEPART(minute, fecha)),2), ':', right(CONCAT('0',DATEPART(second, fecha)),2)), monto, cancelado, cod_empleado FROM FAC.vales where cod_vale = " & cod)
                cmd.CommandType = CommandType.Text
                cmd.Connection = conexion
                lector = cmd.ExecuteReader
                While lector.Read
                    vale = New Vale
                    ConversionDatosDB.VerificarNulo(lector(0), -1)
                    vale.CodVale_ = ConversionDatosDB.VerificarNulo(lector(0), -1)
                    vale.Cajero_ = ConversionDatosDB.VerificarNulo(lector(1), "")
                    vale.Fecha_ = ConversionDatosDB.VerificarNulo(lector(2), "")
                    vale.Monto_ = ConversionDatosDB.VerificarNulo(lector(3), 0)
                    vale.Cancelado_ = ConversionDatosDB.VerificarNulo(lector(4), 0)
                    vale.CodEmpleado_ = ConversionDatosDB.VerificarNulo(lector(5), "")
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return vale
    End Function

    Public Function obtenerAbonosPorVale(ByVal codVale As Integer) As DataTable
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            ' consulta a la base de datos por todos los producto de la base de datos
            cmd = New SqlCommand("select cod_cajero AS Cajero,
		                                CONCAT(DATEPART(year, fecha), '-', 
			                                right(CONCAT('0',DATEPART(month, fecha)),2), '-', 
			                                right(CONCAT('0',DATEPART(day, fecha)),2), ' ', 
			                                right(CONCAT('0',DATEPART(HOUR, fecha)),2), ':',
			                                right(CONCAT('0',DATEPART(minute, fecha)),2), ':', 
			                                right(CONCAT('0',DATEPART(second, fecha)),2)) as Fecha,
		                                fac.abonos.monto as Monto
                                from fac.abonos
                                where fac.abonos.cod_vale = " & codVale)
            ' se asigna el tipo de consulta que es. Si es para llamara a procedimineto almacenado o consulta por string
            cmd.CommandType = CommandType.Text
            ' se le asigna la conexion al sqlCommand
            cmd.Connection = conexion

            ' se ejecuta la consulta y se valida que todo este bien
            If cmd.ExecuteNonQuery Then
                '' datatable que guardara todas las categorias o tipos de productos para mostrarlas en la ventana
                Using nuevatabla As New DataTable
                    Using adaptador As New SqlDataAdapter(cmd)
                        '' se llena la tabla con todas las categorias o tipos de productos
                        adaptador.Fill(nuevatabla)
                        '' se cierra la conexion con la base de datos
                        conexionDB.cerrarConexion()
                        ' retorna las categorias
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

    Public Sub ingresarAbono(ByVal abono As Abono)
        Dim lector As SqlDataReader
        Try
            Using (conexion)
                ' se abre la conexion
                conexion = conexionDB.abrirConexion()
                cmd.CommandType = CommandType.StoredProcedure
                ' se especifica la consulta
                cmd.CommandText = "FAC.sp_insertar_abono"
                'se asigna la conexion
                With cmd.Parameters
                    .AddWithValue("@vale", abono.Vale_.CodVale_)
                    .AddWithValue("@cajero", abono.Cajero_)
                    .AddWithValue("@monto", abono.Monto_)
                End With
                cmd.Connection = conexion
                ' se ejecuta la consulta
                lector = cmd.ExecuteReader
                While lector.Read
                    abono.CodAbono_ = lector(0)
                End While
                crearFacturaAbono(abono)
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub crearFacturaAbono(ByVal abono As Abono)
        Try
            ' se llama al metodo que abre la conexion con la base de datos
            conexion = conexionDB.abrirConexion()
            cmd = New SqlCommand("select fac.abonos.cod_abono, fac.abonos.cod_cajero, 
		                                    CONCAT(DATEPART(year, fac.abonos.fecha), '-', right(CONCAT('0',DATEPART(month, fac.abonos.fecha)),2), '-', 
											                                    right(CONCAT('0',DATEPART(day, fac.abonos.fecha)),2), ' ', 
											                                    right(CONCAT('0',DATEPART(HOUR, fac.abonos.fecha)),2), ':', 
											                                    right(CONCAT('0',DATEPART(minute, fac.abonos.fecha)),2), ':', 
											                                    right(CONCAT('0',DATEPART(second, fac.abonos.fecha)),2)) as fecha, 
		                                    concat('₡', fac.abonos.monto) as Cantidad, 
		                                    concat(RRHH.empleados.nombre, ' ', RRHH.empleados.apellido1, ' ', RRHH.empleados.apellido2) as Empleado
                                    from fac.abonos inner join fac.vales on fac.abonos.cod_vale = fac.vales.cod_vale
		                                    inner join RRHH.empleados on fac.vales.cod_empleado = RRHH.empleados.cod_empleado
                                    where cod_abono = " & abono.CodAbono_)
            cmd.CommandType = CommandType.Text
            cmd.Connection = conexion

            ' llama al metodo para crear el xml
            crearXML(tablas, "C:\XML\factura_abono.xml", "factura_abono", cmd)

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

    Public Function obtenerSaldoPorVale(ByVal vale As Vale) As Decimal
        ' donde se almacenan los datos de la consulta
        Dim lector As SqlDataReader

        Try
            Using (conexion)
                conexion = conexionDB.abrirConexion()
                cmd = New SqlCommand("select monto - ISNULL((select sum(monto) from fac.abonos where cod_vale = " & vale.CodVale_ & "), 0)
                                        from fac.vales
                                        where cod_vale = " & vale.CodVale_)
                cmd.CommandType = CommandType.Text
                cmd.Connection = conexion
                lector = cmd.ExecuteReader
                While lector.Read
                    Return lector(0)
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Sub cancelarVale(ByVal vale As Vale)
        Dim lector As SqlDataReader
        Try
            Using (conexion)
                ' se abre la conexion
                conexion = conexionDB.abrirConexion()
                ' se especifica la consulta
                cmd = New SqlCommand("Update FAC.vales set cancelado = 'S' where cod_vale = " & vale.CodVale_)
                ' se declara el tipo de consulta
                cmd.CommandType = CommandType.Text
                'se asigna la conexion
                cmd.Connection = conexion
                ' se ejecuta la consulta
                lector = cmd.ExecuteReader
                ' se cierra la conexion
                conexionDB.cerrarConexion()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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
End Class
