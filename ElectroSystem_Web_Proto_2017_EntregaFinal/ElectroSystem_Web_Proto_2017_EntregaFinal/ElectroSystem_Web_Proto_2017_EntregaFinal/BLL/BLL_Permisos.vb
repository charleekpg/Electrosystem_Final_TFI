

Public Class BLL_Permisos

    Public Function alta(ByVal unbe As BE.BE_Permisocompuesto) As Integer
        Dim dal_familia As New DAL.DAL_Permisos
        Select Case Me.validar_familia(unbe)
            Case 1999
                Return 1999
            Case False
                Return 1998
            Case True
                Select Case dal_familia.alta(unbe)
                    Case 1997
                        Return 1997
                    Case 1996
                        Return 1996
                End Select
        End Select
    End Function

    Public Function listar_permisossimples() As List(Of BE.BE_Patente)
        Dim dal_patente As New DAL.DAL_Permisos
        Return dal_patente.listar_permisossimples()
    End Function

    Public Function listar_permisoscompuestos() As List(Of BE.BE_Permisocompuesto)
        Dim dal_patente As New DAL.DAL_Permisos
        Return dal_patente.listar_permisoscompuestos()
    End Function


    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Permisocompuesto) As Integer
        Dim dal_permisocompuesto As New DAL.DAL_Permisos
        Return dal_permisocompuesto.baja(unbe)
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Sub consultar(ByVal unbe As Type)

    End Sub

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar_permiso(ByVal unbe As BE.BE_PermisoBase) As BE.BE_PermisoBase
        Dim dal_permisos As New DAL.DAL_Permisos
        Dim permiso As BE.BE_PermisoBase
        permiso = dal_permisos.consultar_permisos(unbe)
        Return permiso
    End Function
    Public Function consultartodos() As List(Of Type)
        consultartodos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Sub crear_familia(ByVal unbe As BE.BE_Permisocompuesto)

    End Sub

    Public Function listarpermisos() As List(Of BE.BE_PermisoBase)
        listarpermisos = Nothing
    End Function

    Public Function modificar(ByVal unbe As BE.BE_Permisocompuesto) As Integer
        Dim dal_familia As New DAL.DAL_Permisos
        Select Case Me.validar_familia(unbe)
            Case 1999
                Return 1999
            Case False
                Return 1998
            Case True
                Select Case dal_familia.modificar(unbe)
                    Case 1990
                        Return 1990
                    Case 1989
                        Return 1989
                End Select
        End Select
    End Function


    Private Function recurrente_permiso(ByVal unbe As BE.BE_PermisoBase, ByVal permiso As BE.BE_PermisoBase) As Boolean
        If TypeOf (permiso) Is BE.BE_Permisocompuesto Then
            If CType(permiso, BE.BE_Permisocompuesto).idpermiso = unbe.idpermiso Then
                Return True
                Exit Function
            End If
            For Each perm As BE.BE_PermisoBase In CType(permiso, BE.BE_Permisocompuesto).lista_permisos
                If TypeOf (perm) Is BE.BE_Patente Then
                    If unbe.idpermiso = CType(perm, BE.BE_Patente).idpermiso Then
                        Return True
                        Exit Function
                    End If
                Else
                    Me.recurrente_permiso(unbe, perm)
                End If
            Next
        End If
        Return False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Function validar_familia(ByVal unbe As BE.BE_Permisocompuesto) As Integer
        Dim dal_permiso As New DAL.DAL_Permisos
        Select Case dal_permiso.validar_familia(unbe)
            Case True
                Return True
            Case False
                Return False
            Case 1999
                Return 1999
        End Select
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function validar_permiso(ByVal unbe As BE.BE_PermisoBase, usuario As BE.BE_Usuario) As Boolean
        For Each permiso As BE.BE_PermisoBase In CType(usuario.permiso_usuario, BE.BE_Permisocompuesto).lista_permisos
            If unbe.idpermiso = permiso.idpermiso Then
                Return True
                Exit Function
            Else
                If TypeOf (permiso) Is BE.BE_Permisocompuesto Then
                    Select Case recurrente_permiso(unbe, permiso)
                        Case True
                            Return True
                            Exit Function
                        Case False
                            Return False
                    End Select
                End If
            End If
        Next
        Return False
    End Function


End Class


