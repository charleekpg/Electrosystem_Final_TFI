Public Class BLL_DigitoVerificador


    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_BLL_Bitacora As BLL.BLL_Bitacora
    Public m_Consistencia_BasedeDatos As Seguridad.Consistencia_BasedeDatos
    Public m_Digito_Verificador As Seguridad.Digito_Verificador

    Public Function comprobarconsistencia() As Boolean
        Try
            Dim objconsistencia As New SEGURIDAD.Consistencia_BasedeDatos
            If objconsistencia.Comprobar_Consistencia() = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function recalculardigitosverificadores() As Integer
        Try
            Dim objrecalculo As New SEGURIDAD.Consistencia_BasedeDatos
            Dim be_Bitacora As New BE.BE_Bitacora
            Dim bll_Bitacora As New BLL.BLL_Bitacora
            be_Bitacora.usuario = BE.BE_Usuario.usuariologueado
            Select Case objrecalculo.recalcular_digitos()
                Case False
                    be_Bitacora.codigo_evento = 3999
                    bll_Bitacora.alta(be_Bitacora)
                    Return 3999
                Case True
                    be_Bitacora.codigo_evento = 4000
                    bll_Bitacora.alta(be_Bitacora)
                    Return 4000
            End Select
        Catch ex As Exception
            Return 3999
        End Try


    End Function


End Class 