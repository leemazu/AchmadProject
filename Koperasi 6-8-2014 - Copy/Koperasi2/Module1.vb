Option Strict On
Imports System.Data.SqlClient

Public Module Module1

#Region "parameter public"
    Public formFlag As String = "0"
    Public testString As String = ""
    Public oldAppID As String = ""
    Public oldMemberID As String = ""
    Public posFlag As Boolean = False
    Public begginingState As String = ""
    Public kontrakFlag As Integer = 0
    Public levelUser As Integer
    Public EmployeeID As String
    Public UserName As String
    '1 = pinjaman dana
    '2 = pinjaman motor baru
    '3 = Elektronik
    '4 = KTA

    'Istilah di program - Database

    'Pinjaman,HargaBarang,HargaMotor -> MotorPrice
    'Premi Asuransi -> InsuranceRate
    'Admin -> InsuranceAdmin
    'Tingkat Bunga Efektif -> EffectiveInterestP
    'Admin Kredit -> LoanAdmin
    '
#End Region



#Region "connection local"

    Public conn As SqlConnection
    Public con_server As String
    Public con_userid As String
    Public con_password As String
    Public con_database As String
    Public con_string As String
    Public strconn As String
    Public cmd As New SqlCommand
    Public rdr As SqlDataReader
    Public da As New SqlDataAdapter
    Public ds As New DataSet
    Public dt As New DataTable
    Public str As String
    Public stateApp As String
    Public stateMember As String
    Public strtest As String
    Public noAplikasi As String
    Public alertmsg As String
    Public StrSQL As String
    Public _isRollBackMode As Boolean
    Public _isRollBackModePemohon As Boolean
    Public flagSQL As Boolean
    Public errorMessage As String

    Public Sub con_getsetting()
        con_server = GetSetting("achmad", "config", "server", "")
        con_userid = GetSetting("achmad", "config", "userid", "")
        con_password = GetSetting("achmad", "config", "password", "")
        con_database = GetSetting("achmad", "config", "database", "")
    End Sub

    Public Sub con_savesetting(ByVal server As String, ByVal userid As String, ByVal password As String, ByVal database As String)
        Call SaveSetting("achmad", "config", "server", server)
        Call SaveSetting("achmad", "config", "userid", userid)
        Call SaveSetting("achmad", "config", "password", password)
        Call SaveSetting("achmad", "config", "database", database)
        Call con_getsetting()
    End Sub

    Public Function conn_open() As Boolean
        Try
            con_string = "data source={0};user id={1};password={2};initial catalog={3}"
            con_string = String.Format(con_string, con_server, con_userid, con_password, con_database)
            conn = New SqlConnection(con_string)
            conn.Open()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    'Public Sub txtDataLoad(ByVal obj1 As TextBox, ByVal obj2 As Object)
    '    Dim hasil As String = ""
    '    If IsDBNull(obj2) OrElse obj2 Is Nothing OrElse obj2.ToString().Trim() = "" Then
    '        obj1.Text = ""
    '    Else
    '        obj1.Text = obj2
    '    End If

    'End Sub


    Public Function RunSQL(ByVal SQLCommand As String, ByVal Flag As Integer, Optional ByVal Table As String = "", Optional ByVal ComboTable As DataTable = Nothing, Optional ByVal Dataset As DataSet = Nothing) As Boolean

        Try

            Call conn_open()
            cmd = New SqlCommand(SQLCommand, conn)
            If Flag = 0 Then 'Contoh penggunaan untuk query INSERT 
                cmd.ExecuteNonQuery()
            ElseIf Flag = 1 Then 'Contoh Penggunaan Untuk mengambil data per kolom , biasa untuk ambil data per variable 
                With dt
                    .Clear()
                    'dt = New DataTable
                    rdr = cmd.ExecuteReader()
                    Try
                        .Load(rdr)
                    Catch ex As Exception
                    End Try
                    conn.Close()
                    Return True
                End With
            ElseIf Flag = 2 Then ' biasa digunakan untuk gridview
                da = New SqlDataAdapter(cmd)
                'Dataset = New DataSet
                da.Fill(Dataset, Table)
            ElseIf Flag = 3 Then
                'hanya jika pakai table dengan 2 Kolom (ID dan Value) , biasa untuk isi combobox
                With ComboTable
                    .Rows.Clear()
                    rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        .Rows.Add(rdr(0), rdr(1))
                    End While
                    conn.Close()
                    Return True
                End With



            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        conn.Close()
        Return True



    End Function


