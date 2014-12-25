
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns

Public Class PembayaranDenda

    Dim contract As String
    Dim statusHutang As Boolean
    Dim totalbayar As Integer
    Dim outstandingRe As Integer
    Dim kwitansi As String
    Private DataFlag As Boolean
    Private InitOutstandingReceive As Double

    Dim memberID As String
    Dim ListKwitansi As RepositoryItemComboBox = New RepositoryItemComboBox


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
        StrSQL &= ",m.MemberID as MemberID"
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
            Case "Motor Baru"
                lblMesin.Text = "No.Mesin"
                lblTipe.Text = "Tipe"
                txtMesin.Text = CStr(dt.Rows(0)("EngineCode"))
                txtTipe.Text = CStr(dt.Rows(0)("MotorType"))

            Case "Dana Tunai"
                lblMesin.Text = "No.Mesin"
                lblTipe.Text = "Tipe"
                txtMesin.Text = CStr(dt.Rows(0)("EngineCode"))
                txtTipe.Text = CStr(dt.Rows(0)("MotorType"))

            Case "Elektronik"
                lblMesin.Text = "Nama Barang"
                lblTipe.Text = "Keterangan"
                txtMesin.Text = CStr(dt.Rows(0)("NamaBarang"))
                txtTipe.Text = CStr(dt.Rows(0)("MotorType"))

        End Select
    End Sub

    Private Sub FillGrid()

        Dim ds_kontrak As New DataSet
        ds_kontrak.Clear()

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



        Dim tbl_kontrak As New DataTable
        Using ds_kontrak
            StrSQL = ""
            StrSQL = "SELECT [Index] as [Angs Ke]"
            StrSQL &= ",isnull(CONVERT(nvarchar,tglbayar),'') as [Tanggal Bayar]"
            StrSQL &= ",Outstanding"
            StrSQL &= ",OutstandingTotal as [Outstanding Total]"
            StrSQL &= ",isnull(CONVERT(nvarchar,outstandingReceive),'0') as [Outstanding Receive]"
            StrSQL &= ",isnull(CONVERT(nvarchar,NoKwitansi),'unpaid') as [Nomor Kwitansi]"
            StrSQL &= " From Denda "
            StrSQL &= String.Format("WHERE ContractID='{0}' ", txtKontrak.Text)
            StrSQL &= " AND OutstandingTotal < 0 "
            StrSQL &= "ORDER BY [index] ASC"
            da = New SqlDataAdapter(StrSQL, conn)
            da.Fill(tbl_kontrak)
            ds_kontrak.Tables.Add(tbl_kontrak)
        End Using


        GridControl1.DataSource = Nothing
        GridControl1.DataSource = tbl_kontrak
        GridView1.Columns("Tanggal Bayar").ColumnEdit = tanggal
        GridView1.Columns("Outstanding").ColumnEdit = uang
        GridView1.Columns("Outstanding Total").ColumnEdit = uang
        GridView1.Columns("Outstanding Receive").ColumnEdit = uang
        GridView1.Columns("Angs Ke").OptionsColumn.AllowEdit = False
        GridView1.Columns("Outstanding").OptionsColumn.AllowEdit = False
        GridView1.Columns("Outstanding Total").OptionsColumn.AllowEdit = False
        GridView1.Columns("Nomor Kwitansi").ColumnEdit = ListKwitansi
        GridView1.Columns("Angs Ke").Width = 52
        GridView1.Columns("Tanggal Bayar").Width = 88
        GridView1.Columns("Outstanding").Width = 88
        GridView1.Columns("Outstanding Total").Width = 100
        GridView1.Columns("Outstanding Receive").Width = 95
        GridView1.Columns("Nomor Kwitansi").Width = 88


        StrSQL = ""
        StrSQL = "SELECT PositionID from Employee Where EmployeeID ='" & EmployeeID & "' "
        RunSQL(StrSQL, 1)

        If dt.Rows(0)("PositionID") <> "SAD" Then
            For i As Integer = 0 To 5
                GridView1.Columns(i).OptionsColumn.AllowEdit = False
            Next
        End If

        'GridView1.Appearance.FocusedRow.BackColor = Color.Green
        'GridView1.Appearance.SelectedRow.BackColor = Color.Green
        'GridView1.Appearance.FocusedCell.BackColor = Color.Green
        'GridView1.OptionsSelection.EnableAppearanceHideSelection = False

    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged

        Dim tempTglBayar As Date

        If e.Column.FieldName = "Tanggal Bayar" Then

            contract = txtHidden.Text
            tempTglBayar = e.Value

            If Not GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar")).ToString() = "" Then
                StrSQL = ""
                StrSQL = String.Format("Select * From Denda INNER JOIN ContractDetail ON Denda.ContractID = ContractDetail.ContractID AND ContractDetail.contractID ='{0}' AND ContractDetail.TglBayar='{1}'", contract, tempTglBayar)
                RunSQL(StrSQL, 1)

                If dt.Rows.Count > 0 Then
                    With ListKwitansi
                        .TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
                        .Items.Clear()
                        StrSQL = ""
                        StrSQL = "SELECT NoKwitansi From Kwitansi Where StatusKwitansi='Belum Terpakai'"
                        StrSQL &= String.Format(" OR (StatusKwitansi='Terpakai' AND TglBayar='{0}' AND ContractID ='{1}') ORDER BY NoKwitansi ASC", tempTglBayar, txtHidden.Text)
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

    End Sub
    Private Sub detail_SAV()
        Dim contract As String = txtHidden.Text
        Dim tglBayar As Date = GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar"))
        Dim outstanding As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding"))
        Dim outstandingRe As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"))
        Dim outstandingTo As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Total"))
        Dim index As Integer = GridView1.GetFocusedRowCellValue(GridView1.Columns("Angs Ke"))
        Dim Nokwitansi As String = GridView1.GetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"))
        Dim alasan As String = "Pembayaran Denda Angsuran Ke " & index & " sebesar Rp. " & outstandingRe & "."

        StrSQL = ""
        StrSQL = "UPDATE ContractDetail SET "
        StrSQL &= "OutstandingReceive = Case When OutstandingReceive IS NULL THEN " & outstandingRe & " "
        StrSQL &= " ELSE OutstandingReceive+" & outstandingRe & " END "
        StrSQL &= "WHERE ContractID ='" & txtHidden.Text & "' "
        StrSQL &= "AND [index]= " & index - 1 & ""
        RunSQL(StrSQL, 0)


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
        'StrSQL &= "Nominal=Nominal+ " & totalBayar & ","
        StrSQL &= "MemberID ='" & memberID & "', "
        StrSQL &= "CaraBayar='" & cmbCaraBayar.Text & "' "
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


        '  If outstanding + outstandingRe < 0 Then
        denda_SAV(outstandingRe, index, contract)
        FillGrid()
        '  End If

    End Sub

    Private Sub denda_SAV(ByVal OutstandingRe As Integer, ByVal index As Integer, ByVal kontrak As String)
        Dim tglBayar As Date = GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar"))
        Dim Nokwitansi As String = GridView1.GetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"))
        OutstandingRe = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"))
        StrSQL = ""
        StrSQL = "UPDATE Denda Set OutstandingTotal = OutstandingTotal +" & OutstandingRe & ", "
        StrSQL &= "TglBayar='" & tglBayar & "',NoKwitansi='" & Nokwitansi & "', "
        StrSQL &= "OutstandingReceive=OutstandingReceive+" & OutstandingRe & " "
        StrSQL &= " WHERE ContractId='" & kontrak & "' "
        StrSQL &= " AND [index]= " & index & ""

        RunSQL(StrSQL, 0)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmTabKontrak.txtFlag.Text = "2"
        frmTabKontrak.Show()
        frmTabKontrak.BringToFront()
    End Sub

    Private Sub txtKontrak_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKontrak.TextChanged

        StrSQL = ""
        StrSQL = String.Format("SELECT * FROM DENDA WHERE ContractID ='{0}'", antisqli(txtKontrak.Text))
        RunSQL(StrSQL, 1)

        If dt.Rows.Count > 0 Then
            DataFlag = True
            FillGrid()
            FillForm()
            FillKwitansi()
            FillPembayaran()

        Else
            DataFlag = False
            GridControl1.DataSource = Nothing
            ClearForm()


        End If

        

    End Sub

    'Private Sub GridView1_ValidateRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView1.ValidateRow
    '    Try
    '        outstandingRe = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"))
    '        kwitansi = GridView1.GetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"))

    '        If GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar")).ToString() = "" Or outstandingRe = "0" Or kwitansi = "" Then
    '            FillGrid()
    '            ListKwitansi.Items.Clear()
    '        Else
    '            Dim result As Integer = MessageBox.Show("Transaksi akan disimpan dan tidak bisa diubah !", "Perhatian !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    '            If result = DialogResult.Yes Then
    '                detail_SAV()
    '                ListKwitansi.Items.Clear()
    '            ElseIf result = DialogResult.No Then
    '                FillGrid()
    '                ListKwitansi.Items.Clear()
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try


    'End Sub

    Private Sub GridView1_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Dim View As GridView = CType(sender, GridView)
        If (e.RowHandle >= 0) Then

            'Dim tglBayar As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Tanggal Bayar"))
            'Dim OutstandingRe As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Outstanding Receive"))
            'Dim kwitansi As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Nomor Kwitansi"))
            Dim OutstandingTotal As Integer = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Outstanding Total"))
            If OutstandingTotal < 0 Then
                e.Appearance.BackColor = Color.Yellow
            Else

                e.Appearance.BackColor = Color.Red

            End If

        End If


       

    End Sub

    Private Function cekBayar(ByVal view As GridView, ByVal row As Integer) As Boolean
        Dim col As GridColumn = view.Columns("Outstanding Total")
        Dim val As Integer = CInt(view.GetRowCellValue(row, col))

        ' If Not GridView1.GetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar")).ToString() = "" And Not GridView1.GetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi")).ToString() = "unpaid" Then
        If val > 0 Then
            cekBayar = True
        Else
            cekBayar = False
        End If
        ' Else
        'cekBayar = False
        ' End If


        Return cekBayar
    End Function

    Private Sub PembayaranDenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillPIC()
        cmbCaraBayar.SelectedIndex = 0
        ClearForm()
        setTanggal(dtBayar)
    End Sub

    Private Sub GridView1_ShowingEditor(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridView1.ShowingEditor
        Dim View As GridView = CType(sender, GridView)

        If (View.FocusedColumn.FieldName = "Outstanding Receive" Or View.FocusedColumn.FieldName = "Tanggal Bayar" Or View.FocusedColumn.FieldName = "Nomor Kwitansi") And cekBayar(View, View.FocusedRowHandle) = True Then
            e.Cancel = True
        End If


    End Sub

    Private Sub FillPIC()
        Dim tablePIC As DataTable = Nothing
        StrSQL = ""
        StrSQL = "SELECT EmployeeID,EmployeeName FROM Employee Where PositionID = 'PC' ORDER BY EmployeeName ASC"
        FillCombobox(StrSQL, cmbPIC, 2, tablePIC)
    End Sub

    Private Sub ClearForm()
        txtKonsumen.Clear()
        txtAlamat.Clear()
        txtObjek.Clear()
        txtBulan.Clear()
        txtTenor.Clear()
        txtMesin.Clear()
        txtBayar.Clear()
        btnBayar.Enabled = False
        txtTipe.Clear()
        txtDenda.Clear()
        cmbAngsuran.DataSource = Nothing
        cmbAngsuran.Items.Clear()
        cmbKwitansi.DataSource = Nothing
        cmbKwitansi.Items.Clear()
        InitOutstandingReceive = 0
    End Sub

    Private Sub FillPembayaran()
        'isi combobox dengan angsuran
        Dim dtAngsuran As New DataTable
        StrSQL = ""
        StrSQL = "SELECT [index] as Angs From Denda Where ContractID='" & antisqli(txtKontrak.Text) & "' AND OutstandingTotal < 0 "
        FillCombobox(StrSQL, cmbAngsuran, 1, dtAngsuran)
        GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(CInt(cmbAngsuran.SelectedIndex))
        GridView1.Appearance.FocusedRow.BackColor = Color.Green
        GridView1.Appearance.SelectedRow.BackColor = Color.Green
        GridView1.Appearance.FocusedCell.BackColor = Color.Green
        GridView1.OptionsSelection.EnableAppearanceHideSelection = False

        'isi denda
        Dim denda As Double = CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Total"))) * -1
        txtDenda.Text = ribuan(CStr(denda))

    End Sub

    Private Sub cmbAngsuran_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAngsuran.SelectedValueChanged
        If DataFlag = True Then
            GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(CInt(cmbAngsuran.SelectedIndex))
            GridView1.Appearance.FocusedRow.BackColor = Color.Green
            GridView1.Appearance.SelectedRow.BackColor = Color.Green
            GridView1.Appearance.FocusedCell.BackColor = Color.Green
            GridView1.OptionsSelection.EnableAppearanceHideSelection = False
        End If

    End Sub

    Private Sub GridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If DataFlag = True Then
            Dim denda As Double = CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Total"))) * -1
            txtDenda.Text = ribuan(CStr(denda))
            txtBayar.Clear()

            If Not GridControl1.DataSource Is Nothing Then
                InitOutstandingReceive = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"))
                'MessageBox.Show(CStr(InitOutstandingReceive))
            End If

        End If

    End Sub

    Private Sub GridView1_MouseDown(ByVal sender As System.Object, ByVal e As DevExpress.Utils.DXMouseEventArgs) Handles GridView1.MouseDown
        e.Handled = True
    End Sub

    Private Sub GridView1_MouseUp(ByVal sender As System.Object, ByVal e As DevExpress.Utils.DXMouseEventArgs) Handles GridView1.MouseUp
        e.Handled = True
    End Sub

   

    Private Sub txtBayar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBayar.TextChanged
        If DataFlag = True Then
            If txtBayar.Text <> "" Then
                If txtBayar.Text > 0 Then
                    btnBayar.Enabled = True
                    ChangingGridValue()
                Else
                    btnBayar.Enabled = False
                End If
            Else
                txtBayar.Text = 0
                ChangingGridValue()
            End If
           
        Else
            btnBayar.Enabled = False

        End If
    End Sub

    Private Sub txtBayar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBayar.KeyPress
        decimalOnly(txtBayar, e, txtBayar.Text)
       

    End Sub

    Private Sub FillKwitansi()
        Dim dtKwitansi As New DataTable

        cmbKwitansi.DataSource = Nothing
        cmbKwitansi.Items.Clear()

        If DataFlag = True Then
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
        Else
            cmbKwitansi.DataSource = Nothing
            cmbKwitansi.Items.Clear()
        End If
    End Sub

    Private Sub dtBayar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtBayar.ValueChanged
        If DataFlag = True Then
            FillKwitansi()
        Else
            cmbKwitansi.DataSource = Nothing
            cmbKwitansi.Items.Clear()
        End If
    End Sub

    Private Sub btnBayar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBayar.Click
        If DataFlag = True And txtBayar.Text > 0 Then
            Pembayaran()

        End If
    End Sub
    Private Sub Pembayaran()
        Dim message As String
        message = "Detail Pembayaran Denda : " & vbNewLine
        Message &= "Nomor Kontrak " & vbTab & ": " & txtKontrak.Text & vbNewLine
        Message &= "Nama Konsumen " & vbTab & ": " & txtKonsumen.Text & vbNewLine
        message &= "Angsuran Ke " & vbTab & ": " & cmbAngsuran.Text & vbNewLine
        Message &= "Jumlah Bayar " & vbTab & ": " & txtBayar.Text & vbNewLine
        Message &= "Anda ingin menginput pembayaran diatas ? "
        Dim result As Integer = MessageBox.Show(Message, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = vbYes Then
            Try
                PembayaranDenda()
                Pendapatan_SAV()
                MessageBox.Show("Pembayaran Denda Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim oldContract = txtKontrak.Text
                txtKontrak.Text = ""
                txtKontrak.Text = oldContract
            Catch ex As Exception
                MessageBox.Show("Proses Gagal Dilakukan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ChangingGridValue()
        Try
            Dim BeginValue As New Double
            StrSQL = ""
            StrSQL = "SELECT OutstandingReceive From Denda Where ContractID='" & txtKontrak.Text & "' AND [index]= " & cmbAngsuran.Text & " "
            RunSQL(StrSQL, 1)
            BeginValue = 0
            BeginValue = CDbl(dt.Rows(0)("OutstandingReceive"))

            GridView1.SetFocusedRowCellValue(GridView1.Columns("Tanggal Bayar"), dtBayar.Value)
            GridView1.SetFocusedRowCellValue(GridView1.Columns("Nomor Kwitansi"), cmbKwitansi.Text)
            GridView1.SetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"), BeginValue + CDbl(txtBayar.Text))

            Dim bayar As Double = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"))
            Dim Total As Double = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding"))

            GridView1.SetFocusedRowCellValue(GridView1.Columns("Outstanding Total"), Total + bayar)
        Catch ex As Exception

        End Try

      

    End Sub

#Region "Proses Pembayaran"
    Private Sub PembayaranDenda()
        Dim ContractId As String = antisqli(txtKontrak.Text)
        Dim index As Integer = CInt(cmbAngsuran.Text)
        Dim TglBayar As String = antisqli(dtBayar.Value.Date)
        Dim outstanding As Double = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding"))
        Dim outstandingreceive As Double = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Receive"))
        Dim outstandingtotal As Double = GridView1.GetFocusedRowCellValue(GridView1.Columns("Outstanding Total"))
        Dim NoKwitansi As String = antisqli(cmbKwitansi.Text)
        Dim CaraBayar As String = antisqli(cmbCaraBayar.Text)
        Dim PIC2 As String = antisqli(cmbPIC.SelectedValue)
        Dim nominal As Double = CDbl(txtBayar.Text)
        Dim statusKwitansi As String = "Terpakai"
        Dim AlasanAdd As String = "Pembayaran Denda Angsuran ke-" & index & " sebesar Rp." & ribuan(txtBayar.Text) & "."
        Dim Alasan As String
        Dim MemberID As String

        'Deklarasi alasan

        StrSQL = ""
        StrSQL = "Select Alasan From Kwitansi Where NoKwitansi='" & antisqli(cmbKwitansi.Text) & "'"
        If dt.Rows.Count > 0 Then
            Alasan = dt.Rows(0)("Alasan") & AlasanAdd
        Else
            Alasan = AlasanAdd
        End If

        'Deklarasi MemberID
        StrSQL = ""
        StrSQL = "Select MemberID From Application Where ContractId='" & antisqli(txtKontrak.Text) & "' "
        If dt.Rows.Count > 0 Then
            MemberID = dt.Rows(0)("MemberID")
        Else
            MemberID = ""
        End If

        StrSQL = ""
        StrSQL = "EXEC Sp_PembayaranDenda "
        StrSQL &= "'" & ContractId & "'"
        StrSQL &= "," & index & ""
        StrSQL &= ",'" & TglBayar & "'"
        StrSQL &= "," & outstanding & ""
        StrSQL &= "," & outstandingreceive & ""
        StrSQL &= "," & outstandingtotal & ""
        StrSQL &= ",'" & NoKwitansi & "'"
        StrSQL &= ",'" & CaraBayar & "'"
        StrSQL &= ",'" & PIC2 & "'"
        StrSQL &= ",'" & statusKwitansi & "'"
        StrSQL &= ",'" & Alasan & "'"
        StrSQL &= ",'" & MemberID & "'"
        StrSQL &= "," & nominal & ""
        RunSQL(StrSQL, 0)
    End Sub
#End Region

    Private Sub Pendapatan_SAV()
        Try
            StrSQL = ""
            StrSQL = "Sp_BankIU "
            StrSQL &= "'IN_BUNGA', "
            StrSQL &= "'" & txtKontrak.Text & "', "
            StrSQL &= "'" & dtBayar.Value.Date & "', "
            StrSQL &= "" & CDbl(txtBayar.Text) & ", "
            StrSQL &= "'" & UserName & "' "
            RunSQL(StrSQL, 0)
        Catch ex As Exception

        End Try
      
    End Sub

End Class