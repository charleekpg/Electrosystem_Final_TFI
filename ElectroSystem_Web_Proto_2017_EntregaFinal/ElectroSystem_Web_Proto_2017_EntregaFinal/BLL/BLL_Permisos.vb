

	Public Class BLL_Permisos


    Public m_BE_PermisoBase As BE.BE_PermisoBase
		Public m_DAL_Permisos As DAL.DAL_Permisos
		Public m_BLL_Bitacora As BLL.BLL_Bitacora

		''' 
		''' <param name="unbe"></param>
    Public Sub alta(ByVal unbe As Type)

    End Sub

		''' 
		''' <param name="unbe"></param>
		Public Function aprobar_permiso(ByVal unbe As BE.BE_PermisoBase) As Boolean
			aprobar_permiso = False
		End Function

		''' 
		''' <param name="unbe"></param>
    Public Sub baja(ByVal unbe As Type)

    End Sub

		''' 
		''' <param name="unbe"></param>
    Public Sub consultar(ByVal unbe As Type)

    End Sub

		''' 
		''' <param name="unbe"></param>
		Public Function consultar_permiso(ByVal unbe As BE.BE_PermisoBase) As BE.BE_PermisoBase
			consultar_permiso = Nothing
		End Function

		''' 
		''' <param name="unbe"></param>
		Private Function consultar_si_espermiso(ByVal unbe As BE.BE_PermisoBase) As Integer
			consultar_si_espermiso = 0
		End Function

    Public Function consultartodos() As List(Of Type)
        consultartodos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Sub crear_familia(ByVal unbe As BE.BE_Permisocompuesto)

		End Sub

    Public Function listarpermisos() As List(Of BE.BE_PermisoBase)
        listarpermisos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Sub modificar(ByVal unbe As Type)

    End Sub

		''' 
		''' <param name="unbe"></param>
		''' <param name="permiso"></param>
		Private Function recurrente_permiso(ByVal unbe As BE.BE_PermisoBase, ByVal permiso As BE.BE_PermisoBase) As Boolean
			recurrente_permiso = False
		End Function

		''' 
		''' <param name="unbe"></param>
		Private Function validar_familia(ByVal unbe As BE.BE_Permisocompuesto) As Integer
			validar_familia = 0
		End Function

		''' 
		''' <param name="unbe"></param>
		Private Function validar_permiso(ByVal unbe As BE.BE_PermisoBase) As Boolean
			validar_permiso = False
		End Function


	End Class ' BLL_Permisos