#End Region


#Region "Connection Report"


 




#End Region

#Region "AutoNumber"
    Public Function autoNumberMember(ByVal pos As String) As String
        Dim tempID As String = ""
        Dim tempTahun As String = ""
        Dim tempTahun2 As String = ""
        Dim tempBulan As String = ""
        Dim tempBulan2 As String = ""
        Dim tempKode As String = ""
        Dim tempDigit As Integer = 0
        Dim tempLastCode As String = ""
        Dim tempPos As String = ""

        tempTahun = Convert.ToString(Year(Now))
        tempTahun2 = Microsoft.VisualBasic.Right(tempTahun, 2)
        tempBulan = Convert.ToString(Month(Now))

        If tempBulan.Length < 2 Then
            tempBulan2 = "0" + tempBulan
        End If

        If pos = "Clara I" Then
            tempPos = CStr(101)
        Else
            tempPos = CStr(106)

        End If

        tempKode = tempPos & "AG"


        ' strcmd = "SELECT APPLICATIONID FROM APPLICATION WHERE APPLICATIONID LIKE '" + tempKode + "%' ORDER BY APPLICATIONID DESC"
        Call conn_open()
        StrSQL = ""
        StrSQL = "SELECT MEMBERID FROM MEMBER WHERE MEMBERID LIKE '" + tempKode + "%' ORDER BY MEMBERID DESC"
        'cmd = New SqlCommand(str, conn)
        'da = New SqlDataAdapter(cmd)
        RunSQL(StrSQL, 1)
        ' rdr = cmd.ExecuteReader()
        If dt.Rows.Count > 0 Then
            tempID = dt.Rows(0)("memberid").ToString
            'tempDigit = Convert.ToInt32(Microsoft.VisualBasic.Right(tempID, 4))
            tempDigit = Convert.ToInt32(tempID.Substring(5, 4))
            tempDigit = tempDigit + 1
            tempLastCode = CStr(generateCode4Digit(Convert.ToString(tempDigit)))

            tempID = tempKode + tempLastCode + tempTahun2

        Else
            tempID = tempKode + "0001" + tempTahun2
        End If
        ' conn.Close()
        ' txtAplikasi.Text = tempID
        noAplikasi = tempID
        Return tempID

    End Function

    Public Function autoNumber(ByVal pos As String) As String
        Dim tempID As String = ""
        Dim tempTahun As String = ""
        Dim tempTahun2 As String = ""
        Dim tempBulan As String = ""
        Dim tempBulan2 As String = ""
        Dim tempKode As String = ""
        Dim tempDigit As Integer = 0
        Dim tempLastCode As String = ""
        Dim tempPos As String = ""


        tempTahun = Convert.ToString(Year(Now))
        tempTahun2 = Microsoft.VisualBasic.Right(tempTahun, 2)
        tempBulan = Convert.ToString(Month(Now))

        If tempBulan.Length < 2 Then
            tempBulan2 = "0" + tempBulan
        End If

        If pos = "Clara I" Then
            tempPos = CStr(101)
        Else
            tempPos = CStr(106)

        End If

        tempKode = tempPos & "AP"



        ' strcmd = "SELECT APPLICATIONID FROM APPLICATION WHERE APPLICATIONID LIKE '" + tempKode + "%' ORDER BY APPLICATIONID DESC"
        Call conn_open()
        StrSQL = ""
        StrSQL = "SELECT APPLICATIONID FROM APPLICATION WHERE APPLICATIONID LIKE '" + tempKode + "%' ORDER BY APPLICATIONID DESC"
        'cmd = New SqlCommand(str, conn)
        'da = New SqlDataAdapter(cmd)
        'rdr = cmd.ExecuteReader()
        RunSQL(StrSQL, 1)
        If dt.Rows.Count > 0 Then
            tempID = dt.Rows(0)("applicationid").ToString
            'tempDigit = Convert.ToInt32(Microsoft.VisualBasic.Right(tempID, 4))
            tempDigit = Convert.ToInt32(tempID.Substring(5, 4))
            tempDigit = tempDigit + 1
            tempLastCode = CStr(generateCode4Digit(Convert.ToString(tempDigit)))

            tempID = tempKode + tempLastCode + tempTahun2

        Else
            tempID = tempKode + "0001" + tempTahun2
        End If

        ' txtAplikasi.Text = tempID
        noAplikasi = tempID
        str = ""



        Return tempID

    End Function

    Function CreateAutoNumber(ByVal KodeDepan As String, ByVal digitKode As Integer, Optional ByVal KodeTerakhir As String = "") As String
        CreateAutoNumber = ""
        Dim tempID As String = ""
        Dim lastDigit As String = ""



        If KodeTerakhir = "" Then
            lastDigit = "1"
        Else
            KodeTerakhir = Microsoft.VisualBasic.Right(KodeTerakhir, digitKode)
            lastDigit = CStr(CInt(KodeTerakhir) + 1)
        End If

        Select Case digitKode
            Case 4
                tempID = KodeDepan & generateCode4Digit(lastDigit)
            Case 5
                tempID = KodeDepan + generateCode5Digit(lastDigit)
            Case 6
                tempID = KodeDepan + generateCode6Digit(lastDigit)
        End Select


        Return tempID
    End Function

    Function generateCode4Digit(ByVal digit As String) As String
        Dim hasil As String = ""

        If digit.Length = 1 Then
            hasil = "000" + digit
        ElseIf digit.Length = 2 Then
            hasil = "00" + digit
        ElseIf digit.Length = 3 Then
            hasil = "0" + digit
        Else
            hasil = digit
        End If


        generateCode4Digit = hasil

    End Function
    Function generateCode5Digit(ByVal digit As String) As String
        Dim hasil As String = ""

        If digit.Length = 1 Then
            hasil = "0000" + digit
        ElseIf digit.Length = 2 Then
            hasil = "000" + digit
        ElseIf digit.Length = 3 Then
            hasil = "00" + digit
        ElseIf digit.Length = 4 Then
            hasil = "0" + digit
        Else
            hasil = digit
        End If


        generateCode5Digit = hasil

    End Function
    Function generateCode6Digit(ByVal digit As String) As String
        Dim hasil As String = ""

        If digit.Length = 1 Then
            hasil = "00000" + digit
        ElseIf digit.Length = 2 Then
            hasil = "0000" + digit
        ElseIf digit.Length = 3 Then
            hasil = "000" + digit
        ElseIf digit.Length = 4 Then
            hasil = "00" + digit
        ElseIf digit.Length = 5 Then
            hasil = "0" + digit
        Else
            hasil = digit
        End If


        generateCode6Digit = hasil

    End Function

    Function AutoNumberContract(ByVal noAplikasi As String, ByVal state As String) As String

        Dim NoKontrak As String = ""
        Dim LastNo As String = ""
        Dim Tahun As String = ""
        Dim TempKode As String = ""
        Dim TempDigit As New Integer

        NoKontrak = Left(noAplikasi, 3)
        NoKontrak &= state

        Tahun = Microsoft.VisualBasic.Right(Convert.ToString(Year(Now)), 2)

        StrSQL = ""
        StrSQL = "SELECT ContractID From Contract WHERE ContractID LIKE '" & NoKontrak & "%' ORDER BY ContractID DESC "
        RunSQL(StrSQL, 1)

        If dt.Rows.Count > 0 Then
            TempKode = CStr(dt.Rows(0)("ContractID"))
            TempDigit = Convert.ToInt32(TempKode.Substring(5, 5))
            TempDigit = TempDigit + 1
            TempKode = generateCode5Digit(CStr(TempDigit))
        Else
            TempKode = "00001"

        End If

        NoKontrak &= TempKode & Tahun


        Return NoKontrak
    End Function

