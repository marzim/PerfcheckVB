Imports Microsoft.Win32
Imports Win.Registry


Public Class VB_Net_Registry
    Function CreateSubKey()
        Dim regKey As RegistryKey
        regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", True)
        regKey.CreateSubKey("MyApp")
        regKey.Close()
        MsgBox("Registry key HKLM\Software\MyApp created.")
    End Function

    'CreateRegNode
    Function CreateRegNode(ByVal hKey As Integer, ByRef sKeyNew As String, ByRef hKeyNew As Integer, Optional ByRef fExisted As Boolean = False, Optional ByVal afAccess As Integer = Win.EREGACCESS.KEY_ALL_ACCESS) As Integer
        Dim ordResult As Integer
        CreateRegNode = Win.Registry.RegCreateKeyEx(hKey, sKeyNew, 0, Win.CommonConst.sEmpty, Win.Registry.REG_OPTION_NON_VOLATILE, afAccess, Win.CommonConst.pNull, hKeyNew, ordResult)
        fExisted = (ordResult = Win.Registry.REG_OPENED_EXISTING_KEY)
    End Function


    'CreateRegValue
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
                CreateRegValue = Win.Registry.RegSetValueEx(hKeyA, sNameA, Win.CommonConst.pNull, ordType, ab(0), c)
                registry.
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


    'GetRegValue
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


    'RegCloseKey
		Call Win.Registry.RegCloseKey(hSubKey)


End Class
