Public Class web_evaluplano
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
                    tienepermiso = DirectCast(Me.Master, General_Electrosystem).Habilitar_Permiso_Formulario("menus_evaluacionplano")
                    If tienepermiso = True Then
                        usu = Session("Usuario")
                        DirectCast(Me.Master, General_Electrosystem).traductora_controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).Deshabilitar_Controles(Me.Controls)
                        DirectCast(Me.Master, General_Electrosystem).traducir_grilla(dtg_evaluarplano)
                        formato_inicial()
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

    Protected Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        Try
            btn_nuevo.Enabled = False
            btn_cancelar.Enabled = True
            btnambiente_agregar.Enabled = True
            btn_evaluarplano.Enabled = True
            txt_numeroambiente.Text = "0"
            drp_ambiente.Enabled = True
            txt_m2.Enabled = True
            Dim be_dibujotecnico As New BE.BE_DibujoTecnico
            be_dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
            Session("DibujoTecnico") = Nothing
            Session("DibujoTecnico") = be_dibujotecnico
            btn_guardardibujo.Enabled = True
            chk_circiluminacion.Enabled = True
            chk_circiluminaespecial.Enabled = True
            chk_circtomacorriente.Enabled = True
            chk_circtomacorrienteespecial.Enabled = True
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub

    Sub formato_inicial()
        Try
            txt_numeroambiente.Text = "0"
            Session("Nuevo") = True
            drp_ambiente.Items.Clear()
            drp_ambiente.Items.Add(DirectCast(Me.Master, General_Electrosystem).Traductora("Sala_De_estar_Comedor"))
            drp_ambiente.Items.Add(DirectCast(Me.Master, General_Electrosystem).Traductora("Dormitorio"))
            drp_ambiente.Items.Add(DirectCast(Me.Master, General_Electrosystem).Traductora("Cocina"))
            drp_ambiente.Items.Add(DirectCast(Me.Master, General_Electrosystem).Traductora("Bano"))
            drp_ambiente.Items.Add(DirectCast(Me.Master, General_Electrosystem).Traductora("Vestibulo_Garage_Hall"))
            txt_m2.Text = "0"
            Session("Evaluado") = False
            Session.Add("Grilla", New List(Of grilla))
            txt_m2.Enabled = False
            txt_cantcirciluminacion.Text = "0"
            txt_cantcirciluminacion.Enabled = False
            txt_cantcirciluminaespecial.Text = "0"
            txt_cantcirciluminaespecial.Enabled = False
            txt_cantcirctomacorriente.Text = "0"
            txt_cantcirctomacorriente.Enabled = False
            txt_cantcirctomacorrienteespecial.Text = "0"
            txt_cantcirctomacorrienteespecial.Enabled = False
            txt_circiluminacion.Text = "0"
            txt_circiluminacion.Enabled = False
            txt_circiluminaespecial.Text = "0"
            txt_circiluminaespecial.Enabled = False
            btn_guardardibujo.Enabled = False
            txt_circtomacorriente.Text = "0"
            txt_circtomacorriente.Enabled = False
            txt_circtomacorrienteespecial.Text = "0"
            txt_circtomacorrienteespecial.Enabled = False
            chk_circiluminacion.Checked = False
            chk_circiluminaespecial.Checked = False
            chk_circtomacorriente.Checked = False
            chk_circtomacorrienteespecial.Checked = False
            chk_circiluminacion.Enabled = False
            chk_circiluminaespecial.Enabled = False
            chk_circtomacorriente.Enabled = False
            chk_circtomacorrienteespecial.Enabled = False
            btn_nuevo.Enabled = True
            btnambiente_agregar.Enabled = False
            btn_cancelar.Enabled = False
            btn_evaluarplano.Enabled = False
            drp_ambiente.Enabled = False
            dtg_ambientes.DataSource = Nothing
            dtg_ambientes.DataBind()
            dtg_evaluarplano.DataSource = Nothing
            dtg_evaluarplano.DataBind()
            lbl_ambiente_anotacion.Text = ""
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub

    Private Sub chk_circiluminacion_CheckedChanged(sender As Object, e As EventArgs) Handles chk_circiluminacion.CheckedChanged
        If chk_circiluminacion.Checked = True Then
            txt_circiluminacion.Text = "0"
            txt_cantcirciluminacion.Text = "0"
            txt_circiluminacion.Enabled = True
            txt_cantcirciluminacion.Enabled = True
        Else
            txt_circiluminacion.Text = "0"
            txt_cantcirciluminacion.Text = "0"
            txt_circiluminacion.Enabled = False
            txt_cantcirciluminacion.Enabled = False
        End If
    End Sub

    Private Sub chk_circiluminaespecial_CheckedChanged(sender As Object, e As EventArgs) Handles chk_circiluminaespecial.CheckedChanged
        If chk_circiluminaespecial.Checked = True Then
            txt_circiluminaespecial.Text = "0"
            txt_cantcirciluminaespecial.Text = "0"
            txt_circiluminaespecial.Enabled = True
            txt_cantcirciluminaespecial.Enabled = True
        Else
            txt_circiluminaespecial.Text = "0"
            txt_cantcirciluminaespecial.Text = "0"
            txt_circiluminaespecial.Enabled = False
            txt_cantcirciluminaespecial.Enabled = False
        End If
    End Sub

    Private Sub chk_circtomacorriente_CheckedChanged(sender As Object, e As EventArgs) Handles chk_circtomacorriente.CheckedChanged
        If chk_circtomacorriente.Checked = True Then
            txt_circtomacorriente.Text = "0"
            txt_cantcirctomacorriente.Text = "0"
            txt_circtomacorriente.Enabled = True
            txt_cantcirctomacorriente.Enabled = True
        Else
            txt_circtomacorriente.Text = "0"
            txt_cantcirctomacorriente.Text = "0"
            txt_circtomacorriente.Enabled = False
            txt_cantcirctomacorriente.Enabled = False
        End If
    End Sub

    Private Sub chk_circtomacorrienteespecial_CheckedChanged(sender As Object, e As EventArgs) Handles chk_circtomacorrienteespecial.CheckedChanged
        If chk_circtomacorrienteespecial.Checked = True Then
            txt_circtomacorrienteespecial.Text = "0"
            txt_cantcirctomacorrienteespecial.Text = "0"
            txt_circtomacorrienteespecial.Enabled = True
            txt_cantcirctomacorrienteespecial.Enabled = True
        Else
            txt_circtomacorrienteespecial.Text = "0"
            txt_cantcirctomacorrienteespecial.Text = "0"
            txt_circtomacorrienteespecial.Enabled = False
            txt_cantcirctomacorrienteespecial.Enabled = False
        End If
    End Sub

    Protected Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Try
            Me.formato_inicial()
            Session("DibujoTecnico") = Nothing
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Protected Sub btnambiente_agregar_Click(sender As Object, e As EventArgs) Handles btnambiente_agregar.Click
        Try
            If validar_formatos() = True Then
                Session("Nuevo") = False
                Session("Evaluado") = False
                Dim be_dibujotecnico As BE.BE_DibujoTecnico
                be_dibujotecnico = Session("DibujoTecnico")
                Dim be_ambiente As New BE.Be_Ambiente
                Dim grilla As New grilla
                be_ambiente.m2 = txt_m2.Text
                grilla.metroscuadrados = txt_m2.Text
                be_ambiente.tipo = DirectCast(Me.Master, General_Electrosystem).buscar_en_espanol_ambiente(drp_ambiente.Text)
                grilla.tipo = be_ambiente.tipo
                be_ambiente.circuitos = New List(Of BE.BE_Circuito)
                For i As Integer = 1 To txt_circiluminacion.Text
                    Dim be_circuito As New BE.BE_Circuito
                    be_circuito.tipo = "Iluminación"
                    be_circuito.sigla = "IUG"
                    grilla.circuitodeiluminacion = txt_circiluminacion.Text
                    be_circuito.cantidad_bocas = txt_cantcirciluminacion.Text
                    grilla.cantidadcircuitosdeiluminacion = txt_cantcirciluminacion.Text
                    be_ambiente.circuitos.Add(be_circuito)
                Next
                For i As Integer = 1 To txt_circtomacorriente.Text
                    Dim be_circuito As New BE.BE_Circuito
                    be_circuito.tipo = "Toma Corriente"
                    be_circuito.sigla = "TUG"
                    grilla.circuitodetomacorriente = txt_circtomacorriente.Text
                    grilla.cantidadcircuitodetomacorriente = txt_cantcirctomacorriente.Text

                    be_circuito.cantidad_bocas = txt_cantcirctomacorriente.Text
                    be_ambiente.circuitos.Add(be_circuito)
                Next
                For i As Integer = 1 To txt_circiluminaespecial.Text
                    Dim be_circuito As New BE.BE_Circuito
                    be_circuito.tipo = "Iluminación Uso Especial"
                    be_circuito.sigla = "IUE"
                    grilla.circuitodeiluminacionespecial = txt_circiluminaespecial.Text
                    grilla.cantidadcircuitodeiluminacionespecial = txt_cantcirciluminaespecial.Text

                    be_circuito.cantidad_bocas = txt_cantcirciluminaespecial.Text
                    be_ambiente.circuitos.Add(be_circuito)
                Next
                For i As Integer = 1 To txt_circtomacorrienteespecial.Text
                    Dim be_circuito As New BE.BE_Circuito
                    be_circuito.tipo = "Toma Corriente Uso Especial"
                    be_circuito.sigla = "TUE"
                    grilla.circuitodetomacorrienteespecial = txt_circtomacorrienteespecial.Text
                    grilla.cantidadcircuitodetomacorrienteespecial = txt_cantcirctomacorrienteespecial.Text
                    be_circuito.cantidad_bocas = txt_cantcirctomacorrienteespecial.Text
                    be_ambiente.circuitos.Add(be_circuito)
                Next
                be_dibujotecnico.ambiente.Add(be_ambiente)
                txt_numeroambiente.Text = txt_numeroambiente.Text + 1
                'ver si me falta poner en sesion
                txt_cantcirciluminacion.Text = "0"
                txt_cantcirciluminacion.Enabled = False
                txt_cantcirciluminaespecial.Text = "0"
                txt_cantcirciluminaespecial.Enabled = False
                txt_cantcirctomacorriente.Text = "0"
                txt_cantcirctomacorriente.Enabled = False
                txt_cantcirctomacorrienteespecial.Text = "0"
                txt_cantcirctomacorrienteespecial.Enabled = False
                txt_circiluminacion.Text = "0"
                txt_circiluminacion.Enabled = False
                txt_circiluminaespecial.Text = "0"
                txt_circiluminaespecial.Enabled = False
                txt_circtomacorriente.Text = "0"
                txt_circtomacorriente.Enabled = False
                txt_circtomacorrienteespecial.Text = "0"
                txt_circtomacorrienteespecial.Enabled = False
                chk_circiluminacion.Checked = False
                chk_circiluminaespecial.Checked = False
                chk_circtomacorriente.Checked = False
                chk_circtomacorrienteespecial.Checked = False
                txt_m2.Text = "0"
                Dim lista_grilla As List(Of grilla)
                lista_grilla = Session("Grilla")
                lista_grilla.Add(grilla)
                Session("Grilla") = lista_grilla
                DirectCast(Me.Master, General_Electrosystem).traducir_grilla(dtg_ambientes)
                dtg_ambientes.DataSource = lista_grilla
                dtg_ambientes.DataBind()
            Else
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_camposincompletos")
            End If

        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)

        End Try

    End Sub

    Protected Sub btn_evaluarplano_Click(sender As Object, e As EventArgs) Handles btn_evaluarplano.Click
        Try
            If Session("Nuevo") = False Then
                Dim resultado As Boolean = True
                Dim lista_circuitos As New List(Of BE.BE_Circuito)
                Dim be_dibujotecnico As BE.BE_DibujoTecnico
                Dim lista_grillaevaluar As New List(Of grilla_evaluarplano)
                Dim grillaevaluar As New grilla_evaluarplano
                be_dibujotecnico = Session("DibujoTecnico")
                Dim bll_dibujotecnico As New BLL.bll_dibujotecnico
                bll_dibujotecnico.evaluar_plano(be_dibujotecnico)
                If be_dibujotecnico.cumple_ambientes = True Then
                    DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_planook")
                Else
                    For Each ambiente As BE.Be_Ambiente In be_dibujotecnico.ambiente
                        For Each circuito As BE.BE_Circuito In ambiente.circuitos
                            If circuito.cumple_cantidad_bocas_circuito = False OrElse circuito.circuito_correcto_segun_ambiente = False Then
                                resultado = False
                                grillaevaluar.ambiente = ambiente.tipo
                                grillaevaluar.tipo = circuito.tipo
                                grillaevaluar.sigla = circuito.sigla
                                grillaevaluar.cantidad_bocas = circuito.cantidad_bocas
                                grillaevaluar.descripcion = circuito.descripcion
                                lista_circuitos.Add(circuito)
                                lista_grillaevaluar.Add(grillaevaluar)
                            End If
                        Next
                    Next
                    If be_dibujotecnico.cumple_cantidadcircuito = False Then
                        resultado = False
                        lbl_ambiente_anotacion.Text = DirectCast(Me.Master, General_Electrosystem).Traductora("msg_dibujoincorrecto") & " " & be_dibujotecnico.descripcion
                    End If
                    DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_planofail")
                    dtg_evaluarplano.DataSource = lista_grillaevaluar
                    dtg_evaluarplano.DataBind()
                End If
                Session("Evaluado") = True
            Else
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_faltaagregarambiente")
            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Protected Sub btn_guardardibujo_Click(sender As Object, e As EventArgs) Handles btn_guardardibujo.Click
        Try
            If Session("Evaluado") = True Then
                Dim be_bitacora As New BE.BE_Bitacora
                Dim bll_bitacora As New BLL.BLL_Bitacora
                Dim be_dibujotecnico As BE.BE_DibujoTecnico
                be_dibujotecnico = Session("DibujoTecnico")
                Dim bll_dibujotecnico As New BLL.bll_dibujotecnico
                Dim entero As Integer = 0
                entero = bll_dibujotecnico.alta(be_dibujotecnico)
                be_bitacora.usuario = Session("Usuario")
                If entero = 0 Then
                    be_bitacora.codigo_evento = 10166
                    bll_bitacora.alta(be_bitacora)
                    Response.Redirect("web_error_inicio.aspx", False)
                Else
                    be_bitacora.codigo_evento = 10165
                    bll_bitacora.alta(be_bitacora)
                    DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_planoguardadook", entero)
                    formato_inicial()
                End If
            Else
                DirectCast(Me.Master, General_Electrosystem).mostrarmodal("msg_faltaevaluar")

            End If
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Private Function validar_formatos() As Boolean
        If chk_circiluminacion.Checked = False AndAlso chk_circiluminaespecial.Checked = False AndAlso chk_circtomacorriente.Checked = False AndAlso chk_circtomacorriente.Checked = False Then
            Return False
        Else
            If txt_m2.Text = "0" OrElse String.IsNullOrWhiteSpace(txt_m2.Text) OrElse txt_m2.Text <= 0 Then
                Return False
            ElseIf chk_circiluminacion.Checked = True And (txt_circiluminacion.Text = "0" OrElse String.IsNullOrWhiteSpace(txt_circiluminacion.Text) OrElse txt_circiluminacion.Text <= 0 OrElse txt_cantcirciluminacion.Text = "0" OrElse String.IsNullOrWhiteSpace(txt_cantcirciluminacion.Text) OrElse txt_cantcirciluminacion.Text <= 0) Then
                Return False
            ElseIf chk_circiluminaespecial.Checked = True And (txt_circiluminaespecial.Text = "0" OrElse String.IsNullOrWhiteSpace(txt_circiluminaespecial.Text) OrElse txt_circiluminaespecial.Text <= 0 OrElse txt_cantcirciluminaespecial.Text = "0" OrElse String.IsNullOrWhiteSpace(txt_cantcirciluminaespecial.Text) OrElse txt_cantcirciluminaespecial.Text <= 0) Then
                Return False
            ElseIf chk_circtomacorriente.Checked = True And (txt_circtomacorriente.Text = "0" OrElse String.IsNullOrWhiteSpace(txt_circtomacorriente.Text) OrElse txt_circtomacorriente.Text <= 0 OrElse txt_cantcirctomacorriente.Text = "0" OrElse String.IsNullOrWhiteSpace(txt_cantcirctomacorriente.Text) OrElse txt_cantcirctomacorriente.Text <= 0) Then
                Return False
            ElseIf chk_circtomacorrienteespecial.Checked = True And (txt_circtomacorrienteespecial.Text = "0" OrElse String.IsNullOrWhiteSpace(txt_circtomacorrienteespecial.Text) OrElse txt_circtomacorrienteespecial.Text <= 0 OrElse txt_cantcirctomacorrienteespecial.Text = "0" OrElse String.IsNullOrWhiteSpace(txt_cantcirctomacorrienteespecial.Text) OrElse txt_cantcirctomacorrienteespecial.Text <= 0) Then
                Return False
            Else
                Return True
            End If
        End If
    End Function


    Private Class grilla
        Private _tipo As String
        Public Property tipo() As String
            Get
                Return _tipo
            End Get
            Set(ByVal value As String)
                _tipo = value
            End Set
        End Property

        Private _metroscuadrados As Decimal
        Public Property metroscuadrados() As Decimal
            Get
                Return _metroscuadrados
            End Get
            Set(ByVal value As Decimal)
                _metroscuadrados = value
            End Set
        End Property

        Private _circuitodeiluminacion As Integer
        Public Property circuitodeiluminacion() As Integer
            Get
                Return _circuitodeiluminacion
            End Get
            Set(ByVal value As Integer)
                _circuitodeiluminacion = value
            End Set
        End Property

        Private _cantidadcircuitosdeiluminacion As Integer
        Public Property cantidadcircuitosdeiluminacion() As Integer
            Get
                Return _cantidadcircuitosdeiluminacion
            End Get
            Set(ByVal value As Integer)
                _cantidadcircuitosdeiluminacion = value
            End Set
        End Property

        Private _circuitodeiluminacionespecial As Integer
        Public Property circuitodeiluminacionespecial() As Integer
            Get
                Return _circuitodeiluminacionespecial
            End Get
            Set(ByVal value As Integer)
                _circuitodeiluminacionespecial = value
            End Set
        End Property

        Private _cantidadcircuitodeiluminacionespecial As Integer
        Public Property cantidadcircuitodeiluminacionespecial() As Integer
            Get
                Return _cantidadcircuitodeiluminacionespecial
            End Get
            Set(ByVal value As Integer)
                _cantidadcircuitodeiluminacionespecial = value
            End Set
        End Property

        Private _circuitodetomacorriente As Integer
        Public Property circuitodetomacorriente() As Integer
            Get
                Return _circuitodetomacorriente
            End Get
            Set(ByVal value As Integer)
                _circuitodetomacorriente = value
            End Set
        End Property

        Private _cantidadcircuitodetomacorriente As Integer
        Public Property cantidadcircuitodetomacorriente() As Integer
            Get
                Return _cantidadcircuitodetomacorriente
            End Get
            Set(ByVal value As Integer)
                _cantidadcircuitodetomacorriente = value
            End Set
        End Property

        Private _circuitodetomacorrienteespecial As Integer
        Public Property circuitodetomacorrienteespecial() As Integer
            Get
                Return _circuitodetomacorrienteespecial
            End Get
            Set(ByVal value As Integer)
                _circuitodetomacorrienteespecial = value
            End Set
        End Property

        Private _cantidadcircuitodetomacorrienteespecial As Integer
        Public Property cantidadcircuitodetomacorrienteespecial() As Integer
            Get
                Return _cantidadcircuitodetomacorrienteespecial
            End Get
            Set(ByVal value As Integer)
                _cantidadcircuitodetomacorrienteespecial = value
            End Set
        End Property
    End Class

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