Public Class DBConfig
    Private _connectionString As String
    Public Property ConnectionString() As String
        Get
            Return _connectionString
        End Get
        Set(ByVal value As String)
            _connectionString = value
        End Set
    End Property


    Private _nome As String
    Public Property Nome() As String
        Get
            Return _nome
        End Get
        Set(ByVal value As String)
            _nome = value
        End Set
    End Property


    Private _utente As String
    Public Property Utente() As String
        Get
            Return _utente
        End Get
        Set(ByVal value As String)
            _utente = value
        End Set
    End Property

    Private _password As String
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property

    Private _server As String
    Public Property Server() As String
        Get
            Return _server
        End Get
        Set(ByVal value As String)
            _server = value
        End Set
    End Property

End Class
