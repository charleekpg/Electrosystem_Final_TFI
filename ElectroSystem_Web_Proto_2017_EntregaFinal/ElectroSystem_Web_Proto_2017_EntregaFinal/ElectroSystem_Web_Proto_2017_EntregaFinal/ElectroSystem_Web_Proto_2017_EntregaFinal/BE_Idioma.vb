Public Class BE_Idioma


    Private _id_idioma As Integer = 1
    Private _Idioma As String = "Español"
    Public _be_etiqueta As List(Of BE_Etiqueta)

    Public Property id_idioma() As Integer
        Get
            Return _id_idioma
        End Get
        Set(ByVal Value As Integer)
            _id_idioma = Value
			End Set
    End Property

    Public Property Idioma() As String
        Get
            Return _Idioma
        End Get
        Set(ByVal Value As String)
            _Idioma = Value
			End Set
    End Property

    Public Property be_etiqueta() As List(Of BE.BE_Etiqueta)
        Get
            Return _be_etiqueta
        End Get
        Set(ByVal value As List(Of BE.BE_Etiqueta))
            _be_etiqueta = value
        End Set
    End Property

End Class