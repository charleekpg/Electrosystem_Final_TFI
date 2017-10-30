Public Class Evaluar_Plano
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If drp_ambiente.SelectedValue = "" Then
            drp_ambiente.Items.Add("Sala de Estar")
            drp_ambiente.Items.Add("Dormitorio")

        End If
    End Sub

    Protected Sub btn_evaluarplano_Click(sender As Object, e As EventArgs) Handles btn_evaluarplano.Click
        Dim resultado As Integer = 0
        Dim be_dibujotecnico As New BE.BE_DibujoTecnico
        Dim bll_dibujotecnico As New BLL.bll_dibujotecnico
        be_dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        Dim be_ambiente As New BE.Be_Ambiente
        be_ambiente.m2 = txt_m2.Text
        be_ambiente.tipo = drp_ambiente.Text
        be_ambiente.circuitos = New List(Of BE.BE_Circuito)
        For i As Integer = 1 To txt_ilumina.Text
            Dim be_circuito As New BE.BE_Circuito
            be_circuito.tipo = "Iluminación"
            be_circuito.sigla = "IUG"
            be_circuito.cantidad_bocas = txt_bocailumina.Text
            be_ambiente.circuitos.Add(be_circuito)
        Next
        For i As Integer = 1 To txt_tc.Text
            Dim be_circuito As New BE.BE_Circuito
            be_circuito.tipo = "Toma Corriente"
            be_circuito.sigla = "TUG"
            be_circuito.cantidad_bocas = txt_bocatc.Text
            be_ambiente.circuitos.Add(be_circuito)

        Next
        For i As Integer = 1 To txt_iluminaue.Text
            Dim be_circuito As New BE.BE_Circuito
            be_circuito.tipo = "Iluminación Uso Especial"
            be_circuito.sigla = "IUE"
            be_circuito.cantidad_bocas = txt_bocailuminaue.Text
            be_ambiente.circuitos.Add(be_circuito)


        Next
        For i As Integer = 1 To txt_tcue.Text
            Dim be_circuito As New BE.BE_Circuito
            be_circuito.tipo = "Toma Corriente Uso Especial"
            be_circuito.sigla = "TUE"
            be_circuito.cantidad_bocas = txt_bocatcue.Text
            be_ambiente.circuitos.Add(be_circuito)
        Next

        be_dibujotecnico.ambiente.Add(be_ambiente)
        resultado = bll_dibujotecnico.evaluar_plano(be_dibujotecnico)
        If resultado = 0 Then
            MsgBox("Aqui se comentaran las recomendaciones correspondientes por circuito/ambiente en el producto final.")
            If MsgBox("El grafico no respeta las recomendaciones, quiere continuar igualmente?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                bll_dibujotecnico.alta(be_dibujotecnico)
            End If
        Else
            MsgBox("El dibujo cumple con las recomendaciones")
            bll_dibujotecnico.alta(be_dibujotecnico)

        End If
    End Sub
End Class