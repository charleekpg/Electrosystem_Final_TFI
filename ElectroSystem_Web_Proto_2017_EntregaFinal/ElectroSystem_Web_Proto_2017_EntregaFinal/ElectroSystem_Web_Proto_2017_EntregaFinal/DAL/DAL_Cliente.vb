Imports System.Data.SqlClient



Public Class DAL_Cliente


    Public Function validaridentificador(ByVal unbe As BE.BE_CLIENTE) As Integer
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim lista_parametros As New List(Of SqlParameter)
            Dim datatable As New DataTable
            Dim listapersona As New List(Of BE.BE_Personafisica)
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            If unbe.id = 0 Then
                Dim P(0) As SqlParameter
                P(0) = sqlhelper.BuildParameter("@P1", unbe.identificador)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("validaridentificador_conidentificador", lista_parametros)
            Else
                Dim P(1) As SqlParameter
                P(0) = sqlhelper.BuildParameter("@P1", unbe.identificador)
                P(1) = sqlhelper.BuildParameter("@P2", unbe.id)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("validaridentificador_conidentificadoryid", lista_parametros)
            End If
            If datatable.Rows.Count = 0 Then
                Return 1
            Else
                Return 10119
            End If
        Catch ex As Exception
            Return 10120
        End Try

    End Function

    Public Function consultar_telefonos_cliente(unbe As BE.BE_CLIENTE) As BE.BE_CLIENTE
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim lista_parametros As New List(Of SqlParameter)
            Dim datatable As New DataTable
            Dim listapersona As New List(Of BE.BE_Personafisica)
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@P1", unbe.id)
            lista_parametros.AddRange(P)
            datatable = mapper_stores.consultar("consultar_telefonos_cliente", lista_parametros)
            unbe.Telefonos = New List(Of BE.BE_Telefono)
            For Each row As DataRow In datatable.Rows
                Dim tmp_telefono As New BE.BE_Telefono
                tmp_telefono.id = row(0)
                tmp_telefono.numero_telefono = row(1)
                unbe.Telefonos.Add(tmp_telefono)
            Next
            Return unbe
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class


