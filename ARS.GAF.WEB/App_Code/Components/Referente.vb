Namespace arsflussi

Public Class ReferenteDetails
    'La classe ReferenteDetails contiene alcuni attributi del referente 
    'da utilizzare nella procedura

    Public FullName As String   'Nome completo
    Public Email As String      'Account
    Public Password As String   'Password
    Public Telefono As String   'N. di telefono
    Public Mail As String   'Indirizzo email
    Public Fax As String    'N. di fax
    Public Datapwd As Date    'Data inizio validità password
        Public NggPWD As Integer    'N. di giorni di validità della password 

End Class
Public Class Referente
    'La funzione Login svolge 2 funzioni: la validazione del referente e il controllo
    'sulla scadenza della password, ritornando oltre al codice del referente 
    'anche un valore vero/falso che indica se l'utente deve cambiare la sua password

    Public Function Login(ByVal email As String, ByVal password As String, ByRef cPwd As Boolean) As Integer
        'Connessione al SQL server tramite la stringa definita nel Web Config
        Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Comando per l'interrogazione dei dati
        'Stringa di esecuzione del comando per la login
        Dim strcomm As String = "SELECT progrreferente, " _
        & "datapwd,dataend,ggpwd,ggpwdsoll,pwdnew FROM T_Referenti WHERE (account = '" & Trim(email) & "') AND " _
        & "(pwd = '" & Trim(password) & "')"
        Dim myCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand(strcomm, myConnection)
        'Oggetto reader per la memorizzazione dei dati ricevuti dal server
        Dim myreader As SqlClient.SqlDataReader
        'Variabile dove viene memorizzato il codice del referente
        Dim customerId As Integer
        Try

            'Apertura della connessione ed esecuzione comando
            myConnection.Open()
            myreader = myCommand.ExecuteReader(CommandBehavior.SingleResult)
            
            'Se l'utente esiste
            If myreader.HasRows Then
                myreader.Read()
                'Se la data fine record non è nulla il record è valido
                If myreader.GetValue(2) Is System.DBNull.Value Then
                    customerId = myreader.GetValue(0)
                    'Se la differenza tra la data odierna è maggiore di 3 mesi
                    'da quella registrata nel Db e non è stata inoltrata la richiesta di cambio password(pwdnew) 
                    'allora la variabile per il cambio della
                    'password viene aggiornata a vero
                    If DateDiff(DateInterval.Day, myreader.GetValue(1), Now()) >= (myreader.GetValue(3) - myreader.GetValue(4)) And myreader.GetValue(5) Is System.DBNull.Value And myreader.GetValue(3) > 0 Then
                        cPwd = True
                    End If
                Else
                    'l'utente è scaduto
                    customerId = -1
                End If

            Else
                'L'utente non esiste
                customerId = 0
            End If
            myreader.Close()
            myConnection.Close()
            myCommand = Nothing
            myConnection = Nothing
            myreader = Nothing
            Return customerId

        Catch ex As Exception
            'In caso di errore durante la procedura chiude la connessione e 
            'tutti gli oggetti, l'utente non viene validato
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            myCommand = Nothing
            myConnection = Nothing
            myreader = Nothing

            customerId = 0
            Return customerId
        End Try
    End Function
    Public Function GetReferenteDetails(ByVal customerID As Integer) As ReferenteDetails
        'La funzione GetReferenteDetails restituisce gli attributi(nome,tel., fax ecc...)
        'del Referente
        'Connessione al SQL server tramite la stringa definita nel Web Config
        Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Stringa di esecuzione del comando per l'interrogazione dei dati
        Dim strcomm As String = "SELECT referente, account, pwd, telefono, email, " _
        & "fax,datapwd,ggpwd FROM T_Referenti WHERE (progrreferente = " & customerID & ")"
        'Comando per l'interrogazione dei dati
        Dim myCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand(strcomm, myConnection)
        'Oggetto reader per la memorizzazione dei dati ricevuti dal server
        Dim myreader As SqlClient.SqlDataReader

        Try
            'Apertura della connessione ed esecuzione comando
            myConnection.Open()
            myreader = myCommand.ExecuteReader(CommandBehavior.SingleResult)
            'Creazione nuovo oggetto ReferenteDetails
            Dim myReferenteDetails As New ReferenteDetails
            'Se l'utente ha attributi vengono assegnati i valori corrispondenti
            If myreader.HasRows Then
                myreader.Read()
                myReferenteDetails.FullName = myreader.GetValue(0)
                myReferenteDetails.Email = myreader.GetValue(1)
                myReferenteDetails.Password = myreader.GetValue(2)
                myReferenteDetails.Telefono = myreader.GetValue(3)
                myReferenteDetails.Mail = myreader.GetValue(4)
                myReferenteDetails.Fax = myreader.GetValue(5)
                myReferenteDetails.Datapwd = myreader.GetValue(6)
                myReferenteDetails.NggPWD = myreader.GetValue(7)
            End If
            myreader.Close()
            myConnection.Close()
            myCommand = Nothing
            myConnection = Nothing

            Return myReferenteDetails
        Catch ex As Exception
            'In caso di errore durante la procedura chiude la connessione e 
            'tutti gli oggetti, non viene restituito alcun attributo
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            myCommand = Nothing
            myConnection = Nothing
            myreader = Nothing
            Return Nothing
        End Try
    End Function
    Public Function ModReferenteDetails(ByVal customerID As Integer, ByVal fullName As String, ByVal email As String, ByVal telefono As String, ByVal mail As String, ByVal fax As String, ByVal password As String, ByVal passmod As Boolean) As String
        'La funzione ModReferenteDetails aggiorna gli attributi del referente 
        'restituendo l'esito dell'operazione
        'Stringa di esecuzione del comando per la modifica dei dati
        Dim strsql As String
        'Connessione al SQL server tramite la stringa definita nel Web Config
        Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Transazione per l'aggiornamento dei dati
        Dim mytransact As SqlClient.SqlTransaction
        Try
            'Se il referente ha modificato la sua pwd
            If passmod Then
                'Vengono aggiornati gli attributi e la data di modifica password 
                strsql = "UPDATE T_Referenti SET datapwd = { fn NOW() }, " _
                & "pwdnew = '" & password & "', " _
                & "telefono = '" & telefono & "', " _
                & "email = '" & mail & "', fax = '" & fax & "' WHERE " _
                & "(progrreferente = " & customerID & ")"
            Else
                'Vengono aggiornati solo gli attributi
                strsql = "UPDATE T_Referenti SET " _
                & "telefono = '" & telefono & "', " _
                & "email = '" & mail & "', fax = '" & fax & "' WHERE " _
                & "(progrreferente = " & customerID & ")"
            End If
            'Comando per l'aggiornamento dei dati
            Dim myCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand(strsql, myConnection)
            'Apertura della connessione 
            myConnection.Open()
            'Inizia la transazione con livello di blocco assoluto del recordset
            mytransact = myConnection.BeginTransaction(IsolationLevel.Serializable)
            'Il comando viene legato alla transazione
            myCommand.Transaction = mytransact
            'Esecuzione comando
            myCommand.ExecuteNonQuery()
            'La transazione viene eseguita
            mytransact.Commit()
            myConnection.Close()

            myCommand = Nothing
            myConnection = Nothing
            mytransact = Nothing
            Return "Operazione completata in maniera corretta."
        Catch ex As Exception
            'In caso di errore durante la procedura la transazione viene annullata,
            'chiude la connessione e viene restituito un messaggio di errore
            mytransact.Rollback()
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            myConnection = Nothing
            Return "Operazione annullata. Riprovare in seguito."
        End Try
    End Function
End Class

End Namespace
