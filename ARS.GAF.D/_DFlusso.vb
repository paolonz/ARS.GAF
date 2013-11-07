Imports ARS.GAF.Core
Imports System.Configuration
Imports System.Text

Public Class _DFlusso
    Inherits BaseFlusso
    Implements IFlusso

    Public Event DisplayMessage(ByVal message As Core.DisplayMessageArgs) Implements Core.IFlusso.DisplayMessage
#Region "Private Properties"

    Dim _flussoRepo As DRepository

#End Region

#Region "IFlusso interfaces"

    Public Sub Init() Implements Core.IFlusso.Init

        _flussoRepo = New DRepository(Me.Controllo.DBConfig, Me.StarterConfig)
        SetRepository(_flussoRepo)
        SetControllo(Me.Controllo)
        SetStarterConfig(Me.StarterConfig)

        AddHandler MyBase.DisplayInnerMessage, AddressOf SuperMessage

    End Sub

    Public Sub SuperMessage(ByVal message As DisplayMessageArgs)

        RaiseEvent DisplayMessage(message)

        If (message.Severity = DisplayMessageSeverity.Errore) Then
            'AccodaNote(message)
        End If

    End Sub

    Private _mailer As Mailer
    Public Property Mailer As Core.Mailer Implements Core.IFlusso.Mailer
        Get
            Return _mailer
        End Get
        Set(ByVal value As Core.Mailer)
            _mailer = value
        End Set
    End Property

    Public ReadOnly Property FileXSD1 As String Implements Core.IFlusso.FileXSD1
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property FileXSD2 As String Implements Core.IFlusso.FileXSD2
        Get
            Return ""
        End Get
    End Property

    Public Sub AccodaNote(ByVal errore As String) Implements Core.IFlusso.AccodaNote
        'TODO
        Repository.AccodaNote(errore)
    End Sub

    Public ReadOnly Property ControlloImmediato As Boolean Implements Core.IFlusso.ControlloImmediato
        Get
            Return False
        End Get
    End Property

    Public Function Controlla(ByVal attivita As Core.Attivita) As Boolean Implements Core.IFlusso.Controlla
    End Function

    Private _flussoKey As String
    Public Property FlussoKey As String Implements Core.IFlusso.FlussoKey
        Get
            Return _flussoKey
        End Get
        Set(ByVal value As String)
            _flussoKey = value
        End Set
    End Property

    Private _id As Integer
    Public Property ID As Integer Implements Core.IFlusso.ID
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Controllo As Core.Controllo Implements Core.IFlusso.Controllo
        Get
            Return _controllo
        End Get
        Set(ByVal value As Core.Controllo)
            _controllo = value
        End Set
    End Property

    Public Property StarterConfig As Core.StarterConfig Implements Core.IFlusso.StarterConfig
        Get
            Return _starterConfig
        End Get
        Set(ByVal value As Core.StarterConfig)
            _starterConfig = value
        End Set
    End Property


#End Region

#Region "Private methods"

#End Region

End Class
