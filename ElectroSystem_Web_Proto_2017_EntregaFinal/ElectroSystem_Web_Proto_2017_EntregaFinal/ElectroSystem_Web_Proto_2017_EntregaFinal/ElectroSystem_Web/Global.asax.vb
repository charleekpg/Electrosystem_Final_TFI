Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication
    Dim idiomas As List(Of BE.BE_Idioma)
    Dim idioma As New BLL.BLL_Gestor_Formulario
    Dim backup As New BLL.BLL_Backup
    Dim backups As List(Of BE.BE_Backup)
    Dim partidos As List(Of BE.BE_Partido)
    Dim bll_partidos As New BLL.bll_partido

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Try
            idiomas = idioma.consultar_idiomas()
            If idiomas.Count = 0 Then
                Response.Redirect("web_error_inicio.aspx", False)
            Else
                Application.Add("Idiomas", idiomas)
            End If
            partidos = bll_partidos.cargar_partidos()
            backups = backup.listar_restore()
            Application.Add("Partidos", partidos)
            If backups.Count = 0 Then

            Else
                Application.Add("Backups", backups)
            End If

        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub


    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class