Public Class FileC2

    Private _utente As String
    Public Property Utente() As String
        Get
            Return _utente
        End Get
        Set(ByVal value As String)
            _utente = value
        End Set
    End Property

    Private _regioneAddebitante As String
    Public Property RegioneAddebitante() As String
        Get
            Return _regioneAddebitante
        End Get
        Set(ByVal value As String)
            _regioneAddebitante = value
        End Set
    End Property

    Private _aslInviante As String
    Public Property AslInviante() As String
        Get
            Return _aslInviante
        End Get
        Set(ByVal value As String)
            _aslInviante = value
        End Set
    End Property

    Private _codiceStrutturaAccRic As String
    Public Property CodiceStrutturaAccRic() As String
        Get
            Return _codiceStrutturaAccRic
        End Get
        Set(ByVal value As String)
            _codiceStrutturaAccRic = value
        End Set
    End Property

    Private _codiceStrutturaErogante As String
    Public Property CodiceStrutturaErogante() As String
        Get
            Return _codiceStrutturaErogante
        End Get
        Set(ByVal value As String)
            _codiceStrutturaErogante = value
        End Set
    End Property

    Private _codiceCentroCosto As String
    Public Property CodiceCentroCosto() As String
        Get
            Return _codiceCentroCosto
        End Get
        Set(ByVal value As String)
            _codiceCentroCosto = value
        End Set
    End Property

    Private _numeroRicetta As String
    Public Property NumeroRicetta() As String
        Get
            Return _numeroRicetta
        End Get
        Set(ByVal value As String)
            _numeroRicetta = value
        End Set
    End Property

    Private _prioritaAccessoPrestazioni As String
    Public Property PrioritaAccessoPrestazioni() As String
        Get
            Return _prioritaAccessoPrestazioni
        End Get
        Set(ByVal value As String)
            _prioritaAccessoPrestazioni = value
        End Set
    End Property

    Private _prioritaEffettiva As String
    Public Property PrioritaEffettiva() As String
        Get
            Return _prioritaEffettiva
        End Get
        Set(ByVal value As String)
            _prioritaEffettiva = value
        End Set
    End Property

    Private _tipoPrescrizione As String
    Public Property TipoPrescrizione() As String
        Get
            Return _tipoPrescrizione
        End Get
        Set(ByVal value As String)
            _tipoPrescrizione = value
        End Set
    End Property

    Private _tipoRicetta As String
    Public Property TipoRicetta() As String
        Get
            Return _tipoRicetta
        End Get
        Set(ByVal value As String)
            _tipoRicetta = value
        End Set
    End Property

    Private _prontoSoccorso As String
    Public Property ProntoSoccorso() As String
        Get
            Return _prontoSoccorso
        End Get
        Set(ByVal value As String)
            _prontoSoccorso = value
        End Set
    End Property

    Private _pac As String
    Public Property PAC() As String
        Get
            Return _pac
        End Get
        Set(ByVal value As String)
            _pac = value
        End Set
    End Property

    Private _cicloPrestazioni As String
    Public Property CicloPrestazioni() As String
        Get
            Return _cicloPrestazioni
        End Get
        Set(ByVal value As String)
            _cicloPrestazioni = value
        End Set
    End Property

    Private _progRigaRicetta As String
    Public Property ProgRigaRicetta() As String
        Get
            Return _progRigaRicetta
        End Get
        Set(ByVal value As String)
            _progRigaRicetta = value
        End Set
    End Property

    Private _dataRicetta As String
    Public Property DataRicetta() As String
        Get
            Return _dataRicetta
        End Get
        Set(ByVal value As String)
            _dataRicetta = value
        End Set
    End Property

    Private _dataDispErogazione As String
    Public Property DataDispErogazione() As String
        Get
            Return _dataDispErogazione
        End Get
        Set(ByVal value As String)
            _dataDispErogazione = value
        End Set
    End Property

    Private _dataPrenotazione As String
    Public Property DataPrenotazione() As String
        Get
            Return _dataPrenotazione
        End Get
        Set(ByVal value As String)
            _dataPrenotazione = value
        End Set
    End Property

    Private _dataInizioErogazione As String
    Public Property DataInizioErogazione() As String
        Get
            Return _dataInizioErogazione
        End Get
        Set(ByVal value As String)
            _dataInizioErogazione = value
        End Set
    End Property

    Private _dataFineErogazione As String
    Public Property DataFineErogazione() As String
        Get
            Return _dataFineErogazione
        End Get
        Set(ByVal value As String)
            _dataFineErogazione = value
        End Set
    End Property

    Private _dataReferto As String
    Public Property DataReferto() As String
        Get
            Return _dataReferto
        End Get
        Set(ByVal value As String)
            _dataReferto = value
        End Set
    End Property

    Private _modoAccesso As String
    Public Property ModoAccesso() As String
        Get
            Return _modoAccesso
        End Get
        Set(ByVal value As String)
            _modoAccesso = value
        End Set
    End Property

    Private _tipoAccesso As String
    Public Property TipoAccesso() As String
        Get
            Return _tipoAccesso
        End Get
        Set(ByVal value As String)
            _tipoAccesso = value
        End Set
    End Property

    Private _codiceDiagnosi As String
    Public Property CodiceDiagnosi() As String
        Get
            Return _codiceDiagnosi
        End Get
        Set(ByVal value As String)
            _codiceDiagnosi = value
        End Set
    End Property

    Private _verificaDiagnosi As String
    Public Property VerificaDiagnosi() As String
        Get
            Return _verificaDiagnosi
        End Get
        Set(ByVal value As String)
            _verificaDiagnosi = value
        End Set
    End Property

    Private _codificaNomenclatore As String
    Public Property CodificaNomenclatore() As String
        Get
            Return _codificaNomenclatore
        End Get
        Set(ByVal value As String)
            _codificaNomenclatore = value
        End Set
    End Property

    Private _codiceBrancaPrestazione As String
    Public Property CodiceBrancaPrestazione() As String
        Get
            Return _codiceBrancaPrestazione
        End Get
        Set(ByVal value As String)
            _codiceBrancaPrestazione = value
        End Set
    End Property

    Private _codiceSpecialisticaPrestazione As String
    Public Property CodiceSpecialisticaPrestazione() As String
        Get
            Return _codiceSpecialisticaPrestazione
        End Get
        Set(ByVal value As String)
            _codiceSpecialisticaPrestazione = value
        End Set
    End Property

    Private _codicePrestazione As String
    Public Property CodicePrestazione() As String
        Get
            Return _codicePrestazione
        End Get
        Set(ByVal value As String)
            _codicePrestazione = value
        End Set
    End Property

    Private _numPrestazioni As String
    Public Property NumeroPrestazioni() As String
        Get
            Return _numPrestazioni
        End Get
        Set(ByVal value As String)
            _numPrestazioni = value
        End Set
    End Property

    Private _tariffaPrestazione As String
    Public Property TariffaPrestazione() As String
        Get
            Return _tariffaPrestazione
        End Get
        Set(ByVal value As String)
            _tariffaPrestazione = value
        End Set
    End Property

    Private _percScontoDaApplicare As String
    Public Property PercentualeScontoDaApplicare() As String
        Get
            Return _percScontoDaApplicare
        End Get
        Set(ByVal value As String)
            _percScontoDaApplicare = value
        End Set
    End Property

    Private _importoSconto As String
    Public Property ImportoSconto() As String
        Get
            Return _importoSconto
        End Get
        Set(ByVal value As String)
            _importoSconto = value
        End Set
    End Property

    Private _tipoEsenzione As String
    Public Property TipoEsenzione() As String
        Get
            Return _tipoEsenzione
        End Get
        Set(ByVal value As String)
            _tipoEsenzione = value
        End Set
    End Property

    Private _codiceEsenzione As String
    Public Property CodiceEsenzione() As String
        Get
            Return _codiceEsenzione
        End Get
        Set(ByVal value As String)
            _codiceEsenzione = value
        End Set
    End Property

    Private _quotaFissaRicetta As String
    Public Property QuotaFissaRicetta() As String
        Get
            Return _quotaFissaRicetta
        End Get
        Set(ByVal value As String)
            _quotaFissaRicetta = value
        End Set
    End Property

    Private _ticketPagato As String
    Public Property TicketPagato() As String
        Get
            Return _ticketPagato
        End Get
        Set(ByVal value As String)
            _ticketPagato = value
        End Set
    End Property

    Private _quotaFissaAssistito As String
    Public Property QuotaFissaAssistito() As String
        Get
            Return _quotaFissaAssistito
        End Get
        Set(ByVal value As String)
            _quotaFissaAssistito = value
        End Set
    End Property

    Private _importoTotale As String
    Public Property ImportoTotale() As String
        Get
            Return _importoTotale
        End Get
        Set(ByVal value As String)
            _importoTotale = value
        End Set
    End Property

    Private _posizioneContabile As String
    Public Property PosizioneContabile() As String
        Get
            Return _posizioneContabile
        End Get
        Set(ByVal value As String)
            _posizioneContabile = value
        End Set
    End Property

    Private _trasmRegione As String
    Public Property TrasmRegione As String
        Get
            Return _trasmRegione
        End Get
        Set(ByVal value As String)
            _trasmRegione = value
        End Set
    End Property

    Private _err01 As String
    Public Property Err01() As String
        Get
            Return _err01
        End Get
        Set(ByVal value As String)
            _err01 = value
        End Set
    End Property

    Private _err02 As String
    Public Property Err02() As String
        Get
            Return _err02
        End Get
        Set(ByVal value As String)
            _err02 = value
        End Set
    End Property

    Private _err03 As String
    Public Property Err03() As String
        Get
            Return _err03
        End Get
        Set(ByVal value As String)
            _err03 = value
        End Set
    End Property

    Private _err04 As String
    Public Property Err04() As String
        Get
            Return _err04
        End Get
        Set(ByVal value As String)
            _err04 = value
        End Set
    End Property

    Private _err05 As String
    Public Property Err05() As String
        Get
            Return _err05
        End Get
        Set(ByVal value As String)
            _err05 = value
        End Set
    End Property

    Private _err06 As String
    Public Property Err06() As String
        Get
            Return _err06
        End Get
        Set(ByVal value As String)
            _err06 = value
        End Set
    End Property

    Private _err07 As String
    Public Property Err07() As String
        Get
            Return _err07
        End Get
        Set(ByVal value As String)
            _err07 = value
        End Set
    End Property

    Private _err08 As String
    Public Property Err08() As String
        Get
            Return _err08
        End Get
        Set(ByVal value As String)
            _err08 = value
        End Set
    End Property

    Private _err09 As String
    Public Property Err09() As String
        Get
            Return _err09
        End Get
        Set(ByVal value As String)
            _err09 = value
        End Set
    End Property

    Private _err10 As String
    Public Property Err10() As String
        Get
            Return _err10
        End Get
        Set(ByVal value As String)
            _err10 = value
        End Set
    End Property

    Private _prestazioneRicovero As String
    Public Property PrestazioneRicovero() As String
        Get
            Return _prestazioneRicovero
        End Get
        Set(ByVal value As String)
            _prestazioneRicovero = value
        End Set
    End Property

    Private _id As String
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _regioneAddebito As String
    Public Property RegioneAddebito() As String
        Get
            Return _regioneAddebito
        End Get
        Set(ByVal value As String)
            _regioneAddebito = value
        End Set
    End Property

    Private _flagErrore As String
    Public Property FlagErrore() As String
        Get
            Return _flagErrore
        End Get
        Set(ByVal value As String)
            _flagErrore = value
        End Set
    End Property

    Private _dataAcquisizione As String
    Public Property DataAcquisizione() As String
        Get
            Return _dataAcquisizione
        End Get
        Set(ByVal value As String)
            _dataAcquisizione = value
        End Set
    End Property

    Private _meseRiferimento As String
    Public Property MeseRiferimento() As String
        Get
            Return _meseRiferimento
        End Get
        Set(ByVal value As String)
            _meseRiferimento = value
        End Set
    End Property

    Private _annoRiferimento As String
    Public Property AnnoRiferimento() As String
        Get
            Return _annoRiferimento
        End Get
        Set(ByVal value As String)
            _annoRiferimento = value
        End Set
    End Property

End Class

