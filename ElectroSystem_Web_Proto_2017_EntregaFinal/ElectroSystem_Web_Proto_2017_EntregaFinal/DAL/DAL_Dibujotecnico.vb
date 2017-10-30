





	Public Class DAL_Dibujotecnico


    Public m_SQLHelper As Seguridad.SQLHelper
    Public m_BE_DibujoTecnico As BE.BE_DibujoTecnico

		''' 
		''' <param name="UNBE"></param>
    Public Function Alta(ByVal UNBE As BE.Be_DibujoTecnico) As Boolean
        Alta = False
    End Function

		''' 
		''' <param name="UNBE"></param>
    Public Function Baja(ByVal UNBE As BE.Be_DibujoTecnico) As Boolean
        Baja = False
    End Function

		''' 
		''' <param name="UNBE"></param>
    Public Function Consulta(ByVal UNBE As BE.Be_DibujoTecnico) As Boolean
        Consulta = False
    End Function

    Public Function Consultartodos() As List(Of BE.be_dibujotecnico)
        Consultartodos = Nothing
    End Function

		''' 
		''' <param name="UNBE"></param>
    Public Function Modificacion(ByVal UNBE As BE.Be_DibujoTecnico) As Boolean
        Modificacion = False
    End Function


	End Class ' DAL_Dibujotecnico


