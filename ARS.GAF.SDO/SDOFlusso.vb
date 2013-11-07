Imports ARS.GAF.Core
Imports System.Configuration
Imports System.Text
Public Class SDOFlusso
    Inherits BaseFlusso
    Implements IFlusso

    Event DisplayMessage(ByVal message As DisplayMessageArgs) Implements ARS.GAF.Core.IFlusso.DisplayMessage
#Region "Private Properties"

    Dim _flussoRepo As SDORepository

#End Region

#Region "IFlusso interfaces"

    Public Sub Init() Implements ARS.GAF.Core.IFlusso.Init
        _flussoRepo = New SDORepository(Me.Controllo.DBConfig, Me.StarterConfig)
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
            Return ""
        End Get
    End Property

    Public ReadOnly Property FileXSD2() As String Implements ARS.GAF.Core.IFlusso.FileXSD2
        Get
            Return ""
        End Get
    End Property

    Public Sub AccodaNote(ByVal errore As String) Implements Core.IFlusso.AccodaNote
        ''TODO
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

    Public Function Controlla(ByVal attivita As Attivita) As Boolean Implements Core.IFlusso.Controlla
        Message(String.Format("Procedura di controllo per l'attività {0} del flusso SDO avviata", attivita.Codice), DisplayMessageSeverity.Info)
        Message(String.Format("Trovati {0} files associati alla attività {1}", attivita.Files.Count, attivita.Codice), DisplayMessageSeverity.Info)
        If (DecomprimiFile(attivita)) Then
            If (InserisciFile(attivita)) Then
                Importa()
                AccodaRicevuta("sp_accoda_ricevuta")
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

    Private Function EsportaGrouper() As Boolean
        Dim result As Boolean = True

        Try
            Dim builder As New StringBuilder()
            builder.AppendFormat("{0}..T_Dimesso_per_grouper out  {1}", Controllo.DBConfig.Nome, System.IO.Path.Combine(StarterConfig.ResocontoPath, "per_grouper.txt"))
            builder.AppendFormat(" -f {0}", System.IO.Path.Combine(StarterConfig.FormatiPath, "t_dimesso_x_grp.fmt"))
            builder.AppendFormat(" -S {0}", Controllo.DBConfig.Server)
            builder.AppendFormat(" -U {0}", Controllo.DBConfig.Utente)
            builder.AppendFormat(" -P {0}", Controllo.DBConfig.Password)

            Dim proc As New Process()
            proc.StartInfo.FileName = "bcp"
            proc.StartInfo.Arguments = builder.ToString()
            proc.Start()
            proc.WaitForExit()
            proc.Close()
        Catch ex As Exception
            result = False
        End Try

        Return result

    End Function

    Private Function ImportaGrouper() As Boolean
        Dim result As Boolean = True

        Try
            Dim builder As New StringBuilder()
            builder.AppendFormat("{0}..T_Dimesso_per_grouper out  {1}", Controllo.DBConfig.Nome, System.IO.Path.Combine(StarterConfig.ResocontoPath, "per_grouper.txt"))
            builder.AppendFormat(" -f {0}", System.IO.Path.Combine(StarterConfig.FormatiPath, "t_dimesso_da_grp.fmt"))
            builder.AppendFormat(" -S {0}", Controllo.DBConfig.Server)
            builder.AppendFormat(" -U {0}", Controllo.DBConfig.Utente)
            builder.AppendFormat(" -P {0}", Controllo.DBConfig.Password)

            Dim proc As New Process()
            proc.StartInfo.FileName = "bcp"
            proc.StartInfo.Arguments = builder.ToString()
            proc.Start()
            proc.WaitForExit()
            proc.Close()
        Catch ex As Exception
            result = False
        End Try

        Return result
    End Function

    Private Function RunGrouper() As Boolean
        Dim result As Boolean = True

        ' TODO: necessario per ambiente di test
        Return True

        Try
            Dim builder As New StringBuilder()
            builder.AppendFormat(" -i {0}", System.IO.Path.Combine(StarterConfig.ResocontoPath, "per_grouper.txt"))
            builder.AppendFormat(" -it {0}", System.IO.Path.Combine(StarterConfig.FormatiPath, "quick15in_new.dic"))
            builder.AppendFormat(" -u {0}", System.IO.Path.Combine(StarterConfig.ResocontoPath, "da_grouper.txt"))
            builder.AppendFormat(" -ut {0}", System.IO.Path.Combine(StarterConfig.FormatiPath, "quick15out_new.dic"))
            builder.Append(" -w ")
            builder.Append(" -g 01240")
            builder.Append(" -cv 240")

            Dim proc As New Process()
            proc.StartInfo.FileName = "C:\Program Files\3M Health Information Systems\3M Core Grouping Software\3MCGS.exe" 'TODO Mettere nel config
            'proc.StartInfo.Arguments = "-i C:\TEMP\Per_grouper.txt -it C:\Inetpub\wwwroot\arsflussi\dati\Formati\quick15in_new.dic -u C:\TEMP\da_grouper.txt -ut C:\Inetpub\wwwroot\arsflussi\dati\Formati\quick15out_new.dic -w -g 01240 -cv 240"
            proc.StartInfo.Arguments = builder.ToString()
            proc.Start()
            proc.WaitForExit()
            proc.Close()
        Catch ex As Exception
            result = False
        End Try

    End Function

    Private Function Importa() As Boolean
        Dim status As Boolean = True
        Try
            'Lancio la stored-procedure del controllo integrità
            If (_flussoRepo.ControlloIntegrita()) Then
                If (_flussoRepo.ControlloProcedura()) Then
                    If (_flussoRepo.CreaDimesso()) Then
                        If (_flussoRepo.ControlloFormale()) Then
                            If (_flussoRepo.PreparaGrouper()) Then
                                If (EsportaGrouper()) Then
                                    If (RunGrouper()) Then
                                        If (ImportaGrouper()) Then
                                            If (_flussoRepo.ValorizzazioneBDR()) Then
                                                If (_flussoRepo.ControlliFormaliPostValidazione()) Then
                                                    Return True
                                                Else
                                                    'ERRORE NEI CONTROLLI FORMALI POSTA VALIDAZIONE
                                                    AccodaNote("ERRORE NEI CONTROLLI FORMALI POSTA VALIDAZIONE") 'TODO
                                                End If
                                            Else
                                                'ERRORE NELLA VALORIZZAZIONE DEL BDR
                                                AccodaNote("ERRORE NELLA VALORIZZAZIONE DEL BDR") 'TODO
                                            End If
                                        Else
                                            'ERRORE NELL'IMPORTAZIONE DEL GROUPER
                                            AccodaNote("ERRORE NELL'IMPORTAZIONE DEL GROUPER") 'TODO
                                        End If
                                    Else
                                        'ERRORE NELL'ESECUAZIONE DEL GROUPER
                                        AccodaNote("ERRORE NELL'ESECUAZIONE DEL GROUPER") 'TODO
                                    End If
                                Else
                                    'ERRORE NELLA ESPORTAZIONE DEL GROUPER
                                    AccodaNote("ERRORE NELLA ESPORTAZIONE DEL GROUPER") 'TODO
                                End If
                            Else
                                'ERRORE NELLA PREPARAZIONE DEL GROUPER
                                AccodaNote("ERRORE NELLA PREPARAZIONE DEL GROUPER") 'TODO
                            End If
                        Else
                            'ERRORE NELLA CREAZIONE DEI CONTROLLI FORMALI
                            AccodaNote("ERRORE NELLA CREAZIONE DEI CONTROLLI FORMALI") 'TODO
                        End If
                    Else
                        ''ERRORE NELLA CREAZIONE T-DIMESSO
                        AccodaNote("ERRORE NELLA CREAZIONE T-DIMESSO") 'TODO
                    End If
                Else
                    ''ERRORE NEL CONTROLLO DELLA PROCEDURA
                    AccodaNote("ERRORE NEL CONTROLLO DELLA PROCEDURA") 'TODO
                End If
            Else
                ''ERRORE NEL CONTROLLO DI INTEGRITA'
                AccodaNote("ERRORE NEL CONTROLLO DI INTEGRITA'") 'TODO
            End If

        Catch ex As Exception

        End Try

        Return False
    End Function

    Public Function Accoda(ByVal attivita As Attivita) As Boolean
        Dim result As Boolean = True
        Dim progressivoTrasmissione As Integer = attivita.Files.FirstOrDefault().ProgressivoTrasmissione
        If (progressivoTrasmissione > 1) Then
            Dim op = Repository.Accoda(progressivoTrasmissione, attivita.Periodo.ID)
            result = op.Success
        End If

        Return result
    End Function

#End Region

End Class
