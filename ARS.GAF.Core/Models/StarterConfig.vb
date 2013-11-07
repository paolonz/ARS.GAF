Public Class StarterConfig
    Private _sevenZipDllPath As String
    Public Property SevenZipDllPath() As String
        Get
            Return _sevenZipDllPath
        End Get
        Set(ByVal value As String)
            _sevenZipDllPath = value
        End Set
    End Property

    Private _ftpFolderPath As String
    Public Property FtpFolderPath() As String
        Get
            Return _ftpFolderPath
        End Get
        Set(ByVal value As String)
            _ftpFolderPath = value
        End Set
    End Property

    Private _xsdFolderPath As String
    Public Property XsdFolderPath() As String
        Get
            Return _xsdFolderPath
        End Get
        Set(ByVal value As String)
            _xsdFolderPath = value
        End Set
    End Property

    Private _resocontoPath As String
    Public Property ResocontoPath() As String
        Get
            Return _resocontoPath
        End Get
        Set(ByVal value As String)
            _resocontoPath = value
        End Set
    End Property

    Private _formatiPath As String
    Public Property FormatiPath() As String
        Get
            Return _formatiPath
        End Get
        Set(ByVal value As String)
            _formatiPath = value
        End Set
    End Property

    'Private _tracciatoErroriPath As String
    'Public Property TracciatoErroriPath() As String
    '    Get
    '        Return _tracciatoErroriPath
    '    End Get
    '    Set(ByVal value As String)
    '        _tracciatoErroriPath = value
    '    End Set
    'End Property
End Class
