Imports ARS.GAF.Core
Imports System.Text

Imports System.IO

' E' la classe che implementa i metodi comune a tutti i flussi
Public Class BaseFlusso

    Public Event DisplayInnerMessage(ByVal message As DisplayMessageArgs)

    Public _fileXSD1 As String
    Public _fileXSD2 As String
    Public _controllo As Controllo
    Public _starterConfig As StarterConfig

    Private _repository As BaseFlussoRepository

    Public Sub SetRepository(ByVal flussoRepository As BaseFlussoRepository)
        _repository = flussoRepository
    End Sub

    Public Sub SetFileXSD1(ByVal fileXsd1 As String)
        _fileXSD1 = fileXsd1
    End Sub

    Public Sub SetFileXSD2(ByVal fileXsd2 As String)
        _fileXSD2 = FileXSD2
    End Sub


    Public Sub SetControllo(ByVal controllo As Controllo)
        _controllo = controllo
    End Sub

    Public Sub SetStarterConfig(ByVal config As StarterConfig)
        _starterConfig = config
    End Sub

#Region "Private Properties"

    Public ReadOnly Property ReportPath() As String
        Get
            Return "Reports\RErrori.rpt"
        End Get
    End Property

    Public ReadOnly Property ReportPathRicevuta() As String
        Get
            Return "Reports\Ricevuta.rpt"
        End Get
    End Property

    Public ReadOnly Property Repository() As BaseFlussoRepository
        Get
            If (_repository Is Nothing) Then
                _repository = New BaseFlussoRepository(_controllo.DBConfig, _starterConfig)
            End If
            Return _repository
        End Get
    End Property

#End Region


    Public Sub Message(ByVal message As String, ByVal severity As DisplayMessageSeverity)

        Dim display As New DisplayMessageArgs
        display.Message = message
        display.Severity = severity
        RaiseEvent DisplayInnerMessage(display)

        If (severity = DisplayMessageSeverity.Errore) Then
            'AccodaNote(message)
        End If


    End Sub

