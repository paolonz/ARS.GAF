Imports ARS.GAF.Core
Imports System.Configuration
Imports System.Text

Public Class SpecialisticaFlusso
    Inherits BaseFlusso
    Implements IFlusso

    Public Event DisplayMessage(ByVal message As Core.DisplayMessageArgs) Implements Core.IFlusso.DisplayMessage
#Region "Private properties"
    Dim _flussoRepo As SpecialisticaRepository
#End Region

#Region "IFlusso interfaces"

    Public Sub Init() Implements Core.IFlusso.Init
        _flussoRepo = New SpecialisticaRepository(Me.Controllo.DBConfig, Me.StarterConfig)
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
        Repository.AccodaNote(errore)
    End Sub

    Public Sub AccodaRicevuta(ByVal storedprocedure As String) Implements Core.IFlusso.AccodaRicevuta
        Repository.AccodaRicevuta(storedprocedure)
    End Sub

    Public ReadOnly Property ControlloImmediato As Boolean Implements Core.IFlusso.ControlloImmediato
        Get
            Return False
        End Get
    End Property


    


    Public Function Controlla(ByVal attivita As Core.Attivita) As Boolean Implements Core.IFlusso.Controlla
        Message(String.Format("Procedura di controllo per l'attività {0} del flusso Specialistica avviata", attivita.Codice), DisplayMessageSeverity.Info)
        Message(String.Format("Trovati {0} files associati alla attività {1}", attivita.Files.Count, attivita.Codice), DisplayMessageSeverity.Info)
        If (DecomprimiFile(attivita)) Then
            If (InserisciFile(attivita)) Then
                _flussoRepo.Importa(attivita, Controllo)

                _flussoRepo.Accoda(Controllo.Flusso.ID, attivita.Periodo.Nome)
                If (InviaResoconto(attivita)) Then
                    Return True
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

#Region "Private Methods"

    Private Function InserisciFile(ByVal Attivita As Attivita) As Boolean
        Dim op As OperationResult = _flussoRepo.PulisciTabelle()
        If (op.Success) Then
            Message(op.Message, DisplayMessageSeverity.Info)
        Else
            Message(op.Message, DisplayMessageSeverity.Errore)
            Return False
        End If

        Dim tableC2 As DataTable
        Dim tableC1 As DataTable
        Dim data As DateTime = DateTime.Now
        For Each file As File In Attivita.Files.OrderByDescending(Function(x) x.NomeFile)

            Try
                If (file.FileSalvato.Contains("_1")) Then
                    'lato FILE C1
                    Message(String.Format("Parsing del file {0} in corso ...", file.NomeFile), DisplayMessageSeverity.Info)
                    tableC1 = FileReader.ParseC1(file.NomeFile, "PLNFRC82S26L366I", data, tableC2)
                    Message(String.Format("Inserimento del file {0} all'interno del database in corso", file.NomeFile), DisplayMessageSeverity.Info)
                    op = _flussoRepo.InserisciRecord(tableC1, "SPECIALISTICA_C1_Elaborazione")
                Else
                    'lato FILE C2
                    Message(String.Format("Parsing del file {0} in corso ...", file.NomeFile), DisplayMessageSeverity.Info)
                    tableC2 = FileReader.ParseC2(file.NomeFile, "PLNFRC82S26L366I", data)
                    Message(String.Format("Inserimento del file {0} all'interno del database in corso", file.NomeFile), DisplayMessageSeverity.Info)
                    op = _flussoRepo.InserisciRecord(tableC2, "SPECIALISTICA_C2_Elaborazione")
                End If

                If (op.Success) Then
                    Message(String.Format(op.Message, file.NomeFile), DisplayMessageSeverity.Info)
                Else
                    Message(op.Message, DisplayMessageSeverity.Errore)
                    Return False
                End If

            Catch ex As Exception
                'mailer.SendMail("Errore nella procedura di inserimento record", "La funzione di inserimento ha generato il seguente errore : " & ex.Message, "federico.paoloni@e-lios.eu; andrea.caputo@e-lios.eu")
                'mailer.SendMail("Errore nella procedura di inserimento record", Controllo.EmailTemplate & "<br>" & "La funzione di inserimento ha generato il seguente errore: " & ex.Message, "andrea.caputo@e-lios.eu"
                Return False
            End Try
        Next
        Return True
    End Function

#End Region

End Class

