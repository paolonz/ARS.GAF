Imports System.IO
Imports System.Web.Services
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports System.Data.SqlClient

Namespace arsflussi

    Partial Class iactivity
        Inherits BasePage
        Dim wds As DataSet
#Region " Codice generato da Progettazione Web Form "

        'Chiamata richiesta da Progettazione Web Form.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTA: la seguente dichiarazione è richiesta da Progettazione Web Form.
        'Non spostarla o rimuoverla.

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: questa chiamata al metodo è richiesta da Progettazione Web Form.
            'Non modificarla nell'editor del codice.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim ruoli() As Integer = {2, 3}
            InitializeUser(Session("TOKEN").ToString())
            Dim op As OperationResult
            op = CheckCohesion(Session("TOKEN").ToString(), ruoli)

            If Not op.Success Then
                MyError.Text = op.Message
                Return
            End If

            Try
                If Not Page.IsPostBack Then
                    'Inserire qui il codice utente necessario per inizializzare la pagina
                    hdUserID.Value = USERID

                    'Creazione oggetti della pagina e relativi attributi, validi per l'utente
                    'che utilizza l'applicazione
                    op = GetFlussiUtente(hdUserID.Value)

                    If op.Success Then
                        Dim flussi As List(Of Flussi) = op.Data
                        'Popolamento del campo Flusso
                        lblFlusso.Visible = True
                        Flusso.Visible = True
                        lflusso.Visible = False
                        linkFlussosucc.Visible = True
                        Flusso.DataSource = flussi
                        Flusso.DataValueField = "ID"
                        Flusso.DataTextField = "Flusso"
                        Flusso.DataBind()
                    Else
                        MyError.Text = op.Message & " Per iniziare di nuovo, fare clic sul Menù alla voce 'Inserisci attività'."
                    End If
                End If
            Catch ex As Exception
                'In caso di errore nella pagina viene visualizzato un messaggio nel campo
                'MyError e il data grid viene reso non visibile
                MyError.Text = ex.Message & ". Per iniziare di nuovo, fare clic sul Menù alla voce 'Inserisci attività'."
                'ListFile.Visible = False
            End Try
        End Sub

        Private Function VerificaFile() As Byte
            'La funzione VerificaFile controlla che i campi dei file da caricare 
            'non siano vuoti, che l'estensione sia valida e che sia compatibile con quella
            'selezionata nel campo Compressione.
            'Se si verifica un errore viene restituito il n. della riga interessata.
            'Il cursore scorre il datagrid e inizializza il campo per il caricamento
            Dim i As Byte
            'N. della riga che genera l'errore
            Dim numerr As Byte
            Dim srcfile As DropDownList
            'Creazione label che contiene la cartella FTP di ricezione del file
            Dim srcftp As Label
            'Stringa con all'interno il messaggio dell'errore
            Dim strerr As String
            Dim dir As String
            dir = "D:\"
            'AGGIUNGERE PERCORSO
            'Try
            '    'check that the file has been selected and it's a valid file
            '    If (Not fuUploadFileFlussi.PostedFile Is Nothing) _
            '       And (fuUploadFileFlussi.PostedFile.ContentLength > 0) Then
            '        'determine file name
            '        Dim sFileName As String = _
            '           System.IO.Path.GetFileName(fuUploadFileFlussi.PostedFile.FileName)
            '        Try
            '            'If fuUploadFileFlussi.PostedFile.ContentLength <= lMaxFileSize Then
            '            'save file on disk
            '            // fuUploadFileFlussi.PostedFile.SaveAs(dir + sFileName)
            '            'lblMessage.Visible = True
            '            'lblMessage.Text = "File: " + dir + sFileName + _
            '            '   " Uploaded Successfully"
            '            'Else    'reject file
            '            'lblMessage.Visible = True
            '            'lblMessage.Text = "File Size if Over the Limit of " + _
            '            '   lMaxFileSize
            '            'End If
            '        Catch exc As Exception    'in case of an error
            '            'lblMessage.Visible = True
            '            'lblMessage.Text = "An Error Occured. Please Try Again!"
            '            'DeleteFile(dir + sFileName)
            '        End Try
            '    Else
            '        'lblMessage.Visible = True
            '        'lblMessage.Text = "Nothing to upload. Please Try Again!"
            '    End If
            '    'For i = 0 To ListFile.Items.Count - 1
            '    '    srcftp = CType(ListFile.Items(i).FindControl("lFTP"), Label)
            '    '    srcfile = CType(ListFile.Items(i).FindControl("FileSrc"), DropDownList)

            '    '    'Se i campi non sono vuoti....
            '    '    If Trim(srcfile.SelectedItem.Value) <> "" Then
            '    '        'Viene richiamata la funzione PathFileActivity per costruire 
            '    '        'il percorso del file caricato nel server di destinazione

            '    '        'Creazione di una data view sulla tabella T_Compressioni filtrata
            '    '        'con l'estensione del file da caricare e il valore 
            '    '        'del campo Trasmissione

            '    '        Dim dv As DataView
            '    '        dv = New DataView
            '    '        dv.Table = wds.Tables("T_Compressioni")
            '    '        dv.RowFilter = "estensione = '" & Trim(Path.GetExtension(srcfile.SelectedItem.Value)) & "' AND " _
            '    '        & "progrcompressione = " & Compressione.SelectedItem.Value
            '    '        'Se la data view risulta avere almeno una riga
            '    '        If dv.Count > 0 Then
            '    '            'Se il file trasmesso risulta essere presente nella 
            '    '            'cartella FTP di competenza dell'utente
            '    '            Dim pathftp As String = Trim(srcftp.Text) & "\" & Path.GetFileName(srcfile.SelectedItem.Value)
            '    '            If File.Exists(pathftp) Then
            '    '                'i controlli sono soddisfatti
            '    '                numerr = 0

            '    '                dv = Nothing
            '    '            Else
            '    '                strerr = "Il file non risulta essere presente nella " _
            '    '                        & "cartella FTP."
            '    '                numerr = i + 1

            '    '                dv = Nothing
            '    '                Exit For
            '    '            End If
            '    '        Else
            '    '            strerr = "Tipo di file non previsto e/o non congruente " _
            '    '            & "con il tipo di compressione selezionata."
            '    '            numerr = i + 1

            '    '            dv = Nothing
            '    '            Exit For
            '    '        End If
            '    '    Else
            '    '        numerr = i + 1
            '    '        strerr = "Campo vuoto."
            '    '        Exit For
            '    '    End If
            '    'Next
            '    srcfile = Nothing
            '    srcftp = Nothing
            '    If numerr > 0 Then
            '        MyError.Text = "Impossibile caricare il file alla posizione " & numerr & ". " & strerr
            '    End If
            '    Return numerr
            'Catch ex As Exception
            '    srcfile = Nothing
            '    srcftp = Nothing
            '    MyError.Text = "Impossibile caricare il file alla posizione " & numerr & ". " & ex.Message
            '    Return i + 1
            'End Try
        End Function
        Private Sub PopolaFile()
            'La Sub PopolaFile alimenta i dropdwnlist presenti nel datagrid inserendo
            ' i file presenti nella cartella FTP di competenza dell'utente
            'Il cursore scorre il datagrid e inizializza il campo per il caricamento
            Dim i As Byte
            Dim combo As DropDownList
            Dim srcftp As Label
            Try
                'Se il datagrdi contiene almeno una riga
                'If ListFile.Items.Count > 0 Then
                '    srcftp = CType(ListFile.Items(0).FindControl("lFTP"), Label)
                '    'Creazione nuova data table
                '    Dim dt As New DataTable
                '    'Creazione campo nfile
                '    dt.Columns.Add("nfile", GetType(String))
                '    'Inserimento riga vuota
                '    Dim Driga As DataRow
                '    Driga = dt.NewRow
                '    Driga("nfile") = ""
                '    dt.Rows.Add(Driga)
                '    'Inserimento righe a seconda di quanti file sono presenti nell'FTP
                '    For Each n As String In Directory.GetFiles(Trim(srcftp.Text))
                '        Driga = dt.NewRow
                '        Driga("nfile") = Path.GetFileName(n)
                '        dt.Rows.Add(Driga)
                '    Next
                '    'Aggiornamento dei dropdownlist
                '    For i = 0 To ListFile.Items.Count - 1
                '        combo = CType(ListFile.Items(i).FindControl("FileSrc"), DropDownList)
                '        combo.DataSource = dt
                '        combo.DataValueField = "nfile"
                '        combo.DataTextField = "nfile"
                '        combo.DataBind()
                '    Next
                '    If dt.Rows.Count <= 1 Then
                '        ListFile.Visible = False
                '        linkfileprec.Visible = False
                '        linkfilesucc.Visible = False
                '        MyError.Text = "Nessun file da caricare. I file devono essere caricati prima per FTP."
                '    End If
                '    dt = Nothing
                '    Driga = Nothing
                'End If
                combo = Nothing
                srcftp = Nothing

            Catch ex As Exception
                MyError.Text = ex.Message
                combo = Nothing
                srcftp = Nothing
            End Try

        End Sub

        Private Sub linkFlussoscc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkFlussosucc.Click
            Try
                lblFlusso.Visible = True
                Flusso.Visible = False
                lflusso.Visible = True
                lflusso.Text = Flusso.SelectedItem.Text
                hdnFlusso.Value = Flusso.SelectedItem.Value
                linkFlussosucc.Visible = False

                Periodo.Visible = True
                lblperiodo.Visible = True
                lperiodo.Visible = False
                linkperiodoprec.Visible = True
                linkperiodosucc.Visible = True

                'Popolamento del campo Periodo
                Dim op As OperationResult
                op = GetPeriodoFlussi(hdUserID.Value, Flusso.SelectedItem.Value)

                If op.Success Then
                    Dim periodoflussi As List(Of PeriodoFlussi)
                    periodoflussi = op.Data
                    Periodo.DataSource = periodoflussi
                    Periodo.DataValueField = "PeriodoID"
                    Periodo.DataTextField = "PeriodoDesc"
                    Periodo.DataBind()
                Else
                    MyError.Text = op.Message & ". Per iniziare di nuovo, fare click sul Menù alla voce 'Inserisci attività."
                End If
            Catch ex As Exception
                'In caso di errore nella pagina viene visualizzato un messaggio nel campo
                'MyError e il data grid viene reso non visibile
                MyError.Text = ex.Message & ". Per iniziare di nuovo, fare clic sul Menù alla voce 'Inserisci attività'."
            End Try
        End Sub

        Private Sub linkperiodoprec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkperiodoprec.Click
            Flusso.Visible = True
            lblFlusso.Visible = True
            lflusso.Visible = False
            linkFlussosucc.Visible = True
            lblperiodo.Visible = False
            Periodo.Visible = False
            lperiodo.Visible = False
            linkperiodosucc.Visible = False
            linkperiodoprec.Visible = False
        End Sub

        Private Sub linkperiodosucc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkperiodosucc.Click
            Try
                'Federico
                lblperiodo.Visible = True
                Periodo.Visible = False

                lperiodo.Visible = True
                lperiodo.Text = Periodo.SelectedItem.Text

                hdnPeriodo.Value = Periodo.SelectedItem.Value

                linkperiodosucc.Visible = False
                linkperiodoprec.Visible = False
                lblTrasmissione.Visible = True
                Trasmissione.Visible = True
                lblBanner.Visible = True
                linktrasmissioneprec.Visible = True
                linktrasmissionesucc.Visible = True

                Dim op As OperationResult
                op = GetTrasmissioneARS()

                If op.Success Then

                    Dim trasmissioni As New List(Of Trasmissioni)
                    trasmissioni = op.Data

                    Trasmissione.DataSource = trasmissioni
                    Trasmissione.DataValueField = "ID"
                    Trasmissione.DataTextField = "Trasmissione"
                    Trasmissione.DataBind()
                Else
                    MyError.Text = op.Message & ". Per iniziare di nuovo, fare click sul Menù alla voce 'Inserisci attività'"
                End If

                
            Catch ex As Exception
                'In caso di errore nella pagina viene visualizzato un messaggio nel campo
                'MyError e il data grid viene reso non visibile
                MyError.Text = ex.Message & ". Per iniziare di nuovo, fare click sul Menù alla voce 'Inserisci attività'."
            End Try
        End Sub

        Private Sub linktrasmissionesucc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linktrasmissionesucc.Click
            'Federico
            lblTrasmissione.Visible = True
            Trasmissione.Visible = False
            ltrasmissione.Visible = True
            ltrasmissione.Text = Trasmissione.SelectedItem.Text

            hdnTrasmissione.Value = Trasmissione.SelectedItem.Value

            lblBanner.Visible = False
            linktrasmissionesucc.Visible = False
            linktrasmissioneprec.Visible = False
            lblChooseFile.Visible = True


            lblUpload.Visible = True
            uploadDiv.Visible = True

            lblCompressione.Visible = True
            lcompressione.Visible = False
            Compressione.Visible = True
            lblnote.Visible = True
            txtnote.Visible = True
            linkfineprec.Visible = True

            Dim op As OperationResult
            op = GetCompressione()

            If op.Success Then

                Dim compressioni As New List(Of Compressione)
                compressioni = op.Data

                Compressione.DataSource = compressioni
                Compressione.DataValueField = "ID"
                Compressione.DataTextField = "Compressione"
                Compressione.DataBind()

                ' Da qui
                NumberOfFileToUpload(Integer.Parse(Flusso.SelectedValue))

            Else
                MyError.Text = op.Message
            End If

        End Sub

        Private Sub linkfineprec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkfineprec.Click
            'lblfine.Visible = False

            linkfineprec.Visible = False

            lblCompressione.Visible = False
            Compressione.Visible = False
            lcompressione.Visible = False
            lblnote.Visible = False
            txtnote.Visible = False
            ltrasmissione.Visible = False
            lblUpload.Visible = False
            uploadDiv.Visible = False

            lblChooseFile.Visible = False

            Trasmissione.Visible = True
            lblBanner.Visible = True
            lblTrasmissione.Visible = True
            linktrasmissionesucc.Visible = True
            linktrasmissioneprec.Visible = True

        End Sub


        Protected Sub linktrasmissioneprec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles linktrasmissioneprec.Click

            lblTrasmissione.Visible = False
            Trasmissione.Visible = False
            ltrasmissione.Visible = False
            linktrasmissioneprec.Visible = False
            linktrasmissionesucc.Visible = False
            lblBanner.Visible = False
            linkperiodoprec.Visible = True
            linkperiodosucc.Visible = True
            Periodo.Visible = True
            lperiodo.Visible = False
            lblperiodo.Visible = True

        End Sub

        Private Sub NumberOfFileToUpload(ByVal idFlusso As Integer)

            Dim fileToUpload As New DataTable
            fileToUpload = GetNumberFileUpload(idFlusso)

            file_upload_repeater.DataSource = fileToUpload
            file_upload_repeater.DataBind()

            ViewState("UploadFileTable") = fileToUpload

        End Sub

        Private Function GetNumberFileUpload(ByVal idFlusso As Integer) As DataTable

            Dim query As String = "SELECT T_FileFlussi.progrflusso, T_FileFlussi.posizione, T_FileFlussi.nomefile FROM T_FileFlussi INNER JOIN T_Flussi ON T_Flussi.progrflusso = T_FileFlussi.progrflusso WHERE T_Flussi.progrflusso = @progrflusso"

            Dim conn As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
            Dim cmd As New SqlClient.SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@progrflusso", idFlusso)

            Dim tblFileUpload As New DataTable()

            Try
                conn.Open()
                Dim adapter As New SqlClient.SqlDataAdapter(cmd)
                adapter.Fill(tblFileUpload)

            Catch ex As Exception
                tblFileUpload = Nothing
            Finally
                conn.Close()
            End Try

            Return tblFileUpload

        End Function

        Protected Sub InserisciBtn_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertBtn.Click

            'Creazione del controllo InputFile per la trasmissione del file
            Dim srcfile As DropDownList
            'Creazione label che contiene la posizione del file
            Dim srcpos As Label
            Dim pos As Integer
            'Creazione label che contiene la cartella di ricezione del file
            Dim srccart As Label
            'Creazione label che contiene il percorso del file da utilizzare nel programma
            'di controllo
            Dim srcperc As Label
            'Creazione label che contiene il percorso del file da utilizzare nell'FTP
            Dim srcftp As Label
            'Creazione di un nuovo oggetto Activity
            Dim wact As New Activity
            'Variabile per il controllo dell'effettivo inserimento dell'attività nell'agenda
            Dim w_response As Boolean
            'N progr del file dell'attività
            Dim numprogratt As Long = 0
            'N attività
            Dim numcodatt As Long = 0
            'Stringa che contiene l'errore generato in questa pagina
            Dim strerr As String

            Try

                Dim i As Integer = 0
                Dim verified As Boolean = True

                For Each item As RepeaterItem In file_upload_repeater.Items

                    Dim fileUpload As FileUpload = item.FindControl("file_upload")

                    If Not (String.IsNullOrEmpty(fileUpload.FileName)) Then

                        '' QUI BISOGNA VERIFICARE SE I FILE CHE SONO STATI INVIATI SONO CORRETTI (Discorso della dimensione + estenzione)
                        '' SE CI SONO ERRORI BISOGNA SCRIVERLI NELLA LABEL ErrorInsert
                        verified = ControlloFile(fileUpload)

                        i = i + 1

                    End If

                    If (verified = False) Then
                        ' Se c'è un errore blocco l'inserimento e visualizzo a video gli eventuali errori
                        ' riscontrati
                        ErrorInsert.Text = "Il file " + fileUpload.FileName + " non rispetta i vincoli di estensione e dimensione consentiti dal sistema. " & _
                            "Il file non può superare i 5 Mb di dimensione. " & _
                            "In caso di file compresso, l'estensione accettata è rar o zip e la dimensione dell'archivio non può superare i 50 Mb."

                        Return

                    End If

                Next

                If (i > 0) Then

                    pos = 1

                    Dim customerID As Integer = Integer.Parse(hdUserID.Value)
                    Dim path() As String = GetInfoUser(customerID)

                    Dim w_keyact As Boolean = wact.KeysActivity(numprogratt, numcodatt, i)
                    If (w_keyact) Then
                        Dim arnomefile As New ArrayList(i)
                        Dim arposiz As New ArrayList(i)
                        Dim arfilesalv As New ArrayList(i)

                        For Each item As RepeaterItem In file_upload_repeater.Items

                            Dim fileUpload As FileUpload = item.FindControl("file_upload")

                            ' DA QUI!!!
                            ' Crea le cartelle!!!

                            'fileUpload.PostedFile.SaveAs(Server.MapPath("Dati\"))

                            ' BISOGNA VEDERE A COSA SERVIVANO TUTTE QUESTE VARIABILI
                            ' QUESTI DATI VENIVANO PRESI DAL CONTROLLO CHE DOBBIAMO SOSTITUIRE

                            'srcfile = CType(ListFile.Items(i).FindControl("FileSrc"), DropDownList)

                            ' Gli altri parametri li ho presi da GetInfoUser()
                            ' VEDERE SOTTO If (i > 0) Then
                            ' srcpos = CType(ListFile.Items(i).FindControl("lPosizione"), Label)
                            ' srccart = CType(ListFile.Items(i).FindControl("lCartella"), Label)
                            ' srcperc = CType(ListFile.Items(i).FindControl("lPathUser"), Label)
                            ' srcftp = CType(ListFile.Items(i).FindControl("lFTP"), Label)

                            ' Viene richiamata la funzione PathFileActivity per costruire
                            ' il percorso del file caricato nel server di destinazione
                            ' COMMENTATO PERCHE' BISOGNA VEDERE QUALI SONO LE VARIABILI DA UTILIZZARE
                            ' Dim strfile As String = wact.PathFileActivity(Trim(srccart.Text), Flusso.SelectedItem.Value, Periodo.SelectedItem.Value, Val(srcpos.Text), numcodatt, Trim(Path.GetExtension(srcfile.SelectedItem.Value)))
                            Dim strfile As String = wact.PathFileActivity(Trim(path(0)), Flusso.SelectedItem.Value, Periodo.SelectedItem.Value, Val(pos.ToString()), numcodatt, Trim(System.IO.Path.GetExtension(fileUpload.FileName)))

                            'Caricamento del file 
                            ' COMMENTATO PERCHE' BISOGNA VEDERE QUALI SONO LE VARIABILI DA UTILIZZAR
                            'File.Move(Trim(srcftp.Text) & "\" & Trim(Path.GetFileName(srcfile.SelectedItem.Value)), Trim(strfile))
                            'fileUpload.SaveAs(Trim(path(2)) & "\" & Trim(System.IO.Path.GetFileName(fileUpload.FileName)))
                            SaveFile(fileUpload.FileBytes, pos, numcodatt, path(1), Flusso.SelectedItem.Value, System.IO.Path.GetExtension(fileUpload.FileName))

                            ' COMMENTATO PERCHE' BISOGNA VEDERE QUALI SONO LE VARIABILI DA UTILIZZAR
                            ' arnomefile.Add(Path.GetFileName(srcfile.SelectedItem.Value))
                            arnomefile.Add(System.IO.Path.GetFileName(fileUpload.FileName))
                            ' COMMENTATO PERCHE' BISOGNA VEDERE QUALI SONO LE VARIABILI DA UTILIZZAR
                            ' arposiz.Add(srcpos.Text)
                            arposiz.Add(pos.ToString())
                            ' COMMENTATO PERCHE' BISOGNA VEDERE QUALI SONO LE VARIABILI DA UTILIZZAR
                            ' arfilesalv.Add(wact.PathFileActivity(Trim(srcperc.Text), Flusso.SelectedItem.Value, Periodo.SelectedItem.Value, Val(srcpos.Text), numcodatt, Trim(Path.GetExtension(srcfile.SelectedItem.Value))))
                            arfilesalv.Add(wact.PathFileActivity(Trim(path(1)), Flusso.SelectedItem.Value, Periodo.SelectedItem.Value, Val(pos.ToString()), numcodatt, Trim(System.IO.Path.GetExtension(fileUpload.FileName))))

                            ' incremento pos
                            pos = pos + 1
                        Next

                        w_response = wact.InsActivity(i, numprogratt, numcodatt, Flusso.SelectedItem.Value, hdUserID.Value, Periodo.SelectedItem.Value, arnomefile, arposiz, Trasmissione.SelectedItem.Value, Compressione.SelectedItem.Value, arfilesalv, Left(txtnote.Text, 254))
                End If
                Else

                    ErrorInsert.Text = "Devi selezionare almeno un file da caricare"

                End If

                srcfile = Nothing
                srcpos = Nothing
                srccart = Nothing
                srcftp = Nothing
                wact = Nothing
                If w_response Then
                    'Se l'attività è stata inserita correttamente si passa 
                    'alla pagina di conferma
                    Response.Redirect("cactivity.aspx?a=" & numcodatt)
                End If
            Catch ex As Exception
                MyError.Text = ex.Message
                srcfile = Nothing
                srcpos = Nothing
                srccart = Nothing
                srcftp = Nothing
                wact = Nothing
            End Try

        End Sub
        Private Function SaveFile(ByVal content As Byte(), ByVal prog As Long, ByVal attivita As Long, ByVal usr As String, ByVal flusso As Integer, ByVal ext As String)
            Dim ftpPath As String = ConfigurationManager.AppSettings("ftpRoot")
            Dim dirInfo As New DirectoryInfo(String.Format("{0}/{1}/{2}", ftpPath, usr, flusso))
            Dim fileInfo As New FileInfo(String.Format("{0}/{1}/{2}/{3}_{4}{5}", ftpPath, usr, flusso, attivita, prog, ext))
            If (Not dirInfo.Exists) Then
                dirInfo.Create()
            End If
            System.IO.File.WriteAllBytes(fileInfo.FullName, content)
        End Function

        Private Function GetInfoUser(ByVal currID As Integer) As String()
            Dim conn As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
            Dim sql As New String("SELECT Utenti.Cartella, Utenti.PercorsoUtente, Utenti.CartellaFTP FROM Utenti WHERE Utenti.ID = " & currID)
            Dim cmd As New SqlClient.SqlCommand(sql, conn)

            Dim result(0 To 2) As String

            Try
                conn.Open()
                Dim reader As SqlClient.SqlDataReader
                reader = cmd.ExecuteReader()

                If (reader.Read()) Then
                    result(0) = reader("Cartella").ToString()
                    result(1) = reader("PercorsoUtente").ToString()
                    result(2) = reader("CartellaFTP").ToString()
                End If

            Catch ex As Exception
                result = Nothing
            End Try

            Return result
        End Function

        ' Controlla se ci sono errori nella dimensione ed estensione dei file da uploadare
        Private Function ControlloFile(ByVal currFile As FileUpload) As Boolean

            ' Se il file ha dimensione minore di 5 Megabyte allora procedo con l'upload
            If (currFile.PostedFile.ContentLength < 5242880) Then
                Return True
            End If

            ' Se il file supera in dimensione 5 Megabyte allora controllo che sia un archivio zippato
            ' Se il file è un archivio zippato controllo se la sua dimensione supera i 50 Mb
            Dim ext As String
            ext = System.IO.Path.GetExtension(currFile.FileName).ToLower()

            If (Not ext.Equals(".zip") And Not ext.Equals(".rar")) Then
                Return False
            ElseIf (currFile.PostedFile.ContentLength > 52428800) Then
                Return False
            End If

            Return True

        End Function

        Private Function GetFlussiUtente(ByVal userID As Integer) As OperationResult

            Dim op As OperationResult

            Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
            Dim strSql As String = "SELECT T_Flussi.progrflusso, T_Flussi.flusso, T_Flussi.codiceflusso " _
                                   & "FROM T_Flussi INNER JOIN UtentiFlussi " _
                                   & "ON T_Flussi.progrflusso = UtentiFlussi.CodiceFlusso " _
                                   & "WHERE UtentiFlussi.CodiceUtente = @id"
            Dim cmd As New SqlCommand(strSql, conn)
            cmd.Parameters.AddWithValue("@id", userID)

            Dim flussi As New List(Of Flussi)

            Try
                conn.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Dim flusso As New Flussi()
                    flusso.ID = reader("progrflusso").ToString()
                    flusso.Flusso = reader("flusso").ToString()
                    flusso.CodiceFlusso = reader("codiceflusso").ToString()

                    flussi.Add(flusso)

                End While

                If flussi Is Nothing Or flussi.Count = 0 Then
                    op = New OperationResult(False, "Nessun flusso disponibile per l'utente!", Nothing)
                Else
                    op = New OperationResult(True, "OK", flussi)
                End If

            Catch ex As Exception
                op = New OperationResult(False, "Errore durante il recupero dei dati: " & ex.Message, Nothing)
            Finally
                conn.Close()
            End Try

            Return op

        End Function

        Private Function GetPeriodoFlussi(ByVal userID As Integer, ByVal flussoID As String) As OperationResult

            Dim op As OperationResult

            Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))

            Dim strSql As String = "SELECT T_Periodi.progrperiodo, T_Periodi.periodo, " _
                                & "T_Periodi.annoperiodo, T_PeriodiFlussi.progrflusso " _
                                & "FROM Utenti INNER JOIN UtentiFlussi " _
                                & "ON Utenti.ID = UtentiFlussi.CodiceUtente " _
                                & "INNER JOIN T_PeriodiFlussi INNER JOIN T_Periodi " _
                                & "ON T_PeriodiFlussi.progrperiodo = T_Periodi.progrperiodo " _
                                & "ON UtentiFlussi.CodiceFlusso = T_PeriodiFlussi.progrflusso " _
                                & "WHERE T_PeriodiFlussi.validita = 's' AND Utenti.ID = @userID " _
                                & "AND T_PeriodiFlussi.progrflusso = @flussoID " _
                                & "GROUP BY T_Periodi.progrperiodo, T_Periodi.periodo, " _
                                & "T_Periodi.annoperiodo, T_Periodi.meseperiodo, T_PeriodiFlussi.progrflusso " _
                                & "ORDER BY T_Periodi.annoperiodo DESC, T_Periodi.meseperiodo DESC"

            Dim cmd As New SqlCommand(strSql, conn)
            cmd.Parameters.AddWithValue("@userID", userID)
            cmd.Parameters.AddWithValue("@flussoID", Integer.Parse(flussoID))

            Dim periodoFlussi As New List(Of PeriodoFlussi)

            Try
                conn.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    Dim periodoflusso As New PeriodoFlussi
                    periodoflusso.PeriodoID = reader("progrperiodo").ToString()
                    periodoflusso.PeriodoDesc = reader("periodo").ToString()
                    periodoflusso.AnnoPeriodo = reader("annoperiodo").ToString()
                    periodoflusso.FlussoID = reader("progrflusso").ToString()

                    periodoFlussi.Add(periodoflusso)

                    End While

                If periodoFlussi Is Nothing Or periodoFlussi.Count = 0 Then
                    op = New OperationResult(False, "Nessun periodo attivo per il flusso selezionato!", Nothing)
                Else
                    op = New OperationResult(True, "OK", periodoFlussi)
                End If

            Catch ex As Exception
                op = New OperationResult(False, "Errore durante il recupero dei dati: " & ex.Message, Nothing)
                End Try

            Return op

        End Function

        Private Function GetTrasmissioneARS() As OperationResult

            Dim op As OperationResult

            Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
            Dim strSql As String = "SELECT progrtras, trasmissione FROM T_TrasmissioneARS"
            Dim cmd As New SqlCommand(strSql, conn)

            Dim trasmissioni As New List(Of Trasmissioni)

            Try
                conn.Open()

                Dim reader As SqlDataReader
                reader = cmd.ExecuteReader()

                While reader.Read()

                    Dim trasmissione As New Trasmissioni
                    trasmissione.ID = reader("progrtras")
                    trasmissione.Trasmissione = reader("trasmissione")

                    trasmissioni.Add(trasmissione)

                End While

                If trasmissioni Is Nothing Or trasmissioni.Count = 0 Then
                    op = New OperationResult(False, "Nessun tipo di trasmissione trovata!", Nothing)
                Else
                    op = New OperationResult(True, "OK", trasmissioni)
                End If


            Catch ex As Exception
                op = New OperationResult(False, "Errore durante il recupero dei dati: " & ex.Message, Nothing)
            End Try

            Return op

        End Function

        Private Function GetCompressione() As OperationResult

            Dim op As OperationResult

            Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
            Dim strSql As String = "SELECT progrcompressione, compressione, estensione " _
                                   & "FROM T_Compressioni"
            Dim cmd As New SqlCommand(strSql, conn)

            Dim trasmissioni As New List(Of Compressione)

            Try
                conn.Open()

                Dim reader As SqlDataReader
                reader = cmd.ExecuteReader()

                While reader.Read()

                    Dim trasmissione As New Compressione
                    trasmissione.ID = reader("progrcompressione")
                    trasmissione.Compressione = reader("compressione")
                    trasmissione.Estensione = reader("estensione")

                    trasmissioni.Add(trasmissione)

                End While

                If trasmissioni Is Nothing Or trasmissioni.Count = 0 Then
                    op = New OperationResult(False, "Nessuna compressione trovata!", Nothing)
                Else
                    op = New OperationResult(True, "OK", trasmissioni)
                End If


            Catch ex As Exception
                op = New OperationResult(False, "Errore durante il recupero dei dati: " & ex.Message, Nothing)
            End Try

            Return op

        End Function

    End Class

End Namespace
