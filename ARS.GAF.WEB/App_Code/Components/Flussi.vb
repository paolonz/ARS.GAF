Imports Microsoft.VisualBasic

Public Class Flussi

    Private _ID As Integer
    Public Property ID As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _Flusso As String
    Public Property Flusso As String
        Get
            Return _Flusso
        End Get
        Set(ByVal value As String)
            _Flusso = value
        End Set
    End Property

    Private _CodiceFlusso As String
    Public Property CodiceFlusso As String
        Get
            Return _CodiceFlusso
        End Get
        Set(ByVal value As String)
            _CodiceFlusso = value
        End Set
    End Property

End Class