#End Region
#Region "table combobox"

    Public tableSalesman As DataTable = CType(getTable(), DataTable)
    Public tableGender As DataTable = CType(getTable(), DataTable)
    Public tableKodeposPemohon As DataTable = CType(getTable(), DataTable)
    Public tableKodeposPerusahaan As DataTable = CType(getTable(), DataTable)
    Public tableKodeposKontak As DataTable = CType(getTable(), DataTable)
    Public tableKodeposBpkb As DataTable = CType(getTable(), DataTable)
    Public tableKodeposPenagihan As DataTable = CType(getTable(), DataTable)
    Public tablePekerjaan As DataTable = CType(getTable(), DataTable)
    Public tablePos As DataTable = CType(getTable(), DataTable)
    Public tableSY As DataTable = CType(getTable(), DataTable)
    Public tableCA As DataTable = CType(getTable(), DataTable)
    Public tableJob As DataTable = CType(getTable(), DataTable)
    ' Public tableCombo As DataTable = getTable()

    Public Function getTable() As DataTable
        Dim table As New DataTable
        table.Columns.Add("ID", GetType(String))
        table.Columns.Add("NAMA", GetType(String))

        Return table

    End Function

    Public Function getTableCombo() As DataTable
        Dim table As New DataTable
        table.Columns.Add("1", GetType(String))
        table.Columns.Add("2", GetType(String))
        Return table

    End Function
