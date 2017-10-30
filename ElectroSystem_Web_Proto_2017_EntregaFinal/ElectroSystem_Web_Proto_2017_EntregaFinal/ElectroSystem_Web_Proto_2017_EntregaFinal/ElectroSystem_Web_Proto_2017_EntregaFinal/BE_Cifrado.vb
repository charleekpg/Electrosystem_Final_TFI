Public Class BE_Cifrado
    Private _texto As String
    Public Property texto() As String
        Get
            Return _texto
        End Get
        Set(ByVal value As String)
            _texto = value
        End Set
    End Property

    Private _digito As Integer
    Public Property digito() As Integer
        Get
            Return _digito
        End Get
        Set(ByVal value As Integer)
            _digito = value
        End Set
    End Property
End Class
