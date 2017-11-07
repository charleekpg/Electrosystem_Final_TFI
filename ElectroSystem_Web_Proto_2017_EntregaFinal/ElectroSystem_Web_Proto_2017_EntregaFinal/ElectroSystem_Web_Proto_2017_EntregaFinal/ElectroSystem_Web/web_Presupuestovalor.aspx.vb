Public Class web_Presupuestovalor
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
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_presucomercial")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        Session.Add("Entero_Flag", entero_flag)
                        DirectCast(Me.Master, General_Electrosystem).traducir_grilla(grd_presupuesto_final)
                        cargar_partidos()
                        btn_cancelarpres_Click(Nothing, Nothing)
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

    Class grilla
        Private _cod_presupuesto As Integer
        Public Property cod_presupuesto() As Integer
            Get
                Return _cod_presupuesto
            End Get
            Set(ByVal value As Integer)
                _cod_presupuesto = value
            End Set
        End Property

        Private _valor_segurovida As Decimal
        Public Property valor_segurovida() As Decimal
            Get
                Return _valor_segurovida
            End Get
            Set(ByVal value As Decimal)
                _valor_segurovida = value
            End Set
        End Property

        Private _valor_total As Decimal
        Public Property valor_total() As Decimal
            Get
                Return _valor_total
            End Get
            Set(ByVal value As Decimal)
                _valor_total = value
            End Set
        End Property

        Private _nomb_ape_rs As String
        Public Property nomb_ape_rs() As String
            Get
                Return _nomb_ape_rs
            End Get
            Set(ByVal value As String)
                _nomb_ape_rs = value
            End Set
        End Property

        Private _valor_manoobra As Decimal
        Public Property valor_manoobra() As Decimal
            Get
                Return _valor_manoobra
            End Get
            Set(ByVal value As Decimal)
                _valor_manoobra = value
            End Set
        End Property

        Private _valor_material As Decimal
        Public Property valor_material() As Decimal
            Get
                Return _valor_material
            End Get
            Set(ByVal value As Decimal)
                _valor_material = value
            End Set
        End Property

        Private _valor_trabajoconprecio As Decimal
        Public Property valor_trabajoconprecio() As Decimal
            Get
                Return _valor_trabajoconprecio
            End Get
            Set(ByVal value As Decimal)
                _valor_trabajoconprecio = value
            End Set
        End Property

        Private _valor_otros As Decimal
        Public Property valor_otros() As Decimal
            Get
                Return _valor_otros
            End Get
            Set(ByVal value As Decimal)
                _valor_otros = value
            End Set
        End Property
    End Class

    Protected Sub btn_cancelarpres_Click(sender As Object, e As EventArgs) Handles btn_cancelarprtec.Click
        Session("Grilla") = Nothing
        Session("Grilla") = New List(Of grilla)
        cargar_presupuestos_estado()
        chk_actuaindice.Enabled = False
        chk_cobroadel.Enabled = False
        chk_preciosegvida.Enabled = False
        chk_viatico.Enabled = False
        chk_actuaindice.Checked = False
        chk_cobroadel.Checked = False
        chk_preciosegvida.Checked = False
        chk_viatico.Checked = False
        txt_poradelanto.Enabled = False
        txt_poradelanto.Text = 0
        txt_valorseg.Enabled = False
        txt_valorseg.Text = 0
        txt_valorvia.Enabled = False
        txt_valorvia.Text = 0
        grd_presupuesto_final.DataSource = Nothing
        grd_presupuesto_final.DataBind()
        btn_calcvaltot.Enabled = False
        btn_cancelarprtec.Enabled = True
        btn_cargar_presupuesto.Enabled = True
        cmb_presupuesto.Enabled = True
        btn_guardarpresucom.Enabled = False
        cbx_localidad.Enabled = False
        cbx_parti.Enabled = False
        Session("Calculado") = 0
    End Sub

    Sub cargar_presupuestos_estado()
        Try
            Dim bll_presupuesto As New BLL.BLL_Presupuesto
            Dim presupuesto As New BE.BE_Presupuesto
            Dim LISTA_PRESUPUESTO As List(Of BE.BE_Presupuesto)
            Dim lista_presupuestos_final As List(Of BE.BE_Presupuesto)
            Session("Lista_Presupuestos_1") = Nothing
            presupuesto.estado_presupuesto = "Pendiente de llenado por parte del Responsable Comercial"
            Session("Lista_Presupuestos_1") = bll_presupuesto.consultar_varios(presupuesto)
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

    Protected Sub btn_cargar_presupuesto_Click(sender As Object, e As EventArgs) Handles btn_cargar_presupuesto.Click
        Try
            btn_cargar_presupuesto.Enabled = False
            cmb_presupuesto.Enabled = False
            Dim presupuesto As BE.BE_Presupuesto
            btn_cargar_presupuesto.Enabled = False
            presupuesto = CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Find(Function(x) x.id = cmb_presupuesto.SelectedItem.Text)
            chk_actuaindice.Enabled = True
            chk_cobroadel.Enabled = True
            chk_preciosegvida.Enabled = True
            chk_viatico.Enabled = True
            cmb_presupuesto.Enabled = False
            btn_cargar_presupuesto.Enabled = False
            btn_cancelarprtec.Enabled = True
            btn_calcvaltot.Enabled = True
            btn_guardarpresucom.Enabled = False
            cbx_parti.Enabled = True
            cbx_localidad.Enabled = True
            If presupuesto.estado_presupuesto = "Pendiente de llenado por Parte del Responsable Comercial" Then
                Session("Entero_Flag") = 1
            Else
                Session("Entero_Flag") = 2
                chk_actuaindice.Checked = presupuesto.actualizaicac
                If presupuesto.porcentaje_aldarluz > 0 Then
                    chk_cobroadel.Checked = True
                    txt_poradelanto.Text = presupuesto.porcentaje_aldarluz
                End If
                chk_actuaindice.Checked = presupuesto.actualizaicac
                If presupuesto.valor_seguro_vida > 0 Then
                    chk_preciosegvida.Checked = True
                    txt_valorseg.Text = presupuesto.valor_seguro_vida
                End If
                If presupuesto.valor_otros > 0 Then
                    chk_viatico.Checked = True
                    txt_valorvia.Text = presupuesto.valor_otros
                End If

                Dim grilla As New grilla
                Dim lista_grilla As List(Of grilla) = Session("Grilla")
                grilla.cod_presupuesto = presupuesto.id
                If presupuesto.Cliente_Persona.identificador.Length = 11 Then
                    grilla.nomb_ape_rs = CType(presupuesto.Cliente_Persona, BE.BE_Personajuridica).Razonsocial
                Else
                    grilla.nomb_ape_rs = CType(presupuesto.Cliente_Persona, BE.BE_Personafisica).Nombre & " " & CType(presupuesto.Cliente_Persona, BE.BE_Personafisica).Apellido
                End If
                grilla.valor_segurovida = presupuesto.valor_seguro_vida
                grilla.valor_manoobra = presupuesto.valor_manodeobra
                grilla.valor_material = presupuesto.valor_material
                grilla.valor_otros = presupuesto.valor_otros
                grilla.valor_trabajoconprecio = presupuesto.valor_trabajoconprecio
                lista_grilla.Add(grilla)
                grd_presupuesto_final.DataSource = lista_grilla
                grd_presupuesto_final.DataBind()
            End If
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

    Private Sub chk_cobroadel_CheckedChanged(sender As Object, e As EventArgs) Handles chk_cobroadel.CheckedChanged
        If chk_cobroadel.Checked = True Then
            txt_poradelanto.Enabled = True
            txt_poradelanto.Text = 1
        Else
            txt_poradelanto.Enabled = False
            txt_poradelanto.Text = 0
        End If
    End Sub

    Private Sub chk_preciosegvida_CheckedChanged(sender As Object, e As EventArgs) Handles chk_preciosegvida.CheckedChanged
        If chk_preciosegvida.Checked = True Then
            txt_valorseg.Enabled = True
            txt_valorseg.Text = 1
        Else
            txt_valorseg.Enabled = False
            txt_valorseg.Text = 0
        End If
    End Sub

    Private Sub chk_viatico_CheckedChanged(sender As Object, e As EventArgs) Handles chk_viatico.CheckedChanged
        If chk_viatico.Checked = True Then
            txt_valorvia.Enabled = True
            txt_valorvia.Text = 1
        Else
            txt_valorvia.Enabled = False
            txt_valorvia.Text = 0
        End If
    End Sub

    Protected Sub btn_calcvaltot_Click(sender As Object, e As EventArgs) Handles btn_calcvaltot.Click
        Try
            Session("Grilla") = New List(Of grilla)
            Dim bll_presupuesto As New BLL.BLL_Presupuesto
            Dim presupuesto As BE.BE_Presupuesto = CType(Session("Lista_Presupuestos_1"), List(Of BE.BE_Presupuesto)).Find(Function(x) x.id = cmb_presupuesto.SelectedItem.Text)
            Dim bll_calculardistancia As New BLL.BLL_Domicilio
            Dim be_domicilio As New BE.BE_Domicilio
            be_domicilio.localidad = CType(Application("Partidos"), List(Of BE.BE_Partido)).Find(Function(x) x.partido = cbx_parti.SelectedItem.Text).localidades.Find(Function(y) y.localidad = cbx_localidad.SelectedItem.Text)
            If bll_calculardistancia.calcular_distancia(presupuesto.Domicilio, be_domicilio) > 20 Then
                presupuesto.masde20km = True
            Else
                presupuesto.masde20km = False
            End If
            bll_presupuesto.calcularvalores(presupuesto)
            Dim grilla As New grilla
            Dim lista_grilla As List(Of grilla) = Session("Grilla")
            grilla.cod_presupuesto = presupuesto.id
            If presupuesto.Cliente_Persona.identificador.Length = 11 Then
                grilla.nomb_ape_rs = CType(presupuesto.Cliente_Persona, BE.BE_Personajuridica).Razonsocial
            Else
                grilla.nomb_ape_rs = CType(presupuesto.Cliente_Persona, BE.BE_Personafisica).Nombre & " " & CType(presupuesto.Cliente_Persona, BE.BE_Personafisica).Apellido
            End If
            grilla.valor_segurovida = presupuesto.valor_seguro_vida
            grilla.valor_manoobra = presupuesto.valor_manodeobra
            grilla.valor_material = presupuesto.valor_material
            grilla.valor_otros = presupuesto.valor_otros
            grilla.valor_trabajoconprecio = presupuesto.valor_trabajoconprecio
            lista_grilla.Add(grilla)
            grd_presupuesto_final.DataSource = lista_grilla
            grd_presupuesto_final.DataBind()
            Session("Calculado") = 1
            btn_guardarpresucom.Enabled = True
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub
End Class