Imports System.Data.SqlClient
Public Class ReportView

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ReportView_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        StrSQL = ""
        StrSQL = "DELETE FROM TANDATERIMAUANG"
        RunSQL(StrSQL, 0)
    End Sub

    Private Sub ReportView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class