#End Region
    Public Sub FillCombobox(ByVal strSql As String, ByVal combobox As ComboBox, ByVal numberSelected As Integer, ByVal table As DataTable)
        table = getTableCombo()
        With table
            .Rows.Clear()
            Call conn_open()
            cmd = New SqlCommand(strSql, conn)
            rdr = cmd.ExecuteReader()

            If numberSelected = 2 Then
                While rdr.Read()
                    .Rows.Add(rdr(0), rdr(1))
                End While
            Else
                While rdr.Read()
                    .Rows.Add(rdr(0))
                End While
            End If
            conn.Close()
        End With

        With combobox
            .DataSource = Nothing
            .Items.Clear()
            .DataSource = table
            If numberSelected = 2 Then
                .ValueMember = "1"
                .DisplayMember = "2"
            Else
                .ValueMember = "1"
                .DisplayMember = "1"
            End If
            
        End With

    End Sub

#Region "fillCombobox"
    Public Sub FillKota(ByVal cmbKota As ComboBox)
        With cmbKota
            .Items.Clear()
            Call conn_open()
            StrSQL = "select distinct City from [__AddrLocation] where City like 'JAKARTA%' or City like 'Kepulauan Seribu' order by City asc"
            'RunSQL(StrSQL, 2)
            cmd = New SqlCommand(StrSQL, conn)
            rdr = cmd.ExecuteReader()

            While rdr.Read()
                .Items.Add(rdr("City"))
                .SelectedIndex = 0
            End While
            conn.Close()

        End With

    End Sub

    Public Sub FillKecamatan(ByVal cmbKec As ComboBox, ByVal kota As String)

        With cmbKec
            .Items.Clear()
            conn.Open()
            str = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + kota + "' ORDER BY [SubDistrict] ASC"
            cmd = New SqlCommand(str, conn)
            rdr = cmd.ExecuteReader()

            While rdr.Read()
                .Items.Add(rdr("SubDistrict"))
                .SelectedIndex = 0
            End While
            conn.Close()

        End With
    End Sub

    Public Sub FillKelurahan(ByVal cmbKel As ComboBox, ByVal kecamatan As String, ByVal table As DataTable)
        With cmbKel

            With table
                .Rows.Clear()
                conn.Open()
                cmd = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + kecamatan + "' ORDER BY [Village] ASC", conn)
                rdr = cmd.ExecuteReader()
                While rdr.Read()
                    .Rows.Add(rdr("AddrLocationID"), rdr("Village"))
                End While
                conn.Close()
            End With

            .DataSource = table
            .ValueMember = "ID"
            .DisplayMember = "NAMA"

        End With
    End Sub

    Public Sub FillComboWithValue(ByVal Combo As ComboBox, ByVal SQLCommand As String, ByVal TableTarget As DataTable)

        With Combo
            RunSQL(SQLCommand, 3, "", TableTarget)
            .Items.Clear()
            .DataSource = TableTarget
            .ValueMember = "ID"
            .DisplayMember = "NAMA"
        End With
    End Sub

    Public Sub fillPos(ByVal pos As ComboBox)
        With pos

            With tablePos
                tablePos.Rows.Clear()
                conn.Open()
                cmd = New SqlCommand("exec Sp_Reference_CBO 'POS'", conn)
                rdr = cmd.ExecuteReader()
                While rdr.Read()
                    .Rows.Add(rdr("ReferenceId"), rdr("ReferenceName"))
                End While
                conn.Close()
            End With

            .DataSource = tablePos
            .ValueMember = "ID"
            .DisplayMember = "NAMA"

        End With


    End Sub

    Public Sub FillSalesman(ByVal cmbSalesman As ComboBox)
        With cmbSalesman

            With tableSalesman
                tableSalesman.Rows.Clear()
                conn.Open()
                cmd = New SqlCommand("exec SpEmployee_CBO 'SM'", conn)
                rdr = cmd.ExecuteReader()
                While rdr.Read()
                    .Rows.Add(rdr("EmployeeID"), rdr("EmployeeName"))
                End While
                conn.Close()
            End With

            .DataSource = tableSalesman
            .ValueMember = "ID"
            .DisplayMember = "NAMA"


        End With
    End Sub

    Public Sub FillCA(ByVal cmbCa As ComboBox)
        With cmbCa

            With tableCA
                tableCA.Rows.Clear()
                conn.Open()
                cmd = New SqlCommand("exec SpEmployee_CBO 'CA'", conn)
                rdr = cmd.ExecuteReader()
                While rdr.Read()
                    .Rows.Add(rdr("EmployeeID"), rdr("EmployeeName"))
                End While
                conn.Close()
            End With

            .DataSource = tableCA
            .ValueMember = "ID"
            .DisplayMember = "NAMA"
        End With



    End Sub

    Public Sub FillSurveyor(ByVal cmbSurveyor As ComboBox)
        With cmbSurveyor

            With tableSY
                tableSY.Rows.Clear()
                conn.Open()
                cmd = New SqlCommand("exec SpEmployee_CBO 'SY'", conn)
                rdr = cmd.ExecuteReader()
                While rdr.Read()
                    .Rows.Add(rdr("EmployeeID"), rdr("EmployeeName"))
                End While
                conn.Close()
            End With

            .DataSource = tableSY
            .ValueMember = "ID"
            .DisplayMember = "NAMA"
        End With

    End Sub

    Public Sub FillGender(ByVal gender As ComboBox)
        With gender
            With tableGender
                tableGender.Rows.Clear()
                conn.Open()
                cmd = New SqlCommand("exec Sp_Reference_CBO 'GEN'", conn)
                rdr = cmd.ExecuteReader()
                While rdr.Read()
                    .Rows.Add(rdr("ReferenceID"), rdr("ReferenceName"))
                End While
                conn.Close()
            End With

            .DataSource = tableGender
            .ValueMember = "ID"
            .DisplayMember = "NAMA"
        End With
    End Sub

    Public Sub FillJob(ByVal job As ComboBox)

        With job
            With tableJob
                tableJob.Rows.Clear()
                conn.Open()
                cmd = New SqlCommand("Sp_Reference_CBO 'TWC'", conn)
                rdr = cmd.ExecuteReader()
                While rdr.Read()
                    .Rows.Add(rdr("ReferenceID"), rdr("ReferenceName"))
                End While
                conn.Close()
            End With

            .DataSource = tableJob
            .ValueMember = "ID"
            .DisplayMember = "NAMA"
        End With
    End Sub


