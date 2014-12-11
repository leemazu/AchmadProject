<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PelunasanAsuransi
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtHidden = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtObjek = New System.Windows.Forms.TextBox
        Me.txtBulan = New System.Windows.Forms.TextBox
        Me.txtTenor = New System.Windows.Forms.TextBox
        Me.txtTipe = New System.Windows.Forms.TextBox
        Me.txtMesin = New System.Windows.Forms.TextBox
        Me.txtAlamat = New System.Windows.Forms.TextBox
        Me.txtKonsumen = New System.Windows.Forms.TextBox
        Me.txtKontrak = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Aktif", "Pelunasan Normal"})
        Me.ComboBox1.Location = New System.Drawing.Point(417, 135)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 93
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(321, 141)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 92
        Me.Label11.Text = "Status Kontrak"
        '
        'txtHidden
        '
        Me.txtHidden.Location = New System.Drawing.Point(650, 12)
        Me.txtHidden.MaxLength = 12
        Me.txtHidden.Name = "txtHidden"
        Me.txtHidden.Size = New System.Drawing.Size(122, 20)
        Me.txtHidden.TabIndex = 91
        Me.txtHidden.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(270, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 21)
        Me.Button2.TabIndex = 90
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtObjek
        '
        Me.txtObjek.Enabled = False
        Me.txtObjek.Location = New System.Drawing.Point(138, 138)
        Me.txtObjek.Name = "txtObjek"
        Me.txtObjek.Size = New System.Drawing.Size(153, 20)
        Me.txtObjek.TabIndex = 89
        '
        'txtBulan
        '
        Me.txtBulan.Enabled = False
        Me.txtBulan.Location = New System.Drawing.Point(417, 106)
        Me.txtBulan.Name = "txtBulan"
        Me.txtBulan.Size = New System.Drawing.Size(153, 20)
        Me.txtBulan.TabIndex = 88
        '
        'txtTenor
        '
        Me.txtTenor.Enabled = False
        Me.txtTenor.Location = New System.Drawing.Point(417, 70)
        Me.txtTenor.Name = "txtTenor"
        Me.txtTenor.Size = New System.Drawing.Size(153, 20)
        Me.txtTenor.TabIndex = 87
        '
        'txtTipe
        '
        Me.txtTipe.Enabled = False
        Me.txtTipe.Location = New System.Drawing.Point(417, 44)
        Me.txtTipe.Name = "txtTipe"
        Me.txtTipe.Size = New System.Drawing.Size(153, 20)
        Me.txtTipe.TabIndex = 86
        '
        'txtMesin
        '
        Me.txtMesin.Enabled = False
        Me.txtMesin.Location = New System.Drawing.Point(417, 12)
        Me.txtMesin.Name = "txtMesin"
        Me.txtMesin.Size = New System.Drawing.Size(153, 20)
        Me.txtMesin.TabIndex = 85
        '
        'txtAlamat
        '
        Me.txtAlamat.Enabled = False
        Me.txtAlamat.Location = New System.Drawing.Point(138, 67)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(153, 59)
        Me.txtAlamat.TabIndex = 84
        '
        'txtKonsumen
        '
        Me.txtKonsumen.Enabled = False
        Me.txtKonsumen.Location = New System.Drawing.Point(138, 41)
        Me.txtKonsumen.Name = "txtKonsumen"
        Me.txtKonsumen.Size = New System.Drawing.Size(153, 20)
        Me.txtKonsumen.TabIndex = 83
        '
        'txtKontrak
        '
        Me.txtKontrak.Location = New System.Drawing.Point(138, 12)
        Me.txtKontrak.MaxLength = 12
        Me.txtKontrak.Name = "txtKontrak"
        Me.txtKontrak.Size = New System.Drawing.Size(122, 20)
        Me.txtKontrak.TabIndex = 82
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(5, 138)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 13)
        Me.Label16.TabIndex = 81
        Me.Label16.Text = "Objek"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(335, 109)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 13)
        Me.Label15.TabIndex = 80
        Me.Label15.Text = "Bulan Booking"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(342, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Tenor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(342, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Tipe"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(342, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "No.Mesin"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Alamat"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Nama Konsumen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "No Kontrak"
        '
        'PelunasanAsuransi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 262)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtHidden)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtObjek)
        Me.Controls.Add(Me.txtBulan)
        Me.Controls.Add(Me.txtTenor)
        Me.Controls.Add(Me.txtTipe)
        Me.Controls.Add(Me.txtMesin)
        Me.Controls.Add(Me.txtAlamat)
        Me.Controls.Add(Me.txtKonsumen)
        Me.Controls.Add(Me.txtKontrak)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PelunasanAsuransi"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtHidden As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtObjek As System.Windows.Forms.TextBox
    Friend WithEvents txtBulan As System.Windows.Forms.TextBox
    Friend WithEvents txtTenor As System.Windows.Forms.TextBox
    Friend WithEvents txtTipe As System.Windows.Forms.TextBox
    Friend WithEvents txtMesin As System.Windows.Forms.TextBox
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents txtKonsumen As System.Windows.Forms.TextBox
    Friend WithEvents txtKontrak As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
