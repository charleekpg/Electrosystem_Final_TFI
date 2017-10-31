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
            Session("Lista_Presupuestos_1") = Nothing
            presupuesto.estado_presupuesto = "Pendiente de llenado por Parte del Responsable Técnico"
            Session("Lista_Presupuestos_1") = bll_presupuesto.consultar_varios(presupuesto)
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
            Else
                Session("Entero_Flag") = 2
                txt_caneria.Text = presupuesto.porcentaje_caneriaycableado
                txt_llaves.Text = presupuesto.porcentaje_llaveytoma
                txt_losa.Text = presupuesto.porcentaje_losa
                txt_tableros.Text = presupuesto.porcentaje_tablero
                txt_terminaciones.Text = presupuesto.porcentaje_terminacion
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
                CHK_Depusodomigranesca.Checked = presupuesto.departamento_granescala
                CHK_Instaeleccomple.Checked = presupuesto.Instalacion_compleja
                dtg_armattrabprtec.DataSource = lista_grilla
                dtg_armattrabprtec.DataBind()
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Private Sub dtg_trabajo_RowUpdated(sender As Object, e As GridViewUpdatedEventArgs) Handles dtg_trabajo.RowUpdated

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
            be_artefacto = bll_artefacto.calcular_precio_cantidad(be_artefacto)
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
            Else
                For Each elemento As grilla In CType(Session("Grilla"), List(Of grilla))
                    If elemento.col_id = be_artefacto.id AndAlso elemento.col_descripcion = be_artefacto.descripcion AndAlso elemento.col_tipo = "Artefacto" Then
                        elemento.col_precio = be_artefacto.precio
                        elemento.col_cantidad = be_artefacto.cantidad
                        dtg_armattrabprtec.DataSource = lista_grilla
                        dtg_armattrabprtec.DataBind()
                        num_arteprtec.Text = String.Empty
                    End If
                Next
            End If
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
            be_material = bll_material.calcular_precio_cantidad(be_material)
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
                        num_matprtec.Text = String.Empty
                    End If
                Next
            End If
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
            be_trabajo = bll_trabajo.calcular_precio_cantidad(be_trabajo)
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
                        num_trabprtec.Text = String.Empty
                    End If
                Next
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Protected Sub btn_evaluarcontradibujo_Click(sender As Object, e As EventArgs) Handles btn_evaluarcontradibujo.Click
        If Session("Entero_Flag") = 1 Then
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
                        Dim datos As BE.BE_ArtefactoElectrico = CType(Session("Lista_Artefactos"), List(Of BE.BE_ArtefactoElectrico)).Find(Function(x) x.id = elemento.col_id AndAlso x.descripcion = elemento.col_descripcion AndAlso elemento.col_tipo = "Material")
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
        End If
    End Sub
End Class