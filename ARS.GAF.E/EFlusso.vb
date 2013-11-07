Imports ARS.GAF.Core
Imports System.Text
Imports System.IO

Public Class EFlusso
    Inherits StandardFlusso
    Implements ARS.GAF.Core.IFlusso

    Public Overrides Sub Init() Implements ARS.GAF.Core.IFlusso.Init
        Dim _flussoRepo As New ERepository(Me.Controllo.DBConfig, Me.StarterConfig)
        SetRepository(_flussoRepo)
        SetFileXSD1("")
        SetFileXSD2("")
        SetControllo(Me.Controllo)
        SetStarterConfig(Me.StarterConfig)
    End Sub

End Class
