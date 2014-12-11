Imports System.Data.SqlClient
Public Class frmLogin

    Dim counter As Integer = 0

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call con_getsetting()
        If conn_open() = True Then
            Dim pass As String
            Using cmd As New SqlCommand(String.Format("SELECT CONVERT(nvarchar(max),DecryptByAsymKey( AsymKey_Id('keyPassword'),Userpass, N'y4djk3ch' )) AS Userpass From Account Where UserID='{0}' AND [State]=1", Textbox1.Text.Replace("'", "").Replace("--", "")), conn)
                pass = cmd.ExecuteScalar
                If pass <> Nothing Then
                    If pass = Textbox2.Text Then
                        MessageBox.Show("Login Success!!", "Mulya", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        mainFormSetting()
                        frmMain.Show()
                        Me.Hide()
                    Else
                        counter += 1
                        If counter <> 3 Then
                            MessageBox.Show("Username atau Password Salah")
                        Else
                            MessageBox.Show(String.Format("Password Salah{0}Anda Sudah 3X Gagal melakukan Login!", vbNewLine))
                            Me.Close()
                        End If
                    End If
                Else
                    counter += 1
                    If counter <> 3 Then
                        MessageBox.Show("Username atau Password Salah")
                    Else
                        MessageBox.Show(String.Format("Username Salah{0}Anda Sudah 3X Gagal melakukan Login!", vbNewLine))
                        Me.Close()
                    End If

                End If
            End Using
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New frmSelectServer
        frm.ShowDialog()
    End Sub

    Private Sub frmLogin_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Textbox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Textbox1.KeyPress
        If e.KeyChar = Chr(13) Then Textbox2.Focus()
    End Sub

    Private Sub Textbox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Textbox2.KeyPress
        If e.KeyChar = Chr(13) Then Call OK_Click(Button1, New System.EventArgs)
    End Sub

    Private Sub mainFormSetting()
        Dim level As String
        StrSQL = ""
        StrSQL = "SELECT * from Account WHERE UserId ='" & Textbox1.Text & "' "
        ' StrSQL &= "AND UserPass = '" & Textbox2.Text & "'"
        RunSQL(StrSQL, 1)

        level = CStr(dt.Rows(0)("ReferenceID"))
        UserName = CStr(dt.Rows(0)("UserID"))
        EmployeeID = CStr(dt.Rows(0)("EmployeeID"))

        StrSQL = ""
        StrSQL = "SELECT * FROM __Akses WHERE EmployeeID='" & EmployeeID & "'"
        RunSQL(StrSQL, 1)

        If dt.Rows.Count > 0 Then

            With frmMain

                .DanaToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnDT"))
                .MotorBaruToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnMB"))
                .KTAToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnKTA"))
                .ElektronikToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnEle"))
                .DanaTunaiToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnDT"))
                .MotorBaruToolStripMenuItem1.Visible = CBool(dt.Rows(0)("EnMB"))
                .KTAToolStripMenuItem1.Visible = CBool(dt.Rows(0)("EnKTA"))
                .ElektronikToolStripMenuItem1.Visible = CBool(dt.Rows(0)("EnEle"))
                .DanaTunaiToolStripMenuItem1.Visible = CBool(dt.Rows(0)("VKontrakDT"))
                .MotorBaruToolStripMenuItem2.Visible = CBool(dt.Rows(0)("VKontrakMB"))
                .KTAToolStripMenuItem2.Visible = CBool(dt.Rows(0)("VKontrakKta"))
                .ElektronikToolStripMenuItem2.Visible = CBool(dt.Rows(0)("VKontrakEle"))
                .BPKBToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnBpkb"))
                .KwitansiToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnKwitansi"))
                .PembayaranAngsuranToolStripMenuItem.Visible = CBool(dt.Rows(0)("Pembayaran"))
                .PolisAsuransiToolStripMenuItem.Visible = CBool(dt.Rows(0)("EnPolis"))
                .PelunasanNormalToolStripMenuItem.Visible = CBool(dt.Rows(0)("PelNormal"))
                .PelunasanDimukaToolStripMenuItem.Visible = CBool(dt.Rows(0)("PelDimuka"))
                .PelunasanKhususToolStripMenuItem.Visible = CBool(dt.Rows(0)("PelKhusus"))
                .PelunasanAsuransiToolStripMenuItem.Visible = CBool(dt.Rows(0)("PelAsuransi"))
                .ReservedToolStripMenuItem.Visible = CBool(dt.Rows(0)("EdKaryawan"))
                .ReportKontrakToolStripMenuItem.Visible = CBool(dt.Rows(0)("VKontrak"))
                .EditToolStripMenuItem.Visible = CBool(dt.Rows(0)("BbKontrak"))
            End With


        Else
            MessageBox.Show("Maaf Anda Tidak Berhak Mengakses Aplikasi Ini !!! ", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Application.Exit()

        End If


    End Sub

End Class
