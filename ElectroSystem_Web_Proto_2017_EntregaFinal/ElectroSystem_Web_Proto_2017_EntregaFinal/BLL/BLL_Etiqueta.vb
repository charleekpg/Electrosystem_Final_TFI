






Public Class BLL_Etiqueta


    Public Shared idioma_activo As BE.BE_Idioma = Nothing
    Public m_BE_Etiqueta As BE.BE_Etiqueta
    Public m_DAL_Etiqueta As DAL.DAL_Etiqueta

    Public Function alta() As Integer
        alta = 0
    End Function

    Public Sub cambiaridioma()

    End Sub

    Public Function consultar_todos() As List(Of BE.BE_Etiqueta)
        consultar_todos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function leer(ByVal unbe As BE.BE_Etiqueta) As BE.BE_Etiqueta
        leer = Nothing
    End Function


End Class 
