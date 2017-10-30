Imports System.Data.SqlClient
Public Class DAL_PersonaJuridica


    Public m_SQLHelper As Seguridad.SQLHelper

    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Personajuridica) As Integer
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Dim lista_parametros As New List(Of SqlParameter)
        Dim alta_usuario As New SqlCommand
        Dim P(5) As SqlParameter
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim telefono As New DAL.DAL_Telefono
        Try
            P(0) = sqlhelper.BuildParameter("@P2", unbe.Referente.Nombre)
            P(1) = sqlhelper.BuildParameter("@P3", unbe.Referente.Apellido)
            P(2) = sqlhelper.BuildParameter("@P4", unbe.Correoelectronico)
            P(3) = sqlhelper.BuildParameter("@P5", unbe.TratamientoEspecial)
            P(4) = sqlhelper.BuildParameter("@P6", unbe.identificador)
            P(5) = sqlhelper.BuildParameter("@P7", unbe.Razonsocial)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("alta_personajuridica", lista_parametros)
            If telefono.alta_telefono(CType(unbe, BE.BE_CLIENTE)) = True Then
                Return 10124
            Else
                Return 10126
            End If
        Catch ex As Exception
            Return 10120
        Finally
            sqlhelper.cerrarconexion()
        End Try
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Personajuridica) As Boolean
        baja = False
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Personajuridica) As List(Of BE.BE_Personajuridica)
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim lista_parametros As New List(Of SqlParameter)
            Dim datatable As New DataTable
            Dim listapersona As New List(Of BE.BE_Personajuridica)
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim P(0) As SqlParameter
            If unbe.id = 0 Then
                P(0) = sqlhelper.BuildParameter("@p5", unbe.identificador)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("consulta_personajuridica_identificador", lista_parametros)
            Else
                P(0) = sqlhelper.BuildParameter("@p5", unbe.id)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("consulta_personajuridica_id", lista_parametros)
            End If
            For Each datarow As DataRow In datatable.Rows
                Dim tmp_personajuridica As New BE.BE_Personajuridica
                tmp_personajuridica.id = datarow.Item(0)
                tmp_personajuridica.Razonsocial = datarow.Item(1)
                tmp_personajuridica.Correoelectronico = datarow.Item(2)
                tmp_personajuridica.TratamientoEspecial = datarow.Item(3)
                tmp_personajuridica.identificador = datarow.Item(5)
                If Not IsDBNull(datarow.Item(4)) Then
                    Dim tmp_personafisica As New BE.BE_Personafisica
                    tmp_personafisica.id = datarow.Item(4)
                    tmp_personajuridica.Referente = tmp_personafisica
                Else
                    tmp_personajuridica.Referente = Nothing
                End If
                listapersona.Add(tmp_personajuridica)
            Next
            Return listapersona
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function consultartodos() As List(Of BE.BE_Personajuridica)
        consultartodos = Nothing
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Personajuridica) As Integer
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Dim lista_parametros As New List(Of SqlParameter)
        Dim alta_usuario As New SqlCommand
        Dim P(6) As SqlParameter
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim telefono As New DAL.DAL_Telefono
        Try
            P(0) = sqlhelper.BuildParameter("@P2", unbe.Referente.Nombre)
            P(1) = sqlhelper.BuildParameter("@P3", unbe.Referente.Apellido)
            P(2) = sqlhelper.BuildParameter("@P4", unbe.Correoelectronico)
            P(3) = sqlhelper.BuildParameter("@P5", unbe.TratamientoEspecial)
            P(4) = sqlhelper.BuildParameter("@P6", unbe.identificador)
            P(5) = sqlhelper.BuildParameter("@P7", unbe.Razonsocial)
            P(6) = sqlhelper.BuildParameter("@P8", unbe.id)
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("actualizar_personajuridica", lista_parametros)
            If telefono.alta_telefono(CType(unbe, BE.BE_CLIENTE)) = True Then
                Return 10136
            Else
                Return 10126
            End If
        Catch ex As Exception
            Return 10134
        Finally
            sqlhelper.cerrarconexion()
        End Try
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Shared Function validarcuit_razonsocial(ByVal unbe As BE.BE_Personajuridica) As Boolean
			validarcuit_razonsocial = False
		End Function


	End Class ' DAL_PersonaJuridica


