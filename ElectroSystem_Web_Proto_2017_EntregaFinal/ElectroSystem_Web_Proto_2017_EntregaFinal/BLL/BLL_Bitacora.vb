Public Class BLL_Bitacora


    Public m_Criptografia As Seguridad.Criptografia
    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_DAL_Bitacora As DAL.DAL_Bitacora

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Bitacora) As Boolean
        alta = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Bitacora) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Bitacora) As BE.BE_Bitacora
        consultar = Nothing
    End Function

    Public Function consultarcodigodeevento() As List(Of BE.BE_Bitacora)
        consultarcodigodeevento = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_Bitacora)
        consultartodos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Bitacora) As Boolean
        modificar = False
    End Function


End Class ' BLL_Bitacora

