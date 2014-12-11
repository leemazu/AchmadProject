<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPenambahanModal
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtTgl = New System.Windows.Forms.DateTimePicker
        Me.txtNominal = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.lblInfo = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tanggal"
        '
        'dtTgl
        '
        Me.dtTgl.Location = New System.Drawing.Point(110, 34)
        Me.dtTgl.Name = "dtTgl"
        Me.dtTgl.Size = New System.Drawing.Size(121, 20)
        Me.dtTgl.TabIndex = 3
        '
        'txtNominal
        '
        Me.txtNominal.Location = New System.Drawing.Point(110, 60)
        Me.txtNominal.Name = "txtNominal"
        Me.txtNominal.Size = New System.Drawing.Size(121, 20)
        Me.txtNominal.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Nominal"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(100, 111)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Proses"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.lblInfo.Location = New System.Drawing.Point(107, 89)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(39, 13)
        Me.lblInfo.TabIndex = 7
        Me.lblInfo.Text = "Label1"
        '
        'frmPenambahanModal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 173)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNominal)
        Me.Controls.Add(Me.dtTgl)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmPenambahanModal"
        Me.Text = "Penambahan Modal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtTgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNominal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblInfo As System.Windows.Forms.Label
End Class
