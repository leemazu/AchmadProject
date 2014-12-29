Imports System.Windows.Forms

Public Class frmMain

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub



    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AksesLevel()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()
        'frmLogin.Visible = True

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmDana.Show()
        'frmDana.MdiParent = Me

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmElektronik.Show()
        'frmElektronik.MdiParent = Me
    End Sub

    Private Sub DanaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanaToolStripMenuItem.Click
        frmDanaTunai.Show()
        frmDanaTunai.MdiParent = Me
        frmDanaTunai.WindowState = FormWindowState.Maximized

        'frmDana.Show()
        'frmDana.MdiParent = Me
    End Sub



    Private Sub LogouToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogouToolStripMenuItem.Click
        Me.Hide()
        UserName = ""
        levelUser = 0
        EmployeeID = ""
        With frmLogin
            .Textbox1.Text = ""
            .Textbox2.Text = ""
            .Show()
            .WindowState = FormWindowState.Normal
            .StartPosition = FormStartPosition.CenterScreen
            .Textbox1.Focus()
        End With



    End Sub

    Private Sub ElektronikToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ElektronikToolStripMenuItem.Click
        frmElektronik.Show()
        frmElektronik.MdiParent = Me
        frmElektronik.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub KTAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KTAToolStripMenuItem.Click
        frmKTA.Show()
        frmKTA.MdiParent = Me
        frmKTA.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub KTAToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KTAToolStripMenuItem1.Click

        BastKTA.MdiParent = Me
        BastKTA.StartPosition = FormStartPosition.Manual
        BastKTA.Location = New Point(0, 0)
        BastKTA.Show()
    End Sub

    Private Sub ElektronikToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ElektronikToolStripMenuItem1.Click

        BastElektronik.MdiParent = Me
        BastElektronik.StartPosition = FormStartPosition.Manual
        BastElektronik.Location = New Point(0, 0)
        BastElektronik.Show()
    End Sub

    Private Sub DanaTunaiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanaTunaiToolStripMenuItem.Click

        BastDana.MdiParent = Me
        BastDana.StartPosition = FormStartPosition.Manual
        BastDana.Location = New Point(0, 0)
        BastDana.Show()
    End Sub

    Private Sub MotorBaruToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MotorBaruToolStripMenuItem.Click
        frmMotorBaru.Show()
        frmMotorBaru.MdiParent = Me
        frmMotorBaru.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PembayaranAngsuranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PembayaranAngsuranToolStripMenuItem.Click

    End Sub

    Private Sub AngsuranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AngsuranToolStripMenuItem.Click
        PembayaranAngsuran.Show()
        PembayaranAngsuran.MdiParent = Me
        PembayaranAngsuran.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DendaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DendaToolStripMenuItem.Click
        PembayaranDenda.Show()
        PembayaranDenda.MdiParent = Me
        PembayaranDenda.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub KwitansiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KwitansiToolStripMenuItem.Click
        frmKwitansiOwner.Show()
        frmKwitansiOwner.MdiParent = Me
    End Sub

    Private Sub PelunasanNormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PelunasanNormalToolStripMenuItem.Click
        PelunasanNormal.Show()
        PelunasanNormal.MdiParent = Me
    End Sub

    Private Sub ReportKontrakToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportKontrakToolStripMenuItem.Click
        ReportKontrak.Show()
        ReportKontrak.MdiParent = Me
        ReportKontrak.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Buyback.Show()
        Buyback.MdiParent = Me
        Buyback.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DanaTunaiToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanaTunaiToolStripMenuItem1.Click
        kontrakDanaTunai.Show()
        kontrakDanaTunai.MdiParent = Me
        kontrakDanaTunai.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub KTAToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        kontrakKTA.Show()
        kontrakKTA.MdiParent = Me
        kontrakKTA.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub MotorBaruToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MotorBaruToolStripMenuItem1.Click

        BastMotorBaru.MdiParent = Me
        BastMotorBaru.StartPosition = FormStartPosition.Manual
        BastMotorBaru.Location = New Point(0, 0)
        BastMotorBaru.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub PelunasanDimukaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PelunasanDimukaToolStripMenuItem.Click
        PelunasanDimuka.Show()
        PelunasanDimuka.MdiParent = Me
        PelunasanDimuka.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PelunasanKhususToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PelunasanKhususToolStripMenuItem.Click
        PelunasanKhusus.Show()
        PelunasanKhusus.MdiParent = Me
        PelunasanKhusus.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub BPKBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPKBToolStripMenuItem.Click
        EntryBPKB.Show()
        EntryBPKB.MdiParent = Me
        EntryBPKB.StartPosition = FormStartPosition.CenterParent
    End Sub

    Private Sub ReservedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservedToolStripMenuItem.Click
      

    End Sub

    Private Sub AksesLevel()

        'StrSQL = ""
        'StrSQL = "SELECT * FROM __Akses WHERE EmployeeID='" & EmployeeID & "'"
        'RunSQL(StrSQL, 1)

        'If dt.Rows.Count > 0 Then
        '    DanaToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnDT"))
        '    MotorBaruToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnMB"))
        '    KTAToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnKTA"))
        '    ElektronikToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnEle"))
        '    DanaTunaiToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnDT"))
        '    MotorBaruToolStripMenuItem1.Visible = CBool(dt.Rows(0)("EnMB"))
        '    KTAToolStripMenuItem1.Visible = CBool(dt.Rows(0)("EnKTA"))
        '    ElektronikToolStripMenuItem1.Visible = CBool(dt.Rows(0)("EnEle"))
        '    DanaTunaiToolStripMenuItem1.Visible = CBool(dt.Rows(0)("VKontrakDT"))
        '    MotorBaruToolStripMenuItem2.Visible = CBool(dt.Rows(0)("VKontrakMB"))
        '    KTAToolStripMenuItem2.Visible = CBool(dt.Rows(0)("VKontrakKta"))
        '    ElektronikToolStripMenuItem2.Visible = CBool(dt.Rows(0)("VKontrakEle"))
        '    BPKBToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnBpkb"))
        '    KwitansiToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnKwitansi"))
        '    PembayaranAngsuranToolStripMenuItem.Visible = CBool(dt.Rows(0)("Pembayaran"))
        '    PolisAsuransiToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnPolis"))
        '    PelunasanNormalToolStripMenuItem.Visible = CBool(dt.Rows(0)("PelNormal"))
        '    PelunasanDimukaToolStripMenuItem.Visible = CBool(dt.Rows(0)("PelDimuka"))
        '    PelunasanKhususToolStripMenuItem.Visible = CBool(dt.Rows(0)("PelKhusus"))
        '    PelunasanAsuransiToolStripMenuItem.Visible = CBool(dt.Rows(0)("PelAsuransi"))
        '    ReservedToolStripMenuItem.Visible = CBool(dt.Rows(0)("EdKaryawan"))
        '    ReportKontrakToolStripMenuItem.Visible = CBool(dt.Rows(0)("VKontrak"))

        'Else
        '    MessageBox.Show("Maaf Anda Tidak Berhak Mengakses Aplikasi Ini !!! ", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Application.Exit()

        'End If

    End Sub

    Private Sub MotorBaruToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        kontrakMotorBaru.Show()
        kontrakMotorBaru.MdiParent = Me
        kontrakMotorBaru.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub ElektronikToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        kontrakElektronik.Show()
        kontrakElektronik.MdiParent = Me
        kontrakElektronik.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PenambahanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenambahanToolStripMenuItem.Click
        frmPenambahanModal.StartPosition = FormStartPosition.Manual
        frmPenambahanModal.Location = New Point(0, 0)
        frmPenambahanModal.MdiParent = Me
        frmPenambahanModal.Show()
    End Sub

    Private Sub PengembalianModalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengembalianModalToolStripMenuItem.Click
        frmPengembalianModal.StartPosition = FormStartPosition.Manual
        frmPengembalianModal.Location = New Point(0, 0)
        frmPengembalianModal.MdiParent = Me
        frmPengembalianModal.Show()
    End Sub

    Private Sub PencairanCashToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PencairanCashToolStripMenuItem.Click
        frmPencairanCash.StartPosition = FormStartPosition.Manual
        frmPencairanCash.Location = New Point(0, 0)
        frmPencairanCash.MdiParent = Me
        frmPencairanCash.Show()
    End Sub

    Private Sub PolisAsuransiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PolisAsuransiToolStripMenuItem.Click
      
    End Sub

    Private Sub KaryawanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KaryawanToolStripMenuItem.Click

        frmKaryawan.MdiParent = Me
        frmKaryawan.StartPosition = FormStartPosition.Manual
        frmKaryawan.Location = New Point(0, 0)
        frmKaryawan.Show()
    End Sub

    Private Sub ParameterSistemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParameterSistemToolStripMenuItem.Click
        frmParsys.StartPosition = FormStartPosition.Manual
        frmParsys.Location = New Point(0, 0)
        frmParsys.MdiParent = Me
        frmParsys.Show()
    End Sub

    Private Sub EntryPolisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntryPolisToolStripMenuItem.Click
        frmPolisAsuransi.StartPosition = FormStartPosition.Manual
        frmPolisAsuransi.Location = New Point(0, 0)
        frmPolisAsuransi.MdiParent = Me
        frmPolisAsuransi.Show()
    End Sub

    Private Sub EntryRebateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntryRebateToolStripMenuItem.Click
        frmRebate.StartPosition = FormStartPosition.Manual
        frmRebate.Location = New Point(0, 0)
        frmRebate.MdiParent = Me
        frmRebate.Show()
    End Sub
End Class
