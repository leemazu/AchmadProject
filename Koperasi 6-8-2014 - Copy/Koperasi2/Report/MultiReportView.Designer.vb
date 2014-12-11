<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiReportView
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.CRViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.CRViewer2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 38)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1255, 726)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CRViewer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1247, 700)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tanda Terima Uang"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'CRViewer1
        '
        Me.CRViewer1.ActiveViewIndex = -1
        Me.CRViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRViewer1.DisplayGroupTree = False
        Me.CRViewer1.DisplayStatusBar = False
        Me.CRViewer1.DisplayToolbar = False
        Me.CRViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRViewer1.Location = New System.Drawing.Point(3, 3)
        Me.CRViewer1.Name = "CRViewer1"
        Me.CRViewer1.SelectionFormula = ""
        Me.CRViewer1.ShowGroupTreeButton = False
        Me.CRViewer1.ShowRefreshButton = False
        Me.CRViewer1.Size = New System.Drawing.Size(1241, 694)
        Me.CRViewer1.TabIndex = 0
        Me.CRViewer1.ViewTimeSelectionFormula = ""
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CRViewer2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1247, 700)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Tanda Terima BPKB"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CRViewer2
        '
        Me.CRViewer2.ActiveViewIndex = -1
        Me.CRViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRViewer2.DisplayGroupTree = False
        Me.CRViewer2.DisplayStatusBar = False
        Me.CRViewer2.DisplayToolbar = False
        Me.CRViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRViewer2.Location = New System.Drawing.Point(3, 3)
        Me.CRViewer2.Name = "CRViewer2"
        Me.CRViewer2.SelectionFormula = ""
        Me.CRViewer2.ShowGroupTreeButton = False
        Me.CRViewer2.ShowRefreshButton = False
        Me.CRViewer2.Size = New System.Drawing.Size(1241, 694)
        Me.CRViewer2.TabIndex = 0
        Me.CRViewer2.ViewTimeSelectionFormula = ""
        '
        'MultiReportView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1279, 750)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "MultiReportView"
        Me.Text = "MultiReportView"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents CRViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CRViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
