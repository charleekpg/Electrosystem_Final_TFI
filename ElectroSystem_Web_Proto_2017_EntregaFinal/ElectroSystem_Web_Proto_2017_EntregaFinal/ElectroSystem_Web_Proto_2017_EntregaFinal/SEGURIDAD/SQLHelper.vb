Imports System.Data.SqlClient


Public Class SQLHelper


    Private sqlconnexion As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConexionNegocio").ConnectionString)
    Private sqlconexionmaster As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConexionMaster").ConnectionString)
   

  
    Public Function abrirconexion()

        If sqlconnexion Is Nothing Then
            sqlconnexion = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConexionNegocio").ConnectionString)
        End If
        If sqlconnexion.State = ConnectionState.Closed Then
            sqlconnexion.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConexionNegocio").ConnectionString
        End If
        Return sqlconnexion

    End Function

    Public Sub cerrarconexion()
        If Not sqlconnexion Is Nothing Then
            If sqlconnexion.State = ConnectionState.Open Then
                sqlconnexion.Close()
            End If
            sqlconnexion.Dispose()
        End If
    End Sub


    Public Function abrirconexionmaster()

        If sqlconnexion Is Nothing Then
            sqlconnexion = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConexionMaster").ConnectionString)
        End If
        If sqlconnexion.State = ConnectionState.Closed Then
            ' esto hay que cambiarlo despues... 'con strcon
            sqlconnexion.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConexionMaster").ConnectionString
            'sqlconnexion.Open()
        End If
        Return sqlconnexion
    End Function

    Public Sub cerrarconexionmaster()
        If Not sqlconexionmaster Is Nothing Then

            If sqlconexionmaster.State = ConnectionState.Open Then
                sqlconexionmaster.Close()
            End If
            sqlconexionmaster.Dispose()
        End If

    End Sub

    Public Function BuildParameter(Name As String, value As Integer?) As SqlParameter
        Dim par As New SqlParameter()
        par.ParameterName = Name
        par.DbType = DbType.Int32
        If value Is Nothing Then
            par.Value = DBNull.Value
        Else
            par.Value = value
        End If
        Return par
    End Function

    Public Function BuildParameter(Name As String, value As Integer) As SqlParameter
        Dim par As New SqlParameter()
        par.ParameterName = Name
        par.DbType = DbType.Int32
        par.Value = value
        Return par
    End Function


    Public Function BuildParameter(Name As String, value As String) As SqlParameter
        Dim par As New SqlParameter()
        If Not value Is Nothing Then
            par.ParameterName = Name
            par.DbType = DbType.String
            par.Value = value
        Else
            par.ParameterName = Name
            par.DbType = DbType.String
            par.Value = ""
        End If
        Return par
    End Function

    Public Function BuildParameter(Name As String, value As DBNull) As SqlParameter
        Dim par As New SqlParameter()
        par.ParameterName = Name
        par.DbType = DbType.Int16
        par.Value = value
        Return par
    End Function

    Public Function BuildParameter(Name As String, value As Decimal) As SqlParameter
        Dim par As New SqlParameter()
        par.ParameterName = Name
        par.DbType = DbType.Decimal
        par.Value = value
        Return par
    End Function
    Public Function BuildParameter(Name As String, value As Single) As SqlParameter
        Dim par As New SqlParameter()
        par.ParameterName = Name
        par.DbType = DbType.Single
        par.Value = value
        Return par
    End Function
    Public Function BuildParameter(Name As String, value As Boolean) As SqlParameter
        Dim par As New SqlParameter()
        par.ParameterName = Name
        par.DbType = DbType.Boolean
        par.Value = value
        Return par
    End Function

    Public Function BuildParameter(Name As String, value As Date?) As SqlParameter
        Dim par As New SqlParameter()
        par.ParameterName = Name
        par.DbType = DbType.DateTime
        If value Is Nothing Then
            par.Value = DBNull.Value
        Else
            par.Value = value
        End If
        Return par
    End Function

    Public Function BuildParameter(Name As String, value As Date) As SqlParameter
        Dim par As New SqlParameter()
        par.ParameterName = Name
        par.DbType = DbType.DateTime
        par.Value = value
        Return par
    End Function

End Class ' SQLHelper


