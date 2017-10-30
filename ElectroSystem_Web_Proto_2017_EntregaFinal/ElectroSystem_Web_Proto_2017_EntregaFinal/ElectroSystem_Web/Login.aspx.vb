Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Dim pepe As New BE.BE_Usuario
        Dim pepes As New BLL.BLL_Usuario
        pepe.Nombre_Usuario = txt_nombreusuario.Text
        pepe.Clave = txt_contrasena.Text
        pepes.loguear_usuario(pepe)

    End Sub

End Class