<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKwitansiOwner
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKwitansiOwner))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtKwitansiDr = New System.Windows.Forms.TextBox
        Me.txtKwitansiSm = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtKwitansi = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmbKwitansi = New System.Windows.Forms.ComboBox
        Me.txtIdKonsumen = New System.Windows.Forms.TextBox
        Me.btnKontrak = New System.Windows.Forms.Button
        Me.btnKonsumen = New System.Windows.Forms.Button
        Me.txtNamaKonsumen = New System.Windows.Forms.TextBox
        Me.txtKontrak = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnApprove = New System.Windows.Forms.Button
        Me.dtBayar = New System.Windows.Forms.DateTimePicker
        Me.txtAlasan = New System.Windows.Forms.TextBox
        Me.txtNominal = New System.Windows.Forms.TextBox
        Me.cmbPIC2 = New System.Windows.Forms.ComboBox
        Me.cmbPIC1 = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbStatKwitansi = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbFisik = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.cmbPIC = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nomor Kwitansi"
        '
        'txtKwitansiDr
        '
        Me.txtKwitansiDr.Location = New System.Drawing.Point(141, 22)
        Me.txtKwitansiDr.MaxLength = 6
        Me.txtKwitansiDr.Name = "txtKwitansiDr"
        Me.txtKwitansiDr.Size = New System.Drawing.Size(46, 20)
        Me.txtKwitansiDr.TabIndex = 0
        '
        'txtKwitansiSm
        '
        Me.txtKwitansiSm.Location = New System.Drawing.Point(237, 23)
        Me.txtKwitansiSm.MaxLength = 6
        Me.txtKwitansiSm.Name = "txtKwitansiSm"
        Me.txtKwitansiSm.Size = New System.Drawing.Size(46, 20)
        Me.txtKwitansiSm.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(222, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "-"
        '
        'dtKwitansi
        '
        Me.dtKwitansi.Location = New System.Drawing.Point(141, 75)
        Me.dtKwitansi.Name = "dtKwitansi"
        Me.dtKwitansi.Size = New System.Drawing.Size(142, 20)
        Me.dtKwitansi.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Tanggal Ambil"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(305, 70)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 24)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Approve"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbKwitansi
        '
        Me.cmbKwitansi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKwitansi.FormattingEnabled = True
        Me.cmbKwitansi.Location = New System.Drawing.Point(129, 147)
        Me.cmbKwitansi.Name = "cmbKwitansi"
        Me.cmbKwitansi.Size = New System.Drawing.Size(124, 21)
        Me.cmbKwitansi.TabIndex = 31
        '
        'txtIdKonsumen
        '
        Me.txtIdKonsumen.Location = New System.Drawing.Point(23, 419)
        Me.txtIdKonsumen.Name = "txtIdKonsumen"
        Me.txtIdKonsumen.Size = New System.Drawing.Size(121, 20)
        Me.txtIdKonsumen.TabIndex = 54
        Me.txtIdKonsumen.Visible = False
        '
        'btnKontrak
        '
        Me.btnKontrak.Location = New System.Drawing.Point(546, 255)
        Me.btnKontrak.Name = "btnKontrak"
        Me.btnKontrak.Size = New System.Drawing.Size(26, 23)
        Me.btnKontrak.TabIndex = 42
        Me.btnKontrak.UseVisualStyleBackColor = True
        '
        'btnKonsumen
        '
        Me.btnKonsumen.Location = New System.Drawing.Point(259, 377)
        Me.btnKonsumen.Name = "btnKonsumen"
        Me.btnKonsumen.Size = New System.Drawing.Size(26, 23)
        Me.btnKonsumen.TabIndex = 47
        Me.btnKonsumen.UseVisualStyleBackColor = True
        '
        'txtNamaKonsumen
        '
        Me.txtNamaKonsumen.Location = New System.Drawing.Point(132, 379)
        Me.txtNamaKonsumen.Name = "txtNamaKonsumen"
        Me.txtNamaKonsumen.Size = New System.Drawing.Size(121, 20)
        Me.txtNamaKonsumen.TabIndex = 46
        '
        'txtKontrak
        '
        Me.txtKontrak.Location = New System.Drawing.Point(410, 257)
        Me.txtKontrak.Name = "txtKontrak"
        Me.txtKontrak.Size = New System.Drawing.Size(130, 20)
        Me.txtKontrak.TabIndex = 40
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(343, 435)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 32)
        Me.btnCancel.TabIndex = 53
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnApprove
        '
        Me.btnApprove.Location = New System.Drawing.Point(221, 435)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(82, 32)
        Me.btnApprove.TabIndex = 51
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = True
        '
        'dtBayar
        '
        Me.dtBayar.Location = New System.Drawing.Point(410, 384)
        Me.dtBayar.Name = "dtBayar"
        Me.dtBayar.Size = New System.Drawing.Size(96, 20)
        Me.dtBayar.TabIndex = 49
        '
        'txtAlasan
        '
        Me.txtAlasan.Location = New System.Drawing.Point(132, 294)
        Me.txtAlasan.Multiline = True
        Me.txtAlasan.Name = "txtAlasan"
        Me.txtAlasan.Size = New System.Drawing.Size(272, 67)
        Me.txtAlasan.TabIndex = 43
        '
        'txtNominal
        '
        Me.txtNominal.Location = New System.Drawing.Point(132, 257)
        Me.txtNominal.Name = "txtNominal"
        Me.txtNominal.Size = New System.Drawing.Size(130, 20)
        Me.txtNominal.TabIndex = 39
        '
        'cmbPIC2
        '
        Me.cmbPIC2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPIC2.FormattingEnabled = True
        Me.cmbPIC2.Location = New System.Drawing.Point(410, 179)
        Me.cmbPIC2.Name = "cmbPIC2"
        Me.cmbPIC2.Size = New System.Drawing.Size(121, 21)
        Me.cmbPIC2.TabIndex = 34
        '
        'cmbPIC1
        '
        Me.cmbPIC1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPIC1.FormattingEnabled = True
        Me.cmbPIC1.Location = New System.Drawing.Point(132, 179)
        Me.cmbPIC1.Name = "cmbPIC1"
        Me.cmbPIC1.Size = New System.Drawing.Size(121, 21)
        Me.cmbPIC1.TabIndex = 32
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 386)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 13)
        Me.Label11.TabIndex = 52
        Me.Label11.Text = "Nama Konsumen"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(294, 264)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "No Kontrak"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(294, 384)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Tanggal Bayar"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 264)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Nominal"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(294, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "PIC Kedua"
        '
        'cmbStatKwitansi
        '
        Me.cmbStatKwitansi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatKwitansi.FormattingEnabled = True
        Me.cmbStatKwitansi.Items.AddRange(New Object() {"Terpakai", "Belum Terpakai", "Cancel"})
        Me.cmbStatKwitansi.Location = New System.Drawing.Point(132, 216)
        Me.cmbStatKwitansi.Name = "cmbStatKwitansi"
        Me.cmbStatKwitansi.Size = New System.Drawing.Size(134, 21)
        Me.cmbStatKwitansi.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 297)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Alasan"
        '
        'cmbFisik
        '
        Me.cmbFisik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFisik.FormattingEnabled = True
        Me.cmbFisik.Items.AddRange(New Object() {"Ada", "Tidak ada"})
        Me.cmbFisik.Location = New System.Drawing.Point(410, 221)
        Me.cmbFisik.Name = "cmbFisik"
        Me.cmbFisik.Size = New System.Drawing.Size(134, 21)
        Me.cmbFisik.TabIndex = 38
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(294, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Fisik"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(23, 224)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Status Kwitansi"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(23, 187)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "PIC Pertama"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(23, 149)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "No Kwitansi"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(2, 108)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(643, 13)
        Me.Label15.TabIndex = 55
        Me.Label15.Text = resources.GetString("Label15.Text")
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(193, 22)
        Me.TextBox1.MaxLength = 8
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(23, 20)
        Me.TextBox1.TabIndex = 56
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(289, 23)
        Me.TextBox2.MaxLength = 8
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(23, 20)
        Me.TextBox2.TabIndex = 57
        '
        'cmbPIC
        '
        Me.cmbPIC.FormattingEnabled = True
        Me.cmbPIC.Location = New System.Drawing.Point(141, 48)
        Me.cmbPIC.Name = "cmbPIC"
        Me.cmbPIC.Size = New System.Drawing.Size(142, 21)
        Me.cmbPIC.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Pemegang Kwitansi"
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(274, 147)
        Me.txtFilter.MaxLength = 8
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(78, 20)
        Me.txtFilter.TabIndex = 58
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(358, 147)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(274, 12)
        Me.Label16.TabIndex = 59
        Me.Label16.Text = "*Masukkan Nomor Kwitansi yang ingin dicari (10 Nomor Kedepan)"
        '
        'frmKwitansiOwner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 546)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbKwitansi)
        Me.Controls.Add(Me.txtIdKonsumen)
        Me.Controls.Add(Me.btnKontrak)
        Me.Controls.Add(Me.btnKonsumen)
        Me.Controls.Add(Me.txtNamaKonsumen)
        Me.Controls.Add(Me.txtKontrak)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.dtBayar)
        Me.Controls.Add(Me.txtAlasan)
        Me.Controls.Add(Me.txtNominal)
        Me.Controls.Add(Me.cmbPIC2)
        Me.Controls.Add(Me.cmbPIC1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbStatKwitansi)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbFisik)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtKwitansi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbPIC)
        Me.Controls.Add(Me.txtKwitansiSm)
        Me.Controls.Add(Me.txtKwitansiDr)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmKwitansiOwner"
        Me.Text = "Entry Stok Kwitansi"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtKwitansiDr As System.Windows.Forms.TextBox
    Friend WithEvents txtKwitansiSm As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtKwitansi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbKwitansi As System.Windows.Forms.ComboBox
    Friend WithEvents txtIdKonsumen As System.Windows.Forms.TextBox
    Friend WithEvents btnKontrak As System.Windows.Forms.Button
    Friend WithEvents btnKonsumen As System.Windows.Forms.Button
    Friend WithEvents txtNamaKonsumen As System.Windows.Forms.TextBox
    Friend WithEvents txtKontrak As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents dtBayar As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAlasan As System.Windows.Forms.TextBox
    Friend WithEvents txtNominal As System.Windows.Forms.TextBox
    Friend WithEvents cmbPIC2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPIC1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbStatKwitansi As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbFisik As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents cmbPIC As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
