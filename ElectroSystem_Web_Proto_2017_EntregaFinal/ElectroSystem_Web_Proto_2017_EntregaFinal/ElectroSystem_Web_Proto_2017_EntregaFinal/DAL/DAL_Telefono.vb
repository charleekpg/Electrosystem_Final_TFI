
Imports System.Data.SqlClient
Public Class DAL_Telefono


    Public m_BE_Telefono As BE.BE_Telefono

		''' 
		''' <param name="unbe"></param>
		Public Function alta_telefono(ByVal unbe As BE.BE_CLIENTE) As Boolean
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim lista_parametros As New List(Of SqlParameter)
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Try
            For Each tel As BE.BE_Telefono In unbe.Telefonos
                If tel.eliminar = False Then
                    Dim P(0) As SqlParameter
                    lista_parametros.Clear()
                    P(0) = sqlhelper.BuildParameter("@P1", tel.numero_telefono)
                    lista_parametros.AddRange(P)
                    mapper_stores.insertar_eliminar_modificar("alta_telefonoid", lista_parametros)
                Else
                    GoTo 1
                End If
1:          Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function cargar_telefono(ByVal unbe As BE.BE_CLIENTE) As List(Of BE.BE_Telefono)
        cargar_telefono = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function validartelefono(ByVal unbe As List(Of BE.BE_Telefono)) As Integer
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim resultado As Integer = 1
            Dim lista_parametros As New List(Of SqlParameter)
            Dim datatable As New DataTable
            Dim listapersona As New List(Of BE.BE_Personafisica)
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            For Each tel As BE.BE_Telefono In unbe
                If tel.id = 0 Then
                    Dim P(0) As SqlParameter
                    P(0) = sqlhelper.BuildParameter("@P1", tel.numero_telefono)
                    lista_parametros.AddRange(P)
                    datatable = mapper_stores.consultar("validartelefono_connumero", lista_parametros)
                Else
                    Dim P(1) As SqlParameter
                    P(0) = sqlhelper.BuildParameter("@P1", tel.numero_telefono)
                    P(1) = sqlhelper.BuildParameter("@P2", tel.id)
                    lista_parametros.AddRange(P)
                    datatable = mapper_stores.consultar("validartelefono_connumeroyid", lista_parametros)
                End If
                If datatable.Rows.Count = 0 Then
                    lista_parametros.Clear()
                Else
                    resultado = 10121
                    Exit For
                End If
            Next
            Return resultado
        Catch ex As Exception
            Return 10122
        End Try
    End Function



End Class ' DAL_Telefono


