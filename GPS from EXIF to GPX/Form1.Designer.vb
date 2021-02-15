<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Formulář přepisuje metodu Dispose, aby vyčistil seznam součástí.
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

    'Vyžadováno Návrhářem Windows Form
    Private components As System.ComponentModel.IContainer

    'POZNÁMKA: Následující procedura je vyžadována Návrhářem Windows Form
    'Může být upraveno pomocí Návrháře Windows Form.  
    'Neupravovat pomocí editoru kódu
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Filename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Latitude = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Longitude = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WaypointName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Delete = New System.Windows.Forms.Button()
        Me.Export = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowDrop = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Filename, Me.Latitude, Me.Longitude, Me.WaypointName})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(13, 13)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1033, 395)
        Me.DataGridView1.TabIndex = 8
        '
        'Filename
        '
        Me.Filename.HeaderText = "Filename"
        Me.Filename.MinimumWidth = 6
        Me.Filename.Name = "Filename"
        Me.Filename.Width = 200
        '
        'Latitude
        '
        Me.Latitude.HeaderText = "Latitude"
        Me.Latitude.MinimumWidth = 6
        Me.Latitude.Name = "Latitude"
        Me.Latitude.Width = 125
        '
        'Longitude
        '
        Me.Longitude.HeaderText = "Longitude"
        Me.Longitude.MinimumWidth = 6
        Me.Longitude.Name = "Longitude"
        Me.Longitude.Width = 125
        '
        'WaypointName
        '
        Me.WaypointName.HeaderText = "Waypoint name"
        Me.WaypointName.MinimumWidth = 6
        Me.WaypointName.Name = "WaypointName"
        Me.WaypointName.Width = 300
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(1054, 13)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(533, 492)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Delete
        '
        Me.Delete.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Delete.Location = New System.Drawing.Point(790, 416)
        Me.Delete.Margin = New System.Windows.Forms.Padding(4)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(256, 89)
        Me.Delete.TabIndex = 10
        Me.Delete.Text = "Delete selected row"
        Me.Delete.UseVisualStyleBackColor = True
        '
        'Export
        '
        Me.Export.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Export.Location = New System.Drawing.Point(526, 416)
        Me.Export.Margin = New System.Windows.Forms.Padding(4)
        Me.Export.Name = "Export"
        Me.Export.Size = New System.Drawing.Size(256, 89)
        Me.Export.TabIndex = 11
        Me.Export.Text = "Export GPX file"
        Me.Export.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1600, 519)
        Me.Controls.Add(Me.Export)
        Me.Controls.Add(Me.Delete)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form1"
        Me.Text = "GPS location from EXIF info to GPX file"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Filename As DataGridViewTextBoxColumn
    Friend WithEvents Latitude As DataGridViewTextBoxColumn
    Friend WithEvents Longitude As DataGridViewTextBoxColumn
    Friend WithEvents WaypointName As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Delete As Button
    Friend WithEvents Export As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
