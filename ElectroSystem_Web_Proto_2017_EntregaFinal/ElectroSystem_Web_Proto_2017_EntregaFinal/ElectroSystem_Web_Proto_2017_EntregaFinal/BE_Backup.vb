Public Class BE_Backup
    Private _directorio As String
    Private _nombre_backup As String

    Public Property directorio() As String
        Get
            Return _directorio
        End Get
        Set(ByVal Value As String)
            _directorio = Value
			End Set
    End Property

    Public Property nombre_backup() As String
        Get
            Return _nombre_backup
        End Get
        Set(ByVal Value As String)
            _nombre_backup = Value
			End Set
    End Property


End Class