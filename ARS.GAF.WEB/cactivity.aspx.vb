Namespace arsflussi

Partial Class cactivity
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
                Check.Text = op.Message
                Return
            End If

            'Inserire qui il codice utente necessario per inizializzare la pagina
            If Page.IsPostBack = False Then
                'Se il valore che proviene dalla pagina di inserimento delle attività è valido,
                ' allora viene visulaizzato un messaggio di conferma, con il codice 
                'dell'attività inserita.
                If Request.QueryString("d") <> "" Then
                    If Request.QueryString("a") > 0 Then
                        Check.Text = "Attività n. " & Request.QueryString("a") & " correttamente eliminata."
                    Else
                        Check.Text = "Nessuna attività eliminata."
                    End If
                Else
                    If Request.QueryString("a") > 0 Then
                        Check.Text = "Attività n. " & Request.QueryString("a") & " correttamente inserita."
                    Else
                        Check.Text = "Nessuna attività inserita."
                    End If
                End If

            End If
        End Sub

End Class

End Namespace
