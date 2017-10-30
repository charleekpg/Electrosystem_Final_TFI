Public Class Backup
    Inherits System.Web.UI.Page

    Private Sub cargar_cbx()
        Dim ls As List(Of BE.BE_Backup)
        Dim backup As New BLL.BLL_Backup
        ls = backup.listar_restore()
        cmbBackups.DataSource = ls
        cmbBackups.DataMember = "nombre_backup"
        cmbBackups.DataBind()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txt_directorio.Text = Request.PhysicalPath()

    End Sub


    Protected Sub btn_backup_Click(sender As Object, e As EventArgs) Handles btn_backup.Click
        Dim be_backup As New BE.BE_Backup
        Dim bll_backup As New BLL.BLL_Backup
        be_backup.nombre_backup = txt_nombrebackup.Text
        be_backup.directorio = txt_directorio.Text + "\"
        bll_backup.hacerbackup(be_backup)
    End Sub

    Protected Sub btnRestaurar_Click(sender As Object, e As EventArgs) Handles btnRestaurar.Click
        Dim bll_backup As New BLL.BLL_Backup
        bll_backup.hacerbackup(CType(cmbBackups.SelectedItem(0),BE.BE_Backup)


    End Sub
End Class