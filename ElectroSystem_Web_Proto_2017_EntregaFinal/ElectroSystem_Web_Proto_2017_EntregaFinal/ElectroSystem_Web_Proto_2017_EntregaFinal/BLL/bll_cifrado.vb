Public Class bll_cifrado
    Function cifrar(unbe As BE.BE_Cifrado) As BE.BE_Cifrado
        Dim cifrado As New SEGURIDAD.Criptografia
        unbe.texto = cifrado.cifrar(unbe.texto)
        Return unbe

    End Function

    Function descifrar(unbe As BE.BE_Cifrado) As BE.BE_Cifrado
        Dim descifrado As New SEGURIDAD.Criptografia
        unbe.texto = descifrado.descifrar(unbe.texto)
        Return unbe
    End Function

    Function calculardigitoverificador(unbe As BE.BE_Cifrado) As BE.BE_Cifrado
        unbe.digito = SEGURIDAD.Digito_Verificador.calculardigitoverificador(unbe.texto)
        Return unbe
    End Function

End Class
