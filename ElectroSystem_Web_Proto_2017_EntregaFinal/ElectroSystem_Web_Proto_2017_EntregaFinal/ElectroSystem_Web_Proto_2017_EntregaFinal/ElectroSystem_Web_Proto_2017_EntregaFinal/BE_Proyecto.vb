Public Class BE_Proyecto


    Private _estado As String
    Private _fecha_establecida_contrato As Date
    Private _fecha_inicio As Date
    Private _fecha_instalacionluzdeobra As Date
    Private _Presupuesto As BE_Presupuesto
    Private _Tareas As List(Of BE_Tarea)

    Public Property fecha_establecida_contrato() As Date
        Get
            Return _fecha_establecida_contrato
        End Get
        Set(ByVal Value As Date)
            _fecha_establecida_contrato = Value
        End Set
    End Property

    Public Property fecha_inicio() As Date
        Get
            Return _fecha_inicio
        End Get
        Set(ByVal Value As Date)
            _fecha_inicio = Value
        End Set
    End Property

    Public Property fecha_instalacionluzdeobra() As Date
        Get
            Return _fecha_instalacionluzdeobra
        End Get
        Set(ByVal Value As Date)
            _fecha_instalacionluzdeobra = Value
        End Set
    End Property

    Public Property Presupuesto() As BE_Presupuesto
        Get
            Return _Presupuesto
        End Get
        Set(ByVal Value As BE_Presupuesto)
            _Presupuesto = Value
        End Set
    End Property

    Public Property tarea() As List(Of BE_Tarea)
        Get
            Return _Tareas
        End Get
        Set(ByVal Value As List(Of BE_Tarea))
            _Tareas = Value
			End Set
    End Property


End Class 