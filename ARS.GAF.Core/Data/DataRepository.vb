Imports System.Data.SqlClient
Imports ARS.GAF.Core

Public Class DataRepository

    Inherits BaseRepository



    Private _starterConfig As StarterConfig
    Public ReadOnly Property StarterConfig() As StarterConfig
        Get
            Return _starterConfig
        End Get
    End Property


    Public Sub New(ByVal connString As String, ByVal StarterConfig As StarterConfig)
        MyBase.New(connString)
        _starterConfig = StarterConfig
    End Sub

    Public Function GetAttivitaDaValidare() As List(Of Attivita)


        Dim result As New List(Of Attivita)

        Dim strSql As New String("SELECT * from V_AttdaValid")

        Dim conn As New SqlConnection(MyBase.connString)
        Dim cmd As New SqlCommand(strSql, conn)

        Try
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            Dim lastCodiceAttivita = 0
            Dim attivita As Attivita = Nothing

            While reader.Read()

                Dim currentCodiceAttivita = Integer.Parse(reader("codiceattivita").ToString())

                If (Not currentCodiceAttivita.Equals(lastCodiceAttivita)) Then

                    attivita = New Attivita
                    result.Add(attivita)
                    attivita.Files = New List(Of File)
                    attivita.Codice = currentCodiceAttivita

                    attivita.Flusso.ID = Integer.Parse(reader("progrflusso").ToString())
                    attivita.Flusso.Nome = reader("flusso").ToString()
                    attivita.Flusso.Tipo = reader("codiceflusso").ToString()
                    attivita.Referente.ID = Integer.Parse(reader("progrreferente").ToString())
                    attivita.Referente.Nome = reader("referente").ToString()
                    attivita.Referente.Recapito.Email = reader("emailref").ToString()
                    attivita.Referente.Recapito.Fax = reader("faxref").ToString()
                    attivita.Referente.Recapito.Telefono = reader("telref").ToString()
                    attivita.Referente.Password = reader("pwd").ToString()
                    attivita.Referente.Percorso = "C:\Inetpub\ftproot\christian_bogino" 'reader("cartella").ToString() TODO : CAMBIARE IN PROD
                    attivita.Gestore.ID = Integer.Parse(reader("progrgestore").ToString())
                    attivita.Gestore.Nome = reader("gestore").ToString()
                    attivita.Gestore.Recapito.Email = reader("emailges").ToString()
                    attivita.Gestore.Recapito.Fax = reader("faxges").ToString()
                    attivita.Gestore.Recapito.Telefono = reader("telges").ToString()
                    attivita.Periodo.ID = Integer.Parse(reader("progrperiodo").ToString())
                    attivita.Periodo.Nome = reader("periodo").ToString()
                    attivita.Periodo.Anno = Integer.Parse(reader("annoperiodo").ToString())
                    attivita.Periodo.Mese = Integer.Parse(reader("meseperiodo").ToString())

                    If reader("validitaperiodo").ToString().Equals("s") Then
                        attivita.Periodo.Valida = True
                    Else
                        attivita.Periodo.Valida = False
                    End If

                    If Not String.IsNullOrEmpty(reader("dataini").ToString()) Then
                        attivita.Periodo.DataInizio = DateTime.Parse(reader("dataini").ToString())
                    Else
                        attivita.Periodo.DataInizio = DateTime.MinValue
                    End If

                    If Not String.IsNullOrEmpty(reader("dataend").ToString()) Then
                        attivita.Periodo.DataFine = DateTime.Parse(reader("dataend").ToString())
                    Else
                        attivita.Periodo.DataFine = DateTime.MinValue
                    End If

                    If Not reader("validitaattivita").ToString() Is Nothing And Integer.Parse(reader("validitaattivita").ToString()) = 1 Then
                        attivita.Validita = True
                    Else
                        attivita.Validita = False
                    End If

                    If Not String.IsNullOrEmpty(reader("datainserimento").ToString()) Then
                        attivita.DataInserimento = DateTime.Parse(reader("datainserimento").ToString())
                    Else
                        attivita.DataInserimento = DateTime.MinValue
                    End If
                End If

                Dim file As New File

                file.ID = Integer.Parse(reader("prograttivita").ToString())
                file.NomeFile = reader("nomefile").ToString()
                file.FileSalvato = reader("filesalvato").ToString()
                file.Posizione = Integer.Parse(reader("posizione").ToString())
                file.ProgressivoTrasmissione = Integer.Parse(reader("progrtras").ToString())
                file.ProgressivoCompressione = Integer.Parse(reader("progrcompressione").ToString())
                file.TracciatoFile = reader("tracciatofile").ToString()
                file.TabDestinazione = reader("tabdest").ToString()
                file.Namespace = reader("nspaces").ToString()
                attivita.Files.Add(file)
                
                lastCodiceAttivita = currentCodiceAttivita

            End While
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        Return result


    End Function


    Function GetControllo(ByVal codiceFlusso As Integer, ByVal codicePeriodo As Integer) As Controllo
        Dim strSQL As String = String.Format("SELECT * FROM V_SelPeriodiFlussi WHERE progrflusso={0} and progrperiodo={1}", codiceFlusso, codicePeriodo)

        Dim conn As New SqlConnection(Me.connString)
        Dim cmd As New SqlCommand(strSQL, conn)

        Dim control As Controllo = Nothing

        Try
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                control = New Controllo()

                control.Flusso.ID = Integer.Parse(reader("progrflusso").ToString())
                control.Flusso.Nome = reader("flusso").ToString()
                control.Flusso.Tipo = reader("codiceflusso").ToString()
                control.Periodo.ID = Integer.Parse(reader("progrperiodo").ToString())
                control.Periodo.Nome = reader("periodo").ToString()
                control.Periodo.Anno = Integer.Parse(reader("annoperiodo").ToString())
                control.Periodo.Mese = Integer.Parse(reader("meseperiodo").ToString())
                If reader("validita").ToString().Equals("s") Then
                    control.Periodo.Valida = True
                Else
                    control.Periodo.Valida = False
                End If

                If Not String.IsNullOrEmpty(reader("dataini").ToString()) Then
                    control.Periodo.DataInizio = DateTime.Parse(reader("dataini").ToString())
                Else
                    control.Periodo.DataInizio = DateTime.MinValue
                End If

                If Not String.IsNullOrEmpty(reader("dataend").ToString()) Then
                    control.Periodo.DataFine = DateTime.Parse(reader("dataend").ToString())
                Else
                    control.Periodo.DataFine = DateTime.MinValue
                End If

                control.DBConfig.ConnectionString = reader("connfile").ToString()
                control.DBConfig.Nome = reader("db").ToString()
                control.DBConfig.Utente = reader("utente").ToString()
                control.DBConfig.Password = reader("pwd").ToString()
                control.DBConfig.Server = reader("server").ToString()
                control.DriveFile = reader("drivefile").ToString()

                control.Tracciato.DErrori = reader("tracciatoderrori").ToString() 'TODO CAMBIARE IN PROD
                control.Tracciato.Errori = reader("tracciatorerrori").ToString()
                control.Tracciato.Ricevuta = reader("tracciatoricevuta").ToString()

                control.LineaComando = reader("lineacomando").ToString()
                control.CartellaCond = reader("cartcond").ToString()
                control.DTS = reader("DTS").ToString()
                control.DTSAccodamento = reader("DTS_acc").ToString()
                control.CartellaOutput = reader("cartoutput").ToString()

                If reader("tipoconnfile").ToString().Equals("SQL") Then
                    control.Tipo = TipoControllo.SQL
                Else
                    control.Tipo = TipoControllo.XML
                End If

                control.EmailTemplate = reader("testomail").ToString()

            End While

        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        Return control
    End Function

    
    Public Function AggiornaAgenda(ByVal attivita As Attivita)
        Dim result = True
        Dim conn As New SqlConnection(connString)
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

    Function GetExportCS(ByVal codiceFlusso As Integer) As String
        Dim strSQL As String = String.Format("SELECT TOP 1 connfile FROM T_PeriodiFlussi WHERE progrflusso={0} order by progrperflussi desc", codiceFlusso)
        Dim r As String = ""

        Dim conn As New SqlConnection(Me.connString)
        Dim cmd As New SqlCommand(strSQL, conn)

        Try
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                r = reader(0).ToString()

            End While

        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        Return r
    End Function



End Class
