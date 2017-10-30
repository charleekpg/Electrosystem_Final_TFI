





Imports System.Data.SqlClient

Public Class DAL_Presupuesto
    Shared presupuestos As New List(Of BE.BE_Presupuesto)
    Shared presupuesto_responsabletecnico As New List(Of BE.BE_Presupuesto)
    Shared presupuestoterminado As New List(Of BE.BE_Presupuesto)
    Public m_SQLHelper As SEGURIDAD.SQLHelper
    Public m_Criptografia As Seguridad.Criptografia
    Public m_BE_Presupuesto As BE.BE_Presupuesto

    ''' 
    ''' <param name="unbe"></param>
    Public Function actualizacion_responsabletecnico(ByVal unbe As BE.BE_Presupuesto) As Integer
        presupuesto_responsabletecnico.Add(unbe)
        Return 1
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Presupuesto) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim dal_domicilio As New DAL.DAL_Domicilio
        Try
            Select Case dal_domicilio.alta(unbe.Domicilio)
                Case 5001
                    Return 5001
                Case Else
                    Dim mapper_stores As New SEGURIDAD.Mapper_Stored
                    Dim lista_parametros As New List(Of SqlParameter)
                    Dim alta_presupuesto As New SqlCommand
                    Dim stringconcatenado As String = ""
                    If unbe.dibujotecnico Is Nothing Then
                        Dim P(3) As SqlParameter
                        P(0) = sqlhelper.BuildParameter("@P1", unbe.Domicilio.id)
                        P(1) = sqlhelper.BuildParameter("@P2", unbe.Cliente_Persona.id)
                        P(2) = sqlhelper.BuildParameter("@P5", unbe.estado_presupuesto)
                        P(3) = sqlhelper.BuildParameter("@P6", unbe.fecha_alta)
                        lista_parametros.AddRange(P)
                        mapper_stores.insertar_eliminar_modificar("alta_presupuesto_inicial_sindibujo", lista_parametros)
                    Else
                        Dim P(4) As SqlParameter
                        P(0) = sqlhelper.BuildParameter("@P1", unbe.Domicilio.id)
                        P(1) = sqlhelper.BuildParameter("@P2", unbe.Cliente_Persona.id)
                        P(2) = sqlhelper.BuildParameter("@P5", unbe.estado_presupuesto)
                        P(3) = sqlhelper.BuildParameter("@P6", unbe.fecha_alta)
                        P(4) = sqlhelper.BuildParameter("@P3", unbe.dibujotecnico.id)
                        lista_parametros.AddRange(P)
                        mapper_stores.insertar_eliminar_modificar("alta_presupuesto_inicial_condibujo", lista_parametros)
                    End If
                    Dim datatable As New DataTable
                    lista_parametros.Clear()
                    datatable = mapper_stores.consultar("consultar_ultimopresupuesto", lista_parametros)
                    For Each elemento As DataRow In datatable.Rows
                        unbe.id = elemento(0)
                    Next
                    Return 5002
            End Select
        Catch ex As Exception
            Return 5003
        End Try
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
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@idpresupuesto", unbe.id)
            lista_parametros.AddRange(P)
            datatable = mapper_stores.consultar("consulta_dom_plano", lista_parametros)
            For Each row As DataRow In datatable.Rows
                Dim tmp_dibujo As New BE.BE_DibujoTecnico
                tmp_dibujo.id = row(0)
                tmp_dibujo.fecha = row(1)
                tmp_dibujo.grado_electrificacion = row(2)
                tmp_dibujo.cumple_ambientes = row(3)
                tmp_dibujo.cumple_cantidadbocas = row(4)
                tmp_dibujo.cumple_cantidadcircuito = row(5)
                tmp_dibujo.cumple_puntosminimos = row(6)
                tmp_dibujo.descripcion = row(7)
                unbe.dibujotecnico = tmp_dibujo
            Next
        Catch ex As Exception
            Return Nothing
        End Try

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
    'esta función va a tener otro objetivo, en base a la selección del usuario..

    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        unbe = presupuestos.Item(presupuestos.Count - 1)
        Return unbe
    End Function
    'esta función no va a estar!! ya que se va a consultar en base la selección del usuario.

    Function consultar_ultimo_comercial(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        unbe = presupuesto_responsabletecnico.Item(presupuesto_responsabletecnico.Count - 1)
        Return unbe
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
        Dim lista_presupuestos As New List(Of BE.BE_Presupuesto)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim seguridad As New SEGURIDAD.Criptografia

        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@estado_presupuesto", unbe.estado_presupuesto)
            lista_parametros.AddRange(P)
            If SEGURIDAD.descifrar(unbe.estado_presupuesto) = "Pendiente de llenado por Parte del Responsable Técnico" Then
                datatable = mapper_stores.consultar("consultar_presupuestos_estado_tecnico", lista_parametros)
            End If
            For Each fila As DataRow In datatable.Rows
                Dim tmppresupuesto As New BE.BE_Presupuesto
                Dim tmpcliente As BE.BE_CLIENTE
                tmppresupuesto.id = fila(0)
                tmppresupuesto.fecha_alta = fila(1)
                If IsDBNull(fila(7)) Then
                    tmppresupuesto.fecha_modificacion = Date.MinValue
                Else
                    tmppresupuesto.fecha_modificacion = fila(7)
                End If
                tmppresupuesto.estado_presupuesto = fila(8)
                If IsDBNull(fila(2)) Then
                    tmppresupuesto.Cliente_Persona = Nothing
                Else
                    If Len(Trim(Str(fila(2)))) = 11 Then
                        tmpcliente = New BE.BE_Personajuridica
                        tmpcliente.identificador = fila(2)
                        tmpcliente.id = fila(3)
                        CType(tmpcliente, BE.BE_Personajuridica).Razonsocial = fila(4)
                        tmppresupuesto.Cliente_Persona = tmpcliente
                    Else
                        tmpcliente = New BE.BE_Personafisica
                        tmpcliente.identificador = fila(2)
                        tmpcliente.id = fila(3)
                        CType(tmpcliente, BE.BE_Personafisica).Nombre = fila(5)
                        CType(tmpcliente, BE.BE_Personafisica).Apellido = fila(6)
                        tmppresupuesto.Cliente_Persona = tmpcliente
                    End If

                    Dim tmp_domicilio As New BE.BE_Domicilio
                    tmp_domicilio.id = fila(9)
                    tmp_domicilio.calle = fila(10)
                    tmp_domicilio.altura = fila(11)
                    If IsDBNull(fila(7)) Then

                    End If
                    If String.IsNullOrWhiteSpace(fila(12)) = True Then
                        tmp_domicilio.departamento = ""
                    Else
                        tmp_domicilio.departamento = fila(12)
                    End If
                    If IsDBNull(fila(13)) = True Then

                    Else
                        tmp_domicilio.piso = fila(13)
                    End If
                    tmp_domicilio.country = fila(14)
                    tmp_domicilio.localidad = New BE.be_localidad
                    tmp_domicilio.localidad.id = fila(15)
                    tmp_domicilio.localidad.localidad = fila(16)
                    tmp_domicilio.partido = New BE.BE_Partido
                    tmp_domicilio.partido.id = fila(17)
                    tmp_domicilio.partido.partido = fila(18)
                    tmppresupuesto.Domicilio = tmp_domicilio
                End If
                lista_presupuestos.Add(tmppresupuesto)
            Next
            Return lista_presupuestos
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function consultartodos() As List(Of BE.BE_Presupuesto)
        consultartodos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function generar_solicitudpresupuesto(ByVal unbe As BE.BE_Presupuesto) As Integer
        If unbe.estado_presupuesto = "Pendiente de llenado por Parte del Responsable Técnico" Then
            If presupuestos.Count > 0 Then
                unbe.id = presupuestos.Count + 1
                presupuestos.Add(unbe)
                Return unbe.id
            Else
                unbe.id = 0
                presupuestos.Add(unbe)
                Return unbe.id
            End If
        End If
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function guardar_estado_cliente(ByVal unbe As BE.BE_Presupuesto) As Integer
        presupuestoterminado.Add(unbe)
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Presupuesto) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim dal_domicilio As New DAL.DAL_Domicilio
        Try
            Select Case dal_domicilio.modificar(unbe.Domicilio)
                Case 5004
                    Return 5004
                Case Else
                    Dim mapper_stores As New SEGURIDAD.Mapper_Stored
                    Dim lista_parametros As New List(Of SqlParameter)
                    Dim modificar_presupuesto As New SqlCommand
                    If unbe.dibujotecnico Is Nothing Then
                        Dim P(4) As SqlParameter
                        P(0) = sqlhelper.BuildParameter("@P1", unbe.Domicilio.id)
                        P(1) = sqlhelper.BuildParameter("@P2", unbe.Cliente_Persona.id)
                        P(2) = sqlhelper.BuildParameter("@P5", unbe.estado_presupuesto)
                        P(3) = sqlhelper.BuildParameter("@P6", unbe.fecha_modificacion)
                        P(4) = sqlhelper.BuildParameter("@P7", unbe.id)
                        lista_parametros.AddRange(P)
                        mapper_stores.insertar_eliminar_modificar("modificar_presupuesto_inicial_sindibujo", lista_parametros)
                    Else
                        Dim P(5) As SqlParameter
                        P(0) = sqlhelper.BuildParameter("@P1", unbe.Domicilio.id)
                        P(1) = sqlhelper.BuildParameter("@P2", unbe.Cliente_Persona.id)
                        P(2) = sqlhelper.BuildParameter("@P5", unbe.estado_presupuesto)
                        P(3) = sqlhelper.BuildParameter("@P6", unbe.fecha_alta)
                        P(4) = sqlhelper.BuildParameter("@P3", unbe.dibujotecnico.id)
                        P(5) = sqlhelper.BuildParameter("@P7", unbe.id)
                        lista_parametros.AddRange(P)
                        mapper_stores.insertar_eliminar_modificar("modificar_presupuesto_inicial_condibujo", lista_parametros)
                    End If
                    lista_parametros.Clear()
                    Return 5005
            End Select
        Catch ex As Exception
            Return 5006
        End Try
    End Function


	End Class ' DAL_Presupuesto


