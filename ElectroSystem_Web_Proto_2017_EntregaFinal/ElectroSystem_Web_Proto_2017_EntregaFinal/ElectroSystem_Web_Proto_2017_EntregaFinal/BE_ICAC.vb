Public Class BE_ICAC


    Private _ano As Integer
    Private _cambiofecha As Boolean = False
    Private _ICAC As Decimal
    Private _id As Integer
    Private _mes As Integer

    Public Property ano() As Integer
        Get
            Return _ano
        End Get
        Set(ByVal Value As Integer)
            _ano = Value
			End Set
    End Property

    Public Property cambiofecha() As Boolean
        Get
            Return _cambiofecha
        End Get
        Set(ByVal Value As Boolean)
            _cambiofecha = Value
			End Set
    End Property

    Public Property ICAC() As Decimal
        Get
            Return _ICAC
        End Get
        Set(ByVal Value As Decimal)
            _ICAC = Value
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

    Public Property mes() As Integer
        Get
            Return _mes
        End Get
        Set(ByVal Value As Integer)
            _mes = Value
			End Set
    End Property


End Class 