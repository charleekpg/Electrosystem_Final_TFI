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
        drp_backups.Items.Clear()
        drp_backups.DataSource = Nothing
        Dim listar_backups As List(Of BE.BE_Backup)
        listar_backups = Application("Backups")
        drp_backups.DataSource = listar_backups
        drp_backups.DataTextField = "nombre_backup"
        drp_backups.DataValueField = "nombre_backup"
        drp_backups.DataBind()
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
            Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_restoreexitoso"))
            be_bitacora.codigo_evento = 6003
            be_bitacora.usuario = Session("Usuario")
            bll_bitacora.alta(be_bitacora)
            Session.Abandon()
            Response.Redirect("Web_login.aspx")
        Else
            Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_restoreerroneo"))
            be_bitacora.codigo_evento = 6002
            be_bitacora.usuario = Session("Usuario")
            bll_bitacora.alta(be_bitacora)
        End If
    End Sub

    Protected Sub btn_hacerbackup_Click(sender As Object, e As EventArgs) Handles btn_hacerbackup.Click
        Try
            Dim bll_backup As New BLL.BLL_Backup
            Dim be_bitacora As New BE.BE_Bitacora
            Dim bll_bitacora As New BLL.BLL_Bitacora
            Dim backups As List(Of BE.BE_Backup)
            Dim backup As New BLL.BLL_Backup
            If bll_backup.hacerbackup() = 6001 Then
                Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_backupexitoso"))
                be_bitacora.codigo_evento = 6001
                be_bitacora.usuario = Session("Usuario")
                bll_bitacora.alta(be_bitacora)
                Try
                    backups = backup.listar_restore()
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
                Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_backuperroneo"))
                be_bitacora.codigo_evento = 6000
                be_bitacora.usuario = Session("Usuario")
                bll_bitacora.alta(be_bitacora)
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub
End Class