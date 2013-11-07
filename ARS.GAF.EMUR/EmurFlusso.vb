Imports ARS.GAF.Core
Imports System.Text
Imports System.IO

Public Class EmurFlusso
    Inherits StandardFlusso
    Implements ARS.GAF.Core.IFlusso

    Public Overrides Sub Init() Implements ARS.GAF.Core.IFlusso.Init
        MyBase.Init()
        Dim _flussoRepo As New EmurRepository(Me.Controllo.DBConfig, Me.StarterConfig)
        SetRepository(_flussoRepo)
        SetFileXSD1("Emur_XSD.xsd")
        SetFileXSD2("")
        SetControllo(Me.Controllo)
        SetStarterConfig(Me.StarterConfig)
    End Sub
End Class
