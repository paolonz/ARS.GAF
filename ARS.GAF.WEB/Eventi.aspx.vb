Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace arsflussi

    Partial Class Eventi1
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

            Dim ruoli() As Integer = {2}
            InitializeUser(Session("TOKEN").ToString())
            Dim op As OperationResult
            op = CheckCohesion(Session("TOKEN").ToString(), ruoli)

            If Not op.Success Then
                MyError.Text = op.Message
                Return
            End If

            hdUserID.Value = USERID
            'Inserire qui il codice utente necessario per inizializzare la pagina
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
                        MyError.Text = op.Message
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

                Dim op As OperationResult

                op = GetPeriodoFlussi(hdUserID.Value, Flusso.SelectedItem.Value)

                If op.Success Then

                    Dim periodoflussi As List(Of PeriodoFlussi) = op.Data

                    Periodo.Visible = True
                    lblperiodo.Visible = True
                    lperiodo.Visible = False
                    linkperiodoprec.Visible = True
                    linkperiodosucc.Visible = True

                    Periodo.DataSource = periodoflussi
                    Periodo.DataValueField = "PeriodoID"
                    Periodo.DataTextField = "PeriodoDesc"
                    Periodo.DataBind()

                Else
                    MyError.Text = op.Message
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
            detailDataGrid.Visible = False
        End Sub

        Private Sub linkperiodosucc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkperiodosucc.Click
            ShowAttivit()
        End Sub
        Private Sub ShowAttivit()
            Try
                'Creazione oggetti della pagina e relativi attributi, validi per l'utente
                'che utilizza l'applicazione
                Dim op As OperationResult
                op = GetDettagliFlusso(Flusso.SelectedItem.Value, Periodo.SelectedItem.Value)

                If op.Success Then
                    Dim dt As New DataTable
                    dt = op.Data
                    detailDataGrid.DataSource = dt
                    detailDataGrid.DataBind()
                    detailDataGrid.Visible = True
                Else
                    Message.Text = op.Message
                    detailDataGrid.Visible = False
                End If
            Catch ex As Exception
                MyError.Text = ex.Message
                detailDataGrid.Visible = False
            End Try
        End Sub

        Private Sub detailDataGrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles detailDataGrid.PageIndexChanged
            Try
                detailDataGrid.CurrentPageIndex = e.NewPageIndex
                ShowAttivit()

            Catch ex As Exception
                detailDataGrid.Visible = False
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

        Private Function GetPeriodoFlussi(ByVal userID As Integer, ByVal flussoID As Integer) As OperationResult
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
            cmd.Parameters.AddWithValue("@flussoID", flussoID)

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

        Private Function GetDettagliFlusso(ByVal flussoID As Integer, ByVal periodoID As Integer) As OperationResult

            Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
            Dim strSql As String = "SELECT progrevento, progrflusso, progrperiodo, evento, cartellaftp, preffile, inv " _
                                   & "iomail, oggettomail, testomail, dataevento, ggevento, dataini, dataend, flusso, " _
                                   & "periodo FROM dbo.V_EventiFlussi where (progrflusso= @flussoID) AND (progrperiodo= @periodoID) AND (dataend is null) ORDER BY dataevento DESC"

            Dim cmd As New SqlCommand(strSql, conn)
            cmd.Parameters.AddWithValue("@flussoID", flussoID)
            cmd.Parameters.AddWithValue("@periodoID", Periodo)

            Dim op As OperationResult

            Try
                conn.Open()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                If Not dt Is Nothing And dt.Rows.Count > 0 Then
                    op = New OperationResult(True, "OK", dt)
                Else
                    op = New OperationResult(False, "Nessun record trovato!", Nothing)
                End If
            Catch ex As Exception
                op = New OperationResult(False, "Errore durante il recupero dei dati: " & ex.Message, Nothing)
            End Try

            Return op

        End Function
    End Class

End Namespace
