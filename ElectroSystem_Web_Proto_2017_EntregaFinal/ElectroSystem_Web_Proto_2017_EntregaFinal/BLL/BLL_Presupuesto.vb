
	Public Class BLL_Presupuesto


    Public m_BE_Bitacora As BE.BE_Bitacora
		Public m_BLL_Bitacora As BLL.BLL_Bitacora
		Public m_Criptografia As Seguridad.Criptografia
		Public m_DAL_Presupuesto As DAL.DAL_Presupuesto
    Public m_BE_Presupuesto As BE.BE_Presupuesto

		''' 
		''' <param name="unbe"></param>
		Public Function actualizacion_responsabletecnico(ByVal unbe As BE.BE_Presupuesto) As Integer
			actualizacion_responsabletecnico = 0
		End Function

		''' 
		''' <param name="unbe"></param>
		Private Function administrar_estado(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
			administrar_estado = Nothing
		End Function

		''' 
		''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Presupuesto) As Boolean
        alta = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Presupuesto) As Boolean
        baja = False
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function calcular_precio_trabmat(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
			calcular_precio_trabmat = Nothing
		End Function

		''' 
		''' <param name="artefactos"></param>
		''' <param name="boca"></param>
    Private Function calcular_precios_artefactos(ByVal artefactos As List(Of BE.BE_ArtefactoElectrico), ByVal boca As BE.BE_BocaMercado) As Decimal
        calcular_precios_artefactos = 0
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Sub calcularvalores(ByVal unbe As BE.BE_Presupuesto)

		End Sub

		''' 
		''' <param name="unbe"></param>
		Public Function calculo_trabajo_tareas(ByVal unbe As BE.BE_Presupuesto) As Integer
			calculo_trabajo_tareas = 0
		End Function

		''' 
		''' <param name="unbe"></param>
		Public Sub calculo_valordinamico(ByVal unbe As BE.BE_Presupuesto)

		End Sub

		''' 
		''' <param name="artefactos"></param>
    Private Function cantidad_bocas(ByVal artefactos As List(Of BE.BE_ArtefactoElectrico)) As Integer
        cantidad_bocas = 0
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function consulta_dom_plano(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
			consulta_dom_plano = Nothing
		End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        consultar = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function consultar_trabajo(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
			consultar_trabajo = Nothing
		End Function

		''' 
		''' <param name="unbe"></param>
		Public Function consultar_valortotal(ByVal unbe As BE.BE_Presupuesto) As Integer
			consultar_valortotal = 0
		End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar_varios(ByVal unbe As BE.BE_Presupuesto) As List(Of BE.BE_Presupuesto)
        consultar_varios = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_Presupuesto)
        consultartodos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function envio_presupuesto_mail(ByVal unbe As BE.BE_Presupuesto) As Boolean
			envio_presupuesto_mail = False
		End Function

		''' 
		''' <param name="unbe"></param>
		Public Function generar_solicitudpresupuesto(ByVal unbe As BE.BE_Presupuesto) As Boolean
			generar_solicitudpresupuesto = False
		End Function

		''' 
		''' <param name="unbe"></param>
		Public Function guardar_estado_cliente(ByVal unbe As BE.BE_Presupuesto) As Integer
			guardar_estado_cliente = 0
		End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Presupuesto) As Boolean
        modificar = False
    End Function


	End Class ' BLL_Presupuesto


