Imports System.Data.SqlClient
Public Class Mapper_Stored
    Dim conexion As New SEGURIDAD.SQLHelper
    Function insertar_eliminar_modificar(nombre As String, lista_sql As List(Of SqlParameter)) As Boolean
        Dim sqlcomando As New SqlCommand

        Try
            Dim tabla As New DataTable
            Dim dataadapter As New SqlDataAdapter
            sqlcomando.CommandType = CommandType.StoredProcedure
            If nombre = "hacerrestore" Then
                sqlcomando.Connection = conexion.abrirconexionmaster()
            Else
                sqlcomando.Connection = conexion.abrirconexion()
            End If
            sqlcomando.CommandText = nombre
            sqlcomando.Parameters.Clear()
            For Each parametro As SqlParameter In lista_sql
                sqlcomando.Parameters.Add(parametro)
            Next
            sqlcomando.Connection.Open()
            sqlcomando.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        Finally
            sqlcomando.Connection.Close()
        End Try
    End Function

    Function consultar(nombre As String, lista_sql As List(Of SqlParameter)) As DataTable
        Try
            Dim tabla As New DataTable
            Dim sqlcomando As New SqlCommand
            Dim dataadapter As New SqlDataAdapter
            sqlcomando.CommandType = CommandType.StoredProcedure
            sqlcomando.CommandText = nombre
            sqlcomando.Connection = conexion.abrirconexion()
            If lista_sql.Count > 0 Then
                sqlcomando.Parameters.Clear()
                For Each parametro As SqlParameter In lista_sql
                    sqlcomando.Parameters.Add(parametro)
                Next
            Else
                sqlcomando.Parameters.Clear()
            End If
            dataadapter.SelectCommand = sqlcomando
            dataadapter.Fill(tabla)
            Return tabla
        Catch ex As Exception
            Dim tabla As New DataTable
            Return tabla
        End Try
    End Function


End Class
