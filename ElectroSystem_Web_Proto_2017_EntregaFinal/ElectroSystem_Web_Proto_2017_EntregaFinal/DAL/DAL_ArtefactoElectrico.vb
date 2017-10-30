

Public Class DAL_ArtefactoElectrico


    Public m_BE_ArtefactoElectrico As BE.BE_ArtefactoElectrico
    Public m_SQLHelper As Seguridad.SQLHelper

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_ArtefactoElectrico) As Boolean
        alta = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_ArtefactoElectrico) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_ArtefactoElectrico) As BE.BE_ArtefactoElectrico
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_ArtefactoElectrico)
        consultartodos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_ArtefactoElectrico) As Boolean
        modificar = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function validardescripcion(ByVal unbe As BE.BE_ArtefactoElectrico) As Boolean
        validardescripcion = False
    End Function


End Class

