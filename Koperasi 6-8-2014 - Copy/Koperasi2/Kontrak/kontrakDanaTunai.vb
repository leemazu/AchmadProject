Imports DevExpress.XtraEditors.Repository
Imports System.Data.SqlClient

Public Class kontrakDanaTunai
    Dim TrueContractID As String
    Dim FlagCollateral As Boolean = False
    Dim FlagBpkb As Boolean = False
    Dim OldBpkb As String = ""
    Private Sub IsiSeluruhForm()
        Try
            If txtKontrakID.Text.Length > 7 Then
                StrSQL = ""
                StrSQL = "SELECT ContractID FROM Contract WHERE ContractID = '" & antisqli(txtKontrakID.Text) & "' "
                RunSQL(StrSQL, 1)
                If dt.Rows.Count = 1 Then
                    TrueContractID = antisqli(txtKontrakID.Text)
                    FillForm(txtKontrakID.Text)
                    IsiCollateral()
                    FillCollateral(txtAplikasiID.Text)
                    FillGrid()
                    DisableComponent()
                    btnUpdate.Enabled = True
                    btnReset.Enabled = True
                Else
                    ClearForm()
                    ClearComponent()
                    DisableComponent()
                End If
            Else
                ClearForm()
                ClearComponent()
                DisableComponent()
            End If
        Catch ex As Exception
            SaveErrorLog(ex.Message, "Form Kontrak")
        End Try
    End Sub
    Private Sub IsiCollateral()
        If txtAplikasiTipe.Text <> "" Then
            Select Case txtAplikasiTipe.Text
                Case "Dana Tunai"
                    TabControl1.TabPages.Insert(2, TpDanaTunai)
                    TabControl1.TabPages.Remove(TpMotorBaru)
                    TabControl1.TabPages.Remove(TpElektronik)
                    TabControl1.TabPages.Remove(TpKTA)
                    lblDokumen.Visible = False
                    txtAplikasiDokumen.Visible = False
                Case "Motor Baru"
                    TabControl1.TabPages.Insert(2, TpMotorBaru)
                    TabControl1.TabPages.Remove(TpDanaTunai)
                    TabControl1.TabPages.Remove(TpElektronik)
                    TabControl1.TabPages.Remove(TpKTA)
                    lblDokumen.Visible = True
                    txtAplikasiDokumen.Visible = True
                Case "KTA"
                    TabControl1.TabPages.Insert(2, TpKTA)
                    TabControl1.TabPages.Remove(TpDanaTunai)
                    TabControl1.TabPages.Remove(TpElektronik)
                    TabControl1.TabPages.Remove(TpMotorBaru)
                    lblDokumen.Visible = False
                    txtAplikasiDokumen.Visible = False
                Case "Elektronik"
                    TabControl1.TabPages.Insert(2, TpElektronik)
                    TabControl1.TabPages.Remove(TpDanaTunai)
                    TabControl1.TabPages.Remove(TpMotorBaru)
                    TabControl1.TabPages.Remove(TpKTA)
                    lblDokumen.Visible = True
                    txtAplikasiDokumen.Visible = True
            End Select

        End If

    End Sub
#Region "Form Component Event"
#Region "Button"
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearForm()
        DisableComponent()
        IsiSeluruhForm()
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        EnableComponent()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        CekStatusCollateral(antisqli(txtKontrakID.Text))
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim result As Integer = MessageBox.Show("Anda yaking akan Mengubah detail Kontrak ini ?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = vbYes Then
                Try
                    UpdateApplication()
                    UpdateMember()
                    UpdateContract()

                    If FlagBpkb = True Then
                        UpdateBpkb(OldBpkb)
                    End If

                    If FlagCollateral = True Then
                        If UpdateCollateral() Then
                            UbahAR()
                        End If
                    End If

                    MessageBox.Show("Data Berhasil Disimpan")
                    txtKontrakID.Clear()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Exit Sub
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplikasiCari.Click
        TabKontrakMesin.txtFlag.Text = "1"
        TabKontrakMesin.StartPosition = FormStartPosition.Manual
        TabKontrakMesin.Location = New Point(0, 0)
        TabKontrakMesin.Show()
        TabKontrakMesin.BringToFront()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            GridView1.OptionsPrint.AutoWidth = False
            GridView1.BestFitColumns()
            GridControl1.ExportToXls(SaveFileDialog1.FileName)
        End If
    End Sub

#End Region
#Region "Text Box"
    Private Sub txtKontrakID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKontrakID.TextChanged
        IsiSeluruhForm()
    End Sub

    Private Sub txtAplikasiTipe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAplikasiTipe.TextChanged
       
    End Sub

    Private Sub KeyPressDecimal(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDTPinjaman.KeyPress, txtDTTingkatBunga.KeyPress, txtDTTenor.KeyPress, txtDTPremiAsuransi.KeyPress, txtDTPremiAdmin.KeyPress, txtDTAdminKredit.KeyPress, txtDTAdmin.KeyPress, txtKTAPinjaman.KeyPress, txtKTATenor.KeyPress, txtKTATingkatBunga.KeyPress, txtDTTahun.KeyPress, txtDTBpkbRW.KeyPress, txtDTBpkbRT.KeyPress, txtMBPinjaman.KeyPress, txtMBTingkatBunga.KeyPress, txtMBTenor.KeyPress, txtMBTahun.KeyPress, txtMBSubsidiDealer.KeyPress, txtMBPremiAsuransi.KeyPress, txtMBDownPayment.KeyPress, txtMBBpkbRW.KeyPress, txtMBBpkbRT.KeyPress, txtMBAdminPremi.KeyPress, txtMBAdminKredit.KeyPress, txtMBAdmin.KeyPress, txtKTATotalHutang.KeyPress, txtKTAPokok.KeyPress, txtKTABunga.KeyPress, txtKTAAngsuran.KeyPress, txtELTingkatBunga.KeyPress, txtELTenor.KeyPress, txtELHarga.KeyPress
        Dim txtBox = DirectCast(sender, TextBox)
        decimalOnly(sender, e, txtBox.Text)
    End Sub

    Private Sub LostFocusRibuan(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDTPinjaman.Leave, txtDTPremiAdmin.Leave, txtDTAdminMurni.Leave, txtDTAdminKredit.Leave, txtDTAdmin.Leave, txtDTTotalHutang.Leave, txtDTPokok.Leave, txtDTBunga.Leave, txtDTAngsuran.Leave, txtKTAPinjaman.Leave
        Dim txtBox = DirectCast(sender, TextBox)
        txtBox.Text = ribuan(txtBox.Text)
    End Sub

    Private Sub TenorLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDTTenor.Leave
        Dim tnr As New Integer
        Dim txtTenor = CType(sender, TextBox)
        tnr = CInt(txtTenor.Text)
        Dim premiRate As Double
        If tnr >= 1 And tnr <= 12 Then
            premiRate = "2.5"
        ElseIf tnr >= 13 And tnr <= 18 Then
            premiRate = "3.56"
        ElseIf tnr >= 19 And tnr <= 24 Then
            premiRate = "4.63"
        ElseIf tnr >= 25 And tnr <= 30 Then
            premiRate = "5.56"
        ElseIf tnr >= 31 And tnr <= 36 Then
            premiRate = "6.5"
        Else
            premiRate = "0"
        End If

        Select Case txtAplikasiTipe.Text
            Case "Dana Tunai"
                txtDTPremiAsuransi.Text = CDbl(premiRate)

        End Select

    End Sub

#End Region
#Region "Form Event"
    Private Sub kontrakDanaTunai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
        gerakinCombo()
        DisableComponent()
    End Sub

    Private Sub gerakinCombo() 'sampe ketemu fix
        cmbKtpKota.SelectedIndex = 1
        cmbKtpKecamatan.SelectedIndex = 1
        cmbTagihKota.SelectedIndex = 1
        cmbTagihKecamatan.SelectedIndex = 1
        cmbKantorKota.SelectedIndex = 1
        cmbKantorKecamatan.SelectedIndex = 1
        cmbDaruratKota.SelectedIndex = 1
        cmbDaruratKecamatan.SelectedIndex = 1
        cmbBaruKota.SelectedIndex = 1
        cmbBaruKecamatan.SelectedIndex = 1
        cmbDTBpkbKota.SelectedIndex = 1
        cmbMBBpkbKota.SelectedIndex = 1
        'cmbDTBpkbKecamatan.SelectedIndex = 1
    End Sub

    Private Sub ComboKotaSelectedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKantorKota.SelectedIndexChanged, cmbTagihKota.SelectedIndexChanged, cmbDaruratKota.SelectedIndexChanged, cmbBaruKota.SelectedIndexChanged, cmbKtpKota.SelectedIndexChanged, cmbDTBpkbKota.SelectedIndexChanged, cmbMBBpkbKota.SelectedIndexChanged
        Dim tblKec1 As New DataTable
        Dim tblKec2 As New DataTable
        Dim tblKec3 As New DataTable
        Dim tblKec4 As New DataTable
        Dim tblKec5 As New DataTable
        Dim tblKec6 As New DataTable
        Dim tblKec7 As New DataTable
        'tblKec.Rows.Clear()

        Select Case sender.Name

            Case "cmbKtpKota"
                tblKec1.Rows.Clear()
                With cmbKtpKecamatan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbKtpKota.Text + "' ORDER BY [SubDistrict] ASC"
                    FillCombobox(StrSQL, cmbKtpKecamatan, 1, tblKec1)
                End With

            Case "cmbTagihKota"
                tblKec2.Rows.Clear()
                With cmbTagihKecamatan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbTagihKota.Text + "' ORDER BY [SubDistrict] ASC"
                    FillCombobox(StrSQL, cmbTagihKecamatan, 1, tblKec2)
                End With

            Case "cmbKantorKota"
                tblKec3.Rows.Clear()
                With cmbKantorKecamatan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbKantorKota.Text + "' ORDER BY [SubDistrict] ASC"
                    FillCombobox(StrSQL, cmbKantorKecamatan, 1, tblKec3)
                End With

            Case "cmbDaruratKota"
                tblKec4.Rows.Clear()
                With cmbDaruratKecamatan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbDaruratKota.Text + "' ORDER BY [SubDistrict] ASC"
                    FillCombobox(StrSQL, cmbDaruratKecamatan, 1, tblKec4)
                End With

            Case "cmbBaruKota"
                tblKec5.Rows.Clear()
                With cmbBaruKecamatan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbBaruKota.Text + "' ORDER BY [SubDistrict] ASC"
                    FillCombobox(StrSQL, cmbBaruKecamatan, 1, tblKec5)
                End With

            Case "cmbDTBpkbKota"
                tblKec6.Rows.Clear()
                With cmbDTBpkbKecamatan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbDTBpkbKota.Text + "' ORDER BY [SubDistrict] ASC"
                    FillCombobox(StrSQL, cmbDTBpkbKecamatan, 1, tblKec6)
                End With

            Case "cmbMBBpkbKota"
                tblKec7.Rows.Clear()
                With cmbMBBpkbKecamatan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbMBBpkbKota.Text + "' ORDER BY [SubDistrict] ASC"
                    FillCombobox(StrSQL, cmbMBBpkbKecamatan, 1, tblKec7)
                End With

        End Select
    End Sub

    Private Sub ComboKecamatanSelectedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbKantorKecamatan.SelectedIndexChanged, cmbTagihKecamatan.SelectedIndexChanged, cmbKtpKecamatan.SelectedIndexChanged, cmbDaruratKecamatan.SelectedIndexChanged, cmbBaruKecamatan.SelectedIndexChanged, cmbDTBpkbKecamatan.SelectedIndexChanged, cmbMBBpkbKecamatan.SelectedIndexChanged
        Dim tblKel1 As New DataTable
        Dim tblKel2 As New DataTable
        Dim tblKel3 As New DataTable
        Dim tblKel4 As New DataTable
        Dim tblKel5 As New DataTable
        Dim tblKel6 As New DataTable
        Dim tblKel7 As New DataTable
        'tblKec.Rows.Clear()

        Select Case sender.Name

            Case "cmbKtpKecamatan"
                tblKel1.Rows.Clear()
                With cmbKtpKelurahan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKtpKecamatan.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbKtpKelurahan, 2, tblKel1)
                End With

            Case "cmbTagihKecamatan"
                tblKel2.Rows.Clear()
                With cmbTagihKelurahan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbTagihKecamatan.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbTagihKelurahan, 2, tblKel2)
                End With

            Case "cmbKantorKecamatan"
                tblKel3.Rows.Clear()
                With cmbKantorKelurahan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKantorKecamatan.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbKantorKelurahan, 2, tblKel3)
                End With

            Case "cmbDaruratKecamatan"
                tblKel4.Rows.Clear()
                With cmbDaruratKelurahan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbDaruratKecamatan.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbDaruratKelurahan, 2, tblKel4)
                End With

            Case "cmbBaruKecamatan"
                tblKel5.Rows.Clear()
                With cmbBaruKelurahan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbBaruKecamatan.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbBaruKelurahan, 2, tblKel5)
                End With

            Case "cmbDTBpkbKecamatan"
                tblKel6.Rows.Clear()
                With cmbDTBpkbKelurahan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbDTBpkbKecamatan.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbDTBpkbKelurahan, 2, tblKel6)
                End With

            Case "cmbMBBpkbKecamatan"
                tblKel7.Rows.Clear()
                With cmbMBBpkbKelurahan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbMBBpkbKecamatan.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbMBBpkbKelurahan, 2, tblKel7)
                End With
        End Select
    End Sub

