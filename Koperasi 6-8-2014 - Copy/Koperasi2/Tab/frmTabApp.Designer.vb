<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTabApp
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
        Me.gridApplication = New System.Windows.Forms.DataGridView
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.txtFlag = New System.Windows.Forms.TextBox
        CType(Me.gridApplication, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridApplication
        '
        Me.gridApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridApplication.Location = New System.Drawing.Point(30, 19)
        Me.gridApplication.Name = "gridApplication"
        Me.gridApplication.Size = New System.Drawing.Size(805, 150)
        Me.gridApplication.TabIndex = 0
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(30, 185)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(570, 20)
        Me.txtFilter.TabIndex = 1
        '
        'txtFlag
        '
        Me.txtFlag.Location = New System.Drawing.Point(37, 227)
        Me.txtFlag.Name = "txtFlag"
        Me.txtFlag.Size = New System.Drawing.Size(117, 20)
        Me.txtFlag.TabIndex = 2
        Me.txtFlag.Visible = False
        '
        'frmTabApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 262)
        Me.Controls.Add(Me.txtFlag)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.gridApplication)
        Me.Name = "frmTabApp"
        Me.Text = "Form2"
        CType(Me.gridApplication, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridApplication As System.Windows.Forms.DataGridView
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents txtFlag As System.Windows.Forms.TextBox
End Class
