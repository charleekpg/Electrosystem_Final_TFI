Imports System.Security.Cryptography
Imports System.IO
Public Class Criptografia
    Private TripleDes As New TripleDESCryptoServiceProvider
    Private key As String = "laClavees123"
    'ACA LE MANDO ESTO PARA PONERLE LA CLAVE QUE VOY A UTILIZAR, COMO LOS BLOQUES DEL ALGORITMO.
    Sub New()
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub


    'ACA SE ESPECIFICA EL BYTE ARRAY DEL HASH QUE TIENE LA CLAVE QUE PUSE ARRIBA.
    Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
        Dim sha1 As New SHA1CryptoServiceProvider
        Dim keyBytes() As Byte =
        System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)
        ReDim Preserve hash(length - 1)
        Return hash
    End Function

    'esto es para encriptar
    Public Function cifrar(ByVal texto As String) As String
        'aca convierto el texto en un array de bytes
        Dim plaintextBytes() As Byte =
        System.Text.Encoding.Unicode.GetBytes(texto)
        Dim ms As New System.IO.MemoryStream
        Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()
        Return Convert.ToBase64String(ms.ToArray)
    End Function

    Public Function descifrar(ByVal texto As String) As String

        Dim encryptedBytes() As Byte = Convert.FromBase64String(texto)
        Dim ms As New System.IO.MemoryStream
        Dim decStream As New CryptoStream(ms,
        TripleDes.CreateDecryptor(),
        System.Security.Cryptography.CryptoStreamMode.Write)
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function



    Public Function cifrar_viejo(ByVal algo As String) As String
        Dim i As Long = 1
        Dim ret As String
        ret = ""
        For i = 1 To Len(algo)
            ret = ret + Chr(Asc(Mid(algo, i, 1)) + 1)
        Next i
        Return ret

    End Function

    ''' 
    ''' <param name="algo"></param>
    Public Function descifrar_viejo(ByVal algo As String) As String
        Dim i As Long = 1
        Dim ret As String
        ret = ""
        For i = 1 To Len(algo)
            ret = ret + Chr(Asc(Mid(algo, i, 1)) - 1)
        Next i
        Return ret


    End Function


End Class ' Criptografia


