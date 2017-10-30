Public Class bll_dibujotecnico


    Public m_BE_DibujoTecnico As BE.BE_DibujoTecnico
    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_BLL_Bitacora As BLL.BLL_Bitacora
    Public m_DAL_Dibujotecnico As DAL.DAL_Dibujotecnico

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_DibujoTecnico) As Boolean
        alta = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_DibujoTecnico) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consulta(ByVal unbe As BE.BE_DibujoTecnico) As BE.BE_DibujoTecnico
        consulta = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_DibujoTecnico)
        consultartodos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Function evaluación_reglamentaria_general(ByVal unbe As BE.BE_DibujoTecnico) As Integer
        evaluación_reglamentaria_general = 0
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Function evaluar_cantidadcircuito(ByVal unbe As BE.BE_DibujoTecnico) As Boolean
        evaluar_cantidadcircuito = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Function evaluar_gradoelectrificacion(ByVal unbe As BE.BE_DibujoTecnico) As String
        evaluar_gradoelectrificacion = ""
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function evaluar_plano(ByVal unbe As BE.BE_DibujoTecnico) As Integer
        evaluar_plano = 0
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Function evaluar_puntosminimos(ByVal unbe As BE.BE_DibujoTecnico) As Integer
        evaluar_puntosminimos = 0
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificacion(ByVal unbe As BE.BE_DibujoTecnico) As Boolean
        modificacion = False
    End Function


End Class 