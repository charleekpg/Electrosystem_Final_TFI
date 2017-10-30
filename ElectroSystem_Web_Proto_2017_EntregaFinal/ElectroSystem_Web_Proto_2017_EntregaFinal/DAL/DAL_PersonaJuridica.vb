
	Public Class DAL_PersonaJuridica


    Public m_SQLHelper As Seguridad.SQLHelper

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

		''' 
		''' <param name="unbe"></param>
		Public Shared Function validarcuit_razonsocial(ByVal unbe As BE.BE_Personajuridica) As Boolean
			validarcuit_razonsocial = False
		End Function


	End Class ' DAL_PersonaJuridica


