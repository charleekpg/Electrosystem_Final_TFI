Public Class Definicion_Boca_Mercado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MsgBox("A modo de ejemplo, se ha asignado que ek porcentaje  de boca empresa es de 110% y el de boca extraordinaria 200%. Es a modo de prototipo, en el producto final será asignado por el usuario en otro modulo")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Dim bll_bocamercado As New BLL.BLL_BocaMercado
        Dim be_boca As New BE.BE_BocaMercado
        be_boca.precio_bocamercado = TextBox1.Text
        'If bll_bocamercado.definir_boca(be_boca) = False Then
        '    MsgBox("Ingreso un valor cero")
        'Else
        Dim lista As List(Of BE.BE_BocaMercado)
            lista = bll_bocamercado.consultartodos()
            For Each unbe As BE.BE_BocaMercado In lista
                'If unbe.tipo = "Boca Empresa" Then
                '    lbl_bocaempresa.Text = unbe.precio_bocamercado
                'Else
                '    If unbe.tipo = "Boca Extraordinaria" Then
                '        lbl_bocaextraordinaria.Text = unbe.precio_bocamercado
                '    End If
                'End If
            Next

        'End If
    End Sub
End Class