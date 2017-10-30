Public Class BLL_Domicilio


    Public m_DAL_Domicilio As DAL.DAL_Domicilio
    Public m_BE_Domicilio As BE.BE_Domicilio

    ''' 
    ''' <param name="unbe"></param>
    ''' <param name="domicilio"></param>
    Public Function calcular_distancia(ByVal unbe As BE.BE_Domicilio, ByVal domicilio As BE.BE_Domicilio) As Decimal
        calcular_distancia = 0
    End Function

    ''' 
    ''' <param name="deg"></param>
    Private Function deg2rad(ByVal deg As Double) As Double
        deg2rad = 0
    End Function

    ''' 
    ''' <param name="rad"></param>
    Private Function rad2deg(ByVal rad As Double) As Double
        rad2deg = 0
    End Function


End Class 