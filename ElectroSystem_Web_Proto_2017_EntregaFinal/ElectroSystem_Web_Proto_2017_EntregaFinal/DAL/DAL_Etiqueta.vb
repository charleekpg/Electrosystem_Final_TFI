




	Public Class DAL_Etiqueta


    Public m_BE_Etiqueta As BE.BE_Etiqueta
    Public m_SQLHelper As Seguridad.SQLHelper

    Public Function alta() As Integer
        alta = 0
    End Function

		''' 
		''' <param name="idioma"></param>
		Private Function consultar_idioma_exis(ByVal idioma As be.be_idioma) As Boolean
			consultar_idioma_exis = False
		End Function

		Public Function consultar_todos() As list(of be.be_etiqueta)
			consultar_todos = Nothing
		End Function

		''' 
		''' <param name="etiqueta"></param>
		Public Function Leer(ByVal etiqueta As BE.BE_Etiqueta) As BE.BE_Etiqueta
			Leer = Nothing
		End Function


	End Class ' DAL_Etiqueta


