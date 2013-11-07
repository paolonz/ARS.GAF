Imports ARS.GAF.Core
Imports System.Data.SqlClient

Public Class SpecialisticaRepository
    Inherits BaseFlussoRepository

    Sub New(ByVal dbConfig As Core.DBConfig, ByVal starterConfig As Core.StarterConfig)
        MyBase.New(dbConfig, starterConfig)
    End Sub

    Function InserisciRecord(ByVal table As DataTable, ByVal tableName As String) As OperationResult
        Dim op = New OperationResult
        Dim result = True
        Dim conn As New SqlConnection()
        conn.ConnectionString = Me.ConnectionString
        Dim tsql As SqlTransaction
        Try

            conn.Open()
            tsql = conn.BeginTransaction()
            Dim cmd As New SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tsql)
            cmd.BatchSize = table.Rows.Count
            cmd.BulkCopyTimeout = 400
            cmd.DestinationTableName = tableName
            cmd.WriteToServer(table)
            tsql.Commit()

            op.Success = True
            op.Message = "File {0} inserito con successo"
        Catch ex As Exception
            If (Not tsql Is Nothing) Then
                tsql.Rollback()
            End If
            op.Success = False
            op.Message = ex.Message
        Finally
            If (conn.State = System.Data.ConnectionState.Open) Then
                conn.Close()
            End If
        End Try
        Return op
    End Function

    Function PulisciTabelle() As OperationResult
        Dim op = New OperationResult
        Dim result = True
        Dim conn As New SqlConnection()
        conn.ConnectionString = Me.ConnectionString
        Dim tsql As SqlTransaction
        Try
            conn.Open()
            tsql = conn.BeginTransaction()
            Dim cmd As New SqlCommand()
            cmd.Connection = conn
            cmd.Transaction = tsql
            cmd.CommandTimeout = 400
            cmd.CommandText = "DELETE SPECIALISTICA_C1_Elaborazione"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "DELETE SPECIALISTICA_C2_Elaborazione"
            cmd.ExecuteNonQuery()

            tsql.Commit()

            op.Success = True
            op.Message = "Tabelle di accodamento cancellate correttamente"
        Catch ex As Exception
            If (Not tsql Is Nothing) Then
                tsql.Rollback()
            End If
            op.Success = False
            op.Message = ex.Message
        Finally
            If (conn.State = System.Data.ConnectionState.Open) Then
                conn.Close()
            End If
        End Try
        Return op
    End Function

    Function AccodaRicevuta(ByVal storedprocedure As String)
        'TODO
    End Function

    Public Overrides Function Importa(ByVal attivita As Core.Attivita, ByVal controllo As Core.Controllo) As Core.OperationResult

        Dim op As New OperationResult
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

            Dim parIdFlusso As New SqlParameter("@ID_Flusso", controllo.Flusso.ID)
            parIdFlusso.Direction = ParameterDirection.Input
            cmd.Parameters.Add(parIdFlusso)

            Dim parIdPeriodo As New SqlParameter("@ID_Periodo", controllo.Periodo.ID)
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



            op.Success = True
            op.Message = "Controlli regionali/ministeriali effettuati con successo"
        Catch ex As Exception
            op.Success = False
            op.Message = ex.Message
        Finally
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
        End Try

        Return op

        


    End Function

End Class
