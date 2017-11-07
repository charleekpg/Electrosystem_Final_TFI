Public Class web_Presupuestovalor
    Inherits System.Web.UI.Page
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True
    Dim usu As BE.BE_Usuario
    Dim idiomas As List(Of BE.BE_Idioma)
    Dim entero_flag As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_presucomercial")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        Session.Add("Entero_Flag", entero_flag)
                        cargar_partidos()

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

    Sub cargar_partidos()
        Try
            cbx_parti.Items.Clear()
            cbx_localidad.Items.Clear()
            Dim bll_partidos As New BLL.bll_partido
            Dim lista_partido As List(Of BE.BE_Partido)
            lista_partido = Application("Partidos")
            If Not lista_partido Is Nothing Then
                cbx_parti.DataSource = lista_partido
                cbx_parti.DataTextField = "partido"
                cbx_parti.DataBind()
                cargar_localidad(lista_partido.Item(0))
            Else
                Response.Redirect("web_error_inicio.aspx", False)
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Sub cargar_localidad(unbe As BE.BE_Partido)
        Try
            cbx_localidad.Items.Clear()
            For Each localidad As BE.be_localidad In unbe.localidades
                cbx_localidad.Items.Add(localidad.localidad)
            Next
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Protected Sub btn_cancelarpres_Click(sender As Object, e As EventArgs) Handles btn_cancelarprtec.Click
        Session("Grilla") = Nothing
        Session("Grilla") = New List(Of grilla)
        cargar_presupuestos_estado()
        chk_actuaindice.Enabled = False
        chk_cobroadel.Enabled = False
        chk_preciosegvida.Enabled = False
        chk_viatico.Enabled = False
        chk_actuaindice.Checked = False
        chk_cobroadel.Checked = False
        chk_preciosegvida.Checked = False
        chk_viatico.Checked = False
        txt_poradelanto.Enabled = False
        txt_poradelanto.Text = 0
        txt_valorseg.Enabled = False
        txt_valorseg.Text = 0
        txt_valorvia.Enabled = False
        txt_valorvia.Text = 0
        grd_presupuesto_final.DataSource = Nothing
        grd_presupuesto_final.DataBind()
        btn_calcvaltot.Enabled = False
        btn_cancelarprtec.Enabled = True
        btn_cargar_presupuesto.Enabled = True
        cmb_presupuesto.Enabled = True
        btn_guardarpresucom.Enabled = False
        cbx_localidad.Enabled = False
        cbx_parti.Enabled = False

    End Sub

    Sub cargar_presupuestos_estado()
        Try
            Dim bll_presupuesto As New BLL.BLL_Presupuesto
            Dim presupuesto As New BE.BE_Presupuesto
            Dim LISTA_PRESUPUESTO As List(Of BE.BE_Presupuesto)
            Session("Lista_Presupuestos_1") = Nothing
            presupuesto.estado_presupuesto = "Pendiente de llenado por parte del Responsable Comercial"
            LISTA_PRESUPUESTO = bll_presupuesto.consultar_varios(presupuesto)
            If LISTA_PRESUPUESTO.Count > 0 Then
                Session("Lista_Presupuestos_1") = LISTA_PRESUPUESTO
                LISTA_PRESUPUESTO.Sort(Function(x, y) x.id.CompareTo(y.id))
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

    Protected Sub btn_cargar_presupuesto_Click(sender As Object, e As EventArgs) Handles btn_cargar_presupuesto.Click
        Try
            btn_cargar_presupuesto.Enabled = False
            cmb_presupuesto.Enabled = False
            Dim presupuesto As BE.BE_Presupuesto
            btn_cargar_presupuesto.Enabled = False
            presupuesto = CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Find(Function(x) x.id = cmb_presupuesto.SelectedItem.Text)
            If presupuesto.estado_presupuesto = "Pendiente de llenado por Parte del Responsable Comercial" Then
                Session("Entero_Flag") = 1
                chk_actuaindice.Enabled = True
                chk_cobroadel.Enabled = True
                chk_preciosegvida.Enabled = True
                chk_viatico.Enabled = True
                cmb_presupuesto.Enabled = False
                btn_cargar_presupuesto.Enabled = False
                btn_cancelarprtec.Enabled = True
                btn_calcvaltot.Enabled = True
                btn_guardarpresucom.Enabled = False
                cbx_parti.Enabled = True
                cbx_localidad.Enabled = True
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

    Private Sub cbx_parti_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_parti.SelectedIndexChanged
        Try
            cargar_localidad(CType(Application("Partidos"), List(Of BE.BE_Partido)).Find(Function(x) x.partido = cbx_parti.SelectedItem.Text))
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Private Sub chk_cobroadel_CheckedChanged(sender As Object, e As EventArgs) Handles chk_cobroadel.CheckedChanged
        If chk_cobroadel.Checked = True Then
            txt_poradelanto.Enabled = True
            txt_poradelanto.Text = 1
        Else
            txt_poradelanto.Enabled = False
            txt_poradelanto.Text = 0
        End If
    End Sub

    Private Sub chk_preciosegvida_CheckedChanged(sender As Object, e As EventArgs) Handles chk_preciosegvida.CheckedChanged
        If chk_preciosegvida.Checked = True Then
            txt_valorseg.Enabled = True
            txt_valorseg.Text = 1
        Else
            txt_valorseg.Enabled = False
            txt_valorseg.Text = 0
        End If
    End Sub

    Private Sub chk_viatico_CheckedChanged(sender As Object, e As EventArgs) Handles chk_viatico.CheckedChanged
        If chk_viatico.Checked = True Then
            txt_valorvia.Enabled = True
            txt_valorvia.Text = 1
        Else
            txt_valorvia.Enabled = False
            txt_valorvia.Text = 0
        End If
    End Sub

    Protected Sub btn_calcvaltot_Click(sender As Object, e As EventArgs) Handles btn_calcvaltot.Click
        Try
            Dim bll_presupuesto As New BLL.BLL_Presupuesto
            Dim bll_calculardistancia As New BLL.BLL_Domicilio
            Dim be_domicilio As New BE.BE_Domicilio
            be_domicilio.localidad = cbx_localidad.SelectedItem()
            If bll_calculardistancia.calcular_distancia(presupuesto.Domicilio, be_domicilio) > 20 Then
                presupuesto.masde20km = True
            Else
                presupuesto.masde20km = False
            End If
            bll_presupuesto.calcularvalores(presupuesto)
            txt_valmano.Text = presupuesto.valor_manodeobra
            txt_valormat.Text = presupuesto.valor_material
            txt_valorseg.Text = presupuesto.valor_seguro_vida
            txt_valorprecest.Text = presupuesto.valor_trabajoconprecio
            txt_valorvia.Text = presupuesto.valor_otros
            habilitar_controles()
        Catch ex As Exception
            MsgBox(traductor.traducir_msgbox("msg_error"), , "Electrosystem")
            Me.Close()
        End Try


    End Sub
End Class