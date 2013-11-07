Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace arsflussi
    Partial Class admin
        Inherits BasePage

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

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

            Dim ruoli() As Integer = {1}
            InitializeUser(Session("TOKEN").ToString())
            Dim op As OperationResult
            op = CheckCohesion(Session("TOKEN").ToString(), ruoli)

            If Not op.Success Then
                lblMessage.Text = op.Message
                ddlSelectOption.Enabled = False
                ddlSelectOption.SelectedIndex = 0
                Return
            End If

        End Sub


        Protected Sub ddlSelectOption_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSelectOption.SelectedIndexChanged

            If ddlSelectOption.SelectedItem.Value = 1 Then

                phContent.Controls.Add(LoadControl("UCAddUtente.ascx"))

            End If
        End Sub
    End Class
End Namespace