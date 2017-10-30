Public Class BE_BocaMercado

    Private _precio_bocamercado As Decimal
    Public Property precio_bocamercado() As Decimal
        Get
            Return _precio_bocamercado
        End Get
        Set(ByVal value As Decimal)
            _precio_bocamercado = value
        End Set
    End Property


End Class 