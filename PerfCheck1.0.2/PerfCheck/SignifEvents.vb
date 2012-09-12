Option Strict Off
Option Explicit On
Imports System.IO

'Namespace PerfCheck
	Public Class SignifEvents
		Implements System.Collections.IEnumerable
		
		Const nSTATUS_UPDATE_INTERVAL As Integer = 10
		Public Enum eSourceFileFormat
			eTraceUnknown = 0
			eTraceLog = 1
			eSuTraceLog = 2
			eDataCapture = 3
	        ePaTraceLog = 4
	        eNoSpaceTraceLog = 5
		End Enum
			
		Private m_mCol As Collection
		
'		Public ReadOnly Property EventCollection() As Collection
'			Get
'				Return m_mCol
'			End Get
'		End Property
		Private m_mPhrases As Phrases
		
		Public ReadOnly Property MPhrases() As Phrases
			Get
				Return m_mPhrases
			End Get
		End Property
		
		Private	m_mvarDictionaryFileName As String 'local copy		
		Private mvarSourceFileName As String 'local copy
		Private mvarSourceFileFormat As eSourceFileFormat 'local copy
		Private mvarParentForm As System.Windows.Forms.Form
		Private mvarnFileSize As Integer
		Private mvarnModLines As Integer
		Private mvarLineCount As Integer
		Private mvar_buf As String
		Private mvar_nEnd As Integer
		Private mvar_nStart As Integer
		Private mvar_TraceFileBytes As Integer
		Private mvar_InvalidTimestamp As Boolean
		Private m_dictionaryTR As IExtendedTextReader
		Private m_EventsTR As IExtendedTextReader
		Private m_dicEventValues As Dictionary(Of String, String)
		
		Public Property DicEventValues() As Dictionary(Of String, String)
			Get
				Return m_dicEventValues
			End Get
			Set
				m_dicEventValues = value
			End Set
		End Property
		
		Public Property SourceFileName() As String
			Get
				SourceFileName = mvarSourceFileName
			End Get
			Set(ByVal Value As String)
				mvarSourceFileName = Value
			End Set
		End Property
		
		
		Public Property DictionaryFileName() As String
			Get
				DictionaryFileName = m_mvarDictionaryFileName
			End Get
			Set(ByVal Value As String)
				m_mvarDictionaryFileName = Value
			End Set
		End Property
		
		Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As SignifEvent
			Get
				Item = m_mCol.Item(vntIndexKey)
			End Get
		End Property
		
		Public ReadOnly Property Count() As Integer
			Get
				Count = m_mCol.Count()
			End Get
		End Property
		
		Public ReadOnly Property MergeCollection As Collection
			Get
				Return m_mCol
			End Get			
		End Property			
		
		Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
	        GetEnumerator = m_mCol.GetEnumerator
		End Function	    
	    
	    Public Function ListAllEvents(Optional convertToKgs As Boolean=False) as LogEvents
	        Dim objEvent, objLastEvent As SignifEvent
	
	        Dim lStartTime As ULong
	        'Dim fTime As Double
	        Dim sFormattedEvent As String
	        Dim i As Integer
	        'Const bTrace As Boolean = False
			'how could bTrace to be true?
	        Dim di2 As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\logs")
	        If Not di2.Exists Then
	        	di2.Create()
	        End If
	        'If (bTrace) Then FileOpen(2, di2.FullName + "\LogEvents.txt1", OpenMode.Output)
	
	        lStartTime = m_mCol.Item(1).TimeMs
	        ' add a root node for start of transition
	        objLastEvent = m_mCol.Item(m_mCol.Count()) 'init to the last for no good reason.	        
	        Dim logevents As New LogEvents()
	        
	        
	        For Each objEvent In m_mCol
	        	Dim logevent As New LogEvent()
	        	
	            'test this obj against any selected time reset states
	            For i = 0 To g_nTimeResetEvents - 1
	                If (objEvent.NameIndex = g_nTimeResetIndexes(i)) Then	            
	                    logevent = new LogEvent()
	            		logevent.Data = "empty row"
	            		logevents.Add(logevent)
	                    'If (bTrace) Then PrintLine(2, "")
	                    lStartTime = objEvent.TimeMs	                    
	                End If
	            Next
	            If (objEvent.EventName <> objLastEvent.EventName Or g_bSupressDuplicates = False) Then

	                Dim dgr(8) As String
					
	                sFormattedEvent = objEvent.FormatEvent(dgr, m_dicEventValues, convertToKgs)
	                If (objEvent.TimeMs < lStartTime) Then ' time may wrap eventually; don't go neg.
	                    lStartTime = objEvent.TimeMs
	                End If
	                dgr(0) = (objEvent.TimeMs - lStartTime) / 1000.0#	        
	                dgr(7) = objEvent.CollectionIndex	                
	                dgr(8) = objEvent.RawEvent
	                
	                logevent = new LogEvent()
	                logevent.RelTime = dgr(0)
	                logevent.Datetime = dgr(1)
	                logevent.Millisec = dgr(2)
	                logevent.Source = dgr(3)
	                logevent.Lineno = dgr(4)
	                logevent.Events = dgr(5)
	                logevent.ColIndex = dgr(7)
	                logevent.RawEvent = dgr(8)
	                logevents.Add(logevent)
	                'If (bTrace) Then PrintLine(2, Str(fTime) & "  " & sFormattedEvent)
	            End If
	            objLastEvent = objEvent 'remember last object
	        Next objEvent
