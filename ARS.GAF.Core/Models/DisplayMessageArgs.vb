Public Class DisplayMessageArgs

    Private _message As String
    Public Property Message() As String
        Get
            Return _message
        End Get
        Set(ByVal value As String)
            _message = value
        End Set
    End Property

    Private _serverity As DisplayMessageSeverity
    Public Property Severity() As DisplayMessageSeverity
        Get
            Return _serverity
        End Get
        Set(ByVal value As DisplayMessageSeverity)
            _serverity = value
        End Set
    End Property

   


End Class
