
	Public Class BLL_Presupuesto


    Public m_BE_Bitacora As BE.BE_Bitacora
		Public m_BLL_Bitacora As BLL.BLL_Bitacora
		Public m_Criptografia As Seguridad.Criptografia
		Public m_DAL_Presupuesto As DAL.DAL_Presupuesto
    Public m_BE_Presupuesto As BE.BE_Presupuesto

		''' 
		''' <param name="unbe"></param>
		Public Function actualizacion_responsabletecnico(ByVal unbe As BE.BE_Presupuesto) As Integer
        Dim contador_bocas As Integer = 0
        Dim cantidad_artefactos As Integer = 0

        For Each ambiente As BE.Be_Ambiente In unbe.dibujotecnico.ambiente
            For Each circui As BE.BE_Circuito In ambiente.circuitos
                contador_bocas = circui.cantidad_bocas + contador_bocas
            Next
        Next
        For Each artefacto As BE.BE_ArtefactoElectrico In unbe.Artefacto_electrico
            cantidad_artefactos = cantidad_artefactos + artefacto.cantidad
        Next
        If contador_bocas < cantidad_artefactos Then
            Return contador_bocas * -1
        Else
            Me.administrar_estado(unbe)
            Dim dal_presupuesto As New DAL.DAL_Presupuesto
            Return dal_presupuesto.actualizacion_responsabletecnico(unbe)

        End If
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function administrar_estado(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        If unbe.id = 0 Then
            unbe.estado_presupuesto = "Pendiente de llenado por Parte del Responsable Técnico"
            'aca se va a cifrar despues esto
        Else
            If unbe.estado_presupuesto = "Pendiente de llenado por Parte del Responsable Técnico" Then
                unbe.estado_presupuesto = "Pendiente de llenado por parte del Responsable Comercial"
            ElseIf unbe.estado_presupuesto = "Comenzado" Then
                unbe.estado_presupuesto = "Finalizado"
            End If

        End If
        Return unbe
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Presupuesto) As Integer
        Dim dal_presupuesto As New DAL.DAL_Presupuesto
        Dim cifrado As New SEGURIDAD.Criptografia
        Try
            'administrar_estado(unbe)
            unbe.estado_presupuesto = cifrado.cifrar(unbe.estado_presupuesto)
            unbe.fecha_alta = Now
            Select Case dal_presupuesto.alta(unbe)
                Case 5001
                    Return 5001
                Case 5002
                    Return 5002
                Case 5003
                    Return 5003
            End Select
        Catch ex As Exception
            Return 5001
        End Try
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Presupuesto) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function calcular_precio_trabmat(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
    End Function

    ''' 
    ''' <param name="artefactos"></param>
    ''' <param name="boca"></param>
    Private Function calcular_precios_artefactos(ByVal artefactos As List(Of BE.BE_ArtefactoElectrico), ByVal boca As BE.BE_BocaMercado) As Decimal
        Dim valor As Decimal = 0
        For Each arte As BE.BE_ArtefactoElectrico In artefactos
            arte.precio = (arte.relacion_bocamercado * boca.precio_bocamercado) * arte.cantidad
            valor = valor + arte.precio
        Next
        Return valor
    End Function


    ''' 
    ''' <param name="unbe"></param>
    Public Sub calcularvalores(ByVal unbe As BE.BE_Presupuesto)
        Dim bll_bocamercado As New BLL_BocaMercado
        Dim be_bocamercado As BE.BE_BocaMercado
        Dim bocas As List(Of BE.BE_BocaMercado)
        Dim cantidad_bocas As Decimal = 0
        bocas = bll_bocamercado.consultartodos()
        If Not unbe.Materiales_trabajo Is Nothing Then
            For Each trabajo As BE.BE_Material_TrabajoconPrec In unbe.Materiales_trabajo
                trabajo.precio_cantidad = trabajo.cantidad * trabajo.Precio
                If trabajo.Material = True Then
                    unbe.valor_material = unbe.valor_material + trabajo.precio_cantidad
                Else
                    If trabajo.Trabajoconprecio = True Then
                        unbe.valor_trabajoconprecio = unbe.valor_trabajoconprecio + trabajo.precio_cantidad
                    End If
                End If
            Next
        End If
        If Not unbe.Artefacto_electrico Is Nothing Then
            cantidad_bocas = Me.cantidad_bocas(unbe.Artefacto_electrico)
        End If
        Select Case cantidad_bocas
            Case Is > 400
                ' be_bocamercado = bocas.FindLast(Function(x) x.tipo = "Boca Mercado")
                unbe.valor_manodeobra = Me.calcular_precios_artefactos(unbe.Artefacto_electrico, be_bocamercado)
            Case Is < 400
                If unbe.departamento_granescala = True Then
                    '     be_bocamercado = bocas.FindLast(Function(x) x.tipo = "Boca Mercado")
                    If Not unbe.Artefacto_electrico Is Nothing Then
                        unbe.valor_manodeobra = Me.calcular_precios_artefactos(unbe.Artefacto_electrico, be_bocamercado)
                    End If
                Else
                    If unbe.Instalacion_compleja = True Then
                        If Not unbe.Cliente_Persona Is Nothing Then
                            If unbe.Cliente_Persona.TratamientoEspecial = True Or unbe.Domicilio.country = True Or unbe.masde20km = True Then
                                '            be_bocamercado = bocas.FindLast(Function(x) x.tipo = "Boca Extraordinaria")
                                If Not unbe.Artefacto_electrico Is Nothing Then
                                    unbe.valor_manodeobra = Me.calcular_precios_artefactos(unbe.Artefacto_electrico, be_bocamercado)
                                End If
                            End If
                        End If
                    Else
                        '  be_bocamercado = bocas.FindLast(Function(x) x.tipo = "Boca Empresa")
                        If Not unbe.Artefacto_electrico Is Nothing Then
                            unbe.valor_manodeobra = Me.calcular_precios_artefactos(unbe.Artefacto_electrico, be_bocamercado)
                        End If
                    End If
                End If
            Case Else
                unbe.valor_manodeobra = 0
        End Select
        Me.calculo_valordinamico(unbe)
        Me.guardar_estado_cliente(unbe)
    End Sub

		''' 
		''' <param name="unbe"></param>
		Public Function calculo_trabajo_tareas(ByVal unbe As BE.BE_Presupuesto) As Integer

    End Function

		''' 
		''' <param name="unbe"></param>
		Public Sub calculo_valordinamico(ByVal unbe As BE.BE_Presupuesto)
        unbe.valor_total = unbe.valor_manodeobra + unbe.valor_material + unbe.valor_otros + unbe.valor_seguro_vida + unbe.valor_trabajoconprecio

    End Sub

		''' 
		''' <param name="artefactos"></param>
    Private Function cantidad_bocas(ByVal artefactos As List(Of BE.BE_ArtefactoElectrico)) As Integer
        Dim cantidad As Decimal = 0
        For Each artefacto As BE.BE_ArtefactoElectrico In artefactos
            cantidad = cantidad + (artefacto.relacion_bocamercado * artefacto.cantidad)
        Next
        If cantidad > 0 Then
            Return cantidad
        Else
            Return Nothing
        End If
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consulta_dom_plano(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        Try
            Dim dal_consultar As New DAL.DAL_Presupuesto
            Dim dal_consultar_ambientes As New DAL.DAL_Dibujotecnico
            dal_consultar.consulta_dom_plano(unbe)
            If Not unbe.dibujotecnico Is Nothing Then
                dal_consultar_ambientes.Consulta_ambientes_circuitos(unbe.dibujotecnico)

            End If
            Return unbe
        Catch ex As Exception

        End Try
       
		End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        Dim dal_consultar As New DAL.DAL_Presupuesto
        Return dal_consultar.consultar(unbe)
    End Function
    'esta función no va a estar!! ya que se va a consultar en base la selección del usuario.
    Function consultar_ultimo_comercial(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        Dim dal_consultar As New DAL.DAL_Presupuesto
        Return dal_consultar.consultar_ultimo_comercial(unbe)
    End Function
    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar_trabajo(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
			consultar_trabajo = Nothing
		End Function

		''' 
		''' <param name="unbe"></param>
		Public Function consultar_valortotal(ByVal unbe As BE.BE_Presupuesto) As Integer
			consultar_valortotal = 0
		End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar_varios(ByVal unbe As BE.BE_Presupuesto) As List(Of BE.BE_Presupuesto)
        Dim dal_presupuesto As New DAL.DAL_Presupuesto
        Dim seguridad As New SEGURIDAD.Criptografia
        Dim be_Bitacora As New BE.BE_Bitacora
        Dim bll_Bitacora As New BLL.BLL_Bitacora
        unbe.estado_presupuesto = seguridad.cifrar(unbe.estado_presupuesto)
        Dim listadepresupuesto As List(Of BE.BE_Presupuesto) = Nothing
        listadepresupuesto = dal_presupuesto.consultar_varios(unbe)
        If Not listadepresupuesto Is Nothing Then
            For Each presu As BE.BE_Presupuesto In listadepresupuesto
                presu.estado_presupuesto = seguridad.descifrar(presu.estado_presupuesto)
                consulta_dom_plano(presu)
            Next
        End If
        Return listadepresupuesto

    End Function

    Public Function consultartodos() As List(Of BE.BE_Presupuesto)
        consultartodos = Nothing
    End Function



    ''' 
    ''' <param name="unbe"></param>
    Public Function envio_presupuesto_mail(ByVal unbe As BE.BE_Presupuesto) As Boolean
        envio_presupuesto_mail = False
    End Function

    ''' <param name="unbe"></param>
    Public Function generar_solicitudpresupuesto(ByVal unbe As BE.BE_Presupuesto) As Integer
        administrar_estado(unbe)
        Dim dal_presupuesto As New DAL.DAL_Presupuesto
        Return dal_presupuesto.generar_solicitudpresupuesto(unbe)
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function guardar_estado_cliente(ByVal unbe As BE.BE_Presupuesto) As Integer
        unbe.estado_presupuesto = "Enviado a Cliente"
        unbe.fecha_modificacion = Now
        Dim dal_presupuesto As New DAL.DAL_Presupuesto
        dal_presupuesto.guardar_estado_cliente(unbe)

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Presupuesto) As Integer
        Dim dal_presupuesto As New DAL.DAL_Presupuesto
        Dim Bitacora As New BE.BE_Bitacora
        Dim bll_Bitacora As New BLL.BLL_Bitacora
        Dim cifrado As New SEGURIDAD.Criptografia
        Try
            unbe.estado_presupuesto = cifrado.cifrar(unbe.estado_presupuesto)
            unbe.fecha_modificacion = Now
            Select Case dal_presupuesto.modificar(unbe)
                Case 5004
                    Return 5004
                Case 5005
                    Return 5005
                Case 5006
                    Return 5006
            End Select
        Catch ex As Exception
            Return 5006
        End Try
    End Function


End Class ' BLL_Presupuesto


