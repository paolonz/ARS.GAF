Imports System.Web.Security


Namespace arsflussi

Partial Class Login
    Inherits System.Web.UI.Page

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
        End Sub

    Private Sub LoginBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginBtn.Click
        Dim vPwd As Boolean = False
        'Se la pagina risulta valida(i campi sono validi)
        If Page.IsValid = True Then
            Try
                'Istanzia un nuovo oggetto referente
                Dim accountSystem As Referente = New Referente
                'Viene richiamata la funzione di Login passando la password criptata
                Dim customerId As Integer = accountSystem.Login(email.Text, Security.Encrypt(password.Text), vPwd)
                'Se l'utente viene validato
                If customerId > 0 Then
                    'Lettura degli attributi
                    Dim ReferenteDetails As ReferenteDetails = accountSystem.GetReferenteDetails(customerId)
                    'Creazione cookie per la memorizzazione del nome del referente
                    Response.Cookies("ImportFlussi_FullName").Value = ReferenteDetails.FullName
                    'Se il check box per la memorizzazione del login è vero
                    If RememberLogin.Checked = True Then
                        'La data di scadenza del login viene incrementata di un mese
                        Response.Cookies("ImportFlussi_FullName").Expires = DateTime.Now.AddMonths(1)
                    End If
                    'Se la password deve essere modificata
                    If vPwd Then
                        FormsAuthentication.RedirectFromLoginPage(CStr(customerId), RememberLogin.Checked)
                        'Apertura pagina di modifica del profilo utente
                        Response.Redirect("Register.aspx?cp=y")
                    Else
                        'Apertura della pagina iniziale
                        FormsAuthentication.RedirectFromLoginPage(CStr(customerId), RememberLogin.Checked)
                        Response.Redirect("Welcome.aspx")
                    End If

                    ReferenteDetails = Nothing
                Else
                    If customerId = 0 Then
                        Message.Text = "Login fallito!"
                    Else
                        Message.Text = "Utente scaduto, contattare l'amministratore di sistema per l'abilitazione."
                    End If
                End If
                accountSystem = Nothing
            Catch ex As Exception
                Message.Text = "Login fallito!"
            End Try
        End If
    End Sub

End Class

End Namespace
