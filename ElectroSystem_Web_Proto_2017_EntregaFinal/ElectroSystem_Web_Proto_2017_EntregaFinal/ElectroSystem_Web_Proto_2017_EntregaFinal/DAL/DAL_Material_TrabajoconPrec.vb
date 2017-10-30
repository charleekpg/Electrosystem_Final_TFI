


Imports System.Data.SqlClient

Public Class DAL_Material_TrabajoconPrec
    Shared trabajoscon_materiales As New List(Of BE.BE_Material_TrabajoconPrec)


    ''' 
    ''' <param name="unbe"></param>
    Public Function alta(ByVal unbe As BE.BE_Material_TrabajoconPrec) As Integer
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim P(1) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@P1", unbe.Descripcion)
            P(1) = sqlhelper.BuildParameter("@P2", unbe.Precio)
            lista_parametros.AddRange(P)
            If unbe.Material = True Then
                mapper_stores.insertar_eliminar_modificar("alta_material", lista_parametros)
            Else
                mapper_stores.insertar_eliminar_modificar("alta_trabajo", lista_parametros)
            End If
            Return 10110
        Catch ex As Exception
            Return 10111
        End Try

    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function baja(ByVal unbe As BE.BE_Material_TrabajoconPrec) As Boolean
        baja = Nothing
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function consultar(ByVal unbe As BE.BE_Material_TrabajoconPrec) As BE.BE_Material_TrabajoconPrec
        consultar = Nothing
    End Function

    Public Function consultartodos() As List(Of BE.BE_Material_TrabajoconPrec)

        Try
            Dim listamaterial_trabajoconprec As New List(Of BE.BE_Material_TrabajoconPrec)
            Dim datatable As New DataTable
            Dim datatable2 As New DataTable
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            datatable = mapper_stores.consultar("consultartodos_material", lista_parametros)
            For Each elemento As DataRow In datatable.Rows
                Dim tmpmaterial As New BE.BE_Material_TrabajoconPrec
                tmpmaterial.id = elemento(0)
                tmpmaterial.Descripcion = elemento(1)
                tmpmaterial.Precio = elemento(2)
                tmpmaterial.Material = True
                tmpmaterial.Trabajoconprecio = False
                listamaterial_trabajoconprec.Add(tmpmaterial)
            Next
            datatable2 = mapper_stores.consultar("consultartodos_trabajo", lista_parametros)
            For Each elemento As DataRow In datatable2.Rows
                Dim tmpartefacto As New BE.BE_Material_TrabajoconPrec
                tmpartefacto.id = elemento(0)
                tmpartefacto.Descripcion = elemento(1)
                tmpartefacto.Precio = elemento(2)
                tmpartefacto.Material = False
                tmpartefacto.Trabajoconprecio = True
                listamaterial_trabajoconprec.Add(tmpartefacto)
            Next
            Return listamaterial_trabajoconprec
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

		''' 
		''' <param name="unbe"></param>
    Public Function modificar(ByVal unbe As BE.BE_Material_TrabajoconPrec) As Boolean
        Dim sqlhelper As New SEGURIDAD.SQLHelper
        Dim lista_parametros As New List(Of SqlParameter)
        Dim mapper_stores As New SEGURIDAD.Mapper_Stored
        Try
            Dim actualizar_mat_trabajo As New SqlCommand
            If unbe.cambiodetipo = True Then
                Select Case Me.alta(unbe)
                    Case 10111
                        GoTo 1
                    Case 10110
                        If unbe.Material = True Then
                            Dim P(0) As SqlParameter
                            P(0) = sqlhelper.BuildParameter("@P3", unbe.id)
                            lista_parametros.AddRange(P)
                            mapper_stores.insertar_eliminar_modificar("eliminar_trabajo", lista_parametros)
                        Else
                            Dim P(0) As SqlParameter
                            P(0) = sqlhelper.BuildParameter("@P3", unbe.id)
                            lista_parametros.AddRange(P)
                            mapper_stores.insertar_eliminar_modificar("eliminar_material", lista_parametros)
                        End If
                End Select
            Else
                If unbe.Material = True Then
                    Dim P(2) As SqlParameter
                    P(0) = sqlhelper.BuildParameter("@P1", unbe.Descripcion)
                    P(1) = sqlhelper.BuildParameter("@P2", unbe.Precio)
                    P(2) = sqlhelper.BuildParameter("@P3", unbe.id)
                    lista_parametros.AddRange(P)
                    mapper_stores.insertar_eliminar_modificar("actualizar_material", lista_parametros)
                Else
                    Dim P(2) As SqlParameter
                    P(0) = sqlhelper.BuildParameter("@P1", unbe.Descripcion)
                    P(1) = sqlhelper.BuildParameter("@P2", unbe.Precio)
                    P(2) = sqlhelper.BuildParameter("@P3", unbe.id)
                    lista_parametros.AddRange(P)
                    mapper_stores.insertar_eliminar_modificar("actualizar_trabajo", lista_parametros)
                End If
            End If
            Return 10113
1:      Catch ex As Exception
            Return 10112
        End Try
    End Function

    ''' 
    ''' <param name="unbe"></param>
    Public Function validardescripcion(ByVal unbe As BE.BE_Material_TrabajoconPrec) As Integer
        Try
            Dim sqlhelper As New SEGURIDAD.SQLHelper
            Dim datatable As New DataTable
            Dim lista_parametros As New List(Of SqlParameter)
            Dim mapper_stores As New SEGURIDAD.Mapper_Stored
            Dim datatable2 As New DataTable
            If unbe.id > 0 Then
                Dim P(1) As SqlParameter
                P(0) = sqlhelper.BuildParameter("@P1", unbe.Descripcion)
                P(1) = sqlhelper.BuildParameter("@P2", unbe.id)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("validarmaterial_conidentificador", lista_parametros)
                If datatable.Rows.Count = 0 Then
                    datatable2 = mapper_stores.consultar("validartrabajoconprecioestipulado_conidentificador", lista_parametros)
                    If datatable2.Rows.Count = 0 Then
                        Return True
                    Else
                        Return 10112
                    End If
                Else
                    Return 10112
                End If
            Else
                Dim P(0) As SqlParameter
                P(0) = sqlhelper.BuildParameter("@P1", unbe.Descripcion)
                lista_parametros.AddRange(P)
                datatable = mapper_stores.consultar("validarmaterial_sinidentificador", lista_parametros)
                If datatable.Rows.Count = 0 Then
                    datatable2 = mapper_stores.consultar("validartrabajoconprecioestipulado_sinidentificador", lista_parametros)
                    If datatable2.Rows.Count = 0 Then
                        Return True
                    Else
                        Return 10112
                    End If
                Else
                    Return 10112
                End If
            End If
        Catch ex As Exception
            Return 10111
        End Try
    End Function


End Class ' DAL_Material_TrabajoconPrec


