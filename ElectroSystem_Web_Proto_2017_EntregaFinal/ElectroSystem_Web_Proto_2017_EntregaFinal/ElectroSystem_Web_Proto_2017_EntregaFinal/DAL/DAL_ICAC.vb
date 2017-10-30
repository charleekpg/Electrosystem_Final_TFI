



	Public Class DAL_ICAC


    Public m_BE_ICAC As BE.BE_ICAC
    Public m_SQLHelper As Seguridad.SQLHelper

		''' 
		''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_ICAC) As Boolean
        alta = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_ICAC) As Boolean
        baja = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_ICAC) As BE.BE_ICAC
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_ICAC)
        consultartodos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_ICAC) As Boolean
        modificar = Nothing
    End Function


	End Class ' DAL_ICAC


