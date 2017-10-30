Public Class BE_Material_TrabajoconPrec


    Private _cambiodetipo As Boolean = False
    Private _cantidad As Integer
    Private _Descripcion As String
    Private _id As Integer
    Private _Material As Boolean
    Private _Precio As Decimal
    Private _precio_cantidad As Decimal
    Private _Trabajoconprecio As Boolean

    Public Property cambiodetipo() As Boolean
        Get
            Return _cambiodetipo
        End Get
        Set(ByVal Value As Boolean)
            _cambiodetipo = Value
			End Set
    End Property

    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal Value As Integer)
            _cantidad = Value
			End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal Value As String)
            _Descripcion = Value
			End Set
    End Property

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
			End Set
    End Property

    Public Property Material() As Boolean
        Get
            Return _Material
        End Get
        Set(ByVal Value As Boolean)
            _Material = Value
			End Set
    End Property

    Public Property Precio() As Decimal
        Get
            Return _Precio
        End Get
        Set(ByVal Value As Decimal)
            _Precio = Value
			End Set
    End Property

    Public Property precio_cantidad() As Decimal
        Get
            Return _precio_cantidad
        End Get
        Set(ByVal Value As Decimal)
            _precio_cantidad = Value
			End Set
    End Property

    Public Property Trabajoconprecio() As Boolean
        Get
            Return _Trabajoconprecio
        End Get
        Set(ByVal Value As Boolean)
            _Trabajoconprecio = Value
			End Set
    End Property


End Class