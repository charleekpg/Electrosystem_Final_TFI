


	Public Class DAL_Bitacora


    Public m_Digito_Verificador As Seguridad.Digito_Verificador
    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_SQLHelper As Seguridad.SQLHelper

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
		''' <param name="UNBE"></param>
    Private Function GestionarErrorBd(ByVal UNBE As String) As Boolean
        GestionarErrorBd = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Bitacora) As Boolean
        modificar = False
    End Function


	End Class ' DAL_Bitacora


