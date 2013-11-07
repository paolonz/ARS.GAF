Namespace arsflussi

Partial Class dactivity
        Inherits BasePage

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

            Dim ruoli() As Integer = {0}
            InitializeUser(Session("TOKEN").ToString())
            Dim op As OperationResult
            op = CheckCohesion(Session("TOKEN").ToString(), ruoli)

            If Not op.Success Then
                myError.Text = op.Message
                Return
            End If

            'Creazione nuovo oggetto Activity per selezionare i dettagli dell'attività
            Dim wact As New Activity
            'Creazione del data table per la memorizzazione dei dati
            Dim dt As New DataTable

            'Al primo caricamento della pagina
            If Page.IsPostBack = False Then
                'Se il codice della prestazione che proviene dalla pagina sactivity è valido
                If Request.QueryString("a") <> "" Then
                    Try
                        'Memorizzazione dettagli dell'attività nel data table
                        dt = wact.DetailsActivity(Val(Request.QueryString("a")))
                        'Se il data table risulta non essere valido
                        If dt Is Nothing Then
                            'Gli oggetti della pagina vengono resi non visibili
                            'e compare un messaggio di errore
                            ListFile.Visible = False
                            hlDErrori.Visible = False
                            hlRErrori.Visible = False
                            hlRicevuta.Visible = False
                            Elimina.Visible = False
                            myError.Text = "Errore. Impossibile visualizzare l'attività."
                        Else
                            'Se il data table risulta avere almeno una riga
                            If dt.Rows.Count > 0 Then
                                'Il datagrid viene popolato
                                ListFile.DataSource = dt
                                ListFile.DataBind()
                                'Se l'attività non è stata validata
                                If Trim(dt.Rows(0)("datacontrollo").ToString) = "" Then
                                    Validazione.Text = "Dato " & dt.Rows(0)("controllofile")
                                    'I campi dei file della ricevuta e degli errori
                                    'non vengono visualizzati
                                    hlDErrori.Visible = False
                                    hlRErrori.Visible = False
                                    hlRicevuta.Visible = False
                                Else
                                    Validazione.Text = "Dato " & dt.Rows(0)("controllofile") & " il " & Trim(dt.Rows(0)("datacontrollo").ToString)
                                    hlDErrori.NavigateUrl = dt.Rows(0)("filederrori")
                                    hlRErrori.NavigateUrl = dt.Rows(0)("filererrori")
                                    hlRicevuta.NavigateUrl = dt.Rows(0)("filericevuta")
                                End If
                                'Memorizzazione del codice dell'attività
                                lAtt.Text = dt.Rows(0)("codiceattivita")
                            Else
                                'Gli oggetti della pagina vengono resi non visibili
                                'e compare un messaggio di errore
                                ListFile.Visible = False
                                hlDErrori.Visible = False
                                hlRErrori.Visible = False
                                hlRicevuta.Visible = False
                                Elimina.Visible = False
                                myError.Text = "Errore. Impossibile visualizzare l'attività."
                            End If
                        End If
                    Catch ex As Exception
                        'In caso di errore nell'esecuzione del codice,
                        'gli oggetti della pagina vengono resi non visibili
                        'e compare un messaggio di errore
                        ListFile.Visible = False
                        hlDErrori.Visible = False
                        hlRErrori.Visible = False
                        hlRicevuta.Visible = False
                        Elimina.Visible = False
                        myError.Text = "Errore. Impossibile visualizzare l'attività."
                    End Try
                Else
                    'Gli oggetti della pagina vengono resi non visibili
                    'e compare un messaggio di errore
                    ListFile.Visible = False
                    hlDErrori.Visible = False
                    hlRErrori.Visible = False
                    hlRicevuta.Visible = False
                    Elimina.Visible = False
                    myError.Text = "Errore. Impossibile visualizzare l'attività."
                End If
            End If
            dt = Nothing
            wact = Nothing
        End Sub

    Private Sub EliminaN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EliminaN.Click
        Risposta.Visible = False
        EliminaY.Visible = False
        EliminaN.Visible = False
    End Sub

    Private Sub EliminaY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EliminaY.Click
        'Creazione nuovo oggetto Activity per eliminare l'attività
        Dim delwact As New Activity
        Try
            'Se il codice dell'attività è valido
            If Trim(lAtt.Text) <> "" Then
                'Se l'operazione dei eliminazione è andata a termine correttamente
                If delwact.DeleteActivity(Val(lAtt.Text)) Then
                    'Viene richiamata la pagina cactivity
                    delwact = Nothing
                    Response.Redirect("cactivity.aspx?d=s&a=" & Val(lAtt.Text))
                Else
                    delwact = Nothing
                    myError.Text = "Errore. Impossibile eliminare l'attività."
                End If
                delwact = Nothing
            End If
        Catch ex As Exception
            'Gli oggetti della pagina vengono resi non visibili
            'e compare un messaggio di errore
            ListFile.Visible = False
            hlDErrori.Visible = False
            hlRErrori.Visible = False
            hlRicevuta.Visible = False
            Elimina.Visible = False
            Risposta.Visible = False
            EliminaY.Visible = False
            EliminaN.Visible = False
            myError.Text = "Errore. Fallito tentativo di eliminare l'attività."
            delwact = Nothing
        End Try

    End Sub

    Private Sub Elimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Elimina.Click
        Risposta.Visible = True
        EliminaY.Visible = True
        EliminaN.Visible = True
    End Sub
End Class

End Namespace