#End Region
#End Region
#Region "Grid"
    Private Sub FillGrid()
        Dim tanggal As RepositoryItemDateEdit = New RepositoryItemDateEdit() With {.EditMask = "dd/MM/yyyy"}
        tanggal.Mask.UseMaskAsDisplayFormat = True
        Dim uang As RepositoryItemSpinEdit = New RepositoryItemSpinEdit
        Dim uang2 As RepositoryItemSpinEdit = New RepositoryItemSpinEdit
        Dim tableKwitansi As New DataTable

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
            StrSQL &= ",Angsuran+ISNULL(Denda,CASE WHEN Angsuran*0.005*ISNULL(OVD,DATEDIFF(DAY,JatuhTempo,GETDATE())) < 0 THEN 0 ELSE Angsuran*0.005*ISNULL(OVD,DATEDIFF(DAY,JatuhTempo,GETDATE())) END) as AMBC"
            'StrSQL &= ",Angsuran+ISNULL(Denda,CASE WHEN Angsuran*0.05*ISNULL(OVD,DATEDIFF(DAY,JatuhTempo,GETDATE())) < 0 THEN 0 END)AS AMBC"
            ''StrSQL &= ",Angsuran+(CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0 then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end) as [AMBC]"
            StrSQL &= ",ISNULL(OVD,DATEDIFF(DAY,JatuhTempo,GETDATE())) as [OVD]"
            'mark tanggal 11/6/2014 reason ubah tampilan denda berdasar ovd
            'StrSQL &= ",DATEDIFF(DAY,JatuhTempo,GETDATE()) as [OVD]"
            'StrSQL &= ",CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0 then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end as [Denda]"

            'StrSQL &= ",CASE WHEN OVD IS NULL THEN CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0"
            'StrSQL &= " THEN 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) END"
            'StrSQL &= " WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0 THEN 0 "
            'StrSQL &= " ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) END as [Denda]"
            'end mark

            StrSQL &= ",CASE WHEN denda IS NULL "
            StrSQL &= "THEN CASE WHEN OVD IS NULL "
            StrSQL &= "THEN CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0 THEN 0 "
            StrSQL &= "ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) END "
            StrSQL &= "ELSE Angsuran*0.005*OVD END "
            StrSQL &= "ELSE Denda END as [Denda] "
            StrSQL &= ",isnull(CONVERT(nvarchar,TotalBayar),'0') as [Total Bayar]"
            StrSQL &= ",isnull(CONVERT(nvarchar,Outstanding),'0') as [Outstanding]"
            StrSQL &= ",isnull(CONVERT(nvarchar,OutstandingReceive),'0') as [Outstanding Receive]"
            StrSQL &= ",isnull(CONVERT(nvarchar,OutstandingTotal),'0') as [Outstanding Total]"
            StrSQL &= ",isnull(CONVERT(nvarchar,NoKwitansi),'unpaid') as [Nomor Kwitansi]"
            StrSQL &= " From ContractDetail "
            StrSQL &= String.Format("WHERE ContractID='{0}' ", txtKontrakID.Text)
            StrSQL &= " ORDER BY [Index] ASC "
            da = New SqlDataAdapter(StrSQL, conn)
            da.Fill(tbl_kontrak)
            ds_kontrak.Tables.Add(tbl_kontrak)
        End Using
        GridControl1.DataSource = Nothing
        GridControl1.DataSource = tbl_kontrak



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
        GridView1.Columns(12).OptionsColumn.AllowEdit = False
        GridView1.Columns("OVD").OptionsColumn.AllowEdit = False
        GridView1.Columns("Denda").OptionsColumn.AllowEdit = False
        GridView1.Columns("AMBC").OptionsColumn.AllowEdit = False
        GridView1.Columns("Outstanding Receive").OptionsColumn.AllowEdit = False
        GridView1.Columns("Outstanding Total").OptionsColumn.AllowEdit = False
        'GridView1.Columns("Nomor Kwitansi").ColumnEdit = ListKwitansi

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


            For i As Integer = 0 To 15
                GridView1.Columns(i).OptionsColumn.AllowEdit = False
            Next


    End Sub


