
Public Class PelunasanNormal

    Dim memberID As String
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmTabKontrak.txtFlag.Text = "Normal"
        frmTabKontrak.Show()
    End Sub

    Private Sub txtKontrak_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKontrak.TextChanged
        If txtKontrak.Text.Length = txtKontrak.MaxLength Then
            If ValidasiKontrak() Then
                FillForm()
            Else
                form_Clear()
            End If
        Else
            form_Clear()
        End If
    End Sub
    Private Sub FillForm()
        StrSQL = ""
        StrSQL = "SELECT m.MemberName,m.Address "
        StrSQL &= ",'Objek'=CASE WHEN a.ApplicationTypeID = 1 THEN 'Motor Baru'"
        StrSQL &= " WHEN a.ApplicationTypeID = 2 THEN 'Dana Tunai'"
        StrSQL &= " WHEN a.ApplicationTypeID=3 THEN 'Elektronik' ELSE 'KTA' END"
        StrSQL &= ",a.EngineCode,a.MotorType,a.Tenor,c.State,"
        StrSQL &= "SUBSTRING('JAN FEB MAR APR MEI JUN JUL AGU SEP OKT NOV DES ',"
        StrSQL &= "(convert(int,month(c.BastDate)) * 4) - 3, 3) "
        StrSQL &= "+ '-' + CONVERT(nvarchar,year(c.bastdate)) as [Bulan Booking]"
        StrSQL &= ",m.MemberID as MemberID"
        StrSQL &= " FROM Member m,Application a,contract c where c.ContractID = a.ContractID"
        StrSQL &= " AND a.MemberID=m.MemberID"
        StrSQL &= String.Format(" AND c.ContractID='{0}'", txtKontrak.Text)
        RunSQL(StrSQL, 1)

        txtKonsumen.Text = dt.Rows(0)("MemberName").ToString()
        txtAlamat.Text = dt.Rows(0)("Address").ToString()
        txtObjek.Text = dt.Rows(0)("Objek").ToString()
        txtMesin.Text = dt.Rows(0)("EngineCode").ToString()
        txtTipe.Text = dt.Rows(0)("MotorType").ToString()
        txtTenor.Text = dt.Rows(0)("Tenor").ToString()
        txtBulan.Text = dt.Rows(0)("Bulan Booking").ToString()
        memberID = dt.Rows(0)("MemberID").ToString()

        If dt.Rows(0)("State").ToString() = "1" Then
            cmbStatus.Text = "Aktif"
        Else
            cmbStatus.Text = "Lunas"
        End If

    End Sub

    Private Sub PelunasanNormal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        form_Clear()
    End Sub
    Private Sub form_Clear()
        txtKonsumen.Clear()
        txtAlamat.Clear()
        txtObjek.Clear()
        txtMesin.Clear()
        txtTipe.Clear()
        txtTenor.Clear()
        txtBulan.Clear()
        cmbStatus.Text = "Aktif"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtHidden.Text = txtKontrak.Text Then
            Dim status As Integer
            If cmbStatus.Text = "Lunas" Then
                status = 2
            Else
                status = 1
            End If

            Dim result As Integer = MessageBox.Show("Anda Ingin mengubah status kontrak?", "Perhatian", MessageBoxButtons.YesNo)
            If result = vbYes Then
                StrSQL = "UPDATE Contract SET State=" & status & " WHERE ContractID ='" & txtKontrak.Text & "' "
                RunSQL(StrSQL, 0)
                MessageBox.Show("Status Kontrak Berhasil Diubah")
                form_Clear()
            Else
                form_Clear()
            End If
        Else
            MessageBox.Show("Status Gagal Diubah")
            form_Clear()
        End If
    End Sub

    Private Function ValidasiKontrak()
        StrSQL = ""
        StrSQL = "SELECT ContractID From contractDetail GROUP BY ContractID HAVING COUNT(noKwitansi) = COUNT([index]) AND SUM(Outstanding) < SUM (outstandingReceive)"
        StrSQL &= " AND ContractID='" & txtKontrak.Text & "' "
        RunSQL(StrSQL, 1)

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class