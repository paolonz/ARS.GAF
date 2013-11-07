Namespace arsflussi

Partial Class checkflussi
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
            Dim ruoli() As Integer = {0}
            InitializeUser(Session("TOKEN").ToString())
            Dim op As OperationResult
            op = CheckCohesion(Session("TOKEN").ToString(), ruoli)

            If Not op.Success Then
                MyError.Text = op.Message
                Return
            End If

            Try
                'Rilevazione utente
                If ROLE = 2 Then
                    Dim activity As New Activity
                    wds = activity.CheckActivity()
                    'Al primo caricamento della pagina
                    If Page.IsPostBack = False Then
                        Flusso.DataSource = wds
                        Flusso.DataMember = "T_Flussi"
                        Flusso.DataValueField = "progrflusso"
                        Flusso.DataTextField = "flusso"
                        Flusso.DataBind()

                    End If
                Else
                    MyError.Text = "Utente non abilitato a consultare la pagina."
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

            Dim wact As New Activity

            wds = wact.CheckActivity()        

            'Popolamento del campo Periodo
            Dim dv As DataView
            dv = New DataView
            dv.Table = wds.Tables("T_Periodi")
            dv.RowFilter = "progrflusso = " & Flusso.SelectedItem.Value

            Periodo.DataSource = dv
            Periodo.DataValueField = "anno"
            Periodo.DataTextField = "anno"
            Periodo.DataBind()
        Catch ex As Exception
            'In caso di errore nella pagina viene visualizzato un messaggio nel campo
            'MyError e il data grid viene reso non visibile
            MyError.Text = ex.Message & ". Per iniziare di nuovo, fare clic sul Menù alla voce 'Visualizza attività'."
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
        Listatt.CurrentPageIndex = 0
        Listatt.Visible = False
    End Sub

    Private Sub linkperiodosucc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkperiodosucc.Click
        ShowAttivit()
    End Sub

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
        wds = Nothing
    End Sub
    Private Sub ShowAttivit()
        Try
            'Creazione oggetti della pagina e relativi attributi, validi per l'utente
            'che utilizza l'applicazione
            Dim wact As New Activity
            wds = wact.CheckActivity()

            Dim dv As DataView
            dv = New DataView
            dv.Table = wds.Tables("T_Dati")
            dv.RowFilter = "progrflusso = " & Flusso.SelectedItem.Value & " AND anno = " & Periodo.SelectedItem.Value

            Listatt.DataSource = dv
            Listatt.DataBind()
            If Listatt.Items.Count > 0 Then
                Message.Text = ""
                Listatt.Visible = True
            Else
                Listatt.Visible = False
                Message.Text = "Nessun record trovato."
            End If
        Catch ex As Exception
            MyError.Text = ex.Message
            Listatt.Visible = False
        End Try
    End Sub


    Private Sub Listatt_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Listatt.PageIndexChanged
        Try
            Listatt.CurrentPageIndex = e.NewPageIndex

            ShowAttivit()

        Catch ex As Exception
            MyError.Text = ex.Message
        End Try
    End Sub


End Class

End Namespace
