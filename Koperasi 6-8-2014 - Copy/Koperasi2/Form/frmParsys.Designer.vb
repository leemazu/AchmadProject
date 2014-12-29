<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParsys
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
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtAdmKTA = New DevExpress.XtraEditors.SpinEdit
        Me.txtAdmEle = New DevExpress.XtraEditors.SpinEdit
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtRateRebate = New DevExpress.XtraEditors.SpinEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.txtTahunKwitansi = New DevExpress.XtraEditors.SpinEdit
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.txtTahunMB = New DevExpress.XtraEditors.SpinEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.txtBiayaAdmin = New DevExpress.XtraEditors.SpinEdit
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnReset = New DevExpress.XtraEditors.SimpleButton
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtAdmKTA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdmEle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRateRebate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTahunKwitansi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTahunMB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBiayaAdmin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(9, 162)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtAdmKTA)
        Me.GroupBox1.Controls.Add(Me.txtAdmEle)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtRateRebate)
        Me.GroupBox1.Controls.Add(Me.LabelControl3)
        Me.GroupBox1.Controls.Add(Me.txtTahunKwitansi)
        Me.GroupBox1.Controls.Add(Me.LabelControl2)
        Me.GroupBox1.Controls.Add(Me.txtTahunMB)
        Me.GroupBox1.Controls.Add(Me.LabelControl1)
        Me.GroupBox1.Controls.Add(Me.txtBiayaAdmin)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(608, 144)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'txtAdmKTA
        '
        Me.txtAdmKTA.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAdmKTA.Location = New System.Drawing.Point(518, 49)
        Me.txtAdmKTA.Name = "txtAdmKTA"
        Me.txtAdmKTA.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtAdmKTA.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txtAdmKTA.Properties.Appearance.Options.UseBackColor = True
        Me.txtAdmKTA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, False, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, "", Nothing, Nothing, True)})
        Me.txtAdmKTA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtAdmKTA.Properties.DisplayFormat.FormatString = "#,##0"
        Me.txtAdmKTA.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtAdmKTA.Properties.IsFloatValue = False
        Me.txtAdmKTA.Properties.Mask.EditMask = "N00"
        Me.txtAdmKTA.Properties.MaxLength = 9
        Me.txtAdmKTA.Size = New System.Drawing.Size(75, 20)
        Me.txtAdmKTA.TabIndex = 5
        '
        'txtAdmEle
        '
        Me.txtAdmEle.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAdmEle.Location = New System.Drawing.Point(518, 19)
        Me.txtAdmEle.Name = "txtAdmEle"
        Me.txtAdmEle.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtAdmEle.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txtAdmEle.Properties.Appearance.Options.UseBackColor = True
        Me.txtAdmEle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, False, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.txtAdmEle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtAdmEle.Properties.DisplayFormat.FormatString = "#,##0"
        Me.txtAdmEle.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtAdmEle.Properties.IsFloatValue = False
        Me.txtAdmEle.Properties.Mask.EditMask = "N00"
        Me.txtAdmEle.Properties.MaxLength = 9
        Me.txtAdmEle.Size = New System.Drawing.Size(75, 20)
        Me.txtAdmEle.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(253, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(212, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Biaya Admin Murni (Pembayaran Ke-1 KTA)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(253, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(239, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Biaya Admin Murni (Pembayaran Ke-1 Elektronik)"
        '
        'txtRateRebate
        '
        Me.txtRateRebate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtRateRebate.Location = New System.Drawing.Point(160, 45)
        Me.txtRateRebate.Name = "txtRateRebate"
        Me.txtRateRebate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txtRateRebate.Properties.Appearance.Options.UseBackColor = True
        Me.txtRateRebate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.txtRateRebate.Properties.MaxLength = 5
        Me.txtRateRebate.Size = New System.Drawing.Size(58, 20)
        Me.txtRateRebate.TabIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(18, 52)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Rate Rebate"
        '
        'txtTahunKwitansi
        '
        Me.txtTahunKwitansi.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtTahunKwitansi.Location = New System.Drawing.Point(160, 101)
        Me.txtTahunKwitansi.Name = "txtTahunKwitansi"
        Me.txtTahunKwitansi.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txtTahunKwitansi.Properties.Appearance.BackColor2 = System.Drawing.Color.MintCream
        Me.txtTahunKwitansi.Properties.Appearance.Options.UseBackColor = True
        Me.txtTahunKwitansi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.txtTahunKwitansi.Properties.IsFloatValue = False
        Me.txtTahunKwitansi.Properties.Mask.EditMask = "N00"
        Me.txtTahunKwitansi.Properties.MaxLength = 4
        Me.txtTahunKwitansi.Size = New System.Drawing.Size(58, 20)
        Me.txtTahunKwitansi.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(18, 108)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(72, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Tahun Kwitansi"
        '
        'txtTahunMB
        '
        Me.txtTahunMB.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtTahunMB.Location = New System.Drawing.Point(160, 75)
        Me.txtTahunMB.Name = "txtTahunMB"
        Me.txtTahunMB.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txtTahunMB.Properties.Appearance.Options.UseBackColor = True
        Me.txtTahunMB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.txtTahunMB.Properties.IsFloatValue = False
        Me.txtTahunMB.Properties.Mask.EditMask = "N00"
        Me.txtTahunMB.Properties.MaxLength = 4
        Me.txtTahunMB.Size = New System.Drawing.Size(58, 20)
        Me.txtTahunMB.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 82)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Tahun Motor Baru"
        '
        'txtBiayaAdmin
        '
        Me.txtBiayaAdmin.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtBiayaAdmin.Location = New System.Drawing.Point(160, 19)
        Me.txtBiayaAdmin.Name = "txtBiayaAdmin"
        Me.txtBiayaAdmin.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtBiayaAdmin.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txtBiayaAdmin.Properties.Appearance.Options.UseBackColor = True
        Me.txtBiayaAdmin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, False, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.txtBiayaAdmin.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtBiayaAdmin.Properties.DisplayFormat.FormatString = "#,##0"
        Me.txtBiayaAdmin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtBiayaAdmin.Properties.IsFloatValue = False
        Me.txtBiayaAdmin.Properties.Mask.EditMask = "N00"
        Me.txtBiayaAdmin.Properties.MaxLength = 9
        Me.txtBiayaAdmin.Size = New System.Drawing.Size(75, 20)
        Me.txtBiayaAdmin.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Biaya Admin"
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(90, 162)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 8
        Me.btnReset.Text = "Reset"
        '
        'frmParsys
        '
        Me.Appearance.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 213)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmParsys"
        Me.Text = "Edit Parameter System"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtAdmKTA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdmEle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRateRebate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTahunKwitansi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTahunMB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBiayaAdmin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBiayaAdmin As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTahunMB As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtTahunKwitansi As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRateRebate As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAdmKTA As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtAdmEle As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents btnReset As DevExpress.XtraEditors.SimpleButton
End Class
