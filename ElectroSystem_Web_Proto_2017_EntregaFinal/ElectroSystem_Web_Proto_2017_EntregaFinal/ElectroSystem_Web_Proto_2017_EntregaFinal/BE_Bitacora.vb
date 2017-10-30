
Public Class BE_Bitacora


    Private _codigo_evento As Integer?
    Private _criticidad As String = ""
    Private _descripcion_evento As String = ""
    Private _fecha_hora As DateTime?
    Private _id_registro As Integer
    Private _informacion_adicional As String = ""
    Private _usuario As BE_Usuario

    Public Property codigo_evento() As Integer?
        Get
            Return _codigo_evento
        End Get
        Set(ByVal Value As Integer?)
            _codigo_evento = Value
			End Set
    End Property

    Public Property criticidad() As String
        Get
            Return _criticidad
        End Get
        Set(ByVal Value As String)
            _criticidad = Value
			End Set
    End Property

    Public Property descripcion_evento() As String
        Get
            Return _descripcion_evento
        End Get
        Set(ByVal Value As String)
            _descripcion_evento = Value
			End Set
    End Property

    Public Property fecha_hora() As DateTime?
        Get
            Return _fecha_hora
        End Get
        Set(ByVal Value As DateTime?)
            _fecha_hora = Value
			End Set
    End Property

    Public Property id_registro() As Integer
        Get
            Return _id_registro
        End Get
        Set(ByVal Value As Integer)
            _id_registro = Value
			End Set
    End Property

    Public Property informacion_adicional() As String
        Get
            Return _informacion_adicional
        End Get
        Set(ByVal Value As String)
            _informacion_adicional = Value
			End Set
    End Property

    Public Property usuario() As BE_Usuario
        Get
            Return _usuario
        End Get
        Set(ByVal Value As BE_Usuario)
            _usuario = Value
			End Set
    End Property


End Class 