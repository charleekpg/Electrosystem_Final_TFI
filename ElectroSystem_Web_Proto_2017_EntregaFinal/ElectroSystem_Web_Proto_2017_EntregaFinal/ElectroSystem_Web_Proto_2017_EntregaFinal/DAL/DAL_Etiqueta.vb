


Imports System.Data.SqlClient

Public Class DAL_Etiqueta
    Shared etiquetas As New List(Of BE.BE_Etiqueta)

    Private Function validar_existencia_idioma(ByVal unbe As BE.BE_Idioma) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@idioma", unbe.Idioma)
            lista_parametros.AddRange(P)
            datatable = mapper_stores.consultar("existe_idioma", lista_parametros)
            If datatable.Rows.Count = 0 Then
                Return 0
            Else
                Return datatable.Rows(0).Item(0)
            End If

        Catch ex As Exception
            Return 2
        End Try
    End Function

    Private Function validar_idioma_conusuarios(ByVal unbe As BE.BE_Idioma) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@id_idioma", unbe.id_idioma)
            lista_parametros.AddRange(P)
            datatable = mapper_stores.consultar("existe_idioma_con_usuarios", lista_parametros)
            If datatable.Rows.Count = 0 Then
                Return 0
            Else
                Return datatable.Rows(0).Item(0)
            End If

        Catch ex As Exception
            Return 2
        End Try
    End Function

    Public Function alta(ByVal unbe As BE.BE_Idioma) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim P(0) As SqlParameter
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim respuesta As Integer = 0
            respuesta = Me.validar_existencia_idioma(unbe)
            'primero valido si existe el idioma
            If respuesta > 0 Then
                'quiere decir que existe
                Return 1
            Else
                'quiere decir que no existe
                Dim alta_idioma As New SqlCommand
                P(0) = sqlhelper.BuildParameter("@idioma", unbe.Idioma)
                lista_parametros.AddRange(P)
                mapper_stores.insertar_eliminar_modificar("alta_idioma", lista_parametros)
                'ahora tengo que consultar el id del que agregue
                unbe.id_idioma = Me.validar_existencia_idioma(unbe)
                For Each etiqueta As BE.BE_Etiqueta In unbe.be_etiqueta
                    ReDim P(2)
                    P(0) = sqlhelper.BuildParameter("@id_control", etiqueta.id_control)
                    P(1) = sqlhelper.BuildParameter("@nombre_traduccion", etiqueta.nombre_traduccion)
                    P(2) = sqlhelper.BuildParameter("@id_idioma", unbe.id_idioma)
                    lista_parametros.Clear()
                    lista_parametros.AddRange(P)
                    mapper_stores.insertar_eliminar_modificar("alta_etiqueta", lista_parametros)
                Next
                Return 0
            End If
        Catch ex As Exception
            Return 2
        End Try
    End Function

    Public Function baja(ByVal unbe As BE.BE_Idioma) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim P(0) As SqlParameter
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim respuesta As Integer = 0
            respuesta = Me.validar_idioma_conusuarios(unbe)
            'primero valido si existe el idioma
            If respuesta <> 0 Then
                'quiere decir que existe
                Return 1
            Else
                'quiere decir que no existe
                Dim baja_idioma As New SqlCommand
                P(0) = sqlhelper.BuildParameter("@id_idioma", unbe.id_idioma)
                lista_parametros.AddRange(P)
                mapper_stores.insertar_eliminar_modificar("baja_idioma", lista_parametros)
                Return 0
            End If
        Catch ex As Exception
            Return 2
        End Try
    End Function

    Public Function modificar(ByVal unbe As BE.BE_Idioma) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim respuesta As Integer = 0
            Dim P(8) As SqlParameter
            If respuesta = unbe.id_idioma Then
                'se quiere modificar al mismo idioma' asi que ok
                For Each etiqueta As BE.BE_Etiqueta In unbe.be_etiqueta
                    ReDim P(2)
                    P(0) = sqlhelper.BuildParameter("@id_control", etiqueta.id_control)
                    P(1) = sqlhelper.BuildParameter("@nombre_traduccion", etiqueta.nombre_traduccion)
                    P(2) = sqlhelper.BuildParameter("@id_idioma", unbe.id_idioma)
                    lista_parametros.Clear()
                    lista_parametros.AddRange(P)
                    mapper_stores.insertar_eliminar_modificar("modifica_etiqueta", lista_parametros)
                Next
                Return 0
            ElseIf respuesta = 0 Then
                'se quiere modificar el nombre del idioma, y las etiquetas asi que ok
                Dim actualiza_idioma As New SqlCommand
                ReDim P(1)
                P(0) = sqlhelper.BuildParameter("@id_idioma", unbe.id_idioma)
                P(1) = sqlhelper.BuildParameter("@idioma", unbe.Idioma)
                lista_parametros.AddRange(P)
                mapper_stores.insertar_eliminar_modificar("modifica_idioma", lista_parametros)
                For Each etiqueta As BE.BE_Etiqueta In unbe.be_etiqueta
                    ReDim P(2)
                    P(0) = sqlhelper.BuildParameter("@id_control", etiqueta.id_control)
                    P(1) = sqlhelper.BuildParameter("@nombre_traduccion", etiqueta.nombre_traduccion)
                    P(2) = sqlhelper.BuildParameter("@id_idioma", unbe.id_idioma)
                    lista_parametros.Clear()
                    lista_parametros.AddRange(P)
                    mapper_stores.insertar_eliminar_modificar("modifica_etiqueta", lista_parametros)
                Next
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            Return 2
        End Try
    End Function

    ''' 
    ''' <param name="idioma"></param>
    Private Function consultar_idioma_exis(ByVal idioma As be.be_idioma) As Boolean
        consultar_idioma_exis = False
    End Function

    Public Function consultar_todos() As list(Of be.be_etiqueta)
        consultar_todos = Nothing
    End Function

    ''' 
    ''' <param name="etiqueta"></param>
    Public Function Leer(ByVal etiqueta As BE.BE_Etiqueta) As BE.BE_Etiqueta
        etiqueta = etiquetas.Find(Function(x) x.idioma.Idioma = etiqueta.idioma.Idioma AndAlso x.id_control = etiqueta.id_control)
        Return etiqueta
    End Function

    Function consultar_idiomas() As List(Of BE.BE_Idioma)
        Dim lista_idioma As New List(Of BE.BE_Idioma)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim datatable As New DataTable
            Dim datatable_etiqueta As New DataTable
            Dim tmpetiqueta As New BE.BE_Etiqueta
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            datatable = mapper_stores.consultar("consultar_idiomas", lista_parametros)
            For Each idioma As DataRow In datatable.Rows
                Dim tmp_idioma As New BE.BE_Idioma
                tmp_idioma.id_idioma = idioma(0)
                tmp_idioma.Idioma = idioma(1)
                lista_idioma.Add(tmp_idioma)
            Next
            For Each idi As BE.BE_Idioma In lista_idioma
                Dim P(0) As SqlParameter
                Dim lista_etiqueta As New List(Of BE.BE_Etiqueta)
                lista_parametros.Clear()
            P(0) = sqlhelper.BuildParameter("@id_idioma", idi.id_idioma)
            lista_parametros.AddRange(P)
                datatable_etiqueta = mapper_stores.consultar("consultar_etiqueta_por_idioma", lista_parametros)
                For Each etique As DataRow In datatable_etiqueta.Rows
                    Dim tmp_etiqueta As New BE.BE_Etiqueta
                    tmp_etiqueta.id_control = etique(0)
                    tmp_etiqueta.nombre_traduccion = etique(1)
                    lista_etiqueta.Add(tmp_etiqueta)
                    idi.be_etiqueta = lista_etiqueta
                Next

            Next
            Return lista_idioma
        Catch ex As Exception
            Dim lista As New List(Of BE.BE_Idioma)
            Return lista
        End Try

    End Function

End Class


