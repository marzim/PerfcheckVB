Option Strict Off
Option Explicit On
Module MRegTool
	
	Public Enum EErrorRegTool
		eeBaseRegTool = 13590 ' RegTool
	End Enum
	
	Const sWin As String = "Software\Microsoft\Windows\"
	Const sExp As String = "CurrentVersion\Explorer\Shell Folders"
	Const sWinExp As String = sWin & sExp
	Const sBack As String = "\"
	Const sAppPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths"
	
	
	Function GetRegValue(ByVal hKey As Integer, ByRef sName As String, ByRef vValue As Object) As Integer
		Dim cData, ordType As Integer
		Dim sData As String
		GetRegValue = Win.Registry.RegQueryValueEx(hKey, sName, Win.CommonConst.pNull, ordType, 0, cData)
		If GetRegValue And GetRegValue <> Win.ErrorConstant.ERROR_MORE_DATA Then Exit Function
		Dim iData As Integer
		Dim dwData As Integer
		Dim abData() As Byte
		Select Case ordType
			Case Win.EREGTYPE.REG_DWORD, Win.EREGTYPE.REG_DWORD_LITTLE_ENDIAN
				GetRegValue = Win.Registry.RegQueryValueExInt(hKey, sName, Win.CommonConst.pNull, ordType, iData, cData)
				vValue = iData
				
			Case Win.EREGTYPE.REG_DWORD_BIG_ENDIAN ' Unlikely, but you never know
				GetRegValue = Win.Registry.RegQueryValueExInt(hKey, sName, Win.CommonConst.pNull, ordType, dwData, cData)
				'        vValue = MBytes.SwapEndian(dwData)
				
			Case Win.EREGTYPE.REG_SZ, Win.EREGTYPE.REG_MULTI_SZ ' Same thing to Visual Basic
				sData = New String(Chr(0), cData - 1)
				GetRegValue = Win.Registry.RegQueryValueExStr(hKey, sName, Win.CommonConst.pNull, ordType, sData, cData)
				vValue = sData
				
			Case Win.EREGTYPE.REG_EXPAND_SZ
				sData = New String(Chr(0), cData - 1)
				GetRegValue = Win.Registry.RegQueryValueExStr(hKey, sName, Win.CommonConst.pNull, ordType, sData, cData)
				'        vValue = MUtility.ExpandEnvStr(sData)
				
				' Catch REG_BINARY and anything else
			Case Else
				ReDim abData(cData)
				GetRegValue = Win.Registry.RegQueryValueExByte(hKey, sName, Win.CommonConst.pNull, ordType, abData(0), cData)
				vValue = VB6.CopyArray(abData)
				
		End Select
	End Function
	
	Function CreateRegValue(ByRef vValueA As Object, ByVal hKeyA As Integer, Optional ByRef sNameA As String = "") As Integer
		Dim c, ordType As Integer
		Dim ab() As Byte
		Dim i As Integer
		Dim s As String
		Dim iPos As Integer
		Select Case VarType(vValueA)
			Case VariantType.Array + VariantType.Byte
				ab = vValueA
				ordType = Win.EREGTYPE.REG_BINARY
				c = UBound(ab) - LBound(ab) - 1
				CreateRegValue = Win.Registry.RegSetValueExByte(hKeyA, sNameA, Win.CommonConst.pNull, ordType, ab(0), c)
				
			Case VariantType.Integer, VariantType.Short
				i = vValueA
				ordType = Win.EREGTYPE.REG_DWORD
				CreateRegValue = Win.Registry.RegSetValueExInt(hKeyA, sNameA, Win.CommonConst.pNull, ordType, i, 4)
				
			Case VariantType.String
				s = vValueA
				ordType = Win.EREGTYPE.REG_SZ
				' Assume anything with two non-adjacent percents is expanded string
				iPos = InStr(s, "%")
				If iPos Then
					If InStr(iPos + 2, s, "%") Then ordType = Win.EREGTYPE.REG_EXPAND_SZ
				End If
				c = Len(s) + 1
				CreateRegValue = Win.Registry.RegSetValueExStr(hKeyA, sNameA, Win.CommonConst.pNull, ordType, s, c)
				
				' User should convert to a compatible type before calling
			Case Else
				CreateRegValue = Win.ErrorConstant.ERROR_INVALID_DATA
				
		End Select
	End Function
	
	Function GetRegValueNext(ByVal hKey As Integer, ByRef i As Integer, ByRef sName As String, ByRef vValue As Object) As Integer
		Dim cName, cData As Integer
		Dim sData As String
		Dim ordType, cJunk As Integer
		Dim ft As Win.FILETIME
		' Get the value name and type in the first call
		vValue = Nothing
		' Name buffer of 256 should be big enough for most
		Do 
			cName = cName + 256
			sName = New String(Chr(0), cName)
			GetRegValueNext = Win.Registry.RegEnumValue(hKey, i, sName, cName, Win.CommonConst.pNull, ordType, Win.CommonConst.pNull, cData)
			' Repeat with bigger buffer in unlikely event name is too long
		Loop While GetRegValueNext = Win.ErrorConstant.ERROR_MORE_DATA
		' Fail for other errors
		If GetRegValueNext Then Exit Function
		sName = Left(sName, cName)
		
		' Handle each type separately
		Dim iData As Integer
		Dim dwData As Integer
		Dim abData() As Byte
		Select Case ordType
			Case Win.EREGTYPE.REG_DWORD, Win.EREGTYPE.REG_DWORD_LITTLE_ENDIAN
				GetRegValueNext = Win.Registry.RegEnumValueInt(hKey, i, sName, cName + 1, Win.CommonConst.pNull, ordType, iData, cData)
				vValue = iData
				
			Case Win.EREGTYPE.REG_DWORD_BIG_ENDIAN ' Unlikely, but you never know
				GetRegValueNext = Win.Registry.RegEnumValueInt(hKey, i, sName, cName + 1, Win.CommonConst.pNull, ordType, dwData, cData)
				'        vValue = MBytes.SwapEndian(dwData)
				
			Case Win.EREGTYPE.REG_SZ, Win.EREGTYPE.REG_MULTI_SZ ' Same thing to Visual Basic
				sData = New String(Chr(0), cData - 1)
				GetRegValueNext = Win.Registry.RegEnumValueStr(hKey, i, sName, cName + 1, Win.CommonConst.pNull, ordType, sData, cData)
				vValue = sData
				
			Case Win.EREGTYPE.REG_EXPAND_SZ ' Expand environment variables
				sData = New String(Chr(0), cData - 1)
				GetRegValueNext = Win.Registry.RegEnumValueStr(hKey, i, sName, cName + 1, Win.CommonConst.pNull, ordType, sData, cData)
				'        vValue = MUtility.ExpandEnvStr(sData)
				
			Case Else ' Catch REG_BINARY and anything else
				ReDim abData(cData)
				GetRegValueNext = Win.Registry.RegEnumValueByte(hKey, i, sName, cName + 1, Win.CommonConst.pNull, ordType, abData(0), cData)
				vValue = VB6.CopyArray(abData)
				
		End Select
		
	End Function
	
	Function GetRegNodeNext(ByVal hKey As Integer, ByRef i As Integer, ByRef sName As String) As Integer
		Dim cName, cJunk As Integer
		Dim ft As Win.FILETIME
		Do 
			cName = cName + 256
			sName = New String(Chr(0), cName)
			GetRegNodeNext = Win.Registry.RegEnumKeyEx(hKey, i, sName, cName, Win.CommonConst.pNull, Win.CommonConst.sNullStr, cJunk, ft)
			' Repeat with bigger buffer in unlikely event name is too long
		Loop While GetRegNodeNext = Win.ErrorConstant.ERROR_MORE_DATA
		' Fail for other errors
		If GetRegNodeNext Then Exit Function
		sName = Left(sName, cName)
		
	End Function
	
	Function CreateRegNode(ByVal hKey As Integer, ByRef sKeyNew As String, ByRef hKeyNew As Integer, Optional ByRef fExisted As Boolean = False, Optional ByVal afAccess As Integer = Win.EREGACCESS.KEY_ALL_ACCESS) As Integer
		Dim ordResult As Integer
		CreateRegNode = Win.Registry.RegCreateKeyEx(hKey, sKeyNew, 0, Win.CommonConst.sEmpty, Win.Registry.REG_OPTION_NON_VOLATILE, afAccess, Win.CommonConst.pNull, hKeyNew, ordResult)
		fExisted = (ordResult = Win.Registry.REG_OPENED_EXISTING_KEY)
	End Function
	
	' Delete node, but only if it has no subnodes (emulate WinNT RegDeleteKey)
	Function DeleteOneRegNode(ByVal hKeyRoot As Integer, ByRef sKey As String) As Integer
		'    If MUtility.IsNT Then
		DeleteOneRegNode = Win.Registry.RegDeleteKey(hKeyRoot, sKey)
		'    Else
		' Check to see if there are subnodes
		Dim e, cJunk, cNode As Integer
		Dim ft As Win.FILETIME
		e = Win.Registry.RegQueryInfoKey(hKeyRoot, Win.CommonConst.sNullStr, cJunk, Win.CommonConst.pNull, cNode, cJunk, cJunk, cJunk, cJunk, cJunk, cJunk, ft)
		' Delete only if no nodes
		If cNode = 0 Then
			DeleteOneRegNode = Win.Registry.RegDeleteKey(hKeyRoot, sKey)
		Else
			DeleteOneRegNode = Win.ErrorConstant.ERROR_ACCESS_DENIED
		End If
		'   End If
	End Function
	
	' Delete node and all its subnodes (emulate Win95 RegDeleteKey)
	Function DeleteRegNodes(ByVal hKeyRoot As Integer, ByRef sKey As String) As Integer
		Dim sKeyT As String
		Dim hSubKey As Integer
		Dim ft As Win.FILETIME
		
		' Try to delete whole thing--always works for Win95, but fails on
		' nodes with subnodes in WinNT
		DeleteRegNodes = Win.Registry.RegDeleteKey(hKeyRoot, sKey)
		If DeleteRegNodes = Win.ErrorConstant.ERROR_SUCCESS Then Exit Function
		DeleteRegNodes = Win.Registry.RegOpenKeyEx(hKeyRoot, sKey, 0, Win.EREGACCESS.KEY_ALL_ACCESS, hSubKey)
		' Delete each subnode
		Do While DeleteRegNodes = Win.ErrorConstant.ERROR_SUCCESS
			sKeyT = New String(Chr(0), Win.CommonConst.cMaxPath)
			DeleteRegNodes = Win.Registry.RegEnumKeyEx(hSubKey, 0, sKeyT, Win.CommonConst.cMaxPath, Win.CommonConst.pNull, Win.CommonConst.sNullStr, 0, ft)
			'        sKeyT = MUtility.StrZToStr(sKeyT)
			' Recursive call to remove node and any subnodes
			If DeleteRegNodes = Win.ErrorConstant.ERROR_SUCCESS Then
				DeleteRegNodes = DeleteRegNodes(hSubKey, sKeyT)
			End If
		Loop 
		Call Win.Registry.RegCloseKey(hSubKey)
		' Try to delete root again
		DeleteRegNodes = Win.Registry.RegDeleteKey(hKeyRoot, sKey)
		
	End Function
	
	Function GetRegStr(ByRef sKey As String, ByRef sItem As String, Optional ByVal hRoot As Win.EROOTKEY = Win.EROOTKEY.HKEY_CURRENT_USER) As String
		Dim e, hKey As Integer
		Dim s As String
		' Open a subkey
		e = Win.Registry.RegOpenKeyEx(hRoot, sKey, 0, Win.EREGACCESS.KEY_QUERY_VALUE, hKey)
		'    ApiRaiseIf e
		Dim ert As Win.EREGTYPE
		Dim c As Integer
		' Get the length and make sure it's a string
		e = Win.Registry.RegQueryValueEx(hKey, sItem, 0, ert, 0, c)
		' This error means no such entry, so return empty
		If e = Win.ErrorConstant.ERROR_FILE_NOT_FOUND Then Exit Function
		'    ApiRaiseIf e
		'    BugAssert ert = REG_SZ
		If c <> 0 Then
			s = New String(Chr(0), c - 1)
			' Read the string
			e = Win.Registry.RegQueryValueExStr(hKey, sItem, 0, ert, s, c)
			'        ApiRaiseIf e
		End If
		Win.Registry.RegCloseKey(hKey)
		GetRegStr = s
	End Function
	
	Function GetRegInt(ByRef sKey As String, ByRef sItem As String, Optional ByVal hRoot As Win.EROOTKEY = Win.EROOTKEY.HKEY_CURRENT_USER) As Integer
		Dim e, hKey As Integer
		' Open a subkey
		e = Win.Registry.RegOpenKeyEx(hRoot, sKey, 0, Win.EREGACCESS.KEY_QUERY_VALUE, hKey)
		'    ApiRaiseIf e
		Dim ert As Win.EREGTYPE
		Dim iVal, c As Integer
		' Get the length and make sure it's an integer
		e = Win.Registry.RegQueryValueEx(hKey, sItem, 0, ert, 0, c)
		' This error means no such entry, so return empty
		If e = Win.ErrorConstant.ERROR_FILE_NOT_FOUND Then Exit Function
		'    ApiRaiseIf e
		'    BugAssert ert = REG_DWORD
		If c <> 0 Then
			' Read the integer
			e = Win.Registry.RegQueryValueExInt(hKey, sItem, 0, ert, iVal, c)
			'        ApiRaiseIf e
		End If
		Win.Registry.RegCloseKey(hKey)
		GetRegInt = iVal
	End Function
	
	Sub SetRegStr(ByRef sItem As String, ByRef sValue As String, Optional ByRef sKey As String = "", Optional ByVal hKey As Win.EROOTKEY = Win.EROOTKEY.HKEY_CURRENT_USER)
		Dim hKeyNew As Integer
		If sKey <> Win.CommonConst.sEmpty Then
			On Error Resume Next
			CreateRegNode(hKey, sKey, hKeyNew)
			If Err.Number Then Exit Sub
			hKey = hKeyNew
		End If
		Win.Registry.RegSetValueExStr(hKeyNew, sItem, 0, Win.EREGTYPE.REG_SZ, sValue, Len(sValue) + 1)
	End Sub
	
	Sub SetRegInt(ByRef sItem As String, ByRef iValue As Integer, Optional ByRef sKey As String = "", Optional ByVal hKey As Win.EROOTKEY = Win.EROOTKEY.HKEY_CURRENT_USER)
		' If sKey not given, use given key handle, otherwise open key
		Dim hKeyNew As Integer
		If sKey <> Win.CommonConst.sEmpty Then
			On Error Resume Next
			CreateRegNode(hKey, sKey, hKeyNew)
			If Err.Number Then Exit Sub
			hKey = hKeyNew
		End If
		Win.Registry.RegSetValueExInt(hKey, sItem, 0, Win.EREGTYPE.REG_DWORD, iValue, 4)
	End Sub
	
	' Get key locations in registry
	
	Function GetDesktop() As String
		GetDesktop = GetRegStr(sWinExp, "Desktop") & sBack
	End Function
	
	Function GetFavorites() As String
		GetFavorites = GetRegStr(sWinExp, "Favorites") & sBack
	End Function
	
	Function GetStartMenu() As String
		GetStartMenu = GetRegStr(sWinExp, "Start Menu") & sBack
	End Function
	
	Function GetStartup() As String
		GetStartup = GetRegStr(sWinExp, "Startup") & sBack
	End Function
	
	Function GetPrograms() As String
		GetPrograms = GetRegStr(sWinExp, "Programs") & sBack
	End Function
	
	Function GetAppData() As String
		GetAppData = GetRegStr(sWinExp, "AppData") & sBack
	End Function
	
	Function GetCommonDesktop() As String
		GetCommonDesktop = GetRegStr(sWinExp, "Common Desktop") & sBack
	End Function
	
	Function GetCommonStartMenu() As String
		GetCommonStartMenu = GetRegStr(sWinExp, "Common Start Menu") & sBack
	End Function
	
	Function GetCommonStartup() As String
		GetCommonStartup = GetRegStr(sWinExp, "Common Startup") & sBack
	End Function
	
	Function GetCommonPrograms() As String
		GetCommonPrograms = GetRegStr(sWinExp, "Common Programs") & sBack
	End Function
	
	' AppPath procedures
	
	Function GetAppPath(ByRef sExe As String) As String
		Dim s As String
		Dim f As Boolean
		On Error Resume Next
		GetAppPath = GetRegStr(sAppPath & "\" & sExe, Win.CommonConst.sEmpty, Win.EROOTKEY.HKEY_LOCAL_MACHINE)
	End Function
	
	Function SetAppPath(ByRef sExeSpec As String, ByRef fSetPath As Boolean) As Boolean
		Dim sExeName As String
		Dim hKeyNew As Integer
		On Error GoTo FailSetAppPath
		'    sExeName = MUtility.GetFileBaseExt(sExeSpec)
		SetRegStr(Win.CommonConst.sEmpty, sExeSpec, sAppPath & "\" & sExeName, Win.EROOTKEY.HKEY_LOCAL_MACHINE)
		
		' Success if name set regardless of path success
		SetAppPath = True
		On Error Resume Next
		
		' Set path subkey if requested
		Dim sExePath As String
		If fSetPath Then
			'        sExePath = MUtility.GetFileDir(sExeSpec)
			sExePath = Left(sExePath, Len(sExePath) - 1) & ";"
			SetRegStr("Path", sExePath, sAppPath & "\" & sExeName, Win.EROOTKEY.HKEY_LOCAL_MACHINE)
		End If
		Win.Registry.RegCloseKey(hKeyNew)
		
FailSetAppPath: 
		
	End Function
	
	Function RemoveAppPath(ByRef sExe As String) As Boolean
		Dim e As Integer
		e = DeleteOneRegNode(Win.EROOTKEY.HKEY_LOCAL_MACHINE, sAppPath & "\" & sExe)
		RemoveAppPath = (e = 0)
	End Function
	
	
#If fComponent = 0 Then
	Private Sub ErrRaise(ByRef e As Integer)
		Dim sText, sSource As String
		If e > 1000 Then
			sSource = My.Application.Info.AssemblyName & ".RegTool"
			Select Case e
				Case EErrorRegTool.eeBaseRegTool
					'            BugAssert True
					' Case ee...
					'     Add additional errors
			End Select
			'        Err.Raise COMError(e), sSource, sText
		Else
			' Raise standard Visual Basic error
			sSource = My.Application.Info.AssemblyName & ".VBError"
			Err.Raise(e, sSource)
		End If
	End Sub
#End If
End Module