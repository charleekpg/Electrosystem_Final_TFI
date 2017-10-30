Imports System.Math
Public Class BLL_Domicilio
    ' ESTO NO VA A ESTAR
    Private LISTA As New List(Of BE.be_localidad)
    ' HASTA ACA


    Public m_DAL_Domicilio As DAL.DAL_Domicilio
    Public m_BE_Domicilio As BE.BE_Domicilio

    ''' 
    ''' <param name="unbe"></param>
    ''' <param name="domicilio"></param>
    Public Function calcular_distancia(ByVal unbe As BE.BE_Domicilio, ByVal domicilio As BE.BE_Domicilio) As Decimal
        'cabe señalar que a los fines del prototipo se realiza nuevamente la busqueda...esto no será de esta forma ya que se tendrá el objeto correspondiente.
        LISTA.Clear()
        'If DAL.DAL_Partido.partidos.Count = 0 Then
        '    DAL.DAL_Partido.cargar_partidoscompartido()
        'End If

        For Each partido As BE.BE_Partido In DAL.DAL_Partido.partidos
                For Each localidad As BE.be_localidad In partido.localidades
                    LISTA.Add(localidad)
                Next
            Next


            unbe.localidad = LISTA.Find(Function(x) x.localidad = unbe.localidad.localidad)
        domicilio.localidad = LISTA.Find(Function(x) x.localidad = domicilio.localidad.localidad)
        '''''''''''' HASTA ACA NO VA A IR

        Dim latitud1 As Double = 0
        Dim latitud2 As Double = 0
        Dim longitud1 As Double = 0
        Dim longitud2 As Double = 0
        Dim latitud1_engdec As String = unbe.localidad.latitud.Insert(3, ",")
        Dim latitud2_engdec As String = domicilio.localidad.latitud.Insert(3, ",")
        Dim longitud1_engdec As String = unbe.localidad.longitud.Insert(3, ",")
        Dim longitud2_engdec As String = domicilio.localidad.longitud.Insert(3, ",")
        Dim latitud1_form As Double = latitud1_engdec.Replace(".", "")
        Dim latitud2_form As Double = latitud2_engdec.Replace(".", "")
        Dim longitud1_form As Double = longitud1_engdec.Replace(".", "")
        Dim longitud2_form As Double = longitud2_engdec.Replace(".", "")
        latitud1 = latitud1_form * (3.141592654 / 180)
        latitud2 = latitud2_form * (3.141592654 / 180)
        longitud1 = longitud1_form * (3.141592654 / 180)
        longitud2 = longitud1_form * (3.141592654 / 180)
        Dim DistanciaenKM As Decimal
        DistanciaenKM = 6371 * Acos(Cos(latitud1) * Cos(latitud2) * Cos(longitud2 - longitud1) + Sin(latitud1) * Sin(latitud2))
        Return DistanciaenKM
    End Function




End Class