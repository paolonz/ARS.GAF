Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace arsflussi

    Partial Class sactivity
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


            hdUserID.Value = USERID
            Try
                'Al primo caricamento della pagina
                If Not Page.IsPostBack Then
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
                        Message.Text = op.Message
                    End If
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

                'Popolamento della dropdown Periodo
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
                    Message.Text = op.Message
                End If

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
                Dim activity As New Activity
                wds = activity.ShowActivity(hdUserID.Value, Flusso.SelectedItem.Value, Periodo.SelectedItem.Value)

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

        Private Sub Listatt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Listatt.SelectedIndexChanged
            Try
                'Apertura della pagina dettaglio attività(dactivity) con il filtro sul
                'codice dell'attività memorizzato nell'etichetta lcodiceattivita
                Dim natt As Label = CType(Listatt.Items(Listatt.SelectedIndex).FindControl("lcodiceattivita"), Label)
                Response.Redirect("dactivity.aspx?a=" & Val(natt.Text))
            Catch ex As Exception
                'In caso di errore nella pagina viene visualizzato un messaggio nel campo
                'MyError e il data grid viene reso non visibile
                MyError.Text = ex.Message
                Listatt.Visible = False
            End Try

        End Sub

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

    End Class

End Namespace
