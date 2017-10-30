

	Public Class bll_fichaBitacora


    Public Function consultartodos(unbe As BE.Be_Ficha_Bitacora) As List(Of BE.BE_Bitacora)
        Try
            Dim dal_fichaBitacora As New DAL.dal_fichaBitacora
            Dim bll_Bitacora As New BLL.BLL_Bitacora
            Dim listadeBitacora As List(Of BE.BE_Bitacora)
            listadeBitacora = dal_fichaBitacora.consultartodos(unbe)
            If listadeBitacora.Count > 0 Then
                For Each elemento As BE.BE_Bitacora In listadeBitacora
                    If Not elemento.usuario.Nombre_Usuario = "" Then
                        Dim seguridad As New SEGURIDAD.Criptografia
                        elemento.usuario.Nombre_Usuario = seguridad.descifrar(elemento.usuario.Nombre_Usuario)
                    End If
                Next
            End If
            Return listadeBitacora
        Catch ex As Exception

        End Try

    End Function
End Class ' bll_fichaBitacora


