Public Class frmRebate

    Dim isRebatePlus As Boolean
    Private Sub frmRebate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
        FillGrid()
    End Sub

    Private Sub ClearForm()
        txtNoPolis.Clear()
        txtPemohon.Clear()
        setTanggal(dtPolis)
        txtAplikasi.Clear()
        txtPremiAwal.Clear()
        txtPremiAsli.Clear()
        txtSelisih.Clear()
        txtRebate.Clear()
        txtRebateP.Clear()
    End Sub

    Private Sub FillGrid()
        Try
            Dim dsGridRebate As New DataSet
            StrSQL = ""
            StrSQL = "SELECT * FROM V_Rebate ORDER By [Nama Pelanggan] ASC "
            RunSQL(StrSQL, 1)
            If dt.Rows.Count > 0 Then
                RunSQL(StrSQL, 2, "TableGridRebate", , dsGridRebate)
                With gv1
                    .DataSource = dsGridRebate
                    .DataMember = "TableGridRebate"
                    .AutoResizeColumns()
                End With
            Else
                gv1.DataSource = Nothing
            End If
           
        Catch ex As Exception

        End Try
        

    End Sub

    Private Sub gv1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gv1.SelectionChanged
        Try
            If Not gv1.DataSource Is Nothing Then
                txtNoPolis.Text = CStr(gv1.CurrentRow.Cells(0).Value)
                txtAplikasi.Text = CStr(gv1.CurrentRow.Cells(1).Value)
                txtPemohon.Text = CStr(gv1.CurrentRow.Cells(2).Value)
                dtPolis.Value = CStr(gv1.CurrentRow.Cells(3).Value)
                cmbPolis.Text = CStr(gv1.CurrentRow.Cells(4).Value)
                txtPremiAwal.Text = ribuan(CStr(gv1.CurrentRow.Cells(5).Value))
            Else
                txtNoPolis.Text = ""
                txtAplikasi.Text = ""
                txtPemohon.Text = ""
                dtPolis.Value = ""
                cmbPolis.Text = ""
                txtPremiAwal.Text = ""
            End If
            
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DecimalKeyPress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPremiAsli.KeyPress, txtRebateP.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        decimalOnly(sender, e, txt.Text)
    End Sub
 

    Private Sub HitungRebate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPremiAsli.TextChanged, txtRebateP.TextChanged
        Dim selisih As Double
        Dim premiawal As Double
        Dim premiasli As Double
        Dim premiP As Double
        Dim rebate As Double

        If txtPremiAwal.Text = "" Then
            premiawal = 0
        Else
            premiawal = CDbl(txtPremiAwal.Text)
        End If

        If txtPremiAsli.Text = "" Then
            premiasli = 0
            txtPremiAsli.Text = 0
        Else
            premiasli = CDbl(txtPremiAsli.Text)
        End If

        selisih = premiasli - premiawal

        txtSelisih.Text = ribuan(selisih)

        If txtRebateP.Text = "" Then
            premiP = 0
            txtRebateP.Text = 0
        Else
            premiP = CDbl(txtRebateP.Text)
        End If

        rebate = selisih * premiP / 100

        txtRebate.Text = ribuan(rebate)

        If rebate > 0 Then
            isRebatePlus = True
        Else
            isRebatePlus = False
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not gv1.DataSource Is Nothing Then
            Dim pesan As String = "Anda Akan Menginput Rebate dengan Detail Berikut : "
            pesan &= vbNewLine & "---------------------------------------------------------------------"
            pesan &= vbNewLine & "Nomor Polis " & vbTab & vbTab & ": " & txtNoPolis.Text
            pesan &= vbNewLine & "Nama Pelanggan " & vbTab & vbTab & ": " & txtPemohon.Text
            pesan &= vbNewLine & "Nilai Rebate " & vbTab & vbTab & ": " & ribuan(txtRebate.Text)
            pesan &= vbNewLine & vbNewLine & "Apakah Anda yakin ? "
            Dim result As Integer = MessageBox.Show(pesan, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = vbYes Then
                If Rebate_SAV() Then
                    MessageBox.Show("Data Telah Disimpan")
                    ClearForm()
                    FillGrid()
                Else
                    MessageBox.Show("Data Gagal Disimpan")
                End If
            End If

        End If
       
    End Sub

    Private Function Rebate_SAV() As Boolean

        Try
            Dim flagRebate As String
            If isRebatePlus = True Then
                flagRebate = "INS_REBATE"
            Else
                flagRebate = "OUT_REBATE"
            End If

            StrSQL = "Sp_BankIU "
            StrSQL &= "'" & flagRebate & "',"
            StrSQL &= "'" & antisqli(txtNoPolis.Text) & "',"
            StrSQL &= "'" & dtPolis.Value.Date & "',"
            StrSQL &= "" & CDbl(txtRebate.Text) & ","
            StrSQL &= "'" & UserName & "'"
            RunSQL(StrSQL, 0)


            StrSQL = ""
            StrSQL = "UPDATE Polis SET "
            StrSQL &= "NOMINAL = " & CDbl(txtPremiAsli.Text) & " "
            StrSQL &= "WHERE NoPolis = '" & txtNoPolis.Text & "' "
            RunSQL(StrSQL, 0)
            Return True

        Catch ex As Exception
            Return False
        End Try
        

    End Function

End Class