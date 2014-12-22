Imports System.Runtime.InteropServices
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmMotorBaru
    Private isDealerSubs As Boolean = False
    Private isDpPlus As Boolean = True
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
#Region "hitung2"
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtPinjaman.Text <> "0" AndAlso txtDownPayment.Text <> "0" Then

            Dim tempPureDownPayment As Double = CDbl(txtDownPayment.Text) - CDbl(txtAdminKredit.Text) - CDbl(txtPremiAdmin.Text)
            Dim tempFlatInterestP As Double = 0
            Dim tempMultiplierInterestP As Double = 0

            If isDpPlus Then
                txtPureDownPayment.Text = Format(tempPureDownPayment, "#,##0")
                txtMarketingCost.Clear()
                txtMarketingCost.Text = "0"
                txtAdminMurni.Text = Format(CDbl(txtAdminKredit.Text) - CDbl(txtDealerSubs.Text), "#,##0")
                txtDealerTransfer.Text = Format(CDbl(txtPinjaman.Text) - CDbl(txtDownPayment.Text) + CDbl(txtDealerSubs.Text), "#,##0")
                txtPureDownPaymentP.Text = Format((CDbl(txtPureDownPayment.Text) / CDbl(txtPinjaman.Text)) * 100, "#,##0.00")
            Else
                If CDbl(tempPureDownPayment) < 0 Then
                    txtMarketingCost.Text = Format(-1 * tempPureDownPayment, "#,##0")
                    txtPureDownPayment.Text = "0"
                    txtAdminKredit.Text = Format(txtAdminKredit.Text + tempPureDownPayment, "#,##0")
                    isDealerSubs = True
                End If

                If isDealerSubs And txtDealerSubs.Text <> "0" Then
                    txtDealerSubs.Text = Format(CDbl(txtDealerSubs.Text) - CDbl(txtMarketingCost.Text), "#,##0")
                    isDealerSubs = False
                End If
                txtAdminMurni.Text = Format(CDbl(txtAdminKredit.Text) - CDbl(txtDealerSubs.Text), "#,##0")
                txtDealerTransfer.Text = Format(CDbl(txtPinjaman.Text) - CDbl(txtDownPayment.Text) + CDbl(txtDealerSubs.Text) + CDbl(txtMarketingCost.Text), "#,##0")
            End If
            txtPureDownPaymentP.Text = Format((CDbl(txtPureDownPayment.Text) / CDbl(txtPinjaman.Text)) * 100, "#,##0.00")
            txtPokok.Text = Format(CDbl(txtPinjaman.Text) - CDbl(txtPureDownPayment.Text), "#,##0")
            tempFlatInterestP = ((((CDbl(txtTenor.Text) * (CDbl(txtTingkatBunga.Text) / 1200)) / (1 - (1 + (CDbl(txtTingkatBunga.Text) / 1200)) ^ (-1 * CDbl(txtTenor.Text)))) - 1) * (12 / CDbl(txtTenor.Text))) * 100
            txtBungaFlat.Text = Format(tempFlatInterestP, "#,##0.00")
            tempMultiplierInterestP = CDbl(tempFlatInterestP) * (CDbl(txtTenor.Text) / 12)
            txtBungaPengali.Text = Format(tempMultiplierInterestP, "#,##0.00")
            txtBunga.Text = Format(CDbl(txtPokok.Text) * CDbl(tempMultiplierInterestP) / 100, "#,##0")
            txtTotalHutang.Text = Format(CDbl(txtPokok.Text) + CDbl(txtBunga.Text), "#,##0")
            txtAngsuran.Text = Format(Math.Ceiling(CDbl(txtTotalHutang.Text) / (CDbl(txtTenor.Text) * 1000)) * 1000, "#,##0")

        End If

    End Sub

    Private Sub MinPlus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDownPayment.Leave, txtAdminKredit.Leave, txtPremiAdmin.Leave
        Dim tempPureDownPayment As Double = CDbl(txtDownPayment.Text) - CDbl(txtAdminKredit.Text) - CDbl(txtPremiAdmin.Text)
        If tempPureDownPayment < 0 Then
            isDpPlus = False
        Else
            isDpPlus = True
        End If

    End Sub

    Private Sub Calculate(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPinjaman.Leave, txtDownPayment.Leave, txtTingkatBunga.TextChanged, txtPremiAsuransi.TextChanged, txtAdmin.Leave, txtTenor.Leave
        Try
            txtPremiAdmin.Text = Format(((CDbl(txtPinjaman.Text) * CDbl(txtPremiAsuransi.Text)) / 100) + CDbl(txtAdmin.Text), "#,##0")
        Catch ex As Exception
            Exit Try
        End Try

        txtAdminMurni.Clear()
        txtDealerTransfer.Clear()
        txtMarketingCost.Clear()
        txtPureDownPayment.Clear()
        txtPureDownPaymentP.Clear()
        txtPokok.Clear()
        txtBungaFlat.Clear()
        txtBungaPengali.Clear()
        txtBunga.Clear()
        txtTotalHutang.Clear()
        txtAngsuran.Clear()
    End Sub

#End Region

    Private Sub frmMotorBaru_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        posFlag = False
        txtKendaraan.Clear()
        txtTipe.Clear()
        txtWarna.Clear()
        txtTahun.Clear()

        txtPinjaman.Text = "0"
        txtPremiAsuransi.Text = "0"
        txtAdmin.Text = ribuan("35000")
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
        FillCombobox("select distinct City from [__AddrLocation] where City like 'JAKARTA%' or City like 'Kepulauan Seribu' OR City Like 'Bogor%' OR City Like 'Tangerang%' order by City asc", cmbPemKota, 1, tblPemKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPemKota.Text + "' ORDER BY [SubDistrict] ASC", cmbPemKec, 1, tblPemKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPemKec.Text + "' ORDER BY [Village] ASC", cmbPemKel, 2, tblPemKel)
        FillCombobox("exec Sp_Reference_CBO 'TWC'", txtPemKerja, 2, tblPemKer)
        FillCombobox("select distinct City from [__AddrLocation] where City like 'JAKARTA%' or City like 'Kepulauan Seribu' OR City Like 'Bogor%' OR City Like 'Tangerang%' order by City asc", cmbPenagihanKota, 1, tblPenKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPenagihanKota.Text + "' ORDER BY [SubDistrict] ASC", cmbPenagihanKec, 1, tblPenKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPenagihanKec.Text + "' ORDER BY [Village] ASC", cmbPenagihanKel, 2, tblPenKel)
        FillCombobox("select distinct City from [__AddrLocation] where City like 'JAKARTA%' or City like 'Kepulauan Seribu' OR City Like 'Bogor%' OR City Like 'Tangerang%' order by City asc", cmbPerusahaanKota, 1, tblPerKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbPerusahaanKota.Text + "' ORDER BY [SubDistrict] ASC", cmbPerusahaanKec, 1, tblPerKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbPerusahaanKec.Text + "' ORDER BY [Village] ASC", cmbPerusahaanKel, 2, tblPerKel)
        FillCombobox("select distinct City from [__AddrLocation] where City like 'JAKARTA%' or City like 'Kepulauan Seribu' OR City Like 'Bogor%' OR City Like 'Tangerang%' order by City asc", cmbKontakKota, 1, tblKonKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbKontakKota.Text + "' ORDER BY [SubDistrict] ASC", cmbKontakKec, 1, tblKonKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKontakKec.Text + "' ORDER BY [Village] ASC", cmbKontakKel, 2, tblKonKel)
        FillCombobox("select distinct City from [__AddrLocation] where City like 'JAKARTA%' or City like 'Kepulauan Seribu' OR City Like 'Bogor%' OR City Like 'Tangerang%' order by City asc", cmbBpkbKota, 1, tblBpKot)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbBpkbKota.Text + "' ORDER BY [SubDistrict] ASC", cmbBpkbKec, 1, tblBpKec)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbBpkbKec.Text + "' ORDER BY [Village] ASC", cmbBpkbKel, 2, tblBpKel)
    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With frmTabApp
            formFlag = "2"
            .txtFlag.Text = "2"
            .Show()
        End With
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

    Private Sub txtPemNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPemNo.TextChanged

        Dim kodeposPemohon As String
        Dim kodeposPenagihan As String
        Dim kodeposPerusahaan As String
        Dim kodeposKontak As String
        Dim kodeposBpkb As String
        If txtPemNo.Text.Length > 7 Then
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

    Private Sub txtAplikasi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAplikasi.TextChanged
        If txtAplikasi.Text.Length = txtAplikasi.MaxLength Then

            StrSQL = ""
            StrSQL = "SELECT * FROM APPLICATION WHERE APPLICATIONID ='" + antisqli(txtAplikasi.Text) + "'"
            RunSQL(StrSQL, 1)
            If dt.Rows.Count > 0 Then
                Dim platno As String = dt.Rows(0)("PlatNo")
                Dim bpkbno As String = dt.Rows(0)("BpkbNo")
                Dim motorprice As String = dt.Rows(0)("Motorprice")
                Dim insurancerate As String = dt.Rows(0)("insurancerate")
                Dim insuranceadmin As String = dt.Rows(0)("insuranceadmin")
                Dim tenor As String = dt.Rows(0)("tenor")
                Dim EffectiveInterestP As String = dt.Rows(0)("EffectiveInterestP")
                Dim loanadmin As String = dt.Rows(0)("LoanAdmin")
                Dim memberid As String = dt.Rows(0)("memberid")
                Dim surveycomment As String = dt.Rows(0)("surveycomment")
                Dim adminpremi As String = dt.Rows(0)("adminpremi")
                Dim marketingCost As String = dt.Rows(0)("MarketingCost")
                Dim DownPayment As String = dt.Rows(0)("DownPayment")
                Dim dealerSubs As String = dt.Rows(0)("DealerSubs")
                Dim dokument As String = dt.Rows(0)("ShortageDoc")
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
                    txtPinjaman.Text = ribuan(motorprice)
                    txtPremiAsuransi.Text = insurancerate
                    txtAdmin.Text = insuranceadmin
                    txtTenor.Text = tenor
                    txtDealerSubs.Text = dealerSubs
                    txtTingkatBunga.Text = EffectiveInterestP
                    txtAdminKredit.Text = loanadmin
                    txtDownPayment.Text = DownPayment
                    txtMarketingCost.Text = marketingCost
                    txtPemNo.Text = memberid
                    oldMemberID = memberid
                    txtKomentar.Text = surveycomment
                    txtDokumen.Text = dokument
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

    Private Sub LostFocusRibuan(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPinjaman.Leave, txtUangPemohon.Leave, txtUangPasangan.Leave, txtUangLain.Leave, txtUangKeluar.Leave, txtPremiAdmin.Leave, txtAdminKredit.Leave, txtAdmin.Leave, txtDealerSubs.Leave, txtMarketingCost.Leave, txtPureDownPayment.Leave, txtDownPayment.Leave, txtDealerSubs.Leave
        Dim txtBox = DirectCast(sender, TextBox)
        txtBox.Text = ribuan(txtBox.Text)
    End Sub
    Private Sub KeyPressDecimal(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPinjaman.KeyPress, txtTingkatBunga.KeyPress, txtTenor.KeyPress, txtPremiAsuransi.KeyPress, txtPremiAdmin.KeyPress, txtPerusahaanTelp.KeyPress, txtPerusahaanRw.KeyPress, txtPerusahaanRt.KeyPress, txtPerusahaanMasa.KeyPress, txtPenagihanRw.KeyPress, txtPenagihanRt.KeyPress, txtPemTelp2.KeyPress, txtPemTelp1.KeyPress, txtPemRw.KeyPress, txtPemRt.KeyPress, txtPemHp.KeyPress, txtKontakRw.KeyPress, txtKontakRt.KeyPress, txtAdminKredit.KeyPress, txtAdmin.KeyPress, txtUangPemohon.KeyPress, txtUangPasangan.KeyPress, txtUangLain.KeyPress, txtUangKeluar.KeyPress, txtKontakTelp.KeyPress, txtBpkbRw.KeyPress, txtBpkbRt.KeyPress
        Dim txtBox = DirectCast(sender, TextBox)
        decimalOnly(sender, e, txtBox.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmTabMem.Show()
        formFlag = 2
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

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
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
                TempPO()
                PrintPO()

                With POView
                    .MdiParent = frmMain
                    .WindowState = FormWindowState.Maximized
                    .Show()
                End With

            ElseIf sender.Name = "btnReject" Then
            End If
            ClearForm()
            txtAplikasi.Text = autoNumber(cmbPos.Text)
            txtPemNo.Text = autoNumberMember(cmbPos.Text)
        Else
            MessageBox.Show(alertmsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub TempPO()
        'Dim kontrak As String
        Dim temptanggalJT As Date
        Dim TanggalJT As String

        temptanggalJT = Date.Now.AddMonths(1)
        TanggalJT = String.Format("{0:dd/MM/yy}", temptanggalJT)

        StrSQL = ""
        StrSQL = "Delete From TempPO"
        RunSQL(StrSQL, 0)



        StrSQL = ""
        StrSQL = "INSERT INTO TempPO Values("
        StrSQL &= "'" & txtAplikasi.Text & "',"
        StrSQL &= "'" & txtAplikasi.Text & "',"
        StrSQL &= "'" & cmbPos.Text & "',"
        StrSQL &= "'" & txtPemNama.Text & "',"
        StrSQL &= "'" & txtPemAlamat.Text & "',"
        StrSQL &= "'" & txtBpkbNama.Text & "',"
        StrSQL &= "'" & txtTipe.Text & "',"
        StrSQL &= "'" & txtPinjaman.Text & "',"
        StrSQL &= "'" & txtDownPayment.Text & "',"
        StrSQL &= "'" & txtAngsuran.Text & "',"
        StrSQL &= "'" & txtTenor.Text & "',"
        StrSQL &= "'" & cmbCreditAnalyst.Text & "',"
        StrSQL &= "'" & txtDokumen.Text & "',"
        StrSQL &= "'" & TanggalJT & "')"

        RunSQL(StrSQL, 0)

    End Sub

    Private Sub PrintPO()
        'RepName = "PO"
        'strReportPath = Application.StartupPath & "\Report\" & RepName & ".rpt"
        'If Not IO.File.Exists(strReportPath) Then
        '    Throw (New Exception("Unable to locate report file:" & vbCrLf & strReportPath))
        'End If
        'Dim rptDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        'rptDocument.Load(strReportPath)
        'rptDocument.Refresh()
        'rptDocument.SetDatabaseLogon(con_userid, con_password, con_server, con_database)
        'With POView
        '    .CRViewer.DisplayToolbar = True
        '    .CRViewer.ReportSource = rptDocument
        'End With
        RepName = "PO"
        strReportPath = Application.StartupPath & "\Report\" & RepName & ".rpt"
        If IO.File.Exists(strReportPath) Then
            ViewReport(POView.CRViewer, strReportPath)
            POView.Show()
        Else

            Throw (New Exception("File Report Tidak Ditemukan di Path ini:" & vbCrLf & strReportPath))
        End If


        
    End Sub






    Private Sub Application_SAV(ByVal _InsUpd As String, ByVal _MemberID As String, ByVal _IsApprv As Boolean)
        ' If _InsUpd = "INS" Then _ApplicationID = gGUID(11)

        StrSQL = "SpApplication_SAV '" & _InsUpd & "', "
        StrSQL &= "'" & txtAplikasi.Text & "', "
        StrSQL &= "'" & dtTanggal.Value.ToString("yyyyMMdd") & "', "
        StrSQL &= "'" & cmbPos.SelectedValue & "', "
        StrSQL &= "'" & cmbCreditAnalyst.SelectedValue & "', "
        StrSQL &= "'" & cmbSurveyor.SelectedValue & "', "
        StrSQL &= "'" & cmbSalesman.SelectedValue & "', "
        StrSQL &= "'2', "
        StrSQL &= "'" & txtTenor.Text & "', "
        StrSQL &= CInt(txtTingkatBunga.Text) & ", "
        StrSQL &= CDbl(txtPinjaman.Text) & ", "
        StrSQL &= "0, "
        StrSQL &= CDbl(txtDownPayment.Text) & ","
        StrSQL &= CDbl(txtPremiAsuransi.Text) & ", "
        StrSQL &= CDbl(txtAdminKredit.Text) & ", "
        StrSQL &= CDbl(txtDealerSubs.Text) & ", " 'CDbl(DealerSubs.Text) & ", "
        StrSQL &= CDbl(txtMarketingCost.Text) & ", "
        StrSQL &= CDbl(txtAdmin.Text) & ", "
        StrSQL &= "'" & txtKendaraan.Text & "', "
        StrSQL &= "'" & txtTipe.Text & "', "
        StrSQL &= "'" & txtWarna.Text & "', "
        StrSQL &= "'" & txtTahun.Text & "', "
        StrSQL &= "'" & _MemberID & "', "
        StrSQL &= IIf(_IsApprv, 1, 0) & ", "
        StrSQL &= "'" & txtKomentar.Text & "',"
        StrSQL &= "'" & txtDokumen.Text & "',"
        StrSQL &= CDbl(txtPokok.Text) & ", "
        StrSQL &= CDbl(txtAngsuran.Text) & ", "
        StrSQL &= "'', "
        StrSQL &= "'', "
        StrSQL &= "'', "
        StrSQL &= "'', "
        StrSQL &= "'', "
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
        StrSQL &= "'', " 'nama ibu yg dihapus
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
    End Sub


End Class