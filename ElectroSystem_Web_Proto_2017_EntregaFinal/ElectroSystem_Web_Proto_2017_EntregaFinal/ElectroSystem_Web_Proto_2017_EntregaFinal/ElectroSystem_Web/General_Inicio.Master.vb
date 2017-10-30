Public Class General_Inicio
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function Traductora(etiqueta As String, idioma As BE.BE_Idioma) As String
        Try
            Dim traduccion As String
            traduccion = idioma.be_etiqueta.Find(Function(x) x.id_control = etiqueta).nombre_traduccion
            Return traduccion
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx")
        End Try
    End Function

    Public Sub traductora_controles(controles As ControlCollection, idioma As BE.BE_Idioma)
        Try
            For Each contro As Control In controles
                If TypeOf contro Is Label Then
                    CType(contro, Label).Text = Me.Traductora(CType(contro, Label).ID, idioma)
                Else
                    If TypeOf contro Is Button Then
                        CType(contro, Button).Text = Me.Traductora(CType(contro, Button).ID, idioma)
                    Else
                        If TypeOf contro Is Menu Then
                            For Each item As MenuItem In CType(contro, Menu).Items
                                item.Text = Me.Traductora(item.Value, idioma)
                            Next
                        Else
                            Me.traductora_controles(contro.Controls, idioma)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx")
        End Try

    End Sub

End Class