'	        If (bTrace) Then FileClose(2)
			return logevents
	    End Function
		
		
	    
	    Public Function Merge(ByRef e1 As SignifEvents, ByRef e2 As SignifEvents) As Object
	        Dim lEvtTime As Integer
	        Dim objEvent As New SignifEvent()
	        Dim stopwatch As New Stopwatch()
	        Dim dateString As String
	        dateString = DateTime.Now.ToString("d")
	        stopwatch.Start()
	        Merge = Nothing
	        lEvtTime = 0
	        Do While (e1.Count > 0 Or e2.Count > 0)
	            If (e1.Count > 0 And e2.Count > 0) Then
	                ' case 1 e1.count > 0 and e2.count >0
	                '            If (e1.Item(1).TimeMs < e2.Item(1).TimeMs) Then
	                If (e1.Item(1).TimeStamp() < e2.Item(1).TimeStamp()) Then
	                    'remove e1.item(1) and add it to merged list
	                    objEvent = e1.Item(1)
	                    e1.Remove(1)
	                Else
	                    'remove e2.item(1) and add it to merged list
	                    objEvent = e2.Item(1)
	                    e2.Remove(1)
	                End If
	
	            Else
	                If (e1.Count > 0 And e2.Count = 0) Then
	                    'case 2; e1.count > 0, e2.count = 0
	                    ' remove e1.item(1) and add it to merged list
	                    objEvent = e1.Item(1)
	                    e1.Remove(1)
	                Else
	                    'case 3; e1.count = 0, e2.count > 0
	                    ' remove e2.item(1) and add it to merged list
	                    objEvent = e2.Item(1)
	                    e2.Remove(1)
	                End If
	            End If
	            
	            m_mCol.Add(objEvent)
	        Loop
	        'UPGRADE_NOTE: Object objEvent may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
	        'objEvent = Nothing
	        Debug.Print("Merging produced " & m_mCol.Count() & " Events")
	        'LogHelper.Log(dateString + " " + stopwatch.Elapsed.ToString() + " Merging produced " & mCol.Count() & " Events", LogType.INFO, True)	        
	        LogHelper.Log(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff") + " Merging produced " & m_mCol.Count() & " Events", LogType.INFO, True)	        	        
	        stopwatch.Stop()
	    End Function		
	    
	    Public Sub ParseEvents(tr As IExtendedTextReader, Optional ByVal bJapan As Boolean=False, Optional ByRef bFormatOverride As String="")
	    	If tr Is Nothing Then
	    		Throw New ArgumentNullException("ParseEvents")
	    	End If
	    	m_EventsTR = tr
	    	ParseEvents(bJapan, bFormatOverride)
	    	m_EventsTR.Close()
	    End Sub
		
		Private Sub ParseEvents(Optional ByVal bJapan As Boolean=False, Optional ByRef bFormatOverride As String="")
			Dim firstLine As Boolean = True			
			Dim firstlineVal As String = String.Empty
			
			Dim line As String = String.Empty
			Dim i As Integer
			Dim sPreface = String.Empty
			Dim nPreface As Short
			Dim nLineCount = 0
			Dim bUnicode As Boolean
			mvarLineCount = 0			
	        m_mCol.Clear()			        
			 ' setup progress bar			 
			 'FormDiagOpen.ProgressBar1.Minimum = 0
			 
			 [RaiseEvent](Me, New ProgressEventArgs(0, m_EventsTR.Length,0))
	        mvar_TraceFileBytes = 0
	        'FormDiagOpen.ProgressBar1.Maximum = m_EventsTR.Length 
	        
	        bUnicode = False
			If (bJapan And InStr(1, mvarSourceFileName, "Traces")) Then
				bUnicode = True
			End If
			If (Len(bFormatOverride) > 0) Then
				If (bFormatOverride = "A") Then bUnicode = False
				If (bFormatOverride = "U") Then bUnicode = True
			End If			
			
			' determine eDataCapture, eTraceLog, or eSUTrace format file
			While (InlineAssignHelper(line, m_EventsTR.ReadLine())) IsNot Nothing
				If firstLine Then	
					line = line.Trim()				
					firstlineVal = line					
		            mvar_TraceFileBytes += line.Length
		            mvarLineCount += 1		            
		            If (mvarSourceFileFormat = eSourceFileFormat.eTraceUnknown) Then
						mvarSourceFileFormat = eSourceFileFormat.eDataCapture ' guess at trace file format
			            i = InStr(1, line, ")")
			            If (i > 0 And i < 10) Then
			                mvarSourceFileFormat = eSourceFileFormat.eTraceLog
			            Else
			                i = InStr(1, line, "*** Trace Log ***")
			                If (i > 0 And i < 10) Then
			                    mvarSourceFileFormat = eSourceFileFormat.eSuTraceLog
			                Else
			                    'PA logs are initialized with a line starting with the strign ***m_traceMask;
			                    'then after they fill and roll over the first line is "Maximum file size reached."
			                    i = InStr(1, line, "Maximum file size reached.")
			                    If (i = 0) Then i = InStr(1, line, "***m_traceMask")
			                    If (i > 0 And i < 10) Then
			                        mvarSourceFileFormat = eSourceFileFormat.ePaTraceLog
			                    Else
			                        mvarSourceFileFormat = eSourceFileFormat.eNoSpaceTraceLog     ' this handles PSXU
			                    End If
			
			                End If
			            End If		            
		            End If		            
				Else
					mvar_TraceFileBytes += line.Length
		            mvarLineCount += 1		            
		            'FormDiagOpen.ProgressBar1.Value = mvar_TraceFileBytes + 1				
		            [RaiseEvent](Me, New ProgressEventArgs(0, m_EventsTR.Length, mvar_TraceFileBytes + 1))
					
					If (sPreface = "" Or sPreface = "Scan SO") Then
		                'i = InStr(s2, " ")
		                i = FindFirstDelim(line)
		                If (i > 0) Then
		                    sPreface = Left(line, i - 1)
		                    nPreface = sPreface.Length
		                End If
		            End If
		            
		            If (line.Length > 0) Then
		            	If ((mvarSourceFileFormat = eSourceFileFormat.ePaTraceLog) And _ 
		            		((Left(line, 1) < "0") Or (Left(line, 1) > "9"))) Or _
		            		((mvarSourceFileFormat = eSourceFileFormat.eDataCapture) And _ 
		            		((Left(line, 1) = " ") Or (Left(line, 1) = Chr(9)) Or _ 
		            		(Mid(line, 1, nPreface) <> sPreface))) Or _
			                (((mvarSourceFileFormat = eSourceFileFormat.eTraceLog) Or _
			                (mvarSourceFileFormat = eSourceFileFormat.eSuTraceLog)) And _ 
			                IsContinue(line)) Then
		                    firstlineVal = firstLineVal & line
		                Else
		                	If Not Me.mvar_InvalidTimestamp Then
		                		ParseSourceFileLine(firstlineVal)
		                	End If		                    
		                	firstlineVal = line
		                End If
		            End If
				End If			
				firstLine = False			
			End While			
			'FormDiagOpen.ProgressBar1.Value = 0     'reset status bar	
			[RaiseEvent](Me, New ProgressEventArgs(0,m_EventsTR.Length,0, "Done Parsing. Events found: " + Count.ToString()))
			Debug.Print(Str(Count) & " Significant events detected from " & mvarSourceFileName)
			'FormDiagOpen.lststatus.Items.Add("Done Parsing. Events found: " + Count.ToString())			
			LogHelper.Log(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff") + " Done Parsing. Events found: " + Count.ToString(),LogType.INFO, True)			
		End Sub
		
		Public Sub ParseDictionary(ByVal tr As IExtendedTextReader)
			If tr Is Nothing Then
				Throw New ArgumentNullException("ParseDictionary")
			End If			
			m_dictionaryTR = tr
			ParseDictionary()
		End Sub
		
		Public Sub ParseDictionary()
			Dim AliasName, Phrase_Renamed As String
			Dim iComma As Short			
			m_mPhrases = New Phrases				
			Dim line2 As String = String.Empty								
			While (InlineAssignHelper(line2, m_dictionaryTR.ReadLine())) IsNot Nothing
				If (Len(line2) > 0) And (Left(line2, 1) <> ";") Then
					iComma = InStr(1, line2, ",")
					If (iComma > 0) Then
						AliasName = Mid(line2, 1, iComma - 1)
						Phrase_Renamed = Trim(Mid(line2, iComma + 1))							
						m_mPhrases.Add(Phrase_Renamed, AliasName) 'Add some keys and items
					End If
				End If
			End While		
			
			Debug.Print(Str(m_mPhrases.Count) & " Keys read from Dictionary" & m_mvarDictionaryFileName)
		End Sub
		
		Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
			target = value
			Return value
		End Function
	
'	    Private Function GetNextLine(ByRef nFileUnit As StreamReader, ByVal bUnicode As Boolean, ByRef sRet As String) As Boolean
'	        GetNextLine = True
'	        sRet = nFileUnit.ReadLine()
'	        If (sRet Is Nothing) Then
'	            GetNextLine = False
'	            sRet = ""
'	        Else
'	            sRet = Trim(sRet)
'	            mvar_TraceFileBytes = mvar_TraceFileBytes + sRet.Length
'	            mvarLineCount = mvarLineCount + 1
'	        End If
'	        'tom.               mvarParentForm.UpdateProgressgBar(mvarnFileSize - mvar_TraceFileBytes)
'	
'	    End Function	   
	    
		Private Function IsContinue(ByRef s2 As String) As Boolean
			Try
				Dim c = "0", s As String
				Dim n, l As Long
				Dim bSearching As Boolean
				s = LTrim(s2)
				l = Len(s)
				n = 1
				bSearching = True
				IsContinue = True
				While n <= l And bSearching
					c = Mid(s, n, 1)
					If (c < "0") Or (c > "9") Then
						bSearching = False
					End If
					n = n + 1
				End While
				
				If (c = ")") Then
					IsContinue = False
				Else
					IsContinue = True
				End If
			Catch ex As Exception
				throw new Exception(ex.Message)
				'MsgBox("Error in parsing this line: " + s2 + Environment.NewLine + ex.ToString())
			End Try
	        
		End Function
		
		
		Private Function ParseSourceFileLine(ByRef valueToProcess As String) As Object
	        Dim LineNo As Double
	        Dim TimeMS As UInt64
	        Dim TimeOfDay_Renamed, SourceType As String
	        Dim AliasName As String = ""
			Dim m, n As Integer
			Dim nNameIndex As Long
			Dim objPhrase As Phrase
			Const delim As String = " "
			
			Dim s9 As String
			Dim l As Long
	        Dim s1 As String
	        ParseSourceFileLine = Nothing	 
	        If valueToProcess.Length <= 2 Then
	        	Return Nothing
	        End If
			Try
				Select Case (mvarSourceFileFormat)
				Case eSourceFileFormat.eTraceLog					
					parseTracesLog()	               					
				Case eSourceFileFormat.eSuTraceLog
					parseSUTraceLog()					
				Case eSourceFileFormat.eDataCapture
					parseDataCapture()					
				Case eSourceFileFormat.ePaTraceLog
					parsePATraceLog()
	            Case eSourceFileFormat.eNoSpaceTraceLog
	                parsePSXScotAppULog()
				End Select				
			Catch ex As Exception
				MessageService.ShowError(ex.Message,"Error in " + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name + " (" + mvarSourceFileFormat.ToString() + ")")			
			End Try	
		End Function
		
		Public Function parseTracesLog(value As String)
			'  18) 08/21 13:05:18;0422090884 PS-PSi@162  Tue May 14 14:18:24 2002
					'isolate lineNo, tod, TimeMs, and remainder of line
			Try		
				 n = InStr(1, s, ")")
				 'If (n > 0) Then
				 If value.Contains(")") Then
                    'On Error GoTo BadLine
                    LineNo = Val(Left(s, n - 1))
                    m = InStr(n + 1, s, ";")
                    TimeOfDay_Renamed = Mid(s, n + 2, m - n - 2)
                    n = InStr(m + 1, s, delim)

                    ' created this hack to allow quick processing of 10 digit time codes.
                    s9 = Mid(s, m + 1, n - m - 1)
                        '                        If (Len(s9) > 9) Then s9 = Mid(s9, 2)
                    If Val(s9) < 0 Then
                    	MessageService.ShowWarning("Invalid timestamp: " + Val(s9).ToString())
                    	me.mvar_InvalidTimestamp = true
                    	Return Nothing
                    Else
                    	me.mvar_InvalidTimestamp = false
                    End If
                    TimeMS = Val(s9)
                    
                    m = InStr(n + 1, s, delim)
                    While (m)
                    	If (m_mPhrases.Exists(Mid(s, n + 1), AliasName, nNameIndex)) Then	                    		
                        	Add(LineNo, TimeOfDay_Renamed, TimeMs, s, AliasName, nNameIndex, "App", GetPhrase(AliasName))	                        	
                        End If
                        n = m
                        m = InStr(n + 1, s, delim)
                    End While
                    If (m_mPhrases.Exists(Mid(s, n + 1), AliasName, nNameIndex)) Then	                    	
                    	Add(LineNo, TimeOfDay_Renamed, TimeMs, s, AliasName, nNameIndex, "App", GetPhrase(AliasName))	                    	
                    End If	                    
                End If
			Catch ex As Exception
				MessageService.ShowInfo(s)
			End Try
		End Function
		
		Public Function parseSUTraceLog()
			'600023) 10/11 20:17:14:832     IBMTransactionBroker.cpp(981)::Releasing TB message msgaddr=0x009f7140, count=21414, PRINTERRECEIPT <|N|cA                                      >
			'600024) 10/11 20:17:14:832 -->AcmeTransactionBroker.cpp(2073)::FeatureAllowed(7)
			'600025) 10/11 20:17:14:832 ..API> TBAPI.cpp(1029)::TBProcessMessage(pMessage 10445040)
			'600031) 10/11 20:17:14:842 <--IBMTransactionBroker.cpp(2592)::ProcessPrintMessage()
			'isolate lineNo, tod, TimeMs, and remainder of line
            n = InStr(1, s, ")")
            If (n > 0) Then
                LineNo = Val(Left(s, n - 1))
                m = InStr(n + 1, s, ":") + 6
                TimeOfDay_Renamed = Mid(s, n + 2, m - n - 2)
                n = InStr(m + 1, s, delim)
                TimeMs = Val(Mid(s, m + 1, n - m - 1))
                m = InStr(n + 1, s, delim)
                ' fastsearch
                For Each objPhrase In m_mPhrases
                    If (InStr(n + 1, s, objPhrase.Phrase, CompareMethod.Text) > 0) Then
                        Add(LineNo, TimeOfDay_Renamed, TimeMs, s, (objPhrase.AliasName), objPhrase.NameIndex, "TB", GetPhrase(AliasName))
                        Exit For
                    End If
                Next objPhrase
            End If
		End Function
		
		Public Function parseDataCapture()
			'TAB: 08/21 13:05:39   422,111,273> StateMachine Belt1: GLOBAL state recognized
			'SS: 08/21 13:05:55   422,127,337> Got wt: 0 |rc: 111 |Ext: 202
			'DB: 08/21 13:06:58   422,190,958>   Update for UPC: 070222026553 was successful
			'ScaleSO11-00 08/21 13:05:56   422,128,058> Serial Read <crlf removed>
			'  0000:0A 30 30 30 33 35 32 35  0D B2 F0 33 03   |.0003525...3.|
			
            ' n = InStr(1, s, " ")   'does not handle psx and some opos logs w/ no space before date
            n = FindFirstDelim(s)
            If (n > 0) Then
                SourceType = Left(s, n - 1)
                LineNo = mvarLineCount
                m = InStr(n + 1, s, " ")
                m = InStr(m + 1, s, " ")
                Dim length = m - n - 1
                If length < 0 Then
                	return -1
                End If
                TimeOfDay_Renamed = Trim(Mid(s, n + 1, length))
                
                n = InStr(m + 1, s, ">")
                If (n > m) Then

                    s1 = Trim(Mid(s, m + 1, n - m - 1))
                    l = InStr(1, s1, " ")
                    If (l > 0) Then
                        If (l < n) Then s1 = Left(s1, l - 1)
                    End If
                    TimeMs = CDbl(s1)

                    '            TimeMs = CDbl(Mid(s, m + 1, n - m - 1))
                    m = InStr(n + 1, s, delim)
                    While (m)
                        If (m_mPhrases.Exists(Mid(s, n + 1), AliasName, nNameIndex)) Then
                            Add(LineNo, TimeOfDay_Renamed, TimeMs, s, AliasName, nNameIndex, SourceType, GetPhrase(AliasName))
                        End If
                        n = m
                        m = InStr(n + 1, s, delim)
                    End While
                    If (m_mPhrases.Exists(Mid(s, n + 1), AliasName, nNameIndex)) Then
                        Add(LineNo, TimeOfDay_Renamed, TimeMs, s, AliasName, nNameIndex, SourceType, GetPhrase(AliasName))
                    End If
                End If
            End If
		End Function
		
		Public Function parsePATraceLog()
			'Maximum file size reached. See file c:\scot\bin\tbtrace.log.bak for previous trace records.
			'07/23 13:59:43: 07/23 13:59:43.140[07a8] [+]CustomerCurrentTransaction@253:CCustomerCurrentTransaction::ResetRewardLineDetails()
			'07/23 13:59:43: 07/23 13:59:43.140[07a8] [-]CustomerCurrentTransaction@253:CCustomerCurrentTransaction::ResetRewardLineDetails()
			'07/23 13:59:43: 07/23 13:59:43.140[07a8] [I]Singleton@85:Singleton Allocated 16018128
			'isolate lineNo, tod, TimeMs, and remainder of line	

			 m = InStr(1, s, ":") + 1
            n = InStr(m, s, delim)
            If (n > 0) Then
                'LineNo = Val(Left(s, n - 1))
                'm = InStr(n + 1, s, ":") + 6
                'If (m > n + 2) Then
                TimeOfDay_Renamed = Trim(Mid(s, 1, n))
                m = InStr(n + 1, s, ">")
                If (m > n + 1) Then

                    TimeMs = Val(Mid(s, n + 1, m - n - 6))
                    m = InStr(m + 1, s, delim)
                    ' fastsearch
                    For Each objPhrase In m_mPhrases
                        If (InStr(n + 1, s, objPhrase.Phrase, CompareMethod.Text) > 0) Then
                            Add(LineNo, TimeOfDay_Renamed, TimeMs, s, (objPhrase.AliasName), objPhrase.NameIndex, "PA", GetPhrase(objPhrase.AliasName))
                            Exit For
                        End If
                    Next objPhrase
                End If
            End If
		End Function
	
	    Public Function FindFirstDelim(ByVal s As String) As Integer
	        'PSX_ScotAppU:06/27 07:14:11    93,273,239 0574> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:NumericP2, ContextName:EnterID, EventName:Click, Param:, Consumed:0, TimeFired:93273239)
	        'find 1st space before date.  If none, look for 1st colon before date.  Otherwise die.
	        Dim nDate, nColon, nSpace As Integer
	        nDate = InStr(1, s, "/") 'get the position of the first /
	        nColon = InStr(1, s, ":") 'get the position of the first :
	        'nSpace = IIf(nDate = 0, InStr(1, s, " "), InStrRev(Mid(s, 1, nDate), " "))
	        If nDate = 0 Then
	        	nSpace = InStr(1, s, " ") 'get the position of the first space
	        Else
	        	Dim val as String = Mid(s, 1, nDate) 'get the data upto position of /
	        	nSpace = InStrRev(val, " ") 'get the position of the first space beginning on the right side of the string
	        End If
	        If ((nSpace = 0) And (nColon > 0)) Then
	            nSpace = nColon
	        End If
	
	        FindFirstDelim = nDate
	        If (nSpace < nDate) Then
	            FindFirstDelim = nSpace
	        Else
	            If (nColon < nDate) Then
	                FindFirstDelim = nColon
	            Else
	                FindFirstDelim = 0
	            End If
	        End If
	    End Function
	    
	    Public Function parsePSXScotAppULog()
	    	'PSX_ScotAppU:02/28 18:01:32       120,983 043C> -- PSX Start Tracing -- File version: 1.0.24.395 (continued)
            n = FindFirstDelim(s)
            If (n > 0) Then
                SourceType = Left(s, n - 1)
                LineNo = mvarLineCount
                m = InStr(n + 1, s, " ")
                m = InStr(m + 1, s, " ")
                Dim length = m - n - 1
                If length < 0 Then
                	return -1
                End If
                TimeOfDay_Renamed = Trim(Mid(s, n + 1, length))
                n = InStr(m + 1, s, ">")
                If (n > m) Then

                    s1 = Trim(Mid(s, m + 1, n - m - 1))
                    l = InStr(1, s1, " ")
                    If (l > 0) Then
                        If (l < n) Then s1 = Left(s1, l - 1)
                    End If
                    TimeMs = CDbl(s1)

                    '            TimeMs = CDbl(Mid(s, m + 1, n - m - 1))
                    m = InStr(n + 1, s, delim)
                    While (m)
                        If (m_mPhrases.Exists(Mid(s, n + 1), AliasName, nNameIndex)) Then
                            Add(LineNo, TimeOfDay_Renamed, TimeMs, s, AliasName, nNameIndex, SourceType, GetPhrase(AliasName))
                        End If
                        n = m
                        m = InStr(n + 1, s, delim)
                    End While
                    If (m_mPhrases.Exists(Mid(s, n + 1), AliasName, nNameIndex)) Then
                        Add(LineNo, TimeOfDay_Renamed, TimeMs, s, AliasName, nNameIndex, SourceType, GetPhrase(AliasName))
                    End If
                End If
            End If
	
	   	End Function
	    
	    'below function was not used -mc184104
'	    Public Function TOD2Seconds(ByRef s1 As String) As Long
'			' 07/23 13:59:43
'			Dim n, m As Integer
'			Dim nSeconds, nHours, nMinutes, nDays As Double
'			TOD2Seconds = 0
'			n = InStr(1, s1, "/")
'			m = InStr(n + 1, s1, " ")
'			If (n > 0) Then
'				nDays = Val(Mid(s1, n + 1, m - n - 1))
'				
'				n = InStr(m + 1, s1, ":")
'				If (n > 0) Then
'					nHours = Val(Mid(s1, m + 1, n - m - 1))
'					m = InStr(n + 1, s1, ":")
'					If (m > 0) Then
'						nMinutes = Val(Mid(s1, n + 1, m - n - 1))
'						nSeconds = Val(Mid(s1, m + 1))
'					End If
'				End If
'			End If
'			TOD2Seconds = nSeconds + nMinutes * 60 + nHours * 3600 + nDays * 24 * 3600
'			
'		End Function
		
		'below function was not used -mc185104
		Public Function FindEvent(ByRef sEventType As String, ByRef nFrom As Integer) As Integer
			Dim nEvent As Integer
			FindEvent = 0
			
			If (nFrom < Count) Then
				For nEvent = nFrom + 1 To Count
	                If (m_mCol.Item(nEvent).EventName = sEventType) Then
	                    FindEvent = nEvent
	                    Exit For
	                End If
				Next
			End If
		End Function
		
		
	    Public Function Add(ByRef LineNo As Integer, ByRef TimeOfDay_Renamed As String, ByRef TimeMs As UInt64, ByRef FullLine As String, ByRef EventName As String, ByVal EventNameIndex As Integer, ByRef SourceType As String, rawEvent As String, Optional ByRef sKey As String = "") As SignifEvent
	        Try
	            'create a new object
	            Dim objNewMember As New SignifEvent()	
	
	            'set the properties passed into the method
	            objNewMember.LineNo = LineNo
	            objNewMember.TimeMs = TimeMs
	            objNewMember.TimeOfDay_Renamed = TimeOfDay_Renamed
	            objNewMember.FullLine = FullLine
	            objNewMember.EventName = EventName
	            objNewMember.SourceType = SourceType
	            objNewMember.NameIndex = EventNameIndex
	            objNewMember.RawEvent = rawEvent
	            
	            If Len(sKey) = 0 Then
	                m_mCol.Add(objNewMember)
	            Else
	                m_mCol.Add(objNewMember, sKey)
	            End If
	
	            'return the object created
	            Add = objNewMember
	            objNewMember = Nothing
	        Catch ex As OverflowException
	        '	MessageService.ShowError("Number supplied is too large to handle a certain datatype","Error in Add()")
	        	Throw New OverflowException("Number supplied is too large to handle a certain datatype")
	        	Add = Nothing	
	        'Catch ex1 As Exception
	        '	MessageService.ShowError(ex1.Message,"Error in " + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)
	        '	Add = Nothing	
	        End Try	
	    End Function
	    
	    Public Function GetPhrase(aliasName As String) As String
	    	For Each p As Phrase In m_mPhrases
	    		If p.AliasName.Equals(aliasName) Then
	    			Return p.Phrase
	    		End If
	    	Next
	    	Return String.Empty
	    End Function
		
		Public Sub Remove(ByRef vntIndexKey As Object)
			m_mCol.Remove(vntIndexKey)
		End Sub
		
		'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Private Sub Class_Initialize_Renamed()
			'creates the collection when this class is created
			m_mCol = New Collection
			mvarnModLines = nSTATUS_UPDATE_INTERVAL
			mvarSourceFileFormat = eSourceFileFormat.eTraceUnknown
	        '		mvar_TraceFileBytes = -1
		End Sub
		Public Sub New()
			MyBase.New()
			Class_Initialize_Renamed()
		End Sub
		
	    Private Sub Class_Terminate_Renamed()
	        'destroys collection when this class is terminated
	        m_mCol = Nothing
	        mvarParentForm = Nothing
	    End Sub
		Protected Overrides Sub Finalize()
			Class_Terminate_Renamed()
			MyBase.Finalize()
		End Sub
		
		Public Delegate Sub ProgressHandler(sender As Object, e As ProgressEventArgs)
		Public Event progress As ProgressHandler

		Protected Sub [RaiseEvent](sender As Object, e As ProgressEventArgs)
			RaiseEvent progress(sender, e)					
		End Sub		
	End Class	
	
	
'End Namespace	
	

