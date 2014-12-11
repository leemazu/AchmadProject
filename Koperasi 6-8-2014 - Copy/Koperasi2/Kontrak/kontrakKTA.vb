Imports DevExpress.XtraEditors.Repository
Imports System.Data.SqlClient
Public Class kontrakKTA

    Private Sub kontrakKTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub KontrakLoad()
        StrSQL = ""
        StrSQL = "SELECT Contract.EmployeeID as [Kolektor],"
        StrSQL &= "Contract.[State] as [State],"
        StrSQL &= "Application.ApplicationID as [NoAplikasi],"
        StrSQL &= "application.ApplicationDate as [TanggalApplikasi],"
        StrSQL &= "application.PosID as [Pos],"
        StrSQL &= "Application.CreditAnalystID as [CA],"
        StrSQL &= "application.SurveyorID as [SY],"
        StrSQL &= "Application.SalesManID as [SM],"
        StrSQL &= "Application.MemberID as [MemberID],"
        StrSQL &= "member.MemberName as [MemberName],"
        StrSQL &= "member.GenderID as [GenderID],"
        StrSQL &= "member.BirthPlace as [TempatLahir],"
        StrSQL &= "member.BirthDate as [TanggalLahir],"
        StrSQL &= "member.PersonalIdentity as [KTP],"
        StrSQL &= "member.Phone1 as [Handphone],"
        StrSQL &= "member.Phone2 as [Telp1Pemohon],"
        StrSQL &= "member.Phone3 as [Telp2Pemohon],"
        StrSQL &= "member.MomMaidenName as [NamaIbu],"
        StrSQL &= "member.WorkTypeID as [Pekerjaan],"
        StrSQL &= "member.CompName as [Perusahaan],"
        StrSQL &= "member.CompPosition as [Jabatan],"
        StrSQL &= "member.CompWorkTime as [MasaKerja],"
        StrSQL &= "member.Income as [Pendapatan],"
        StrSQL &= "member.SpouseIncome as [PendapatanPasangan],"
        StrSQL &= "member.OtherIncome as [PendapatanLain],"
        StrSQL &= "member.Expense as [Pengeluaran],"
        StrSQL &= "Application.SurveyComment as [Komentar],"
        StrSQL &= "member.Address as [AlamatKTP],"
        StrSQL &= "member.BillingAddress as [AlamatTagih],"
        StrSQL &= "member.CompAddress as [AlamatKantor],"
        StrSQL &= "member.CompPhone as [TelpKantor],"
        StrSQL &= "member.EmerAddress as [AlamatDarurat],"
        StrSQL &= "member.EmerName as [NamaDarurat],"
        StrSQL &= "member.EmerRelations as [Hubungan],"
        StrSQL &= "member.EmerPhone as [TelpDarurat],"
        StrSQL &= "Application.MotorBrand as [MerkKendaraan],"
        StrSQL &= "application.MotorType as [Tipe],"
        StrSQL &= "Application.MotorColor as [Warna],"
        StrSQL &= "Application.MotorYear as [Tahun],"
        StrSQL &= "application.EngineCode as [NomorMesin],"
        StrSQL &= "application.FrameCode as [NomorRangka],"
        StrSQL &= "application.PlatNo as [NoPolisi],"
        StrSQL &= "application.BpkbNo as [NoBpkb],"
        StrSQL &= "application.MotorPrice as [Pinjaman],"
        StrSQL &= "application.Tenor as [Tenor],"
        StrSQL &= "application.InsuranceRate as [PremiAsuransi],"
        StrSQL &= "Application.InsuranceAdmin as [Admin],"
        StrSQL &= "application.AdminPremi as [PremiAdmin],"
        StrSQL &= "application.EffectiveInterestP as [TingkatBungaEfektif],"
        StrSQL &= "application.LoanAdmin as [AdminKredit],"
        StrSQL &= "Application.BungaPengali as [BungaPengali],"
        StrSQL &= "application.Pokok as [Pokok],"
        StrSQL &= "application.Bunga as [Bunga],"
        StrSQL &= "application.Installment as [Angsuran],"
        StrSQL &= "contract.BpkbState as [StatusBpkb],"
        StrSQL &= "contract.BpkbNo as [NoBpkb],"
        StrSQL &= "contract.BastDate as [TglBast],"
        StrSQL &= "contract.FirstInstallment as [TglAngsuran] "
        StrSQL &= "From Contract Inner Join Application ON contract.ContractID = Application.ContractID "
        StrSQL &= "Inner Join Member ON Application.MemberID = member.MemberID "
        StrSQL &= "WHERE Contract.ContractID ='" & txtKontrak.Text & "'"

        RunSQL(StrSQL, 1)

        txtKolektor.Text = getFieldValue("SELECT EmployeeName From Employee Where EmployeeID ='" & dt.Rows(0)("Kolektor").ToString() & "'")
        Select Case dt.Rows(0)("State")
            Case "1"
                txtStatusKontrak.Text = "Aktif"
            Case "2"
                txtStatusKontrak.Text = "Lunas - Normal"
            Case "3"
                txtStatusKontrak.Text = "Lunas - Dimuka"
            Case "4"
                txtStatusKontrak.Text = "Lunas - Khusus"
            Case "5"
                txtStatusKontrak.Text = "Lunas - Asuransi"
            Case "6"
                txtStatusKontrak.Text = "Buyback"
        End Select

        txtAplikasi.Text = CStr(dt.Rows(0)("NoAplikasi"))
        txtTglAplikasi.Text = CDate(dt.Rows(0)("TanggalApplikasi")).ToString("dd/MM/yyyy")
        txtPOS.Text = getFieldValue("SELECT ReferenceName from _Reference Where ReferenceID ='" & dt.Rows(0)("Pos").ToString() & "'")
        txtCA.Text = getFieldValue("SELECT EmployeeName From Employee Where EmployeeID ='" & dt.Rows(0)("CA").ToString() & "'")
        txtSY.Text = getFieldValue("SELECT EmployeeName From Employee Where EmployeeID ='" & dt.Rows(0)("SY").ToString() & "'")
        txtSM.Text = getFieldValue("SELECT EmployeeName From Employee Where EmployeeID ='" & dt.Rows(0)("SM").ToString() & "'")
        txtPemNo.Text = CStr(dt.Rows(0)("MemberID"))
        txtPemNama.Text = CStr(dt.Rows(0)("MemberName"))
        txtGender.Text = getFieldValue("SELECT ReferenceName from _Reference Where ReferenceID ='" & dt.Rows(0)("GenderID").ToString() & "'")
        txtPemTl.Text = CStr(dt.Rows(0)("TempatLahir"))
        txtPemLahir.Text = CDate(dt.Rows(0)("TanggalLahir")).ToString("dd/MM/yyyy")
        txtPemKtp.Text = CStr(dt.Rows(0)("KTP"))
        txtPemHp.Text = CStr(dt.Rows(0)("HandPhone"))
        txtPemTelp1.Text = CStr(dt.Rows(0)("Telp1Pemohon"))
        txtPemTelp2.Text = CStr(dt.Rows(0)("Telp2Pemohon"))
        txtPemIbu.Text = CStr(dt.Rows(0)("NamaIbu"))
        txtPemPekerjaan.Text = getFieldValue("SELECT ReferenceName from _Reference Where ReferenceID ='" & dt.Rows(0)("Pekerjaan").ToString() & "'")
        txtPerusahaanNama.Text = CStr(dt.Rows(0)("Perusahaan"))
        txtPerusahaanJabatan.Text = CStr(dt.Rows(0)("Jabatan"))
        txtPerusahaanMasa.Text = CStr(dt.Rows(0)("MasaKerja"))
        txtUangPemohon.Text = ribuan(CStr(dt.Rows(0)("Pendapatan")))
        txtUangPasangan.Text = ribuan(CStr(dt.Rows(0)("PendapatanPasangan")))
        txtUangLain.Text = ribuan(CStr(dt.Rows(0)("PendapatanLain")))
        txtUangKeluar.Text = ribuan(CStr(dt.Rows(0)("Pengeluaran")))
        txtKomentar.Text = CStr(dt.Rows(0)("Komentar"))
        txtAlamatKTP.Text = CStr(dt.Rows(0)("AlamatKTP"))
        txtAlamatTagih.Text = CStr(dt.Rows(0)("AlamatTagih"))
        txtAlamatKantor.Text = CStr(dt.Rows(0)("AlamatKantor"))
        txtTeleponKantor.Text = CStr(dt.Rows(0)("TelpKantor"))
        txtAlamatDarurat.Text = CStr(dt.Rows(0)("AlamatDarurat"))
        txtDaruratNama.Text = CStr(dt.Rows(0)("NamaDarurat"))
        txtDaruratHubungan.Text = CStr(dt.Rows(0)("Hubungan"))
        txtTeleponDarurat.Text = CStr(dt.Rows(0)("TelpDarurat"))
      
        txtPinjaman.Text = ribuan(CStr(dt.Rows(0)("Pinjaman")))
        txtTenor.Text = CStr(dt.Rows(0)("Tenor"))
      

        txtTingkatBunga.Text = CStr(dt.Rows(0)("TingkatBungaEfektif"))

        txtBungaPengali.Text = CStr(dt.Rows(0)("BungaPengali"))
        Dim tempBungaFlat As Double = ((((CDbl(txtTenor.Text) * (CDbl(txtTingkatBunga.Text) / 1200)) / (1 - (1 + (CDbl(txtTingkatBunga.Text) / 1200)) ^ (-1 * CDbl(txtTenor.Text)))) - 1) * (12 / CDbl(txtTenor.Text))) * 100
        txtBungaFlat.Text = Format(tempBungaFlat, "#,##0.00")
        txtPokok.Text = ribuan(CStr(dt.Rows(0)("Pokok")))
        txtBunga.Text = ribuan(CStr(dt.Rows(0)("Bunga")))
        txtAngsuran.Text = ribuan(CStr(dt.Rows(0)("Angsuran")))

        txtTotalHutang.Text = Format(CDbl(txtPokok.Text) + CDbl(txtBunga.Text), "#,##0")
       
        txtTglBpkb.Text = CDate(dt.Rows(0)("TglBast")).ToString("dd/MM/yyyy")
        txtTglAngsuran.Text = CDate(dt.Rows(0)("TglAngsuran")).ToString("dd/MM/yyyy")
        txtPokok.Text = Format(CDbl(txtPinjaman.Text), "#,##0")
        Dim tempMultiplierInterestP As Double = 0
        Dim tempFlatInterestP As Double = 0
        tempFlatInterestP = ((((CDbl(txtTenor.Text) * (CDbl(txtTingkatBunga.Text) / 1200)) / (1 - (1 + (CDbl(txtTingkatBunga.Text) / 1200)) ^ (-1 * CDbl(txtTenor.Text)))) - 1) * (12 / CDbl(txtTenor.Text))) * 100
        tempMultiplierInterestP = CDbl(tempFlatInterestP) * (CDbl(txtTenor.Text) / 12)
        txtBungaPengali.Text = Format(tempMultiplierInterestP, "#,##0.00")
    End Sub

    Private Sub ClearForm()
        txtKolektor.Clear()
        txtAplikasi.Clear()
        txtTglAplikasi.Clear()
        txtPOS.Clear()
        txtCA.Clear()
        txtSY.Clear()
        txtSM.Clear()
        txtPemNo.Clear()
        txtPemNama.Clear()
        txtGender.Clear()
        txtPemTl.Clear()
        txtPemLahir.Clear()
        txtPemKtp.Clear()
        txtPemHp.Clear()
        txtPemTelp1.Clear()
        txtPemTelp2.Clear()
        txtPemIbu.Clear()
        txtPemPekerjaan.Clear()
        txtPerusahaanNama.Clear()
        txtPerusahaanJabatan.Clear()
        txtPerusahaanMasa.Clear()
        txtUangPemohon.Clear()
        txtUangPasangan.Clear()
        txtUangLain.Clear()
        txtUangKeluar.Clear()
        txtKomentar.Clear()
        txtAlamatKTP.Clear()
        txtAlamatTagih.Clear()
        txtAlamatKantor.Clear()
        txtTeleponKantor.Clear()
        txtAlamatDarurat.Clear()
        txtDaruratNama.Clear()
        txtDaruratHubungan.Clear()
        txtTeleponDarurat.Clear()
      
        txtPinjaman.Clear()
        txtTenor.Clear()
       
        txtBungaPengali.Clear()
        'Dim tempBungaFlat As Double = ((((CDbl(txtTenor.Text) * (CDbl(txtTingkatBunga.Text) / 1200)) / (1 - (1 + (CDbl(txtTingkatBunga.Text) / 1200)) ^ (-1 * CDbl(txtTenor.Text)))) - 1) * (12 / CDbl(txtTenor.Text))) * 100
        txtBungaFlat.Clear()
        txtPokok.Clear()
        txtBunga.Clear()
        txtAngsuran.Clear()

        txtTotalHutang.Clear()
       
        txtTglBpkb.Clear()
        txtTglAngsuran.Clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TabKontrakMesin.txtFlag.Text = "4"
        TabKontrakMesin.Show()
    End Sub

    Private Sub txtKontrak_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKontrak.TextChanged
        If txtKontrak.Text.Length = txtKontrak.MaxLength Then
            KontrakLoad()
            FillGrid()
        Else
            ClearForm()
        End If
    End Sub
    Private Sub FillGrid()

        Dim tanggal As RepositoryItemDateEdit = New RepositoryItemDateEdit() With {.EditMask = "dd/MM/yyyy"}
        tanggal.Mask.UseMaskAsDisplayFormat = True
        Dim uang As RepositoryItemSpinEdit = New RepositoryItemSpinEdit
        Dim uang2 As RepositoryItemSpinEdit = New RepositoryItemSpinEdit

        uang2.MaxLength = 9
        uang2.IsFloatValue = False
        uang2.EditMask = "###,###,##0"
        uang2.Mask.UseMaskAsDisplayFormat = True

        uang.NullText = 0
        uang.MaxLength = 9
        uang.IsFloatValue = False
        uang.EditMask = "###,###,##0"
        uang.Mask.UseMaskAsDisplayFormat = True
        uang.MinValue = 0
        uang.NullText = 0

        Dim tbl_kontrak As New DataTable
        Using ds_kontrak As New DataSet()
            StrSQL = ""
            StrSQL = "SELECT [Index]+1 as [Angs Ke]"
            StrSQL &= ",JatuhTempo as [Due Date]"
            StrSQL &= ",Angsuran"
            StrSQL &= ",Sp as [Amount Principal]"
            StrSQL &= ",Si as [Interest Principal]"
            StrSQL &= ",Op as [Amount Principal (sisa)]"
            StrSQL &= ",Oi as [Interest Principal (sisa)]"
            StrSQL &= ",isnull(CONVERT(nvarchar,tglbayar),'') as [Tanggal Bayar]"
            StrSQL &= ",Angsuran+(CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0 then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end) as [AMBC]"
            StrSQL &= ",ISNULL(OVD,DATEDIFF(DAY,JatuhTempo,GETDATE())) as [OVD]"
            'mark tanggal 11/6/2014 reason ubah tampilan denda berdasar ovd
            'StrSQL &= ",DATEDIFF(DAY,JatuhTempo,GETDATE()) as [OVD]"
            'StrSQL &= ",CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0 then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end as [Denda]"
            'end mark
            StrSQL &= ",CASE WHEN OVD IS NULL THEN CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0"
            StrSQL &= " then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end"
            StrSQL &= " ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) END as [Denda]"
            StrSQL &= ",isnull(CONVERT(nvarchar,TotalBayar),'0') as [Total Bayar]"
            StrSQL &= ",isnull(CONVERT(nvarchar,Outstanding),'0') as [Outstanding]"
            StrSQL &= ",isnull(CONVERT(nvarchar,OutstandingReceive),'0') as [Outstanding Receive]"
            StrSQL &= ",isnull(CONVERT(nvarchar,OutstandingTotal),'0') as [Outstanding Total]"
            StrSQL &= ",isnull(CONVERT(nvarchar,NoKwitansi),'unpaid') as [Nomor Kwitansi]"
            StrSQL &= " From ContractDetail "
            StrSQL &= String.Format("WHERE ContractID='{0}' ", txtKontrak.Text)
            da = New SqlDataAdapter(StrSQL, conn)
            da.Fill(tbl_kontrak)
            ds_kontrak.Tables.Add(tbl_kontrak)
        End Using
        GridControl1.DataSource = Nothing
        GridControl1.DataSource = tbl_kontrak

        'set ga bisa diedit
        For i As Integer = 0 To 15
            GridView1.Columns(i).OptionsColumn.AllowEdit = False
        Next

        'set datetime
        GridView1.Columns(1).ColumnEdit = tanggal
        GridView1.Columns(7).ColumnEdit = tanggal
        GridView1.Columns(2).ColumnEdit = uang
        GridView1.Columns(3).ColumnEdit = uang
        GridView1.Columns(4).ColumnEdit = uang
        GridView1.Columns(5).ColumnEdit = uang
        GridView1.Columns(6).ColumnEdit = uang
        GridView1.Columns(8).ColumnEdit = uang
        GridView1.Columns(10).ColumnEdit = uang
        GridView1.Columns(11).ColumnEdit = uang
        GridView1.Columns("Outstanding").ColumnEdit = uang2
        GridView1.Columns("Outstanding Receive").ColumnEdit = uang2
        GridView1.Columns("Outstanding Total").ColumnEdit = uang2

        'add total
        GridView1.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(2).SummaryItem.DisplayFormat = "{0:###,###}"
        GridView1.Columns("Denda").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("Denda").SummaryItem.DisplayFormat = "{0:###,###}"
        GridView1.Columns("Outstanding").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("Outstanding").SummaryItem.DisplayFormat = "{0:###,###}"
        GridView1.Columns("Outstanding Receive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("Outstanding Total").SummaryItem.DisplayFormat = "{0:###,###}"
        GridView1.Columns("Amount Principal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("Amount Principal").SummaryItem.DisplayFormat = "{0:###,###}"
        GridView1.Columns("Interest Principal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("Interest Principal").SummaryItem.DisplayFormat = "{0:###,###}"

        'set lebar grid
        GridView1.Columns(0).Width = 52
        GridView1.Columns(1).Width = 65
        GridView1.Columns(2).Width = 70
        GridView1.Columns(3).Width = 89
        GridView1.Columns(4).Width = 88
        GridView1.Columns(5).Width = 115
        GridView1.Columns(6).Width = 117
        GridView1.Columns(7).Width = 79
        GridView1.Columns(8).Width = 62
        GridView1.Columns(9).Width = 38
        GridView1.Columns(10).Width = 65
        GridView1.Columns(11).Width = 77
        GridView1.Columns(12).Width = 70
        GridView1.Columns(13).Width = 110
        GridView1.Columns(14).Width = 95
        GridView1.Columns(15).Width = 87


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            GridView1.OptionsPrint.AutoWidth = False
            GridView1.BestFitColumns()
            GridControl1.ExportToXls(SaveFileDialog1.FileName)
        End If
    End Sub
End Class