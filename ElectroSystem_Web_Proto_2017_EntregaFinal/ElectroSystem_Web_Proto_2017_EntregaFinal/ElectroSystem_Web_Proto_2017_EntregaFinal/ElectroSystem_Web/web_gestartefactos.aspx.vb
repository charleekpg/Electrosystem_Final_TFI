Public Class web_gestartefactos
    Inherits System.Web.UI.Page
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True
    Dim usu As BE.BE_Usuario
    Dim listado As New List(Of BE.BE_ArtefactoElectrico)
    Dim elemento_seleccionado As BE.BE_ArtefactoElectrico
    Dim entero_flag As Integer = 0
    Dim modificarartefacto As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_gestartefactos")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        Session.Add("Entero_Flag", entero_flag)
                        Session.Add("Listado", listado)
                        DirectCast(Me.Master, General_Electrosystem).traducir_grilla(dtg_artefacto)
                        cargarartefactoelectrico()
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

    Sub cargarartefactoelectrico()
        Try
            Dim bll_artefactoelectrico As New BLL.BLL_ArtefactoElectrico
            Dim listados As List(Of BE.BE_ArtefactoElectrico)
            Session("Listado") = Nothing
            Session.Add("Listado", listado)
            listados = Session("Listado")
            dtg_artefacto.DataSource = Nothing
            dtg_artefacto.DataBind()
            Dim lista As List(Of BE.BE_ArtefactoElectrico) = bll_artefactoelectrico.consultartodos()
            Dim i As Integer = 0
            For Each elemento In lista
                listados.Add(elemento)
            Next
            Session("Listado") = listados

            If lista.Count > 0 Then
                dtg_artefacto.DataSource = listados
                dtg_artefacto.DataBind()
            End If
            btn_cancelararte.Enabled = False
            btn_guardararte.Enabled = False
            dtg_artefacto.Enabled = True
            txt_descripcionartefacto.Enabled = False
            num_relacionboca.Enabled = False
            btn_nuevoarte.Enabled = True
            lbl_precio.Enabled = False
            lbl_precio.Checked = False
            lbl_relacionboca.Enabled = False
            lbl_relacionboca.Checked = False
            txt_descripcionartefacto.Text = ""
            num_precio2.Enabled = False
            num_precio2.Text = "0"
            num_relacionboca.Text = "0"
            Session("Elemento_Seleccionado") = Nothing
            Session("Modificar") = False
            DirectCast(Me.Master, General_Electrosystem).traducir_grilla(dtg_artefacto)
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub

    Private Sub Relacion_bocamercado_CheckedChanged(sender As Object, e As EventArgs) Handles lbl_relacionboca.CheckedChanged
        If lbl_relacionboca.Checked = True Then
            manejarchkprecio_relacion(True)
        End If
    End Sub

    Private Sub precio_CheckedChanged(sender As Object, e As EventArgs) Handles lbl_precio.CheckedChanged
        If lbl_precio.Checked = True Then
            manejarchkprecio_relacion(False)
        End If
    End Sub

    Sub manejarchkprecio_relacion(booleano As Boolean)
        If booleano = True Then
            num_relacionboca.Enabled = True
            lbl_relacionboca.Checked = True
            num_precio2.Enabled = False
            lbl_precio.Checked = False
        Else
            num_precio2.Enabled = True
            lbl_precio.Checked = True
            num_relacionboca.Enabled = False
            lbl_relacionboca.Checked = False
        End If
    End Sub

    Protected Sub btn_nuevoarte_Click(sender As Object, e As EventArgs) Handles btn_nuevoarte.Click
        Try
            btn_nuevoarte.Enabled = False
            dtg_artefacto.Enabled = False
            btn_cancelararte.Enabled = True
            btn_guardararte.Enabled = True
            manejarchkprecio_relacion()
            txt_descripcionartefacto.Enabled = True
            lbl_relacionboca.Enabled = True
            lbl_relacionboca.Checked = True
            num_relacionboca.Enabled = True
            num_relacionboca.Text = "0"
            Session("Modificar") = False
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Sub manejarchkprecio_relacion()
        Try
            lbl_precio.Enabled = True
            lbl_relacionboca.Enabled = True
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Private Sub dtg_artefacto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dtg_artefacto.SelectedIndexChanged
        Dim listados As List(Of BE.BE_ArtefactoElectrico)
        listados = Session("Listado")
        elemento_seleccionado = listados.Find(Function(x) x.descripcion = dtg_artefacto.SelectedRow.Cells(1).Text)
        Session("Elemento_Seleccionado") = elemento_seleccionado
        txt_descripcionartefacto.Text = elemento_seleccionado.descripcion
        txt_descripcionartefacto.Enabled = True
        lbl_relacionboca.Enabled = True
        num_relacionboca.Enabled = True
        lbl_relacionboca.Checked = True
        lbl_precio.Enabled = True
        lbl_precio.Checked = False
        num_precio2.Text = elemento_seleccionado.precio
        num_relacionboca.Text = elemento_seleccionado.relacion_bocamercado
        btn_nuevoarte.Enabled = False
        btn_guardararte.Enabled = True
        btn_cancelararte.Enabled = True
        Session("Modificar") = True
    End Sub

    Protected Sub btn_guardararte_Click(sender As Object, e As EventArgs) Handles btn_guardararte.Click
        Try
            If String.IsNullOrWhiteSpace(txt_descripcionartefacto.Text) = True Then
                Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_camposincompletos"))
                cargarartefactoelectrico()
            Else
                Dim be_etiqueta As New BE.BE_Etiqueta
                Dim bll_etiqueta As New BLL.BLL_Etiqueta
                Dim bll_artefactoelectrico As New BLL.BLL_ArtefactoElectrico
                Dim be_bitacora As New BE.BE_Bitacora
                Dim bll_bitacora As New BLL.BLL_Bitacora
                Select Case txt_descripcionartefacto.Text
                    Case ""
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_camposincompletos"))
                        cargarartefactoelectrico()
                    Case Else
                        If Session("Modificar") = False Then
                            Dim be_artefactoelectrico As New BE.BE_ArtefactoElectrico
                            If lbl_precio.Checked = True Then
                                If num_precio2.Text > 0 Then
                                    be_artefactoelectrico.precio = num_precio2.Text
                                    be_artefactoelectrico.relacion_bocamercado = 0
                                Else
                                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_valorcero"))
                                    cargarartefactoelectrico()
                                    GoTo 1
                                End If
                            Else
                                If num_relacionboca.Text > 0 Then
                                    be_artefactoelectrico.relacion_bocamercado = num_relacionboca.Text
                                    be_artefactoelectrico.precio = 0
                                Else
                                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_valorcero"))
                                    cargarartefactoelectrico()
                                    GoTo 1
                                End If
                            End If
                            be_artefactoelectrico.descripcion = txt_descripcionartefacto.Text
                            Select Case bll_artefactoelectrico.alta(be_artefactoelectrico)
                                Case 10105
                                    be_bitacora.codigo_evento = 10105
                                    be_bitacora.usuario = Session("Usuario")
                                    bll_bitacora.alta(be_bitacora)
                                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_altacorrecta"))
                                    cargarartefactoelectrico()
                                Case 10107
                                    be_bitacora.codigo_evento = 10107
                                    be_bitacora.usuario = Session("Usuario")
                                    bll_bitacora.alta(be_bitacora)
                                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_artefactoexistente"))
                                    cargarartefactoelectrico()
                                Case 10106
                                    be_bitacora.codigo_evento = 10107
                                    be_bitacora.usuario = Session("Usuario")
                                    bll_bitacora.alta(be_bitacora)
                                    Response.Redirect("web_error_inicio.aspx", False)
                            End Select
                        Else
                            Dim be_artefactoelectrico As BE.BE_ArtefactoElectrico
                            Dim elemento_seleccionado As BE.BE_ArtefactoElectrico
                            elemento_seleccionado = Session("Elemento_seleccionado")
                            be_artefactoelectrico = elemento_seleccionado
                            If lbl_precio.Checked = True Then
                                If num_precio2.Text > 0 Then
                                    be_artefactoelectrico.precio = num_precio2.Text
                                    be_artefactoelectrico.relacion_bocamercado = 0
                                Else
                                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_valorcero"))
                                    cargarartefactoelectrico()
                                    GoTo 1
                                End If
                            Else
                                If num_relacionboca.Text > 0 Then
                                    be_artefactoelectrico.relacion_bocamercado = num_relacionboca.Text
                                    be_artefactoelectrico.precio = 0

                                Else
                                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_valorcero"))
                                    cargarartefactoelectrico()
                                    GoTo 1
                                End If
                            End If
                            be_artefactoelectrico.descripcion = txt_descripcionartefacto.Text
                            Select Case bll_artefactoelectrico.modificar(be_artefactoelectrico)
                                Case 10108
                                    be_bitacora.codigo_evento = 10108
                                    be_bitacora.usuario = Session("Usuario")
                                    bll_bitacora.alta(be_bitacora)
                                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_modificaok"))
                                    cargarartefactoelectrico()
                                Case 10107
                                    be_bitacora.codigo_evento = 10107
                                    be_bitacora.usuario = Session("Usuario")
                                    bll_bitacora.alta(be_bitacora)
                                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_artefactoexistente"))
                                    cargarartefactoelectrico()
                                Case 10109
                                    be_bitacora.codigo_evento = 10109
                                    be_bitacora.usuario = Session("Usuario")
                                    bll_bitacora.alta(be_bitacora)
                                    Response.Redirect("web_error_inicio.aspx", False)
                            End Select
                        End If
1:              End Select
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Protected Sub btn_cancelararte_Click(sender As Object, e As EventArgs) Handles btn_cancelararte.Click
        cargarartefactoelectrico()
    End Sub
End Class