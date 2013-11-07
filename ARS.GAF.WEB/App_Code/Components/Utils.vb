Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections.Generic

Namespace arsflussi

    Public Class Utils

        Public Shared Function GetCFUtente(ByVal token As String) As OperationResult

            Dim op As OperationResult

            If (Not token Is Nothing) Then
                Dim xDoc = New System.Xml.XmlDocument()
                xDoc.LoadXml(token)

                If xDoc.GetElementsByTagName("codice_fiscale").Count > 0 Then

                    Dim cf = xDoc.GetElementsByTagName("codice_fiscale")(0).InnerText

                    op = New OperationResult(True, "OK", cf)
                Else
                    op = New OperationResult(False, "La sessione non contiene i dati richiesti!", Nothing)

                End If

            Else
                op = New OperationResult(False, "La sessione non contiene i dati richiesti", Nothing)
                
            End If

            Return op

        End Function

        Public Shared Function GetRuoloUtente(ByVal cf As String) As OperationResult

            Dim op As OperationResult

            Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
            Dim strSql As String = "SELECT CodiceRuolo FROM Utenti WHERE CodiceFiscale = @cf"
            Dim cmd As New SqlCommand(strSql, conn)
            cmd.Parameters.AddWithValue("@cf", cf)

            Try
                conn.Open()

                Dim res As Object = cmd.ExecuteScalar()

                If (Not res Is Nothing) Then
                    op = New OperationResult(True, "OK", res)
                Else
                    op = New OperationResult(False, "Nessun ruolo corrispondente per l'utente!", Nothing)
                End If

            Catch ex As Exception
                op = New OperationResult(False, "Errore durante il recupero dei dati: " & ex.Message, Nothing)
            Finally
                conn.Close()
            End Try

            Return op

        End Function

        Public Shared Function GetIDUtente(ByVal cf As String) As OperationResult

            Dim op As OperationResult

            Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
            Dim strSql As String = "SELECT ID FROM Utenti WHERE CodiceFiscale = @cf"
            Dim cmd As New SqlCommand(strSql, conn)
            cmd.Parameters.AddWithValue("@cf", cf)

            Try
                conn.Open()

                Dim res As Object = cmd.ExecuteScalar()

                If (Not res Is Nothing) Then
                    op = New OperationResult(True, "OK", res)
                Else
                    op = New OperationResult(False, "Nessun ID corrispondente per l'utente!", Nothing)
                End If

            Catch ex As Exception
                op = New OperationResult(False, "Errore durante il recupero dei dati: " & ex.Message, Nothing)
            Finally
                conn.Close()
            End Try

            Return op

        End Function

        Public Shared Function GetUtente(ByVal cf As String) As OperationResult

            Dim op As OperationResult

            Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
            Dim strSql As String = "SELECT Nome + ' ' + Cognome AS nomecognome FROM Utenti WHERE CodiceFiscale = @cf"
            Dim cmd As New SqlCommand(strSql, conn)
            cmd.Parameters.AddWithValue("@cf", cf)

            Try
                conn.Open()
                Dim res As New Object

                Dim reader As SqlDataReader
                reader = cmd.ExecuteReader()
                If reader.Read() Then
                    res = reader("nomecognome")
                End If

                If (Not res Is Nothing) Then
                    op = New OperationResult(True, "OK", res)
                Else
                    op = New OperationResult(False, "Nessun Nome e Cognome corrispondente per l'utente!", Nothing)
                End If

            Catch ex As Exception
                op = New OperationResult(False, "Errore durante il recupero dei dati: " & ex.Message, Nothing)
            Finally
                conn.Close()
            End Try

            Return op

        End Function

        Public Shared Function InitUserLogin(ByVal token As String) As OperationResult

            Dim op As OperationResult

            If (Not token Is Nothing) Then
                Dim xDoc = New System.Xml.XmlDocument()
                xDoc.LoadXml(token)

                If xDoc.GetElementsByTagName("codice_fiscale").Count > 0 Then
                    Dim cf = xDoc.GetElementsByTagName("codice_fiscale")(0).InnerText
                    Dim cognome = xDoc.GetElementsByTagName("cognome")(0).InnerText
                    Dim nome = xDoc.GetElementsByTagName("nome")(0).InnerText

                    op = New OperationResult(True, "OK", String.Format("{0}|{1}|{2}", cf, nome, cognome))
                Else
                    op = New OperationResult(False, "La sessione non può inizializzare l'utente", Nothing)
                End If

            Else
                op = New OperationResult(False, "La sessione non contiene i dati richiesti", Nothing)
            End If

            Return op

        End Function

    End Class

End Namespace