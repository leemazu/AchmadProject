Public Class frmTabKontrak

    Dim kontrakFlag As Integer
    Private Sub frmTabKontrak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillGrid()
    End Sub

    Private Sub FillGrid()
        Dim dsTable As New DataSet
        Try
            If txtFlag.Text = "1" Then
                StrSQL = ""
                'StrSQL = "SELECT ContractID FROM Contract WHERE State=1 ORDER BY ContractID ASC"
                StrSQL = "SELECT DISTINCT TOP 100 * FROM V_SELECTCONTRACT"
                RunSQL(StrSQL, 2, "TabelViewKontrak", , dsTable)
                gv1.DataSource = dsTable
                gv1.DataMember = "TabelViewKontrak"


            ElseIf txtFlag.Text = "2" Then

                'StrSQL = "SELECT Contract.ContractID,Contract.ContractDate,Contract.BpkbNo,contract.BpkbState,contract.EmployeeID,contract.FirstInstallment from Contract left join ContractDetail on contract.ContractID=ContractDetail.ContractID WHERE ContractDetail.Outstanding < 0 GROUP BY contract.ContractID,Contract.ContractDate,Contract.BpkbNo,contract.BpkbState,contract.EmployeeID,contract.FirstInstallment "
                StrSQL = "select DISTINCT TOP 100 *from v_selectdenda"
                RunSQL(StrSQL, 2, "TabelViewDenda", , dsTable)
                gv1.DataSource = dsTable
                gv1.DataMember = "TabelViewDenda"



            ElseIf txtFlag.Text = "Normal" Then
                StrSQL = "SELECT ContractID From contractDetail GROUP BY ContractID HAVING COUNT(TotalBayar) = COUNT([index])"
                RunSQL(StrSQL, 2, "TabelPelunasanNormal", , dsTable)
                gv1.DataSource = dsTable
                gv1.DataMember = "TabelPelunasanNormal"

            ElseIf txtFlag.Text = "Dimuka" Then
                StrSQL = ""
                StrSQL = "SELECT ContractID FROM Contract WHERE State=1 ORDER BY ContractID ASC"
                RunSQL(StrSQL, 2, "TabelPelunasanDimuka", , dsTable)
                gv1.DataSource = dsTable
                gv1.DataMember = "TabelPelunasanDimuka"
            ElseIf txtFlag.Text = "Khusus" Then
                StrSQL = ""
                StrSQL = "SELECT ContractID FROM Contract WHERE State=1 ORDER BY ContractID ASC"
                RunSQL(StrSQL, 2, "TabelPelunasanKhusus", , dsTable)
                gv1.DataSource = dsTable
                gv1.DataMember = "TabelPelunasanKhusus"
            ElseIf txtFlag.Text = "KontrakLama" Then
                StrSQL = ""
                StrSQL = "select Contract.ContractID From Contract Inner Join contractDetail ON Contract.ContractID = contractDetail.ContractID AND (contractDetail.[index]=0 AND contractDetail.NoKwitansi NOT LIKE 'unpaid') AND Contract.[State] = 1 ORDER BY Contract.ContractID ASC"
                RunSQL(StrSQL, 2, "TabelKontrakLama", , dsTable)
                gv1.DataSource = dsTable
                gv1.DataMember = "TabelKontrakLama"
            ElseIf txtFlag.Text = "KontrakBaru" Then
                StrSQL = ""
                StrSQL = "select Contract.ContractID From Contract Inner Join contractDetail ON Contract.ContractID = contractDetail.ContractID AND (contractDetail.[index]=0 AND contractDetail.TglBayar IS NULL) AND Contract.[State] = 1 ORDER BY Contract.ContractID ASC"
                RunSQL(StrSQL, 2, "TabelKontrakBaru", , dsTable)
                gv1.DataSource = dsTable
                gv1.DataMember = "TabelKontrakBaru"

            End If

            'SetLebarGrid()
            gv1.AutoResizeColumns()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Private Sub gv1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv1.CellContentDoubleClick
        If txtFlag.Text = "1" Then
            With PembayaranAngsuran
                .txtKontrak.Text = gv1.CurrentRow.Cells(0).Value
                .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            End With

        ElseIf txtFlag.Text = "2" Then
            With PembayaranDenda
                .txtKontrak.Text = gv1.CurrentRow.Cells(0).Value
                .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            End With
        ElseIf txtFlag.Text = "Normal" Then
            With PelunasanNormal
                .txtKontrak.Text = gv1.CurrentRow.Cells(0).Value
                .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            End With
        ElseIf txtFlag.Text = "Dimuka" Then
            With PelunasanDimuka
                .txtKontrak.Text = gv1.CurrentRow.Cells(0).Value
                .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            End With

        ElseIf txtFlag.Text = "Khusus" Then
            With PelunasanKhusus
                .txtKontrak.Text = gv1.CurrentRow.Cells(0).Value
                .txtHidden.Text = gv1.CurrentRow.Cells(0).Value
            End With
        ElseIf txtFlag.Text = "KontrakLama" Then
            With Buyback
                .txtKontrakLama.Text = gv1.CurrentRow.Cells(0).Value
            End With
        ElseIf txtFlag.Text = "KontrakBaru" Then
            With Buyback
                .txtKontrakBaru.Text = gv1.CurrentRow.Cells(0).Value
            End With
        End If
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        Dim filter As String = ""
        Dim dsFilter As New DataSet
        If txtFlag.Text = "1" Then
            filter = "([Nomor Kontrak] LIKE '%" & antisqli(txtFilter.Text) & "%' OR [Nama Konsumen] LIKE '%" & antisqli(txtFilter.Text) & "%') "
            StrSQL = "SELECT DISTINCT TOP 100 * FROM V_SELECTCONTRACT WHERE " & filter & " ORDER BY [Nama Konsumen] ASC"
            RunSQL(StrSQL, 2, "GridFilterKontrak", , dsFilter)
            gv1.DataSource = dsFilter
            gv1.DataMember = "GridFilterKontrak"
            SetLebarGrid()
        ElseIf txtFlag.Text = "Normal" Then
            filter = " AND ContractID LIKE '%" & txtFilter.Text & "%'"
            StrSQL = "SELECT ContractID From contractDetail GROUP BY ContractID HAVING COUNT(noKwitansi) = COUNT([index]) AND SUM(Outstanding) < SUM (outstandingReceive)"
            RunSQL(StrSQL, 2, "GridPelunasanNormal")
            gv1.DataSource = ds
            gv1.DataMember = "GridPelunasanNormal"
        End If
        gv1.AutoResizeColumns()
    End Sub

    Private Sub txtFlag_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFlag.TextChanged
        FillGrid()
    End Sub

    Private Sub SetLebarGrid()
        gv1.Columns(0).Width = 100
        gv1.Columns(1).Width = 100
        gv1.Columns(2).Width = 200
        gv1.Columns(3).Width = 600
    End Sub
End Class