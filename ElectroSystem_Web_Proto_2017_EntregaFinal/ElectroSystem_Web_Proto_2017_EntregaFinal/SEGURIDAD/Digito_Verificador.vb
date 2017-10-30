

	Public Class Digito_Verificador


    Public m_MD5CryptoServiceProvider As Seguridad.MD5CryptoServiceProvider
    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_SQLHelper As Seguridad.SQLHelper

		''' 
		''' <param name="tabla"></param>
		Public Shared Function buscarfilaconerror(ByVal tabla As String) As Integer
			buscarfilaconerror = 0
		End Function

		''' 
		''' <param name="algo"></param>
		Public Shared Function calculardigitoverificador(ByVal algo As String) As Integer
			calculardigitoverificador = 0
		End Function

		''' 
		''' <param name="tabla"></param>
		Public Shared Function calculardigitoverificadorvertical(ByVal tabla As String) As Integer
			calculardigitoverificadorvertical = 0
		End Function

		''' 
		''' <param name="tabla"></param>
		Public Shared Function comparardigitoverificadorvertical(ByVal tabla As String) As Boolean
			comparardigitoverificadorvertical = False
		End Function

		''' 
		''' <param name="tabla"></param>
		Public Shared Function recalcular_digitos(ByVal tabla As String) As Integer
			recalcular_digitos = 0
		End Function


	End Class ' Digito_Verificador


