

Imports System.Data.SqlClient
Public Class DAL_Permisos

    Public m_SQLHelper As Seguridad.SQLHelper

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Permisocompuesto) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Dim lista_parametros As New List(Of SqlParameter)
        Try
            Dim P(0) As SqlParameter
            Dim consultarid As New SqlCommand
            P(0) = sqlhelper.BuildParameter("@permiso_descripcion", unbe.Descripcion)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("alta_familia", lista_parametros)
            For Each permiso As BE.BE_PermisoBase In unbe.lista_permisos
                lista_parametros.Clear()
                ReDim P(1)
                P(0) = sqlhelper.BuildParameter("@permiso_descripcion", unbe.Descripcion)
                P(1) = sqlhelper.BuildParameter("@permisohijo_id", permiso.idpermiso)
                lista_parametros.AddRange(P)
                mapper_stores.insertar_eliminar_modificar("alta_permisos_hijo", lista_parametros)
            Next
            Return 1997
        Catch ex As Exception
            Return 1996
        End Try
    End Function

    Public Function modificar(ByVal unbe As BE.BE_Permisocompuesto) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Dim lista_parametros As New List(Of SqlParameter)
        Try
            Dim P(1) As SqlParameter
            Dim modifica_permiso As New SqlCommand
            P(0) = sqlhelper.BuildParameter("@permiso_descripcion", unbe.Descripcion)
            P(1) = sqlhelper.BuildParameter("@permiso_id", unbe.idpermiso)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("modifica_familia", lista_parametros)
            For Each permiso As BE.BE_PermisoBase In unbe.lista_permisos
                lista_parametros.Clear()
                ReDim P(1)
                P(0) = sqlhelper.BuildParameter("@permiso_id", unbe.idpermiso)
                P(1) = sqlhelper.BuildParameter("@permisohijo_id", permiso.idpermiso)
                lista_parametros.AddRange(P)
                mapper_stores.insertar_eliminar_modificar("modifica_permisos_hijo", lista_parametros)
            Next
            Return 1990
        Catch ex As Exception
            Return 1989
        End Try
    End Function

    Private Function validar_rol_asignado(unbe As BE.BE_Permisocompuesto) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@permiso_id", unbe.idpermiso)
            lista_parametros.AddRange(P)
            datatable = mapper_stores.consultar("existe_permiso_con_usuarios", lista_parametros)
            If datatable.Rows.Count = 0 Then
                Return 0
            Else
                Return datatable.Rows(0).Item(0)
            End If

        Catch ex As Exception
            Return 2
        End Try
    End Function

    Public Function baja(ByVal unbe As BE.BE_Permisocompuesto) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim P(0) As SqlParameter
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim respuesta As Integer = 0
            respuesta = Me.validar_rol_asignado(unbe)
            If respuesta <> 0 Then
                'quiere decir que  lo tienen asignado
                Return 7009
            Else
                'quiere decir que nadie lo tiene asignado
                Dim baja_idioma As New SqlCommand
                P(0) = sqlhelper.BuildParameter("@permiso_id", unbe.idpermiso)
                lista_parametros.AddRange(P)
                mapper_stores.insertar_eliminar_modificar("baja_rol", lista_parametros)
                Return 7011
            End If
        Catch ex As Exception
            Return 7010
        End Try
    End Function

    Public Function consultar_permisos(ByVal unbe As BE.BE_PermisoBase) As BE.BE_Permisocompuesto
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim tiene_hijos As String = "tiene_hijos"
            Dim data_table As New DataTable
            Dim permiso As BE.BE_PermisoBase = Nothing
            Dim permiso_actual As BE.BE_PermisoBase = Nothing
            Dim P(0) As SqlParameter
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            P(0) = sqlhelper.BuildParameter("@id_permiso", unbe.idpermiso)
            Dim lista_parametros As New List(Of SqlParameter)
            lista_parametros.AddRange(P)
            data_table = mapper_stores.consultar(tiene_hijos, lista_parametros)
            'Si tiene hijos... pregunto quienes son!
            If data_table.Rows(0)(0) > 0 Then
                Dim data_adapter As New SqlDataAdapter
                Dim hijos As String = "quienes_son_los_hijos"
                Dim a(0) As SqlParameter
                a(0) = sqlhelper.BuildParameter("@id_permiso", unbe.idpermiso)
                lista_parametros.Clear()
                lista_parametros.AddRange(a)
                data_table.Clear()
                data_table = mapper_stores.consultar(hijos, lista_parametros)
                'tiene hijos su hijo?
                For Each r As DataRow In data_table.Rows()
                    Dim data_adapter_hijos_hijos As New SqlDataAdapter
                    Dim tabla As New DataTable
                    Dim b(0) As SqlParameter
                    b(0) = sqlhelper.BuildParameter("@id_permiso", r(0))
                    lista_parametros.Clear()
                    lista_parametros.AddRange(a)
                    tabla = mapper_stores.consultar(hijos, lista_parametros)
                    'si tiene hijos su hijo....
                    If tabla.Rows.Count > 0 Then
                        If tabla.Rows(0)(0) > 0 Then
                            permiso_actual = New BE.BE_Permisocompuesto
                            permiso_actual.idpermiso = r(0)
                            If Not IsDBNull(r(1)) Then
                                permiso_actual.Descripcion = r(1)
                            Else
                                permiso_actual.Descripcion = Nothing
                            End If
                            permiso = Me.consultar_permisos(permiso_actual)
                            'no tiene hijos su hijo...
                        Else
                            permiso_actual = New BE.BE_Patente
                            CType(permiso_actual, BE.BE_Patente).idpermiso = r(0)
                            If Not IsDBNull(r(1)) Then
                                CType(permiso_actual, BE.BE_Patente).Descripcion = r(1)
                            Else
                                CType(permiso_actual, BE.BE_Patente).Descripcion = Nothing
                            End If
                        End If
                    Else
                        permiso_actual = New BE.BE_Patente
                        CType(permiso_actual, BE.BE_Patente).idpermiso = r(0)
                        If Not IsDBNull(r(1)) Then
                            CType(permiso_actual, BE.BE_Patente).Descripcion = r(1)
                        Else
                            CType(permiso_actual, BE.BE_Patente).Descripcion = Nothing
                        End If
                    End If
                    ' lo agregamos al primero...
                    CType(unbe, BE.BE_Permisocompuesto).lista_permisos.Add(permiso_actual)
                Next
            Else
                Return Nothing
            End If
            Return unbe
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function consultar_si_espermiso(ByVal unbe As BE.BE_PermisoBase) As Boolean
        consultar_si_espermiso = False
    End Function

    Public Function listarpermisos() As List(Of BE.BE_Permisocompuesto)
        listarpermisos = Nothing
    End Function

    Public Function listar_permisoscompuestos() As List(Of BE.BE_Permisocompuesto)
        Dim lista_permisos As New List(Of BE.BE_Permisocompuesto)
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            datatable = mapper_stores.consultar("consultartodospermisoscompuestos", lista_parametros)
            For Each elemento As DataRow In datatable.Rows
                Dim tmp_permisocompuesto As New BE.BE_Permisocompuesto
                tmp_permisocompuesto.idpermiso = elemento(0)
                tmp_permisocompuesto.Descripcion = elemento(1)
                Me.consultar_permisos(tmp_permisocompuesto)
                lista_permisos.Add(tmp_permisocompuesto)
            Next
            Return lista_permisos
        Catch ex As Exception

        End Try

    End Function

    Public Function listar_permisossimples() As List(Of BE.BE_Patente)
        Dim lista_permisos As New List(Of BE.BE_Patente)
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            datatable = mapper_stores.consultar("consultartodospermisosbases", lista_parametros)
            For Each elemento As DataRow In datatable.Rows
                Dim tmp_patente As New BE.BE_Patente
                tmp_patente.idpermiso = elemento(0)
                tmp_patente.Descripcion = elemento(1)
                lista_permisos.add(tmp_patente)
            Next
            Return lista_permisos
        Catch ex As Exception

        End Try

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function validar_familia(ByVal unbe As BE.BE_Permisocompuesto) As Boolean
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            If unbe.idpermiso = "" Then
                Dim P(0) As SqlParameter
                P(0) = sqlhelper.BuildParameter("@permiso_descripcion", unbe.Descripcion)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("validar_familia", lista_parametros)
            Else
                Dim P(0) As SqlParameter
                P(0) = sqlhelper.BuildParameter("@permiso_descripcion", unbe.Descripcion)
                P(1) = sqlhelper.BuildParameter("@permiso_id", unbe.Descripcion)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("validar_familia_conid", lista_parametros)
            End If
            If datatable.Rows.Count = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return 1999
        End Try
    End Function


	End Class ' DAL_Permisos


