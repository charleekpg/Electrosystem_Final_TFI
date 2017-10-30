







	Public Class DAL_Presupuesto


    Public m_SQLHelper As Seguridad.SQLHelper
    Public m_Criptografia As Seguridad.Criptografia
    Public m_BE_Presupuesto As BE.BE_Presupuesto

    ''' 
    ''' <param name="unbe"></param>
    Public Function actualizacion_responsabletecnico(ByVal unbe As BE.BE_Presupuesto) As Integer
        actualizacion_responsabletecnico = 0
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
    Private Function consulta_artefactos_presupuesto(ByVal unbe As BE.BE_Presupuesto) As Integer
        consulta_artefactos_presupuesto = 0
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consulta_dom_plano(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        consulta_dom_plano = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Function consulta_material_presupuesto(ByVal unbe As BE.BE_Presupuesto) As Integer
        consulta_material_presupuesto = 0
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consulta_presupuesto(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        consulta_presupuesto = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Function consulta_trabajo_presupuesto(ByVal unbe As BE.BE_Presupuesto) As Integer
        consulta_trabajo_presupuesto = 0
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Presupuesto) As Boolean
        consultar = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar_trabajo(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Material_TrabajoconPrec
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


	End Class ' DAL_Presupuesto


