Imports ARS.GAF.Core
Imports System.Data.SqlClient

Public Class FarmaceuticaRepository
    Inherits BaseFlussoRepository

    Sub New(ByVal dbConfig As Core.DBConfig, ByVal starterConfig As Core.StarterConfig)
        MyBase.New(dbConfig, starterConfig)
    End Sub

    Public Function InserisciRecord(ByVal file As Core.File, ByVal CFUtente As String, ByVal fileFormato As String) As OperationResult
        Dim op As New OperationResult
        Dim result = True
        Dim conn As New SqlConnection()
        conn.ConnectionString = Me.ConnectionString
        Dim tsql As SqlTransaction

        Try
            conn.Open()
            tsql = conn.BeginTransaction()
            Dim cmd As New SqlCommand()
            cmd.Connection = conn
            cmd.CommandText = "ImportaRicette_NEW"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@FileDaImportare", file.NomeFile)
            cmd.Parameters.AddWithValue("@Utente", CFUtente)
            cmd.Parameters.AddWithValue("@FileFormato", fileFormato)
            cmd.CommandTimeout = 400

            cmd.Transaction = tsql
            cmd.ExecuteNonQuery()

            tsql.Commit()

            op.Success = True
            op.Message = String.Format("File {0} inserito correttamente tramite bcp", file.NomeFile)

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
            Dim cmd As New SqlCommand("Controlli_Ricette_New", conn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            result = False
        Finally
            conn.Close()
        End Try

        Return result
    End Function

    Public Function InserisciRicette() As Boolean

        Dim result = True
        Dim conn As New SqlConnection(Me.ConnectionString)

        Try
            conn.Open()
            Dim cmd As New SqlCommand("Inserisci_Ricette", conn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            result = False
        Finally
            conn.Close()
        End Try

        Return result


    End Function

End Class
