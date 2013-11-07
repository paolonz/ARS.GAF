Public Class StandardFlusso
    Inherits BaseFlusso
    Implements ARS.GAF.Core.IFlusso

    Event DisplayMessage(ByVal message As DisplayMessageArgs) Implements ARS.GAF.Core.IFlusso.DisplayMessage


    Public Sub SuperMessage(ByVal message As DisplayMessageArgs)

        RaiseEvent DisplayMessage(message)

        If (message.Severity = DisplayMessageSeverity.Errore) Then
            'AccodaNote(message)
        End If

    End Sub

    Public Overridable Sub Init() Implements ARS.GAF.Core.IFlusso.Init
        AddHandler MyBase.DisplayInnerMessage, AddressOf SuperMessage
    End Sub
    Private _mailer As Mailer
    Public Property Mailer() As Mailer Implements ARS.GAF.Core.IFlusso.Mailer
        Get
            Return _mailer
        End Get
        Set(ByVal value As Mailer)
            _mailer = value
        End Set
    End Property


    Public ReadOnly Property FileXSD1() As String Implements ARS.GAF.Core.IFlusso.FileXSD1
        Get
            Return _fileXSD1
        End Get
    End Property

    Public ReadOnly Property FileXSD2() As String Implements ARS.GAF.Core.IFlusso.FileXSD2
        Get
            Return _fileXSD2
        End Get
    End Property

    Public Overridable Sub AccodaNote(ByVal errore As String) Implements Core.IFlusso.AccodaNote
        Repository.AccodaNote(errore)
    End Sub

    Public Overridable Sub AccodaRicevuta(ByVal storedprocedure As String) Implements Core.IFlusso.AccodaRicevuta
        Repository.AccodaRicevuta(storedprocedure)
    End Sub

    Public ReadOnly Property ControlloImmediato As Boolean Implements Core.IFlusso.ControlloImmediato
        Get
            Return False
        End Get
    End Property


    Public Function Controlla(ByVal attivita As Attivita) As Boolean Implements Core.IFlusso.Controlla
        Message(String.Format("Procedura di controllo per l'attività {0} del flusso {1} avviata", attivita.Codice, attivita.Flusso.Nome), DisplayMessageSeverity.Info)
        Message(String.Format("Trovati {0} files associati alla attività {1}", attivita.Files.Count, attivita.Codice), DisplayMessageSeverity.Info)
        If (DecomprimiFile(attivita)) Then
            If (InserisciFile(attivita)) Then
                Importa(attivita)
                AccodaRicevuta("")
                Accoda(attivita)
                If (InviaResoconto(attivita)) Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Private _flussoKey As String
    Public Property FlussoKey() As String Implements Core.IFlusso.FlussoKey
        Get
            Return _flussoKey
        End Get
        Set(ByVal value As String)
            _flussoKey = value
        End Set
    End Property

    Private _id As Integer
    Public Property ID() As Integer Implements Core.IFlusso.ID
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _controllo As Controllo
    Public Property Controllo() As Controllo Implements Core.IFlusso.Controllo
        Get
            Return _controllo
        End Get
        Set(ByVal value As Controllo)
            _controllo = value
        End Set
    End Property

    Private _starterConfig As StarterConfig
    Public Property StarterConfig() As StarterConfig Implements Core.IFlusso.StarterConfig
        Get
            Return _starterConfig
        End Get
        Set(ByVal value As StarterConfig)
            _starterConfig = value
        End Set
    End Property

End Class
