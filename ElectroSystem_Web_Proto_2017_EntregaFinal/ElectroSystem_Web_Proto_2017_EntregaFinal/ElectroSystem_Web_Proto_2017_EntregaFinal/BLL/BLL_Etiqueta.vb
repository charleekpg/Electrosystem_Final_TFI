






Public Class BLL_Etiqueta


    Public Function alta(unbe As BE.BE_Idioma) As Integer
        Dim dal_etiqueta As New DAL.DAL_Etiqueta
        Try
            Return dal_etiqueta.alta(unbe)
        Catch ex As Exception
            Return 2
        End Try

    End Function

    Public Function baja(unbe As BE.BE_Idioma) As Integer
        Dim dal_etiqueta As New DAL.DAL_Etiqueta
        Try
            Return dal_etiqueta.baja(unbe)
        Catch ex As Exception
            Return 2
        End Try
    End Function

    Public Function modificar(unbe As BE.BE_Idioma) As Integer
        Dim dal_etiqueta As New DAL.DAL_Etiqueta
        Try
            Return dal_etiqueta.modificar(unbe)
        Catch ex As Exception
            Return 2
        End Try
    End Function

    Public Sub cambiaridioma()

    End Sub

    Public Function consultar_todos() As List(Of BE.BE_Etiqueta)
        consultar_todos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function leer(ByVal unbe As BE.BE_Etiqueta) As BE.BE_Etiqueta
        Dim etiqueta As New DAL.DAL_Etiqueta()
        Return etiqueta.Leer(unbe)
    End Function


End Class 
