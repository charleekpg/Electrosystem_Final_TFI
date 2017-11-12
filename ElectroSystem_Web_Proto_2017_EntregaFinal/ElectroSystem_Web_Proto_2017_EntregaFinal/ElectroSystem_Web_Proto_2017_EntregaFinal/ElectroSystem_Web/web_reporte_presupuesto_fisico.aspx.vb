Imports Microsoft.Reporting

Public Class web_reporte_presupuesto_fisico

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim reporte As WebForms.LocalReport = ReportViewer1.LocalReport
            Dim parametros As WebForms.ReportParameterInfoCollection = reporte.GetParameters()
            Dim datasource As WebForms.ReportDataSourceCollection = reporte.DataSources
            traducir_parametros(parametros)
            cargar_presupuesto_parametros(parametros)
            cargar_presupuesto_datos(datasource, parametros)
    End Sub

    Sub traducir_parametros(parametros As WebForms.ReportParameterInfoCollection)
        Try
            Dim traductor As New BLL.BLL_Gestor_Formulario
            Dim electro As New General_Electrosystem
            For Each parametro In parametros
                If LSet(parametro.Name, 3) = "rep" Then
                    Dim pr As New WebForms.ReportParameter
                    pr.Name = parametro.Name
                    pr.Values.Add(electro.Traductora(parametro.Name))
                    ReportViewer1.LocalReport.SetParameters(New WebForms.ReportParameter() {pr})
                End If
            Next
        Catch ex As Exception
            Response.Redirect("web_login.aspx", False)
        End Try

    End Sub

    Sub cargar_presupuesto_datos(data As WebForms.ReportDataSourceCollection, parametros As WebForms.ReportParameterInfoCollection)
        Dim be_presupuesto As BE.BE_Presupuesto = Session("Presupuesto_Impresion")
        Try
            Dim lista_trabajo As New List(Of BE.BE_Material_TrabajoconPrec)
            Dim lista_material As New List(Of BE.BE_Material_TrabajoconPrec)
            For Each TRABAJO In be_presupuesto.Materiales_trabajo
                If Not TRABAJO.id = 0 Then
                    If TRABAJO.Material = True Then
                        lista_material.Add(TRABAJO)
                    Else
                        If TRABAJO.Trabajoconprecio = True Then
                            lista_trabajo.Add(TRABAJO)
                        End If
                    End If
                End If
            Next
            For Each datos In data
                Select Case datos.Name
                    Case "presupuesto_mano_obra"
                        If Not be_presupuesto.Artefacto_electrico Is Nothing Then
