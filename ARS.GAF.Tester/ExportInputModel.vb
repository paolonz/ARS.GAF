Imports ARS.GAF.Core

Public Class ExportInputModel

    Private _list As List(Of ExportParameter)

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(ByVal list As List(Of ExportParameter))
        InitializeComponent()
        _list = list
        GenerateForm()
    End Sub

    Private Sub GenerateForm()
        Dim x As Integer = 10
        Dim y As Integer = 10
        For Each param As ExportParameter In _list
            Dim label As New Label
            label.Name = String.Format("lbl_{0}", param.PropertyName)
            label.Location = New Point(x, y)
            label.Text = param.PropertyName

            Controls.Add(label)

            Select Case param.Type.ToString()
                Case GetType(DateTime).ToString()
                    Dim datePicker As New DateTimePicker()
                    datePicker.Name = param.PropertyName
                    datePicker.Size = New Size(200, 30)
                    datePicker.Location = New Point(x + 150, y)
                    Controls.Add(datePicker)
                Case GetType(String).ToString()
                    Dim txt As New TextBox
                    txt.Name = param.PropertyName
                    txt.Size = New Size(200, 30)
                    txt.Location = New Point(x + 150, y)
                    Controls.Add(txt)
                Case Else
            End Select
            y = y + 40
        Next

        Dim btn As New Button()
        btn.Name = "btnExport"
        btn.Text = "Avvia esportazione"
        btn.Size = New Size(350, 30)
        btn.Location = New Point(25, y)

        Controls.Add(btn)

        Me.Size = New Size(400, y + 100)
    End Sub

End Class