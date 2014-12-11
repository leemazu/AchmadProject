<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTabKontrak
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
        Me.gv1 = New System.Windows.Forms.DataGridView
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFlag = New System.Windows.Forms.TextBox
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gv1
        '
        Me.gv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv1.Location = New System.Drawing.Point(16, 18)
        Me.gv1.Name = "gv1"
        Me.gv1.Size = New System.Drawing.Size(1000, 328)
        Me.gv1.TabIndex = 0
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(215, 353)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(385, 20)
        Me.txtFilter.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 356)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filter Nomor Kontrak / Nama Konsumen"
        '
        'txtFlag
        '
        Me.txtFlag.Location = New System.Drawing.Point(773, 356)
        Me.txtFlag.Name = "txtFlag"
        Me.txtFlag.Size = New System.Drawing.Size(110, 20)
        Me.txtFlag.TabIndex = 3
        Me.txtFlag.Visible = False
        '
        'frmTabKontrak
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 384)
        Me.Controls.Add(Me.txtFlag)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.gv1)
        Me.Name = "frmTabKontrak"
        Me.Text = "Tabel List Kontrak"
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gv1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFlag As System.Windows.Forms.TextBox
End Class
