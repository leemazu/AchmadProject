Imports System.Xml
Public Class EntryBPKB
    Dim FlagGrid As Boolean
    Dim MemberID As String
    Dim oldBpkbNo As String
    Dim flagInsUpd As String

    Private Sub EntryBPKB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
    End Sub



    Private Function Validation()
        If txtNoBpkb.Text = "" Then
            MessageBox.Show("No Bpkb Harus Diisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNoBpkb.Focus()
            Return False
        ElseIf txtNamabpkb.Text = "" Then
            MessageBox.Show("Nama Bpkb Harus Diisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNamabpkb.Focus()
            Return False
        ElseIf txtPlatno.Text = "" Then
            MessageBox.Show("Nomor Polisi Harus Diisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPlatno.Focus()
            Return False
        ElseIf txtMesin.Text = "" Then
            MessageBox.Show("Nomor Mesin Harus Diisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMesin.Focus()
            Return False
        ElseIf txtRangka.Text = "" Then
            MessageBox.Show("Nomor Rangka Harus Diisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRangka.Focus()
            Return False
            Return False
        ElseIf txtWarna.Text = "" Then
            MessageBox.Show("Warna Harus Diisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtWarna.Focus()
            Return False
        ElseIf txtPengambil.Text = "" Then
            MessageBox.Show("Pengambil Diisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPengambil.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub FillCombo()
        Dim TableBpkb As New DataTable
        Dim dtKota As New DataTable
        Dim dtKecamatan As New DataTable
        Dim dtKelurahan As New DataTable

        StrSQL = ""
        StrSQL = "Sp_Reference_CBO 'BST'"
        FillCombobox(StrSQL, cmbStatusBpkb, 2, TableBpkb)
        FillCombobox("select*from v_kota ORDer BY city asc", cmbBpkbKota, 1, dtKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbBpkbKota.Text + "' ORDER BY [SubDistrict] ASC", cmbBpkbKecamatan, 1, dtKecamatan)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbBpkbKecamatan.Text + "' ORDER BY [Village] ASC", cmbBpkbKelurahan, 2, dtKelurahan)
    End Sub

    Private Sub setTanggal()
        dtMasuk.Text = CStr(Now)
        dtKeluar.Text = CStr(Now)

        dtMasuk.Format = DateTimePickerFormat.Custom
        dtMasuk.CustomFormat = "dd/MM/yyyy"

        dtKeluar.Format = DateTimePickerFormat.Custom
        dtKeluar.CustomFormat = "dd/MM/yyyy"

    End Sub

    Private Sub FillGrid()
        'Dim dsBpkb As New DataSet
        'StrSQL = ""
        'StrSQL = "SELECT Application.ContractID as [No Kontrak],Application.ApplicationID as [No Aplikasi],"
        'StrSQL &= " _Reference.ReferenceName as Pos,Member.MemberName as Pemohon From Application "
        'StrSQL &= "INNER JOIN Contract ON Application.ContractID = contract.ContractID  "
        'StrSQL &= "INNER JOIN _Reference ON Application.PosID = _Reference.ReferenceID "
        'StrSQL &= "INNER JOIN Member ON Application.MemberID = Member.MemberID "
        'StrSQL &= "WHERE Application.ApplicationTypeID = 2 AND Contract.BpkbNo = '' "

        'RunSQL(StrSQL, 2, "TableApplication", , dsBpkb)
        'gv1.DataSource = dsBpkb
        'gv1.DataMember = "TableApplication"
        'FlagGrid = True

        Dim dsGridBPKB As New DataSet
        StrSQL = ""
        StrSQL = "SELECT DISTINCT TOP 100 * FROM V_BpkbList order by [Nama Pelanggan] ASC "
        RunSQL(StrSQL, 2, "TableBpkb", , dsGridBPKB)
        gv1.DataSource = dsGridBPKB
        gv1.DataMember = "TableBpkb"
        gv1.AutoResizeColumns()

    End Sub


    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        'FlagGrid = False
        'Dim dsFilterBpkb As New DataSet
        'StrSQL = ""
        'StrSQL = "SELECT Application.ContractID as [No Kontrak],Application.ApplicationID as [No Aplikasi],"
        'StrSQL &= " _Reference.ReferenceName as Pos,Member.MemberName as Pemohon From Application "
        'StrSQL &= "INNER JOIN Contract ON Application.ContractID = contract.ContractID  "
        'StrSQL &= "INNER JOIN _Reference ON Application.PosID = _Reference.ReferenceID "
        'StrSQL &= "INNER JOIN Member ON Application.MemberID = Member.MemberID "
        'StrSQL &= "WHERE Application.ApplicationTypeID = 2 "
        'StrSQL &= "AND (Application.ContractID LIKE '%" & txtCari.Text & "%' OR "
        'StrSQL &= "Member.MemberName LIKE '%" & txtCari.Text & "%')"
        'RunSQL(StrSQL, 2, "FilterBpkb", , dsFilterBpkb)
        'gv1.DataSource = dsFilterBpkb
        'gv1.DataMember = "FilterBpkb"
        'FlagGrid = True
        Dim filter As String = antisqli(txtCari.Text)
        Dim dsFilterBpkb As New DataSet
        StrSQL = ""
        StrSQL = "SELECT DISTINCT TOP 100 * FROM V_BpkbList  "
        StrSQL &= "WHERE [Nomor Aplikasi] LIKE '%" & filter & "%'  "
        StrSQL &= "OR [Nomor Kontrak] LIKE '%" & filter & "%'  "
        StrSQL &= "OR [Nama Pelanggan] LIKE '%" & filter & "%'  "
        StrSQL &= "ORDER BY [Nama Pelanggan] ASC "
        RunSQL(StrSQL, 2, "TableFilterBpkb", , dsFilterBpkb)
        gv1.DataSource = dsFilterBpkb
        gv1.DataMember = "TableFilterBpkb"
        gv1.AutoResizeColumns()
    End Sub

    Private Sub gv1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gv1.SelectionChanged
        'If FlagGrid = True Then
        '    Dim statusBpkb As Integer
        '    Try
        '        statusBpkb = CInt(getFieldValue("Select State From Contract Where ContractId='" & CStr(gv1.CurrentRow.Cells("No Kontrak").Value & "' ")))
        '    Catch ex As Exception

        '    End Try

        '    txtKontrak.Text = CStr(gv1.CurrentRow.Cells("No Kontrak").Value)
        '    txtAplikasi.Text = CStr(gv1.CurrentRow.Cells("No Aplikasi").Value)
        '    txtPos.Text = CStr(gv1.CurrentRow.Cells("Pos").Value)
        '    txtPemohon.Text = CStr(gv1.CurrentRow.Cells("Pemohon").Value)
        '    MemberID = getFieldValue("SELECT MemberID From Application Where ApplicationID ='" & txtAplikasi.Text & "'")

        '    If statusBpkb = 1 Then
        '        txtStatusKontrak.Text = "Aktif"
        '    Else
        '        txtStatusKontrak.Text = "Lunas"
        '    End If

        'End If

        Try
            txtAplikasi.Text = gv1.CurrentRow.Cells(0).Value.ToString()
            txtPemohon.Text = gv1.CurrentRow.Cells(2).Value.ToString()
            txtPos.Text = gv1.CurrentRow.Cells(4).Value.ToString()
            txtNoBpkb.Text = gv1.CurrentRow.Cells(5).Value.ToString()
            txtKontrak.Text = gv1.CurrentRow.Cells(1).Value.ToString()
            oldBpkbNo = gv1.CurrentRow.Cells(5).Value.ToString()
            SetFlagBpkbInfo(txtNoBpkb.Text)
            If txtKontrak.Text = "" Then
                txtStatusKontrak.Text = "Kontrak Belum Dibuat"
            Else
                txtStatusKontrak.Text = getFieldValue("SELECT TOP 1 [Status Kontrak] FROM V_ContractStatus WHERE [Nomor Kontrak] = '" & txtKontrak.Text & "'")
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Validation() Then
    '        Dim result As Integer = MessageBox.Show("Anda yakin ingin menginput data ini ?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '        If result = vbYes Then
    '            updateAplikasi()
    '            UpdateKontrak()
    '            UpdateBpkb()
    '            MessageBox.Show("Data Berhasil Ditambah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            ClearForm()
    '        Else
    '            ClearForm()
    '        End If
    '    End If
    'End Sub

    Private Sub ClearForm()
        MemberID = ""
        txtKontrak.Clear()
        txtAplikasi.Clear()
        txtPemohon.Clear()
        txtPos.Clear()
        txtStatusKontrak.Clear()
        txtNoBpkb.Clear()
        txtNamabpkb.Clear()
        txtPlatno.Clear()
        txtMesin.Clear()
        txtRangka.Clear()
        txtWarna.Clear()
        txtPengambil.Clear()
        FillGrid()
        setTanggal()
        FillCombo()
    End Sub

    Private Sub SetFlagBpkbInfo(ByVal noBpkb As String)
        Try


            StrSQL = ""
            StrSQL = "SELECT * FROM BPKB WHERE NoBpkb = '" & antisqli(noBpkb) & "' "
            RunSQL(StrSQL, 1)

            If dt.Rows.Count > 0 Then
                flagInsUpd = "UPD"
                lblWarn.Visible = False
                btnReset.Enabled = True
                FillBpkbInfo(noBpkb)
            Else
                flagInsUpd = "INS"
                lblWarn.Visible = True
                btnReset.Enabled = False
                ClearComponent()
            End If
            DisableComponent()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub FillBpkbInfo(ByVal Bpkbno As String)
        Try
            StrSQL = ""
            StrSQL = "SELECT * FROM V_BpkbDetail Where NoBpkb = '" & Bpkbno & "' "
            RunSQL(StrSQL, 1)

            If dt.Rows.Count > 0 Then
                txtNamabpkb.Text = dt.Rows(0)("NamaBpkb").ToString()
                txtPlatno.Text = dt.Rows(0)("NomorPolisi").ToString()
                txtMesin.Text = dt.Rows(0)("NomorMesin").ToString()
                txtRangka.Text = dt.Rows(0)("NomorRangka").ToString()
                txtWarna.Text = dt.Rows(0)("Warna").ToString()
                dtMasuk.Text = dt.Rows(0)("TglMasuk").ToString()
                dtKeluar.Text = dt.Rows(0)("TglKeluar").ToString()
                txtPengambil.Text = dt.Rows(0)("Pengambil").ToString()
                cmbStatusBpkb.SelectedValue = dt.Rows(0)("Status").ToString()
                txtBPKBAlamat.Text = dt.Rows(0)("Alamat").ToString()
                txtBpkbRt.Text = dt.Rows(0)("RT").ToString()
                txtBpkbRW.Text = dt.Rows(0)("RW").ToString()
                Dim kodepos As String = dt.Rows(0)("Kodepos").ToString()
                cmbBpkbKota.Text = detailAlamat(kodepos).kota
                cmbBpkbKecamatan.Text = detailAlamat(kodepos).kecamatan
                cmbBpkbKelurahan.Text = detailAlamat(kodepos).kelurahan
             

            End If
        Catch ex As Exception

        End Try
        

    End Sub




    Private Function UpdateBpkb(ByVal insUpdFlag As String) As Boolean
        Try
            StrSQL = ""
            StrSQL = "Sp_BpkbIU "
            StrSQL &= "'" & insUpdFlag & "' "
            StrSQL &= ",'" & antisqli(txtNoBpkb.Text) & "' "
            StrSQL &= ",'" & antisqli(txtNamabpkb.Text) & "' "
            StrSQL &= ",'" & antisqli(txtPlatno.Text) & "' "
            StrSQL &= ",'" & antisqli(txtMesin.Text) & "' "
            StrSQL &= ",'" & antisqli(txtRangka.Text) & "' "
            StrSQL &= ",'" & antisqli(txtWarna.Text) & "' "
            StrSQL &= ",'" & antisqli(dtMasuk.Value.Date) & "' "
            StrSQL &= ",'" & antisqli(dtKeluar.Value.Date) & "' "
            StrSQL &= ",'" & antisqli(txtPengambil.Text) & "' "
            StrSQL &= ",'" & antisqli(cmbStatusBpkb.SelectedValue) & "' "
            StrSQL &= ",'" & antisqli(txtBPKBAlamat.Text) & "' "
            StrSQL &= ",'" & antisqli(cmbBpkbKelurahan.SelectedValue) & "' "
            StrSQL &= ",'" & antisqli(txtBpkbRt.Text) & "' "
            StrSQL &= ",'" & antisqli(txtBpkbRW.Text) & "' "
            StrSQL &= ",'" & antisqli(txtAplikasi.Text) & "' "
            StrSQL &= ",'" & antisqli(oldBpkbNo) & "' "
            RunSQL(StrSQL, 0)
            Return True
        Catch ex As Exception
            Return False
            SaveErrorLog(ex.Message, "FORM BPKB update")
        End Try

    End Function

    Private Sub DisableComponent()
        txtNoBpkb.Enabled = False
        txtNamabpkb.Enabled = False
        txtPlatno.Enabled = False
        txtMesin.Enabled = False
        txtRangka.Enabled = False
        txtWarna.Enabled = False
        dtMasuk.Enabled = False
        dtKeluar.Enabled = False
        txtPengambil.Enabled = False
        cmbStatusBpkb.Enabled = False
        txtBPKBAlamat.Enabled = False
        cmbBpkbKecamatan.Enabled = False
        cmbBpkbKelurahan.Enabled = False
        cmbBpkbKota.Enabled = False
        txtBpkbRt.Enabled = False
        txtBpkbRW.Enabled = False
        btnSave.Enabled = False
        btnUpdate.Enabled = True
    End Sub

    Private Sub EnabledComponent()
        txtNoBpkb.Enabled = True
        txtNamabpkb.Enabled = True
        txtPlatno.Enabled = True
        txtMesin.Enabled = True
        txtRangka.Enabled = True
        txtWarna.Enabled = True
        dtMasuk.Enabled = True
        dtKeluar.Enabled = True
        txtPengambil.Enabled = True
        cmbStatusBpkb.Enabled = True
        txtBPKBAlamat.Enabled = True
        cmbBpkbKecamatan.Enabled = True
        cmbBpkbKelurahan.Enabled = True
        cmbBpkbKota.Enabled = True
        txtBpkbRt.Enabled = True
        txtBpkbRW.Enabled = True
        btnSave.Enabled = True
        btnUpdate.Enabled = False
    End Sub

    Private Sub ClearComponent()
        txtNoBpkb.Clear()
        txtNamabpkb.Clear()
        txtPlatno.Clear()
        txtMesin.Clear()
        txtRangka.Clear()
        txtWarna.Clear()
        setTanggal()
        cmbStatusBpkb.SelectedIndex = 0
        txtBPKBAlamat.Clear()
        cmbBpkbKota.SelectedIndex = 0
        txtBpkbRt.Clear()
        txtBpkbRW.Clear()
    End Sub

    Private Function ValidationInput() As Boolean
        If txtNoBpkb.Text = "" Then
            errorMessage = "Nomor BPKB belum diisi !"
            Return False
        ElseIf txtNamabpkb.Text = "" Then
            errorMessage = "Nama BPKB belum diisi !"
            Return False
        ElseIf txtPlatno.Text = "" Then
            errorMessage = "Nomor Polisi belum diisi !"
            Return False
        ElseIf txtMesin.Text = "" Then
            errorMessage = "Nomor Mesin belum diisi !"
            Return False
        ElseIf txtRangka.Text = "" Then
            errorMessage = "Nomor Rangka belum diisi !"
            Return False
        ElseIf txtWarna.Text = "" Then
            errorMessage = "Warna belum diisi !"
            Return False
        ElseIf txtBPKBAlamat.Text = "" Then
            errorMessage = "Alamat BPKB belum diisi !"
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        EnabledComponent()
    End Sub


 
    Private Sub cmbBpkbKota_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBpkbKota.SelectedIndexChanged
        Dim tblKec1 As New DataTable
        tblKec1.Rows.Clear()
        With cmbBpkbKecamatan
            .DataSource = Nothing
            StrSQL = ""
            StrSQL = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbBpkbKota.Text + "' ORDER BY [SubDistrict] ASC"
            FillCombobox(StrSQL, cmbBpkbKecamatan, 1, tblKec1)
        End With
    End Sub
    Private Sub cmbBpkbKecamatan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBpkbKecamatan.SelectedIndexChanged
        Dim tblKel1 As New DataTable
        tblKel1.Rows.Clear()
        With cmbBpkbKelurahan
            .DataSource = Nothing
            StrSQL = ""
            StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbBpkbKecamatan.Text + "' ORDER BY [Village] ASC"
            FillCombobox(StrSQL, cmbBpkbKelurahan, 2, tblKel1)
        End With
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationInput() Then
            Dim pesan As String = "Anda Akan Menginput Data BPKB dengan Detail Berikut : "
            pesan &= vbNewLine & "---------------------------------------------------------------------"
            pesan &= vbNewLine & "Nomor BPKB " & vbTab & ": " & txtNoBpkb.Text
            pesan &= vbNewLine & "Nama BPKB " & vbTab & ": " & txtNamabpkb.Text
            pesan &= vbNewLine & "Nomor Mesin " & vbTab & ": " & txtMesin.Text
            pesan &= vbNewLine & "Nomor Rangka " & vbTab & ": " & txtRangka.Text
            pesan &= vbNewLine & vbNewLine & "Apakah Anda yakin ? "
            Dim result As Integer = MessageBox.Show(pesan, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = vbYes Then
                If UpdateBpkb(flagInsUpd) Then
                    MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearForm()
                End If
            End If
        Else
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtBpkbRt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBpkbRt.KeyPress, txtBpkbRW.KeyPress
        decimalOnly(sender, e, sender.Text)
    End Sub
End Class