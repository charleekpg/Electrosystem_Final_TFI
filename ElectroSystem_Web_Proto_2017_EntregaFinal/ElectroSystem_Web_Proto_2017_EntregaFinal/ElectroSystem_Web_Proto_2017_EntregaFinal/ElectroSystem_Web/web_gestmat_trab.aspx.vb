Public Class web_gestarte
    Inherits System.Web.UI.Page
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True
    Dim usu As BE.BE_Usuario
    Dim listado As New List(Of BE.BE_Material_TrabajoconPrec)
    Dim elemento_seleccionado As BE.BE_Material_TrabajoconPrec
    Dim entero_flag As Integer = 0
    Dim modificarmat_trabajo As Boolean = False


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_gestmattrab")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        Session.Add("Entero_Flag", entero_flag)
                        DirectCast(Me.Master, General_Electrosystem).traducir_grilla(dtg_trabajo_material)
                        cargarmaterial_trabajo()
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

    Sub cargarmaterial_trabajo()
        Try
            Dim bll_material_trabajo As New BLL.BLL_Material_TrabajoconPrec
            Dim lista As List(Of BE.BE_Material_TrabajoconPrec) = bll_material_trabajo.consultartodos()
            listado.Clear()
            Dim i As Integer = 0
            For Each elemento In lista
                listado.Add(elemento)
            Next
            Session("Listado") = listado
            If lista.Count > 0 Then
                dtg_trabajo_material.DataSource = lista
                dtg_trabajo_material.DataBind()
            End If
            btn_nuevotrab.Enabled = True
            dtg_trabajo_material.Enabled = True
            btn_guardartrab.Enabled = False
            btn_cancelartrab.Enabled = False
            rdb_material.Enabled = False
            rdb_trabajo.Enabled = False
            txt_descripcion.Enabled = False
            num_precio.Enabled = False
            rdb_material.Checked = False
            rdb_trabajo.Checked = False
            rdb_material.Enabled = False
            rdb_trabajo.Enabled = False
            txt_descripcion.Text = ""
            num_precio.Text = "0"
            modificarmat_trabajo = False
            Session("Elemento_Seleccionado") = Nothing
            Session("Modificar") = False
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Protected Sub btn_nuevotrab_Click(sender As Object, e As EventArgs) Handles btn_nuevotrab.Click
        btn_nuevotrab.Enabled = False
        dtg_trabajo_material.Enabled = False
        btn_guardartrab.Enabled = True
        btn_cancelartrab.Enabled = True
        rdb_material.Enabled = True
        rdb_trabajo.Enabled = True
        txt_descripcion.Enabled = True
        num_precio.Enabled = True
        rdb_material.Checked = True
        rdb_trabajo.Checked = False
        rdb_material.Enabled = True
        rdb_trabajo.Enabled = True
        Session("Elemento_Seleccionado") = Nothing
        Session("Modificar") = False

    End Sub

    Protected Sub btn_cancelartrab_Click(sender As Object, e As EventArgs) Handles btn_cancelartrab.Click
        cargarmaterial_trabajo()
    End Sub

    Private Sub rdb_material_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_material.CheckedChanged
        rdb_material.Checked = True
        rdb_trabajo.Checked = False
    End Sub

    Private Sub rdb_trabajo_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_trabajo.CheckedChanged
        rdb_material.Checked = False
        rdb_trabajo.Checked = True
    End Sub

    Protected Sub btn_guardartrab_Click(sender As Object, e As EventArgs) Handles btn_guardartrab.Click

        Try
            If String.IsNullOrWhiteSpace(txt_descripcion.Text) = True Then
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_camposincompletos")
                cargarmaterial_trabajo()
            Else
                Dim be_etiqueta As New BE.BE_Etiqueta
                Dim bll_etiqueta As New BLL.BLL_Etiqueta
                Dim bll_material_trabajo As New BLL.BLL_Material_TrabajoconPrec
                Dim be_bitacora As New BE.BE_Bitacora
                Dim bll_bitacora As New BLL.BLL_Bitacora
                Select Case txt_descripcion.Text
                    Case ""
                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_camposincompletos")
                        cargarmaterial_trabajo()
                    Case Else
                        If Session("Modificar") = False Then

                            If rdb_material.Checked = False And rdb_trabajo.Checked = False Then
                                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_faltardb")
                                cargarmaterial_trabajo()
                            Else

                                Dim be_material_trabajo As New BE.BE_Material_TrabajoconPrec
                                be_material_trabajo.Material = rdb_material.Checked
                                be_material_trabajo.Trabajoconprecio = rdb_trabajo.Checked
                                be_material_trabajo.Descripcion = txt_descripcion.Text
                                be_material_trabajo.Precio = num_precio.Text
                                If num_precio.Text <= 0 Then
                                    DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_valorcero")
                                    cargarmaterial_trabajo()
                                    GoTo 1
                                Else
                                    Select Case bll_material_trabajo.alta(be_material_trabajo)
                                        Case 10110
                                            be_bitacora.codigo_evento = 10110
                                            be_bitacora.usuario = Session("Usuario")
                                            bll_bitacora.alta(be_bitacora)
                                            DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_altacorrecta")
                                            cargarmaterial_trabajo()
                                        Case 10112
                                            be_bitacora.codigo_evento = 10112
                                            be_bitacora.usuario = Session("Usuario")
                                            bll_bitacora.alta(be_bitacora)
                                            DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_material_trabajo_existente")
                                            cargarmaterial_trabajo()
                                        Case 10111
                                            be_bitacora.codigo_evento = 10111
                                            be_bitacora.usuario = Session("Usuario")
                                            bll_bitacora.alta(be_bitacora)
                                            Response.Redirect("web_error_inicio.aspx", False)
                                    End Select
                                End If

                            End If
                        Else

                            elemento_seleccionado = Session("Elemento_Seleccionado")
                            If elemento_seleccionado.Material <> rdb_material.Checked And elemento_seleccionado.Trabajoconprecio <> rdb_trabajo.Checked Then
                                elemento_seleccionado.cambiodetipo = True
                            Else
                                elemento_seleccionado.cambiodetipo = False
                            End If
                            elemento_seleccionado.Material = rdb_material.Checked
                            elemento_seleccionado.Trabajoconprecio = rdb_trabajo.Checked
                            elemento_seleccionado.Descripcion = txt_descripcion.Text
                            elemento_seleccionado.Precio = num_precio.Text
                            If num_precio.Text <= 0 Then
                                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_valorcero")
                                cargarmaterial_trabajo()
                                GoTo 1
                            Else
                                Select Case bll_material_trabajo.modificar(elemento_seleccionado)
                                    Case 10113
                                        be_bitacora.codigo_evento = 10113
                                        be_bitacora.usuario = Session("Usuario")
                                        bll_bitacora.alta(be_bitacora)
                                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_modificaok")
                                        cargarmaterial_trabajo()
                                    Case 10112
                                        be_bitacora.codigo_evento = 10112
                                        be_bitacora.usuario = Session("Usuario")
                                        bll_bitacora.alta(be_bitacora)
                                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_material_trabajo_existente")
                                        cargarmaterial_trabajo()
                                    Case 10114
                                        be_bitacora.codigo_evento = 10114
                                        be_bitacora.usuario = Session("Usuario")
                                        bll_bitacora.alta(be_bitacora)
                                        Response.Redirect("web_error_inicio.aspx", False)
                                End Select
                            End If

                        End If
                End Select
            End If

1:
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Private Sub dtg_trabajo_material_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dtg_trabajo_material.SelectedIndexChanged
        Try
            listado = Session("Listado")
            elemento_seleccionado = listado.Find(Function(x) x.Descripcion = dtg_trabajo_material.SelectedRow.Cells(1).Text)
            Session("Elemento_seleccionado") = elemento_seleccionado
            txt_descripcion.Text = elemento_seleccionado.Descripcion
            txt_descripcion.Enabled = True
            num_precio.Enabled = True
            num_precio.Text = elemento_seleccionado.Precio.ToString
            Session("Modificar") = True
            If elemento_seleccionado.Material = True Then
                rdb_material.Checked = True
                rdb_trabajo.Checked = False

            Else
                rdb_trabajo.Checked = True
                rdb_material.Checked = False
            End If
            rdb_material.Enabled = True
            rdb_trabajo.Enabled = True
            btn_nuevotrab.Enabled = False
            btn_cancelartrab.Enabled = True
            btn_guardartrab.Enabled = True
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub
End Class