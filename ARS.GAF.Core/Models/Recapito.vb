Public Class Recapito
    Private _email As String
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _fax As String
    Public Property Fax() As String
        Get
            Return _fax
        End Get
        Set(ByVal value As String)
            _fax = value
        End Set
    End Property

    Private _telefono As String
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property
End Class
