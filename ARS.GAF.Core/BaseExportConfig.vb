Public Class BaseExportConfig
    Private _connectionString As String
    Public Property ConnectionString() As String
        Get
            Return _connectionString
        End Get
        Set(ByVal value As String)
            _connectionString = value
        End Set
    End Property
End Class
