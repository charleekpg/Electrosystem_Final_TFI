






Imports System.Data.SqlClient
Public Class DAL_Domicilio


    Public m_BE_Domicilio As BE.BE_Domicilio
    Public m_SQLHelper As Seguridad.SQLHelper

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Domicilio) As Integer
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(5) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@P1", unbe.calle)
            If unbe.altura Is Nothing Then
                P(1) = sqlhelper.BuildParameter("@P2", DBNull.Value)
            Else
                P(1) = sqlhelper.BuildParameter("@P2", unbe.altura)
            End If
            P(2) = sqlhelper.BuildParameter("@P3", unbe.departamento)
            If unbe.piso Is Nothing Then
                P(3) = sqlhelper.BuildParameter("@P4", DBNull.Value)
            Else
                P(3) = sqlhelper.BuildParameter("@P4", unbe.piso)
            End If
            P(4) = sqlhelper.BuildParameter("@P5", unbe.localidad.id)
            P(5) = sqlhelper.BuildParameter("@P6", unbe.country)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("alta_domicilio", lista_parametros)
            If consultar_ultimo(unbe) Is Nothing Then
                Return 5001
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return 5001
        End Try

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Domicilio) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Domicilio) As BE.BE_Domicilio
        consultar = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function consultar_ultimo(ByVal unbe As BE.BE_Domicilio) As BE.BE_Domicilio
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            datatable = mapper_stores.consultar("consultar_ultimodomicilio", lista_parametros)
            For Each elemento As DataRow In datatable.Rows
                unbe.id = elemento(0)
            Next
            Return unbe
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function consultartodos() As List(Of BE.BE_Domicilio)
        consultartodos = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Domicilio) As Integer
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(6) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@P1", unbe.calle)
            If unbe.altura Is Nothing Then
                P(1) = sqlhelper.BuildParameter("@P2", DBNull.Value)
            Else
                P(1) = sqlhelper.BuildParameter("@P2", unbe.altura)
            End If
            P(2) = sqlhelper.BuildParameter("@P3", unbe.departamento)
            If unbe.piso Is Nothing Then
                P(3) = sqlhelper.BuildParameter("@P4", DBNull.Value)
            Else
                P(3) = sqlhelper.BuildParameter("@P4", unbe.piso)
            End If
            P(4) = sqlhelper.BuildParameter("@P5", unbe.localidad.id)
            P(5) = sqlhelper.BuildParameter("@P6", unbe.country)
            P(6) = sqlhelper.BuildParameter("@P7", unbe.id)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("modificar_domicilio", lista_parametros)
            Return Nothing
        Catch ex As Exception
            Return 5004
        End Try
    End Function


	End Class ' DAL_Domicilio


