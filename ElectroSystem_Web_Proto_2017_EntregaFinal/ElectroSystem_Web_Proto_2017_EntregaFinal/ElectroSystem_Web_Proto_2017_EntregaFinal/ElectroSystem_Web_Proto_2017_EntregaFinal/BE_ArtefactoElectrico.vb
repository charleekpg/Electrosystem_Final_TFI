Public Class BE_ArtefactoElectrico
    Private _cantidad As Integer
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Private _descripcion As String
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _precio As Decimal
    Public Property precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property

    Private _preciocantidad As Decimal
    Public Property preciocantidad() As Decimal
        Get
            Return _preciocantidad
        End Get
        Set(ByVal value As Decimal)
            _preciocantidad = value
        End Set
    End Property

    Private _relacion_bocamercado As Decimal
    Public Property relacion_bocamercado() As Decimal
        Get
            Return _relacion_bocamercado
        End Get
        Set(ByVal value As Decimal)
            _relacion_bocamercado = value
        End Set
    End Property

End Class
