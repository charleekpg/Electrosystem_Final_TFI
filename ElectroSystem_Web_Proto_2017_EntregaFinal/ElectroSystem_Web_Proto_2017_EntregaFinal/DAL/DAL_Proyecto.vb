




	Public Class DAL_Proyecto


    Public m_BE_Proyecto As BE.BE_Proyecto
    Public m_SQLHelper As Seguridad.SQLHelper

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
    Public Function cerrar_proyecto(ByVal unbe As BE.BE_Proyecto) As Boolean
        cerrar_proyecto = False
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


	End Class ' DAL_Proyecto


