Public Class General_Inicio
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub mostrarmodal(etiqueta As String, idioma As BE.BE_Idioma)
        'Response.Write("<div id='modal-box' style='background-color:red; position: absolute; padding-top: 100px; z-index: 1000;'> <input type='button' value='X' id='cerrarmodal' onclick='eliminar_modal()'>" & Me.Traductora(etiqueta) & "</div>")

        Dim msgHTML As String

        msgHTML = "<div id='modal-box' style='background-color:red;position: fixed;z-index: 1000;padding-top: 100px;left: 0;top: 0;width: 100%;height: 100%;overflow: auto;background-color: rgb(0,0,0); background-color: rgba(0,0,0,0.4);'> " & _
                        "<div style='background-color: #fefefe; margin: auto; padding: 20px; border: 1px solid #888; width: 80%;'>" & _
                            "<div style='float: right;'>" & _
                                "<input type='button' value='X' id='cerrarmodal' onclick='eliminar_modal()'>" & _
                            "</div>" & _
                            "<p>" & Me.Traductora(etiqueta, idioma) & "</p>" & _
                        "</div>" & _
                    "</div>"

        Response.Write(msgHTML)

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