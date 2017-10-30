Public Class BE_Telefono


    Private _eliminar As Boolean
    Private _id As Integer = 0
    Private _numero_telefono As String

    Public Property eliminar() As Boolean
        Get
            Return _eliminar
        End Get
        Set(ByVal Value As Boolean)
            _eliminar = Value
			End Set
    End Property

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
			End Set
    End Property

    Public Property numero_telefono() As String
        Get
            Return _numero_telefono
        End Get
        Set(ByVal Value As String)
            _numero_telefono = Value
			End Set
    End Property


End Class 