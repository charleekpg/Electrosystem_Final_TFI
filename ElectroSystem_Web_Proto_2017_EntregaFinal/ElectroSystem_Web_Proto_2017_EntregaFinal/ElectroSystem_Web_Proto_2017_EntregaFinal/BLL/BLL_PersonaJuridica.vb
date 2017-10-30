Public Class BLL_PersonaJuridica


    Private dal_personajuridica As New DAL.DAL_PersonaJuridica
    Public m_DAL_Cliente As DAL.DAL_Cliente
    Public m_BE_Personajuridica As BE.BE_Personajuridica

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Personajuridica) As Integer
        Dim persona_juridica As New DAL.DAL_PersonaJuridica
        Dim Bitacora As New BE.BE_Bitacora
        Dim dal_cliente As New DAL.DAL_Cliente
        Dim bll_Bitacora As New BLL.BLL_Bitacora
        Dim dal_telefono As New DAL.DAL_Telefono
        Select Case dal_cliente.validaridentificador(CType(unbe, BE.BE_CLIENTE))
            Case 10119
                Return 10119
            Case 10120
                Return 10120
            Case 1
                Select Case dal_telefono.validartelefono(unbe.Telefonos)
                    Case 10121
                        Return 10121
                    Case 10122
                        Return 10122
                    Case 1
                        Select Case persona_juridica.alta(unbe)
                            Case 10124
                                Return 10124
                            Case 10120
                                Return 10120
                            Case 10126
                                Return 10126
                        End Select
                End Select
        End Select
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Personajuridica) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Personajuridica) As List(Of BE.BE_Personajuridica)
        Dim resultado As List(Of BE.BE_Personajuridica)
        Dim cliente As New DAL.DAL_Cliente
        Dim dal_personajuridica As New DAL.DAL_PersonaJuridica
        Dim Bitacora As New BE.BE_Bitacora
        Dim bll_Bitacora As New BLL.BLL_Bitacora
        resultado = dal_personajuridica.consultar(unbe)
        If resultado.Count <> 0 Then
            resultado.Item(0) = cliente.consultar_telefonos_cliente(resultado.Item(0))
            If resultado.Count > 0 Then
                For Each obj As BE.BE_Personajuridica In resultado
                    If Not obj.Referente Is Nothing Then
                        Dim bll_personafisica As New BLL.BLL_PersonaFisica
                        obj.Referente = bll_personafisica.consultar_contacto(obj.Referente)
                    End If
                Next
            End If
        End If
        Return resultado

    End Function

    Public Function consultartodos() As List(Of BE.BE_Personajuridica)
        consultartodos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Personajuridica) As Integer
        Dim persona_juridica As New DAL.DAL_PersonaJuridica
        Dim Bitacora As New BE.BE_Bitacora
        Dim dal_cliente As New DAL.DAL_Cliente
        Dim bll_Bitacora As New BLL.BLL_Bitacora
        Dim dal_telefono As New DAL.DAL_Telefono
        Select Case dal_cliente.validaridentificador(CType(unbe, BE.BE_CLIENTE))
            Case 10119
                Return 10119
            Case 10120
                Return 10120
            Case 1
                Select Case dal_telefono.validartelefono(unbe.Telefonos)
                    Case 10121
                        Return 10121
                    Case 10122
                        Return 10122
                    Case 1
                        Select Case persona_juridica.modificar(unbe)
                            Case 10136
                                Return 10136
                            Case 10134
                                Return 10134
                            Case 10126
                                Return 10126
                        End Select
                End Select
        End Select
    End Function


End Class ' BLL_PersonaJuridica


