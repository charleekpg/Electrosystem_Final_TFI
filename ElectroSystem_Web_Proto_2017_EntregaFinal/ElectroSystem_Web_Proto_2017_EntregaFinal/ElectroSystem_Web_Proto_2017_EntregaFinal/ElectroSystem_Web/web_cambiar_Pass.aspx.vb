Public Class web_cambiar_Pass
    Inherits System.Web.UI.Page
    Dim usu As BE.BE_Usuario
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_cambiar_Pass")

                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)

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

    Protected Sub btn_cambiarcontrasena_Click(sender As Object, e As EventArgs) Handles btn_cambiarcontrasena.Click
        Try
            Dim bll_usuario As New BLL.BLL_Usuario
            Dim be_bitacora As New BE.BE_Bitacora
            Dim bll_bitacora As New BLL.BLL_Bitacora
            Dim be_usuario As New BE.BE_Usuario
            If CType(Session("Usuario"), BE.BE_Usuario).Clave = txt_contrasena.Text Then
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_claveigual")
                txt_contrasena.Text = ""
            ElseIf Len(Trim(txt_contrasena.Text)) = 0 Then
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_campovacio")
            Else
                be_usuario.ip = CType(Session("Usuario"), BE.BE_Usuario).ip
                be_usuario.Fec_Creacionclave = CType(Session("Usuario"), BE.BE_Usuario).Fec_Creacionclave
                be_usuario.Idioma = CType(Session("Usuario"), BE.BE_Usuario).Idioma
                be_usuario.Intentos_Fallidos = CType(Session("Usuario"), BE.BE_Usuario).Intentos_Fallidos
                be_usuario.id_usuario = CType(Session("Usuario"), BE.BE_Usuario).id_usuario
                be_usuario.Nombre_Usuario = CType(Session("Usuario"), BE.BE_Usuario).Nombre_Usuario
                be_usuario.nota = CType(Session("Usuario"), BE.BE_Usuario).Nombre_Usuario
                be_usuario.permiso_usuario = CType(Session("Usuario"), BE.BE_Usuario).permiso_usuario
                be_usuario.Usuario_Bloqueado = CType(Session("Usuario"), BE.BE_Usuario).Usuario_Bloqueado
                be_usuario.Clave = txt_contrasena.Text
                Select Case bll_usuario.cambiar_contraseña(be_usuario)
                    Case 2107
                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_formatinpass")
                        be_bitacora.codigo_evento = 2107
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        txt_contrasena.Text = ""
                    Case 2106
                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_cambiocorrecto")
                        be_bitacora.codigo_evento = 2106
                        Session("Usuario") = be_usuario
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                    Case 2105
                        be_bitacora.codigo_evento = 2105
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        txt_contrasena.Text = ""
                        Response.Redirect("web_error_inicio.aspx", False)
                End Select
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub
End Class