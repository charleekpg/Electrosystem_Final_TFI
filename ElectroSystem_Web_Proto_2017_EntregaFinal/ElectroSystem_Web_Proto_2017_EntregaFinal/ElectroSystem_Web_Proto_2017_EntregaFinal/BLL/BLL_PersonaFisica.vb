
	Public Class BLL_PersonaFisica


		Private dal_personafisica As New DAL.DAL_PersonaFisica
    Public m_BE_Personafisica As BE.BE_Personafisica
		Public m_DAL_Cliente As DAL.DAL_Cliente

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Personafisica) As Integer
        Dim persona_fisica As New DAL.DAL_PersonaFisica
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
                        Select Case persona_fisica.alta(unbe)
                            Case 10123
                                Return 10123
                            Case 10120
                                Return 10120
                            Case 10125
                                Return 10125
                        End Select
                End Select
        End Select
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Personafisica) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Personafisica) As List(Of BE.BE_Personafisica)
        Dim resultado As List(Of BE.BE_Personafisica)
        Dim cliente As New DAL.DAL_Cliente
        Dim Bitacora As New BE.BE_Bitacora
        Dim telefono As New DAL.DAL_Telefono
        Dim bll_Bitacora As New BLL.BLL_Bitacora
        resultado = dal_personafisica.consultar(unbe)
        If Not resultado.Count = 0 Then
            resultado.Item(0) = cliente.consultar_telefonos_cliente(resultado.Item(0))
        End If
        Return resultado
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar_contacto(ByVal unbe As BE.BE_Personafisica) As BE.BE_Personafisica
        Return dal_personafisica.consultar_contacto(unbe)
    End Function

    Public Function consultartodos() As List(Of BE.BE_Personafisica)
        consultartodos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Personafisica) As Integer
        Dim persona_fisica As New DAL.DAL_PersonaFisica
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
                        Select Case persona_fisica.modificar(unbe)
                            Case 10135
                                Return 10135
                            Case 10125
                                Return 10125
                            Case 10134
                                Return 10134
                        End Select
                End Select
        End Select

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Sub validaridenti(ByVal unbe As BE.BE_Personafisica)

		End Sub


	End Class ' BLL_PersonaFisica


