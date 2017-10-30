Public Class BLL_BocaMercado


    Public Shared bocamercado As BE.BE_BocaMercado
    Public m_BLL_Bitacora As BLL.BLL_Bitacora
    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_DAL_BocaMercado As DAL.DAL_BocaMercado

    ''' 
    ''' <param name="unbe"></param>
    Public Function calcularbocaempresa(ByVal unbe As BE.BE_BocaMercado) As BE.BE_BocaMercado
        Try
            Dim bocaempresa As New BE.BE_BocaMercado
            Dim dal_boca As New DAL.DAL_BocaMercado
            bocaempresa.precio_bocamercado = unbe.precio_bocamercado * 1.125
            Return bocaempresa
        Catch ex As Exception

        End Try

    End Function


    ''' 
    ''' <param name="unbe"></param>
    Public Function calcularbocaextraordinaria(ByVal unbe As BE.BE_BocaMercado) As BE.BE_BocaMercado
        Try
            Dim bocaextraordinaria As New BE.BE_BocaMercado
            Dim dal_boca As New DAL.DAL_BocaMercado
            bocaextraordinaria.precio_bocamercado = unbe.precio_bocamercado * 1.25
            Return bocaextraordinaria
        Catch ex As Exception

        End Try

    End Function


    Public Function consultartodos() As List(Of BE.BE_BocaMercado)
        Try
            Dim dal_bocamercado As New DAL.DAL_BocaMercado
            Return dal_bocamercado.consultartodos()
        Catch ex As Exception

        End Try


    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(unbe As BE.BE_BocaMercado) As Integer
        Try
            Dim dal_bocamercado As New DAL.DAL_BocaMercado
            Dim Bitacora As New BE.BE_Bitacora
            Dim bll_Bitacora As New BLL.BLL_Bitacora
            If dal_bocamercado.modificar(unbe) = True Then
                Return 10101
            Else
                Return 10102
            End If
        Catch ex As Exception

        End Try


    End Function

End Class 