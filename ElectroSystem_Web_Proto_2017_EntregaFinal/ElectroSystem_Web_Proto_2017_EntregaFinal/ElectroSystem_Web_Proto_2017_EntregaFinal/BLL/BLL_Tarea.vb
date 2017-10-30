




	Public Class BLL_Tarea


    Public m_BE_Tarea As BE.BE_Tarea
		Public m_DAL_Tarea As DAL.DAL_Tarea

		''' 
		''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Tarea) As Boolean
        alta = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Tarea) As Boolean
        baja = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Tarea) As BE.BE_Tarea
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_Tarea)
        consultartodos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function generar_certificado(ByVal unbe As List(Of BE.BE_Tarea)) As Boolean
        generar_certificado = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Tarea) As Boolean
        modificar = False
    End Function

		

		''' 
		''' <param name="unbe"></param>
    Public Function validartareas_porcentaje(ByVal unbe As BE.BE_Tarea) As Boolean
        validartareas_porcentaje = False
    End Function


	End Class ' BLL_Tarea


