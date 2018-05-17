Public Class SeleccionarProducto
    Dim subcategoriaDatos As New SubcategoriaDatos
    Dim productoDatos As New ProductoDatos
    Dim btnProducto As Button
    Dim ordenes As Ordenes
    Dim seleccionarsubCategoria As SeleccionarSubcategoria
    Dim subCategoria As Integer

    Public Sub New(ByVal ordenes As Ordenes, ByVal seleccionarsubCategoria As SeleccionarSubcategoria, ByVal subCategoria As Integer, ByVal nombreCat As String)
        Me.subCategoria = subCategoria
        Me.ordenes = ordenes
        Me.seleccionarsubCategoria = seleccionarsubCategoria

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Text = nombreCat
    End Sub


    Private Sub SeleccionarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrarProductos()

    End Sub

    Public Sub mostrarProductos()

        Dim productos As New List(Of Producto)

        'obtiene todos los productos pertenecientes a la categoria seleccionada
        productos = productoDatos.obtenerProductoPorSubcategoria(subCategoria)

        'poscisiones (x,y) de cada boton con producto
        Dim posX = 15
        Dim posY = 15
        'esta variable se usa para saber cuantos botones se han creado y saber si se debe 
        'cambiar de columna para llevar un orden
        Dim cont = 0
        Dim filas = Math.Floor(Math.Sqrt(productos.Count))
        If (productos.Count) / filas > filas + 1 Then
            filas = filas + 1
        End If

        'recorre la lista de productos y crea los botones 
        For i = 0 To productos.Count - 1
            btnProducto = New Button
            btnProducto.Text = productos(i).Nombre_
            btnProducto.Name = productos(i).CodProducto
            If productos(i).Nombre_.Length > 30 Then
                btnProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Else
                btnProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            End If
            btnProducto.Location = New Point(posX, posY)
            btnProducto.Size() = New Size(150, 65)

            btnProducto.Image = Global.SunChangSystem.My.Resources.Resources.btnProducto
            btnProducto.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
            btnProducto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            btnProducto.FlatAppearance.BorderSize = 0
            btnProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(49, Byte), Integer))
            btnProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btnProducto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            btnProducto.Cursor = Cursors.Hand

            'agrega el boton al panel
            Me.Controls.Add(btnProducto)

            'crea el evento para cuando se le da click al boton..
            AddHandler btnProducto.Click, AddressOf btnProducto_Click

            'modifica las poscisiones "x" y "y" para la ubicacion del siguiente boton
            posY = posY + 75
            cont = cont + 1

            If cont = filas Then
                posY = 15
                posX = posX + 170
                cont = 0
            End If
        Next i

        Me.Height = (filas * 75) + 70
        If (productos.Count) / filas = filas Then
            Me.Width = (filas * 170) + 40
        Else
            If Math.Floor(Math.Sqrt(productos.Count)) <> filas Then
                Me.Width = ((filas) * 170) + 40
            Else
                Me.Width = ((filas + 1) * 170) + 40
            End If
        End If


        If (productos.Count) > 50 Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.Location = New Point(((1368 / 2) - (Me.Width / 2)), ((768 / 2) - (Me.Height / 2)))
        End If

    End Sub

    Private Sub btnProducto_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.ordenes.agregarProductoADetalleOrden(CType(sender, Button).Name)
        seleccionarsubCategoria.Close()
        Me.Close()
    End Sub

End Class