Imports DevExpress.XtraReports.UI
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository

Public Class ReportKontrak

    Private Sub ReportKontrak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadioButton1.Checked = True
        dtDari.Text = Now
        dtDari.Format = DateTimePickerFormat.Custom
        dtDari.CustomFormat = "dd/MM/yyyy"
        dtSampai.Text = Now
        dtSampai.Format = DateTimePickerFormat.Custom
        dtSampai.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            dtDari.Enabled = False
            dtSampai.Enabled = False
        Else
            dtDari.Enabled = True
            dtSampai.Enabled = True
        End If
    End Sub

    Private Function Validation() As Boolean
        Validation = True
        If dtDari.Value > dtSampai.Value Then
            MessageBox.Show("Tanggal Salah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton2.Checked Then
            If Validation() = False Then
                Exit Sub
            End If
        End If
        FillGrid()

    End Sub

    Private Sub FillGrid()

        StrSQL = ""
        StrSQL = " select ROW_NUMBER()over(ORDER BY Application.Applicationid ASC)as [No],"
        StrSQL &= "Application.ContractID as [No Kontrak],Application.PosID as [POS],"
        StrSQL &= "application.ApplicationDate as [Tanggal Order],Application.ApplicationTypeID as [Objek],"
        StrSQL &= "Application.ApplicationID as [No Aplikasi],member.MemberName as [Nama],application.MemberID as [MemberID],"
        StrSQL &= "member.Address as [Alamat KTP],member.PostalID as [Kodepos KTP] ,"
        StrSQL &= "member.BillingAddress as [Alamat Survey],member.BillingPostalID as [Kodepos Survey],"
        StrSQL &= "member.Phone1 as [Handphone],member.Phone2 as [Telp 2],member.Phone3 as [Telp 3],"
        StrSQL &= "application.MotorType as [Tipe],"
        StrSQL &= "application.MotorPrice as [Pinjaman],Application.Installment as [Angsuran],"
        StrSQL &= "Application.Tenor as [Top],Application.FrameCode as [No Rangka],"
        StrSQL &= "application.EngineCode as [No Mesin],application.PlatNo as [No Polisi],"
        StrSQL &= "application.MotorColor as [Warna],member.BpkbName as [Nama Bpkb],"
        StrSQL &= "Application.DealerSubs as [Subsidi Dealer],application.InsuranceRate as [%Premi Asuransi],"
        StrSQL &= "application.InsuranceAdmin as [Admin Asuransi],application.AdminPremi as [Premi],"
        StrSQL &= "application.LoanAdmin as [Admin],Application.SurveyorID as [Surveyor],"
        StrSQL &= "application.SalesManID as [Sales],application.SurveyComment as [History],"
        StrSQL &= "application.MarketingCost as [Biaya Marketing],application.DownPayment as [DP Net],"
        StrSQL &= "Application.ApprovalState as [Status Order],"
        StrSQL &= "'Status Kontrak'=CASE WHEN Application.ContractID = '' THEN 'N' ELSE 'Y' END,"
        StrSQL &= "'Status Asuransi'=CASE WHEN Application.AdminPremi = 0 THEN 'N' ELSE 'Y' END,"
        StrSQL &= "contract.BpkbState as [Status Bpkb],contract.FirstInstallment as [JT Angsuran 1],"
        StrSQL &= "SUBSTRING('JAN FEB MAR APR MEI JUN JUL AGU SEP OKT NOV DES ',"
        StrSQL &= "(convert(int,month(contract.BastDate)) * 4) - 3, 3) + '-' + CONVERT(nvarchar,year(contract.bastdate)) as [Bulan Booking]"
        StrSQL &= "from Application left join Contract ON Application.ContractID = contract.ContractID "
        StrSQL &= "Inner join Member on Application.MemberID = member.MemberID"
        If RadioButton1.Checked = False Then
            StrSQL &= " WHERE Contract.ContractDate >='" & Format(dtDari.Value, "yyyy-MM-dd") & "' AND ContractDate <='" & Format(dtSampai.Value, "yyyy-MM-dd") & "' "
        End If
        RunSQL(StrSQL, 1)

        If dt.Rows.Count > 0 Then
            deleteTempTable()
            SaveTempTable(dt)

            StrSQL = ""
            StrSQL = ("SELECT*From TempKontrak")

            Dim tbl_kontrak As New DataTable
            Using ds_kontrak As New DataSet()
                da = New SqlDataAdapter(StrSQL, conn)
                da.Fill(tbl_kontrak)
                ds_kontrak.Tables.Add(tbl_kontrak)
            End Using
            GridView1.BestFitColumns()
            GridControl1.DataSource = Nothing
            GridView1.BestFitColumns()
            GridControl1.DataSource = tbl_kontrak
            GridView1.BestFitColumns()
            settingGrid()
        End If




        'Dim tbl_kontrak As New DataTable
        'Using ds_kontrak As New DataSet()
        '    da = New SqlDataAdapter(StrSQL, conn)
        '    da.Fill(tbl_kontrak)
        '    ds_kontrak.Tables.Add(tbl_kontrak)
        'End Using
        'GridView1.BestFitColumns()
        'GridControl1.DataSource = Nothing
        'GridView1.BestFitColumns()
        'GridControl1.DataSource = tbl_kontrak
        'GridView1.BestFitColumns()
    End Sub

    Private Sub SaveTempTable(ByVal datatable As DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1

            Dim cabang As String = getFieldValue("SELECT ReferenceName From _Reference WHERE ReferenceID ='" & dt.Rows(i)("POS") & "'")
            Dim objek As String = CStr(dt.Rows(i)("Objek"))
            Select Case objek
                Case "1"
                    objek = "Dana Tunai"
                Case "2"
                    objek = "Motor Baru"
                Case "3"
                    objek = "Elektronik"
                Case Else
                    objek = "KTA"
            End Select
            Dim RT As String = getFieldValue("SELECT MemberRT From Member WHERE MemberID ='" & dt.Rows(i)("MemberID") & "'")
            Dim RW As String = getFieldValue("SELECT MemberRW From Member WHERE MemberID ='" & dt.Rows(i)("MemberID") & "'")
            Dim Kelurahan As String = getFieldValue("SELECT Village From __addrLocation WHERE AddrLocationID ='" & dt.Rows(i)("Kodepos KTP") & "'")
            Dim Kecamatan As String = getFieldValue("SELECT SubDistrict From __addrLocation WHERE AddrLocationID ='" & dt.Rows(i)("Kodepos KTP") & "'")
            Dim Kota As String = getFieldValue("SELECT City From __addrLocation WHERE AddrLocationID ='" & dt.Rows(i)("Kodepos KTP") & "'")
            Dim alamat As String = dt.Rows(i)("Alamat KTP") & " RT" & RT & " RW" & RW & " Kelurahan " & Kelurahan & " Kecamatan " & Kecamatan & " " & Kota
            Dim RTSurvey As String = getFieldValue("SELECT BillingRT From Member WHERE MemberID ='" & dt.Rows(i)("MemberID") & "'")
            Dim RWSurvey As String = getFieldValue("SELECT BillingRW From Member WHERE MemberID ='" & dt.Rows(i)("MemberID") & "'")
            Dim KelurahanSurvey As String = getFieldValue("SELECT Village From __addrLocation WHERE AddrLocationID ='" & dt.Rows(i)("Kodepos Survey") & "'")
            Dim KecamatanSurvey As String = getFieldValue("SELECT SubDistrict From __addrLocation WHERE AddrLocationID ='" & dt.Rows(i)("Kodepos Survey") & "'")
            Dim KotaSurvey As String = getFieldValue("SELECT City From __addrLocation WHERE AddrLocationID ='" & dt.Rows(i)("Kodepos Survey") & "'")
            Dim alamatSurvey As String = dt.Rows(i)("Alamat Survey") & " RT " & RTSurvey & " RW " & RWSurvey & " Kelurahan " & KelurahanSurvey & " Kecamatan " & KecamatanSurvey & " " & KotaSurvey
            Dim tipe As String
            Dim pinjaman As Integer = CInt(dt.Rows(i)("Pinjaman"))
            Dim premi As Integer = CInt(dt.Rows(i)("Premi"))
            Dim admin As Integer = CInt(dt.Rows(i)("Admin"))
            Dim modal As Integer = pinjaman + premi + admin
            Dim surveyor As String = getFieldValue("SELECT EmployeeName From Employee WHERE EmployeeID ='" & dt.Rows(i)("Surveyor") & "'")
            Dim sales As String = getFieldValue("SELECT EmployeeName From Employee WHERE EmployeeID ='" & dt.Rows(i)("Sales") & "'")
            If objek = "KTA" Then
                tipe = objek
            Else
                tipe = dt.Rows(i)("Tipe")
            End If

            Dim statusORder As String = dt.Rows(i)("Status Order")
            Dim stBpkb As String
            If IsDBNull(dt.Rows(i)("Status Bpkb")) = True Then
                stBpkb = ""
            Else
                stBpkb = dt.Rows(i)("Status Bpkb")
            End If
            Dim statusBpkb As String
            If stBpkb = "" Then
                statusBpkb = ""
            Else
                statusBpkb = getFieldValue("SELECT ReferenceName From _Reference WHERE ReferenceID ='" & CStr(dt.Rows(i)("Status Bpkb")) & "'")
            End If
            Dim jt As String
            If IsDBNull(dt.Rows(i)("JT Angsuran 1")) = True Then
                jt = ""
            Else
                jt = dt.Rows(i)("JT Angsuran 1")
            End If
            Dim bulanBooking As String
            If IsDBNull(dt.Rows(i)("Bulan Booking")) = True Then
                bulanBooking = ""
            Else
                bulanBooking = dt.Rows(i)("Bulan Booking")
            End If


            StrSQL = ""
            StrSQL = "Sp_TempKontrak_SAV "
            StrSQL &= dt.Rows(i)("No") & ","
            StrSQL &= "'" & cabang & "',"
            StrSQL &= "'" & dt.Rows(i)("Tanggal Order") & "',"
            StrSQL &= "'" & objek & "',"
            StrSQL &= "'" & dt.Rows(i)("No Aplikasi") & "',"
            StrSQL &= "'" & dt.Rows(i)("No Kontrak") & "',"
            StrSQL &= "'" & dt.Rows(i)("Nama") & "',"
            StrSQL &= "'" & alamat & "',"
            StrSQL &= "'" & alamatSurvey & "',"
            StrSQL &= "'" & dt.Rows(i)("Handphone") & "',"
            StrSQL &= "'" & dt.Rows(i)("Telp 2") & "',"
            StrSQL &= "'" & dt.Rows(i)("Telp 3") & "',"
            StrSQL &= "'" & tipe & "',"
            StrSQL &= dt.Rows(i)("Pinjaman") & "," 'ini untuk OTR ,nanti harus diubah klo udah rapi modul motorbaru
            StrSQL &= dt.Rows(i)("Pinjaman") & ","
            StrSQL &= dt.Rows(i)("Angsuran") & ","
            StrSQL &= dt.Rows(i)("Top") & ","
            StrSQL &= "'" & dt.Rows(i)("No Rangka") & "',"
            StrSQL &= "'" & dt.Rows(i)("No Mesin") & "',"
            StrSQL &= "'" & dt.Rows(i)("No Polisi") & "',"
            StrSQL &= "'" & dt.Rows(i)("Warna") & "',"
            StrSQL &= "'" & dt.Rows(i)("Nama Bpkb") & "',"
            StrSQL &= dt.Rows(i)("Subsidi Dealer") & ","
            StrSQL &= 0 & "," ' ini pelepasan unit nanti harus diubah
            StrSQL &= dt.Rows(i)("%Premi Asuransi") & ","
            StrSQL &= dt.Rows(i)("Admin Asuransi") & ","
            StrSQL &= dt.Rows(i)("Premi") & ","
            StrSQL &= dt.Rows(i)("Admin") & ","
            StrSQL &= modal & ","
            StrSQL &= "'" & surveyor & "',"
            StrSQL &= "'" & sales & "',"
            StrSQL &= "'" & dt.Rows(i)("History") & "',"
            StrSQL &= dt.Rows(i)("Biaya Marketing") & ","
            StrSQL &= dt.Rows(i)("DP Net") & ","
            StrSQL &= "ACC," 'ini harus diubah [status order]
            StrSQL &= "'" & dt.Rows(i)("Status Kontrak") & "'," '[status kontrak]
            StrSQL &= "'" & dt.Rows(i)("Status Asuransi") & "'," 'flag asuransi'
            StrSQL &= "''," 'status kirim asuransi
            StrSQL &= "'" & statusBpkb & "',"
            StrSQL &= "'" & jt & "',"
            StrSQL &= "'" & bulanBooking & "',"
            StrSQL &= "'','',''" 'ini nanti diubah klo polis dah jadi

            RunSQL(StrSQL, 0)

        Next
    End Sub

    Private Sub deleteTempTable()
        StrSQL = ""
        StrSQL = "Delete From TempKontrak"
        RunSQL(StrSQL, 0)
    End Sub

    Private Sub settingGrid()
        Dim tanggal As RepositoryItemDateEdit = New RepositoryItemDateEdit() With {.EditMask = "dd/MM/yyyy"}
        tanggal.Mask.UseMaskAsDisplayFormat = True
        Dim uang As RepositoryItemSpinEdit = New RepositoryItemSpinEdit
        uang.NullText = 0
        uang.MaxLength = 9
        uang.IsFloatValue = False
        uang.EditMask = "###,###,##0"
        uang.Mask.UseMaskAsDisplayFormat = True
        uang.MinValue = 0
        uang.NullText = 0

        For i As Integer = 0 To 43
            GridView1.Columns(i).OptionsColumn.AllowEdit = False
        Next
        GridView1.Columns("TglOrder").ColumnEdit = tanggal
        GridView1.Columns("JT").ColumnEdit = tanggal
        GridView1.Columns("TglPolis").ColumnEdit = tanggal
        GridView1.Columns("SubsidiDealer").ColumnEdit = uang
        GridView1.Columns("PelunasanUnit").ColumnEdit = uang
        GridView1.Columns("AdminAsuransi").ColumnEdit = uang
        GridView1.Columns("Premi").ColumnEdit = uang
        GridView1.Columns("Admin").ColumnEdit = uang
        GridView1.Columns("Modal").ColumnEdit = uang
        GridView1.Columns("BiayaMarketing").ColumnEdit = uang
        GridView1.Columns("DpNet").ColumnEdit = uang
        GridView1.Columns("OTR").ColumnEdit = uang
        GridView1.Columns("DpPinjaman").ColumnEdit = uang
        GridView1.Columns("Angsuran").ColumnEdit = uang
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            GridView1.OptionsPrint.AutoWidth = False
            GridView1.BestFitColumns()
            GridControl1.ExportToXls(SaveFileDialog1.FileName)
        End If
    End Sub
End Class