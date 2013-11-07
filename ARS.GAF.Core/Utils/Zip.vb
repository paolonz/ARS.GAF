Imports System.IO
Imports SevenZip

Public Class Zip

    Public Shared Function GetSavedName(ByVal file As File) As String
        Dim savedFileName = String.Empty
        Dim lastIndex As Integer = -1
        lastIndex = file.FileSalvato.LastIndexOf("/")
        If (lastIndex <> -1) Then
            savedFileName = file.FileSalvato.Substring(lastIndex + 1)
        Else
            lastIndex = file.FileSalvato.LastIndexOf("\")
            If (lastIndex <> -1) Then
                savedFileName = file.FileSalvato.Substring(lastIndex + 1)
            End If
        End If
        Return savedFileName
    End Function

    Public Shared Function DecomprimiFile(ByVal SevenZipDllPath As String, ByVal file As File, ByVal referente As Referente, ByVal flussoID As Integer, ByVal destinationFolder As String) As OperationResult
        Dim op As New OperationResult
        Dim savedFileName = GetSavedName(file)
        Dim fullPathName = String.Format("{0}/{1}/{2}", referente.Percorso, flussoID, savedFileName)
        Dim password = String.Empty
        If (file.ProgressivoCompressione > 3) Then
            password = referente.Password
        End If
        Try
            If (file.ProgressivoCompressione > 1) Then
                op = Zip.EstraiFile(SevenZipDllPath, fullPathName, password, destinationFolder)
                If (op.Success) Then
                    file.NomeFile = Path.Combine(destinationFolder, op.Parameter)
                End If
            End If
        Catch ex As Exception
            op.Success = False
            op.Message = ex.Message
        End Try

        Return op
    End Function

    ' Estrazione archivio
    Public Shared Function EstraiFile(ByVal SevenZipDllPath As String, ByVal fileName As String, ByVal password As String, ByVal destinationDirectory As String) As OperationResult
        Dim op As New OperationResult
        op.Success = True
        Try

            SevenZipExtractor.SetLibraryPath(SevenZipDllPath)

            Dim ext As SevenZipExtractor

            If (String.IsNullOrEmpty(password)) Then
                ext = New SevenZipExtractor(fileName)
            Else
                ext = New SevenZipExtractor(fileName, password)
            End If

            ext.ExtractArchive(destinationDirectory)

            Dim extractedFileName = ext.ArchiveFileNames(0)
            op.Parameter = extractedFileName
            op.Message = String.Format("Decompressione del file {0} avvenuta con successo. Estratto il file {1}", fileName, Path.Combine(destinationDirectory, extractedFileName))
        Catch ex As Exception
            op.Success = False
            op.Message = ex.Message
            op.Parameter = String.Empty
        End Try

        Return op
    End Function

    ' Compressione Archivio

    Public Shared Function ComprimiFile(ByVal SevenZipDllPath As String, ByVal destionationFileName As String, ByVal fileToAdd As String, ByVal destinationDirectory As String) As OperationResult
        Dim files = New String(0) {}
        files(0) = fileToAdd
        Return ComprimiFile(SevenZipDllPath, destionationFileName, files, destinationDirectory)
    End Function

    Public Shared Function ComprimiFile(ByVal SevenZipDllPath As String, ByVal destionationFileName As String, ByVal filesToAdd As String(), ByVal destinationDirectory As String) As OperationResult

        Dim op As New OperationResult

        SevenZipCompressor.SetLibraryPath(SevenZipDllPath)

        Dim zip As New SevenZipCompressor()

        zip.ArchiveFormat = SevenZip.OutArchiveFormat.Zip
        zip.CompressionMethod = SevenZip.CompressionMethod.Default
        zip.CompressionMode = SevenZip.CompressionMode.Create
        zip.CompressionLevel = SevenZip.CompressionLevel.Ultra

        If (destinationDirectory.EndsWith("/")) Then
            destinationDirectory = destinationDirectory.Substring(0, destinationDirectory.Length - 1)
        End If

        If (destinationDirectory.EndsWith("\")) Then
            destinationDirectory = destinationDirectory.Substring(0, destinationDirectory.Length - 1)
        End If

        Try
            zip.CompressFiles(Path.Combine(destinationDirectory, destionationFileName & ".zip"), filesToAdd)
            op.Success = True
            op.Message = String.Format("File {0} compresso all'interno dell'archivio {1}", filesToAdd.FirstOrDefault(), Path.Combine(destinationDirectory, destionationFileName & ".zip"))
        Catch ex As Exception
            op.Success = False
            op.Message = ex.Message
        End Try

        Return op

    End Function
End Class
