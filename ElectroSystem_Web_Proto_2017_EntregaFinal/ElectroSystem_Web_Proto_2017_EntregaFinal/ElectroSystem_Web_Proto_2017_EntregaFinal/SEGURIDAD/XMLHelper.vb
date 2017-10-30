Imports System.Xml
Imports System.IO

Friend Class XmlHelper
    Private PathNew As String = ""
    Private FullPathNew As String = ""
    Public Function ReadFile(NodeName As String) As String
        Try
            Dim strConn As String = ""
            Dim Connections As XmlDocument = New XmlDocument()
            Connections.Load(FullPathNew)
            Dim ConnectionsNodo = Connections.DocumentElement
            For Each n As XmlNode In ConnectionsNodo
                If n.Attributes("Name").Value = NodeName Then
                    strConn = n.InnerText
                    Exit For
                End If
            Next
            Return strConn
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub New()
        'ver esto de path..no creo que este bien.
        PathNew = VerifyPath("Installation")
        FullPathNew = PathNew & "\Connections.xml"
    End Sub


    Private Function VerifyPath(Directorio As String) As String
        'ver esto de path..no creo que este bien.
        Dim PathX86 As String = "C:\ElectroSystem\"
        Dim Path As String = "C:\ElectroSystem\"
        Dim FullPath As String = ""
        If Directory.Exists(PathX86 & Directorio) Then
            FullPath = PathX86 + Directorio
        Else
            If Directory.Exists(Path & Directorio) Then
                FullPath = Path & Directorio
            End If
        End If
        Return FullPath
    End Function
End Class

