
Public Class BE_Personafisica
    Inherits BE_CLIENTE


    Private _abreviaturatitulo As String
    Private _Apellido As String
    Private _Flagcreacion As Boolean = False
    Private _Nombre As String

    Public Property Abreviaturadetitulo() As String
        Get
            Return _abreviaturatitulo
        End Get
        Set(ByVal Value As String)
            _abreviaturatitulo = Value
			End Set
    End Property

    Public Property Apellido() As String
        Get
            Return _Apellido
        End Get
        Set(ByVal Value As String)
            _Apellido = Value
			End Set
    End Property

    Public Property Flagcreacion() As Boolean
        Get
            Return _Flagcreacion
        End Get
        Set(ByVal Value As Boolean)
            _Flagcreacion = Value
			End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
			End Set
    End Property


End Class 