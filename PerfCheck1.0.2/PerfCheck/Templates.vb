'Option Strict On
Option Explicit On
'Namespace PerfCheck
Public Class CTemplates
	Const MAX_ANCHORSTATES As Integer = 200
	
	Private m_UnrecognizedStatesListFile As String
	Private m_PatternResultsFile As String
	Private m_AnchorStateIndexes(MAX_ANCHORSTATES) As Integer
	Private m_AnchorStateCount As Integer
	Private m_Patterns As New CPatterns
	Private m_UnknownPatterns As New CPatterns
	Private m_UnknownPatternCount As Integer
	Private m_TotalPatternsFound As Integer
	Private m_bInit As Boolean
	Private finalCollectionStates As SignifEvents
	
	'PatternMatch is the top level function to test existing patterns against a
	' state linked list, adding new state patterns as required to reach the
	' anchor states
	
	
	Public Function PatternMatch(ByRef colStates As SignifEvents, ByRef frmForm As System.Windows.Forms.Form) As Integer
		'Public Function PatternMatch(colTransactions As CTransactions, colStates As SignifEvents, frmForm As Form) As Long
		If colStates Is Nothing Then
			Throw New ArgumentNullException("PatternMatch")
		End If
		
		finalCollectionStates = colStates
        Dim objLastAnchorState, objNewAnchorState As SignifEvent
        '		Dim objPattern As CPattern
		
		'UPGRADE_NOTE: Object objLastAnchorState may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        objLastAnchorState = Nothing
        objNewAnchorState = Nothing       
		
		Try
			' once only - find first anchor state
		If (objLastAnchorState Is Nothing) Then
            objLastAnchorState = FindNextAnchorState(colStates(1))
            If objLastAnchorState Is Nothing Then
            	MessageService.ShowWarning("No Anchor State found in STF file", "Warning in PatternMatch()")
            	return -1
            End If
            objNewAnchorState = FindNextAnchorState(objLastAnchorState)
            m_TotalPatternsFound = 0
			If (objNewAnchorState Is Nothing) Then
				MessageService.ShowWarning("No Anchor State found in STF file", "Warning in PatternMatch()")
				return -1
			End If
			
			'        frmForm.SetProgressBarLimit colStates.Count
		End If
		Dim bMatch As Boolean
		Dim lOldStates, lStates, nPatternIdx As Integer
		
		lStates = 0
		lOldStates = 0
        Do While (Not objNewAnchorState Is Nothing)

            lStates = lStates + 1
            If (lStates - lOldStates > 500) Then
                lOldStates = lStates
                '            frmForm.UpdateProgressgBar lStates
                System.Windows.Forms.Application.DoEvents()
            End If

            ' anchor state now valid;
            ' perform pattern search
            ' *** verify that patterns are in fact unique.
            bMatch = TestAllPatterns(m_Patterns, objLastAnchorState, objNewAnchorState, nPatternIdx)
            If (bMatch) Then ' pattern has matched
                m_TotalPatternsFound = m_TotalPatternsFound + 1
                    'Else

                    'bMatch = TestAllPatterns(m_UnknownPatterns, objLastAnchorState, objNewAnchorState, nPatternIdx)
                    ' No pattern matched; isolate the new pattern and create a CPattern of it
                    ' The pattern starts at last anchor, and ends at the next anchor state found
                    ' Locate the next anchor state

                    'objLastAnchorState = objNewAnchorState
                    'If (objNewAnchorState Is Nothing) Then
                    ' Exit Do
                    'End If

                    ' have the previous and next anchor states; create the pattern
                    'If (Not AddUnknownPattern(colStates, objLastAnchorState, objNewAnchorState, nPatternIdx)) Then
                    ' pattern already existed
                    'End If
            End If
            '        IncTransitionPatternCount colTransactions, nPatternIdx, objLastAnchorState
            objLastAnchorState = objNewAnchorState
            objNewAnchorState = FindNextAnchorState(objLastAnchorState)
        Loop
		Catch ex As Exception
			throw new Exception(ex.Message)
		End Try
		
		'    frmForm.UpdateProgressgBar 0
		PatternMatch = m_TotalPatternsFound
	End Function
	
	'Private Sub IncTransitionPatternCount(colTransactions As CTransactions, nPatternIdx As Long, objFirstPatternState As SignifEvent)
	'    ' determine the ctransaction state that contains the first pattern state and tally
	'    ' the pattern index of cpatternArray for the indicated pattern for that transaction.
	'    Static objTransaction As CTransaction
	'    If (objTransaction Is Nothing) Then Set objTransaction = colTransactions(1)
	'    If (Not m_bInit) Then
	'        If (objFirstPatternState.nStateIndex < objTransaction.objAttractState.nStateIndex) Then
	'            Exit Sub
	'        Else
	'            m_bInit = True
	'        End If
	'    End If
	'    If (Not objTransaction.objNextTransaction Is Nothing) Then
	'        Do Until (objFirstPatternState.nStateIndex >= objTransaction.objAttractState.nStateIndex _
	''            And objFirstPatternState.nStateIndex < objTransaction.objNextTransaction.objAttractState.nStateIndex)
	'
	'            Set objTransaction = objTransaction.objNextTransaction
	'            If (objFirstPatternState.nStateIndex < objTransaction.objAttractState.nStateIndex) Then
	'                MsgBox ("transaction obj and pattern detection sync loss")
	'                Stop
	'            End If
	'            If (objTransaction.objNextTransaction Is Nothing) Then Exit Do
	'        Loop
	'    End If
	'    objTransaction.objPatternArray.Tally (nPatternIdx)
	'End Sub
	
	Private Function TestAllPatterns(ByRef objPatterns As CPatterns, ByRef objLastAnchorState As SignifEvent, ByRef objNewAnchorState As SignifEvent, ByRef nPatternIdx As Integer) As Boolean
        Dim objPattern As CPattern, bSequencePoisoned As Boolean
        TestAllPatterns = False

        Try
            For Each objPattern In objPatterns
                bSequencePoisoned = False
                If (PatternTest(objPattern, objLastAnchorState, objNewAnchorState)) Then

                    ' pattern matched; check for poison states
                    Dim obj As CPatternState
                    For Each obj In objPattern.PoisonStates
                        If (objPattern.Count > 0) Then
                        	If (Me.SearchState(obj, _
                        		finalCollectionStates.Item(objPattern(1).CollectionIndex), _
                        		finalCollectionStates.Item(objPattern(objPattern.Count).CollectionIndex)) = True) Then
                            'formLogAnalysisMain.MergedTraceEvents.Item(objPattern(1).CollectionIndex), _
                            	'formLogAnalysisMain.MergedTraceEvents.Item(objPattern(objPattern.Count).CollectionIndex)) = True) Then
                            	
                                bSequencePoisoned = True
                                Exit For
                            End If
                        End If
                    Next

                    ' Tally the pattern and duration
                    If (Not bSequencePoisoned And objPattern.Count > 0) Then
                        objPattern.AccumulateStatsMs(objPattern(1).TimeMs, objPattern(objPattern.Count).TimeMs)
                        objPattern.PatternPointers.Add(objPattern(1).CollectionIndex, _
                            CDbl(objPattern(objPattern.Count).TimeMs) - CDbl(objPattern(1).TimeMs))
                        TestAllPatterns = True
                        nPatternIdx = objPattern.nIndex
                    End If
                End If
            Next objPattern
            'MsgBox(scount.ToString())
        Catch ex As Exception
        	MessageService.ShowError(ex.Message,"Error in " + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)            
        End Try
		
        objPattern = Nothing
	End Function
	
	
    Private Function PatternTest(ByRef objPattern As CPattern, ByRef objLastAnchorState As SignifEvent, ByRef objNextAnchorState As SignifEvent) As Boolean
        ' test all known patterns starting from the current anchor state constrained by the next anchor state

        Dim objState As SignifEvent, objTemp As SignifEvent, objExclusionAnchor As SignifEvent
        Dim objPatternState As CPatternState
        Dim objExclusions As CExclusions, objExclusion As CPatternState

        Dim bRecursiveExit As Boolean = False
        PatternTest = True
        objExclusions = Nothing
        objExclusionAnchor = Nothing

        objState = objLastAnchorState 'reset starting state

        For Each objPatternState In objPattern
            'Perform a bounded search for the pattern within the state sequence bounded by LastAnchorstate and NextAnchorState
            'search must be completed within the bounds of consecutive anchor states; e.g. cannot extend beyond the end of the
            'search range signalled by NextAnchorState
			
			'From_SMCashPayment-To_SMTakeCard-To_SMTakeChange		
			
            If (objPatternState.eStateName < 0) Then
                If (objExclusions Is Nothing) Then objExclusions = New CExclusions
                objExclusions.Add(-objPatternState.eStateName)
                If (objExclusionAnchor Is Nothing) Then
                    objExclusionAnchor = objState           'remember where to start exception search
                End If
            Else

                'for each state within the pattern, search for consecutive matches
                ' on success, objState is updated to the matching state
                If (SearchState(objPatternState, objState, objNextAnchorState) = False) Then
                    PatternTest = False
                    Exit For
                End If
                ' tom End If
                ' verify no exclusion states exist in the interval just found
                If objExclusions IsNot Nothing Then
                    For Each objExclusion In objExclusions
                        objTemp = objExclusionAnchor.objNextState       'reset search to start of interval + one state
                        If (SearchState(objExclusion, objTemp, objState) = True) Then
                            PatternTest = PatternTest(objPattern, objTemp, objNextAnchorState)      ''recursive call!!!
                            bRecursiveExit = True
                            Exit For
                        End If
                    Next objExclusion
                    objExclusions = Nothing
                    objExclusionAnchor = Nothing
                End If
                If ((PatternTest = False) Or (bRecursiveExit = True)) Then
                    Exit For
                End If
            End If  '.tom.
        Next objPatternState

        objState = Nothing
        objPatternState = Nothing
        objTemp = Nothing
        objExclusion = Nothing
        objExclusions = Nothing
        
    End Function

    Function SearchState(ByRef objPattern As CPatternState, ByRef objState As SignifEvent, ByRef objEndingState As SignifEvent) As Boolean
        'start of search (objState) is updated on successful search to point to object found; other wise indeterminant.
        SearchState = False

        Do
            If (objPattern.eStateName = objState.NameIndex) Then
                objPattern.TimeMs = objState.TimeMs                     'store time of matched state
                objPattern.CollectionIndex = objState.CollectionIndex   'store location in event collection

                SearchState = True          ' found it.
                Exit Do
            End If
            objState = objState.objNextState
            If (objState Is Nothing) Then Exit Do
        Loop Until objState.CollectionIndex > objEndingState.CollectionIndex
    End Function