#End Region
#Region "Form Utility"
    Private Sub ClearForm()
        TrueContractID = ""
        btnSave.Enabled = False
        btnUpdate.Enabled = False
        btnReset.Enabled = False
        Try
            ComboBoxFillData()
        Catch ex As Exception

        End Try
        GridControl1.DataSource = Nothing
        setTanggal(dtpAplikasiTanggal)
        setTanggal(dtpAnggotaTglLahir)
        setTanggal(dtpDTAngsuran1)
        setTanggal(dtpDTBast)
        setTanggal(dtpDTKontrak)
        setTanggal(dtpKTAAngsuran)
        setTanggal(dtpKTABast)
        setTanggal(dtpKTAKontrak)
        setTanggal(dtpDTBpkbKeluar)
        setTanggal(dtpDTBpkbMasuk)
        setTanggal(dtpELAngsuran)
        setTanggal(dtpELBast)
        setTanggal(dtpELKontrak)
        setTanggal(dtpMBAngsuran)
        setTanggal(dtpMBBast)
        setTanggal(dtpMBBpkbKeluar)
        setTanggal(dtpMbBpkbMasuk)
        setTanggal(dtpMBKontrak)
        TabControl1.TabPages.Remove(TpDanaTunai)
        TabControl1.TabPages.Remove(TpMotorBaru)
        TabControl1.TabPages.Remove(TpElektronik)
        TabControl1.TabPages.Remove(TpKTA)
        txtKontrakStatus.Enabled = False

        'DisableComponent()
        'ClearComponent()
    End Sub
    Private Sub ComboBoxFillData()
        Dim dtKolektor As New DataTable
        Dim dtPos As New DataTable
        Dim dtCA As New DataTable
        Dim dtSY As New DataTable
        Dim dtSM As New DataTable
        Dim dtSex As New DataTable
        Dim dtWorkID As New DataTable
        Dim dtKtpKota As New DataTable
        Dim dtKtpKecamatan As New DataTable
        Dim dtKtpKelurahan As New DataTable
        Dim dtTagihKota As New DataTable
        Dim dtTagihKecamatan As New DataTable
        Dim dtTagihKelurahan As New DataTable
        Dim dtKantorKota As New DataTable
        Dim dtKantorKecamatan As New DataTable
        Dim dtKantorKelurahan As New DataTable
        Dim dtDaruratKota As New DataTable
        Dim dtDaruratKecamatan As New DataTable
        Dim dtDaruratKelurahan As New DataTable
        Dim dtBaruKota As New DataTable
        Dim dtBaruKecamatan As New DataTable
        Dim dtBaruKelurahan As New DataTable
        Dim dtDTStatusBpkb As New DataTable
        Dim dtDTBpkbKota As New DataTable
        Dim dtDTBpkbKecamatan As New DataTable
        Dim dtDTBpkbKelurahan As New DataTable
        Dim dtMBBpkbKota As New DataTable
        Dim dtMbBpkbStatus As New DataTable


        FillCombobox("SpEmployee_CBO 'CL'", cmbKolektor, 2, dtKolektor)
        FillCombobox("Sp_Reference_CBO 'POS'", cmbAplikasiPos, 2, dtPos)
        FillCombobox("SpEmployee_CBO 'CA'", cmbAplikasiCa, 2, dtCA)
        FillCombobox("SpEmployee_CBO 'SY'", cmbAplikasiSy, 2, dtSY)
        FillCombobox("SpEmployee_CBO 'SM'", cmbAplikasiSm, 2, dtSM)
        FillCombobox("Sp_Reference_CBO 'GEN'", cmbAnggotaSex, 2, dtSex)
        FillCombobox("Sp_Reference_CBO 'TWC'", cmbAnggotaPekerjaan, 2, dtWorkID)

        FillCombobox("select*from v_kota ORDer BY city asc", cmbKtpKota, 1, dtKtpKota)
        cmbKtpKota.SelectedItem = 1

        ' cmbKtpKota.SelectedItem = 0

        'FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbKtpKota.Text + "' ORDER BY [SubDistrict] ASC", cmbKtpKecamatan, 1, dtKtpKecamatan)
        'FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKtpKecamatan.Text + "' ORDER BY [Village] ASC", cmbKtpKelurahan, 2, dtKtpKelurahan)

        FillCombobox("select*from v_kota ORDer BY city asc", cmbTagihKota, 1, dtTagihKota)
        ' FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbTagihKota.Text + "' ORDER BY [SubDistrict] ASC", cmbTagihKecamatan, 1, dtTagihKecamatan)
        ' FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbTagihKecamatan.Text + "' ORDER BY [Village] ASC", cmbTagihKelurahan, 2, dtTagihKelurahan)
        cmbTagihKota.SelectedItem = 1
        ' cmbTagihKota.SelectedItem = 0
        FillCombobox("select*from v_kota ORDer BY city asc", cmbKantorKota, 1, dtKantorKota)
        ' FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbKantorKota.Text + "' ORDER BY [SubDistrict] ASC", cmbKantorKecamatan, 1, dtKantorKecamatan)
        ' FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKantorKecamatan.Text + "' ORDER BY [Village] ASC", cmbKantorKelurahan, 2, dtKantorKelurahan)
        cmbKantorKota.SelectedItem = 1
        ' cmbKantorKota.SelectedItem = 0
        FillCombobox("select*from v_kota ORDer BY city asc", cmbDaruratKota, 1, dtDaruratKota)
        ' FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbDaruratKota.Text + "' ORDER BY [SubDistrict] ASC", cmbDaruratKecamatan, 1, dtDaruratKecamatan)
        ' FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbDaruratKecamatan.Text + "' ORDER BY [Village] ASC", cmbDaruratKelurahan, 2, dtDaruratKelurahan)
        cmbDaruratKota.SelectedItem = 1
        ' cmbDaruratKota.SelectedItem = 0
        FillCombobox("select*from v_kota ORDer BY city asc", cmbBaruKota, 1, dtBaruKota)
        ' FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbBaruKota.Text + "' ORDER BY [SubDistrict] ASC", cmbBaruKecamatan, 1, dtBaruKecamatan)
        ' FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbBaruKecamatan.Text + "' ORDER BY [Village] ASC", cmbBaruKelurahan, 2, dtBaruKelurahan)
        cmbBaruKota.SelectedItem = 1
        FillCombobox("select*from v_kota ORDer BY city asc", cmbDTBpkbKota, 1, dtDTBpkbKota)
        cmbDTBpkbKota.SelectedItem = 1
        FillCombobox("select*from v_kota ORDer BY city asc", cmbMBBpkbKota, 1, dtMBBpkbKota)
        cmbMBBpkbKota.SelectedItem = 1
        FillCombobox("SELECT DISTINCT SUBDISTRICT FROM __ADDRLOCATION WHERE CITY='" & cmbDTBpkbKota.Text & "' ", cmbDTBpkbKecamatan, 1, dtDTBpkbKecamatan)

        FillCombobox("SELECT DISTINCT ADDRLOCATIONID,VILLAGE FROM __ADDRLOCATION WHERE VILLAGE ='" & cmbDTBpkbKecamatan.Text & "'", cmbDTBpkbKelurahan, 2, dtDTBpkbKelurahan)
        'cmbBaruKota.SelectedItem = 0
        FillCombobox("Sp_Reference_CBO 'BST'", cmbDTBpkbStatus, 2, dtDTStatusBpkb)
        FillCombobox("Sp_Reference_CBO 'BST'", cmbMBBpkbStatus, 2, dtMbBpkbStatus)
    End Sub
    Private Sub DisableComponent()
        cmbKolektor.Enabled = False
        txtAplikasiTipe.Enabled = False
        txtKontrakStatus.Enabled = False
        txtAplikasiID.Enabled = False
        dtpAplikasiTanggal.Enabled = False
        cmbAplikasiPos.Enabled = False
        cmbAplikasiCa.Enabled = False
        cmbAplikasiSy.Enabled = False
        cmbAplikasiSm.Enabled = False
        txtAnggotaID.Enabled = False
        txtAnggotaNama.Enabled = False
        cmbAnggotaSex.Enabled = False
        txtAnggotaTmptLahir.Enabled = False
        dtpAnggotaTglLahir.Enabled = False
        txtAnggotaKtp.Enabled = False
        txtAnggotaHp.Enabled = False
        txtAnggotaTelp1.Enabled = False
        txtAnggotaTelp2.Enabled = False
        cmbAnggotaPekerjaan.Enabled = False
        txtAnggotaPerusahaanNama.Enabled = False
        txtAnggotaPerusahaanJabatan.Enabled = False
        txtAnggotaPerusahaanMasa.Enabled = False
        txtAnggotaPenghasilan.Enabled = False
        txtAnggotaPenghasilanLain.Enabled = False
        txtAnggotaPenghasilanPasangan.Enabled = False
        txtAnggotaPenghasilanPengeluaran.Enabled = False
        txtAnggotaKomentar.Enabled = False
        txtKtpAlamat.Enabled = False
        cmbKtpKecamatan.Enabled = False
        cmbKtpKelurahan.Enabled = False
        cmbKtpKota.Enabled = False
        txtKtpRT.Enabled = False
        txtKTPRw.Enabled = False
        txtTagihAlamat.Enabled = False
        txtTagihRT.Enabled = False
        txtTagihRW.Enabled = False
        cmbTagihKota.Enabled = False
        cmbTagihKecamatan.Enabled = False
        cmbTagihKelurahan.Enabled = False
        txtKantorAlamat.Enabled = False
        txtKantorRT.Enabled = False
        txtKantorRW.Enabled = False
        txtKantorTelp.Enabled = False
        cmbKantorKota.Enabled = False
        cmbKantorKecamatan.Enabled = False
        cmbKantorKelurahan.Enabled = False
        txtDaruratAlamat.Enabled = False
        txtDaruratRT.Enabled = False
        txtDaruratRW.Enabled = False
        txtDaruratTelp.Enabled = False
        cmbDaruratKota.Enabled = False
        cmbDaruratKecamatan.Enabled = False
        cmbDaruratKelurahan.Enabled = False
        txtBaruAlamat.Enabled = False
        txtBaruRT.Enabled = False
        txtBaruRW.Enabled = False
        txtBaruTelp.Enabled = False
        cmbBaruKota.Enabled = False
        cmbBaruKecamatan.Enabled = False
        cmbBaruKelurahan.Enabled = False

        txtKtpRT.Enabled = False
        txtKTPRw.Enabled = False
        txtTagihRT.Enabled = False
        txtTagihRW.Enabled = False
        txtKantorRT.Enabled = False
        txtKantorRW.Enabled = False
        txtKantorTelp.Enabled = False
        txtDaruratHubungan.Enabled = False
        txtDaruratRT.Enabled = False
        txtDaruratTelp.Enabled = False
        txtDaruratRW.Enabled = False
        txtBaruRT.Enabled = False
        txtBaruRW.Enabled = False
        txtBaruTelp.Enabled = False
        txtBaruTelp2.Enabled = False
        txtDaruratNama.Enabled = False

        'add 15/12/2014 By Achmad
        'tambahan 


        cmbAnggotaPekerjaan.Enabled = False
        dtpAplikasiTanggal.Enabled = False
        cmbKtpKota.Enabled = False
        cmbKtpKecamatan.Enabled = False
        cmbKtpKota.Enabled = False
        txtKtpRT.Enabled = False
        txtKTPRw.Enabled = False
        txtTagihRT.Enabled = False
        txtTagihRW.Enabled = False
        txtKantorRT.Enabled = False
        txtKantorRW.Enabled = False
        txtKantorTelp.Enabled = False
        txtDaruratHubungan.Enabled = False
        txtDaruratNama.Enabled = False
        txtDaruratTelp.Enabled = False
        txtDaruratRT.Enabled = False
        txtDaruratRW.Enabled = False
        txtBaruRT.Enabled = False
        txtBaruRW.Enabled = False
        txtBaruTelp.Enabled = False
        txtBaruTelp2.Enabled = False


       
        txtDTAdmin.Enabled = False
        txtDTAdminKredit.Enabled = False
        txtDTAdminMurni.Enabled = False
        txtDTAngsuran.Enabled = False
        txtDTBunga.Enabled = False
        txtDTBungaFlat.Enabled = False
        txtDTBungaPengali.Enabled = False
        txtDTKendaraan.Enabled = False
        txtDTBpkbMesin.Enabled = False
        txtDTBpkbNo.Enabled = False
        txtDTPinjaman.Enabled = False
        txtDTPokok.Enabled = False
        txtDTPremiAdmin.Enabled = False
        txtDTPremiAsuransi.Enabled = False
        txtDTBPKBRangka.Enabled = False
        txtDTTahun.Enabled = False
        txtDTTenor.Enabled = False
        txtDTTingkatBunga.Enabled = False
        txtDTTipe.Enabled = False
        txtDTTotalHutang.Enabled = False
        dtpDTAngsuran1.Enabled = False
        dtpDTBast.Enabled = False
        dtpDTKontrak.Enabled = False

        txtDTBpkbNo.Enabled = False
        txtDTBpkbNama.Enabled = False
        txtDTBpkbPengambil.Enabled = False
        txtDTBpkbWarna.Enabled = False
        txtDTBpknNopol.Enabled = False
        txtDTBpkbMesin.Enabled = False
        cmbDTBpkbStatus.Enabled = False
        dtpDTBpkbKeluar.Enabled = False
        dtpDTBpkbMasuk.Enabled = False




    End Sub
    Private Sub EnableComponent()
        cmbKolektor.Enabled = True
        dtpAplikasiTanggal.Enabled = True
        cmbAplikasiPos.Enabled = True
        cmbAplikasiCa.Enabled = True
        cmbAplikasiSy.Enabled = True
        cmbAplikasiSm.Enabled = True
        txtAnggotaNama.Enabled = True
        cmbAnggotaSex.Enabled = True
        txtAnggotaTmptLahir.Enabled = True
        dtpAnggotaTglLahir.Enabled = True
        txtAnggotaKtp.Enabled = True
        txtAnggotaHp.Enabled = True
        txtAnggotaTelp1.Enabled = True
        txtAnggotaTelp2.Enabled = True
        cmbAnggotaPekerjaan.Enabled = True
        txtAnggotaPerusahaanNama.Enabled = True
        txtAnggotaPerusahaanJabatan.Enabled = True
        txtAnggotaPerusahaanMasa.Enabled = True
        txtAnggotaPenghasilan.Enabled = True
        txtAnggotaPenghasilanLain.Enabled = True
        txtAnggotaPenghasilanPasangan.Enabled = True
        txtAnggotaPenghasilanPengeluaran.Enabled = True
        txtAnggotaKomentar.Enabled = True
        txtKtpAlamat.Enabled = True
        cmbKtpKecamatan.Enabled = True
        cmbKtpKelurahan.Enabled = True
        cmbKtpKota.Enabled = True
        txtKtpRT.Enabled = True
        txtKTPRw.Enabled = True
        txtTagihAlamat.Enabled = True
        txtTagihRT.Enabled = True
        txtTagihRW.Enabled = True
        cmbTagihKota.Enabled = True
        cmbTagihKecamatan.Enabled = True
        cmbTagihKelurahan.Enabled = True
        txtKantorAlamat.Enabled = True
        txtKantorRT.Enabled = True
        txtKantorRW.Enabled = True
        txtKantorTelp.Enabled = True
        cmbKantorKota.Enabled = True
        cmbKantorKecamatan.Enabled = True
        cmbKantorKelurahan.Enabled = True
        txtDaruratAlamat.Enabled = True
        txtDaruratRT.Enabled = True
        txtDaruratRW.Enabled = True
        txtDaruratTelp.Enabled = True
        cmbDaruratKota.Enabled = True
        cmbDaruratKecamatan.Enabled = True
        cmbDaruratKelurahan.Enabled = True
        txtBaruAlamat.Enabled = True
        txtBaruRT.Enabled = True
        txtBaruRW.Enabled = True
        txtBaruTelp.Enabled = True
        cmbBaruKota.Enabled = True
        cmbBaruKecamatan.Enabled = True
        cmbBaruKelurahan.Enabled = True

        txtKtpRT.Enabled = True
        txtKTPRw.Enabled = True
        txtTagihRT.Enabled = True
        txtTagihRW.Enabled = True
        txtKantorRT.Enabled = True
        txtKantorRW.Enabled = True
        txtKantorTelp.Enabled = True
        txtDaruratHubungan.Enabled = True
        txtDaruratRT.Enabled = True
        txtDaruratTelp.Enabled = True
        txtDaruratRW.Enabled = True
        txtBaruRT.Enabled = True
        txtBaruRW.Enabled = True
        txtBaruTelp.Enabled = True
        txtBaruTelp2.Enabled = True
        txtDaruratNama.Enabled = True

        txtDTKendaraan.Enabled = True
        txtDTTipe.Enabled = True

        txtDTTahun.Enabled = True
        txtDTBpkbMesin.Enabled = True
        txtDTBPKBRangka.Enabled = True

        txtDTBpkbNo.Enabled = True

        txtDTBpkbNo.Enabled = True
        txtDTBpkbNama.Enabled = True
        txtDTBpkbPengambil.Enabled = True
        txtDTBpkbWarna.Enabled = True
        txtDTBpknNopol.Enabled = True
        txtDTBpkbMesin.Enabled = True
        cmbDTBpkbStatus.Enabled = True
        dtpDTBpkbKeluar.Enabled = True
        dtpDTBpkbMasuk.Enabled = True



    End Sub
    Private Sub ClearComponent()
        txtAplikasiTipe.Clear()
        txtKontrakStatus.Clear()
        txtAplikasiID.Clear()
        txtAnggotaID.Clear()
        txtAnggotaNama.Clear()
        txtAnggotaTmptLahir.Clear()
        txtAnggotaKtp.Clear()
        txtAnggotaHp.Clear()
        txtAnggotaTelp1.Clear()
        txtAnggotaTelp2.Clear()
        txtAnggotaPerusahaanNama.Clear()
        txtAnggotaPerusahaanJabatan.Clear()
        txtAnggotaPerusahaanMasa.Clear()
        txtAnggotaPenghasilan.Clear()
        txtAnggotaPenghasilanLain.Clear()
        txtAnggotaPenghasilanPasangan.Clear()
        txtAnggotaPenghasilanPengeluaran.Clear()
        txtAnggotaKomentar.Clear()
        txtKtpAlamat.Clear()
        txtKtpRT.Clear()
        txtKTPRw.Clear()
        txtTagihAlamat.Clear()
        txtTagihRT.Clear()
        txtTagihRW.Clear()
        txtKantorAlamat.Clear()
        txtKantorRT.Clear()
        txtKantorRW.Clear()
        txtKantorTelp.Clear()
        txtDaruratAlamat.Clear()
        txtDaruratRT.Clear()
        txtDaruratRW.Clear()
        txtDaruratTelp.Clear()
        txtDaruratHubungan.Clear()
        txtBaruAlamat.Clear()
        txtBaruRT.Clear()
        txtBaruRW.Clear()
        txtBaruTelp.Clear()
        txtBaruTelp2.Clear()
        txtDaruratNama.Clear()
        lblCollateralWarning.Text = ""


    End Sub
    Private Sub FillForm(ByVal NomorKontrak As String)
        Try
            Dim KodePostKtp As String
            Dim KodePostTagih As String
            Dim KodePostKantor As String
            Dim KodepostDarurat As String
            Dim KodepostBaru As String

            StrSQL = ""
            StrSQL = "SELECT DISTINCT * FROM V_ContractDetail WHERE ContractID ='" & NomorKontrak & "' "
            RunSQL(StrSQL, 1)
            cmbKolektor.SelectedValue = dt.Rows(0)("Collector").ToString()
            txtAplikasiTipe.Text = dt.Rows(0)("Tipe").ToString()
            txtKontrakStatus.Text = dt.Rows(0)("Status Kontrak").ToString()
            txtAplikasiID.Text = dt.Rows(0)("Nomor Aplikasi").ToString()
            dtpAplikasiTanggal.Text = dt.Rows(0)("Tanggal Aplikasi").ToString()
            cmbAplikasiPos.SelectedValue = dt.Rows(0)("PosID").ToString()
            cmbAplikasiCa.SelectedValue = dt.Rows(0)("CreditAnalystID").ToString()
            cmbAplikasiSy.SelectedValue = dt.Rows(0)("SurveyorID").ToString()
            cmbAplikasiSm.SelectedValue = dt.Rows(0)("SalesmanID").ToString()
            txtAnggotaID.Text = dt.Rows(0)("MemberID").ToString()
            txtAnggotaNama.Text = dt.Rows(0)("MemberName").ToString()
            cmbAnggotaSex.SelectedValue = dt.Rows(0)("GenderID").ToString()
            txtAnggotaTmptLahir.Text = dt.Rows(0)("BirthPlace").ToString()
            dtpAnggotaTglLahir.Text = dt.Rows(0)("BirthDate").ToString()
            txtAnggotaKtp.Text = dt.Rows(0)("PersonalIdentity").ToString()
            txtAnggotaHp.Text = dt.Rows(0)("Handphone").ToString()
            txtAnggotaTelp1.Text = dt.Rows(0)("Telp1").ToString()
            txtAnggotaTelp2.Text = dt.Rows(0)("Telp2").ToString()
            cmbAnggotaPekerjaan.SelectedValue = dt.Rows(0)("WorkTypeID").ToString()
            txtAnggotaPerusahaanNama.Text = dt.Rows(0)("CompName").ToString()
            txtAnggotaPerusahaanJabatan.Text = dt.Rows(0)("CompPosition").ToString()
            txtAnggotaPerusahaanMasa.Text = dt.Rows(0)("CompWorkTime").ToString()
            txtAnggotaPenghasilan.Text = ribuan(dt.Rows(0)("Income").ToString())
            txtAnggotaPenghasilanLain.Text = ribuan(dt.Rows(0)("OtherIncome").ToString())
            txtAnggotaPenghasilanPasangan.Text = ribuan(dt.Rows(0)("SpouseIncome").ToString())
            txtAnggotaPenghasilanPengeluaran.Text = ribuan(dt.Rows(0)("Expense").ToString())
            txtAnggotaKomentar.Text = dt.Rows(0)("SurveyComment").ToString()

            KodePostKtp = dt.Rows(0)("PostalID").ToString()
            txtKtpAlamat.Text = dt.Rows(0)("Address").ToString()
            cmbKtpKota.Text = detailAlamat(KodePostKtp).kota
            cmbKtpKecamatan.Text = detailAlamat(KodePostKtp).kecamatan
            cmbKtpKelurahan.Text = detailAlamat(KodePostKtp).kelurahan
            txtKtpRT.Text = dt.Rows(0)("MemberRT").ToString()
            txtKTPRw.Text = dt.Rows(0)("MemberRW").ToString()

            KodePostTagih = dt.Rows(0)("BillingPostalID").ToString()
            txtTagihAlamat.Text = dt.Rows(0)("BillingAddress").ToString()
            txtTagihRT.Text = dt.Rows(0)("BillingRT").ToString()
            txtTagihRW.Text = dt.Rows(0)("BillingRW").ToString()
            cmbTagihKota.Text = detailAlamat(KodePostTagih).kota
            cmbTagihKecamatan.Text = detailAlamat(KodePostTagih).kecamatan
            cmbTagihKelurahan.Text = detailAlamat(KodePostTagih).kelurahan

            KodePostKantor = dt.Rows(0)("CompPostalID").ToString()
            txtKantorAlamat.Text = dt.Rows(0)("CompAddress").ToString()
            txtKantorRT.Text = dt.Rows(0)("CompRT").ToString()
            txtKantorRW.Text = dt.Rows(0)("CompRW").ToString()
            txtKantorTelp.Text = dt.Rows(0)("CompPhone").ToString()
            cmbKantorKota.Text = detailAlamat(KodePostKantor).kota
            cmbKantorKecamatan.Text = detailAlamat(KodePostKantor).kecamatan
            cmbKantorKelurahan.Text = detailAlamat(KodePostKantor).kelurahan

            KodepostDarurat = dt.Rows(0)("EmerPostalID").ToString()
            txtDaruratAlamat.Text = dt.Rows(0)("EmerAddress").ToString()
            txtDaruratHubungan.Text = dt.Rows(0)("EmerRelations").ToString()
            txtDaruratRT.Text = dt.Rows(0)("EmerRT").ToString()
            txtDaruratRW.Text = dt.Rows(0)("EmerRW").ToString()
            txtDaruratTelp.Text = dt.Rows(0)("EmerPhone").ToString()
            txtDaruratNama.Text = dt.Rows(0)("EmerName").ToString()
            cmbDaruratKota.Text = detailAlamat(KodepostDarurat).kota
            cmbDaruratKecamatan.Text = detailAlamat(KodepostDarurat).kecamatan
            cmbDaruratKelurahan.Text = detailAlamat(KodepostDarurat).kelurahan

            KodepostBaru = dt.Rows(0)("NewPostalID").ToString()
            txtBaruAlamat.Text = dt.Rows(0)("NewAddress").ToString()
            txtBaruRT.Text = dt.Rows(0)("NewRT").ToString()
            txtBaruRW.Text = dt.Rows(0)("NewRW").ToString()
            txtBaruTelp.Text = dt.Rows(0)("NewTelp1").ToString()
            txtBaruTelp2.Text = dt.Rows(0)("NewTelp2").ToString()
            cmbBaruKota.Text = detailAlamat(KodepostBaru).kota
            cmbBaruKecamatan.Text = detailAlamat(KodepostBaru).kecamatan
            cmbBaruKelurahan.Text = detailAlamat(KodepostBaru).kelurahan

        Catch ex As Exception
            SaveErrorLog(ex.Message, "Form kontrak")
        End Try

    End Sub


