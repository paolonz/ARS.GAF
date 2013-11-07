Imports System.Data.SqlClient

Namespace arsflussi

    Partial Class Contatti
        Inherits BasePage

#Region " Codice generato da Progettazione Web Form "

        'Chiamata richiesta da Progettazione Web Form.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand
            Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection
            Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand
            Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand
            Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand
            Me.OleDbSelectCommand2 = New System.Data.OleDb.OleDbCommand
            Me.OleDbInsertCommand2 = New System.Data.OleDb.OleDbCommand
            Me.OleDbDataAdapter1 = New System.Data.OleDb.OleDbDataAdapter
            Me.OleDbDataAdapter2 = New System.Data.OleDb.OleDbDataAdapter
            Me.objGestoriFlussi = New arsflussi.GestoriFlussi
            CType(Me.objGestoriFlussi, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'OleDbSelectCommand1
            '
            Me.OleDbSelectCommand1.CommandText = "SELECT progrgestore, gestore, telefono, fax, email, dataini, dataend FROM dbo.T_G" & _
            "estori where (dataend is null)"
            Me.OleDbSelectCommand1.Connection = Me.OleDbConnection1
            '
            'OleDbConnection1
            '
            Me.OleDbConnection1.ConnectionString = "User ID=userflussi;Password=flussi;Data Source=localhost;Tag with column collatio" & _
            "n when possible=False;Initial Catalog=GAF;Use Procedure for Prepare=1;Auto Trans" & _
            "late=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=ARSSE" & _
            "RVER2;Use Encryption for Data=False;Packet Size=4096"
            '
            'OleDbInsertCommand1
            '
            Me.OleDbInsertCommand1.CommandText = "INSERT INTO dbo.T_Gestori(progrgestore, gestore, telefono, fax, email, dataini, d" & _
            "ataend) VALUES (?, ?, ?, ?, ?, ?, ?); SELECT progrgestore, gestore, telefono, fa" & _
            "x, email, dataini, dataend FROM dbo.T_Gestori WHERE (progrgestore = ?)"
            Me.OleDbInsertCommand1.Connection = Me.OleDbConnection1
            Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("progrgestore", System.Data.OleDb.OleDbType.Integer, 4, "progrgestore"))
            Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("gestore", System.Data.OleDb.OleDbType.VarChar, 150, "gestore"))
            Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("telefono", System.Data.OleDb.OleDbType.VarChar, 50, "telefono"))
            Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("fax", System.Data.OleDb.OleDbType.VarChar, 50, "fax"))
            Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("email", System.Data.OleDb.OleDbType.VarChar, 150, "email"))
            Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("dataini", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "dataini"))
            Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("dataend", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "dataend"))
            Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Select_progrgestore", System.Data.OleDb.OleDbType.Integer, 4, "progrgestore"))
            '
            'OleDbUpdateCommand1
            '
            Me.OleDbUpdateCommand1.CommandText = "UPDATE dbo.T_Gestori SET progrgestore = ?, gestore = ?, telefono = ?, fax = ?, em" & _
            "ail = ?, dataini = ?, dataend = ? WHERE (progrgestore = ?) AND (dataend = ? OR ?" & _
            " IS NULL AND dataend IS NULL) AND (dataini = ? OR ? IS NULL AND dataini IS NULL)" & _
            " AND (email = ? OR ? IS NULL AND email IS NULL) AND (fax = ? OR ? IS NULL AND fa" & _
            "x IS NULL) AND (gestore = ? OR ? IS NULL AND gestore IS NULL) AND (telefono = ? " & _
            "OR ? IS NULL AND telefono IS NULL); SELECT progrgestore, gestore, telefono, fax," & _
            " email, dataini, dataend FROM dbo.T_Gestori WHERE (progrgestore = ?)"
            Me.OleDbUpdateCommand1.Connection = Me.OleDbConnection1
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("progrgestore", System.Data.OleDb.OleDbType.Integer, 4, "progrgestore"))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("gestore", System.Data.OleDb.OleDbType.VarChar, 150, "gestore"))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("telefono", System.Data.OleDb.OleDbType.VarChar, 50, "telefono"))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("fax", System.Data.OleDb.OleDbType.VarChar, 50, "fax"))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("email", System.Data.OleDb.OleDbType.VarChar, 150, "email"))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("dataini", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "dataini"))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("dataend", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "dataend"))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_progrgestore", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "progrgestore", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_dataend", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dataend", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_dataend1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dataend", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_dataini", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dataini", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_dataini1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dataini", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_email", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "email", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_email1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "email", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_fax", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "fax", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_fax1", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "fax", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_gestore", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "gestore", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_gestore1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "gestore", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_telefono", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "telefono", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_telefono1", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "telefono", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Select_progrgestore", System.Data.OleDb.OleDbType.Integer, 4, "progrgestore"))
            '
            'OleDbDeleteCommand1
            '
            Me.OleDbDeleteCommand1.CommandText = "DELETE FROM dbo.T_Gestori WHERE (progrgestore = ?) AND (dataend = ? OR ? IS NULL " & _
            "AND dataend IS NULL) AND (dataini = ? OR ? IS NULL AND dataini IS NULL) AND (ema" & _
            "il = ? OR ? IS NULL AND email IS NULL) AND (fax = ? OR ? IS NULL AND fax IS NULL" & _
            ") AND (gestore = ? OR ? IS NULL AND gestore IS NULL) AND (telefono = ? OR ? IS N" & _
            "ULL AND telefono IS NULL)"
            Me.OleDbDeleteCommand1.Connection = Me.OleDbConnection1
            Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_progrgestore", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "progrgestore", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_dataend", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dataend", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_dataend1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dataend", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_dataini", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dataini", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_dataini1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dataini", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_email", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "email", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_email1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "email", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_fax", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "fax", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_fax1", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "fax", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_gestore", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "gestore", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_gestore1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "gestore", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_telefono", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "telefono", System.Data.DataRowVersion.Original, Nothing))
            Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_telefono1", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "telefono", System.Data.DataRowVersion.Original, Nothing))
            '
            'OleDbSelectCommand2
            '
            Me.OleDbSelectCommand2.CommandText = "SELECT progrgesflussi, progrgestore, progrflusso, flusso, gestore FROM dbo.V_Gest" & _
            "oriFlussi"
            Me.OleDbSelectCommand2.Connection = Me.OleDbConnection1
            '
            'OleDbInsertCommand2
            '
            Me.OleDbInsertCommand2.CommandText = "INSERT INTO dbo.V_GestoriFlussi(progrgestore, progrflusso, flusso, gestore) VALUE" & _
            "S (?, ?, ?, ?); SELECT progrgesflussi, progrgestore, progrflusso, flusso, gestor" & _
            "e FROM dbo.V_GestoriFlussi"
            Me.OleDbInsertCommand2.Connection = Me.OleDbConnection1
            Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("progrgestore", System.Data.OleDb.OleDbType.Integer, 4, "progrgestore"))
            Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("progrflusso", System.Data.OleDb.OleDbType.Integer, 4, "progrflusso"))
            Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("flusso", System.Data.OleDb.OleDbType.VarChar, 150, "flusso"))
            Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("gestore", System.Data.OleDb.OleDbType.VarChar, 150, "gestore"))
            '
            'OleDbDataAdapter1
            '
            Me.OleDbDataAdapter1.DeleteCommand = Me.OleDbDeleteCommand1
            Me.OleDbDataAdapter1.InsertCommand = Me.OleDbInsertCommand1
            Me.OleDbDataAdapter1.SelectCommand = Me.OleDbSelectCommand1
            Me.OleDbDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_Gestori", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("progrgestore", "progrgestore"), New System.Data.Common.DataColumnMapping("gestore", "gestore"), New System.Data.Common.DataColumnMapping("telefono", "telefono"), New System.Data.Common.DataColumnMapping("fax", "fax"), New System.Data.Common.DataColumnMapping("email", "email"), New System.Data.Common.DataColumnMapping("dataini", "dataini"), New System.Data.Common.DataColumnMapping("dataend", "dataend")})})
            Me.OleDbDataAdapter1.UpdateCommand = Me.OleDbUpdateCommand1
            '
            'OleDbDataAdapter2
            '
            Me.OleDbDataAdapter2.InsertCommand = Me.OleDbInsertCommand2
            Me.OleDbDataAdapter2.SelectCommand = Me.OleDbSelectCommand2
            Me.OleDbDataAdapter2.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "V_GestoriFlussi", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("progrgesflussi", "progrgesflussi"), New System.Data.Common.DataColumnMapping("progrgestore", "progrgestore"), New System.Data.Common.DataColumnMapping("progrflusso", "progrflusso"), New System.Data.Common.DataColumnMapping("flusso", "flusso"), New System.Data.Common.DataColumnMapping("gestore", "gestore")})})
            '
            'objGestoriFlussi
            '
            Me.objGestoriFlussi.DataSetName = "GestoriFlussi"
            Me.objGestoriFlussi.Locale = New System.Globalization.CultureInfo("it-IT")
            CType(Me.objGestoriFlussi, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Protected WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
        Protected WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
        Protected WithEvents OleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
        Protected WithEvents OleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
        Protected WithEvents OleDbSelectCommand2 As System.Data.OleDb.OleDbCommand
        Protected WithEvents OleDbInsertCommand2 As System.Data.OleDb.OleDbCommand
        Protected WithEvents OleDbConnection1 As System.Data.OleDb.OleDbConnection
        Protected WithEvents OleDbDataAdapter1 As System.Data.OleDb.OleDbDataAdapter
        Protected WithEvents OleDbDataAdapter2 As System.Data.OleDb.OleDbDataAdapter
        Protected WithEvents objGestoriFlussi As arsflussi.GestoriFlussi

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
                Message.Text = op.Message
                Return
            End If

            'Inserire qui il codice utente necessario per inizializzare la pagina
            If Page.IsPostBack = False Then
                Try
                    Me.LoadDataSet()
                    Me.masterDataGrid.SelectedIndex = -1
                    Me.masterDataGrid.DataBind()
                    Me.detailDataGrid.Visible = False
                    Dim sw As System.IO.StringWriter = New System.IO.StringWriter
                    Me.objGestoriFlussi.WriteXml(sw)
                    Me.ViewState("objGestoriFlussi") = sw.ToString
                Catch eLoad As System.Exception
                    Me.Response.Write(eLoad.Message)
                End Try
            End If
        End Sub

        Private Sub ShowDetailGrid()
            If (Me.masterDataGrid.SelectedIndex <> -1) Then
                Dim parentRows As System.Data.DataView
                Dim childRows As System.Data.DataView
                Dim currentParentRow As System.Data.DataRowView
                Dim sr As System.IO.StringReader = New System.IO.StringReader(CType(Me.ViewState("objGestoriFlussi"), String))
                Me.objGestoriFlussi.ReadXml(sr)
                parentRows = New DataView
                parentRows.Table = Me.objGestoriFlussi.Tables("T_Gestori")
                currentParentRow = parentRows(Me.masterDataGrid.SelectedIndex + (masterDataGrid.CurrentPageIndex * 5))
                childRows = currentParentRow.CreateChildView("GestoriFlussi")
                Me.detailDataGrid.DataSource = childRows
                Me.detailDataGrid.DataBind()
                If childRows.Count > 0 Then
                    Me.detailDataGrid.Visible = True
                    Message.Text = ""
                Else
                    Me.detailDataGrid.Visible = False
                    Message.Text = "Nessun record trovato."
                End If

            Else
                Me.detailDataGrid.Visible = False
            End If

        End Sub
        Private Sub masterDataGrid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles masterDataGrid.SelectedIndexChanged
            Me.ShowDetailGrid()

        End Sub

        Private Function GetUtentiReferenti() As OperationResult

            Dim op As OperationResult
            Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
            Dim strSql As String = "SELECT ID, Nome + ' ' + Cognome AS Referente, Numero, Fax, Email " _
                                   & "FROM Utenti WHERE CodiceRuolo = 2"
            Dim cmd As New SqlCommand(strSql, conn)

            Try
                conn.Open()

                Dim dt As New DataTable()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                op = New OperationResult(True, "OK", dt)

            Catch ex As Exception
                op = New OperationResult(False, "Errore durante il recupero dei dati: " & ex.Message, Nothing)
            Finally
                conn.Close()
            End Try

            Return op
        End Function


        Public Sub LoadDataSet()
            'Crea un nuovo dataset per i record restituiti dalla chiamata a FillDataSet.
            'Viene utilizzato un dataset temporaneo perché il riempimento del dataset esistente potrebbe
            'richiedere la riassociazione delle associazioni dati.
            Dim objDataSetTemp As arsflussi.GestoriFlussi
            objDataSetTemp = New arsflussi.GestoriFlussi
            Try
                'Tenta di riempire il dataset temporaneo.
                Me.FillDataSet(objDataSetTemp)
            Catch eFillDataSet As System.Exception
                'Aggiungere qui il codice per la gestione degli errori.
                Throw eFillDataSet
            End Try
            Try
                'Rimuove i vecchi record dal dataset.
                objGestoriFlussi.Clear()
                'Unisce i record al dataset principale.
                objGestoriFlussi.Merge(objDataSetTemp)
            Catch eLoadMerge As System.Exception
                'Aggiungere qui il codice per la gestione degli errori.
                Throw eLoadMerge
            End Try

        End Sub
        Public Sub FillDataSet(ByVal dataSet As arsflussi.GestoriFlussi)
            'Disattiva la verifica dei vincoli prima del riempimento del dataset.
            'Consente agli adattatori di riempire il dataset senza difficoltà
            'per dipendenze tra le tabelle
            dataSet.EnforceConstraints = False
            Try
                'Apri la connessione.
                Me.OleDbConnection1.Open()
                'Tenta di riempire il dataset tramite OleDbDataAdapter1.
                Me.OleDbDataAdapter1.Fill(dataSet)
                Me.OleDbDataAdapter2.Fill(dataSet)
            Catch fillException As System.Exception
                'Aggiungere qui il codice per la gestione degli errori.
                Throw fillException
            Finally
                'Riattivare la verifica dei vincoli.
                dataSet.EnforceConstraints = True
                'Chiudi la connessione indipendentemente dalla generazione dell'eccezione.
                Me.OleDbConnection1.Close()
            End Try

        End Sub

        Private Sub masterDataGrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles masterDataGrid.PageIndexChanged
            Try
                Me.LoadDataSet()
                masterDataGrid.CurrentPageIndex = e.NewPageIndex
                Me.masterDataGrid.SelectedIndex = -1
                Me.masterDataGrid.DataBind()
                Me.detailDataGrid.Visible = False

            Catch ex As Exception
                masterDataGrid.Visible = False
            End Try
        End Sub
    End Class

End Namespace
