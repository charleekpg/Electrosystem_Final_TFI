Public Class BLL_Bitacora


    Public m_Criptografia As Seguridad.Criptografia
    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_DAL_Bitacora As DAL.DAL_Bitacora

    Public Function alta(ByVal unbe As BE.BE_Bitacora) As Boolean

        Dim dal_Bitacora As New DAL.DAL_Bitacora
        Try
            unbe.informacion_adicional = unbe.usuario.Nombre_Usuario
            unbe.fecha_hora = Now
            dal_Bitacora.alta(unbe)
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function

    Public Function consultar(ByVal unbe As BE.BE_Bitacora) As BE.BE_Bitacora
        consultar = Nothing
    End Function

    Public Function consultarcodigodeevento() As List(Of BE.BE_Bitacora)
        Try
            Dim dal_Bitacora As New DAL.DAL_Bitacora
            Dim lista_bitacora As New List(Of BE.BE_Bitacora)
            lista_bitacora = dal_Bitacora.consultarcodigodeevento()
            Return lista_bitacora
        Catch ex As Exception

        End Try

    End Function

    Public Function consultartodos() As List(Of BE.BE_Bitacora)
        consultartodos = Nothing
    End Function

End Class ' BLL_Bitacora

