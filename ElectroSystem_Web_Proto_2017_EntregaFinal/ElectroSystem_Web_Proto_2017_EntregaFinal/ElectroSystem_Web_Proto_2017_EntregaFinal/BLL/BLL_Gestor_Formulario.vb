


Public Class BLL_Gestor_Formulario


    Public m_BLL_Permisos As BLL.BLL_Permisos
    Public m_BE_Etiqueta As BE.BE_Etiqueta
    Public m_DAL_Etiqueta As DAL.DAL_Etiqueta
    Public m_BLL_Etiqueta As BLL.BLL_Etiqueta

    Public Function DIGITOS_VERIFICADORES(ByVal mensaje As String) As Boolean
        DIGITOS_VERIFICADORES = False
    End Function


    Function consultar_idiomas() As List(Of BE.BE_Idioma)
        Try
            Dim lista_idioma As List(Of BE.BE_Idioma)
            Dim etiqueta As New DAL.DAL_Etiqueta
            lista_idioma = etiqueta.consultar_idiomas()
            Return lista_idioma
        Catch ex As Exception
            Dim lista As New List(Of BE.BE_Idioma)
            Return lista
        End Try

    End Function




End Class ' 


