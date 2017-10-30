


	Public Class BLL_Material_TrabajoconPrec


    Public m_BE_Material_TrabajoconPrec As BE.BE_Material_TrabajoconPrec
		Public m_DAL_Material_TrabajoconPrec As DAL.DAL_Material_TrabajoconPrec
		Public m_BLL_Bitacora As BLL.BLL_Bitacora

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Material_TrabajoconPrec) As Integer
        Dim dal_material_trabajo As New DAL.DAL_Material_TrabajoconPrec
        Dim Bitacora As New BE.BE_Bitacora
        Dim bll_Bitacora As New BLL.BLL_Bitacora
        Select Case dal_material_trabajo.validardescripcion(unbe)
            Case 10112
                Return 10112
            Case 10111
                Return 10111
            Case True
                Select Case dal_material_trabajo.alta(unbe)
                    Case 10110
                        Return 10110
                    Case 10111
                        Return 10111
                End Select
        End Select
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Material_TrabajoconPrec) As Boolean
        baja = False
    End Function

		''' 
		''' <param name="unbe"></param>
		Public Sub calcular_precio_cantidad(ByVal unbe As BE.BE_Material_TrabajoconPrec)

		End Sub

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Material_TrabajoconPrec) As BE.BE_Material_TrabajoconPrec
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_Material_TrabajoconPrec)
        Try
            Dim dal_consultar As New DAL.DAL_Material_TrabajoconPrec
            Return dal_consultar.consultartodos()
        Catch ex As Exception

        End Try

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Material_TrabajoconPrec) As Integer
        Dim material_trabajo As New DAL.DAL_Material_TrabajoconPrec
        Select Case material_trabajo.validardescripcion(unbe)
            Case 10112
                Return 10112
            Case 10114
                Return 10114
            Case True
                Select Case material_trabajo.modificar(unbe)
                    Case 10113
                        Return 10113
                    Case 10114
                        Return 10114
                End Select
        End Select
    End Function


End Class ' BLL_Material_TrabajoconPrec


