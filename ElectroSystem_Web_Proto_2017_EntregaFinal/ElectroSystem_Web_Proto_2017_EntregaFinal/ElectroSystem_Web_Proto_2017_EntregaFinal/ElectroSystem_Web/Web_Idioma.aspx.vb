Public Class Web_Idioma

    Inherits System.Web.UI.Page
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True
    Dim usu As BE.BE_Usuario
    Dim idiomas As List(Of BE.BE_Idioma)
    Dim idioma As New BE.BE_Idioma
    Dim idioma_agregable As New BE.BE_Idioma
    ' si es 0 es que no hace nada, si es 1 es que agrega, si es 2 es que modifica, 3 elimina
    Dim entero_flag As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_gestidioma")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        Session.Add("Entero_Flag", entero_flag)
                        formatoinicial()
                        Session.Add("Idioma_Modificable", idioma)
                        Session.Add("Idioma_Agregable", idioma_agregable)
                        btn_cancelar_Click(Nothing, Nothing)
                        ' cargar_grilla(grilla_idioma)
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



    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Try
            If String.IsNullOrWhiteSpace(txt_idioma.Text) Then
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_formatoinvalido")
            Else
                Dim be_bitacora As New BE.BE_Bitacora
                Dim bll_bitacora As New BLL.BLL_Bitacora
                Try
                    Select Case Session("Entero_Flag")
                        Case 0
                            Response.Write("<script language='JavaScript'>alert('No se ha realizado ninguna modificación ni alta.');</script>")
                        Case 1
                            Dim idioma As BE.BE_Idioma
                            idioma = Session("Idioma_Agregable")
                            idioma.Idioma = txt_idioma.Text
                            idioma.id_idioma = Nothing
                            'Dim lista_etiqueta As New List(Of BE.BE_Etiqueta)
                            'For Each fila As DataRow In grilla_carga.Rows
                            '    Dim etiqueta As New BE.BE_Etiqueta
                            '    etiqueta.id_control = fila(0)
                            '    etiqueta.nombre_traduccion = fila(1)
                            '    lista_etiqueta.Add(etiqueta)
                            'Next
                            'idioma.be_etiqueta = lista_etiqueta
                            Dim bll_idioma As New BLL.BLL_Etiqueta
                            Select Case bll_idioma.alta(idioma)
                                Case 1
                                    be_bitacora.codigo_evento = 7001
                                    be_bitacora.usuario = Session("Usuario")
                                    bll_bitacora.alta(be_bitacora)
                                    formatoinicial()
                                    DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_idiomaduplicado")

                                Case 2
                                    be_bitacora.codigo_evento = 7002
                                    be_bitacora.usuario = Session("Usuario")
                                    bll_bitacora.alta(be_bitacora)
                                    Response.Redirect("web_error_inicio.aspx", False)
                                Case 0
                                    Dim idiomas As List(Of BE.BE_Idioma)
                                    Dim idiom As New BLL.BLL_Gestor_Formulario
                                    idiomas = idiom.consultar_idiomas()
                                    Dim lista As List(Of BE.BE_Idioma)
                                    lista = Application("Idiomas")
                                    lista.Clear()
                                    lista.AddRange(idiomas)
                                    Application("Idiomas") = lista
                                    be_bitacora.codigo_evento = 7003
                                    be_bitacora.usuario = Session("Usuario")
                                    bll_bitacora.alta(be_bitacora)

                                    '     Response.Write("<div id='modal-box' style='background-color:red; position: absolute; padding-top: 100px; z-index: 1000;'>" & DirectCast(Me.Master, General_Electrosystem).Traductora("msg_altaidiomaok") & "</div>")
                                    formatoinicial()
                                    DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_altaidiomaok")

                            End Select
                        Case 2
                            Dim idioma_seleccionado As BE.BE_Idioma
                            'Dim etiqueta_deldatarow As BE.BE_Etiqueta
                            idioma_seleccionado = Session("Idioma_Modificable")
                            idioma_seleccionado.Idioma = txt_idioma.Text
                            'For Each etiqueta As BE.BE_Etiqueta In idioma_seleccionado.be_etiqueta
                            '    For Each fila As DataRow In grilla_carga.Rows
                            '        etiqueta_deldatarow = idioma_seleccionado.be_etiqueta.Find(Function(x) x.id_control = fila(0))
                            '        etiqueta_deldatarow.nombre_traduccion = fila(1)
                            '        etiqueta = etiqueta_deldatarow
                            '    Next
                            'Next
                            Dim bll_idioma As New BLL.BLL_Etiqueta
                            Select Case bll_idioma.modificar(idioma_seleccionado)
                                Case 1
                                    be_bitacora.codigo_evento = 7004
                                    be_bitacora.usuario = Session("Usuario")
                                    bll_bitacora.alta(be_bitacora)
                                    formatoinicial()
                                    DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_idiomaduplicado")

                                Case 2
                                    be_bitacora.codigo_evento = 7005
                                    be_bitacora.usuario = Session("Usuario")
                                    bll_bitacora.alta(be_bitacora)
                                    Response.Redirect("web_error_inicio.aspx", False)
                                Case 0
                                    Dim idiomas As List(Of BE.BE_Idioma)
                                    Dim idiom As New BLL.BLL_Gestor_Formulario
                                    idiomas = idiom.consultar_idiomas()
                                    Dim lista As List(Of BE.BE_Idioma)
                                    lista = Application("Idiomas")
                                    lista.Clear()
                                    lista.AddRange(idiomas)
                                    Application("Idiomas") = lista
                                    be_bitacora.codigo_evento = 10163
                                    be_bitacora.usuario = Session("Usuario")
                                    bll_bitacora.alta(be_bitacora)
                                    If drp_idioma.Text = CType(Session("Usuario"), BE.BE_Usuario).Idioma.Idioma Then
                                        If drp_idioma.Text <> txt_idioma.Text Then
                                            CType(Session("Usuario"), BE.BE_Usuario).Idioma = lista.Find(Function(x) x.Idioma = txt_idioma.Text)
                                        Else
                                            CType(Session("Usuario"), BE.BE_Usuario).Idioma = lista.Find(Function(x) x.Idioma = drp_idioma.Text)
                                        End If
                                        formatoinicial()
                                        DirectCast(Me.Master, General_Electrosystem).mostrarmodalredireccion("msg_modificaidiomaok", "web_inicio.aspx")
                                        ' Response.Redirect("Web_Inicio.aspx", False)
                                    Else
                                        formatoinicial()
                                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_modificaidiomaok")

                                    End If

                            End Select
                    End Select
                Catch ex As Exception
                    Response.Redirect("web_error_inicio.aspx")
                End Try
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx")
        End Try


    End Sub

    Sub formatoinicial()
        Try
            txt_idioma.Text = ""
            txt_idioma.Enabled = False
            drp_idioma.Enabled = True
            btn_nuevo.Enabled = True
            btn_guardar.Enabled = False
            btn_eliminar.Enabled = False
            btn_cancelar.Enabled = False
            Session("Entero_Flag") = 0
            Dim lista As List(Of BE.BE_Idioma)
            lista = Application("Idiomas")
            Session("Idioma_Modificable") = Nothing
            Session("Idioma_Agregable") = Nothing
            drp_idioma.Items.Clear()
            drp_idioma.Items.Add("N/A")
            For Each elemento As BE.BE_Idioma In lista
                drp_idioma.Items.Add(elemento.Idioma)
            Next
            DirectCast(Me.Master, General_Electrosystem).traducir_grilla(grilla_carga)

            grilla_carga.DataSource = Nothing
            grilla_carga.DataBind()
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx")

        End Try

    End Sub
    Private Sub cargar_grilla(grilla As GridView)
        Try
            Dim lista_idiomas As New List(Of BE.BE_Idioma)
            lista_idiomas = Application("Idiomas")
            Dim lista_grilla As New List(Of grilla)
            If Session("Entero_Flag") = 1 Then
                grilla_carga.DataSource = Nothing
                grilla_carga.DataBind()
                DirectCast(Me.Master, General_Electrosystem).traducir_grilla(grilla_carga)
                Dim idioma As New BE.BE_Idioma
                Dim idi As BE.BE_Idioma
                idi = lista_idiomas.Find(Function(x) x.id_idioma = 1)
                idioma.id_idioma = idi.id_idioma
                idioma.Idioma = idi.Idioma
                idioma.be_etiqueta = New List(Of BE.BE_Etiqueta)
                For Each etiqueta As BE.BE_Etiqueta In idi.be_etiqueta
                    Dim tmp_etiqueta As New BE.BE_Etiqueta
                    tmp_etiqueta.id_control = etiqueta.id_control
                    tmp_etiqueta.nombre_traduccion = etiqueta.nombre_traduccion
                    idioma.be_etiqueta.Add(tmp_etiqueta)
                Next
                Session.Add("Idioma_Agregable", idioma)
                Session("Idioma_Modificable") = Nothing
                grilla_carga.DataSource = idioma.be_etiqueta
                grilla_carga.DataBind()
            Else
                grilla_carga.DataSource = Nothing
                grilla_carga.DataBind()
                DirectCast(Me.Master, General_Electrosystem).traducir_grilla(grilla_carga)
                Dim idioma As BE.BE_Idioma
                Session("Idioma_Agregable") = Nothing
                idioma = Session("Idioma_Modificable")
                grilla_carga.DataSource = idioma.be_etiqueta
                grilla_carga.DataBind()
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx")
        End Try

    End Sub


    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        Try
            txt_idioma.Enabled = True
            txt_idioma.Text = ""
            drp_idioma.Enabled = False
            btn_nuevo.Enabled = False
            btn_guardar.Enabled = True
            btn_eliminar.Enabled = False
            grilla_carga.Enabled = True
            grilla_carga.DataSource = Nothing
            grilla_carga.DataBind()
            Session("Entero_Flag") = 1
            cargar_grilla(grilla_carga)
            btn_cancelar.Enabled = True
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx")

        End Try

    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Try
            If drp_idioma.SelectedValue = "Español" Or drp_idioma.SelectedValue = "English" Then
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_idiomaconusuarios")
                formatoinicial()
            Else
                Dim be_bitacora As New BE.BE_Bitacora
                Dim bll_bitacora As New BLL.BLL_Bitacora
                Dim idioma_seleccionado As BE.BE_Idioma
                idioma_seleccionado = DirectCast(Application("Idiomas"), List(Of BE.BE_Idioma)).Find(Function(x) x.Idioma = drp_idioma.SelectedValue)
                Dim bll_idioma As New BLL.BLL_Etiqueta
                Select Case bll_idioma.baja(idioma_seleccionado)
                    Case 1
                        be_bitacora.codigo_evento = 7006
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        formatoinicial()
                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_idiomaconusuarios")

                    Case 2
                        be_bitacora.codigo_evento = 7007
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Redirect("web_error_inicio.aspx", False)
                    Case 0
                        Dim idiomas As List(Of BE.BE_Idioma)
                        Dim idiom As New BLL.BLL_Gestor_Formulario
                        idiomas = idiom.consultar_idiomas()
                        Dim lista As List(Of BE.BE_Idioma)
                        lista = Application("Idiomas")
                        lista.Clear()
                        lista.AddRange(idiomas)
                        be_bitacora.codigo_evento = 7008
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        formatoinicial()
                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_bajaidioma")

                End Select
            End If

        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx")

        End Try
    End Sub

    Private Sub drp_idioma_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drp_idioma.SelectedIndexChanged
        If drp_idioma.SelectedValue = "N/A" Then

        Else
            txt_idioma.Enabled = True
            drp_idioma.Enabled = False
            txt_idioma.Text = drp_idioma.SelectedValue
            Dim idioma As New BE.BE_Idioma
            idioma.Idioma = drp_idioma.SelectedValue
            idioma.id_idioma = CType(Application("Idiomas"), List(Of BE.BE_Idioma)).Find(Function(x) x.Idioma = drp_idioma.SelectedValue).id_idioma
            idioma.be_etiqueta = New List(Of BE.BE_Etiqueta)
            For Each objeto As BE.BE_Etiqueta In CType(Application("Idiomas"), List(Of BE.BE_Idioma)).Find(Function(x) x.Idioma = drp_idioma.SelectedValue).be_etiqueta
                Dim tmp_etiqueta As New BE.BE_Etiqueta
                tmp_etiqueta.id_control = objeto.id_control
                tmp_etiqueta.nombre_traduccion = objeto.nombre_traduccion
                idioma.be_etiqueta.Add(tmp_etiqueta)
            Next
            Session("Idioma_Modificable") = Nothing
            Session.Add("Idioma_Modificable", idioma)
            Session("Entero_Flag") = 2
            cargar_grilla(grilla_carga)
            btn_nuevo.Enabled = False
            btn_guardar.Enabled = True
            btn_eliminar.Enabled = True
            btn_cancelar.Enabled = True
        End If

    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        formatoinicial()
    End Sub

    Private Sub grilla_carga_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grilla_carga.RowEditing
        Try
            If Session("Entero_Flag") = 2 Then
                grilla_carga.EditIndex = e.NewEditIndex
                Dim idioma As BE.BE_Idioma
                idioma = Session("Idioma_Modificable")
                grilla_carga.DataSource = idioma.be_etiqueta
                grilla_carga.DataBind()
            Else
                grilla_carga.EditIndex = e.NewEditIndex
                Dim idioma As BE.BE_Idioma
                idioma = Session("Idioma_Agregable")
                grilla_carga.DataSource = idioma.be_etiqueta
                grilla_carga.DataBind()
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx")

        End Try

      
    End Sub

    Private Sub grilla_carga_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grilla_carga.RowCancelingEdit
        Try
            If Session("Entero_Flag") = 2 Then
                grilla_carga.EditIndex = -1
                Dim idioma As BE.BE_Idioma
                idioma = Session("Idioma_Modificable")
                grilla_carga.DataSource = idioma.be_etiqueta
                grilla_carga.DataBind()
            Else
                grilla_carga.EditIndex = -1
                Dim idioma As BE.BE_Idioma
                idioma = Session("Idioma_Agregable")
                grilla_carga.DataSource = idioma.be_etiqueta
                grilla_carga.DataBind()
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx")

        End Try
       
    End Sub

    Private Sub grilla_carga_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grilla_carga.RowUpdating
        Try
            Dim row = grilla_carga.Rows(e.RowIndex)
            If Session("Entero_Flag") = 2 Then
                Dim idioma As BE.BE_Idioma
                idioma = Session("Idioma_Modificable")
                idioma.be_etiqueta.Find(Function(x) x.id_control = row.Cells(1).Text).nombre_traduccion = (CType((row.Cells(2).Controls(0)), TextBox)).Text
                grilla_carga.EditIndex = -1
                grilla_carga.DataSource = idioma.be_etiqueta
                grilla_carga.DataBind()
            Else
                Dim idioma As BE.BE_Idioma
                idioma = Session("Idioma_Agregable")
                idioma.be_etiqueta.Find(Function(x) x.id_control = row.Cells(1).Text).nombre_traduccion = (CType((row.Cells(2).Controls(0)), TextBox)).Text
                grilla_carga.EditIndex = -1
                grilla_carga.DataSource = idioma.be_etiqueta
                grilla_carga.DataBind()
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx")

        End Try
       
    End Sub
End Class