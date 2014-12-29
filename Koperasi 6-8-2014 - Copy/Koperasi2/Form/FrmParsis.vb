Imports System.Xml
Public Class FrmParsis

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        decimalOnly(txtBiayaAdmin, e, txtBiayaAdmin.Text)
    End Sub

    Private Sub FrmParsis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm()
    End Sub

    Private Sub LoadForm()
        StrSQL = ""
        StrSQL = "SELECT * FROM SystemParameter"
        RunSQL(StrSQL, 1)
        If dt.Rows.Count > 0 Then
            txtBiayaAdmin.Text = ribuan(CStr(dt.Rows(0)("BiayaAdmin")))
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim result As Integer = MessageBox.Show("Anda yakin ingin mengubah parameter sistem ? ", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = vbYes Then
            If Parsis_SAVE() Then
                MessageBox.Show("Parameter Sistem Berhasil Diubah")
            Else
                MessageBox.Show("Parameter Sistem Gagal Diubah")
            End If
        End If

    End Sub

    Private Function Parsis_SAVE() As Boolean
        Try
            StrSQL = ""
            StrSQL = "UPDATE SystemParameter SET BiayaAdmin = " & CDbl(txtBiayaAdmin.Text) & " "
            RunSQL(StrSQL, 0)
            Return True
        Catch ex As Exception
            Return False
        End Try
       
    End Function
End Class