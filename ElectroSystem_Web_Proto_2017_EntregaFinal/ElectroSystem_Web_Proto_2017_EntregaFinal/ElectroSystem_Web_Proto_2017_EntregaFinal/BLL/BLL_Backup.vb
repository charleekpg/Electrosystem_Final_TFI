Imports System.IO
Public Class BLL_Backup

    Public m_DAL_Backup As DAL.DAL_Backup
    Public m_BE_Usuario As BE.BE_Usuario
    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_BE_Backup As BE.BE_Backup
    Public m_BLL_Bitacora As BLL.BLL_Bitacora

    ''' 
    Public Function hacerbackup() As Integer
        Try
            Dim unbe As New BE.BE_Backup
            unbe.nombre_backup = DateAndTime.Now.Day.ToString & "_" & DateAndTime.Now.Month.ToString & "_" & DateTime.Now.Year.ToString & "_" & DateTime.Now.Hour.ToString & DateTime.Now.Minute.ToString & DateTime.Now.Second.ToString & "_" & DateTime.Now.Millisecond.ToString & "_Electrosystem"
            unbe.directorio = "C:\Backups\"
            Dim seguridad As New DAL.DAL_Backup
            Return seguridad.hacerbackup(unbe)
        Catch ex As Exception
            Return 6000
        End Try

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function hacerrestore(ByVal unbe As BE.BE_Backup) As Integer
        Try
            Dim seguridad As New DAL.DAL_Backup
            Return SEGURIDAD.hacerrestore(unbe)
        Catch ex As Exception
            Return 6002
        End Try
    End Function

    Public Function listar_restore(ByVal unbe As BE.BE_Backup) As List(Of BE.BE_Backup)
        Try
            Dim listar As New DAL.DAL_Backup
            Return listar.listar_restore(unbe)
        Catch ex As Exception

        End Try

    End Function


End Class