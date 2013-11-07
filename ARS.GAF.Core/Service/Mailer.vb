Imports System.Net
Imports System.Net.Mail

Public Class Mailer
    Private _config As Config
    Public Property Config() As Config
        Get
            Return _config
        End Get
        Set(ByVal value As Config)
            _config = value
        End Set
    End Property

    Sub New(ByVal cnf As Config)
        _config = cnf
    End Sub

    Function SendMail(ByVal subject As String, ByVal body As String, ByVal fromAddress As String, ByVal toAddress As String, ByVal attivita As Attivita, ByVal controllo As Controllo) As Boolean
        Return SendMail(subject, body, fromAddress, toAddress, attivita, controllo, Nothing)
    End Function

    Function SendMail(ByVal subject As String, ByVal body As String, ByVal fromAddress As String, ByVal toAddress As String, ByVal attivita As Attivita, ByVal controllo As Controllo, ByVal attachments As String) As Boolean

        ''TODO Implementare l'invio delle mail
        Dim mail As MailMessage = New MailMessage
        Dim smtpMail As SmtpClient

        If Environment.UserDomainName <> System.Configuration.ConfigurationSettings.AppSettings("dominio").ToString() Then
            Return False
        End If

        Try
            mail.From = New MailAddress(_config.EmailAmministratore)
            mail.To.Add(toAddress)
            mail.Subject = subject
            mail.Body = controllo.EmailTemplate & "<br>" & body
            mail.IsBodyHtml = True

            If (Not String.IsNullOrEmpty(attachments)) Then
                Dim allegato As Attachment
                allegato = New Attachment(attachments)
                mail.Attachments.Add(allegato)
            End If

            smtpMail = New SmtpClient(_config.ServerSmtp)
            smtpMail.Credentials = New System.Net.NetworkCredential(_config.EmailAmministratore, _config.Password)
            smtpMail.Port = 25
            smtpMail.Send(mail)
        Catch ex As Exception
            Throw New Exception("Errore durante l'invio dell'email: " & ex.Message)
            Return False
        Finally
            mail = Nothing
        End Try

        Return True

    End Function
End Class
