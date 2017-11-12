Public Class web_cambiaridioma
    Inherits System.Web.UI.Page
    Dim usu As BE.BE_Usuario
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_seleccionaridioma")

                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)

                        cargar_idioma()
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

    Sub cargar_idioma()
        drp_idiomas.Items.Clear()
        drp_idiomas.DataSource = Nothing
        Dim lista_idioma As List(Of BE.BE_Idioma)
        lista_idioma = Application("Idiomas")
        drp_idiomas.DataSource = lista_idioma
        drp_idiomas.DataTextField = "Idioma"
        drp_idiomas.DataBind()
    End Sub
    Protected Sub btn_cambiaridioma_Click(sender As Object, e As EventArgs) Handles btn_cambiaridioma.Click
        Try
            Dim be_bitacora As New BE.BE_Bitacora
            Dim bll_bitacora As New BLL.BLL_Bitacora
            Dim lista_idioma As List(Of BE.BE_Idioma)
            Dim bll_usuario As New BLL.BLL_Usuario
            lista_idioma = Application("Idiomas")
            CType(Session("Usuario"), BE.BE_Usuario).Idioma = lista_idioma.Find(Function(x) x.Idioma = drp_idiomas.SelectedItem.Text)
            Select Case bll_usuario.modificar_idioma(DirectCast(Session("Usuario"), BE.BE_Usuario))
                Case 10163
                    be_bitacora.codigo_evento = 10163
                    be_bitacora.usuario = Session("Usuario")
                    bll_bitacora.alta(be_bitacora)
                    DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                    DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_idiomacambiado")
                Case 10164
                    be_bitacora.codigo_evento = 10164
                    be_bitacora.usuario = Session("Usuario")
                    bll_bitacora.alta(be_bitacora)
                    Response.Redirect("web_error_inicio.aspx", False)
                Case Else
                    Response.Redirect("web_error_inicio.aspx", False)
            End Select
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub
End Class