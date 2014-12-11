<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPencairanCash
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
        Me.lblInfo = New System.Windows.Forms.Label
        Me.txtSaldo = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNominal = New System.Windows.Forms.TextBox
        Me.dtTanggal = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.lblInfo.Location = New System.Drawing.Point(34, 96)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(39, 13)
        Me.lblInfo.TabIndex = 23
        Me.lblInfo.Text = "Label4"
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(122, 45)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(121, 20)
        Me.txtSaldo.TabIndex = 22
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(92, 118)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Proses"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Cash Dicairkan"
        '
        'txtNominal
        '
        Me.txtNominal.Location = New System.Drawing.Point(122, 71)
        Me.txtNominal.Name = "txtNominal"
        Me.txtNominal.Size = New System.Drawing.Size(121, 20)
        Me.txtNominal.TabIndex = 19
        '
        'dtTanggal
        '
        Me.dtTanggal.Location = New System.Drawing.Point(122, 19)
        Me.dtTanggal.Name = "dtTanggal"
        Me.dtTanggal.Size = New System.Drawing.Size(121, 20)
        Me.dtTanggal.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Tanggal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Nominal Tersedia"
        '
        'frmPencairanCash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 174)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.txtSaldo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNominal)
        Me.Controls.Add(Me.dtTanggal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmPencairanCash"
        Me.Text = "Pencairan Cash"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNominal As System.Windows.Forms.TextBox
    Friend WithEvents dtTanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
