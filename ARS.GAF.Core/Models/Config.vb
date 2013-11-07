Public Class Config
    'Mappa i dati che si trovano dentro la tabella T_Sys_Controllo

    Private _emailAmministratore As String
    Public Property EmailAmministratore() As String
        Get
            Return _emailAmministratore
        End Get
        Set(ByVal value As String)
            _emailAmministratore = value
        End Set
    End Property

    Private _serverSmtp As String
    Public Property ServerSmtp() As String
        Get
            Return _serverSmtp
        End Get
        Set(ByVal value As String)
            _serverSmtp = value
        End Set
    End Property

    Private _serverFtp As String
    Public Property ServerFtp() As String
        Get
            Return _serverFtp
        End Get
        Set(ByVal value As String)
            _serverFtp = value
        End Set
    End Property


    Private _account As String
    Public Property Account() As String
        Get
            Return _account
        End Get
        Set(ByVal value As String)
            _account = value
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

    Private _serverWeb As String
    Public Property ServerWeb() As String
        Get
            Return _serverWeb
        End Get
        Set(ByVal value As String)
            _serverWeb = value
        End Set
    End Property
End Class
