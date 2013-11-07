Imports System.Web.UI.WebControls
Imports ARS.GAF.Core
Imports System.Globalization

Public Class SDOExportUserControl
    Inherits System.Web.UI.UserControl
    Implements ARS.GAF.Core.IExportUserControl

    Sub New()
        MyBase.New()
    End Sub

    Private _exportBasePath As String
    Public Property ExportBasePath() As String Implements IExportUserControl.ExportBasePath
        Get
            Return _exportBasePath
        End Get
        Set(ByVal value As String)
            _exportBasePath = value
        End Set
    End Property


    Private _gafcs As String
    Public Property GAFCS() As String Implements IExportUserControl.GAFCS
        Get
            Return _gafcs
        End Get
        Set(ByVal value As String)
            _gafcs = value
        End Set
    End Property

    Private _id As Integer
    Public Property FlussoID() As Integer Implements IExportUserControl.FlussoID
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _key As String
    Public Property FlussoKey() As String Implements IExportUserControl.FlussoKey
        Get
            Return _key
        End Get
        Set(ByVal value As String)
            _key = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
        Page.Validate()
        If (Page.IsValid) Then


            Dim service As New SDOExportService()
            Dim dataRepo As New DataRepository(GAFCS, Nothing)
            Dim exportCF As String = dataRepo.GetExportCS(FlussoID)
            Dim repo As New SDOExportRepository(exportCF)

            Dim dataInizio As DateTime = DateTime.ParseExact(txtDateStart.Text, "dd/MM/yyyy", New CultureInfo("it-IT"))
            Dim dataFine As DateTime = DateTime.ParseExact(txtDateEnd.Text, "dd/MM/yyyy", New CultureInfo("it-IT"))

            Dim now As DateTime = DateTime.Now

            Dim dtA As DataTable = repo.EstraiFileA(dataInizio, dataFine)
            service.GenerateTxtFile(dtA, String.Format("{0}/{1}/SDO_FILE_A_{2:yyyyMMddhhmmss}.txt", ExportBasePath, FlussoKey, now))
            Dim dtB As DataTable = repo.EstraiFileB(dataInizio, dataFine)
            service.GenerateTxtFile(dtB, String.Format("{0}/{1}/SDO_FILE_B_{2:yyyyMMddhhmmss}.txt", ExportBasePath, FlussoKey, now))

            pnlExport.Visible = False
            pnlResult.Visible = True
            lblResult.Text = "Esportazione completata con successo"
        End If

    End Sub
End Class