Public Class Periodo
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
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

    Private _anno As Integer
    Public Property Anno() As Integer
        Get
            Return _anno
        End Get
        Set(ByVal value As Integer)
            _anno = value
        End Set
    End Property

    Private _mese As Integer
    Public Property Mese() As Integer
        Get
            Return _mese
        End Get
        Set(ByVal value As Integer)
            _mese = value
        End Set
    End Property

    Private _valida As Boolean
    Public Property Valida() As Boolean
        Get
            Return _valida
        End Get
        Set(ByVal value As Boolean)
            _valida = value
        End Set
    End Property

    Private _dataInizio As DateTime
    Public Property DataInizio() As DateTime
        Get
            Return _dataInizio
        End Get
        Set(ByVal value As DateTime)
            _dataInizio = value
        End Set
    End Property

    Private _dataFine As DateTime
    Public Property DataFine() As DateTime
        Get
            Return _dataFine
        End Get
        Set(ByVal value As DateTime)
            _dataFine = value
        End Set
    End Property
End Class
