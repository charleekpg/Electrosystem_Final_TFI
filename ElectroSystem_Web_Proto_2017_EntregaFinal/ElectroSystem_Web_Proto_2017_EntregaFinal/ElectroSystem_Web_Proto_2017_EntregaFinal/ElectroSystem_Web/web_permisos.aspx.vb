Public Class web_permisos
    Inherits System.Web.UI.Page
    Dim usu As BE.BE_Usuario
    Private cambio As Boolean
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_opcion_permisos")

                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        cambio = False
                        Session.Add("Cambio", cambio)
                        Me.formato_inicial()
                    Else
                        Response.Redirect("web_login.aspx", False)
                    End If
                End If
            Else
               ' DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                Me.entro = True
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Private Sub cargar_patentes()
        Try
            'esto esta OK.
            Dim bll_permisos As New BLL.BLL_Permisos
            Dim lista_patentes As List(Of BE.BE_Patente)
            lista_patentes = bll_permisos.listar_permisossimples()
            Session.Add("Patentes", lista_patentes)
            lst_patentes.DataSource = lista_patentes
            lst_patentes.DataValueField = "Descripcion"
            lst_patentes.DataBind()
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub

    Private Sub cargar_permisoscompuestos_modificable()
        Try
            Dim bll_permisos As New BLL.BLL_Permisos
            Dim lista_permisoscompuestos As List(Of BE.BE_Permisocompuesto)
            lista_permisoscompuestos = bll_permisos.listar_permisoscompuestos()
            Session.Add("Roles_Modificables", lista_permisoscompuestos)
            lst_roles_modificables.Items.Clear()
            lst_roles_modificables.DataSource = lista_permisoscompuestos
            lst_roles_modificables.DataValueField = "Descripcion"
            lst_roles_modificables.DataBind()
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Private Sub cargar_permisoscompuestos()
        Try
            Dim bll_permisos As New BLL.BLL_Permisos
            Dim lista_permisoscompuestos As List(Of BE.BE_Permisocompuesto)
            lista_permisoscompuestos = bll_permisos.listar_permisoscompuestos()
            Session.Add("Roles", lista_permisoscompuestos)
            lst_roles.Items.Clear()
            lst_roles.DataSource = lista_permisoscompuestos
            lst_roles.DataValueField = "Descripcion"
            lst_roles.DataBind()
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Private Sub diseno_modificar_eliminar()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_eliminar.Enabled = True
        btn_cancelar.Enabled = True
        txtpermiso.Enabled = True
        lst_roles.Enabled = True
        lst_patentes.Enabled = True
    End Sub

    Private Sub lst_roles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_roles.SelectedIndexChanged

    End Sub

    Private Sub formato_inicial()
        'revisado, ok
        cargar_patentes()
        cargar_permisoscompuestos()
        cargar_permisoscompuestos_modificable()
        lst_patentes.Enabled = False
        lst_roles.Enabled = False
        lst_roles_modificables.Enabled = True
        btn_nuevo.Enabled = True
        btn_guardar.Enabled = False
        btn_eliminar.Enabled = False
        btn_cancelar.Enabled = False
        Session("Cambio") = False
        txtpermiso.Enabled = False
        txtpermiso.Text = ""

    End Sub

    Private Sub recorrer_permisos(unbe As BE.BE_PermisoBase)
        If TypeOf (unbe) Is BE.BE_Permisocompuesto Then
            For Each permiso As BE.BE_PermisoBase In CType(unbe, BE.BE_Permisocompuesto).lista_permisos
                If TypeOf (unbe) Is BE.BE_Patente Then
                    lst_roles.Items.Add(unbe.Descripcion)
                Else
                    lst_roles.Items.Add(unbe.Descripcion)
                    Me.recorrer_permisos(unbe)
                End If
            Next
        End If
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim be_bitacora As New BE.BE_Bitacora
            Dim bll_bitacora As New BLL.BLL_Bitacora
            Dim permiso As BE.BE_Permisocompuesto
            Dim bll_permiso As New BLL.BLL_Permisos
            Dim lista_permisos As List(Of BE.BE_Permisocompuesto)
            lista_permisos = Session("Roles_Modificables")
            permiso = lista_permisos.Find(Function(x) x.Descripcion = lst_roles_modificables.SelectedItem.Text)
            Select Case bll_permiso.baja(permiso)
                Case 7009
                    be_bitacora.codigo_evento = 7009
                    be_bitacora.usuario = Session("Usuario")
                    bll_bitacora.alta(be_bitacora)
                    formato_inicial()
                    Session("Cambio") = False
                    DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_rolconusuario")
                Case 7010
                    be_bitacora.codigo_evento = 7010
                    be_bitacora.usuario = Session("Usuario")
                    bll_bitacora.alta(be_bitacora)
                    Response.Redirect("web_error_inicio.aspx", False)
                Case 7011
                    be_bitacora.codigo_evento = 7011
                    be_bitacora.usuario = Session("Usuario")
                    bll_bitacora.alta(be_bitacora)
                    formato_inicial()
                    Session("Cambio") = False
                    DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_borradorolok")
            End Select
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Protected Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        'revisado, ok
        txtpermiso.Enabled = True
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_eliminar.Enabled = False
        btn_cancelar.Enabled = True
        Session("Cambio") = False
        lst_roles_modificables.Enabled = False
        lst_roles.Enabled = True
        lst_patentes.Enabled = True
    End Sub

    Private Sub lst_roles_modificables_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_roles_modificables.SelectedIndexChanged
        'revisado ok
        For Each item As ListItem In lst_patentes.Items
            item.Selected = False
        Next
        For Each item As ListItem In lst_roles.Items
            item.Selected = False
        Next
        Session("Cambio") = True
        diseno_modificar_eliminar()
        Dim be_permisocompuesto As BE.BE_Permisocompuesto
        Dim lista As List(Of BE.BE_Permisocompuesto)
        lista = Session("Roles_Modificables")
        be_permisocompuesto = lista.Find(Function(x) x.Descripcion = lst_roles_modificables.SelectedValue)
        For Each patente As BE.BE_PermisoBase In be_permisocompuesto.lista_permisos
            For Each item As ListItem In lst_patentes.Items
                If patente.Descripcion = item.Text Then
                    item.Selected = True
                End If
            Next
            For Each item As ListItem In lst_roles.Items
                If patente.Descripcion = item.Text Then
                    item.Selected = True
                End If
            Next
        Next
        txtpermiso.Text = be_permisocompuesto.Descripcion
        txtpermiso.Enabled = False
    End Sub

    Protected Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        'revisado, ok
        Me.formato_inicial()
    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Try
            Dim validar_seleccion As Integer = 0
            For Each item As ListItem In lst_patentes.Items
                If item.Selected = True Then
                    validar_seleccion = 1
                End If
            Next
            For Each item As ListItem In lst_roles.Items
                If item.Selected = True Then
                    validar_seleccion = 1
                End If
            Next
            If validar_seleccion = 1 Then
                Dim be_bitacora As New BE.BE_Bitacora
                Dim bll_bitacora As New BLL.BLL_Bitacora
                Dim permiso As New BLL.BLL_Permisos
                If Session("Cambio") = True Then
                    Dim rol As BE.BE_Permisocompuesto
                    Dim LISTA_ROLES As List(Of BE.BE_Permisocompuesto)
                    Dim lista As List(Of BE.BE_Patente)
                    Dim patente As BE.BE_Patente
                    Dim be_permiso_compuesto As BE.BE_Permisocompuesto
                    LISTA_ROLES = Session("Roles_Modificables")
                    rol = LISTA_ROLES.Find(Function(x) x.Descripcion = lst_roles_modificables.SelectedItem.Text)
                    If rol.idpermiso = CType(Session("Usuario"), BE.BE_Usuario).permiso_usuario.idpermiso Then
                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_mismopermiso")
                        Exit Sub
                    End If
                    'aca me falta validar lo del texto
                    If txtpermiso.Text <> "" Then
                        rol.Descripcion = txtpermiso.Text
                        rol.lista_permisos.Clear()
                        For Each item As ListItem In lst_patentes.Items
                            If item.Selected = True Then
                                lista = Session("Patentes")
                                patente = lista.Find(Function(x) x.Descripcion = item.Text)
                                rol.lista_permisos.Add(patente)
                            End If
                        Next
                        For Each item As ListItem In lst_roles.Items
                            If item.Selected = True Then
                                If item.Text = txtpermiso.Text Then
                                Else
                                    LISTA_ROLES = Session("Roles")
                                    be_permiso_compuesto = LISTA_ROLES.Find(Function(x) x.Descripcion = item.Text)
                                    rol.lista_permisos.Add(be_permiso_compuesto)
                                End If
                            End If
                        Next
                        Select Case permiso.modificar(rol)
                            Case 1999
                                be_bitacora.codigo_evento = 1999
                                be_bitacora.usuario = Session("Usuario")
                                bll_bitacora.alta(be_bitacora)
                                Response.Redirect("web_error_inicio.aspx", False)
                            Case 1998
                                be_bitacora.codigo_evento = 1998
                                be_bitacora.usuario = Session("Usuario")
                                bll_bitacora.alta(be_bitacora)
                                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_familiaduplica")
                            Case 1990
                                be_bitacora.codigo_evento = 1990
                                be_bitacora.usuario = Session("Usuario")
                                bll_bitacora.alta(be_bitacora)
                                formato_inicial()

                                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_modificaok")

                            Case 1989
                                be_bitacora.codigo_evento = 1989
                                be_bitacora.usuario = Session("Usuario")
                                bll_bitacora.alta(be_bitacora)
                                Response.Redirect("web_error_inicio.aspx", False)

                        End Select
                    End If

                Else
                    'aca me falta validar lo del texto
                    If txtpermiso.Text <> "" Then
                        Dim rol As New BE.BE_Permisocompuesto
                        rol.Descripcion = txtpermiso.Text
                        Dim lista As List(Of BE.BE_Patente)
                        Dim lista_roles As List(Of BE.BE_Permisocompuesto)
                        Dim be_permiso_compuesto As BE.BE_Permisocompuesto
                        Dim patente As BE.BE_Patente
                        For Each item As ListItem In lst_patentes.Items
                            If item.Selected = True Then
                                lista = Session("Patentes")
                                patente = lista.Find(Function(x) x.Descripcion = item.Text)
                                rol.lista_permisos.Add(patente)
                            End If
                        Next
                        For Each item As ListItem In lst_roles.Items
                            If item.Selected = True Then
                                lista_roles = Session("Roles")
                                be_permiso_compuesto = lista_roles.Find(Function(x) x.Descripcion = item.Text)
                                rol.lista_permisos.Add(be_permiso_compuesto)
                            End If
                        Next
                        Select Case permiso.alta(rol)
                            Case 1999
                                be_bitacora.codigo_evento = 1999
                                be_bitacora.usuario = Session("Usuario")
                                bll_bitacora.alta(be_bitacora)
                                Response.Redirect("web_error_inicio.aspx", False)
                            Case 1998
                                be_bitacora.codigo_evento = 1998
                                be_bitacora.usuario = Session("Usuario")
                                bll_bitacora.alta(be_bitacora)
                                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_familiaduplica")
                            Case 1997
                                be_bitacora.codigo_evento = 1997
                                be_bitacora.usuario = Session("Usuario")
                                bll_bitacora.alta(be_bitacora)
                                formato_inicial()

                                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_altacorrecta")

                            Case 1996
                                be_bitacora.codigo_evento = 1996
                                be_bitacora.usuario = Session("Usuario")
                                bll_bitacora.alta(be_bitacora)
                                Response.Redirect("web_error_inicio.aspx", False)
                        End Select
                    End If
                End If
            Else
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_debeseleccionar")
            End If

        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try
       

    End Sub


End Class