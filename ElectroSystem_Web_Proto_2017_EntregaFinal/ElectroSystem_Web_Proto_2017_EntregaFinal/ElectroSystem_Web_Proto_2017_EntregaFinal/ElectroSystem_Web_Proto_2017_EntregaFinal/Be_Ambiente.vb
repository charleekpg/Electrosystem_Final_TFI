Public Class Be_Ambiente

    
    Private _cantidad_puntoselectricos As Integer
    Private _circuitos As List(Of BE_Circuito)
    Private _id As Integer
    Private _m2 As Decimal
    Private _tipo As String


    Public Property cantidad_puntoselectricos() As Integer
        Get
            Return _cantidad_puntoselectricos
        End Get
        Set(ByVal Value As Integer)
            _cantidad_puntoselectricos = Value
			End Set
    End Property

    Public Property circuitos() As List(Of be_circuito)
        Get
            Return _circuitos
        End Get
        Set(ByVal Value As List(Of be_circuito))
            _circuitos = Value
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

    Public Property m2() As Decimal
        Get
            Return _m2
        End Get
        Set(ByVal Value As Decimal)
            _m2 = Value
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
