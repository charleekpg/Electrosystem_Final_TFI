Public MustInherit Class BE_PermisoBase


    Private _Descripcion As String
    Private _flagdeborrado As Boolean
    Private _idpermiso As String

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal Value As String)
            _Descripcion = Value
			End Set
    End Property

    Public Property flagdeborrado() As Boolean
        Get
            Return _flagdeborrado
        End Get
        Set(ByVal Value As Boolean)
            _flagdeborrado = Value
			End Set
    End Property

    Public Property idpermiso() As String
        Get
            Return _idpermiso
        End Get
        Set(ByVal Value As String)
            _idpermiso = Value
			End Set
    End Property

    Public Sub New()

    End Sub


End Class 