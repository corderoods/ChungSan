Imports SunChangSystem

Public Class FlujoCaja
    Private valor5, valor10, valor25, valor50, valor100, valor500, valor1000, valor2000, valor5000, valor10000, valor20000, valor50000 As Double
    Private subtotal5, subtotal10, subtotal25, subtotal50, subtotal100, subtotal500, subtotal1000, subtotal2000, subtotal5000, subtotal10000, subtotal20000, subtotal50000 As Double
    Private subtotalCi5, subtotalCi10, subtotalCi25, subtotalCi50, subtotalCi100, subtotalCi500, subtotalCi1000, subtotalCi2000, subtotalCi5000, subtotalCi10000, subtotalCi20000, subtotalCi50000 As Double

    Public Sub New()

    End Sub

    Public Property valor5SG As Double
        Get
            Return valor5

        End Get
        Set(value As Double)
            Me.valor5 = value
        End Set
    End Property

    Public Property valor10SG As Double
        Get
            Return valor10

        End Get
        Set(value As Double)
            Me.valor10 = value
        End Set
    End Property

    Public Property valor25SG As Double
        Get
            Return valor25
        End Get
        Set(value As Double)
            Me.valor25 = value
        End Set
    End Property

    Public Property valor50SG As Double
        Get
            Return valor50
        End Get
        Set(value As Double)
            Me.valor50 = value
        End Set
    End Property

    Public Property valor100SG As Double
        Get
            Return valor100
        End Get
        Set(value As Double)
            Me.valor100 = value
        End Set
    End Property

    Public Property valor500SG As Double
        Get
            Return valor500
        End Get
        Set(value As Double)
            Me.valor500 = value
        End Set
    End Property

    Public Property valor1000SG As Double
        Get
            Return valor1000
        End Get
        Set(value As Double)
            Me.valor1000 = value
        End Set
    End Property

    Public Property valor2000SG As Double
        Get
            Return valor2000
        End Get
        Set(value As Double)
            Me.valor2000 = value

        End Set
    End Property

    Public Property valor5000SG As Double
        Get
            Return valor5000
        End Get
        Set(value As Double)
            Me.valor5000 = value
        End Set
    End Property

    Public Property valor10000SG As Double
        Get
            Return valor10000

        End Get
        Set(value As Double)
            Me.valor10000 = value
        End Set
    End Property

    Public Property valor20000SG As Double
        Get
            Return valor20000
        End Get
        Set(value As Double)
            Me.valor20000 = value
        End Set
    End Property

    Public Property valor500000SG As Double
        Get
            Return valor50000
        End Get
        Set(value As Double)
            Me.valor50000 = value
        End Set
    End Property

    Public Property subtotal5SG As Double
        Get
            Return subtotal5

        End Get
        Set(value As Double)
            Me.subtotal5 = value
        End Set
    End Property


    Public Property subtotal10SG As Double
        Get
            Return subtotal10

        End Get
        Set(value As Double)
            Me.subtotal10 = value

        End Set
    End Property

    Public Property subtotal25SG As Double
        Get
            Return subtotal25

        End Get
        Set(value As Double)
            Me.subtotal25 = value
        End Set
    End Property

    Public Property subtotal50SG As Double
        Get
            Return subtotal50
        End Get
        Set(value As Double)
            Me.subtotal50 = value
        End Set
    End Property

    Public Property subtotal100SG As Double
        Get
            Return subtotal100
        End Get
        Set(value As Double)
            Me.subtotal100 = value
        End Set
    End Property

    Public Property subtotal500SG As Double
        Get
            Return subtotal500

        End Get
        Set(value As Double)
            Me.subtotal500 = value
        End Set
    End Property

    Public Property subtotal1000SG As Double
        Get
            Return subtotal1000
        End Get
        Set(value As Double)
            Me.subtotal1000 = value
        End Set
    End Property

    Public Property subtotal2000SG As Double
        Get
            Return subtotal2000
        End Get
        Set(value As Double)
            Me.subtotal2000 = value
        End Set
    End Property

    Public Property subtotal5000SG As Double
        Get
            Return subtotal5000

        End Get
        Set(value As Double)
            Me.subtotal5000 = value
        End Set
    End Property

    Public Property subtotal10000SG As Double
        Get
            Return subtotal10000
        End Get
        Set(value As Double)
            Me.subtotal10000 = value
        End Set
    End Property

    Public Property subtotal20000SG As Double
        Get
            Return subtotal20000
        End Get
        Set(value As Double)
            Me.subtotal20000 = value
        End Set
    End Property

    Public Property subtotal50000SG As Double
        Get
            Return subtotal50000
        End Get
        Set(value As Double)
            Me.subtotal50000 = value
        End Set
    End Property

    Public Property subtotalCi5SG As Double
        Get
            Return subtotalCi5
        End Get
        Set(value As Double)
            Me.subtotalCi5 = value

        End Set
    End Property

    Public Property subtotalCi10SG As Double
        Get
            Return subtotalCi10
        End Get
        Set(value As Double)
            Me.subtotalCi10 = value
        End Set
    End Property

    Public Property subtotalCi25SG As Double
        Get
            Return subtotalCi25
        End Get
        Set(value As Double)
            Me.subtotalCi25 = value
        End Set
    End Property

    Public Property subtotalCi50SG As Double
        Get
            Return subtotalCi50

        End Get
        Set(value As Double)
            Me.subtotalCi50 = value

        End Set
    End Property

    Public Property subtotalCi100SG As Double
        Get
            Return subtotalCi100

        End Get
        Set(value As Double)
            Me.subtotalCi100 = value
        End Set
    End Property

    Public Property subtotalCi500SG As Double
        Get
            Return subtotalCi500
        End Get
        Set(value As Double)
            Me.subtotalCi500 = value

        End Set
    End Property

    Public Property subtotalCi1000SG As Double
        Get
            Return subtotalCi1000
        End Get
        Set(value As Double)
            Me.subtotalCi1000 = value
        End Set
    End Property

    Public Property subtotalCi5000SG As Double
        Get
            Return subtotalCi5000
        End Get
        Set(value As Double)
            Me.subtotalCi5000 = value

        End Set
    End Property

    Public Property subtotalCi2000SG As Double
        Get
            Return subtotalCi2000
        End Get
        Set(value As Double)
            Me.subtotalCi2000 = value
        End Set
    End Property

    Public Property subtotalCi10000SG As Double
        Get
            Return subtotalCi10000
        End Get
        Set(value As Double)
            Me.subtotalCi10000 = value
        End Set
    End Property

    Public Property subtotalCi20000SG As Double
        Get
            Return subtotalCi20000
        End Get
        Set(value As Double)
            Me.subtotalCi20000 = value
        End Set
    End Property

    Public Property subtotalCi50000SG As Double
        Get
            Return subtotalCi50000
        End Get
        Set(value As Double)
            Me.subtotalCi50000 = value
        End Set
    End Property

End Class
