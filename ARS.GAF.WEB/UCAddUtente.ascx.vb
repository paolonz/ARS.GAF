Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient

Namespace arsflussi
    Partial Class AggiungiUtente
        Inherits System.Web.UI.UserControl

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

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

            Dim op As OperationResult
            op = GetRuoli()

            If op.Success Then
                Dim roles As New List(Of KeyValuePair(Of Integer, String))
                roles = op.Data

                ddlRuolo.DataSource = roles
                ddlRuolo.DataValueField = "ID"
                ddlRuolo.DataTextField = "Descrizione"
                ddlRuolo.DataBind()
            Else
                lblResult.Text = op.Message
                btnSalva.Enabled = False
            End If

        End Sub

        Private Function GetRuoli() As OperationResult

            Dim op As OperationResult

            Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
            Dim strSql As String = "SELECT ID, Descrizione FROM Ruoli"

            Dim cmd As New SqlCommand(strSql, conn)

            Dim result As New List(Of KeyValuePair(Of Integer, String))

            Try
                conn.Open()
                Dim reader As SqlDataReader
                reader = cmd.ExecuteReader()

                While reader.Read
                    Dim role As New KeyValuePair(Of Integer, String)(reader("ID"), reader("Descrizione"))
                    result.Add(role)
                End While

                If result Is Nothing Or result.Count = 0 Then
                    op = New OperationResult(False, "Nessun Ruolo Trovato!", Nothing)
                Else
                    op = New OperationResult(True, "OK", result)
                End If

            Catch ex As Exception
                op = New OperationResult(False, "Errore durante il recupero dei dati: " & ex.Message, Nothing)
            Finally
                conn.Close()
            End Try

            Return op
        End Function

        Protected Sub btnSalva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalva.Click

            Dim op As OperationResult

            If String.IsNullOrEmpty(hdnUserID.Value) Then
                ' Aggiunta di un nuovo utente

                Dim valid As Boolean = True
                Dim message As String = String.Empty
                ' Validazione Form
                If String.IsNullOrEmpty(txtNome.Text) Then
                    valid = False
                    message = message & "- Nome obbligatorio!" & vbCrLf
                End If
                If String.IsNullOrEmpty(txtCognome.Text) Then
                    valid = False
                    message = message & "- Cognome obbligatorio!" & vbCrLf
                End If
                If String.IsNullOrEmpty(txtCF.Text) Then
                    valid = False
                    message = message & "- Codice Fiscale obbligatorio!" & vbCrLf
                End If
                If String.IsNullOrEmpty(txtEmail.Text) Then
                    valid = False
                    message = message & "- Email obbligatoria!" & vbCrLf
                End If
                If String.IsNullOrEmpty(txtFax.Text) Then
                    valid = False
                    message = message & "- Fax obbligatorio!" & vbCrLf
                End If
                If String.IsNullOrEmpty(txtNumero.Text) Then
                    valid = False
                    message = message & "- Numero obbligatorio!" & vbCrLf
                End If
                If String.IsNullOrEmpty(txtCartella.Text) Then
                    valid = False
                    message = message & "- Percorso cartella obbligatorio!" & vbCrLf
                End If
                If String.IsNullOrEmpty(txtCartellaFTP.Text) Then
                    valid = False
                    message = message & "- Percorso cartella FTP obbligatorio!" & vbCrLf
                End If
                If String.IsNullOrEmpty(txtPercorsoUtente.Text) Then
                    valid = False
                    message = message & "- Percorso Utente obbligatorio!"
                End If

                If Not valid Then
                    lblResult.Text = message
                Else
                    Dim data As String = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}", txtNome.Text, _
                                                       txtCognome.Text, txtCF.Text, txtEmail.Text, txtFax.Text, _
                                                       txtNumero.Text, txtCartella.Text, txtCartellaFTP.Text, _
                                                       txtPercorsoUtente.Text, ddlRuolo.SelectedValue, chkAttivo.Checked)
                    op = New OperationResult(True, "OK", data)
                    op = AddUser(op)

                    If op.Success Then
                        lblResult.Text = op.Message
                        PulisciForm()
                    Else
                        lblResult.Text = op.Message
                    End If

                End If

            Else
                ' Update dell'utente esistente
            End If
        End Sub

        Private Function AddUser(ByVal data As OperationResult) As OperationResult

            Dim op As OperationResult

            Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
            Dim strSql As String = "INSERT INTO Utenti " & _
                "(Nome, Cognome, CodiceFiscale, Email, Fax, Numero, Cartella, CartellaFTP, PercorsoUtente, CodiceRuolo, Attivo) " & _
                "VALUES (@nome, @cognome, @cf, @email, @fax, @numero, @cartella, @ftp, @percorsoUser, @ruolo, @attivo)"

            Dim par As String() = data.Data.ToString().Split("|")

            Dim cmd As New SqlCommand(strSql, conn)
            cmd.Parameters.AddWithValue("@nome", par(0))
            cmd.Parameters.AddWithValue("@cognome", par(1))
            cmd.Parameters.AddWithValue("@cf", par(2))
            cmd.Parameters.AddWithValue("@email", par(3))
            cmd.Parameters.AddWithValue("@fax", par(4))
            cmd.Parameters.AddWithValue("@numero", par(5))
            cmd.Parameters.AddWithValue("@cartella", par(6))
            cmd.Parameters.AddWithValue("@ftp", par(7))
            cmd.Parameters.AddWithValue("@percorsoUser", par(8))
            cmd.Parameters.AddWithValue("@ruolo", Integer.Parse(par(9)))
            cmd.Parameters.AddWithValue("@attivo", Boolean.Parse(par(10)))

            Try
                conn.Open()
                cmd.ExecuteNonQuery()

                op = New OperationResult(True, "Utente inserito con successo!", Nothing)

            Catch ex As Exception
                op = New OperationResult(False, "Errore durante la creazione dell'utente: " & ex.Message, Nothing)
            Finally
                conn.Close()
            End Try

            Return op
        End Function

        Private Sub PulisciForm()

            txtNome.Text = String.Empty
            txtCognome.Text = String.Empty
            txtCF.Text = String.Empty
            txtEmail.Text = String.Empty
            txtFax.Text = String.Empty
            txtNumero.Text = String.Empty
            txtCartella.Text = String.Empty
            txtCartellaFTP.Text = String.Empty
            txtPercorsoUtente.Text = String.Empty
            ddlRuolo.SelectedIndex = 0
            chkAttivo.Checked = False

        End Sub

    End Class
End Namespace