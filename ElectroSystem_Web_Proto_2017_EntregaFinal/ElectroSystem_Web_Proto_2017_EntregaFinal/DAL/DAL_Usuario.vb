Imports System.Data.SqlClient
Imports System.Linq
Public Class DAL_Usuario
    Shared lista_usuarios As New List(Of BE.BE_Usuario)

    Public Sub New()
        Dim usuario As New BE.BE_Usuario
        Dim usuario1 As New BE.BE_Usuario
        Dim usuario2 As New BE.BE_Usuario
        usuario.Nombre_Usuario = "carlos2018"
        usuario.Clave = "pepe"
        usuario.Intentos_Fallidos = 0
        usuario1.Nombre_Usuario = "carlos2019"
        usuario1.Clave = "hola"
        usuario1.Intentos_Fallidos = 3
        usuario1.Usuario_Bloqueado = True
        usuario2.Nombre_Usuario = "carlos2020"
        usuario2.Clave = "pepe2"
        usuario2.Intentos_Fallidos = 2
        usuario2.Usuario_Bloqueado = False
        lista_usuarios.Add(usuario)
        lista_usuarios.Add(usuario1)
        lista_usuarios.Add(usuario2)
    End Sub

    Public m_SQLHelper As SEGURIDAD.SQLHelper
    Public m_BE_Usuario As BE.BE_Usuario
    Public m_Digito_Verificador As SEGURIDAD.Digito_Verificador

    ''' 
    ''' <param name="unbe"></param>
    Public Function actualizarintentosfallidosybloqueado(ByVal unbe As BE.BE_Usuario) As Boolean
        
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Usuario) As Boolean
        alta = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function asignar_permisos(ByVal unbe As BE.BE_Usuario) As Integer
        asignar_permisos = 0
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Usuario) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Usuario) As BE.BE_Usuario
        If lista_usuarios.Exists(Function(x) x.Nombre_Usuario = unbe.Nombre_Usuario) Then
            If lista_usuarios.Exists(Function(y) y.Nombre_Usuario = unbe.Nombre_Usuario And y.Clave = unbe.Clave) Then
                If lista_usuarios.Exists(Function(w) w.Nombre_Usuario = unbe.Nombre_Usuario And w.Clave = unbe.Clave And w.Usuario_Bloqueado = False) Then
                    unbe = lista_usuarios.Find(Function(x) x.Nombre_Usuario = unbe.Nombre_Usuario)
                    unbe.Intentos_Fallidos = 0
                    Return unbe
                Else
                    unbe = lista_usuarios.Find(Function(x) x.Nombre_Usuario = unbe.Nombre_Usuario)
                    unbe.nota = "Usuario Bloqueado"
                    Return unbe
                End If
            Else
                unbe = lista_usuarios.Find(Function(x) x.Nombre_Usuario = unbe.Nombre_Usuario)
                unbe.nota = "Contraseña Incorrecta"
                Return unbe
            End If
            Else
            unbe.nota = "Usuario y/o Contraseña Incorrecta"
                Return unbe
            End If
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Function consultar_permisos_usuario(ByVal unbe As BE.BE_Usuario) As BE.BE_PermisoBase
        consultar_permisos_usuario = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_Usuario)
        consultartodos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Function elimino_permisos(ByVal unbe As BE.BE_Usuario) As Integer
        elimino_permisos = 0
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Usuario) As Boolean
        modificar = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function validarunicousuario(ByVal unbe As BE.BE_Usuario) As Boolean
        validarunicousuario = False
    End Function


End Class ' DAL_Usuario


