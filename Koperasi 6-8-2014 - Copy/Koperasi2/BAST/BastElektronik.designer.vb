<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BastElektronik
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
        Me.dtPem = New System.Windows.Forms.DateTimePicker
        Me.txtModal = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtAngsuran = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTenor = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtHarga = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtKeterangan = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtNoSeri = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtBarang = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPemNama = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtAplikasi = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtAngsuran = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtBast = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtKontrak = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnProcess = New System.Windows.Forms.Button
        Me.btnReject = New System.Windows.Forms.Button
        Me.dtKontrak = New System.Windows.Forms.DateTimePicker
        Me.cmbCollector = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
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
        Me.GroupBox1.Controls.Add(Me.dtPem)
        Me.GroupBox1.Controls.Add(Me.txtModal)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtAngsuran)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtTenor)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtHarga)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtKeterangan)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtNoSeri)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtBarang)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPemNama)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtAplikasi)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 234)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(714, 161)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Aplikasi"
        '
        'dtPem
        '
        Me.dtPem.Enabled = False
        Me.dtPem.Location = New System.Drawing.Point(562, 23)
        Me.dtPem.Name = "dtPem"
        Me.dtPem.Size = New System.Drawing.Size(146, 20)
        Me.dtPem.TabIndex = 20
        '
        'txtModal
        '
        Me.txtModal.Enabled = False
        Me.txtModal.Location = New System.Drawing.Point(556, 125)
        Me.txtModal.Name = "txtModal"
        Me.txtModal.Size = New System.Drawing.Size(127, 20)
        Me.txtModal.TabIndex = 19
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(514, 131)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Modal"
        '
        'txtAngsuran
        '
        Me.txtAngsuran.Enabled = False
        Me.txtAngsuran.Location = New System.Drawing.Point(401, 128)
        Me.txtAngsuran.Name = "txtAngsuran"
        Me.txtAngsuran.Size = New System.Drawing.Size(98, 20)
        Me.txtAngsuran.TabIndex = 17
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(343, 132)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Angsuran"
        '
        'txtTenor
        '
        Me.txtTenor.Enabled = False
        Me.txtTenor.Location = New System.Drawing.Point(292, 128)
        Me.txtTenor.Name = "txtTenor"
        Me.txtTenor.Size = New System.Drawing.Size(35, 20)
        Me.txtTenor.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(219, 131)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Tenor(bulan)"
        '
        'txtHarga
        '
        Me.txtHarga.Enabled = False
        Me.txtHarga.Location = New System.Drawing.Point(86, 128)
        Me.txtHarga.Name = "txtHarga"
        Me.txtHarga.Size = New System.Drawing.Size(127, 20)
        Me.txtHarga.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Harga Barang"
        '
        'txtKeterangan
        '
        Me.txtKeterangan.Enabled = False
        Me.txtKeterangan.Location = New System.Drawing.Point(333, 66)
        Me.txtKeterangan.Multiline = True
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(375, 45)
        Me.txtKeterangan.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(239, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Keterangan"
        '
        'txtNoSeri
        '
        Me.txtNoSeri.Enabled = False
        Me.txtNoSeri.Location = New System.Drawing.Point(87, 91)
        Me.txtNoSeri.Name = "txtNoSeri"
        Me.txtNoSeri.Size = New System.Drawing.Size(146, 20)
        Me.txtNoSeri.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Nomor Seri"
        '
        'txtBarang
        '
        Me.txtBarang.Enabled = False
        Me.txtBarang.Location = New System.Drawing.Point(86, 62)
        Me.txtBarang.Name = "txtBarang"
        Me.txtBarang.Size = New System.Drawing.Size(147, 20)
        Me.txtBarang.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Nama Barang"
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
        Me.GroupBox2.Controls.Add(Me.dtAngsuran)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.dtBast)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 401)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(715, 58)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'dtAngsuran
        '
        Me.dtAngsuran.Location = New System.Drawing.Point(383, 16)
        Me.dtAngsuran.Name = "dtAngsuran"
        Me.dtAngsuran.Size = New System.Drawing.Size(152, 20)
        Me.dtAngsuran.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(286, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Angsuran Ke-1"
        '
        'dtBast
        '
        Me.dtBast.Location = New System.Drawing.Point(87, 19)
        Me.dtBast.Name = "dtBast"
        Me.dtBast.Size = New System.Drawing.Size(152, 20)
        Me.dtBast.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Tanggal BAST"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(256, 468)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Tanggal Kontrak"
        '
        'txtKontrak
        '
        Me.txtKontrak.Location = New System.Drawing.Point(101, 462)
        Me.txtKontrak.Name = "txtKontrak"
        Me.txtKontrak.Size = New System.Drawing.Size(147, 20)
        Me.txtKontrak.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 468)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Nomor Kontrak"
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(520, 465)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(73, 26)
        Me.btnProcess.TabIndex = 9
        Me.btnProcess.Text = "Proses"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'btnReject
        '
        Me.btnReject.Location = New System.Drawing.Point(609, 464)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(73, 29)
        Me.btnReject.TabIndex = 10
        Me.btnReject.Text = "Batal"
        Me.btnReject.UseVisualStyleBackColor = True
        '
        'dtKontrak
        '
        Me.dtKontrak.Location = New System.Drawing.Point(345, 461)
        Me.dtKontrak.Name = "dtKontrak"
        Me.dtKontrak.Size = New System.Drawing.Size(152, 20)
        Me.dtKontrak.TabIndex = 11
        '
        'cmbCollector
        '
        Me.cmbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCollector.FormattingEnabled = True
        Me.cmbCollector.Location = New System.Drawing.Point(100, 488)
        Me.cmbCollector.Name = "cmbCollector"
        Me.cmbCollector.Size = New System.Drawing.Size(148, 21)
        Me.cmbCollector.TabIndex = 17
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(17, 491)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 13)
        Me.Label22.TabIndex = 16
        Me.Label22.Text = "Nama Kolektor"
        '
        'BastElektronik
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 513)
        Me.Controls.Add(Me.cmbCollector)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.dtKontrak)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtKontrak)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gv1)
        Me.Controls.Add(Me.txtCari)
        Me.Controls.Add(Me.Label1)
        Me.Name = "BastElektronik"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BAST Elektronik"
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
    Friend WithEvents txtHarga As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNoSeri As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBarang As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
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
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents dtKontrak As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtModal As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtAngsuran As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTenor As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtPem As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbCollector As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
