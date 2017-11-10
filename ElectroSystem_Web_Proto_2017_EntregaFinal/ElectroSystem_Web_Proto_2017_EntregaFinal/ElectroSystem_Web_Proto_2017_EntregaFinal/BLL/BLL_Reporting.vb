


Public Class BLL_Reporting
    Private Function clientes_criticos(UNBE As BE.BE_Reporting) As BE.BE_Reporting
        Try
            Dim dal_reporte As New DAL.DAL_Reporting
            Dim reporte As BE.BE_Reporting
            Dim Bitacora As New BE.BE_Bitacora
            Dim bll_Bitacora As New BLL.BLL_Bitacora
            Dim cifrado As New SEGURIDAD.Criptografia
            Dim presupuesto As New BE.BE_Presupuesto
            presupuesto.estado_presupuesto = "Cerrado"
            presupuesto.estado_presupuesto = cifrado.cifrar(presupuesto.estado_presupuesto)
            UNBE.presupuesto = presupuesto
            reporte = dal_reporte.clientes_criticos(UNBE)
            Select Case reporte.fallo
                Case False
                    Bitacora.codigo_evento = 10155
                    Bitacora.usuario = BE.BE_Usuario.usuariologueado
                    bll_Bitacora.alta(Bitacora)
                    Return reporte
                Case True
                    Bitacora.codigo_evento = 10156
                    Bitacora.usuario = BE.BE_Usuario.usuariologueado
                    bll_Bitacora.alta(Bitacora)
                    Return reporte
            End Select
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ''' 
    ''' <param name="unbe"></param>
    Public Function generar_grafico(ByVal unbe As BE.BE_Reporting) As BE.BE_Reporting
			generar_grafico = Nothing
		End Function

    Function reporte(unbe As BE.BE_Reporting) As BE.BE_Reporting
        If unbe.top5artefacto = True Then
            Return top5_artefactos()
        Else
            If unbe.top5trabajo = True Then
                Return top5_trabajos()
            Else
                If unbe.top5material = True Then
                    Return top5_material()
                Else
                    If unbe.cantidad_clientes = True Or unbe.valores_clientes = True Then
                        Return clientes_criticos(unbe)
                    End If
                End If

            End If
        End If
    End Function

    ''' 
    Private Function top5_artefactos() As BE.BE_Reporting
        Try
            Dim dal_reporting As New DAL.DAL_Reporting
            Dim be_reporte As BE.BE_Reporting
            Dim Bitacora As New BE.BE_Bitacora
            Dim bll_Bitacora As New BLL.BLL_Bitacora
            be_reporte = dal_reporting.top5_artefactos()
            Select Case be_reporte.fallo
                Case True
                    Return be_reporte
                Case False
                    Return be_reporte
            End Select
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' 
    Private Function top5_material() As BE.BE_Reporting
        Try
            Dim dal_reporting As New DAL.DAL_Reporting
            Dim be_reporte As BE.BE_Reporting
            Dim Bitacora As New BE.BE_Bitacora
            Dim bll_Bitacora As New BLL.BLL_Bitacora
            be_reporte = dal_reporting.top5_material()
            Select Case be_reporte.fallo
                Case True
                    Bitacora.codigo_evento = 10161
                    Bitacora.usuario = BE.BE_Usuario.usuariologueado
                    bll_Bitacora.alta(Bitacora)
                    Return be_reporte
                Case False
                    Bitacora.codigo_evento = 10162
                    Bitacora.usuario = BE.BE_Usuario.usuariologueado
                    bll_Bitacora.alta(Bitacora)
                    Return be_reporte
            End Select
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Function top5_trabajos() As BE.BE_Reporting
        Try
            Dim dal_reporting As New DAL.DAL_Reporting
            Dim be_reporte As BE.BE_Reporting
            Dim Bitacora As New BE.BE_Bitacora
            Dim bll_Bitacora As New BLL.BLL_Bitacora
            be_reporte = dal_reporting.top5_trabajos()
            Select Case be_reporte.fallo
                Case True
                    Bitacora.codigo_evento = 10159
                    Bitacora.usuario = BE.BE_Usuario.usuariologueado
                    bll_Bitacora.alta(Bitacora)
                    Return be_reporte
                Case False
                    Bitacora.codigo_evento = 10160
                    Bitacora.usuario = BE.BE_Usuario.usuariologueado
                    bll_Bitacora.alta(Bitacora)
                    Return be_reporte
            End Select
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class ' BLL_Reporting


