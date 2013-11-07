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
                
                Return
            End If

        End Sub


      

        Protected Sub gridUtenti_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridUtenti.RowCommand
            Select Case e.CommandName
                Case "AggiungiUtente"
                    DetailsView.Visible = True
                    gridUtenti.Visible = False
                    DetailsView.ChangeMode(DetailsViewMode.Insert)
                Case "EliminaUtente"
                Case "ModificaUtente"
                    Dim control As Control = DirectCast(e.CommandSource, Control)
                    Dim selectedRow As GridViewRow = DirectCast(control.Parent.Parent, GridViewRow)
                    gridUtenti.SelectedIndex = selectedRow.RowIndex

                    DetailsView.Visible = True
                    gridUtenti.Visible = False
                    DetailsView.ChangeMode(DetailsViewMode.Edit)
                    DetailsView.DataBind()
            End Select
        End Sub

        Protected Sub DetailsView_DataBound(sender As Object, e As System.EventArgs) Handles DetailsView.DataBound

            If (DetailsView.CurrentMode = DetailsViewMode.Edit) Then
                Dim ddlRoles As DropDownList = DetailsView.FindControl("ddlRoles")
                If (Not ddlRoles Is Nothing) Then
                    ddlRoles.SelectedIndex = ddlRoles.Items.IndexOf(ddlRoles.Items.FindByValue(DataBinder.Eval(DetailsView.DataItem,"CodiceRuolo").ToString()))
                End If
                Dim btnInsert As LinkButton = DetailsView.FindControl("btnInsert")
                btnInsert.Visible = False
                Dim btnEdit As LinkButton = DetailsView.FindControl("btnEdit")
                btnEdit.Visible = True
            End If
            If (DetailsView.CurrentMode = DetailsViewMode.Insert) Then
                Dim btnInsert As LinkButton = DetailsView.FindControl("btnInsert")
                btnInsert.Visible = True
                Dim btnEdit As LinkButton = DetailsView.FindControl("btnEdit")
                btnEdit.Visible = False
            End If

        End Sub

        Protected Sub DetailsView_ItemUpdated(sender As Object, e As System.Web.UI.WebControls.DetailsViewUpdatedEventArgs) Handles DetailsView.ItemUpdated
            DetailsView.Visible = False
            gridUtenti.Visible = True
            gridUtenti.DataBind()
        End Sub
    End Class
End Namespace