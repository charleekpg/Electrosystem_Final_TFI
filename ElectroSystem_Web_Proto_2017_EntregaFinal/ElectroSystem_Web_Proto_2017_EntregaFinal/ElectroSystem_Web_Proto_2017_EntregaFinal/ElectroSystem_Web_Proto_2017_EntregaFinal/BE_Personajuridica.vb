Public Class BE_Personajuridica
    Inherits BE_CLIENTE


    Private _Razonsocial As String
    Private _Referente As BE_Personafisica

    Public Property Razonsocial() As String
        Get
            Return _Razonsocial
        End Get
        Set(ByVal Value As String)
            _Razonsocial = Value
			End Set
    End Property

    Public Property Referente() As BE_Personafisica
        Get
            Return _Referente
        End Get
        Set(ByVal Value As BE_Personafisica)
            _Referente = Value
			End Set
    End Property


End Class 