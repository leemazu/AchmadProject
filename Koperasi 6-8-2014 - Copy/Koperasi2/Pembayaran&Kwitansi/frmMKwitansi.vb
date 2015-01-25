Option Strict On
Imports System.Xml
Public Class frmMKwitansi

    Private Sub frmMKwitansi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
    End Sub

    Private Sub ClearForm()
        setTanggal(dtAmbil)
        txtJumlah.Text = CStr(0)

        StrSQL = ""
        StrSQL = "SELECT TOP 1 NoKwitansi FROM KWITANSI WHERE NoKwitansi LIKE '%" & Microsoft.VisualBasic.Right(CStr(ParsisTahunKwitansi), 2) & "' ORDER BY NoKwitansi DESC"
        RunSQL(StrSQL, 1)
        If dt.Rows.Count = 1 Then
            txtKwitansi.Text = dt.Rows(0)("NoKwitansi").ToString()
        Else
            txtKwitansi.Text = "000000" & Microsoft.VisualBasic.Right(CStr(ParsisTahunKwitansi), 2)
        End If




    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        If txtJumlah.Value <= 0 Then
            MessageBox.Show("Masukkan Jumlah Kwitansi yang Ingin Dicetak", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Kwitansi_SAV() Then
                MessageBox.Show("Kwitansi Telah dibuat sebanyak " & txtJumlah.Text & " Lembar", "Sukses", MessageBoxButtons.OK)
                ClearForm()
            End If
        End If
    End Sub

    Private Function Kwitansi_SAV() As Boolean
        Try
            Dim tempLastKwitansi As Integer = CInt(Microsoft.VisualBasic.Left(txtKwitansi.Text, 6))
            Dim tempFormattedKwitansi As String = ""
            For index As Integer = 1 To (CInt(txtJumlah.Text))
                tempLastKwitansi = tempLastKwitansi + 1
                tempFormattedKwitansi = generateCode6Digit(CStr(tempLastKwitansi)) & Microsoft.VisualBasic.Right(CStr(ParsisTahunKwitansi), 2)
                StrSQL = ""
                StrSQL = ""
                'StrSQL = "INSERT INTO KWITANSI VALUES ('" & tempFormatedKwitansi & "','" & CStr(CDate(dtKwitansi.Value)) & "','" & CStr(cmbPIC.SelectedValue) & "')"
                StrSQL = "INSERT INTO KWITANSI VALUES ("
                StrSQL &= "'" & tempFormattedKwitansi & "',"
                StrSQL &= "'EM0043'," 'awal2 bind ke cabang
                StrSQL &= "'',"
                StrSQL &= "'" & CStr(CDate(dtAmbil.Value)) & "',"
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
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class