#End Region
#Region "CRUD DB"
    Private Function UpdateMember() As Boolean
        Try
            Dim memberID As String = txtAnggotaID.Text
            Dim memberName As String = antisqli(txtAnggotaNama.Text)
            Dim salesmanID As String = cmbAplikasiSm.SelectedValue
            Dim genderID As String = cmbAnggotaSex.SelectedValue
            Dim BirthDate As Date = dtpAnggotaTglLahir.Value
            Dim BirthPlace As String = antisqli(txtAnggotaTmptLahir.Text)
            Dim personalIdentity As String = antisqli(txtAnggotaKtp.Text)
            Dim address As String = antisqli(txtKtpAlamat.Text)
            Dim memberRt As String = antisqli(txtKtpRT.Text)
            Dim memberRW As String = antisqli(txtKTPRw.Text)
            Dim PostalID As String = cmbKtpKelurahan.SelectedValue
            Dim phone1 As String = antisqli(txtAnggotaHp.Text)
            Dim phone2 As String = antisqli(txtAnggotaTelp1.Text)
            Dim phone3 As String = antisqli(txtAnggotaTelp2.Text)
            Dim worktypeid As String = cmbAnggotaPekerjaan.SelectedValue
            Dim CompName As String = antisqli(txtAnggotaPerusahaanNama.Text)
            Dim CompPosition As String = antisqli(txtAnggotaPerusahaanJabatan.Text)
            Dim compWorkTime As Integer = CInt(txtAnggotaPerusahaanMasa.Text)
            Dim CompAddress As String = antisqli(txtKantorAlamat.Text)
            Dim compRt As String = txtKantorRT.Text
            Dim compRw As String = txtKantorRW.Text
            Dim CompPostalID As String = cmbKantorKelurahan.SelectedValue
            Dim CompPhone As String = antisqli(txtKantorTelp.Text)
            Dim EmerName As String = antisqli(txtDaruratNama.Text)
            Dim emerAddress As String = antisqli(txtDaruratAlamat.Text)
            Dim emerRt As String = txtDaruratRT.Text
            Dim emerRw As String = txtDaruratRW.Text
            Dim emerPostalID As String = cmbDaruratKelurahan.SelectedValue
            Dim emerPhone As String = antisqli(txtDaruratTelp.Text)
            Dim emerRelation As String = antisqli(txtDaruratHubungan.Text)
            Dim BillingAddress As String = antisqli(txtTagihAlamat.Text)
            Dim billingRt As String = txtTagihRT.Text
            Dim billingRw As String = txtTagihRW.Text
            Dim billingPostalID As String = cmbTagihKelurahan.SelectedValue
            Dim income As Double = CDbl(txtAnggotaPenghasilan.Text)
            Dim SpouseIncome As Double = CDbl(txtAnggotaPenghasilanPasangan.Text)
            Dim OtherIncome As Double = CDbl(txtAnggotaPenghasilanLain.Text)
            Dim Expense As Double = CDbl(txtAnggotaPenghasilanPengeluaran.Text)
            Dim newAddress As String = antisqli(txtBaruAlamat.Text)
            Dim newTelp As String = antisqli(txtBaruTelp.Text)
            Dim newTelp2 As String = antisqli(txtBaruTelp2.Text)
            Dim newPostalID As String = cmbBaruKelurahan.SelectedValue
            Dim newRT As String = txtBaruRT.Text
            Dim newRW As String = txtBaruRW.Text

            StrSQL = ""
            StrSQL = "Sp_MemberUpdate "
            StrSQL &= "'" & memberID & "',"
            StrSQL &= "'" & memberName & "',"
            StrSQL &= "'" & salesmanID & "',"
            StrSQL &= "'" & genderID & "',"
            StrSQL &= "'" & BirthDate & "',"
            StrSQL &= "'" & BirthPlace & "',"
            StrSQL &= "'" & personalIdentity & "',"
            StrSQL &= "'" & address & "',"
            StrSQL &= "'" & memberRt & "',"
            StrSQL &= "'" & memberRW & "',"
            StrSQL &= "'" & PostalID & "',"
            StrSQL &= "'" & phone1 & "',"
            StrSQL &= "'" & phone2 & "',"
            StrSQL &= "'" & phone3 & "',"
            StrSQL &= "'" & worktypeid & "',"
            StrSQL &= "'" & CompName & "',"
            StrSQL &= "'" & CompPosition & "',"
            StrSQL &= "" & compWorkTime & ","
            StrSQL &= "'" & CompAddress & "',"
            StrSQL &= "'" & compRt & "',"
            StrSQL &= "'" & compRw & "',"
            StrSQL &= "'" & CompPostalID & "',"
            StrSQL &= "'" & CompPhone & "',"
            StrSQL &= "'" & EmerName & "',"
            StrSQL &= "'" & emerAddress & "',"
            StrSQL &= "'" & emerRt & "',"
            StrSQL &= "'" & emerRw & "',"
            StrSQL &= "'" & emerPostalID & "',"
            StrSQL &= "'" & emerPhone & "',"
            StrSQL &= "'" & emerRelation & "',"
            StrSQL &= "'" & BillingAddress & "',"
            StrSQL &= "'" & billingRt & "',"
            StrSQL &= "'" & billingRw & "',"
            StrSQL &= "'" & billingPostalID & "',"
            StrSQL &= "" & income & ","
            StrSQL &= "" & SpouseIncome & ","
            StrSQL &= "" & OtherIncome & ","
            StrSQL &= "" & Expense & ","
            StrSQL &= "'" & newAddress & "',"
            StrSQL &= "'" & newTelp & "',"
            StrSQL &= "'" & newTelp2 & "',"
            StrSQL &= "'" & newPostalID & "',"
            StrSQL &= "'" & newRT & "',"
            StrSQL &= "'" & newRW & "'"
            RunSQL(StrSQL, 0)
            Return True
        Catch ex As Exception
            SaveErrorLog(ex.Message, "Update Member Form Kontrak")
            Return False
        End Try
    End Function
    Private Function UpdateApplication() As Boolean
        Try
            Dim ApplicationID As String = txtAplikasiID.Text
            Dim ApplicationDate As Date = dtpAplikasiTanggal.Value
            Dim PosID As String = cmbAplikasiPos.SelectedValue
            Dim CreditAnalystID As String = cmbAplikasiCa.SelectedValue
            Dim SurveyorID As String = cmbAplikasiSy.SelectedValue
            Dim SalesmanID As String = cmbAplikasiSm.SelectedValue
            Dim tenor As String = ""
            Dim effectiveInterestP As Double
            Dim Motorprice As Double
            Dim ElectronicPrice As Double
            Dim DownPayment As Double
            Dim InsuranceRate As Double
            Dim LoanAdmin As Double
            Dim DealerSubs As Double
            Dim MarketingCost As Double
            Dim InsuranceAdmin As Double
            Dim MotorBrand As String = ""
            Dim MotorType As String = ""
            Dim MotorColor As String = ""
            Dim MotorYear As String = ""
            Dim SurveyComment As String = txtAnggotaKomentar.Text
            Dim ShortageDocument As String = ""
            Dim baseDebt As Double
            Dim Installment As Double
            Dim BpkbNo As String = ""
            Dim FrameCode As String = ""
            Dim EngineCode As String = ""
            Dim platNo As String = ""
            Dim AdminPremi As Double
            Dim BungaPengali As Double
            Dim Pokok As Double
            Dim Bunga As Double

            Select Case txtAplikasiTipe.Text
                Case "Dana Tunai"
                    tenor = txtDTTenor.Text
                    effectiveInterestP = CDbl(txtDTTingkatBunga.Text)
                    Motorprice = CDbl(txtDTPinjaman.Text)
                    ElectronicPrice = 0
                    DownPayment = 0
                    InsuranceRate = CDbl(txtDTPremiAsuransi.Text)
                    LoanAdmin = CDbl(txtDTAdminKredit.Text)
                    DealerSubs = 0
                    MarketingCost = 0
                    InsuranceAdmin = CDbl(txtDTAdmin.Text)
                    MotorBrand = antisqli(txtDTKendaraan.Text)
                    MotorType = antisqli(txtDTTipe.Text)
                    MotorColor = antisqli(txtDTBpkbWarna.Text)
                    MotorYear = antisqli(txtDTTahun.Text)
                    ShortageDocument = ""
                    baseDebt = CDbl(txtDTPokok.Text)
                    Installment = CDbl(txtDTAngsuran.Text)
                    BpkbNo = antisqli(txtDTBpkbNo.Text)
                    FrameCode = antisqli(txtDTBPKBRangka.Text)
                    EngineCode = antisqli(txtDTBpkbMesin.Text)
                    platNo = antisqli(txtDTBpknNopol.Text)
                    AdminPremi = CDbl(txtDTPremiAdmin.Text)
                    Pokok = CDbl(txtDTPokok.Text)
                    BungaPengali = CDbl(txtDTBungaPengali.Text)
                    Bunga = CDbl(txtDTBunga.Text)

                Case "KTA"
                    tenor = txtKTATenor.Text
                    effectiveInterestP = CDbl(txtKTATingkatBunga.Text)
                    Motorprice = CDbl(txtKTAPinjaman.Text)
                    ElectronicPrice = 0
                    DownPayment = 0
                    InsuranceRate = 0
                    LoanAdmin = 0
                    DealerSubs = 0
                    MarketingCost = 0
                    InsuranceAdmin = 0
                    MotorBrand = ""
                    MotorType = ""
                    MotorColor = ""
                    MotorYear = ""
                    ShortageDocument = ""
                    baseDebt = CDbl(txtKTAPokok.Text)
                    Installment = CDbl(txtKTAAngsuran.Text)
                    BpkbNo = ""
                    FrameCode = ""
                    EngineCode = ""
                    platNo = ""
                    AdminPremi = 0
                    Pokok = CDbl(txtKTAPokok.Text)
                    BungaPengali = CDbl(txtKTABungaPengali.Text)
                    Bunga = CDbl(txtKTABunga.Text)

                Case "Elektronik"
                    tenor = txtELTenor.Text
                    effectiveInterestP = CDbl(txtELTingkatBunga.Text)
                    Motorprice = CDbl(txtELHarga.Text)
                    ElectronicPrice = CDbl(txtELHarga.Text)
                    DownPayment = 0
                    InsuranceRate = 0
                    LoanAdmin = 0
                    DealerSubs = 0
                    MarketingCost = 0
                    InsuranceAdmin = 0
                    MotorBrand = antisqli(txtELNamaBarang.Text)
                    MotorType = antisqli(txtELKeterangan.Text)
                    MotorColor = antisqli(txtELNomorSeri.Text)
                    MotorYear = ""
                    ShortageDocument = antisqli(txtAplikasiDokumen.Text)
                    baseDebt = CDbl(txtELPokok.Text)
                    Installment = CDbl(txtELAngsuran.Text)
                    BpkbNo = ""
                    FrameCode = ""
                    EngineCode = ""
                    platNo = ""
                    AdminPremi = 0
                    Pokok = CDbl(txtELPokok.Text)
                    BungaPengali = CDbl(txtELBungaPengali.Text)
                    Bunga = CDbl(txtELBunga.Text)

                Case "Motor Baru"
                    tenor = txtMBTenor.Text
                    effectiveInterestP = CDbl(txtMBTingkatBunga.Text)
                    Motorprice = CDbl(txtMBPinjaman.Text)
                    ElectronicPrice = 0
                    DownPayment = CDbl(txtMBDownPayment.Text)
                    InsuranceRate = CDbl(txtMBPremiAsuransi.Text)
                    LoanAdmin = CDbl(txtMBAdminKredit.Text)
                    DealerSubs = CDbl(txtMBSubsidiDealer.Text)
                    MarketingCost = CDbl(txtMBMarketingCost.Text)
                    InsuranceAdmin = CDbl(txtMBAdmin.Text)
                    MotorBrand = antisqli(txtMBKendaraan.Text)
                    MotorType = antisqli(txtMBTipe.Text)
                    MotorColor = antisqli(txtMBBpkbWarna.Text)
                    MotorYear = antisqli(txtMBTahun.Text)
                    ShortageDocument = antisqli(txtAplikasiDokumen.Text)
                    baseDebt = CDbl(txtMBPokok.Text)
                    Installment = CDbl(txtMBAngsuran.Text)
                    BpkbNo = antisqli(txtMBBpkbNo.Text)
                    FrameCode = antisqli(txtMbBpkbRangka.Text)
                    EngineCode = antisqli(txtMBBpkbMesin.Text)
                    platNo = antisqli(txtMBBpkbNopol.Text)
                    AdminPremi = CDbl(txtMBAdminPremi.Text)
                    Pokok = CDbl(txtMBPokok.Text)
                    BungaPengali = CDbl(txtMBBungaPengali.Text)
                    Bunga = CDbl(txtMBBunga.Text)

            End Select

            StrSQL = ""
            StrSQL = "Sp_ApplicationUpdate "
            StrSQL &= "'" & txtAplikasiID.Text & "',"
            StrSQL &= "'" & ApplicationDate & "',"
            StrSQL &= "'" & PosID & "',"
            StrSQL &= "'" & CreditAnalystID & "',"
            StrSQL &= "'" & SurveyorID & "',"
            StrSQL &= "'" & SalesmanID & "',"
            StrSQL &= "'" & tenor & "',"
            StrSQL &= "" & effectiveInterestP & ","
            StrSQL &= "" & Motorprice & ","
            StrSQL &= "" & ElectronicPrice & ","
            StrSQL &= "" & DownPayment & ","
            StrSQL &= "" & InsuranceRate & ","
            StrSQL &= "" & LoanAdmin & ","
            StrSQL &= "" & DealerSubs & ","
            StrSQL &= "" & MarketingCost & ","
            StrSQL &= "" & InsuranceAdmin & ","
            StrSQL &= "'" & MotorBrand & "',"
            StrSQL &= "'" & MotorType & "',"
            StrSQL &= "'" & MotorColor & "',"
            StrSQL &= "'" & MotorYear & "',"
            StrSQL &= "'" & SurveyComment & "',"
            StrSQL &= "'" & ShortageDocument & "',"
            StrSQL &= "'" & baseDebt & "',"
            StrSQL &= "'" & Installment & "',"
            StrSQL &= "'" & BpkbNo & "',"
            StrSQL &= "'" & FrameCode & "',"
            StrSQL &= "'" & EngineCode & "',"
            StrSQL &= "'" & platNo & "',"
            StrSQL &= "" & AdminPremi & ","
            StrSQL &= "" & BungaPengali & ","
            StrSQL &= "" & Pokok & ","
            StrSQL &= "" & Bunga & ""
            RunSQL(StrSQL, 0)
            Return True
        Catch ex As Exception
            SaveErrorLog(ex.Message, "Update Aplikasi Form Kontrak")
            Return False
        End Try
    End Function
    Private Function UpdateContract() As Boolean

        Try
            Dim ContractDate As Date
            Dim BastDate As Date
            Dim FirstInstallment As Date
            Dim EmployeeID As String = cmbKolektor.SelectedValue


            Select Case txtAplikasiTipe.Text
                Case "Dana Tunai"
                    ContractDate = dtpDTKontrak.Value
                    BastDate = dtpDTBast.Value
                    FirstInstallment = dtpDTAngsuran1.Value
                    ' modal = CDbl(txtDTPinjaman.Text) + CDbl(txtDTAdmin.Text) + CDbl(txtDTAdminKredit.Text)
                Case "KTA"
                    ContractDate = dtpKTAKontrak.Value
                    BastDate = dtpKTABast.Value
                    FirstInstallment = dtpKTAAngsuran.Value

                Case "Elektronik"
                    ContractDate = dtpELKontrak.Value
                    BastDate = dtpELBast.Value
                    FirstInstallment = dtpELAngsuran.Value
                    ' modal = CDbl(txtKTAPinjaman.Text)

                Case "Motor Baru"
                    ContractDate = dtpMBKontrak.Value
                    BastDate = dtpMBBast.Value
                    FirstInstallment = dtpMBAngsuran.Value

            End Select
            StrSQL = ""
            StrSQL = "Sp_ContractUpdate "
            StrSQL &= "'" & antisqli(TrueContractID) & "',"
            StrSQL &= "'" & ContractDate & "',"
            StrSQL &= "'" & BastDate & "',"
            StrSQL &= "'" & FirstInstallment & "',"
            StrSQL &= "'" & EmployeeID & "'"
            If RunSQL(StrSQL, 0) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            SaveErrorLog(ex.Message, "Update Kontrak Form Kontrak")
            Return False
        End Try
    End Function
