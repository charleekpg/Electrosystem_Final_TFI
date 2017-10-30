Public Class Idioma
    Inherits System.Web.UI.Page
    Dim be_etiqueta As New BE.BE_Etiqueta
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If drp_idioma.SelectedValue = "Español" Or drp_idioma.SelectedValue = "Ingles" Then
            be_etiqueta.id_control = btn_cambiaridioma.ID
            MsgBox("Cabe señalar en el versión final se cargaran todos los idiomas cargados correspondientes para la selección.")
        Else

            drp_idioma.Items.Add("Español")
            drp_idioma.Items.Add("Ingles")
            be_etiqueta.id_control = btn_cambiaridioma.ID
            MsgBox("Cabe señalar en el versión final se cargaran todos los idiomas cargados correspondientes para la selección.")
        End If

    End Sub


    Protected Sub btn_cambiaridioma_Click(sender As Object, e As EventArgs) Handles btn_cambiaridioma.Click
        Dim be_usuario As New BE.BE_Usuario
        Dim bll_usuario As New BLL.BLL_Usuario
        be_usuario.Nombre_Usuario = "Usuario Test"
        be_usuario.Idioma = New BE.BE_Idioma
        be_usuario.Idioma.Idioma = drp_idioma.SelectedValue
        bll_usuario.modificar(be_usuario)
        Dim traducir As New BLL.BLL_Gestor_Formulario
        'cabe señalar que esto en realidad no se realizará de esta forma. Se envíara el formulario con todos los controles tal como se menciona en el diagrama de secuencia.
        'Se ha realizado de esta forma para mostrar la funcionalidad del prototipo.
        'traducir.traducir(be_etiqueta, be_usuario.Idioma)
        btn_cambiaridioma.Text = be_etiqueta.nombre_traduccion
    End Sub


End Class