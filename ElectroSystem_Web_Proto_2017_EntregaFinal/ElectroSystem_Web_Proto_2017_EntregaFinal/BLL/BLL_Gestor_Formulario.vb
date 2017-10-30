

	Public Class BLL_Gestor_Formulario


		Public m_BLL_Permisos As BLL.BLL_Permisos
    Public m_BE_Etiqueta As BE.BE_Etiqueta
		Public m_DAL_Etiqueta As DAL.DAL_Etiqueta
		Public m_BLL_Etiqueta As BLL.BLL_Etiqueta

		''' 
		''' <param name="form1"></param>
    'Public Sub Deshabilitar_Controles(ByVal form1 As Form)

    'End Sub

		''' 
		''' <param name="mensaje"></param>
		Public Function DIGITOS_VERIFICADORES(ByVal mensaje As String) As Boolean
			DIGITOS_VERIFICADORES = False
		End Function

		''' 
		''' <param name="form1"></param>
		''' <param name="unbe"></param>
    'Public Sub traducir(ByVal form1 As Form, ByVal unbe As BE_Idioma)

    'End Sub

		''' 
		''' <param name="mensaje"></param>
		Public Function traducir_msgbox(ByVal mensaje As String) As String
			traducir_msgbox = ""
		End Function

		''' 
		''' <param name="form1"></param>
    'Public Sub traducirformprincipal(ByVal form1 As Form)

    'End Sub


	End Class ' BLL_Gestor_Formulario


