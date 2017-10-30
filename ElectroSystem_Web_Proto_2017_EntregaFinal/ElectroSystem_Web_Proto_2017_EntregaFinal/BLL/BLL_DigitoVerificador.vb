Public Class BLL_DigitoVerificador


    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_BLL_Bitacora As BLL.BLL_Bitacora
    Public m_Consistencia_BasedeDatos As Seguridad.Consistencia_BasedeDatos
    Public m_Digito_Verificador As Seguridad.Digito_Verificador

    Public Function comprobarconsistencia() As Boolean
        comprobarconsistencia = False
    End Function

    Public Function recalculardigitosverificadores() As Integer
        recalculardigitosverificadores = 0
    End Function


End Class 