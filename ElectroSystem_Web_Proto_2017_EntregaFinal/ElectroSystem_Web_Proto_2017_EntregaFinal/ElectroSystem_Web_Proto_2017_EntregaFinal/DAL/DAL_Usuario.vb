Imports System.Data.SqlClient
Imports System.Linq
Public Class DAL_Usuario
    Shared lista_usuarios As New List(Of BE.BE_Usuario)
    Shared usuario_idioma As BE.BE_Usuario
    ''' <param name="unbe"></param>
    Public Function actualizarintentosfallidosybloqueado(ByVal unbe As BE.BE_Usuario) As Boolean
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(2) As SqlParameter
            Dim actualizarintento As New SqlCommand
            P(0) = sqlhelper.BuildParameter("@cantidadintentosfallidos", unbe.Intentos_Fallidos)
            P(1) = sqlhelper.BuildParameter("@bloqueado", unbe.Usuario_Bloqueado)
            P(2) = sqlhelper.BuildParameter("@username", unbe.Nombre_Usuario)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("actualizarintentosfallidosybloqueado", lista_parametros)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Usuario) As Boolean
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim stringconcatenado As String = ""
        Try
            Dim DDVVH As Integer
            stringconcatenado = unbe.Nombre_Usuario & unbe.Clave
            DDVVH = SEGURIDAD.Digito_Verificador.calculardigitoverificador(stringconcatenado)
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(8) As SqlParameter
            Dim alta_usuario As New SqlCommand
            P(0) = sqlhelper.BuildParameter("@username", unbe.Nombre_Usuario)
            P(1) = sqlhelper.BuildParameter("@clave", unbe.Clave)
            P(2) = sqlhelper.BuildParameter("@fecha_creacion", unbe.Fec_Creacionclave)
            P(3) = sqlhelper.BuildParameter("@bloqueado", unbe.Usuario_Bloqueado)
            P(4) = sqlhelper.BuildParameter("@borrado", False)
            P(5) = sqlhelper.BuildParameter("@cantidadintentosfallidos", 0)
            P(6) = sqlhelper.BuildParameter("@id_idioma", unbe.Idioma.id_idioma)
            P(7) = sqlhelper.BuildParameter("@ddvvh", DDVVH)
            P(8) = sqlhelper.BuildParameter("@permiso_id", unbe.permiso_usuario.idpermiso)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("alta_usuario", lista_parametros)
            SEGURIDAD.Digito_Verificador.calculardigitoverificadorvertical("Usuario")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function asignar_permisos(ByVal unbe As BE.BE_Usuario) As Integer
        asignar_permisos = 0
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Usuario) As Boolean
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(0) As SqlParameter
            Dim baja_usuario As New SqlCommand
            P(0) = sqlhelper.BuildParameter("@id_usuario", unbe.id_usuario)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("baja_usuario", lista_parametros)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Usuario) As BE.BE_Usuario
        Dim listadepersonas As New List(Of BE.BE_Usuario)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(0) As SqlParameter
            Dim objusuario As New BE.BE_Usuario
            Dim objidioma As New BE.BE_Idioma
            P(0) = sqlhelper.BuildParameter("@username", unbe.Nombre_Usuario)
            lista_parametros.AddRange(P)
            datatable = mapper_stores.consultar("consultar_usuario", lista_parametros)
            If datatable.Rows.Count = 0 Then
                objusuario.nota = "Usuario y/o Contraseña Incorrecta"
                Return objusuario
            Else
                For Each fila As DataRow In datatable.Rows
                    objusuario.Nombre_Usuario = fila("username")
                    objusuario.Usuario_Bloqueado = fila("bloqueado")
                    objusuario.Intentos_Fallidos = fila("cantidadintentosfallidos")
                    objusuario.id_usuario = fila("id_usuario")
                Next
                datatable.Clear()
                ReDim P(1)
                P(0) = sqlhelper.BuildParameter("@username", unbe.Nombre_Usuario)
                P(1) = sqlhelper.BuildParameter("@contrasena", unbe.Clave)
                lista_parametros.Clear()
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("consultar_usuario_contrasena", lista_parametros)
                If datatable.Rows.Count = 0 Then
                    objusuario.nota = "Contraseña Incorrecta"
                    Return objusuario
                Else
                    For Each fila As DataRow In datatable.Rows
                        objusuario.Nombre_Usuario = fila("username")
                        objusuario.Clave = fila("clave")
                        objusuario.Fec_Creacionclave = fila("fecha_creacionclave")
                        objusuario.Usuario_Bloqueado = fila("bloqueado")
                        objusuario.Intentos_Fallidos = fila("cantidadintentosfallidos")
                        objusuario.id_usuario = fila("id_usuario")
                        objidioma.Idioma = fila("idioma")
                        objidioma.id_idioma = fila("id_idioma")
                        objusuario.Idioma = objidioma
                    Next
                    objusuario.permiso_usuario = consultar_permisos_usuario(objusuario)
                    Return objusuario
                End If

            End If
        Catch ex As Exception
            Dim objusuario As New BE.BE_Usuario
            objusuario.nota = "Fallo"
            Return objusuario
        End Try
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Function consultar_permisos_usuario(ByVal unbe As BE.BE_Usuario) As BE.BE_PermisoBase
        Dim listadepersonas As New List(Of BE.BE_Usuario)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim permiso_base As BE.BE_PermisoBase
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@id_usuario", unbe.id_usuario)
            lista_parametros.AddRange(P)
            datatable = mapper_stores.consultar("consultar_permisos_usuario", lista_parametros)
            Dim dal_permisos As New DAL.DAL_Permisos
            If datatable.Rows.Count > 0 Then
                For Each fila As DataRow In datatable.Rows
                    permiso_base = New BE.BE_Permisocompuesto
                    permiso_base.idpermiso = fila(0)
                    permiso_base.Descripcion = fila(1)
                    permiso_base = dal_permisos.consultar_permisos(permiso_base)
                Next
                Return permiso_base
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function consultartodos() As List(Of BE.BE_Usuario)
        Dim listadepersonas As New List(Of BE.BE_Usuario)
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            datatable = mapper_stores.consultar("consultartodos_usuarios", lista_parametros)
            For Each usuario As DataRow In datatable.Rows
                Dim tmpusuario As New BE.BE_Usuario
                Dim tmpidioma As New BE.BE_Idioma
                tmpusuario.Nombre_Usuario = usuario(0)
                tmpusuario.Clave = usuario(1)
                tmpusuario.Fec_Creacionclave = usuario(2)
                tmpusuario.Usuario_Bloqueado = usuario(3)
                tmpusuario.Intentos_Fallidos = usuario(4)
                tmpidioma.Idioma = usuario(5)
                tmpidioma.id_idioma = usuario(7)
                tmpusuario.Idioma = tmpidioma
                tmpusuario.id_usuario = usuario(6)
                tmpusuario.permiso_usuario = consultar_permisos_usuario(tmpusuario)
                listadepersonas.Add(tmpusuario)
            Next
            Return listadepersonas
        Catch ex As Exception
            Return listadepersonas
        End Try
    End Function

    Public Function consultartodos_existentes() As List(Of BE.BE_Usuario)
        Dim listadepersonas As New List(Of BE.BE_Usuario)
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            datatable = mapper_stores.consultar("consultartodos_usuarios", lista_parametros)
            For Each usuario As DataRow In datatable.Rows
                Dim tmpusuario As New BE.BE_Usuario
                Dim tmpidioma As New BE.BE_Idioma
                tmpusuario.Nombre_Usuario = usuario(0)
                tmpusuario.Clave = usuario(1)
                tmpusuario.Fec_Creacionclave = usuario(2)
                tmpusuario.Usuario_Bloqueado = usuario(3)
                tmpusuario.Intentos_Fallidos = usuario(4)
                tmpidioma.Idioma = usuario(5)
                tmpidioma.id_idioma = usuario(7)
                tmpusuario.Idioma = tmpidioma
                tmpusuario.id_usuario = usuario(6)
                tmpusuario.permiso_usuario = consultar_permisos_usuario(tmpusuario)
                listadepersonas.Add(tmpusuario)
            Next
            Return listadepersonas
        Catch ex As Exception
            Return listadepersonas
        End Try
    End Function
    ''' 
    ''' <param name="unbe"></param>
    Private Function elimino_permisos(ByVal unbe As BE.BE_Usuario) As Integer
        elimino_permisos = 0
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Usuario) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim stringconcatenado As String = ""
        Try
            Dim DDVVH As Integer
            stringconcatenado = unbe.Nombre_Usuario & unbe.Clave
            DDVVH = SEGURIDAD.Digito_Verificador.calculardigitoverificador(stringconcatenado)
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(9) As SqlParameter
            Dim modifica_usuario As New SqlCommand
            P(0) = sqlhelper.BuildParameter("@username", unbe.Nombre_Usuario)
            P(1) = sqlhelper.BuildParameter("@clave", unbe.Clave)
            P(2) = sqlhelper.BuildParameter("@fecha_creacion", unbe.Fec_Creacionclave)
            P(3) = sqlhelper.BuildParameter("@bloqueado", unbe.Usuario_Bloqueado)
            P(4) = sqlhelper.BuildParameter("@borrado", False)
            P(5) = sqlhelper.BuildParameter("@cantidadintentosfallidos", unbe.Intentos_Fallidos)
            P(6) = sqlhelper.BuildParameter("@id_idioma", unbe.Idioma.id_idioma)
            P(7) = sqlhelper.BuildParameter("@ddvvh", DDVVH)
            P(8) = sqlhelper.BuildParameter("@id_usuario", unbe.id_usuario)
            P(9) = sqlhelper.BuildParameter("@permiso_id", unbe.permiso_usuario.idpermiso)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("modificar_usuario", lista_parametros)
            SEGURIDAD.Digito_Verificador.calculardigitoverificadorvertical("Usuario")
            Return 2111
        Catch ex As Exception
            Return 2112
        End Try

    End Function
    Public Function modificar_idioma(ByVal unbe As BE.BE_Usuario) As Integer
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(1) As SqlParameter
            Dim modifica_usuario As New SqlCommand
            P(0) = sqlhelper.BuildParameter("@id_idioma", unbe.Idioma.id_idioma)
            P(1) = sqlhelper.BuildParameter("@id_usuario", unbe.id_usuario)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("modificar_usuario_idioma", lista_parametros)
            Return 10163
        Catch ex As Exception
            Return 10164
        End Try


    End Function
    ''' 
    ''' <param name="unbe"></param>
    Public Function validarunicousuario(ByVal unbe As BE.BE_Usuario) As Boolean
        Dim listadepersonas As New List(Of BE.BE_Usuario)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Try
            Dim datatable As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(0) As SqlParameter
            If unbe.id_usuario Is Nothing Then
                P(0) = sqlhelper.BuildParameter("@username", unbe.Nombre_Usuario)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("validarunicousuario_sinid", lista_parametros)
            Else
                ReDim P(1)
                P(0) = sqlhelper.BuildParameter("@username", unbe.Nombre_Usuario)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("validarunicousuario_conid", lista_parametros)
            End If
            If datatable.Rows.Count = 0 Then
                Return False
            Else
                Return True

            End If

        Catch ex As Exception
            Return 2000
        Finally

        End Try

    End Function


End Class ' DAL_Usuario


