Public Class Evaluar_Distancia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If drp_destino.SelectedValue = "" Or drp_origen.SelectedValue = "" Then
            Dim bll_partidos As New BLL.bll_partido
            Dim lista_partido As List(Of BE.BE_Partido)
            lista_partido = bll_partidos.cargar_partidos()
            For Each partido As BE.BE_Partido In lista_partido
                For Each localidad As BE.be_localidad In partido.localidades
                    drp_destino.Items.Add(localidad.localidad)
                    drp_origen.Items.Add(localidad.localidad)
                Next
            Next
        End If

    End Sub

    Protected Sub btn_calculardistancia_Click(sender As Object, e As EventArgs) Handles btn_calculardistancia.Click
        MsgBox("Cabe señalar que en la version final figuraran todos los partidos con sus localidades correspondientes.")
        Dim bll_calculardistancia As New BLL.BLL_Domicilio
        Dim be_origen As New BE.BE_Domicilio
        Dim be_destino As New BE.BE_Domicilio
        be_origen.localidad = New BE.be_localidad
        be_destino.localidad = New BE.be_localidad
        be_origen.localidad.localidad = drp_origen.Text
        be_destino.localidad.localidad = drp_destino.Text
        lbl_distancia.Text = bll_calculardistancia.calcular_distancia(be_origen, be_destino)

    End Sub
End Class