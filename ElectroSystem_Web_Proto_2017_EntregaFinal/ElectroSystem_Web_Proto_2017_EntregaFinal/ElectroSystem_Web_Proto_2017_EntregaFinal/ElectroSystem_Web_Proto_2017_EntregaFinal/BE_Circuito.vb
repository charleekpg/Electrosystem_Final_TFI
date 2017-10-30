Public Class BE_Circuito


    Private _cantidad_bocas As Integer
    Private _circuito_correcto_segun_ambiente As Boolean = True
    Private _descripcion As String
    Private _id As Integer
    Private _sigla As String

    Public Property tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property

    Private _tipo As String


    Public Property cantidad_bocas() As Integer
        Get
            Return _cantidad_bocas
        End Get
        Set(ByVal value As Integer)
            _cantidad_bocas = value
        End Set
    End Property

    Public Property circuito_correcto_segun_ambiente() As Boolean
        Get
            Return _circuito_correcto_segun_ambiente
        End Get
        Set(ByVal value As Boolean)
            _circuito_correcto_segun_ambiente = value
        End Set
    End Property

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property sigla() As String
        Get
            Return _sigla
        End Get
        Set(ByVal value As String)
            _sigla = value
        End Set
    End Property

    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _cumple_cantidad_bocas_circuito As Boolean = True
    Public Property cumple_cantidad_bocas_circuito() As Boolean
        Get
            Return _cumple_cantidad_bocas_circuito
        End Get
        Set(ByVal value As Boolean)
            _cumple_cantidad_bocas_circuito = value
        End Set
    End Property


End Class 