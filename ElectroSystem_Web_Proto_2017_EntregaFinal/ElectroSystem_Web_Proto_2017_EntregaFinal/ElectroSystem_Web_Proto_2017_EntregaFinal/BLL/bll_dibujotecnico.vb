Public Class bll_dibujotecnico


    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_DibujoTecnico) As Integer
        Try
            Dim dal_dibujo As New DAL.DAL_Dibujotecnico
            unbe.fecha = Date.Now()
            Return dal_dibujo.Alta(unbe)
        Catch ex As Exception
            Return 0
        End Try

    End Function


    Friend Function contar_bocas_dibujo(unbe As BE.BE_DibujoTecnico) As Integer
        Dim contador As Integer = 0
        For Each ambiente As BE.Be_Ambiente In unbe.ambiente
            For Each circuito As BE.BE_Circuito In ambiente.circuitos
                contador = circuito.cantidad_bocas + contador
            Next
        Next
        Return contador
    End Function
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_DibujoTecnico) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consulta(ByVal unbe As BE.BE_DibujoTecnico) As BE.BE_DibujoTecnico
        Dim dal_consultar As New DAL.DAL_Dibujotecnico
        unbe = dal_consultar.Consulta(unbe)
        Return unbe
    End Function

    Public Function consultartodos() As List(Of BE.BE_DibujoTecnico)
        Try
            Dim dal_consultar As New DAL.DAL_Dibujotecnico
            Dim lista As List(Of BE.BE_DibujoTecnico)
            lista = dal_consultar.Consultartodos()
            For Each elemento As BE.BE_DibujoTecnico In lista
                dal_consultar.Consulta_ambientes_circuitos(elemento)
            Next
            Return lista

        Catch ex As Exception

        End Try

    End Function


    Private Function evaluar_cantidadcircuito(ByVal unbe As BE.BE_DibujoTecnico) As Boolean
        Try
            'este si hay que tenerlo en cuenta...

            Dim suma_circuitos As Integer = 0
            Dim ambiente As List(Of BE.Be_Ambiente)
            ambiente = unbe.ambiente
            For Each be_ambiente As BE.Be_Ambiente In ambiente
                For Each circuito As BE.BE_Circuito In be_ambiente.circuitos
                    circuito.descripcion = ""
                    suma_circuitos = suma_circuitos + 1
                Next
            Next
            Select Case unbe.grado_electrificacion
                Case "Minimo"
                    If suma_circuitos < 2 Then
                        unbe.cumple_cantidadcircuito = False
                        unbe.descripcion = "La cantidad mínima de circuitos según el grado de Electrificación es de 2."
                        Exit Select
                    End If
                Case "Medio"
                    If suma_circuitos < 3 Then
                        unbe.cumple_cantidadcircuito = False
                        unbe.descripcion = "La cantidad mínima de circuitos según el grado de Electrificación es de 3 ."

                        Exit Select
                    End If
                Case "Elevado"
                    If suma_circuitos < 5 Then
                        unbe.cumple_cantidadcircuito = False
                        unbe.descripcion = "La cantidad mínima de circuitos según el grado de Electrificación es de 5 ."

                        Exit Select
                    End If
                Case "Superior"
                    If suma_circuitos < 6 Then
                        unbe.cumple_cantidadcircuito = False
                        unbe.descripcion = "La cantidad mínima de circuitos según el grado de Electrificación es de 6 ."

                        Exit Select

                    End If
            End Select
            Return unbe.cumple_cantidadcircuito
        Catch ex As Exception

        End Try

    End Function

    Private Function evaluar_gradoelectrificacion(ByVal unbe As BE.BE_DibujoTecnico) As String
        Try
            ' se evalua metros cuadrados totales de la vivienda
            ' no debe devolver nada importante en nota.
            Dim suma As Decimal = 0
            unbe.descripcion = ""
            For Each ambiente As BE.Be_Ambiente In unbe.ambiente
                suma = ambiente.m2 + suma
            Next
            If suma <= 60 Then
                unbe.grado_electrificacion = "Minimo"
            Else
                If suma > 60 And suma <= 130 Then
                    unbe.grado_electrificacion = "Medio"
                Else
                    If suma > 130 And suma <= 200 Then
                        unbe.grado_electrificacion = "Elevado"
                    Else
                        unbe.grado_electrificacion = "Superior"
                    End If
                End If
            End If
            Return "OK"
        Catch ex As Exception

        End Try

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function evaluar_plano(ByVal unbe As BE.BE_DibujoTecnico) As Integer
        Try
            evaluar_gradoelectrificacion(unbe)
            evaluar_cantidadcircuito(unbe)
            evaluar_puntosminimos(unbe)
            If unbe.cumple_cantidadcircuito = True And unbe.cumple_puntosminimos = True And unbe.cumple_cantidadbocas = True Then
                unbe.cumple_ambientes = True
                Return 1
            Else
                unbe.cumple_ambientes = False
                Return 0

            End If
        Catch ex As Exception

        End Try

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Function evaluar_puntosminimos(ByVal unbe As BE.BE_DibujoTecnico) As Integer
        Try
            For Each ambiente As BE.Be_Ambiente In unbe.ambiente
                Select Case ambiente.tipo
                    Case "Bano"
                        For Each circuito As BE.BE_Circuito In ambiente.circuitos
                            If circuito.sigla = "TUE" Then
                                circuito.circuito_correcto_segun_ambiente = True
                            Else
                                If circuito.cantidad_bocas >= 1 Then
                                    circuito.circuito_correcto_segun_ambiente = True
                                Else
                                    circuito.descripcion = "Se debe contener una boca como mínimo."
                                    circuito.circuito_correcto_segun_ambiente = False
                                    unbe.cumple_puntosminimos = False
                                End If
                            End If
                        Next
                    Case "Dormitorio"
                        If ambiente.m2 < 10 Then
                            For Each circuito As BE.BE_Circuito In ambiente.circuitos
                                If circuito.sigla = "IUG" Then
                                    If circuito.cantidad_bocas >= 1 Then
                                        circuito.circuito_correcto_segun_ambiente = True
                                    Else
                                        circuito.descripcion = "Se debe contener una boca como mínimo."
                                        circuito.circuito_correcto_segun_ambiente = False
                                        unbe.cumple_puntosminimos = False
                                    End If
                                ElseIf circuito.sigla = "TUG" Then
                                    If circuito.cantidad_bocas >= 2 Then
                                        circuito.circuito_correcto_segun_ambiente = True
                                    Else
                                        circuito.descripcion = "Se debe contener dos bocas como mínimo."
                                        circuito.circuito_correcto_segun_ambiente = False
                                        unbe.cumple_puntosminimos = False

                                    End If
                                Else
                                    circuito.circuito_correcto_segun_ambiente = True
                                End If
                            Next
                        ElseIf ambiente.m2 >= 10 And ambiente.m2 < 36 Then
                            For Each circuito As BE.BE_Circuito In ambiente.circuitos
                                If circuito.sigla = "IUG" Then
                                    If circuito.cantidad_bocas >= 1 Then
                                        circuito.circuito_correcto_segun_ambiente = True
                                    Else
                                        circuito.descripcion = "Se debe contener una boca como mínimo."

                                        circuito.circuito_correcto_segun_ambiente = False
                                        unbe.cumple_puntosminimos = False
                                    End If
                                ElseIf circuito.sigla = "TUG" Then
                                    If circuito.cantidad_bocas >= 3 Then
                                        circuito.circuito_correcto_segun_ambiente = True
                                    Else
                                        circuito.descripcion = "Se debe contener tres bocas como mínimo."

                                        circuito.circuito_correcto_segun_ambiente = False
                                        unbe.cumple_puntosminimos = False
                                    End If
                                Else
                                    circuito.circuito_correcto_segun_ambiente = True
                                End If
                            Next
                        Else
                            For Each circuito As BE.BE_Circuito In ambiente.circuitos
                                If circuito.sigla = "IUG" Then
                                    If (unbe.grado_electrificacion = "Elevado" Or unbe.grado_electrificacion = "Superior") Then
                                        If circuito.cantidad_bocas >= 2 Then
                                            circuito.circuito_correcto_segun_ambiente = True
                                        Else
                                            circuito.descripcion = "Se debe contener dos bocas como mínimo."
                                            unbe.cumple_puntosminimos = False
                                            circuito.circuito_correcto_segun_ambiente = False
                                        End If
                                    Else
                                        circuito.circuito_correcto_segun_ambiente = True
                                    End If
                                ElseIf circuito.sigla = "TUG" Then
                                    If (unbe.grado_electrificacion = "Elevado" Or unbe.grado_electrificacion = "Superior") Then
                                        If circuito.cantidad_bocas >= 3 Then
                                            circuito.circuito_correcto_segun_ambiente = True
                                        Else
                                            circuito.descripcion = "Se debe contener tres bocas como mínimo."
                                            circuito.circuito_correcto_segun_ambiente = False
                                            unbe.cumple_puntosminimos = False
                                        End If
                                    Else
                                        circuito.circuito_correcto_segun_ambiente = True
                                    End If
                                ElseIf circuito.sigla = "TUE" Then
                                    If (unbe.grado_electrificacion = "Elevado" Or unbe.grado_electrificacion = "Superior") Then
                                        If circuito.cantidad_bocas >= 1 Then
                                            circuito.circuito_correcto_segun_ambiente = True
                                        Else
                                            circuito.descripcion = "Se debe contener una boca como mínimo."
                                            circuito.circuito_correcto_segun_ambiente = False
                                            unbe.cumple_puntosminimos = False
                                        End If
                                    Else
                                        circuito.circuito_correcto_segun_ambiente = True
                                    End If
                                End If
                            Next
                        End If
                    Case "Sala_De_estar_Comedor"
                        For Each circuito As BE.BE_Circuito In ambiente.circuitos
                            If circuito.sigla = "IUG" Then
                                If circuito.cantidad_bocas >= Me.redondeo(18, ambiente.m2) Then
                                    circuito.circuito_correcto_segun_ambiente = True
                                Else
                                    circuito.descripcion = "Se debe contener una boca cada 18m2 de superficie."
                                    unbe.cumple_puntosminimos = False

                                    circuito.circuito_correcto_segun_ambiente = False
                                End If
                            ElseIf circuito.sigla = "TUG" Then
                                If circuito.cantidad_bocas >= Me.redondeo(6, ambiente.m2) Then
                                    circuito.circuito_correcto_segun_ambiente = True
                                Else
                                    circuito.descripcion = "Se debe contener una boca cada 6m2 de superficie."
                                    unbe.cumple_puntosminimos = False

                                    circuito.circuito_correcto_segun_ambiente = False
                                End If
                            ElseIf circuito.sigla = "TUE" Then
                                If (unbe.grado_electrificacion = "Elevado" Or unbe.grado_electrificacion = "Superior") Then
                                    If ambiente.m2 > 36 Then
                                        If circuito.cantidad_bocas >= Me.redondeo(36, ambiente.m2) Then
                                            circuito.circuito_correcto_segun_ambiente = True
                                        Else
                                            circuito.descripcion = "Se debe contener una boca si la superficie de los ambientes supera los 36m2."
                                            unbe.cumple_puntosminimos = False

                                            circuito.circuito_correcto_segun_ambiente = False
                                        End If
                                    Else
                                        circuito.circuito_correcto_segun_ambiente = True
                                    End If
                                Else
                                    circuito.circuito_correcto_segun_ambiente = True
                                End If
                            End If
                        Next
                    Case "Cocina"
                        For Each circuito As BE.BE_Circuito In ambiente.circuitos
                            If circuito.sigla = "IUG" Then
                                If (unbe.grado_electrificacion = "Minimo") Then
                                    If circuito.cantidad_bocas >= 1 Then
                                        circuito.circuito_correcto_segun_ambiente = True
                                    Else
                                        circuito.descripcion = "Se debe contener una boca como mínimo."
                                        unbe.cumple_puntosminimos = False

                                        circuito.circuito_correcto_segun_ambiente = False
                                    End If
                                Else
                                    If circuito.cantidad_bocas >= 2 Then
                                        circuito.circuito_correcto_segun_ambiente = True
                                    Else
                                        circuito.descripcion = "Se debe contener dos bocas como mínimo."
                                        unbe.cumple_puntosminimos = False

                                        circuito.circuito_correcto_segun_ambiente = False
                                    End If
                                End If
                            ElseIf circuito.sigla = "TUG" Then
                                If (unbe.grado_electrificacion = "Minimo" Or unbe.grado_electrificacion = "Medio") Then
                                    If circuito.cantidad_bocas >= 5 Then
                                        circuito.circuito_correcto_segun_ambiente = True
                                    Else
                                        circuito.descripcion = "Se debe contener cinco bocas como mínimo."
                                        unbe.cumple_puntosminimos = False

                                        circuito.circuito_correcto_segun_ambiente = False
                                    End If
                                Else
                                    If (unbe.grado_electrificacion = "Elevado") Then
                                        If circuito.cantidad_bocas >= 6 Then
                                            circuito.circuito_correcto_segun_ambiente = True
                                        Else
                                            circuito.descripcion = "Se debe contener seis bocas como mínimo."
                                            unbe.cumple_puntosminimos = False

                                            circuito.circuito_correcto_segun_ambiente = False
                                        End If
                                    Else
                                        If (unbe.grado_electrificacion = "Superior") Then
                                            If circuito.cantidad_bocas >= 7 Then
                                                circuito.circuito_correcto_segun_ambiente = True
                                            Else
                                                circuito.descripcion = "Se debe contener siete bocas como mínimo."
                                                unbe.cumple_puntosminimos = False

                                                circuito.circuito_correcto_segun_ambiente = False
                                            End If
                                        Else
                                            circuito.circuito_correcto_segun_ambiente = True
                                        End If
                                    End If
                                End If
                            ElseIf circuito.sigla = "TUE" Then
                                If (unbe.grado_electrificacion = "Elevado" Or unbe.grado_electrificacion = "Superior") Then
                                    If circuito.cantidad_bocas >= 1 Then
                                        circuito.circuito_correcto_segun_ambiente = True
                                    Else
                                        circuito.descripcion = "Se debe contener una boca como mínimo."
                                        circuito.circuito_correcto_segun_ambiente = False
                                        unbe.cumple_puntosminimos = False

                                    End If
                                Else
                                    circuito.circuito_correcto_segun_ambiente = True
                                End If
                            End If
                        Next
                    Case "Vestibulo_Garage_Hall"
                        For Each circuito As BE.BE_Circuito In ambiente.circuitos
                            If circuito.sigla = "IUG" Then
                                If circuito.cantidad_bocas >= 1 Then
                                    circuito.circuito_correcto_segun_ambiente = True
                                Else
                                    circuito.descripcion = "Se debe contener una boca como mínimo."
                                    unbe.cumple_puntosminimos = False

                                    circuito.circuito_correcto_segun_ambiente = False
                                End If
                            Else
                                If circuito.sigla = "TUG" Then
                                    If (unbe.grado_electrificacion = "Minimo") Then
                                        If circuito.cantidad_bocas >= 1 Then
                                            circuito.circuito_correcto_segun_ambiente = True
                                        Else
                                            circuito.descripcion = "Se debe contener una boca como mínimo."
                                            unbe.cumple_puntosminimos = False

                                            circuito.circuito_correcto_segun_ambiente = False
                                        End If
                                    Else
                                        If circuito.cantidad_bocas >= Me.redondeo(12, ambiente.m2) Then
                                            circuito.circuito_correcto_segun_ambiente = True
                                        Else
                                            unbe.cumple_puntosminimos = False

                                            circuito.descripcion = "Se debe contener una boca cada 12 m2 de superficie."
                                            circuito.circuito_correcto_segun_ambiente = False
                                        End If
                                    End If
                                Else
                                    circuito.circuito_correcto_segun_ambiente = True
                                End If
                            End If
                        Next
                End Select
                For Each circuito As BE.BE_Circuito In ambiente.circuitos
                    Select Case circuito.sigla
                        Case "IUG"
                            If circuito.cantidad_bocas <= 15 Then
                                circuito.cumple_cantidad_bocas_circuito = True
                            Else
                                circuito.descripcion = circuito.descripcion & "La máxima cantidad de bocas permitida es 15."
                                circuito.cumple_cantidad_bocas_circuito = False
                                unbe.cumple_cantidadbocas = False
                                Exit Select
                            End If
                        Case "TUG"
                            If circuito.cantidad_bocas <= 15 Then
                                circuito.cumple_cantidad_bocas_circuito = True
                            Else
                                circuito.descripcion = circuito.descripcion & "La máxima cantidad de bocas permitida es 15."
                                circuito.cumple_cantidad_bocas_circuito = False
                                unbe.cumple_cantidadbocas = False
                                Exit Select
                            End If
                        Case "IUE"
                            If circuito.cantidad_bocas <= 12 Then
                                circuito.cumple_cantidad_bocas_circuito = True
                            Else
                                circuito.descripcion = circuito.descripcion & "La máxima cantidad de bocas permitida es 12."
                                circuito.cumple_cantidad_bocas_circuito = False
                                unbe.cumple_cantidadbocas = False
                                Exit Select
                            End If
                        Case "TUE"
                            If circuito.cantidad_bocas <= 12 Then
                                circuito.cumple_cantidad_bocas_circuito = True
                            Else
                                circuito.descripcion = circuito.descripcion & "La máxima cantidad de bocas permitida es 12."
                                circuito.cumple_cantidad_bocas_circuito = False
                                unbe.cumple_cantidadbocas = False
                                Exit Select
                            End If
                    End Select
                Next
            Next
        Catch ex As Exception

        End Try

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificacion(ByVal unbe As BE.BE_DibujoTecnico) As Boolean
        modificacion = False
    End Function

    Private Function redondeo(valor1 As Integer, valor2 As Decimal) As Integer
        If Decimal.Truncate(valor2 / valor1) > 1 Then
            Return Decimal.Truncate(valor2 / valor1)
        Else
            Return 1
        End If
    End Function
End Class