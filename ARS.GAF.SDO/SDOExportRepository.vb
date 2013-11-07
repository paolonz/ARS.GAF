Imports System.Data.SqlClient

Public Class SDOExportRepository

    Private _connectionString As String
    Sub New(ByVal cs As String)
        _connectionString = cs
    End Sub

    Public Function EstraiFileA(ByVal DataStart As DateTime, ByVal DataEnd As DateTime) As DataTable
        Return EstraiFile("SP_ESPORTA_FILE_A", DataStart, DataEnd)
    End Function

    Public Function EstraiFileB(ByVal DataStart As DateTime, ByVal DataEnd As DateTime) As DataTable
        Return EstraiFile("SP_ESPORTA_FILE_B", DataStart, DataEnd)
    End Function

    Private Function EstraiFile(ByVal proc As String, ByVal DataStart As DateTime, ByVal DataEnd As DateTime) As DataTable
        Dim dt As New DataTable
        Try
            Using conn As New SqlConnection(_connectionString)
                conn.Open()
                Using adapter As New SqlDataAdapter(proc, conn)
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure
                    adapter.SelectCommand.Parameters.Add("@DATA_INIZIO", SqlDbType.DateTime)
                    adapter.SelectCommand.Parameters("@DATA_INIZIO").Value = DataStart
                    adapter.SelectCommand.Parameters.Add("@DATA_FINE", SqlDbType.DateTime)
                    adapter.SelectCommand.Parameters("@DATA_FINE").Value = DataEnd
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
        End Try

        Return dt
    End Function
End Class
