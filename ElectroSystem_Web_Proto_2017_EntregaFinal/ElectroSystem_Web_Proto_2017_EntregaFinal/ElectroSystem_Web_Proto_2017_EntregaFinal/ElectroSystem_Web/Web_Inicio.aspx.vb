Public Class Web_Inicio
    Inherits System.Web.UI.Page
    Dim idioma As BE.BE_Idioma
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack Then
                DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
            ElseIf TypeOf (Session("Usuario")) Is BE.BE_Usuario = True Then
                DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
            Else
                Response.Redirect("web_login.aspx", False)
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
     End Sub

End Class