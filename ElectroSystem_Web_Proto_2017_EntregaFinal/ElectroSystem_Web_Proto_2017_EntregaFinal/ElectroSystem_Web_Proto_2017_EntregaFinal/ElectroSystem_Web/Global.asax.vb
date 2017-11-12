Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication
    

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim idiomas As List(Of BE.BE_Idioma)
            Dim idioma As New BLL.BLL_Gestor_Formulario
            Dim backup As New BLL.BLL_Backup
            Dim backups As List(Of BE.BE_Backup)
            Dim partidos As List(Of BE.BE_Partido)
            Dim bll_partidos As New BLL.bll_partido
            Dim be_backup As New BE.BE_Backup
            be_backup.directorio = System.Configuration.ConfigurationManager.AppSettings("PathBackup")
            idiomas = idioma.consultar_idiomas()
            If idiomas.Count = 0 Then
                Response.Redirect("web_error_inicio.aspx", False)
            Else
                Application("Idiomas") = idiomas
            End If
            partidos = bll_partidos.cargar_partidos()
            backups = backup.listar_restore(be_backup)
            Application("Partidos") = partidos

        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub


    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
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