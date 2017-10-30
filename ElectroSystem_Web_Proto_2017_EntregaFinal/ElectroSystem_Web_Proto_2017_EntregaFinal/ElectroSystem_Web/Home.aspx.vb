Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles frm_creacionpresumodtec.Click

    End Sub

    Protected Sub lnk_login_Click(sender As Object, e As EventArgs) Handles lnk_login.Click
        Response.Redirect("Login.aspx")
    End Sub
End Class