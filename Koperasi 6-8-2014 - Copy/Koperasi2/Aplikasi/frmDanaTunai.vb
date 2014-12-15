Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.ReportingServices.DataExtensions.ParameterCollectionWrapper

Public Class frmDanaTunai


#Region "Declare Variable"
    Dim tempPokok As Double = 0
    Dim tempPremiAdmin As Double = 0
    Dim tblSales As New DataTable
    Dim tblPos As New DataTable
    Dim tblCA As New DataTable
    Dim tblSY As New DataTable
    Dim tblGender As New DataTable
    Dim tblPemKota As New DataTable
    Dim tblPemKec As New DataTable
    Dim tblPemKel As New DataTable
    Dim tblPemKer As New DataTable
    Dim tblPenKota As New DataTable
    Dim tblPenKec As New DataTable
    Dim tblPenKel As New DataTable
    Dim tblPerKota As New DataTable
    Dim tblPerKec As New DataTable
    Dim tblPerKel As New DataTable
    Dim tblKonKota As New DataTable
    Dim tblKonKec As New DataTable
    Dim tblKonKel As New DataTable
    Dim tblBpKot As New DataTable
    Dim tblBpKec As New DataTable
    Dim tblBpKel As New DataTable
    Dim oldBpkb As String = ""
#End Region
#Region "Function"
    Private Sub setTanggal()
        dtTanggal.Text = Now
        dtTanggal.Format = DateTimePickerFormat.Custom
        dtTanggal.CustomFormat = "dd/MM/yyyy"
        dtPemTl.Text = Now
        dtPemTl.Format = DateTimePickerFormat.Custom
        dtPemTl.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub ClearForm()
        stateApp = "INS"
        stateMember = "INS"
        begginingState = "AWAL"
        _isRollBackMode = False
        FreshForm()
        Try
            isiComboBox()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'cmbPemGender.SelectedIndex = 0
    End Sub

    Private Sub FreshForm()
        'txtAplikasi.Text = autoNumber()
        ' txtPemNo.Text = autoNumberMember()
        oldBpkb = ""
        posFlag = False
        txtKendaraan.Clear()
        txtTipe.Clear()
        txtWarna.Clear()
        txtTahun.Clear()
        txtMesin.Clear()
        txtRangka.Clear()
        txtNopol.Clear()
        txtPinjaman.Text = "0"
        txtPremiAsuransi.Text = "0"
        txtAdmin.Text = ribuan(CStr(getFieldValue("SELECT BiayaAdmin From SystemParameter")))
        txtPremiAdmin.Text = "0"
        txtTenor.Text = "0"
        txtTingkatBunga.Text = "0"
        txtAdminKredit.Text = "0"
        txtBungaFlat.Text = "0"
        txtBungaPengali.Text = "0"
        txtAdminMurni.Text = "0"
        txtPokok.Text = "0"
        txtBunga.Text = "0"
        txtTotalHutang.Text = "0"
        txtAngsuran.Text = "0"
        'autoNumberMember(cmbPos.Text)
        txtKomentar.Clear()
        txtAplikasi.Focus()
        txtBpkb.Clear()
        Member_Clear()
    End Sub
    Private Sub Member_Clear()
        txtPemNama.Clear()
        txtPemTl.Clear()
        dtPemTl.Text = Now
        txtPemKtp.Clear()
        txtPemAlamat.Clear()
        txtPemHp.Clear()
        txtPemTelp1.Clear()
        txtPemTelp2.Clear()
        'txtPemIbu.Clear()
        txtPemRt.Clear()
        txtPemRw.Clear()
        txtPenagihanAlamat.Clear()
        txtPenagihanRt.Clear()
        txtPenagihanRw.Clear()
        txtPerusahaanNama.Clear()
        txtPerusahaanJabatan.Clear()
        txtPerusahaanMasa.Clear()
        txtPerusahaanAlamat.Clear()
        txtPerusahaanRt.Clear()
        txtPerusahaanRw.Clear()
        txtPerusahaanTelp.Clear()
        txtKontakNama.Clear()
        txtKontakAlamat.Clear()
        txtKontakRt.Clear()
        txtKontakRw.Clear()
        txtKontakHubungan.Clear()
        txtKontakTelp.Clear()
        txtBpkbNama.Clear()
        txtBpkbAlamat.Clear()
        txtBpkbRt.Clear()
        txtBpkbRw.Clear()
        txtUangPemohon.Text = "0"
        txtUangPasangan.Text = "0"
        txtUangLain.Text = "0"
        txtUangKeluar.Text = "0"
    End Sub
    Private Sub isiComboBox()
        FillCombobox("exec SpEmployee_CBO 'SM'", cmbSalesman, 2, tblSales)
        FillCombobox("exec Sp_Reference_CBO 'POS'", cmbPos, 2, tblPos)
        FillCombobox("exec SpEmployee_CBO 'CA'", cmbCreditAnalyst, 2, tblCA)
        FillCombobox("exec SpEmployee_CBO 'SY'", cmbSurveyor, 2, tblSY)
        FillCombobox("exec Sp_Reference_CBO 'GEN'", cmbPemGender, 2, tblGender)
        FillCombobox("select*from v_kota ORDer BY city asc", cmbPemKota, 1, tblPemKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPemKota.Text + "' ORDER BY [SubDistrict] ASC", cmbPemKec, 1, tblPemKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPemKec.Text + "' ORDER BY [Village] ASC", cmbPemKel, 2, tblPemKel)
        FillCombobox("exec Sp_Reference_CBO 'TWC'", txtPemKerja, 2, tblPemKer)
        FillCombobox("select*from v_kota ORDer BY city asc", cmbPenagihanKota, 1, tblPenKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPenagihanKota.Text + "' ORDER BY [SubDistrict] ASC", cmbPenagihanKec, 1, tblPenKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPenagihanKec.Text + "' ORDER BY [Village] ASC", cmbPenagihanKel, 2, tblPenKel)
        FillCombobox("select*from v_kota ORDer BY city asc", cmbPerusahaanKota, 1, tblPerKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPerusahaanKota.Text + "' ORDER BY [SubDistrict] ASC", cmbPerusahaanKec, 1, tblPerKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPerusahaanKec.Text + "' ORDER BY [Village] ASC", cmbPerusahaanKel, 2, tblPerKel)
        FillCombobox("select*from v_kota ORDer BY city asc", cmbKontakKota, 1, tblKonKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbKontakKota.Text + "' ORDER BY [SubDistrict] ASC", cmbKontakKec, 1, tblKonKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKontakKec.Text + "' ORDER BY [Village] ASC", cmbKontakKel, 2, tblKonKel)
        FillCombobox("select*from v_kota ORDer BY city asc", cmbBpkbKota, 1, tblBpKot)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbBpkbKota.Text + "' ORDER BY [SubDistrict] ASC", cmbBpkbKec, 1, tblBpKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbBpkbKec.Text + "' ORDER BY [Village] ASC", cmbBpkbKel, 2, tblBpKel)
    End Sub

    Private Sub LostFocusRibuan(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPinjaman.Leave, txtUangPemohon.Leave, txtUangPasangan.Leave, txtUangLain.Leave, txtUangKeluar.Leave, txtPremiAdmin.Leave, txtAdminKredit.Leave, txtAdmin.Leave
        Dim txtBox = DirectCast(sender, TextBox)
        txtBox.Text = ribuan(txtBox.Text)
    End Sub
    Private Sub KeyPressDecimal(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPinjaman.KeyPress, txtTingkatBunga.KeyPress, txtTenor.KeyPress, txtPremiAsuransi.KeyPress, txtPremiAdmin.KeyPress, txtPerusahaanTelp.KeyPress, txtPerusahaanRw.KeyPress, txtPerusahaanRt.KeyPress, txtPerusahaanMasa.KeyPress, txtPenagihanRw.KeyPress, txtPenagihanRt.KeyPress, txtPemTelp2.KeyPress, txtPemTelp1.KeyPress, txtPemRw.KeyPress, txtPemRt.KeyPress, txtPemHp.KeyPress, txtKontakRw.KeyPress, txtKontakRt.KeyPress, txtAdminKredit.KeyPress, txtAdmin.KeyPress, txtUangPemohon.KeyPress, txtUangPasangan.KeyPress, txtUangLain.KeyPress, txtUangKeluar.KeyPress, txtKontakTelp.KeyPress, txtBpkbRw.KeyPress, txtBpkbRt.KeyPress
        Dim txtBox = DirectCast(sender, TextBox)
        decimalOnly(sender, e, txtBox.Text)
    End Sub

    Private Function VcAplikasi() As Boolean
        Dim hasil As Boolean = True
        If _isRollBackMode = True Then
            If txtAplikasi.Text <> noAplikasi Then
                alertmsg = "No Aplikasi Tidak Sesuai Ketentuan"
                txtAplikasi.Focus()
                hasil = False
            End If
        End If
        If txtKendaraan.Text = "" Then
            alertmsg = "Jenis Kendaraan Tidak Boleh Kosong"
            txtKendaraan.Focus()
            hasil = False
        ElseIf txtTipe.Text = "" Then
            alertmsg = "Tipe Kendaraan Tidak Boleh Kosong"
            txtTipe.Focus()
            hasil = False
        ElseIf txtWarna.Text = "" Then
            alertmsg = "Warna Kendaraan Tidak Boleh Kosong"
            txtWarna.Focus()
            hasil = False
        ElseIf txtTahun.Text = "" Then
            alertmsg = "Tahun Kendaraan Tidak Boleh Kosong "
            txtTahun.Focus()
            hasil = False
        ElseIf txtMesin.Text = "" Then
            alertmsg = "Nomor Mesin Tidak Boleh Kosong"
            txtMesin.Focus()
            hasil = False
        ElseIf txtRangka.Text = "" Then
            alertmsg = "Nomor Rangka Tidak Boleh Kosong"
            txtRangka.Focus()
            hasil = False
        ElseIf txtNopol.Text = "" Then
            alertmsg = "Nomor Plat Tidak Boleh Kosong"
            txtNopol.Focus()
            hasil = False
        ElseIf txtPinjaman.Text < 0 Then
            alertmsg = "Pinjaman Tidak Boleh Minus"
            txtPinjaman.Focus()
            hasil = False
        ElseIf txtPremiAsuransi.Text < 0 Then
            alertmsg = "Premi Asuransi Tidak Boleh Minus"
            txtPremiAsuransi.Focus()
            hasil = False
        ElseIf txtAdmin.Text < 0 Then
            alertmsg = "Admin Tidak Boleh Minus"
            txtAdmin.Focus()
            hasil = False
        ElseIf txtPremiAdmin.Text < 0 Then
            alertmsg = "Premi + Admin Tidak Boleh Minus"
            txtPremiAdmin.Focus()
            hasil = False
        ElseIf txtPemNo.Text = "" Then
            alertmsg = "Nomor Anggota Tidak Boleh Kosong"
            txtPemNo.Focus()
            hasil = False
        ElseIf txtPemNama.Text = "" Then
            alertmsg = "Nama Anggota Tidak Boleh Kosong"
            txtPemNama.Focus()
            hasil = False
        ElseIf txtPemTl.Text = "" Then
            alertmsg = "Tempat Lahir Anggota Tidak Boleh Kosong"
            txtPemTl.Focus()
            hasil = False
        ElseIf dtPemTl.Text = "" Then
            alertmsg = "Tanggal Lahir Anggota Tidak Boleh Kosong"
            dtPemTl.Focus()
            hasil = False
        ElseIf txtPemKtp.Text = "" Then
            alertmsg = "Nomor KTP Anggota Tidak Boleh Kosong"
            txtRangka.Focus()
            hasil = False
        ElseIf txtPemAlamat.Text = "" Then
            alertmsg = "Alamat Anggota Tidak Boleh Kosong"
            txtPemAlamat.Focus()
            hasil = False
        ElseIf txtPemRt.Text = "" Then
            alertmsg = "Nomor RT Anggota Tidak Boleh Kosong"
            txtPemRt.Focus()
            hasil = False
        ElseIf txtPemRw.Text = "" Then
            alertmsg = "Nomor RW Anggota Tidak Boleh Kosong"
            txtPemRw.Focus()
            hasil = False
        ElseIf txtPemHp.Text = "" Then
            alertmsg = "Nomor Handphone Anggota Tidak Boleh Kosong"
            txtPemHp.Focus()
            hasil = False
            'ElseIf txtPemIbu.Text = "" Then
            '    alertmsg = "Nama Ibu Anggota Tidak Boleh Kosong"
            '    txtPemIbu.Focus()
            '    hasil = False
        ElseIf txtPenagihanAlamat.Text = "" Then
            alertmsg = "Alamat Penagihan Tidak Boleh Kosong"
            txtPenagihanAlamat.Focus()
            hasil = False
        ElseIf txtPenagihanRt.Text = "" Then
            alertmsg = "Nomor RT Alamat Penagihan Tidak Boleh Kosong"
            txtPenagihanRt.Focus()
            hasil = False
        ElseIf txtPenagihanRw.Text = "" Then
            alertmsg = "Nomor RW Alamat Penagihan Tidak Boleh Kosong"
            txtPenagihanRw.Focus()
            hasil = False
        ElseIf txtPerusahaanNama.Text = "" Then
            alertmsg = "Nama Perusahaan Tidak Boleh Kosong"
            txtPerusahaanNama.Focus()
            hasil = False
        ElseIf txtPerusahaanJabatan.Text = "" Then
            alertmsg = "Jabatan Tidak Boleh Kosong"
            txtPerusahaanJabatan.Focus()
            hasil = False
        ElseIf txtPerusahaanMasa.Text = "" Then
            alertmsg = "Masa Jabatan Tidak Boleh Kosong"
            txtPerusahaanMasa.Focus()
            hasil = False
        ElseIf txtPerusahaanAlamat.Text = "" Then
            alertmsg = "Alamat Perusahaan Tidak Boleh Kosong"
            txtPerusahaanAlamat.Focus()
            hasil = False
        ElseIf txtPerusahaanRt.Text = "" Then
            alertmsg = "Nomor RT Perusahaan Tidak Boleh Kosong"
            txtPerusahaanRt.Focus()
            hasil = False
        ElseIf txtPerusahaanRw.Text = "" Then
            alertmsg = "Nomor RW Perusahaan Tidak Boleh Kosong"
            txtPerusahaanRw.Focus()
            hasil = False
        ElseIf txtBpkbNama.Text = "" Then
            alertmsg = "Nama Pemilik BPKB Tidak Boleh Kosong"
            txtBpkbNama.Focus()
            hasil = False
        ElseIf txtBpkbAlamat.Text = "" Then
            alertmsg = "Alamat Pada BPKB Tidak Boleh Kosong"
            txtBpkbAlamat.Focus()
            hasil = False
        ElseIf txtBpkbRt.Text = "" Then
            alertmsg = "Nomor RT pada BPKB Tidak Boleh Kosong"
            txtBpkbRt.Focus()
            hasil = False
        ElseIf txtBpkbRw.Text = "" Then
            alertmsg = "Nomor RW Pada BPKB Tidak Boleh Kosong"
            txtBpkbRw.Focus()
            hasil = False
        ElseIf txtUangPemohon.Text = "" Then
            alertmsg = "Penghasilan Anggota Tidak Boleh Kosong"
            txtUangPemohon.Focus()
            hasil = False
        ElseIf txtUangPasangan.Text = "" Then
            alertmsg = "Penghasilan Pasangan Anggota Tidak Boleh Kosong"
            txtUangPasangan.Focus()
            hasil = False
        ElseIf txtUangLain.Text = "" Then
            alertmsg = "Penghasilan Lain Anggota Tidak Boleh Kosong"
            txtUangLain.Focus()
            hasil = False
        ElseIf txtUangKeluar.Text = "" Then
            alertmsg = "Pengeluaran Anggota Tidak Boleh Kosong"
            txtUangKeluar.Focus()
            hasil = False
        ElseIf txtKomentar.Text = "" Then
            alertmsg = "Komentar Survey Tidak Boleh Kosong"
            txtKomentar.Focus()
            hasil = False
        Else
            hasil = True
            alertmsg = "Data berhasil ditambahkan"
        End If
        Return hasil
    End Function
    Private Sub Application_SAV(ByVal _InsUpd As String, ByVal _MemberID As String, ByVal _IsApprv As Boolean)
        ' If _InsUpd = "INS" Then _ApplicationID = gGUID(11)

        StrSQL = "SpApplication_SAV '" & _InsUpd & "', "
        StrSQL &= "'" & txtAplikasi.Text & "', "
        StrSQL &= "'" & dtTanggal.Value.ToString("yyyyMMdd") & "', "
        StrSQL &= "'" & cmbPos.SelectedValue & "', "
        StrSQL &= "'" & cmbCreditAnalyst.SelectedValue & "', "
        StrSQL &= "'" & cmbSurveyor.SelectedValue & "', "
        StrSQL &= "'" & cmbSalesman.SelectedValue & "', "
        StrSQL &= "'1', "
        StrSQL &= "'" & txtTenor.Text & "', "
        StrSQL &= CInt(txtTingkatBunga.Text) & ", " 'effectiveinterestP
        StrSQL &= CDbl(txtPinjaman.Text) & ", " 'motor price
        StrSQL &= "0, " 'electronicprice
        StrSQL &= "0, " 'CDbl(DownPayment.Text) & ", " 'downpayment
        StrSQL &= CDbl(txtPremiAsuransi.Text) & ", " 'insuranceRate
        StrSQL &= CDbl(txtAdminKredit.Text) & ", " 'LoanAdmin
        StrSQL &= "0, " 'CDbl(DealerSubs.Text) & ", "
        StrSQL &= "0, " 'MarketingCost
        StrSQL &= CDbl(txtAdmin.Text) & ", " 'InsuranceAdmin
        StrSQL &= "'" & txtKendaraan.Text & "', "
        StrSQL &= "'" & txtTipe.Text & "', "
        StrSQL &= "'" & txtWarna.Text & "', "
        StrSQL &= "'" & txtTahun.Text & "', "
        StrSQL &= "'" & _MemberID & "', "
        StrSQL &= IIf(_IsApprv, 1, 0) & ", "
        StrSQL &= "'" & txtKomentar.Text & "',"
        StrSQL &= "'',"
        StrSQL &= CDbl(txtPokok.Text) & ", "
        StrSQL &= CDbl(txtAngsuran.Text) & ", " 'installment
        StrSQL &= "'', "
        StrSQL &= "'" & txtBpkb.Text & "',"
        StrSQL &= "'" & txtRangka.Text & "',"
        StrSQL &= "'" & txtMesin.Text & "',"
        StrSQL &= "'" & txtNopol.Text & "',"
        StrSQL &= "" & 0 & ","
        StrSQL &= "'" & oldAppID & "',"
        StrSQL &= "" & CStr(Replace(txtPremiAdmin.Text, ",", "")) & ","
        StrSQL &= "" & CStr(Replace(txtBungaPengali.Text, ",", "")) & ","
        StrSQL &= "" & CStr(Replace(txtPokok.Text, ",", "")) & ","
        StrSQL &= "" & CStr(Replace(txtBunga.Text, ",", "")) & ""
        RunSQL(StrSQL, 0)
    End Sub
    Private Sub Member_SAV(ByVal _InsUpd As String)
        'If _InsUpd = "INS" Then _MemberID = gGUID(16)
        StrSQL = "SpMember_SAV '" & _InsUpd & "', "
        StrSQL &= "'" & txtPemNo.Text & "', "
        StrSQL &= "'" & txtPemNama.Text & "', "
        StrSQL &= "'" & cmbSalesman.SelectedValue & "', "
        StrSQL &= "'" & cmbPemGender.SelectedValue & "', "
        StrSQL &= "'" & dtPemTl.Value.ToString("yyyyMMdd") & "', "
        StrSQL &= "'" & txtPemTl.Text & "', "
        StrSQL &= "'" & txtPemKtp.Text & "', "
        StrSQL &= "'" & txtPemAlamat.Text & "', "
        StrSQL &= "'" & txtPemRt.Text & "', "
        StrSQL &= "'" & txtPemRw.Text & "', "
        StrSQL &= "'" & cmbPemKel.SelectedValue & "', "
        StrSQL &= "'" & txtPemHp.Text & "', "
        StrSQL &= "'" & txtPemTelp1.Text & "', "
        StrSQL &= "'" & txtPemTelp2.Text & "', "
        StrSQL &= "'', "
        StrSQL &= "'" & txtPemKerja.SelectedValue & "', "
        StrSQL &= "'" & txtPerusahaanNama.Text & "', "
        StrSQL &= "'" & txtPerusahaanJabatan.Text & "', "
        StrSQL &= txtPerusahaanMasa.Text & ", "
        StrSQL &= "'" & txtPerusahaanAlamat.Text & "', "
        StrSQL &= "'" & txtPerusahaanRt.Text & "', "
        StrSQL &= "'" & txtPerusahaanRw.Text & "', "
        StrSQL &= "'" & cmbPerusahaanKel.SelectedValue & "', "
        StrSQL &= "'" & txtPerusahaanTelp.Text & "', "
        StrSQL &= "'" & txtKontakNama.Text & "', "
        StrSQL &= "'" & txtKontakAlamat.Text & "', "
        StrSQL &= "'" & txtKontakRt.Text & "', "
        StrSQL &= "'" & txtKontakRw.Text & "', "
        StrSQL &= "'" & cmbKontakKel.SelectedValue & "', "
        StrSQL &= "'" & txtKontakTelp.Text & "', "
        StrSQL &= "'" & txtKontakHubungan.Text & "', "
        StrSQL &= "'" & txtBpkbNama.Text & "', "
        StrSQL &= "'" & txtBpkbAlamat.Text & "', "
        StrSQL &= "'" & txtBpkbRt.Text & "', "
        StrSQL &= "'" & txtBpkbRw.Text & "', "
        StrSQL &= "'" & cmbBpkbKel.SelectedValue & "', "
        StrSQL &= "'" & txtPenagihanAlamat.Text & "', "
        StrSQL &= "'" & txtPenagihanRt.Text & "', "
        StrSQL &= "'" & txtPenagihanRw.Text & "', "
        StrSQL &= "'" & cmbPenagihanKel.SelectedValue & "', "
        StrSQL &= CDbl(txtUangPemohon.Text) & ", "
        StrSQL &= CDbl(txtUangPasangan.Text) & ", "
        StrSQL &= CDbl(txtUangLain.Text) & ", "
        StrSQL &= CDbl(txtUangKeluar.Text) & ", "
        StrSQL &= "'" & oldMemberID & "' "
        RunSQL(StrSQL, 0)

        Dim statusBpkb As String
        StrSQL = ""
        StrSQL = "SELECT*FROM Bpkb Where NoBpkb = '" & oldBpkb & "' "
        RunSQL(StrSQL, 1)
        If dt.Rows.Count > 0 Then
            statusBpkb = "UPD"
        Else
            statusBpkb = "INS"
        End If

        StrSQL = ""
        StrSQL = "Sp_BpkbSAVE "
        StrSQL &= "'" & statusBpkb & "', "
        StrSQL &= "'" & txtBpkb.Text & "', "
        StrSQL &= "'" & txtBpkbNama.Text & "', "
        StrSQL &= "'" & txtNopol.Text & "', "
        StrSQL &= "'" & txtMesin.Text & "', "
        StrSQL &= "'" & txtRangka.Text & "', "
        StrSQL &= "'" & txtWarna.Text & "', "
        StrSQL &= "'', " 'tglmasuk
        StrSQL &= "'', " 'tglkeluar
        StrSQL &= "'', " 'pengambil
        StrSQL &= "'423E4A13', " 'ONHAND
        StrSQL &= "'" & antisqli(txtBpkbAlamat.Text) & "', "
        StrSQL &= "'" & cmbBpkbKel.SelectedValue & "', "
        StrSQL &= "'" & txtBpkbRt.Text & "', "
        StrSQL &= "'" & txtBpkbRw.Text & "', "
        StrSQL &= "'" & oldBpkb & "' "
        RunSQL(StrSQL, 0)
    End Sub
    Private Sub PrintTandaTerimaUang()

        'Call conn_open()
        'StrSQL = "SELECT * FROM TTU where ApplicationID='" & txtAplikasi.Text & "'"
        'RunSQL(StrSQL, 2, "TandaTerimaUang")
        'RepName = "TandaTerimaUang"
        'strReportPath = Application.StartupPath & "\Report\" & RepName & ".rpt"
        'If Not IO.File.Exists(strReportPath) Then
        '    Throw (New Exception("Unable to locate report file:" & vbCrLf & strReportPath))
        'End If
        'Dim rptDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        'Dim paramV As CrystalDecisions.Shared.ParameterValues
        'Dim paramDValue As CrystalDecisions.Shared.ParameterDiscreteValue
        'rptDocument.Load(strReportPath)
        'rptDocument.SetDataSource(ds)
        'rptDocument.Refresh()
        'paramV = New CrystalDecisions.Shared.ParameterValues
        'paramDValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        'paramDValue.Value = Terbilang(CDbl(txtPinjaman.Text))
        'paramV.Add(paramDValue)
        ''rptDocument.SetParameterValue("terbilang", Terbilang(CDbl(txtPinjaman.Text)))
        'rptDocument.ParameterFields.Item("terbilang").CurrentValues = paramV
        'rptDocument.ParameterFields.Item("terbilang").HasCurrentValue = True
        'rptDocument.SetDatabaseLogon(con_userid, con_password, con_server, con_database)

        'With MultiReportView
        '    .CRViewer1.DisplayToolbar = True
        '    .CRViewer1.ReportSource = rptDocument
        'End With
        Dim dsTTU As New DataSet
        Dim paramDValue As New CrystalDecisions.Shared.ParameterDiscreteValue
        StrSQL = "SELECT * FROM TTU where ApplicationID='" & txtAplikasi.Text & "'"
        RunSQL(StrSQL, 2, "TandaTerimaUang", , dsTTU)
        RepName = "TandaTerimaUang"
        strReportPath = Application.StartupPath & "\Report\" & RepName & ".rpt"
        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & vbCrLf & strReportPath))
        Else
            paramDValue.Value = Terbilang(CDbl(txtPinjaman.Text))
            ViewReport(MultiReportView.CRViewer1, strReportPath, dsTTU, paramDValue)
        End If


    End Sub
    Private Sub tempTandaTerimaUang()
        Dim tanggal As String = "1"
        tanggal = Convert.ToString(dtTanggal.Value.Day)
        StrSQL = "INSERT INTO TTU VALUES (" & CDbl(txtPinjaman.Text) & ",'" & txtAplikasi.Text & "'"
        StrSQL &= ",'" & txtPemNama.Text & "','" & txtPemAlamat.Text & "'"
        StrSQL &= ",'" & txtTenor.Text & "'," & CDbl(txtAngsuran.Text) & ",'" & tanggal & "')"
        RunSQL(StrSQL, 0)
        PrintTandaTerimaUang()
    End Sub
    Private Sub tempTandaTerimaBpkb()
        Dim tanggal2 As String = "1"
        tanggal2 = Convert.ToString(dtTanggal.Value.Day)
        StrSQL = "INSERT INTO TandaTerimaBpkb VALUES ('" & txtPemNama.Text & "','" & txtBpkbNama.Text & "'"
        StrSQL &= ",'" & txtAplikasi.Text & "','" & txtMesin.Text & "'"
        StrSQL &= ",'" & txtRangka.Text & "','" & txtNopol.Text & "')"
        RunSQL(StrSQL, 0)
        PrintTandaTerimaBpkb()
    End Sub

    Private Sub PrintTandaTerimaBpkb()
        'Dim CrTable As CrystalDecisions.CrystalReports.Engine.Table
        'Dim CrLogonInfo As CrystalDecisions.Shared.TableLogOnInfo
        'Dim DsReport As New DataSet
        'StrSQL = ""
        'StrSQL = "SELECT * FROM TandaTerimaBpkb where ApplicationID='" & txtAplikasi.Text & "'"
        'RunSQL(StrSQL, 2, "TandaTerimaBpkb", , DsReport)
        'RepName = "TandaTerimaBpkb"
        'strReportPath = Application.StartupPath & "\Report\" & RepName & ".rpt"
        'If Not IO.File.Exists(strReportPath) Then
        '    Throw (New Exception("Unable to locate report file:" & vbCrLf & strReportPath))
        'End If
        'Dim rptDocument2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        'rptDocument2.Load(strReportPath)
        'rptDocument2.SetDataSource(DsReport)

        'For Each CrTable In rptDocument2.Database.Tables
        '    CrLogonInfo = CrTable.LogOnInfo
        '    With CrLogonInfo.ConnectionInfo
        '        .ServerName = con_server
        '        .UserID = con_userid
        '        .Password = con_password
        '        .DatabaseName = con_database
        '    End With
        '    CrTable.ApplyLogOnInfo(CrLogonInfo)
        'Next CrTable

        'With MultiReportView
        '    .CRViewer2.ReportSource = rptDocument2
        '    .CRViewer2.DisplayToolbar = True
        'End With



        'rptDocument2.SetDatabaseLogon(con_userid, con_password, con_server, con_database)
        'With MultiReportView
        '    .CRViewer2.ReportSource = rptDocument2
        '    .CRViewer2.DisplayToolbar = True
        'End With

        Dim dsTTB As New DataSet
        StrSQL = ""
        StrSQL = "SELECT * FROM TandaTerimaBpkb where ApplicationID='" & txtAplikasi.Text & "'"
        RunSQL(StrSQL, 2, "TandaTerimaBpkb", , dsTTB)
        RepName = "TandaTerimaBpkb"
        strReportPath = Application.StartupPath & "\Report\" & RepName & ".rpt"
        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & vbCrLf & strReportPath))
        Else
            ViewReport(MultiReportView.CRViewer2, strReportPath, dsTTB)
        End If

    End Sub
