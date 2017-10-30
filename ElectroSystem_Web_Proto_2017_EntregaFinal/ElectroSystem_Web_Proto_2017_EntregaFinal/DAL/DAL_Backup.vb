Imports System.IO

Imports System.Data.SqlClient



	Public Class DAL_Backup
    Shared restores As New List(Of BE.BE_Backup)


    Public m_BE_Backup As BE.BE_Backup
    Public m_SQLHelper As Seguridad.SQLHelper

		''' 
		''' <param name="unbe"></param>
		Public Function hacerbackup(ByVal unbe As BE.BE_Backup) As Integer
        File.Create(unbe.directorio & unbe.nombre_backup)
        restores.Add(unbe)
        Return 1
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function hacerrestore(ByVal unbe As BE.BE_Backup) As Integer
        Return 2

    End Function

    Public Function listar_restore() As List(Of BE.BE_Backup)
        Return restores

    End Function


	End Class ' DAL_Backup


