Public Class BE_Domicilio


    Private _altura As Integer?
    Private _calle As String
    Private _country As Boolean
    Private _departamento As String
    Private _id As Integer
    Private _localidad As be_localidad
    Private _partido As BE_Partido
    Private _piso As Integer?

    Public Property altura() As Integer?
        Get
            Return _altura
        End Get
        Set(ByVal Value As Integer?)
            _altura = Value
			End Set
    End Property

    Public Property calle() As String
        Get
            Return _calle
        End Get
        Set(ByVal Value As String)
            _calle = Value
			End Set
    End Property

    Public Property country() As Boolean
        Get
            Return _country
        End Get
        Set(ByVal Value As Boolean)
            _country = Value
			End Set
    End Property

    Public Property departamento() As String
        Get
            Return _departamento
        End Get
        Set(ByVal Value As String)
            _departamento = Value
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

    Public Property localidad() As be_localidad
        Get
            Return _localidad
        End Get
        Set(ByVal Value As be_localidad)
            _localidad = Value
			End Set
    End Property

    Public Property partido() As BE_Partido
        Get
            Return _partido
        End Get
        Set(ByVal Value As BE_Partido)
            _partido = Value
			End Set
    End Property

    Public Property piso() As Integer?
        Get
            Return _piso
        End Get
        Set(ByVal Value As Integer?)
            _piso = Value
			End Set
    End Property


End Class 