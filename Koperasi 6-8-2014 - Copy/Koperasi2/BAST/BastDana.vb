Option Strict On

Imports System.Data.SqlClient

Public Class BastDana
    Dim FlagGrid As Boolean = False

    

    Private Sub BastKTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        settanggal()
        FillTable()
        FillCombo()
        FlagGrid = True

    

    End Sub

    Private Sub settanggal()
        Dim tanggalAngsuran As Date = Date.Now.AddMonths(1)
        dtPem.Text = CStr(Now)
        dtAngsuran.Text = CStr(tanggalAngsuran)
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
        Dim dsTable As New DataSet
        'da.Dispose()
        'ds.Clear()
        StrSQL = "SELECT ApplicationID as [No.Aplikasi],"
        StrSQL &= "MemberName as [Nama Konsumen],"
        StrSQL &= "Convert(varchar,BirthDate,103) as [Tanggal Lahir],"
        StrSQL &= "MotorBrand as [Merk Motor],"
        StrSQL &= "MotorType as [Tipe],"
        StrSQL &= "MotorColor as [Warna],"
        StrSQL &= "MotorYear as [Tahun],"
        StrSQL &= "PlatNo as [No.Polisi],"
        StrSQL &= "FrameCode as [No.Rangka],"
        StrSQL &= "EngineCode as [No.Mesin],"
        StrSQL &= "convert(int,MotorPrice) as [Pinjaman],"
        StrSQL &= "Tenor,convert(int,Installment) as [Angsuran],"
        StrSQL &= "convert(int,(MotorPrice+InsuranceAdmin+LoanAdmin)) as Modal, "
        StrSQL &= "BpkbNo as [Nomor Bpkb] "
        StrSQL &= "from [Application] INNER JOIN Member ON application.MemberID=member.memberid "
        StrSQL &= "AND Application.ApplicationTypeID ='1' AND Application.State=0 ORDER BY ApplicationID ASC"
        RunSQL(StrSQL, 2, "BastDana", , dsTable)
        gv1.DataSource = dsTable
        gv1.DataMember = "BastDana"
        FlagGrid = True
    End Sub

    Private Sub FillCombo()

        Dim TableBpkb As DataTable = CType(getTable(), DataTable)
        Dim tableCollector As DataTable = CType(getTable(), DataTable)
        StrSQL = ""
        StrSQL = "Sp_Reference_CBO 'BST'"
        FillComboWithValue(cmbBpkb, StrSQL, TableBpkb)

        StrSQL = ""
        StrSQL = "SpEmployee_CBO 'CL'"
        FillComboWithValue(cmbCollector, StrSQL, tableCollector)
      
    End Sub

    Private Sub form_Clear()
        settanggal()
        txtAplikasi.Clear()
        txtPemNama.Clear()
        txtMotor.Clear()
        txtTipe.Clear()
        txtWarna.Clear()
        txtTahun.Clear()
        txtNoPol.Clear()
        txtRangka.Clear()
        txtMesin.Clear()
        txtPinjaman.Clear()
        txtTenor.Clear()
        txtAngsuran.Clear()
        txtModal.Clear()
        cmbBpkb.SelectedIndex = 0
        txtBpkb.Clear()
        txtKontrak.Clear()
        cmbCollector.SelectedIndex = 0
        txtBunga.Clear()
        txtEffectiveInterest.Clear()
        txtBungaPengali.Clear()
        txtPokok.Clear()
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        FlagGrid = False
        Dim dsFilter As New DataSet
        'da.Dispose()
        'ds.Clear()
        StrSQL = "SELECT ApplicationID as [No.Aplikasi],"
        StrSQL &= "MemberName as [Nama Konsumen],"
        StrSQL &= "Convert(varchar,BirthDate,103) as [Tanggal Lahir],"
        StrSQL &= "MotorBrand as [Merk Motor],"
        StrSQL &= "MotorType as [Tipe],"
        StrSQL &= "MotorColor as [Warna],"
        StrSQL &= "MotorYear as [Tahun],"
        StrSQL &= "PlatNo as [No.Polisi],"
        StrSQL &= "FrameCode as [No.Rangka],"
        StrSQL &= "EngineCode as [No.Mesin],"
        StrSQL &= "convert(int,MotorPrice) as [Pinjaman],"
        StrSQL &= "Tenor,convert(int,Installment) as [Angsuran],"
        StrSQL &= "convert(int,(MotorPrice+AdminPremi+LoanAdmin)) as Modal, "
        StrSQL &= "BpkbNo as [Nomor Bpkb] "
        StrSQL &= "from [Application] INNER JOIN Member ON application.MemberID=member.memberid "
        StrSQL &= "AND (ApplicationID LIKE '%" & CStr(antisqli(CStr(txtCari.Text))) & "%' "
        StrSQL &= "OR MemberName LIKE '%" & CStr(antisqli(CStr(txtCari.Text))) & "%') "
        StrSQL &= "AND Application.ApplicationTypeID ='1' AND Application.State=0 ORDER BY ApplicationID ASC"
        RunSQL(StrSQL, 2, "FilterBastDana", , dsFilter)
        gv1.DataSource = dsFilter
        gv1.DataMember = "FilterBastDana"
        FlagGrid = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If txtAplikasi.Text.Length > 7 Then
        '    StrSQL = ""
        '    StrSQL = "SELECT ApplicationID From Application Where ApplicationID ='" & txtAplikasi.Text & "' "
        '    RunSQL(StrSQL, 1)

        '    If dt.Rows.Count > 0 Then
        '        Dim pesan As String = "Anda Akan Membuat Kontrak dengan Detail Berikut : "
        '        pesan &= vbNewLine & "---------------------------------------------------------------------"
        '        pesan &= vbNewLine & "Nomor Kontrak " & vbTab & vbTab & ": " & txtKontrak.Text
        '        pesan &= vbNewLine & "Nama Pelanggan Kontrak " & vbTab & ": " & txtPemNama.Text
        '        pesan &= vbNewLine & "Tanggal Kontrak " & vbTab & vbTab & ": " & dtKontrak.Text
        '        pesan &= vbNewLine & vbNewLine & "Apakah Anda yakin ? "
        '        Dim result As Integer = MessageBox.Show(pesan, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        '        If result = vbYes Then
        '            Contract_SAV()
        '            ContractDetail_SAV()
        '            Bank_SAVE()
        '            MessageBox.Show("Kontrak Berhasil Dibuat")
        '            FlagGrid = False
        '            form_Clear()
        '            FillTable()
        '        End If


        '    Else
        '        MessageBox.Show("Kontrak tidak berhasil dibuat")
        '    End If
        'Else
        '    MessageBox.Show("Kontrak tidak berhasil dibuat")
        'End If
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
                    FlagGrid = False
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

    Private Sub Contract_SAV()
        StrSQL = ""
        StrSQL = "SpContract_SAV "
        StrSQL &= "'" & txtAplikasi.Text & "',"
        StrSQL &= "'" & txtKontrak.Text & "',"
        StrSQL &= "'" & dtKontrak.Value & "',"
        StrSQL &= "'" & dtBast.Value & "',"
        StrSQL &= "'" & dtAngsuran.Value & "',"
        StrSQL &= "1,"
        StrSQL &= "'none',"
        StrSQL &= "'" & CStr(cmbCollector.SelectedValue) & "'"
        RunSQL(StrSQL, 0)

    End Sub

    Private Sub ContractDetail_SAV()
        Dim TanggalAwal As Integer = Microsoft.VisualBasic.DateAndTime.Day(dtAngsuran.Value)

        Dim bulan As Integer = Microsoft.VisualBasic.DateAndTime.Month(dtAngsuran.Value)
        'Dim tahun As Integer = Microsoft.VisualBasic.DateAndTime.Year(dtAngsuran.Value)
        Dim tanggalJatuhTempo As Integer = Microsoft.VisualBasic.DateAndTime.Day(dtAngsuran.Value)
        Dim bulanJatuhTempo As Integer = Microsoft.VisualBasic.DateAndTime.Month(dtAngsuran.Value)
        Dim tahunJatuhTempo As Integer = Microsoft.VisualBasic.DateAndTime.Year(dtAngsuran.Value)
        Dim tempJatuhTempo As String = ""
        ' Dim penambahBulan As Integer = 0
        Dim tempIndex As Integer
        Dim pokok As Double = CDbl(txtPokok.Text)
        'Dim BungaPengali As Double = CDbl(txtBungaPengali.Text)
        Dim EffectiveInterestP As Double = CDbl(txtEffectiveInterest.Text)
        Dim Bunga As Double = CDbl(txtBunga.Text)
        Dim Sp As Double
        Dim Si As Double
        Dim Op As Double
        Dim Oi As Double
        Dim tenor As Integer = CInt(txtTenor.Text)
        For index As Integer = 0 To tenor - 2
            If bulanJatuhTempo > 12 Then
                bulanJatuhTempo = bulanJatuhTempo - 12
                bulan = 1
                'penambahBulan += 1
                tahunJatuhTempo += 1
            End If

            If (bulanJatuhTempo = 4 Or bulanJatuhTempo = 6 Or bulanJatuhTempo = 9 Or bulanJatuhTempo = 11) And tanggalJatuhTempo = 31 Then
                tanggalJatuhTempo = 30
            End If
            If bulanJatuhTempo = 2 And tanggalJatuhTempo > 27 Then
                If tahunJatuhTempo Mod 4 = 0 Then
                    tanggalJatuhTempo = 28
                Else
                    tanggalJatuhTempo = 27
                End If
            End If
            tempJatuhTempo = CStr(tahunJatuhTempo) & "-" & CStr(bulanJatuhTempo) & "-" & CStr(tanggalJatuhTempo)

            bulanJatuhTempo += 1
            tanggalJatuhTempo = TanggalAwal
            ' JatuhTempo = CDate(tempJatuhTempo)
            Si = 30 / 360 * (EffectiveInterestP / 100) * CDbl(pokok)
            Sp = CDbl(txtAngsuran.Text) - Si
            Op = pokok - Sp
            Oi = Bunga - Si
            If Op < 0 Then
                Op = 0
            End If

            If Oi < 0 Then
                Oi = 0
            End If
            'Remark Tgl 17-7-14 by Achmad "Hilangkan Value beberapa kolom"
            'StrSQL = ""
            'StrSQL = "INSERT INTO ContractDetail (ContractID,JatuhTempo,Angsuran,Sp,Si,Op,Oi,[index],TglBayar,AMBC,OVD,Denda,TotalBayar,Outstanding,OutstandingReceive,OutstandingTotal,NoKwitansi) Values("
            'StrSQL &= "'" & CStr(antisqli(txtKontrak.Text)) & "',"
            'StrSQL &= "'" & CStr(tempJatuhTempo) & "',"
            'StrSQL &= "" & CDbl(txtAngsuran.Text) & ","
            'StrSQL &= "" & Math.Round(Sp) & ","
            'StrSQL &= "" & Math.Round(Si) & ","
            'StrSQL &= "" & Math.Round(Op) & ","
            'StrSQL &= "" & Math.Round(Oi) & ","
            'StrSQL &= "" & index & ","
            'StrSQL &= "''," 'tglbayar
            'StrSQL &= "0," 'ambc
            'StrSQL &= "0," 'ovd
            'StrSQL &= "0," 'denda
            'StrSQL &= "0," 'totalbayar
            'StrSQL &= "0," 'outstanding
            'StrSQL &= "0," 'outstandingreceive
            'StrSQL &= "0," 'outstandingTotal
            'StrSQL &= "'unpaid')" 'nokwitansi

            'RunSQL(StrSQL, 0) 
            'End Remark

            StrSQL = ""
            StrSQL = "INSERT INTO ContractDetail (ContractID,JatuhTempo,Angsuran,Sp,Si,Op,Oi,[index],NoKwitansi) Values("
            StrSQL &= "'" & CStr(antisqli(txtKontrak.Text)) & "',"
            StrSQL &= "'" & CStr(tempJatuhTempo) & "',"
            StrSQL &= "" & CDbl(txtAngsuran.Text) & ","
            StrSQL &= "" & Math.Round(Sp) & ","
            StrSQL &= "" & Math.Round(Si) & ","
            StrSQL &= "" & Math.Round(Op) & ","
            StrSQL &= "" & Math.Round(Oi) & ","
            StrSQL &= "" & index & ","
            StrSQL &= "'unpaid')" 'nokwitansi

            RunSQL(StrSQL, 0)

            pokok = pokok - Sp
            Bunga = Bunga - Si
            'Bunga = Bunga + Si
            tanggalJatuhTempo = Microsoft.VisualBasic.DateAndTime.Day(dtAngsuran.Value)
            tempIndex = index

        Next

        lastTenor(tempIndex, tempJatuhTempo, Sp, Si, Op, Oi, pokok, Bunga, TanggalAwal)


    End Sub

    Private Sub lastTenor(ByVal index As Integer, ByVal JatuhTempo As String, ByVal sp As Double, ByVal si As Double, ByVal op As Double, ByVal oi As Double, ByVal pokok As Double, ByVal bunga As Double, ByVal tanggalawal As Integer)

        Dim tanggal As Integer
        Dim bulan As Integer
        Dim tahun As Integer
        Dim penambahtahun As Integer = 0
        Dim EffectiveInterestP As Double = CDbl(txtEffectiveInterest.Text)
        Dim angsuran As Double

        tahun = Microsoft.VisualBasic.DateAndTime.Year(CDate(JatuhTempo))
        bulan = Microsoft.VisualBasic.DateAndTime.Month(CDate(JatuhTempo))
        tanggal = tanggalawal
        bulan = bulan + 1

        If bulan = 13 Then
            bulan = 1
            penambahtahun += 1
        End If

        If penambahtahun <> 0 Then
            tahun = tahun + penambahtahun
        End If

        If bulan = 2 And tanggal > 27 Then
            If tahun Mod 4 = 0 Then
                tanggal = 28
            Else
                tanggal = 27
            End If
        End If

        If bulan = 4 Or bulan = 6 Or bulan = 9 Or bulan = 11 And tanggal = 31 Then
            tanggal = 30
        End If




        JatuhTempo = CStr(tahun) & "-" & CStr(bulan) & "-" & CStr(tanggal)

        sp = op
        si = oi
        op = 0
        oi = 0

        angsuran = sp + si


        'Remark 17-7-14 By Achmad "Hilangkan value beberapa kolom"
        'StrSQL = ""
        'StrSQL = "INSERT INTO ContractDetail (ContractID,JatuhTempo,Angsuran,Sp,Si,Op,Oi,[index],TglBayar,AMBC,OVD,Denda,TotalBayar,Outstanding,OutstandingReceive,OutstandingTotal,NoKwitansi) Values("
        'StrSQL &= "'" & CStr(antisqli(txtKontrak.Text)) & "',"
        'StrSQL &= "'" & CStr(JatuhTempo) & "',"
        'StrSQL &= "" & CDbl(angsuran) & ","
        'StrSQL &= "" & Math.Round(sp) & ","
        'StrSQL &= "" & Math.Round(si) & ","
        'StrSQL &= "" & Math.Round(op) & ","
        'StrSQL &= "" & Math.Round(oi) & ","
        'StrSQL &= "" & index + 1 & ","
        'StrSQL &= "''," 'tglbayar
        'StrSQL &= "0," 'ambc
        'StrSQL &= "0," 'ovd
        'StrSQL &= "0," 'denda
        'StrSQL &= "0," 'totalbayar
        'StrSQL &= "0," 'outstanding
        'StrSQL &= "0," 'outstandingreceive
        'StrSQL &= "0," 'outstandingTotal
        'StrSQL &= "'unpaid')" 'nokwitansi


        'RunSQL(StrSQL, 0)
        'End Remark

        StrSQL = ""
        StrSQL = "INSERT INTO ContractDetail (ContractID,JatuhTempo,Angsuran,Sp,Si,Op,Oi,[index],NoKwitansi) Values("
        StrSQL &= "'" & CStr(antisqli(txtKontrak.Text)) & "',"
        StrSQL &= "'" & CStr(JatuhTempo) & "',"
        StrSQL &= "" & CDbl(angsuran) & ","
        StrSQL &= "" & Math.Round(sp) & ","
        StrSQL &= "" & Math.Round(si) & ","
        StrSQL &= "" & Math.Round(op) & ","
        StrSQL &= "" & Math.Round(oi) & ","
        StrSQL &= "" & index + 1 & ","
        StrSQL &= "'unpaid')" 'nokwitansi


        RunSQL(StrSQL, 0)



    End Sub

    Private Sub Bank_SAVE()
        Dim keterangan As String = "Penyerahan Uang (BAST Dana Tunai) Kepada pelanggan "
        StrSQL = ""
        StrSQL = "Sp_BastSave "
        StrSQL &= "'" & dtKontrak.Value.Date & "'"
        StrSQL &= "," & CDbl(txtModal.Text) & ""
        StrSQL &= ",'" & UserName & "'"
        StrSQL &= ",'" & Now & "'"
        StrSQL &= ",'" & txtKontrak.Text & "'"
        StrSQL &= ",'" & keterangan & "'"
        StrSQL &= ",'TRB001'"
        RunSQL(StrSQL, 0)
    End Sub

    Private Sub gv1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gv1.SelectionChanged
        If FlagGrid = True Then
            txtAplikasi.Text = CStr(gv1.CurrentRow.Cells(0).Value)
            RunSQL("SELECT BirthDate from Member inner join Application ON member.MemberID=application.memberid AND applicationid ='" & CStr(antisqli(CStr(txtAplikasi.Text))) & "'", 1)
            dtPem.Text = CStr(dt.Rows(0)("BirthDate"))
            txtPemNama.Text = CStr(gv1.CurrentRow.Cells(1).Value)
            'dtPem.Text = tampung
            txtMotor.Text = CStr(gv1.CurrentRow.Cells(3).Value)
            txtTipe.Text = CStr(gv1.CurrentRow.Cells(4).Value)
            txtWarna.Text = CStr(gv1.CurrentRow.Cells(5).Value)
            txtTahun.Text = CStr(gv1.CurrentRow.Cells(6).Value)
            txtNoPol.Text = CStr(gv1.CurrentRow.Cells(7).Value)
            txtRangka.Text = CStr(gv1.CurrentRow.Cells(8).Value)
            txtMesin.Text = CStr(gv1.CurrentRow.Cells(9).Value)
            txtPinjaman.Text = CStr(ribuan(CStr(gv1.CurrentRow.Cells(10).Value)))
            txtTenor.Text = CStr(gv1.CurrentRow.Cells(11).Value)
            txtAngsuran.Text = CStr(ribuan(CStr(gv1.CurrentRow.Cells(12).Value)))
            txtModal.Text = CStr(ribuan(CStr(gv1.CurrentRow.Cells(13).Value)))
            txtBpkb.Text = CStr(gv1.CurrentRow.Cells(14).Value)
            txtKontrak.Text = CStr(AutoNumberContract(CStr(txtAplikasi.Text), "01"))
            StrSQL = ""
            StrSQL = String.Format("SELECT Bunga,BungaPengali,EffectiveInterestP,Pokok FROM Application where ApplicationID='{0}'", CStr(antisqli(txtAplikasi.Text)))
            RunSQL(StrSQL, 1)
            txtBungaPengali.Text = CStr(dt.Rows(0)("BungaPengali"))
            txtPokok.Text = CStr(dt.Rows(0)("Pokok"))
            txtEffectiveInterest.Text = CStr(dt.Rows(0)("EffectiveInterestP"))
            txtBunga.Text = CStr(dt.Rows(0)("Bunga"))
        End If
    End Sub


    Private Function CreateContract() As Boolean
        Try
            Dim pokok As Double = CDbl(getFieldValue("SELECT BaseDebt from Application Where ApplicationID='" & txtAplikasi.Text & "'"))
            'Dim BungaPengali As Double = CDbl(txtBungaPengali.Text)
            Dim EffectiveInterestP As Double = CDbl(getFieldValue("SELECT EffectiveInterestP from Application Where ApplicationID='" & txtAplikasi.Text & "'"))
            Dim AdminMurni As Double = CDbl(getFieldValue("SELECT LoanAdmin from Application Where ApplicationID='" & txtAplikasi.Text & "'"))
            Dim FlagInsUpd As String = "INS"
            Dim FlagKontrak As String = "BAST_DT"
            StrSQL = ""
            StrSQL = "Sp_ContractIU '" & FlagInsUpd & "', "
            StrSQL &= "'" & FlagKontrak & "',"
            StrSQL &= "'" & txtAplikasi.Text & "',"
            StrSQL &= "'" & txtKontrak.Text & "',"
            StrSQL &= "'" & dtKontrak.Value & "',"
            StrSQL &= "'" & dtBast.Value & "',"
            StrSQL &= "'" & dtAngsuran.Value & "',"
            StrSQL &= "'" & cmbCollector.SelectedValue.ToString() & "',"
            StrSQL &= "'" & UserName & "',"
            StrSQL &= "" & CInt(txtTenor.Text) & ","
            StrSQL &= "" & pokok & ","
            StrSQL &= "" & EffectiveInterestP & ","
            StrSQL &= "" & AdminMurni & ",0"
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