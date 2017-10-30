Public Class Armado_PresupuestoTecnico
    Inherits System.Web.UI.Page
    Shared artefacto As List(Of BE.BE_ArtefactoElectrico)
    Shared trabajo As New List(Of BE.BE_Material_TrabajoconPrec)
    Shared materiales As New List(Of BE.BE_Material_TrabajoconPrec)
    Shared grilla As New List(Of tarea)
    Shared presupuesto As New BE.BE_Presupuesto
    Shared grilla2 As New List(Of material_trabajo)
    Shared dibujo_tecnico As New BE.BE_DibujoTecnico
    Shared lista_dibujo As New List(Of BE.BE_DibujoTecnico)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargar_grilla()
        If trabajo.Count = 0 Then
            cargar_cbx()
        End If
        cargar_grilla1()
    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        'esto es en el prototipo que se ponen dichos valores...en el producto final lo tomará de la grilal según l oespecificado por el usuario.
        Dim respuesta As Integer = 0
        Dim bll_presupuesto As New BLL.BLL_Presupuesto
        presupuesto.Artefacto_electrico = New List(Of BE.BE_ArtefactoElectrico)
        presupuesto.Materiales_trabajo = New List(Of BE.BE_Material_TrabajoconPrec)
        presupuesto.porcentaje_losa = 20
        presupuesto.porcentaje_caneriaycableado = 20
        presupuesto.porcentaje_tablero = 20
        presupuesto.porcentaje_llaveytoma = 20
        presupuesto.porcentaje_terminacion = 20
        presupuesto.Instalacion_compleja = chk_instalacioncompleja.Checked
        presupuesto.departamento_granescala = chk_deptogranescala.Checked
        For Each material_trabajo As material_trabajo In grilla2
            If material_trabajo.tipo = "Material" Then
                presupuesto.Materiales_trabajo.Add(materiales.Find(Function(x) x.Descripcion = material_trabajo.descripcion))
            ElseIf material_trabajo.tipo = "Trabajo" Then
                presupuesto.Materiales_trabajo.Add(trabajo.Find(Function(x) x.Descripcion = material_trabajo.descripcion))

            Else
                presupuesto.Artefacto_electrico.Add(artefacto.Find(Function(x) x.descripcion = material_trabajo.descripcion))
            End If
        Next
        presupuesto.dibujotecnico = dibujo_tecnico
        respuesta = bll_presupuesto.actualizacion_responsabletecnico(presupuesto)
        If respuesta < 0 Then
            MsgBox("Por dibujo técnico, La cantidad de artefactos debe ser como máximo:" & respuesta * -1)
        Else
            MsgBox("Se ha guardado correctamente el presupuesto técnico.")
        End If

    End Sub

    Protected Sub grd_tareas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grd_tareas.SelectedIndexChanged

    End Sub

    Private Class tarea
        Private _tarea As String
        Public Property tarea() As String
            Get
                Return _tarea
            End Get
            Set(ByVal value As String)
                _tarea = value
            End Set
        End Property
        Private _porcentaje As Integer
        Public Property porcentaje() As Integer
            Get
                Return _porcentaje
            End Get
            Set(ByVal value As Integer)
                _porcentaje = value
            End Set
        End Property
    End Class

    Private Sub cargar_grilla()
        Dim tarea1 As New tarea
        Dim tarea2 As New tarea
        Dim tarea3 As New tarea
        Dim tarea4 As New tarea
        Dim tarea5 As New tarea
        tarea1.tarea = "Losa"
        tarea1.porcentaje = 20
        tarea2.tarea = "Caneria y Cableado"
        tarea2.porcentaje = 20
        tarea3.tarea = "Tableros"
        tarea3.porcentaje = 20
        tarea4.tarea = "Llaves y Tomas de Corriente"
        tarea4.porcentaje = 20
        tarea5.tarea = "Terminaciones"
        tarea5.porcentaje = 20
        grilla.Clear()
        grilla.Add(tarea1)
        grilla.Add(tarea2)
        grilla.Add(tarea3)
        grilla.Add(tarea4)
        grilla.Add(tarea5)
        grd_tareas.DataSource = grilla
        grd_tareas.DataBind()
    End Sub

    Private Sub cargar_cbx()
        Dim bll_artefacto As New BLL.BLL_ArtefactoElectrico
        Dim bll_material As New BLL.BLL_Material_TrabajoconPrec
        artefacto = bll_artefacto.consultartodos()
        For Each material As BE.BE_Material_TrabajoconPrec In bll_material.consultartodos()
            If material.Material = True Then
                materiales.Add(material)
            Else
                trabajo.Add(material)
            End If
        Next
        drp_artefacto.DataSource = artefacto
        drp_artefacto.DataTextField = "descripcion"
        drp_artefacto.DataValueField = "descripcion"
        drp_artefacto.DataBind()
        drp_material.DataSource = materiales
        drp_material.DataTextField = "Descripcion"
        drp_material.DataValueField = "Descripcion"
        drp_material.DataBind()
        drp_trabajoconprecio.DataSource = trabajo
        drp_trabajoconprecio.DataTextField = "Descripcion"
        drp_trabajoconprecio.DataValueField = "Descripcion"
        drp_trabajoconprecio.DataBind()
    End Sub

    Protected Sub link_cargarpresu_Click(sender As Object, e As EventArgs) Handles link_cargarpresu.Click
        Dim bll_presupuesto As New BLL.BLL_Presupuesto
        presupuesto = bll_presupuesto.consultar(presupuesto)
        Label1.Text = presupuesto.id
    End Sub

    Private Class material_trabajo
        Private _descripcion As String
        Public Property descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal value As String)
                _descripcion = value
            End Set
        End Property
        Private _cantidad As Integer
        Public Property cantidad() As Integer
            Get
                Return _cantidad
            End Get
            Set(ByVal value As Integer)
                _cantidad = value
            End Set
        End Property
        Private _tipo As String
        Public Property tipo() As String
            Get
                Return _tipo
            End Get
            Set(ByVal value As String)
                _tipo = value
            End Set
        End Property

    End Class

    Private Sub cargar_grilla1()

        grd_artefactos.DataSource = grilla2
        grd_artefactos.DataBind()
    End Sub

    Protected Sub btn_artefacto_Click(sender As Object, e As EventArgs) Handles btn_artefacto.Click
        Dim be_artefacto As New BE.BE_ArtefactoElectrico
        Dim bll_artefacto As New BLL.BLL_ArtefactoElectrico
        Dim material_trabajo As New material_trabajo
        If grilla2.Exists(Function(x) x.descripcion = drp_artefacto.Text) Then
            MsgBox("Ya ha agregado dicho artefacto. En el prototipo no se puede cambiar.")
        Else
            be_artefacto = artefacto.Find(Function(x) x.descripcion = drp_artefacto.Text)
            be_artefacto.cantidad = txt_artefacto.Text
            material_trabajo.descripcion = be_artefacto.descripcion
            material_trabajo.cantidad = be_artefacto.cantidad
            material_trabajo.tipo = "Artefacto"
            grilla2.Add(material_trabajo)
            cargar_grilla1()

        End If

    End Sub

    Protected Sub btn_material_Click(sender As Object, e As EventArgs) Handles btn_material.Click
        Dim be_material As New BE.BE_Material_TrabajoconPrec
        Dim bll_material As New BLL.BLL_Material_TrabajoconPrec
        Dim material_trabajo As New material_trabajo
        If grilla2.Exists(Function(x) x.descripcion = drp_material.Text) Then
            MsgBox("Ya ha agregado dicho material. En el prototipo no se puede cambiar.")
        Else
            be_material = materiales.Find(Function(x) x.Descripcion = drp_material.Text)
            be_material.cantidad = txt_cantidad.Text
            material_trabajo.descripcion = be_material.Descripcion
            material_trabajo.cantidad = be_material.cantidad
            material_trabajo.tipo = "Material"
            grilla2.Add(material_trabajo)
            cargar_grilla1()
        End If

    End Sub

    Protected Sub btn_trabajo_Click(sender As Object, e As EventArgs) Handles btn_trabajo.Click
        Dim be_trabajo As New BE.BE_Material_TrabajoconPrec
        Dim bll_trabajo As New BLL.BLL_Material_TrabajoconPrec
        Dim material_trabajo As New material_trabajo
        If grilla2.Exists(Function(x) x.descripcion = drp_trabajoconprecio.Text) Then
            MsgBox("Ya ha agregado dicho trabajo. En el prototipo no se puede cambiar.")
        Else
            be_trabajo = trabajo.Find(Function(x) x.Descripcion = drp_trabajoconprecio.Text)
            be_trabajo.cantidad = txt_trabajoconprecio.Text
            material_trabajo.descripcion = be_trabajo.Descripcion
            material_trabajo.cantidad = be_trabajo.cantidad
            material_trabajo.tipo = "Trabajo"
            grilla2.Add(material_trabajo)
            cargar_grilla1()
        End If

    End Sub

    Protected Sub lnk_cargardibujo_Click(sender As Object, e As EventArgs) Handles lnk_cargardibujo.Click
        Dim bll_dibujo As New BLL.bll_dibujotecnico
        dibujo_tecnico = bll_dibujo.consulta(dibujo_tecnico)
        lista_dibujo.Add(dibujo_tecnico)
        MsgBox("Cargado dibujo tecnico")

    End Sub


End Class