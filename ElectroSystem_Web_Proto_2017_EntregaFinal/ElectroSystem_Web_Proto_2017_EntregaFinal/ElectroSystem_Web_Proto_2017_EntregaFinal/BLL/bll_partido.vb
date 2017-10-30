


	Public Class bll_partido


		Public m_DAL_Partido As DAL.DAL_Partido
    Public m_BE_Partido As BE.BE_Partido

    Function cargar_partidos() As List(Of BE.BE_Partido)
        Try
            Dim dal_partido As New DAL.DAL_Partido
            Dim lista_partido As List(Of BE.BE_Partido)
            lista_partido = dal_partido.cargar_partidos()
            Select Case lista_partido.Count
                Case 0
                    Return Nothing
                Case Else
                    Return lista_partido
            End Select
        Catch ex As Exception

        End Try

    End Function


End Class ' bll_partido


