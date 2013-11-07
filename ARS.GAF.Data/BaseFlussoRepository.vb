Imports ARS.GAF.Core
Imports System.Data.SqlClient

Public Class BaseFlussoRepository

    Sub New(ByVal dbConfig As DBConfig, ByVal starterConfig As StarterConfig)
        Me.DBConfig = dbConfig
        Me.StarterConfig = starterConfig
    End Sub

    Private _DbConfig As DBConfig
    Public Property DBConfig() As DBConfig
        Get
            Return _DbConfig
        End Get
        Set(ByVal value As DBConfig)
            _DbConfig = value
        End Set
    End Property

    Private _starterConfig As StarterConfig
    Public Property StarterConfig() As StarterConfig
        Get
            Return _starterConfig
        End Get
        Set(ByVal value As StarterConfig)
            _starterConfig = value
        End Set
    End Property

    Public ReadOnly Property ConnectionString() As String
        Get
            Return String.Format("data source={0};initial catalog={1};user id={2};password={3}", DBConfig.Server, DBConfig.Nome, DBConfig.Utente, DBConfig.Password)
        End Get
    End Property

    Overridable Function InserisciXML(ByVal file As Core.File) As Boolean
        Dim result As Boolean = True
        Dim conn As New SqlConnection()
        conn.ConnectionString = Me.ConnectionString
        Dim tsql As SqlTransaction

        Try
            conn.Open()
            tsql = conn.BeginTransaction()
            Dim cmd = New SqlCommand()
            cmd.Connection = conn
            cmd.CommandText = String.Format("exec {0} '{1}', '{2}'", Trim(file.TabDestinazione), System.IO.Path.Combine(StarterConfig.FtpFolderPath, Trim(file.FileSalvato)), file.Namespace)
            cmd.Transaction = tsql
            cmd.ExecuteNonQuery()

            tsql.Commit()

            'If (attivita.ProgressivoTrasmissione = 1) Then
            'System.IO.File.Delete(Trim(attivita.NomeFile))
            'End If

        Catch ex As Exception
            If (Not tsql Is Nothing) Then
                tsql.Rollback()
            End If
            result = False
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
        End Try
        Return result
    End Function

    Overridable Function InserisciRecord(ByVal file As Core.File) As Boolean
        Dim result = True
        Dim conn As New SqlConnection()
        conn.ConnectionString = Me.ConnectionString
        Dim tsql As SqlTransaction
        Try

            conn.Open()
            tsql = conn.BeginTransaction()
            Dim cmd As New SqlCommand()
            cmd.Connection = conn
            cmd.CommandText = String.Format("truncate table {0}", file.TabDestinazione)
            cmd.Transaction = tsql
            cmd.ExecuteNonQuery()

            Dim proc As New Process()
            proc.StartInfo.FileName = "bcp"
            proc.StartInfo.Arguments = String.Format("{0}..{1} in {2} -f {3} -S {4} -U {5} -P {6}", DBConfig.Nome, Trim(file.TabDestinazione), Trim(file.NomeFile), file.TracciatoFile, DBConfig.Server, DBConfig.Utente, DBConfig.Password)

            proc.Start()
            proc.WaitForExit()
            proc.Close()

            If (file.ProgressivoTrasmissione = 1) Then
                System.IO.File.Delete(Trim(file.NomeFile))
            End If

            tsql.Commit()

        Catch ex As Exception
            If (Not tsql Is Nothing) Then
                tsql.Rollback()
            End If
            result = False
        Finally
            If (conn.State = System.Data.ConnectionState.Open) Then
                conn.Close()
            End If
        End Try
        Return result
    End Function

    Overridable Function Importa(ByVal attivita As Attivita, ByVal controllo As Controllo)
        Dim result As Boolean = True
        Dim strConn As String = Me.ConnectionString
        Dim conn As New SqlConnection()
        conn.ConnectionString = strConn

        Try
            conn.Open()

            Dim cmd As New SqlCommand("sp_controllaflusso", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim parIdAttivita As New SqlParameter("@ID_Attivita", attivita.Codice)
            parIdAttivita.Direction = ParameterDirection.Input
            cmd.Parameters.Add(parIdAttivita)

            Dim parIdFlusso As New SqlParameter("@ID_Flusso", Controllo.Flusso.ID)
            parIdFlusso.Direction = ParameterDirection.Input
            cmd.Parameters.Add(parIdFlusso)

            Dim parIdPeriodo As New SqlParameter("@ID_Periodo", Controllo.Periodo.ID)
            parIdPeriodo.Direction = ParameterDirection.Input
            cmd.Parameters.Add(parIdPeriodo)

            Dim parResult As New SqlParameter("@result", SqlDbType.Int)
            parResult.Direction = ParameterDirection.Output
            cmd.Parameters.Add(parResult)

            Dim parMessage As New SqlParameter("@message", SqlDbType.NVarChar)
            parMessage.Direction = ParameterDirection.Output
            parMessage.Size = 100
            cmd.Parameters.Add(parMessage)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            result = False
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
        End Try

        Return result
    End Function

    Overridable Function Accoda(ByVal progressivoTrasmissione, ByVal codicePeriodo) As Boolean
        Dim result As Boolean = True
        Dim conn As New SqlConnection(Me.ConnectionString)
        Dim tsql As SqlTransaction = Nothing
        Try
            conn.Open()
            tsql = conn.BeginTransaction()
            Dim cmd = New SqlCommand()
            cmd.CommandText = String.Format("execute sp_crea_accodamento {0}, {1}", progressivoTrasmissione, codicePeriodo)
            cmd.Transaction = tsql
            cmd.ExecuteNonQuery()

            tsql.Commit()
        Catch ex As Exception
            If (Not tsql Is Nothing) Then
                tsql.Rollback()
            End If
            result = False
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
        End Try
        Return result
    End Function

    Overridable Function NormalizzaErrori() As Boolean
        Dim result = True
        Dim conn As New SqlConnection()
        conn.ConnectionString = Me.ConnectionString

        Dim tsql As SqlTransaction

        Try
            conn.Open()
            tsql = conn.BeginTransaction()

            Dim cmd As New SqlCommand()
            cmd.Connection = conn
            cmd.CommandText = "UPDATE T_Errori_Dettaglio SET chiaverecord = " _
                & "REPLACE (chiaverecord, '|', ''), valore = REPLACE (valore, '|', '') " _
                & "WHERE (CHARINDEX ('|', chiaverecord) <> 0) OR (CHARINDEX ('|', valore) <> 0)"

            cmd.Transaction = tsql
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Overridable Function GetRiepilogoRicevuta() As DataTable
        Dim dt As New DataTable()
        Dim conn As New SqlConnection()
        conn.ConnectionString = Me.ConnectionString
        Dim cmd As New SqlCommand("SELECT * FROM q_ricevuta", conn)
        Try
            conn.Open()
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(dt)
            conn.Close()
        Catch ex As Exception
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
        End Try
        Return dt
    End Function

    Overridable Function GetRiepilogoErrori() As DataTable
        Dim dt As New DataTable()
        Dim conn As New SqlConnection()
        conn.ConnectionString = Me.ConnectionString
        Dim cmd As New SqlCommand("SELECT * FROM Q_Errori_Riepilogo ORDER BY Cod_Errore", conn)
        Try
            conn.Open()
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(dt)
            conn.Close()
        Catch ex As Exception
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
        End Try
        Return dt
    End Function

    Overridable Sub AccodaNote(ByVal errore As String)
        Dim strConn As String = Me.ConnectionString

        Dim conn As New SqlConnection()
        conn.ConnectionString = strConn

        Dim transaction As SqlTransaction

        Try
            conn.Open()
            Dim cmd As New SqlCommand()
            transaction = conn.BeginTransaction(IsolationLevel.Serializable)
            cmd.CommandText = "execute sp_accoda_note_ricevuta '" & errore & "'"
            cmd.Connection = conn
            cmd.Transaction = transaction
            cmd.ExecuteNonQuery()
            transaction.Commit()
        Catch ex As Exception
            'mailer.SendMail("Errore durante l'esecuzione della procedura di accodamento delle note nella ricevuta", "Impossibile accodare le note nella ricevuta", "federico.paoloni@e-lios.eu;andrea.caputo@e-lios.eu")
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
        End Try
    End Sub

    Overridable Function AggiornaAgenda(ByVal attivita As Attivita)
        Dim result = True
        Dim conn As New SqlConnection(Me.ConnectionString)
        Dim cmd As New SqlCommand
        Dim transact As SqlTransaction

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            transact = conn.BeginTransaction(IsolationLevel.Serializable)
            cmd.CommandText = "UPDATE T_Attivita SET controllo = 1, datacontrollo = {fn NOW()}, filererrori = '" & System.IO.Path.Combine(StarterConfig.ResocontoPath, attivita.Codice & "_rerr.zip") & "', filederrori = " & "'" & System.IO.Path.Combine(StarterConfig.ResocontoPath, attivita.Codice & "_derr.zip") & "', filericevuta= '" & System.IO.Path.Combine(StarterConfig.ResocontoPath, attivita.Codice & "_ric.zip") & "' WHERE (codiceattivita = " & attivita.Codice & ")"
            cmd.Connection = conn
            cmd.Transaction = transact

            cmd.ExecuteNonQuery()
            transact.Commit()
            conn.Close()
            'Scrivere l'invio email
        Catch ex As Exception
            If Not transact Is Nothing Then
                transact.Rollback()
            End If
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        Return result
    End Function

End Class
