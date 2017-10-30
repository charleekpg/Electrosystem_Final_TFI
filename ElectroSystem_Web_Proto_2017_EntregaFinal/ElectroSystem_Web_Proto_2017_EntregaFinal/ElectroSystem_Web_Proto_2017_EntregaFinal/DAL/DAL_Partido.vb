


Imports System.Data.SqlClient


Public Class DAL_Partido
    Public Shared partidos As New List(Of BE.BE_Partido)

    Public Function cargar_partidos() As List(Of BE.BE_Partido)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim lista_parametros As New List(Of SqlParameter)
        Dim lista_partido As New List(Of BE.BE_Partido)
        Dim datatable As New DataTable
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Try
            datatable = mapper_stores.consultar("cargar_partidos", lista_parametros)
            For Each row As DataRow In datatable.Rows
                Dim tmppartido As New BE.BE_Partido
                tmppartido.id = row(0)
                tmppartido.partido = row(1)
                lista_partido.Add(tmppartido)
            Next
            lista_partido = Me.cargar_localidad(lista_partido)
            Return lista_partido
        Catch ex As Exception
            lista_partido.Clear()
            Return lista_partido
        End Try
    End Function

    Private Function cargar_localidad(unbe As List(Of BE.BE_Partido)) As List(Of BE.BE_Partido)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim lista_parametros As New List(Of SqlParameter)
        Dim datatable As New DataTable
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Dim lista_localidades As List(Of BE.be_localidad)

        Try
            For Each partidito As BE.BE_Partido In unbe
                Dim P(0) As SqlParameter
                lista_localidades = New List(Of BE.be_localidad)
                P(0) = sqlhelper.BuildParameter("@P1", partidito.id)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("cargar_localidades", lista_parametros)
                For Each row As DataRow In datatable.Rows
                    Dim tmp_localidad As New BE.be_localidad
                    tmp_localidad.id = row(0)
                    tmp_localidad.localidad = row(1)
                    tmp_localidad.longitud = row(2)
                    tmp_localidad.latitud = row(3)
                    lista_localidades.Add(tmp_localidad)
                Next
                lista_parametros.Clear()
                partidito.localidades = lista_localidades
            Next
            Return unbe
        Catch ex As Exception
            Return unbe

        End Try
    End Function

End Class ' DAL_Partido


