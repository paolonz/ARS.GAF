Imports System.IO

Public Class SDOExportService

    Function GenerateTxtFile(ByVal dt As DataTable, ByVal path As String) As Boolean
        Dim r As Boolean = False
        Try
            Dim fi As New FileInfo(path)
            If (Not fi.Directory.Exists) Then
                fi.Directory.Create()
            End If

            For Each row As DataRow In dt.Rows
                For Each column As DataColumn In dt.Columns
                    If Not IsDBNull(row(column)) Then
                        File.AppendAllText(path, row(column))
                    End If
                Next
                File.AppendAllText(path, System.Environment.NewLine)
            Next
        Catch ex As Exception

        End Try
        Return r
    End Function

End Class
