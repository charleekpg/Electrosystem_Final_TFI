Public Class BE_BocaMercado


    Private _fecha As Date
    Private _id As Integer
    Private _precio_bocamercado As Decimal
    Private _tipo As String

    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal Value As Date)
            _fecha = Value
			End Set
    End Property

    Private Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
        End Set
		End Property

		Public Property precio_bocamercado() As Decimal
			Get
            Return _precio_bocamercado
        End Get
        Set(ByVal Value As Decimal)
            _precio_bocamercado = Value
			End Set
    End Property

    Public Property tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal Value As String)
            _tipo = Value
			End Set
    End Property


End Class 