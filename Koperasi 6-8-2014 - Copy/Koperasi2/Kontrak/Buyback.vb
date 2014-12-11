Imports DevExpress.XtraEditors.Repository
Imports System.Data.SqlClient
Imports System.Xml

Public Class Buyback

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        With frmTabKontrak
            .txtFlag.Text = "KontrakLama"
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With frmTabKontrak
            .txtFlag.Text = "KontrakBaru"
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub txtKontrakLama_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKontrakLama.TextChanged
        If txtKontrakLama.Text.Length = txtKontrakLama.MaxLength Then
            FillGrid()
        Else
            GridControl1.DataSource = Nothing
        End If
    End Sub

    Private Sub FillGrid()

        Dim tanggal As RepositoryItemDateEdit = New RepositoryItemDateEdit() With {.EditMask = "dd/MM/yyyy"}
        tanggal.Mask.UseMaskAsDisplayFormat = True
        Dim uang As RepositoryItemSpinEdit = New RepositoryItemSpinEdit
        Dim uang2 As RepositoryItemSpinEdit = New RepositoryItemSpinEdit
        Dim tableKwitansi As New DataTable

        uang2.MaxLength = 9
        uang2.IsFloatValue = False
        uang2.EditMask = "###,###,##0"
        uang2.Mask.UseMaskAsDisplayFormat = True

        uang.NullText = 0
        uang.MaxLength = 9
        uang.IsFloatValue = False
        uang.EditMask = "###,###,##0"
        uang.Mask.UseMaskAsDisplayFormat = True
        uang.MinValue = 0
        uang.NullText = 0



        Dim tbl_kontrak As New DataTable
        Using ds_kontrak As New DataSet()
            StrSQL = ""
            StrSQL = "SELECT [Index]+1 as [Angs Ke]"
            StrSQL &= ",JatuhTempo as [Due Date]"
            StrSQL &= ",Angsuran"
            StrSQL &= ",Sp as [Amount Principal]"
            StrSQL &= ",Si as [Interest Principal]"
            StrSQL &= ",Op as [Amount Principal (sisa)]"
            StrSQL &= ",Oi as [Interest Principal (sisa)]"
            StrSQL &= ",isnull(CONVERT(nvarchar,tglbayar),'') as [Tanggal Bayar]"
            StrSQL &= ",Angsuran+(CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0 then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end) as [AMBC]"
            StrSQL &= ",ISNULL(OVD,DATEDIFF(DAY,JatuhTempo,GETDATE())) as [OVD]"
            'mark tanggal 11/6/2014 reason ubah tampilan denda berdasar ovd
            'StrSQL &= ",DATEDIFF(DAY,JatuhTempo,GETDATE()) as [OVD]"
            'StrSQL &= ",CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0 then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end as [Denda]"
            'end mark
            StrSQL &= ",CASE WHEN OVD IS NULL THEN CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0"
            StrSQL &= " then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end"
            StrSQL &= " ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) END as [Denda]"
            StrSQL &= ",isnull(CONVERT(nvarchar,TotalBayar),'0') as [Total Bayar]"
            StrSQL &= ",isnull(CONVERT(nvarchar,Outstanding),'0') as [Outstanding]"
            StrSQL &= ",isnull(CONVERT(nvarchar,OutstandingReceive),'0') as [Outstanding Receive]"
            StrSQL &= ",isnull(CONVERT(nvarchar,OutstandingTotal),'0') as [Outstanding Total]"
            StrSQL &= ",isnull(CONVERT(nvarchar,NoKwitansi),'unpaid') as [Nomor Kwitansi]"
            StrSQL &= " From ContractDetail "
            StrSQL &= String.Format("WHERE ContractID='{0}' ", txtKontrakLama.Text)
            da = New SqlDataAdapter(StrSQL, conn)
            da.Fill(tbl_kontrak)
            ds_kontrak.Tables.Add(tbl_kontrak)
        End Using
        GridControl1.DataSource = Nothing
        GridControl1.DataSource = tbl_kontrak

        'set ga bisa diedit
        For i As Integer = 0 To 15
            GridView1.Columns(i).OptionsColumn.AllowEdit = False
        Next

        'set datetime
        GridView1.Columns(1).ColumnEdit = tanggal
        GridView1.Columns(7).ColumnEdit = tanggal
        GridView1.Columns(2).ColumnEdit = uang
        GridView1.Columns(3).ColumnEdit = uang
        GridView1.Columns(4).ColumnEdit = uang
        GridView1.Columns(5).ColumnEdit = uang
        GridView1.Columns(6).ColumnEdit = uang
        GridView1.Columns(8).ColumnEdit = uang
        GridView1.Columns(10).ColumnEdit = uang
        GridView1.Columns(11).ColumnEdit = uang
        GridView1.Columns("Outstanding").ColumnEdit = uang2
        GridView1.Columns("Outstanding Receive").ColumnEdit = uang2
        GridView1.Columns("Outstanding Total").ColumnEdit = uang2
        GridView1.Columns(12).OptionsColumn.AllowEdit = False
        GridView1.Columns("OVD").OptionsColumn.AllowEdit = False
        GridView1.Columns("Denda").OptionsColumn.AllowEdit = False
        GridView1.Columns("AMBC").OptionsColumn.AllowEdit = False
        GridView1.Columns("Outstanding Receive").OptionsColumn.AllowEdit = False
        GridView1.Columns("Outstanding Total").OptionsColumn.AllowEdit = False


        'add total
        GridView1.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(2).SummaryItem.DisplayFormat = "{0:###,###}"
        GridView1.Columns("Denda").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("Denda").SummaryItem.DisplayFormat = "{0:###,###}"
        GridView1.Columns("Outstanding").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("Outstanding").SummaryItem.DisplayFormat = "{0:###,###}"
        GridView1.Columns("Outstanding Receive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("Outstanding Total").SummaryItem.DisplayFormat = "{0:###,###}"
        GridView1.Columns("Amount Principal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("Amount Principal").SummaryItem.DisplayFormat = "{0:###,###}"
        GridView1.Columns("Interest Principal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("Interest Principal").SummaryItem.DisplayFormat = "{0:###,###}"

        'set lebar grid
        GridView1.Columns(0).Width = 52
        GridView1.Columns(1).Width = 65
        GridView1.Columns(2).Width = 70
        GridView1.Columns(3).Width = 89
        GridView1.Columns(4).Width = 88
        GridView1.Columns(5).Width = 115
        GridView1.Columns(6).Width = 117
        GridView1.Columns(7).Width = 79
        GridView1.Columns(8).Width = 62
        GridView1.Columns(9).Width = 38
        GridView1.Columns(10).Width = 65
        GridView1.Columns(11).Width = 77
        GridView1.Columns(12).Width = 70
        GridView1.Columns(13).Width = 110
        GridView1.Columns(14).Width = 95
        GridView1.Columns(15).Width = 87

        'GridControl1.Enabled = False
        'GridControl1.UseDisabledStatePainter = False


    End Sub

    Private Sub FillGrid2()

        Dim tanggal As RepositoryItemDateEdit = New RepositoryItemDateEdit() With {.EditMask = "dd/MM/yyyy"}
        tanggal.Mask.UseMaskAsDisplayFormat = True
        Dim uang As RepositoryItemSpinEdit = New RepositoryItemSpinEdit
        Dim uang2 As RepositoryItemSpinEdit = New RepositoryItemSpinEdit
        Dim tableKwitansi As New DataTable

        uang2.MaxLength = 9
        uang2.IsFloatValue = False
        uang2.EditMask = "###,###,##0"
        uang2.Mask.UseMaskAsDisplayFormat = True

        uang.NullText = 0
        uang.MaxLength = 9
        uang.IsFloatValue = False
        uang.EditMask = "###,###,##0"
        uang.Mask.UseMaskAsDisplayFormat = True
        uang.MinValue = 0
        uang.NullText = 0



        Dim tbl_kontrak As New DataTable
        Using ds_kontrak As New DataSet()
            StrSQL = ""
            StrSQL = "SELECT [Index]+1 as [Angs Ke]"
            StrSQL &= ",JatuhTempo as [Due Date]"
            StrSQL &= ",Angsuran"
            StrSQL &= ",Sp as [Amount Principal]"
            StrSQL &= ",Si as [Interest Principal]"
            StrSQL &= ",Op as [Amount Principal (sisa)]"
            StrSQL &= ",Oi as [Interest Principal (sisa)]"
            StrSQL &= ",isnull(CONVERT(nvarchar,tglbayar),'') as [Tanggal Bayar]"
            StrSQL &= ",Angsuran+(CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0 then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end) as [AMBC]"
            StrSQL &= ",ISNULL(OVD,DATEDIFF(DAY,JatuhTempo,GETDATE())) as [OVD]"
            'mark tanggal 11/6/2014 reason ubah tampilan denda berdasar ovd
            'StrSQL &= ",DATEDIFF(DAY,JatuhTempo,GETDATE()) as [OVD]"
            'StrSQL &= ",CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0 then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end as [Denda]"
            'end mark
            StrSQL &= ",CASE WHEN OVD IS NULL THEN CASE WHEN Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) < 0"
            StrSQL &= " then 0 ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) end"
            StrSQL &= " ELSE Angsuran*0.005*DATEDIFF(DAY,JatuhTempo,GETDATE()) END as [Denda]"
            StrSQL &= ",isnull(CONVERT(nvarchar,TotalBayar),'0') as [Total Bayar]"
            StrSQL &= ",isnull(CONVERT(nvarchar,Outstanding),'0') as [Outstanding]"
            StrSQL &= ",isnull(CONVERT(nvarchar,OutstandingReceive),'0') as [Outstanding Receive]"
            StrSQL &= ",isnull(CONVERT(nvarchar,OutstandingTotal),'0') as [Outstanding Total]"
            StrSQL &= ",isnull(CONVERT(nvarchar,NoKwitansi),'unpaid') as [Nomor Kwitansi]"
            StrSQL &= " From ContractDetail "
            StrSQL &= String.Format("WHERE ContractID='{0}' ", txtKontrakBaru.Text)
            da = New SqlDataAdapter(StrSQL, conn)
            da.Fill(tbl_kontrak)
            ds_kontrak.Tables.Add(tbl_kontrak)
        End Using
        GridControl2.DataSource = Nothing
        GridControl2.DataSource = tbl_kontrak

        'set ga bisa diedit
        For i As Integer = 0 To 15
            GridView2.Columns(i).OptionsColumn.AllowEdit = False
        Next

        'set datetime
        GridView2.Columns(1).ColumnEdit = tanggal
        GridView2.Columns(7).ColumnEdit = tanggal
        GridView2.Columns(2).ColumnEdit = uang
        GridView2.Columns(3).ColumnEdit = uang
        GridView2.Columns(4).ColumnEdit = uang
        GridView2.Columns(5).ColumnEdit = uang
        GridView2.Columns(6).ColumnEdit = uang
        GridView2.Columns(8).ColumnEdit = uang
        GridView2.Columns(10).ColumnEdit = uang
        GridView2.Columns(11).ColumnEdit = uang
        GridView2.Columns("Outstanding").ColumnEdit = uang2
        GridView2.Columns("Outstanding Receive").ColumnEdit = uang2
        GridView2.Columns("Outstanding Total").ColumnEdit = uang2
        GridView2.Columns(12).OptionsColumn.AllowEdit = False
        GridView2.Columns("OVD").OptionsColumn.AllowEdit = False
        GridView2.Columns("Denda").OptionsColumn.AllowEdit = False
        GridView2.Columns("AMBC").OptionsColumn.AllowEdit = False
        GridView2.Columns("Outstanding Receive").OptionsColumn.AllowEdit = False
        GridView2.Columns("Outstanding Total").OptionsColumn.AllowEdit = False


        'add total
        GridView2.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns(2).SummaryItem.DisplayFormat = "{0:###,###}"
        GridView2.Columns("Denda").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns("Denda").SummaryItem.DisplayFormat = "{0:###,###}"
        GridView2.Columns("Outstanding").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns("Outstanding").SummaryItem.DisplayFormat = "{0:###,###}"
        GridView2.Columns("Outstanding Receive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns("Outstanding Total").SummaryItem.DisplayFormat = "{0:###,###}"
        GridView2.Columns("Amount Principal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns("Amount Principal").SummaryItem.DisplayFormat = "{0:###,###}"
        GridView2.Columns("Interest Principal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns("Interest Principal").SummaryItem.DisplayFormat = "{0:###,###}"

        'set lebar grid
        GridView2.Columns(0).Width = 52
        GridView2.Columns(1).Width = 65
        GridView2.Columns(2).Width = 70
        GridView2.Columns(3).Width = 89
        GridView2.Columns(4).Width = 88
        GridView2.Columns(5).Width = 115
        GridView2.Columns(6).Width = 117
        GridView2.Columns(7).Width = 79
        GridView2.Columns(8).Width = 62
        GridView2.Columns(9).Width = 38
        GridView2.Columns(10).Width = 65
        GridView2.Columns(11).Width = 77
        GridView2.Columns(12).Width = 70
        GridView2.Columns(13).Width = 110
        GridView2.Columns(14).Width = 95
        GridView2.Columns(15).Width = 87

        'GridControl2.Enabled = False
        'GridControl2.UseDisabledStatePainter = False


    End Sub

    Private Sub txtKontrakBaru_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKontrakBaru.TextChanged
        If txtKontrakBaru.Text.Length = txtKontrakBaru.MaxLength Then
            FillGrid2()
        Else
            GridControl2.DataSource = Nothing
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim result As Integer = MessageBox.Show("Anda Yakin Ingin Melakukan BuyBack ?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = vbyes Then
            BuyBack()
        End If
        FillGrid2()
    End Sub


    Private Sub BuyBack()

        Dim TglBayar As Date
        Dim index As Integer
        Dim totalBayar As Integer
        Dim OutstandingRe As Integer
        Dim noKwitansi As String

        StrSQL = ""
        StrSQL = "SELECT [index],TglBayar,totalBayar,OutstandingReceive"
        StrSQL &= " from contractDetail Where ContractID='" & txtKontrakLama.Text & "'"
        StrSQL &= "  AND TglBayar is not NULL ORDER BY [index] ASC "
        RunSQL(StrSQL, 1)

        If dt.Rows.Count > 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1
                TglBayar = dt.Rows(i)("TglBayar")
                index = dt.Rows(i)("index")
                totalBayar = dt.Rows(i)("totalBayar")
                OutstandingRe = dt.Rows(i)("OutstandingReceive")
                noKwitansi = dt.Rows(i)("NoKwitansi")


                StrSQL = ""
                StrSQL = "UPDATE ContractDetail SET "
                StrSQL &= "TglBayar = '" & TglBayar.Date & "', "
                StrSQL &= "totalBayar=" & totalBayar & ", "
                StrSQL &= "NoKwitansi='" & noKwitansi & "',"
                StrSQL &= "OutstandingReceive = " & OutstandingRe & " "
                StrSQL &= "  WHERE ContractID ='" & txtKontrakBaru.Text & "' AND "
                StrSQL &= "[index]= " & index & " "

                RunSQL(StrSQL, 0)

                StrSQL = ""
                StrSQL = "UPDATE ContractDetail SET OVD = DATEDIFF(day,JatuhTempo,TglBayar) "
                StrSQL &= "  WHERE ContractID ='" & txtKontrakBaru.Text & "' AND "
                StrSQL &= "[index]= " & index & " "
                RunSQL(StrSQL, 0)

                'update denda
                StrSQL = ""
                StrSQL = "UPDATE ContractDetail SET Denda = CASE WHEN Angsuran*0.005*OVD > 0 THEN Angsuran*0.005*OVD ELSE 0 END "
                StrSQL &= "  WHERE ContractID ='" & txtKontrakBaru.Text & "' AND "
                StrSQL &= "[index]= " & index & " "
                RunSQL(StrSQL, 0)

                'update AMBC
                StrSQL = ""
                StrSQL = "UPDATE ContractDetail SET AMBC = Angsuran + Denda "
                StrSQL &= "  WHERE ContractID ='" & txtKontrakBaru.Text & "' AND "
                StrSQL &= "[index]= " & index & " "
                RunSQL(StrSQL, 0)

                'update outstanding
                StrSQL = ""
                StrSQL = "UPDATE ContractDetail SET Outstanding = TotalBayar - AMBC "
                StrSQL &= "  WHERE ContractID ='" & txtKontrakBaru.Text & "' AND "
                StrSQL &= "[index]= " & index & " "
                RunSQL(StrSQL, 0)

                'update OutstandingTotal
                StrSQL = ""
                StrSQL = "UPDATE ContractDetail SET OUtstandingTotal = Outstanding + OutstandingReceive "
                StrSQL &= "  WHERE ContractID ='" & txtKontrakBaru.Text & "' AND "
                StrSQL &= "[index]= " & index & " "
                RunSQL(StrSQL, 0)

                'update status kontrak lama
                StrSQL = ""
                StrSQL = "UPDATE Contract SET [State] = 6 "
                StrSQL &= ",TransLogID='Buyback ke ContractID " & txtKontrakBaru.Text & " '"
                StrSQL &= "  WHERE ContractID ='" & txtKontrakLama.Text & "' "
                RunSQL(StrSQL, 0)

                'update log kontrak baru
                StrSQL = ""
                StrSQL = "UPDATE Contract SET "
                StrSQL &= "TransLogID='Pindahan dari ContractID " & txtKontrakLama.Text & " '"
                StrSQL &= "  WHERE ContractID ='" & txtKontrakBaru.Text & "' "
                RunSQL(StrSQL, 0)

                'update keterangan kwitansi

                StrSQL = ""
                StrSQL = "UPDATE Kwitansi SET "
                StrSQL &= "Alasan ='Pembayaran (Buyback) Nomor Kontrak " & txtKontrakBaru.Text & "' "
                StrSQL &= " WHERE NoKwitansi ='" & noKwitansi & "' "
                RunSQL(StrSQL, 0)


            Next




        End If


    End Sub

End Class