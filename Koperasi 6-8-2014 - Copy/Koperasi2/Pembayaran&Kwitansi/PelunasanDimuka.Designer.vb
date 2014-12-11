<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PelunasanDimuka
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
        Me.txtHidden = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtBayar = New System.Windows.Forms.TextBox
        Me.txtTotalKekurangan = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPinalty = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDenda = New System.Windows.Forms.TextBox
        Me.txtSIsaPokok = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbPIC = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmbCaraBayar = New System.Windows.Forms.ComboBox
        Me.txtObjek = New System.Windows.Forms.TextBox
        Me.txtTipe = New System.Windows.Forms.TextBox
        Me.txtBulan = New System.Windows.Forms.TextBox
        Me.txtTenor = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtMesin = New System.Windows.Forms.TextBox
        Me.txtAlamat = New System.Windows.Forms.TextBox
        Me.txtKonsumen = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblTipe = New System.Windows.Forms.Label
        Me.lblMesin = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.txtKontrak = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbKwitansi = New System.Windows.Forms.ComboBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.dtBayar = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtHidden
        '
        Me.txtHidden.Location = New System.Drawing.Point(653, 13)
        Me.txtHidden.MaxLength = 12
        Me.txtHidden.Name = "txtHidden"
        Me.txtHidden.Size = New System.Drawing.Size(122, 20)
        Me.txtHidden.TabIndex = 52
        Me.txtHidden.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.dtBayar)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.cmbKwitansi)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtBayar)
        Me.GroupBox1.Controls.Add(Me.txtTotalKekurangan)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtPinalty)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDenda)
        Me.GroupBox1.Controls.Add(Me.txtSIsaPokok)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbPIC)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.GridControl1)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cmbCaraBayar)
        Me.GroupBox1.Location = New System.Drawing.Point(-18, 180)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1317, 508)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(309, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Bayar"
        '
        'txtBayar
        '
        Me.txtBayar.Location = New System.Drawing.Point(402, 87)
        Me.txtBayar.Name = "txtBayar"
        Me.txtBayar.Size = New System.Drawing.Size(153, 20)
        Me.txtBayar.TabIndex = 57
        '
        'txtTotalKekurangan
        '
        Me.txtTotalKekurangan.Enabled = False
        Me.txtTotalKekurangan.Location = New System.Drawing.Point(128, 87)
        Me.txtTotalKekurangan.Name = "txtTotalKekurangan"
        Me.txtTotalKekurangan.Size = New System.Drawing.Size(153, 20)
        Me.txtTotalKekurangan.TabIndex = 56
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 13)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "Total Kekurangan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(578, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Pinalty"
        '
        'txtPinalty
        '
        Me.txtPinalty.Location = New System.Drawing.Point(622, 49)
        Me.txtPinalty.MaxLength = 10
        Me.txtPinalty.Name = "txtPinalty"
        Me.txtPinalty.Size = New System.Drawing.Size(153, 20)
        Me.txtPinalty.TabIndex = 53
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(309, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Sisa Denda"
        '
        'txtDenda
        '
        Me.txtDenda.Enabled = False
        Me.txtDenda.Location = New System.Drawing.Point(402, 50)
        Me.txtDenda.Name = "txtDenda"
        Me.txtDenda.Size = New System.Drawing.Size(153, 20)
        Me.txtDenda.TabIndex = 51
        '
        'txtSIsaPokok
        '
        Me.txtSIsaPokok.Enabled = False
        Me.txtSIsaPokok.Location = New System.Drawing.Point(128, 50)
        Me.txtSIsaPokok.Name = "txtSIsaPokok"
        Me.txtSIsaPokok.Size = New System.Drawing.Size(153, 20)
        Me.txtSIsaPokok.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Sisa Pokok"
        '
        'cmbPIC
        '
        Me.cmbPIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPIC.FormattingEnabled = True
        Me.cmbPIC.Location = New System.Drawing.Point(128, 19)
        Me.cmbPIC.Name = "cmbPIC"
        Me.cmbPIC.Size = New System.Drawing.Size(153, 21)
        Me.cmbPIC.TabIndex = 35
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1190, 455)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 36)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Export ke Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(22, 113)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1289, 336)
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
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "PIC kedua"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(309, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 13)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Cara Bayar"
        '
        'cmbCaraBayar
        '
        Me.cmbCaraBayar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCaraBayar.FormattingEnabled = True
        Me.cmbCaraBayar.Items.AddRange(New Object() {"Kasir 101", "Kasir 106", "Kolektor 101", "Kolektor 106", "Transfer BCA", "Kantor Pusat"})
        Me.cmbCaraBayar.Location = New System.Drawing.Point(402, 22)
        Me.cmbCaraBayar.Name = "cmbCaraBayar"
        Me.cmbCaraBayar.Size = New System.Drawing.Size(119, 21)
        Me.cmbCaraBayar.TabIndex = 18
        '
        'txtObjek
        '
        Me.txtObjek.Enabled = False
        Me.txtObjek.Location = New System.Drawing.Point(141, 139)
        Me.txtObjek.Name = "txtObjek"
        Me.txtObjek.Size = New System.Drawing.Size(153, 20)
        Me.txtObjek.TabIndex = 49
        '
        'txtTipe
        '
        Me.txtTipe.Enabled = False
        Me.txtTipe.Location = New System.Drawing.Point(420, 45)
        Me.txtTipe.Name = "txtTipe"
        Me.txtTipe.Size = New System.Drawing.Size(153, 20)
        Me.txtTipe.TabIndex = 46
        '
        'txtBulan
        '
        Me.txtBulan.Enabled = False
        Me.txtBulan.Location = New System.Drawing.Point(420, 107)
        Me.txtBulan.Name = "txtBulan"
        Me.txtBulan.Size = New System.Drawing.Size(153, 20)
        Me.txtBulan.TabIndex = 48
        '
        'txtTenor
        '
        Me.txtTenor.Enabled = False
        Me.txtTenor.Location = New System.Drawing.Point(420, 71)
        Me.txtTenor.Name = "txtTenor"
        Me.txtTenor.Size = New System.Drawing.Size(153, 20)
        Me.txtTenor.TabIndex = 47
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(273, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 21)
        Me.Button2.TabIndex = 51
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtMesin
        '
        Me.txtMesin.Enabled = False
        Me.txtMesin.Location = New System.Drawing.Point(420, 13)
        Me.txtMesin.Name = "txtMesin"
        Me.txtMesin.Size = New System.Drawing.Size(153, 20)
        Me.txtMesin.TabIndex = 45
        '
        'txtAlamat
        '
        Me.txtAlamat.Enabled = False
        Me.txtAlamat.Location = New System.Drawing.Point(141, 68)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(153, 59)
        Me.txtAlamat.TabIndex = 44
        '
        'txtKonsumen
        '
        Me.txtKonsumen.Enabled = False
        Me.txtKonsumen.Location = New System.Drawing.Point(141, 42)
        Me.txtKonsumen.Name = "txtKonsumen"
        Me.txtKonsumen.Size = New System.Drawing.Size(153, 20)
        Me.txtKonsumen.TabIndex = 43
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(345, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Tenor"
        '
        'lblTipe
        '
        Me.lblTipe.AutoSize = True
        Me.lblTipe.Location = New System.Drawing.Point(345, 45)
        Me.lblTipe.Name = "lblTipe"
        Me.lblTipe.Size = New System.Drawing.Size(28, 13)
        Me.lblTipe.TabIndex = 38
        Me.lblTipe.Text = "Tipe"
        '
        'lblMesin
        '
        Me.lblMesin.AutoSize = True
        Me.lblMesin.Location = New System.Drawing.Point(345, 16)
        Me.lblMesin.Name = "lblMesin"
        Me.lblMesin.Size = New System.Drawing.Size(52, 13)
        Me.lblMesin.TabIndex = 37
        Me.lblMesin.Text = "No.Mesin"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Alamat"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Nama Konsumen"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Microsoft Excel  | *.xls"
        '
        'txtKontrak
        '
        Me.txtKontrak.Location = New System.Drawing.Point(141, 13)
        Me.txtKontrak.MaxLength = 12
        Me.txtKontrak.Name = "txtKontrak"
        Me.txtKontrak.Size = New System.Drawing.Size(122, 20)
        Me.txtKontrak.TabIndex = 42
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 139)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 13)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Objek"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(338, 110)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 13)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Bulan Booking"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "No Kontrak"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(578, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "Kwitansi"
        '
        'cmbKwitansi
        '
        Me.cmbKwitansi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKwitansi.FormattingEnabled = True
        Me.cmbKwitansi.Location = New System.Drawing.Point(630, 19)
        Me.cmbKwitansi.Name = "cmbKwitansi"
        Me.cmbKwitansi.Size = New System.Drawing.Size(153, 21)
        Me.cmbKwitansi.TabIndex = 60
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(581, 83)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(107, 27)
        Me.Button3.TabIndex = 61
        Me.Button3.Text = "Simpan"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dtBayar
        '
        Me.dtBayar.Location = New System.Drawing.Point(892, 19)
        Me.dtBayar.Name = "dtBayar"
        Me.dtBayar.Size = New System.Drawing.Size(117, 20)
        Me.dtBayar.TabIndex = 62
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(810, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 63
        Me.Label11.Text = "Tanggal Bayar"
        '
        'PelunasanDimuka
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1280, 728)
        Me.Controls.Add(Me.txtHidden)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtObjek)
        Me.Controls.Add(Me.txtTipe)
        Me.Controls.Add(Me.txtBulan)
        Me.Controls.Add(Me.txtTenor)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtMesin)
        Me.Controls.Add(Me.txtAlamat)
        Me.Controls.Add(Me.txtKonsumen)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblTipe)
        Me.Controls.Add(Me.lblMesin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtKontrak)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PelunasanDimuka"
        Me.Text = "PelunasanDimuka"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHidden As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPIC As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbCaraBayar As System.Windows.Forms.ComboBox
    Friend WithEvents txtObjek As System.Windows.Forms.TextBox
    Friend WithEvents txtTipe As System.Windows.Forms.TextBox
    Friend WithEvents txtBulan As System.Windows.Forms.TextBox
    Friend WithEvents txtTenor As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtMesin As System.Windows.Forms.TextBox
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents txtKonsumen As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTipe As System.Windows.Forms.Label
    Friend WithEvents lblMesin As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txtKontrak As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSIsaPokok As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBayar As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalKekurangan As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPinalty As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDenda As System.Windows.Forms.TextBox
    Friend WithEvents cmbKwitansi As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtBayar As System.Windows.Forms.DateTimePicker
End Class
