Imports ARS.GAF.Core
Imports System.Configuration
Imports System.Linq
Imports System.ComponentModel
Imports System.Reflection

Public Class Form1

    Dim _dataRepo As DataRepository
    Dim _loader As ModuleLoader
    Dim _config As StarterConfig
    Dim _backgroundWorker As BackgroundWorker
    Dim _backgroundExportWorker As BackgroundWorker

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
        Dim cs As String = ConfigurationManager.ConnectionStrings("CS").ConnectionString
        _config = GetStarterConfig()

        _loader = New ModuleLoader()

        _dataRepo = New DataRepository(cs, _config)

        BindData()
        myDelegate = New AddListItem(AddressOf AddListItemMethod)
    End Sub

    Public Sub AddListItemMethod(ByVal args As DisplayMessageArgs)
        Dim item As New ColorListBoxItem()
        item.Message = args.Message
        Select Case (args.Severity)
            Case DisplayMessageSeverity.Debug
                item.ItemColor = Color.Black
            Case DisplayMessageSeverity.Errore
                item.ItemColor = Color.Red
            Case DisplayMessageSeverity.Info
                item.ItemColor = Color.Black
            Case DisplayMessageSeverity.Warning
                item.ItemColor = Color.Yellow
            Case Else
        End Select

        listMessage.Items.Add(item)

        Dim visibleItems = listMessage.ClientSize.Height / listMessage.ItemHeight

        listMessage.TopIndex = Math.Max(listMessage.Items.Count - visibleItems + 1, 0)
        'listMessage.TopIndex = listMessage.Items.Count - 1

        Dim lvi As ListViewItem = listViewMessage.Items.Add(DateTime.Now)
        lvi.ForeColor = item.ItemColor

        'If (item.Bold) Then
        '    Dim font = lvi.Font
        '    font = New Font(lvi.Font.FontFamily, lvi.Font.Size, FontStyle.Bold)
        '    lvi.Font = font
        'End If

        lvi.SubItems.Add(args.Severity.ToString())
        lvi.SubItems.Add(item.Message)


    End Sub 'AddListItemMethod

    Private Sub BindData()
        Dim lstAttivita As List(Of Attivita) = _dataRepo.GetAttivitaDaValidare()

        Dim list As New List(Of AttivitaTest)

        For Each atta As Attivita In lstAttivita

            Dim c As New AttivitaTest
            c.Attivita = atta

            list.Add(c)

        Next

        bsAttivita.DataSource = list

        DataGridView1.DataSource = bsAttivita

        bsAttivita.ResetBindings(False)
    End Sub

    Function GetStarterConfig() As StarterConfig
        Dim starter As New StarterConfig()
        starter.SevenZipDllPath = ConfigurationManager.AppSettings("7ZipLocation")
        starter.FtpFolderPath = ConfigurationManager.AppSettings("FtpFolderPath")
        starter.XsdFolderPath = ConfigurationManager.AppSettings("XsdFolderPath")
        starter.ResocontoPath = ConfigurationManager.AppSettings("ResocontoPath")
        starter.FormatiPath = ConfigurationManager.AppSettings("FormatiPath")
        Return starter
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        BindData()
    End Sub

    Delegate Sub AddListItem(ByVal myString As DisplayMessageArgs)
    Public myDelegate As AddListItem

    Private Sub DisplayMessage_Event(ByVal message As DisplayMessageArgs)

        listMessage.Invoke(Me.myDelegate, message)

    End Sub

    Dim Resizing As Boolean = False

    Private Sub ListViewSizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.SizeChanged
        Try


            If (Resizing = False) Then

                Resizing = True

                Dim listView = listViewMessage

                If (Not listView Is Nothing) Then

                    Dim totalColumnWidth As Double = 0

                    For i As Integer = 0 To listView.Columns.Count - 1
                        totalColumnWidth += Convert.ToInt32(listView.Columns(i).Tag)
                    Next
                    For i As Integer = 0 To listView.Columns.Count - 1
                        Dim colPercentage = (Convert.ToInt32(listView.Columns(i).Tag) / totalColumnWidth)
                        listView.Columns(i).Width = (colPercentage * listView.ClientRectangle.Width)
                    Next
                End If
                Resizing = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BackgroundWorkerExportDoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        

        'currentFlusso.Export(Nothing)
    End Sub

    Private Sub BackgroundWorkerDoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)

        Dim current As AttivitaTest = DirectCast(e.Argument, AttivitaTest)

        Dim startMessage As New DisplayMessageArgs
        startMessage.Message = String.Format("Inizio Validazione attività {0}", current.CodiceAttivita)
        startMessage.Severity = DisplayMessageSeverity.Info

        DisplayMessage_Event(startMessage)

        Dim configFlusso As FlussoModule = _loader.GetModule(current.Attivita.Flusso.ID)
        Dim fullNameDll As String = String.Empty
        Dim currentFlusso As IFlusso = _loader.LoadFlusso(configFlusso.Key, fullNameDll)
        AddHandler currentFlusso.DisplayMessage, AddressOf Me.DisplayMessage_Event
        currentFlusso.StarterConfig = _config

        Dim controllo As Controllo = _dataRepo.GetControllo(currentFlusso.ID, current.Attivita.Periodo.ID)

        If (Not controllo Is Nothing) Then
            currentFlusso.Controllo = controllo
            currentFlusso.Init()

            If (currentFlusso.Controlla(current.Attivita)) Then
                '_dataRepo.AggiornaAgenda(current.Attivita)
            End If
        Else
        End If

        Dim endMessage As New DisplayMessageArgs
        endMessage.Message = String.Format("Fine Validazione attività {0}", current.CodiceAttivita)
        startMessage.Severity = DisplayMessageSeverity.Info
        DisplayMessage_Event(endMessage)
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick

        If (e.ColumnIndex.Equals(0)) Then
            If (_backgroundWorker Is Nothing) Then
                _backgroundWorker = New BackgroundWorker()
                AddHandler _backgroundWorker.DoWork, AddressOf Me.BackgroundWorkerDoWork
            End If
            If (Not _backgroundWorker.IsBusy) Then

                Dim list As List(Of AttivitaTest) = DirectCast(bsAttivita.DataSource, List(Of AttivitaTest))
                Dim current As AttivitaTest = list(e.RowIndex)
                _backgroundWorker.RunWorkerAsync(current)
            End If
        End If
        If (e.ColumnIndex.Equals(1)) Then
            Dim list As List(Of AttivitaTest) = DirectCast(bsAttivita.DataSource, List(Of AttivitaTest))
            Dim current As AttivitaTest = list(e.RowIndex)
            ShowExportInputPanel(current)
        End If
    End Sub

    Private Sub ShowExportInputPanel(ByVal current As AttivitaTest)
        Dim configFlusso As FlussoModule = _loader.GetModule(current.Attivita.Flusso.ID)
        Dim fullNameDll As String = String.Empty
        Dim fullPath As String = String.Empty
        Dim name As String = String.Empty
        Dim currentFlusso As IExport = _loader.LoadExport(configFlusso.Key, fullNameDll, fullPath, name)

        Dim configType As Type = currentFlusso.ConfigType

        Dim list As New List(Of ExportParameter)

        For Each prop As PropertyInfo In configType.GetProperties()
            If (Attribute.IsDefined(prop, GetType(ExportFormParamAttribute))) Then
                Dim exp As New ExportParameter
                exp.PropertyName = prop.Name
                exp.Type = prop.PropertyType
                list.Add(exp)
            End If
        Next

        Dim exportInputPanel As New ExportInputModel(list)
        exportInputPanel.ShowDialog(Me)

    End Sub

    Private Sub listMessage_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles listMessage.DrawItem

        Dim item As ColorListBoxItem = listMessage.Items(e.Index)

        e.DrawBackground()

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(Brushes.LightGreen, e.Bounds)
        End If

        Using b As New SolidBrush(item.ItemColor)
            If (item.Bold) Then
                Dim font = e.Font
                font = New Font(e.Font.FontFamily, e.Font.Size, FontStyle.Bold)
                e.Graphics.DrawString(item.Message, font, b, e.Bounds)
            Else
                e.Graphics.DrawString(item.Message, e.Font, b, e.Bounds)

            End If

        End Using
        e.DrawFocusRectangle()



    End Sub
End Class

