﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------





Namespace My

    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(), _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.tingsDesigner.tingsSingleFileGenerator", "11.0.0.0"), _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Partial Friend NotInheritable Class Mysettings
        Inherits Global.System.Configuration.ApplicationSettingsBase

        Private Shared defaultInstance As Mysettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Mysettings), Mysettings)

#Region "My.tings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
        Private Shared addedHandler As Boolean

        Private Shared addedHandlerLockObject As New Object

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Shared Sub AutoSavetings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
            If My.Application.SaveMytingsOnExit Then
                My.tings.Save()
            End If
        End Sub
#End If
#End Region

        Public Shared ReadOnly Property [Default]() As Mysettings
            Get

#If _MyType = "WindowsForms" Then
                   If Not addedHandler Then
                        SyncLock addedHandlerLockObject
                            If Not addedHandler Then
                                AddHandler My.Application.Shutdown, AddressOf AutoSavetings
                                addedHandler = True
                            End If
                        End SyncLock
                    End If
#End If
                Return defaultInstance
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MytingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.tings")> _
        Friend ReadOnly Property tings() As Global.DAL.My.Mysettings
            Get
                Return Global.DAL.My.Mysettings.Default
            End Get
        End Property
    End Module
End Namespace
