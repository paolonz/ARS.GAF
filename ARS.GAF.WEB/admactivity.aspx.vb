Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections.Generic

Namespace arsflussi

    Partial Class admactivity
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

            Dim ruoli() As Integer = {0}
            InitializeUser(Session("TOKEN").ToString())
            Dim op As OperationResult
            op = CheckCohesion(Session("TOKEN").ToString(), ruoli)

            If Not op.Success Then
                MyError.Text = op.Message
                Return
            End If

            Try
                'Creazione oggetti della pagina e relativi attributi, validi per l'utente
                'che utilizza l'applicazione
                op = GetFlussiUtente(USERID)

                If op.Success Then
                    Dim flussi As List(Of Flussi) = op.Data
                    'Popolamento del campo Flusso
                    lblFlusso.Visible = True
                    Flusso.Visible = True
                    lflusso.Visible = False
                    linkflussoprec.Visible = False
                    linkFlussosucc.Visible = True
                    Flusso.DataSource = flussi
                    Flusso.DataValueField = "ID"
                    Flusso.DataTextField = "Flusso"
                    Flusso.DataBind()
                Else
                    MyError.Text = op.Message
                End If

            Catch ex As Exception
                'In caso di errore nella pagina viene visualizzato un messaggio nel campo
                'MyError e il data grid viene reso non visibile
                MyError.Text = ex.Message
                'ListFile.Visible = False
            End Try
        End Sub

        Private Sub linkReferente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkReferente.Click
            Try
                lReferente.Text = cmbReferente.SelectedItem.Text
                lReferente.Visible = True
                cmbReferente.Visible = False
                lblFlusso.Visible = True
                Flusso.Visible = True
                lflusso.Visible = False
                linkflussoprec.Visible = True
                linkFlussosucc.Visible = True
                linkReferente.Visible = False

                Dim wact As New Activity
                wds = wact.ParamActivity(cmbReferente.SelectedItem.Value)
                Flusso.DataSource = wds
                Flusso.DataMember = "T_Flussi"
                Flusso.DataValueField = "progrflusso"
                Flusso.DataTextField = "flusso"
                Flusso.DataBind()
            Catch ex As Exception
                'In caso di errore nella pagina viene visualizzato un messaggio nel campo
                'MyError e il data grid viene reso non visibile
                MyError.Text = ex.Message & ". Per iniziare di nuovo, fare clic sul Menù alla voce 'Visualizza attività'."
            End Try
        End Sub

        Private Sub linkflussoprec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkflussoprec.Click
            cmbReferente.Visible = True
            lblReferente.Visible = True
            lReferente.Visible = False
            linkReferente.Visible = True
            lblFlusso.Visible = False
            Flusso.Visible = False
            lflusso.Visible = False
            linkFlussosucc.Visible = False
            linkflussoprec.Visible = False
        End Sub

        Private Sub linkFlussosucc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkFlussosucc.Click
            Try
                lblFlusso.Visible = True
                Flusso.Visible = False
                lflusso.Visible = True
                lflusso.Text = Flusso.SelectedItem.Text
                linkFlussosucc.Visible = False
                linkflussoprec.Visible = False

                Periodo.Visible = True
                lblperiodo.Visible = True
                lperiodo.Visible = False
                linkperiodoprec.Visible = True
                linkperiodosucc.Visible = True

                Dim customerID As Integer = Val(User.Identity.Name)
                Dim wact As New Activity

                If lblReferente.Visible = True Then
                    wds = wact.ParamActivity(cmbReferente.SelectedItem.Value)
                Else
                    wds = wact.ParamActivity(customerID)
                End If

                'Popolamento del campo Periodo
                Dim dv As DataView
                dv = New DataView
                dv.Table = wds.Tables("T_Periodi")
                dv.RowFilter = "progrflusso = " & Flusso.SelectedItem.Value

                Periodo.DataSource = dv
                Periodo.DataValueField = "progrperiodo"
                Periodo.DataTextField = "periodo"
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
            If lblReferente.Visible = True Then
                linkflussoprec.Visible = True
            Else
                linkflussoprec.Visible = False
            End If
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
                Dim customerID As Integer = Val(User.Identity.Name)
                'Creazione oggetti della pagina e relativi attributi, validi per l'utente
                'che utilizza l'applicazione
                Dim wact As New Activity
                If lblReferente.Visible = True Then
                    wds = wact.ShowActivityAdmin(cmbReferente.SelectedItem.Value, Flusso.SelectedItem.Value, Periodo.SelectedItem.Value)
                Else
                    wds = wact.ShowActivityAdmin(customerID, Flusso.SelectedItem.Value, Periodo.SelectedItem.Value)
                End If
                Listatt.DataSource = wds
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

        Private Function GetFlussiUtente(ByVal userID) As OperationResult

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

    End Class

End Namespace
