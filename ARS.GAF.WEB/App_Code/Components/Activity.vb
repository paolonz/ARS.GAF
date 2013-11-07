Namespace arsflussi

Public Class Activity
    'La classe Activity individua l'attività e i relativi attributi che il referente vuole
    'o inserire o visualizzare
    Public Function ParamActivity(ByVal customerID As Integer) As DataSet
        'La funzione ParamActivity restituisce un dataset con memorizzati i dati(flusso,
        'files, periodo...)per creare un nuovo oggetto activity
        'Crea un nuovo dataset DSFileFlussi
        Dim ds As New DataSet
        ds.DataSetName = "DSFileFlussi"
        'Connessione al SQL server tramite la stringa definita nel Web Config
        Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Creazione DataAdapter e relativo comando di selezione
        Dim sqlda1 As New SqlClient.SqlDataAdapter
        Dim sqlda2 As New SqlClient.SqlDataAdapter
        Dim sqlda3 As New SqlClient.SqlDataAdapter
            Dim sqlda4 As New SqlClient.SqlDataAdapter
        Dim sqlda5 As New SqlClient.SqlDataAdapter
        Dim sqlda6 As New SqlClient.SqlDataAdapter        
        Dim sqlcomm1 As New SqlClient.SqlCommand
        Dim sqlcomm2 As New SqlClient.SqlCommand
        Dim sqlcomm3 As New SqlClient.SqlCommand
        Dim sqlcomm4 As New SqlClient.SqlCommand
        Dim sqlcomm5 As New SqlClient.SqlCommand
        Dim sqlcomm6 As New SqlClient.SqlCommand

        Try
            'Mappatura(creazione colonne) dei data adapter
            sqlda1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_Flussi", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("progrflusso", "progrflusso"), New System.Data.Common.DataColumnMapping("flusso", "flusso")})})
            sqlda1.SelectCommand = sqlcomm1
            sqlcomm1.CommandText = ParamMappa("Flusso", customerID)
            sqlda2.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_Periodi", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("progrperiodo", "progrperiodo"), New System.Data.Common.DataColumnMapping("periodo", "periodo"), New System.Data.Common.DataColumnMapping("annoperiodo", "annoperiodo"), New System.Data.Common.DataColumnMapping("progrflusso", "progrflusso")})})
            sqlcomm2.CommandText = ParamMappa("Periodo", customerID)
            sqlda2.SelectCommand = sqlcomm2
            sqlda3.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_Trasmissioni", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("progrtras", "progrtras"), New System.Data.Common.DataColumnMapping("trasmissione", "trasmissione")})})
            sqlcomm3.CommandText = ParamMappa("TrasmissioneARS", customerID)
            sqlda3.SelectCommand = sqlcomm3
            sqlda4.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_Compressioni", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("progrcompressione", "progrcompressione"), New System.Data.Common.DataColumnMapping("compressione", "compressione"), New System.Data.Common.DataColumnMapping("estensione", "estensione")})})
            sqlcomm4.CommandText = ParamMappa("Compressione", customerID)
            sqlda4.SelectCommand = sqlcomm4
            sqlda5.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_FileFlussi", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("progrflusso", "progrflusso"), New System.Data.Common.DataColumnMapping("posizione", "posizione"), New System.Data.Common.DataColumnMapping("nomefile", "nomefile"), New System.Data.Common.DataColumnMapping("cartella", "cartella"), New System.Data.Common.DataColumnMapping("percorsouser", "percorsouser"), New System.Data.Common.DataColumnMapping("cartellaftp", "cartellaftp")})})
            sqlcomm5.CommandText = ParamMappa("FileFlussi", customerID)
            sqlda5.SelectCommand = sqlcomm5
            sqlda6.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_Referenti", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("progrfreferente", "progrfreferente"), New System.Data.Common.DataColumnMapping("referente", "referente")})})
            sqlcomm6.CommandText = ParamMappa("Referenti", customerID)
            sqlda6.SelectCommand = sqlcomm6
            sqlcomm1.Connection = myConnection
            sqlcomm2.Connection = myConnection
            sqlcomm3.Connection = myConnection
            sqlcomm4.Connection = myConnection
            sqlcomm5.Connection = myConnection
            sqlcomm6.Connection = myConnection
            'Apertura della connessione ed esecuzione comando
            myConnection.Open()
            'Popolamento del Dataset
            ds.EnforceConstraints = False
            sqlda1.Fill(ds)
            sqlda2.Fill(ds)
            sqlda3.Fill(ds)
            sqlda4.Fill(ds)
            sqlda5.Fill(ds)
            sqlda6.Fill(ds)
            ds.EnforceConstraints = True
            myConnection.Close()
            myConnection = Nothing
            Return ds
        Catch ex As Exception
            'In caso di errore durante la procedura chiude la connessione e 
            'tutti gli oggetti, non viene restituito alcun valore
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            myConnection = Nothing
            sqlda1 = Nothing
            sqlda2 = Nothing
            sqlda3 = Nothing
            sqlda4 = Nothing
            sqlda5 = Nothing
            sqlda6 = Nothing
            sqlcomm1 = Nothing
            sqlcomm2 = Nothing
            sqlcomm3 = Nothing
            sqlcomm4 = Nothing
            sqlcomm5 = Nothing
            sqlcomm6 = Nothing
            Return Nothing
        End Try
    End Function
    Public Function ParamMappa(ByVal nTab As String, ByVal nUtente As Integer) As String
        'La funzione ParamMappa restituisce una stringa corrispondente al tipo di 
        'data adapter da popolare
        Dim sselect As String
        Select Case nTab
            Case Is = "Flusso"
                sselect = "SELECT T_ReferentiFlussi.progrflusso, T_Flussi.flusso FROM " _
                & "T_ReferentiFlussi INNER JOIN T_Flussi " _
                & "ON T_ReferentiFlussi.progrflusso = T_Flussi.progrflusso " _
                & "WHERE (T_ReferentiFlussi.progrreferente = " & nUtente & ")"
            Case Is = "Periodo"
                sselect = "SELECT T_Periodi.progrperiodo, T_Periodi.periodo, " _
                & "T_Periodi.annoperiodo, T_PeriodiFlussi.progrflusso FROM T_Referenti INNER JOIN " _
                & "T_ReferentiFlussi ON T_Referenti.progrreferente " _
                & "= T_ReferentiFlussi.progrreferente INNER JOIN " _
                & "T_PeriodiFlussi INNER JOIN T_Periodi ON " _
                & "T_PeriodiFlussi.progrperiodo = T_Periodi." _
                & "progrperiodo ON T_ReferentiFlussi.progrflusso " _
                & "= T_PeriodiFlussi.progrflusso WHERE (" _
                & "T_PeriodiFlussi.validita = 's') AND " _
                & "(T_Referenti.progrreferente = " & nUtente & ") GROUP " _
                & "BY T_Periodi.progrperiodo, T_Periodi.periodo" _
                & ", T_Periodi.annoperiodo, T_Periodi.meseperiodo, T_PeriodiFlussi.progrflusso " _
                & "ORDER BY T_Periodi.annoperiodo DESC, " _
                & "T_Periodi.meseperiodo DESC"
            Case Is = "TrasmissioneARS"
                sselect = "SELECT progrtras, trasmissione FROM T_TrasmissioneARS"
            Case Is = "Compressione"
                sselect = "SELECT progrcompressione, compressione, estensione " _
                & "FROM T_Compressioni"
            Case Is = "FileFlussi"
                sselect = "SELECT T_FileFlussi.progrflusso, T_FileFlussi.posizione, " _
                & "T_FileFlussi.nomefile, T_Referenti.cartella, T_Referenti.percorsouser," _
                & " T_Referenti.cartellaftp FROM T_Referenti " _
                & "INNER JOIN T_ReferentiFlussi ON T_Referenti.progrreferente = " _
                & "T_ReferentiFlussi.progrreferente INNER JOIN T_FileFlussi ON " _
                & "T_ReferentiFlussi.progrflusso = T_FileFlussi.progrflusso " _
                & "WHERE(T_Referenti.progrreferente = " & nUtente & ") " _
                & "ORDER BY T_FileFlussi.progrflusso, T_FileFlussi.posizione"
            Case Is = "Controlli"
                sselect = "SELECT controllo, controllofile FROM T_Controlli"
            Case Is = "Attivit"
                sselect = "SELECT T_Attivita.codiceattivita, T_Attivita.progrflusso, " _
                & "T_Flussi.flusso, T_Attivita.progrperiodo, T_Periodi.periodo, " _
                & "MIN(T_Attivita.datainserimento) AS data, T_Attivita.controllo, " _
                & "T_Controlli.controllofile FROM T_Attivita INNER JOIN T_Controlli " _
                & "ON T_Attivita.controllo = T_Controlli.controllo INNER JOIN T_Flussi " _
                & "ON T_Attivita.progrflusso = T_Flussi.progrflusso INNER JOIN T_Periodi " _
                & "ON T_Attivita.progrperiodo = T_Periodi.progrperiodo " _
                & "WHERE(T_Attivita.progrreferente = " & nUtente & ") " _
                & "AND (T_Attivita.validita = 1) GROUP BY T_Attivita.codiceattivita, " _
                & "T_Attivita.progrflusso, T_Flussi.flusso, T_Attivita.progrperiodo, " _
                & "T_Periodi.periodo, T_Attivita.controllo, T_Controlli.controllofile " _
                & "ORDER BY MIN(T_Attivita.datainserimento) DESC"
            Case Is = "Referenti"
                sselect = "SELECT T_Referenti.progrreferente, " _
                & "T_Referenti.referente FROM T_Referenti " _
                & "T_Referenti_1 INNER JOIN T_ReferentiFlussi " _
                & "T_ReferentiFlussi_1 ON T_Referenti_1." _
                & "progrreferente = T_ReferentiFlussi_1." _
                & "progrreferente INNER JOIN T_Referenti INNER " _
                & "JOIN T_ReferentiFlussi ON T_Referenti." _
                & "progrreferente = T_ReferentiFlussi." _
                & "progrreferente ON  T_ReferentiFlussi_1." _
                & "progrflusso = T_ReferentiFlussi.progrflusso " _
                & "WHERE (T_Referenti_1.codaz = 'ars') AND " _
                & "(T_Referenti_1.progrreferente = " & nUtente & ") " _
                & "AND (T_Referenti.codaz <> 'ars') AND " _
                & "(T_Referenti.dataend IS NULL) GROUP BY " _
                & "T_Referenti.progrreferente, " _
                & "T_Referenti.referente ORDER BY T_Referenti.referente"
            Case Else
                sselect = ""
        End Select
        Return sselect
    End Function
        Public Function KeysActivity(ByRef nprog As Long, ByRef nact As Long, ByVal nstep As Byte) As Boolean
            'La funzione KeysActivity legge i parametri progressivo e codice attività nel Db
            'li assegna alle variabili di input e poi li aggiorna nel db, mentre il progressivo
            'viene incrementato a seconda dei file da inserire(nstep), il codice attività
            'viene incrementato di 1.

            'Stringa di esecuzione del comando per la l'interrogazione dei dati
            Dim strsql As String = "SELECT prograttivita, codiceattivita FROM T_Attivita_Sys"
            'Connessione al SQL server tramite la stringa definita nel Web Config
            Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
            'Transazione per l'aggiornamento dei dati
            Dim mytransact As SqlClient.SqlTransaction
            'Data reader per la memorizzazione dei dati
            Dim myreader As SqlClient.SqlDataReader
            Try
                'Comando per l'aggiornamento dei dati
                Dim myCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand(strsql, myConnection)
                'Apertura della connessione 
                myConnection.Open()
                'Inizia la transazione con livello di blocco assoluto del recordset
                mytransact = myConnection.BeginTransaction(IsolationLevel.Serializable)
                'Il comando viene legato alla transazione
                myCommand.Transaction = mytransact
                'Il reader viene popolato con i dati richiesti
                myreader = myCommand.ExecuteReader(CommandBehavior.SingleRow)
                If myreader.HasRows Then
                    myreader.Read()
                    nprog = myreader.GetValue(0)
                    nact = myreader.GetValue(1)
                End If
                myreader.Close()

                'Se i valori ricevuti da server sono maggiori di 0
                If nprog > 0 And nact > 0 Then
                    'Stringa di esecuzione del comando per la modifica dei dati
                    strsql = "UPDATE T_Attivita_Sys SET prograttivita" _
                    & "= " & nprog & " + " & nstep & ", codiceattivita = " & nact & " + 1"
                    myCommand.CommandText = strsql
                    'Esecuzione comando
                    myCommand.ExecuteNonQuery()
                End If

                'La transazione viene eseguita
                mytransact.Commit()
                myConnection.Close()

                myCommand = Nothing
                myConnection = Nothing
                mytransact = Nothing
                myreader = Nothing
                Return True
            Catch ex As Exception
                'In caso di errore durante la procedura la transazione viene annullata,
                'chiude la connessione e viene restituito un messaggio di errore
                mytransact.Rollback()
                If myConnection.State = ConnectionState.Open Then
                    myConnection.Close()
                End If
                myConnection = Nothing
                mytransact = Nothing
                myreader = Nothing
                Return False
            End Try
        End Function
    Public Function PathFileActivity(ByVal wcartella As String, ByVal wflusso As Integer, ByVal wperiodo As Integer, ByVal nprog As Long, ByVal nact As Long, ByVal wext As String) As String
        'La funzione PathFileActivity costruisce in base ai parametri passati il percorso
        'da attribuire nella macchina locale ai file caricati dall'utente
        If Trim(wcartella) <> "" And wflusso > 0 And wperiodo > 0 And nprog > 0 And nact > 0 And Trim(wext) <> "" Then
            Return Trim(wcartella) & "\" & Trim(Str(wflusso)) & "\" & Trim(Str(nact)) & "_" & Trim(Str(nprog)) & Trim(wext)
        Else
            Return ""
        End If
    End Function
    Public Function InsActivity(ByVal numf As Byte, ByVal progf As Long, ByVal natt As Long, ByVal nflu As Integer, ByVal nref As Integer, ByVal nperiodo As Integer, ByVal nomef As ArrayList, ByVal npos As ArrayList, ByVal ntrasm As Integer, ByVal ncompr As Integer, ByVal filesalv As ArrayList, ByVal wnote As String) As Boolean
        'La funzione InsActivity inserisce nel Db la nuova attività con all'interno
        'tutti i file caricati dall'utente
        'Stringa di esecuzione del comando per la modifica dei dati
        Dim strsql As String
        'Connessione al SQL server tramite la stringa definita nel Web Config
        Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Transazione per l'aggiornamento dei dati
        Dim mytransact As SqlClient.SqlTransaction
        'Comando per l'aggiornamento dei dati
        Dim myCommand As New SqlClient.SqlCommand
        myCommand.Connection = myConnection
        Try
            'Apertura della connessione 
            myConnection.Open()
            'Inizia la transazione con livello di blocco assoluto del recordset
            mytransact = myConnection.BeginTransaction(IsolationLevel.Serializable)
            'Il comando viene legato alla transazione
            myCommand.Transaction = mytransact
            'Creazione del contatore da inserire nel ciclo con il numero dei file da caricare
            Dim i As Byte
            For i = 0 To numf - 1
                'Creo la stringa di comando per l'inserimento dell'attività
                strsql = "INSERT INTO T_Attivita (prograttivita, codiceattivita, " _
                & "progrreferente, progrflusso, progrperiodo, datainserimento, " _
                & "nomefile, posizione, progrtras, progrcompressione, controllo, " _
                & "filesalvato, validita, dataini, note) VALUES (" & progf + i + 1 & "," _
                & " " & natt & ", " & nref & ", " & nflu & ", " & nperiodo & ", " _
                & "{ fn NOW() }, '" & nomef(i) & "', " & npos(i) & ", " & ntrasm & "," _
                & " " & ncompr & ", 0, '" & filesalv(i) & "', 1, { fn NOW() }, '" & RimpiazzaStringa(wnote) & "')"
                myCommand.CommandText = strsql
                myCommand.ExecuteNonQuery()
            Next
            mytransact.Commit()
            myConnection.Close()

            myCommand = Nothing
            myConnection = Nothing
            mytransact = Nothing
            Return True
        Catch ex As Exception
            'In caso di errore durante la procedura la transazione viene annullata,
            'chiude la connessione e viene restituito un messaggio di errore
            mytransact.Rollback()
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            myConnection = Nothing
            Return False
        End Try
    End Function
    Public Function ShowActivity(ByVal customerID As Integer, ByVal wflusso As Integer, ByVal wperiodo As Integer) As DataSet
        'La funzione ShowActivity restituisce un dataset con memorizzati i dati(flusso,
        'controllo, periodo...)per visualizzare tutte le attività relative ad un utente
        'Crea un nuovo dataset DSAttivit
        Dim ds As New DataSet
        ds.DataSetName = "DSAttivit"
        'Connessione al SQL server tramite la stringa definita nel Web Config
        Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Creazione DataAdapter e relativo comando di selezione
        Dim sqlda4 As New SqlClient.SqlDataAdapter
        Dim sqlcomm4 As New SqlClient.SqlCommand

        Try
            'Mappatura(creazione colonne) dei data adapter
            sqlda4.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_Attivita", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("codiceattivita", "codiceattivita"), New System.Data.Common.DataColumnMapping("progrflusso", "progrflusso"), New System.Data.Common.DataColumnMapping("flusso", "flusso"), New System.Data.Common.DataColumnMapping("progrperiodo", "progrperiodo"), New System.Data.Common.DataColumnMapping("periodo", "periodo"), New System.Data.Common.DataColumnMapping("data", "data"), New System.Data.Common.DataColumnMapping("controllo", "controllo"), New System.Data.Common.DataColumnMapping("controllofile", "controllofile")})})
                sqlcomm4.CommandText = "select * from V_SelAttivit where " _
                & " (progrreferente = " & customerID & ") AND " _
                & "(progrflusso = " & wflusso & ") " _
                & "AND (progrperiodo = " & wperiodo & ") ORDER BY codiceattivita DESC"
            sqlda4.SelectCommand = sqlcomm4
            sqlcomm4.Connection = myConnection
            'Apertura della connessione ed esecuzione comando
            myConnection.Open()
            'Popolamento del Dataset
            ds.EnforceConstraints = False
            sqlda4.Fill(ds)
            ds.EnforceConstraints = True
            myConnection.Close()
            myConnection = Nothing
            Return ds
        Catch ex As Exception
            'In caso di errore durante la procedura chiude la connessione e 
            'tutti gli oggetti, non viene restituito alcun valore
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            myConnection = Nothing
            sqlda4 = Nothing
            sqlcomm4 = Nothing
            Return Nothing
        End Try
    End Function
    Public Function FiltraActivity(ByVal w_dv As DataView, ByVal fflusso As Integer, ByVal fperiodo As Integer, ByVal fdatada As String, ByVal fdataa As String, ByVal fcontrollo As Integer) As DataView
        'La funzione FiltraActivity riceve un dataview e lo restituisce filtrato
        Try
            'Utilizzo della funzione CreaFiltro
            w_dv.RowFilter = CreaFiltro(fflusso, fperiodo, fdatada, fdataa, fcontrollo)
            Return w_dv
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function CreaFiltro(ByVal fflusso As Integer, ByVal fperiodo As Integer, ByVal fdatada As String, ByVal fdataa As String, ByVal fcontrollo As Integer) As String
        'La funzione CreaFiltro restituisce una stringa con all'interno il filtro per la dataview
        'costruito sulla base dei parametri selezionati dall'utente
        Try
            'Creazione stringa per il filtro
            Dim strfiltro As String
            'Se il flusso è valido
            If fflusso > 0 Then
                strfiltro = "progrflusso=" & fflusso
            End If
            'Se il periodo è valido
            If fperiodo > 0 Then
                'Se è stato applicato un filtro precedente 
                If strfiltro <> "" Then
                    strfiltro = strfiltro & " AND progrperiodo=" & fperiodo
                Else
                    strfiltro = "progrperiodo=" & fperiodo
                End If
            End If
            'Se il campo data da è valido
            If Trim(fdatada) <> "" Then
                'Se è stato applicato un filtro precedente 
                If strfiltro <> "" Then
                    strfiltro = strfiltro & " AND data>=#" & fdatada & "# and data<=#" & fdataa & "#"
                Else
                    strfiltro = "data>=#" & fdatada & "# and data<=#" & fdataa & "#"
                End If
            End If
            'Se il campo controllo è valido
            If fcontrollo >= 0 Then
                'Se è stato applicato un filtro precedente
                If strfiltro <> "" Then
                    strfiltro = strfiltro & " AND controllo='" & fcontrollo & "'"
                Else
                    strfiltro = "controllo='" & fcontrollo & "'"
                End If
            End If
            Return strfiltro
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function DetailsActivity(ByVal wcodatt As Long) As DataTable
        'La funzione DetailsActivity restituisce il dettaglio dell'attività richiesta,
        'mostrando l'elenco di file e lo stato di validazione
        'Stringa di esecuzione del comando per la l'interrogazione dei dati
        Dim strsql As String = "SELECT T_FileFlussi.posizione, T_FileFlussi.nomefile, " _
        & "T_Attivita.nomefile AS nome, T_Controlli.controllofile, " _
        & "T_Attivita.datacontrollo, T_Attivita.filererrori, T_Attivita.filederrori, " _
        & "T_Attivita.filericevuta, T_Attivita.codiceattivita " _
        & "FROM T_Attivita INNER JOIN T_FileFlussi ON " _
        & "T_Attivita.progrflusso = T_FileFlussi.progrflusso AND T_Attivita.posizione = " _
        & "T_FileFlussi.posizione INNER JOIN T_Controlli ON T_Attivita.controllo = " _
        & "T_Controlli.controllo WHERE (T_Attivita.codiceattivita = " & wcodatt & ") " _
        & "AND (T_Attivita.validita = 1)"
        'Connessione al SQL server tramite la stringa definita nel Web Config
        Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Transazione per l'aggiornamento dei dati
        Dim mytransact As SqlClient.SqlTransaction
        'Data reader per la memorizzazione dei dati
        Dim myreader As SqlClient.SqlDataReader
        Try
            'Comando per l'aggiornamento dei dati
            Dim myCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand(strsql, myConnection)
            'Apertura della connessione 
            myConnection.Open()
            'Inizia la transazione con livello di blocco assoluto del recordset
            mytransact = myConnection.BeginTransaction(IsolationLevel.Serializable)
            'Il comando viene legato alla transazione
            myCommand.Transaction = mytransact
            'Il reader viene popolato con i dati richiesti
            myreader = myCommand.ExecuteReader(CommandBehavior.SequentialAccess)

            Dim dt As New DataTable
            dt.Columns.Add("posizione", GetType(Integer))
            dt.Columns.Add("nomefile", GetType(String))
            dt.Columns.Add("nome", GetType(String))
            dt.Columns.Add("controllofile", GetType(String))
            dt.Columns.Add("datacontrollo", GetType(Date))
            dt.Columns.Add("filererrori", GetType(String))
            dt.Columns.Add("filederrori", GetType(String))
            dt.Columns.Add("filericevuta", GetType(String))
            dt.Columns.Add("codiceattivita", GetType(Long))

            If myreader.HasRows Then
                Do While myreader.Read
                    Dim Driga As DataRow = dt.NewRow
                    Driga("posizione") = myreader.GetValue(0)
                    Driga("nomefile") = myreader.GetValue(1)
                    Driga("nome") = myreader.GetValue(2)
                    Driga("controllofile") = myreader.GetValue(3)
                    Driga("datacontrollo") = myreader.GetValue(4)
                    Driga("filererrori") = myreader.GetValue(5)
                    Driga("filederrori") = myreader.GetValue(6)
                    Driga("filericevuta") = myreader.GetValue(7)
                    Driga("codiceattivita") = myreader.GetValue(8)
                    dt.Rows.Add(Driga)
                Loop
            End If

            myreader.Close()

            'La transazione viene eseguita
            mytransact.Commit()
            myConnection.Close()

            myCommand = Nothing
            myConnection = Nothing
            mytransact = Nothing
            myreader = Nothing
            Return dt
        Catch ex As Exception
            'In caso di errore durante la procedura la transazione viene annullata,
            'chiude la connessione e viene restituito un messaggio di errore
            mytransact.Rollback()
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            myConnection = Nothing
            mytransact = Nothing
            myreader = Nothing
            Return Nothing
        End Try
    End Function
    Public Function DeleteActivity(ByVal wcodatt As Long) As Boolean
        'La funzione DeleteActivity elimina l'attività selezionata dall'utente,
        'si tratta di un'eliminazione fittizia poichè il record non viene eliminato, ma
        'viene aggiornato il flag validità.
        'Stringa di esecuzione del comando per la l'eliminazione dei dati
        Dim strsql As String = "UPDATE T_Attivita SET validita = 0, dataend = " _
        & "{ fn NOW() } WHERE (codiceattivita = " & wcodatt & ")"
        'Connessione al SQL server tramite la stringa definita nel Web Config
        Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Transazione per l'eliminazione dei dati
        Dim mytransact As SqlClient.SqlTransaction
        Try
            'Comando per l'eliminazione dei dati
            Dim myCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand(strsql, myConnection)
            'Apertura della connessione 
            myConnection.Open()
            'Inizia la transazione con livello di blocco assoluto del recordset
            mytransact = myConnection.BeginTransaction(IsolationLevel.Serializable)
            'Il comando viene legato alla transazione e alla stringa SQL
            myCommand.Transaction = mytransact
            myCommand.CommandText = strsql
            myCommand.ExecuteNonQuery()
            'La transazione viene eseguita
            mytransact.Commit()
            myConnection.Close()

            myCommand = Nothing
            myConnection = Nothing
            mytransact = Nothing
            Return True
        Catch ex As Exception
            'In caso di errore durante la procedura la transazione viene annullata,
            'chiude la connessione e viene restituito un messaggio di errore
            mytransact.Rollback()
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            myConnection = Nothing
            mytransact = Nothing
            Return False
        End Try
    End Function
    Public Function RimpiazzaStringa(ByVal wstr As String) As String
        'La funzione RimpiazzaStringa costruisce una stringa da passare
        'in una sintassi SQL omettendo i caratteri ' e " che possono generare
        'un errore nell'esecuzione dell'istruzione SQL
        'Dimensiona una nuova stringa
        Dim newstr As String
        'Rimpiazza i caratteri non validi
        newstr = wstr.Replace("'", "")

        Return newstr
    End Function
    Public Function ShowActivityAdmin(ByVal customerID As Integer, ByVal wflusso As Integer, ByVal wperiodo As Integer) As DataSet
        'La funzione ShowActivity restituisce un dataset con memorizzati i dati(flusso,
        'controllo, periodo...)per visualizzare tutte le attività relative ad un utente
        'Crea un nuovo dataset DSAttivit
        Dim ds As New DataSet
        ds.DataSetName = "DSAttivit"
        'Connessione al SQL server tramite la stringa definita nel Web Config
        Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Creazione DataAdapter e relativo comando di selezione
        Dim sqlda4 As New SqlClient.SqlDataAdapter
        Dim sqlcomm4 As New SqlClient.SqlCommand

        Try
            'Mappatura(creazione colonne) dei data adapter
            sqlda4.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_Attivita", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("[Codice attività]", "[Codice attività]"), New System.Data.Common.DataColumnMapping("flusso", "flusso"), New System.Data.Common.DataColumnMapping("periodo", "periodo"), New System.Data.Common.DataColumnMapping("[Referente ZT]", "[Referente ZT]"), New System.Data.Common.DataColumnMapping("ZT", "ZT"), New System.Data.Common.DataColumnMapping("[Data caricamento]", "[Data caricamento]"), New System.Data.Common.DataColumnMapping("[Data controllo]", "[Data controllo]"), New System.Data.Common.DataColumnMapping("[File Ricevuta]", "[File Ricevuta]"), New System.Data.Common.DataColumnMapping("[File riepilogo errori]", "[File riepilogo errori]"), New System.Data.Common.DataColumnMapping("trasmissione", "trasmissione"), New System.Data.Common.DataColumnMapping("progrflusso", "progrflusso"), New System.Data.Common.DataColumnMapping("progrperiodo", "progrperiodo"), New System.Data.Common.DataColumnMapping("progrreferente", "progrreferente")})})
                sqlcomm4.CommandText = "select * from V_Controlla_Attivit_x_ASUR where " _
                & "(progrflusso = " & wflusso & ") " _
                & "AND (progrperiodo = " & wperiodo & ") ORDER BY [Codice attività] DESC"
            sqlda4.SelectCommand = sqlcomm4
            sqlcomm4.Connection = myConnection
            'Apertura della connessione ed esecuzione comando
            myConnection.Open()
            'Popolamento del Dataset
            ds.EnforceConstraints = False
            sqlda4.Fill(ds)
            ds.EnforceConstraints = True
            myConnection.Close()
            myConnection = Nothing
            Return ds
        Catch ex As Exception
            'In caso di errore durante la procedura chiude la connessione e 
            'tutti gli oggetti, non viene restituito alcun valore
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            myConnection = Nothing
            sqlda4 = Nothing
            sqlcomm4 = Nothing
            Return Nothing
        End Try
    End Function
    Public Function CheckActivity() As DataSet
        'La funzione CheckActivity restituisce un dataset con memorizzati i dati(flusso,
        'periodo...)per accedere alla vista dove sono elencati i dati caricati nei vari db
        'Crea un nuovo dataset DSFlussi
        Dim ds As New DataSet
        ds.DataSetName = "DSFlussi"
        'Connessione al SQL server tramite la stringa definita nel Web Config
        Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Creazione DataAdapter e relativo comando di selezione
        Dim sqlda1 As New SqlClient.SqlDataAdapter
        Dim sqlda2 As New SqlClient.SqlDataAdapter
        Dim sqlda3 As New SqlClient.SqlDataAdapter
        
        Dim sqlcomm1 As New SqlClient.SqlCommand
        Dim sqlcomm2 As New SqlClient.SqlCommand
        Dim sqlcomm3 As New SqlClient.SqlCommand
        

        Try
            'Mappatura(creazione colonne) dei data adapter
            sqlda1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_Flussi", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("progrflusso", "progrflusso"), New System.Data.Common.DataColumnMapping("flusso", "flusso")})})
            sqlda1.SelectCommand = sqlcomm1
            sqlcomm1.CommandText = "SELECT progrflusso, flusso " _
            & "FROM T_CheckDati_Flussi_Tot GROUP BY progrflusso" _
            & ", flusso ORDER BY progrflusso"
            sqlda2.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_Periodi", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("progrflusso", "progrflusso"), New System.Data.Common.DataColumnMapping("anno", "anno")})})
            sqlcomm2.CommandText = "SELECT progrflusso, anno FROM " _
            & "T_CheckDati_Flussi_Tot GROUP BY anno, progrflusso ORDER BY progrflusso, anno"
            sqlda2.SelectCommand = sqlcomm2
            sqlda3.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_Dati", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("azienda", "azienda"), New System.Data.Common.DataColumnMapping("anno", "anno"), New System.Data.Common.DataColumnMapping("mese", "mese"), New System.Data.Common.DataColumnMapping("record", "record"), New System.Data.Common.DataColumnMapping("progrflusso", "progrflusso"), New System.Data.Common.DataColumnMapping("flusso", "flusso")})})
            sqlcomm3.CommandText = "SELECT T_CheckDati_Flussi_Tot.* FROM " _
            & "T_CheckDati_Flussi_Tot ORDER BY flusso, anno, azienda, mese"
            sqlda3.SelectCommand = sqlcomm3
            
            sqlcomm1.Connection = myConnection
            sqlcomm2.Connection = myConnection
            sqlcomm3.Connection = myConnection
            
            'Apertura della connessione ed esecuzione comando
            myConnection.Open()
            'Popolamento del Dataset
            ds.EnforceConstraints = False
            sqlda1.Fill(ds)
            sqlda2.Fill(ds)
            sqlda3.Fill(ds)
            
            ds.EnforceConstraints = True
            myConnection.Close()
            myConnection = Nothing
            Return ds
        Catch ex As Exception
            'In caso di errore durante la procedura chiude la connessione e 
            'tutti gli oggetti, non viene restituito alcun valore
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            myConnection = Nothing
            sqlda1 = Nothing
            sqlda2 = Nothing
            sqlda3 = Nothing
            
            sqlcomm1 = Nothing
            sqlcomm2 = Nothing
            sqlcomm3 = Nothing
            
            Return Nothing
        End Try
    End Function
End Class

End Namespace
