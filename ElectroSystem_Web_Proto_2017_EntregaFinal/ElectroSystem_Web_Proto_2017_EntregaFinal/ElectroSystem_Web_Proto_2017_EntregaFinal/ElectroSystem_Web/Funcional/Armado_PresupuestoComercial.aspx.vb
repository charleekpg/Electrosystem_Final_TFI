Public Class Armado_PresupuestoComercial

    Inherits System.Web.UI.Page
    Dim lista_partido As List(Of BE.BE_Partido)
    Shared presupuesto As New BE.BE_Presupuesto
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If drp_destino.SelectedValue = "" Or drp_origen.SelectedValue = "" Then
            Dim bll_partidos As New BLL.bll_partido

            lista_partido = bll_partidos.cargar_partidos()
            For Each partido As BE.BE_Partido In lista_partido
                For Each localidad As BE.be_localidad In partido.localidades
                    drp_destino.Items.Add(localidad.localidad)

                Next
            Next
        End If

    End Sub

    Protected Sub link_cargarpresu_Click(sender As Object, e As EventArgs) Handles link_cargarpresu.Click
        Dim bll_presupuesto As New BLL.BLL_Presupuesto
        presupuesto = bll_presupuesto.consultar_ultimo_comercial(presupuesto)
        Label1.Text = presupuesto.id
        drp_origen.Items.Add(presupuesto.Domicilio.localidad.localidad)
    End Sub

    Protected Sub btn_guardarcalcular_Click(sender As Object, e As EventArgs) Handles btn_guardarcalcular.Click
        Dim bll_presupuesto As New BLL.BLL_Presupuesto
        Dim bll_calculardistancia As New BLL.BLL_Domicilio
        Dim be_domicilio As New BE.BE_Domicilio
        be_domicilio.localidad = New BE.be_localidad
        be_domicilio.localidad.localidad = drp_destino.Text
        presupuesto.valor_seguro_vida = txt_precioseguro.Text
        presupuesto.valor_otros = txt_viatico.Text
        presupuesto.porcentaje_aldarluz = txt_porcentajeadelanto.Text

        If bll_calculardistancia.calcular_distancia(presupuesto.Domicilio, be_domicilio) > 20 Then
            presupuesto.masde20km = True
        Else
            presupuesto.masde20km = False
        End If
        bll_presupuesto.calcularvalores(presupuesto)
        txt_valormano.Text = presupuesto.valor_manodeobra
        txt_materiales.Text = presupuesto.valor_material
        txt_precioseguro.Text = presupuesto.valor_seguro_vida
        txt_precioestipula.Text = presupuesto.valor_trabajoconprecio
        txt_viatico.Text = presupuesto.valor_otros
        If MsgBox("Quiere continuar?", MsgBoxStyle.OkCancel) = vbOK Then
            MsgBox("El reporte estará disponible en la versión final!")
        Else
            Response.Redirect("Home.aspx")
        End If
    End Sub
End Class