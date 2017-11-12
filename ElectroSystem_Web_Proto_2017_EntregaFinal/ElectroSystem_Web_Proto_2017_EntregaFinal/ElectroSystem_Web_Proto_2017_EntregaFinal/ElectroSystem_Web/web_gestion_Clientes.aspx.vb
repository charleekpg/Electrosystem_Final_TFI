Public Class web_gestion_Clientes
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
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_gestidioma")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        Session.Add("Entero_Flag", entero_flag)
                        habilito_controles_principal()
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

    Private Function mkf_validacuit(ByVal mk_p_nro As String) As Boolean
        Dim mk_valido As String
        Dim mk_suma As Integer
        mk_valido = False
        mk_p_nro = mk_p_nro.Replace("-", "")
        If IsNumeric(mk_p_nro) Then
            If mk_p_nro.Length <> 11 Then
                mk_valido = False
            Else
                mk_suma = 0
                mk_suma += CInt(mk_p_nro.Substring(0, 1)) * 5
                mk_suma += CInt(mk_p_nro.Substring(1, 1)) * 4
                mk_suma += CInt(mk_p_nro.Substring(2, 1)) * 3
                mk_suma += CInt(mk_p_nro.Substring(3, 1)) * 2
                mk_suma += CInt(mk_p_nro.Substring(4, 1)) * 7
                mk_suma += CInt(mk_p_nro.Substring(5, 1)) * 6
                mk_suma += CInt(mk_p_nro.Substring(6, 1)) * 5
                mk_suma += CInt(mk_p_nro.Substring(7, 1)) * 4
                mk_suma += CInt(mk_p_nro.Substring(8, 1)) * 3
                mk_suma += CInt(mk_p_nro.Substring(9, 1)) * 2
                mk_suma += CInt(mk_p_nro.Substring(10, 1)) * 1
                If Math.Round(mk_suma / 11, 0) = (mk_suma / 11) Then
                    mk_valido = True
                Else
                    mk_valido = False
                End If
            End If
        Else
            mk_valido = False
        End If
        Return (mk_valido)

    End Function

    Private Sub habilito_controles_nuevo()
        RDB_personaFisica.Checked = True
        RDB_personaFisica.Enabled = True
        rdb_personaJuridica.Checked = False
        RDB_personaFisica.Enabled = True
        limpiar_campos()
        btn_nuevo.Enabled = False
        btn_cancelarcte.Enabled = True
        btn_buscarcte.Enabled = False
        btn_agregartel.Enabled = True
        btn_guardarcte.Enabled = True
        Session("Entero_flag") = 1
        txt_dni.Enabled = True
        txt_cuit.Enabled = False
        txt_apellido.Enabled = True
        txt_correoelectronico.Enabled = True
        txt_nombre.Enabled = True
        txt_razon.Enabled = False
        txt_telefono.Enabled = True
        dtg_telefonos.Enabled = True
        dtg_telefonos.Items.Clear()
        Session("Telefonos") = Nothing
        chk_clienteespecia.Enabled = True
        btn_deseleccionar.Enabled = False
    End Sub

    Protected Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        habilito_controles_nuevo()
    End Sub

    Private Sub limpiar_campos()
        txt_apellido.Text = ""
        txt_correoelectronico.Text = ""
        txt_cuit.Text = ""
        txt_dni.Text = ""
        txt_nombre.Text = ""
        txt_razon.Text = ""
        txt_telefono.Text = ""
        dtg_telefonos.Items.Clear()
        btn_deseleccionar.Enabled = False
    End Sub

    Private Sub habilitar_personajuridica()
        RDB_personaFisica.Enabled = False
        RDB_personaFisica.Checked = False
        rdb_personaJuridica.Enabled = True
        RDB_personaFisica.Checked = True
        txt_apellido.Enabled = False
        txt_correoelectronico.Enabled = True
        txt_dni.Enabled = False
        txt_nombre.Enabled = False
        txt_cuit.Enabled = True
        txt_razon.Enabled = True
        txt_telefono.Enabled = True
    End Sub

    Private Sub RDB_personaFisica_CheckedChanged(sender As Object, e As EventArgs) Handles RDB_personaFisica.CheckedChanged
        If RDB_personaFisica.Checked = True Then

            If Session("Entero_flag") <> 1 And Session("Entero_flag") <> 2 Then
                txt_dni.Enabled = True
                limpiar_campos()
                txt_cuit.Enabled = False
                txt_razon.Enabled = False
                rdb_personaJuridica.Checked = False
            Else
                If Session("Entero_flag") = 1 Then
                    txt_dni.Enabled = True
                    txt_cuit.Enabled = False
                    rdb_personaJuridica.Checked = False
                    txt_apellido.Enabled = True
                    txt_correoelectronico.Enabled = True
                    txt_nombre.Enabled = True
                    txt_razon.Enabled = False
                    txt_telefono.Enabled = True
                    btn_agregartel.Enabled = True
                    limpiar_campos()
                End If
            End If
        End If


    End Sub


    Private Sub habilito_controles_principal()
        Session("Entero_Flag") = 0
        Session("Telefonos") = Nothing
        Session("Persona_Buscada") = Nothing
        limpiar_campos()
        rdb_personaJuridica.Checked = False
        rdb_personaJuridica.Enabled = True
        RDB_personaFisica.Checked = True
        RDB_personaFisica.Enabled = True
        btn_nuevo.Enabled = True
        btn_buscarcte.Enabled = True
        btn_cancelarcte.Enabled = False
        btn_guardarcte.Enabled = False
        btn_agregartel.Enabled = False
        txt_apellido.Enabled = False
        txt_nombre.Enabled = False
        txt_razon.Enabled = False
        txt_telefono.Enabled = False
        txt_correoelectronico.Enabled = False
        chk_clienteespecia.Checked = False
        chk_clienteespecia.Enabled = False
        btn_deseleccionar.Enabled = False
        txt_dni.Enabled = True
        txt_cuit.Enabled = False
        dtg_telefonos.Enabled = True

    End Sub

    Private Sub btn_cancelarcte_Click(sender As Object, e As EventArgs) Handles btn_cancelarcte.Click
        habilito_controles_principal()
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscarcte.Click
        Try
            Dim be_telefono As New BE.BE_Telefono
            Dim i As Integer = 0
            Dim be_bitacora As New BE.BE_Bitacora
            Dim bll_bitacora As New BLL.BLL_Bitacora
            If RDB_personaFisica.Checked = True Then
                Dim be_personafisica As New BE.BE_Personafisica
                Dim bll_personafisica As New BLL.BLL_PersonaFisica
                Dim lista As List(Of BE.BE_Personafisica)
                With be_personafisica
                    .identificador = txt_dni.Text
                End With
                lista = bll_personafisica.consultar(be_personafisica)
                If lista Is Nothing Then
                    be_bitacora.usuario = Session("Usuario")
                    be_bitacora.codigo_evento = 10128
                    bll_bitacora.alta(be_bitacora)
                    Session("Entero_Flag") = 0
                    limpiar_campos()
                    rdb_personaJuridica.Checked = False
                    RDB_personaFisica.Checked = True
                    btn_nuevo.Enabled = True
                    btn_buscarcte.Enabled = True
                    btn_cancelarcte.Enabled = False
                    btn_guardarcte.Enabled = False
                    btn_agregartel.Enabled = False
                    txt_telefono.Enabled = False
                    Response.Redirect("web_error_inicio.aspx", False)
                ElseIf lista.Count > 0 Then
                    be_bitacora.codigo_evento = 10127
                    be_bitacora.usuario = Session("Usuario")
                    bll_bitacora.alta(be_bitacora)
                    For Each item As BE.BE_Personafisica In lista
                        txt_apellido.Enabled = True
                        txt_apellido.Text = item.Apellido
                        txt_correoelectronico.Enabled = True
                        txt_correoelectronico.Text = item.Correoelectronico
                        txt_dni.Text = item.identificador
                        txt_nombre.Enabled = True
                        txt_nombre.Text = item.Nombre
                        dtg_telefonos.Items.Clear()
                        dtg_telefonos.Enabled = True
                        chk_clienteespecia.Enabled = True
                        chk_clienteespecia.Checked = item.TratamientoEspecial
                        txt_cuit.Text = ""
                        txt_razon.Text = ""
                        txt_telefono.Text = ""
                        id_hiddenfield.Value = item.id
                        txt_telefono.Enabled = True
                        rdb_personaJuridica.Enabled = False
                        For Each telefono As BE.BE_Telefono In item.Telefonos
                            dtg_telefonos.Items.Add(telefono.numero_telefono)
                        Next
                        btn_agregartel.Enabled = True
                        Session("Telefonos") = item.Telefonos
                    Next
                    Session.Add("Persona_Buscada", lista.Item(0))
                    Session("Entero_flag") = 2
                    btn_nuevo.Enabled = False
                    btn_guardarcte.Enabled = True
                    btn_cancelarcte.Enabled = True
                    btn_buscarcte.Enabled = False
                ElseIf lista.Count = 0 Then
                    be_bitacora.codigo_evento = 10129
                    be_bitacora.usuario = Session("Usuario")
                    bll_bitacora.alta(be_bitacora)
                    DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_sinresultado")
                End If
            ElseIf rdb_personaJuridica.Checked = True Then
                Dim be_personajuridica As New BE.BE_Personajuridica
                Dim bll_personajuridica As New BLL.BLL_PersonaJuridica
                Dim lista As List(Of BE.BE_Personajuridica)
                With be_personajuridica
                    .identificador = txt_cuit.Text
                End With
                lista = bll_personajuridica.consultar(be_personajuridica)
                If lista Is Nothing Then
                    be_bitacora.usuario = Session("Usuario")
                    be_bitacora.codigo_evento = 10128
                    bll_bitacora.alta(be_bitacora)
                    Session("Entero_Flag") = 0
                    limpiar_campos()
                    rdb_personaJuridica.Checked = False
                    RDB_personaFisica.Checked = True
                    btn_nuevo.Enabled = True
                    btn_buscarcte.Enabled = True
                    btn_cancelarcte.Enabled = False
                    btn_guardarcte.Enabled = False
                    btn_agregartel.Enabled = False
                    Response.Redirect("web_error_inicio.aspx", False)
                ElseIf lista.Count > 0 Then
                    be_bitacora.codigo_evento = 10127
                    be_bitacora.usuario = Session("Usuario")
                    bll_bitacora.alta(be_bitacora)
                    Session.Add("Persona_Buscada", lista.Item(0))
                    For Each item As BE.BE_Personajuridica In lista
                        txt_nombre.Enabled = True
                        txt_apellido.Enabled = True
                        txt_razon.Enabled = True
                        txt_correoelectronico.Enabled = True
                        chk_clienteespecia.Enabled = True
                        btn_agregartel.Enabled = True
                        txt_razon.Text = item.Razonsocial
                        txt_correoelectronico.Text = item.Correoelectronico
                        txt_cuit.Text = item.identificador
                        chk_clienteespecia.Checked = item.TratamientoEspecial
                        dtg_telefonos.Items.Clear()
                        txt_apellido.Text = item.Referente.Apellido
                        txt_dni.Text = ""
                        txt_nombre.Text = item.Referente.Nombre
                        id_hiddenfield.Value = item.id
                        txt_telefono.Enabled = True
                        RDB_personaFisica.Enabled = False

                        For Each telefono As BE.BE_Telefono In item.Telefonos
                            dtg_telefonos.Items.Add(telefono.numero_telefono)
                        Next
                        Session("Telefonos") = item.Telefonos
                    Next
                    Session("Entero_flag") = 2
                    btn_nuevo.Enabled = False
                    btn_guardarcte.Enabled = True
                    btn_cancelarcte.Enabled = True
                    btn_buscarcte.Enabled = False
                ElseIf lista.Count = 0 Then
                    be_bitacora.codigo_evento = 10129
                    be_bitacora.usuario = Session("Usuario")
                    bll_bitacora.alta(be_bitacora)
                    DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_sinresultado")
                End If
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Private Sub btn_agregartel_Click(sender As Object, e As EventArgs) Handles btn_agregartel.Click
        If Len(Trim(txt_telefono.Text)) < 5 Then
            DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_telefonoformato")
        Else
            Dim repeticion As Boolean = False
            For Each item As ListItem In dtg_telefonos.Items
                If item.Text = txt_telefono.Text Then
                    repeticion = True
                End If
            Next
            If repeticion = False Then
                Dim seleccion As Boolean = False
                For Each item As ListItem In dtg_telefonos.Items
                    If item.Selected = True Then
                        item.Text = Trim(txt_telefono.Text)
                        seleccion = True
                        Exit For
                    End If
                Next
                If seleccion = True Then
                    For Each item As ListItem In dtg_telefonos.Items
                        item.Selected = False
                    Next
                Else
                    dtg_telefonos.Items.Add(txt_telefono.Text)
                End If
            End If
            txt_telefono.Text = ""
            For Each item As ListItem In dtg_telefonos.Items
                item.Selected = False
            Next
        End If

    End Sub

    Private Sub btn_guardarcte_Click(sender As Object, e As EventArgs) Handles btn_guardarcte.Click
        Dim bll_personafisica As New BLL.BLL_PersonaFisica
        Dim be_bitacora As New BE.BE_Bitacora
        Dim bll_bitacora As New BLL.BLL_Bitacora
        Dim bll_personajuridica As New BLL.BLL_PersonaJuridica
        If RDB_personaFisica.Checked = True Then
            If Len(Trim(txt_dni.Text)) = 0 Or Len(Trim(txt_nombre.Text)) = 0 Or Len(Trim(txt_apellido.Text)) = 0 Or Len(Trim(txt_correoelectronico.Text)) = 0 Or dtg_telefonos.Items.Count = 0 Then
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_camposincompletos")
                GoTo 1
            ElseIf Len(Trim(txt_dni.Text)) < 8 Then
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_dnilength")
                GoTo 1
            ElseIf Session("Entero_flag") = 1 Then
                Dim be_personafisica As New BE.BE_Personafisica
                Dim be_telefono As New List(Of BE.BE_Telefono)
                With be_personafisica
                    .Apellido = txt_apellido.Text
                    .Nombre = txt_nombre.Text
                    .identificador = txt_dni.Text
                    For Each item In dtg_telefonos.Items
                        Dim tmp_telefono As New BE.BE_Telefono
                        tmp_telefono.eliminar = False
                        tmp_telefono.numero_telefono = item.text
                        be_telefono.Add(tmp_telefono)
                    Next
                    .Telefonos = be_telefono
                    .Correoelectronico = txt_correoelectronico.Text
                    .TratamientoEspecial = chk_clienteespecia.Checked
                End With
                Select Case bll_personafisica.alta(be_personafisica)
                    Case 10119
                        be_bitacora.codigo_evento = 10119
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_errorduplicidadcte")
                        GoTo 1
                    Case 10120
                        be_bitacora.codigo_evento = 10120
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Session("Entero_Flag") = 0
                        limpiar_campos()
                        rdb_personaJuridica.Checked = False
                        RDB_personaFisica.Checked = True
                        btn_nuevo.Enabled = True
                        btn_buscarcte.Enabled = True
                        btn_cancelarcte.Enabled = False
                        btn_guardarcte.Enabled = False
                        btn_agregartel.Enabled = False
                        Response.Redirect("web_error_inicio.aspx", False)
                    Case 10121
                        be_bitacora.codigo_evento = 10121
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_telefonoduplicado")
                    Case 10122
                        be_bitacora.codigo_evento = 10122
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Session("Entero_Flag") = 0
                        limpiar_campos()
                        rdb_personaJuridica.Checked = False
                        RDB_personaFisica.Checked = True
                        btn_nuevo.Enabled = True
                        btn_buscarcte.Enabled = True
                        btn_cancelarcte.Enabled = False
                        btn_guardarcte.Enabled = False
                        btn_agregartel.Enabled = False
                        Response.Redirect("web_error_inicio.aspx", False)
                    Case 10123
                        be_bitacora.codigo_evento = 10123
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_altacorrecta")
                        habilito_controles_principal()
                    Case 10125
                        be_bitacora.codigo_evento = 10125
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Session("Entero_Flag") = 0
                        limpiar_campos()
                        rdb_personaJuridica.Checked = False
                        RDB_personaFisica.Checked = True
                        btn_nuevo.Enabled = True
                        btn_buscarcte.Enabled = True
                        btn_cancelarcte.Enabled = False
                        btn_guardarcte.Enabled = False
                        btn_agregartel.Enabled = False
                        Response.Redirect("web_error_inicio.aspx", False)
                End Select
            ElseIf Session("Entero_flag") = 2 Then
                Dim be_personafisica As New BE.BE_Personafisica
                Dim be_telefono As New List(Of BE.BE_Telefono)
                With be_personafisica
                    .Apellido = txt_apellido.Text
                    .Nombre = txt_nombre.Text
                    .identificador = txt_dni.Text
                    .id = id_hiddenfield.Value
                    Dim lista As List(Of BE.BE_Telefono) = Session("Telefonos")
                    For Each item In dtg_telefonos.Items
                        Dim existe As Boolean = False
                        For Each elemento As BE.BE_Telefono In lista
                            If elemento.numero_telefono = item.TEXT Then
                                elemento.eliminar = False
                                be_telefono.Add(elemento)
                                existe = True
                            End If
                        Next
                        If existe = False Then
                            Dim tmp_telefono As New BE.BE_Telefono
                            tmp_telefono.eliminar = False
                            tmp_telefono.numero_telefono = item.text
                            be_telefono.Add(tmp_telefono)
                        End If
                    Next
                    .Telefonos = be_telefono
                    .Correoelectronico = txt_correoelectronico.Text
                    .TratamientoEspecial = chk_clienteespecia.Checked
                End With
                Select Case bll_personafisica.modificar(be_personafisica)
                    Case 10119
                        be_bitacora.codigo_evento = 10133
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_errorduplicidadcte")
                        GoTo 1
                    Case 10120
                        be_bitacora.codigo_evento = 10134
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Session("Entero_Flag") = 0
                        limpiar_campos()
                        rdb_personaJuridica.Checked = False
                        RDB_personaFisica.Checked = True
                        btn_nuevo.Enabled = True
                        btn_buscarcte.Enabled = True
                        btn_cancelarcte.Enabled = False
                        btn_guardarcte.Enabled = False
                        btn_agregartel.Enabled = False
                        Response.Redirect("web_error_inicio.aspx", False)
                    Case 10121
                        be_bitacora.codigo_evento = 10121
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_telefonoduplicado")
                    Case 10122
                        be_bitacora.codigo_evento = 10122
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Session("Entero_Flag") = 0
                        limpiar_campos()
                        rdb_personaJuridica.Checked = False
                        RDB_personaFisica.Checked = True
                        btn_nuevo.Enabled = True
                        btn_buscarcte.Enabled = True
                        btn_cancelarcte.Enabled = False
                        btn_guardarcte.Enabled = False
                        btn_agregartel.Enabled = False
                        Response.Redirect("web_error_inicio.aspx", False)
                    Case 10135
                        be_bitacora.codigo_evento = 10135
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_modificacionok")
                        habilito_controles_principal()
                    Case 10125
                        be_bitacora.codigo_evento = 10125
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Session("Entero_Flag") = 0
                        limpiar_campos()
                        rdb_personaJuridica.Checked = False
                        RDB_personaFisica.Checked = True
                        btn_nuevo.Enabled = True
                        btn_buscarcte.Enabled = True
                        btn_cancelarcte.Enabled = False
                        btn_guardarcte.Enabled = False
                        btn_agregartel.Enabled = False
                        Response.Redirect("web_error_inicio.aspx", False)
                    Case 10134
                        be_bitacora.codigo_evento = 10134
                        be_bitacora.usuario = Session("Usuario")
                        bll_bitacora.alta(be_bitacora)
                        Session("Entero_Flag") = 0
                        limpiar_campos()
                        rdb_personaJuridica.Checked = False
                        RDB_personaFisica.Checked = True
                        btn_nuevo.Enabled = True
                        btn_buscarcte.Enabled = True
                        btn_cancelarcte.Enabled = False
                        btn_guardarcte.Enabled = False
                        btn_agregartel.Enabled = False
                        Response.Redirect("web_error_inicio.aspx", False)
                End Select
            End If
        Else
            If Len(Trim(txt_cuit.Text)) = 0 Or Len(Trim(txt_razon.Text)) = 0 Or Len(Trim(txt_nombre.Text)) = 0 Or Len(Trim(txt_apellido.Text)) = 0 Or Len(Trim(txt_correoelectronico.Text)) = 0 Or dtg_telefonos.Items.Count = 0 Then
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_camposincompletos")
                GoTo 1
            ElseIf Len(Trim(txt_cuit.Text)) < 11 Then
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_txtcuitlenght")
                GoTo 1
            ElseIf Me.mkf_validacuit(txt_cuit.Text) = False Then
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_cuitinvalido")
                GoTo 1
            Else
                If Session("Entero_flag") = 1 Then
                    Dim be_personajuridica As New BE.BE_Personajuridica
                    Dim be_telefono As New List(Of BE.BE_Telefono)
                    With be_personajuridica
                        .Razonsocial = txt_razon.Text
                        .identificador = txt_cuit.Text
                        For Each item In dtg_telefonos.Items
                            Dim tmp_telefono As New BE.BE_Telefono
                            tmp_telefono.eliminar = False
                            tmp_telefono.numero_telefono = item.text
                            be_telefono.Add(tmp_telefono)
                        Next
                        .Telefonos = be_telefono
                        .Correoelectronico = txt_correoelectronico.Text
                        .TratamientoEspecial = chk_clienteespecia.Checked
                        .Referente = New BE.BE_Personafisica
                        .Referente.Nombre = txt_nombre.Text
                        .Referente.Apellido = txt_apellido.Text
                    End With
                    Select Case bll_personajuridica.alta(be_personajuridica)
                        Case 10119
                            be_bitacora.codigo_evento = 10119
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_errorduplicidadcte")
                            GoTo 1
                        Case 10120
                            be_bitacora.codigo_evento = 10120
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            Session("Entero_Flag") = 0
                            limpiar_campos()
                            rdb_personaJuridica.Checked = False
                            RDB_personaFisica.Checked = True
                            btn_nuevo.Enabled = True
                            btn_buscarcte.Enabled = True
                            btn_cancelarcte.Enabled = False
                            btn_guardarcte.Enabled = False
                            btn_agregartel.Enabled = False
                            Response.Redirect("web_error_inicio.aspx", False)
                        Case 10121
                            be_bitacora.codigo_evento = 10121
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_telefonoduplicado")
                        Case 10122
                            be_bitacora.codigo_evento = 10122
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            Session("Entero_Flag") = 0
                            limpiar_campos()
                            rdb_personaJuridica.Checked = False
                            RDB_personaFisica.Checked = True
                            btn_nuevo.Enabled = True
                            btn_buscarcte.Enabled = True
                            btn_cancelarcte.Enabled = False
                            btn_guardarcte.Enabled = False
                            btn_agregartel.Enabled = False
                            Response.Redirect("web_error_inicio.aspx", False)
                        Case 10124
                            be_bitacora.codigo_evento = 10124
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_altacorrecta")
                            habilito_controles_principal()

                        Case 10126
                            be_bitacora.codigo_evento = 10126
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            Session("Entero_Flag") = 0
                            limpiar_campos()
                            rdb_personaJuridica.Checked = False
                            RDB_personaFisica.Checked = True
                            btn_nuevo.Enabled = True
                            btn_buscarcte.Enabled = True
                            btn_cancelarcte.Enabled = False
                            btn_guardarcte.Enabled = False
                            btn_agregartel.Enabled = False
                            Response.Redirect("web_error_inicio.aspx", False)
                    End Select
                ElseIf Session("Entero_flag") = 2 Then
                    Dim be_personajuridica As New BE.BE_Personajuridica
                    Dim be_telefono As New List(Of BE.BE_Telefono)
                    With be_personajuridica
                        .Razonsocial = txt_razon.Text
                        .identificador = txt_cuit.Text
                        Dim lista As List(Of BE.BE_Telefono) = Session("Telefonos")
                        For Each item In dtg_telefonos.Items
                            Dim existe As Boolean = False
                            For Each elemento As BE.BE_Telefono In lista
                                If elemento.numero_telefono = item.TEXT Then
                                    elemento.eliminar = False
                                    be_telefono.Add(elemento)
                                    existe = True
                                End If
                            Next
                            If existe = False Then
                                Dim tmp_telefono As New BE.BE_Telefono
                                tmp_telefono.eliminar = False
                                tmp_telefono.numero_telefono = item.text
                                be_telefono.Add(tmp_telefono)
                            End If
                        Next
                        .id = id_hiddenfield.Value
                        .Telefonos = be_telefono
                        .Correoelectronico = txt_correoelectronico.Text
                        .TratamientoEspecial = chk_clienteespecia.Checked
                        .Referente = New BE.BE_Personafisica
                        .Referente.Nombre = txt_nombre.Text
                        .Referente.Apellido = txt_apellido.Text
                    End With
                    Select Case bll_personajuridica.modificar(be_personajuridica)
                        Case 10119
                            be_bitacora.codigo_evento = 10119
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_errorduplicidadcte")
                            GoTo 1
                        Case 10120
                            be_bitacora.codigo_evento = 10134
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            Session("Entero_Flag") = 0
                            limpiar_campos()
                            rdb_personaJuridica.Checked = False
                            RDB_personaFisica.Checked = True
                            btn_nuevo.Enabled = True
                            btn_buscarcte.Enabled = True
                            btn_cancelarcte.Enabled = False
                            btn_guardarcte.Enabled = False
                            btn_agregartel.Enabled = False
                            Response.Redirect("web_error_inicio.aspx", False)
                        Case 10121
                            be_bitacora.codigo_evento = 10121
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_telefonoduplicado")
                        Case 10122
                            be_bitacora.codigo_evento = 10122
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            Session("Entero_Flag") = 0
                            limpiar_campos()
                            rdb_personaJuridica.Checked = False
                            RDB_personaFisica.Checked = True
                            btn_nuevo.Enabled = True
                            btn_buscarcte.Enabled = True
                            btn_cancelarcte.Enabled = False
                            btn_guardarcte.Enabled = False
                            btn_agregartel.Enabled = False
                            Response.Redirect("web_error_inicio.aspx", False)
                        Case 10136
                            be_bitacora.codigo_evento = 10136
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_modificacionok")
                            Session("Entero_Flag") = 0
                            limpiar_campos()
                            rdb_personaJuridica.Checked = False
                            RDB_personaFisica.Checked = True
                            btn_nuevo.Enabled = True
                            btn_buscarcte.Enabled = True
                            btn_cancelarcte.Enabled = False
                            btn_guardarcte.Enabled = False
                            btn_agregartel.Enabled = False
                            habilito_controles_principal()

                        Case 10126
                            be_bitacora.codigo_evento = 10126
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            Session("Entero_Flag") = 0
                            limpiar_campos()
                            rdb_personaJuridica.Checked = False
                            RDB_personaFisica.Checked = True
                            btn_nuevo.Enabled = True
                            btn_buscarcte.Enabled = True
                            btn_cancelarcte.Enabled = False
                            btn_guardarcte.Enabled = False
                            btn_agregartel.Enabled = False
                            Response.Redirect("web_error_inicio.aspx", False)
                        Case 10134
                            be_bitacora.codigo_evento = 10134
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            Session("Entero_Flag") = 0
                            limpiar_campos()
                            rdb_personaJuridica.Checked = False
                            RDB_personaFisica.Checked = True
                            btn_nuevo.Enabled = True
                            btn_buscarcte.Enabled = True
                            btn_cancelarcte.Enabled = False
                            btn_guardarcte.Enabled = False
                            btn_agregartel.Enabled = False
                            Response.Redirect("web_error_inicio.aspx", False)
                    End Select
                End If
            End If
        End If
