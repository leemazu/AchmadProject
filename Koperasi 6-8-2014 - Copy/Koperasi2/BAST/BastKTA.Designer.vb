<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BastKTA
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
        Me.txtModal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAngsuran = New System.Windows.Forms.TextBox
        Me.lblxx = New System.Windows.Forms.Label
        Me.txtTenor = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPinjaman = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtPem = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPemNama = New System.Windows.Forms.TextBox
        Me.labelxx = New System.Windows.Forms.Label
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
        Me.gv1.AllowUserToAddRows = False
        Me.gv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv1.Location = New System.Drawing.Point(18, 36)
        Me.gv1.Name = "gv1"
        Me.gv1.Size = New System.Drawing.Size(716, 192)
        Me.gv1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtModal)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtAngsuran)
        Me.GroupBox1.Controls.Add(Me.lblxx)
        Me.GroupBox1.Controls.Add(Me.txtTenor)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtPinjaman)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtPem)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPemNama)
        Me.GroupBox1.Controls.Add(Me.labelxx)
        Me.GroupBox1.Controls.Add(Me.txtAplikasi)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 234)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(714, 106)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Aplikasi"
        '
        'txtModal
        '
        Me.txtModal.Enabled = False
        Me.txtModal.Location = New System.Drawing.Point(556, 62)
        Me.txtModal.Name = "txtModal"
        Me.txtModal.Size = New System.Drawing.Size(127, 20)
        Me.txtModal.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(500, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Modal"
        '
        'txtAngsuran
        '
        Me.txtAngsuran.Enabled = False
        Me.txtAngsuran.Location = New System.Drawing.Point(403, 62)
        Me.txtAngsuran.Name = "txtAngsuran"
        Me.txtAngsuran.Size = New System.Drawing.Size(79, 20)
        Me.txtAngsuran.TabIndex = 11
        '
        'lblxx
        '
        Me.lblxx.AutoSize = True
        Me.lblxx.Location = New System.Drawing.Point(345, 65)
        Me.lblxx.Name = "lblxx"
        Me.lblxx.Size = New System.Drawing.Size(52, 13)
        Me.lblxx.TabIndex = 10
        Me.lblxx.Text = "Angsuran"
        '
        'txtTenor
        '
        Me.txtTenor.Enabled = False
        Me.txtTenor.Location = New System.Drawing.Point(290, 62)
        Me.txtTenor.Name = "txtTenor"
        Me.txtTenor.Size = New System.Drawing.Size(43, 20)
        Me.txtTenor.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(217, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Tenor(bulan)"
        '
        'txtPinjaman
        '
        Me.txtPinjaman.Enabled = False
        Me.txtPinjaman.Location = New System.Drawing.Point(86, 62)
        Me.txtPinjaman.Name = "txtPinjaman"
        Me.txtPinjaman.Size = New System.Drawing.Size(125, 20)
        Me.txtPinjaman.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 69)
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
        'labelxx
        '
        Me.labelxx.AutoSize = True
        Me.labelxx.Location = New System.Drawing.Point(239, 29)
        Me.labelxx.Name = "labelxx"
        Me.labelxx.Size = New System.Drawing.Size(88, 13)
        Me.labelxx.TabIndex = 2
        Me.labelxx.Text = "Nama Konsumen"
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
        Me.GroupBox2.Location = New System.Drawing.Point(19, 346)
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
        Me.Label11.Location = New System.Drawing.Point(257, 413)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Tanggal Kontrak"
        '
        'txtKontrak
        '
        Me.txtKontrak.Location = New System.Drawing.Point(102, 407)
        Me.txtKontrak.Name = "txtKontrak"
        Me.txtKontrak.Size = New System.Drawing.Size(147, 20)
        Me.txtKontrak.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 413)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Nomor Kontrak"
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(521, 410)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(73, 26)
        Me.btnProcess.TabIndex = 9
        Me.btnProcess.Text = "Proses"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'btnReject
        '
        Me.btnReject.Location = New System.Drawing.Point(610, 409)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(73, 29)
        Me.btnReject.TabIndex = 10
        Me.btnReject.Text = "Batal"
        Me.btnReject.UseVisualStyleBackColor = True
        '
        'dtKontrak
        '
        Me.dtKontrak.Location = New System.Drawing.Point(346, 406)
        Me.dtKontrak.Name = "dtKontrak"
        Me.dtKontrak.Size = New System.Drawing.Size(152, 20)
        Me.dtKontrak.TabIndex = 11
        '
        'cmbCollector
        '
        Me.cmbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCollector.FormattingEnabled = True
        Me.cmbCollector.Location = New System.Drawing.Point(101, 433)
        Me.cmbCollector.Name = "cmbCollector"
        Me.cmbCollector.Size = New System.Drawing.Size(148, 21)
        Me.cmbCollector.TabIndex = 19
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(18, 436)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 13)
        Me.Label22.TabIndex = 18
        Me.Label22.Text = "Nama Kolektor"
        '
        'BastKTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 477)
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
        Me.Name = "BastKTA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form BAST KTA"
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
    Friend WithEvents lblxx As System.Windows.Forms.Label
    Friend WithEvents txtTenor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPinjaman As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtPem As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPemNama As System.Windows.Forms.TextBox
    Friend WithEvents labelxx As System.Windows.Forms.Label
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
    Friend WithEvents cmbCollector As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
