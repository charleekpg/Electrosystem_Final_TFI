Imports System.Data.SqlClient


Public Class SQLHelper


    ''' <summary>
    ''' Private sqlconnexion As New SqlConnection("Data Source=NOTENGO\SQLEXPRESS;
    ''' Initial Catalog=ElectroSystem_DB;Integrated Security=True") Private
    ''' sqlconexionmaster As New SqlConnection("Data Source=NOTENGO\SQLEXPRESS;Initial
    ''' Catalog=Master;Integrated Security=True")
    ''' </summary>
    Private sqlconexionmaster As SqlConnection = Nothing
    Private sqlconnexion As SqlConnection = Nothing
    Private strCon As String = ""
    Private strMas As String = ""

    Public Sub abrirconexion()

    End Sub

    Public Sub abrirconexionmaster()

    End Sub

    ''' 
    ''' <param name="Name"></param>
    ''' <param name="value"></param>
    Public Function BuildParameter(ByVal Name As String, ByVal value As Integer?) As SqlParameter
        BuildParameter = Nothing
    End Function

    ''' 
    ''' <param name="Name"></param>
    ''' <param name="value"></param>
    Public Function BuildParameter(ByVal Name As String, ByVal value As Integer) As SqlParameter
        BuildParameter = Nothing
    End Function

    ''' 
    ''' <param name="Name"></param>
    ''' <param name="value"></param>
    Public Function BuildParameter(ByVal Name As String, ByVal value As String) As SqlParameter
        BuildParameter = Nothing
    End Function

    ''' 
    ''' <param name="Name"></param>
    ''' <param name="value"></param>
    Public Function BuildParameter(ByVal Name As String, ByVal value As DBNull) As SqlParameter
        BuildParameter = Nothing
    End Function

    ''' 
    ''' <param name="Name"></param>
    ''' <param name="value"></param>
    Public Function BuildParameter(ByVal Name As String, ByVal value As Decimal) As SqlParameter
        BuildParameter = Nothing
    End Function

    ''' 
    ''' <param name="Name"></param>
    ''' <param name="value"></param>
    Public Function BuildParameter(ByVal Name As String, ByVal value As Single) As SqlParameter
        BuildParameter = Nothing
    End Function

    ''' 
    ''' <param name="Name"></param>
    ''' <param name="value"></param>
    Public Function BuildParameter(ByVal Name As String, ByVal value As Boolean) As SqlParameter
        BuildParameter = Nothing
    End Function

    ''' 
    ''' <param name="Name"></param>
    ''' <param name="value"></param>
    Public Function BuildParameter(ByVal Name As String, ByVal value As Date?) As SqlParameter
        BuildParameter = Nothing
    End Function

    ''' 
    ''' <param name="Name"></param>
    ''' <param name="value"></param>
    Public Function BuildParameter(ByVal Name As String, ByVal value As Date) As SqlParameter
        BuildParameter = Nothing
    End Function

    Public Sub cerrarconexion()

    End Sub

    Public Sub cerrarconexionmaster()

    End Sub

    Public Sub givemeconnection()

    End Sub

    Public Sub New()

    End Sub


End Class ' SQLHelper


