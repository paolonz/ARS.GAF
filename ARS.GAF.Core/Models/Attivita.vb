Public Class Attivita

    Private _codice As Integer
    Public Property Codice() As Integer
        Get
            Return _codice
        End Get
        Set(ByVal value As Integer)
            _codice = value
        End Set
    End Property

    Private _flusso As Flusso
    Public Property Flusso() As Flusso
        Get
            Return _flusso
        End Get
        Set(ByVal value As Flusso)
            _flusso = value
        End Set
    End Property

    Private _referente As Referente
    Public Property Referente() As Referente
        Get
            Return _referente
        End Get
        Set(ByVal value As Referente)
            _referente = value
        End Set
    End Property


    Private _gestore As Gestore
    Public Property Gestore() As Gestore
        Get
            Return _gestore
        End Get
        Set(ByVal value As Gestore)
            _gestore = value
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


    Private _files As List(Of File)
    Public Property Files() As List(Of File)
        Get
            Return _files
        End Get
        Set(ByVal value As List(Of File))
            _files = value
        End Set
    End Property


    Private _dataInserimento As DateTime
    Public Property DataInserimento() As DateTime
        Get
            Return _dataInserimento
        End Get
        Set(ByVal value As DateTime)
            _dataInserimento = value
        End Set
    End Property


    Private _validita As Boolean
    Public Property Validita() As Boolean
        Get
            Return _validita
        End Get
        Set(ByVal value As Boolean)
            _validita = value
        End Set
    End Property

    Public Sub New()
        Flusso = New Flusso
        Referente = New Referente
        Gestore = New Gestore
        Periodo = New Periodo
    End Sub


End Class