'    Private Function AddUnknownPattern(ByRef m_colStates As SignifEvents, ByRef objLastAnchorState As SignifEvent, ByRef objNewAnchorState As SignifEvent, ByRef nPatternIdx As Integer) As Boolean
'        ' create a new pattern for the unknown sequence
'        Dim objState As SignifEvent
'        Dim objPattern As CPattern
'        objState = objLastAnchorState
'        AddUnknownPattern = False
'
'        objPattern = New CPattern
'        Try
'        	Do
'            'add the PatternStates by index only
'            objPattern.Add((objState.NameIndex))
'            objState = objState.objNextState
'	        Loop Until objState.NameIndex = objNewAnchorState.NameIndex
'	        objPattern.Add((objState.NameIndex))
'	
'	        'now compare the new pattern against the existing patterns for uniqueness
'	        '    If (PatternDuplicate(m_UnknownPatterns, objPattern) Or objPattern.Count < 2) Then
'	        '        ' delete the duplicate pattern
'	        '        Set objPattern = Nothing        'distructor cleans up class
'	        '    Else
'	        ' make a name; don't name it until we know it's unique...
'	        m_UnknownPatternCount = m_UnknownPatternCount + 1
'	        objPattern.PatternName = MakeUnknownPatternName(objPattern)
'	        '        objPattern.PatternName = "Unknown" + Str(m_UnknownPatternCount)
'	        objPattern.Category = "Unknown"
'	        'x.1        objPattern.AccumulateStats objLastAnchorState, objNewAnchorState
'	        If Not objLastAnchorState.objNextState Is Nothing and Not objNewAnchorState.objNextState Is Nothing Then
'	        	objPattern.AccumulateStatsMs(objLastAnchorState.objNextState.TimeMs, objNewAnchorState.objNextState.TimeMs)
'	        	m_UnknownPatterns.Add(objPattern)
'		        nPatternIdx = objPattern.nIndex
'		        AddUnknownPattern = True
'	        End If
'        Catch ex As Exception
'        	MessageService.ShowError(ex.Message,"Error in "  + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)
'        End Try
'        
'        '    End If
'
'        'UPGRADE_NOTE: Object objPattern may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
'        objPattern = Nothing
'        'UPGRADE_NOTE: Object objState may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
'        objState = Nothing
'    End Function

