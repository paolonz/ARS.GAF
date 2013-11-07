Imports ARS.GAF.Core
Imports System.Data.SqlClient

Public Class DistintaContabileRepository
    Inherits BaseFlussoRepository

    Sub New(ByVal dbConfig As Core.DBConfig, ByVal starterConfig As Core.StarterConfig)
        MyBase.New(dbConfig, starterConfig)
    End Sub

    Function PulisciTabella() As OperationResult
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
            cmd.CommandText = "DELETE DistinteAppo" & vbCrLf & _
                "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'ErroriDistinte')" & vbCrLf & _
                "DROP TABLE [dbo].[ErroriDistinte]"
            cmd.ExecuteNonQuery()

            tsql.Commit()

            op.Success = True
            op.Message = "Tabella temporanea cancellata correttamente"
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
            op.Message = "File {0} Inserito con successo"
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

    Public Function EseguiControlli() As Boolean
        Dim result = True
        Dim conn As New SqlConnection(Me.ConnectionString)

        Try
            conn.Open()
            Dim cmd As New SqlCommand("ControllaDistinte", conn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            result = False
        Finally
            conn.Close()
        End Try

        Return result
    End Function

    Public Function ControllaErrori() As Boolean
        Dim result = True
        Dim conn As New SqlConnection(Me.ConnectionString)

        Try
            conn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM ErroriDistinte", conn)
        Catch ex As Exception
            result = False
        Finally
            conn.Close()
        End Try

        Return result
    End Function

    Public Function AggiornaRicette() As Boolean

        Return ExecProcWithTransaction("sp_aggiornaricette", True, False)
        
    End Function

    

End Class
