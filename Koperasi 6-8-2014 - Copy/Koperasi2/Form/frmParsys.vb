Option Strict On
Public Class frmParsys

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        LoadForm()
    End Sub

    Private Sub LoadForm()
        StrSQL = ""
        StrSQL = "SELECT*FROM V_PARSYS"
        RunSQL(StrSQL, 1)

        Try
            txtBiayaAdmin.Text = dt.Rows(0)("Biaya Admin").ToString()
            txtRateRebate.Text = dt.Rows(0)("Rate Rebate").ToString()
            txtTahunKwitansi.Text = dt.Rows(0)("Tahun Kwitansi").ToString()
            txtTahunMB.Text = dt.Rows(0)("Tahun Motor Baru").ToString()
            txtAdmEle.Text = dt.Rows(0)("Admin Elektronik").ToString()
            txtAdmKTA.Text = dt.Rows(0)("Admin KTA").ToString()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmParsys_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If InputVerification() = True Then
            Dim result As Integer = MessageBox.Show("Anda yakin melakukan update pada parameter sistem ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = vbYes Then
                If Parsys_Update() Then
                    SetParsysValue()
                    MessageBox.Show("Parameter System Berhasil Diupdate", "Sukses", MessageBoxButtons.OK)
                    LoadForm()
                Else
                    MessageBox.Show("Parameter System Gagal Diupdate", "Error", MessageBoxButtons.OK)
                End If
            End If
        End If
    End Sub

    Private Function InputVerification() As Boolean

        If txtBiayaAdmin.Text = "" Then
            Return False
        ElseIf txtAdmEle.Text = "" Then
            Return False
        ElseIf txtAdmKTA.Text = "" Then
            Return False
        ElseIf txtRateRebate.Text = "" Then
            Return False
        ElseIf txtTahunKwitansi.Text = "" Then
            Return False
        ElseIf txtTahunMB.Text = "" Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Function Parsys_Update() As Boolean
        Try
            StrSQL = ""
            StrSQL = "Sp_ParsysIU "
            StrSQL &= "" & CDbl(txtBiayaAdmin.Text) & ","
            StrSQL &= "" & CDbl(txtRateRebate.Text) & ","
            StrSQL &= "" & CInt(txtTahunMB.Text) & ","
            StrSQL &= "" & CInt(txtTahunKwitansi.Text) & ","
            StrSQL &= "" & CDbl(txtAdmEle.Text) & ","
            StrSQL &= "" & CDbl(txtAdmKTA.Text) & ""
            RunSQL(StrSQL, 0)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class