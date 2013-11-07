Imports System.Web.Security


Namespace arsflussi

Partial Class Register
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
    Dim accountSystem As Referente = New Referente

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Inserire qui il codice utente necessario per inizializzare la pagina
        If Page.IsPostBack = False Then
            Try
                'Rilevazione utente
                Dim customerID As Integer = Val(User.Identity.Name)
                If customerID = 85 Or customerID = 67 Or customerID = 80 Then
                    HyperLink2.Visible = True
                Else
                    HyperLink2.Visible = False
                End If
                'Selezione attributi utente
                Dim ReferenteDetails As ReferenteDetails = accountSystem.GetReferenteDetails(customerID)
                'Assegnazione variabili agli oggetti della pagina
                Name.Text = Trim(ReferenteDetails.FullName)
                Email.Text = Trim(ReferenteDetails.Email)
                Telefono.Text = Trim(ReferenteDetails.Telefono)
                Mail.Text = Trim(ReferenteDetails.Mail)
                Fax.Text = Trim(ReferenteDetails.Fax)
                oldPassword.Text = Trim(Security.Decrypt(ReferenteDetails.Password))
                'Se la password è in scadenza, l'utente viene avvisato.
                If Request.QueryString("cp") = "y" Then
                    MyError.Text = "La password sta per scadere! Giorni alla scadenza: " & (ReferenteDetails.NggPWD - DateDiff(DateInterval.Day, ReferenteDetails.Datapwd, Now()))

                End If
                ReferenteDetails = Nothing
                accountSystem = Nothing
            Catch ex As Exception
                'In caso di errore i campi vengono annullati
                accountSystem = Nothing
                Name.Text = "Errore#"
                Email.Text = "Errore#"
                Telefono.Text = "Errore#"
                Mail.Text = "Errore#"
                Fax.Text = "Errore#"
                MyError.Text = ex.Message
            End Try
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Label4.Enabled = True
            Password.Enabled = True
            Regularexpressionvalidator6.Enabled = True
            RequiredFieldValidator6.Enabled = True
            Label5.Enabled = True
            ConfirmPassword.Enabled = True
            RequiredFieldValidator7.Enabled = True
            CompareValidator1.Enabled = True
            CompareValidator2.Enabled = True
        Else
            Label4.Enabled = False
            Password.Enabled = False
            Regularexpressionvalidator6.Enabled = False
            RequiredFieldValidator6.Enabled = False
            Label5.Enabled = False
            ConfirmPassword.Enabled = False
            RequiredFieldValidator7.Enabled = False
            CompareValidator1.Enabled = False
            CompareValidator2.Enabled = False
        End If
    End Sub

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
        accountSystem = Nothing
    End Sub

    Private Sub RegisterBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterBtn.Click
        'Se gli oggetti della pagina risultano essere validi
        If Page.IsValid = True Then
            Try
                'Se il flag per la gestione della password è checked
                If CheckBox1.Checked = True Then
                    'La pwd deve essere lunga almeno 8 caratteri
                    If Len(Password.Text) >= 8 Then
                        'Se la nuova password è diversa da quella vecchia
                        If Password.Text <> oldPassword.Text Then
                            'Aggiornamento attributi e nuova password
                            MyError.Text = accountSystem.ModReferenteDetails(Val(User.Identity.Name), Name.Text, Email.Text, Telefono.Text, Mail.Text, Fax.Text, Security.Encrypt(Password.Text), True)
                            myPwd.Text = "La richiesta per il cambio della password è stata inoltrata, a breve sarà inviata via mail l'attivazione della password stessa."
                        Else
                            'Aggiornamento attributi
                            MyError.Text = accountSystem.ModReferenteDetails(Val(User.Identity.Name), Name.Text, Email.Text, Telefono.Text, Mail.Text, Fax.Text, Security.Encrypt(Password.Text), False)
                        End If
                    Else
                        MyError.Text = "La Password deve essere lunga almeno 8 caratteri"
                    End If
                Else
                    'Aggiornamento attributi
                    MyError.Text = accountSystem.ModReferenteDetails(Val(User.Identity.Name), Name.Text, Email.Text, Telefono.Text, Mail.Text, Fax.Text, Security.Encrypt(Password.Text), False)
                End If

            Catch ex As Exception
                MyError.Text = ex.Message
            End Try
        End If
    End Sub
End Class

End Namespace
