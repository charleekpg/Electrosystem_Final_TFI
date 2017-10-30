Public Class Cierre_proyecto
    Inherits System.Web.UI.Page
    Private grilla1 As New List(Of grilla)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim be_proyecto As New BE.BE_Proyecto
        Dim bll_proyecto As New BLL.BLL_Proyecto
        Dim be_presupuesto As New BE.BE_Presupuesto
        be_presupuesto.id = 10
        Dim proyecto As BE.BE_Proyecto
        be_presupuesto.estado_presupuesto = "Comenzado"
        be_proyecto.Presupuesto = be_presupuesto
        be_proyecto.fecha_inicio = "29/07/2017"
        be_proyecto.tarea = New List(Of BE.BE_Tarea)
        Dim be_tarea As New BE.BE_Tarea
        be_tarea.cableado = True
        be_tarea.porcentaje_tarea = 20
        Dim be_tarea1 As New BE.BE_Tarea
        be_tarea1.caneria = True
        be_tarea1.porcentaje_tarea = 20
        Dim be_tarea2 As New BE.BE_Tarea
        be_tarea2.istablero = True
        be_tarea2.porcentaje_tarea = 20
        Dim be_tarea3 As New BE.BE_Tarea
        be_tarea3.isterminacion = True
        be_tarea3.porcentaje_tarea = 20
        Dim be_taera4 As New BE.BE_Tarea
        be_taera4.losa = True
        be_taera4.porcentaje_tarea = 20
        be_proyecto.tarea.Add(be_tarea)
        be_proyecto.tarea.Add(be_tarea1)
        be_proyecto.tarea.Add(be_tarea2)
        be_proyecto.tarea.Add(be_tarea3)
        be_proyecto.tarea.Add(be_taera4)
        If bll_proyecto.cerrarproyecto(be_proyecto) = False Then
            MsgBox("No se puede cerrar el proyecto por que las tareas no cumplen 100%")
        Else
            MsgBox("Cerrado correctamente.")
            proyecto = bll_proyecto.consultar(be_proyecto)
            Dim grilla As New grilla
            grilla.estado = proyecto.Presupuesto.estado_presupuesto
            grilla.fecha = proyecto.fecha_establecida_contrato
            grilla.porcentajecableado = 20
            grilla.porcentajecaneria = 20
            grilla.porcentajelosa = 20
            grilla.porcentajetablero = 20
            grilla.porcentajeterminacion = 20
            grilla1.Add(grilla)
            GridView1.DataSource = grilla1
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim be_proyecto As New BE.BE_Proyecto
        Dim bll_proyecto As New BLL.BLL_Proyecto
        Dim be_presupuesto As New BE.BE_Presupuesto
        be_presupuesto.id = 10
        be_presupuesto.estado_presupuesto = "Comenzado"
        be_proyecto.Presupuesto = be_presupuesto
        be_proyecto.fecha_inicio = "29/07/2017"
        be_proyecto.tarea = New List(Of BE.BE_Tarea)
        Dim be_tarea As New BE.BE_Tarea
        be_tarea.cableado = True
        be_tarea.porcentaje_tarea = 10
        Dim be_tarea1 As New BE.BE_Tarea
        be_tarea1.caneria = True
        be_tarea1.porcentaje_tarea = 10
        Dim be_tarea2 As New BE.BE_Tarea
        be_tarea2.istablero = True
        be_tarea2.porcentaje_tarea = 20
        Dim be_tarea3 As New BE.BE_Tarea
        be_tarea3.isterminacion = True
        be_tarea3.porcentaje_tarea = 20
        Dim be_taera4 As New BE.BE_Tarea
        be_taera4.losa = True
        be_taera4.porcentaje_tarea = 20
        be_proyecto.tarea.Add(be_tarea)
        be_proyecto.tarea.Add(be_tarea1)
        be_proyecto.tarea.Add(be_tarea2)
        be_proyecto.tarea.Add(be_tarea3)
        be_proyecto.tarea.Add(be_taera4)
        If bll_proyecto.cerrarproyecto(be_proyecto) = False Then
            MsgBox("No se puede cerrar el proyecto por que las tareas no cumplen 100%")
        Else
            MsgBox("Cerrado correctamente.")
        End If
    End Sub



End Class
Class grilla
    Private _estado As String
    Public Property estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property
    Private _fecha As Date
    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property
    Private _porcentajecableado As Integer
    Public Property porcentajecableado() As Integer
        Get
            Return _porcentajecableado
        End Get
        Set(ByVal value As Integer)
            _porcentajecableado = value
        End Set
    End Property
    Private _porcentajecaneria As Integer
    Public Property porcentajecaneria() As Integer
        Get
            Return _porcentajecaneria
        End Get
        Set(ByVal value As Integer)
            _porcentajecaneria = value
        End Set
    End Property
    Private _porcentajetablero As Integer
    Public Property porcentajetablero() As Integer
        Get
            Return _porcentajetablero
        End Get
        Set(ByVal value As Integer)
            _porcentajetablero = value
        End Set
    End Property
    Private _porcentajeterminacion As Integer
    Public Property porcentajeterminacion() As Integer
        Get
            Return _porcentajeterminacion
        End Get
        Set(ByVal value As Integer)
            _porcentajeterminacion = value
        End Set
    End Property
    Private _porcentajelosa As Integer
    Public Property porcentajelosa() As Integer
        Get
            Return _porcentajelosa
        End Get
        Set(ByVal value As Integer)
            _porcentajelosa = value
        End Set
    End Property
End Class