'	Private Function MakeUnknownPatternName(ByRef objPattern As CPattern) As String
'		Dim sName As String
'		Dim nNameLen, nNameCount As Integer
'		Dim objExistingPattern As CPattern
'		sName = objPattern(1).StateName & "-" & objPattern((objPattern.Count)).StateName
'		nNameLen = Len(sName)
'		' count previous instances of this pattern name and suffix a highest count integer
'		For	Each objExistingPattern In m_UnknownPatterns
'			If (Left(objExistingPattern.PatternName, nNameLen) = sName) Then
'				nNameCount = nNameCount + 1
'			End If
'		Next objExistingPattern
'		nNameCount = nNameCount + 1
'		MakeUnknownPatternName = sName & Str(nNameCount)
'	End Function
'	
'	Private Function PatternDuplicate(ByRef Patterns As CPatterns, ByRef objNewPattern As CPattern) As Boolean
'		Dim objPattern As CPattern
'		Dim bMismatch As Boolean
'		Dim n As Integer
'		bMismatch = False
'		PatternDuplicate = False
'		
'		For	Each objPattern In Patterns
'			If (objPattern.Count = objNewPattern.Count) Then
'				For n = 1 To objNewPattern.Count
'					If (objNewPattern(n).eStateName <> objPattern(n).eStateName) Then
'						bMismatch = True
'						Exit For
'					End If
'				Next
'			End If
'			If (Not bMismatch) Then
'				'a duplicate was found
'				PatternDuplicate = True
'				Exit For
'			End If
'		Next objPattern
'		'UPGRADE_NOTE: Object objPattern may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
'		objPattern = Nothing
'	End Function
	
	Private Function FindNextAnchorState(ByRef objAnchorState As SignifEvent) As SignifEvent
		' Starting at the state following the AnchorState parameter, return the next
		' anchor state.'''
		
		Dim objCurrentState As SignifEvent
		Dim n As Integer
		objCurrentState = objAnchorState
		'UPGRADE_NOTE: Object FindNextAnchorState may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		FindNextAnchorState = Nothing
		Try
			Do While (Not objCurrentState.objNextState Is Nothing)
				objCurrentState = objCurrentState.objNextState
				For n = 0 To m_AnchorStateCount - 1
					If (objCurrentState.NameIndex = m_AnchorStateIndexes(n)) Then
						FindNextAnchorState = objCurrentState
						Exit Do
					End If
				Next
			Loop
		Catch ex As Exception
			MessageService.ShowError(ex.Message,"Error in " + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)
			
		End Try
		
		'UPGRADE_NOTE: Object objCurrentState may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		objCurrentState = Nothing
	End Function
	
	Public Function Initialize(esReader As IExtendedTextReader) As Object	
        Dim sLine As String
        Dim sSection As String = ""
		Dim o As Object = Nothing
		Dim bRet As Boolean
		sLine = String.Empty	
		Do While (InlineAssignHelper(sLine, eSReader.ReadLine())) IsNot Nothing ' Loop until end of file.
			If (Len(sLine) > 0 And Mid(sLine, 1, 1) <> ";") Then				
				LTrim(sLine)
				If (Mid(sLine, 1, 1) = "[") Then
					sSection = ""
					If (StrComp(Mid(sLine, 2, 13), "Configuration", CompareMethod.Text) = 0) Then
						sSection = "Configuration"
					ElseIf (StrComp(Mid(sLine, 2, 12), "AnchorStates", CompareMethod.Text) = 0) Then
						sSection = "AnchorStates"
					ElseIf (StrComp(Mid(sLine, 2, 8), "Patterns", CompareMethod.Text) = 0) Then
						sSection = "Patterns"
					End If
					
					If (sSection = "") Then								
						MessageService.ShowError("Unknown ini file section name","Error in " + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)
					End If
				Else					
					bRet = False
					Select Case sSection
						Case "Configuration"
							'bRet = ParseConfiguration(sLine)
						Case "AnchorStates"
							bRet = ParseAnchorStates(sLine)
						Case "Patterns"
							bRet = ParsePatterns(sLine)
					End Select
					If (Not bRet) Then								
						 MessageService.ShowError("INI file syntax error","Error in " + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)								
					End If
				End If
				o = New Object()
			End If					
		Loop
		eSReader.Close
		Return o
	End Function
	
	Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
			target = value
			Return value
	End Function
	
	
	'ta185044 - function not in use
	'I think this function will not work anymore since in .ini file, configuration section is removed
