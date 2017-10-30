

	Public Class DAL_Telefono


    Public m_BE_Telefono As BE.BE_Telefono

		''' 
		''' <param name="unbe"></param>
		Public Function alta_telefono(ByVal unbe As BE.BE_CLIENTE) As Boolean
			alta_telefono = False
		End Function

		''' 
		''' <param name="unbe"></param>
    Public Function cargar_telefono(ByVal unbe As BE.BE_CLIENTE) As List(Of BE.BE_Telefono)
        cargar_telefono = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function validartelefono(ByVal unbe As List(Of BE.BE_Telefono)) As Integer
        validartelefono = 0
    End Function



	End Class ' DAL_Telefono


