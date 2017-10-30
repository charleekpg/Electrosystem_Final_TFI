Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles frm_creacionpresumodtec.Click
        Response.Redirect("Armado_PresupuestoTecnico.aspx")
    End Sub

    Protected Sub lnk_login_Click(sender As Object, e As EventArgs) Handles lnk_login.Click
        Response.Redirect("Login.aspx")
    End Sub

    Protected Sub frm_backupyrestore_Click(sender As Object, e As EventArgs) Handles frm_backupyrestore.Click
        Response.Redirect("Backup.aspx")
    End Sub

    Protected Sub frm_bitacora_Click(sender As Object, e As EventArgs) Handles frm_bitacora.Click
        Dim be_Bitacora As New BE.BE_Bitacora
        Dim bll_Bitacora As New BLL.BLL_Bitacora
        be_Bitacora.codigo_evento = 1
        be_Bitacora.usuario = New BE.BE_Usuario
        be_Bitacora.usuario.Nombre_Usuario = "Usuario test"
        bll_Bitacora.alta(be_Bitacora)
        Response.Redirect("Bitacora.aspx")
    End Sub

    Protected Sub frm_cifrado_Click(sender As Object, e As EventArgs) Handles frm_cifrado.Click
        Response.Redirect("Cifrado_Digito.aspx")
    End Sub

    Protected Sub frm_idioma_Click(sender As Object, e As EventArgs) Handles frm_idioma.Click
        Response.Redirect("Idioma.aspx")

    End Sub

    Protected Sub frm_Bocamercado_Click(sender As Object, e As EventArgs) Handles frm_Bocamercado.Click
        Response.Redirect("Definicion Boca Mercado.aspx")

    End Sub

    Protected Sub lnk_evalplano_Click(sender As Object, e As EventArgs) Handles lnk_evalplano.Click
        Response.Redirect("Evaluar Plano.aspx")
    End Sub

    Protected Sub frm_creacionpresatenc_Click(sender As Object, e As EventArgs) Handles frm_creacionpresatenc.Click
        MsgBox("Cabe señalar que a modo de ejemplo, se especifico como cliente, un cliente sin tratamiento especial. En el producto final el usuario podrá seleccionar el cliente correspondiente, como así tambien su partido y localidad.")
        Response.Redirect("creacion_atcliente.aspx")
    End Sub

    Protected Sub frm_evaluardistancia_Click(sender As Object, e As EventArgs) Handles frm_evaluardistancia.Click
        Response.Redirect("Evaluar Distancia.aspx")
    End Sub

    Protected Sub frm_armadopresupuestomodcome_Click(sender As Object, e As EventArgs) Handles frm_armadopresupuestomodcome.Click
        Response.Redirect("Armado_PresupuestoTecnico.aspx")

    End Sub

    Protected Sub frm_generacionpresu_Click(sender As Object, e As EventArgs) Handles frm_generacionpresu.Click
        MsgBox("Para la versión final ya que genera un reporte!")
    End Sub

    Protected Sub frm_generacionserv_Click(sender As Object, e As EventArgs) Handles frm_generacionserv.Click
        MsgBox("Para la versión final ya que genera un reporte!")

    End Sub

    Protected Sub frm_especificarfechaproy_Click(sender As Object, e As EventArgs) Handles frm_especificarfechaproy.Click
        Response.Redirect("Especificar_Fecha.aspx")

    End Sub

    Protected Sub frm_cierreproy_Click(sender As Object, e As EventArgs) Handles frm_cierreproy.Click
        Response.Redirect("Cierre_proyecto.aspx")
    End Sub

    Protected Sub frm_generaciongraf_Click(sender As Object, e As EventArgs) Handles frm_generaciongraf.Click
        MsgBox("Para la versión final ya que genera gráficos!")
    End Sub
End Class