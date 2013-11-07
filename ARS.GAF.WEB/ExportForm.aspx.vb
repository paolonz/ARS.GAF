Imports ARS.GAF.Core
Imports System.IO
Imports System.Reflection

Partial Class ExportForm
    Inherits BasePage
    Protected Sub ddl_flusso_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_flusso.SelectedIndexChanged
        LoadUserControl()
    End Sub

    Protected Sub LoadUserControl()
        panelUC.Controls.Clear()
        Dim item As ListItem = ddl_flusso.SelectedItem
        If (item.Value <> "0") Then
            Dim loader As New ARS.GAF.Core.ModuleLoader
            Dim flusso As FlussoModule = loader.GetModule(Integer.Parse(item.Value))
            Dim fullName As String = ""
            Dim fullPath As String = String.Empty
            Dim name As String = String.Empty
            Dim exportFlusso As IExport = loader.LoadExport(flusso.Key, fullName, fullPath, name)

            Dim uc As UserControl = Page.LoadControl(String.Format("~/absolute/{0}/{1}", fullPath.Replace(":", ""), exportFlusso.UserControlFullName))
            uc.ID = "uc" + flusso.ID.ToString()
            Dim uce = TryCast(uc, IExportUserControl)
            uce.FlussoID = flusso.ID
            uce.FlussoKey = flusso.Key
            uce.GAFCS = ConfigurationSettings.AppSettings("ConnectionString")
            uce.ExportBasePath = ConfigurationSettings.AppSettings("ExportPath")

            If (Not uc Is Nothing) Then
                panelUC.Controls.Add(TryCast(uc, System.Web.UI.UserControl))
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ruoli() As Integer = {1, 2, 3}
        InitializeUser(Session("TOKEN").ToString())
        Dim op As OperationResult
        op = CheckCohesion(Session("TOKEN").ToString(), ruoli)

        If Not op.Success Then
            lbl.Text = op.Message
            Return
        End If


        If (Not Page.IsPostBack) Then
            GenerateFlussiDDL()
        Else
            If Not ddl_flusso.SelectedItem Is Nothing Then
                LoadUserControl()
            End If
        End If
    End Sub

    Protected Sub GenerateFlussiDDL()
        Dim loader As New ARS.GAF.Core.ModuleLoader

        Dim flussi As FlussoModuleConfigurationCollection = loader.GetModules()

        Dim defaultItem As New ListItem("Seleziona il flusso da esportare", "0")
        ddl_flusso.Items.Add(defaultItem)

        For Each flusso As FlussoModule In flussi
            Dim fullNameDll As String = String.Empty
            Dim fullPath As String = String.Empty
            Dim name As String = String.Empty
            Dim currentFlusso As IExport = loader.LoadExport(flusso.Key, fullNameDll, fullPath, name)
            If (Not currentFlusso Is Nothing) Then
                Dim item As New ListItem(currentFlusso.Name, currentFlusso.ID.ToString())
                ddl_flusso.Items.Add(item)
            End If
        Next
    End Sub

End Class
