Public Class Web_Backup

    Inherits System.Web.UI.Page
    Dim tRow As New TableRow()
    Dim usu As BE.BE_Usuario
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_backyrest")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        Me.cargar_backup()
                        Me.entro = True
                    Else
                        Response.Redirect("web_login.aspx", False)
                    End If
                End If
            Else
                ' DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                Me.entro = True
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Private Sub cargar_backup()
        Dim be_backup As New BE.BE_Backup
        Dim backups As List(Of BE.BE_Backup)
        Dim backup As New BLL.BLL_Backup
        be_backup.directorio = System.Configuration.ConfigurationManager.AppSettings("PathBackup")
        drp_backups.Items.Clear()
        drp_backups.DataSource = Nothing
        backups = backup.listar_restore(be_backup)
        If backups.Count = 0 Then
            drp_backups.Items.Add("N/A")
            drp_backups.DataBind()
            drp_backups.Enabled = False
            btn_recupero.Enabled = False
            btn_hacerbackup.Enabled = True
        Else
            Application("Backups") = backups
            Dim listar_backups As List(Of BE.BE_Backup)
            listar_backups = Application("Backups")
            drp_backups.DataSource = listar_backups
            drp_backups.DataTextField = "nombre_backup"
            drp_backups.DataValueField = "nombre_backup"
            drp_backups.DataBind()
            btn_hacerbackup.Enabled = True
            btn_recupero.Enabled = True
        End If
        
    
    End Sub

    Protected Sub btn_recupero_Click(sender As Object, e As EventArgs) Handles btn_recupero.Click
        Dim be_backup As BE.BE_Backup
        Dim bll_backup As New BLL.BLL_Backup
        Dim be_bitacora As New BE.BE_Bitacora
        Dim bll_bitacora As New BLL.BLL_Bitacora
        Dim lista As List(Of BE.BE_Backup)
        lista = Application("Backups")
        be_backup = lista.Find(Function(x) x.nombre_backup = drp_backups.SelectedItem.Text)
        If bll_backup.hacerrestore(be_backup) = 6003 Then
            be_bitacora.codigo_evento = 6003
            be_bitacora.usuario = Session("Usuario")
            bll_bitacora.alta(be_bitacora)
            Me.configuracion_inicial()
            DirectCast(Me.Master, General_Electrosystem).mostrarmodalredireccion("msg_restoreexitoso", "Web_Login.aspx")
            Session.Abandon()
        Else
            be_bitacora.codigo_evento = 6002
            be_bitacora.usuario = Session("Usuario")
            bll_bitacora.alta(be_bitacora)
            DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_restoreerroneo")

        End If
    End Sub

    Private Sub configuracion_inicial()
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

    End Sub

    Protected Sub btn_hacerbackup_Click(sender As Object, e As EventArgs) Handles btn_hacerbackup.Click
        Try
            Dim bll_backup As New BLL.BLL_Backup
            Dim be_bitacora As New BE.BE_Bitacora
            Dim bll_bitacora As New BLL.BLL_Bitacora
            Dim backups As List(Of BE.BE_Backup)
            Dim backup As New BLL.BLL_Backup
            If bll_backup.hacerbackup() = 6001 Then
                be_bitacora.codigo_evento = 6001
                be_bitacora.usuario = Session("Usuario")
                bll_bitacora.alta(be_bitacora)
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_backupexitoso")

                Try
                    backups = Application("Backups")
                    If backups.Count = 0 Then

                    Else
                        Dim lista As List(Of BE.BE_Backup)
                        lista = Application("Backups")
                        lista.Clear()
                        lista.AddRange(backups)
                        Me.cargar_backup()

                    End If
                Catch
                End Try

            Else
                be_bitacora.codigo_evento = 6000
                be_bitacora.usuario = Session("Usuario")
                bll_bitacora.alta(be_bitacora)
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_backuperroneo")

            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub
End Class