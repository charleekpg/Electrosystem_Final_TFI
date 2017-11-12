Imports System.IO

Imports System.Data.SqlClient



Public Class DAL_Backup
    Public m_BE_Backup As BE.BE_Backup
    Public m_SQLHelper As SEGURIDAD.SQLHelper
    Public Function hacerbackup(ByVal unbe As BE.BE_Backup) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Dim lista_parametros As New List(Of SqlParameter)
        Dim P(0) As SqlParameter
        Try
            Dim sqlcomando As New SqlCommand
            Dim string_disco As String = unbe.directorio & unbe.nombre_backup & ".bak"
            Dim Per As New System.Security.Permissions.FileIOPermission(Security.Permissions.PermissionState.Unrestricted, unbe.directorio)
            Per.Demand()
            P(0) = sqlhelper.BuildParameter("@nombre_backup", string_disco)
            lista_parametros.AddRange(P)
            If mapper_stores.insertar_eliminar_modificar("hacerbackup", lista_parametros) = True Then
                Return 6001
            Else
                Return 6000
            End If
        Catch ex As Exception
            Return 6000
        End Try
    End Function

    Public Function hacerrestore(ByVal unbe As BE.BE_Backup) As Integer
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Dim lista_parametros As New List(Of SqlParameter)
        Dim string_disco As String = "C:\" & unbe.directorio & "\" & unbe.nombre_backup
        Try
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@p1", string_disco)
            lista_parametros.AddRange(P)
            If mapper_stores.insertar_eliminar_modificar("hacerrestore", lista_parametros) = True Then
                Return 6003
            Else
                Return 6002
            End If
        Catch ex As Exception
            Return 6002

        End Try


    End Function

    Public Function listar_restore(ByVal unbe As BE.BE_Backup) As List(Of BE.BE_Backup)
        Try
            Dim folder As New DirectoryInfo(unbe.directorio)
            Dim lista_backups As New List(Of BE.BE_Backup)
            For Each file As FileInfo In folder.GetFiles()
                If file.Extension = ".bak" Then
                    Dim tmp_backup As New BE.BE_Backup
                    tmp_backup.nombre_backup = file.Name
                    tmp_backup.directorio = file.Directory.Name
                    lista_backups.Add(tmp_backup)
                End If
            Next
            Return lista_backups
        Catch ex As Exception
            Dim lista_backups As New List(Of BE.BE_Backup)
            Return lista_backups
        End Try

    End Function


End Class


