Public Class BLL_ArtefactoElectrico


    Public m_BE_ArtefactoElectrico As BE.BE_ArtefactoElectrico
    Public m_DAL_ArtefactoElectrico As DAL.DAL_ArtefactoElectrico
    Public m_BLL_Bitacora As BLL.BLL_Bitacora

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
    Public Sub calcular_precio_cantidad(ByVal unbe As BE.BE_ArtefactoElectrico)

    End Sub

    ''' 
    ''' <param name="unbe"></param>
    Private Sub calcularprecio(ByVal unbe As BE.BE_ArtefactoElectrico)

    End Sub

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
    Private Sub relacionboca(ByVal unbe As BE.BE_ArtefactoElectrico)

    End Sub


End Class