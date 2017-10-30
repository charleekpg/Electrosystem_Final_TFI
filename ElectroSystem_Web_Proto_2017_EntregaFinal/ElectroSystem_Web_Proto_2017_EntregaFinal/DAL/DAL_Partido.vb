




	Public Class DAL_Partido


    Public m_SQLHelper As Seguridad.SQLHelper
    Public m_BE_Partido As BE.BE_Partido

		''' 
		''' <param name="unbe"></param>
    Private Function cargar_localidad(ByVal unbe As List(Of BE.BE_Partido)) As List(Of BE.be_localidad)
        cargar_localidad = Nothing
    End Function

    Public Function cargar_partidos() As List(Of BE.BE_Partido)
        cargar_partidos = Nothing
    End Function


	End Class ' DAL_Partido


