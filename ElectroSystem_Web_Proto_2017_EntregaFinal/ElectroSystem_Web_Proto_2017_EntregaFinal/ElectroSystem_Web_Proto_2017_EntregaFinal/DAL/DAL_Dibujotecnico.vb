



Imports System.Data.SqlClient


Public Class DAL_Dibujotecnico
    Shared dibujos As New List(Of BE.BE_DibujoTecnico)

    Public m_SQLHelper As Seguridad.SQLHelper
    Public m_BE_DibujoTecnico As BE.BE_DibujoTecnico

    ''' 
    ''' <param name="UNBE"></param>
    Public Function Alta(ByVal UNBE As BE.BE_DibujoTecnico) As Integer
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(6) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@P1", UNBE.grado_electrificacion)
            P(1) = sqlhelper.BuildParameter("@P2", UNBE.cumple_ambientes)
            P(2) = sqlhelper.BuildParameter("@P3", UNBE.cumple_cantidadbocas)
            P(3) = sqlhelper.BuildParameter("@P4", UNBE.cumple_cantidadcircuito)
            P(4) = sqlhelper.BuildParameter("@P5", UNBE.cumple_puntosminimos)
            P(5) = sqlhelper.BuildParameter("@P6", UNBE.descripcion)
            P(6) = sqlhelper.BuildParameter("@P7", UNBE.fecha)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("alta_dibujotecnico", lista_parametros)
            For Each ambiente As BE.Be_Ambiente In UNBE.ambiente
                lista_parametros.Clear()
                ReDim P(2)
                P(0) = sqlhelper.BuildParameter("@P1", ambiente.tipo)
                P(1) = sqlhelper.BuildParameter("@P2", ambiente.m2)
                P(2) = sqlhelper.BuildParameter("@P3", ambiente.cantidad_puntoselectricos)
                lista_parametros.AddRange(P)
                mapper_stores.insertar_eliminar_modificar("alta_ambiente", lista_parametros)
                For Each circuito As BE.BE_Circuito In ambiente.circuitos
                    lista_parametros.Clear()
                    ReDim P(5)
                    P(0) = sqlhelper.BuildParameter("@P1", circuito.cantidad_bocas)
                    P(1) = sqlhelper.BuildParameter("@P2", circuito.circuito_correcto_segun_ambiente)
                    P(2) = sqlhelper.BuildParameter("@P3", circuito.descripcion)
                    P(3) = sqlhelper.BuildParameter("@P4", circuito.tipo)
                    P(4) = sqlhelper.BuildParameter("@P5", circuito.sigla)
                    P(5) = sqlhelper.BuildParameter("@P6", circuito.cumple_cantidad_bocas_circuito)
                    lista_parametros.AddRange(P)
                    mapper_stores.insertar_eliminar_modificar("alta_circuito", lista_parametros)
                Next
            Next

            Dim datatable As New DataTable
            Dim id As Integer = 0
            lista_parametros.Clear()
            datatable = mapper_stores.consultar("consultar_id_dibujo", lista_parametros)
            For Each row As DataRow In datatable.Rows
                UNBE.id = row(0)
                id = row(0)
            Next
            Return id
        Catch ex As Exception
            Return 0
        End Try


    End Function

    ''' 
    ''' <param name="UNBE"></param>
    Public Function Baja(ByVal UNBE As BE.Be_DibujoTecnico) As Boolean
        Baja = False
    End Function

    ''' 
    ''' <param name="UNBE"></param>
    Public Function Consulta(ByVal UNBE As BE.BE_DibujoTecnico) As BE.BE_DibujoTecnico
        Dim pepe As BE.BE_DibujoTecnico
        pepe = dibujos.Item(dibujos.Count - 1)
        Return pepe
    End Function

    Public Function Consulta_ambientes_circuitos(unbe As BE.BE_DibujoTecnico) As Integer
        Dim lista_ambientes As New List(Of BE.Be_Ambiente)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            unbe.ambiente = New List(Of BE.Be_Ambiente)
            Dim datatable As New DataTable
            Dim datatable2 As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim p(0) As SqlParameter
            p(0) = sqlhelper.BuildParameter("@p1", unbe.id)
            lista_parametros.AddRange(p)
            datatable = mapper_stores.consultar("consultar_todosambientes", lista_parametros)
            For Each ambiente As DataRow In datatable.Rows
                Dim tmp_ambiente As New BE.Be_Ambiente
                tmp_ambiente.id = ambiente(0)
                tmp_ambiente.tipo = ambiente(1)
                tmp_ambiente.m2 = ambiente(2)
                tmp_ambiente.cantidad_puntoselectricos = ambiente(3)
                tmp_ambiente.circuitos = New List(Of BE.BE_Circuito)
                Dim a(0) As SqlParameter
                a(0) = sqlhelper.BuildParameter("@p1", tmp_ambiente.id)
                lista_parametros.Clear()
                lista_parametros.AddRange(a)
                datatable2 = mapper_stores.consultar("consultar_todoscircuitos", lista_parametros)
                For Each circuito As DataRow In datatable2.Rows
                    Dim tmp_circuito As New BE.BE_Circuito
                    tmp_circuito.id = circuito(0)
                    tmp_circuito.cantidad_bocas = circuito(1)
                    tmp_circuito.circuito_correcto_segun_ambiente = circuito(2)
                    tmp_circuito.descripcion = circuito(3)
                    tmp_circuito.tipo = circuito(4)
                    tmp_circuito.sigla = circuito(5)
                    tmp_circuito.cumple_cantidad_bocas_circuito = circuito(6)
                    tmp_ambiente.circuitos.Add(tmp_circuito)
                Next
                unbe.ambiente.Add(tmp_ambiente)
            Next
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function Consultartodos() As List(Of BE.be_dibujotecnico)
        Dim listadedibujos As New List(Of BE.BE_DibujoTecnico)
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            datatable = mapper_stores.consultar("consultar_todosdibujos", lista_parametros)
            For Each dibujo As DataRow In datatable.Rows
                Dim tmp_dibujo As New BE.BE_DibujoTecnico
                tmp_dibujo.id = dibujo(0)
                tmp_dibujo.fecha = dibujo(1)
                tmp_dibujo.grado_electrificacion = dibujo(2)
                tmp_dibujo.cumple_ambientes = dibujo(3)
                tmp_dibujo.cumple_cantidadbocas = dibujo(4)
                tmp_dibujo.cumple_cantidadcircuito = dibujo(5)
                tmp_dibujo.cumple_puntosminimos = dibujo(6)
                tmp_dibujo.descripcion = dibujo(7)
                listadedibujos.Add(tmp_dibujo)
            Next
            Return listadedibujos
        Catch ex As Exception
            Return listadedibujos
        End Try
    End Function

		''' 
		''' <param name="UNBE"></param>
    Public Function Modificacion(ByVal UNBE As BE.Be_DibujoTecnico) As Boolean
        Modificacion = False
    End Function


	End Class ' DAL_Dibujotecnico


