Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Module Module2
    Public Const TrialDate As String = ""
    Public Const InitApplUserID = "admin"
    Public Const InitApplUserName = "Administrator"
    Public Const InitApplUserPass = "abcd"

    Private _UserAuth As String
    Private _ApplUserLv As Int16

    Private _StrSQL As String
    Private _isDoubleLogin As Boolean

    Public Property UserAuth() As String
        Get
            Return _UserAuth
        End Get
        Set(ByVal value As String)
            _UserAuth = value
        End Set
    End Property
    Public Property ApplUserlv() As Int16
        Get
            Return _ApplUserLv
        End Get
        Set(ByVal value As Int16)
            _ApplUserLv = value
        End Set
    End Property


    Public Property isDoubleLogin() As Boolean
        Get
            Return _isDoubleLogin
        End Get
        Set(ByVal value As Boolean)
            _isDoubleLogin = True
        End Set
    End Property

    Public Sub ViewReport(ByVal Crv As CrystalDecisions.Windows.Forms.CrystalReportViewer, ByVal CrPath As String, Optional ByVal Dataset As DataSet = Nothing, Optional ByVal Parameter As CrystalDecisions.Shared.ParameterDiscreteValue = Nothing)
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        cryRpt.Load(CrPath)
        If Not Dataset Is Nothing Then
            cryRpt.SetDataSource(Dataset)
        End If

        If Not Parameter Is Nothing Then
            Dim paramV = New CrystalDecisions.Shared.ParameterValues
            paramV.add(Parameter)
            cryRpt.ParameterFields.Item("parameter").CurrentValues = paramV
            cryRpt.ParameterFields.Item("parameter").HasCurrentValue = True

        End If

        With crConnectionInfo
            .ServerName = con_server
            .DatabaseName = con_database
            .UserID = con_userid
            .Password = con_password
        End With

        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        With Crv
            .ReportSource = cryRpt
            .DisplayToolbar = True
            .Refresh()
        End With



    End Sub

    'Public Sub viewReport(ByVal crv As CrystalDecisions.Windows.Forms.CrystalReportViewer, ByVal tableName As String, ByVal rFileName As String, ByVal paramFields As CrystalDecisions.Shared.ParameterFields)
    '    Dim logonInfo As New CrystalDecisions.Shared.TableLogOnInfo
    '    Dim logonInfos As New CrystalDecisions.Shared.TableLogOnInfos

    '    logonInfo.TableName = tableName
    '    logonInfo.ConnectionInfo.ServerName() = con_server
    '    logonInfo.ConnectionInfo.Password() = con_password
    '    logonInfo.ConnectionInfo.UserID = con_userid
    '    logonInfo.ConnectionInfo.DatabaseName = con_database
    '    logonInfos.Add(logonInfo)

    '    crv.LogOnInfo = logonInfos
    '    crv.ParameterFieldInfo = paramFields
    '    crv.ReportSource = Application.StartupPath & "\" & rFileName & ".rpt"
    '    crv.Zoom(1)
    'End Sub

    'Public Function addParamField(ByVal fieldName As String, ByVal value As String) As CrystalDecisions.Shared.ParameterField
    '    Dim paramField As New CrystalDecisions.Shared.ParameterField
    '    Dim paramDiscreteVal As New CrystalDecisions.Shared.ParameterDiscreteValue

    '    paramField.ParameterFieldName = fieldName
    '    paramDiscreteVal.Value = value
    '    paramField.CurrentValues.Add(paramDiscreteVal)

    '    Return paramField
    'End Function

    Public Class getAddress
        Public kelurahan As String
        Public kecamatan As String
        Public kota As String
    End Class

    Public Function detailAlamat(ByVal kodePost As String) As getAddress
        Dim detAl = New getAddress()
        Dim dtGetAlamat As New DataTable
        Dim connGetAlamat As New SqlConnection
        Dim connStringGetAlamat As String
        Dim cmdGetAlamat As New SqlCommand
        Dim rdrGetAlamat As SqlDataReader

        connStringGetAlamat = "data source={0};user id={1};password={2};initial catalog={3}"
        connStringGetAlamat = String.Format(con_string, con_server, con_userid, con_password, con_database)
        connGetAlamat = New SqlConnection(connStringGetAlamat)

        If kodePost = "" Then
            kodePost = "001012012000000"
        End If


        Try
            connGetAlamat.Open()
            cmdGetAlamat = New SqlCommand("SELECT VILLAGE,SubDistrict,City From __addrLocation Where AddrLocationID='" & kodePost & "'", connGetAlamat)
            With dtGetAlamat
                .Clear()
                'dt = New DataTable
                rdrGetAlamat = cmdGetAlamat.ExecuteReader()
                Try
                    .Load(rdrGetAlamat)
                Catch ex As Exception
                End Try
                connGetAlamat.Close()
            End With
        Catch ex As Exception

        End Try



        Try
            detAl.kelurahan = dtGetAlamat.Rows(0)("VILLAGE").ToString()
            detAl.kecamatan = dtGetAlamat.Rows(0)("SubDistrict").ToString()
            detAl.kota = dtGetAlamat.Rows(0)("City").ToString()
        Catch ex As Exception
        End Try
        Return detAl




    End Function

    Public Sub ChangedIndexComboBox(ByVal strSql As String, ByVal comboBox As ComboBox, ByVal numberSelected As String, ByVal dataTable As DataTable)
        dataTable.Rows.Clear()
        With comboBox
            .DataSource = Nothing
            .Items.Clear()
            FillCombobox(strSql, comboBox, numberSelected, dataTable)
        End With
    End Sub

    Public Function getFieldValue(ByVal SQLQuery As String) As String
        Dim hasil As String = ""
        Dim dtGetField As New DataTable
        Dim connStringGetField As String
        Dim connGetField As SqlConnection
        Dim cmdGetGield As New SqlCommand
        Dim rdrGetField As SqlDataReader
        Dim daGetField As New SqlDataAdapter
        Dim dsGetField As New DataSet
        connStringGetField = "data source={0};user id={1};password={2};initial catalog={3}"
        connStringGetField = String.Format(con_string, con_server, con_userid, con_password, con_database)
        connGetField = New SqlConnection(connStringGetField)
        Try
            connGetField.Open()
            cmdGetGield = New SqlCommand(SQLQuery, connGetField)
            With dtGetField
                .Clear()
                'dt = New DataTable
                rdrGetField = cmdGetGield.ExecuteReader()
                Try
                    .Load(rdrGetField)
                Catch ex As Exception
                End Try
            End With
            hasil = dtGetField.Rows(0)(0).ToString()
        Catch ex As Exception
            hasil = ""
        End Try
        connGetField.Close()
        Return hasil
    End Function

End Module
