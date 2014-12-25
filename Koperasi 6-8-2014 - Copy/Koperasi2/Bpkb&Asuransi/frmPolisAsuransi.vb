Public Class frmPolisAsuransi
    Dim oldPolis As String = ""
    Dim insUpd As String
    Private Sub frmPolisAsuransi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
        FillGrid()
    End Sub

    Private Sub ClearForm()
        txtAplikasi.Enabled = False
        txtKontrak.Enabled = False
        txtPemohon.Enabled = False
        txtPos.Enabled = False
        txtStatus.Enabled = False
        txtNoPolis.Clear()
        setTanggal(dtPolis)
        txtPremi.Text = 0
        cmbPolis.SelectedIndex = 0
        oldPolis = ""
        insUpd = "INS"
    End Sub

    Private Sub FillGrid()
        Try
            Dim dsGrid As New DataSet
            StrSQL = ""
            StrSQL = "SELECT DISTINCT TOP 100 * FROM V_GRIDFORMPOLIS ORDER BY [Nama Konsumen] ASC "

            RunSQL(StrSQL, 1)

            If dt.Rows.Count > 0 Then
                RunSQL(StrSQL, 2, "TableGrid", Nothing, dsGrid)
                DataGridView1.DataSource = dsGrid
                DataGridView1.DataMember = "TableGrid"
                DataGridView1.AutoResizeColumns()
            Else
                DataGridView1.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtPremi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPremi.KeyPress
        decimalOnly(txtPremi, e, txtPremi.Text)
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Try
            txtKontrak.Text = CStr(DataGridView1.CurrentRow.Cells(0).Value)
            txtAplikasi.Text = CStr(DataGridView1.CurrentRow.Cells(1).Value)
            txtPemohon.Text = CStr(DataGridView1.CurrentRow.Cells(2).Value)
            txtStatus.Text = CStr(DataGridView1.CurrentRow.Cells(7).Value)
            txtPremi.Text = ribuan(CStr(DataGridView1.CurrentRow.Cells(5).Value))
            txtPos.Text = CStr(DataGridView1.CurrentRow.Cells(6).Value)

            StrSQL = "SELECT * FROM Polis WHERe ApplicationID = '" & txtAplikasi.Text & "' "
            RunSQL(StrSQL, 1)
            If dt.Rows.Count > 0 Then
                txtNoPolis.Text = CStr(dt.Rows(0)("NoPolis"))
                dtPolis.Value = CDate(dt.Rows(0)("TglPolis"))
                'txtPremi.Text = ribuan(CStr(dt.Rows(0)("PremiAwal")))
                cmbPolis.Text = CStr(dt.Rows(0)("BulanPolis"))
                oldPolis = CStr(dt.Rows(0)("NoPolis"))
                insUpd = "UPD"
            Else
                txtNoPolis.Text = ""
                dtPolis.Value = Now
                'txtPremi.Text = 0
                cmbPolis.Text = "JANUARI"
                insUpd = "INS"
                oldPolis = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        Try
            Dim dsFilter As New DataSet
            Dim filter As String = antisqli(txtFilter.Text)
            StrSQL = ""
            StrSQL = "SELECT DISTINCT TOP 100 * FROM V_GRIDFORMPOLIS  "
            StrSQL &= " WHERE [Nomor Kontrak] LIKE '%" & filter & "%'  "
            StrSQL &= "OR [Nomor Aplikasi] LIKE '%" & filter & "%' "
            StrSQL &= "OR [Nama Konsumen] LIKE '%" & filter & "%' "
            StrSQL &= "ORDER BY [Nama Konsumen] ASC"

            RunSQL(StrSQL, 1)

            If dt.Rows.Count > 0 Then
                RunSQL(StrSQL, 2, "TableGrid", Nothing, dsFilter)
                DataGridView1.DataSource = dsFilter
                DataGridView1.DataMember = "TableGrid"
                DataGridView1.AutoResizeColumns()
            Else
                DataGridView1.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtNoPolis.Text <> "" And txtAplikasi.Text <> "" Then
            Dim pesan As String = "Anda Akan Menginput Polis dengan Detail Berikut : "
            pesan &= vbNewLine & "---------------------------------------------------------------------"
            pesan &= vbNewLine & "Nomor Polis " & vbTab & vbTab & ": " & txtNoPolis.Text
            pesan &= vbNewLine & "Nama Pelanggan " & vbTab & vbTab & ": " & txtPemohon.Text
            pesan &= vbNewLine & "Tanggal Polis " & vbTab & vbTab & ": " & dtPolis.Text
            pesan &= vbNewLine & vbNewLine & "Apakah Anda yakin ? "
            Dim result As Integer = MessageBox.Show(pesan, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = vbYes Then
                StrSQL = ""
                StrSQL = "Sp_PolisIU "
                StrSQL &= "'" & insUpd & "',"
                StrSQL &= "'" & antisqli(txtNoPolis.Text) & "',"
                StrSQL &= "'" & dtPolis.Value.Date & "',"
                StrSQL &= "0,"
                StrSQL &= "'" & cmbPolis.Text & "',"
                StrSQL &= "'',"
                StrSQL &= "'" & txtAplikasi.Text & "',"
                StrSQL &= "" & CDbl(txtPremi.Text) & ","
                StrSQL &= "'" & oldPolis & "'"
                If RunSQL(StrSQL, 0) = True Then
                    MessageBox.Show("Data Berhasil Disimpan !", "Sukses", MessageBoxButtons.OK)
                    ClearForm()
                End If

            End If
        End If
       
    End Sub
End Class