1:
    End Sub

    Protected Sub rdb_personaJuridica_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_personaJuridica.CheckedChanged
        If rdb_personaJuridica.Checked = True Then
            If Session("Entero_flag") <> 1 And Session("Entero_flag") <> 2 Then
                txt_cuit.Enabled = True
                limpiar_campos()
                txt_dni.Enabled = False
                RDB_personaFisica.Checked = False
            Else
                If Session("Entero_flag") = 1 Then
                    txt_cuit.Enabled = True
                    txt_dni.Enabled = False
                    RDB_personaFisica.Checked = False
                    txt_apellido.Enabled = True
                    txt_correoelectronico.Enabled = True
                    txt_nombre.Enabled = True
                    txt_razon.Enabled = True
                    txt_telefono.Enabled = True
                    btn_agregartel.Enabled = True
                    limpiar_campos()
                End If
            End If
        End If



    End Sub

    Private Sub dtg_telefonos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dtg_telefonos.SelectedIndexChanged
        For Each item As ListItem In dtg_telefonos.Items
            If item.Selected = True Then
                txt_telefono.Text = item.Text
                btn_deseleccionar.Enabled = True
                Exit For
            Else
                txt_telefono.Text = ""
                btn_deseleccionar.Enabled = False
            End If
        Next
    End Sub

    Private Sub btn_deseleccionar_Click(sender As Object, e As EventArgs) Handles btn_deseleccionar.Click
        For Each item As ListItem In dtg_telefonos.Items
            item.Selected = False
        Next
        txt_telefono.Text = ""
        btn_deseleccionar.Enabled = False
    End Sub
End Class