#End Region

#Region "changed combobox"

    'Public Sub ChangedKota(ByVal cmbKota As ComboBox)
    '    With cmbKota
    '        .Items.Clear()
    '        connCh.Open()
    '        strCh = "select distinct City from [__AddrLocation] where City like 'JAKARTA%' or City like 'Kepulauan Seribu' order by City asc"
    '        cmdCh = New SqlCommand(strCh, connCh)
    '        rdrCh = cmdCh.ExecuteReader()

    '        While rdrCh.Read()
    '            .Items.Add(rdrCh("City"))
    '            .SelectedIndex = 0
    '        End While
    '        connCh.Close()

    '    End With

    'End Sub

    Public Sub ChangedKecamatan(ByVal cmbKec As ComboBox, ByVal kota As String)
        Dim strconnCh As String = "Integrated Security=SSPI;Data Source=MIAOW-PC\SQLEXPRESS;" & _
         "Initial Catalog=SimpanPinjam;Persist Security Info=True;" & _
         "User ID=sa;Password=asdf"
        Dim connCh As New SqlConnection(strconnCh)
        Dim cmdCh As New SqlCommand
        Dim rdrCh As SqlDataReader
        Dim strCh As String

        With cmbKec
            .Items.Clear()
            connCh.Open()
            strCh = "select distinct [SubDistrict] from [__AddrLocation] WHERE CITY ='" + kota + "' ORDER BY [SubDistrict] ASC"
            cmdCh = New SqlCommand(strCh, connCh)
            rdrCh = cmdCh.ExecuteReader()

            While rdrCh.Read()
                .Items.Add(rdrCh("SubDistrict"))
                .SelectedIndex = 0
            End While
            connCh.Close()

        End With
    End Sub

    Public Sub ChangedKelurahan(ByVal cmbKel As ComboBox, ByVal kecamatan As String, ByVal table As DataTable)
        Dim strconnKel As String = "Integrated Security=SSPI;Data Source=MIAOW-PC\SQLEXPRESS;" & _
         "Initial Catalog=SimpanPinjam;Persist Security Info=True;" & _
         "User ID=sa;Password=asdf"
        Dim connKel As New SqlConnection(strconnKel)
        Dim cmdKel As New SqlCommand
        Dim rdrKel As SqlDataReader

        ' Dim tableKodepos() As DataTable = getTable()

        With table
            .Rows.Clear()
            ' tableKodeposPemohon.Rows.Clear()
            connKel.Open()
            cmdKel = New SqlCommand("select distinct AddrLocationID,[Village] from [__AddrLocation] WHERE SubDistrict ='" + kecamatan + "' ORDER BY [Village] ASC", connKel)
            rdrKel = cmdKel.ExecuteReader()
            While rdrKel.Read()
                .Rows.Add(rdrKel("AddrLocationID"), rdrKel("Village"))
            End While
            connKel.Close()
        End With

        With cmbKel
            .DataSource = table
            .ValueMember = "ID"
            .DisplayMember = "NAMA"

        End With
    End Sub
