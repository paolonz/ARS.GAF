Imports ARS.GAF.Core

Public Class AttivitaTest

    Private _Attivita As Attivita
    Public Property Attivita() As Attivita
        Get
            Return _Attivita
        End Get
        Set(ByVal value As Attivita)
            _Attivita = value
        End Set
    End Property

    Public ReadOnly Property CodiceAttivita() As Integer
        Get
            Return _Attivita.Codice
        End Get
    End Property



    Public ReadOnly Property Referente() As String
        Get
            Return _Attivita.Referente.Nome
        End Get
    End Property


    Public ReadOnly Property Flusso() As String
        Get
            Return _Attivita.Flusso.Nome
        End Get
    End Property



    Public ReadOnly Property DataCaricamento() As DateTime
        Get
            Return _Attivita.DataInserimento
        End Get
    End Property


End Class
