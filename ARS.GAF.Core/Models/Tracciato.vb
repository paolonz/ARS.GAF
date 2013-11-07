Public Class Tracciato
    Private _errori As String
    Public Property Errori() As String
        Get
            Return _errori
        End Get
        Set(ByVal value As String)
            _errori = value
        End Set
    End Property


    Private _ricevuta As String
    Public Property Ricevuta() As String
        Get
            Return _ricevuta
        End Get
        Set(ByVal value As String)
            _ricevuta = value
        End Set
    End Property

    ' Non ho idea di cosa sia occorre verificare TODO
    Private _dErrori As String
    Public Property DErrori() As String
        Get
            Return _dErrori
        End Get
        Set(ByVal value As String)
            _dErrori = value
        End Set
    End Property
End Class
