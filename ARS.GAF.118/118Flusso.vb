Imports ARS.GAF.Core
Imports System.Text
Imports System.IO

Public Class _118Flusso
    Inherits StandardFlusso
    Implements ARS.GAF.Core.IFlusso

    Public Overrides Sub Init() Implements ARS.GAF.Core.IFlusso.Init
        Dim _flussoRepo As New _118Repository(Me.Controllo.DBConfig, Me.StarterConfig)
        SetRepository(_flussoRepo)
        SetFileXSD1("118_XSD_File1.xsd")
        SetFileXSD2("118_XSD_File2.xsd")
        SetControllo(Me.Controllo)
        SetStarterConfig(Me.StarterConfig)
    End Sub
End Class
