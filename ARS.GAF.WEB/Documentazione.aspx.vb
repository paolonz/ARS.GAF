Namespace arsflussi

Partial Class Documentazione1
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
            'Inserire qui il codice utente necessario per inizializzare la pagina
            Dim ruoli() As Integer = {2, 3}
            InitializeUser(Session("TOKEN").ToString())
            Dim op As OperationResult
            op = CheckCohesion(Session("TOKEN").ToString(), ruoli)

            If Not op.Success Then
                MyError.Text = op.Message
                Return
            End If

        Try
            'Rilevazione utente
            Dim customerID As Integer = Val(User.Identity.Name)
            'Creazione oggetti della pagina e relativi attributi, validi per l'utente
            'che utilizza l'applicazione
            Dim wact As New Activity
            wds = wact.ParamActivity(customerID)
            'Al primo caricamento della pagina
            If Page.IsPostBack = False Then


                'Popolamento del campo Flusso
                lblFlusso.Visible = True
                Flusso.Visible = True
                lflusso.Visible = False
                linkFlussosucc.Visible = True
                Flusso.DataSource = wds
                Flusso.DataMember = "T_Flussi"
                Flusso.DataValueField = "progrflusso"
                Flusso.DataTextField = "flusso"
                Flusso.DataBind()

            End If

        Catch ex As Exception
            'In caso di errore nella pagina viene visualizzato un messaggio nel campo
            'MyError e il data grid viene reso non visibile
            MyError.Text = ex.Message
        End Try
    End Sub

    Private Sub linkFlussosucc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkFlussosucc.Click
        Try
            lblFlusso.Visible = True
            Flusso.Visible = False
            lflusso.Visible = True
            lflusso.Text = Flusso.SelectedItem.Text
            linkFlussosucc.Visible = False

            Periodo.Visible = True
            lblperiodo.Visible = True
            lperiodo.Visible = False
            linkperiodoprec.Visible = True
            linkperiodosucc.Visible = True

            Dim wact As New Docsinfo

            wds = wact.ParamDocs

            Periodo.DataSource = wds
            Periodo.DataMember = "T_TipiDocumento"
            Periodo.DataValueField = "progrtipodoc"
            Periodo.DataTextField = "tipodocumento"
            Periodo.DataBind()
        Catch ex As Exception
            'In caso di errore nella pagina viene visualizzato un messaggio nel campo
            'MyError e il data grid viene reso non visibile
            MyError.Text = ex.Message & ". Per iniziare di nuovo, fare clic sul Menù alla voce 'Documentazione'."
        End Try
            
    End Sub

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
        wds = Nothing
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
        detailDataGrid.Visible = False
    End Sub

    Private Sub linkperiodosucc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkperiodosucc.Click
        ShowAttivit()
    End Sub
    Private Sub ShowAttivit()
        Try
            'Creazione oggetti della pagina e relativi attributi, validi per l'utente
            'che utilizza l'applicazione
            Dim wact As New Docsinfo

            wds = wact.GetDocsDetails(Flusso.SelectedItem.Value, Periodo.SelectedItem.Value)
            detailDataGrid.DataSource = wds
            detailDataGrid.DataMember = "T_Docs"
            detailDataGrid.DataBind()
            If detailDataGrid.Items.Count > 0 Then
                Message.Text = ""
                detailDataGrid.Visible = True
            Else
                detailDataGrid.Visible = False
                Message.Text = "Nessun record trovato."
            End If
        Catch ex As Exception
            MyError.Text = ex.Message
            detailDataGrid.Visible = False
        End Try
    End Sub


    Private Sub detailDataGrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles detailDataGrid.PageIndexChanged
        Try
            detailDataGrid.CurrentPageIndex = e.NewPageIndex
            ShowAttivit

        Catch ex As Exception
            detailDataGrid.Visible = False
        End Try
    End Sub
End Class

End Namespace
