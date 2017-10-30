Public Class BE_Partido


    Private _id As Integer
    Private _localidades As List(Of be_localidad)
    Private _partido As String

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
			End Set
    End Property

    Public Property localidades() As List(Of be_localidad)
        Get
            Return _localidades
        End Get
        Set(ByVal Value As List(Of be_localidad))
            _localidades = Value
			End Set
    End Property

    Public Property partido() As String
        Get
            Return _partido
        End Get
        Set(ByVal Value As String)
            _partido = Value
			End Set
    End Property


End Class 