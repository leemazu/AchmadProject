Public Class frmPencairanCash
    Dim NoTransaksi As String
    Private Sub frmPencairanCash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
    End Sub

    Private Sub ClearForm()
        setTanggal(dtTanggal)
        txtSaldo.Enabled = False
        txtNominal.Text = 0
        lblInfo.Visible = False
        ViewSaldo()
    End Sub

    Private Sub ViewSaldo()
        Dim D As New Double
        Dim K As New Double
        StrSQL = ""
        StrSQL = "Sp_BankModalLOAD"
        RunSQL(StrSQL, 1)

        D = CDbl(dt.Rows(0)("Saldo"))
        K = CDbl(dt.Rows(1)("Saldo"))

        If D - K > 0 Then
            txtSaldo.Text = ribuan(CStr(D - K))
            txtNominal.Enabled = True
            Button1.Enabled = True
        Else
            txtSaldo.Text = "Saldo Tidak Tersedia"
            txtNominal.Enabled = False
            Button1.Enabled = False
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CInt(txtNominal.Text) <= CInt(txtSaldo.Text) Then

            If txtNominal.Text = 0 Then
                Exit Sub
            End If

            Dim result As Integer = MessageBox.Show("Anda ingin melakukan Pencairan Cash sebesar Rp " & txtNominal.Text & ",- ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = vbYes Then
                PencairanCash()
                If flagSQL = True Then
                    MessageBox.Show("Pencairan Berhasil Dilakukan", "Sukses", MessageBoxButtons.OK)
                    ClearForm()
                Else
                    MessageBox.Show("Pencairan Gagal Dilakukan", "Gagal", MessageBoxButtons.OK)
                    lblInfo.Text = errorMessage
                End If

            End If
        Else
            lblInfo.Text = "Nominal Dicairkan tidak bisa lebih dari saldo tersedia !"
            lblInfo.Visible = True
            txtNominal.Focus()
            txtNominal.SelectAll()
        End If
    End Sub

    Private Sub PencairanCash()
        StrSQL = ""
        StrSQL = "Sp_PencairanCash "
        StrSQL &= "'" & dtTanggal.Value.Date & "',"
        StrSQL &= antisqli(CStr(CDbl(txtNominal.Text))) & ","
        StrSQL &= "'" & UserName & "',"
        StrSQL &= "'" & Now & "',"
        StrSQL &= "'" & GenerateNoTransaksi() & "'"
        RunSQL(StrSQL, 0)
    End Sub

    Private Sub txtNominal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNominal.KeyPress
        decimalOnly(txtNominal, e, txtNominal.Text)
    End Sub

    Private Sub txtNominal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNominal.Leave
        txtNominal.Text = ribuan(txtNominal.Text)
        lblInfo.Text = ""
        lblInfo.Visible = False
    End Sub

    Private Function GenerateNoTransaksi() As String
        StrSQL = ""
        StrSQL = "SELECT NoTransaksi From Cash ORDER BY NoTransaksi DESC"
        RunSQL(StrSQL, 1)

        If dt.Rows.Count > 0 Then
            GenerateNoTransaksi = CreateAutoNumber("C", 6, dt.Rows(0)("NoTransaksi").ToString())
        Else
            GenerateNoTransaksi = CreateAutoNumber("C", 6, "")
        End If

        Return GenerateNoTransaksi
    End Function
End Class