Imports Microsoft.VisualBasic

Public Class Trasmissioni

    Private _ID As Integer
    Public Property ID As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _Trasmissione As String
    Public Property Trasmissione As String
        Get
            Return _Trasmissione
        End Get
        Set(ByVal value As String)
            _Trasmissione = value
        End Set
    End Property

End Class
