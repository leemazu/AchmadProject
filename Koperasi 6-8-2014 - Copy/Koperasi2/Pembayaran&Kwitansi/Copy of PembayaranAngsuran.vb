'Option Strict On
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils.Menu
Imports System.Threading

Public Class PembayaranAngsuran

    Dim contract As String
    Dim ovd As Integer
    Dim totalbayar As Integer
    Dim outstanding As Integer
    Dim kwitansi As String
    Dim denda As Integer
    Dim memberID As String
    Dim ListKwitansi As RepositoryItemComboBox = New RepositoryItemComboBox

    Private Sub FormClear()
        txtKontrak.Text = ""
        txtAngsuran.Text = ""
        txtAmbc.Text = 0
        txtBayar.Text = 0
        txtHidden.Text = ""
        txtHiddenAngsuran.Text = 0
        txtAdminKredit.Text = 0
        GroupBox2.Visible = False
        lblError.Text = ""
    End Sub

    Private Sub PembayaranAngsuran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillPIC()
        cmbCaraBayar.SelectedIndex = 0
        setTanggal(dtBayar)
        FormClear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmTabKontrak.txtFlag.Text = "1"
        frmTabKontrak.Show()
        frmTabKontrak.BringToFront()
    End Sub

    Private Sub txtKontrak_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKontrak.TextChanged
        'If txtKontrak.Text.Length = txtKontrak.MaxLength Then

            StrSQL = ""
            StrSQL = "SELECT * FROM ContractDetail Where ContractID ='" & txtKontrak.Text & "' "
            RunSQL(StrSQL, 1)
            If dt.Rows.Count > 0 Then
                FillForm()
                FillGrid()
                FillPembayaran()
                btnBayar.Enabled = True
                FillNoKwitansi()
                btnBayar.Visible = True
                dtBayar.Value = Now
                GridView1.SetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar"), dtBayar.Value)
                GridView1.SetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"), cmbKwitansi.Text)
            Else
                GroupBox2.Visible = False
                GridControl1.DataSource = Nothing
                ClearForm()
                btnBayar.Visible = False
            End If

          
        'Else
        '    GroupBox2.Visible = False
        '    GridControl1.DataSource = Nothing
        '    ClearForm()
        '    btnBayar.Visible = False
        'End If
    End Sub

    Private Sub ClearForm()
        txtKonsumen.Clear()
        txtAlamat.Clear()
        txtObjek.Clear()
        txtBulan.Clear()
        txtTenor.Clear()
        txtTipe.Clear()
    End Sub

    Private Sub FillPIC()
        Dim tablePIC As DataTable = Nothing
        StrSQL = ""
        StrSQL = "SELECT EmployeeID,EmployeeName FROM Employee Where PositionID = 'PC' ORDER BY EmployeeName ASC"
        FillCombobox(StrSQL, cmbPIC, 2, tablePIC)
    End Sub

    Private Sub FillForm()
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
        End If

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
                txtAdminKredit.Enabled = False
            Case "Elektronik"
                lblMesin.Visible = True
                lblTipe.Visible = True
                txtMesin.Visible = True
                txtTipe.Visible = True
                lblMesin.Text = "Nama Barang"
                lblTipe.Text = "Keterangan"
                txtMesin.Text = CStr(dt.Rows(0)("NamaBarang"))
                txtTipe.Text = CStr(dt.Rows(0)("MotorType"))
                txtAdminKredit.Text = 0
                txtAdminKredit.Enabled = False
            Case Else
                lblMesin.Visible = False
                lblTipe.Visible = False
                txtMesin.Visible = False
                txtTipe.Visible = False
        End Select

       
    End Sub

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
            StrSQL &= String.Format("WHERE ContractID='{0}' ", txtKontrak.Text)
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
        GridView1.Columns("Nomor Kwitansi").ColumnEdit = ListKwitansi

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


        StrSQL = ""
        StrSQL = "SELECT PositionID from Employee Where EmployeeID ='" & EmployeeID & "' "
        RunSQL(StrSQL, 1)

        If dt.Rows(0)("PositionID") <> "SAD" Then
            For i As Integer = 0 To 15
                GridView1.Columns(i).OptionsColumn.AllowEdit = False
            Next
        End If

     

        'set ga bisa diedit
       

        'GridControl1.Enabled = False
        ' GridControl1.UseDisabledStatePainter = False


    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim tempTglBayar As Date
        Dim OVD As Integer
        Dim denda As Integer
        Dim ambc As Integer
        'Dim ot As Integer
        Dim ott As Integer
        Dim angsuran As Integer
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

        If e.Column.FieldName = "Tanggal Bayar" Then
            OVD = DateDiff(DateInterval.Day, GridView1.GetFocusedRowCellValue(GridView1.Columns("Due Date")), GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar")))
            GridView1.SetFocusedRowCellValue(GridView1.Columns("OVD"), OVD)

        End If

        If e.Column.FieldName = "OVD" Then
            OVD = GridView1.GetFocusedRowCellValue(GridView1.Columns("OVD"))
            angsuran = GridView1.GetFocusedRowCellValue(GridView1.Columns("Angsuran"))
            denda = angsuran * 0.005 * OVD
            If denda < 0 Then
                denda = 0
            End If
            GridView1.SetFocusedRowCellValue(GridView1.Columns("Denda"), denda)
        End If

        If e.Column.FieldName = "Denda" Then
            ambc = GridView1.GetFocusedRowCellValue(GridView1.Columns("Denda")) + GridView1.GetFocusedRowCellValue(GridView1.Columns("Angsuran"))
            GridView1.SetFocusedRowCellValue(GridView1.Columns("AMBC"), ambc)
        End If

        'If e.Column.FieldName = "AMBC" Then
        '    ot = GridView1.GetFocusedRowCellValue(GridView1.Columns("Total Bayar")) - GridView1.GetFocusedRowCellValue(GridView1.Columns("AMBC"))
        '    GridView1.SetFocusedRowCellValue(GridView1.Columns("Outstanding"), ot)
        'End If

        If e.Column.FieldName = "AMBC" Then
            txtAmbc.Text = ribuan(CStr(GridView1.GetFocusedRowCellValue(GridView1.Columns("AMBC"))))
        End If



        'If e.Column.FieldName = "Total Bayar" Then
        '    Dim outstanding As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding"))
        '    Dim outstandingRe As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"))
        '    If IsDBNull(e.Value) Then
        '        totalbayar = 0
        '    Else
        '        Try
        '            totalbayar = e.Value
        '        Catch ex As Exception
        '            totalbayar = 0
        '        End Try

        '    End If

        '    If totalbayar < GridView1.GetFocusedRowCellValue(GridView1.Columns(2)) Then
        '        'MessageBox.Show("Total Bayar tidak boleh lebih kecil dari Angsuran")
        '        lblError.Text = "Total Bayar tidak boleh lebih kecil dari Angsuran"
        '        GridView1.SetFocusedRowCellValue(GridView1.Columns("Outstanding"), 0)
        '        GridView1.SetFocusedRowCellValue(GridView1.Columns("Outstanding Total"), 0)
        '        'GridView1.SetFocusedRowCellValue("Total Bayar", CInt(0))
        '    Else
        '        lblError.Text = ""
        '        GridView1.SetFocusedRowCellValue(GridView1.Columns("Outstanding"), CInt(totalbayar - GridView1.GetFocusedRowCellValue(GridView1.Columns("AMBC"))))
        '        GridView1.SetFocusedRowCellValue(GridView1.Columns("Outstanding Total"), CInt(GridView1.GetFocusedRowCellValue("Outstanding") + CInt(GridView1.GetFocusedRowCellValue("Outstanding Receive"))))
        '    End If

        'End If

        If e.Column.FieldName = "Outstanding" Then
            ott = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding")) - GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"))
            GridView1.SetFocusedRowCellValue(GridView1.Columns("Outstanding Total"), ott)
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

    Private Sub Detail_SAV2()
        Dim contract As String = txtHidden.Text
        Dim tglBayar As Date = dtBayar.Value.Date
        Dim AMBC As Integer = CInt(txtAmbc.Text)
        Dim OVD As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("OVD"))
        Dim denda As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Denda"))
        Dim totalBayar As Integer = CInt(txtBayar.Text)
        Dim outstanding As Integer = CInt(txtBayar.Text) - CInt(txtAmbc.Text)
        Dim outstandingRe As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"))
        Dim outstandingTotal As Integer = outstanding - outstandingRe
        Dim index As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Angs Ke"))
        Dim Nokwitansi As String = cmbKwitansi.Text
        Dim alasan As String = "Pembayaran Angsuran Ke " & index & " sebesar Rp. " & ribuan(CStr(totalBayar)) & "."

        StrSQL = ""
        StrSQL = "UPDATE ContractDetail SET "
        StrSQL &= String.Format("TglBayar = '{0}',", tglBayar)
        'StrSQL &= String.Format("AMBC ={0},", AMBC)
        'StrSQL &= "OVD =" & OVD & ","
        'StrSQL &= "denda =" & denda & ","
        StrSQL &= "totalBayar = " & totalBayar & ","
        'StrSQL &= "outstanding = " & outstanding & ","
        StrSQL &= "outstandingReceive = " & outstandingRe & ","
        'StrSQL &= "outstandingTotal= " & outstandingTotal & ","
        StrSQL &= "NoKwitansi ='" & Nokwitansi & "' "
        StrSQL &= "WHERE ContractID ='" & txtHidden.Text & "' "
        StrSQL &= "AND [index]= " & index - 1 & ""
        RunSQL(StrSQL, 0)

        'update OVD
        StrSQL = ""
        StrSQL = "UPDATE ContractDetail SET "
        StrSQL &= "OVD = DATEDIFF(DAY,JatuhTempo,TglBayar) "
        StrSQL &= "WHERE ContractID ='" & txtHidden.Text & "' "
        StrSQL &= "AND [index]= " & index - 1 & ""
        RunSQL(StrSQL, 0)

        'UPDATE DENDA
        StrSQL = ""
        StrSQL = "UPDATE ContractDetail SET "
        StrSQL &= "Denda = Angsuran*0.005*OVD "
        StrSQL &= "WHERE ContractID ='" & txtHidden.Text & "' "
        StrSQL &= "AND [index]= " & index - 1 & ""
        RunSQL(StrSQL, 0)

        'UPDATE AMBC
        StrSQL = ""
        StrSQL = "UPDATE ContractDetail SET "
        StrSQL &= "AMBC = Angsuran+Denda "
        StrSQL &= "WHERE ContractID ='" & txtHidden.Text & "' "
        StrSQL &= "AND [index]= " & index - 1 & ""
        RunSQL(StrSQL, 0)

        'UPDATE OUTSTANDING
        StrSQL = ""
        StrSQL = "UPDATE ContractDetail SET "
        StrSQL &= "Outstanding = TotalBayar-AMBC "
        StrSQL &= "WHERE ContractID ='" & txtHidden.Text & "' "
        StrSQL &= "AND [index]= " & index - 1 & ""
        RunSQL(StrSQL, 0)

        'UPDATE OutstandingTotal
        StrSQL = ""
        StrSQL = "UPDATE ContractDetail SET "
        StrSQL &= "OutstandingTotal = Outstanding + OutstandingReceive "
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

    'Private Sub GridView1_ValidateRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView1.ValidateRow
    '    ovd = GridView1.GetFocusedRowCellValue(GridView1.Columns("OVD"))
    '    denda = GridView1.GetFocusedRowCellValue(GridView1.Columns("Denda"))
    '    totalbayar = GridView1.GetFocusedRowCellValue(GridView1.Columns("Total Bayar"))
    '    outstanding = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding"))
    '    kwitansi = GridView1.GetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"))

    '    If GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar")).ToString() = "" Or totalbayar = "0" Or kwitansi = "unpaid" Then
    '        FillGrid()
    '        ListKwitansi.Items.Clear()
    '    Else
    '        Dim result As Integer = MessageBox.Show("Transaksi akan disimpan dan tidak bisa diubah !", "Perhatian !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    '        If result = DialogResult.Yes Then
    '            detail_SAV()
    '            ListKwitansi.Items.Clear()
    '        ElseIf result = DialogResult.No Then
    '            FillGrid()
    '            ListKwitansi.Items.Clear()
    '        End If

    '    End If
    'End Sub

    Private Sub GridView1_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        If txtAngsuran.Text <> "" Then
            GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(CInt(txtAngsuran.Text) - 1)
        End If



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
            e.Cancel = False
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

    Private Sub FillPembayaran()
        Dim index As New Integer
        txtBayar.Text = "0"
        txtBayar.Focus()
        txtHiddenAngsuran.Clear()

        StrSQL = ""
        StrSQL = "SELECT TOP 1 [index]+1 as [Angs ke] "
        StrSQL &= " From ContractDetail "
        StrSQL &= String.Format("WHERE ContractID='{0}' ", txtKontrak.Text)
        StrSQL &= " AND TotalBayar IS NULL "
        StrSQL &= " ORDER BY [Index]"
        RunSQL(StrSQL, 1)

        If dt.Rows.Count > 0 Then
            index = dt.Rows(0)("Angs Ke")
            GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(CInt(index) - 1)
            GridView1.Appearance.FocusedRow.BackColor = Color.Green
            GridView1.Appearance.SelectedRow.BackColor = Color.Green
            GridView1.Appearance.FocusedCell.BackColor = Color.Green
            GridView1.OptionsSelection.EnableAppearanceHideSelection = False
            GroupBox2.Visible = True
        Else
            MessageBox.Show("Kontrak ini telah melakukan seluruh pembayaran angsuran namun status masih aktif", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            GroupBox2.Visible = False
            GridView1.Appearance.FocusedRow.BackColor = Color.Red
            GridView1.Appearance.SelectedRow.BackColor = Color.Red
            GridView1.Appearance.FocusedCell.BackColor = Color.Red
            GridView1.OptionsSelection.EnableAppearanceHideSelection = False
        End If

      

            'txtBayar.Text = ""
            'txtHiddenAngsuran.Text = ""
            'StrSQL = ""
            'StrSQL = "SELECT TOP 1 [Index]+1 as [Angs Ke],Sp,"
            '' StrSQL &= "Angsuran+(CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0 then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end) as [AMBC] "
            'StrSQL &= "Angsuran+CASE WHEN ISNULL(denda,Angsuran*0.005*ISNULL(OVD,DATEDIFF(day,jatuhtempo,getdate()))) < 0 TheN 0 ELSE ISNULL(denda,Angsuran*0.005*ISNULL(OVD,DATEDIFF(day,jatuhtempo,getdate()))) END as AMBC "
            'StrSQL &= " From ContractDetail "
            'StrSQL &= String.Format("WHERE ContractID='{0}' ", txtKontrak.Text)
            'StrSQL &= " AND TotalBayar IS NULL "
            'StrSQL &= " ORDER BY [Index]"

            'RunSQL(StrSQL, 1)

            'If dt.Rows.Count > 0 Then
            '    txtAngsuran.Text = dt.Rows(0)("Angs Ke")
            '    txtAmbc.Text = ribuan(CStr(dt.Rows(0)("AMBC")))
            '    txtHiddenAngsuran.Text = dt.Rows(0)("Sp")
            'End If

            'GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(CInt(dt.Rows(0)("Angs Ke")) - 1)
            'GridView1.Appearance.FocusedRow.BackColor = Color.Green
            'GridView1.Appearance.SelectedRow.BackColor = Color.Green
            'GridView1.Appearance.FocusedCell.BackColor = Color.Green
            'GridView1.OptionsSelection.EnableAppearanceHideSelection = False

            'txtBayar.Text = 0
            'txtBayar.Focus()

    End Sub

    Private Sub FillNoKwitansi()
        Dim dtKwitansi As New DataTable

        If txtKontrak.Text <> "" Then
            StrSQL = ""
            StrSQL = "SELECT PositionID from Employee Where EmployeeID ='" & EmployeeID & "' "
            RunSQL(StrSQL, 1)

            If dt.Rows(0)("PositionID") = "SAD" Then

                StrSQL = "SELECT TOP 20 NoKwitansi From Kwitansi Where StatusKwitansi='Belum Terpakai'"
                StrSQL &= String.Format(" OR (StatusKwitansi='Terpakai' AND CONVERT(DATE,TglBayar)='{0}') ORDER BY NoKwitansi ASC", dtBayar.Value.Date)
                FillCombobox(StrSQL, cmbKwitansi, 1, dtKwitansi)
            Else
                StrSQL = ""
                StrSQL = String.Format("Select * From contractDetail where contractID ='{0}' AND CONVERT(DATE,TglBayar)='{1}'", txtHidden.Text, dtBayar.Value.Date)
                RunSQL(StrSQL, 1)

                If dt.Rows.Count > 0 Then
                    StrSQL = ""
                    StrSQL = "SELECT TOP 20 NoKwitansi From Kwitansi Where PIC1='" & EmployeeID & "' AND (StatusKwitansi='Belum Terpakai'"
                    StrSQL &= String.Format(" OR (StatusKwitansi='Terpakai' AND CONVERT(DATE,TglBayar)='{0}')) ORDER BY NoKwitansi ASC", dtBayar.Value.Date)
                    FillCombobox(StrSQL, cmbKwitansi, 1, dtKwitansi)
                Else
                    StrSQL = ""
                    StrSQL = "SELECT TOP 20 NoKwitansi From Kwitansi Where StatusKwitansi='Belum Terpakai' AND PIC1='" & EmployeeID & "' ORDER BY NoKwitansi ASC"
                    FillCombobox(StrSQL, cmbKwitansi, 1, dtKwitansi)
                End If

            End If
        End If

    End Sub

    Private Sub ChangeGridValue()
        GridView1.SetFocusedRowCellValue(GridView1.Columns("OVD"), DateDiff(DateInterval.Day, GridView1.GetFocusedRowCellValue("Due Date"), dtBayar.Value))
        txtAmbc.Text = ribuan(CStr(GridView1.GetFocusedRowCellValue(GridView1.Columns("AMBC"))))
    End Sub

    Private Sub btnBayar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBayar.Click
        If txtBayar.Text <> "" Then
            If CDbl(txtBayar.Text) < CDbl(txtHiddenAngsuran.Text) Then
                MessageBox.Show("Nilai Pembayaran Tidak Boleh Kurang Dari Sisa Pokok !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBayar.Focus()
                txtBayar.SelectAll()
            Else
                Pembayaran()
                'Dim result As Integer = MessageBox.Show("Pembayaran akan disimpan dan tidak bisa diubah !", "Perhatian !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                'If result = DialogResult.Yes Then
                '    Detail_SAV2()
                'End If

                'FillGrid()
                'FillPembayaran()

                'GridView1.SetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"), cmbKwitansi.Text)
                'GridView1.SetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar"), dtBayar.Value)
            End If
        End If
    End Sub

    Private Sub txtBayar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBayar.KeyPress
        decimalOnly(sender, e, sender.Text)
    End Sub

    

    Private Sub txtBayar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBayar.TextChanged
        Dim sp As Integer = CInt(GridView1.GetFocusedRowCellValue(GridView1.Columns("Amount Principal")))


        Dim bayar As Integer

        If txtBayar.Text = "" Then
            bayar = 0
        Else
            bayar = CInt(txtBayar.Text)

        End If

        If Not GridControl1.DataSource Is Nothing Then

            Try
                GridView1.SetRowCellValue(GridView1.GetVisibleRowHandle(CInt(txtAngsuran.Text) - 1), "Total Bayar", CInt(txtBayar.Text))
                ' GridView1.SetFocusedRowCellValue(GridView1.Columns("Total Bayar"), CInt(txtBayar.Text))
                If bayar < sp Then
                    lblError.Visible = True
                    lblError.Text = "Pembayaran tidak boleh kurang dari " & ribuan(sp) & " (Pokok) "
                    btnBayar.Enabled = False
                Else
                    lblError.Visible = False
                    lblError.Text = ""
                    btnBayar.Enabled = True
                End If
            Catch ex As Exception
                GridView1.SetFocusedRowCellValue(GridView1.Columns("Total Bayar"), 0)
            End Try

        End If
    End Sub

    Private Sub cmbKwitansi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKwitansi.SelectedIndexChanged
        GridView1.SetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"), cmbKwitansi.Text)
    End Sub

    Private Sub dtBayar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtBayar.ValueChanged
        If GridControl1.DataSource Is Nothing Then
        Else
            FillNoKwitansi()
            ' ChangeGridValue()
            GridView1.SetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar"), dtBayar.Value)
            'GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(CInt(txtAngsuran.Text) - 1)
        End If
    End Sub

    Private Sub GridView1_MouseDown(ByVal sender As System.Object, ByVal e As DevExpress.Utils.DXMouseEventArgs) Handles GridView1.MouseDown
        e.Handled = True
    End Sub

    Private Sub GridView1_MouseUp(ByVal sender As System.Object, ByVal e As DevExpress.Utils.DXMouseEventArgs) Handles GridView1.MouseUp
        e.Handled = True
    End Sub

    Private Sub GridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        txtAngsuran.Text = GridView1.GetFocusedRowCellValue(GridView1.Columns("Angs Ke"))
        txtAmbc.Text = ribuan(CStr(GridView1.GetFocusedRowCellValue(GridView1.Columns("AMBC"))))
        txtHiddenAngsuran.Text = GridView1.GetFocusedRowCellValue(GridView1.Columns("Amount Principal"))
    End Sub

    Private Sub Pembayaran()
        Dim message As String

        message = "Detail Pembayaran : " & vbNewLine
        message &= "Nomor Kontrak " & vbTab & ": " & txtKontrak.Text & vbNewLine
        message &= "Nama Konsumen " & vbTab & ": " & txtKonsumen.Text & vbNewLine
        message &= "Angsuran Ke " & vbTab & ": " & txtAngsuran.Text & vbNewLine
        message &= "Jumlah Bayar " & vbTab & ": " & txtBayar.Text & vbNewLine
        message &= "Anda ingin menginput pembayaran diatas ? "
        Dim result As Integer = MessageBox.Show(message, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = vbYes Then
            If ContractDetail_SAV() Then
                MessageBox.Show("Pembayaran telah disimpan")
                FillForm()
                FillGrid()
                FillPembayaran()
                btnBayar.Enabled = True
                FillNoKwitansi()

                GroupBox2.Visible = True
                btnBayar.Visible = True
                dtBayar.Value = Now
                GridView1.SetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar"), dtBayar.Value)
                GridView1.SetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"), cmbKwitansi.Text)
            End If
        End If




    End Sub

    Private Function ContractDetail_SAV() As Boolean
        Dim contract As String = txtHidden.Text
        Dim tglBayar As Date = dtBayar.Value.Date
        Dim AMBC As Integer = CInt(txtAmbc.Text)
        Dim OVD As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("OVD"))
        Dim denda As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Denda"))
        Dim totalBayar As Integer = CInt(txtBayar.Text)
        Dim outstanding As Integer = CInt(txtBayar.Text) - CInt(txtAmbc.Text)
        Dim outstandingRe As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"))
        Dim outstandingTotal As Integer = outstanding - outstandingRe
        Dim index As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Angs Ke"))
        Dim Nokwitansi As String = cmbKwitansi.Text
        Dim alasan As String = "Pembayaran Angsuran Ke " & index & " sebesar Rp. " & ribuan(CStr(totalBayar)) & "."

        Try
            StrSQL = ""
            StrSQL = "UPDATE ContractDetail SET "
            StrSQL &= String.Format("TglBayar = '{0}',", tglBayar)
            StrSQL &= "totalBayar = " & totalBayar & ","
            'StrSQL &= "outstanding = " & outstanding & ","
            StrSQL &= "outstandingReceive = " & outstandingRe & ","
            'StrSQL &= "outstandingTotal= " & outstandingTotal & ","
            StrSQL &= "NoKwitansi ='" & Nokwitansi & "' "
            StrSQL &= "WHERE ContractID ='" & txtHidden.Text & "' "
            StrSQL &= "AND [index]= " & index - 1 & ""
            RunSQL(StrSQL, 0)

            'update OVD
            StrSQL = ""
            StrSQL = "UPDATE ContractDetail SET "
            StrSQL &= "OVD = DATEDIFF(DAY,JatuhTempo,TglBayar) "
            StrSQL &= "WHERE ContractID ='" & txtHidden.Text & "' "
            StrSQL &= "AND [index]= " & index - 1 & ""
            RunSQL(StrSQL, 0)

            'UPDATE DENDA
            StrSQL = ""
            StrSQL = "UPDATE ContractDetail SET "
            StrSQL &= "Denda = Angsuran*0.005*OVD "
            StrSQL &= "WHERE ContractID ='" & txtHidden.Text & "' "
            StrSQL &= "AND [index]= " & index - 1 & ""
            RunSQL(StrSQL, 0)

            'UPDATE AMBC
            StrSQL = ""
            StrSQL = "UPDATE ContractDetail SET "
            StrSQL &= "AMBC = Angsuran+Denda "
            StrSQL &= "WHERE ContractID ='" & txtHidden.Text & "' "
            StrSQL &= "AND [index]= " & index - 1 & ""
            RunSQL(StrSQL, 0)

            'UPDATE OUTSTANDING
            StrSQL = ""
            StrSQL = "UPDATE ContractDetail SET "
            StrSQL &= "Outstanding = TotalBayar-AMBC "
            StrSQL &= "WHERE ContractID ='" & txtHidden.Text & "' "
            StrSQL &= "AND [index]= " & index - 1 & ""
            RunSQL(StrSQL, 0)

            'UPDATE OutstandingTotal
            StrSQL = ""
            StrSQL = "UPDATE ContractDetail SET "
            StrSQL &= "OutstandingTotal = Outstanding + OutstandingReceive "
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

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message)
        End Try
        
    End Function


End Class