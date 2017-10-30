Public Class BLL_BocaMercado


    Public Shared bocamercado As BE.BE_BocaMercado
    Public m_BLL_Bitacora As BLL.BLL_Bitacora
    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_DAL_BocaMercado As DAL.DAL_BocaMercado

    ''' 
    ''' <param name="unbe"></param>
    Public Function calcularbocaempresa(ByVal unbe As BE.BE_BocaMercado) As BE.BE_BocaMercado
        calcularbocaempresa = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function calcularbocaextraordinaria(ByVal unbe As BE.BE_BocaMercado) As BE.BE_BocaMercado
        calcularbocaextraordinaria = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_BocaMercado) As BE.BE_BocaMercado
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_BocaMercado)
        consultartodos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function definir_boca(ByVal unbe As BE.BE_BocaMercado) As Boolean
        definir_boca = False
    End Function


End Class 