'	Public Function ParseConfiguration(ByVal sLine As String) As Boolean
'		
'		'UnrecognizedStatesListFile = UnrecognizedStatesListFile.txt
'		'PatternResultsFile = PatternResultsFile
'		Dim sKeyWord As String
'		Dim n As Integer
'		ParseConfiguration = False ' function return value as error
'		
'		n = InStr(sLine, "=")
'		If (n > 1) Then
'			sKeyWord = Mid(sLine, 1, n - 2)
'			sLine = Mid(sLine, n + 1)
'			LTrim(sLine)
'			
'			If (StrComp(sKeyWord, "UnrecognizedStatesListFile", CompareMethod.Text) = 0) Then
'				m_UnrecognizedStatesListFile = LTrim(sLine)
'				ParseConfiguration = True
'			ElseIf (StrComp(sKeyWord, "PatternResultsFile", CompareMethod.Text) = 0) Then
'				m_PatternResultsFile = LTrim(sLine)
'				ParseConfiguration = True
'			End If
'		End If
'		'    If (sSection = "") Then
'		'        MsgBox "Unknown ini file section name: " + sLine
'		'        Stop
'		'    End If
'		
'	End Function
	
	
	Public Function ParseAnchorStates(ByVal sStateName As String) As Boolean
		Dim n As Integer
		ParseAnchorStates = False
		If sStateName.Length > 0 Then
			n = StateName2Code(sStateName, True)
			If (n > 0) Then
				m_AnchorStateIndexes(m_AnchorStateCount) = n
				m_AnchorStateCount = m_AnchorStateCount + 1
				ParseAnchorStates = True
			Else
				MessageService.ShowWarning("Unknown State in INI file: " & sStateName)		
			End If	
		End If		
	End Function
	
	Public Function ParsePatterns(ByVal sLine As String) As Boolean
		'[Patterns]
		'; name, state-state-...-state, keyword=value [, keyword=value, ...]
		'Scan From Attract, SMAttract - SMBagAndEAS - SMScanAndBag, Category=Normal
		'Normal Scan Item, SMScanAndBag - SMBagAndEAS - SMScanAndBag, Category=Normal
        Dim sName, sKeyValPairs As String
        Dim n As Integer, m As Integer
        Dim sStateList As String, sExceptionList As String
		Dim objPattern As CPattern
		
        ParsePatterns = True ' function return value as error
        sKeyValPairs = ""
		
		' Isolate name field
		n = InStr(sLine, ",")
		If (n > 1) Then
			sName = Mid(sLine, 1, n - 1)
			sLine = Mid(sLine, n + 1)
			LTrim(sLine)
			
			' Isolate state list
			n = InStr(sLine, ",")
			If (n > 1) Then
                sStateList = Mid(sLine, 1, n - 1)
                m = InStr(n + 1, sLine, ",")
                If (m > 1) Then
                    sExceptionList = LTrim(Mid(sLine, n + 1, m - n - 1))
                    sKeyValPairs = Mid(sLine, m + 1)
                    LTrim(sStateList)
                    LTrim(sKeyValPairs)
                    objPattern = m_Patterns.Add2(sName, sStateList, sKeyValPairs, sName)

					If (sExceptionList.Length() > 0) Then 
						objPattern.ExclusionList = sExceptionList

					'If (objPattern Is Nothing) Then
					'	MessageService.ShowError("Error adding pattern: " & sName & "," & sStateList & "," & sKeyValPairs, "Error in " + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)	
                    '	ParsePatterns = False ' function return value as error
                    'Else
                        'UPGRADE_NOTE: Object objPattern may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                        objPattern = Nothing
                    End If
                Else
                	MessageService.ShowError("Syntax error adding pattern: " & sName & "," & sStateList & "," & sKeyValPairs, "Error in " + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)  
                	ParsePatterns = False
                End If
			End If
        End If
	End Function
	