#End Region



#Region "Collateral Function"

    Private Sub FillCollateral(ByVal NomorAplikasi As String)
        StrSQL = ""
        StrSQL = "SELECT DISTINCT * FROM V_ApplicationCollateral WHERE ApplicationID = '" & NomorAplikasi & "'"
        RunSQL(StrSQL, 1)
        If dt.Rows.Count > 0 Then
            Select Case txtAplikasiTipe.Text
                Case "Dana Tunai"
                    DisableDTComponent()
                    txtDTKendaraan.Text = dt.Rows(0)("Merk").ToString()
                    txtDTTipe.Text = dt.Rows(0)("Tipe").ToString()
                    'txtDTBpkbWarna.Text = dt.Rows(0)("Warna").ToString()
                    txtDTTahun.Text = dt.Rows(0)("Tahun").ToString()
                    ' txtDTBpkbMesin.Text = dt.Rows(0)("Mesin").ToString()
                    ' txtDTBpknNopol.Text = dt.Rows(0)("Plat").ToString()
                    'txtDTRangka.Text = dt.Rows(0)("Rangka").ToString()
                    txtDTBpkbNo.Text = dt.Rows(0)("Bpkb").ToString()
                    txtDTTenor.Text = dt.Rows(0)("Tenor").ToString()
                    txtDTPinjaman.Text = ribuan(dt.Rows(0)("Pinjaman").ToString())
                    txtMBTenor.Text = CDbl(dt.Rows(0)("Tenor").ToString())
                    txtDTPremiAsuransi.Text = CDbl(dt.Rows(0)("PremiAsuransi%").ToString())
                    txtDTAdmin.Text = ribuan(dt.Rows(0)("Admin").ToString())
                    txtDTPremiAdmin.Text = ribuan(dt.Rows(0)("Premi+Admin").ToString())
                    txtDTTingkatBunga.Text = CDbl(dt.Rows(0)("TingkatBungaEfektif%").ToString())
                    txtDTAdminKredit.Text = ribuan(dt.Rows(0)("AdminKredit").ToString())
                    dtpDTAngsuran1.Value = getFieldValue("SELECT TOP 1 FirstInstallment FROM CONTRACT WHERE ContractID='" & txtKontrakID.Text & "' ")
                    dtpDTBast.Value = getFieldValue("SELECT TOP 1 BASTDATE FROM CONTRACT WHERE ContractID='" & txtKontrakID.Text & "' ")
                    dtpDTKontrak.Value = getFieldValue("SELECT TOP 1 CONTRACTDATE FROM CONTRACT WHERE ContractID='" & txtKontrakID.Text & "' ")
                    KalkulasiDanaTunai()
                    FlagBpkb = True
                    FillDataBpkb(txtDTBpkbNo.Text)

                Case "KTA"
                    DisableKTAComponent()
                    txtKTAPinjaman.Text = ribuan(dt.Rows(0)("Pinjaman").ToString())
                    txtKTATenor.Text = dt.Rows(0)("Tenor").ToString()
                    txtKTATingkatBunga.Text = CDbl(dt.Rows(0)("TingkatBungaEfektif%").ToString())
                    dtpKTAAngsuran.Value = getFieldValue("SELECT TOP 1 FirstInstallment FROM CONTRACT WHERE ContractID='" & txtKontrakID.Text & "' ")
                    dtpKTABast.Value = getFieldValue("SELECT TOP 1 BASTDATE FROM CONTRACT WHERE ContractID='" & txtKontrakID.Text & "' ")
                    dtpKTAKontrak.Value = getFieldValue("SELECT TOP 1 CONTRACTDATE FROM CONTRACT WHERE ContractID='" & txtKontrakID.Text & "' ")
                    KalkulasiKTA()
                    FlagBpkb = False

                Case "Elektronik"
                    ClearELComponent()
                    DisableELComponent()
                    txtELNamaBarang.Text = dt.Rows(0)("Merk").ToString()
                    txtELKeterangan.Text = dt.Rows(0)("Tipe").ToString()
                    txtELNomorSeri.Text = dt.Rows(0)("Warna").ToString()
                    txtAplikasiDokumen.Text = dt.Rows(0)("Dokumen").ToString()
                    txtELHarga.Text = ribuan(dt.Rows(0)("Pinjaman").ToString())
                    txtELTenor.Text = dt.Rows(0)("Tenor").ToString()
                    txtELTingkatBunga.Text = dt.Rows(0)("TingkatBungaEfektif%").ToString()
                    dtpELAngsuran.Value = getFieldValue("SELECT TOP 1 FirstInstallment FROM CONTRACT WHERE ContractID='" & txtKontrakID.Text & "' ")
                    dtpELBast.Value = getFieldValue("SELECT TOP 1 BASTDATE FROM CONTRACT WHERE ContractID='" & txtKontrakID.Text & "' ")
                    dtpELKontrak.Value = getFieldValue("SELECT TOP 1 CONTRACTDATE FROM CONTRACT WHERE ContractID='" & txtKontrakID.Text & "' ")
                    KalkulasiElektronik()

                Case "Motor Baru"
                    ClearMBComponent()
                    DisableMBComponent()
                    txtMBKendaraan.Text = dt.Rows(0)("Merk").ToString()
                    txtMBTipe.Text = dt.Rows(0)("Tipe").ToString()
                    'txtMBBpkbWarna.Text = dt.Rows(0)("Warna").ToString()
                    txtMBTahun.Text = dt.Rows(0)("Tahun").ToString()
                    ' txtMBBpkbMesin.Text = dt.Rows(0)("Mesin").ToString()
                    ' txtMBBpknNopol.Text = dt.Rows(0)("Plat").ToString()
                    'txtMBRangka.Text = dt.Rows(0)("Rangka").ToString()
                    txtMBBpkbNo.Text = dt.Rows(0)("Bpkb").ToString()
                    txtMBTenor.Text = dt.Rows(0)("Tenor").ToString()
                    txtMBPinjaman.Text = ribuan(dt.Rows(0)("Pinjaman").ToString())
                    txtMBTenor.Text = CDbl(dt.Rows(0)("Tenor").ToString())
                    txtMBPremiAsuransi.Text = CDbl(dt.Rows(0)("PremiAsuransi%").ToString())
                    txtMBAdmin.Text = ribuan(dt.Rows(0)("Admin").ToString())
                    txtMBAdminPremi.Text = ribuan(dt.Rows(0)("Premi+Admin").ToString())
                    txtMBTingkatBunga.Text = CDbl(dt.Rows(0)("TingkatBungaEfektif%").ToString())
                    txtMBAdminKredit.Text = ribuan(dt.Rows(0)("AdminKredit").ToString())
                    dtpMBAngsuran.Value = getFieldValue("SELECT TOP 1 FirstInstallment FROM CONTRACT WHERE ContractID='" & txtKontrakID.Text & "' ")
                    dtpMBBast.Value = getFieldValue("SELECT TOP 1 BASTDATE FROM CONTRACT WHERE ContractID='" & txtKontrakID.Text & "' ")
                    dtpMBKontrak.Value = getFieldValue("SELECT TOP 1 CONTRACTDATE FROM CONTRACT WHERE ContractID='" & txtKontrakID.Text & "' ")
                    txtMBDownPayment.Text = ribuan(dt.Rows(0)("UangMuka").ToString())
                    txtMBSubsidiDealer.Text = ribuan(dt.Rows(0)("SubsidiDealer").ToString())
                    txtAplikasiDokumen.Text = dt.Rows(0)("Dokumen").ToString()
                    KalkulasiMotorBaru()
                    FlagBpkb = True
                    FillDataBpkb(txtMBBpkbNo.Text)

            End Select
        End If
    End Sub

    Private Sub CekStatusCollateral(ByVal ContractID As String)
        StrSQL = ""
        StrSQL = "SELECT * FROM ContractDetail Where ContractID = '" & ContractID & "' AND TglBayar IS NOT NULL"
        RunSQL(StrSQL, 1)
        If dt.Rows.Count = 0 Then
            BukaCollateral()
            FlagCollateral = True
        Else
            TutupCollateral()
            FlagCollateral = False
        End If
    End Sub

    Private Sub BukaCollateral()
        lblCollateralWarning.Visible = True
        lblCollateralWarning.Text = "Update Pada Collateral Akan Merubah AR INFO"
        Select Case txtAplikasiTipe.Text
            Case "Dana Tunai"
                EnableDTComponent()
            Case "KTA"
                EnableKTAComponent()
            Case "Elektronik"
                EnableELComponent()
            Case "Motor Baru"
                EnableMBComponent()
        End Select
    End Sub
    Private Sub TutupCollateral()
        lblCollateralWarning.Visible = True
        lblCollateralWarning.Text = "Collateral Tidak Bisa Diubah Karena Pembayaran Telah Dilakukan"
        Select Case txtAplikasiTipe.Text
            Case "Dana Tunai"
                DisableDTComponent()
                txtDTBpkbNo.Enabled = True
                txtDTBpkbMesin.Enabled = True
                txtDTBpkbNama.Enabled = True
                txtDTBpkbPengambil.Enabled = True
                txtDTBpkbWarna.Enabled = True
                txtDTBpknNopol.Enabled = True
                txtDTBPKBRangka.Enabled = True
                txtDTTahun.Enabled = True
                txtDTKendaraan.Enabled = True
                txtDTTipe.Enabled = True
                dtpDTBpkbKeluar.Enabled = True
                dtpDTBpkbMasuk.Enabled = True
                cmbDTBpkbStatus.Enabled = True
                txtDTBpkbAlamat.Enabled = True
                txtDTBpkbRT.Enabled = True
                txtDTBpkbRW.Enabled = True
                cmbDTBpkbKecamatan.Enabled = True
                cmbDTBpkbKota.Enabled = True
                cmbDTBpkbKelurahan.Enabled = True
            Case "KTA"
                DisableKTAComponent()
            Case "Elektronik"
                DisableELComponent()
            Case "Motor Baru"
                DisableMBComponent()
                txtMBBpkbNo.Enabled = True
                txtMBBpkbAlamat.Enabled = True
                txtMBBpkbMesin.Enabled = True
                txtMBBpkbNama.Enabled = True
                txtMBBpkbNopol.Enabled = True
                txtMBBpkbPengambil.Enabled = True
                txtMbBpkbRangka.Enabled = True
                txtMBBpkbRT.Enabled = True
                txtMBBpkbRW.Enabled = True
                txtMBBpkbWarna.Enabled = True
                txtMBKendaraan.Enabled = True
                txtMBTahun.Enabled = True
                txtMBTipe.Enabled = True
                dtpMBAngsuran.Enabled = True
                dtpMBBast.Enabled = True
                dtpMBKontrak.Enabled = True
                dtpMBBpkbKeluar.Enabled = True
                dtpMbBpkbMasuk.Enabled = True
                btnMBKalkulasi.Enabled = True
                cmbMBBpkbKota.Enabled = True
                cmbMBBpkbKecamatan.Enabled = True
                cmbMBBpkbKelurahan.Enabled = True
                cmbMBBpkbStatus.Enabled = True

        End Select
    End Sub

    Private Sub HitungPremiAdmin(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDTPinjaman.TextChanged, txtDTPremiAsuransi.TextChanged, txtDTAdmin.TextChanged, txtDTAdminKredit.TextChanged
        'tempPokok = Format(CDbl(txtPinjaman.Text) + CDbl(txtAdminKredit.Text), "#,##0")
        'tempPremiAdmin = Format(((CDbl(tempPokok) * CDbl(txtPremiAsuransi.Text)) / 100) + CDbl(txtAdmin.Text), "#,##0")
        'txtPremiAdmin.Text = ribuan(CStr(tempPremiAdmin))
        Dim tempPokok As Double
        Dim tempPremiAdmin As Double
        Dim Pinjaman As Double
        Dim AdminKredit As Double
        Dim PremiAsuransi As Double
        Dim Admin As Double
        Select Case txtAplikasiTipe.Text
            Case "Dana Tunai"
                If txtDTPinjaman.Text = "" Then
                    Pinjaman = 0
                Else
                    Pinjaman = CDbl(txtDTPinjaman.Text)
                End If

                If txtDTAdminKredit.Text = "" Then
                    AdminKredit = 0
                Else
                    AdminKredit = CDbl(txtDTAdminKredit.Text)
                End If

                If txtDTPremiAsuransi.Text = "" Then
                    PremiAsuransi = 0
                Else
                    PremiAsuransi = CDbl(txtDTPremiAsuransi.Text)
                End If

                If txtDTAdmin.Text = "" Then
                    Admin = 0
                Else
                    Admin = CDbl(txtDTAdmin.Text)
                End If


                tempPokok = Format(CDbl(Pinjaman) + CDbl(AdminKredit), "#,##0")
                tempPremiAdmin = Format(((CDbl(tempPokok) * CDbl(PremiAsuransi)) / 100) + CDbl(Admin), "#,##0")
                txtDTPremiAdmin.Text = ribuan(CStr(tempPremiAdmin))
        End Select
    End Sub


    Private Function UpdateCollateral() As Boolean
        Try
            Dim ContractID As String = antisqli(txtKontrakID.Text)
            Dim Flag As String = "UPD_CTR"
            Dim Tanggal As Date = Now
            Dim Nominal As Double = 0
            Dim Userid As String = UserName

            Select Case txtAplikasiTipe.Text

                Case "KTA"
                    KalkulasiKTA()
                    Tanggal = dtpKTAKontrak.Value.Date
                    Nominal = CDbl(txtKTAPokok.Text)

                Case "Elektronik"
                    KalkulasiElektronik()
                    Tanggal = dtpELKontrak.Value.Date
                    Nominal = CDbl(txtELPokok.Text)

                Case "Dana Tunai"
                    KalkulasiDanaTunai()
                    Tanggal = dtpDTKontrak.Value.Date
                    Nominal = CDbl(txtDTPokok.Text)

                Case "Motor Baru"
                    KalkulasiMotorBaru()
                    Tanggal = dtpMBKontrak.Value.Date
                    Nominal = CDbl(txtMBPokok.Text)

            End Select

            StrSQL = ""
            StrSQL = "Sp_BankIU "
            StrSQL &= "'" & Flag & "',"
            StrSQL &= "'" & ContractID & "',"
            StrSQL &= "'" & Tanggal & "',"
            StrSQL &= "" & Nominal & ","
            StrSQL &= "'" & Userid & "'"
            RunSQL(StrSQL, 0)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub UbahAR()
        Dim TanggalAngsuran As Date
        Dim TanggalBast As Date
        Dim TanggalKontrak As Date
        Dim tenor As Integer
        Dim angsuran As Double
        StrSQL = ""
        StrSQL = "DELETE FROM CONTRACTDETAIL WHERE ContractID = '" & txtKontrakID.Text & "'"
        RunSQL(StrSQL, 0)

        Select Case txtAplikasiTipe.Text
            Case "KTA"
                TanggalAngsuran = dtpKTAAngsuran.Value.Date
                TanggalBast = dtpKTABast.Value.Date
                TanggalKontrak = dtpKTAKontrak.Value.Date
                tenor = CInt(txtKTATenor.Text)
                angsuran = CDbl(txtKTAAngsuran.Text)
            Case "Dana Tunai"
                TanggalAngsuran = dtpDTAngsuran1.Value.Date
                TanggalBast = dtpDTBast.Value.Date
                TanggalKontrak = dtpDTKontrak.Value.Date
                tenor = CInt(txtDTTenor.Text)
                angsuran = CDbl(txtDTAngsuran.Text)
            Case "Elektronik"
                TanggalAngsuran = dtpELAngsuran.Value.Date
                TanggalBast = dtpELBast.Value.Date
                TanggalKontrak = dtpELKontrak.Value.Date
                tenor = CInt(txtELTenor.Text)
                angsuran = CDbl(txtELAngsuran.Text)
            Case "Motor Baru"
                TanggalAngsuran = dtpMBAngsuran.Value.Date
                TanggalBast = dtpMBBast.Value.Date
                TanggalKontrak = dtpMBKontrak.Value.Date
                tenor = CInt(txtMBTenor.Text)
                angsuran = CDbl(txtMBAngsuran.Text)

        End Select

        StrSQL = ""
        StrSQL = "UPDATE Contract SET ContractDate = '" & TanggalKontrak & "',"
        StrSQL &= "BastDate='" & TanggalBast & "',FirstInstallment='" & TanggalAngsuran & "', "
        StrSQL &= "EmployeeID='" & cmbKolektor.SelectedValue & "' "
        StrSQL &= "WHERE CONTRACTID='" & txtKontrakID.Text & "' "
        RunSQL(StrSQL, 0)

        HitungUlangAR(txtAplikasiID.Text, TanggalAngsuran, tenor, angsuran)


    End Sub

    Private Sub HitungUlangAR(ByVal NomorAplikasi As String, ByVal TanggalAngsuran As Date, ByVal tenor As Integer, ByVal angsuran As Double)
        Dim TanggalAwal As Integer = Microsoft.VisualBasic.DateAndTime.Day(TanggalAngsuran)
        Dim bulan As Integer = Microsoft.VisualBasic.DateAndTime.Month(TanggalAngsuran)
        'Dim tahun As Integer = Microsoft.VisualBasic.DateAndTime.Year(TanggalKontrak)
        Dim tanggalJatuhTempo As Integer = Microsoft.VisualBasic.DateAndTime.Day(TanggalAngsuran)
        Dim bulanJatuhTempo As Integer = Microsoft.VisualBasic.DateAndTime.Month(TanggalAngsuran)
        Dim tahunJatuhTempo As Integer = Microsoft.VisualBasic.DateAndTime.Year(TanggalAngsuran)
        Dim tempJatuhTempo As String = ""
        ' Dim penambahBulan As Integer = 
        Dim tempIndex As Integer
        Dim pokok As Double = CDbl(getFieldValue("SELECT BaseDebt from Application Where ApplicationID='" & NomorAplikasi & "'"))
        'Dim BungaPengali As Double = CDbl(txtBungaPengali.Text)
        Dim EffectiveInterestP As Double = CDbl(getFieldValue("SELECT EffectiveInterestP from Application Where ApplicationID='" & NomorAplikasi & "'"))
        Dim Bunga As Double = CDbl(getFieldValue("SELECT Bunga from Application Where ApplicationID='" & NomorAplikasi & "'"))
        Dim Sp As Double
        Dim Si As Double
        Dim Op As Double
        Dim Oi As Double

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
            Sp = CDbl(angsuran) - Si
            Op = pokok - Sp
            Oi = Bunga - Si
            If Op < 0 Then
                Op = 0
            End If

            If Oi < 0 Then
                Oi = 0
            End If
            StrSQL = ""
            StrSQL = "INSERT INTO ContractDetail (ContractID,JatuhTempo,Angsuran,Sp,Si,Op,Oi,[index]) Values("
            StrSQL &= "'" & CStr(antisqli(txtKontrakID.Text)) & "',"
            StrSQL &= "'" & CStr(tempJatuhTempo) & "',"
            StrSQL &= "" & CDbl(angsuran) & ","
            StrSQL &= "" & Math.Round(Sp) & ","
            StrSQL &= "" & Math.Round(Si) & ","
            StrSQL &= "" & Math.Round(Op) & ","
            StrSQL &= "" & Math.Round(Oi) & ","
            StrSQL &= "" & index & ")"

            RunSQL(StrSQL, 0)

            pokok = pokok - Sp
            Bunga = Bunga - Si
            'Bunga = Bunga + Si
            tanggalJatuhTempo = Microsoft.VisualBasic.DateAndTime.Day(TanggalAngsuran)
            tempIndex = index
        Next
        lastTenor(tempIndex, tempJatuhTempo, Sp, Si, Op, Oi, pokok, Bunga, TanggalAwal, NomorAplikasi)
    End Sub

    Private Sub lastTenor(ByVal index As Integer, ByVal JatuhTempo As String, ByVal sp As Double, ByVal si As Double, ByVal op As Double, ByVal oi As Double, ByVal pokok As Double, ByVal bunga As Double, ByVal tanggalawal As Integer, ByVal NoAplikasi As String)

        Dim tanggal As Integer
        Dim bulan As Integer
        Dim tahun As Integer
        Dim penambahtahun As Integer = 0
        Dim EffectiveInterestP As Double = CDbl(getFieldValue("SELECT EffectiveInterestP from Application Where ApplicationID='" & NoAplikasi & "'"))
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
        StrSQL = ""
        StrSQL = "INSERT INTO ContractDetail (ContractID,JatuhTempo,Angsuran,Sp,Si,Op,Oi,[index]) Values("
        StrSQL &= "'" & CStr(antisqli(txtKontrakID.Text)) & "',"
        StrSQL &= "'" & CStr(JatuhTempo) & "',"
        StrSQL &= "" & CDbl(angsuran) & ","
        StrSQL &= "" & Math.Round(sp) & ","
        StrSQL &= "" & Math.Round(si) & ","
        StrSQL &= "" & Math.Round(op) & ","
        StrSQL &= "" & Math.Round(oi) & ","
        StrSQL &= "" & index + 1 & ")"


        RunSQL(StrSQL, 0)



    End Sub
#End Region
    Private Sub FillDataBpkb(ByVal NoBpkb As String)
        StrSQL = ""
        StrSQL = "SELECT TOP 1 *FROM Bpkb WHERE NoBpkb = '" & antisqli(NoBpkb) & "' "
        RunSQL(StrSQL, 1)
        If dt.Rows.Count > 0 Then

            Select Case txtAplikasiTipe.Text
                Case "Dana Tunai"
                    OldBpkb = txtDTBpkbNo.Text
                    txtDTBpkbNama.Text = dt.Rows(0)("NamaBpkb").ToString()
                    txtDTBpknNopol.Text = dt.Rows(0)("NomorPolisi").ToString()
                    txtDTBpkbMesin.Text = dt.Rows(0)("NomorMesin").ToString()
                    txtDTBPKBRangka.Text = dt.Rows(0)("NomorRangka").ToString()
                    txtDTBpkbWarna.Text = dt.Rows(0)("Warna").ToString()
                    dtpDTBpkbKeluar.Value = dt.Rows(0)("TglKeluar").ToString()
                    dtpDTBpkbMasuk.Value = dt.Rows(0)("TglMasuk").ToString()
                    txtDTBpkbPengambil.Text = dt.Rows(0)("Pengambil").ToString()
                    cmbDTBpkbStatus.SelectedValue = dt.Rows(0)("Status").ToString()
                    txtDTBpkbAlamat.Text = dt.Rows(0)("Alamat").ToString()
                    txtDTBpkbRT.Text = dt.Rows(0)("RT").ToString()
                    txtDTBpkbRW.Text = dt.Rows(0)("RW").ToString()
                    cmbDTBpkbKota.Text = detailAlamat(dt.Rows(0)("kodepos").ToString()).kota
                    cmbDTBpkbKecamatan.Text = detailAlamat(dt.Rows(0)("kodepos").ToString()).kecamatan
                    cmbDTBpkbKelurahan.Text = detailAlamat(dt.Rows(0)("kodepos").ToString()).kelurahan
                Case "Motor Baru"
                    OldBpkb = txtMBBpkbNo.Text
                    txtMBBpkbNama.Text = dt.Rows(0)("NamaBpkb").ToString()
                    txtMBBpkbNopol.Text = dt.Rows(0)("NomorPolisi").ToString()
                    txtMBBpkbMesin.Text = dt.Rows(0)("NomorMesin").ToString()
                    txtMbBpkbRangka.Text = dt.Rows(0)("NomorRangka").ToString()
                    txtMBBpkbWarna.Text = dt.Rows(0)("Warna").ToString()
                    dtpMBBpkbKeluar.Value = dt.Rows(0)("TglKeluar").ToString()
                    dtpMbBpkbMasuk.Value = dt.Rows(0)("TglMasuk").ToString()
                    txtMBBpkbPengambil.Text = dt.Rows(0)("Pengambil").ToString()
                    cmbMBBpkbStatus.SelectedValue = dt.Rows(0)("Status").ToString()
                    txtMBBpkbAlamat.Text = dt.Rows(0)("Alamat").ToString()
                    txtMBBpkbRT.Text = dt.Rows(0)("RT").ToString()
                    txtMBBpkbRW.Text = dt.Rows(0)("RW").ToString()
                    cmbMBBpkbKota.Text = detailAlamat(dt.Rows(0)("kodepos").ToString()).kota
                    cmbMBBpkbKecamatan.Text = detailAlamat(dt.Rows(0)("kodepos").ToString()).kecamatan
                    cmbMBBpkbKelurahan.Text = detailAlamat(dt.Rows(0)("kodepos").ToString()).kelurahan

            End Select
        End If
    End Sub

    Private Sub UpdateBpkb(ByVal NoBpkb As String)

        Dim newBpkb As String = ""
        Dim namabpkb As String = ""
        Dim nomorPolisi As String = ""
        Dim nomorMesin As String = ""
        Dim nomorRangka As String = ""
        Dim Warna As String = ""
        Dim TglMasuk As Date = Now
        Dim TglKeluar As Date = Now
        Dim Pengambil As String = ""
        Dim status As String = ""
        Dim alamat As String = ""
        Dim kodepos As String = ""
        Dim rt As String = ""
        Dim rw As String = ""

        Select Case txtAplikasiTipe.Text
            Case "Dana Tunai"
                newBpkb = antisqli(txtDTBpkbNo.Text)
                namabpkb = antisqli(txtDTBpkbNama.Text)
                nomorPolisi = antisqli(txtDTBpknNopol.Text)
                nomorMesin = antisqli(txtDTBpkbMesin.Text)
                nomorRangka = antisqli(txtDTBPKBRangka.Text)
                Warna = antisqli(txtDTBpkbWarna.Text)
                TglMasuk = dtpDTBpkbMasuk.Value.Date
                TglKeluar = dtpDTBpkbKeluar.Value.Date
                Pengambil = antisqli(txtDTBpkbPengambil.Text)
                status = cmbDTBpkbStatus.SelectedValue
                alamat = antisqli(txtDTBpkbAlamat.Text)
                kodepos = cmbDTBpkbKelurahan.SelectedValue.ToString()
                rt = antisqli(txtDTBpkbRT.Text)
                rw = antisqli(txtDTBpkbRW.Text)
            Case "Motor Baru"
                newBpkb = antisqli(txtMBBpkbNo.Text)
                namabpkb = antisqli(txtMBBpkbNama.Text)
                nomorPolisi = antisqli(txtMBBpkbNopol.Text)
                nomorMesin = antisqli(txtMBBpkbMesin.Text)
                nomorRangka = antisqli(txtMbBpkbRangka.Text)
                Warna = antisqli(txtMBBpkbWarna.Text)
                TglMasuk = dtpMbBpkbMasuk.Value.Date
                TglKeluar = dtpMBBpkbKeluar.Value.Date
                Pengambil = antisqli(txtMBBpkbPengambil.Text)
                status = cmbMBBpkbStatus.SelectedValue
                alamat = antisqli(txtMBBpkbAlamat.Text)
                kodepos = cmbMBBpkbKelurahan.SelectedValue.ToString()
                rt = antisqli(txtMBBpkbRT.Text)
                rw = antisqli(txtMBBpkbRW.Text)

        End Select

        If NoBpkb = "" Then
            StrSQL = ""
            StrSQL = "INSERT INTO BPKB (NoBpkb,NamaBpkb,NomorPolisi,NomorMesin,NomorRangka,Warna,TglMasuk,TglKeluar,Pengambil,Status,Alamat,Kodepos,RT,RW) "
            StrSQL &= "VALUES ("
            StrSQL &= "'" & newBpkb & "',"
            StrSQL &= "'" & namabpkb & "',"
            StrSQL &= "'" & nomorPolisi & "',"
            StrSQL &= "'" & nomorMesin & "',"
            StrSQL &= "'" & nomorRangka & "',"
            StrSQL &= "'" & Warna & "',"
            StrSQL &= "'" & TglMasuk & "',"
            StrSQL &= "'" & TglKeluar & "',"
            StrSQL &= "'" & Pengambil & "',"
            StrSQL &= "'" & status & "',"
            StrSQL &= "'" & alamat & "',"
            StrSQL &= "'" & kodepos & "',"
            StrSQL &= "'" & rt & "',"
            StrSQL &= "'" & rw & "')"
            RunSQL(StrSQL, 0)
        Else
            StrSQL = ""
            StrSQL = "UPDATE BPKB SET "
            StrSQL &= "NoBpkb = '" & newBpkb & "', "
            StrSQL &= "NamaBpkb = '" & namabpkb & "', "
            StrSQL &= "NomorPolisi = '" & nomorPolisi & "', "
            StrSQL &= "NomorMesin = '" & nomorMesin & "', "
            StrSQL &= "NomorRangka = '" & nomorRangka & "', "
            StrSQL &= "Warna = '" & Warna & "', "
            StrSQL &= "tglmasuk = '" & TglMasuk & "', "
            StrSQL &= "TglKeluar = '" & TglKeluar & "', "
            StrSQL &= "Pengambil = '" & Pengambil & "', "
            StrSQL &= "status = '" & status & "', "
            StrSQL &= "Alamat = '" & alamat & "', "
            StrSQL &= "Kodepos = '" & kodepos & "', "
            StrSQL &= "RT = '" & rt & "', "
            StrSQL &= "Rw = '" & rw & "' "
            StrSQL &= "WHERE NoBpkb = '" & OldBpkb & "' "
            RunSQL(StrSQL, 0)
        End If
    End Sub
#Region "Collateral Dana Tunai"
    Private Sub btnKalkulasiDanaTunai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKalkulasiDanaTunai.Click
        KalkulasiDanaTunai()
    End Sub

    Private Sub KalkulasiDanaTunai()
        If txtDTPinjaman.Text <> "0" Then
            Dim tempBungaFlat As Double = 0
            Dim tempBungaPengali As Double = 0
            txtDTAdminMurni.Text = Format(CDbl(txtDTAdminKredit.Text), "#,##0")
            txtDTPokok.Text = Format(CDbl(txtDTPinjaman.Text) + CDbl(txtDTAdminKredit.Text) + CDbl(txtDTPremiAdmin.Text), "#,##0")
            tempBungaFlat = ((((CDbl(txtDTTenor.Text) * (CDbl(txtDTTingkatBunga.Text) / 1200)) / (1 - (1 + (CDbl(txtDTTingkatBunga.Text) / 1200)) ^ (-1 * CDbl(txtDTTenor.Text)))) - 1) * (12 / CDbl(txtDTTenor.Text))) * 100
            txtDTBungaFlat.Text = Format(tempBungaFlat, "#,##0.00")
            tempBungaPengali = CDbl(tempBungaFlat) * (CDbl(txtDTTenor.Text) / 12)
            txtDTBungaPengali.Text = Format(tempBungaPengali, "#,##0.00")
            txtDTBunga.Text = Format(CDbl(txtDTPokok.Text) * CDbl(tempBungaPengali) / 100, "#,##0")
            txtDTTotalHutang.Text = Format(CDbl(txtDTPokok.Text) + CDbl(txtDTBunga.Text), "#,##0")
            txtDTAngsuran.Text = Format(Math.Ceiling(CDbl(txtDTTotalHutang.Text) / (CDbl(txtDTTenor.Text) * 1000)) * 1000, "#,##0")
        End If
    End Sub

    Private Sub FillBpkbCollateral(ByVal NoBpkb As String)
        StrSQL = ""
        StrSQL = "SELECT * FROM V_BpkbDetail WHERE NoBpkb = '" & NoBpkb & "'"
        RunSQL(StrSQL, 1)
        If dt.Rows.Count > 0 Then
            txtDTBpkbNama.Text = dt.Rows(0)("NamaBpkb").ToString()
            txtDTBpkbMesin.Text = dt.Rows(0)("NomorMesin").ToString()
            txtDTBpkbWarna.Text = dt.Rows(0)("Warna").ToString()
            txtDTBpknNopol.Text = dt.Rows(0)("NomorPolisi").ToString()


        End If
    End Sub
#End Region
#Region "Collateral KTA"
    Private Sub KalkulasiKTA()
        Try
            Dim Pinjaman As Double = 0
            Dim tenor As Double = 0
            Dim TingkatBunga As Double = 0
            Dim tempFlatInterestP As Double = 0
            Dim tempMultiplierInterestP As Double = 0

            If txtKTAPinjaman.Text = "" Then
                txtKTAPinjaman.Text = 0
                Pinjaman = 0
            Else
                Pinjaman = txtKTAPinjaman.Text
            End If

            If txtKTATenor.Text = "" Then
                txtKTATenor.Text = 0
                tenor = 0
            Else
                tenor = txtKTATenor.Text
            End If

            If txtKTATingkatBunga.Text = "" Then
                txtKTATingkatBunga.Text = 0
                TingkatBunga = 0
            Else
                TingkatBunga = txtKTATingkatBunga.Text
            End If

            txtKTAPokok.Text = Format(CDbl(Pinjaman), "#,##0")
            tempFlatInterestP = ((((CDbl(tenor) * (CDbl(TingkatBunga) / 1200)) / (1 - (1 + (CDbl(TingkatBunga) / 1200)) ^ (-1 * CDbl(tenor)))) - 1) * (12 / CDbl(tenor))) * 100
            txtKTABungaFlat.Text = Format(tempFlatInterestP, "#,##0.00")
            tempMultiplierInterestP = CDbl(tempFlatInterestP) * (CDbl(tenor) / 12)
            txtKTABungaPengali.Text = Format(tempMultiplierInterestP, "#,##0.00")
            txtKTABunga.Text = Format(CDbl(txtKTAPokok.Text) * CDbl(tempMultiplierInterestP) / 100, "#,##0")
            txtKTATotalHutang.Text = Format(CDbl(txtKTAPokok.Text) + CDbl(txtKTABunga.Text), "#,##0")
            txtKTAAngsuran.Text = Format(Math.Ceiling(CDbl(txtKTATotalHutang.Text) / (CDbl(tenor) * 1000)) * 1000, "#,##0")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnKTAKalkulasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKTAKalkulasi.Click
        KalkulasiKTA()
    End Sub

    Private Sub DisableDTComponent()
        txtDTPinjaman.Enabled = False
        txtDTTenor.Enabled = False
        txtDTPremiAsuransi.Enabled = False
        txtDTAdmin.Enabled = False
        txtDTPremiAdmin.Enabled = False
        txtDTTingkatBunga.Enabled = False
        txtDTAdminKredit.Enabled = False
        btnKalkulasiDanaTunai.Enabled = False
        dtpDTAngsuran1.Enabled = False
        dtpDTBast.Enabled = False
        dtpDTKontrak.Enabled = False
        txtDTBpkbNo.Enabled = False
        txtDTBpkbMesin.Enabled = False
        txtDTBpkbNama.Enabled = False
        txtDTBpkbPengambil.Enabled = False
        txtDTBpkbWarna.Enabled = False
        txtDTBpknNopol.Enabled = False
        txtDTBPKBRangka.Enabled = False
        txtDTTahun.Enabled = False
        txtDTKendaraan.Enabled = False
        txtDTTipe.Enabled = False
        dtpDTBpkbKeluar.Enabled = False
        dtpDTBpkbMasuk.Enabled = False
        cmbDTBpkbStatus.Enabled = False
        txtDTBpkbAlamat.Enabled = False
        txtDTBpkbRT.Enabled = False
        txtDTBpkbRW.Enabled = False
        cmbDTBpkbKecamatan.Enabled = False
        cmbDTBpkbKota.Enabled = False
        cmbDTBpkbKelurahan.Enabled = False


    End Sub

    Private Sub EnableDTComponent()
        txtDTPinjaman.Enabled = True
        txtDTTenor.Enabled = True
        txtDTPremiAsuransi.Enabled = True
        txtDTAdmin.Enabled = True
        txtDTPremiAdmin.Enabled = True
        txtDTTingkatBunga.Enabled = True
        txtDTAdminKredit.Enabled = True
        btnKalkulasiDanaTunai.Enabled = True
        dtpDTAngsuran1.Enabled = True
        dtpDTBast.Enabled = True
        dtpDTKontrak.Enabled = True
        txtDTBpkbNo.Enabled = True
        txtDTBpkbMesin.Enabled = True
        txtDTBpkbNama.Enabled = True
        txtDTBpkbPengambil.Enabled = True
        txtDTBpkbWarna.Enabled = True
        txtDTBpknNopol.Enabled = True
        txtDTBPKBRangka.Enabled = True
        txtDTTahun.Enabled = True
        txtDTKendaraan.Enabled = True
        txtDTTipe.Enabled = True
        dtpDTBpkbKeluar.Enabled = True
        dtpDTBpkbMasuk.Enabled = True
        cmbDTBpkbStatus.Enabled = True
        txtDTBpkbAlamat.Enabled = True
        txtDTBpkbRT.Enabled = True
        txtDTBpkbRW.Enabled = True
        cmbDTBpkbKecamatan.Enabled = True
        cmbDTBpkbKota.Enabled = True
        cmbDTBpkbKelurahan.Enabled = True
    End Sub

    Private Sub DisableKTAComponent()
        txtKTAPinjaman.Enabled = False
        txtKTATenor.Enabled = False
        txtKTATingkatBunga.Enabled = False
        btnKTAKalkulasi.Enabled = False
        'btnKTACollateralUpdate.Enabled = False
        dtpKTAAngsuran.Enabled = False
        dtpKTABast.Enabled = False
        dtpKTAKontrak.Enabled = False
    End Sub
    Private Sub EnableKTAComponent()
        txtKTAPinjaman.Enabled = True
        txtKTATenor.Enabled = True
        txtKTATingkatBunga.Enabled = True
        btnKTAKalkulasi.Enabled = True
        'btnKTACollateralUpdate.Enabled = True
        dtpKTAAngsuran.Enabled = True
        dtpKTABast.Enabled = True
        dtpKTAKontrak.Enabled = True
    End Sub
    Private Sub ClearKTAComponent()
        txtKTAPinjaman.Clear()
        txtKTATenor.Clear()
        txtKTATingkatBunga.Clear()
        txtKTABunga.Clear()
        txtKTABungaFlat.Clear()
        txtKTABungaPengali.Clear()
        txtKTAPokok.Clear()
        txtKTATenor.Clear()
        txtKTAAngsuran.Clear()
    End Sub

    Private Sub EnableELComponent()
        txtELNamaBarang.Enabled = True
        txtELKeterangan.Enabled = True
        txtELNomorSeri.Enabled = True
        txtELHarga.Enabled = True
        txtELTenor.Enabled = True
        txtELTingkatBunga.Enabled = True
        dtpELAngsuran.Enabled = True
        dtpELBast.Enabled = True
        dtpELKontrak.Enabled = True
    End Sub

    Private Sub DisableELComponent()
        txtELNamaBarang.Enabled = False
        txtELKeterangan.Enabled = False
        txtELNomorSeri.Enabled = False
        txtELHarga.Enabled = False
        txtELTenor.Enabled = False
        txtELTingkatBunga.Enabled = False
        dtpELAngsuran.Enabled = False
        dtpELBast.Enabled = False
        dtpELKontrak.Enabled = False
    End Sub

    Private Sub ClearELComponent()
        txtELNamaBarang.Text = ""
        txtELKeterangan.Text = ""
        txtELNomorSeri.Text = ""
        txtELHarga.Text = 0
        txtELTenor.Text = 0
        txtELBungaPengali.Text = 0
        txtELBungaFlat.Text = 0
        txtELBunga.Text = 0
        txtELPokok.Text = 0
        txtELAngsuran.Text = 0
        txtELTingkatBunga.Text = 0
        txtELTotalHutang.Text = 0

    End Sub
#End Region
#Region "Collateral Elektronik"
    Private Sub KalkulasiElektronik()
        Dim pinjaman As Double
        Dim Tenor As Double
        Dim TingkatBungaEfektif As Double

        If txtELHarga.Text = "" Then
            pinjaman = 0
            txtELHarga.Text = 0
        Else
            pinjaman = CDbl(txtELHarga.Text)
        End If

        If txtELTenor.Text = "" Then
            Tenor = 0
            txtELTenor.Text = 0
        Else
            Tenor = CDbl(txtELTenor.Text)
        End If

        If txtELTingkatBunga.Text = "" Then
            TingkatBungaEfektif = 0
            txtELTingkatBunga.Text = 0
        Else
            TingkatBungaEfektif = CDbl(txtELTingkatBunga.Text)
        End If

            Dim tempFlatInterestP As Double = 0
            Dim tempMultiplierInterestP As Double = 0
        txtELPokok.Text = Format(CDbl(pinjaman), "#,##0")
        tempFlatInterestP = ((((CDbl(Tenor) * (CDbl(TingkatBungaEfektif) / 1200)) / (1 - (1 + (CDbl(TingkatBungaEfektif) / 1200)) ^ (-1 * CDbl(Tenor)))) - 1) * (12 / CDbl(Tenor))) * 100
        txtELBungaFlat.Text = Format(tempFlatInterestP, "#,##0.00")
        tempMultiplierInterestP = CDbl(tempFlatInterestP) * (CDbl(Tenor) / 12)
        txtELBungaPengali.Text = Format(tempMultiplierInterestP, "#,##0.00")
        txtELBunga.Text = Format(CDbl(txtELPokok.Text) * CDbl(tempMultiplierInterestP) / 100, "#,##0")
        txtELTotalHutang.Text = Format(CDbl(txtELPokok.Text) + CDbl(txtELBunga.Text), "#,##0")
        txtELAngsuran.Text = Format(Math.Ceiling(CDbl(txtELTotalHutang.Text) / (CDbl(Tenor) * 1000)) * 1000, "#,##0")

    End Sub
    Private Sub btnELKalkulasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnELKalkulasi.Click
        KalkulasiElektronik()
    End Sub
#End Region
#Region "Collateral Motor Baru"
    Private Sub KalkulasiMotorBaru()
        Try
            Dim isDpPlus As Boolean
            Dim isDealerSubs As Boolean
            Dim pinjaman As Double
            Dim downpayment As Double
            Dim adminkredit As Double
            Dim premiadmin As Double
            Dim subsidiDealer As Double

            Dim tempPureDownPayment As Double



            If txtMBPinjaman.Text = "" Then
                pinjaman = 0
                txtMBPinjaman.Text = 0
            Else
                pinjaman = CDbl(txtMBPinjaman.Text)
            End If

            If txtMBDownPayment.Text = "" Then
                downpayment = 0
                txtMBDownPayment.Text = 0
            Else
                downpayment = CDbl(txtMBDownPayment.Text)
            End If

            If txtMBAdminKredit.Text = "" Then
                adminkredit = 0
                txtMBAdminKredit.Text = 0
            Else
                adminkredit = CDbl(txtMBAdminKredit.Text)
            End If

            If txtMBAdminPremi.Text = "" Then
                premiadmin = 0
                txtMBAdminPremi.Text = 0
            Else
                premiadmin = CDbl(txtMBAdminPremi.Text)
            End If

            If txtMBSubsidiDealer.Text = "" Then
                subsidiDealer = 0
                txtMBSubsidiDealer.Text = 0
            Else
                subsidiDealer = CDbl(txtMBSubsidiDealer.Text)
            End If


            tempPureDownPayment = downpayment - adminkredit - premiadmin

            If tempPureDownPayment < 0 Then
                isDpPlus = False
            Else
                isDpPlus = True

            End If


            If txtMBPinjaman.Text <> "0" AndAlso txtMBDownPayment.Text <> "0" Then

                'Dim tempPureDownPayment As Double = CDbl(txtDownPayment.Text) - CDbl(txtAdminKredit.Text) - CDbl(txtPremiAdmin.Text)
                Dim tempFlatInterestP As Double = 0
                Dim tempMultiplierInterestP As Double = 0

                If isDpPlus Then
                    txtMBPureDownPayment.Text = Format(tempPureDownPayment, "#,##0")
                    txtMBMarketingCost.Clear()
                    txtMBMarketingCost.Text = "0"
                    txtMBAdminMurni.Text = Format(CDbl(adminkredit) - CDbl(subsidiDealer), "#,##0")
                    txtMBDealerTransfer.Text = Format(CDbl(pinjaman) - CDbl(downpayment) + CDbl(subsidiDealer), "#,##0")
                    txtMBPureDownPaymentP.Text = Format((CDbl(txtMBPureDownPayment.Text) / CDbl(pinjaman)) * 100, "#,##0.00")
                Else
                    If CDbl(tempPureDownPayment) < 0 Then
                        txtMBMarketingCost.Text = Format(-1 * tempPureDownPayment, "#,##0")
                        txtMBPureDownPayment.Text = "0"
                        txtMBAdminKredit.Text = Format(adminkredit + tempPureDownPayment, "#,##0")
                        isDealerSubs = True
                    End If

                    If isDealerSubs And subsidiDealer <> "0" Then
                        txtMBSubsidiDealer.Text = Format(CDbl(subsidiDealer) - CDbl(txtMBMarketingCost.Text), "#,##0")
                        isDealerSubs = False
                    End If
                    txtMBAdminMurni.Text = Format(CDbl(adminkredit) - CDbl(txtMBSubsidiDealer.Text), "#,##0")
                    txtMBDealerTransfer.Text = Format(CDbl(pinjaman) - CDbl(downpayment) + CDbl(txtMBSubsidiDealer.Text) + CDbl(txtMBMarketingCost.Text), "#,##0")
                End If
                txtMBPureDownPaymentP.Text = Format((CDbl(txtMBPureDownPayment.Text) / CDbl(txtMBPinjaman.Text)) * 100, "#,##0.00")
                txtMBPokok.Text = Format(CDbl(txtMBPinjaman.Text) - CDbl(txtMBPureDownPayment.Text), "#,##0")
                tempFlatInterestP = ((((CDbl(txtMBTenor.Text) * (CDbl(txtMBTingkatBunga.Text) / 1200)) / (1 - (1 + (CDbl(txtMBTingkatBunga.Text) / 1200)) ^ (-1 * CDbl(txtMBTenor.Text)))) - 1) * (12 / CDbl(txtMBTenor.Text))) * 100
                txtMBBungaFlat.Text = Format(tempFlatInterestP, "#,##0.00")
                tempMultiplierInterestP = CDbl(tempFlatInterestP) * (CDbl(txtMBTenor.Text) / 12)
                txtMBBungaPengali.Text = Format(tempMultiplierInterestP, "#,##0.00")
                txtMBBunga.Text = Format(CDbl(txtMBPokok.Text) * CDbl(tempMultiplierInterestP) / 100, "#,##0")
                txtMBTotalHutang.Text = Format(CDbl(txtMBPokok.Text) + CDbl(txtMBBunga.Text), "#,##0")
                txtMBAngsuran.Text = Format(Math.Ceiling(CDbl(txtMBTotalHutang.Text) / (CDbl(txtMBTenor.Text) * 1000)) * 1000, "#,##0")

            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub EnableMBComponent()
        txtMBPinjaman.Enabled = True
        txtMBDownPayment.Enabled = True
        txtMBTenor.Enabled = True
        txtMBAdmin.Enabled = True
        txtMBAdminKredit.Enabled = True
        txtMBAdminMurni.Enabled = False
        txtMBAdminPremi.Enabled = True
        txtMBTingkatBunga.Enabled = True
        txtMBSubsidiDealer.Enabled = True
        txtMBBungaPengali.Enabled = False
        txtMBBungaPengali.Enabled = False
        txtMBDealerTransfer.Enabled = False
        txtMBMarketingCost.Enabled = False
        txtMBPureDownPayment.Enabled = False
        txtMBPureDownPaymentP.Enabled = False
        txtMBPokok.Enabled = False
        txtMBBunga.Enabled = False
        txtMBTotalHutang.Enabled = False
        txtMBAngsuran.Enabled = False
        txtMBBpkbNo.Enabled = True
        txtMBBpkbAlamat.Enabled = True
        txtMBBpkbMesin.Enabled = True
        txtMBBpkbNama.Enabled = True
        txtMBBpkbNopol.Enabled = True
        txtMBBpkbPengambil.Enabled = True
        txtMbBpkbRangka.Enabled = True
        txtMBBpkbRT.Enabled = True
        txtMBBpkbRW.Enabled = True
        txtMBBpkbWarna.Enabled = True
        txtMBKendaraan.Enabled = True
        txtMBTahun.Enabled = True
        txtMBTipe.Enabled = True
        dtpMBAngsuran.Enabled = True
        dtpMBBast.Enabled = True
        dtpMBKontrak.Enabled = True
        dtpMBBpkbKeluar.Enabled = True
        dtpMbBpkbMasuk.Enabled = True
        btnMBKalkulasi.Enabled = True
        cmbMBBpkbKota.Enabled = True
        cmbMBBpkbKecamatan.Enabled = True
        cmbMBBpkbKelurahan.Enabled = True
        cmbMBBpkbStatus.Enabled = True
        txtMBPremiAsuransi.Enabled = True
        txtAplikasiDokumen.Enabled = True
    End Sub
    Private Sub DisableMBComponent()
        txtMBPinjaman.Enabled = False
        txtMBDownPayment.Enabled = False
        txtMBTenor.Enabled = False
        txtMBAdmin.Enabled = False
        txtMBAdminKredit.Enabled = False
        txtMBAdminMurni.Enabled = False
        txtMBAdminPremi.Enabled = False
        txtMBTingkatBunga.Enabled = False
        txtMBSubsidiDealer.Enabled = False
        txtMBBungaPengali.Enabled = False
        txtMBBungaPengali.Enabled = False
        txtMBDealerTransfer.Enabled = False
        txtMBMarketingCost.Enabled = False
        txtMBPureDownPayment.Enabled = False
        txtMBPureDownPaymentP.Enabled = False
        txtMBPokok.Enabled = False
        txtMBBunga.Enabled = False
        txtMBTotalHutang.Enabled = False
        txtMBAngsuran.Enabled = False
        txtMBBpkbNo.Enabled = False
        txtMBBpkbAlamat.Enabled = False
        txtMBBpkbMesin.Enabled = False
        txtMBBpkbNama.Enabled = False
        txtMBBpkbNopol.Enabled = False
        txtMBBpkbPengambil.Enabled = False
        txtMbBpkbRangka.Enabled = False
        txtMBBpkbRT.Enabled = False
        txtMBBpkbRW.Enabled = False
        txtMBBpkbWarna.Enabled = False
        txtMBKendaraan.Enabled = False
        txtMBTahun.Enabled = False
        txtMBTipe.Enabled = False
        dtpMBAngsuran.Enabled = False
        dtpMBBast.Enabled = False
        dtpMBKontrak.Enabled = False
        dtpMBBpkbKeluar.Enabled = False
        dtpMbBpkbMasuk.Enabled = False
        btnMBKalkulasi.Enabled = False
        cmbMBBpkbKota.Enabled = False
        cmbMBBpkbKecamatan.Enabled = False
        cmbMBBpkbKelurahan.Enabled = False
        cmbMBBpkbStatus.Enabled = False
        txtMBPremiAsuransi.Enabled = False
        txtAplikasiDokumen.Enabled = False
    End Sub
    Private Sub ClearMBComponent()
        txtMBPremiAsuransi.Clear()
        txtMBPinjaman.Clear()
        txtMBDownPayment.Clear()
        txtMBTenor.Clear()
        txtMBAdmin.Clear()
        txtMBAdminKredit.Clear()
        txtMBAdminMurni.Clear()
        txtMBAdminPremi.Clear()
        txtMBTingkatBunga.Clear()
        txtMBSubsidiDealer.Clear()
        txtMBBungaPengali.Clear()
        txtMBBungaPengali.Clear()
        txtMBDealerTransfer.Clear()
        txtMBMarketingCost.Clear()
        txtMBPureDownPayment.Clear()
        txtMBPureDownPaymentP.Clear()
        txtMBPokok.Clear()
        txtMBBunga.Clear()
        txtMBTotalHutang.Clear()
        txtMBAngsuran.Clear()
        txtMBBpkbNo.Clear()
        txtMBBpkbAlamat.Clear()
        txtMBBpkbMesin.Clear()
        txtMBBpkbNama.Clear()
        txtMBBpkbNopol.Clear()
        txtMBBpkbPengambil.Clear()
        txtMbBpkbRangka.Clear()
        txtMBBpkbRT.Clear()
        txtMBBpkbRW.Clear()
        txtMBBpkbWarna.Clear()
        txtMBKendaraan.Clear()
        txtMBTahun.Clear()
        txtMBTipe.Clear()
        txtAplikasiDokumen.Clear()

    End Sub

#End Region

End Class