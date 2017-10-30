

	Public Class DAL_Permisos


    Public m_SQLHelper As Seguridad.SQLHelper

		''' 
		''' <param name="unbe"></param>
		Public Function alta(ByVal unbe As BE.BE_Permisocompuesto) As Boolean
			alta = False
		End Function

		''' 
		''' <param name="unbe"></param>
		Public Function consultar_permisos(ByVal unbe As BE.BE_PermisoBase) As BE.BE_PermisoBase
			consultar_permisos = Nothing
		End Function

		''' 
		''' <param name="unbe"></param>
		Public Function consultar_si_espermiso(ByVal unbe As BE.BE_PermisoBase) As Boolean
			consultar_si_espermiso = False
		End Function

    Public Function listarpermisos() As List(Of BE.BE_Permisocompuesto)
        listarpermisos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function validar_familia(ByVal unbe As BE.BE_Permisocompuesto) As Boolean
			validar_familia = False
		End Function


	End Class ' DAL_Permisos


