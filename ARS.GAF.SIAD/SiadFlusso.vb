Imports ARS.GAF.Core
Imports System.Text
Imports System.IO

Public Class SiadFlusso
    Inherits StandardFlusso
    Implements ARS.GAF.Core.IFlusso

    Public Sub Init() Implements ARS.GAF.Core.IFlusso.Init
        Dim _flussoRepo As New SiadRepository(Me.Controllo.DBConfig, Me.StarterConfig)
        SetRepository(_flussoRepo)
        SetFileXSD1("Siad_file1.xsd")
        SetFileXSD2("Siad_file1.xsd")
        SetControllo(Me.Controllo)
        SetStarterConfig(Me.StarterConfig)
    End Sub
End Class
