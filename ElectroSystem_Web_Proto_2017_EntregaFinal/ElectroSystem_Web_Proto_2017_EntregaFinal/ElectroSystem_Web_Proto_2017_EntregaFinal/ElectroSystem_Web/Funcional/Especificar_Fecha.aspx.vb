Public Class Especificar_Fecha

    Inherits System.Web.UI.Page
    Shared lista_proyectos As List(Of BE.BE_Proyecto)
    Shared grilla As New List(Of grilla_ejemplo)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargar_grilla()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim unbe_proyecto As New BE.BE_Proyecto
        Dim bll_proyecto As New BLL.BLL_Proyecto
        unbe_proyecto.Presupuesto = New BE.BE_Presupuesto
        unbe_proyecto.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        unbe_proyecto.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        Dim unbe_ambiente As New BE.Be_Ambiente
        unbe_ambiente.circuitos = New List(Of BE.BE_Circuito)
        Dim unbe_circuito As New BE.BE_Circuito
        unbe_circuito.cantidad_bocas = 13
        unbe_ambiente.circuitos.Add(unbe_circuito)
        unbe_proyecto.Presupuesto.dibujotecnico.ambiente.Add(unbe_ambiente)
        unbe_proyecto.fecha_inicio = Calendar1.SelectedDate
        unbe_proyecto = bll_proyecto.calcular_tiempos_regulares(unbe_proyecto)
        TextBox1.Text = unbe_proyecto.fecha_establecida_contrato

    End Sub


    Sub cargar_grilla()
        grilla.Clear()
        Dim bll_proyecto As New BLL.BLL_Proyecto
        lista_proyectos = bll_proyecto.consultartodos()
        For Each elemento In lista_proyectos
            Dim grilla_ejemplo As New grilla_ejemplo
            grilla_ejemplo.fecha_inicio = elemento.fecha_inicio
            grilla_ejemplo.fecha_fin = elemento.fecha_establecida_contrato
            For Each elemento2 In elemento.Presupuesto.dibujotecnico.ambiente
                For Each elemento3 In elemento2.circuitos
                    grilla_ejemplo.bocas = grilla_ejemplo.bocas + elemento3.cantidad_bocas
                Next
            Next
            grilla.Add(grilla_ejemplo)
        Next
        GridView1.DataSource = grilla
        GridView1.DataBind()
    End Sub
    Private Class grilla_ejemplo
        Private _fecha_inicio As Date
        Public Property fecha_inicio() As Date
            Get
                Return _fecha_inicio
            End Get
            Set(ByVal value As Date)
                _fecha_inicio = value
            End Set
        End Property

        Private _fecha_fin As Date
        Public Property fecha_fin() As Date
            Get
                Return _fecha_fin
            End Get
            Set(ByVal value As Date)
                _fecha_fin = value
            End Set
        End Property

        Private _bocas As Integer = 0
        Public Property bocas() As Integer
            Get
                Return _bocas
            End Get
            Set(ByVal value As Integer)
                _bocas = value
            End Set
        End Property
    End Class

    Protected Sub btn_sindatos_Click(sender As Object, e As EventArgs) Handles btn_sindatos.Click
        Dim unbe_proyecto As New BE.BE_Proyecto
        Dim bll_proyecto As New BLL.BLL_Proyecto
        unbe_proyecto.Presupuesto = New BE.BE_Presupuesto
        unbe_proyecto.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        unbe_proyecto.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        Dim unbe_ambiente As New BE.Be_Ambiente
        unbe_ambiente.circuitos = New List(Of BE.BE_Circuito)
        Dim unbe_circuito As New BE.BE_Circuito
        unbe_circuito.cantidad_bocas = 27
        unbe_ambiente.circuitos.Add(unbe_circuito)
        unbe_proyecto.Presupuesto.dibujotecnico.ambiente.Add(unbe_ambiente)
        unbe_proyecto.fecha_inicio = Calendar1.SelectedDate
        unbe_proyecto = bll_proyecto.calcular_tiempos_regulares(unbe_proyecto)
        TextBox1.Text = unbe_proyecto.fecha_establecida_contrato
    End Sub

    Protected Sub btn_sindatos0_Click(sender As Object, e As EventArgs) Handles btn_sindatos0.Click
        Dim unbe_proyecto As New BE.BE_Proyecto
        Dim bll_proyecto As New BLL.BLL_Proyecto
        unbe_proyecto.Presupuesto = New BE.BE_Presupuesto
        unbe_proyecto.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        unbe_proyecto.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        Dim unbe_ambiente As New BE.Be_Ambiente
        unbe_ambiente.circuitos = New List(Of BE.BE_Circuito)
        Dim unbe_circuito As New BE.BE_Circuito
        unbe_circuito.cantidad_bocas = 1
        unbe_ambiente.circuitos.Add(unbe_circuito)
        unbe_proyecto.Presupuesto.dibujotecnico.ambiente.Add(unbe_ambiente)
        unbe_proyecto.fecha_inicio = Calendar1.SelectedDate
        unbe_proyecto = bll_proyecto.calcular_tiempos_regulares(unbe_proyecto)
        TextBox1.Text = unbe_proyecto.fecha_establecida_contrato
    End Sub
End Class