



Imports System.Data.SqlClient



Public Class DAL_BocaMercado




    Public Function modificar(unbe As BE.BE_BocaMercado) As Boolean
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim stringconcatenado As String = ""
        Try
            Dim DDVVH As Integer
            stringconcatenado = unbe.precio_bocamercado
            DDVVH = SEGURIDAD.Digito_Verificador.calculardigitoverificador(stringconcatenado)
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(1) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@P1", unbe.precio_bocamercado)
            P(1) = sqlhelper.BuildParameter("@P2", DDVVH)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("alta_bocamercado", lista_parametros)
            SEGURIDAD.Digito_Verificador.calculardigitoverificadorvertical("precio_boca")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function



    Public Function consultartodos() As List(Of BE.BE_BocaMercado)
        Dim listabocamercado As New List(Of BE.BE_BocaMercado)
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            datatable = mapper_stores.consultar("consultar_bocamercado", lista_parametros)
            For Each boca As DataRow In datatable.Rows
                Dim bocamercado As New BE.BE_BocaMercado
                bocamercado.precio_bocamercado = boca(0)
                listabocamercado.Add(bocamercado)
            Next
            Return listabocamercado
        Catch ex As Exception
            Return listabocamercado
        End Try
    End Function

End Class ' DAL_BocaMercado


