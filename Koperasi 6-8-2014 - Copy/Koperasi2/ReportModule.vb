Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Module ReportModule
    Public RepName As String
    Public RepPath As String
    Public strReportPath As String
    'Public App_Path As System.IO.FileInfo = System.IO.FileInfo(Application.ExecutablePath).DirectoryName
    'Public App_Path As System.IO.FileInfo(Application.ExecutablePath).DirectoryName
    Public cryRpt As New ReportDocument
    Public crtableLogoninfos As New TableLogOnInfos
    Public crtableLogoninfo As New TableLogOnInfo
    Public crConnectionInfo As New ConnectionInfo
    Public CrTables As Tables
    Public CrTable As Table
End Module
