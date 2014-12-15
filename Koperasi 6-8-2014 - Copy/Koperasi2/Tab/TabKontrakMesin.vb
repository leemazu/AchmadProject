Public Class TabKontrakMesin


    Dim kontrakFlag As Integer
    Private Sub frmTabKontrak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillGrid()
        'txtFilter.Focus()
    End Sub

    Private Sub FillGrid()
        Dim dsContractList As New DataSet
        If txtFlag.Text = "1" Then
            StrSQL = ""
            StrSQL = "SELECT DISTINCT *FROM V_ContractList Order By [Nama Pelanggan] ASC"
            RunSQL(StrSQL, 2, "TabelViewKontrakMesin", , dsContractList)
            gv1.DataSource = dsContractList
            gv1.DataMember = "TabelViewKontrakMesin"
            gv1.AutoResizeColumns()

        ElseIf txtFlag.Text = "2" Then

            StrSQL = "select contractID from application WHERE contractID NOT LIKE '' AND ApplicationTypeID = 2 "
            RunSQL(StrSQL, 2, "TabelKontrakMotorBaru")
            gv1.DataSource = ds
            gv1.DataMember = "TabelKontrakMotorBaru"


        ElseIf txtFlag.Text = "4" Then

            StrSQL = "select contractID from application WHERE contractID NOT LIKE '' AND ApplicationTypeID = 4 "
            RunSQL(StrSQL, 2, "TabelKontrakKTA")
            gv1.DataSource = ds
            gv1.DataMember = "TabelKontrakKTA"

        ElseIf txtFlag.Text = "3" Then

            StrSQL = "select contractID from application WHERE contractID NOT LIKE '' AND ApplicationTypeID = 3 "
            RunSQL(StrSQL, 2, "TabelKontrakElektronik")
            gv1.DataSource = ds
            gv1.DataMember = "TabelKontrakElektronik"

            'ElseIf txtFlag.Text = "Normal" Then
            '    StrSQL = ""
            '    StrSQL = "select contractID from contractDetail where totalBayar IS NULL GROUP BY ContractID ORDER BY ContractID ASC"
            '    RunSQL(StrSQL, 2, "TabelPelunasanNormal")
            '    gv1.DataSource = ds
            '    gv1.DataMember = "TabelPelunasanNormal"
        End If




    End Sub


    Private Sub gv1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv1.CellContentDoubleClick
        If txtFlag.Text = "1" Then
            With kontrakDanaTunai
                .txtKontrakID.Text = gv1.CurrentRow.Cells(1).Value
                ' .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            End With

        ElseIf txtFlag.Text = "2" Then
            With kontrakMotorBaru
                .txtKontrak.Text = gv1.CurrentRow.Cells(0).Value
                ' .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            End With

        ElseIf txtFlag.Text = "3" Then
            With kontrakElektronik
                .txtKontrak.Text = gv1.CurrentRow.Cells(0).Value
                ' .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            End With

        ElseIf txtFlag.Text = "4" Then
            With kontrakKTA
                .txtKontrak.Text = gv1.CurrentRow.Cells(0).Value
                ' .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            End With
            'ElseIf txtFlag.Text = "2" Then
            '    With PembayaranDenda
            '        .txtKontrak.Text = gv1.CurrentRow.Cells(0).Value
            '        .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            '    End With
            'ElseIf txtFlag.Text = "Normal" Then
            '    With PelunasanNormal
            '        .txtKontrak.Text = gv1.CurrentRow.Cells(0).Value
            '        .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            '    End With
        End If
        Me.Close()
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

        Try
            Dim filter As String = antisqli(txtFilter.Text)
            Dim dsAfterFilter As New DataSet
            StrSQL = ""
            StrSQL = "SELECT DISTINCT *FROM V_ContractList "
            StrSQL &= "WHERE [Nomor Aplikasi] LIKE '%" & filter & "%' OR "
            StrSQL &= " [Nomor Kontrak] LIKE '%" & filter & "%' OR "
            StrSQL &= " [Nama Pelanggan] LIKE '%" & filter & "%' "
            StrSQL &= " Order By [Nama Pelanggan] ASC"
            RunSQL(StrSQL, 2, "TabelViewAfterFilter", , dsAfterFilter)
            gv1.DataSource = dsAfterFilter
            gv1.DataMember = "TabelViewAfterFilter"
            gv1.AutoResizeColumns()
        Catch ex As Exception

        End Try
      


    End Sub
End Class