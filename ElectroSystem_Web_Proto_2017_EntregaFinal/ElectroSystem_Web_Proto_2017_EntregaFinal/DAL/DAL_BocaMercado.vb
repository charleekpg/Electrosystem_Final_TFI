







	Public Class DAL_BocaMercado


    Public m_BE_BocaMercado As BE.BE_BocaMercado
    Public m_SQLHelper As Seguridad.SQLHelper
    Public m_Digito_Verificador As Seguridad.Digito_Verificador

		''' 
		''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_BocaMercado) As Boolean
        alta = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_BocaMercado) As Boolean
        baja = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_BocaMercado) As Boolean
        consultar = False
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function consultar_bocaempresa(ByVal unbe As BE.BE_BocaMercado) As BE.BE_BocaMercado
			consultar_bocaempresa = Nothing
		End Function

		''' 
		''' <param name="unbe"></param>
		Public Function consultar_bocaextraordinaria(ByVal unbe As BE.BE_BocaMercado) As BE.BE_BocaMercado
			consultar_bocaextraordinaria = Nothing
		End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar_bocamercado(ByVal unbe As BE.BE_BocaMercado) As BE.BE_BocaMercado
        consultar_bocamercado = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar_Porcentaje_BocaEmpresa(ByVal unbe As BE.BE_BocaMercado) As Decimal
        consultar_Porcentaje_BocaEmpresa = 0
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function consultar_Porcentaje_BocaExtraordinaria(ByVal unbe As BE.BE_BocaMercado) As Decimal
			consultar_Porcentaje_BocaExtraordinaria = 0
		End Function

    Public Function consultartodos() As List(Of BE.BE_BocaMercado)
        consultartodos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function definir_boca(ByVal unbe As List(Of BE.BE_BocaMercado)) As Boolean
        definir_boca = False
    End Function


	End Class ' DAL_BocaMercado


