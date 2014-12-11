Imports System.Data.SqlClient

Public Class MultiReportView

    Private Sub MultiReportView_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        deltempTTB()
        deltempTTU()
        deltempTTBarang()
    End Sub

    Private Sub MultiReportView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        Try
            deltempTTB()
            deltempTTU()
            deltempTTBarang()
        Catch ex As Exception

        End Try
        
        'Me.ControlBox = True

    End Sub

    Private Sub deltempTTU()
        StrSQL = ""
        StrSQL = "DELETE FROM TTU"
        RunSQL(StrSQL, 0)


    End Sub

    Private Sub deltempTTB()
        StrSQL = ""
        StrSQL = "DELETE FROM TANDATERIMABPKB"
        RunSQL(StrSQL, 0)
    End Sub

    Private Sub deltempTTBarang()
        StrSQL = ""
        StrSQL = "DELETE FROM TANDATERIMABARANG"
        RunSQL(StrSQL, 0)
    End Sub


End Class