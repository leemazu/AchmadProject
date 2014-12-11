<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PembayaranAngsuran
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblMesin = New System.Windows.Forms.Label
        Me.lblTipe = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmbCaraBayar = New System.Windows.Forms.ComboBox
        Me.txtKontrak = New System.Windows.Forms.TextBox
        Me.txtKonsumen = New System.Windows.Forms.TextBox
        Me.txtAlamat = New System.Windows.Forms.TextBox
        Me.txtMesin = New System.Windows.Forms.TextBox
        Me.txtTipe = New System.Windows.Forms.TextBox
        Me.txtTenor = New System.Windows.Forms.TextBox
        Me.txtBulan = New System.Windows.Forms.TextBox
        Me.txtObjek = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.cmbPIC = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.txtAdminKredit = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtHidden = New System.Windows.Forms.TextBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No Kontrak"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Konsumen"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Alamat"
        '
        'lblMesin
        '
        Me.lblMesin.AutoSize = True
        Me.lblMesin.Location = New System.Drawing.Point(375, 15)
        Me.lblMesin.Name = "lblMesin"
        Me.lblMesin.Size = New System.Drawing.Size(52, 13)
        Me.lblMesin.TabIndex = 3
        Me.lblMesin.Text = "No.Mesin"
        '
        'lblTipe
        '
        Me.lblTipe.AutoSize = True
        Me.lblTipe.Location = New System.Drawing.Point(375, 44)
        Me.lblTipe.Name = "lblTipe"
        Me.lblTipe.Size = New System.Drawing.Size(28, 13)
        Me.lblTipe.TabIndex = 4
        Me.lblTipe.Text = "Tipe"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(375, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Tenor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Adm Kredit"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(19, 75)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "PIC kedua"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(368, 109)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 13)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Bulan Booking"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(38, 138)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 13)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Objek"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(316, 43)
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
        Me.cmbCaraBayar.Location = New System.Drawing.Point(409, 40)
        Me.cmbCaraBayar.Name = "cmbCaraBayar"
        Me.cmbCaraBayar.Size = New System.Drawing.Size(119, 21)
        Me.cmbCaraBayar.TabIndex = 18
        '
        'txtKontrak
        '
        Me.txtKontrak.Location = New System.Drawing.Point(171, 12)
        Me.txtKontrak.MaxLength = 12
        Me.txtKontrak.Name = "txtKontrak"
        Me.txtKontrak.Size = New System.Drawing.Size(122, 20)
        Me.txtKontrak.TabIndex = 20
        '
        'txtKonsumen
        '
        Me.txtKonsumen.Enabled = False
        Me.txtKonsumen.Location = New System.Drawing.Point(171, 41)
        Me.txtKonsumen.Name = "txtKonsumen"
        Me.txtKonsumen.Size = New System.Drawing.Size(153, 20)
        Me.txtKonsumen.TabIndex = 21
        '
        'txtAlamat
        '
        Me.txtAlamat.Enabled = False
        Me.txtAlamat.Location = New System.Drawing.Point(171, 67)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(153, 59)
        Me.txtAlamat.TabIndex = 22
        '
        'txtMesin
        '
        Me.txtMesin.Enabled = False
        Me.txtMesin.Location = New System.Drawing.Point(450, 12)
        Me.txtMesin.Name = "txtMesin"
        Me.txtMesin.Size = New System.Drawing.Size(153, 20)
        Me.txtMesin.TabIndex = 23
        '
        'txtTipe
        '
        Me.txtTipe.Enabled = False
        Me.txtTipe.Location = New System.Drawing.Point(450, 44)
        Me.txtTipe.Name = "txtTipe"
        Me.txtTipe.Size = New System.Drawing.Size(153, 20)
        Me.txtTipe.TabIndex = 24
        '
        'txtTenor
        '
        Me.txtTenor.Enabled = False
        Me.txtTenor.Location = New System.Drawing.Point(450, 70)
        Me.txtTenor.Name = "txtTenor"
        Me.txtTenor.Size = New System.Drawing.Size(153, 20)
        Me.txtTenor.TabIndex = 25
        '
        'txtBulan
        '
        Me.txtBulan.Enabled = False
        Me.txtBulan.Location = New System.Drawing.Point(450, 106)
        Me.txtBulan.Name = "txtBulan"
        Me.txtBulan.Size = New System.Drawing.Size(153, 20)
        Me.txtBulan.TabIndex = 27
        '
        'txtObjek
        '
        Me.txtObjek.Enabled = False
        Me.txtObjek.Location = New System.Drawing.Point(171, 138)
        Me.txtObjek.Name = "txtObjek"
        Me.txtObjek.Size = New System.Drawing.Size(153, 20)
        Me.txtObjek.TabIndex = 28
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.cmbPIC)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.GridControl1)
        Me.GroupBox1.Controls.Add(Me.txtAdminKredit)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cmbCaraBayar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 179)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1317, 508)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1039, 457)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(138, 34)
        Me.Button3.TabIndex = 36
        Me.Button3.Text = "Save"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cmbPIC
        '
        Me.cmbPIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPIC.FormattingEnabled = True
        Me.cmbPIC.Location = New System.Drawing.Point(130, 72)
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
        'txtAdminKredit
        '
        Me.txtAdminKredit.Location = New System.Drawing.Point(130, 36)
        Me.txtAdminKredit.Name = "txtAdminKredit"
        Me.txtAdminKredit.Size = New System.Drawing.Size(153, 20)
        Me.txtAdminKredit.TabIndex = 29
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(303, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 21)
        Me.Button2.TabIndex = 32
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtHidden
        '
        Me.txtHidden.Location = New System.Drawing.Point(683, 12)
        Me.txtHidden.MaxLength = 12
        Me.txtHidden.Name = "txtHidden"
        Me.txtHidden.Size = New System.Drawing.Size(122, 20)
        Me.txtHidden.TabIndex = 33
        Me.txtHidden.Visible = False
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Microsoft Excel  | *.xls"
        '
        'PembayaranAngsuran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1280, 728)
        Me.Controls.Add(Me.txtHidden)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
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
        Me.Name = "PembayaranAngsuran"
        Me.Text = "PembayaranAngsuran"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMesin As System.Windows.Forms.Label
    Friend WithEvents lblTipe As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbCaraBayar As System.Windows.Forms.ComboBox
    Friend WithEvents txtKontrak As System.Windows.Forms.TextBox
    Friend WithEvents txtKonsumen As System.Windows.Forms.TextBox
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents txtMesin As System.Windows.Forms.TextBox
    Friend WithEvents txtTipe As System.Windows.Forms.TextBox
    Friend WithEvents txtTenor As System.Windows.Forms.TextBox
    Friend WithEvents txtBulan As System.Windows.Forms.TextBox
    Friend WithEvents txtObjek As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtAdminKredit As System.Windows.Forms.TextBox
    Friend WithEvents txtHidden As System.Windows.Forms.TextBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmbPIC As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button

End Class
