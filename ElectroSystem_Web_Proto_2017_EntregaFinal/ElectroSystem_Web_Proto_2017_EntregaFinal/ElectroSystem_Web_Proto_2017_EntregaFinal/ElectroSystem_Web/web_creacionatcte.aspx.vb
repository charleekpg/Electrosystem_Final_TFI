Public Class web_creacionatcte
    Inherits System.Web.UI.Page
    Dim entro As Boolean = False
    Dim tienepermiso As Boolean = True
    Dim usu As BE.BE_Usuario
    Dim dibujo_tecnico As BE.BE_DibujoTecnico
    Dim entero_flag As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If IsPostBack = False Then
                If entro = False Then
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_gest_dom")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        Session("Entero_Flag") = entero_flag
                        formato_inicial()
                        cargar_partidos()
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

    Sub cargar_partidos()
        Try
            cbx_parti.Items.Clear()
            cbx_localidad.Items.Clear()
            Dim bll_partidos As New BLL.bll_partido
            Dim lista_partido As List(Of BE.BE_Partido)
            lista_partido = Application("Partidos")
            If Not lista_partido Is Nothing Then
                cbx_parti.DataSource = lista_partido
                cbx_parti.DataTextField = "partido"
                cbx_parti.DataBind()
                cargar_localidad(lista_partido.Item(0))
            Else
                Response.Redirect("web_error_inicio.aspx", False)
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Sub formato_inicial()
        Try
            txt_nombre_razonsocial.Enabled = False
            txt_nombre_razonsocial.Text = ""
            cbx_localidad.Items.Clear()
            cbx_localidad.Enabled = False
            cbx_parti.Items.Clear()
            cbx_parti.Enabled = False
            txt_dnicuit.Text = ""
            txt_calle.Text = ""
            txt_calle.Enabled = False
            txt_depto.Text = ""
            txt_depto.Enabled = False
            txt_piso.Text = ""
            txt_piso.Enabled = False
            drp_dibujo.Items.Clear()
            drp_dibujo.Enabled = False
            chk_country.Checked = False
            chk_country.Enabled = False
            btn_nuevopresu.Enabled = True
            btn_guardarpresu.Enabled = False
            txt_altura.Enabled = False
            txt_altura.Text = ""
            txt_dnicuit.Text = ""
            txt_dnicuit.Enabled = False
            btn_buscar.Enabled = False
            id.Value = ""
            Session("Entero_Flag") = 0
            Session("Lista_Presupuestos_1") = Nothing
            cargar_presupuestos_estado()
            Session("Busqueda_cliente") = Nothing
            Session("Lista_Dibujos") = Nothing
            btn_cancelarpresu.Enabled = True
            cargar_partidos()
            btn_verdibujo.Enabled = False
            DirectCast(Me.Master, General_Electrosystem).traducir_grilla(dtg_ambientes)

            dtg_ambientes.DataSource = Nothing
            dtg_ambientes.DataBind()
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub

    Sub cargar_localidad(unbe As BE.BE_Partido)
        Try
            cbx_localidad.Items.Clear()
            For Each localidad As BE.be_localidad In unbe.localidades
                cbx_localidad.Items.Add(localidad.localidad)
            Next
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

    Protected Sub btn_nuevopresu_Click(sender As Object, e As EventArgs) Handles btn_nuevopresu.Click
        Try
            txt_dnicuit.Text = ""
            txt_dnicuit.Enabled = True
            btn_nuevopresu.Enabled = False
            btn_guardarpresu.Enabled = False
            btn_cancelarpresu.Enabled = True
            cmb_presupuesto.Enabled = False
            Session("Entero_Flag") = 1
            cmb_presupuesto.Enabled = False
            btn_buscar.Enabled = True
            btn_cargar_presupuesto.Enabled = False
            cbx_parti.Enabled = False
            cbx_localidad.Enabled = False

        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Try
            Dim be_persona_juridica As New BE.BE_Personajuridica
            Dim bll_persona_juridica As New BLL.BLL_PersonaJuridica
            Dim lista_persona As List(Of BE.BE_Personajuridica)
            Dim lista_dibujos As List(Of BE.BE_DibujoTecnico)
            Dim bll_dibujos As New BLL.bll_dibujotecnico
            be_persona_juridica.identificador = txt_dnicuit.Text
            Session("Busqueda_cliente") = Nothing
            cbx_parti.Enabled = True
            cbx_localidad.Enabled = True
            lista_persona = bll_persona_juridica.consultar(be_persona_juridica)
            If lista_persona.Count = 0 Then
                Dim be_persona_fisica As New BE.BE_Personafisica
                Dim bll_persona_fisica As New BLL.BLL_PersonaFisica
                Dim lista_persona_fisica As List(Of BE.BE_Personafisica)
                be_persona_fisica.identificador = txt_dnicuit.Text
                lista_persona_fisica = bll_persona_fisica.consultar(be_persona_fisica)
                If lista_persona_fisica.Count = 0 Then
                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_sinresultados"))
                    formato_inicial()
                Else
                    For Each persona As BE.BE_Personafisica In lista_persona_fisica
                        Session("Busqueda_cliente") = persona
                        id.Value = persona.id
                        txt_nombre_razonsocial.Text = persona.Nombre & " " & persona.Apellido
                    Next
                    txt_altura.Enabled = True
                    txt_altura.Text = ""
                    txt_calle.Enabled = True
                    txt_calle.Text = ""
                    txt_depto.Enabled = True
                    txt_depto.Text = ""
                    txt_piso.Enabled = True
                    txt_piso.Text = ""
                    chk_country.Enabled = True
                    btn_guardarpresu.Enabled = True
                    lista_dibujos = bll_dibujos.consultartodos()
                    Session("Lista_Dibujos") = Nothing
                    Session("Lista_dibujos") = lista_dibujos
                    drp_dibujo.Items.Clear()
                    drp_dibujo.Items.Add("N/A")
                    drp_dibujo.Enabled = True
                    For Each item As BE.BE_DibujoTecnico In lista_dibujos
                        drp_dibujo.Items.Add(item.id)
                    Next
                End If
            Else
                For Each persona As BE.BE_Personajuridica In lista_persona
                    Session("Busqueda_cliente") = Nothing
                    Session("Busqueda_cliente") = persona
                    id.Value = persona.id
                    txt_nombre_razonsocial.Text = persona.Razonsocial
                Next
                txt_altura.Enabled = True
                txt_altura.Text = ""
                txt_calle.Enabled = True
                txt_calle.Text = ""
                txt_depto.Enabled = True
                txt_depto.Text = ""
                txt_piso.Enabled = True
                txt_piso.Text = ""
                CHK_Country.Enabled = True
                btn_guardarpresu.Enabled = True
                lista_dibujos = bll_dibujos.consultartodos()
                Session("Lista_Dibujos") = Nothing
                Session("Lista_dibujos") = lista_dibujos
                drp_dibujo.Items.Clear()
                drp_dibujo.Items.Add("N/A")
                drp_dibujo.Enabled = True

                For Each item As BE.BE_DibujoTecnico In lista_dibujos
                    drp_dibujo.Items.Add(item.id)
                Next
                drp_dibujo.Enabled = True
            End If
            btn_buscar.Enabled = False
            txt_dnicuit.Enabled = False
            btn_verdibujo.Enabled = True

        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Protected Sub btn_guardarpresu_Click(sender As Object, e As EventArgs) Handles btn_guardarpresu.Click
        Try
            Dim be_bitacora As New BE.BE_Bitacora
            Dim bll_bitacora As New BLL.BLL_Bitacora
            Dim usuario As BE.BE_CLIENTE
            If Session("Entero_Flag") = 1 Then
                usuario = Session("Busqueda_cliente")
                If usuario Is Nothing Then
                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_cargarcliente"))
                    GoTo 0
                Else
                    If cbx_parti.SelectedItem Is Nothing Then
                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_faltapartido"))
                        GoTo 0
                    Else
                        If cbx_localidad.SelectedItem Is Nothing Then
                            Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_faltalocalidad"))
                            GoTo 0
                        Else
                            If Len(Trim(txt_calle.Text)) = 0 OrElse Len(Trim(txt_altura.Text)) = 0 Then
                                Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_camposincompletos"))
                                GoTo 0
                            Else
                                Dim be_presupuesto As New BE.BE_Presupuesto
                                Dim bll_presupuesto As New BLL.BLL_Presupuesto
                                Dim be_domicilio As New BE.BE_Domicilio
                                be_domicilio.partido = CType(Application("Partidos"), List(Of BE.BE_Partido)).Find(Function(x) x.partido = cbx_parti.SelectedItem.Text)
                                be_domicilio.localidad = be_domicilio.partido.localidades.Find(Function(x) x.localidad = cbx_localidad.SelectedItem.Text)
                                be_domicilio.calle = txt_calle.Text
                                If String.IsNullOrWhiteSpace(txt_altura.Text) Then
                                Else
                                    be_domicilio.altura = Trim(txt_altura.Text)
                                End If
                                be_domicilio.departamento = txt_depto.Text
                                If String.IsNullOrWhiteSpace(txt_piso.Text) Then
                                Else
                                    be_domicilio.piso = Trim(txt_piso.Text)
                                End If
                                be_domicilio.country = chk_country.Checked
                                If Not drp_dibujo.SelectedValue = "N/A" Then
                                    be_presupuesto.dibujotecnico = CType(Session("Lista_dibujos"), List(Of BE.BE_DibujoTecnico)).Find(Function(x) x.id = drp_dibujo.SelectedItem.Text)
                                Else
                                    be_presupuesto.dibujotecnico = Nothing
                                End If
                                be_presupuesto.Cliente_Persona = Session("Busqueda_Cliente")
                                be_presupuesto.Domicilio = be_domicilio
                                be_presupuesto.estado_presupuesto = "Pendiente de llenado por Parte del Responsable Técnico"
                                Select Case bll_presupuesto.alta(be_presupuesto)
                                    Case 5001
                                        be_bitacora.codigo_evento = 5001
                                        be_bitacora.usuario = Session("Usuario")
                                        bll_bitacora.alta(be_bitacora)
                                        Response.Redirect("web_error_inicio.aspx", False)
                                    Case 5002
                                        be_bitacora.codigo_evento = 5002
                                        be_bitacora.usuario = Session("Usuario")
                                        bll_bitacora.alta(be_bitacora)
                                        Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_altapresuOK") & " " & be_presupuesto.id)
                                        formato_inicial()
                                    Case 5003
                                        be_bitacora.codigo_evento = 5003
                                        be_bitacora.usuario = Session("Usuario")
                                        bll_bitacora.alta(be_bitacora)
                                        Response.Redirect("web_error_inicio.aspx", False)
                                End Select

                            End If
                        End If

                    End If
                End If
            ElseIf Session("Entero_Flag") = 2 Then
                If Len(Trim(txt_calle.Text)) = 0 OrElse Len(Trim(txt_altura.Text)) = 0 Then
                    Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_camposincompletos"))
                    GoTo 0
                Else
                    Dim be_presupuesto As BE.BE_Presupuesto
                    Dim bll_presupuesto As New BLL.BLL_Presupuesto
                    be_presupuesto = CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Find(Function(x) x.id = cmb_presupuesto.SelectedItem.Text)
                    be_presupuesto.Domicilio.partido = CType(Application("Partidos"), List(Of BE.BE_Partido)).Find(Function(x) x.partido = cbx_parti.SelectedItem.Text)
                    be_presupuesto.Domicilio.localidad = be_presupuesto.Domicilio.partido.localidades.Find(Function(x) x.localidad = cbx_localidad.SelectedItem.Text)
                    be_presupuesto.Domicilio.calle = txt_calle.Text
                    If String.IsNullOrWhiteSpace(txt_altura.Text) Then
                    Else
                        be_presupuesto.Domicilio.altura = Trim(txt_altura.Text)
                    End If
                    be_presupuesto.Domicilio.departamento = txt_depto.Text
                    If String.IsNullOrWhiteSpace(txt_piso.Text) Then
                    Else
                        be_presupuesto.Domicilio.piso = Trim(txt_piso.Text)
                    End If
                    be_presupuesto.Domicilio.country = CHK_Country.Checked
                    If Not drp_dibujo.SelectedValue = "N/A" Then
                        be_presupuesto.dibujotecnico = CType(Session("Lista_dibujos"), List(Of BE.BE_DibujoTecnico)).Find(Function(x) x.id = drp_dibujo.SelectedItem.Text)
                    Else
                        be_presupuesto.dibujotecnico = Nothing
                    End If
                    be_presupuesto.estado_presupuesto = "Pendiente de llenado por Parte del Responsable Técnico"
                    Select Case bll_presupuesto.modificar(be_presupuesto)
                        Case 5004
                            be_bitacora.codigo_evento = 5004
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            Response.Redirect("web_error_inicio.aspx", False)
                        Case 5005
                            be_bitacora.codigo_evento = 5005
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            Response.Write(DirectCast(Me.Master, General_Electrosystem).Traductora("msg_modificaok"))
                            formato_inicial()
                        Case 5006
                            be_bitacora.codigo_evento = 5006
                            be_bitacora.usuario = Session("Usuario")
                            bll_bitacora.alta(be_bitacora)
                            Response.Redirect("web_error_inicio.aspx", False)
                    End Select
                End If
            End If

