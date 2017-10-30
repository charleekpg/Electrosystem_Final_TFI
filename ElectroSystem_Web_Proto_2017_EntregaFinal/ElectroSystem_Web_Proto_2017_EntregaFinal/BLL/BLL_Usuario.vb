

	Public Class BLL_Usuario


		Private dal_usuario As New DAL.DAL_Usuario
    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_BE_Usuario As BE.BE_Usuario
		Public m_Criptografia As Seguridad.Criptografia
		Public m_BLL_Bitacora As BLL.BLL_Bitacora

		''' 
		''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Usuario) As Boolean
        alta = False
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Sub asignar_permisos(ByVal unbe As BE.BE_Usuario)

		End Sub

		''' 
		''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Usuario) As Boolean
        baja = False
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function cambiar_contraseña(ByVal unbe As BE.BE_Usuario) As Integer
			cambiar_contraseña = 0
		End Function

		Public Sub cerrar_sesion()

		End Sub

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Usuario) As BE.BE_Usuario
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_Usuario)
        consultartodos = Nothing
    End Function

		''' 
		''' <param name="usuario_tmp"></param>
		Private Function intentosfallidos(ByVal usuario_tmp As BE.BE_Usuario) As Boolean
        usuario_tmp.Intentos_Fallidos = usuario_tmp.Intentos_Fallidos + 1
        If usuario_tmp.Intentos_Fallidos >= 3 Then
            dal_usuario.actualizarintentosfallidosybloqueado(usuario_tmp)
            usuario_tmp.Usuario_Bloqueado = True
        Else
            dal_usuario.actualizarintentosfallidosybloqueado(usuario_tmp)
        End If
		End Function

    Public Function limpiar_sesion() As Integer
        limpiar_sesion = 0
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function loguear_usuario(ByVal unbe As BE.BE_Usuario) As Integer
        Dim dal_usuario As New DAL.DAL_Usuario
        Dim usuario_login As BE.BE_Usuario
        usuario_login = dal_usuario.consultar(unbe)
        If usuario_login.nota = "Usuario y/o Contraseña Incorrecta" Then
            usuario_login.nota = ""
            Return MsgBox("Usuario y/o Contraseña Incorrecta")
        Else
            If usuario_login.nota = "Contraseña Incorrecta" Then
                Me.intentosfallidos(usuario_login)
                usuario_login.nota = ""
                Return MsgBox("Contraseña Incorrecta. Intento fallido:" & usuario_login.Intentos_Fallidos)
            Else
                If usuario_login.Usuario_Bloqueado = True Then
                    usuario_login.nota = ""
                    Return MsgBox("Usuario Bloqueado")
                Else
                    usuario_login.Intentos_Fallidos = 0
                    dal_usuario.actualizarintentosfallidosybloqueado(usuario_login)
                    usuario_login.nota = ""
                    Return MsgBox("LOGIN EXITOSO")
                End If
            End If
        End If
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Usuario) As Boolean
        modificar = False
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Function validarformato(ByVal unbe As BE.BE_Usuario) As Integer
			validarformato = 0
		End Function


	End Class ' BLL_Usuario


