
	Public Class BLL_Presupuesto

    Public Function evaluar_presupuestovsdibujo(unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        Dim cantidad_dispositivos_presupuesto As Integer = 0
        cantidad_dispositivos_presupuesto = Me.contar_cantidaddispositivos(unbe)
        If Not unbe.dibujotecnico Is Nothing Then
            Dim bll_dibujo_tecnico As New BLL.bll_dibujotecnico
            Dim cantidad_bocas_dibujo As Integer = 0
            cantidad_bocas_dibujo = bll_dibujo_tecnico.contar_bocas_dibujo(unbe.dibujotecnico)
            If cantidad_bocas_dibujo > cantidad_dispositivos_presupuesto Then
                unbe.observacion = "-" & (cantidad_bocas_dibujo - cantidad_dispositivos_presupuesto).ToString
            ElseIf cantidad_dispositivos_presupuesto > cantidad_bocas_dibujo Then
                unbe.observacion = cantidad_dispositivos_presupuesto - cantidad_bocas_dibujo
            Else
                unbe.observacion = "Cantidad_Artefactos_OK"
            End If
        Else
            unbe.observacion = "Cantidad_Artefactos_OK"
        End If
        Return unbe
    End Function

    Private Function contar_cantidaddispositivos(unbe As BE.BE_Presupuesto) As Integer
        Dim contador As Integer = 0
        If Not unbe.Artefacto_electrico Is Nothing Then
            For Each artefacto As BE.BE_ArtefactoElectrico In unbe.Artefacto_electrico
                contador = artefacto.cantidad + contador
            Next
            Return contador
        End If
    End Function


    Public Function actualizacion_responsabletecnico(ByVal unbe As BE.BE_Presupuesto) As Integer
        Me.administrar_estado(unbe)
        Dim cifrado As New SEGURIDAD.Criptografia
        Dim dal_presupuesto As New DAL.DAL_Presupuesto
        Try
            Select Case Me.calculo_trabajo_tareas(unbe)
                Case 10147
                    Return 10147
                Case 10146
                    Return 10146
                Case Else
                    unbe.estado_presupuesto = cifrado.cifrar(unbe.estado_presupuesto)
                    unbe.fecha_modificacion = Now
                    Select Case dal_presupuesto.actualizacion_responsabletecnico(unbe)
                        Case 10150
                            Return 10150
                        Case 10149
                            Return 10149
                    End Select
            End Select
        Catch ex As Exception
            Return 10149
        End Try
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function administrar_estado(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        If unbe.id = 0 Then
            unbe.estado_presupuesto = "Pendiente de llenado por Parte del Responsable T�cnico"
            'aca se va a cifrar despues esto
        Else
            If unbe.estado_presupuesto = "Pendiente de llenado por Parte del Responsable T�cnico" Then
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

    Public Sub calcularvalores(ByVal unbe As BE.BE_Presupuesto)
        Dim bll_bocamercado As New BLL_BocaMercado
        Dim bocas As List(Of BE.BE_BocaMercado)
        Dim cantidad_bocas As Decimal = 0
        bocas = bll_bocamercado.consultartodos()
        unbe.valor_trabajoconprecio = 0
        unbe.valor_material = 0
        unbe.valor_total = 0
        unbe.valor_manodeobra = 0
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
                unbe.valor_manodeobra = Me.calcular_precios_artefactos(unbe.Artefacto_electrico, (bocas.Item(0)))
            Case Is < 400
                If unbe.departamento_granescala = True Then
                    If Not unbe.Artefacto_electrico Is Nothing Then
                        unbe.valor_manodeobra = Me.calcular_precios_artefactos(unbe.Artefacto_electrico, (bocas.Item(0)))
                    End If
                Else
                    If unbe.Instalacion_compleja = True Then
                        If Not unbe.Cliente_Persona Is Nothing Then
                            If unbe.Cliente_Persona.TratamientoEspecial = True Or unbe.Domicilio.country = True Or unbe.masde20km = True Then
                                If Not unbe.Artefacto_electrico Is Nothing Then
                                    unbe.valor_manodeobra = Me.calcular_precios_artefactos(unbe.Artefacto_electrico, bll_bocamercado.calcularbocaextraordinaria((bocas.Item(0))))
                                End If
                            End If
                        End If
                    Else
                        If Not unbe.Artefacto_electrico Is Nothing Then
                            unbe.valor_manodeobra = Me.calcular_precios_artefactos(unbe.Artefacto_electrico, bll_bocamercado.calcularbocaempresa(bocas.Item(0)))
                        End If
                    End If
                End If
            Case Else
                unbe.valor_manodeobra = 0
        End Select
        Me.calculo_valordinamico(unbe)
        ' Me.guardar_estado_cliente(unbe)
    End Sub

    ''' 
    ''' <param name="unbe"></param>
    Private Function calculo_trabajo_tareas(ByVal unbe As BE.BE_Presupuesto) As Integer
        Try
            Dim TOTAL As Integer = 0.0
            TOTAL = unbe.porcentaje_losa + unbe.porcentaje_caneriaycableado + unbe.porcentaje_llaveytoma + unbe.porcentaje_tablero + unbe.porcentaje_terminacion
            If TOTAL > 100 Then
                Return 10146
            Else
                If TOTAL < 100 Then
                    Return 10147
                Else
                    Return 10148
                End If
            End If
        Catch ex As Exception
            Return 10149

        End Try
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Sub calculo_valordinamico(ByVal unbe As BE.BE_Presupuesto)
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

    Function consultar_ultimo_comercial(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        Dim dal_consultar As New DAL.DAL_Presupuesto
        Return dal_consultar.consultar_ultimo_comercial(unbe)
    End Function
    ''' 

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
                If presu.estado_presupuesto = "Pendiente de llenado por parte del Responsable Comercial" Or presu.estado_presupuesto = "Cerrado" Then
                    dal_presupuesto.consulta_artefactos_presupuesto(presu)
                    dal_presupuesto.consulta_material_presupuesto(presu)
                    dal_presupuesto.consulta_trabajo_presupuesto(presu)
                End If
            Next
        End If
        Return listadepresupuesto

    End Function

    Public Function generar_solicitudpresupuesto(ByVal unbe As BE.BE_Presupuesto) As Integer
        administrar_estado(unbe)
        Dim dal_presupuesto As New DAL.DAL_Presupuesto
        Return dal_presupuesto.generar_solicitudpresupuesto(unbe)
    End Function

    Public Function guardar_estado_cliente(ByVal unbe As BE.BE_Presupuesto) As Integer
        Dim dal_presupuesto As New DAL.DAL_Presupuesto
        Dim cifrado As New SEGURIDAD.Criptografia
        Try
            unbe.estado_presupuesto = "Cerrado"
            unbe.estado_presupuesto = cifrado.cifrar(unbe.estado_presupuesto)
            unbe.fecha_modificacion = Now
            Select Case dal_presupuesto.guardar_estado_cliente(unbe)
                Case 10153
                    Return 10153
                Case 10154
                    Return 10154
            End Select
        Catch ex As Exception
            Return 10154
        End Try
        
    End Function

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


End Class


