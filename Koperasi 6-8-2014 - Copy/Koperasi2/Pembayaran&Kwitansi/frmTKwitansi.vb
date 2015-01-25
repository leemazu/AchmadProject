Public Class frmTKwitansi

    Private Sub frmTKwitansi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
    End Sub

    Private Sub ClearForm()
        Dim dtPic1 As New DataTable
        Dim dtPic2 As New DataTable
        setTanggal(dtAmbil)
        setTanggal(dtBayar)
        txtKonsumen.Clear()
        txtKeterangan.Clear()
        txtNominal.Clear()
        FillCombobox("SELECT EmployeeID,EmployeeName From Employee WHERE PositionID ='PC' ORDER BY EmployeeName ASC", cmbPic1, 2, dtPic1)
        FillCombobox("SELECT EmployeeID,EmployeeName From Employee WHERE PositionID ='PC' ORDER BY EmployeeName ASC", cmbPic2, 2, dtPic2)
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        If txtKwitansi.Text <> "" Then
            StrSQL = ""
            StrSQL = "SELECT * FROM Kwitansi WHERE NoKwitansi = '" & antisqli(txtKwitansi.Text) & "' "
            RunSQL(StrSQL, 1)
            If dt.Rows.Count > 0 Then
                cmbPic1.SelectedValue = dt.Rows(0)("PIC1").ToString()
                cmbPic2.SelectedValue = dt.Rows(0)("PIC2").ToString()
                dtAmbil.Text = dt.Rows(0)("TglAmbil").ToString()
                cmbStatus.Text = dt.Rows(0)("StatusKwitansi").ToString()
                dtBayar.Text = dt.Rows(0)("TglBayar").ToString()
                cmbFisik.Text = dt.Rows(0)("Fisik").ToString()
                txtKonsumen.Text = getFieldValue("SELECT MemberName From Member WHERE MemberID ='" & dt.Rows(0)("MemberID").ToString() & "'")
                txtNominal.Text = ribuan(dt.Rows(0)("Nominal").ToString())
                txtKeterangan.Text = dt.Rows(0)("Alasan").ToString()
            Else
                MessageBox.Show("Nomor Kwitansi Tidak Ditemukan !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ClearForm()
            End If

        End If
    End Sub

    Private Sub txtKwitansi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKwitansi.TextChanged
        ClearForm()
    End Sub
End Class