0:                          'BE_ArtefactoElectricoBindingSource.DataSource = BE_presupuesto.Artefacto_electrico
                            'For Each arte As BE.BE_ArtefactoElectrico In BE_presupuesto.Artefacto_electrico
                            datos.Value = be_presupuesto.Artefacto_electrico
                            'Next
                            'BE_ArtefactoElectricoBindingSource.Add(BE_presupuesto.Artefacto_electrico)
                        Else
                            datos.Value = Nothing
                            For Each par In parametros
                                If par.Name = "contador_mano" Then
                                    Dim pr As New WebForms.ReportParameter
                                    pr.Visible = False
                                    pr.Name = par.Name
                                    pr.Values.Add(100)
                                    ReportViewer1.LocalReport.SetParameters(New WebForms.ReportParameter() {pr})
                                End If
                            Next
                        End If
                    Case "presupuesto_trabajos_adicionales"
                        If Not lista_trabajo.Count = 0 Then
                            datos.Value = lista_trabajo
                        Else
                            datos.Value = Nothing
                            For Each par In parametros
                                If par.Name = "contador_trabajo" Then
                                    Dim pr As New WebForms.ReportParameter
                                    pr.Visible = False
                                    pr.Name = par.Name
                                    pr.Values.Add(100)
                                    ReportViewer1.LocalReport.SetParameters(New WebForms.ReportParameter() {pr})
                                End If
                            Next
                        End If
                        If Not lista_material.Count = 0 Then
                            datos.Value = lista_material
                        Else
                            For Each par In parametros
                                If par.Name = "contador_material" Then
                                    Dim pr As New WebForms.ReportParameter
                                    pr.Visible = False
                                    pr.Name = par.Name
                                    pr.Values.Add(100)
                                    ReportViewer1.LocalReport.SetParameters(New WebForms.ReportParameter() {pr})
                                End If
                            Next
                        End If
                    Case Else
                        datos.Value = be_presupuesto
                End Select
            Next
        Catch ex As Exception
            Response.Redirect("web_login.aspx", False)
        End Try

    End Sub

    Sub cargar_presupuesto_parametros(parametros As WebForms.ReportParameterInfoCollection)
        Try
            Dim be_presupuesto As BE.BE_Presupuesto
            be_presupuesto = Session("Presupuesto_Impresion")
            For Each parametro In parametros
                If LSet(parametro.Name, 3) = "par" Then
                    Select Case parametro.Name
                        Case "par_nombreapellido"
                            Dim nombre_apellido As String = CType(be_presupuesto.Cliente_Persona, BE.BE_Personafisica).Nombre & " " & CType(be_presupuesto.Cliente_Persona, BE.BE_Personafisica).Apellido
                            Dim pr As New WebForms.ReportParameter
                            pr.Name = parametro.Name
                            pr.Values.Add(nombre_apellido)
                            ReportViewer1.LocalReport.SetParameters(New WebForms.ReportParameter() {pr})
                        Case "par_domicilio"
                            Dim domicilio As String = BE_presupuesto.Domicilio.calle & " " & BE_presupuesto.Domicilio.altura & " " & BE_presupuesto.Domicilio.piso & " " & BE_presupuesto.Domicilio.altura
                            Dim pr As New WebForms.ReportParameter
                            pr.Name = parametro.Name
                            pr.Values.Add(domicilio)
                            ReportViewer1.LocalReport.SetParameters(New WebForms.ReportParameter() {pr})
                        Case "par_localidad"
                            Dim localidad As String = BE_presupuesto.Domicilio.localidad.localidad & ", " & BE_presupuesto.Domicilio.partido.partido
                            Dim pr As New WebForms.ReportParameter
                            pr.Name = parametro.Name
                            pr.Values.Add(localidad)
                            ReportViewer1.LocalReport.SetParameters(New WebForms.ReportParameter() {pr})
                        Case "par_presupuesto"
                            Dim pr As New WebForms.ReportParameter
                            pr.Name = parametro.Name
                            pr.Values.Add(BE_presupuesto.id)
                            ReportViewer1.LocalReport.SetParameters(New WebForms.ReportParameter() {pr})
                        Case "par_fecha"
                            Dim pr As New WebForms.ReportParameter
                            pr.Name = parametro.Name
                            pr.Values.Add(BE_presupuesto.fecha_modificacion.Value.Date.ToString)
                            ReportViewer1.LocalReport.SetParameters(New WebForms.ReportParameter() {pr})
                        Case "par_actualizaindice"
                            Dim pr As New WebForms.ReportParameter
                            pr.Name = parametro.Name
                            If Not BE_presupuesto.actualizaicac = False Then
                                pr.Values.Add("NO")
                            Else
                                pr.Values.Add("OK")
                            End If
                            ReportViewer1.LocalReport.SetParameters(New WebForms.ReportParameter() {pr})
                        Case "par_aldarluz"
                            Dim pr As New WebForms.ReportParameter
                            pr.Name = parametro.Name
                            If Not BE_presupuesto.porcentaje_aldarluz = -1 Then
                                pr.Values.Add(BE_presupuesto.porcentaje_aldarluz.ToString)
                            Else
                                pr.Values.Add("0")
                            End If
                            ReportViewer1.LocalReport.SetParameters(New WebForms.ReportParameter() {pr})
                    End Select
                End If
            Next
        Catch ex As Exception
            Response.Redirect("web_login.aspx", False)
        End Try

    End Sub
End Class