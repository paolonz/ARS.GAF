Public Class OperationResult

    Private _success As Boolean
    Public ReadOnly Property Success() As Boolean

        Get
            Return _success
        End Get

    End Property

    Private _message As String
    Public ReadOnly Property Message() As String

        Get
            Return _message
        End Get
    End Property

    Private _data As Object
    Public ReadOnly Property Data() As Object
        Get
            Return _data
        End Get
    End Property

    Public Sub New(ByVal success As Boolean, ByVal message As String, ByVal data As Object)
        _success = success
        _message = message
        _data = data
    End Sub

End Class