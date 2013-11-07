Public Class ColorListBoxItem

    Private _itemColor As Color
    Public Property ItemColor() As Color
        Get
            Return _itemColor
        End Get
        Set(ByVal value As Color)
            _itemColor = value
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

    Private _bold As Boolean
    Public Property Bold() As Boolean
        Get
            Return _bold
        End Get
        Set(ByVal value As Boolean)
            _bold = value
        End Set
    End Property




    End Class
