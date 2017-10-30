Imports BE.BE

Public MustInherit Class BE_CLIENTE
    Private _cantidad_presupuestos As Integer
    Private _Correoelectronico As String
    Private _id As Integer
    Private _Identificador As String
    Private _Telefonos As New List(Of BE_Telefono)
    Private _TratamientoEspecial As Boolean = False

    Public Property cantidad_presupuesto() As Integer
        Get
            Return _cantidad_presupuestos
        End Get
        Set(ByVal Value As Integer)
            _cantidad_presupuestos = Value
        End Set
    End Property

    Public Property Correoelectronico() As String
        Get
            Return _Correoelectronico
        End Get
        Set(ByVal Value As String)
            _Correoelectronico = Value
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

    Public Property identificador() As String
        Get
            Return _Identificador
        End Get
        Set(ByVal Value As String)
            _Identificador = Value
        End Set
    End Property

    Public Property Telefonos() As List(Of BE_Telefono)
        Get
            Return _Telefonos
        End Get
        Set(ByVal Value As List(Of BE_Telefono))
            _Telefonos = Value
        End Set
    End Property

    Public Property TratamientoEspecial() As Boolean
        Get
            Return _TratamientoEspecial
        End Get
        Set(ByVal Value As Boolean)
            _TratamientoEspecial = Value
        End Set
    End Property



End Class
