<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTabMem
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
        Me.gridMember = New System.Windows.Forms.DataGridView
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.txtFlag = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.gridMember, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridMember
        '
        Me.gridMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridMember.Location = New System.Drawing.Point(36, 30)
        Me.gridMember.Name = "gridMember"
        Me.gridMember.Size = New System.Drawing.Size(839, 149)
        Me.gridMember.TabIndex = 0
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(205, 189)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(391, 20)
        Me.txtFilter.TabIndex = 1
        '
        'txtFlag
        '
        Me.txtFlag.Location = New System.Drawing.Point(40, 223)
        Me.txtFlag.Name = "txtFlag"
        Me.txtFlag.Size = New System.Drawing.Size(102, 20)
        Me.txtFlag.TabIndex = 2
        Me.txtFlag.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Filter Nama Member / No KTP"
        '
        'frmTabMem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 265)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFlag)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.gridMember)
        Me.Name = "frmTabMem"
        Me.Text = "Daftar Member"
        CType(Me.gridMember, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridMember As System.Windows.Forms.DataGridView
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents txtFlag As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
