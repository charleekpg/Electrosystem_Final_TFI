Imports System.Data.SqlClient

Public Class DAL_ArtefactoElectrico
    Shared artefactos As New List(Of BE.BE_ArtefactoElectrico)

    Public m_BE_ArtefactoElectrico As BE.BE_ArtefactoElectrico
    Public m_SQLHelper As Seguridad.SQLHelper


    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_ArtefactoElectrico) As Boolean
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(1) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@P1", unbe.descripcion)
            P(1) = sqlhelper.BuildParameter("@P2", unbe.relacion_bocamercado)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("alta_artefacto_electrico", lista_parametros)
            Return 10105
        Catch ex As Exception
            Return 10106
        End Try



    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_ArtefactoElectrico) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_ArtefactoElectrico) As BE.BE_ArtefactoElectrico
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_ArtefactoElectrico)

        Try

            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim listaartefactos As New List(Of BE.BE_ArtefactoElectrico)
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            datatable = mapper_stores.consultar("consultartodos_artefactos", lista_parametros)
            For Each elemento As DataRow In datatable.Rows
                Dim tmpartefacto As New BE.BE_ArtefactoElectrico
                tmpartefacto.id = elemento(0)
                tmpartefacto.descripcion = elemento(1)
                tmpartefacto.relacion_bocamercado = elemento(2)
                listaartefactos.Add(tmpartefacto)
            Next

            Return listaartefactos
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_ArtefactoElectrico) As Boolean
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(2) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@P1", unbe.descripcion)
            P(1) = sqlhelper.BuildParameter("@P2", unbe.relacion_bocamercado)
            P(2) = sqlhelper.BuildParameter("@P3", unbe.id)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("modificar_artefacto_electrico", lista_parametros)
            Return 10108
        Catch ex As Exception
            Return 10106
        End Try

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function validardescripcion(ByVal unbe As BE.BE_ArtefactoElectrico) As Integer
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim datatable As New DataTable
            Dim lista_parametros As New List(Of SqlParameter)
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            If unbe.id > 0 Then
                Dim P(1) As SqlParameter
                P(0) = sqlhelper.BuildParameter("@P1", unbe.descripcion)
                P(1) = sqlhelper.BuildParameter("@P2", unbe.id)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("validarartefacto_conidentificador", lista_parametros)
                If datatable.Rows.Count = 0 Then
                    Return 1
                Else
                    Return 10107
                End If
            Else

                Dim P(0) As SqlParameter
                P(0) = sqlhelper.BuildParameter("@P1", unbe.descripcion)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("validarartefacto_sinidentificador", lista_parametros)
                If datatable.Rows.Count = 0 Then

                    Return 1
                Else
                    Return 10107
                End If
            End If
        Catch ex As Exception
            Return 10106
        End Try

    End Function


End Class

