Public Class BE_Usuario

    Private _Clave As String
    Private _Fec_creacionclave As DateTime
    Private _id_usuario As Integer?
    Private _idioma As BE_Idioma
    Private _Intentos_Fallidos As Integer
    Private _Nombre_Usuario As String
    Private _permiso_usuario As BE_PermisoBase
    Private _Usuario_Bloqueado As Boolean
    Public Shared usuariologueado As BE_Usuario = Nothing

    Public Property Clave() As String
        Get
            Return _Clave
        End Get
        Set(ByVal Value As String)
            _Clave = Value
			End Set
    End Property

    Public Property Fec_Creacionclave() As DateTime
        Get
            Return _Fec_creacionclave
        End Get
        Set(ByVal Value As DateTime)
            _Fec_creacionclave = Value
			End Set
    End Property

    Public Property id_usuario() As Integer?
        Get
            Return _id_usuario
        End Get
        Set(ByVal Value As Integer?)
            _id_usuario = Value
			End Set
    End Property

    Public Property Idioma() As BE_Idioma
        Get
            Return _idioma
        End Get
        Set(ByVal Value As BE_Idioma)
            _idioma = Value
			End Set
    End Property

    Public Property Intentos_Fallidos() As Integer
        Get
            Return _Intentos_Fallidos
        End Get
        Set(ByVal Value As Integer)
            _Intentos_Fallidos = Value
			End Set
    End Property

    Private _nota As String
    Public Property nota() As String
        Get
            Return _nota
        End Get
        Set(ByVal value As String)
            _nota = value
        End Set
    End Property

    Public Property Nombre_Usuario() As String
        Get
            Return _Nombre_Usuario
        End Get
        Set(ByVal Value As String)
            _Nombre_Usuario = Value
			End Set
    End Property

    Public Property permiso_usuario() As BE_PermisoBase
        Get
            Return _permiso_usuario
        End Get
        Set(ByVal Value As BE_PermisoBase)
            _permiso_usuario = Value
			End Set
    End Property

    Public Property Usuario_Bloqueado() As Boolean
        Get
            Return _Usuario_Bloqueado
        End Get
        Set(ByVal Value As Boolean)
            _Usuario_Bloqueado = Value
			End Set
    End Property


End Class 