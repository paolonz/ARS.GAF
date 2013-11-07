Public Class Controllo
    Private _flusso As Flusso
    Public Property Flusso() As Flusso
        Get
            Return _flusso
        End Get
        Set(ByVal value As Flusso)
            _flusso = value
        End Set
    End Property


    Private _periodo As Periodo
    Public Property Periodo() As Periodo
        Get
            Return _periodo
        End Get
        Set(ByVal value As Periodo)
            _periodo = value
        End Set
    End Property


    Private _dbConfig As DBConfig
    Public Property DBConfig() As DBConfig
        Get
            Return _dbConfig
        End Get
        Set(ByVal value As DBConfig)
            _dbConfig = value
        End Set
    End Property


    Private _dts As String
    Public Property DTS() As String
        Get
            Return _dts
        End Get
        Set(ByVal value As String)
            _dts = value
        End Set
    End Property


    Private _dtsAccodamento As String
    Public Property DTSAccodamento() As String
        Get
            Return _dtsAccodamento
        End Get
        Set(ByVal value As String)
            _dtsAccodamento = value
        End Set
    End Property


    Private _tipo As TipoControllo
    Public Property Tipo() As TipoControllo
        Get
            Return _tipo
        End Get
        Set(ByVal value As TipoControllo)
            _tipo = value
        End Set
    End Property

    Private _emailTemplate As String
    Public Property EmailTemplate() As String
        Get
            Return _emailTemplate
        End Get
        Set(ByVal value As String)
            _emailTemplate = value
        End Set
    End Property


    Private _cartellaOutput As String
    Public Property CartellaOutput() As String
        Get
            Return _cartellaOutput
        End Get
        Set(ByVal value As String)
            _cartellaOutput = value
        End Set
    End Property

    ' Verificare quello che è TODO
    Private _cartellaCond As String
    Public Property CartellaCond() As String
        Get
            Return _cartellaCond
        End Get
        Set(ByVal value As String)
            _cartellaCond = value
        End Set
    End Property

    ' Per ora ce l'ho messa ma considera che potrebbe non aver senso richiamare un tool esterno
    ' per scompattare un file. Si prende una dll e si fa internamente senza bisogno di passare per un software esterno
    ' TODO
    Private _lineaComando As String
    Public Property LineaComando() As String
        Get
            Return _lineaComando
        End Get
        Set(ByVal value As String)
            _lineaComando = value
        End Set
    End Property

    Private _tracciato As Tracciato
    Public Property Tracciato() As Tracciato
        Get
            Return _tracciato
        End Get
        Set(ByVal value As Tracciato)
            _tracciato = value
        End Set
    End Property


    Private _driveFile As String
    Public Property DriveFile() As String
        Get
            Return _driveFile
        End Get
        Set(ByVal value As String)
            _driveFile = value
        End Set
    End Property

    Public Sub New()
        Flusso = New Flusso
        Periodo = New Periodo
        DBConfig = New DBConfig
        Tracciato = New Tracciato
    End Sub

End Class
