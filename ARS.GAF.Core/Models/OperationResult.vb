Public Class OperationResult

    Private _success As Boolean
    Public Property Success() As Boolean
        Get
            Return _success
        End Get
        Set(ByVal value As Boolean)
            _success = value
        End Set

    End Property

    Private _message As String
    Public Property Message() As String
        Get
            Return _message
        End Get
        Set(ByVal value As String)
            _message = value
        End Set
    End Property

    Private _paramater As String
    Public Property Parameter() As String
        Get
            Return _paramater
        End Get
        Set(ByVal value As String)
            _paramater = value
        End Set
    End Property

    Private _data As Object
    Public Property Data() As Object
        Get
            Return _data
        End Get
        Set(ByVal value As Object)
            _data = value
        End Set
    End Property

End Class
