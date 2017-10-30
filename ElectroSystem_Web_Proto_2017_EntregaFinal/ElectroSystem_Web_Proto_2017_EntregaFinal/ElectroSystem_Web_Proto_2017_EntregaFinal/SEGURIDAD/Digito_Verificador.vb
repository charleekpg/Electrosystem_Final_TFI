Imports System.Security.Cryptography
Imports System.Math
Imports System.Text
Imports System.Data.SqlClient

Public Class Digito_Verificador


    Public m_BE_Bitacora As BE.BE_Bitacora
    Public m_SQLHelper As Seguridad.SQLHelper

    Public Shared Function buscarfilaconerror(ByVal tabla As String) As Integer
        Dim sqlhelper As New SQLHelper
        Try
            Dim sqlcomando As New SqlCommand
            Dim fila As Integer = 0
            Dim error_integridad As Boolean = False
            Dim mapper_stores As New Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Dim datatable As New DataTable
            Select Case tabla
                Case "Bitacora"
                    datatable = mapper_stores.consultar("buscarfilaerror_bitacora", lista_parametros)
                    For Each row As DataRow In datatable.Rows
                        Dim stringconcatenado As String = ""
                        If row.Item(5) = "0" Then
                            stringconcatenado = "0" & row.Item(1).ToString & row.Item(3).ToString & row.Item(6).ToString
                        Else
                            stringconcatenado = "1" & row.Item(1).ToString & row.Item(3).ToString & row.Item(6).ToString
                        End If
                        If Not calculardigitoverificador(stringconcatenado) = row.Item(2).ToString Then
                            error_integridad = True
                            fila = fila + 1
                            Exit For
                        End If
                    Next
                Case "usuario"
                    datatable = mapper_stores.consultar("buscarfilaerror_usuario", lista_parametros)
                    For Each row As DataRow In datatable.Rows
                        Dim stringconcatenado As String = ""
                        stringconcatenado = row.Item(1).ToString & row.Item(2).ToString
                        If Not calculardigitoverificador(stringconcatenado) = row.Item(8) Then
                            error_integridad = True
                            fila = fila + 1
                            Exit For
                        End If
                    Next
            End Select
            Return fila
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' 
    ''' <param name="algo"></param>
    Public Shared Function calculardigitoverificador(ByVal algo As String) As Integer
        Dim tmpSource() As Byte
        Dim tmpHash() As Byte
        Dim total As Integer = 0
        Dim i As Integer
        tmpSource = ASCIIEncoding.ASCII.GetBytes(algo)
        tmpHash = New MD5CryptoServiceProvider().ComputeHash(tmpSource)
        For i = 0 To tmpHash.Length - 1
            total = total + tmpHash(i)
        Next
        Return total
    End Function

    ''' 
    ''' <param name="tabla"></param>
    Public Shared Function calculardigitoverificadorvertical(ByVal tabla As String) As Integer
        Dim sqlhelper As New SQLHelper
        Try
            Dim totaldigitovertical As Integer = 0
            Dim totalcalcularconcatenar As Integer = 0
            Dim datatable As New DataTable
            Dim mapper_stores As New Mapper_Stored
            Dim lista_parametros As New List(Of SqlParameter)
            Select Case tabla
                Case "Bitacora"
                    datatable = mapper_stores.consultar("calculardigitoverificadorvertical_bitacora", lista_parametros)
                Case "Usuario"
                    datatable = mapper_stores.consultar("calculardigitoverificadorvertical_usuario", lista_parametros)
                Case Else
            End Select
            For Each datarow As DataRow In datatable.Rows
                totalcalcularconcatenar = datarow.Item(0)
            Next
            totaldigitovertical = calculardigitoverificador(totalcalcularconcatenar.ToString)
            Dim P(1) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@ddvvv", totaldigitovertical)
            P(1) = sqlhelper.BuildParameter("@nombre_tabla", tabla)
            lista_parametros.Clear()
            lista_parametros.AddRange(P)
            mapper_stores.insertar_eliminar_modificar("actualizarddvvv", lista_parametros)
            Return totaldigitovertical
        Catch ex As Exception
            Return False
        Finally
        End Try
    End Function

		''' 
		''' <param name="tabla"></param>
		Public Shared Function comparardigitoverificadorvertical(ByVal tabla As String) As Boolean
        Dim sqlhelper As New SQLHelper
        Try
            Dim totaldigitovertical As Integer = 0
            Dim calcularconcatenar As New SqlCommand
            Dim totalcalcularconcatenar As Integer = 0
            calcularconcatenar.CommandText = "SELECT SUM(DDVVH) FROM " & tabla
            calcularconcatenar.Connection = sqlhelper.abrirconexion()
            totalcalcularconcatenar = calcularconcatenar.ExecuteScalar()
            sqlhelper.cerrarconexion()
            totaldigitovertical = calculardigitoverificador(totalcalcularconcatenar.ToString)
            Dim consultarddvvh As New SqlCommand
            consultarddvvh.CommandText = "Select DDVVV from Digito_Vertical where Nombre_tabla=@P1"
            Dim P(0) As SqlParameter
            P(0) = sqlhelper.BuildParameter("@P1", tabla)
            consultarddvvh.Parameters.AddRange(P)
            consultarddvvh.Connection = sqlhelper.abrirconexion()
            If consultarddvvh.ExecuteScalar() = totaldigitovertical Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return 2
        Finally
            sqlhelper.cerrarconexion()
        End Try

    End Function

    Public Shared Function recalcular_digitos(ByVal tabla As String) As Integer
        Dim sqlhelper As New SQLHelper
        Try
            Dim sqlcomando As New SqlCommand
            Dim sqldata As New SqlDataAdapter()
            Dim dt As New DataTable
            Dim sqlcoman As New SqlCommand
            sqlcoman.CommandText = "Select * from " & tabla
            sqlcoman.Connection = sqlhelper.abrirconexion()
            sqldata.SelectCommand = sqlcoman
            sqldata.Fill(dt)
            sqlhelper.cerrarconexion()
            For i = 0 To dt.Rows.Count - 1
                sqlcomando.Parameters.Clear()
                Select Case tabla
                    Case "Bitacora"
                        Dim stringconcatenado As String = ""
                        If dt.Rows(i).Item(5) = "0" Then
                            stringconcatenado = "0" & dt.Rows(i).Item(1).ToString & dt.Rows(i).Item(3).ToString & dt.Rows(i).Item(6).ToString
                        Else
                            stringconcatenado = "1" & dt.Rows(i).Item(1).ToString & dt.Rows(i).Item(3).ToString & dt.Rows(i).Item(6).ToString
                        End If
                        sqlcomando.CommandText = "Update " & tabla & " set DDVVH=@P2 WHERE id_registro=@P3"
                        Dim a(1) As SqlParameter
                        a(0) = sqlhelper.BuildParameter("@P2", calculardigitoverificador(stringconcatenado))
                        a(1) = sqlhelper.BuildParameter("@P3", dt.Rows(i).Item(0))
                        sqlcomando.Parameters.AddRange(a)
                        sqlcomando.Connection = sqlhelper.abrirconexion()
                        sqlcomando.ExecuteNonQuery()
                        sqlhelper.cerrarconexion()
                    Case "Usuario"
                        'VER ESTO'
                        Dim stringconcatenado As String = ""
                        stringconcatenado = dt.Rows(i).Item(0).ToString & dt.Rows(i).Item(1).ToString
                        sqlcomando.CommandText = "Update " & tabla & " set DDVVH=@P2 WHERE Permiso_ID=@P3 and PermisoHijo_ID=@P4"
                        Dim a(2) As SqlParameter
                        a(0) = sqlhelper.BuildParameter("@P2", calculardigitoverificador(stringconcatenado))
                        a(1) = sqlhelper.BuildParameter("@P3", dt.Rows(i).Item(0))
                        a(2) = sqlhelper.BuildParameter("@P4", dt.Rows(i).Item(1))
                        sqlcomando.Parameters.AddRange(a)
                        sqlcomando.Connection = sqlhelper.abrirconexion()
                        sqlcomando.ExecuteNonQuery()
                        sqlhelper.cerrarconexion()
                    Case "precio_boca"
                        Dim stringconcatenado As String = ""
                        stringconcatenado = dt.Rows(i).Item(0).ToString
                        sqlcomando.CommandText = "Update " & tabla & " set DDVVH=@P2"
                        Dim a(0) As SqlParameter
                        a(0) = sqlhelper.BuildParameter("@P2", calculardigitoverificador(stringconcatenado))
                        sqlcomando.Parameters.AddRange(a)
                        sqlcomando.Connection = sqlhelper.abrirconexion()
                        sqlcomando.ExecuteNonQuery()
                        sqlhelper.cerrarconexion()
                End Select
            Next
            calculardigitoverificadorvertical(tabla)
            sqlhelper.cerrarconexion()
            Return True
        Catch ex As Exception
            Return False
        Finally
            sqlhelper.cerrarconexion()
        End Try

    End Function


	End Class ' Digito_Verificador