#End Region
#Region "Calculating"
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtPinjaman.Text <> "0" Then
            Dim tempBungaFlat As Double = 0
            Dim tempBungaPengali As Double = 0
            txtAdminMurni.Text = Format(CDbl(txtAdminKredit.Text), "#,##0")
            txtPokok.Text = Format(CDbl(txtPinjaman.Text) + CDbl(txtAdminKredit.Text) + CDbl(txtPremiAdmin.Text), "#,##0")
            tempBungaFlat = ((((CDbl(txtTenor.Text) * (CDbl(txtTingkatBunga.Text) / 1200)) / (1 - (1 + (CDbl(txtTingkatBunga.Text) / 1200)) ^ (-1 * CDbl(txtTenor.Text)))) - 1) * (12 / CDbl(txtTenor.Text))) * 100
            txtBungaFlat.Text = Format(tempBungaFlat, "#,##0.00")
            tempBungaPengali = CDbl(tempBungaFlat) * (CDbl(txtTenor.Text) / 12)
            txtBungaPengali.Text = Format(tempBungaPengali, "#,##0.00")
            txtBunga.Text = Format(CDbl(txtPokok.Text) * CDbl(tempBungaPengali) / 100, "#,##0")
            txtTotalHutang.Text = Format(CDbl(txtPokok.Text) + CDbl(txtBunga.Text), "#,##0")
            txtAngsuran.Text = Format(Math.Ceiling(CDbl(txtTotalHutang.Text) / (CDbl(txtTenor.Text) * 1000)) * 1000, "#,##0")
        End If
    End Sub

    Private Sub HitungPremiAdmin()
        tempPokok = Format(CDbl(txtPinjaman.Text) + CDbl(txtAdminKredit.Text), "#,##0")
        tempPremiAdmin = Format(((CDbl(tempPokok) * CDbl(txtPremiAsuransi.Text)) / 100) + CDbl(txtAdmin.Text), "#,##0")
        txtPremiAdmin.Text = ribuan(CStr(tempPremiAdmin))
    End Sub

