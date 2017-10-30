Public Class BLL_PersonaJuridica


    Private dal_personajuridica As New DAL.DAL_PersonaJuridica
    Public m_DAL_Cliente As DAL.DAL_Cliente
    Public m_BE_Personajuridica As BE.BE_Personajuridica

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Personajuridica) As Boolean
        alta = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Personajuridica) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Personajuridica) As List(Of BE.BE_Personajuridica)
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_Personajuridica)
        consultartodos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Personajuridica) As Boolean
        modificar = False
    End Function


End Class ' BLL_PersonaJuridica


