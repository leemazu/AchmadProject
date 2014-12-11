Imports DevExpress.XtraEditors.Repository
Imports System.Data.SqlClient

Public Class kontrakDanaTunai

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplikasiCari.Click
        TabKontrakMesin.txtFlag.Text = "1"
        TabKontrakMesin.StartPosition = FormStartPosition.Manual
        TabKontrakMesin.Location = New Point(0, 0)
        TabKontrakMesin.Show()
        TabKontrakMesin.BringToFront()

    End Sub
#Region "Grid"
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
            StrSQL &= String.Format("WHERE ContractID='{0}' ", txtKontrakID.Text)
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
#End Region

    

    

    
    Private Sub kontrakDanaTunai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
    End Sub

#Region "Form Utility"
    Private Sub ClearForm()
        ComboBoxFillData()
        setTanggal(dtpAplikasiTanggal)
        setTanggal(dtpAnggotaTglLahir)

        txtKontrakStatus.Enabled = False
        txtKontrakStatus.Clear()

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


        FillCombobox("SpEmployee_CBO 'CL'", cmbKolektor, 2, dtKolektor)
        FillCombobox("Sp_Reference_CBO 'POS'", cmbAplikasiPos, 2, dtPos)
        FillCombobox("SpEmployee_CBO 'CA'", cmbAplikasiCa, 2, dtCA)
        FillCombobox("SpEmployee_CBO 'SY'", cmbAplikasiSy, 2, dtSY)
        FillCombobox("SpEmployee_CBO 'SM'", cmbAplikasiSm, 2, dtSM)
        FillCombobox("Sp_Reference_CBO 'GEN'", cmbAnggotaSex, 2, dtSex)
        FillCombobox("Sp_Reference_CBO 'TWC'", cmbAnggotaPekerjaan, 2, dtWorkID)

        FillCombobox("select*from v_kota ORDer BY city asc", cmbKtpKota, 1, dtKtpKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbKtpKota.Text + "' ORDER BY [SubDistrict] ASC", cmbKtpKecamatan, 1, dtKtpKecamatan)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKtpKecamatan.Text + "' ORDER BY [Village] ASC", cmbKtpKelurahan, 2, dtKtpKelurahan)

        FillCombobox("select*from v_kota ORDer BY city asc", cmbTagihKota, 1, dtTagihKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbTagihKota.Text + "' ORDER BY [SubDistrict] ASC", cmbTagihKecamatan, 1, dtTagihKecamatan)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbTagihKecamatan.Text + "' ORDER BY [Village] ASC", cmbTagihKelurahan, 2, dtTagihKelurahan)

        FillCombobox("select*from v_kota ORDer BY city asc", cmbKantorKota, 1, dtKantorKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbKantorKota.Text + "' ORDER BY [SubDistrict] ASC", cmbKantorKecamatan, 1, dtKantorKecamatan)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbKantorKecamatan.Text + "' ORDER BY [Village] ASC", cmbKantorKelurahan, 2, dtKantorKelurahan)

        FillCombobox("select*from v_kota ORDer BY city asc", cmbDaruratKota, 1, dtDaruratKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbDaruratKota.Text + "' ORDER BY [SubDistrict] ASC", cmbDaruratKecamatan, 1, dtDaruratKecamatan)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbDaruratKecamatan.Text + "' ORDER BY [Village] ASC", cmbDaruratKelurahan, 2, dtDaruratKelurahan)

        FillCombobox("select*from v_kota ORDer BY city asc", cmbBaruKota, 1, dtBaruKota)
        FillCombobox("select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + cmbBaruKota.Text + "' ORDER BY [SubDistrict] ASC", cmbBaruKecamatan, 1, dtBaruKecamatan)
        FillCombobox("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbBaruKecamatan.Text + "' ORDER BY [Village] ASC", cmbBaruKelurahan, 2, dtBaruKelurahan)

    End Sub

    Private Sub ComboKotaSelectedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKtpKota.SelectedIndexChanged, cmbKantorKota.SelectedIndexChanged, cmbTagihKota.SelectedIndexChanged, cmbDaruratKota.SelectedIndexChanged, cmbBaruKota.SelectedIndexChanged
        Dim tblKec1 As New DataTable
        Dim tblKec2 As New DataTable
        Dim tblKec3 As New DataTable
        Dim tblKec4 As New DataTable
        Dim tblKec5 As New DataTable
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
        End Select
    End Sub

    Private Sub ComboKecamatanSelectedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKantorKecamatan.SelectedIndexChanged, cmbTagihKecamatan.SelectedIndexChanged, cmbKtpKecamatan.SelectedIndexChanged, cmbDaruratKecamatan.SelectedIndexChanged, cmbBaruKecamatan.SelectedIndexChanged
        Dim tblKel1 As New DataTable
        Dim tblKel2 As New DataTable
        Dim tblKel3 As New DataTable
        Dim tblKel4 As New DataTable
        Dim tblKel5 As New DataTable
        'tblKec.Rows.Clear()

        Select Case sender.Name

            Case "cmbPemKec"
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

            Case "cmbKontakKec"
                tblKel4.Rows.Clear()
                With cmbDaruratKelurahan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbDaruratKecamatan.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbDaruratKelurahan, 2, tblKel4)
                End With

            Case "cmbBpkbKec"
                tblKel5.Rows.Clear()
                With cmbBaruKelurahan
                    .DataSource = Nothing
                    StrSQL = ""
                    StrSQL = "select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + cmbBaruKecamatan.Text + "' ORDER BY [Village] ASC"
                    FillCombobox(StrSQL, cmbBaruKelurahan, 2, tblKel5)
                End With
        End Select
    End Sub

    Private Sub DisableComponent()
        cmbKolektor.Enabled = False
        txtAplikasiTipe.Enabled = False
        txtKontrakStatus.Enabled = False
        txtAplikasiID.Enabled = False
        dtpAplikasiTanggal.Enabled = False
        cmbAplikasiPos.Enabled = False
        cmbAplikasiCa.Enabled = False

    End Sub

#End Region





    Private Sub txtKontrakID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKontrakID.TextChanged
        Try
            If txtKontrakID.Text.Length > 7 Then
                StrSQL = ""
                StrSQL = "SELECT * FROM Contract WHERE ContractID = '" & antisqli(txtKontrakID.Text) & "' "
                If dt.Rows.Count = 1 Then
                    FillForm(txtKontrakID.Text)
                Else
                    ClearForm()
                End If
            Else
                ClearForm()
            End If
        Catch ex As Exception
            SaveErrorLog(ex.Message, "Form Kontrak")
        End Try
    End Sub

    Private Sub FillForm(ByVal NomorKontrak As String)
        Try
            StrSQL = ""
            StrSQL = "SELECT DISTINCT * FROM V_ContractDetail WHERE ContractID ='" & NomorKontrak & "' "
            RunSQL(StrSQL, 1)
            cmbKolektor.SelectedValue = dt.Rows(0)("Collector").ToString()
            txtAplikasiTipe.Text = dt.Rows(0)("Tipe").ToString()
            txtKontrakStatus.Text = dt.Rows(0)("Status Kontrak").ToString()
            txtAplikasiID.Text = dt.Rows(0)("Nomor Aplikasi").ToString()
            dtpAplikasiTanggal.Text = dt.Rows(0)("Tanggal Aplikasi").ToString()

        Catch ex As Exception
            SaveErrorLog(ex.Message, "Form kontrak")
        End Try
      
    End Sub

End Class