Public Class web_reporte_seleccion
    Inherits System.Web.UI.Page
    Dim usu As BE.BE_Usuario
    Private cambio As Boolean
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_reporte_selec")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        btn_cancelar_Click(Nothing, Nothing)
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
            Dim LISTA_PRESUPUESTO As List(Of BE.BE_Presupuesto)
            Dim lista_presupuestos_final As List(Of BE.BE_Presupuesto)
            presupuesto.estado_presupuesto = "Cerrado"
            LISTA_PRESUPUESTO = bll_presupuesto.consultar_varios(presupuesto)
            If LISTA_PRESUPUESTO.Count > 0 Then
                lista_presupuestos_final = Session("Lista_Presupuestos_1")
                For Each elemento As BE.BE_Presupuesto In LISTA_PRESUPUESTO
                    lista_presupuestos_final.Add(elemento)
                Next
                lista_presupuestos_final.Sort(Function(x, y) x.id.CompareTo(y.id))
            End If
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

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Try
            Session("Lista_Presupuestos_1") = Nothing
            cargar_presupuestos_estado()
            With chk_artefactos
                .Enabled = False
                .Checked = False
            End With
            With chk_materiales
                .Enabled = False
                .Checked = False
            End With
            With chk_porcluz
                .Enabled = False
                .Checked = False
            End With
            With chk_trabajos
                .Enabled = False
                .Checked = False
            End With
            With chk_valormano
                .Enabled = False
                .Checked = False
            End With
            With chk_valormaterial
                .Enabled = False
                .Checked = False
            End With
            With chk_valorotros
                .Enabled = False
                .Checked = False
            End With
            With chk_valorsegvida
                .Enabled = False
                .Checked = False
            End With
            With chk_valortrabajo
                .Enabled = False
                .Checked = False
            End With
            btn_cargar_presupuesto.Enabled = True
            btn_exportarrep.Enabled = False
            btn_cancelar.Enabled = True
            Session("Presupuesto_Impresion") = Nothing
            cmb_presupuesto.Enabled = True
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub

    Protected Sub btn_cargar_presupuesto_Click(sender As Object, e As EventArgs) Handles btn_cargar_presupuesto.Click
        Try
            With chk_artefactos
                .Enabled = True
                .Checked = False
            End With
            With chk_materiales
                .Enabled = True
                .Checked = False
            End With
            With chk_porcluz
                .Enabled = True
                .Checked = False
            End With
            With chk_trabajos
                .Enabled = True
                .Checked = False
            End With
            With chk_valormano
                .Enabled = True
                .Checked = False
            End With
            With chk_valormaterial
                .Enabled = True
                .Checked = False
            End With
            With chk_valorotros
                .Enabled = True
                .Checked = False
            End With
            With chk_valorsegvida
                .Enabled = True
                .Checked = False
            End With
            With chk_valortrabajo
                .Enabled = True
                .Checked = False
            End With
            btn_cargar_presupuesto.Enabled = False
            btn_exportarrep.Enabled = True
            btn_cancelar.Enabled = True
            cmb_presupuesto.Enabled = False
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Private Sub btn_exportarrep_Click(sender As Object, e As EventArgs) Handles btn_exportarrep.Click
        Try
            Dim be_presupuesto As BE.BE_Presupuesto
            customizar_presupuesto()
            be_presupuesto = CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Find(Function(x) x.id = cmb_presupuesto.SelectedItem.Text)
            Session("Presupuesto_Impresion") = be_presupuesto
            If TypeOf (be_presupuesto.Cliente_Persona) Is BE.BE_Personajuridica Then
                Response.Redirect("web_reporte_presupuesto_juridica.aspx", False)
            Else
                Response.Redirect("web_reporte_presupuesto_fisico.aspx", False)
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub

    Sub customizar_presupuesto()
        Try
            Dim be_presupuesto As BE.BE_Presupuesto
            be_presupuesto = CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Find(Function(x) x.id = cmb_presupuesto.SelectedItem.Text)
            If Not chk_artefactos.Checked Then
                be_presupuesto.Artefacto_electrico = Nothing
            End If
            If Not chk_materiales.Checked Then
                For Each mate As BE.BE_Material_TrabajoconPrec In be_presupuesto.Materiales_trabajo
                    If mate.Material = True Then
                        mate.id = 0
                    End If
                Next
            End If
            If Not chk_trabajos.Checked Then
                For Each mate As BE.BE_Material_TrabajoconPrec In be_presupuesto.Materiales_trabajo
                    If mate.Trabajoconprecio = True Then
                        mate.id = 0
                    End If
                Next
            End If
            If Not chk_porcluz.Checked Then
                be_presupuesto.porcentaje_aldarluz = -1
            End If

            If Not chk_valormano.Checked Then
                be_presupuesto.valor_manodeobra = -1
            End If
            If Not chk_valormaterial.Checked Then
                be_presupuesto.valor_material = -1
            End If
            If Not chk_valorotros.Checked Then
                be_presupuesto.valor_otros = -1
            End If
            If Not chk_valorsegvida.Checked Then
                be_presupuesto.valor_seguro_vida = -1
            End If
            If Not chk_valortrabajo.Checked Then
                be_presupuesto.valor_trabajoconprecio = -1
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub
End Class