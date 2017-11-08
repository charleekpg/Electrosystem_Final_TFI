Imports System.Data.SqlClient

Public Class DAL_Bitacora

    Public Shared bitacora As New List(Of BE.BE_Bitacora)

    Public m_Digito_Verificador As Seguridad.Digito_Verificador
    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_SQLHelper As Seguridad.SQLHelper

    Public Function alta(ByVal unbe As BE.BE_Bitacora) As Boolean
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(0) As SqlParameter
            Dim actualizarintento As New SqlCommand
            Dim alta_Bitacora As New SqlCommand
            Dim stringconcatenado As String = ""
            Dim borrado As Integer = 0
            Dim DDVVH As Integer
            If unbe.usuario Is Nothing OrElse unbe.usuario.id_usuario Is Nothing Then
                ReDim P(3)
                stringconcatenado = "0" & unbe.fecha_hora.ToString & unbe.codigo_evento.ToString & unbe.informacion_adicional.ToString '& unbe.usuario.id_usuario.ToString
                DDVVH = SEGURIDAD.Digito_Verificador.calculardigitoverificador(stringconcatenado)
                P(0) = sqlhelper.BuildParameter("@fecha_hora", unbe.fecha_hora)
                P(1) = sqlhelper.BuildParameter("@ddvvh", DDVVH)
                P(2) = sqlhelper.BuildParameter("@codigo_evento", unbe.codigo_evento)
                P(3) = sqlhelper.BuildParameter("@informacion_adicional", unbe.informacion_adicional)
                lista_parametros.AddRange(P)
                mapper_stores.insertar_eliminar_modificar("alta_bitacora_sinidusuario", lista_parametros)
                SEGURIDAD.Digito_Verificador.calculardigitoverificadorvertical("Bitacora")
            Else
                stringconcatenado = "0" & unbe.fecha_hora.ToString & unbe.codigo_evento.ToString & unbe.informacion_adicional.ToString & unbe.usuario.id_usuario.ToString
                DDVVH = SEGURIDAD.Digito_Verificador.calculardigitoverificador(stringconcatenado)
                ReDim P(5)
                P(0) = sqlhelper.BuildParameter("@fecha_hora", unbe.fecha_hora)
                P(1) = sqlhelper.BuildParameter("@ddvvh", DDVVH)
                P(2) = sqlhelper.BuildParameter("@codigo_evento", unbe.codigo_evento)
                P(3) = sqlhelper.BuildParameter("@informacion_adicional", unbe.informacion_adicional)
                P(4) = sqlhelper.BuildParameter("@id_usuario", unbe.usuario.id_usuario)
                P(5) = sqlhelper.BuildParameter("@ip", unbe.usuario.ip)
                lista_parametros.AddRange(P)
                mapper_stores.insertar_eliminar_modificar("alta_bitacora_conidusuario", lista_parametros)
                SEGURIDAD.Digito_Verificador.calculardigitoverificadorvertical("Bitacora")
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function


    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Bitacora) As BE.BE_Bitacora
        consultar = Nothing
    End Function

    Public Function consultarcodigodeevento() As List(Of BE.BE_Bitacora)
        Try
            Dim listaeventos As New List(Of BE.BE_Bitacora)

            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            datatable = mapper_stores.consultar("consultarcodigodeevento", lista_parametros)
            For Each fila As DataRow In datatable.Rows
                Dim tmpBitacora As New BE.BE_Bitacora
                tmpBitacora.codigo_evento = fila(0)
                listaeventos.Add(tmpBitacora)
            Next
            Return listaeventos
        Catch ex As Exception
            Dim listaeventos As New List(Of BE.BE_Bitacora)
            Return listaeventos
        End Try

    End Function

    Public Function consultartodos() As List(Of BE.BE_Bitacora)
        consultartodos = Nothing
    End Function

    ''' 
    ''' <param name="UNBE"></param>
    Private Function GestionarErrorBd(ByVal UNBE As String) As Boolean
        GestionarErrorBd = False
    End Function

End Class ' DAL_Bitacora


