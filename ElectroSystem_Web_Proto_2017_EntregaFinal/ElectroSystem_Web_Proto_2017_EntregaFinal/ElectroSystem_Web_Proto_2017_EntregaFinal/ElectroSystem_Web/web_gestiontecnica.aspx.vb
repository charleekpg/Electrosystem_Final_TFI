Public Class web_gestiontecnica
    Inherits System.Web.UI.Page
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True
    Dim usu As BE.BE_Usuario
    Dim entero_flag As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_gest_pres_tec")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        Session.Add("Entero_Flag", entero_flag)
                        DirectCast(Me.Master, General_Electrosystem).traducir_grilla(dtg_armattrabprtec)
                        DirectCast(Me.Master, General_Electrosystem).traducir_grilla(dtg_ambientes)
                        btn_cancelarprtec_Click(Nothing, Nothing)
                    Else
                        Response.Redirect("web_login.aspx", False)
                    End If
                End If
            Else
                Me.entro = True
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Sub cargar_presupuestos_estado()
        Try
            Dim bll_presupuesto As New BLL.BLL_Presupuesto
            Dim presupuesto As New BE.BE_Presupuesto
            Dim LISTA_PRESUPUESTO As List(Of BE.BE_Presupuesto)
            Dim lista_presupuestos_final As List(Of BE.BE_Presupuesto)
            Session("Lista_Presupuestos_1") = Nothing
            presupuesto.estado_presupuesto = "Pendiente de llenado por Parte del Responsable Técnico"
            Session("Lista_Presupuestos_1") = bll_presupuesto.consultar_varios(presupuesto)
            presupuesto.estado_presupuesto = "Pendiente de llenado por parte del Responsable Comercial"
            LISTA_PRESUPUESTO = bll_presupuesto.consultar_varios(presupuesto)

            If LISTA_PRESUPUESTO.Count > 0 Then
                lista_presupuestos_final = Session("Lista_Presupuestos_1")
                For Each elemento As BE.BE_Presupuesto In LISTA_PRESUPUESTO
                    lista_presupuestos_final.Add(elemento)
                Next
                lista_presupuestos_final.Sort(Function(x, y) x.id.CompareTo(y.id))
            End If
            cmb_presupuesto.Enabled = True
            cmb_presupuesto.DataSource = Session("Lista_Presupuestos_1")
            cmb_presupuesto.DataValueField = "id"
            cmb_presupuesto.DataBind()
            If CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Count = 0 Then
                btn_cargar_presupuesto.Enabled = False
            Else
                btn_cargar_presupuesto.Enabled = True
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Sub cargar_artefacto()
        Try
            Dim bll_artefacto As New BLL.BLL_ArtefactoElectrico
            Dim lista_artefactos As List(Of BE.BE_ArtefactoElectrico)
            cbx_arteprtec.DataSource = Nothing
            Session("Lista_Artefactos") = Nothing
            lista_artefactos = bll_artefacto.consultartodos()
            Session("Lista_Artefactos") = lista_artefactos
            cbx_arteprtec.DataSource = lista_artefactos
            cbx_arteprtec.DataTextField = "Descripcion"
            cbx_arteprtec.DataBind()
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Sub cargar_materiales()
        Try
            cbx_matprtec.Items.Clear()
            cbx_trabprtec.Items.Clear()
            Dim bll_materiales As New BLL.BLL_Material_TrabajoconPrec
            Dim lista_materiales_trabajos As List(Of BE.BE_Material_TrabajoconPrec)
            lista_materiales_trabajos = bll_materiales.consultartodos()
            Dim lista_material As New List(Of BE.BE_Material_TrabajoconPrec)
            Dim lista_trabajos As New List(Of BE.BE_Material_TrabajoconPrec)
            Session("Lista_Materiales") = Nothing
            Session("Lista_Trabajos") = Nothing
            Session("Lista_Materiales") = lista_material
            Session("Lista_Trabajos") = lista_trabajos
            For Each material As BE.BE_Material_TrabajoconPrec In lista_materiales_trabajos
                If material.Material = True Then
                    lista_material.Add(material)
                Else
                    lista_trabajos.Add(material)
                End If
            Next
            cbx_matprtec.DataSource = lista_material
            cbx_matprtec.DataTextField = "Descripcion"
            cbx_matprtec.DataBind()
            cbx_trabprtec.DataSource = lista_trabajos
            cbx_trabprtec.DataTextField = "Descripcion"
            cbx_trabprtec.DataBind()
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub

    Protected Sub btn_cargar_presupuesto_Click(sender As Object, e As EventArgs) Handles btn_cargar_presupuesto.Click
        Try
            btn_cargar_presupuesto.Enabled = False
            cmb_presupuesto.Enabled = False
            Dim presupuesto As BE.BE_Presupuesto
            btn_cargar_presupuesto.Enabled = False
            presupuesto = CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Find(Function(x) x.id = cmb_presupuesto.SelectedItem.Text)
            If presupuesto.dibujotecnico Is Nothing Then
                txt_dibujotecnico.Text = "N/A"
                btn_verdibujo.Enabled = False
            Else
                txt_dibujotecnico.Text = presupuesto.dibujotecnico.id
                btn_verdibujo.Enabled = True
            End If
            If presupuesto.estado_presupuesto = "Pendiente de llenado por Parte del Responsable Técnico" Then
                Session("Entero_Flag") = 1
                cargar_artefacto()
                cbx_arteprtec.Enabled = True
                num_arteprtec.Enabled = True
                num_arteprtec.Text = "1"
                cargar_materiales()
                cbx_matprtec.Enabled = True
                num_matprtec.Enabled = True
                num_matprtec.Text = "1"
                cbx_trabprtec.Enabled = True
                num_trabprtec.Enabled = True
                num_trabprtec.Text = "1"
                CHK_Depusodomigranesca.Checked = False
                CHK_Instaeleccomple.Checked = False
                CHK_Depusodomigranesca.Enabled = True
                CHK_Instaeleccomple.Enabled = True
                txt_caneria.Enabled = True
                txt_dibujotecnico.Enabled = True
                txt_llaves.Enabled = True
                txt_losa.Enabled = True
                txt_tableros.Enabled = True
                txt_terminaciones.Enabled = True
                btn_evaluarcontradibujo.Enabled = True
                btn_guardarprte.Enabled = False
                btn_cancelarprtec.Enabled = True
                btn_addarteleprtec.Enabled = True
                btn_addmatprtec.Enabled = True
                btn_addtrabprtec.Enabled = True
            Else
                Session("Entero_Flag") = 2
                txt_caneria.Text = presupuesto.porcentaje_caneriaycableado
                txt_caneria.Enabled = True
                txt_llaves.Text = presupuesto.porcentaje_llaveytoma
                txt_llaves.Enabled = True
                txt_losa.Text = presupuesto.porcentaje_losa
                txt_losa.Enabled = True
                txt_tableros.Text = presupuesto.porcentaje_tablero
                txt_tableros.Enabled = True
                txt_terminaciones.Text = presupuesto.porcentaje_terminacion
                txt_terminaciones.Enabled = True
                btn_evaluarcontradibujo.Enabled = True
                Dim lista_grilla As New List(Of grilla)
                Dim tmp_grilla As grilla
                For Each elemento In presupuesto.Artefacto_electrico
                    tmp_grilla = New grilla
                    tmp_grilla.col_id = elemento.id
                    tmp_grilla.col_precio = elemento.precio
                    tmp_grilla.col_descripcion = elemento.descripcion
                    tmp_grilla.col_cantidad = elemento.cantidad
                    tmp_grilla.col_tipo = "Artefacto"
                    lista_grilla.Add(tmp_grilla)
                Next
                For Each elemento In presupuesto.Materiales_trabajo
                    tmp_grilla = New grilla
                    tmp_grilla.col_id = elemento.id
                    tmp_grilla.col_precio = elemento.Precio
                    tmp_grilla.col_descripcion = elemento.Descripcion
                    tmp_grilla.col_cantidad = elemento.cantidad
                    If elemento.Material = True Then
                        tmp_grilla.col_tipo = "Material"
                    Else
                        tmp_grilla.col_tipo = "Trabajo"
                    End If
                    lista_grilla.Add(tmp_grilla)
                Next
                Session("Grilla") = lista_grilla
                cargar_artefacto()
                cbx_arteprtec.Enabled = True
                num_arteprtec.Enabled = True
                num_arteprtec.Text = "1"
                cargar_materiales()
                cbx_matprtec.Enabled = True
                num_matprtec.Enabled = True
                num_matprtec.Text = "1"
                cbx_trabprtec.Enabled = True
                num_trabprtec.Enabled = True
                num_trabprtec.Text = "1"
                CHK_Depusodomigranesca.Checked = False
                CHK_Instaeleccomple.Checked = False

                CHK_Depusodomigranesca.Checked = presupuesto.departamento_granescala
                CHK_Depusodomigranesca.Enabled = True
                CHK_Instaeleccomple.Checked = presupuesto.Instalacion_compleja
                CHK_Instaeleccomple.Enabled = True
                cbx_arteprtec.Enabled = True
                num_arteprtec.Enabled = True
                btn_addarteleprtec.Enabled = True

                cbx_matprtec.Enabled = True
                num_matprtec.Enabled = True
                btn_addmatprtec.Enabled = True
                cbx_trabprtec.Enabled = True
                num_trabprtec.Enabled = True
                btn_addtrabprtec.Enabled = True
                dtg_armattrabprtec.DataSource = lista_grilla
                dtg_armattrabprtec.DataBind()
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub
    Protected Sub btn_addarteleprtec_Click(sender As Object, e As EventArgs) Handles btn_addarteleprtec.Click
        Dim lista_grilla As List(Of grilla) = Session("Grilla")
        Try
            Dim be_artefacto As New BE.BE_ArtefactoElectrico
            Dim bll_artefacto As New BLL.BLL_ArtefactoElectrico
            be_artefacto = CType(Session("Lista_Artefactos"), List(Of BE.BE_ArtefactoElectrico)).Find(Function(x) x.descripcion = cbx_arteprtec.SelectedItem.Text)
            Dim cambio As Boolean = False
            If String.IsNullOrWhiteSpace(num_arteprtec.Text) OrElse num_arteprtec.Text = 0 OrElse num_arteprtec.Text = 0 OrElse num_arteprtec.Text = 0 OrElse num_arteprtec.Text = 0 Then
                Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_valor0o>"))
                Exit Sub
            Else
                For Each elemento As grilla In CType(Session("Grilla"), List(Of grilla))
                    If elemento.col_id = be_artefacto.id AndAlso elemento.col_descripcion = be_artefacto.descripcion AndAlso elemento.col_cantidad = num_arteprtec.Text AndAlso elemento.col_tipo = "Artefacto" Then
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_addartex"))
                        Exit Sub
                    Else
                        If elemento.col_id = be_artefacto.id AndAlso elemento.col_descripcion = be_artefacto.descripcion AndAlso elemento.col_cantidad <> num_arteprtec.Text AndAlso elemento.col_tipo = "Artefacto" Then
                            cambio = True
                        End If
                    End If
                Next
            End If
            be_artefacto.cantidad = num_arteprtec.Text
            be_artefacto = bll_artefacto.calcular_precio_cantidad(be_artefacto)
            btn_guardarprte.Enabled = False
            If cambio = False Then
                Dim tmp_grilla As New grilla
                tmp_grilla.col_id = be_artefacto.id
                tmp_grilla.col_descripcion = be_artefacto.descripcion
                tmp_grilla.col_cantidad = be_artefacto.cantidad
                tmp_grilla.col_precio = be_artefacto.precio
                tmp_grilla.col_tipo = "Artefacto"
                lista_grilla.Add(tmp_grilla)
                num_arteprtec.Text = String.Empty
                dtg_armattrabprtec.DataSource = lista_grilla
                dtg_armattrabprtec.DataBind()
                btn_evaluarcontradibujo.Enabled = True
            Else
                For Each elemento As grilla In CType(Session("Grilla"), List(Of grilla))
                    If elemento.col_id = be_artefacto.id AndAlso elemento.col_descripcion = be_artefacto.descripcion AndAlso elemento.col_tipo = "Artefacto" Then
                        elemento.col_precio = be_artefacto.precio
                        elemento.col_cantidad = be_artefacto.cantidad
                        dtg_armattrabprtec.DataSource = lista_grilla
                        dtg_armattrabprtec.DataBind()
                        num_arteprtec.Text = 1
                        btn_evaluarcontradibujo.Enabled = True
                    End If
                Next
            End If
            Session("Evaluado") = 0
            num_arteprtec.Text = 1
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub


    Private Class grilla
        Private _col_descripcion As String
        Public Property col_descripcion() As String
            Get
                Return _col_descripcion
            End Get
            Set(ByVal value As String)
                _col_descripcion = value
            End Set
        End Property

        Private _col_cantidad As Integer
        Public Property col_cantidad() As Integer
            Get
                Return _col_cantidad
            End Get
            Set(ByVal value As Integer)
                _col_cantidad = value
            End Set
        End Property

        Private _col_precio As Decimal
        Public Property col_precio() As Decimal
            Get
                Return _col_precio
            End Get
            Set(ByVal value As Decimal)
                _col_precio = value
            End Set
        End Property

        Private _col_tipo As String
        Public Property col_tipo() As String
            Get
                Return _col_tipo
            End Get
            Set(ByVal value As String)
                _col_tipo = value
            End Set
        End Property

        Private _col_id As Integer
        Public Property col_id() As Integer
            Get
                Return _col_id
            End Get
            Set(ByVal value As Integer)
                _col_id = value
            End Set
        End Property

    End Class

    Private Sub btn_cancelarprtec_Click(sender As Object, e As EventArgs) Handles btn_cancelarprtec.Click
        Session("Grilla") = Nothing
        Session("Grilla") = New List(Of grilla)
        cbx_arteprtec.Enabled = False
        cbx_arteprtec.DataSource = Nothing
        cbx_arteprtec.DataBind()
        num_arteprtec.Enabled = False
        num_arteprtec.Text = "0"
        cbx_matprtec.Enabled = False
        cbx_matprtec.DataSource = Nothing
        cbx_matprtec.DataBind()
        num_matprtec.Enabled = False
        num_matprtec.Text = "0"
        cbx_trabprtec.Enabled = False
        cbx_trabprtec.DataSource = Nothing
        cbx_trabprtec.DataBind()
        num_trabprtec.Enabled = False
        num_trabprtec.Text = "0"
        txt_caneria.Enabled = False
        txt_caneria.Text = "20"
        txt_dibujotecnico.Text = "N/A"
        txt_llaves.Enabled = False
        txt_llaves.Text = "20"
        txt_losa.Enabled = False
        txt_losa.Text = "20"
        txt_tableros.Enabled = False
        txt_tableros.Text = "20"
        txt_terminaciones.Enabled = False
        txt_terminaciones.Text = "20"
        btn_addarteleprtec.Enabled = False
        btn_addmatprtec.Enabled = False
        btn_addtrabprtec.Enabled = False
        btn_cancelarprtec.Enabled = False
        cargar_presupuestos_estado()
        btn_guardarprte.Enabled = False
        btn_evaluarcontradibujo.Enabled = False
        Session("Entero_Flag") = 0
        Session("Evaluado") = 0
        CHK_Depusodomigranesca.Enabled = False
        CHK_Instaeleccomple.Enabled = False
        CHK_Depusodomigranesca.Checked = False
        CHK_Instaeleccomple.Checked = False
        txt_dibujotecnico.ReadOnly = True
        btn_verdibujo.Enabled = False
        btn_cancelarprtec.Enabled = True
        dtg_ambientes.DataSource = Nothing
        dtg_ambientes.DataBind()
        dtg_armattrabprtec.DataSource = Nothing
        dtg_armattrabprtec.DataBind()
    End Sub
    Private Sub btn_addmatprtec_Click(sender As Object, e As EventArgs) Handles btn_addmatprtec.Click
        Dim lista_grilla As List(Of grilla) = Session("Grilla")
        Try
            Dim be_material As New BE.BE_Material_TrabajoconPrec
            Dim bll_material As New BLL.BLL_Material_TrabajoconPrec
            be_material = CType(Session("Lista_Materiales"), List(Of BE.BE_Material_TrabajoconPrec)).Find(Function(x) x.Descripcion = cbx_matprtec.SelectedItem.Text)
            Dim cambio As Boolean = False
            If String.IsNullOrWhiteSpace(num_matprtec.Text) OrElse num_matprtec.Text = 0 Then
                Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_valor0o>"))
                Exit Sub
            Else
                For Each elemento As grilla In CType(Session("Grilla"), List(Of grilla))
                    If elemento.col_id = be_material.id AndAlso elemento.col_descripcion = be_material.Descripcion AndAlso elemento.col_cantidad = num_matprtec.Text AndAlso elemento.col_tipo = "Material" Then
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_addmatex"))
                        Exit Sub
                    Else
                        If elemento.col_id = be_material.id AndAlso elemento.col_descripcion = be_material.Descripcion AndAlso elemento.col_cantidad <> num_matprtec.Text AndAlso elemento.col_tipo = "Material" Then
                            cambio = True
                        End If
                    End If
                Next
            End If
            be_material.cantidad = num_matprtec.Text
            be_material = bll_material.calcular_precio_cantidad(be_material)
            btn_guardarprte.Enabled = False

            If cambio = False Then
                Dim tmp_grilla As New grilla
                tmp_grilla.col_id = be_material.id
                tmp_grilla.col_descripcion = be_material.Descripcion
                tmp_grilla.col_cantidad = be_material.cantidad
                tmp_grilla.col_precio = be_material.Precio
                tmp_grilla.col_tipo = "Material"
                lista_grilla.Add(tmp_grilla)
                num_matprtec.Text = String.Empty
                dtg_armattrabprtec.DataSource = lista_grilla
                dtg_armattrabprtec.DataBind()
            Else
                For Each elemento As grilla In CType(Session("Grilla"), List(Of grilla))
                    If elemento.col_id = be_material.id AndAlso elemento.col_descripcion = be_material.Descripcion AndAlso elemento.col_tipo = "Material" Then
                        elemento.col_precio = be_material.Precio
                        elemento.col_cantidad = be_material.cantidad
                        dtg_armattrabprtec.DataSource = lista_grilla
                        dtg_armattrabprtec.DataBind()
                        num_matprtec.Text = 1
                        btn_evaluarcontradibujo.Enabled = True

                    End If
                Next
            End If
            Session("Evaluado") = 0
            num_matprtec.Text = 1
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

     
    End Sub

    Private Sub btn_addtrabprtec_Click(sender As Object, e As EventArgs) Handles btn_addtrabprtec.Click
        Dim lista_grilla As List(Of grilla) = Session("Grilla")
        Try
            Dim be_trabajo As New BE.BE_Material_TrabajoconPrec
            Dim bll_trabajo As New BLL.BLL_Material_TrabajoconPrec
            be_trabajo = CType(Session("Lista_Trabajos"), List(Of BE.BE_Material_TrabajoconPrec)).Find(Function(x) x.Descripcion = cbx_trabprtec.SelectedItem.Text)
            Dim cambio As Boolean = False
            If String.IsNullOrWhiteSpace(num_trabprtec.Text) OrElse num_trabprtec.Text = 0 Then
                Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_valor0o>"))
                Exit Sub
            Else
                For Each elemento As grilla In CType(Session("Grilla"), List(Of grilla))
                    If elemento.col_id = be_trabajo.id AndAlso elemento.col_descripcion = be_trabajo.Descripcion AndAlso elemento.col_cantidad = num_trabprtec.Text AndAlso elemento.col_tipo = "Trabajo" Then
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_trabexis"))
                        Exit Sub
                    Else
                        If elemento.col_id = be_trabajo.id AndAlso elemento.col_descripcion = be_trabajo.Descripcion AndAlso elemento.col_cantidad <> num_trabprtec.Text AndAlso elemento.col_tipo = "Trabajo" Then
                            cambio = True
                        End If
                    End If
                Next
            End If
            be_trabajo.cantidad = num_trabprtec.Text
            be_trabajo = bll_trabajo.calcular_precio_cantidad(be_trabajo)
            btn_guardarprte.Enabled = False

            If cambio = False Then
                Dim tmp_grilla As New grilla
                tmp_grilla.col_id = be_trabajo.id
                tmp_grilla.col_descripcion = be_trabajo.Descripcion
                tmp_grilla.col_cantidad = be_trabajo.cantidad
                tmp_grilla.col_precio = be_trabajo.Precio
                tmp_grilla.col_tipo = "Trabajo"
                lista_grilla.Add(tmp_grilla)
                num_trabprtec.Text = String.Empty
                dtg_armattrabprtec.DataSource = lista_grilla
                dtg_armattrabprtec.DataBind()
            Else
                For Each elemento As grilla In CType(Session("Grilla"), List(Of grilla))
                    If elemento.col_id = be_trabajo.id AndAlso elemento.col_descripcion = be_trabajo.Descripcion AndAlso elemento.col_tipo = "Trabajo" Then
                        elemento.col_precio = be_trabajo.Precio
                        elemento.col_cantidad = be_trabajo.cantidad
                        dtg_armattrabprtec.DataSource = lista_grilla
                        dtg_armattrabprtec.DataBind()
                        num_trabprtec.Text = 1
                        btn_evaluarcontradibujo.Enabled = True

                    End If
                Next
            End If
            Session("Evaluado") = 0
            num_trabprtec.Text = 1
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Protected Sub btn_evaluarcontradibujo_Click(sender As Object, e As EventArgs) Handles btn_evaluarcontradibujo.Click
        Try
            Dim bll_presupuesto As New BLL.BLL_Presupuesto
            If String.IsNullOrWhiteSpace(txt_caneria.Text) Then
                txt_caneria.Text = 0
            End If
            If String.IsNullOrWhiteSpace(txt_llaves.Text) Then
                txt_llaves.Text = 0
            End If
            If String.IsNullOrWhiteSpace(txt_losa.Text) Then
                txt_losa.Text = 0
            End If
            If String.IsNullOrWhiteSpace(txt_tableros.Text) Then
                txt_tableros.Text = 0
            End If
            If String.IsNullOrWhiteSpace(txt_terminaciones.Text) Then
                txt_terminaciones.Text = 0
            End If
            If Session("Entero_Flag") = 1 Or Session("Entero_Flag") = 2 Then
                Dim presupuesto As BE.BE_Presupuesto
                presupuesto = CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Find(Function(x) x.id = cmb_presupuesto.SelectedItem.Text)
                presupuesto.Instalacion_compleja = CHK_Instaeleccomple.Checked
                presupuesto.departamento_granescala = CHK_Depusodomigranesca.Checked
                presupuesto.Instalacion_compleja = CHK_Instaeleccomple.Checked
                presupuesto.porcentaje_caneriaycableado = txt_caneria.Text
                presupuesto.porcentaje_llaveytoma = txt_llaves.Text
                presupuesto.porcentaje_losa = txt_losa.Text
                presupuesto.porcentaje_tablero = txt_tableros.Text
                presupuesto.porcentaje_terminacion = txt_terminaciones.Text
                Dim lista_materiales_trabajos As New List(Of BE.BE_Material_TrabajoconPrec)
                Dim lista_artefactos As New List(Of BE.BE_ArtefactoElectrico)
                For Each elemento In CType(Session("Grilla"), List(Of grilla))
                    Select Case elemento.col_tipo
                        Case "Material"
                            Dim datos As BE.BE_Material_TrabajoconPrec = CType(Session("Lista_Materiales"), List(Of BE.BE_Material_TrabajoconPrec)).Find(Function(x) x.id = elemento.col_id AndAlso x.Descripcion = elemento.col_descripcion AndAlso x.Material = True)
                            Dim material As New BE.BE_Material_TrabajoconPrec
                            material.cantidad = elemento.col_cantidad
                            material.Precio = elemento.col_precio
                            material.id = datos.id
                            material.precio_cantidad = datos.precio_cantidad
                            material.Material = True
                            material.Trabajoconprecio = False
                            lista_materiales_trabajos.Add(material)
                        Case "Trabajo"
                            Dim datos As BE.BE_Material_TrabajoconPrec = CType(Session("Lista_Trabajos"), List(Of BE.BE_Material_TrabajoconPrec)).Find(Function(x) x.id = elemento.col_id AndAlso x.Descripcion = elemento.col_descripcion AndAlso x.Trabajoconprecio = True)
                            Dim trabajo As New BE.BE_Material_TrabajoconPrec
                            trabajo.cantidad = elemento.col_cantidad
                            trabajo.Precio = elemento.col_precio
                            trabajo.id = datos.id
                            trabajo.precio_cantidad = datos.precio_cantidad
                            trabajo.Material = False
                            trabajo.Trabajoconprecio = True
                            lista_materiales_trabajos.Add(trabajo)
                        Case "Artefacto"
                            Dim datos As BE.BE_ArtefactoElectrico = CType(Session("Lista_Artefactos"), List(Of BE.BE_ArtefactoElectrico)).Find(Function(x) x.id = elemento.col_id AndAlso x.descripcion = elemento.col_descripcion AndAlso elemento.col_tipo = "Artefacto")
                            Dim artefacto As New BE.BE_ArtefactoElectrico
                            artefacto.cantidad = elemento.col_cantidad
                            artefacto.precio = elemento.col_precio
                            artefacto.id = datos.id
                            artefacto.preciocantidad = datos.preciocantidad
                            lista_artefactos.Add(artefacto)
                    End Select
                Next
                presupuesto.Materiales_trabajo = lista_materiales_trabajos
                presupuesto.Artefacto_electrico = lista_artefactos
                presupuesto = bll_presupuesto.evaluar_presupuestovsdibujo(presupuesto)
                Select Case presupuesto.observacion.Substring(0, 1)
                    Case "C"
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("Cantidad_Artefactos_OK"))
                        Session("Evaluado") = 1
                        btn_guardarprte.Enabled = True
                    Case "-"
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("Cantidad_BocasDibujoMayor") & " " & presupuesto.observacion.Substring(1, presupuesto.observacion.Length - 1).ToString)
                        Session("Evaluado") = 1
                        btn_guardarprte.Enabled = True
                    Case Else
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("Cantidad_BocasDibujoMayor") & " " & presupuesto.observacion.ToString)
                        Session("Evaluado") = 1
                        btn_guardarprte.Enabled = True
                End Select
            End If


        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try
     


    End Sub

    Private Sub btn_guardarprte_Click(sender As Object, e As EventArgs) Handles btn_guardarprte.Click
        If String.IsNullOrWhiteSpace(txt_caneria.Text) Then
            txt_caneria.Text = 0
        End If
        If String.IsNullOrWhiteSpace(txt_llaves.Text) Then
            txt_llaves.Text = 0
        End If
        If String.IsNullOrWhiteSpace(txt_losa.Text) Then
            txt_losa.Text = 0
        End If
        If String.IsNullOrWhiteSpace(txt_tableros.Text) Then
            txt_tableros.Text = 0
        End If
        If String.IsNullOrWhiteSpace(txt_terminaciones.Text) Then
            txt_terminaciones.Text = 0
        End If
        If Session("Entero_Flag") = 1 Or Session("Entero_Flag") = 2 Then
            Dim be_presupuesto As BE.BE_Presupuesto
            Dim bll_presupuesto As New BLL.BLL_Presupuesto
            be_presupuesto = CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Find(Function(x) x.id = cmb_presupuesto.SelectedItem.Text)
            be_presupuesto.Instalacion_compleja = CHK_Instaeleccomple.Checked
            be_presupuesto.departamento_granescala = CHK_Depusodomigranesca.Checked
            be_presupuesto.Instalacion_compleja = CHK_Instaeleccomple.Checked
            be_presupuesto.porcentaje_caneriaycableado = txt_caneria.Text
            be_presupuesto.porcentaje_llaveytoma = txt_llaves.Text
            be_presupuesto.porcentaje_losa = txt_losa.Text
            be_presupuesto.porcentaje_tablero = txt_tableros.Text
            be_presupuesto.porcentaje_terminacion = txt_terminaciones.Text
            Select Case bll_presupuesto.actualizacion_responsabletecnico(be_presupuesto)
                Case 10147
                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_total<100"))
                Case 10146
                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_total<100"))
                Case 10149
                    Response.Redirect("web_error_inicio.aspx", False)
                Case 10150
                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_actuaok"))
                    btn_cancelarprtec_Click(Nothing, Nothing)
                Case Else
                    Response.Redirect("web_error_inicio.aspx", False)
            End Select
        End If
    End Sub

    Private Sub btn_verdibujo_Click(sender As Object, e As EventArgs) Handles btn_verdibujo.Click
        Dim lista_grillaevaluar As New List(Of grilla_evaluarplano)
        Dim be_presupuesto As BE.BE_Presupuesto
        be_presupuesto = CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Find(Function(x) x.id = cmb_presupuesto.SelectedItem.Text)
        For Each ambiente As BE.Be_Ambiente In be_presupuesto.dibujotecnico.ambiente
            For Each circuito As BE.BE_Circuito In ambiente.circuitos
                Dim grillaevaluar As New grilla_evaluarplano
                grillaevaluar.ambiente = ambiente.tipo
                grillaevaluar.tipo = circuito.tipo
                grillaevaluar.sigla = circuito.sigla
                grillaevaluar.cantidad_bocas = circuito.cantidad_bocas
                lista_grillaevaluar.Add(grillaevaluar)
            Next
        Next
        dtg_ambientes.DataSource = Nothing
        dtg_ambientes.DataBind()
        dtg_ambientes.DataSource = lista_grillaevaluar
        dtg_ambientes.DataBind()
    End Sub


    Private Class grilla_evaluarplano
        Private _ambiente As String
        Public Property ambiente() As String
            Get
                Return _ambiente
            End Get
            Set(ByVal value As String)
                _ambiente = value
            End Set
        End Property

        Private _sigla As String
        Public Property sigla() As String
            Get
                Return _sigla
            End Get
            Set(ByVal value As String)
                _sigla = value
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

        Private _cantidad_bocas As Integer
        Public Property cantidad_bocas() As Integer
            Get
                Return _cantidad_bocas
            End Get
            Set(ByVal value As Integer)
                _cantidad_bocas = value
            End Set
        End Property

    End Class

    Private Sub dtg_armattrabprtec_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles dtg_armattrabprtec.RowDeleting
        Try
            Dim elemento As grilla
            elemento = CType(Session("Grilla"), List(Of grilla)).Item(e.RowIndex)
            CType(Session("Grilla"), List(Of grilla)).Remove(elemento)
            If CType(Session("Grilla"), List(Of grilla)).Count = 0 Then
                dtg_armattrabprtec.DataSource = Nothing
                btn_evaluarcontradibujo.Enabled = False
            End If
            dtg_armattrabprtec.DataSource = Session("Grilla")
            dtg_armattrabprtec.DataBind()
            btn_guardarprte.Enabled = False

        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try
        
    End Sub
End Class