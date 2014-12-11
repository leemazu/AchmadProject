Imports System.Xml
Public Class EntryBPKB
    Dim FlagGrid As Boolean
    Dim MemberID As String

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
        StrSQL = ""
        StrSQL = "Sp_Reference_CBO 'BST'"
        FillCombobox(StrSQL, cmbStatusBpkb, 2, TableBpkb)
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
        StrSQL = ""
        StrSQL = "SELECT Application.ContractID as [No Kontrak],Application.ApplicationID as [No Aplikasi],"
        StrSQL &= " _Reference.ReferenceName as Pos,Member.MemberName as Pemohon From Application "
        StrSQL &= "INNER JOIN Contract ON Application.ContractID = contract.ContractID  "
        StrSQL &= "INNER JOIN _Reference ON Application.PosID = _Reference.ReferenceID "
        StrSQL &= "INNER JOIN Member ON Application.MemberID = Member.MemberID "
        StrSQL &= "WHERE Application.ApplicationTypeID = 2 AND Contract.BpkbNo = '' "

        RunSQL(StrSQL, 2, "TableApplication")
        gv1.DataSource = ds
        gv1.DataMember = "TableApplication"
        FlagGrid = True

    End Sub


    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        FlagGrid = False
        da.Dispose()
        ds.Clear()
        StrSQL = ""
        StrSQL = "SELECT Application.ContractID as [No Kontrak],Application.ApplicationID as [No Aplikasi],"
        StrSQL &= " _Reference.ReferenceName as Pos,Member.MemberName as Pemohon From Application "
        StrSQL &= "INNER JOIN Contract ON Application.ContractID = contract.ContractID  "
        StrSQL &= "INNER JOIN _Reference ON Application.PosID = _Reference.ReferenceID "
        StrSQL &= "INNER JOIN Member ON Application.MemberID = Member.MemberID "
        StrSQL &= "WHERE Application.ApplicationTypeID = 2 "
        StrSQL &= "AND (Application.ContractID LIKE '%" & txtCari.Text & "%' OR "
        StrSQL &= "Member.MemberName LIKE '%" & txtCari.Text & "%')"
        RunSQL(StrSQL, 2, "FilterBpkb")
        gv1.DataSource = ds
        gv1.DataMember = "FilterBpkb"
        FlagGrid = True
    End Sub

    Private Sub gv1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gv1.SelectionChanged
        If FlagGrid = True Then
            Dim statusBpkb As Integer
            Try
                statusBpkb = CInt(getFieldValue("Select State From Contract Where ContractId='" & CStr(gv1.CurrentRow.Cells("No Kontrak").Value & "' ")))
            Catch ex As Exception

            End Try

            txtKontrak.Text = CStr(gv1.CurrentRow.Cells("No Kontrak").Value)
            txtAplikasi.Text = CStr(gv1.CurrentRow.Cells("No Aplikasi").Value)
            txtPos.Text = CStr(gv1.CurrentRow.Cells("Pos").Value)
            txtPemohon.Text = CStr(gv1.CurrentRow.Cells("Pemohon").Value)
            MemberID = getFieldValue("SELECT MemberID From Application Where ApplicationID ='" & txtAplikasi.Text & "'")

            If statusBpkb = 1 Then
                txtStatusKontrak.Text = "Aktif"
            Else
                txtStatusKontrak.Text = "Lunas"
            End If

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Validation() Then
            Dim result As Integer = MessageBox.Show("Anda yakin ingin menginput data ini ?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = vbYes Then
                UpdateAplikasi()
                UpdateKontrak()
                UpdateBpkb()
                MessageBox.Show("Data Berhasil Ditambah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearForm()
            Else
                ClearForm()
            End If
        End If
    End Sub

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

    Private Sub UpdateKontrak()
        StrSQL = ""
        StrSQL = "Update Contract Set BpkbNo='" & txtNoBpkb.Text & "',"
        StrSQL &= "BpkbState='" & cmbStatusBpkb.SelectedValue & "' "
        StrSQL &= "WHERE ContractID ='" & txtKontrak.Text & "' "
        RunSQL(StrSQL, 0)
    End Sub

    Private Sub updateAplikasi()
        StrSQL = ""
        StrSQL = "Update Application Set BpkbNo='" & txtNoBpkb.Text & "',"
        StrSQL &= "FrameCode='" & txtRangka.Text & "',"
        StrSQL &= "EngineCode='" & txtMesin.Text & "',"
        StrSQL &= "PlatNo='" & txtPlatno.Text & "' "
        StrSQL &= "WHERE ApplicationID = '" & txtAplikasi.Text & "' "
        RunSQL(StrSQL, 0)
    End Sub

    Private Sub UpdateBpkb()
        StrSQL = ""
        StrSQL = "Insert Into Bpkb (NoBpkb,ContractID,TglMasuk,TglKeluar,PengambilBpkb,StatusBpkb) VALUES ("
        StrSQL &= "'" & txtNoBpkb.Text & "',"
        StrSQL &= "'" & txtKontrak.Text & "',"
        StrSQL &= "'" & dtMasuk.Value & "',"
        StrSQL &= "'" & dtKeluar.Value & "',"
        StrSQL &= "'" & txtPengambil.Text & "',"
        StrSQL &= "'" & cmbStatusBpkb.SelectedValue & "')"
        RunSQL(StrSQL, 0)
    End Sub

End Class