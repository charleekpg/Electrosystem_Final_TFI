Public Class web_gestiontecnica
    Inherits System.Web.UI.Page
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True
    Dim usu As BE.BE_Usuario
    Dim entero_flag As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_gest_pres_tec")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        Session.Add("Entero_Flag", entero_flag)
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

    Sub cargar_presupuestos_estado()
        Try
            Dim bll_presupuesto As New BLL.BLL_Presupuesto
            Dim presupuesto As New BE.BE_Presupuesto
            Session("Lista_Presupuestos_1") = Nothing
            presupuesto.estado_presupuesto = "Pendiente de llenado por Parte del Responsable Técnico"
            Session("Lista_Presupuestos_1") = bll_presupuesto.consultar_varios(presupuesto)
            cmb_presupuesto.Enabled = True
            cmb_presupuesto.DataSource = Session("Lista_Presupuestos_1")
            cmb_presupuesto.DataValueField = "id"
            cmb_presupuesto.DataBind()
            If CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Count = 0 Then
                btn_cargar_presupuesto.Enabled = False
            Else
                btn_cargar_presupuesto.Enabled = True
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub
    Sub cargar_artefacto()
        Try
            Dim bll_artefacto As New BLL.BLL_ArtefactoElectrico
            Dim lista_artefactos As List(Of BE.BE_ArtefactoElectrico)
            cbx_arteprtec.DataSource = Nothing
            Session("Lista_Artefactos") = Nothing
            lista_artefactos = bll_artefacto.consultartodos()
            Session("Lista_Artefactos") = lista_artefactos
            cbx_arteprtec.DataSource = lista_artefactos
            cbx_arteprtec.DataTextField = "Descripcion"
            cbx_arteprtec.DataBind()
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Sub cargar_materiales()
        Try
            cbx_matprtec.Items.Clear()
            cbx_trabprtec.Items.Clear()
            Dim bll_materiales As New BLL.BLL_Material_TrabajoconPrec
            Dim lista_materiales_trabajos As List(Of BE.BE_Material_TrabajoconPrec)
            lista_materiales_trabajos = bll_materiales.consultartodos()
            Dim lista_material As New List(Of BE.BE_Material_TrabajoconPrec)
            Dim lista_trabajos As New List(Of BE.BE_Material_TrabajoconPrec)
            Session("Lista_material") = Nothing
            Session("Lista_Trabajos") = Nothing
            Session("Lista_material") = lista_material
            Session("Lista_Trabajos") = lista_trabajos
            For Each material As BE.BE_Material_TrabajoconPrec In lista_materiales_trabajos
                If material.Material = True Then
                    lista_material.Add(material)
                Else
                    lista_trabajos.Add(material)
                End If
            Next
            cbx_matprtec.DataSource = lista_material
            cbx_matprtec.DataTextField = "Descripcion"
            cbx_matprtec.DataBind()
            cbx_trabprtec.DataSource = lista_trabajos
            cbx_trabprtec.DataTextField = "Descripcion"
            cbx_trabprtec.DataBind()
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub

    Protected Sub btn_cargar_presupuesto_Click(sender As Object, e As EventArgs) Handles btn_cargar_presupuesto.Click
        Try
            Dim presupuesto As BE.BE_Presupuesto
            btn_cargar_presupuesto.Enabled = False
            presupuesto = CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Find(Function(x) x.id = cmb_presupuesto.SelectedItem.Text)
            If presupuesto.dibujotecnico Is Nothing Then
                txt_dibujotecnico.Text = "N/A"
                btn_verdibujo.Enabled = False
            Else
                txt_dibujotecnico.Text = presupuesto.dibujotecnico.id
                btn_verdibujo.Enabled = True
            End If
            If presupuesto.estado_presupuesto = "Pendiente de llenado por Parte del Responsable Técnico" Then
                Session("Entero_Flag") = 1
                cargar_artefacto()
                cbx_arteprtec.Enabled = True
                num_arteprtec.Enabled = True
                num_arteprtec.Text = "1"
                cargar_materiales()
                cbx_matprtec.Enabled = True
                num_matprtec.Enabled = True
                num_matprtec.Text = "1"
                cbx_trabprtec.Enabled = True
                num_trabprtec.Enabled = True
                num_trabprtec.Text = "1"
            Else
                Session("Entero_Flag") = 2

            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Private Sub dtg_trabajo_RowUpdated(sender As Object, e As GridViewUpdatedEventArgs) Handles dtg_trabajo.RowUpdated

    End Sub
End Class