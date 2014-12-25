Public Class frmPenambahanModal

    Private Sub frmPenambahanModal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtNominal.Text > 0 Then
            Dim result As Integer = MessageBox.Show("Konfirmasi Penambahan Modal Sebesar Rp." & txtNominal.Text & ",- ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = vbYes Then
                Modal_SAV()
                MessageBox.Show("Modal Berhasil Ditambah", "Proses Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearForm()
            End If
        Else
            lblInfo.Visible = True
            lblInfo.Text = "Nominal harus lebih dari 0"
            txtNominal.Focus()
            txtNominal.SelectAll()
        End If
       
    End Sub

    Private Sub ClearForm()
        setTanggal(dtTgl)
        txtNominal.Text = "0"
        lblInfo.Visible = False
        ModalView()

    End Sub

    Private Sub Modal_SAV()
        StrSQL = ""
        StrSQL = "Sp_BankIU 'INV_MODAL', "
        StrSQL &= "'',"
        StrSQL &= "'" & dtTgl.Value.Date & "',"
        StrSQL &= "" & CDbl(txtNominal.Text) & ","
        StrSQL &= "'" & UserName & "'"
        RunSQL(StrSQL, 0)
    End Sub

    Private Sub txtNominal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNominal.KeyPress
        decimalOnly(txtNominal, e, txtNominal.Text)
        lblInfo.Visible = False
    End Sub

    Private Sub txtNominal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNominal.Leave
        txtNominal.Text = ribuan(txtNominal.Text)
    End Sub

    Private Sub ModalView()
        Dim Debet As Double
        Dim Kredit As Double
        StrSQL = ""
        StrSQL = "SELECT SUM(Nominal) as Saldo From Bank_Modal WHERE DK='D'"
        RunSQL(StrSQL, 1)


        Try
            Debet = dt.Rows(0)("Saldo")
        Catch ex As Exception
            Debet = 0
        End Try

        StrSQL = ""
        StrSQL = "SELECT SUM(Nominal) as Saldo From Bank_Modal WHERE DK='K'"
        RunSQL(StrSQL, 1)
        Try
            Kredit = dt.Rows(0)("Saldo")
        Catch ex As Exception
            Kredit = 0
        End Try

        Dim modal As Double = CDbl(Debet) - CDbl(Kredit)

        txtCurrentModal.Text = ribuan(modal)

    End Sub
End Class