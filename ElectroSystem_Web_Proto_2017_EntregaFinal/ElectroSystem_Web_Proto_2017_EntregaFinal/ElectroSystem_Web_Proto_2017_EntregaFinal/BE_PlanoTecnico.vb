Public Class BE_PlanoTecnico


    Private _archivo As String
    Private _directorio As String
    Private _id As Integer

    Public Property archivo() As String
        Get
            Return _archivo
        End Get
        Set(ByVal value As String)
            _archivo = value
        End Set
    End Property
    Public Property directorio() As String
        Get
            Return _directorio
        End Get
        Set(ByVal value As String)
            _directorio = value
        End Set
    End Property


    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

End Class 