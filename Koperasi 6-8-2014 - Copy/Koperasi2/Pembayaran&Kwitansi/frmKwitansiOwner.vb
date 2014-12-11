Option Strict On
Public Class frmKwitansiOwner
    Dim tableKwitansi As New DataTable
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If validation() Then
            Kwitansi_SAV()
            FreshForm()
        End If




    End Sub

    Private Function validation() As Boolean
        If txtKwitansiDr.Text.Length = txtKwitansiDr.MaxLength And txtKwitansiSm.Text.Length = txtKwitansiSm.MaxLength Then
            If txtKwitansiDr.Text > txtKwitansiSm.Text Then
                MessageBox.Show("Nomor Kwitansi Awal Tidak Boleh Lebih Kecil Dari Nomor Kwitansi Akhir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                validation = False
            Else
                validation = True
            End If
        Else
            MessageBox.Show("Nomor Kwitansi Salah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            validation = False
        End If


        Return validation
    End Function

    Private Sub frmKwitansiOwner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCombo()
        FreshForm()
        FillFilter()
        setTanggal(dtBayar)
    End Sub
    Private Sub FillFilter()
        txtFilter.Text = CStr(getFieldValue("SELECT TOP 1 NoKwitansi From Kwitansi ORDER BY NoKwitansi ASC"))
    End Sub
    Private Sub FillCombo()

        Dim tablePIC As New DataTable
        Dim tablePIC1 As New DataTable
        Dim tablePIC2 As New DataTable
        'Dim tablePIC As DataTable = CType(getTable(), DataTable)
        'StrSQL = ""
        'StrSQL = "SpEmployee_CBO 'PC'"
        'FillComboWithValue(cmbPIC, StrSQL, tablePIC)
        FillCombobox("SpEmployee_CBO 'PC'", cmbPIC, 2, tablePIC)
        FillCombobox("Select NoKwitansi From Kwitansi ORDER BY NoKwitansi ASC", cmbKwitansi, 1, tableKwitansi)
        FillCombobox("SpEmployee_CBO 'PC'", cmbPIC1, 2, tablePIC1)
        FillCombobox("SpEmployee_CBO 'PC'", cmbPIC2, 2, tablePIC2)
    End Sub

    Private Sub Kwitansi_SAV()
        Dim totalREC As Integer
        Dim tempKwitansi As Integer
        Dim tempTahun As String
        'tempKwitansi = CInt(Microsoft.VisualBasic.Left(txtKwitansiDr.Text, 6))
        tempKwitansi = CInt(txtKwitansiDr.Text)
        'tempKwitansi = CInt(txtKwitansiDr.Text)
        Dim tempFormatedKwitansi As String
        tempTahun = TextBox1.Text
        totalREC = 1 + CInt(txtKwitansiSm.Text) - CInt(txtKwitansiDr.Text)
        'totalREC = CInt(txtKwitansiSm.Text) - CInt(txtKwitansiDr.Text) + 1
        StrSQL = ""
        StrSQL = "SELECT*FROM Kwitansi Where NoKwitansi >='" & CStr(antisqli(txtKwitansiDr.Text)) & "' AND NoKwitansi <='" & CStr(antisqli(txtKwitansiSm.Text)) & "'"
        RunSQL(StrSQL, 1)

        If dt.Rows.Count = totalREC Then
            StrSQL = ""
            StrSQL = "UPDATE KwitansiOwner SET EmployeeID='" & CStr(cmbPIC.SelectedValue) & "' "
            StrSQL &= "WHERE NoKwitansi >='" & CStr(antisqli(txtKwitansiDr.Text)) & "' AND NoKwitansi <='" & CStr(antisqli(txtKwitansiSm.Text)) & "'"
            RunSQL(StrSQL, 0)
        Else
            For index As Integer = 0 To (totalREC - 1)
                tempFormatedKwitansi = CStr(tempKwitansi + index)
                tempFormatedKwitansi = CStr(generateCode6Digit(tempFormatedKwitansi)) & tempTahun
                StrSQL = ""
                StrSQL = "SELECT * FROM KWITANSI Where NoKwitansi ='" & tempFormatedKwitansi & "'"
                RunSQL(StrSQL, 1)
                If dt.Rows.Count > 0 Then
                    StrSQL = ""
                    StrSQL = "UPDATE Kwitansi SET PIC1='" & CStr(cmbPIC.SelectedValue) & "', "
                    StrSQL &= "TglAmbil='" & CStr(CDate(dtKwitansi.Value)) & "' "
                    StrSQL &= "WHERE NoKwitansi >='" & CStr(antisqli(txtKwitansiDr.Text)) & "' AND NoKwitansi <='" & CStr(antisqli(txtKwitansiSm.Text)) & "'"
                    RunSQL(StrSQL, 0)
                Else
                    StrSQL = ""
                    'StrSQL = "INSERT INTO KWITANSI VALUES ('" & tempFormatedKwitansi & "','" & CStr(CDate(dtKwitansi.Value)) & "','" & CStr(cmbPIC.SelectedValue) & "')"
                    StrSQL = "INSERT INTO KWITANSI VALUES ("
                    StrSQL &= "'" & tempFormatedKwitansi & "',"
                    StrSQL &= "'EM0043'," 'awal2 bind ke cabang
                    StrSQL &= "'',"
                    StrSQL &= "'" & CStr(CDate(dtKwitansi.Value)) & "',"
                    StrSQL &= "'Belum Terpakai',"
                    StrSQL &= "'Ada',"
                    StrSQL &= "'',"
                    StrSQL &= "0,"
                    StrSQL &= "'',"
                    StrSQL &= "'',"
                    StrSQL &= "'',"
                    StrSQL &= "0,"
                    StrSQL &= "'Pusat',"
                    StrSQL &= "'')"
                    RunSQL(StrSQL, 0)
                End If
            Next index
        End If
        MessageBox.Show("Proses Selesai")
    End Sub

    Private Sub FreshForm()
        Dim tahun As String = CStr(Year(Now))
        TextBox1.Text = Microsoft.VisualBasic.Right(tahun, 2)
        TextBox2.Text = Microsoft.VisualBasic.Right(tahun, 2)
        txtKwitansiDr.Clear()
        txtKwitansiSm.Clear()
        setTanggal(dtKwitansi)
        cmbPIC.SelectedIndex = 0


    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click

    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        decimalOnly(sender, e, txtFilter.Text)
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

        If txtFilter.Text.Length = txtFilter.MaxLength Then
            'Filter = CStr(CStr(CDbl(CDbl(Microsoft.VisualBasic.Left(txtFilter.Text, 6)) + 10)) + Microsoft.VisualBasic.Right(txtFilter.Text, 2))
            StrSQL = ""
            StrSQL = "SELECT TOP 10 NoKwitansi From Kwitansi Where NoKwitansi >= '" & txtFilter.Text & "' ORDER BY NoKwitansi ASC"
            FillCombobox(StrSQL, cmbKwitansi, 1, tableKwitansi)
        End If
    End Sub

    Private Sub cmbKwitansi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKwitansi.SelectedIndexChanged
        FillDetail()
    End Sub

    Private Sub FillDetail()
        StrSQL = ""
        StrSQL = "SELECT* FROM Kwitansi Where NoKwitansi = '" & cmbKwitansi.Text & "' "
        RunSQL(StrSQL, 1)

        If dt.Rows.Count > 0 Then
            cmbPIC1.SelectedValue = dt.Rows(0)("PIC1").ToString()
            cmbPIC2.SelectedValue = dt.Rows(0)("PIC2").ToString()
            cmbStatKwitansi.Text = dt.Rows(0)("StatusKwitansi").ToString()
            cmbFisik.Text = dt.Rows(0)("Fisik").ToString()
            txtNominal.Text = CStr(ribuan(dt.Rows(0)("Nominal").ToString()))
            txtKontrak.Text = dt.Rows(0)("ContractID").ToString()
            txtAlasan.Text = dt.Rows(0)("Alasan").ToString()
            txtNamaKonsumen.Text = getFieldValue("SELECT MemberName From Member Where MemberID='" & dt.Rows(0)("MemberID").ToString() & "' ")
            dtBayar.Value = CDate(dt.Rows(0)("TglBayar"))

        End If

    End Sub

End Class