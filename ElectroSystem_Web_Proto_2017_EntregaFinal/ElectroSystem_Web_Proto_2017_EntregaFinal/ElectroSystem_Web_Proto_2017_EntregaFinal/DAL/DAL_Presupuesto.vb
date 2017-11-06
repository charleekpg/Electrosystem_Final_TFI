Imports System.Data.SqlClient

Public Class DAL_Presupuesto
    Function actualizacion_responsabletecnico(unbe As BE.BE_Presupuesto) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Dim lista_parametros As New List(Of SqlParameter)
        Dim stringconcatenado As String = ""
        Try
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@P1", unbe.id)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("baja_para_alta_artefactos_materiales_trabajos", lista_parametros)
            If Not unbe.Artefacto_electrico Is Nothing Then
                For Each ARTEFACTO As BE.BE_ArtefactoElectrico In unbe.Artefacto_electrico
                    Dim A(3) As SqlParameter
                    A(0) = sqlhelper.BuildParameter("@P2", unbe.id)
                    A(1) = sqlhelper.BuildParameter("@P1", ARTEFACTO.id)
                    A(2) = sqlhelper.BuildParameter("@P3", ARTEFACTO.precio)
                    A(3) = sqlhelper.BuildParameter("@P4", ARTEFACTO.cantidad)
                    lista_parametros.Clear()
                    lista_parametros.AddRange(A)
                    mapper_stores.insertar_eliminar_modificar("alta_artefacto_presupuesto", lista_parametros)
                Next
            End If
            If Not unbe.Materiales_trabajo Is Nothing Then
                For Each MAT_TRABAJO As BE.BE_Material_TrabajoconPrec In unbe.Materiales_trabajo
                    Dim A(3) As SqlParameter
                    A(0) = sqlhelper.BuildParameter("@P2", unbe.id)
                    A(1) = sqlhelper.BuildParameter("@P1", MAT_TRABAJO.id)
                    A(2) = sqlhelper.BuildParameter("@P3", MAT_TRABAJO.Precio)
                    A(3) = sqlhelper.BuildParameter("@P4", MAT_TRABAJO.cantidad)
                    lista_parametros.Clear()
                    lista_parametros.AddRange(A)
                    If MAT_TRABAJO.Material = True Then
                        mapper_stores.insertar_eliminar_modificar("alta_material_presupuesto", lista_parametros)
                    Else
                        mapper_stores.insertar_eliminar_modificar("alta_trabajo_presupuesto", lista_parametros)
                    End If
                Next
            End If
            ReDim P(13)
            P(0) = sqlhelper.BuildParameter("@P1", unbe.porcentaje_caneriaycableado)
            P(1) = sqlhelper.BuildParameter("@P2", unbe.Instalacion_compleja)
            P(2) = sqlhelper.BuildParameter("@P3", unbe.departamento_granescala)
            P(3) = sqlhelper.BuildParameter("@P4", unbe.porcentaje_losa)
            P(4) = sqlhelper.BuildParameter("@P5", unbe.porcentaje_tablero)
            P(5) = sqlhelper.BuildParameter("@P6", unbe.porcentaje_llaveytoma)
            P(6) = sqlhelper.BuildParameter("@P7", unbe.porcentaje_terminacion)
            P(7) = sqlhelper.BuildParameter("@P8", 0)
            P(8) = sqlhelper.BuildParameter("@P9", 0)
            P(9) = sqlhelper.BuildParameter("@P10", 0)
            P(10) = sqlhelper.BuildParameter("@P11", unbe.estado_presupuesto)
            P(11) = sqlhelper.BuildParameter("@P12", 0)
            P(12) = sqlhelper.BuildParameter("@P14", unbe.fecha_modificacion)
            P(13) = sqlhelper.BuildParameter("@P15", unbe.id)
            lista_parametros.Clear()
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("actualizar_presupuesto_resptecnico", lista_parametros)
            Return 10150
        Catch ex As Exception
            Return 10149
        End Try
    End Function

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

    Public Function consulta_artefactos_presupuesto(ByVal unbe As BE.BE_Presupuesto) As Integer
        Dim lista_artefactos As New List(Of BE.BE_ArtefactoElectrico)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim dal_artefacto As New DAL.DAL_ArtefactoElectrico
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@p1", unbe.id)
            lista_parametros.AddRange(P)
            datatable = mapper_stores.consultar("consulta_artefactos_presupuesto", lista_parametros)
            If datatable.Rows.Count > 0 Then
                For Each row As DataRow In datatable.Rows
                    Dim tmp_artefacto As New BE.BE_ArtefactoElectrico
                    tmp_artefacto.id = row(0)
                    tmp_artefacto.precio = row(2)
                    dal_artefacto.consultar(tmp_artefacto)
                    tmp_artefacto.cantidad = row(3)
                    lista_artefactos.Add(tmp_artefacto)
                Next
                unbe.Artefacto_electrico = lista_artefactos
            Else
                unbe.Artefacto_electrico = New List(Of BE.BE_ArtefactoElectrico)
            End If

            Return True
        Catch ex As Exception
            Return 10141
        End Try
    End Function

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
    Public Function consulta_material_presupuesto(ByVal unbe As BE.BE_Presupuesto) As Integer
        Dim lista_material As New List(Of BE.BE_Material_TrabajoconPrec)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim dal_material As New DAL.DAL_Material_TrabajoconPrec
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@p1", unbe.id)
            lista_parametros.AddRange(P)
            datatable = mapper_stores.consultar("consulta_material_presupuesto", lista_parametros)
            If datatable.Rows.Count > 0 Then
                For Each row As DataRow In datatable.Rows
                    Dim tmp_material As New BE.BE_Material_TrabajoconPrec
                    tmp_material.id = row(0)
                    tmp_material.Trabajoconprecio = False
                    tmp_material.Material = True
                    tmp_material.Precio = row(2)
                    dal_material.consultar(tmp_material)
                    tmp_material.cantidad = row(3)
                    lista_material.Add(tmp_material)
                Next
                If unbe.Materiales_trabajo Is Nothing Then
                    unbe.Materiales_trabajo = lista_material
                Else
                    For Each material As BE.BE_Material_TrabajoconPrec In lista_material
                        unbe.Materiales_trabajo.Add(material)
                    Next
                End If
            Else
                unbe.Materiales_trabajo = New List(Of BE.BE_Material_TrabajoconPrec)
            End If
            Return True
        Catch ex As Exception
            Return 10142
        End Try
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consulta_presupuesto(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        consulta_presupuesto = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consulta_trabajo_presupuesto(ByVal unbe As BE.BE_Presupuesto) As Integer
        Dim lista_trabajo As New List(Of BE.BE_Material_TrabajoconPrec)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim dal_trabajo As New DAL.DAL_Material_TrabajoconPrec
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@p1", unbe.id)
            lista_parametros.AddRange(P)
            datatable = mapper_stores.consultar("consulta_trabajo_presupuesto", lista_parametros)
            If datatable.Rows.Count > 0 Then
                For Each row As DataRow In datatable.Rows
                    Dim tmp_trabajo As New BE.BE_Material_TrabajoconPrec
                    tmp_trabajo.id = row(0)
                    tmp_trabajo.Precio = row(2)
                    tmp_trabajo.Trabajoconprecio = True
                    tmp_trabajo.Material = False

                    dal_trabajo.consultar(tmp_trabajo)
                    tmp_trabajo.cantidad = row(3)
                    lista_trabajo.Add(tmp_trabajo)
                Next
                If unbe.Materiales_trabajo Is Nothing Then
                    unbe.Materiales_trabajo = lista_trabajo
                Else
                    For Each trabajo As BE.BE_Material_TrabajoconPrec In lista_trabajo
                        unbe.Materiales_trabajo.Add(trabajo)
                    Next
                End If
            Else
                unbe.Materiales_trabajo = New List(Of BE.BE_Material_TrabajoconPrec)
            End If
            Return True
        Catch ex As Exception
            Return 10143
        End Try

    End Function

    ''' 
    'esta función va a tener otro objetivo, en base a la selección del usuario..

    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
        Return unbe
    End Function
    'esta función no va a estar!! ya que se va a consultar en base la selección del usuario.

    Function consultar_ultimo_comercial(ByVal unbe As BE.BE_Presupuesto) As BE.BE_Presupuesto
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
            Select Case seguridad.descifrar(unbe.estado_presupuesto)
                Case "Pendiente de llenado por Parte del Responsable Técnico"
                    datatable = mapper_stores.consultar("consultar_presupuestos_estado_tecnico", lista_parametros)
                Case "Pendiente de llenado por parte del Responsable Comercial"
                    datatable = mapper_stores.consultar("consultar_presupuestos_estado_comercial", lista_parametros)
            End Select
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
                    If seguridad.descifrar(unbe.estado_presupuesto) = "Pendiente de llenado por parte del Responsable Comercial" Then
                        tmppresupuesto.porcentaje_caneriaycableado = fila(19)
                        tmppresupuesto.porcentaje_llaveytoma = fila(20)
                        tmppresupuesto.porcentaje_losa = fila(21)
                        tmppresupuesto.porcentaje_tablero = fila(22)
                        tmppresupuesto.porcentaje_terminacion = fila(23)
                        tmppresupuesto.departamento_granescala = fila(24)
                        tmppresupuesto.Instalacion_compleja = fila(25)
                    End If
                    


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

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function guardar_estado_cliente(ByVal unbe As BE.BE_Presupuesto) As Integer
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


