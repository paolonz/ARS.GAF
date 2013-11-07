<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.listMessage = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.listViewMessage = New System.Windows.Forms.ListView()
        Me.ColumnDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnSeverity = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnMessage = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.bsAttivita = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColumnValida = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ColumnCodiceAttivita = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnNomeFlusso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnReferente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnDataCaricamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExportData = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsAttivita, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(683, 4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(91, 36)
        Me.btnRefresh.TabIndex = 0
        Me.btnRefresh.Text = "Aggiorna"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(792, 47)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Attivita da validare"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(792, 47)
        Me.Panel1.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnValida, Me.ColumnCodiceAttivita, Me.ColumnNomeFlusso, Me.ColumnReferente, Me.ColumnDataCaricamento, Me.ExportData})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 47)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 50
        Me.DataGridView1.Size = New System.Drawing.Size(792, 329)
        Me.DataGridView1.TabIndex = 3
        '
        'listMessage
        '
        Me.listMessage.Dock = System.Windows.Forms.DockStyle.Top
        Me.listMessage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listMessage.FormattingEnabled = True
        Me.listMessage.ItemHeight = 20
        Me.listMessage.Location = New System.Drawing.Point(0, 423)
        Me.listMessage.Name = "listMessage"
        Me.listMessage.Size = New System.Drawing.Size(792, 64)
        Me.listMessage.TabIndex = 4
        Me.listMessage.Visible = False
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 376)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(792, 47)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Risultati validazione"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'listViewMessage
        '
        Me.listViewMessage.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnDate, Me.ColumnSeverity, Me.ColumnMessage})
        Me.listViewMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewMessage.Location = New System.Drawing.Point(0, 487)
        Me.listViewMessage.Name = "listViewMessage"
        Me.listViewMessage.Size = New System.Drawing.Size(792, 86)
        Me.listViewMessage.TabIndex = 6
        Me.listViewMessage.UseCompatibleStateImageBehavior = False
        Me.listViewMessage.View = System.Windows.Forms.View.Details
        '
        'ColumnDate
        '
        Me.ColumnDate.Tag = "1"
        Me.ColumnDate.Text = "Data"
        Me.ColumnDate.Width = 100
        '
        'ColumnSeverity
        '
        Me.ColumnSeverity.Tag = "1"
        Me.ColumnSeverity.Text = "Tipologia"
        Me.ColumnSeverity.Width = 100
        '
        'ColumnMessage
        '
        Me.ColumnMessage.Tag = "10"
        Me.ColumnMessage.Text = "Messaggio"
        Me.ColumnMessage.Width = 90
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.ARS.GAF.Tester.My.Resources.Resources.start_256
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.DataGridViewImageColumn1.MinimumWidth = 50
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 50
        '
        'ColumnValida
        '
        Me.ColumnValida.HeaderText = ""
        Me.ColumnValida.Image = Global.ARS.GAF.Tester.My.Resources.Resources.start_256
        Me.ColumnValida.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.ColumnValida.MinimumWidth = 50
        Me.ColumnValida.Name = "ColumnValida"
        Me.ColumnValida.ReadOnly = True
        Me.ColumnValida.Width = 50
        '
        'ColumnCodiceAttivita
        '
        Me.ColumnCodiceAttivita.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColumnCodiceAttivita.DataPropertyName = "CodiceAttivita"
        Me.ColumnCodiceAttivita.FillWeight = 10.0!
        Me.ColumnCodiceAttivita.HeaderText = "Codice Attivita"
        Me.ColumnCodiceAttivita.MinimumWidth = 50
        Me.ColumnCodiceAttivita.Name = "ColumnCodiceAttivita"
        Me.ColumnCodiceAttivita.ReadOnly = True
        '
        'ColumnNomeFlusso
        '
        Me.ColumnNomeFlusso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColumnNomeFlusso.DataPropertyName = "Flusso"
        Me.ColumnNomeFlusso.FillWeight = 10.0!
        Me.ColumnNomeFlusso.HeaderText = "Flusso"
        Me.ColumnNomeFlusso.MinimumWidth = 50
        Me.ColumnNomeFlusso.Name = "ColumnNomeFlusso"
        Me.ColumnNomeFlusso.ReadOnly = True
        '
        'ColumnReferente
        '
        Me.ColumnReferente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColumnReferente.DataPropertyName = "Referente"
        Me.ColumnReferente.FillWeight = 10.0!
        Me.ColumnReferente.HeaderText = "Referente"
        Me.ColumnReferente.MinimumWidth = 50
        Me.ColumnReferente.Name = "ColumnReferente"
        Me.ColumnReferente.ReadOnly = True
        '
        'ColumnDataCaricamento
        '
        Me.ColumnDataCaricamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColumnDataCaricamento.DataPropertyName = "DataCaricamento"
        Me.ColumnDataCaricamento.FillWeight = 10.0!
        Me.ColumnDataCaricamento.HeaderText = "Data Caricamento"
        Me.ColumnDataCaricamento.MinimumWidth = 50
        Me.ColumnDataCaricamento.Name = "ColumnDataCaricamento"
        Me.ColumnDataCaricamento.ReadOnly = True
        '
        'ExportData
        '
        Me.ExportData.HeaderText = "ExportData"
        Me.ExportData.Name = "ExportData"
        Me.ExportData.ReadOnly = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.listViewMessage)
        Me.Controls.Add(Me.listMessage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "GAF - Validazione Attività"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsAttivita, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents bsAttivita As System.Windows.Forms.BindingSource
    Friend WithEvents listMessage As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents listViewMessage As System.Windows.Forms.ListView
    Friend WithEvents ColumnDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnSeverity As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnMessage As System.Windows.Forms.ColumnHeader
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ColumnValida As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ColumnCodiceAttivita As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnNomeFlusso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnReferente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnDataCaricamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExportData As System.Windows.Forms.DataGridViewButtonColumn

End Class