'    Public Function Report(ByRef bDetails As Boolean, ByRef objListBox As System.Windows.Forms.DataGridView) As Object
'        ' report our findings.  For each end node; report path and stats
'        Dim objPattern As CPattern, objSummaryStats As CStatistics, nCategories As Integer
'        Dim myColors(2) As Color, i As Integer
'        myColors(1) = Color.PaleGoldenrod
'        myColors(2) = Color.PaleVioletRed
'        Report = Nothing
'
'        objListBox.Rows.Clear()
'        If (m_TotalPatternsFound > 0) Then
'
'            'objListBox.Items.Add("Known Pattern Statistics")
'            objListBox.Rows.Add("Known Pattern Statistics")
'            objPattern = New CPattern
'
'            Dim sCategory As String, sFormattedLine As String
'            Dim dgr(6) As String, flags(6) As Integer
'
'            sCategory = ""
'            While GetNextCategory(sCategory, m_Patterns)
'                objListBox.Rows.Add("")
'                objListBox.Rows.Add("Category: " & sCategory)
'                objListBox.Item(0, objListBox.RowCount - 1).Style.ForeColor = Color.Red
'                'objListBox.Items.Add("")
'                'objListBox.Items.Add("Category: " & sCategory)
'                objSummaryStats = New CStatistics()
'                nCategories = 0
'
'
'                For Each objPattern In m_Patterns
'                	
'                    If (ExtractKeyValue(objPattern.keyValue("Category")) = sCategory) Then
'                    	objSummaryStats.LumpStats(objPattern.stats)
'                        nCategories = nCategories + 1
'                        sFormattedLine = objPattern.Report(dgr, flags)
'                        If dgr(4).Split(CChar(".")).Length > 0 Then
'                            dgr(4) = dgr(4).Split(CChar("."))(0)
'                        End If
'                        If dgr(5).Split(CChar(".")).Length > 0 Then
'                            dgr(5) = dgr(5).Split(CChar("."))(0)
'                        End If
'                        objListBox.Rows.Add(dgr)
'                        
'                        For i = 1 To 6
'                        	If (flags(i) > 0) Then
'                        		If flags(i) = 1 Then
'                        			objListBox.Item(i, objListBox.RowCount - 1).Style.BackColor = Color.Yellow
'                        		Else
'                        			objListBox.Item(i, objListBox.RowCount - 1).Style.BackColor = Color.PaleVioletRed
'                        		End If
'                                'objListBox.Item(i, objListBox.RowCount - 1).Style.BackColor = CType(IIf(flags(i) = 1, Color.Yellow, Color.PaleVioletRed), Color)
'                            End If
'                        Next
'                        'objListBox.Item(2, 2).Style.BackColor = Color.LimeGreen
'                        'objListBox.Items.Add(objPattern.Report())
'                    End If
'                Next objPattern
'                If (nCategories > 1) Then
'                    'objListBox.Items.Add("Category " & sCategory & " Totals: " & objSummaryStats.Report())
'                    Dim s As String = objSummaryStats.Report(dgr, flags, 999999, 999999, 999999, 999999, 99999.0#, 99999.0#)
'                    If dgr(4).Split(CChar(".")).Length > 0 Then
'                        dgr(4) = dgr(4).Split(CChar("."))(0)
'                    End If
'                    dgr(0) = "Totals:"                  	
'                    objListBox.Rows.Add(dgr)
'                    
'                    objListBox.Rows(objListBox.Rows.Count-1).Cells(4).Value = GetAvgTotal(objListBox, sCategory).ToString()  
'                    objListBox.Rows(objListBox.Rows.Count-1).Cells(1).Value = ""
'                    objListBox.Rows(objListBox.Rows.Count-1).Cells(5).Value = ""
'                    
'                    objListBox.Item(0, objListBox.RowCount - 1).Style.ForeColor = Color.Red
'                    'objListBox.Rows.Add("Category " & sCategory & " Totals: " & objSummaryStats.Report())
'                    objSummaryStats = Nothing
'                End If
'            End While
'            FileClose(1)
'        Else
'            objListBox.Rows.Add("No Patterns Found")
'        End If
'        objPattern = Nothing
'        If g_errPatternsLoad.Length > 0 Then
'        	MessageService.ShowWarning("Below event patterns are not found. Maybe you misspell them?" + Environment.NewLine + g_errPatternsLoad.ToString(),"Warning in Report()")
'	 		g_errPatternsLoad = new System.Text.StringBuilder()
'		End If
'    End Function
    
