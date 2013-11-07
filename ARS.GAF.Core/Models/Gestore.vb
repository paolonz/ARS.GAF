Public Class Gestore
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
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

    Public Sub New()
        Recapito = New Recapito
    End Sub
End Class
