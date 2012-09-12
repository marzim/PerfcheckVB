Option Strict Off
Option Explicit On
Imports System.Math

'UPGRADE_NOTE: Global was upgraded to Global_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
Module Global_Renamed
	Public g_nTotalNameCount As Integer
	Public gStateNames() As String
	Dim g_nStateNamesSize As Integer
	Public g_nTimeResetEvents As Integer
	Public g_nTimeResetIndexes(95) As Integer
    'Public Const g_nNUMBER_CHECK_BOXES_ON_FORM As Integer = 12
    Public Const g_MAX_LOG_FILES = 200
	Public g_sINITIAL_DIRECTORY As String
    Public g_sDICTIONARY_DIR As String
    Public g_bUnicodeDiagFiles As Boolean
	'    Global g_sDiagDirectory As String
	Public g_bSupressDuplicates As Boolean
	Public Const g_KgsToLbs As Double = 2.20462262
	Public g_Kgs As Boolean
	'Public g_cmdline as Boolean = False
	Public g_errPatternsLoad as New System.Text.StringBuilder()
	
	Function Add_StateName(ByRef sName As String) As Integer
		
		Add_StateName = Name_Sequence()
		If (Add_StateName > g_nStateNamesSize) Then
			g_nStateNamesSize = g_nStateNamesSize + 100
			ReDim Preserve gStateNames(g_nStateNamesSize)
		End If
		gStateNames(Add_StateName) = sName
		
	End Function
	
	Function StateName2Code(ByRef sStateName As String, ByRef bAddIfNew As Boolean) As Integer
        Dim n As Integer, bExceptionState As Boolean
        Dim sCleanStateName As String
        bExceptionState = False
        sCleanStateName = Trim(sStateName)
        If (sCleanStateName.StartsWith("!")) Then
            sCleanStateName = sCleanStateName.Substring(1)
            bExceptionState = True
        End If
		
        StateName2Code = 0
        If (g_nTotalNameCount > 0) Then
            For n = 0 To g_nTotalNameCount
                If (sCleanStateName = gStateNames(n)) Then
                    StateName2Code = n
                    Exit For
                End If
            Next
        End If

        If ((StateName2Code = 0) And (bAddIfNew = True)) Then StateName2Code = Add_StateName(sStateName)
        If (bExceptionState = True) Then StateName2Code = -StateName2Code
    End Function
	
	Function StateCode2Name(ByRef nStateCode As Integer) As String
        Dim nAbsStateCode As Integer
        nAbsStateCode = Abs(nStateCode)
        If (nStateCode <= g_nTotalNameCount) Then
            StateCode2Name = gStateNames(nAbsStateCode)
        Else
            StateCode2Name = ""
        End If
	End Function
	
	
	Function Name_Sequence() As Integer
		'    Static g_nTotalNameCount As Long
		g_nTotalNameCount = g_nTotalNameCount + 1
		Name_Sequence = g_nTotalNameCount
	End Function
	
	Function Sequence() As Integer
		Static g_nTotalPatternCount As Integer
		g_nTotalPatternCount = g_nTotalPatternCount + 1
		Sequence = g_nTotalPatternCount
	End Function
End Module