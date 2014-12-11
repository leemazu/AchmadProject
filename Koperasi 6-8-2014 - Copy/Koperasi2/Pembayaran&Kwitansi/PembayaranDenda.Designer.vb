<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PembayaranDenda
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PembayaranDenda))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
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
        Me.lblTipe = New System.Windows.Forms.Label
        Me.lblMesin = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbAngsuran = New System.Windows.Forms.ComboBox
        Me.txtHiddenAngsuran = New System.Windows.Forms.TextBox
        Me.btnBayar = New System.Windows.Forms.Button
        Me.txtBayar = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbKwitansi = New System.Windows.Forms.ComboBox
        Me.dtBayar = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDenda = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbCaraBayar = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmbPIC = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.GridControl1)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 304)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1248, 375)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "AR Info"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 339)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 26)
        Me.Button1.TabIndex = 76
        Me.Button1.Text = "Export Ke Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(6, 26)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1202, 307)
        Me.GridControl1.TabIndex = 32
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "", Nothing, "")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(19, 400)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Total Bayar"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(19, 429)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 13)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Cara Bayar"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Kasir 101", "Kasir 106", "Kolektor 101", "Kolektor 106", "Transfer BCA", "Kantor Pusat"})
        Me.ComboBox1.Location = New System.Drawing.Point(112, 426)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(119, 21)
        Me.ComboBox1.TabIndex = 18
        '
        'txtHidden
        '
        Me.txtHidden.Location = New System.Drawing.Point(676, 22)
        Me.txtHidden.MaxLength = 12
        Me.txtHidden.Name = "txtHidden"
        Me.txtHidden.Size = New System.Drawing.Size(122, 21)
        Me.txtHidden.TabIndex = 75
        Me.txtHidden.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(293, 22)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 21)
        Me.Button2.TabIndex = 74
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtObjek
        '
        Me.txtObjek.Enabled = False
        Me.txtObjek.Location = New System.Drawing.Point(164, 148)
        Me.txtObjek.Name = "txtObjek"
        Me.txtObjek.Size = New System.Drawing.Size(153, 21)
        Me.txtObjek.TabIndex = 73
        '
        'txtBulan
        '
        Me.txtBulan.Enabled = False
        Me.txtBulan.Location = New System.Drawing.Point(443, 116)
        Me.txtBulan.Name = "txtBulan"
        Me.txtBulan.Size = New System.Drawing.Size(153, 21)
        Me.txtBulan.TabIndex = 72
        '
        'txtTenor
        '
        Me.txtTenor.Enabled = False
        Me.txtTenor.Location = New System.Drawing.Point(443, 80)
        Me.txtTenor.Name = "txtTenor"
        Me.txtTenor.Size = New System.Drawing.Size(153, 21)
        Me.txtTenor.TabIndex = 71
        '
        'txtTipe
        '
        Me.txtTipe.Enabled = False
        Me.txtTipe.Location = New System.Drawing.Point(443, 54)
        Me.txtTipe.Name = "txtTipe"
        Me.txtTipe.Size = New System.Drawing.Size(153, 21)
        Me.txtTipe.TabIndex = 70
        '
        'txtMesin
        '
        Me.txtMesin.Enabled = False
        Me.txtMesin.Location = New System.Drawing.Point(443, 22)
        Me.txtMesin.Name = "txtMesin"
        Me.txtMesin.Size = New System.Drawing.Size(153, 21)
        Me.txtMesin.TabIndex = 69
        '
        'txtAlamat
        '
        Me.txtAlamat.Enabled = False
        Me.txtAlamat.Location = New System.Drawing.Point(164, 77)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(153, 59)
        Me.txtAlamat.TabIndex = 68
        '
        'txtKonsumen
        '
        Me.txtKonsumen.Enabled = False
        Me.txtKonsumen.Location = New System.Drawing.Point(164, 51)
        Me.txtKonsumen.Name = "txtKonsumen"
        Me.txtKonsumen.Size = New System.Drawing.Size(153, 21)
        Me.txtKonsumen.TabIndex = 67
        '
        'txtKontrak
        '
        Me.txtKontrak.Location = New System.Drawing.Point(164, 22)
        Me.txtKontrak.MaxLength = 12
        Me.txtKontrak.Name = "txtKontrak"
        Me.txtKontrak.Size = New System.Drawing.Size(122, 21)
        Me.txtKontrak.TabIndex = 66
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(31, 148)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 13)
        Me.Label16.TabIndex = 65
        Me.Label16.Text = "Objek"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(361, 119)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 13)
        Me.Label15.TabIndex = 64
        Me.Label15.Text = "Bulan Booking"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(368, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Tenor"
        '
        'lblTipe
        '
        Me.lblTipe.AutoSize = True
        Me.lblTipe.Location = New System.Drawing.Point(368, 54)
        Me.lblTipe.Name = "lblTipe"
        Me.lblTipe.Size = New System.Drawing.Size(27, 13)
        Me.lblTipe.TabIndex = 62
        Me.lblTipe.Text = "Tipe"
        '
        'lblMesin
        '
        Me.lblMesin.AutoSize = True
        Me.lblMesin.Location = New System.Drawing.Point(368, 25)
        Me.lblMesin.Name = "lblMesin"
        Me.lblMesin.Size = New System.Drawing.Size(51, 13)
        Me.lblMesin.TabIndex = 61
        Me.lblMesin.Text = "No.Mesin"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Alamat"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Nama Konsumen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "No Kontrak"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.PictureBox3)
        Me.GroupBox3.Controls.Add(Me.PictureBox2)
        Me.GroupBox3.Location = New System.Drawing.Point(994, 197)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 82)
        Me.GroupBox3.TabIndex = 76
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Keterangan Warna"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(66, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Denda Ingin Dibayar"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(64, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 13)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "Denda Belum Dibayar"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(16, 51)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 18)
        Me.PictureBox3.TabIndex = 44
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(16, 27)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 18)
        Me.PictureBox2.TabIndex = 43
        Me.PictureBox2.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbAngsuran)
        Me.GroupBox2.Controls.Add(Me.txtHiddenAngsuran)
        Me.GroupBox2.Controls.Add(Me.btnBayar)
        Me.GroupBox2.Controls.Add(Me.txtBayar)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cmbKwitansi)
        Me.GroupBox2.Controls.Add(Me.dtBayar)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtDenda)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cmbCaraBayar)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.cmbPIC)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(939, 124)
        Me.GroupBox2.TabIndex = 77
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detail Pembayaran"
        '
        'cmbAngsuran
        '
        Me.cmbAngsuran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAngsuran.FormattingEnabled = True
        Me.cmbAngsuran.Location = New System.Drawing.Point(83, 61)
        Me.cmbAngsuran.Name = "cmbAngsuran"
        Me.cmbAngsuran.Size = New System.Drawing.Size(36, 21)
        Me.cmbAngsuran.TabIndex = 78
        '
        'txtHiddenAngsuran
        '
        Me.txtHiddenAngsuran.Location = New System.Drawing.Point(677, 60)
        Me.txtHiddenAngsuran.MaxLength = 12
        Me.txtHiddenAngsuran.Name = "txtHiddenAngsuran"
        Me.txtHiddenAngsuran.Size = New System.Drawing.Size(122, 21)
        Me.txtHiddenAngsuran.TabIndex = 48
        Me.txtHiddenAngsuran.Visible = False
        '
        'btnBayar
        '
        Me.btnBayar.Enabled = False
        Me.btnBayar.Location = New System.Drawing.Point(582, 55)
        Me.btnBayar.Name = "btnBayar"
        Me.btnBayar.Size = New System.Drawing.Size(75, 23)
        Me.btnBayar.TabIndex = 47
        Me.btnBayar.Text = "Bayar"
        Me.btnBayar.UseVisualStyleBackColor = True
        '
        'txtBayar
        '
        Me.txtBayar.Location = New System.Drawing.Point(413, 58)
        Me.txtBayar.MaxLength = 9
        Me.txtBayar.Name = "txtBayar"
        Me.txtBayar.Size = New System.Drawing.Size(153, 21)
        Me.txtBayar.TabIndex = 46
        Me.txtBayar.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(337, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Jumlah Bayar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(561, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "No Kwitansi"
        '
        'cmbKwitansi
        '
        Me.cmbKwitansi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKwitansi.FormattingEnabled = True
        Me.cmbKwitansi.Location = New System.Drawing.Point(624, 20)
        Me.cmbKwitansi.Name = "cmbKwitansi"
        Me.cmbKwitansi.Size = New System.Drawing.Size(100, 21)
        Me.cmbKwitansi.TabIndex = 44
        '
        'dtBayar
        '
        Me.dtBayar.Location = New System.Drawing.Point(435, 20)
        Me.dtBayar.Name = "dtBayar"
        Me.dtBayar.Size = New System.Drawing.Size(117, 21)
        Me.dtBayar.TabIndex = 42
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(353, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Tanggal Bayar"
        '
        'txtDenda
        '
        Me.txtDenda.Enabled = False
        Me.txtDenda.Location = New System.Drawing.Point(172, 60)
        Me.txtDenda.Name = "txtDenda"
        Me.txtDenda.Size = New System.Drawing.Size(153, 21)
        Me.txtDenda.TabIndex = 40
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(129, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Denda"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Angsuran Ke"
        '
        'cmbCaraBayar
        '
        Me.cmbCaraBayar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCaraBayar.FormattingEnabled = True
        Me.cmbCaraBayar.Items.AddRange(New Object() {"Kasir 101", "Kasir 106", "Kolektor 101", "Kolektor 106", "Transfer BCA", "Kantor Pusat"})
        Me.cmbCaraBayar.Location = New System.Drawing.Point(243, 19)
        Me.cmbCaraBayar.Name = "cmbCaraBayar"
        Me.cmbCaraBayar.Size = New System.Drawing.Size(100, 21)
        Me.cmbCaraBayar.TabIndex = 18
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(178, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Cara Bayar"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "PIC kedua"
        '
        'cmbPIC
        '
        Me.cmbPIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPIC.FormattingEnabled = True
        Me.cmbPIC.Location = New System.Drawing.Point(72, 19)
        Me.cmbPIC.Name = "cmbPIC"
        Me.cmbPIC.Size = New System.Drawing.Size(100, 21)
        Me.cmbPIC.TabIndex = 35
        '
        'PembayaranDenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1280, 713)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
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
        Me.Controls.Add(Me.lblTipe)
        Me.Controls.Add(Me.lblMesin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PembayaranDenda"
        Me.Text = "PembayaranDenda"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
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
    Friend WithEvents lblTipe As System.Windows.Forms.Label
    Friend WithEvents lblMesin As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbAngsuran As System.Windows.Forms.ComboBox
    Friend WithEvents txtHiddenAngsuran As System.Windows.Forms.TextBox
    Friend WithEvents btnBayar As System.Windows.Forms.Button
    Friend WithEvents txtBayar As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbKwitansi As System.Windows.Forms.ComboBox
    Friend WithEvents dtBayar As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDenda As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbCaraBayar As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbPIC As System.Windows.Forms.ComboBox
End Class
