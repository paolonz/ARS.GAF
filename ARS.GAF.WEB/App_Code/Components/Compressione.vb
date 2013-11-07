Imports Microsoft.VisualBasic

Public Class Compressione

    Private _ID As Integer
    Public Property ID As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _Compressione As String
    Public Property Compressione As String
        Get
            Return _Compressione
        End Get
        Set(ByVal value As String)
            _Compressione = value
        End Set
    End Property

    Private _Estensione As String
    Public Property Estensione As String
        Get
            Return _Estensione
        End Get
        Set(ByVal value As String)
            _Estensione = value
        End Set
    End Property

End Class
