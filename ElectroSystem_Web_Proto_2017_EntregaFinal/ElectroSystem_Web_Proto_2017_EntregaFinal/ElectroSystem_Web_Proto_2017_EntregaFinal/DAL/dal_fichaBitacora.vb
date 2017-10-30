


Imports System.Data.SqlClient
Public Class dal_fichaBitacora


    Public m_Be_Ficha_Bitacora As BE.Be_Ficha_Bitacora
    Public m_SQLHelper As Seguridad.SQLHelper

		''' 
		''' <param name="unbe"></param>
    Public Function consultartodos(ByVal unbe As BE.Be_Ficha_Bitacora) As List(Of BE.BE_Bitacora)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim data_table As DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim P() As SqlParameter
            Dim listaBitacora As New List(Of BE.BE_Bitacora)
            Dim existen As Boolean = False
            If unbe.fecha_hora IsNot Nothing AndAlso unbe.fecha_hasta_hora IsNot Nothing AndAlso unbe.usuario.Nombre_Usuario <> "" AndAlso unbe.codigo_evento IsNot Nothing Then
                Dim stored1 As String = "ficha_bitacora_generica_fechahora_fechahasta_usuario_codigo_evento"
                ReDim P(3)
                P(0) = sqlhelper.BuildParameter("@fecha_hora", unbe.fecha_hora)
                P(1) = sqlhelper.BuildParameter("@fecha_hasta_hora", unbe.fecha_hasta_hora)
                P(2) = sqlhelper.BuildParameter("@id_usuario", unbe.usuario.id_usuario)
                P(3) = sqlhelper.BuildParameter("@codigo_evento", unbe.codigo_evento)
                Dim lista_parametros As New List(Of SqlParameter)
                lista_parametros.AddRange(P)
                data_table = mapper_stores.consultar(stored1, lista_parametros)
            ElseIf unbe.fecha_hora IsNot Nothing AndAlso unbe.fecha_hasta_hora IsNot Nothing AndAlso unbe.usuario.Nombre_Usuario = "" AndAlso unbe.codigo_evento Is Nothing Then
                Dim stored1 As String = "ficha_bitacora_generica_fechahora_fechahasta"
                ReDim P(1)
                P(0) = sqlhelper.BuildParameter("@fecha_hora", unbe.fecha_hora)
                P(1) = sqlhelper.BuildParameter("@fecha_hasta_hora", unbe.fecha_hasta_hora)
                Dim lista_parametros As New List(Of SqlParameter)
                lista_parametros.AddRange(P)
                data_table = mapper_stores.consultar(stored1, lista_parametros)
            ElseIf unbe.fecha_hora IsNot Nothing AndAlso unbe.fecha_hasta_hora Is Nothing AndAlso unbe.usuario.Nombre_Usuario = "" AndAlso unbe.codigo_evento Is Nothing Then
                Dim stored1 As String = "ficha_bitacora_generica_fechahora"
                ReDim P(0)
                P(0) = sqlhelper.BuildParameter("@fecha_hora", unbe.fecha_hora)
                Dim lista_parametros As New List(Of SqlParameter)
                lista_parametros.AddRange(P)
                data_table = mapper_stores.consultar(stored1, lista_parametros)
            ElseIf unbe.fecha_hora IsNot Nothing AndAlso unbe.usuario.Nombre_Usuario <> "" AndAlso unbe.fecha_hasta_hora Is Nothing AndAlso unbe.codigo_evento Is Nothing Then
                Dim stored1 As String = "ficha_bitacora_generica_fechahora_usuario"
                ReDim P(1)
                P(0) = sqlhelper.BuildParameter("@fecha_hora", unbe.fecha_hora)
                P(1) = sqlhelper.BuildParameter("@id_usuario", unbe.usuario.id_usuario)
                Dim lista_parametros As New List(Of SqlParameter)
                lista_parametros.AddRange(P)
                data_table = mapper_stores.consultar(stored1, lista_parametros)
            ElseIf unbe.fecha_hora Is Nothing AndAlso unbe.usuario.Nombre_Usuario <> "" AndAlso unbe.fecha_hasta_hora IsNot Nothing AndAlso unbe.codigo_evento Is Nothing Then
                Dim stored1 As String = "ficha_bitacora_generica_fechahasta_usuario"
                ReDim P(1)
                P(0) = sqlhelper.BuildParameter("@fecha_hasta_hora", unbe.fecha_hasta_hora)
                P(1) = sqlhelper.BuildParameter("@id_usuario", unbe.usuario.id_usuario)
                Dim lista_parametros As New List(Of SqlParameter)
                lista_parametros.AddRange(P)
                data_table = mapper_stores.consultar(stored1, lista_parametros)
            ElseIf unbe.fecha_hora IsNot Nothing AndAlso unbe.usuario.Nombre_Usuario <> "" AndAlso unbe.fecha_hasta_hora IsNot Nothing AndAlso unbe.codigo_evento Is Nothing Then
                Dim stored1 As String = "ficha_bitacora_generica_fechahora_fechahasta_usuario"
                ReDim P(2)
                P(0) = sqlhelper.BuildParameter("@fecha_hora", unbe.fecha_hora)
                P(1) = sqlhelper.BuildParameter("@fecha_hasta_hora", unbe.fecha_hasta_hora)
                P(2) = sqlhelper.BuildParameter("@id_usuario", unbe.usuario.id_usuario)
                Dim lista_parametros As New List(Of SqlParameter)
                lista_parametros.AddRange(P)
                data_table = mapper_stores.consultar(stored1, lista_parametros)

            ElseIf unbe.fecha_hora Is Nothing AndAlso unbe.fecha_hasta_hora IsNot Nothing AndAlso unbe.usuario.Nombre_Usuario = "" AndAlso unbe.codigo_evento Is Nothing Then
                Dim stored1 As String = "ficha_bitacora_generica_fechahasta"
                ReDim P(0)
                P(0) = sqlhelper.BuildParameter("@fecha_hasta_hora", unbe.fecha_hasta_hora)
                Dim lista_parametros As New List(Of SqlParameter)
                lista_parametros.AddRange(P)
                data_table = mapper_stores.consultar(stored1, lista_parametros)

            ElseIf unbe.fecha_hora Is Nothing AndAlso unbe.fecha_hasta_hora Is Nothing AndAlso unbe.usuario.Nombre_Usuario = "" AndAlso unbe.codigo_evento Is Nothing Then
                Dim stored1 As String = "ficha_bitacora_generica"
                Dim lista_parametros As New List(Of SqlParameter)
                data_table = mapper_stores.consultar(stored1, lista_parametros)
            Else
                If unbe.fecha_hora IsNot Nothing AndAlso unbe.fecha_hasta_hora Is Nothing AndAlso unbe.usuario.Nombre_Usuario <> "" AndAlso unbe.codigo_evento IsNot Nothing Then
                    Dim stored1 As String = "ficha_bitacora_generica_fechahora_usuario_codigo_evento"
                    ReDim P(2)
                    P(0) = sqlhelper.BuildParameter("@fecha_hora", unbe.fecha_hora)
                    P(1) = sqlhelper.BuildParameter("@id_usuario", unbe.usuario.id_usuario)
                    P(2) = sqlhelper.BuildParameter("@codigo_evento", unbe.codigo_evento)
                    Dim lista_parametros As New List(Of SqlParameter)
                    lista_parametros.AddRange(P)
                    data_table = mapper_stores.consultar(stored1, lista_parametros)
                ElseIf unbe.usuario.Nombre_Usuario <> "" AndAlso unbe.codigo_evento IsNot Nothing AndAlso unbe.fecha_hora Is Nothing AndAlso unbe.fecha_hasta_hora Is Nothing Then
                    Dim stored1 As String = "ficha_bitacora_generica_usuario_codigo_evento"
                    ReDim P(1)
                    P(0) = sqlhelper.BuildParameter("@id_usuario", unbe.usuario.id_usuario)
                    P(1) = sqlhelper.BuildParameter("@codigo_evento", unbe.codigo_evento)
                    Dim lista_parametros As New List(Of SqlParameter)
                    lista_parametros.AddRange(P)
                    data_table = mapper_stores.consultar(stored1, lista_parametros)
                ElseIf unbe.usuario.Nombre_Usuario <> "" AndAlso unbe.codigo_evento Is Nothing AndAlso unbe.fecha_hora Is Nothing AndAlso unbe.fecha_hasta_hora Is Nothing Then
                    Dim stored1 As String = "ficha_bitacora_generica_usuario"
                    ReDim P(0)
                    P(0) = sqlhelper.BuildParameter("@id_usuario", unbe.usuario.id_usuario)
                    Dim lista_parametros As New List(Of SqlParameter)
                    lista_parametros.AddRange(P)
                    data_table = mapper_stores.consultar(stored1, lista_parametros)
                ElseIf unbe.codigo_evento IsNot Nothing AndAlso unbe.usuario.Nombre_Usuario = "" AndAlso unbe.fecha_hora Is Nothing AndAlso unbe.fecha_hasta_hora Is Nothing Then
                    Dim stored1 As String = "ficha_bitacora_generica_codigo_evento"
                    ReDim P(0)
                    P(0) = sqlhelper.BuildParameter("@codigo_evento", unbe.codigo_evento)
                    Dim lista_parametros As New List(Of SqlParameter)
                    lista_parametros.AddRange(P)
                    data_table = mapper_stores.consultar(stored1, lista_parametros)
                ElseIf unbe.codigo_evento IsNot Nothing AndAlso unbe.fecha_hora IsNot Nothing AndAlso unbe.usuario.Nombre_Usuario = "" AndAlso unbe.fecha_hasta_hora Is Nothing Then
                    Dim stored1 As String = "ficha_bitacora_generica_codigo_evento_fechahora"
                    ReDim P(1)
                    P(0) = sqlhelper.BuildParameter("@codigo_evento", unbe.codigo_evento)
                    P(1) = sqlhelper.BuildParameter("@fecha_hora", unbe.fecha_hora)
                    Dim lista_parametros As New List(Of SqlParameter)
                    lista_parametros.AddRange(P)
                    data_table = mapper_stores.consultar(stored1, lista_parametros)
                ElseIf unbe.codigo_evento IsNot Nothing AndAlso unbe.fecha_hora Is Nothing AndAlso unbe.usuario.Nombre_Usuario = "" AndAlso unbe.fecha_hasta_hora IsNot Nothing Then
                    Dim stored1 As String = "ficha_bitacora_generica_codigo_evento_fechahasta"
                    ReDim P(1)
                    P(0) = sqlhelper.BuildParameter("@codigo_evento", unbe.codigo_evento)
                    P(1) = sqlhelper.BuildParameter("@fecha_hasta_hora", unbe.fecha_hasta_hora)
                    Dim lista_parametros As New List(Of SqlParameter)
                    lista_parametros.AddRange(P)
                    data_table = mapper_stores.consultar(stored1, lista_parametros)

                ElseIf unbe.codigo_evento IsNot Nothing AndAlso unbe.fecha_hora IsNot Nothing AndAlso unbe.usuario.Nombre_Usuario = "" AndAlso unbe.fecha_hasta_hora IsNot Nothing Then
                    Dim stored1 As String = "ficha_bitacora_generica_codigo_evento_fechahora_fechahasta"
                    ReDim P(2)
                    P(0) = sqlhelper.BuildParameter("@codigo_evento", unbe.codigo_evento)
                    P(1) = sqlhelper.BuildParameter("@fecha_hora", unbe.fecha_hora)
                    P(2) = sqlhelper.BuildParameter("@fecha_hasta_hora", unbe.fecha_hasta_hora)
                    Dim lista_parametros As New List(Of SqlParameter)
                    lista_parametros.AddRange(P)
                    data_table = mapper_stores.consultar(stored1, lista_parametros)
                End If
            End If
            If data_table.Rows.Count > 0 Then
                For Each fila As DataRow In data_table.Rows
                    existen = True
                    Dim tmpBitacora As New BE.BE_Bitacora
                    Dim tmpusuario As New BE.BE_Usuario
                    tmpBitacora.id_registro = fila.Item(0)
                    tmpBitacora.fecha_hora = fila.Item(1)
                    tmpBitacora.informacion_adicional = fila.Item(2)
                    tmpBitacora.codigo_evento = fila.Item(3)
                    If IsDBNull(fila.Item(7)) Then
                        tmpusuario.id_usuario = Nothing
                        If IsDBNull(fila.Item(8)) Then
                            tmpusuario.ip = ""
                        Else
                            tmpusuario.ip = fila.Item(8)

                        End If
                    Else
                        tmpusuario.id_usuario = fila.Item(4)
                        tmpusuario.Nombre_Usuario = fila.Item(7)
                        If IsDBNull(fila.Item(8)) Then
                            tmpusuario.ip = ""
                        Else
                            tmpusuario.ip = fila.Item(8)
                        End If
                    End If
                    tmpBitacora.descripcion_evento = fila.Item(5)
                    tmpBitacora.criticidad = fila.Item(6)
                    tmpBitacora.usuario = tmpusuario
                    listaBitacora.Add(tmpBitacora)
                Next
            Else
                Return listaBitacora
            End If
            Return listaBitacora
        Catch ex As Exception
            sqlhelper.cerrarconexion()
        Finally
            sqlhelper.cerrarconexion()
        End Try
    End Function


End Class ' dal_fichaBitacora


