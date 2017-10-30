
Imports System.Text.RegularExpressions

Public Class BLL_Usuario

    Private dal_usuario As New DAL.DAL_Usuario

    Public Function alta(ByVal unbe As BE.BE_Usuario) As Integer
        Dim cifrado As New SEGURIDAD.Criptografia
        unbe.Fec_Creacionclave = Format(CDate(Today.Date), "yyyy-MM-dd")
        Select Case Me.validarformato(unbe)
            Case 2108
                Return 2108
            Case 2113
                Return 2113
            Case True
                Return 2007
            Case 2000
                Return 2000
            Case False
                unbe.Usuario_Bloqueado = False
                unbe.Intentos_Fallidos = 0
                unbe.Nombre_Usuario = cifrado.cifrar(unbe.Nombre_Usuario)
                unbe.Clave = cifrado.cifrar(unbe.Clave)
                Select Case dal_usuario.alta(unbe)
                    Case True
                        Return 2109
                    Case False
                        Return 2110
                End Select
        End Select
    End Function
    Public Sub asignar_permisos(ByVal unbe As BE.BE_Usuario)

    End Sub

    Public Function baja(ByVal unbe As BE.BE_Usuario) As Boolean
        Return dal_usuario.baja(unbe)
    End Function

    Public Function cambiar_contraseña(ByVal unbe As BE.BE_Usuario) As Integer
        Dim cifrado As New SEGURIDAD.Criptografia
        Select Case validarformato(unbe)
            Case 2113
                Return 2107
            Case Else
                unbe.Fec_Creacionclave = Format(CDate(Today.Date), "yyyy-MM-dd")
                unbe.Nombre_Usuario = cifrado.cifrar(unbe.Nombre_Usuario)
                unbe.Clave = cifrado.cifrar(unbe.Clave)
                Select Case dal_usuario.modificar(unbe)
                    Case 2112
                        Return 2105
                    Case 2111
                        unbe.Nombre_Usuario = cifrado.descifrar(unbe.Nombre_Usuario)
                        unbe.Clave = cifrado.descifrar(unbe.Clave)
                        Return 2106
                End Select
        End Select
    End Function

    Public Function modificar_idioma(ByVal unbe As BE.BE_Usuario) As Integer
        Dim dal_usuario As New DAL.DAL_Usuario
        Return dal_usuario.modificar_idioma(unbe)
    End Function
    Public Sub cerrar_sesion()

		End Sub

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Usuario) As BE.BE_Usuario
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_Usuario)
        Try
            Dim listausuario As List(Of BE.BE_Usuario)
            Dim bll_permiso As New BLL.BLL_Permisos
            listausuario = dal_usuario.consultartodos()
            For Each elemento As BE.BE_Usuario In listausuario
                If Not elemento.Nombre_Usuario = "" Then
                    Dim seguridad As New SEGURIDAD.Criptografia
                    elemento.Nombre_Usuario = seguridad.descifrar(elemento.Nombre_Usuario)
                    elemento.Clave = seguridad.descifrar(elemento.Clave)
                    If Not elemento.permiso_usuario Is Nothing Then
                        elemento.permiso_usuario = bll_permiso.consultar_permiso(elemento.permiso_usuario)
                    End If
                End If
            Next
            Return listausuario

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function consultartodos_existentes() As List(Of BE.BE_Usuario)
        Try
            Dim listausuario As List(Of BE.BE_Usuario)
            Dim bll_permiso As New BLL.BLL_Permisos
            listausuario = dal_usuario.consultartodos_existentes()
            For Each elemento As BE.BE_Usuario In listausuario
                If Not elemento.Nombre_Usuario = "" Then
                    Dim seguridad As New SEGURIDAD.Criptografia
                    elemento.Nombre_Usuario = seguridad.descifrar(elemento.Nombre_Usuario)
                    elemento.Clave = seguridad.descifrar(elemento.Clave)
                    If Not elemento.permiso_usuario Is Nothing Then
                        elemento.permiso_usuario = bll_permiso.consultar_permiso(elemento.permiso_usuario)
                    End If
                End If
            Next
            Return listausuario

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ''' 
    ''' <param name="usuario_tmp"></param>
    Private Function intentosfallidos(ByVal usuario_tmp As BE.BE_Usuario) As Boolean
        Try
            usuario_tmp.Intentos_Fallidos = usuario_tmp.Intentos_Fallidos + 1
            If usuario_tmp.Intentos_Fallidos >= 3 Then
                usuario_tmp.Usuario_Bloqueado = True
                If dal_usuario.actualizarintentosfallidosybloqueado(usuario_tmp) Then
                Else
                    Return False
                End If
            Else
                If dal_usuario.actualizarintentosfallidosybloqueado(usuario_tmp) = True Then
                    Return True
                Else
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function limpiar_sesion() As Integer
        limpiar_sesion = 0
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function loguear_usuario(ByVal unbe As BE.BE_Usuario) As Integer
        Try
            Dim dal_usuario As New DAL.DAL_Usuario
            Dim cifrado As New SEGURIDAD.Criptografia
            Dim be_Bitacora As New BE.BE_Bitacora
            Dim bll_Bitacora As New BLL.BLL_Bitacora
            Dim usuario_login As BE.BE_Usuario
            unbe.Nombre_Usuario = cifrado.cifrar(unbe.Nombre_Usuario)
            unbe.Clave = cifrado.cifrar(unbe.Clave)
            usuario_login = dal_usuario.consultar(unbe)
            usuario_login.ip = unbe.ip
            If usuario_login.nota = "Usuario y/o Contraseña Incorrecta" Then
                unbe.Nombre_Usuario = cifrado.descifrar(unbe.Nombre_Usuario)
                be_Bitacora.usuario = unbe
                be_Bitacora.informacion_adicional = unbe.Nombre_Usuario
                be_Bitacora.codigo_evento = 2100
                bll_Bitacora.alta(be_Bitacora)
                Return 2100
            Else
                If usuario_login.nota = "Contraseña Incorrecta" Then
                    usuario_login.Nombre_Usuario = unbe.Nombre_Usuario
                    Me.intentosfallidos(usuario_login)
                    usuario_login.Nombre_Usuario = cifrado.descifrar(unbe.Nombre_Usuario)
                    usuario_login.ip = unbe.ip
                    be_Bitacora.usuario = usuario_login
                    be_Bitacora.codigo_evento = 2101
                    bll_Bitacora.alta(be_Bitacora)
                    Return 2101
                Else
                    If usuario_login.Usuario_Bloqueado = True Then
                        usuario_login.Nombre_Usuario = cifrado.descifrar(unbe.Nombre_Usuario)
                        usuario_login.Clave = cifrado.descifrar(unbe.Clave)
                        be_Bitacora.usuario = usuario_login
                        be_Bitacora.codigo_evento = 2102
                        bll_Bitacora.alta(be_Bitacora)
                        Return 2102
                    Else
                        If usuario_login.nota = "Fallo" Then
                            Return 211
                        Else
                            Dim bll_comprobarconsistencia As New BLL.BLL_DigitoVerificador
                            If bll_comprobarconsistencia.comprobarconsistencia() = False Then
                                Return 210
                            Else
                                unbe.Intentos_Fallidos = 0
                                If dal_usuario.actualizarintentosfallidosybloqueado(unbe) = True Then
                                    unbe.Nombre_Usuario = cifrado.descifrar(unbe.Nombre_Usuario)
                                    unbe.Clave = cifrado.descifrar(unbe.Clave)
                                    unbe.nota = ""
                                    unbe.Fec_Creacionclave = usuario_login.Fec_Creacionclave
                                    unbe.Usuario_Bloqueado = usuario_login.Usuario_Bloqueado
                                    unbe.id_usuario = usuario_login.id_usuario
                                    unbe.Idioma = usuario_login.Idioma
                                    unbe.permiso_usuario = usuario_login.permiso_usuario
                                    be_Bitacora.usuario = unbe
                                    be_Bitacora.codigo_evento = 2103
                                    bll_Bitacora.alta(be_Bitacora)
                                    Return 2103
                                Else
                                    unbe.Nombre_Usuario = cifrado.descifrar(unbe.Nombre_Usuario)
                                    be_Bitacora.usuario = unbe
                                    be_Bitacora.codigo_evento = 211
                                    bll_Bitacora.alta(be_Bitacora)
                                    Return 211
                                End If
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Return 211
        End Try

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Usuario) As Integer
        Dim cifrado As New SEGURIDAD.Criptografia
        Select Case Me.validarformato(unbe)
            Case 2108
                Return 2108
            Case 2113
                Return 2113
            Case True
                Return 2007
            Case 2000
                Return 2000
            Case false
                unbe.Intentos_Fallidos = 0
                unbe.Nombre_Usuario = cifrado.cifrar(unbe.Nombre_Usuario)
                unbe.Clave = cifrado.cifrar(unbe.Clave)
                Select Case dal_usuario.modificar(unbe)
                    Case 2111
                        Return 2111
                    Case 2112
                        Return 2112
                End Select
        End Select
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function validarformato(ByVal unbe As BE.BE_Usuario) As Integer
        Dim cifrado As New SEGURIDAD.Criptografia
        Dim regexusuario As New Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")
        Dim regexpass As New Regex("(?=^.{8,12}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$")
        Dim dal_usuario As New DAL.DAL_Usuario
        If regexusuario.IsMatch(unbe.Nombre_Usuario) = False Then
            Return 2108
        Else
            If regexpass.IsMatch(unbe.Clave) = False Then
                Return 2113
            Else
                unbe.Nombre_Usuario = cifrado.cifrar(unbe.Nombre_Usuario)
                Select Case dal_usuario.validarunicousuario(unbe)
                    Case True
                        unbe.Nombre_Usuario = cifrado.descifrar(unbe.Nombre_Usuario)
                        Return True
                    Case False
                        unbe.Nombre_Usuario = cifrado.descifrar(unbe.Nombre_Usuario)
                        Return False
                    Case 2000
                        unbe.Nombre_Usuario = cifrado.descifrar(unbe.Nombre_Usuario)
                        Return 2000
                End Select
            End If
        End If
        Return True
    End Function


End Class ' BLL_Usuario


