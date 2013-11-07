Imports ARS.GAF.Core
Imports System.Configuration
Imports System.Text

Public Class FarmaceuticaFlusso
    Inherits BaseFlusso
    Implements IFlusso


    Public Event DisplayMessage(ByVal message As Core.DisplayMessageArgs) Implements Core.IFlusso.DisplayMessage
#Region "Private Properties"

    Dim _flussoRepo As FarmaceuticaRepository

#End Region


#Region "IFlusso interfaces"

    Public Sub Init() Implements Core.IFlusso.Init

        _flussoRepo = New FarmaceuticaRepository(Me.Controllo.DBConfig, Me.StarterConfig)
        SetRepository(_flussoRepo)
        SetControllo(Me.Controllo)
        SetStarterConfig(Me.StarterConfig)

        AddHandler MyBase.DisplayInnerMessage, AddressOf SuperMessage

    End Sub

    Public Sub SuperMessage(ByVal message As DisplayMessageArgs)

        RaiseEvent DisplayMessage(message)

        If (message.Severity = DisplayMessageSeverity.Errore) Then
            'AccodaNote(message)
        End If

    End Sub

    Private _mailer As Mailer
    Public Property Mailer As Core.Mailer Implements Core.IFlusso.Mailer
        Get
            Return _mailer
        End Get
        Set(ByVal value As Core.Mailer)
            _mailer = value
        End Set
    End Property

    Public ReadOnly Property FileXSD1 As String Implements Core.IFlusso.FileXSD1
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property FileXSD2 As String Implements Core.IFlusso.FileXSD2
        Get
            Return ""
        End Get
    End Property

    Public Sub AccodaNote(ByVal errore As String) Implements Core.IFlusso.AccodaNote
        'TODO
        Repository.AccodaNote(errore)
    End Sub

    Public Sub accodaricevuta(ByVal storedprocedure As String) Implements Core.IFlusso.AccodaRicevuta
        Repository.AccodaRicevuta(storedprocedure)
    End Sub

    Public ReadOnly Property ControlloImmediato As Boolean Implements Core.IFlusso.ControlloImmediato
        Get
            Return False
        End Get
    End Property

    Public Function Controlla(ByVal attivita As Core.Attivita) As Boolean Implements Core.IFlusso.Controlla
        Message(String.Format("Procedura di controllo per l'attività {0} del flusso Farmaceutica avviata", attivita.Codice), DisplayMessageSeverity.Info)
        Message(String.Format("Trovati {0} files associati alla attività {1}", attivita.Files.Count, attivita.Codice), DisplayMessageSeverity.Info)
        If (DecomprimiFile(attivita)) Then
            ' Overloadare il metodo Inserisci file
            ' 1) Deve lanciare una stored-procedure per l'inserimento del file nel DB
            ' 2) Eseguire i controlli
            ' 3) Se controlli OK allora generare ricevuta,
            ' Se non OK generare ricevuta e dettaglio senza caricare il file
            If (InserisciFile(attivita)) Then
                If (Importa()) Then
                    Accoda(attivita)
                    If (InviaResoconto(attivita)) Then
                        Return True
                    End If
                End If
            End If
        End If
        Return False
    End Function

    Private _flussoKey As String
    Public Property FlussoKey As String Implements Core.IFlusso.FlussoKey
        Get
            Return _flussoKey
        End Get
        Set(ByVal value As String)
            _flussoKey = value
        End Set
    End Property

    Private _id As Integer
    Public Property ID As Integer Implements Core.IFlusso.ID
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Controllo As Core.Controllo Implements Core.IFlusso.Controllo
        Get
            Return _controllo
        End Get
        Set(ByVal value As Core.Controllo)
            _controllo = value
        End Set
    End Property

    Public Property StarterConfig As Core.StarterConfig Implements Core.IFlusso.StarterConfig
        Get
            Return _starterConfig
        End Get
        Set(ByVal value As Core.StarterConfig)
            _starterConfig = value
        End Set
    End Property

#End Region

#Region "Private methods"

    Private Function InserisciFile(ByVal attivita As Attivita) As Boolean

        For Each file As ARS.GAF.Core.File In attivita.Files
            Message(String.Format("Inserimento del file {0} in corso ...", file.NomeFile), DisplayMessageSeverity.Info)
            Try
                Message(String.Format("Controllo di tipo SQL per il file {0} in corso ...", file.NomeFile), DisplayMessageSeverity.Info)
                'TODO
                Dim op As OperationResult = _flussoRepo.InserisciRecord(file, "CPTNDR86L21A462S", file.TracciatoFile)
                If (op.Success) Then
                    Message(op.Message, DisplayMessageSeverity.Info)
                Else
                    Message(op.Message, DisplayMessageSeverity.Errore)
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        Next

        Return True
    End Function

    Private Function Importa() As Boolean

        Dim status As Boolean = True

        Try
            If (_flussoRepo.EseguiControlli()) Then
                If (_flussoRepo.InserisciRicette()) Then
                    Return True
                Else
                    'ERRORE NELL'INSERIMENTO DELLE RICETTE POST VALIDAZIONE
                    AccodaNote("ERRORE NELL'INSERIMENTO DELLE RICETTE POST VALIDAZIONE")
                End If
            Else
                'ERRORE NELLA VALIDAZIONE DEL FILE
                AccodaNote("Errore nella validazione del file")
            End If
        Catch ex As Exception

        End Try

        Return False
    End Function

#End Region


End Class
