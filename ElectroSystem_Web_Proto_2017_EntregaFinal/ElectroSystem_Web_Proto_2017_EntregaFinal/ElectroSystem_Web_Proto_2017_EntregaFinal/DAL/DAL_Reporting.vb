Imports System.Data.SqlClient


Public Class DAL_Reporting


    Public m_BE_Reporting As BE.BE_Reporting

    ''' 
    ''' <param name="unbe"></param>
    Public Function clientes_criticos(ByVal unbe As BE.BE_Reporting) As BE.BE_Reporting
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim reporte As New BE.BE_Reporting
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Dim datatable As New DataTable
        Dim lista_parametros As New List(Of SqlParameter)
        Try
            Dim consultagenerica As String = Nothing
            Dim consulta As New SqlCommand
            Dim sqldatareader As SqlDataReader
            Dim lista_cliente As New List(Of BE.BE_CLIENTE)
            Dim P(2) As SqlParameter
            If unbe.cantidad_clientes = True Then
                P(0) = sqlhelper.BuildParameter("@P1", unbe.fechadesde)
                P(1) = sqlhelper.BuildParameter("@P2", unbe.fechahasta)
                P(2) = sqlhelper.BuildParameter("@P3", unbe.presupuesto.estado_presupuesto)
                If unbe.fechadesde = unbe.fechahasta Then
                    lista_parametros.AddRange(P)

                    datatable = mapper_stores.consultar("consultar_clientecriticodesdeidemhastaconcli", lista_parametros)
                Else
                    lista_parametros.AddRange(P)

                    datatable = mapper_stores.consultar("consultar_clientecriticodesdedifehastaconcli", lista_parametros)
                End If
            Else

                If unbe.fechadesde = unbe.fechahasta Then
                    ReDim P(0)
                    P(0) = sqlhelper.BuildParameter("@P3", unbe.presupuesto.estado_presupuesto)
                    lista_parametros.AddRange(P)

                    datatable = mapper_stores.consultar("consultar_clientecriticodesdeidemhastasincli", lista_parametros)
                Else
                    lista_parametros.AddRange(P)

                    P(0) = sqlhelper.BuildParameter("@P1", unbe.fechadesde)
                    P(1) = sqlhelper.BuildParameter("@P2", unbe.fechahasta)
                    P(2) = sqlhelper.BuildParameter("@P3", unbe.presupuesto.estado_presupuesto)
                    datatable = mapper_stores.consultar("consultar_clientecriticodesdedifehastasincli", lista_parametros)
                End If
            End If
            Dim contador As Integer = 0
            For Each persona As DataRow In datatable.Rows
                If IsDBNull(persona(1)) = True Then
                    Dim tmp_personafisica As New BE.BE_Personafisica
                    tmp_personafisica.cantidad_presupuesto = persona(0)
                    tmp_personafisica.identificador = persona(2)
                    tmp_personafisica.Nombre = persona(3)
                    tmp_personafisica.Apellido = persona(4)
                    lista_cliente.Add(tmp_personafisica)
                Else
                    Dim tmp_personajuridica As New BE.BE_Personajuridica
                    tmp_personajuridica.Razonsocial = persona(1)
                    tmp_personajuridica.cantidad_presupuesto = persona(0)
                    tmp_personajuridica.identificador = persona(2)
                    lista_cliente.Add(tmp_personajuridica)
                End If
                contador = contador + 1
                If contador = 5 Then
                    Exit For
                End If
            Next
            reporte.cliente = lista_cliente
            Return reporte
        Catch ex As Exception
            reporte.fallo = True
            Return reporte
        End Try

    End Function

    Function top5_artefactos() As BE.BE_Reporting
        Dim listaartefactos As New List(Of BE.BE_ArtefactoElectrico)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim reporte As New BE.BE_Reporting
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Dim datatable As New DataTable
        Dim lista_parametros As New List(Of SqlParameter)
        Dim contador As Integer = 0
        Try
            datatable = mapper_stores.consultar("consultar_top5artefactos", lista_parametros)
            For Each report As DataRow In datatable.Rows
                Dim tmpartefacto As New BE.BE_ArtefactoElectrico
                tmpartefacto.descripcion = report(1)
                If IsDBNull(report(0)) Then
                    tmpartefacto.precio = 0
                Else
                    tmpartefacto.precio = report(0)
                End If
                listaartefactos.Add(tmpartefacto)
                contador = contador + 1
                If contador = 5 Then
                    Exit For
                End If
            Next
            reporte.artefactos = listaartefactos
            Return reporte
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Function top5_material() As BE.BE_Reporting
        Dim listamaterial As New List(Of BE.BE_Material_TrabajoconPrec)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim reporte As New BE.BE_Reporting
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Dim datatable As New DataTable
        Dim lista_parametros As New List(Of SqlParameter)
        Dim contador As Integer = 0
        Try
            datatable = mapper_stores.consultar("consultar_top5material", lista_parametros)
            For Each report As DataRow In datatable.Rows
                Dim tmp_material As New BE.BE_Material_TrabajoconPrec
                tmp_material.Descripcion = report(1)
                If IsDBNull(report(0)) Then
                    tmp_material.Precio = 0
                Else
                    tmp_material.Precio = report(0)
                End If
                listamaterial.Add(tmp_material)
                contador = contador + 1
                If contador = 5 Then
                    Exit For
                End If
            Next
            reporte.materiales = listamaterial
            Return reporte
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function top5_trabajos() As BE.BE_Reporting
        Dim listatrabajo As New List(Of BE.BE_Material_TrabajoconPrec)
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim reporte As New BE.BE_Reporting
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Dim datatable As New DataTable
        Dim lista_parametros As New List(Of SqlParameter)
        Dim contador As Integer = 0
        Try
            datatable = mapper_stores.consultar("consultar_top5trabajos", lista_parametros)
            For Each report As DataRow In datatable.Rows
                Dim tmp_trabajos As New BE.BE_Material_TrabajoconPrec
                tmp_trabajos.Descripcion = report(1)
                If IsDBNull(report(0)) Then
                    tmp_trabajos.Precio = 0
                Else
                    tmp_trabajos.Precio = report(0)
                End If
                listatrabajo.Add(tmp_trabajos)
                contador = contador + 1
                If contador = 5 Then
                    Exit For
                End If
            Next
            reporte.trabajos = listatrabajo
            Return reporte
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


	End Class ' DAL_Reporting


