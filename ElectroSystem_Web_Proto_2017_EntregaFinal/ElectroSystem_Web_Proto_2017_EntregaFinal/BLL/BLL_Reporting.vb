


	Public Class BLL_Reporting


		Public m_DAL_Reporting As DAL.DAL_Reporting
    Public m_BE_Reporting As BE.BE_Reporting
		Public m_BLL_Bitacora As BLL.BLL_Bitacora
    Public m_BE_Bitacora As BE.BE_Bitacora

		''' 
		''' <param name="UNBE"></param>
		Private Function clientes_criticos(ByVal UNBE As BE.BE_Reporting) As BE.BE_Reporting
			clientes_criticos = Nothing
		End Function

		''' 
		''' <param name="unbe"></param>
		Public Function generar_grafico(ByVal unbe As BE.BE_Reporting) As BE.BE_Reporting
			generar_grafico = Nothing
		End Function

		''' 
		''' <param name="unbe"></param>
		Public Function reporte(ByVal unbe As BE.BE_Reporting) As BE.BE_Reporting
			reporte = Nothing
		End Function

		''' 
		''' <param name="unbe"></param>
		Private Function top5_artefactos(ByVal unbe As BE.BE_Reporting) As BE.BE_Reporting
			top5_artefactos = Nothing
		End Function

		''' 
		''' <param name="unbe"></param>
		Private Function top5_material(ByVal unbe As BE.BE_Reporting) As BE.BE_Reporting
			top5_material = Nothing
		End Function

		''' 
		''' <param name="unbe"></param>
		Private Function top5_trabajos(ByVal unbe As BE.BE_Reporting) As BE.BE_Reporting
			top5_trabajos = Nothing
		End Function


	End Class ' BLL_Reporting


