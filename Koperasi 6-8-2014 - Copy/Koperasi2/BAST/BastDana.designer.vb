<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BastDana
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCari = New System.Windows.Forms.TextBox
        Me.gv1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtMesin = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtRangka = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtNoPol = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTahun = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtWarna = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtTipe = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtMotor = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtModal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAngsuran = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTenor = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPinjaman = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtPem = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPemNama = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtAplikasi = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbBpkb = New System.Windows.Forms.ComboBox
        Me.txtBpkb = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.dtAngsuran = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtBast = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtKontrak = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.dtKontrak = New System.Windows.Forms.DateTimePicker
        Me.txtBungaPengali = New System.Windows.Forms.TextBox
        Me.txtPokok = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cmbCollector = New System.Windows.Forms.ComboBox
        Me.txtEffectiveInterest = New System.Windows.Forms.TextBox
        Me.txtBunga = New System.Windows.Forms.TextBox
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cari (No.Aplikasi / Konsumen )"
        '
        'txtCari
        '
        Me.txtCari.Location = New System.Drawing.Point(172, 10)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(564, 20)
        Me.txtCari.TabIndex = 1
        '
        'gv1
        '
        Me.gv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv1.Location = New System.Drawing.Point(18, 36)
        Me.gv1.Name = "gv1"
        Me.gv1.Size = New System.Drawing.Size(716, 192)
        Me.gv1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMesin)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtRangka)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtNoPol)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtTahun)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtWarna)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtTipe)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtMotor)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtModal)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtAngsuran)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtTenor)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtPinjaman)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtPem)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPemNama)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtAplikasi)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 234)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(714, 151)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Aplikasi"
        '
        'txtMesin
        '
        Me.txtMesin.Enabled = False
        Me.txtMesin.Location = New System.Drawing.Point(383, 84)
        Me.txtMesin.MaxLength = 20
        Me.txtMesin.Name = "txtMesin"
        Me.txtMesin.Size = New System.Drawing.Size(102, 20)
        Me.txtMesin.TabIndex = 27
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(311, 87)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 13)
        Me.Label19.TabIndex = 26
        Me.Label19.Text = "No.Mesin"
        '
        'txtRangka
        '
        Me.txtRangka.Enabled = False
        Me.txtRangka.Location = New System.Drawing.Point(87, 81)
        Me.txtRangka.MaxLength = 20
        Me.txtRangka.Name = "txtRangka"
        Me.txtRangka.Size = New System.Drawing.Size(218, 20)
        Me.txtRangka.TabIndex = 25
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(15, 84)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 13)
        Me.Label18.TabIndex = 24
        Me.Label18.Text = "No. Rangka"
        '
        'txtNoPol
        '
        Me.txtNoPol.Enabled = False
        Me.txtNoPol.Location = New System.Drawing.Point(621, 55)
        Me.txtNoPol.MaxLength = 10
        Me.txtNoPol.Name = "txtNoPol"
        Me.txtNoPol.Size = New System.Drawing.Size(87, 20)
        Me.txtNoPol.TabIndex = 23
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(564, 58)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 13)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "No. Polisi"
        '
        'txtTahun
        '
        Me.txtTahun.Enabled = False
        Me.txtTahun.Location = New System.Drawing.Point(517, 55)
        Me.txtTahun.MaxLength = 4
        Me.txtTahun.Name = "txtTahun"
        Me.txtTahun.Size = New System.Drawing.Size(41, 20)
        Me.txtTahun.TabIndex = 21
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(473, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 13)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "Tahun"
        '
        'txtWarna
        '
        Me.txtWarna.Enabled = False
        Me.txtWarna.Location = New System.Drawing.Point(401, 55)
        Me.txtWarna.MaxLength = 10
        Me.txtWarna.Name = "txtWarna"
        Me.txtWarna.Size = New System.Drawing.Size(62, 20)
        Me.txtWarna.TabIndex = 19
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(356, 58)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Warna"
        '
        'txtTipe
        '
        Me.txtTipe.Enabled = False
        Me.txtTipe.Location = New System.Drawing.Point(255, 55)
        Me.txtTipe.MaxLength = 15
        Me.txtTipe.Name = "txtTipe"
        Me.txtTipe.Size = New System.Drawing.Size(86, 20)
        Me.txtTipe.TabIndex = 17
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(183, 58)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Tipe Motor"
        '
        'txtMotor
        '
        Me.txtMotor.Enabled = False
        Me.txtMotor.Location = New System.Drawing.Point(87, 55)
        Me.txtMotor.MaxLength = 15
        Me.txtMotor.Name = "txtMotor"
        Me.txtMotor.Size = New System.Drawing.Size(85, 20)
        Me.txtMotor.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Merk Motor"
        '
        'txtModal
        '
        Me.txtModal.Enabled = False
        Me.txtModal.Location = New System.Drawing.Point(556, 112)
        Me.txtModal.MaxLength = 12
        Me.txtModal.Name = "txtModal"
        Me.txtModal.Size = New System.Drawing.Size(127, 20)
        Me.txtModal.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(500, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Modal"
        '
        'txtAngsuran
        '
        Me.txtAngsuran.Enabled = False
        Me.txtAngsuran.Location = New System.Drawing.Point(390, 112)
        Me.txtAngsuran.MaxLength = 12
        Me.txtAngsuran.Name = "txtAngsuran"
        Me.txtAngsuran.Size = New System.Drawing.Size(95, 20)
        Me.txtAngsuran.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(324, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Angsuran"
        '
        'txtTenor
        '
        Me.txtTenor.Enabled = False
        Me.txtTenor.Location = New System.Drawing.Point(272, 112)
        Me.txtTenor.MaxLength = 3
        Me.txtTenor.Name = "txtTenor"
        Me.txtTenor.Size = New System.Drawing.Size(46, 20)
        Me.txtTenor.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(199, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Tenor(bulan)"
        '
        'txtPinjaman
        '
        Me.txtPinjaman.Enabled = False
        Me.txtPinjaman.Location = New System.Drawing.Point(86, 112)
        Me.txtPinjaman.MaxLength = 12
        Me.txtPinjaman.Name = "txtPinjaman"
        Me.txtPinjaman.Size = New System.Drawing.Size(107, 20)
        Me.txtPinjaman.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Pinjaman"
        '
        'dtPem
        '
        Me.dtPem.Enabled = False
        Me.dtPem.Location = New System.Drawing.Point(556, 22)
        Me.dtPem.Name = "dtPem"
        Me.dtPem.Size = New System.Drawing.Size(152, 20)
        Me.dtPem.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(486, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tanggal Lahir"
        '
        'txtPemNama
        '
        Me.txtPemNama.Enabled = False
        Me.txtPemNama.Location = New System.Drawing.Point(333, 22)
        Me.txtPemNama.Name = "txtPemNama"
        Me.txtPemNama.Size = New System.Drawing.Size(147, 20)
        Me.txtPemNama.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(239, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nama Konsumen"
        '
        'txtAplikasi
        '
        Me.txtAplikasi.Enabled = False
        Me.txtAplikasi.Location = New System.Drawing.Point(86, 25)
        Me.txtAplikasi.MaxLength = 11
        Me.txtAplikasi.Name = "txtAplikasi"
        Me.txtAplikasi.Size = New System.Drawing.Size(147, 20)
        Me.txtAplikasi.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "No.Aplikasi"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbBpkb)
        Me.GroupBox2.Controls.Add(Me.txtBpkb)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.dtAngsuran)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.dtBast)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 391)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(714, 58)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'cmbBpkb
        '
        Me.cmbBpkb.FormattingEnabled = True
        Me.cmbBpkb.Location = New System.Drawing.Point(82, 26)
        Me.cmbBpkb.Name = "cmbBpkb"
        Me.cmbBpkb.Size = New System.Drawing.Size(90, 21)
        Me.cmbBpkb.TabIndex = 15
        '
        'txtBpkb
        '
        Me.txtBpkb.Location = New System.Drawing.Point(228, 25)
        Me.txtBpkb.MaxLength = 18
        Me.txtBpkb.Name = "txtBpkb"
        Me.txtBpkb.Size = New System.Drawing.Size(118, 20)
        Me.txtBpkb.TabIndex = 14
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(178, 29)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 13)
        Me.Label21.TabIndex = 12
        Me.Label21.Text = "No.BPKB"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(4, 28)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(68, 13)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Status BPKB"
        '
        'dtAngsuran
        '
        Me.dtAngsuran.Location = New System.Drawing.Point(606, 22)
        Me.dtAngsuran.Name = "dtAngsuran"
        Me.dtAngsuran.Size = New System.Drawing.Size(102, 20)
        Me.dtAngsuran.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(523, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Angsuran Ke-1"
        '
        'dtBast
        '
        Me.dtBast.Location = New System.Drawing.Point(432, 22)
        Me.dtBast.Name = "dtBast"
        Me.dtBast.Size = New System.Drawing.Size(85, 20)
        Me.dtBast.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(349, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Tanggal BAST"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(256, 458)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Tanggal Kontrak"
        '
        'txtKontrak
        '
        Me.txtKontrak.Location = New System.Drawing.Point(101, 452)
        Me.txtKontrak.MaxLength = 12
        Me.txtKontrak.Name = "txtKontrak"
        Me.txtKontrak.Size = New System.Drawing.Size(147, 20)
        Me.txtKontrak.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 458)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Nomor Kontrak"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(520, 455)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 26)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Proses"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(609, 454)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(73, 29)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Batal"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dtKontrak
        '
        Me.dtKontrak.Location = New System.Drawing.Point(345, 451)
        Me.dtKontrak.Name = "dtKontrak"
        Me.dtKontrak.Size = New System.Drawing.Size(152, 20)
        Me.dtKontrak.TabIndex = 11
        '
        'txtBungaPengali
        '
        Me.txtBungaPengali.Location = New System.Drawing.Point(585, 500)
        Me.txtBungaPengali.Name = "txtBungaPengali"
        Me.txtBungaPengali.Size = New System.Drawing.Size(77, 20)
        Me.txtBungaPengali.TabIndex = 12
        Me.txtBungaPengali.Visible = False
        '
        'txtPokok
        '
        Me.txtPokok.Location = New System.Drawing.Point(668, 500)
        Me.txtPokok.Name = "txtPokok"
        Me.txtPokok.Size = New System.Drawing.Size(77, 20)
        Me.txtPokok.TabIndex = 13
        Me.txtPokok.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(17, 485)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 13)
        Me.Label22.TabIndex = 14
        Me.Label22.Text = "Nama Kolektor"
        '
        'cmbCollector
        '
        Me.cmbCollector.FormattingEnabled = True
        Me.cmbCollector.Location = New System.Drawing.Point(101, 482)
        Me.cmbCollector.Name = "cmbCollector"
        Me.cmbCollector.Size = New System.Drawing.Size(142, 21)
        Me.cmbCollector.TabIndex = 15
        '
        'txtEffectiveInterest
        '
        Me.txtEffectiveInterest.Location = New System.Drawing.Point(494, 500)
        Me.txtEffectiveInterest.Name = "txtEffectiveInterest"
        Me.txtEffectiveInterest.Size = New System.Drawing.Size(77, 20)
        Me.txtEffectiveInterest.TabIndex = 16
        Me.txtEffectiveInterest.Visible = False
        '
        'txtBunga
        '
        Me.txtBunga.Location = New System.Drawing.Point(401, 500)
        Me.txtBunga.Name = "txtBunga"
        Me.txtBunga.Size = New System.Drawing.Size(77, 20)
        Me.txtBunga.TabIndex = 17
        Me.txtBunga.Visible = False
        '
        'BastDana
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 532)
        Me.Controls.Add(Me.txtBunga)
        Me.Controls.Add(Me.txtEffectiveInterest)
        Me.Controls.Add(Me.cmbCollector)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtPokok)
        Me.Controls.Add(Me.txtBungaPengali)
        Me.Controls.Add(Me.dtKontrak)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtKontrak)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gv1)
        Me.Controls.Add(Me.txtCari)
        Me.Controls.Add(Me.Label1)
        Me.Name = "BastDana"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BAST Dana Tunai"
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCari As System.Windows.Forms.TextBox
    Friend WithEvents gv1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtModal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAngsuran As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTenor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPinjaman As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtPem As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPemNama As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAplikasi As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtAngsuran As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtBast As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtKontrak As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dtKontrak As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNoPol As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTahun As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtWarna As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTipe As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMotor As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtMesin As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtRangka As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbBpkb As System.Windows.Forms.ComboBox
    Friend WithEvents txtBpkb As System.Windows.Forms.TextBox
    Friend WithEvents txtBungaPengali As System.Windows.Forms.TextBox
    Friend WithEvents txtPokok As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbCollector As System.Windows.Forms.ComboBox
    Friend WithEvents txtEffectiveInterest As System.Windows.Forms.TextBox
    Friend WithEvents txtBunga As System.Windows.Forms.TextBox
End Class
