
Public Class BE_Tarea


    Private _cableado As Boolean
    Private _caneria As Boolean
    Private _comentario As String
    Private _fecha_de_cobro As Date
    Private _fecha_emision_certificado As Date
    Private _fecha_estimada_cobro As Date
    Private _fecha_finalizacion_tarea As Date
    Private _fecha_inicio_tarea As Date
    Private _llaveytoma As Boolean
    Private _losa As Boolean
    Private _monto_cobrado As Decimal
    Private _monto_garantia As Decimal
    Private _porcentaje_tarea As Decimal
    Private _tablero As Boolean
    Private _tarea As String
    Private _terminacion As Boolean

    Public Property cableado() As Boolean
        Get
            Return _cableado
        End Get
        Set(ByVal Value As Boolean)
            _cableado = Value
        End Set
    End Property

    Public Property caneria() As Boolean
        Get
            Return _caneria
        End Get
        Set(ByVal Value As Boolean)
            _caneria = Value
        End Set
    End Property

    Public Property comentario() As String
        Get
            Return _comentario
        End Get
        Set(ByVal Value As String)
            _comentario = Value
        End Set
    End Property

    Public Property fecha_de_cobro() As Date
        Get
            Return _fecha_de_cobro
        End Get
        Set(ByVal Value As Date)
            _fecha_de_cobro = Value
        End Set
    End Property

    Public Property fecha_emision_certificado() As Date
        Get
            Return _fecha_emision_certificado
        End Get
        Set(ByVal Value As Date)
            _fecha_emision_certificado = Value
        End Set
    End Property

    Public Property fecha_estimada_cobro() As Date
        Get
            Return _fecha_estimada_cobro
        End Get
        Set(ByVal Value As Date)
            _fecha_estimada_cobro = Value
        End Set
    End Property

    Public Property fecha_finalizacion_tarea() As Date
        Get
            Return _fecha_finalizacion_tarea
        End Get
        Set(ByVal Value As Date)
            _fecha_finalizacion_tarea = Value
        End Set
    End Property

    Public Property fecha_inicio_tarea() As Date
        Get
            Return _fecha_inicio_tarea
        End Get
        Set(ByVal Value As Date)
            _fecha_inicio_tarea = Value
        End Set
    End Property

    Public Property istablero() As Boolean
        Get
            Return _tablero
        End Get
        Set(ByVal Value As Boolean)
            _tablero = Value
        End Set
    End Property

    Public Property isterminacion() As Boolean
        Get
            Return _terminacion
        End Get
        Set(ByVal Value As Boolean)
            _terminacion = Value
        End Set
    End Property

    Public Property llaveytoma() As Boolean
        Get
            Return _llaveytoma
        End Get
        Set(ByVal Value As Boolean)
            _llaveytoma = Value
        End Set
    End Property

    Public Property losa() As Boolean
        Get
            Return _losa
        End Get
        Set(ByVal Value As Boolean)
            _losa = Value
        End Set
    End Property

    Public Property monto_cobrado() As Decimal
        Get
            Return _monto_cobrado
        End Get
        Set(ByVal Value As Decimal)
            _monto_cobrado = Value
        End Set
    End Property

    Public Property monto_garantia() As Decimal
        Get
            Return _monto_garantia
        End Get
        Set(ByVal Value As Decimal)
            _monto_garantia = Value
        End Set
    End Property

    Public Property porcentaje_tarea() As Decimal
        Get
            Return _porcentaje_tarea
        End Get
        Set(ByVal Value As Decimal)
            _porcentaje_tarea = Value
        End Set
    End Property

    Public Property tablero() As Boolean
        Get
            Return _tablero
        End Get
        Set(ByVal Value As Boolean)
            _tablero = Value
        End Set
    End Property

    Public Property tarea() As String
        Get
            Return _tarea
        End Get
        Set(ByVal Value As String)
            _tarea = Value
        End Set
    End Property

    Public Property terminacion() As Boolean
        Get
            Return _terminacion
        End Get
        Set(ByVal Value As Boolean)
            _terminacion = Value
        End Set
    End Property


End Class