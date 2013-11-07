Public Class Referente
    Private _id As String
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _nome As String
    Public Property Nome() As String
        Get
            Return _nome
        End Get
        Set(ByVal value As String)
            _nome = value
        End Set
    End Property


    Private _recapito As Recapito
    Public Property Recapito() As Recapito
        Get
            Return _recapito
        End Get
        Set(ByVal value As Recapito)
            _recapito = value
        End Set
    End Property


    Private _password As String
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property

    Private _percorso As String
    Public Property Percorso() As String
        Get
            Return _percorso
        End Get
        Set(ByVal value As String)
            _percorso = value
        End Set
    End Property

    Public Sub New()
        Recapito = New Recapito
    End Sub
End Class
