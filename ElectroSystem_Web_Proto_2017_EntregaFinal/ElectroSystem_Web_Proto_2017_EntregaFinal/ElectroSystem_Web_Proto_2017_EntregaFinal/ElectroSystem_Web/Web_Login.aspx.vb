Public Class Login
    Inherits System.Web.UI.Page
    Dim idioma As BE.BE_Idioma

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Session("Usuario") = Nothing
            Session("lista_usuarios") = Nothing
            Session("Entero_Flag") = Nothing
            Session("Lista_Presupuestos_1") = Nothing
            Session("Lista_Dibujos") = Nothing
            Session("Busqueda_cliente") = Nothing
            Session("DibujoTecnico") = Nothing
            Session("Nuevo") = Nothing
            Session("Evaluado") = Nothing
            Session("Grilla") = Nothing
            Session("Elemento_Seleccionado") = Nothing
            Session("Listado") = Nothing
            Session("Modificar") = Nothing
            Session("Telefonos") = Nothing
            Session("Persona_Buscada") = Nothing
            Session("Lista_Artefactos") = Nothing
            Session("Lista_Materiales") = Nothing
            Session("Lista_Trabajos") = Nothing
            Session("Idioma_Agregable") = Nothing
            Session("Idioma_Modificable") = Nothing
            Session("Roles_Modificables") = Nothing
            Session("Cambio") = Nothing
            Session("Patentes") = Nothing
            Session("Calculado") = Nothing
            Session("Presupuesto_Impresion") = Nothing
            Session("Lista_usuario") = Nothing
            If IsPostBack Then

                idioma = DirectCast(Application("Idiomas"), List(Of BE.BE_Idioma)).Find(Function(x) x.Idioma = cmb_idioma.SelectedItem.Text)
                DirectCast(Me.Master, General_Inicio).traductora_controles(Me.Controls, idioma)
            Else
                cmb_idioma.DataSource = CType(Application("Idiomas"), List(Of BE.BE_Idioma))
                cmb_idioma.DataValueField = "Idioma"
                cmb_idioma.DataBind()
                idioma = DirectCast(Application("Idiomas"), List(Of BE.BE_Idioma)).Item(0)
                DirectCast(Me.Master, General_Inicio).traductora_controles(Me.Controls, idioma)
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub
    Protected Sub btn_ingresar_Click(sender As Object, e As EventArgs) Handles btn_ingresar.Click
        Try
            Dim usu As New BE.BE_Usuario
            Dim usu_bll As New BLL.BLL_Usuario
            If String.IsNullOrEmpty(txt_usuario.Text) = True Or String.IsNullOrEmpty(txt_contraseña.Text) = True Then
                DirectCast(Me.Master, General_Inicio).mostrarmodal("msg_compruebecampos", idioma)
                Exit Sub
            End If
            usu.Nombre_Usuario = txt_usuario.Text
            usu.Clave = txt_contraseña.Text
            If Request.ServerVariables("REMOTE_ADDR") = "::1" Then
                usu.ip = "127.0.0.1"
            Else
                usu.ip = Request.ServerVariables("REMOTE_ADDR")
            End If
            Select Case usu_bll.loguear_usuario(usu)
                Case 2100
                    txt_usuario.Text = String.Empty
                    txt_contraseña.Text = String.Empty
                    DirectCast(Me.Master, General_Inicio).mostrarmodal("msg_usuariopasserronea", idioma)

                Case 2101
                    txt_usuario.Text = String.Empty
                    txt_contraseña.Text = String.Empty
                    DirectCast(Me.Master, General_Inicio).mostrarmodal("msg_usuariopasserronea", idioma)

                Case 2102
                    DirectCast(Me.Master, General_Inicio).mostrarmodal("msg_usuariobloqueado", idioma)
                Case 2103
                    usu.Idioma = idioma
                    Session.Add("Usuario", usu)
                    Response.Redirect("Web_Inicio.aspx", False)
                Case 210
                    Session.Abandon()
                    usu.Idioma = idioma
                    Session.Add("Usuario", usu)
                    'aca recorramos los permisos (me falta poner eso)
                    Response.Redirect("web_error_inicio.aspx", False)
                Case 211
                    Response.Redirect("web_error_inicio.aspx", False)
            End Select
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub

End Class