0:
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try
    End Sub

    Private Sub cbx_parti_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_parti.SelectedIndexChanged
        Try
            cargar_localidad(CType(Application("Partidos"), List(Of BE.BE_Partido)).Find(Function(x) x.partido = cbx_parti.SelectedItem.Text))
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Protected Sub btn_cargar_presupuesto_Click(sender As Object, e As EventArgs) Handles btn_cargar_presupuesto.Click
        Try
            Dim lista_dibujos As List(Of BE.BE_DibujoTecnico)
            Dim bll_dibujos As New BLL.bll_dibujotecnico
            lista_dibujos = bll_dibujos.consultartodos()
            Session("Lista_Dibujos") = Nothing
            Session("Lista_Dibujos") = lista_dibujos
            drp_dibujo.Items.Clear()
            drp_dibujo.Items.Add("N/A")
            drp_dibujo.Enabled = True
            For Each item As BE.BE_DibujoTecnico In lista_dibujos
                drp_dibujo.Items.Add(item.id)
            Next
            drp_dibujo.Enabled = True
            Dim presupuesto As BE.BE_Presupuesto
            btn_buscar.Enabled = False
            presupuesto = CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Find(Function(x) x.id = cmb_presupuesto.SelectedItem.Text)
            txt_dnicuit.Text = presupuesto.Cliente_Persona.identificador
            txt_dnicuit.Enabled = False
            If Len(presupuesto.Cliente_Persona.identificador) = 11 Then
                txt_nombre_razonsocial.Text = CType(presupuesto.Cliente_Persona, BE.BE_Personajuridica).Razonsocial
            Else
                txt_nombre_razonsocial.Text = CType(presupuesto.Cliente_Persona, BE.BE_Personafisica).Nombre & " " & CType(presupuesto.Cliente_Persona, BE.BE_Personafisica).Apellido
            End If
            txt_nombre_razonsocial.Enabled = False
            txt_calle.Enabled = True
            txt_calle.Text = presupuesto.Domicilio.calle
            txt_altura.Enabled = True
            txt_altura.Text = presupuesto.Domicilio.altura
            txt_depto.Enabled = True
            If Not presupuesto.Domicilio.departamento Is Nothing Then
                txt_depto.Text = presupuesto.Domicilio.departamento
            Else
                txt_depto.Text = ""
            End If
            txt_depto.Text = presupuesto.Domicilio.departamento
            txt_piso.Enabled = True
            If Not presupuesto.Domicilio.piso Is Nothing Then
                txt_piso.Text = presupuesto.Domicilio.piso
            Else
                txt_piso.Text = ""
            End If
            For Each item As ListItem In cbx_parti.Items
                If item.Text = presupuesto.Domicilio.partido.partido Then
                    item.Selected = True
                    cargar_localidad(CType(Application("Partidos"), List(Of BE.BE_Partido)).Find(Function(x) x.partido = presupuesto.Domicilio.partido.partido))
                Else
                    item.Selected = False
                End If
            Next
            For Each item As ListItem In cbx_localidad.Items
                If item.Text = presupuesto.Domicilio.localidad.localidad Then
                    item.Selected = True
                Else
                    item.Selected = False
                End If
            Next
            CHK_Country.Enabled = True
            CHK_Country.Checked = presupuesto.Domicilio.country
            drp_dibujo.Enabled = True
            If Not presupuesto.dibujotecnico Is Nothing Then
                drp_dibujo.Items.Add(presupuesto.dibujotecnico.id)
                For Each item As ListItem In drp_dibujo.Items
                    If item.Text = "N/A" Then
                    ElseIf item.Text = presupuesto.dibujotecnico.id Then
                        item.Selected = True
                        CType(Session("Lista_dibujos"), List(Of BE.BE_DibujoTecnico)).Add(presupuesto.dibujotecnico)
                        Exit For
                    End If
                Next
            Else
                For Each item As ListItem In drp_dibujo.Items
                    If item.Text = "N/A" Then
                        item.Selected = True
                    Else
                        item.Selected = False
                    End If
                Next
                
            End If
            Session("Entero_Flag") = 2
            btn_guardarpresu.Enabled = True
            btn_nuevopresu.Enabled = False
            cmb_presupuesto.Enabled = False
            btn_cargar_presupuesto.Enabled = False
            cbx_parti.Enabled = True
            cbx_localidad.Enabled = True
            btn_verdibujo.Enabled = True

        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub

    Private Sub btn_cancelarpresu_Click(sender As Object, e As EventArgs) Handles btn_cancelarpresu.Click
        formato_inicial()
    End Sub

    Protected Sub btn_verdibujo_Click(sender As Object, e As EventArgs) Handles btn_verdibujo.Click
        DirectCast(Me.Master, General_Electrosystem).traducir_grilla(dtg_ambientes)
        dtg_ambientes.DataSource = Nothing
        dtg_ambientes.DataBind()
        If Not drp_dibujo.SelectedItem.Text = "N/A" Then
            Dim lista As New List(Of grilla_evaluarplano)
            Dim grilla As grilla_evaluarplano
            Dim be_dibujotecnico As BE.BE_DibujoTecnico
            be_dibujotecnico = CType(Session("Lista_Dibujos"), List(Of BE.BE_DibujoTecnico)).Find(Function(x) x.id = drp_dibujo.SelectedItem.Text)
            For Each ambiente As BE.Be_Ambiente In be_dibujotecnico.ambiente
                For Each circuito As BE.BE_Circuito In ambiente.circuitos
                    grilla = New grilla_evaluarplano
                    grilla.ambiente = ambiente.tipo
                    grilla.tipo = circuito.tipo
                    grilla.sigla = circuito.sigla
                    grilla.cantidad_bocas = circuito.cantidad_bocas
                    grilla.descripcion = circuito.descripcion
                    lista.Add(grilla)
                Next
            Next
            DirectCast(Me.Master, General_Electrosystem).traducir_grilla(dtg_ambientes)
            dtg_ambientes.DataSource = lista
            dtg_ambientes.DataBind()
        End If

    End Sub

    Private Class grilla_evaluarplano
        Private _ambiente As String
        Public Property ambiente() As String
            Get
                Return _ambiente
            End Get
            Set(ByVal value As String)
                _ambiente = value
            End Set
        End Property

        Private _sigla As String
        Public Property sigla() As String
            Get
                Return _sigla
            End Get
            Set(ByVal value As String)
                _sigla = value
            End Set
        End Property

        Private _tipo As String
        Public Property tipo() As String
            Get
                Return _tipo
            End Get
            Set(ByVal value As String)
                _tipo = value
            End Set
        End Property

        Private _cantidad_bocas As Integer
        Public Property cantidad_bocas() As Integer
            Get
                Return _cantidad_bocas
            End Get
            Set(ByVal value As Integer)
                _cantidad_bocas = value
            End Set
        End Property

        Private _descripcion As String
        Public Property descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal value As String)
                _descripcion = value
            End Set
        End Property
    End Class
End Class