#End Region




    Public Function validation(ByVal obj As TextBox) As Boolean
        Dim result As Boolean = True

        If obj.Text = "" Then
            result = False
            obj.Focus()
            alertmsg = "Inputan Tidak Boleh Kosong"

        Else
            alertmsg = "Sukses"

        End If

        Return result
    End Function

    Public Function validationNumber(ByVal obj As TextBox) As Boolean
        Dim result As Boolean = True

        If obj.Text <> noAplikasi Then
            result = False
            obj.Focus()
            alertmsg = "Inputan Salah"
            obj.Text = noAplikasi

        End If

        Return result
    End Function

#Region "Fungsi Terbilang Hingga Ratusan Trilyun"
    Public Function Terbilang(ByVal Angka As Double) As String
        Dim strAngka, strDiurai, Urai, Tbl1, Tbl2 As String
        Dim x, y, z As Short
        Dim arrBelasan() As String = {"SEPULUH ", "SEBELAS ", _
            "DUA BELAS ", "TIGA BELAS ", "EMPAT BELAS ", _
            "LIMA BELAS ", "ENAM BELAS ", "TUJUH BELAS ", _
            "DELAPAN BELAS ", "SEMBILAN BELAS "}
        Dim arrSatuan() As String = {"DUA ", "TIGA ", "EMPAT ", _
            "LIMA ", "ENAM ", "TUJUH ", "DELAPAN ", "SEMBILAN "}
        Urai = ""
        'Angka yang akan dibuat terbilang dibulatkan dulu Jika ada desimalnya

        Angka = Math.Round(Angka)

        'Angka tipe Double diubah menjadi string Dihilangkan spasi dikiri atau kanan angka jika ada
        strAngka = Trim(CStr(Angka))

        'Perulangan While ...End While akan mengevaluasi angka satu per satu dan dimulai dari angka paling kiri
        'x menunjukkan iterasi ke berapa dimulai dari 1

        While (x < Len(strAngka))
            x = CShort(x + 1)
            strDiurai = Mid(strAngka, x, 1)

            'y menunjukkan angka yang sedang dievaluasi
            y = CShort(y + Val(strDiurai))

            'z menunjukkan posisi digit ke berapa
            z = CShort(Len(strAngka) - x + 1)

            ' Jika yang dievaluasi angka 1
            If Val(strDiurai) = 1 Then
                If (z = 1 Or z = 7 Or z = 10 Or z = 13) Then
                    Tbl1 = "SATU "
                ElseIf (z = 4) Then
                    If (x = 1) Then
                        Tbl1 = "SE"
                    Else
                        Tbl1 = "SATU "
                    End If
                ElseIf (z = 2 Or z = 5 Or z = 8 Or z = 11 Or z = 14) Then
                    'Ditambahkan iterasi angka berikutnya
                    x = CShort(x + 1)
                    strDiurai = Mid(strAngka, x, 1)
                    z = CShort(Len(strAngka) - x + 1)
                    Tbl2 = ""
                    Tbl1 = arrBelasan(CInt(Val(strDiurai)))
                Else
                    Tbl1 = "SE"
                End If
                'Yang dievaluasi angka 2 sampai 9
            ElseIf Val(strDiurai) > 1 And Val(strDiurai) < 10 Then
                Tbl1 = arrSatuan(CInt((Val(strDiurai)) - 2))
            Else
                Tbl1 = ""
            End If

            If (Val(strDiurai) > 0) Then
                If (z = 2 Or z = 5 Or z = 8 Or z = 11 Or _
                        z = 14) Then
                    Tbl2 = "PULUH "
                ElseIf (z = 3 Or z = 6 Or z = 9 Or z = 12 _
                        Or z = 15) Then
                    Tbl2 = "RATUS "
                Else
                    Tbl2 = ""
                End If
            Else
                Tbl2 = ""
            End If

            If (y > 0) Then
                Select Case z
                    Case 4
                        Tbl2 &= "RIBU "
                        y = 0
                    Case 7
                        Tbl2 &= "JUTA "
                        y = 0
                    Case 10
                        Tbl2 &= "MILYAR "
                        y = 0
                    Case 13
                        Tbl2 &= "TRILYUN "
                        y = 0
                End Select
            End If

            Urai = Urai & Tbl1 & Tbl2
        End While

        Terbilang = Urai & "RUPIAH"
    End Function
