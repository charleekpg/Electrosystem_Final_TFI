
	Public Class DAL_Familia


		''' 
		''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Permisocompuesto) As Boolean
        alta = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Permisocompuesto) As Boolean
        baja = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Permisocompuesto) As BE.BE_Permisocompuesto
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_Permisocompuesto)
        consultartodos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Sub eliminarfamiliaentablasDistinta(ByVal unbe As BE.BE_Permisocompuesto)

		End Sub

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Permisocompuesto) As Boolean
        modificar = False
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function validarunicafamilia(ByVal unbe As BE.BE_Permisocompuesto) As Boolean
			validarunicafamilia = False
		End Function


	End Class ' DAL_Familia