'    Private Function GetAvgTotal(ByVal dg As DataGridView, ByVal category As String) as Integer
'    	Dim i As Integer = 0    	
'    	For i = 0 To dg.Rows.Count -1
'    		Dim s as String = dg.Rows(i).Cells(0).Value.ToString()
'    		If s.Contains(CChar(":")) Then
'    			If s.Split(CChar(":"))(1).Trim().Equals(category) Then
'    				return AvgTotal(dg, i+1)	
'    			End If    			
'    		End If
'    	Next    	
'    End Function
'    
'    Private Function AvgTotal(ByVal dg As DataGridView, Byval cnt as Integer) as Integer
'    	Dim i As Integer = 0
'    	Dim total as Integer = 0
'    	For i = cnt To dg.Rows.Count -2
'    		total += Integer.Parse(dg.Rows(i).Cells(4).Value.ToString())
'    	Next
'    	return total
'    End Function
    
    Public Function Report() As LogEventsSummary
        ' report our findings.  For each end node; report path and stats
        Dim logevents as new LogEventsSummary()
        Dim objPattern As CPattern, objSummaryStats As CStatistics, nCategories As Integer, nTotalAverage As Double, nAverage as Double
        
        If (m_TotalPatternsFound > 0) Then
			
            logevents = New LogEventsSummary(New LogEventSummary("Known Pattern Statistics","","","","",""))
            objPattern = New CPattern

            Dim sCategory As String, sFormattedLine As String
            Dim dgr(6) As String, flags(6) As Integer
            sCategory = ""
            While GetNextCategory(sCategory, m_Patterns)
				
                logevents.Add(New LogEventSummary("","","","","",""))
                logevents.Add(New LogEventSummary("Category: " + sCategory,"","","","",""))
                logevents.GetEvents().Item(logevents.GetEvents().Count-1).Flag.Add(1000) 'indicator for forecolor of the datagridview
                objSummaryStats = New CStatistics()
                nCategories = 0
                nTotalAverage=0

                For Each objPattern In m_Patterns
                    If (ExtractKeyValue(objPattern.keyValue("Category")) = sCategory) Then
                        objSummaryStats.LumpStats(objPattern.stats)
                        nCategories = nCategories + 1
                        sFormattedLine = objPattern.Report(dgr, flags)
                        If dgr(4).Split(CChar(".")).Length > 0 Then
                            dgr(4) = dgr(4).Split(CChar("."))(0)
                        End If
                        Double.TryParse(dgr(4), nAverage)
                        nTotalAverage += nAverage                        
                        If dgr(5).Split(CChar(".")).Length > 0 Then
                            dgr(5) = dgr(5).Split(CChar("."))(0)
                        End If
                        
                        If Not dgr Is Nothing Then
                        	If dgr(0) Is Nothing Then
                        		dgr(0) = ""
                        	End If
                        	logevents.Add(New LogEventSummary(dgr(0),dgr(1),dgr(2),dgr(3),dgr(4),dgr(5)))                        	
                        End If
                        Dim i As Integer
                    	For i = 1 To 6
                    		If flags(i) > 0 Then
                    			If flags(i) = 1 Then                    				
                    				logevents.GetEvents().Item(logevents.GetEvents().Count-1).Flag.Add(1)
                    				logevents.GetEvents().Item(logevents.GetEvents().Count-1).Col.Add(i)
                    			Else                    				
                    				logevents.GetEvents().Item(logevents.GetEvents().Count-1).Flag.Add(2)
                    				logevents.GetEvents().Item(logevents.GetEvents().Count-1).Col.Add(i)
                    			End If
                    		End If
                    	Next
                    End If
                Next 
                If (nCategories > 1) Then
                    Dim s As String = objSummaryStats.Report(dgr, flags, 999999, 999999, 999999, 999999, 99999.0#, 99999.0#)
                    dgr(0) = "Totals:"
                    dgr(4) = nTotalAverage.ToString
                    If dgr(4).Split(CChar(".")).Length > 0 Then
                        dgr(4) = dgr(4).Split(CChar("."))(0)
                    End If
                    
					logevents.Add(New LogEventSummary(dgr(0),"",dgr(2),dgr(3),dgr(4),""))
                    logevents.GetEvents().Item(logevents.GetEvents().Count-1).Flag.Add(1000) 'indicator for forecolor of the datagridview
                    objSummaryStats = Nothing
                End If
            End While
            FileClose(1)
        Else
        	'LogHelper.Log("No Patterns Found",LogType.WARNING, true)
        	MessageService.ShowWarning("No Patterns Found","ReportCmd()")
        End If
        objPattern = Nothing
        If g_errPatternsLoad.Length > 0 Then
        	MessageService.ShowWarning("Below patterns are not found." + Environment.NewLine + g_errPatternsLoad.ToString(),"Patterns not found.")
	 		
			g_errPatternsLoad = new System.Text.StringBuilder()
		End If
		return logevents
    End Function

    ' return next category value after param
    Public Function GetNextCategory(ByRef sCategory As String, ByVal col As CPatterns) As Boolean
        ' key = value collection
        Dim sKey As String, sTemp As String, objPattern As CPattern
        GetNextCategory = False            ' def return value
        sTemp = ""

        For Each objPattern In col
            '            i = objPattern.KeyValPairs.IndexOf("=")
            '            sKey = Trim(objPattern.KeyValPairs.Substring(i + 1))
            sKey = objPattern.keyValue("Category")
            If (sTemp = "" And sKey > sCategory) Then sTemp = sKey
            If (sTemp > "" And sKey > sCategory And sTemp > sKey) Then sTemp = sKey
        Next
        If (sTemp > "") Then
            GetNextCategory = True
            sCategory = sTemp
        End If
    End Function
    ' return value extracted from kv param
    Public Function ExtractKeyValue(ByVal sKeyVal As String) As String
        Dim i As Integer
        i = sKeyVal.IndexOf("=")
        ExtractKeyValue = Trim(sKeyVal.Substring(i + 1))
    End Function

	Public Sub cmdMakeCSVFiles(ByRef OutFileName As String, ByRef bAppendTransactionStats As Boolean)
		'Public Sub cmdMakeCSVFiles(OutFileName As String, bAppendTransactionStats As Boolean, colTransactions As CTransactions)
		
		Const sPatCsvExtension As String = "_pat.csv"
		
		'    Dim sLine As String, sCsvFileRootName As String
		Dim objPattern As CPattern
		Dim sLine As String
		Dim isSuccess As Boolean = True
		Dim fInTrxProb, fValidTrxCnt As Single
		Dim InTrxCnt As Integer
		
			If (m_TotalPatternsFound > 0) Then
				
			Try
				
				FileOpen(1, OutFileName & sPatCsvExtension, OpenMode.Output)
				PrintLine(1, "Known Pattern Statistics")
				PrintLine(1, "")
				objPattern = New CPattern
				
				PrintLine(1, objPattern.CSV_Labels)
				'        fValidTrxCnt = colTransactions.ValidTransactionCount
				fValidTrxCnt = 1
				me.m_perfmeasures = new PerfMeasures()
				For	Each objPattern In m_Patterns
					'            InTrxCnt = colTransactions.InTrxCnt(objPattern.nIndex, True)
					fInTrxProb = InTrxCnt / fValidTrxCnt
					sLine = objPattern.CSV_Data(InTrxCnt, fInTrxProb)
					
					'Me.m_perfmeasures.Add(Me.GetPerfMeasureData(objPattern))
					
					PrintLine(1, sLine)
				Next objPattern
				
	            '			PrintLine(1, "")
	            '			PrintLine(1, "Unknown Pattern Statistics")
	            '			PrintLine(1, "")
	            '			objPattern = New CPattern
	            '			PrintLine(1, objPattern.CSV_Labels)
				
	            '			For	Each objPattern In m_UnknownPatterns
	            '				'            InTrxCnt = colTransactions.InTrxCnt(objPattern.nIndex, True)
	            '				fInTrxProb = InTrxCnt / fValidTrxCnt
	            '				sLine = objPattern.CSV_Data(InTrxCnt, fInTrxProb)
	            '				PrintLine(1, sLine)
	            '			Next objPattern
	            FileClose(1)
	        Catch ex As Exception
	        	MessageService.ShowError(ex.Message, "The file is in use. ")
	        	'isSuccess = False
	        	Exit Sub
			End Try
			
			Else
				MessageService.ShowWarning("No Patterns to Export","Warning in cmdMakeCSVFiles()")
	        End If
		'UPGRADE_NOTE: Object objPattern may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		objPattern = Nothing
	End Sub
	
	Public Sub AddPerfMeasuresData(patternsFound As Integer, p As CPatterns)
		If p Is Nothing Then
			Throw New ArgumentNullException("AddPerfMeasuresData")
		End If
		Dim objPattern As CPattern		
		If (patternsFound > 0) Then
			Me.m_perfmeasures = New PerfMeasures()		
			For	Each objPattern In p
				Me.m_perfmeasures.Add(Me.GetPerfMeasureData(objPattern))
			Next	
		End If		
	End Sub
	
	Dim m_perfmeasures As New PerfMeasures()
	Public Property Perfmeasures() As PerfMeasures
		Get
			Return m_perfmeasures
		End Get
		Set
			m_perfmeasures = value
		End Set
	End Property
	
	Public Function GetPerfMeasureData(byval cpat as CPattern) as PerfMeasure
		Dim perfm As New PerfMeasure()
		perfm.Measure = cpat.PatternName
		perfm.DAvgHiLim = cpat.DAvgHiLim
		perfm.DAvgLoLim = cpat.DAvgLoLim
		perfm.NMaxHiLim = cpat.NMaxHiLim
		perfm.NMaxLoLim = cpat.NMaxLoLim
		perfm.NMinHiLim = cpat.NMinHiLim
		perfm.NMinLoLim = cpat.NMinLoLim
		return perfm
	End Function
	
	' m_PatternResultsFile
	
'	Public Property sPatternResultsFile() As String
'		Get
'			sPatternResultsFile = m_PatternResultsFile
'		End Get
'		Set(ByVal Value As String)
'			m_PatternResultsFile = Value
'		End Set
'	End Property
	
    Public ReadOnly Property TotalPatterns() As Integer
        Get
            TotalPatterns = m_Patterns.Count + m_UnknownPatterns.Count
        End Get
    End Property

    Public ReadOnly Property Patterns() As CPatterns
        Get
            Patterns = m_Patterns
        End Get
    End Property


	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		m_AnchorStateCount = 0
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		'destroys collection when this class is terminated
		Dim n As Integer
		If (m_Patterns.Exists()) Then
			For n = 1 To m_Patterns.Count
				m_Patterns.Remove((1))
			Next
			'UPGRADE_NOTE: Object m_Patterns may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			m_Patterns = Nothing
		End If
		
		If (m_UnknownPatterns.Exists()) Then
			For n = 1 To m_UnknownPatterns.Count
				m_UnknownPatterns.Remove((1))
			Next
			'UPGRADE_NOTE: Object m_UnknownPatterns may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			m_UnknownPatterns = Nothing
		End If
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
End Class
'End Namespace