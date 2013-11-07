Public Class BaseRepository


    Private _connString As String

    Property connString As String
        Get
            Return _connString
        End Get
        Private Set(ByVal value As String)
            _connString = value
        End Set
    End Property

    Public Sub New(ByVal connString As String)
        Me.connString = connString
    End Sub



End Class
