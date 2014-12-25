<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRebate
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
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gv1 = New System.Windows.Forms.DataGridView
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtNoPolis = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbPolis = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtPemohon = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtAplikasi = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtPolis = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtRebate = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtRebateP = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSelisih = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPremiAsli = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPremiAwal = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(230, 10)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(294, 20)
        Me.txtFilter.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Cari Nomor Kontrak/Polis/Nama Konsumen"
        '
        'gv1
        '
        Me.gv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv1.Location = New System.Drawing.Point(12, 41)
        Me.gv1.Name = "gv1"
        Me.gv1.Size = New System.Drawing.Size(838, 229)
        Me.gv1.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Nomor Polis"
        '
        'txtNoPolis
        '
        Me.txtNoPolis.Enabled = False
        Me.txtNoPolis.Location = New System.Drawing.Point(107, 23)
        Me.txtNoPolis.Name = "txtNoPolis"
        Me.txtNoPolis.Size = New System.Drawing.Size(151, 20)
        Me.txtNoPolis.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(281, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Tgl Terima Polis"
        '
        'cmbPolis
        '
        Me.cmbPolis.Enabled = False
        Me.cmbPolis.FormattingEnabled = True
        Me.cmbPolis.Items.AddRange(New Object() {"JANUARI", "FEBRUARI", "MARET", "APRIL", "MEI", "JUNI", "JULI", "AGUSTUS", "SEPTEMBER", "OKTOBER", "NOVEMBER", "DESEMBER"})
        Me.cmbPolis.Location = New System.Drawing.Point(369, 48)
        Me.cmbPolis.Name = "cmbPolis"
        Me.cmbPolis.Size = New System.Drawing.Size(102, 21)
        Me.cmbPolis.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(281, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Bulan Polis"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(271, 128)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Simpan"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPemohon)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtAplikasi)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbPolis)
        Me.GroupBox1.Controls.Add(Me.dtPolis)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtNoPolis)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 276)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(561, 114)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'txtPemohon
        '
        Me.txtPemohon.Enabled = False
        Me.txtPemohon.Location = New System.Drawing.Point(107, 75)
        Me.txtPemohon.Name = "txtPemohon"
        Me.txtPemohon.Size = New System.Drawing.Size(151, 20)
        Me.txtPemohon.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Nama Pemohon"
        '
        'txtAplikasi
        '
        Me.txtAplikasi.Enabled = False
        Me.txtAplikasi.Location = New System.Drawing.Point(107, 49)
        Me.txtAplikasi.Name = "txtAplikasi"
        Me.txtAplikasi.Size = New System.Drawing.Size(151, 20)
        Me.txtAplikasi.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Nomor Aplikasi"
        '
        'dtPolis
        '
        Me.dtPolis.Enabled = False
        Me.dtPolis.Location = New System.Drawing.Point(369, 23)
        Me.dtPolis.Name = "dtPolis"
        Me.dtPolis.Size = New System.Drawing.Size(153, 20)
        Me.dtPolis.TabIndex = 23
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtRebate)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtRebateP)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtSelisih)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtPremiAsli)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtPremiAwal)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 397)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 165)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        '
        'txtRebate
        '
        Me.txtRebate.Enabled = False
        Me.txtRebate.Location = New System.Drawing.Point(104, 130)
        Me.txtRebate.Name = "txtRebate"
        Me.txtRebate.Size = New System.Drawing.Size(151, 20)
        Me.txtRebate.TabIndex = 39
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 133)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Rebate"
        '
        'txtRebateP
        '
        Me.txtRebateP.Location = New System.Drawing.Point(104, 104)
        Me.txtRebateP.MaxLength = 4
        Me.txtRebateP.Name = "txtRebateP"
        Me.txtRebateP.Size = New System.Drawing.Size(41, 20)
        Me.txtRebateP.TabIndex = 37
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "%"
        '
        'txtSelisih
        '
        Me.txtSelisih.Enabled = False
        Me.txtSelisih.Location = New System.Drawing.Point(104, 78)
        Me.txtSelisih.Name = "txtSelisih"
        Me.txtSelisih.Size = New System.Drawing.Size(151, 20)
        Me.txtSelisih.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Selisih"
        '
        'txtPremiAsli
        '
        Me.txtPremiAsli.Location = New System.Drawing.Point(104, 52)
        Me.txtPremiAsli.Name = "txtPremiAsli"
        Me.txtPremiAsli.Size = New System.Drawing.Size(151, 20)
        Me.txtPremiAsli.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Premi Asli"
        '
        'txtPremiAwal
        '
        Me.txtPremiAwal.Enabled = False
        Me.txtPremiAwal.Location = New System.Drawing.Point(104, 26)
        Me.txtPremiAwal.MaxLength = 15
        Me.txtPremiAwal.Name = "txtPremiAwal"
        Me.txtPremiAwal.Size = New System.Drawing.Size(151, 20)
        Me.txtPremiAwal.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Premi Awal"
        '
        'frmRebate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 574)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gv1)
        Me.Name = "frmRebate"
        Me.Text = "frmRebate"
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNoPolis As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbPolis As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtPolis As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPemohon As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAplikasi As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPremiAsli As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPremiAwal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRebate As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRebateP As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSelisih As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
