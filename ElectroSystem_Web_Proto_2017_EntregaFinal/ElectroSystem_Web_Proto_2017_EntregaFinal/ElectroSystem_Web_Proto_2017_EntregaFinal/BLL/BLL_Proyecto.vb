


	Public Class BLL_Proyecto


    Private Function porcentaje_tareas(ByVal unbe As BE.BE_Proyecto) As Boolean
        Dim suma_porcentaje_1 As Decimal = 0
        Dim suma_porcentaje_2 As Decimal = 0
        Dim suma_porcentaje_3 As Decimal = 0
        Dim suma_porcentaje_4 As Decimal = 0
        Dim suma_porcentaje_5 As Decimal = 0

        For Each tarea In unbe.tarea
            If tarea.cableado = True Then
                suma_porcentaje_1 = suma_porcentaje_1 + tarea.porcentaje_tarea
            ElseIf tarea.caneria = True Then
                suma_porcentaje_2 = suma_porcentaje_2 + tarea.porcentaje_tarea
            ElseIf tarea.istablero = True Then
                suma_porcentaje_3 = suma_porcentaje_3 + tarea.porcentaje_tarea
            ElseIf tarea.isterminacion = True Then
                suma_porcentaje_4 = suma_porcentaje_4 + tarea.porcentaje_tarea
            ElseIf tarea.losa = True Then
                suma_porcentaje_5 = suma_porcentaje_5 + tarea.porcentaje_tarea

            End If
        Next
        If suma_porcentaje_1 + suma_porcentaje_2 + suma_porcentaje_3 + suma_porcentaje_4 + suma_porcentaje_5 = 100 Then
            Return 1
        Else Return 0
        End If
    End Function
    Public m_BLL_Tarea As BLL.BLL_Tarea
    Public m_BE_Proyecto As BE.BE_Proyecto
		Public m_DAL_Proyecto As DAL.DAL_Proyecto
    Public m_BE_Bitacora As BE.BE_Bitacora
		Public m_BLL_Bitacora As BLL.BLL_Bitacora

		''' 
		''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Proyecto) As Boolean
        alta = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Proyecto) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function calcular_tiempos_regulares(ByVal unbe As BE.BE_Proyecto) As BE.BE_Proyecto
        Dim consultartodos As New DAL.DAL_Proyecto
        Dim be_proyectos As List(Of BE.BE_Proyecto)

        Dim suma_boca_proy As Integer = 0
        Dim SUMA_BOCA_MENOR As Integer = 100000000
        Dim lista_con_bocas_similares As New List(Of BE.BE_Proyecto)
        Dim lista_con_bocas_mayores_menores As New List(Of BE.BE_Proyecto)
        be_proyectos = consultartodos.consultartodos()
        For Each be_ambiente As BE.Be_Ambiente In unbe.Presupuesto.dibujotecnico.ambiente
            For Each circuito As BE.BE_Circuito In be_ambiente.circuitos
                suma_boca_proy = circuito.cantidad_bocas + suma_boca_proy
            Next
        Next

        For Each be_proyecto As BE.BE_Proyecto In be_proyectos
            Dim suma_boca_proyectos As Integer = 0
            For Each be_ambiente As BE.Be_Ambiente In be_proyecto.Presupuesto.dibujotecnico.ambiente
                For Each circuito As BE.BE_Circuito In be_ambiente.circuitos
                    suma_boca_proyectos = circuito.cantidad_bocas + suma_boca_proyectos
                Next
                If suma_boca_proyectos = suma_boca_proy Then
                    lista_con_bocas_similares.Add(be_proyecto)
                Else
                    If Math.Abs(suma_boca_proyectos - suma_boca_proy) < 10 Then

                        lista_con_bocas_mayores_menores.Add(be_proyecto)

                    End If
                End If
            Next
        Next
        If lista_con_bocas_similares.Count > 0 Then
                unbe.fecha_establecida_contrato = unbe.fecha_inicio.AddDays(Me.calcularpromediodedias(lista_con_bocas_similares).Presupuesto.id)

        Else
            If lista_con_bocas_mayores_menores.Count > 0 Then 'lo agrego a la lista, se que el ultimo es el cargado.
                lista_con_bocas_mayores_menores.Add(unbe)
                unbe.fecha_establecida_contrato = unbe.fecha_inicio.AddDays(Me.calcularlimite_superior_inferior(lista_con_bocas_mayores_menores).Presupuesto.id)

            Else
                unbe.fecha_establecida_contrato = unbe.fecha_inicio.AddDays(1)
                End If
            End If

        Return unbe
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Function calcularlimite_superior_inferior(ByVal unbe As List(Of BE.BE_Proyecto)) As BE.BE_Proyecto
        Dim suma_boca_proy As Integer = 0
        Dim proyecto As BE.BE_Proyecto
        proyecto = unbe.Item(unbe.Count - 1)
        For Each be_ambiente As BE.Be_Ambiente In proyecto.Presupuesto.dibujotecnico.ambiente
            For Each circuito As BE.BE_Circuito In be_ambiente.circuitos
                suma_boca_proy = circuito.cantidad_bocas + suma_boca_proy
            Next
        Next
        Dim be_proyecto_temp As New BE.BE_Proyecto
        Dim lista_de_dias As New List(Of Integer)
        Dim suma As Integer = 0
        Dim lista_temporal As New List(Of BE.BE_Proyecto)
        Dim valormenor As Integer = 0
        For Each objeto In unbe
            Dim valor As Integer = 0
            If objeto IsNot proyecto Then

                For Each elemento In objeto.Presupuesto.dibujotecnico.ambiente
                    For Each elemento1 In elemento.circuitos
                        valor = valor + elemento1.cantidad_bocas
                    Next
                Next
                If valormenor = 0 Then
                    valormenor = valor
                Else
                    If Math.Abs(valormenor - suma_boca_proy) > Math.Abs(valor - suma_boca_proy) Then
                        valormenor = valor
                    End If
                End If
            End If
        Next

        For Each objeto In unbe
            Dim valor As Integer = 0
            If objeto IsNot proyecto Then
                For Each elemento In objeto.Presupuesto.dibujotecnico.ambiente
                    For Each elemento1 In elemento.circuitos
                        valor = valor + elemento1.cantidad_bocas
                    Next
                Next
                If valormenor = valor Then
                    lista_temporal.Add(objeto)
                End If
            End If
        Next

        For Each proyecto In lista_temporal
            lista_de_dias.Add(DateDiff(DateInterval.Day, proyecto.fecha_inicio, proyecto.fecha_establecida_contrato))
        Next
        For Each elemento In lista_de_dias
            suma += elemento
        Next
        be_proyecto_temp.Presupuesto = New BE.BE_Presupuesto
        'esto lo uso solamente para devolverle el valor de la suma...
        be_proyecto_temp.Presupuesto.id = Math.Truncate(suma / lista_de_dias.Count)
        Return be_proyecto_temp
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Function calcularpromediodedias(ByVal unbe As List(Of BE.BE_Proyecto)) As BE.BE_Proyecto
        Dim be_proyecto_temp As New BE.BE_Proyecto
        Dim lista_de_dias As New List(Of Integer)
        Dim suma As Integer = 0
        For Each proyecto In unbe
            lista_de_dias.Add(DateDiff(DateInterval.Day, proyecto.fecha_inicio, proyecto.fecha_establecida_contrato))
        Next
        For Each elemento In lista_de_dias
            suma += elemento
        Next
        be_proyecto_temp.Presupuesto = New BE.BE_Presupuesto
        'esto lo uso solamente para devolverle el valor de la suma...
        be_proyecto_temp.Presupuesto.id = Math.Truncate(suma / lista_de_dias.Count)
        Return be_proyecto_temp
    End Function


    ''' 
    ''' <param name="unbe"></param>
    Public Function cerrarproyecto(ByVal unbe As BE.BE_Proyecto) As Boolean
        unbe.fecha_establecida_contrato = Date.Today
        If Me.porcentaje_tareas(unbe) = False Then
            Return False

        Else
            Dim bll_presupuesto As New BLL.BLL_Presupuesto
            unbe.Presupuesto = bll_presupuesto.administrar_estado(unbe.Presupuesto)
            Dim dal_proyecto As New DAL.DAL_Proyecto
            Return dal_proyecto.cerrar_proyecto(unbe)
        End If

    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Proyecto) As BE.BE_Proyecto
        Dim dal_consultar As New DAL.DAL_Proyecto
        unbe = dal_consultar.consultar(unbe)
        Return unbe
    End Function

    Public Function consultartodos() As List(Of BE.BE_Proyecto)
        Dim consultartodo As New DAL.DAL_Proyecto
        Return consultartodo.consultartodos()
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Proyecto) As Boolean
        modificar = False
    End Function




End Class ' BLL_Proyecto


