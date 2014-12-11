Public Class frmTabKaryawan

    Private Sub frmTabKaryawan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillGrid()
    End Sub

    Private Sub FillGrid()
        Try
            StrSQL = ""
            StrSQL = "SELECT EmployeeID as [NIK],EmployeeName as [Nama],PositionID as [Posisi],Address as [Alamat] From Employee ORDER BY EmployeeID ASC"
            RunSQL(StrSQL, 2, "TableKaryawan")
            gv1.DataSource = ds
            gv1.DataMember = "TableKaryawan"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        Dim Filter As String = ""

        Try
            Filter = String.Format("WHERE EmployeeID LIKE '%{0}%' ", txtCari.Text)
            Filter &= String.Format("OR EmployeeName LIKE '%{0}%' ", txtCari.Text)
            StrSQL = ""
            StrSQL = String.Format("SELECT EmployeeID as [NIK],EmployeeName as [Nama],PositionID as [Posisi],Address as [Alamat] From Employee {0} ORDER BY EmployeeID ASC ", Filter)
            RunSQL(StrSQL, 2, "FilterKaryawan")
            gv1.DataSource = Nothing
            gv1.DataSource = ds
            gv1.DataMember = "FilterKaryawan"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gv1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv1.CellContentDoubleClick
        With frmKaryawan
            .txtNIK.Text = gv1.CurrentRow.Cells(0).Value
        End With
        Me.Close()
    End Sub
End Class