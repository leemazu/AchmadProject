Imports System.Xml
Public Class frmKaryawan
    Dim dtKecamatan As New DataTable
    Dim dtKelurahan As New DataTable
    Dim FlagAkun As String
    Dim FlagMember As String

#Region "Event Tombol"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmTabKaryawan.Show()
        frmTabKaryawan.MdiParent = frmMain
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        StrSQL = ""
        StrSQL = "SELECT * FROM Employee Where EmployeeID = '" & antisqli(txtNIK.Text) & "' "
        RunSQL(StrSQL, 1)
        If dt.Rows.Count > 0 Then
            If Validation() Then
                Try
                    Employee_SAV()

                    If ValidationID() Then
                        If FlagAkun = "INS" Then
                            Akun_SAV()
                            Akses_SAV()
                        ElseIf FlagAkun = "UPD" Then
                            Akun_SAV()
                            Akses_SAV()
                        End If
                    End If
                    MessageBox.Show("Data Berhasil Diubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearForm()
                    AutoNumberKaryawan()
                Catch ex As Exception
                    MessageBox.Show("Data Gagal Diubah", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try
            End If
        Else
            If Validation() Then
                Try
                    Employee_SAV()

                    If ValidationID() Then
                        Akun_SAV()
                        Akses_SAV()
                    End If
                    MessageBox.Show("Data Berhasil Ditambah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearForm()
                    AutoNumberKaryawan()
                Catch ex As Exception
                    MessageBox.Show("Data Gagal Ditambahkan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try
            End If
        End If
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ClearForm()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub



#End Region
#Region "ComboBox Thing"
    Private Sub isiFormComboBox()
        Dim dtStatus As DataTable = getTable()
        Dim dtStatusAkun As DataTable = getTable()
        Dim dtGender As New DataTable
        Dim dtKota As New DataTable


        Dim dtPosisi As DataTable = getTable()
        dtPosisi.Rows.Add("CA", "Credit Analyst")
        dtPosisi.Rows.Add("CL", "Collector")
        dtPosisi.Rows.Add("PC", "PC")
        dtPosisi.Rows.Add("SY", "Surveyor")
        dtPosisi.Rows.Add("SM", "Salesman")
        dtPosisi.Rows.Add("ADM", "Administrasi")
        dtPosisi.Rows.Add("SAD", "Admin Aplikasi")
        cmbPosisi.DataSource = dtPosisi
        cmbPosisi.ValueMember = "ID"
        cmbPosisi.DisplayMember = "NAMA"

        With dtStatus
            .Rows.Add("1", "Aktif")
            .Rows.Add("0", "Non-Aktif")
        End With

        With dtStatusAkun
            .Rows.Add("1", "Aktif")
            .Rows.Add("0", "Non-Aktif")
        End With

        cmbStatus.DataSource = dtStatus
        cmbStatus.ValueMember = "ID"
        cmbStatus.DisplayMember = "NAMA"

        cmbStatusAkun.DataSource = dtStatusAkun
        cmbStatusAkun.ValueMember = "ID"
        cmbStatusAkun.DisplayMember = "NAMA"

        FillCombobox("SELECT ReferenceID,ReferenceName From _Reference WHERE ReferenceGroupID='GEN'", cmbGender, 2, dtGender)
        FillCombobox("select distinct City from [__AddrLocation] where City like 'JAKARTA%' or City like 'Kepulauan Seribu' OR City Like 'Bogor%' OR City Like 'Tangerang%' order by City asc", cmbKota, 1, dtKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbKota.Text + "' ORDER BY [SubDistrict] ASC", cmbKecamatan, 1, dtKecamatan)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKecamatan.Text + "' ORDER BY [Village] ASC", cmbKelurahan, 2, dtKelurahan)

    End Sub


    Private Sub cmbKota_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKota.SelectedIndexChanged
        dtKecamatan.Rows.Clear()
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbKota.Text + "' ORDER BY [SubDistrict] ASC", cmbKecamatan, 1, dtKecamatan)
    End Sub

    Private Sub cmbKecamatan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKecamatan.SelectedIndexChanged
        dtKelurahan.Rows.Clear()
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKecamatan.Text + "' ORDER BY [Village] ASC", cmbKelurahan, 2, dtKelurahan)
    End Sub

#End Region

    Private Sub ClearForm()
        txtNama.Clear()
        txtKTP.Clear()
        txtTmptLahir.Clear()
        txtAlamat.Clear()
        txtRT.Clear()
        txtRW.Clear()
        txtTelp.Clear()
        txtUsername.Clear()
        txtPassword1.Clear()
        txtPassword2.Clear()
        ckEditDT.Checked = False
        ckEditEle.Checked = False
        ckEditKaryawan.Checked = False
        ckEditKTA.Checked = False
        ckEditMB.Checked = False
        ckEntryBPKB.Checked = False
        ckEntryDT.Checked = False
        ckEntryMB.Checked = False
        ckEntryKTA.Checked = False
        ckEntryEle.Checked = False
        ckEntryKwitansi.Checked = False
        ckEntryPolis.Checked = False
        ckPelunasanAsuransi.Checked = False
        ckPelunasanDimuka.Checked = False
        ckPelunasanKhusus.Checked = False
        ckPelunasanNormal.Checked = False
        ckPembayaran.Checked = False
        ckVKontrakDT.Checked = False
        ckVKontrakEle.Checked = False
        ckVKontrakKTA.Checked = False
        ckVKontrakMB.Checked = False
        ckVReportKotnrak.Checked = False
        ckBBKontrak.Checked = False
        isiFormComboBox()
        setTanggal(dtTglLahir)
        Button2.Text = "Save"
        FlagMember = "INS"

    End Sub

    Private Sub frmKaryawan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AutoNumberKaryawan()
        ClearForm()
    End Sub

    Private Sub txtNIK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNIK.TextChanged
        If txtNIK.Text.Length = txtNIK.MaxLength Then
            StrSQL = ""
            StrSQL = String.Format("SELECT * FROM Employee WHERE EmployeeID ='{0}' ", antisqli(txtNIK.Text))
            RunSQL(StrSQL, 1)

            If dt.Rows.Count > 0 Then
                FlagMember = "UPD"
                Dim kodepos = dt.Rows(0)("PostalID").ToString()
                txtNama.Text = dt.Rows(0)("EmployeeName")
                cmbPosisi.SelectedValue = dt.Rows(0)("PositionID")
                cmbGender.SelectedValue = dt.Rows(0)("GenderID")
                cmbStatus.SelectedValue = dt.Rows(0)("state")
                txtKTP.Text = dt.Rows(0)("PersonalID").ToString()
                txtTmptLahir.Text = dt.Rows(0)("BirthPlace").ToString()
                If IsDBNull(dt.Rows(0)("BirthDate")) Then
                    dtTglLahir.Value = Now
                Else
                    dtTglLahir.Value = dt.Rows(0)("BirthDate")
                End If
                txtAlamat.Text = dt.Rows(0)("Address").ToString()
                txtTelp.Text = dt.Rows(0)("MobileNo").ToString()
                txtRT.Text = dt.Rows(0)("EmployeeRT").ToString()
                txtRW.Text = dt.Rows(0)("EmployeeRW").ToString()
                cmbKota.Text = getFieldValue("SELECT CITY FROM __AddrLocation Where AddrLocationID='" & kodepos & "'")
                cmbKecamatan.Text = getFieldValue("SELECT SubDistrict FROM __AddrLocation Where AddrLocationID='" & kodepos & "'")
                cmbKelurahan.Text = getFieldValue("SELECT Village FROM __AddrLocation Where AddrLocationID='" & kodepos & "'")
                FillAkses()
                Button2.Text = "Update"
            End If

        Else
            FlagMember = "INS"
            ClearForm()
        End If
    End Sub

    Private Sub AutoNumberKaryawan()
        Dim kodeTerakhir As String
        StrSQL = ""
        StrSQL = "SELECT TOP 1 EmployeeID From Employee ORDER BY EmployeeID DESC"
        RunSQL(StrSQL, 1)
        If dt.Rows.Count > 0 Then
            kodeTerakhir = dt.Rows(0)("EmployeeID")
        Else
            kodeTerakhir = ""
        End If
        txtNIK.Text = CreateAutoNumber("EM", 4, kodeTerakhir)
    End Sub

    Private Sub FillAkses()
        StrSQL = ""
        StrSQL = "SELECT * FROM Account Where EmployeeID ='" & antisqli(txtNIK.Text) & "' "
        RunSQL(StrSQL, 1)
        If dt.Rows.Count > 0 Then
            txtUsername.Text = dt.Rows(0)("UserID")
            txtPassword1.Text = dt.Rows(0)("UserPass")
            txtPassword2.Text = dt.Rows(0)("UserPass")
            cmbStatusAkun.SelectedValue = dt.Rows(0)("state")

        End If

        StrSQL = ""
        StrSQL = "SELECT * From __Akses Where EmployeeID ='" & antisqli(txtNIK.Text) & "' "
        RunSQL(StrSQL, 1)
        If dt.Rows.Count > 0 Then
            ckEntryDT.Checked = CBool(dt.Rows(0)("EnDT"))
            ckEntryMB.Checked = CBool(dt.Rows(0)("EnMB"))
            ckEntryEle.Checked = CBool(dt.Rows(0)("EnEle"))
            ckEntryKTA.Checked = CBool(dt.Rows(0)("EnKta"))
            ckEntryBPKB.Checked = CBool(dt.Rows(0)("EnBpkb"))
            ckEntryKwitansi.Checked = CBool(dt.Rows(0)("EnKwitansi"))
            ckEntryPolis.Checked = CBool(dt.Rows(0)("EnPolis"))
            ckPembayaran.Checked = CBool(dt.Rows(0)("Pembayaran"))
            ckPelunasanAsuransi.Checked = CBool(dt.Rows(0)("PelAsuransi"))
            ckPelunasanDimuka.Checked = CBool(dt.Rows(0)("PelDimuka"))
            ckPelunasanKhusus.Checked = CBool(dt.Rows(0)("PelKhusus"))
            ckPelunasanNormal.Checked = CBool(dt.Rows(0)("PelNormal"))
            ckVKontrakDT.Checked = CBool(dt.Rows(0)("VKontrakDT"))
            ckVKontrakEle.Checked = CBool(dt.Rows(0)("VKontrakEle"))
            ckVKontrakKTA.Checked = CBool(dt.Rows(0)("VKontrakKta"))
            ckVKontrakMB.Checked = CBool(dt.Rows(0)("VKontrakMB"))
            ckVReportKotnrak.Checked = CBool(dt.Rows(0)("VKontrak"))
            ckEditDT.Checked = CBool(dt.Rows(0)("EdDT"))
            ckEditEle.Checked = CBool(dt.Rows(0)("EdEle"))
            ckEditKaryawan.Checked = CBool(dt.Rows(0)("EdKaryawan"))
            ckEditKTA.Checked = CBool(dt.Rows(0)("EdKta"))
            ckEditMB.Checked = CBool(dt.Rows(0)("EdMB"))
            ckBBKontrak.Checked = CBool(dt.Rows(0)("BbKontrak"))

        End If

    End Sub

    Private Function Validation() As Boolean

        If txtNama.Text = "" Then
            MessageBox.Show("Nama Harus Diisi !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtKTP.Text = "" Then
            MessageBox.Show("KTP Harus Diisi !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtAlamat.Text = "" Then
            MessageBox.Show("Alamat Harus Diisi !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtTmptLahir.Text = "" Then
            MessageBox.Show("Tempat Lahir Harus Diisi !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtAlamat.Text = "" Then
            MessageBox.Show("Alamat Harus Diisi !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtTelp.Text = "" Then
            MessageBox.Show("Telepon Harus Diisi !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtRT.Text = "" Then
            MessageBox.Show("RT Harus Diisi !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtRW.Text = "" Then
            MessageBox.Show("RW Harus Diisi !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        Else
            Return True
        End If

    End Function

    Private Function ValidationID() As Boolean
        If txtUsername.Text <> "" Then

            If txtPassword1.Text <> txtPassword2.Text Then
                MessageBox.Show("Kedua Password Harus Sama", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            Else

                If FlagMember = "INS" Then
                    FlagAkun = "INS"
                    Return True
                Else
                    StrSQL = "SELECT * FROM Account WHERE UserID='" & antisqli(txtUsername.Text) & "' "
                    StrSQL &= "AND EmployeeID ='" & antisqli(txtNIK.Text) & "' "
                    RunSQL(StrSQL, 1)

                    If dt.Rows.Count > 0 Then
                        FlagAkun = "UPD"
                        Return True
                    Else
                        StrSQL = "SELECT UserID FROM Account WHERE UserID='" & antisqli(txtUsername.Text) & "' "
                        RunSQL(StrSQL, 1)
                        If dt.Rows.Count > 0 Then
                            FlagAkun = "ERR"
                            MessageBox.Show("UserID sudah terdaftar", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return False
                        Else
                            FlagAkun = "INS"
                            Return True
                        End If
                    End If
                End If
            End If
        Else
            Return False
        End If
    End Function

    Private Sub Employee_SAV()
        StrSQL = ""
        StrSQL = "SpEmployee_SAV '" & FlagMember & "', "
        StrSQL &= "'" & txtNIK.Text & "',"
        StrSQL &= "'" & txtNama.Text & "',"
        StrSQL &= "'" & cmbGender.SelectedValue & "',"
        StrSQL &= "'" & dtTglLahir.Value & "',"
        StrSQL &= "'" & txtTmptLahir.Text & "',"
        StrSQL &= "'" & txtKTP.Text & "',"
        StrSQL &= "'" & txtAlamat.Text & "',"
        StrSQL &= "'" & txtRT.Text & "',"
        StrSQL &= "'" & txtRW.Text & "',"
        StrSQL &= "'" & cmbKelurahan.SelectedValue & "',"
        StrSQL &= "'" & txtTelp.Text & "',"
        StrSQL &= "'" & cmbPosisi.SelectedValue & "',"
        StrSQL &= "" & cmbStatus.SelectedValue & ","
        StrSQL &= "''"
        RunSQL(StrSQL, 0)

    End Sub

    Private Sub Akun_SAV()
        StrSQL = ""
        StrSQL = "SpAccount_SAV '" & FlagAkun & "', "
        StrSQL &= "'" & txtUsername.Text & "',"
        StrSQL &= "'" & txtPassword1.Text & "',"
        StrSQL &= "'" & txtNIK.Text & "',"
        StrSQL &= cmbStatusAkun.SelectedValue
        RunSQL(StrSQL, 0)
    End Sub

    Private Sub Akses_SAV()
        Dim enDT As Integer = IIf(ckEntryDT.Checked, 1, 0)
        Dim enMB As Integer = IIf(ckEntryMB.Checked, 1, 0)
        Dim enEle As Integer = IIf(ckEntryEle.Checked, 1, 0)
        Dim enKTA As Integer = IIf(ckEntryKTA.Checked, 1, 0)
        Dim enBpkb As Integer = IIf(ckEntryBPKB.Checked, 1, 0)
        Dim enKwitansi As Integer = IIf(ckEntryKwitansi.Checked, 1, 0)
        Dim enPolis As Integer = IIf(ckEntryPolis.Checked, 1, 0)
        Dim Pembayaran As Integer = IIf(ckPembayaran.Checked, 1, 0)
        Dim PelNormal As Integer = IIf(ckPelunasanNormal.Checked, 1, 0)
        Dim PelKhusus As Integer = IIf(ckPelunasanKhusus.Checked, 1, 0)
        Dim PelDimuka As Integer = IIf(ckPelunasanDimuka.Checked, 1, 0)
        Dim PelAsuransi As Integer = IIf(ckPelunasanAsuransi.Checked, 1, 0)
        Dim VKontrak As Integer = IIf(ckVReportKotnrak.Checked, 1, 0)
        Dim VKontrakDT As Integer = IIf(ckVKontrakDT.Checked, 1, 0)
        Dim VKontrakMB As Integer = IIf(ckVKontrakMB.Checked, 1, 0)
        Dim VKontrakEle As Integer = IIf(ckVKontrakEle.Checked, 1, 0)
        Dim VKontrakKta As Integer = IIf(ckVKontrakKTA.Checked, 1, 0)
        Dim EdDT As Integer = IIf(ckEditDT.Checked, 1, 0)
        Dim EdMB As Integer = IIf(ckEditMB.Checked, 1, 0)
        Dim EdEle As Integer = IIf(ckEditEle.Checked, 1, 0)
        Dim EdKta As Integer = IIf(ckEditKTA.Checked, 1, 0)
        Dim EdKaryawan As Integer = IIf(ckEditKaryawan.Checked, 1, 0)
        Dim BbKontrak As Integer = IIf(ckBBKontrak.Checked, 1, 0)

        StrSQL = ""
        StrSQL = "SpAkses_SAV '" & FlagAkun & "', "
        StrSQL &= "'" & txtNIK.Text & "', "
        StrSQL &= enDT & ","
        StrSQL &= enMB & ","
        StrSQL &= enEle & ","
        StrSQL &= enKTA & ","
        StrSQL &= enBpkb & ","
        StrSQL &= enKwitansi & ","
        StrSQL &= enPolis & ","
        StrSQL &= Pembayaran & ","
        StrSQL &= PelNormal & ","
        StrSQL &= PelKhusus & ","
        StrSQL &= PelDimuka & ","
        StrSQL &= PelAsuransi & ","
        StrSQL &= VKontrak & ","
        StrSQL &= VKontrakDT & ","
        StrSQL &= VKontrakMB & ","
        StrSQL &= VKontrakEle & ","
        StrSQL &= VKontrakKta & ","
        StrSQL &= EdDT & ","
        StrSQL &= EdMB & ","
        StrSQL &= EdEle & ","
        StrSQL &= EdKta & ","
        StrSQL &= EdKaryawan & ","
        StrSQL &= BbKontrak

        RunSQL(StrSQL, 0)

    End Sub

End Class