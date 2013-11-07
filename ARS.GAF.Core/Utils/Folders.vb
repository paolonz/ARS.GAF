Imports System.IO

Public Class Folders

    ' Controllo se il percorso per l'estrazione esiste
    Private Shared Sub CreaDirectory(ByVal dir As String)

        Dim dirInfo As New DirectoryInfo(dir)
        If Not dirInfo.Exists Then
            dirInfo.Create()
        End If

    End Sub

End Class
