

Imports System.Data.SqlClient


Public Class DAL_PersonaFisica


    Public m_SQLHelper As Seguridad.SQLHelper

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Personafisica) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim alta_usuario As New SqlCommand
            Dim P(4) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@P2", unbe.Nombre)
            P(1) = sqlhelper.BuildParameter("@P3", unbe.Apellido)
            P(2) = sqlhelper.BuildParameter("@P4", unbe.Correoelectronico)
            P(3) = sqlhelper.BuildParameter("@P5", unbe.TratamientoEspecial)
            P(4) = sqlhelper.BuildParameter("@P6", unbe.identificador)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("alta_personafisica", lista_parametros)
            Dim telefono As New DAL.DAL_Telefono
            If telefono.alta_telefono(CType(unbe, BE.BE_CLIENTE)) = True Then
                Return 10123
            Else
                Return 10125
            End If
        Catch ex As Exception
            Return 10120
        End Try
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Personafisica) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Personafisica) As List(Of BE.BE_Personafisica)
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim lista_parametros As New List(Of SqlParameter)
            Dim datatable As New DataTable
            Dim listapersona As New List(Of BE.BE_Personafisica)
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim P(0) As SqlParameter
            If unbe.id = 0 Then
                P(0) = sqlhelper.BuildParameter("@p1", unbe.identificador)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("consulta_personafisica_identificador", lista_parametros)
            Else
                P(0) = sqlhelper.BuildParameter("@p1", unbe.id)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("consulta_personafisica_id", lista_parametros)
            End If
            For Each datarow As DataRow In datatable.Rows
                Dim tmp_personafisica As New BE.BE_Personafisica
                tmp_personafisica.id = datarow.Item(0)
                tmp_personafisica.Correoelectronico = datarow.Item(1)
                tmp_personafisica.TratamientoEspecial = datarow.Item(2)
                tmp_personafisica.identificador = datarow.Item(3)
                tmp_personafisica.Nombre = datarow.Item(4)
                tmp_personafisica.Apellido = datarow.Item(5)
                listapersona.Add(tmp_personafisica)
            Next
            Return listapersona
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar_contacto(ByVal unbe As BE.BE_Personafisica) As BE.BE_Personafisica
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim lista_parametros As New List(Of SqlParameter)
            Dim datatable As New DataTable
            Dim listapersona As New List(Of BE.BE_Personafisica)
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@p1", unbe.id)
            lista_parametros.AddRange(P)
            datatable = mapper_stores.consultar("consultar_contacto", lista_parametros)
            For Each datarow As DataRow In datatable.Rows
                unbe.id = datarow.Item(0)
                unbe.Nombre = datarow.Item(1)
                unbe.Apellido = datarow.Item(2)
            Next
            Return unbe
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function consultartodos() As List(Of BE.BE_Personafisica)
        consultartodos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Personafisica) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim alta_usuario As New SqlCommand
            Dim P(5) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@P2", unbe.Nombre)
            P(1) = sqlhelper.BuildParameter("@P3", unbe.Apellido)
            P(2) = sqlhelper.BuildParameter("@P4", unbe.Correoelectronico)
            P(3) = sqlhelper.BuildParameter("@P5", unbe.TratamientoEspecial)
            P(4) = sqlhelper.BuildParameter("@P6", unbe.identificador)
            P(5) = sqlhelper.BuildParameter("@P7", unbe.id)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("actualizar_personafisica", lista_parametros)
            Dim telefono As New DAL.DAL_Telefono
            If telefono.alta_telefono(CType(unbe, BE.BE_CLIENTE)) = True Then
                Return 10135
            Else
                Return 10125
            End If
        Catch ex As Exception
            Return 10134
        End Try
    End Function


End Class ' DAL_PersonaFisica


