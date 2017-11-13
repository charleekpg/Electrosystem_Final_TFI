Public Class web_reportes
    Inherits System.Web.UI.Page
    Dim usu As BE.BE_Usuario
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim bitacora As New BE.BE_Bitacora
            Dim bll_bitacora As New BLL.BLL_Bitacora
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_reportes_grafico")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        bitacora.codigo_evento = 2999
                        bitacora.usuario = usu
                        bll_bitacora.alta(bitacora)
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        formato_inicial()
                        chart_top5.DataBind()
                        chart_clicritico.DataBind()
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

    Private Sub cargar_cbx()
        Dim indice As Integer = 0
        cbx_top5.Items.Clear()
        cbx_top5.Items.Add(DirectCast(Me.Master, General_Electrosystem).Traductora("top5artefacto"))
        cbx_top5.Items.Add(DirectCast(Me.Master, General_Electrosystem).Traductora("top5trabajos"))
        cbx_top5.Items.Add(DirectCast(Me.Master, General_Electrosystem).Traductora("top5materiales"))
        cbx_top5.DataBind()
        cbx_top5.SelectedIndex = 0
        Dim be_reporte As New BE.BE_Reporting
        Dim bll_reporte As New BLL.BLL_Reporting
        be_reporte.top5artefacto = True
        be_reporte = bll_reporte.reporte(be_reporte)
        If Not be_reporte.artefactos Is Nothing Then
            For Each artefacto As BE.BE_ArtefactoElectrico In be_reporte.artefactos
                Me.chart_top5.Series(0).Points.AddXY(artefacto.descripcion, artefacto.precio)
                Me.chart_top5.Series(0).Points(indice).AxisLabel = "$" & artefacto.precio
                Me.chart_top5.Series(0).Points(indice).LegendText = artefacto.descripcion
                Me.chart_top5.Series(0).Points(indice).IsVisibleInLegend = True
                indice = indice + 1
            Next
        Else
            cbx_top5.SelectedIndex = 1
            be_reporte.top5trabajo = True
            be_reporte = bll_reporte.reporte(be_reporte)
            If Not be_reporte.trabajos Is Nothing Then
                For Each trabajo As BE.BE_Material_TrabajoconPrec In be_reporte.trabajos
                    Me.chart_top5.Series(0).Points.AddXY(trabajo.Descripcion, trabajo.Precio)
                    Me.chart_top5.Series(0).Points(indice).AxisLabel = "$" & trabajo.Precio
                    Me.chart_top5.Series(0).Points(indice).LegendText = trabajo.Descripcion
                    Me.chart_top5.Series(0).Points(indice).IsVisibleInLegend = True
                    indice = indice + 1
                Next
                cbx_top5.SelectedIndex = 2
            Else
                cbx_top5.SelectedIndex = 2
                be_reporte.top5material = True
                be_reporte = bll_reporte.reporte(be_reporte)
                If Not be_reporte.materiales Is Nothing Then
                    For Each material As BE.BE_Material_TrabajoconPrec In be_reporte.materiales
                        Me.chart_top5.Series(0).Points.AddXY(material.Descripcion, material.Precio)
                        Me.chart_top5.Series(0).Points(indice).AxisLabel = "$" & material.Precio
                        Me.chart_top5.Series(0).Points(indice).LegendText = material.Descripcion
                        Me.chart_top5.Series(0).Points(indice).IsVisibleInLegend = True
                        indice = indice + 1
                    Next
                Else
                    Me.chart_top5.Series(0).Points.AddXY("No Data", 100)
                    Me.chart_top5.Series(0).Points(indice).AxisLabel = "No Data"
                    Me.chart_top5.Series(0).Points(indice).LegendText = "No Data"
                    Me.chart_top5.Series(0).Points(indice).IsVisibleInLegend = True
                    indice = indice + 1
                End If
            End If
        End If
        chart_top5.DataBind()
        indice = 0
        Me.chart_clicritico.Series(0).Points.AddXY("No Data", 100)
        Me.chart_clicritico.Series(0).Points(indice).LegendText = "No Data"
        Me.chart_clicritico.Series(0).Points(indice).AxisLabel = "No Data"
        Me.chart_clicritico.Series(0).Points(indice).IsVisibleInLegend = True
        chart_clicritico.DataBind()

    End Sub


    Private Sub formato_inicial()
        cbx_top5.Enabled = True
        cargar_cbx()
        chk_fechadesde.Enabled = True
        chk_fechahasta.Enabled = False
        chk_fechadesde.Checked = False
        chk_fechahasta.Enabled = False
        dtp_fechadesde.Enabled = False
        dtp_fechahasta.Enabled = False
        rdb_cantidadpre.Enabled = True
        rdb_cantidadpre.Checked = True
        rdb_valor.Enabled = True
        rdb_valor.Checked = False
        dtp_fechadesde.Text = DateTime.Today.ToString
        dtp_fechahasta.Text = DateTime.Today.ToString
        dtp_fechadesde.Enabled = False
        dtp_fechahasta.Enabled = False

    End Sub


    Private Sub chk_fecdesde_CheckedChanged(sender As Object, e As EventArgs) Handles chk_fechadesde.CheckedChanged

        If chk_fechadesde.Checked = True Then
            dtp_fechadesde.Enabled = True
            dtp_fechadesde.Text = DateTime.Today.ToString
            chk_fechahasta.Enabled = True
            dtp_fechahasta.Text = DateTime.Today.ToString

        Else
            dtp_fechadesde.Enabled = False
            dtp_fechadesde.Text = DateTime.Today.ToString
            dtp_fechahasta.Text = DateTime.Today.ToString
            chk_fechahasta.Enabled = False
            chk_fechahasta.Checked = False
            dtp_fechahasta.Enabled = False
        End If
    End Sub

    Private Sub chk_fechasta_CheckedChanged(sender As Object, e As EventArgs) Handles chk_fechahasta.CheckedChanged
        dtp_fechahasta.Text = DateTime.Today.ToString
        If chk_fechahasta.Checked = True And chk_fechahasta.Enabled = True Then
            dtp_fechahasta.Enabled = True
        End If
    End Sub

    Private Sub cbx_top5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_top5.SelectedIndexChanged
        Try
            chart_top5.Series(0).Points.Clear()
            chart_top5.DataBind()
            Dim be_reporte As New BE.BE_Reporting
            Dim bll_reporte As New BLL.BLL_Reporting
            Dim indice As Integer = 0
            If cbx_top5.SelectedIndex = 0 Then
                be_reporte.top5artefacto = True
            Else
                If cbx_top5.SelectedIndex = 1 Then
                    be_reporte.top5trabajo = True
                Else
                    If cbx_top5.SelectedIndex = 2 Then
                        be_reporte.top5material = True
                    End If
                End If
            End If
            be_reporte = bll_reporte.reporte(be_reporte)
            If Not be_reporte.artefactos Is Nothing Then
                For Each artefacto As BE.BE_ArtefactoElectrico In be_reporte.artefactos
                    Me.chart_top5.Series(0).Points.AddXY(artefacto.descripcion, artefacto.precio)
                    Me.chart_top5.Series(0).Points(indice).AxisLabel = "$" & artefacto.precio
                    Me.chart_top5.Series(0).Points(indice).LegendText = artefacto.descripcion
                    Me.chart_top5.Series(0).Points(indice).IsVisibleInLegend = True
                    indice = indice + 1
                Next
            Else
                If Not be_reporte.trabajos Is Nothing Then
                    For Each trabajo As BE.BE_Material_TrabajoconPrec In be_reporte.trabajos
                        Me.chart_top5.Series(0).Points.AddXY(trabajo.Descripcion, trabajo.Precio)
                        Me.chart_top5.Series(0).Points(indice).AxisLabel = "$" & trabajo.Precio
                        Me.chart_top5.Series(0).Points(indice).LegendText = trabajo.Descripcion
                        Me.chart_top5.Series(0).Points(indice).IsVisibleInLegend = True
                        indice = indice + 1
                    Next
                Else
                    If Not be_reporte.materiales Is Nothing Then
                        For Each material As BE.BE_Material_TrabajoconPrec In be_reporte.materiales
                            Me.chart_top5.Series(0).Points.AddXY(material.Descripcion, material.Precio)
                            Me.chart_top5.Series(0).Points(indice).AxisLabel = "$" & material.Precio
                            Me.chart_top5.Series(0).Points(indice).LegendText = material.Descripcion
                            Me.chart_top5.Series(0).Points(indice).IsVisibleInLegend = True
                            indice = indice + 1
                        Next
                    End If
                End If
            End If
            chart_top5.DataBind()

        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub


    Private Sub btn_clientecrit_Click(sender As Object, e As EventArgs) Handles btn_clientecrit.Click
        Try
            chart_clicritico.Series(0).Points.Clear()
            Dim be_reporte As New BE.BE_Reporting
            Dim bll_reporte As New BLL.BLL_Reporting
            Dim indice As Integer = 0
            If rdb_cantidadpre.Checked Then
                be_reporte.cantidad_clientes = True
            Else
                be_reporte.valores_clientes = True
            End If
            If chk_fechadesde.Checked Then
                be_reporte.fechadesde = dtp_fechadesde.Text
                If chk_fechahasta.Checked Then
                    be_reporte.fechahasta = dtp_fechahasta.Text
                Else
                    be_reporte.fechahasta = Date.Now
                End If
            Else
                be_reporte.fechadesde = Date.Now
                be_reporte.fechahasta = Date.Now
            End If
            be_reporte = bll_reporte.reporte(be_reporte)
            If Not be_reporte.cliente Is Nothing Then
                For Each cliente As BE.BE_CLIENTE In be_reporte.cliente
                    If TypeOf (cliente) Is BE.BE_Personajuridica Then
                        If rdb_cantidadpre.Checked Then
                            Me.chart_clicritico.Series(0).Points.AddXY(CType(cliente, BE.BE_Personajuridica).Razonsocial, CType(CType(cliente, BE.BE_Personajuridica).cantidad_presupuesto, Integer))
                            Me.chart_clicritico.Series(0).Points(indice).LegendText = CType(cliente, BE.BE_Personajuridica).Razonsocial
                            Me.chart_clicritico.Series(0).Points(indice).AxisLabel = CType(cliente, BE.BE_Personajuridica).Razonsocial
                            Me.chart_clicritico.Series(0).Points(indice).IsVisibleInLegend = True
                            indice = indice + 1
                        Else
                            Me.chart_clicritico.Series(0).Points.AddXY(CType(cliente, BE.BE_Personajuridica).Razonsocial, CType(cliente, BE.BE_Personajuridica).cantidad_presupuesto)
                            Me.chart_clicritico.Series(0).Points(indice).LegendText = CType(cliente, BE.BE_Personajuridica).Razonsocial
                            Me.chart_clicritico.Series(0).Points(indice).AxisLabel = CType(cliente, BE.BE_Personajuridica).Razonsocial
                            Me.chart_clicritico.Series(0).Points(indice).IsVisibleInLegend = True
                            indice = indice + 1
                        End If
                    Else
                        If rdb_cantidadpre.Checked Then
                            Me.chart_clicritico.Series(0).Points.AddXY(CType(cliente, BE.BE_Personafisica).Nombre & " " & CType(cliente, BE.BE_Personafisica).Apellido, CType(CType(cliente, BE.BE_Personafisica).cantidad_presupuesto, Integer))
                            Me.chart_clicritico.Series(0).Points(indice).LegendText = CType(cliente, BE.BE_Personafisica).Nombre & " " & CType(cliente, BE.BE_Personafisica).Apellido
                            Me.chart_clicritico.Series(0).Points(indice).AxisLabel = CType(cliente, BE.BE_Personafisica).Nombre & " " & CType(cliente, BE.BE_Personafisica).Apellido
                            Me.chart_clicritico.Series(0).Points(indice).IsVisibleInLegend = True
                            indice = indice + 1
                        Else
                            Me.chart_clicritico.Series(0).Points.AddXY(CType(cliente, BE.BE_Personafisica).Nombre & " " & CType(cliente, BE.BE_Personafisica).Apellido, CType(cliente, BE.BE_Personafisica).cantidad_presupuesto)
                            Me.chart_clicritico.Series(0).Points(indice).LegendText = CType(cliente, BE.BE_Personafisica).Nombre & " " & CType(cliente, BE.BE_Personafisica).Apellido
                            Me.chart_clicritico.Series(0).Points(indice).AxisLabel = CType(cliente, BE.BE_Personafisica).Nombre & " " & CType(cliente, BE.BE_Personafisica).Apellido
                            Me.chart_clicritico.Series(0).Points(indice).IsVisibleInLegend = True
                            indice = indice + 1
                        End If
                    End If
                Next
            End If
            chart_clicritico.DataBind()
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub


    Private Sub rdb_cantidadpre_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_cantidadpre.CheckedChanged
        If rdb_cantidadpre.Checked = True Then
            rdb_valor.Checked = False
        Else
            rdb_valor.Checked = True
        End If
    End Sub

    Private Sub rdb_valor_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_valor.CheckedChanged
        If rdb_valor.Checked = True Then
            rdb_cantidadpre.Checked = False
        Else
            rdb_cantidadpre.Checked = True
        End If
    End Sub
End Class