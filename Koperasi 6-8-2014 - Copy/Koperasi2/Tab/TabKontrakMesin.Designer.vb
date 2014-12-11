<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TabKontrakMesin
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
        Me.txtFlag = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.gv1 = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFlag
        '
        Me.txtFlag.Location = New System.Drawing.Point(355, 354)
        Me.txtFlag.Name = "txtFlag"
        Me.txtFlag.Size = New System.Drawing.Size(110, 20)
        Me.txtFlag.TabIndex = 7
        Me.txtFlag.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-205, 221)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Filter"
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(237, 354)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(364, 20)
        Me.txtFilter.TabIndex = 5
        '
        'gv1
        '
        Me.gv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv1.Location = New System.Drawing.Point(12, 12)
        Me.gv1.Name = "gv1"
        Me.gv1.Size = New System.Drawing.Size(589, 336)
        Me.gv1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 357)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(214, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Filter No Aplikasi/Kontrak/Nama Pelanggan"
        '
        'TabKontrakMesin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 386)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFlag)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.gv1)
        Me.Name = "TabKontrakMesin"
        Me.Text = "Form List Kontrak"
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFlag As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents gv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
