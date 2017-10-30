Public Class Be_Ficha_Bitacora
    Inherits BE_Bitacora


    Private _fecha_hasta_hora As DateTime?

    Public Property fecha_hasta_hora() As DateTime?
        Get
            Return _fecha_hasta_hora
        End Get
        Set(ByVal Value As DateTime?)
            _fecha_hasta_hora = Value
			End Set
    End Property


End Class

