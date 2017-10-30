Public Class web_bitacora
    Inherits System.Web.UI.Page
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True
    Dim usu As BE.BE_Usuario
    Dim tRow As New TableRow()
    Dim idiomas As List(Of BE.BE_Idioma)
    Dim idioma As New BLL.BLL_Gestor_Formulario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_bita")

                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)

                        Me.deshabilitacion_inicial(Me.Controls)
                        ' Me.diseño_grilla()
                        Me.TRADUCIR_grilla()
                        Me.entro = True
                    Else
                        Response.Redirect("web_login.aspx", False)
                    End If
                End If
            Else
                'DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                Me.entro = True
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Private Sub deshabilitacion_inicial(controles As ControlCollection)
        For Each contro As Control In controles
            If TypeOf contro Is CheckBox Then
                Me.habilitar_controles(contro, False)
            Else
                Me.deshabilitacion_inicial(contro.Controls)
            End If
        Next
    End Sub
    Private Sub habilitar_controles(control As CheckBox, habilitar As Boolean)
        Select Case control.ID
            Case "chk_fechadesde"
                chk_fechadesde.Checked = habilitar
                dtp_fechadesde.Enabled = habilitar
                chk_fechahasta.Enabled = habilitar
            Case "chk_fechahasta"
                dtp_fechahasta.Enabled = habilitar
            Case "chk_nombredeusuario"
                chk_nombredeusuario.Checked = habilitar
                cbx_usuario.Enabled = habilitar
            Case "chk_codigodeevento"
                chk_codigodeevento.Checked = habilitar
                cbx_codigoevento.Enabled = habilitar
        End Select
    End Sub
    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click

        Try

            Dim be_ficha As New BE.Be_Ficha_Bitacora
            Dim bll_Bitacora As New BLL.bll_fichaBitacora
            Dim bll_bita As New BLL.BLL_Bitacora
            Dim lista_Bitacora As List(Of BE.BE_Bitacora)
            If chk_nombredeusuario.Checked = True Then
                Dim lista As List(Of BE.BE_Usuario)
                lista = Session("lista_usuarios")
                be_ficha.usuario = lista.Find(Function(x) x.Nombre_Usuario = cbx_usuario.SelectedItem.Text)
            Else
                be_ficha.usuario = New BE.BE_Usuario
            End If
            If chk_codigodeevento.Checked = True Then
                be_ficha.codigo_evento = cbx_codigoevento.Text
            Else
                be_ficha.codigo_evento = Nothing
            End If
            If chk_fechadesde.Checked = True Then
                be_ficha.fecha_hora = dtp_fechadesde.Text
            End If
            If chk_fechahasta.Checked = True Then
                be_ficha.fecha_hasta_hora = dtp_fechahasta.Text
            End If
            lista_Bitacora = bll_Bitacora.consultartodos(be_ficha)
            If lista_Bitacora.Count = 0 Then
                Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_sinresultados"))
                GVGrillaEventos.DataSource = Nothing
                GVGrillaEventos.DataBind()
                deshabilitacion_inicial(Me.Controls)
            Else
                GVGrillaEventos.DataSource = lista_Bitacora
                GVGrillaEventos.DataBind()
            End If
            Dim be_Bitacora As New BE.BE_Bitacora
            be_Bitacora.usuario = Session("Usuario")
            be_Bitacora.codigo_evento = 3001
            bll_bita.alta(be_Bitacora)
            
            'Else
            '    Me.diseño_grilla()
            '    For Each elemento As BE.BE_Bitacora In lista_Bitacora
            '        Dim Row As New TableRow
            '        Dim celda As New TableCell
            '        celda.Text = elemento.usuario.ip
            '        Row.Cells.Add(celda)
            '        celda = New TableCell
            '        celda.Text = elemento.usuario.Nombre_Usuario
            '        Row.Cells.Add(celda)
            '        celda = New TableCell
            '        celda.Text = elemento.fecha_hora.ToString
            '        Row.Cells.Add(celda)
            '        celda = New TableCell
            '        celda.Text = elemento.codigo_evento
            '        Row.Cells.Add(celda)
            '        celda = New TableCell
            '        celda.Text = elemento.criticidad
            '        Row.Cells.Add(celda)
            '        celda = New TableCell
            '        celda.Text = elemento.descripcion_evento
            '        Row.Cells.Add(celda)
            '        celda = New TableCell
            '        celda.Text = elemento.informacion_adicional
            '        Row.Cells.Add(celda)
            '        dtg_busquedaBitacora.Rows.Add(Row)
            '    Next
            'End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
            End Try

    End Sub


    Private Sub chk_nombredeusuario_CheckedChanged(sender As Object, e As EventArgs) Handles chk_nombredeusuario.CheckedChanged
        Try
            Me.habilitar_controles(chk_nombredeusuario, chk_nombredeusuario.Checked)
            If chk_nombredeusuario.Checked = True Then
                cbx_usuario.Enabled = True
                Dim bll_usuarios As New BLL.BLL_Usuario
                Dim lista_usuarios As List(Of BE.BE_Usuario)
                lista_usuarios = bll_usuarios.consultartodos()
                Session.Add("lista_usuarios", lista_usuarios)
                cbx_usuario.DataSource = lista_usuarios
                cbx_usuario.DataTextField = "Nombre_Usuario"
                cbx_usuario.DataValueField = "id_usuario"
                cbx_usuario.DataBind()
            Else
                cbx_usuario.DataSource = Nothing
                cbx_usuario.Items.Clear()
                cbx_usuario.Enabled = False
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx")
        End Try
    End Sub

    Private Sub diseño_grilla()
        Try

        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Private Sub TRADUCIR_grilla()
        Try
            For Each elemento As BoundField In GVGrillaEventos.Columns
                elemento.HeaderText = DirectCast(Me.Master, General_Electrosystem).Traductora(elemento.FooterText)
            Next
            ' tRow.Cells.Add(celda)
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Protected Sub chk_fechadesde_CheckedChanged(sender As Object, e As EventArgs) Handles chk_fechadesde.CheckedChanged
        Me.habilitar_controles(chk_fechadesde, chk_fechadesde.Checked)
    End Sub

    Protected Sub chk_fechahasta_CheckedChanged(sender As Object, e As EventArgs) Handles chk_fechahasta.CheckedChanged
        Me.habilitar_controles(chk_fechahasta, chk_fechahasta.Checked)
    End Sub

    Protected Sub cbx_usuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_usuario.SelectedIndexChanged

    End Sub

    Private Sub chk_codigodeevento_CheckedChanged(sender As Object, e As EventArgs) Handles chk_codigodeevento.CheckedChanged
        Try
            Me.habilitar_controles(chk_codigodeevento, chk_codigodeevento.Checked)
            If chk_codigodeevento.Checked = True Then
                cbx_codigoevento.Enabled = True
                Dim bll_Bitacora As New BLL.BLL_Bitacora
                Dim lista_bitacora As New List(Of BE.BE_Bitacora)
                lista_bitacora = bll_Bitacora.consultarcodigodeevento()
                If lista_bitacora.Count > 0 Then
                    cbx_codigoevento.DataSource = bll_Bitacora.consultarcodigodeevento()
                    cbx_codigoevento.DataTextField = "codigo_evento"
                    cbx_codigoevento.DataBind()
                Else
                    Response.Redirect("web_error_inicio.aspx", False)
                End If
            Else
                cbx_codigoevento.DataSource = Nothing
                cbx_codigoevento.Items.Clear()
                cbx_codigoevento.Enabled = False
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Private Sub GVGrillaEventos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVGrillaEventos.PageIndexChanging
        GVGrillaEventos.PageIndex = e.NewPageIndex
        btn_buscar_Click(Nothing, Nothing)
    End Sub

End Class