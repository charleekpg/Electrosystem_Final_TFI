




	Public Class DAL_Proyecto
    Shared listado_proyectos As New List(Of BE.BE_Proyecto)
    Shared listado_proyectos_terminados As New List(Of BE.BE_Proyecto)
    Public m_BE_Proyecto As BE.BE_Proyecto
    Public m_SQLHelper As Seguridad.SQLHelper
    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Proyecto) As Boolean
        alta = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Proyecto) As Boolean
        baja = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function cerrar_proyecto(ByVal unbe As BE.BE_Proyecto) As Boolean
        listado_proyectos_terminados.Add(unbe)
        Return True
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Proyecto) As BE.BE_Proyecto
        Return listado_proyectos_terminados.Item(0)
    End Function

    Public Function consultartodos() As List(Of BE.BE_Proyecto)
        cargar_fechas_aleatorias()
        Return listado_proyectos
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Proyecto) As Boolean
        modificar = False
    End Function

    Private Sub cargar_fechas_aleatorias()
        listado_proyectos.Clear()
        Dim PROYECTO1 As New BE.BE_Proyecto
        Dim PROYECTO2 As New BE.BE_Proyecto
        Dim PROYECTO3 As New BE.BE_Proyecto
        Dim PROYECTO4 As New BE.BE_Proyecto
        Dim PROYECTO5 As New BE.BE_Proyecto
        Dim PROYECTO6 As New BE.BE_Proyecto
        Dim PROYECTO7 As New BE.BE_Proyecto
        Dim PROYECTO8 As New BE.BE_Proyecto
        Dim PROYECTO9 As New BE.BE_Proyecto
        Dim PROYECTO10 As New BE.BE_Proyecto
        Dim PROYECTO11 As New BE.BE_Proyecto
        Dim PROYECTO12 As New BE.BE_Proyecto
        Dim PROYECTO13 As New BE.BE_Proyecto
        PROYECTO1.Presupuesto = New BE.BE_Presupuesto
        PROYECTO2.Presupuesto = New BE.BE_Presupuesto
        PROYECTO3.Presupuesto = New BE.BE_Presupuesto
        PROYECTO4.Presupuesto = New BE.BE_Presupuesto
        PROYECTO5.Presupuesto = New BE.BE_Presupuesto
        PROYECTO6.Presupuesto = New BE.BE_Presupuesto
        PROYECTO7.Presupuesto = New BE.BE_Presupuesto
        PROYECTO8.Presupuesto = New BE.BE_Presupuesto
        PROYECTO9.Presupuesto = New BE.BE_Presupuesto
        PROYECTO10.Presupuesto = New BE.BE_Presupuesto
        PROYECTO11.Presupuesto = New BE.BE_Presupuesto
        PROYECTO12.Presupuesto = New BE.BE_Presupuesto
        PROYECTO13.Presupuesto = New BE.BE_Presupuesto
        PROYECTO1.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        PROYECTO2.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        PROYECTO3.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        PROYECTO4.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        PROYECTO5.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        PROYECTO6.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        PROYECTO7.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        PROYECTO8.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        PROYECTO9.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        PROYECTO10.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        PROYECTO11.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        PROYECTO12.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        PROYECTO13.Presupuesto.dibujotecnico = New BE.BE_DibujoTecnico
        PROYECTO1.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)

        PROYECTO2.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        PROYECTO3.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        PROYECTO4.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        PROYECTO5.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        PROYECTO6.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        PROYECTO7.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        PROYECTO8.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        PROYECTO9.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        PROYECTO10.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        PROYECTO11.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        PROYECTO12.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        PROYECTO13.Presupuesto.dibujotecnico.ambiente = New List(Of BE.Be_Ambiente)
        Dim ambiente1 As New BE.Be_Ambiente
        Dim ambiente2 As New BE.Be_Ambiente
        Dim ambiente3 As New BE.Be_Ambiente
        Dim ambiente4 As New BE.Be_Ambiente
        Dim ambiente5 As New BE.Be_Ambiente
        Dim ambiente6 As New BE.Be_Ambiente
        Dim ambiente7 As New BE.Be_Ambiente
        Dim ambiente8 As New BE.Be_Ambiente
        Dim ambiente9 As New BE.Be_Ambiente
        Dim ambiente10 As New BE.Be_Ambiente
        Dim ambiente11 As New BE.Be_Ambiente
        Dim ambiente12 As New BE.Be_Ambiente
        Dim ambiente13 As New BE.Be_Ambiente
        Dim circuito1 As New BE.BE_Circuito
        Dim circuito2 As New BE.BE_Circuito
        Dim circuito3 As New BE.BE_Circuito
        Dim circuito4 As New BE.BE_Circuito
        Dim circuito5 As New BE.BE_Circuito
        Dim circuito6 As New BE.BE_Circuito
        Dim circuito7 As New BE.BE_Circuito
        Dim circuito8 As New BE.BE_Circuito
        Dim circuito9 As New BE.BE_Circuito
        Dim circuito10 As New BE.BE_Circuito
        Dim circuito11 As New BE.BE_Circuito
        Dim circuito12 As New BE.BE_Circuito
        Dim circuito13 As New BE.BE_Circuito
        circuito1.cantidad_bocas = 30
        circuito2.cantidad_bocas = 15
        circuito3.cantidad_bocas = 14
        circuito4.cantidad_bocas = 23
        circuito5.cantidad_bocas = 26
        circuito6.cantidad_bocas = 13
        circuito7.cantidad_bocas = 30
        circuito8.cantidad_bocas = 12
        circuito9.cantidad_bocas = 14
        circuito10.cantidad_bocas = 29
        circuito11.cantidad_bocas = 13
        circuito12.cantidad_bocas = 30
        circuito13.cantidad_bocas = 14
        ambiente1.circuitos = New List(Of BE.BE_Circuito)
        ambiente2.circuitos = New List(Of BE.BE_Circuito)
        ambiente3.circuitos = New List(Of BE.BE_Circuito)
        ambiente4.circuitos = New List(Of BE.BE_Circuito)
        ambiente5.circuitos = New List(Of BE.BE_Circuito)
        ambiente6.circuitos = New List(Of BE.BE_Circuito)
        ambiente7.circuitos = New List(Of BE.BE_Circuito)
        ambiente8.circuitos = New List(Of BE.BE_Circuito)
        ambiente9.circuitos = New List(Of BE.BE_Circuito)
        ambiente10.circuitos = New List(Of BE.BE_Circuito)
        ambiente11.circuitos = New List(Of BE.BE_Circuito)
        ambiente12.circuitos = New List(Of BE.BE_Circuito)
        ambiente13.circuitos = New List(Of BE.BE_Circuito)

        ambiente1.circuitos.Add(circuito1)
        ambiente2.circuitos.Add(circuito2)
        ambiente3.circuitos.Add(circuito3)
        ambiente4.circuitos.Add(circuito4)
        ambiente5.circuitos.Add(circuito5)
        ambiente6.circuitos.Add(circuito6)
        ambiente7.circuitos.Add(circuito7)
        ambiente8.circuitos.Add(circuito8)
        ambiente9.circuitos.Add(circuito9)
        ambiente10.circuitos.Add(circuito10)
        ambiente11.circuitos.Add(circuito11)
        ambiente12.circuitos.Add(circuito12)
        ambiente13.circuitos.Add(circuito13)
        PROYECTO1.Presupuesto.dibujotecnico.ambiente.Add(ambiente1)
        PROYECTO2.Presupuesto.dibujotecnico.ambiente.Add(ambiente2)
        PROYECTO3.Presupuesto.dibujotecnico.ambiente.Add(ambiente3)
        PROYECTO4.Presupuesto.dibujotecnico.ambiente.Add(ambiente4)
        PROYECTO5.Presupuesto.dibujotecnico.ambiente.Add(ambiente5)
        PROYECTO6.Presupuesto.dibujotecnico.ambiente.Add(ambiente6)
        PROYECTO7.Presupuesto.dibujotecnico.ambiente.Add(ambiente7)
        PROYECTO8.Presupuesto.dibujotecnico.ambiente.Add(ambiente8)
        PROYECTO9.Presupuesto.dibujotecnico.ambiente.Add(ambiente9)
        PROYECTO10.Presupuesto.dibujotecnico.ambiente.Add(ambiente10)
        PROYECTO11.Presupuesto.dibujotecnico.ambiente.Add(ambiente11)
        PROYECTO12.Presupuesto.dibujotecnico.ambiente.Add(ambiente12)
        PROYECTO13.Presupuesto.dibujotecnico.ambiente.Add(ambiente13)
        PROYECTO1.fecha_inicio = "31/05/2017"
        PROYECTO2.fecha_inicio = "20/05/2017"
        PROYECTO3.fecha_inicio = "25/05/2017"
        PROYECTO4.fecha_inicio = "20/03/2017"
        PROYECTO5.fecha_inicio = "15/06/2017"
        PROYECTO6.fecha_inicio = "10/09/2017"
        PROYECTO7.fecha_inicio = "02/06/2017"
        PROYECTO8.fecha_inicio = "26/06/2017"
        PROYECTO9.fecha_inicio = "12/04/2017"
        PROYECTO10.fecha_inicio = "20/06/2017"
        PROYECTO11.fecha_inicio = "18/08/2017"
        PROYECTO12.fecha_inicio = "28/12/2017"
        PROYECTO13.fecha_inicio = "13/10/2017"
        PROYECTO1.fecha_establecida_contrato = "14/08/2017"
        PROYECTO2.fecha_establecida_contrato = "05/11/2017"
        PROYECTO3.fecha_establecida_contrato = "15/08/2017"
        PROYECTO4.fecha_establecida_contrato = "01/07/2017"
        PROYECTO5.fecha_establecida_contrato = "30/09/2017"
        PROYECTO6.fecha_establecida_contrato = "23/09/2017"
        PROYECTO7.fecha_establecida_contrato = "22/07/2017"
        PROYECTO8.fecha_establecida_contrato = "25/12/2017"
        PROYECTO9.fecha_establecida_contrato = "09/09/2017"
        PROYECTO10.fecha_establecida_contrato = "25/08/2017"
        PROYECTO11.fecha_establecida_contrato = "27/12/2017"
        PROYECTO12.fecha_establecida_contrato = "30/12/2017"
        PROYECTO13.fecha_establecida_contrato = "26/10/2017"
        listado_proyectos.Add(PROYECTO1)
        listado_proyectos.Add(PROYECTO2)
        listado_proyectos.Add(PROYECTO3)
        listado_proyectos.Add(PROYECTO4)
        listado_proyectos.Add(PROYECTO5)
        listado_proyectos.Add(PROYECTO6)
        listado_proyectos.Add(PROYECTO7)
        listado_proyectos.Add(PROYECTO8)
        listado_proyectos.Add(PROYECTO9)
        listado_proyectos.Add(PROYECTO10)
        listado_proyectos.Add(PROYECTO11)
        listado_proyectos.Add(PROYECTO12)
        listado_proyectos.Add(PROYECTO13)

    End Sub

End Class ' DAL_Proyecto


