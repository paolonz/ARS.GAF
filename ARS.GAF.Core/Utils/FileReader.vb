Public Class FileReader

    Public Shared Function ReadFile(ByVal fileName As String) As List(Of String)

        Dim result As List(Of String)

        Try
            result = New List(Of String)
            Dim reader As New System.IO.StreamReader(fileName)

            Do While Not reader.EndOfStream

                result.Add(reader.ReadLine())

            Loop
        Catch ex As Exception

            Console.WriteLine(ex.Message)

            result = Nothing
        End Try

        Return result
    End Function

    Public Shared Function ParseC1(ByVal fileName As String, ByVal codiceFiscaleReferente As String, ByVal data As DateTime, ByVal dataTableC2 As DataTable) As DataTable
        Dim table As DataTable = InitC1DataTable()

        Try
            Dim reader As New System.IO.StreamReader(fileName)

            Do While Not reader.EndOfStream

                Dim record As String = reader.ReadLine()
                Dim row As DataRow = table.NewRow()

                row("Utente") = codiceFiscaleReferente
                row("RegAdd") = record.Substring(0, 3)
                row("AslInviante") = record.Substring(3, 3)
                row("CodStruttura_AccRic") = record.Substring(6, 6)
                row("CodStruttura_Ero") = record.Substring(12, 6)
                row("TipoMedico") = record.Substring(18, 1)
                row("CFMedico") = record.Substring(19, 16)
                row("CFMedEro") = record.Substring(35, 16)
                row("CognomeUtente") = record.Substring(51, 30)
                row("NomeUtente") = record.Substring(81, 20)
                row("SessoUtente") = record.Substring(101, 1)
                row("DataNasUtente") = record.Substring(102, 8)
                row("CFUtente") = record.Substring(110, 16)
                row("ComResUtente") = record.Substring(126, 6)
                row("RegResUtente") = record.Substring(132, 3)
                row("AslResUtente") = record.Substring(135, 3)
                row("StatoEst") = record.Substring(138, 2)
                row("IstituzComp") = record.Substring(140, 28)
                row("NumIdentPers") = record.Substring(168, 20)
                row("NumIdentTess") = record.Substring(188, 20)
                row("ScadTS") = record.Substring(208, 8)
                row("NumRicetta") = record.Substring(216, 16)
                row("ProgRigaRicetta") = record.Substring(232, 2)
                row("PosContabile") = record.Substring(234, 1)
                row("ModComp") = record.Substring(235, 1)
                row("ModRilCF") = record.Substring(236, 1)
                row("OnerePrest") = record.Substring(237, 1)
                row("ID") = record.Substring(238, 20)

                Dim rowC2 As DataRow = dataTableC2.Select(String.Format("ID = '{0}' and CodStruttura_AccRic='{1}' and ProgRigaRicetta='{2}'", row("ID"), row("CodStruttura_AccRic"), row("ProgRigaRicetta"))).FirstOrDefault()

                If (Not rowC2 Is Nothing) Then
                    ' Aggiunto perchè fa parte della chiave primaria ma non è parte del tracciato record
                    row("TRASMREGIONE") = rowC2("TRASMREGIONE")
                Else
                    Throw New Exception("Errore")
                End If
                
                ' Campi riempiti che non fanno parte del tracciato
                row("FLAG_ERRORE") = "1"
                row("DataAcquisizione") = data

                table.Rows.Add(row)

                If (table.Rows.Count = 5) Then
                    Exit Do
                End If

            Loop
        Catch ex As Exception
            Throw ex
        End Try

        Return table
    End Function

    Public Shared Function ParseC2(ByVal fileName As String, ByVal codiceFiscaleReferente As String, ByVal data As DateTime) As DataTable
        Dim table As DataTable = InitC2DataTable()

        Try

            Dim reader As New System.IO.StreamReader(fileName)

            Do While Not reader.EndOfStream

                Dim record As String = reader.ReadLine()
                Dim row As DataRow = table.NewRow()

                row("Utente") = codiceFiscaleReferente
                row("RegAdd") = record.Substring(0, 3)
                row("AslInviante") = record.Substring(3, 3)
                row("CodStruttura_AccRic") = record.Substring(6, 6)
                row("CodStruttura_Ero") = record.Substring(12, 6)
                row("CodCentroCosto") = record.Substring(18, 10)
                row("NumRicetta") = record.Substring(28, 16)
                row("Priorita_Acc") = record.Substring(44, 1)
                row("Priorita_Eff") = record.Substring(45, 1)
                row("TipoPrescr") = record.Substring(46, 1)
                row("TipoRicetta") = record.Substring(47, 2)
                row("ProntoSoccorso") = record.Substring(49, 1)
                row("PAC") = record.Substring(50, 1)
                row("CicloPrestazioni") = record.Substring(51, 1)
                row("ProgRigaRicetta") = record.Substring(52, 2)
                row("DataRicetta") = record.Substring(54, 8)
                row("DataDispEro") = record.Substring(62, 8)
                row("DataPrenotazione") = record.Substring(70, 8)
                row("DataEroInizio") = record.Substring(78, 8)
                row("DataEroFine") = record.Substring(86, 8)
                row("DataReferto") = record.Substring(94, 8)
                row("ModoAccesso") = record.Substring(102, 2)
                row("TipoAccesso") = record.Substring(104, 1)
                row("CodDiagnosi") = record.Substring(105, 7)
                row("VerificaDiagnosi") = record.Substring(112, 1)
                row("CodNomenclatore") = record.Substring(113, 1)
                row("CodBrancaPrest") = record.Substring(114, 3)
                row("CodSpecPrest") = record.Substring(117, 5)
                row("CodPrestazione") = record.Substring(122, 8)
                row("NumPrestazioniTot") = record.Substring(130, 3)
                row("TariffaPrest") = record.Substring(133, 8)
                row("PercScoApp") = record.Substring(141, 2)
                row("ImpSconto") = record.Substring(143, 8)
                row("TipoEsenzione") = record.Substring(151, 1)
                row("CodEsenzione") = record.Substring(152, 6)
                row("QuotaFissaRic") = record.Substring(158, 1)
                row("QuotaCaricoAss") = record.Substring(159, 8)
                row("QuotaFissaAss") = record.Substring(167, 8)
                row("ImpTotale") = record.Substring(175, 8)
                row("PosContabile") = record.Substring(183, 1)
                row("TrasmRegione") = record.Substring(184, 1)
                row("ERR01") = record.Substring(185, 1)
                row("ERR02") = record.Substring(186, 1)
                row("ERR03") = record.Substring(187, 1)
                row("ERR04") = record.Substring(188, 1)
                row("ERR05") = record.Substring(189, 1)
                row("ERR06") = record.Substring(190, 1)
                row("ERR07") = record.Substring(191, 1)
                row("ERR08") = record.Substring(192, 1)
                row("ERR09") = record.Substring(193, 1)
                row("ERR10") = record.Substring(194, 1)
                row("PrestRicovero") = record.Substring(195, 22)
                row("ID") = record.Substring(217, 20)
                row("RegioneAddebito") = record.Substring(237, 3)
                row("FLAG_ERRORE") = ""
                row("DataAcquisizione") = data
                row("MeseRif") = record.Substring(88, 2)
                row("AnnoRif") = record.Substring(90, 4)

                table.Rows.Add(row)

                If (table.Rows.Count = 5) Then
                    Exit Do
                End If
            Loop

        Catch ex As Exception
        End Try

        Return table
    End Function

    Private Shared Function InitC1DataTable() As DataTable

        Dim table As New DataTable("c1")
        table.Columns.Add("Utente")
        table.Columns.Add("RegAdd")
        table.Columns.Add("AslInviante")
        table.Columns.Add("CodStruttura_AccRic")
        table.Columns.Add("CodStruttura_Ero")
        table.Columns.Add("TipoMedico")
        table.Columns.Add("CFMedico")
        table.Columns.Add("CFMedEro")
        table.Columns.Add("CognomeUtente")
        table.Columns.Add("NomeUtente")
        table.Columns.Add("SessoUtente")
        table.Columns.Add("DataNasUtente")
        table.Columns.Add("CFUtente")
        table.Columns.Add("ComResUtente")
        table.Columns.Add("RegResUtente")
        table.Columns.Add("AslResUtente")
        table.Columns.Add("StatoEst")
        table.Columns.Add("IstituzComp")
        table.Columns.Add("NumIdentPers")
        table.Columns.Add("NumIdentTess")
        table.Columns.Add("ScadTS")
        table.Columns.Add("NumRicetta")
        table.Columns.Add("ProgRigaRicetta")
        table.Columns.Add("PosContabile")
        table.Columns.Add("ModComp")
        table.Columns.Add("ModRilCF")
        table.Columns.Add("OnerePrest")
        table.Columns.Add("ID")
        table.Columns.Add("TRASMREGIONE")
        table.Columns.Add("FLAG_ERRORE")
        table.Columns.Add("DataAcquisizione")

        Return table

    End Function

    Private Shared Function InitC2DataTable() As DataTable
        Dim table As New DataTable("c2")

        table.Columns.Add("Utente")
        table.Columns.Add("RegAdd")
        table.Columns.Add("AslInviante")
        table.Columns.Add("CodStruttura_AccRic")
        table.Columns.Add("CodStruttura_Ero")
        table.Columns.Add("CodCentroCosto")
        table.Columns.Add("NumRicetta")
        table.Columns.Add("Priorita_Acc")
        table.Columns.Add("Priorita_Eff")
        table.Columns.Add("TipoPrescr")
        table.Columns.Add("TipoRicetta")
        table.Columns.Add("ProntoSoccorso")
        table.Columns.Add("PAC")
        table.Columns.Add("CicloPrestazioni")
        table.Columns.Add("ProgRigaRicetta")
        table.Columns.Add("DataRicetta")
        table.Columns.Add("DataDispEro")
        table.Columns.Add("DataPrenotazione")
        table.Columns.Add("DataEroInizio")
        table.Columns.Add("DataEroFine")
        table.Columns.Add("DataReferto")
        table.Columns.Add("ModoAccesso")
        table.Columns.Add("TipoAccesso")
        table.Columns.Add("CodDiagnosi")
        table.Columns.Add("VerificaDiagnosi")
        table.Columns.Add("CodNomenclatore")
        table.Columns.Add("CodBrancaPrest")
        table.Columns.Add("CodSpecPrest")
        table.Columns.Add("CodPrestazione")
        table.Columns.Add("NumPrestazioniTot")
        table.Columns.Add("TariffaPrest")
        table.Columns.Add("PercScoApp")
        table.Columns.Add("ImpSconto")
        table.Columns.Add("TipoEsenzione")
        table.Columns.Add("CodEsenzione")
        table.Columns.Add("QuotaFissaRic")
        table.Columns.Add("QuotaCaricoAss")
        table.Columns.Add("QuotaFissaAss")
        table.Columns.Add("ImpTotale")
        table.Columns.Add("PosContabile")
        table.Columns.Add("TrasmRegione")
        table.Columns.Add("ERR01")
        table.Columns.Add("ERR02")
        table.Columns.Add("ERR03")
        table.Columns.Add("ERR04")
        table.Columns.Add("ERR05")
        table.Columns.Add("ERR06")
        table.Columns.Add("ERR07")
        table.Columns.Add("ERR08")
        table.Columns.Add("ERR09")
        table.Columns.Add("ERR10")
        table.Columns.Add("PrestRicovero")
        table.Columns.Add("ID")
        table.Columns.Add("RegioneAddebito")
        table.Columns.Add("FLAG_ERRORE")
        table.Columns.Add("DataAcquisizione")
        table.Columns.Add("MeseRif")
        table.Columns.Add("AnnoRif")

        Return table

    End Function

    Public Shared Function ParseDistinte(ByVal fileName As String) As DataTable

        Dim table As DataTable = InitDistinteDataTable()

        Try
            Dim reader As New System.IO.StreamReader(fileName)

            Do While Not reader.EndOfStream

                Dim record As String = reader.ReadLine()
                Dim row As DataRow = table.NewRow()

                row("Reg") = record.Substring(0, 3)
                row("Zona") = record.Substring(3, 3)
                ' Dal nome del file estrarre il Codice della farmacia o Centro Servizi
                row("CodFarma") = record.Substring(6, 5)
                ' Dal nome del file estrarre il mese di riferimento
                row("Mese") = record.Substring(11, 2)
                ' Dal nome del file estrarre l'anno di riferimento
                row("Anno") = record.Substring(13, 2)
                row("RicConv") = record.Substring(15, 5)
                row("ImportoLordo") = record.Substring(20, 10)
                row("RettificheLordo") = record.Substring(30, 10)
                row("ScontoSSN") = record.Substring(40, 10)
                row("ScontoAifa") = record.Substring(50, 10)
                row("ScontoAifa2") = record.Substring(60, 10)
                row("ScontoSSN2") = record.Substring(70, 10)
                row("ImportoTicket") = record.Substring(80, 10)
                row("ImportoFisse") = record.Substring(90, 10)
                row("ImportoVariabili") = record.Substring(100, 10)
                row("ImportoNetto") = record.Substring(110, 10)
                row("ImportoTrattenute") = record.Substring(120, 10)
                row("Enpaf") = record.Substring(130, 10)
                row("Convenzionali") = record.Substring(140, 10)
                row("FederFarma") = record.Substring(150, 10)
                row("ATF") = record.Substring(160, 10)
                row("ASSOFARM") = record.Substring(170, 10)
                row("ImpNettoTrat") = record.Substring(180, 10)
                row("ImpoAIR") = record.Substring(190, 10)
                row("RicetteDietetici") = record.Substring(200, 5)
                row("ImpDietetici") = record.Substring(205, 10)
                row("ImpRettDietetici") = record.Substring(215, 10)
                row("RicetteStomizzati") = record.Substring(225, 5)
                row("ImpStomizzati") = record.Substring(230, 10)
                row("ImpRettStomizzati") = record.Substring(240, 10)
                row("RicettePannoloni") = record.Substring(250, 5)
                row("ImpPannoloni") = record.Substring(255, 10)
                row("ImpRettPannoloni") = record.Substring(265, 10)
                row("RicetteDiabetici") = record.Substring(275, 5)
                row("ImpDiabetici") = record.Substring(280, 10)
                row("ImpRettDiabetici") = record.Substring(290, 10)
                row("ImpLiq") = record.Substring(300, 10)
                row("RicPM") = record.Substring(310, 4)
                row("ImportoPM") = record.Substring(314, 10)
                row("ImpRettPM") = record.Substring(324, 10)
                row("TicketPM") = record.Substring(334, 10)
                row("LordoPM") = record.Substring(344, 10)
                row("RicOss") = record.Substring(354, 4)
                row("ImportoOss") = record.Substring(358, 10)
                row("Acconto") = record.Substring(368, 10)
                row("DataCessazione") = record.Substring(378, 8)
                ' Campo che non fa parte del tracciato
                ' Chiedere cosa farci
                row("ImpRettAIR") = ""

                table.Rows.Add(row)

            Loop

        Catch ex As Exception
            Throw ex
        End Try

        Return table
    End Function

    Private Shared Function InitDistinteDataTable() As DataTable

        Dim table As New DataTable("Distinte")
        table.Columns.Add("Reg")
        table.Columns.Add("Zona")
        table.Columns.Add("CodFarma")
        table.Columns.Add("Mese")
        table.Columns.Add("Anno")
        table.Columns.Add("RicConv")
        table.Columns.Add("ImportoLordo")
        table.Columns.Add("RettificheLordo")
        table.Columns.Add("ScontoSSN")
        table.Columns.Add("ScontoAifa")
        table.Columns.Add("ScontoAifa2")
        table.Columns.Add("ScontoSSN2")
        table.Columns.Add("ImportoTicket")
        table.Columns.Add("ImportoFisse")
        table.Columns.Add("ImportoVariabili")
        table.Columns.Add("ImportoNetto")
        table.Columns.Add("ImportoTrattenute")
        table.Columns.Add("Enpaf")
        table.Columns.Add("Convenzionali")
        table.Columns.Add("FederFarma")
        table.Columns.Add("ATF")
        table.Columns.Add("ASSOFARM")
        table.Columns.Add("ImpNettoTrat")
        table.Columns.Add("ImpoAIR")
        table.Columns.Add("RicetteDietetici")
        table.Columns.Add("ImpDietetici")
        table.Columns.Add("ImpRettDietetici")
        table.Columns.Add("RicetteStomizzati")
        table.Columns.Add("ImpStomizzati")
        table.Columns.Add("ImpRettStomizzati")
        table.Columns.Add("RicettePannoloni")
        table.Columns.Add("ImpPannoloni")
        table.Columns.Add("ImpRettPannoloni")
        table.Columns.Add("RicetteDiabetici")
        table.Columns.Add("ImpDiabetici")
        table.Columns.Add("ImpRettDiabetici")
        table.Columns.Add("ImpRettAIR")
        table.Columns.Add("ImpLiq")
        table.Columns.Add("RicPM")
        table.Columns.Add("ImportoPM")
        table.Columns.Add("ImpRettPM")
        table.Columns.Add("TicketPM")
        table.Columns.Add("LordoPM")
        table.Columns.Add("RicOss")
        table.Columns.Add("ImportoOss")
        table.Columns.Add("Acconto")
        table.Columns.Add("DataCessazione")

        Return table

    End Function

End Class
