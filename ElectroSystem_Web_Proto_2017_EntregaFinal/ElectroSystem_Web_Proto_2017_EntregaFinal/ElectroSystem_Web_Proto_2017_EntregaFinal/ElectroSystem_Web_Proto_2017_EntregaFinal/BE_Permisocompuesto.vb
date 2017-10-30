Public Class BE_Permisocompuesto
    Inherits BE_PermisoBase


    Private _lista_permisos As New List(Of BE_PermisoBase)

    Public Property lista_permisos() As List(Of BE_PermisoBase)
        Get
            Return _lista_permisos
        End Get
        Set(ByVal Value As List(Of BE_PermisoBase))
            _lista_permisos = Value
			End Set
    End Property


End Class