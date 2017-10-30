


	Public Class BLL_Proyecto


    Private porcentaje_tareas As Integer
		Public m_BLL_Tarea As BLL.BLL_Tarea
    Public m_BE_Proyecto As BE.BE_Proyecto
		Public m_DAL_Proyecto As DAL.DAL_Proyecto
    Public m_BE_Bitacora As BE.BE_Bitacora
		Public m_BLL_Bitacora As BLL.BLL_Bitacora

		''' 
		''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Proyecto) As Boolean
        alta = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Proyecto) As Boolean
        baja = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Sub calcular_tiempos_regulares(ByVal unbe As BE.BE_Proyecto)

    End Sub

		''' 
		''' <param name="unbe"></param>
    Private Function calcularlimite_superior_inferior(ByVal unbe As List(Of BE.BE_Proyecto)) As BE.BE_Proyecto
        calcularlimite_superior_inferior = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Private Function calcularpromediodedias(ByVal unbe As List(Of BE.BE_Proyecto)) As BE.BE_Proyecto
        calcularpromediodedias = Nothing
    End Function

		''' 
		''' <param name="inferior"></param>
		''' <param name="superior"></param>
    Private Function calcularpromediodiascercanos(ByVal inferior As BE.BE_Proyecto, ByVal superior As BE.BE_Proyecto) As BE.BE_Proyecto
        calcularpromediodiascercanos = Nothing
    End Function

		''' 
		''' <param name="inferior"></param>
		''' <param name="superior"></param>
    Private Function calcularpromediogeneraldias(ByVal inferior As BE.BE_Proyecto, ByVal superior As BE.BE_Proyecto) As BE.BE_Proyecto
        calcularpromediogeneraldias = Nothing
    End Function

		''' 
		''' <param name="inferior"></param>
		''' <param name="superior"></param>
    Private Function calcularpromediomargensupinf(ByVal inferior As BE.BE_Proyecto, ByVal superior As BE.BE_Proyecto) As BE.BE_Proyecto
        calcularpromediomargensupinf = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function cerrarproyecto(ByVal unbe As BE.BE_Proyecto) As Boolean
        cerrarproyecto = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Proyecto) As BE.BE_Proyecto
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_Proyecto)
        consultartodos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Proyecto) As Boolean
        modificar = False
    End Function



		''' 
		''' <param name="inferior"></param>
		''' <param name="superior"></param>
    Public Function validar_margenes(ByVal inferior As BE.BE_Proyecto, ByVal superior As BE.BE_Proyecto) As BE.BE_Proyecto
        validar_margenes = Nothing
    End Function


	End Class ' BLL_Proyecto


