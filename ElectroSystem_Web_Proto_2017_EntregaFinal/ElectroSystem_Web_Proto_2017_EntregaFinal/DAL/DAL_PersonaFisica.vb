




	Public Class DAL_PersonaFisica


    Public m_SQLHelper As Seguridad.SQLHelper

		''' 
		''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Personafisica) As Boolean
        alta = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Personafisica) As Boolean
        baja = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Personafisica) As List(Of BE.BE_Personafisica)
        consultar = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function consultar_contacto(ByVal unbe As BE.BE_Personafisica) As BE.BE_Personafisica
			consultar_contacto = Nothing
		End Function

    Public Function consultartodos() As List(Of BE.BE_Personafisica)
        consultartodos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Personafisica) As Boolean
        modificar = Nothing
    End Function


	End Class ' DAL_PersonaFisica


