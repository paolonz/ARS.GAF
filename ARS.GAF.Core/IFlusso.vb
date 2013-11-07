Public Interface IFlusso
    Property Mailer As Mailer
    ReadOnly Property FileXSD1 As String
    ReadOnly Property FileXSD2 As String
    Property Controllo As Controllo
    ReadOnly Property ControlloImmediato As Boolean
    Property ID As Integer
    Property FlussoKey As String
    Property StarterConfig As StarterConfig
    Function Controlla(ByVal attivita As Attivita) As Boolean
    Sub AccodaNote(ByVal errore As String)
    Sub AccodaRicevuta(ByVal storedprocedureName As String)
    Sub Init()
    Event DisplayMessage(ByVal message As DisplayMessageArgs)


End Interface
