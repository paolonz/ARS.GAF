Imports System.Data.SqlClient

Namespace arsflussi

    Partial Class UClinks
        Inherits System.Web.UI.UserControl

#Region " Codice generato da Progettazione Web Form "

        'Chiamata richiesta da Progettazione Web Form.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTA: la seguente dichiarazione è richiesta da Progettazione Web Form.
        'Non spostarla o rimuoverla.

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: questa chiamata al metodo è richiesta da Progettazione Web Form.
            'Non modificarla nell'editor del codice.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Inserire qui il codice utente necessario per inizializzare la pagina

            If (Not Session("TOKEN") Is Nothing) Then

                Dim op As OperationResult

                op = Utils.GetCFUtente(Session("TOKEN").ToString())

                If Not op.Success Then
                    Response.Redirect("ErrorPage.aspx")
                Else

                    op = Utils.GetRuoloUtente(op.Data)

                    If op.Success Then
                        Dim ruolo As Integer
                        ruolo = op.Data

                        Select Case ruolo
                            Case 1
                                hlLogin.Visible = True
                                Hyperlink2.Visible = False
                                hlProfilo.Visible = False
                                hlIActivity.Visible = False
                                hlSActivity.Visible = False
                                hlSDocs.Visible = False
                                Hyperlink1.Visible = False
                            Case 2
                                hlLogin.Visible = True
                                Hyperlink2.Visible = False
                                hlProfilo.Visible = False
                                hlIActivity.Visible = True
                                hlSActivity.Visible = True
                                hlSDocs.Visible = True
                                Hyperlink1.Visible = True
                            Case 3
                                hlLogin.Visible = True
                                Hyperlink2.Visible = False
                                hlProfilo.Visible = False
                                hlIActivity.Visible = True
                                hlSActivity.Visible = True
                                hlSDocs.Visible = False
                                Hyperlink1.Visible = True
                            Case Else
                                hlLogin.Visible = False
                                Hyperlink2.Visible = False
                                hlProfilo.Visible = False
                                hlIActivity.Visible = False
                                hlSActivity.Visible = False
                                hlSDocs.Visible = False
                                Hyperlink1.Visible = False
                        End Select
                    Else
                        '' TODO: ERRORE NEL RECUPERO DEI RUOLI
                        Response.Redirect("ErrorPage.aspx")
                    End If
                End If
            End If
        End Sub

        Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
            Response.Redirect("http://10.6.9.14/arsflussi")
        End Sub

    End Class

End Namespace


