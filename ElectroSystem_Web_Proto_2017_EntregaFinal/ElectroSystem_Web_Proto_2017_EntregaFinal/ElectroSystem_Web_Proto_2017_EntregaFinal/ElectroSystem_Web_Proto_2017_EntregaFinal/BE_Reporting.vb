Public Class BE_Reporting


    Private _artefactos As List(Of BE_ArtefactoElectrico)
    Private _cantidad_clientes As Boolean
    Private _cliente As List(Of BE_CLIENTE)
    Private _fallo As Boolean = False
    Private _fechadesde As DateTime
    Private _fechahasta As DateTime
    Private _materiales As List(Of BE_Material_TrabajoconPrec)
    Private _presupuesto As BE_Presupuesto
    Private _top5artefacto As Boolean
    Private _top5material As Boolean
    Private _top5trabajo As Boolean
    Private _trabajos As List(Of BE_Material_TrabajoconPrec)
    Private _valores_clientes As Boolean = False
   
    Public Property artefactos() As List(Of BE_ArtefactoElectrico)
        Get
            Return _artefactos
        End Get
        Set(ByVal Value As List(Of BE_ArtefactoElectrico))
            _artefactos = Value
			End Set
    End Property

    Public Property cantidad_clientes() As Boolean
        Get
            Return _cantidad_clientes
        End Get
        Set(ByVal Value As Boolean)
            _cantidad_clientes = Value
			End Set
    End Property

    Public Property cliente() As List(Of BE_CLIENTE)
        Get
            Return _cliente
        End Get
        Set(ByVal Value As List(Of BE_CLIENTE))
            _cliente = Value
			End Set
    End Property

    Public Property fallo() As Boolean
        Get
            Return _fallo
        End Get
        Set(ByVal Value As Boolean)
            _fallo = Value
			End Set
    End Property

    Public Property fechadesde() As DateTime
        Get
            Return _fechadesde
        End Get
        Set(ByVal Value As DateTime)
            _fechadesde = Value
			End Set
    End Property

    Public Property fechahasta() As DateTime
        Get
            Return _fechahasta
        End Get
        Set(ByVal Value As DateTime)
            _fechahasta = Value
			End Set
    End Property

    Public Property materiales() As List(Of BE_Material_TrabajoconPrec)
        Get
            Return _materiales
        End Get
        Set(ByVal Value As List(Of BE_Material_TrabajoconPrec))
            _materiales = Value
			End Set
    End Property

    Public Property presupuesto() As BE_Presupuesto
        Get
            Return _presupuesto
        End Get
        Set(ByVal Value As BE_Presupuesto)
            _presupuesto = Value
			End Set
    End Property

    Public Property top5artefacto() As Boolean
        Get
            Return _top5artefacto
        End Get
        Set(ByVal Value As Boolean)
            _top5artefacto = Value
			End Set
    End Property

    Public Property top5material() As Boolean
        Get
            Return _top5material
        End Get
        Set(ByVal Value As Boolean)
            _top5material = Value
			End Set
    End Property

    Public Property top5trabajo() As Boolean
        Get
            Return _top5trabajo
        End Get
        Set(ByVal Value As Boolean)
            _top5trabajo = Value
			End Set
    End Property

    Public Property trabajos() As List(Of BE_Material_TrabajoconPrec)
        Get
            Return _trabajos
        End Get
        Set(ByVal Value As List(Of BE_Material_TrabajoconPrec))
            _trabajos = Value
			End Set
    End Property

    Public Property valores_clientes() As Boolean
        Get
            Return _valores_clientes
        End Get
        Set(ByVal Value As Boolean)
            _valores_clientes = Value
			End Set
    End Property


End Class 