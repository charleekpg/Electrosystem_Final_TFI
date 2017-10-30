


	Public Class DAL_Tarea


    Public m_BE_Tarea As BE.BE_Tarea

		''' 
		''' <param name="unbe"></param>
    Function alta(ByVal unbe As BE.BE_Tarea) As Boolean

    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Tarea) As Boolean

    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Tarea) As BE.BE_Tarea

    End Function

    Public Function consultartodos() As List(Of BE.BE_Tarea)
        consultartodos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Tarea) As Boolean

    End Function


	End Class ' DAL_Tarea


