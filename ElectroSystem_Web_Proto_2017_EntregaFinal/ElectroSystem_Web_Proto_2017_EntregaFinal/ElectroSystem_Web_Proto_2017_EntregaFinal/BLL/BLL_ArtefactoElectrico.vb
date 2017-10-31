Public Class BLL_ArtefactoElectrico


    Public m_BE_ArtefactoElectrico As BE.BE_ArtefactoElectrico
    Public m_DAL_ArtefactoElectrico As DAL.DAL_ArtefactoElectrico
    Public m_BLL_Bitacora As BLL.BLL_Bitacora

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_ArtefactoElectrico) As Integer
        If unbe.relacion_bocamercado = 0 Then
            Me.relacionboca(unbe)
        Else
            calcularprecio(unbe)
        End If
        Dim dal_artefacto As New DAL.DAL_ArtefactoElectrico
        Select Case dal_artefacto.validardescripcion(unbe)
            Case 10107
                Return 10107
            Case 10106

                Return 10106
            Case 1
                Select Case dal_artefacto.alta(unbe)
                    Case 10105
                        Return 10105
                    Case 10106

                        Return 10106
                End Select
        End Select
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_ArtefactoElectrico) As Boolean
        baja = False
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function calcular_precio_cantidad(ByVal unbe As BE.BE_ArtefactoElectrico) As BE.BE_ArtefactoElectrico
        Dim bll_boca As New BLL.BLL_BocaMercado
        Dim be_boca As New BE.BE_BocaMercado
        be_boca = bll_boca.consultartodos().Item(0)
        unbe.precio = unbe.relacion_bocamercado * be_boca.precio_bocamercado
        unbe.preciocantidad = unbe.cantidad * unbe.precio
        Return unbe
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Sub calcularprecio(ByVal unbe As BE.BE_ArtefactoElectrico)
        Try
            Dim bll_boca As New BLL.BLL_BocaMercado
            Dim lista As List(Of BE.BE_BocaMercado)
            Dim be_bocamercado As New BE.BE_BocaMercado
            lista = bll_boca.consultartodos()
            unbe.precio = unbe.relacion_bocamercado * lista.Item(0).precio_bocamercado
        Catch ex As Exception

        End Try

    End Sub

    ''' 
    ''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_ArtefactoElectrico) As BE.BE_ArtefactoElectrico
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_ArtefactoElectrico)
        Try
            Dim dal_artefacto As New DAL.DAL_ArtefactoElectrico
            Dim lista As List(Of BE.BE_ArtefactoElectrico)
            lista = dal_artefacto.consultartodos()
            For Each unbe As BE.BE_ArtefactoElectrico In lista
                calcularprecio(unbe)
            Next
            Return lista
        Catch ex As Exception

        End Try


    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_ArtefactoElectrico) As Integer
        If unbe.relacion_bocamercado = 0 Then
            Me.relacionboca(unbe)
        Else
            calcularprecio(unbe)
        End If
        Dim dal_artefacto As New DAL.DAL_ArtefactoElectrico
        Select Case dal_artefacto.validardescripcion(unbe)
            Case 10107
                Return 10107
            Case 10109
                Return 10109
            Case 1
                Select Case dal_artefacto.modificar(unbe)
                    Case 10108
                        Return 10108
                    Case 10109
                        Return 10109
                End Select
        End Select
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Private Sub relacionboca(ByVal unbe As BE.BE_ArtefactoElectrico)
        Try
            Dim bll_boca As New BLL.BLL_BocaMercado
            Dim lista As List(Of BE.BE_BocaMercado)
            lista = bll_boca.consultartodos()
            unbe.relacion_bocamercado = unbe.precio / lista.Item(0).precio_bocamercado
        Catch ex As Exception

        End Try

    End Sub


End Class