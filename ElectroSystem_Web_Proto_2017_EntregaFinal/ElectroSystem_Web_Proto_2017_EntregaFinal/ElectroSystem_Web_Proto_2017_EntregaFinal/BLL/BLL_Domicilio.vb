Imports System.Math
Public Class BLL_Domicilio

    Public Function calcular_distancia(ByVal unbe As BE.BE_Domicilio, ByVal domicilio As BE.BE_Domicilio) As Decimal
        Try
            Dim latitud1 As Double = 0
            Dim latitud2 As Double = 0
            Dim longitud1 As Double = 0
            Dim longitud2 As Double = 0
            Dim latitud1_engdec As String = unbe.localidad.latitud.Replace(".", "")
            latitud1_engdec = latitud1_engdec.Insert(3, ",")
            Dim latitud2_engdec As String = domicilio.localidad.latitud.Replace(".", "")
            latitud2_engdec = latitud2_engdec.Insert(3, ",")
            Dim longitud1_engdec As String = unbe.localidad.longitud.Replace(".", "")
            longitud1_engdec = longitud1_engdec.Insert(3, ",")
            Dim longitud2_engdec As String = domicilio.localidad.longitud.Replace(".", "")
            longitud2_engdec = longitud2_engdec.Insert(3, ",")
            Dim latitud1_form As Double = latitud1_engdec
            Dim latitud2_form As Double = latitud2_engdec
            Dim longitud1_form As Double = longitud1_engdec
            Dim longitud2_form As Double = longitud2_engdec
            latitud1 = latitud1_form * (3.141592654 / 180)
            latitud2 = latitud2_form * (3.141592654 / 180)
            longitud1 = longitud1_form * (3.141592654 / 180)
            longitud2 = longitud1_form * (3.141592654 / 180)
            Dim DistanciaenKM As Decimal
            DistanciaenKM = 6371 * Acos(Cos(latitud1) * Cos(latitud2) * Cos(longitud2 - longitud1) + Sin(latitud1) * Sin(latitud2))
            Return DistanciaenKM
        Catch ex As Exception
            Return 0
        End Try
      
    End Function
End Class