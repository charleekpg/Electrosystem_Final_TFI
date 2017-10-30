Public Class BE_Presupuesto


    Private _actualizaicac As Boolean
    Private _departamento_granescala As Boolean
    Private _Domicilio As be_domicilio
    Private _estado_presupuesto As String
    Private _fecha_alta As Date?
    Private _fecha_modificacion As Date?
    Private _id As Integer
    Private _Instalacion_compleja As Boolean
    Private _masde20km As Boolean
    Private _masde400bocas As Boolean
    Private _observacion As String
    Private _porcentaje_aldarluz As Integer
    Private _porcentaje_caneriaycableado As Integer
    Private _porcentaje_llaveytoma As Integer
    Private _porcentaje_losa As Integer
    Private _porcentaje_tablero As Integer
    Private _porcentaje_terminacion As Integer
    Private _valor_manodeobra As Decimal
    Private _valor_material As Decimal
    Private _valor_otros As Decimal
    Private _valor_seguro_vida As Decimal
    Private _valor_total As Decimal
    Private _valor_trabajoconprecio As Decimal
    Private _Plano_Tecnico As BE_PlanoTecnico
    Private _Boca_Mercado As BE_BocaMercado
    Private _BE_CLIENTE As BE_CLIENTE
    Private _artefacto_electrico As List(Of BE_ArtefactoElectrico)
    Private _Material_TrabajoconPrec As List(Of BE_Material_TrabajoconPrec)

    Public Property actualizaicac() As Boolean
        Get
            Return _actualizaicac
        End Get
        Set(ByVal Value As Boolean)
            _actualizaicac = Value
			End Set
    End Property

    Public Property Artefacto_electrico() As List(Of BE_ArtefactoElectrico)
        Get
            Return _artefacto_electrico
        End Get
        Set(ByVal Value As List(Of BE_ArtefactoElectrico))
            _artefacto_electrico = Value
			End Set
    End Property

    Public Property boca_mercado() As BE_BocaMercado
        Get
            Return _boca_mercado
        End Get
        Set(ByVal Value As BE_BocaMercado)
            _boca_mercado = Value
			End Set
    End Property

    Public Property Cliente_Persona() As BE_CLIENTE
        Get
            Return _BE_CLIENTE
        End Get
        Set(ByVal Value As BE_CLIENTE)
            _BE_CLIENTE = Value
			End Set
    End Property

    Public Property departamento_granescala() As Boolean
        Get
            Return _departamento_granescala
        End Get
        Set(ByVal Value As Boolean)
            _departamento_granescala = Value
			End Set
    End Property

    Public Property Domicilio() As be_domicilio
        Get
            Return _Domicilio
        End Get
        Set(ByVal Value As be_domicilio)
            _Domicilio = Value
			End Set
    End Property

    Public Property estado_presupuesto() As String
        Get
            Return _estado_presupuesto
        End Get
        Set(ByVal Value As String)
            _estado_presupuesto = Value
			End Set
    End Property

    Public Property fecha_alta() As Date?
        Get
            Return _fecha_alta
        End Get
        Set(ByVal Value As Date?)
            _fecha_alta = Value
			End Set
    End Property

    Public Property fecha_modificacion() As Date?
        Get
            Return _fecha_modificacion
        End Get
        Set(ByVal Value As Date?)
            _fecha_modificacion = Value
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

    Public Property Instalacion_compleja() As Boolean
        Get
            Return _Instalacion_compleja
        End Get
        Set(ByVal Value As Boolean)
            _Instalacion_compleja = Value
			End Set
    End Property

    Public Property masde20km() As Boolean
        Get
            Return _masde20km
        End Get
        Set(ByVal Value As Boolean)
            _masde20km = Value
			End Set
    End Property

    Public Property masde400bocas() As Boolean
        Get
            Return _masde400bocas
        End Get
        Set(ByVal Value As Boolean)
            _masde400bocas = Value
			End Set
    End Property

    Public Property Materiales_trabajo() As List(Of BE_Material_TrabajoconPrec)
        Get
            Return _Material_TrabajoconPrec
        End Get
        Set(ByVal Value As List(Of BE_Material_TrabajoconPrec))
            _Material_TrabajoconPrec = Value
			End Set
    End Property

    Public Property observacion() As String
        Get
            Return _observacion
        End Get
        Set(ByVal Value As String)
            _observacion = Value
			End Set
    End Property

    Public Property Plano_tecnico() As BE_PlanoTecnico
        Get
            Return _Plano_Tecnico
        End Get
        Set(ByVal Value As BE_PlanoTecnico)
            _Plano_Tecnico = Value
			End Set
    End Property

    Public Property porcentaje_aldarluz() As Integer
        Get
            Return _porcentaje_aldarluz
        End Get
        Set(ByVal Value As Integer)
            _porcentaje_aldarluz = Value
			End Set
    End Property

    Public Property porcentaje_caneriaycableado() As Integer
        Get
            Return _porcentaje_caneriaycableado
        End Get
        Set(ByVal Value As Integer)
            _porcentaje_caneriaycableado = Value
			End Set
    End Property

    Public Property porcentaje_llaveytoma() As Integer
        Get
            Return _porcentaje_llaveytoma
        End Get
        Set(ByVal Value As Integer)
            _porcentaje_llaveytoma = Value
			End Set
    End Property

    Public Property porcentaje_losa() As Integer
        Get
            Return _porcentaje_losa
        End Get
        Set(ByVal Value As Integer)
            _porcentaje_losa = Value
			End Set
    End Property

    Public Property porcentaje_tablero() As Integer
        Get
            Return _porcentaje_tablero
        End Get
        Set(ByVal Value As Integer)
            _porcentaje_tablero = Value
			End Set
    End Property

    Public Property porcentaje_terminacion() As Integer
        Get
            Return _porcentaje_terminacion
        End Get
        Set(ByVal Value As Integer)
            _porcentaje_terminacion = Value
			End Set
    End Property

    Public Property valor_manodeobra() As Decimal
        Get
            Return _valor_manodeobra
        End Get
        Set(ByVal Value As Decimal)
            _valor_manodeobra = Value
			End Set
    End Property

    Public Property valor_material() As Decimal
        Get
            Return _valor_material
        End Get
        Set(ByVal Value As Decimal)
            _valor_material = Value
			End Set
    End Property

    Public Property valor_otros() As Decimal
        Get
            Return _valor_otros
        End Get
        Set(ByVal Value As Decimal)
            _valor_otros = Value
			End Set
    End Property

    Public Property valor_seguro_vida() As Decimal
        Get
            Return _valor_seguro_vida
        End Get
        Set(ByVal Value As Decimal)
            _valor_seguro_vida = Value
			End Set
    End Property

    Public Property valor_total() As Decimal
        Get
            Return _valor_total
        End Get
        Set(ByVal Value As Decimal)
            _valor_total = Value
			End Set
    End Property

    Public Property valor_trabajoconprecio() As Decimal
        Get
            Return _valor_trabajoconprecio
        End Get
        Set(ByVal Value As Decimal)
            _valor_trabajoconprecio = Value
			End Set
    End Property


End Class 