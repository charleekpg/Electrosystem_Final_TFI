Public Class BE_ExportarDatos


    Private _directorio As String

    Public Property directorio() As String
        Get
            Return _directorio
        End Get
        Set(ByVal Value As String)
            _directorio = Value
			End Set
    End Property


End Class