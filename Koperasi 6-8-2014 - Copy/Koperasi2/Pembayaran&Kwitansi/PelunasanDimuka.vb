
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Public Class PelunasanDimuka
    Dim contract As String
    Dim ovd As Integer
    Dim totalbayar As Integer
    Dim outstanding As Integer
    Dim kwitansi As String
    Dim denda As Integer
    Dim memberID As String
    Dim ListKwitansi As RepositoryItemComboBox = New RepositoryItemComboBox
    Private Sub PelunasanDimuka_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  
        ClearForm()
        setTanggal()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmTabKontrak.txtFlag.Text = "Dimuka"
        frmTabKontrak.Show()
    End Sub

    Private Sub setTanggal()
        dtBayar.Text = Now
        dtBayar.Format = DateTimePickerFormat.Custom
        dtBayar.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub txtKontrak_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKontrak.TextChanged
        If txtKontrak.Text.Length = txtKontrak.MaxLength Then
            If FillForm() Then
                FillGrid()
                FillPelunasan()
                Button3.Enabled = True
            Else
                GridControl1.DataSource = Nothing
                ClearForm()
            End If
            '  FillForm()

        Else
            GridControl1.DataSource = Nothing
            ClearForm()
        End If
    End Sub

    Private Sub ClearForm()
        txtKontrak.Clear()
        lblMesin.Visible = True
        lblTipe.Visible = True
        txtMesin.Visible = True
        txtTipe.Visible = True
        lblMesin.Text = "No.Mesin"
        lblTipe.Text = "Tipe"
        txtHidden.Clear()
        memberID = ""
        txtTotalKekurangan.Text = 0
        txtDenda.Text = 0
        txtBayar.Text = 0
        txtSIsaPokok.Text = 0
        cmbCaraBayar.Text = "Kasir 101"
        txtKonsumen.Clear()
        txtAlamat.Clear()
        txtObjek.Clear()
        txtBulan.Clear()
        txtTenor.Clear()
        txtPinalty.Text = 0
        txtKonsumen.Clear()
        FillPIC()
        FillKwitansi()
        Button3.Enabled = False

    End Sub

    Private Sub FillPIC()
        Dim tablePIC As DataTable = Nothing
        StrSQL = ""
        StrSQL = "SELECT EmployeeID,EmployeeName FROM Employee Where PositionID = 'PC' ORDER BY EmployeeName ASC"
        FillCombobox(StrSQL, cmbPIC, 2, tablePIC)
    End Sub

    Private Function FillForm()
        StrSQL = ""
        StrSQL = "SELECT m.MemberName,m.Address "
        StrSQL &= ",'Objek'=CASE WHEN a.ApplicationTypeID = 1 THEN 'Dana Tunai'"
        StrSQL &= " WHEN a.ApplicationTypeID = 2 THEN 'Motor Baru'"
        StrSQL &= " WHEN a.ApplicationTypeID=3 THEN 'Elektronik' ELSE 'KTA' END"
        StrSQL &= ",a.EngineCode,a.MotorType,a.Tenor,"
        StrSQL &= "SUBSTRING('JAN FEB MAR APR MEI JUN JUL AGU SEP OKT NOV DES ',"
        StrSQL &= "(convert(int,month(c.BastDate)) * 4) - 3, 3) "
        StrSQL &= "+ '-' + CONVERT(nvarchar,year(c.bastdate)) as [Bulan Booking]"
        StrSQL &= ",m.MemberID as MemberID,a.MotorBrand as [NamaBarang]"
        StrSQL &= " FROM Member m,Application a,contract c where c.ContractID = a.ContractID"
        StrSQL &= " AND a.MemberID=m.MemberID"
        StrSQL &= String.Format(" AND c.ContractID='{0}'", txtKontrak.Text)
        RunSQL(StrSQL, 1)

        If dt.Rows.Count > 0 Then
            txtKonsumen.Text = CStr(dt.Rows(0)("MemberName"))
            txtAlamat.Text = CStr(dt.Rows(0)("Address"))
            txtObjek.Text = CStr(dt.Rows(0)("Objek"))
            txtBulan.Text = CStr(dt.Rows(0)("Bulan Booking"))
            txtTenor.Text = CStr(dt.Rows(0)("Tenor"))
            memberID = CStr(dt.Rows(0)("MemberID"))

            Select Case txtObjek.Text

                Case "Dana Tunai", "Motor Baru"
                    lblMesin.Visible = True
                    lblTipe.Visible = True
                    txtMesin.Visible = True
                    txtTipe.Visible = True
                    lblMesin.Text = "No.Mesin"
                    lblTipe.Text = "Tipe"
                    txtMesin.Text = CStr(dt.Rows(0)("EngineCode"))
                    txtTipe.Text = CStr(dt.Rows(0)("MotorType"))

                Case "Elektronik"
                    lblMesin.Visible = True
                    lblTipe.Visible = True
                    txtMesin.Visible = True
                    txtTipe.Visible = True
                    lblMesin.Text = "Nama Barang"
                    lblTipe.Text = "Keterangan"
                    txtMesin.Text = CStr(dt.Rows(0)("NamaBarang"))
                    txtTipe.Text = CStr(dt.Rows(0)("MotorType"))

                Case Else
                    lblMesin.Visible = False
                    lblTipe.Visible = False
                    txtMesin.Visible = False
                    txtTipe.Visible = False
            End Select
            Return True
        Else
            Return False
        End If



    End Function

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
        GridView1.Columns(12).OptionsColumn.AllowEdit = False
        GridView1.Columns("OVD").OptionsColumn.AllowEdit = False
        GridView1.Columns("Denda").OptionsColumn.AllowEdit = False
        GridView1.Columns("AMBC").OptionsColumn.AllowEdit = False
        GridView1.Columns("Outstanding Receive").OptionsColumn.AllowEdit = False
        GridView1.Columns("Outstanding Total").OptionsColumn.AllowEdit = False
        GridView1.Columns("Nomor Kwitansi").ColumnEdit = ListKwitansi

        'add total
        GridView1.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(2).SummaryItem.DisplayFormat = "{0:###,###}"
        GridView1.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(8).SummaryItem.DisplayFormat = "{0:###,###}"
        GridView1.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(11).SummaryItem.DisplayFormat = "{0:###,###}"
        GridView1.Columns(14).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(14).SummaryItem.DisplayFormat = "{0:###,###}"
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

    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim tempTglBayar As Date

        If e.Column.FieldName = "Tanggal Bayar" Then

            contract = txtHidden.Text
            tempTglBayar = e.Value

            If Not GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar")).ToString() = "" Then
                StrSQL = ""
                StrSQL = String.Format("Select * From contractDetail where contractID ='{0}' AND TglBayar='{1}'", contract, tempTglBayar)
                RunSQL(StrSQL, 1)

                If dt.Rows.Count > 0 Then
                    With ListKwitansi
                        .TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
                        .Items.Clear()
                        StrSQL = ""
                        StrSQL = "SELECT NoKwitansi From Kwitansi Where StatusKwitansi='Belum Terpakai'"
                        StrSQL &= String.Format(" OR (StatusKwitansi='Terpakai' AND TglBayar='{0}') ORDER BY NoKwitansi ASC", tempTglBayar)
                        Call conn_open()
                        cmd = New SqlCommand(StrSQL, conn)
                        rdr = cmd.ExecuteReader()
                        While rdr.Read()
                            .Items.Add(rdr("NoKwitansi"))
                        End While
                        conn.Close()
                    End With
                Else
                    With ListKwitansi
                        .TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
                        .Items.Clear()
                        StrSQL = ""
                        StrSQL = "SELECT NoKwitansi From Kwitansi Where StatusKwitansi='Belum Terpakai' ORDER BY NoKwitansi ASC"
                        Call conn_open()
                        cmd = New SqlCommand(StrSQL, conn)
                        rdr = cmd.ExecuteReader()
                        While rdr.Read()
                            .Items.Add(rdr("NoKwitansi"))
                        End While
                        conn.Close()
                    End With
                End If
            End If




        End If

        If e.Column.FieldName = "Total Bayar" Then

            If IsDBNull(e.Value) Then
                totalbayar = 0
            Else
                totalbayar = e.Value
            End If

            If totalbayar < GridView1.GetFocusedRowCellValue(GridView1.Columns(2)) Then
                MessageBox.Show("Total Bayar tidak boleh lebih kecil dari Angsuran")
                'GridView1.SetFocusedRowCellValue("Total Bayar", CInt(0))
            Else
                GridView1.SetFocusedRowCellValue(GridView1.Columns("Outstanding"), CInt(totalbayar - GridView1.GetFocusedRowCellValue(GridView1.Columns("AMBC"))))
                Dim outstanding As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding"))
                Dim outstandingRe As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"))
                GridView1.SetFocusedRowCellValue(GridView1.Columns("Outstanding Total"), outstanding + outstandingRe)
            End If

        End If

    End Sub

    Private Sub denda_SAV(ByVal outstanding As Integer, ByVal index As Integer, ByVal kontrak As String)

        StrSQL = ""
        StrSQL = "SELECT * From Denda Where ContractID ='" & kontrak & "'"
        StrSQL &= " AND [index]= " & index & ""
        RunSQL(StrSQL, 1)

        If dt.Rows.Count > 0 Then
            StrSQL = ""
            StrSQL = "UPDATE Denda Set Outstanding = " & outstanding & " "
            StrSQL &= " WHERE ContractId='" & kontrak & "' "
            StrSQL &= " AND [index]= " & index & ""
        Else
            StrSQL = ""
            StrSQL = "INSERT INTO denda (ContractID,Outstanding,OutstandingTotal,[index],OutstandingReceive) VALUES ("
            StrSQL &= String.Format("'{0}',", kontrak)
            StrSQL &= String.Format("{0},", outstanding)
            StrSQL &= String.Format("{0},", outstanding)
            StrSQL &= String.Format("{0},", index)
            StrSQL &= "0)"
        End If
        RunSQL(StrSQL, 0)
    End Sub

    Private Sub detail_SAV()
        Dim contract As String = txtHidden.Text
        Dim tglBayar As Date = GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar"))
        Dim AMBC As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("AMBC"))
        Dim OVD As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("OVD"))
        Dim denda As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Denda"))
        Dim totalBayar As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Total Bayar"))
        Dim outstanding As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding"))
        Dim outstandingRe As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"))
        Dim outstandingTotal As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Total"))
        Dim index As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Angs Ke"))
        Dim Nokwitansi As String = GridView1.GetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"))
        Dim alasan As String = "Pembayaran Angsuran Ke " & index & " sebesar Rp. " & totalBayar & "."

        StrSQL = ""
        StrSQL = "UPDATE ContractDetail SET "
        StrSQL &= String.Format("TglBayar = '{0}',", tglBayar)
        StrSQL &= String.Format("AMBC ={0},", AMBC)
        StrSQL &= "OVD =" & OVD & ","
        StrSQL &= "denda =" & denda & ","
        StrSQL &= "totalBayar = " & totalBayar & ","
        StrSQL &= "outstanding = " & outstanding & ","
        StrSQL &= "outstandingReceive = " & outstandingRe & ","
        StrSQL &= "outstandingTotal= " & outstandingTotal & ","
        StrSQL &= "NoKwitansi ='" & Nokwitansi & "' "
        StrSQL &= "WHERE ContractID ='" & txtHidden.Text & "' "
        StrSQL &= "AND [index]= " & index - 1 & ""
        RunSQL(StrSQL, 0)

        StrSQL = ""
        StrSQL = "UPDATE Kwitansi SET "
        StrSQL &= "StatusKwitansi ='Terpakai',"
        StrSQL &= "TglBayar ='" & tglBayar & "',"
        StrSQL &= "ContractID ='" & contract & "',"
        StrSQL &= "PIC2='" & cmbPIC.SelectedValue & "',"
        StrSQL &= "Alasan = case when alasan like '%" & alasan & "%'"
        StrSQL &= " THEN Alasan ELSE Alasan+'" & alasan & "' END,"
        StrSQL &= "CaraBayar ='" & cmbCaraBayar.Text & "',"
        StrSQL &= "MemberID ='" & memberID & "' "
        StrSQL &= " WHERE NoKwitansi ='" & Nokwitansi & "'"
        RunSQL(StrSQL, 0)

        StrSQL = ""
        StrSQL = ("UPDATE Kwitansi SET ")
        StrSQL &= "Nominal= A.Valsum From Kwitansi INNER JOIN "
        StrSQL &= "(SELECT NoKwitansi,SUM(totalbayar) valsum from ContractDetail "
        StrSQL &= "Where NoKwitansi ='" & Nokwitansi & "' GROUP BY NoKwitansi)  A "
        StrSQL &= " ON Kwitansi.NoKwitansi = A.NoKwitansi "
        StrSQL &= "WHERE Kwitansi.NoKwitansi ='" & Nokwitansi & "'"
        RunSQL(StrSQL, 0)


        If outstanding < 0 Then
            denda_SAV(outstanding, index, contract)
        End If

    End Sub

    Private Sub GridView1_ValidateRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView1.ValidateRow
        ovd = GridView1.GetFocusedRowCellValue(GridView1.Columns("OVD"))
        denda = GridView1.GetFocusedRowCellValue(GridView1.Columns("Denda"))
        totalbayar = GridView1.GetFocusedRowCellValue(GridView1.Columns("Total Bayar"))
        outstanding = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding"))
        kwitansi = GridView1.GetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"))

        If GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar")).ToString() = "" Or totalbayar = "0" Or kwitansi = "unpaid" Then
            FillGrid()
            ListKwitansi.Items.Clear()
        Else
            Dim result As Integer = MessageBox.Show("Transaksi akan disimpan dan tidak bisa diubah !", "Perhatian !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                detail_SAV()
                ListKwitansi.Items.Clear()
            ElseIf result = DialogResult.No Then
                FillGrid()
                ListKwitansi.Items.Clear()
            End If

        End If
    End Sub

    Private Sub GridView1_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Dim View As GridView = CType(sender, GridView)
        'If (GridView1.IsCellSelected(e.RowHandle, View.Columns("Tanggal Bayar"))) Then
        '    e.Appearance.BackColor = Color.Transparent
        'End If


        If (e.RowHandle >= 0) Then

            Dim tglBayar As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Tanggal Bayar"))
            Dim totalBayar As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Total Bayar"))
            Dim kwitansi As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Nomor Kwitansi"))
            If tglBayar = "" Or totalBayar = "" Or totalBayar = "0" Or kwitansi = "" Then
                e.Appearance.BackColor = Color.Yellow
            Else

                e.Appearance.BackColor = Color.Red

            End If

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            GridView1.OptionsPrint.AutoWidth = False
            GridView1.BestFitColumns()
            GridControl1.ExportToXls(SaveFileDialog1.FileName)
        End If
    End Sub



    Private Sub GridView1_ShowingEditor(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridView1.ShowingEditor
        Dim View As GridView = CType(sender, GridView)

        If (View.FocusedColumn.FieldName = "Total Bayar" Or View.FocusedColumn.FieldName = "Tanggal Bayar" Or View.FocusedColumn.FieldName = "Nomor Kwitansi") And cekBayar(View, View.FocusedRowHandle) = True And levelUser = 2 Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If

    End Sub


    Private Function cekBayar(ByVal view As GridView, ByVal row As Integer) As Boolean
        Dim col As GridColumn = view.Columns("Total Bayar")
        Dim col2 As GridColumn = view.Columns("Angsuran")
        Dim val As Integer = CInt(view.GetRowCellValue(row, col))
        Dim val2 As Integer = CInt(view.GetRowCellValue(row, col2))
        If val - val2 >= 0 Then
            cekBayar = True
        Else
            cekBayar = False
        End If
        Return cekBayar
    End Function

    Private Sub FillPelunasan()

        Dim strOutstandingTotal As String = GridView1.Columns("Outstanding Total").SummaryText
        Dim outstandingTotal As Integer

        If strOutstandingTotal <> "" Then
            outstandingTotal = CInt(GridView1.Columns("Outstanding Total").SummaryText) * -1
        Else
            outstandingTotal = 0

        End If

        Dim totalDenda As Integer
        Dim strTotalDenda As String = GridView1.Columns("Denda").SummaryText
        If strTotalDenda <> "" Then
            totalDenda = CInt(GridView1.Columns("Denda").SummaryText)
        Else
            totalDenda = 0
        End If
        'Dim totalOutstanding As Integer = CInt(GridView1.Columns("Outstanding").SummaryText)
        Dim strDendaDicatat As String
        Dim dendaDicatat As Integer

        'totalDenda = totalDenda - totalOutstanding + outstandingTotal

        StrSQL = ""
        StrSQL = "select top 1 OP from contractDetail "
        StrSQL &= " WHERE totalBayar > Angsuran "
        StrSQL &= " AND ContractID = '" & txtKontrak.Text & "' Group By ContractID , op,[index] Order By [index] DESC"

        RunSQL(StrSQL, 1)
        If dt.Rows.Count > 0 Then
            txtSIsaPokok.Text = ribuan(getFieldValue(StrSQL))
        Else
            StrSQL = ""
            StrSQL = "select top 1 OP from contractDetail "
            StrSQL &= " WHERE ContractID = '" & txtKontrak.Text & "' Group By ContractID , op,[index] Order By [index] ASC"
            txtSIsaPokok.Text = ribuan(getFieldValue(StrSQL))
        End If



        StrSQL = ""
        StrSQL = "SELECT Sum(Denda) From ContractDetail WHERE "
        StrSQL &= " totalBayar is not null "
        StrSQL &= " AND ContractID = '" & txtKontrak.Text & "' "
        strDendaDicatat = getFieldValue(StrSQL)
        If strDendaDicatat <> "" Then
            dendaDicatat = CInt(strDendaDicatat)
        Else
            dendaDicatat = 0
        End If

        totalDenda = totalDenda - dendaDicatat + outstandingTotal
        txtDenda.Text = ribuan(totalDenda)

        If txtSIsaPokok.Text <> 0 Then
            txtPinalty.Text = ribuan(CDbl(txtSIsaPokok.Text) * 7.5 / 100)
        Else
            txtPinalty.Text = 0
        End If

    End Sub

    

    Private Sub txtPinalty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPinalty.TextChanged
        If txtPinalty.Text <> "" Then
            Try
                Dim kekurangan As Integer = CDbl(txtSIsaPokok.Text) + CDbl(txtDenda.Text) + CDbl(txtPinalty.Text)
                txtTotalKekurangan.Text = ribuan(kekurangan)
            Catch ex As Exception

            End Try
          
        End If


     
    End Sub

    Private Sub txtPinalty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPinalty.KeyPress
        decimalOnly(sender, e, txtPinalty.Text)


    End Sub

    Private Sub txtPinalty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPinalty.Leave
        txtPinalty.Text = ribuan(txtPinalty.Text)
    End Sub

    Private Sub txtBayar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBayar.KeyPress
        decimalOnly(sender, e, txtBayar.Text)
    End Sub

    Private Sub txtBayar_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBayar.Leave
        txtBayar.Text = ribuan(txtBayar.Text)
    End Sub

    Private Sub FillKwitansi()
        Dim tblKwitansi As New DataTable
        FillCombobox("SELECT TOP 10 NoKwitansi From Kwitansi Where StatusKwitansi='Belum Terpakai'", cmbKwitansi, 1, tblKwitansi)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtBayar.Text < txtTotalKekurangan.Text Then
            MessageBox.Show("Jumlah Bayar Tidak Boleh Kurang Dari TotalKekurangan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            UpdateContract()
            UpdateKwitansi()
            MessageBox.Show("Status Kontrak Berhasil Diubah", "Sukses", MessageBoxButtons.OK)
            ClearForm()
        End If
    End Sub
    Private Sub UpdateContract()
        StrSQL = ""
        StrSQL = "Update Contract Set State=3 Where ContractId='" & txtKontrak.Text & "'"
        RunSQL(StrSQL, 0)
    End Sub

    Private Sub UpdateKwitansi()
        StrSQL = ""
        StrSQL = "Update Kwitansi Set PIC2='" & cmbPIC.SelectedValue & "', "
        StrSQL &= "StatusKwitansi ='Terpakai',Alasan='Pelunasan Dimuka Nomor Kontrak " & txtKontrak.Text & " Sebesar Rp." & txtBayar.Text & "', "
        StrSQL &= "Nominal=" & CDbl(txtBayar.Text) & ","
        StrSQL &= "TglBayar='" & dtBayar.Value & "',"
        StrSQL &= "ContractID='" & txtKontrak.Text & "',"
        StrSQL &= "MemberID='" & memberID & "',"
        StrSQL &= "state=0,"
        StrSQL &= "CaraBayar ='" & cmbCaraBayar.Text & "' "
        StrSQL &= "Where NoKwitansi ='" & cmbKwitansi.Text & "'"
        RunSQL(StrSQL, 0)

    End Sub
End Class