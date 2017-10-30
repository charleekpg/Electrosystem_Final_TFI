Imports System.IO
Public Class BLL_Backup

    Public m_DAL_Backup As DAL.DAL_Backup
    Public m_BE_Usuario As BE.BE_Usuario
    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_BE_Backup As BE.BE_Backup
    Public m_BLL_Bitacora As BLL.BLL_Bitacora

    ''' 
    ''' <param name="unbe"></param>
    Public Function hacerbackup(ByVal unbe As BE.BE_Backup) As Integer
        If unbe.nombre_backup = "" Then
            Return MsgBox("Esta Vacio")

        Else
            unbe.nombre_backup = unbe.nombre_backup & ".txt"
            If File.Exists(unbe.directorio & unbe.nombre_backup) Then
                Return MsgBox("Ya existe")
            Else

                Dim seguridad As New DAL.DAL_Backup
                Dim Bitacora As New BE.BE_Bitacora
                Dim bll_Bitacora As New BLL.BLL_Bitacora
                seguridad.hacerbackup(unbe)
                Return MsgBox("BackupCreadoOK")
            End If
        End If
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function hacerrestore(ByVal unbe As BE.BE_Backup) As Integer
        Dim seguridad As New DAL.DAL_Backup
        Return seguridad.hacerrestore(unbe)
    End Function

    Public Function listar_restore() As List(Of BE.BE_Backup)
        Dim listar As New DAL.DAL_Backup
        Return listar.listar_restore()
    End Function


End Class