#End Region

    Private Sub frmDanaTunai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setTanggal()
        ClearForm()
        txtAplikasi.Text = autoNumber(cmbPos.Text)
        txtPemNo.Text = autoNumberMember(cmbPos.Text)
        begginingState = "UBAH"
    End Sub

    Private Sub txtTenor_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTenor.Leave
        Dim tnr As New Integer
        tnr = Convert.ToInt32(txtTenor.Text)
        If tnr >= 1 And tnr <= 12 Then
            txtPremiAsuransi.Text = "2.5"
        ElseIf tnr >= 13 And tnr <= 18 Then
            txtPremiAsuransi.Text = "3.56"
        ElseIf tnr >= 19 And tnr <= 24 Then
            txtPremiAsuransi.Text = "4.63"
        ElseIf tnr >= 25 And tnr <= 30 Then
            txtPremiAsuransi.Text = "5.56"
        ElseIf tnr >= 31 And tnr <= 36 Then
            txtPremiAsuransi.Text = "6.5"
        Else
            txtPremiAsuransi.Text = "0"
        End If
    End Sub

    Private Sub txtPinjaman_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If txtAdminKredit.Text = "" Then txtAdminKredit.Text = 0
            If txtAdminKredit.Text <> 0 Then
                HitungPremiAdmin()
            End If

        Catch ex As Exception
            Exit Try
        End Try
        txtAdminMurni.Text = 0
        txtBungaPengali.Text = 0
        txtBungaFlat.Text = 0
        txtBunga.Text = 0
        txtTotalHutang.Text = 0
        txtAngsuran.Text = 0
    End Sub

    Private Sub txtAdminKredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdminKredit.TextChanged
        Try
            If txtPinjaman.Text = "" Then txtAdminKredit.Text = 0
            If txtPinjaman.Text <> 0 Then
                HitungPremiAdmin()
            End If
        Catch ex As Exception
            Exit Try
        End Try
        txtAdminMurni.Text = 0
        txtBungaPengali.Text = 0
        txtBungaFlat.Text = 0
        txtBunga.Clear()
        txtTotalHutang.Text = 0
        txtAngsuran.Text = 0
    End Sub

    Private Sub txtMesin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMesin.TextChanged
        StrSQL = ""
        StrSQL = String.Format("SELECT FRAMECODE FROM APPLICATION WHERE ENGINECODE='{0}'", antisqli(txtMesin.Text))
        RunSQL(StrSQL, 1)
        If dt.Rows.Count > 0 Then
            txtRangka.Text = dt.Rows(0)("FrameCode")
        Else
            txtRangka.Clear()
        End If
    End Sub

    Private Sub cmbPos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPos.SelectedIndexChanged
        If stateApp = "INS" And begginingState = "UBAH" Then
            txtAplikasi.Text = autoNumber(cmbPos.Text)
            txtPemNo.Text = autoNumberMember(cmbPos.Text)
        End If
        If stateApp = "UPD" And posFlag = True Then
            txtAplikasi.Text = autoNumber(cmbPos.Text)
            txtPemNo.Text = autoNumberMember(cmbPos.Text)
        End If
    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click, btnReject.Click
        Dim _IsApprv As Boolean = False
        If sender.Name = "btnApprove" Then
            _IsApprv = True
        End If
        If VcAplikasi() = True Then
            If _isRollBackMode Then
                Application_SAV("UPD", txtPemNo.Text, _IsApprv)
                Member_SAV(stateMember)
            Else
                Application_SAV("INS", txtPemNo.Text, _IsApprv)
                Member_SAV(stateMember)
            End If
            MessageBox.Show(alertmsg, "Sukses!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If sender.Name = "btnApprove" Then
                tempTandaTerimaUang()
                tempTandaTerimaBpkb()
                MultiReportView.Show()
            ElseIf sender.Name = "btnReject" Then
            End If
            ClearForm()
            txtAplikasi.Text = autoNumber(cmbPos.Text)
            txtPemNo.Text = autoNumberMember(cmbPos.Text)
        Else
            MessageBox.Show(alertmsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With frmTabApp
            formFlag = "1"
            .txtFlag.Text = "1"
            .Show()
        End With
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmTabMem.Show()
        formFlag = 1
    End Sub

    Private Sub txtAplikasi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAplikasi.TextChanged
        If txtAplikasi.Text.Length = txtAplikasi.MaxLength Then

            StrSQL = ""
            StrSQL = "SELECT * FROM APPLICATION WHERE APPLICATIONID ='" + antisqli(txtAplikasi.Text) + "'"
            RunSQL(StrSQL, 1)
            If dt.Rows.Count > 0 Then
                Dim platno As String = dt.Rows(0)("PlatNo")
                Dim bpkbno As String = dt.Rows(0)("BpkbNo")
                oldBpkb = bpkbno
                Dim motorprice As String = dt.Rows(0)("Motorprice")
                Dim insurancerate As String = dt.Rows(0)("insurancerate")
                Dim insuranceadmin As String = dt.Rows(0)("insuranceadmin")
                Dim tenor As String = dt.Rows(0)("tenor")
                Dim EffectiveInterestP As String = dt.Rows(0)("EffectiveInterestP")
                Dim loanadmin As String = dt.Rows(0)("LoanAdmin")
                Dim memberid As String = dt.Rows(0)("memberid")
                Dim surveycomment As String = dt.Rows(0)("surveycomment")
                Dim adminpremi As String = dt.Rows(0)("adminpremi")
                stateApp = "UPD"
                _isRollBackMode = True
                If stateApp = "UPD" Then
                    dtTanggal.Text = dt.Rows(0)("ApplicationDate")
                    cmbPos.Text = getFieldValue("SELECT ReferenceName from [_Reference] where ReferenceID='" + dt.Rows(0)("PosID").ToString() + "'")
                    posFlag = True
                    cmbCreditAnalyst.Text = getFieldValue("SELECT EmployeeName from Employee where EmployeeID='" + dt.Rows(0)("CreditAnalystID").ToString() + "'")
                    cmbSurveyor.Text = getFieldValue("SELECT EmployeeName from Employee where EmployeeID='" + dt.Rows(0)("SurveyorID").ToString() + "'")
                    cmbSalesman.Text = getFieldValue("SELECT EmployeeName from Employee where EmployeeID='" + dt.Rows(0)("SalesManID").ToString() + "'")
                    txtKendaraan.Text = dt.Rows(0)("MotorBrand")
                    txtTipe.Text = dt.Rows(0)("motortype")
                    txtWarna.Text = dt.Rows(0)("motorcolor")
                    txtTahun.Text = dt.Rows(0)("MotorYear")
                    txtMesin.Text = dt.Rows(0)("EngineCode")
                    txtRangka.Text = dt.Rows(0)("FrameCode")
                    txtNopol.Text = platno
                    txtBpkb.Text = bpkbno
                    txtPinjaman.Text = ribuan(motorprice)
                    txtPremiAsuransi.Text = insurancerate
                    txtAdmin.Text = insuranceadmin
                    txtTenor.Text = tenor
                    txtTingkatBunga.Text = EffectiveInterestP
                    txtAdminKredit.Text = loanadmin
                    txtPemNo.Text = memberid
                    oldMemberID = memberid
                    txtKomentar.Text = surveycomment
                    txtAdmin.Text = ribuan(txtAdmin.Text)
                    txtAdminKredit.Text = ribuan(txtAdminKredit.Text)
                    txtPremiAdmin.Text = ribuan(adminpremi)
                    Button2.PerformClick()
                End If
            Else
                stateApp = "INS"
            End If

        Else
            FreshForm()
            txtPemNo.Text = autoNumberMember(cmbPos.Text)
        End If
    End Sub

    Private Sub txtPemNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPemNo.TextChanged

        Dim kodeposPemohon As String
        Dim kodeposPenagihan As String
        Dim kodeposPerusahaan As String
        Dim kodeposKontak As String
        Dim kodeposBpkb As String
        If txtPemNo.Text.Length = txtPemNo.MaxLength Then
            StrSQL = ""
            StrSQL = "SELECT*FROM MEMBER WHERE MEMBERID='" + txtPemNo.Text + "'"
            RunSQL(StrSQL, 1)
            If dt.Rows.Count > 0 Then
                stateMember = "UPD"
                txtPemNama.Text = dt.Rows(0)("MemberName").ToString()
                txtPemTl.Text = dt.Rows(0)("BirthPlace").ToString()
                If dt.Rows(0)("GenderID").ToString() = "C5AB75CC" Then
                    cmbPemGender.Text = "Pria"
                Else
                    cmbPemGender.Text = "Wanita"
                End If
                dtPemTl.Text = dt.Rows(0)("BirthDate").ToString()
                txtPemKtp.Text = dt.Rows(0)("PersonalIdentity").ToString()
                txtPemAlamat.Text = dt.Rows(0)("Address").ToString()
                txtPemHp.Text = dt.Rows(0)("Phone1").ToString()
                txtPemTelp1.Text = dt.Rows(0)("Phone2").ToString()
                txtPemTelp2.Text = dt.Rows(0)("Phone3").ToString()
                txtPemRt.Text = dt.Rows(0)("MemberRT").ToString()
                txtPemRw.Text = dt.Rows(0)("MemberRW").ToString()
                'txtPemIbu.Text = dt.Rows(0)("MomMaidenName").ToString()
                txtPenagihanAlamat.Text = dt.Rows(0)("BillingAddress").ToString()
                txtPenagihanRt.Text = dt.Rows(0)("BillingRT").ToString()
                txtPenagihanRw.Text = dt.Rows(0)("BillingRW").ToString()
                txtPerusahaanNama.Text = dt.Rows(0)("CompName").ToString()
                txtPerusahaanJabatan.Text = dt.Rows(0)("CompPosition").ToString()
                txtPerusahaanMasa.Text = dt.Rows(0)("CompWorkTime").ToString()
                txtPerusahaanAlamat.Text = dt.Rows(0)("CompAddress").ToString()
                txtPerusahaanRt.Text = dt.Rows(0)("CompRT").ToString()
                txtPerusahaanRw.Text = dt.Rows(0)("CompRW").ToString()
                txtPerusahaanTelp.Text = dt.Rows(0)("CompPhone").ToString()
                txtKontakNama.Text = dt.Rows(0)("EmerName").ToString()
                txtKontakAlamat.Text = dt.Rows(0)("EmerAddress").ToString()
                txtKontakRt.Text = dt.Rows(0)("EmerRT").ToString()
                txtKontakRw.Text = dt.Rows(0)("EmerRW").ToString()
                txtKontakTelp.Text = dt.Rows(0)("EmerPhone").ToString()
                txtBpkbNama.Text = dt.Rows(0)("bpkbName").ToString()
                txtBpkbAlamat.Text = dt.Rows(0)("bpkbAddress").ToString()
                txtKontakHubungan.Text = dt.Rows(0)("EmerRelations").ToString()
                txtBpkbRt.Text = dt.Rows(0)("bpkbRT").ToString()
                txtBpkbRw.Text = dt.Rows(0)("BpkbRW").ToString()
                txtUangPemohon.Text = dt.Rows(0)("Income").ToString()
                txtUangPasangan.Text = dt.Rows(0)("SpouseIncome").ToString()
                txtUangLain.Text = dt.Rows(0)("OtherIncome").ToString()
                txtUangKeluar.Text = dt.Rows(0)("Expense").ToString()
                txtUangPemohon.Text = ribuan(txtUangPemohon.Text)
                txtUangPasangan.Text = ribuan(txtUangPasangan.Text)
                txtUangLain.Text = ribuan(txtUangLain.Text)
                txtUangKeluar.Text = ribuan(txtUangKeluar.Text)
                kodeposPemohon = dt.Rows(0)("PostalId").ToString()
                kodeposPerusahaan = dt.Rows(0)("CompPostalId").ToString()
                kodeposPenagihan = dt.Rows(0)("BillingPostalId").ToString()
                kodeposBpkb = dt.Rows(0)("BpkbPostalId").ToString()
                kodeposKontak = dt.Rows(0)("EmerPostalId").ToString()
                cmbPemKota.Text = detailAlamat(kodeposPemohon).kota
                cmbPemKec.Text = detailAlamat(kodeposPemohon).kecamatan
                cmbPemKel.Text = detailAlamat(kodeposPemohon).kelurahan
                cmbPerusahaanKota.Text = detailAlamat(kodeposPerusahaan).kota
                cmbPerusahaanKec.Text = detailAlamat(kodeposPerusahaan).kecamatan
                cmbPerusahaanKel.Text = detailAlamat(kodeposPerusahaan).kelurahan
                cmbPenagihanKota.Text = detailAlamat(kodeposPenagihan).kota
                cmbPenagihanKec.Text = detailAlamat(kodeposPenagihan).kecamatan
                cmbPenagihanKel.Text = detailAlamat(kodeposPenagihan).kelurahan
                cmbBpkbKota.Text = detailAlamat(kodeposBpkb).kota
                cmbBpkbKec.Text = detailAlamat(kodeposBpkb).kecamatan
                cmbBpkbKel.Text = detailAlamat(kodeposBpkb).kelurahan
                cmbKontakKota.Text = detailAlamat(kodeposKontak).kota
                cmbKontakKec.Text = detailAlamat(kodeposKontak).kecamatan
                cmbKontakKel.Text = detailAlamat(kodeposKontak).kelurahan
            End If
        Else
            Member_Clear()
            stateMember = "INS"
        End If
    End Sub

    Private Sub ComboKotaSelectedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPemKota.SelectedIndexChanged, cmbPerusahaanKota.SelectedIndexChanged, cmbPenagihanKota.SelectedIndexChanged, cmbKontakKota.SelectedIndexChanged, cmbBpkbKota.SelectedIndexChanged
        Dim tblKec1 As New DataTable
        Dim tblKec2 As New DataTable
        Dim tblKec3 As New DataTable
        Dim tblKec4 As New DataTable
        Dim tblKec5 As New DataTable
        'tblKec.Rows.Clear()

        Select Case sender.Name

            Case "cmbPemKota"
                tblKec1.Rows.Clear()
                With cmbPemKec
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPemKota.Text + "' ORDER BY [SubDistrict] ASC"
                    FillCombobox(StrSQL, cmbPemKec, 1, tblKec1)
                End With

            Case "cmbPenagihanKota"
                tblKec2.Rows.Clear()
                With cmbPenagihanKec
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPenagihanKota.Text + "' ORDER BY [SubDistrict] ASC"
                    FillCombobox(StrSQL, cmbPenagihanKec, 1, tblKec2)
                End With

            Case "cmbPerusahaanKota"
                tblKec3.Rows.Clear()
                With cmbPerusahaanKec
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPerusahaanKota.Text + "' ORDER BY [SubDistrict] ASC"
                    FillCombobox(StrSQL, cmbPerusahaanKec, 1, tblKec3)
                End With

            Case "cmbKontakKota"
                tblKec4.Rows.Clear()
                With cmbKontakKec
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbKontakKota.Text + "' ORDER BY [SubDistrict] ASC"
                    FillCombobox(StrSQL, cmbKontakKec, 1, tblKec4)
                End With

            Case "cmbBpkbKota"
                tblKec5.Rows.Clear()
                With cmbBpkbKec
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbBpkbKota.Text + "' ORDER BY [SubDistrict] ASC"
                    FillCombobox(StrSQL, cmbBpkbKec, 1, tblKec5)
                End With
        End Select
    End Sub

    Private Sub ComboKecamatanSelectedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPerusahaanKec.SelectedIndexChanged, cmbPenagihanKec.SelectedIndexChanged, cmbPemKec.SelectedIndexChanged, cmbKontakKec.SelectedIndexChanged, cmbBpkbKec.SelectedIndexChanged
        Dim tblKel1 As New DataTable
        Dim tblKel2 As New DataTable
        Dim tblKel3 As New DataTable
        Dim tblKel4 As New DataTable
        Dim tblKel5 As New DataTable
        'tblKec.Rows.Clear()

        Select Case sender.Name

            Case "cmbPemKec"
                tblKel1.Rows.Clear()
                With cmbPemKel
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPemKec.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbPemKel, 2, tblKel1)
                End With

            Case "cmbPenagihanKec"
                tblKel2.Rows.Clear()
                With cmbPenagihanKel
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPenagihanKec.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbPenagihanKel, 2, tblKel2)
                End With

            Case "cmbPerusahaanKec"
                tblKel3.Rows.Clear()
                With cmbPerusahaanKel
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPerusahaanKec.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbPerusahaanKel, 2, tblKel3)
                End With

            Case "cmbKontakKec"
                tblKel4.Rows.Clear()
                With cmbKontakKel
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKontakKec.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbKontakKel, 2, tblKel4)
                End With

            Case "cmbBpkbKec"
                tblKel5.Rows.Clear()
                With cmbBpkbKel
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbBpkbKec.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbBpkbKel, 2, tblKel5)
                End With
        End Select
    End Sub

    Private Sub ckBpkb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckBpkb.CheckedChanged
        Dim kodepos As String = cmbPemKel.SelectedValue
        Dim tblKOta As New DataTable
        'MessageBox.Show(kodepos)

        If ckBpkb.Checked = True Then
            txtBpkbNama.Text = txtPemNama.Text
            txtBpkbAlamat.Text = txtPemAlamat.Text
            txtBpkbRt.Text = txtPemRt.Text
            txtBpkbRw.Text = txtPemRw.Text

            With cmbBpkbKota
                .DataSource = Nothing
                .Items.Clear()
                StrSQL = ""
                StrSQL = "SELECT City From __addrlocation WHERE addrLocationID='" & kodepos & "'"
                FillCombobox(StrSQL, cmbBpkbKota, 1, tblKOta)
            End With
            cmbBpkbKota.Text = cmbPemKota.Text
            cmbBpkbKec.Text = cmbPemKec.Text
            'cmbBpkbKel.DataSource = cmbPemKel.DataSource
            cmbBpkbKel.Text = cmbPemKel.Text


        End If
    End Sub


    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class