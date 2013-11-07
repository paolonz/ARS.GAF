Imports Microsoft.VisualBasic
Imports arsflussi

Public Class BasePage
    Inherits Page

    Private _cf As String
    Public ReadOnly Property CF() As String
        Get
            Return _cf
        End Get
    End Property


    Private _userID As Integer
    Public ReadOnly Property USERID() As Integer
        Get
            Return _userID
        End Get
    End Property

    Private _role As Integer
    Public ReadOnly Property ROLE() As Integer
        Get
            Return _role
        End Get
    End Property

    Public Sub InitializeUser(ByVal token As String)

        Dim op As OperationResult

        If Not token Is Nothing Then

            op = Utils.GetCFUtente(token)
            If Not op.Success Then
                Response.Redirect("ErrorPage.aspx")
                Return
            End If
            _cf = op.Data

            op = Utils.GetIDUtente(_cf)
            If Not op.Success Then
                Response.Redirect("ErrorPage.aspx")
                Return
            End If
            _userID = op.Data

            op = Utils.GetRuoloUtente(_cf)
            If Not op.Success Then
                Response.Redirect("ErrorPage.aspx")
                Return
            End If
            _role = op.Data
        Else
            'Errore inizializzazione parametri utente
            op = New OperationResult(False, "La sessione non contiene parametri dell'utente", Nothing)
        End If

    End Sub

    Public Function CheckCohesion(ByVal token As String, ByVal roles As Integer()) As OperationResult

        Dim op As OperationResult

        'Se in sessione non abbiamo il token di Cohesion allora non si è loggati
        If String.IsNullOrEmpty(token) Then

            op = New OperationResult(False, "Nessun utente loggato!", Nothing)
            Return op
        End If

        'Se _cf è null o vuoto o se _userID è null o se _role è null allora c'è un errore
        If String.IsNullOrEmpty(_cf) Or (_userID = Nothing Or _userID = 0) Or (_role = 0 Or _role = Nothing) Then

            op = New OperationResult(False, "Errore durante il recupero dei parametri dell'utente!", Nothing)
            Return op
        End If

        Dim accepted As Boolean = False
        For Each role As Integer In roles

            If _role = role Then
                accepted = True
            End If
        Next

        If Not accepted Then
            op = New OperationResult(False, "L'utente non ha i permessi per accedere alla pagina!", Nothing)
            Return op
        End If

        op = New OperationResult(True, "OK", Nothing)
        Return op

    End Function

    Public Function CheckUserRole(ByVal rolerequired As Integer) As OperationResult

        Dim op As OperationResult
        If (_role <> rolerequired) Then
            op = New OperationResult(False, "L'utente non ha il permesso di accedere alla pagina richiesta!", Nothing)
        Else
            op = New OperationResult(True, "OK!", Nothing)
        End If

        Return op
    End Function

End Class
