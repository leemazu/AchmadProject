Imports System.Data.SqlClient
Public Class frmTabMem

    Private Sub frmTabMem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillTable()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub fillTable()
        Dim dsMember As New DataSet
        Try
            StrSQL = "SELECT TOP 100 MemberID as[ID],MemberName as [Nama],PersonalIdentity as [No.KTP],Address as [Alamat] FROM Member ORDER BY MemberID DESC"
            RunSQL(StrSQL, 2, "MEMBER", , dsMember)
            gridMember.DataSource = dsMember
            gridMember.DataMember = "MEMBER"
            gridMember.AutoResizeColumns()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dropTable()
        Try
            StrSQL = "DELETE FROM TEMPAPPLICATION"
            RunSQL(StrSQL, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dropTemp()
        Try
            StrSQL = "exec sp_dropTemp"
            RunSQL(StrSQL, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridMember.CellContentDoubleClick
        oldMemberID = gridMember.CurrentRow.Cells(0).Value
        If formFlag = 1 Then
            With frmDanaTunai
                stateMember = "UPD"
                .txtPemNo.Text = gridMember.CurrentRow.Cells(0).Value
            End With

        ElseIf formFlag = 2 Then
            With frmMotorBaru
                stateMember = "UPD"
                .txtPemNo.Text = gridMember.CurrentRow.Cells(0).Value
            End With
      
        ElseIf formFlag = 3 Then
            With frmElektronik
                stateMember = "UPD"
                .txtPemNo.Text = gridMember.CurrentRow.Cells(0).Value
            End With
        ElseIf formFlag = 4 Then
            With frmKTA
                stateMember = "UPD"
                .txtPemNo.Text = gridMember.CurrentRow.Cells(0).Value
            End With
        
        End If
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        Dim filter As String = ""
        Dim dsFilter As New DataSet
        Try
            filter = String.Format("WHERE [MemberID] LIKE '%{0}%' ", antisqli(txtFilter.Text))
            filter &= String.Format("OR [MemberName] LIKE '%{0}%' ", antisqli(txtFilter.Text))
            filter &= String.Format("OR [PersonalIdentity] LIKE '%{0}%' ", antisqli(txtFilter.Text))
            filter &= String.Format("OR [Address] LIKE '%{0}%' ", antisqli(txtFilter.Text))
            StrSQL = String.Format("SELECT TOP 100 MemberId,MemberName,PersonalIdentity,Address FROM MEMBER {0} ORDER BY [MemberId] DESC", filter)
            RunSQL(StrSQL, 2, "MEMBER", , dsFilter)
            gridMember.DataSource = dsFilter
            gridMember.DataMember = "MEMBER"
            gridMember.AutoResizeColumns()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class