#Region "Private methods"

    Public Function DecomprimiFile(ByVal Attivita As Attivita) As Boolean
        For Each File As File In Attivita.Files
            If (File.ProgressivoCompressione > 1) Then
                Message(String.Format("Il file {0}\{1}\{2} risulta compresso. Decompressione in corso ...", Attivita.Referente.Percorso, Attivita.Flusso.ID, Zip.GetSavedName(File)), DisplayMessageSeverity.Info)
                Dim op = Zip.DecomprimiFile(_starterConfig.SevenZipDllPath, File, Attivita.Referente, Attivita.Flusso.ID, _controllo.DriveFile)
                If (op.Success) Then
                    Message(op.Message, DisplayMessageSeverity.Info)
                Else
                    Message(op.Message, DisplayMessageSeverity.Errore)
                    Return False
                End If
            Else
                File.NomeFile = String.Format(Attivita.Referente.Percorso & "\" & Attivita.Flusso.ID & "\" & Zip.GetSavedName(File))
            End If
        Next
        Return True
    End Function

    Public Function InserisciFile(ByVal Attivita As Attivita) As Boolean

        For Each file As ARS.GAF.Core.File In Attivita.Files
            Message(String.Format("Inserimento del file {0} in corso ...", file.NomeFile), DisplayMessageSeverity.Info)
            Try
                Select Case _controllo.Tipo
                    Case TipoControllo.SQL
                        Message(String.Format("Controllo di tipo SQL per il file {0} in corso ...", file.NomeFile), DisplayMessageSeverity.Info)
                        Message(String.Format("Inserimento del file {0} all'interno del database in corso ...", file.NomeFile), DisplayMessageSeverity.Info)
                        Dim op As OperationResult = Repository.InserisciRecord(file)
                        If (op.Success) Then
                            Message(op.Message, DisplayMessageSeverity.Info)
                        Else
                            Message(op.Message, DisplayMessageSeverity.Errore)
                            Return False
                        End If
                    Case TipoControllo.XML
                        Dim currentSchema = String.Empty
                        If (file.TracciatoFile.EndsWith(_fileXSD1)) Then
                            currentSchema = System.IO.Path.Combine(_starterConfig.XsdFolderPath, _fileXSD1)
                        Else
                            currentSchema = System.IO.Path.Combine(_starterConfig.XsdFolderPath, _fileXSD2)
                        End If
                        Message(String.Format("Controllo di tipo XML per il file {0} in corso ...", file.NomeFile), DisplayMessageSeverity.Info)
                        Message(String.Format("Validazione del file {0} con lo schema {1} in corso ...", file.NomeFile, file.TracciatoFile), DisplayMessageSeverity.Info)
                        If (Xml.Validate(System.IO.Path.Combine(_starterConfig.FtpFolderPath, file.FileSalvato), file.Namespace, currentSchema)) Then
                            Message(String.Format("File {0} valido! Inserimento del contenuto nel database in corso ...", file.NomeFile), DisplayMessageSeverity.Info)
                            file.Valido = "SI"
                            Dim op = Repository.InserisciXML(file)
                            If (op.Success) Then
                                Message(op.Message, DisplayMessageSeverity.Info)
                            Else
                                Message(op.Message, DisplayMessageSeverity.Errore)
                            End If
                        Else
                            file.Valido = "NO"
                            Message(String.Format("File non valido!", file.NomeFile), DisplayMessageSeverity.Errore)
                            'Return False
                        End If
                    Case Else
                End Select
            Catch ex As Exception
                'mailer.SendMail("Errore nella procedura di inserimento record", "La funzione di inserimento ha generato il seguente errore : " & ex.Message, "federico.paoloni@e-lios.eu; andrea.caputo@e-lios.eu")
                'mailer.SendMail("Errore nella procedura di inserimento record", Controllo.EmailTemplate & "<br>" & "La funzione di inserimento ha generato il seguente errore: " & ex.Message, "andrea.caputo@e-lios.eu"
                Return False
            End Try
        Next
        Return True
    End Function

    Public Overridable Function Importa(ByVal attivita As Attivita) As Boolean
        Message("Esecuzione dei controlli regionali/ministeriali in corso....", DisplayMessageSeverity.Info)
        Dim op As OperationResult = Repository.Importa(attivita, _controllo)
        If (op.Success) Then
            Message(op.Message, DisplayMessageSeverity.Info)
        Else
            Message(op.Message, DisplayMessageSeverity.Errore)
        End If
        Return op.Success
    End Function

    Public Function Accoda(ByVal attivita As Attivita) As Boolean
        Message("Accodamento dei dati all'interno del database in corso ...", DisplayMessageSeverity.Info)
        Dim result As Boolean = True
        Dim progressivoTrasmissione As Integer = attivita.Files.FirstOrDefault().ProgressivoTrasmissione
        If (progressivoTrasmissione > 1) Then
            Dim op = Repository.Accoda(progressivoTrasmissione, attivita.Periodo.ID)
            result = op.Success
            If (op.Success) Then
                Message(op.Message, DisplayMessageSeverity.Info)
            Else
                Message(op.Message, DisplayMessageSeverity.Errore)
            End If
        End If

        Return result
    End Function

    Public Function AccodaRicevuta(ByVal attivita As Attivita) As Boolean
        Message("Accodamento dei data della ricevuta in corso...", DisplayMessageSeverity.Info)
        Dim result As Boolean = True
        Dim op = Repository.AccodaRicevuta()
        result = op.Success

        Return result
    End Function

    Public Function InviaResoconto(ByVal attivita As Attivita) As Boolean
        Message("Normalizzazione degli errori in corso ....", DisplayMessageSeverity.Info)
        Dim op = Repository.NormalizzaErrori()
        If (op.Success) Then
            Message(op.Message, DisplayMessageSeverity.Info)
        Else
            Message(op.Message, DisplayMessageSeverity.Errore)
            Return False
        End If

        Dim detailsFileFullPath = System.IO.Path.Combine(_starterConfig.ResocontoPath, attivita.Codice & "_derr.txt")

        Message(String.Format("Esportazione degli errori sul file {0} in corso ....", detailsFileFullPath), DisplayMessageSeverity.Info)
        op = EsportaDettaglio(attivita)
        If (op.Success) Then
            Message(op.Message, DisplayMessageSeverity.Info)
        Else
            Message(op.Message, DisplayMessageSeverity.Errore)
            Return False
        End If

        Message(String.Format("Compressione del file {0} in corso ....", detailsFileFullPath), DisplayMessageSeverity.Info)

        op = Zip.ComprimiFile(_starterConfig.SevenZipDllPath, attivita.Codice & "_derr", detailsFileFullPath, _starterConfig.ResocontoPath)
        If (op.Success) Then
            Message(op.Message, DisplayMessageSeverity.Info)
        Else
            Message(op.Message, DisplayMessageSeverity.Errore)
            Return False
        End If

        Dim reportFullPath = System.IO.Path.Combine(_starterConfig.ResocontoPath, attivita.Codice & "_rerr.pdf")

        Message(String.Format("Generazione del report degli errori nel file {0} in corso ...", reportFullPath), DisplayMessageSeverity.Info)
        op = CreaReportErrori(attivita, reportFullPath)
        If (op.Success) Then
            Message(op.Message, DisplayMessageSeverity.Info)
        Else
            Message(op.Message, DisplayMessageSeverity.Errore)
            Return False
        End If

        Message(String.Format("Compressione del file {0} in corso ....", reportFullPath), DisplayMessageSeverity.Info)

        op = Zip.ComprimiFile(_starterConfig.SevenZipDllPath, attivita.Codice & "_rerr", reportFullPath, _starterConfig.ResocontoPath)
        If (op.Success) Then
            Message(op.Message, DisplayMessageSeverity.Info)
        Else
            Message(op.Message, DisplayMessageSeverity.Errore)
            Return False
        End If

        Dim ricevutaFullPath = System.IO.Path.Combine(_starterConfig.ResocontoPath, attivita.Codice & "_ric.pdf")

        Message(String.Format("Generazione della ricevuta nel file {0} in corso ...", ricevutaFullPath), DisplayMessageSeverity.Info)

        op = CreaReportRicevuta(attivita, ricevutaFullPath)
        If (op.Success) Then
            Message(op.Message, DisplayMessageSeverity.Info)
        Else
            Message(op.Message, DisplayMessageSeverity.Errore)
            Return False
        End If

        op = Zip.ComprimiFile(_starterConfig.SevenZipDllPath, attivita.Codice & "_ric", ricevutaFullPath, _starterConfig.ResocontoPath)
        If (op.Success) Then
            Message(op.Message, DisplayMessageSeverity.Info)
        Else
            Message(op.Message, DisplayMessageSeverity.Errore)
            Return False
        End If

        Return True
    End Function

    Public Function EsportaDettaglio(ByVal attivita As Attivita) As OperationResult
        Dim op As New OperationResult
        Try
            ' Esportazione tramite BCP del file del dettaglio degli errori
            Dim proc As New Process()
            proc.StartInfo.FileName = "bcp"

            Dim builder As New StringBuilder()
            builder.AppendFormat("{0}..Q_Errori_Dettaglio out  {1}", _controllo.DBConfig.Nome, Path.Combine(_starterConfig.ResocontoPath, attivita.Codice & "_derr.txt"))
            builder.AppendFormat(" -f {0}", _controllo.Tracciato.DErrori)
            builder.AppendFormat(" -S {0}", _controllo.DBConfig.Server)
            builder.AppendFormat(" -U {0}", _controllo.DBConfig.Utente)
            builder.AppendFormat(" -P {0}", _controllo.DBConfig.Password)

            proc.StartInfo.Arguments = builder.ToString()
            proc.Start()
            proc.WaitForExit()
            proc.Close()

            op.Success = True
            op.Message = String.Format("Creazione del file {0} di dettaglio degli errori avvenuta con successo!", Path.Combine(_starterConfig.ResocontoPath, attivita.Codice & "_derr.txt"))

        Catch ex As Exception
            op.Success = False
            op.Message = ex.Message
        End Try
        Return op
    End Function

    Public Function CreaReportErrori(ByVal attivita As Attivita, ByVal file As String) As OperationResult
        Dim op = New OperationResult
        op.Success = True
        op.Message = String.Format("Report non necessario per la tipologia di controllo {0}", _controllo.Tipo)
        If (_controllo.Tipo = TipoControllo.SQL Or _controllo.Tipo = TipoControllo.XML) Then
            Dim dt As DataTable = Repository.GetRiepilogoErrori()
            op = EsportaReport(dt, attivita, file)
        End If

        Return op
    End Function

    Public Function EsportaReport(ByVal dt As DataTable, ByVal attivita As Attivita, ByVal file As String) As OperationResult
        Dim op = New OperationResult
        Try
            Dim report As New RErrori
            report.Load(ReportPath)
            report.SetDataSource(dt)

            report.SetParameterValue("attivit", "Report di feedback per l'attività n. " & attivita.Codice)
            report.SetParameterValue("flusso", "Flusso: " & Trim(_controllo.Flusso.Nome))
            report.SetParameterValue("periodo", "Periodo: " & Trim(_controllo.Periodo.Nome))

            report.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.PortableDocFormat, file)
            report.Close()

            op.Success = True
            op.Message = String.Format("Report {0} generato con successo!", file)

        Catch ex As Exception
            op.Success = False
            op.Message = ex.Message
        End Try
        Return op
    End Function

    Public Function CreaReportRicevuta(ByVal attivita As Attivita, ByVal file As String) As OperationResult

        Dim op As New OperationResult
        op.Success = True
        op.Message = String.Format("Ricevuta non necessaria per il tipo di controllo {0}", _controllo.Tipo)

        If (_controllo.Tipo = TipoControllo.SQL Or _controllo.Tipo = TipoControllo.XML) Then
            Dim dt As DataTable = Repository.GetRiepilogoRicevuta()
            op = EsportaReportRicevuta(dt, attivita, file)
        End If

        Return op

    End Function

    Public Overridable Function EsportaReportRicevuta(ByVal dt As DataTable, ByVal attivita As Attivita, ByVal file As String) As OperationResult
        Dim op = New OperationResult
        Try
            Dim report As New Ricevuta
            report.Load(ReportPathRicevuta)
            report.SetDataSource(dt)

            report.SetParameterValue("attivit", "Report di feedback per l'attività n. " & attivita.Codice)
            report.SetParameterValue("flusso", "Flusso: " & Trim(_controllo.Flusso.Nome))
            report.SetParameterValue("periodo", "Periodo: " & Trim(_controllo.Periodo.Nome))

            Dim fileNome As String = String.Empty
            For Each currFile As ARS.GAF.Core.File In attivita.Files
                fileNome += System.IO.Path.GetFileName(currFile.NomeFile) & " "
            Next


            Dim esitoValidazione As String = String.Empty
            'For Each currFile As ARS.GAF.Core.File In attivita.Files
            '    If (Not String.IsNullOrEmpty(currFile.Valido)) Then
            '        esitoValidazione += System.IO.Path.GetFileName(currFile.NomeFile) & " : " & currFile.Valido & " "
            '    End If
            'Next

            report.SetParameterValue("filecar", "File caricati: " & fileNome)
            report.SetParameterValue("inviatoda", "Inviato da: " & attivita.Referente.Nome)
            report.SetParameterValue("validatoil", "Data validazione: " & DateTime.Now.ToString())
            report.SetParameterValue("caricatoil", "Data caricamento: " & attivita.DataInserimento.ToString())
            If (String.IsNullOrEmpty(esitoValidazione)) Then
                report.SetParameterValue("esitoValidazione", "")
            Else
                report.SetParameterValue("esitoValidazione", "Esito validazione: " & esitoValidazione)
            End If


            report.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.PortableDocFormat, file)
            report.Close()

            op.Success = True
            op.Message = String.Format("Ricevuta generata correttamente nel file {0}", file)

        Catch ex As Exception
            op.Success = False
            op.Message = ex.Message
        End Try
        Return op
    End Function

#End Region

End Class