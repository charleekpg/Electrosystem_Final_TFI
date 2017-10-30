


	Public Class BLL_Material_TrabajoconPrec


    Public m_BE_Material_TrabajoconPrec As BE.BE_Material_TrabajoconPrec
		Public m_DAL_Material_TrabajoconPrec As DAL.DAL_Material_TrabajoconPrec
		Public m_BLL_Bitacora As BLL.BLL_Bitacora

		''' 
		''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Material_TrabajoconPrec) As Boolean
        alta = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Material_TrabajoconPrec) As Boolean
        baja = False
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Sub calcular_precio_cantidad(ByVal unbe As BE.BE_Material_TrabajoconPrec)

		End Sub

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Material_TrabajoconPrec) As BE.BE_Material_TrabajoconPrec
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_Material_TrabajoconPrec)
        consultartodos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Material_TrabajoconPrec) As Boolean
        modificar = False
    End Function


	End Class ' BLL_Material_TrabajoconPrec


