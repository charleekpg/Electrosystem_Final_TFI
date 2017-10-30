
Public Class Consistencia_BasedeDatos

    Public Function Comprobar_Consistencia() As Boolean
        Try
            Dim tablas As New List(Of String)
            Dim archivo As String = "\log.txt"
            Dim filaconerror As Integer = 0
            tablas.Add("Bitacora")
            tablas.Add("usuario")
            For Each tabla In tablas
                filaconerror = Digito_Verificador.buscarfilaconerror(tabla)
                If filaconerror > 0 Then
                    Dim texto As String = Now.ToString & " Existe una inconsistencia de Datos en la Tabla: " & tabla & " en la fila: " & filaconerror.ToString
                    Dim sw As New System.IO.StreamWriter(My.Computer.FileSystem.CurrentDirectory & archivo, True)
                    sw.WriteLine(texto)
                    sw.Close()
                    Return False
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function recalcular_digitos() As Boolean

        Dim tablas As New List(Of String)
        Dim filaconerror As Integer = 0
        tablas.Add("Bitacora")
        tablas.Add("usuario")
        For Each tabla In tablas
            Try
                Select Case Digito_Verificador.recalcular_digitos(tabla)
                    Case False
                        Return False
                End Select
            Catch ex As Exception
                Return False
            End Try
        Next
        Return True
    End Function


End Class

