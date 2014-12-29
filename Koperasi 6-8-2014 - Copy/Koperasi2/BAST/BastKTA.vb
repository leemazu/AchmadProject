Public Class BastKTA
    Dim flagGrid As Boolean = False
    Private Sub BastKTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        settanggal()
        FillTable()
        FillCombo()
    End Sub
    Private Sub FillCombo()
        Dim tableCollector As DataTable = CType(getTable(), DataTable)
        StrSQL = ""
        StrSQL = "SpEmployee_CBO 'CL'"
        FillComboWithValue(cmbCollector, StrSQL, tableCollector)
    End Sub
    Private Sub settanggal()
        ' Dim tanggalAngsuran As Date = Date.Now.AddMonths(1)
        dtPem.Text = CStr(Now)
        ' dtAngsuran.Text = CStr(tanggalAngsuran)
        dtBast.Text = CStr(Now)
        dtKontrak.Text = CStr(Now)
        dtPem.Format = DateTimePickerFormat.Custom
        dtPem.CustomFormat = "dd/MM/yyyy"
        dtAngsuran.Format = DateTimePickerFormat.Custom
        dtAngsuran.CustomFormat = "dd/MM/yyyy"
        dtBast.Format = DateTimePickerFormat.Custom
        dtBast.CustomFormat = "dd/MM/yyyy"
        dtKontrak.Format = DateTimePickerFormat.Custom
        dtKontrak.CustomFormat = "dd/MM/yyyy"


    End Sub

    Private Sub FillTable()
        Dim DsKTA As New DataSet
        StrSQL = "SELECT ApplicationID as [No.Aplikasi],"
        StrSQL &= "MemberName as [Nama Konsumen],"
        StrSQL &= "Convert(varchar(10),convert(date,BirthDate,106),103) as [Tanggal Lahir],"
        StrSQL &= "convert(int,MotorPrice) as [Pinjaman],"
        StrSQL &= "Tenor,convert(int,Installment) as [Angsuran],"
        StrSQL &= "convert(int,(MotorPrice+InsuranceAdmin+LoanAdmin)) as Modal "
        StrSQL &= "from [Application] INNER JOIN Member ON application.MemberID=member.memberid "
        StrSQL &= "AND Application.ApplicationTypeID ='4' AND Application.State=0 ORDER BY ApplicationID ASC"
        RunSQL(StrSQL, 2, "BastKTA", , DsKTA)
        gv1.DataSource = DsKTA
        gv1.DataMember = "BastKTA"
        flagGrid = True
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        Dim dsFilterKta As New DataSet
        StrSQL = "SELECT TOP 100 ApplicationID as [No.Aplikasi],"
        StrSQL &= "MemberName as [Nama Konsumen],"
        StrSQL &= "Convert(varchar(10),convert(date,BirthDate,103),103) as [Tanggal Lahir],"
        StrSQL &= "convert(int,MotorPrice) as [Pinjaman],"
        StrSQL &= "Tenor,convert(int,Installment) as [Angsuran],"
        StrSQL &= "convert(int,(MotorPrice+InsuranceAdmin+LoanAdmin)) as Modal "
        StrSQL &= "from [Application] app,Member mem "
        StrSQL &= "WHERE (ApplicationID LIKE '%" & antisqli(txtCari.Text) & "%' "
        StrSQL &= "OR MemberName LIKE '%" & antisqli(txtCari.Text) & "%') "
        StrSQL &= "AND App.ApplicationTypeID ='4' "
        StrSQL &= "AND App.MemberID = Mem.MemberID AND Application.State=0"
        RunSQL(StrSQL, 2, "FilterBastKTA", , dsFilterKta)
        gv1.DataSource = dsFilterKta
        gv1.DataMember = "FilterBastKTA"
    End Sub
    Private Sub dtBast_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtBast.ValueChanged
        Dim tanggalAngsuran As Date = dtBast.Value.AddMonths(1)
        dtAngsuran.Text = CStr(tanggalAngsuran)
    End Sub
    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click

        If InputVerification() Then
            Dim pesan As String = "Anda Akan Membuat Kontrak dengan Detail Berikut : "
            pesan &= vbNewLine & "---------------------------------------------------------------------"
            pesan &= vbNewLine & "Nomor Kontrak " & vbTab & vbTab & ": " & txtKontrak.Text
            pesan &= vbNewLine & "Nama Pelanggan Kontrak " & vbTab & ": " & txtPemNama.Text
            pesan &= vbNewLine & "Tanggal Kontrak " & vbTab & vbTab & ": " & dtKontrak.Text
            pesan &= vbNewLine & vbNewLine & "Apakah Anda yakin ? "
            Dim result As Integer = MessageBox.Show(pesan, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = vbYes Then
                If CreateContract() = True Then
                    MessageBox.Show("Kontrak Berhasil Dibuat")
                    flagGrid = False
                    form_Clear()
                    FillTable()
                Else
                    MessageBox.Show("Kontrak Tidak Berhasil Dibuat")
                End If

            End If
        Else
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub form_Clear()
        settanggal()
        txtAplikasi.Clear()
        txtPemNama.Clear()
        txtTenor.Clear()
        txtAngsuran.Clear()
        txtModal.Clear()
        txtKontrak.Clear()
        cmbCollector.SelectedIndex = 0

    End Sub
    Private Sub gv1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gv1.SelectionChanged
        Try
            If flagGrid = True Then
                txtAplikasi.Text = CStr(gv1.CurrentRow.Cells(0).Value)
                txtPemNama.Text = CStr(gv1.CurrentRow.Cells(1).Value)
                RunSQL("SELECT BirthDate from Member inner join Application ON member.MemberID=application.memberid AND applicationid ='" & antisqli(txtAplikasi.Text) & "'", 1)
                dtPem.Text = CStr(dt.Rows(0)("BirthDate"))
                'dtPem.Text = gv1.CurrentRow.Cells(2).Value
                txtPinjaman.Text = CStr(gv1.CurrentRow.Cells(3).Value)
                txtTenor.Text = CStr(gv1.CurrentRow.Cells(4).Value)
                txtAngsuran.Text = CStr(gv1.CurrentRow.Cells(5).Value)
                txtModal.Text = CStr(gv1.CurrentRow.Cells(6).Value)
                txtKontrak.Text = CStr(AutoNumberContract(txtAplikasi.Text, "04"))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function CreateContract() As Boolean
        Try
            Dim pokok As Double = CDbl(getFieldValue("SELECT BaseDebt from Application Where ApplicationID='" & txtAplikasi.Text & "'"))
            'Dim BungaPengali As Double = CDbl(txtBungaPengali.Text)
            Dim EffectiveInterestP As Double = CDbl(getFieldValue("SELECT EffectiveInterestP from Application Where ApplicationID='" & txtAplikasi.Text & "'"))
            Dim FlagInsUpd As String = "INS"
            Dim FlagKontrak As String = "BAST_KTA"
            StrSQL = ""
            StrSQL = "Sp_ContractIU '" & FlagInsUpd & "', "
            StrSQL &= "'" & FlagKontrak & "',"
            StrSQL &= "'" & txtAplikasi.Text & "',"
            StrSQL &= "'" & txtKontrak.Text & "',"
            StrSQL &= "'" & dtKontrak.Value & "',"
            StrSQL &= "'" & dtBast.Value & "',"
            StrSQL &= "'" & dtAngsuran.Value & "',"
            StrSQL &= "'" & cmbCollector.SelectedValue & "',"
            StrSQL &= "'" & UserName & "',"
            StrSQL &= "" & CInt(txtTenor.Text) & ","
            StrSQL &= "" & pokok & ","
            StrSQL &= "" & EffectiveInterestP & ",0,0"
            RunSQL(StrSQL, 0)
            Return True
        Catch ex As Exception
            Return False
        End Try
      
    End Function

    Private Function InputVerification() As Boolean
        StrSQL = ""
        StrSQL = "SELECT ContractID From Contract WHERE ContractID = '" & txtKontrak.Text & "' "
        RunSQL(StrSQL, 1)
        If txtKontrak.Text = "" Or txtKontrak.Text.Length < 7 Then
            errorMessage = "Nomor Kontrak Salah"
            Return False
        ElseIf dt.Rows.Count > 0 Then
            errorMessage = "Nomor Kontrak " & txtKontrak.Text & " Sudah Terdaftar "
            Return False
        ElseIf txtAplikasi.Text = "" Then
            errorMessage = "Tidak ada aplikasi yang diproses"
            Return False
        Else
            Return True
        End If
    End Function

End Class