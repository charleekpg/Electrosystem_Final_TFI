Public Class BE_Etiqueta

    Private _id_control As String
    Private _idioma As BE_Idioma
    Private _nombre_traduccion As String

    Public Property id_control() As String
        Get
            Return _id_control
        End Get
        Set(ByVal Value As String)
            _id_control = Value
			End Set
    End Property

    Public Property idioma() As BE_Idioma
        Get
            Return _idioma
        End Get
        Set(ByVal Value As BE_Idioma)
            _idioma = Value
			End Set
    End Property

    Public Property nombre_traduccion() As String
        Get
            Return _nombre_traduccion
        End Get
        Set(ByVal Value As String)
            _nombre_traduccion = Value
			End Set
    End Property

End Class
