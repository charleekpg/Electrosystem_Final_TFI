Public Class web_usuario
    Inherits System.Web.UI.Page
    Dim usu As BE.BE_Usuario
    Private cambio As Boolean
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_opcion_usuarios")

                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)

                        cargar_lista()
                        cargar_idioma()
                        cargar_permisoscompuestos()
                        formato_inicial()
                        cambio = False
                        Session.Add("Cambio", cambio)
                    Else
                        Response.Redirect("web_login.aspx", False)
                    End If
                End If
            Else
                '  DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                Me.entro = True
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Private Sub formato_inicial()
        txt_password.Enabled = False
        txt_usuario.Enabled = False
        drp_idioma.Enabled = False
        btn_nuevous.Enabled = True
        btn_guardarus.Enabled = False
        btn_eliminar.Enabled = False
        btn_cancelarus.Enabled = False
        lst_users.SelectionMode = ListSelectionMode.Single
        txt_password.Text = ""
        txt_usuario.Text = ""
        chk_bloqueado.Checked = False
        chk_bloqueado.Enabled = False
        Session("Cambio") = False
        drp_roles.Enabled = False
        If lst_users.SelectedItem IsNot Nothing Then
            lst_users.SelectedItem.Selected = False
        End If

    End Sub
    Protected Sub btn_nuevous_Click(sender As Object, e As EventArgs) Handles btn_nuevous.Click
        txt_password.Enabled = True
        txt_usuario.Enabled = True
        drp_idioma.Enabled = True
        Session("Cambio") = False
        btn_guardarus.Enabled = True
        btn_nuevous.Enabled = False
        btn_cancelarus.Enabled = True
        chk_bloqueado.Enabled = True
        drp_roles.Enabled = True
        lst_users.Enabled = False

    End Sub

    Sub cargar_idioma()
        drp_idioma.Items.Clear()
        drp_idioma.DataSource = Nothing
        Dim lista_idioma As List(Of BE.BE_Idioma)
        lista_idioma = Application("Idiomas")
        drp_idioma.DataSource = lista_idioma
        drp_idioma.DataTextField = "Idioma"
        drp_idioma.DataBind()
    End Sub

    Private Sub cargar_permisoscompuestos()
        Try
            Dim bll_permisos As New BLL.BLL_Permisos
            Dim lista_permisoscompuestos As List(Of BE.BE_Permisocompuesto)
            lista_permisoscompuestos = bll_permisos.listar_permisoscompuestos()
            Session.Add("Roles", lista_permisoscompuestos)
            drp_roles.Items.Clear()
            drp_roles.DataSource = lista_permisoscompuestos
            drp_roles.DataValueField = "Descripcion"
            drp_roles.DataBind()
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Sub cargar_lista()
        Try
            lst_users.Items.Clear()
            lst_users.DataSource = Nothing
            Dim bll_usuarios As New BLL.BLL_Usuario
            Dim lista_usuario As List(Of BE.BE_Usuario)
            lista_usuario = bll_usuarios.consultartodos_existentes()
            Session.Add("Lista_usuario", lista_usuario)
            lst_users.DataSource = lista_usuario
            lst_users.DataTextField = "Nombre_Usuario"
            lst_users.DataBind()
            lst_users.Enabled = True
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Private Sub lst_users_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_users.SelectedIndexChanged
        Try
            If lst_users.SelectedItem.Text = CType(Session("Usuario"), BE.BE_Usuario).Nombre_Usuario Then
                Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_nopuedeseleusu"))
                Me.formato_inicial()
            Else
                Session("Cambio") = True
                btn_nuevous.Enabled = False
                btn_guardarus.Enabled = True
                Dim be_usuario As BE.BE_Usuario
                Dim lista As List(Of BE.BE_Usuario)
                lista = Session("Lista_usuario")
                be_usuario = lista.Find(Function(x) x.Nombre_Usuario = lst_users.SelectedItem.Text)
                txt_usuario.Text = be_usuario.Nombre_Usuario
                txt_password.Text = be_usuario.Clave
                drp_idioma.SelectedValue = be_usuario.Idioma.Idioma
                drp_roles.SelectedValue = be_usuario.permiso_usuario.Descripcion
                drp_idioma.Enabled = True
                chk_bloqueado.Checked = be_usuario.Usuario_Bloqueado
                txt_password.Enabled = True
                txt_usuario.Enabled = True
                chk_bloqueado.Enabled = True
                btn_cancelarus.Enabled = True
                btn_eliminar.Enabled = True
                drp_roles.Enabled = True
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try


    End Sub

    Protected Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim be_bitacora As New BE.BE_Bitacora
            Dim bll_bitacora As New BLL.BLL_Bitacora
            Dim usuario As BE.BE_Usuario
            Dim bll_usuario As New BLL.BLL_Usuario
            Dim lista_usuario As List(Of BE.BE_Usuario)
            lista_usuario = Session("Lista_usuario")
            usuario = lista_usuario.Find(Function(x) x.Nombre_Usuario = lst_users.SelectedItem.Text)
            Select Case bll_usuario.baja(usuario)
                Case True
                    be_bitacora.codigo_evento = 10165
                    be_bitacora.usuario = Session("Usuario")
                    bll_bitacora.alta(be_bitacora)
                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_borradook"))

                Case False
                    be_bitacora.codigo_evento = 10165
                    be_bitacora.usuario = Session("Usuario")
                    bll_bitacora.alta(be_bitacora)
                    Response.Redirect("web_error_inicio.aspx", False)

            End Select
            cargar_lista()
            formato_inicial()
            Session("Cambio") = False
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Protected Sub btn_guardarus_Click(sender As Object, e As EventArgs) Handles btn_guardarus.Click
        Try
            Dim be_bitacora As New BE.BE_Bitacora
            Dim bll_bitacora As New BLL.BLL_Bitacora
            If Session("Cambio") = True Then
                Dim usuario As BE.BE_Usuario
                Dim usuario_bll As New BLL.BLL_Usuario
                Dim lista_idioma As List(Of BE.BE_Idioma)
                Dim lista_usuario As List(Of BE.BE_Usuario)
                lista_idioma = Application("Idiomas")
                lista_usuario = Session("Lista_usuario")
                usuario = lista_usuario.Find(Function(x) x.Nombre_Usuario = lst_users.SelectedItem.Text)
                usuario.Nombre_Usuario = LCase(txt_usuario.Text)
                If txt_password.Text <> usuario.Clave Then
                    usuario.Fec_Creacionclave = Format(CDate(Today.Date), "yyyy-MM-dd")
                End If
                usuario.Clave = txt_password.Text
                usuario.Usuario_Bloqueado = chk_bloqueado.Checked
                usuario.Intentos_Fallidos = 0
                usuario.Idioma = lista_idioma.Find(Function(x) x.Idioma = drp_idioma.SelectedItem.Text)
                Dim lista_permisos As List(Of BE.BE_Permisocompuesto)
                lista_permisos = Session("Roles")
                usuario.permiso_usuario = lista_permisos.Find(Function(x) x.Descripcion = drp_roles.SelectedItem.Text)
                Session("Cambio") = False
                Select Case usuario_bll.modificar(usuario)
                    Case 2108

                        be_bitacora.codigo_evento = 2108
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_formatincuser"))

                    Case 2113
                        be_bitacora.codigo_evento = 2113
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_formatinpass"))
                    Case 2007
                        be_bitacora.codigo_evento = 2007
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_altaduplica"))

                    Case 2000
                        be_bitacora.codigo_evento = 2000
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Redirect("web_error_inicio.aspx", False)
                    Case 2111
                        be_bitacora.codigo_evento = 2111
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_modificacionok"))
                        cargar_lista()
                        formato_inicial()
                    Case 2112
                        be_bitacora.codigo_evento = 2112
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Redirect("web_error_inicio.aspx", False)
                End Select
            Else
                Dim be_usuario As New BE.BE_Usuario
                Dim bll_usuario As New BLL.BLL_Usuario
                Dim lista_idioma As List(Of BE.BE_Idioma)
                Dim resultado As Integer
                lista_idioma = Application("Idiomas")
                be_usuario.Idioma = lista_idioma.Find(Function(x) x.Idioma = drp_idioma.SelectedItem.Text)
                be_usuario.Nombre_Usuario = LCase(txt_usuario.Text)
                be_usuario.Clave = txt_password.Text
                be_usuario.Fec_Creacionclave = Format(CDate(Today.Date), "yyyy-MM-dd")
                be_usuario.Usuario_Bloqueado = chk_bloqueado.Checked
                Dim lista_permisos As List(Of BE.BE_Permisocompuesto)
                lista_permisos = Session("Roles")
                be_usuario.permiso_usuario = lista_permisos.Find(Function(x) x.Descripcion = drp_roles.SelectedItem.Text)
                be_usuario.Intentos_Fallidos = 0
                resultado = bll_usuario.alta(be_usuario).ToString
                Session("Cambio") = False
                Select Case resultado
                    Case 2108
                        be_bitacora.codigo_evento = 2108
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_formatincuser"))
                    Case 2113
                        be_bitacora.codigo_evento = 2113
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_formatinpass"))
                    Case 2007
                        be_bitacora.codigo_evento = 2007
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_altaduplica"))
                    Case 2000
                        be_bitacora.codigo_evento = 2000
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Redirect("web_error_inicio.aspx", False)
                    Case 2109
                        be_bitacora.codigo_evento = 2109
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_altacorrecta"))
                        cargar_lista()
                        formato_inicial()
                    Case 2110
                        be_bitacora.codigo_evento = 2110
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Redirect("web_error_inicio.aspx", False)
                End Select
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Protected Sub btn_cancelarus_Click(sender As Object, e As EventArgs) Handles btn_cancelarus.Click
        Me.formato_inicial()
    End Sub
End Class