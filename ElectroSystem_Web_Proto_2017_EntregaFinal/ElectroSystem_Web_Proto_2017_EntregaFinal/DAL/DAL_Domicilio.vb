







	Public Class DAL_Domicilio


    Public m_BE_Domicilio As BE.BE_Domicilio
    Public m_SQLHelper As Seguridad.SQLHelper

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Domicilio) As Boolean
        alta = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Domicilio) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Domicilio) As BE.BE_Domicilio
        consultar = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function consultar_ultimo(ByVal unbe As BE.BE_Domicilio) As BE.BE_Domicilio
			consultar_ultimo = Nothing
		End Function

    Public Function consultartodos() As List(Of BE.BE_Domicilio)
        consultartodos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Domicilio) As Boolean
        modificar = False
    End Function


	End Class ' DAL_Domicilio


