Public Class be_localidad


    Private _id As Integer
    Private _latitud As String
    Private _localidad As String
    Private _longitud As String

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
			End Set
    End Property

    Public Property latitud() As String
        Get
            Return _latitud
        End Get
        Set(ByVal Value As String)
            _latitud = Value
			End Set
    End Property

    Public Property localidad() As String
        Get
            Return _localidad
        End Get
        Set(ByVal Value As String)
            _localidad = Value
			End Set
    End Property

    Public Property longitud() As String
        Get
            Return _longitud
        End Get
        Set(ByVal Value As String)
            _longitud = Value
			End Set
    End Property


End Class 