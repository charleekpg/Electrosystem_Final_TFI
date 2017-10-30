Public Class BE_DibujoTecnico


    Private _ambientes As List(Of Be_Ambiente)
    Public Property ambiente() As List(Of Be_Ambiente)
        Get
            Return _ambientes
        End Get
        Set(ByVal value As List(Of Be_Ambiente))
            _ambientes = value
        End Set
    End Property

    Private _cliente As BE_CLIENTE
    Public Property cliente() As BE_CLIENTE
        Get
            Return _cliente
        End Get
        Set(ByVal value As BE_CLIENTE)
            _cliente = value
        End Set
    End Property

    Private _cumple_ambientes As Integer
    Public Property cumple_ambientes() As Integer
        Get
            Return _cumple_ambientes
        End Get
        Set(ByVal value As Integer)
            _cumple_ambientes = value
        End Set
    End Property
    Private _cumple_cantidadbocas As Boolean
    Public Property cumple_cantidadbocas() As Integer
        Get
            Return _cumple_cantidadbocas
        End Get
        Set(ByVal value As Integer)
            _cumple_cantidadbocas = value
        End Set
    End Property
    Private _cumple_cantidadcircuito As Boolean
    Public Property cumple_cantidadcircuito() As Integer
        Get
            Return _cumple_cantidadcircuito
        End Get
        Set(ByVal value As Integer)
            _cumple_cantidadcircuito = value
        End Set
    End Property
    Private _cumple_puntosminimos As Boolean
    Public Property cumple_puntosminimos() As Integer
        Get
            Return _cumple_puntosminimos
        End Get
        Set(ByVal value As Integer)
            _cumple_puntosminimos = value
        End Set
    End Property
    Private _cumple_tipodecircuito As Boolean
    Public Property cumple_tipodecircuito() As Integer
        Get
            Return _cumple_tipodecircuito
        End Get
        Set(ByVal value As Integer)
            _cumple_tipodecircuito = value
        End Set
    End Property
    Private _fecha As Date
    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property
    Private _grado_electrificacion As String
    Public Property grado_electrificacion() As String
        Get
            Return _grado_electrificacion
        End Get
        Set(ByVal value As String)
            _grado_electrificacion = value
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
    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Private _plano_tecnico As BE_PlanoTecnico
    Public Property plano_tecnico() As BE_PlanoTecnico
        Get
            Return _plano_tecnico
        End Get
        Set(ByVal value As BE_PlanoTecnico)
            _plano_tecnico = value
        End Set
    End Property

End Class 