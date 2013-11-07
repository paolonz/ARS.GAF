Public Class File


    Private _valido As String
    Public Property Valido() As String
        Get
            Return _valido
        End Get
        Set(ByVal value As String)
            _valido = value
        End Set
    End Property


    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _posizione As Integer
    Public Property Posizione() As Integer
        Get
            Return _posizione
        End Get
        Set(ByVal value As Integer)
            _posizione = value
        End Set
    End Property


    Private _progressivoTrasmissione As Integer
    Public Property ProgressivoTrasmissione() As Integer
        Get
            Return _progressivoTrasmissione
        End Get
        Set(ByVal value As Integer)
            _progressivoTrasmissione = value
        End Set
    End Property

    Private _progressivoCompressione As Integer
    Public Property ProgressivoCompressione() As Integer
        Get
            Return _progressivoCompressione
        End Get
        Set(ByVal value As Integer)
            _progressivoCompressione = value
        End Set
    End Property


    Private _tracciatoFile As String
    Public Property TracciatoFile() As String
        Get
            Return _tracciatoFile
        End Get
        Set(ByVal value As String)
            _tracciatoFile = value
        End Set
    End Property


    Private _tabDestinazione As String
    Public Property TabDestinazione() As String
        Get
            Return _tabDestinazione
        End Get
        Set(ByVal value As String)
            _tabDestinazione = value
        End Set
    End Property

    Private _namespace As String
    Public Property [Namespace]() As String
        Get
            Return _namespace
        End Get
        Set(ByVal value As String)
            _namespace = value
        End Set
    End Property


    Private _nomeFile As String
    Public Property NomeFile() As String
        Get
            Return _nomeFile
        End Get
        Set(ByVal value As String)
            _nomeFile = value
        End Set
    End Property

    Private _fileSalvato As String
    Public Property FileSalvato() As String
        Get
            Return _fileSalvato
        End Get
        Set(ByVal value As String)
            _fileSalvato = value
        End Set
    End Property
End Class
