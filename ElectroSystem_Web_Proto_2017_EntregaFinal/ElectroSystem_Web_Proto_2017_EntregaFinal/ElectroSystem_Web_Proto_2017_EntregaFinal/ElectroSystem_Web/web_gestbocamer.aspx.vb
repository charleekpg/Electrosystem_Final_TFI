Public Class web_gestbocamer
    Inherits System.Web.UI.Page
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True
    Dim usu As BE.BE_Usuario
    Dim idiomas As List(Of BE.BE_Idioma)
    Dim entero_flag As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_gestbocamer")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        Session.Add("Entero_Flag", entero_flag)
                        cargarbocamercado()
                    Else
                        Response.Redirect("web_login.aspx", False)
                    End If
                End If
            Else
                Me.entro = True
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Sub cargarbocamercado()
        Try
            Dim bll_bocamercado As New BLL.BLL_BocaMercado
            Dim be_bocamercado As BE.BE_BocaMercado
            be_bocamercado = bll_bocamercado.consultartodos().Item(0)
            txt_bocaempresa.Text = bll_bocamercado.calcularbocaempresa(be_bocamercado).precio_bocamercado.ToString()
            txt_bocaextraordinaria.Text = bll_bocamercado.calcularbocaextraordinaria(be_bocamercado).precio_bocamercado.ToString()
            txt_bocamercado.Text = be_bocamercado.precio_bocamercado.ToString()
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Protected Sub btn_guardarprboca_Click(sender As Object, e As EventArgs) Handles btn_guardarprboca.Click
        Try
            Dim be_bitacora As New BE.BE_Bitacora
            Dim bll_bitacora As New BLL.BLL_Bitacora
            If num_bocamercado.Text = "0" Or num_bocamercado.Text = "" Then
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_bocacero")
                cargarbocamercado()
            Else
                Dim be_bocamercado As New BE.BE_BocaMercado
                Dim bll_bocamercado As New BLL.BLL_BocaMercado
                be_bocamercado.precio_bocamercado = num_bocamercado.Text
                If be_bocamercado.precio_bocamercado <= 0 Then
                    DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_formato")
                    cargarbocamercado()
                Else
                    If bll_bocamercado.modificar(be_bocamercado) = 10101 Then
                        be_bitacora.codigo_evento = 10101
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_modificarboca")
                        cargarbocamercado()
                    Else
                        be_bitacora.codigo_evento = 10102
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Response.Redirect("web_error_inicio.aspx", False)
                    End If
                End If

            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Private Sub num_bocamercado_TextChanged(sender As Object, e As EventArgs) Handles num_bocamercado.TextChanged
        Try
            Dim bll_boca As New BLL.BLL_BocaMercado
            Dim be_boca As New BE.BE_BocaMercado
            be_boca.precio_bocamercado = FormatNumber(num_bocamercado.Text, 2)
            txt_bocaempresa.Text = bll_boca.calcularbocaempresa(be_boca).precio_bocamercado.ToString()
            txt_bocaextraordinaria.Text = bll_boca.calcularbocaextraordinaria(be_boca).precio_bocamercado.ToString()
            txt_bocamercado.Text = num_bocamercado.Text
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub
End Class