#End Region

#Region "anti sqlinject"
    Public Function antisqli(ByVal str As String) As String
        Return Replace(Replace(Replace(Replace(str, "'", ""), ",", ""), "`", ""), "--", "")
    End Function
#End Region

#Region "textbox desimal"
    Public Sub decimalOnly(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal text As String)

        If Char.IsControl(e.KeyChar) = False Then
            If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Then
                If text.Contains(".") Then
                    If text.Split(CChar("."))(1).Length < 4 Then
                        If Char.IsDigit(e.KeyChar) = False Then
                            e.Handled = True
                        End If
                    Else
                        e.Handled = True
                    End If
                End If
            Else
                e.Handled = True
            End If
        End If
    End Sub

#End Region

#Region "beri . ribuan"
    Public Function ribuan(ByVal angka As String) As String
        Dim hasil As String
        Try
            hasil = Format(CDbl(angka), "#,##0")

        Catch ex As Exception
            hasil = CStr(0)
            'MessageBox.Show("Format Angka Salah,Nilai akan direset")
        End Try
        Return hasil

    End Function
#End Region

    Public Sub setTanggal(ByVal obj As DateTimePicker)

        obj.Text = CStr(Now)
        obj.Format = DateTimePickerFormat.Custom
        obj.CustomFormat = "dd/MM/yyyy"

    End Sub


    Public Sub SaveErrorLog(ByVal Keterangan As String, ByVal NamaModule As String)
        StrSQL = ""
        StrSQL = "Sp_ErrorLogSave "
        StrSQL &= "'" & antisqli(Keterangan) & "',"
        StrSQL &= "'" & Now & "',"
        StrSQL &= "'" & UserName & "',"
        StrSQL &= "'" & antisqli(NamaModule) & "'"
        RunSQL(StrSQL, 0)
        MessageBox.Show("Ada Kesalahan Dalam Sistem,Hubungi Administrator Untuk Proses Pengecekan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

End Module
