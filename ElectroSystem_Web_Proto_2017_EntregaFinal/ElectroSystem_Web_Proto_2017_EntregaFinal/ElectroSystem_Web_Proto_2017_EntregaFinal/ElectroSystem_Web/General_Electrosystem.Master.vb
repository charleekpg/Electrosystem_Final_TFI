Public Class General_Electrosystem
    Inherits System.Web.UI.MasterPage
    Private _puede As Boolean = False
    Public ReadOnly Property puede() As Boolean
        Get
            Return _puede
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function Habilitar_Permiso_Formulario(formulario As String) As Boolean
        Dim bll_permisos As New BLL.BLL_Permisos
        Try
            Dim be_permisobase As New BE.BE_Permisocompuesto
            be_permisobase.idpermiso = formulario
            Return bll_permisos.validar_permiso(be_permisobase, Session("Usuario"))
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub traducir_grilla(grilla As GridView)

        Try
            For Each elemento In grilla.Columns
                If TypeOf elemento Is BoundField OrElse TypeOf elemento Is CheckBoxField Then
                    elemento.HeaderText = Me.Traductora(elemento.FooterText)
                End If
            Next
            ' tRow.Cells.Add(celda)
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try

    End Sub

    Public Sub Deshabilitar_Controles(controles As ControlCollection)
        Dim bll_permisos As New BLL.BLL_Permisos
        Try
            For Each contro As Control In controles
                If contro.ClientID.StartsWith("menus") = True Then
                    Dim be_permisobase As New BE.BE_Permisocompuesto
                    be_permisobase.idpermiso = contro.ClientID
                    CType(contro, HtmlAnchor).Visible = bll_permisos.validar_permiso(be_permisobase, Session("Usuario"))
                Else
                    Me.Deshabilitar_Controles(contro.Controls)
                End If
            Next
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx")
        End Try

    End Sub

    Public Sub mostrarmodal(etiqueta As String, Optional etiqueta2 As String = "")
        'Response.Write("<div id='modal-box' style='background-color:red; position: absolute; padding-top: 100px; z-index: 1000;'> <input type='button' value='X' id='cerrarmodal' onclick='eliminar_modal()'>" & Me.Traductora(etiqueta) & "</div>")

        Dim msgHTML As String

        msgHTML = "<div id='modal-box' style='background-color:red;position: fixed;z-index: 1000;padding-top: 100px;left: 0;top: 0;width: 100%;height: 100%;overflow: auto;background-color: rgb(0,0,0); background-color: rgba(0,0,0,0.4);'> " & _
                        "<div style='background-color: #fefefe; margin: auto; padding: 20px; border: 1px solid #888; width: 80%;'>" & _
                            "<div style='float: right;'>" & _
                                "<input type='button' value='X' id='cerrarmodal' onclick='eliminar_modal()'>" & _
                            "</div>" & _
                            "<p>" & Me.Traductora(etiqueta) & " " & etiqueta2 & "</p>" & _
                        "</div>" & _
                    "</div>"

        Response.Write(msgHTML)

    End Sub

    Public Sub mostrarmodalredireccion(etiqueta As String, url As String)
        'Response.Write("<div id='modal-box' style='background-color:red; position: absolute; padding-top: 100px; z-index: 1000;'> <input type='button' value='X' id='cerrarmodal' onclick='eliminar_modal()'>" & Me.Traductora(etiqueta) & "</div>")

        Dim msgHTML As String
        Dim fix_char As String = "'funcion_redirect(""" + url + """);'"

        msgHTML = "<div id='modal-box' style='background-color:red;position: fixed;z-index: 1000;padding-top: 100px;left: 0;top: 0;width: 100%;height: 100%;overflow: auto;background-color: rgb(0,0,0); background-color: rgba(0,0,0,0.4);'> " & _
                        "<div style='background-color: #fefefe; margin: auto; padding: 20px; border: 1px solid #888; width: 80%;'>" & _
                            "<div style='float: right;'>" & _
                                "<input type='button' value='X' id='cerrarmodal' onclick=" & fix_char & ">" & _
                            "</div>" & _
                            "<p>" & Me.Traductora(etiqueta) & "</p>" & _
                        "</div>" & _
                    "</div>"


        Response.Write(msgHTML)

    End Sub
    Public Function Traductora(etiqueta As String) As String
        Try
            Dim traduccion As String
            Dim idioma_sesion As BE.BE_Idioma
            idioma_sesion = DirectCast(DirectCast(Session("Usuario"), BE.BE_Usuario).Idioma, BE.BE_Idioma)
            traduccion = idioma_sesion.be_etiqueta.Find(Function(x) x.id_control = etiqueta).nombre_traduccion
            Return traduccion
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx")
        End Try


    End Function

    Public Function buscar_en_espanol_ambiente(etiqueta As String) As String
        Try
            Dim control As String
            Dim idioma_sesion As BE.BE_Idioma

            idioma_sesion = DirectCast(DirectCast(Session("Usuario"), BE.BE_Usuario).Idioma, BE.BE_Idioma)
            control = idioma_sesion.be_etiqueta.Find(Function(x) x.nombre_traduccion = etiqueta).id_control
            Return control

        Catch ex As Exception

        End Try

    End Function


    Public Sub traductora_controles(controles As ControlCollection)
        Try
            For Each contro As Control In controles
                If TypeOf contro Is Label Then
                    If Not CType(contro, Label).ID = "lbl_nobuscar_nombreusuario" AndAlso Not CType(contro, Label).ID = "lbl_ambiente_anotacion" Then
                        CType(contro, Label).Text = Me.Traductora(CType(contro, Label).ID)
                    Else
                        lbl_nobuscar_nombreusuario.Text = CType(Session("Usuario"), BE.BE_Usuario).Nombre_Usuario
                    End If
                Else
                    If TypeOf contro Is Button Then
                        CType(contro, Button).Text = Me.Traductora(CType(contro, Button).ID)
                    Else
                        If TypeOf contro Is Menu Then
                            For Each item As MenuItem In CType(contro, Menu).Items
                                item.Text = Me.Traductora(item.Value)
                            Next
                        ElseIf TypeOf contro Is LinkButton Then
                            CType(contro, LinkButton).Text = Me.Traductora(CType(contro, LinkButton).ID)
                        ElseIf TypeOf contro Is CheckBox Then
                            CType(contro, CheckBox).Text = Me.Traductora(CType(contro, CheckBox).ID)
                        Else
                            If TypeOf contro Is RangeValidator Then
                                CType(contro, RangeValidator).Text = Me.Traductora(CType(contro, RangeValidator).ID)
                            Else
                                If TypeOf contro Is HiddenField Then
                                Else
                                        Me.traductora_controles(contro.Controls)
                                    End If
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            Response.Redirect("web_error_inicio.aspx", False)
        End Try
    End Sub

    Protected Sub menu_cerrarsesion_Click(sender As Object, e As EventArgs) Handles men_cerrarsesion.Click
        Session.Abandon()
        Response.Redirect("web_inicio.aspx", False)
    End Sub


End Class