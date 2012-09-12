Option Strict Off
Option Explicit On

Imports System.Text.RegularExpressions
'Namespace PerfCheck
	Public Class SignifEvent
	
	'local variable(s) to hold property value(s)
	Private mvarLineNo As Integer 'local copy
    Private mvarTimeMs As UInt64 'local copy
	Private mvarTimeOfDay As String 'local copy
	Private mvarFullLine As String 'local copy
	'local variable(s) to hold property value(s)
	Private mvarEventName As String 'local copy
	'local variable(s) to hold property value(s)
	Private mvarSourceType As String 'local copy
	Private mvarNameIndex As Integer
    Private mvarobjNextState As SignifEvent
    Private mvarCollectionIndex As Integer
    Private m_rawEvent As String
    
	Public Property RawEvent() As String
		Get
			Return m_rawEvent
		End Get
		Set
			m_rawEvent = value
		End Set
	End Property
	
	
	Public Property objNextState() As SignifEvent
		Get
			objNextState = mvarobjNextState
		End Get
		Set(ByVal Value As SignifEvent)
			mvarobjNextState = Value
		End Set
	End Property
	
    Public Property CollectionIndex() As Integer
        Get
            CollectionIndex = mvarCollectionIndex
        End Get
        Set(ByVal Value As Integer)
            mvarCollectionIndex = Value
        End Set
    End Property

    Public Property NameIndex() As Integer
        Get
            NameIndex = mvarNameIndex
        End Get
        Set(ByVal Value As Integer)
            mvarNameIndex = Value
        End Set
    End Property

	
	
	
	Public Property SourceType() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.SourceType
			SourceType = mvarSourceType
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.SourceType = 5
			mvarSourceType = Value
		End Set
	End Property
	
	
	
	
	
	Public Property EventName() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.EventName
			EventName = mvarEventName
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.EventName = 5
			mvarEventName = Value
		End Set
	End Property
	
	
	
	
	
	Public Property FullLine() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.FullLine
			FullLine = mvarFullLine
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.FullLine = 5
			mvarFullLine = Value
		End Set
	End Property
	
	
	
	
	
	'UPGRADE_NOTE: TimeOfDay was upgraded to TimeOfDay_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Property TimeOfDay_Renamed() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.TimeOfDay
			TimeOfDay_Renamed = mvarTimeOfDay
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.TimeOfDay = 5
			mvarTimeOfDay = Value
		End Set
	End Property
	
	
	
	
	
    Public Property TimeMs() As UInt64
        Get
            'used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.TimeMs
            TimeMs = mvarTimeMs
        End Get
        Set(ByVal Value As UInt64)
            'used when assigning a value to the property, on the left side of an assignment.
            'Syntax: X.TimeMs = 5
            mvarTimeMs = Value
        End Set
    End Property
	
	
	
	
	
	Public Property LineNo() As Integer
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.LineNo
			LineNo = mvarLineNo
		End Get
		Set(ByVal Value As Integer)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.LineNo = 5
			mvarLineNo = Value
		End Set
	End Property
	
	Public Function TimeStamp() As String
		TimeStamp = mvarTimeOfDay & " " & Str(mvarTimeMs)
	End Function
	
	
    Public Function FormatEvent(ByRef dgr As String(), eventValues As Dictionary(Of String, String), Optional convertToKgs As Boolean = False) As Object
        Dim sSource, sDescription As String
        'Dim i, j As Integer
        Dim dScale As Double
        Dim isIncludeName As Boolean = False
        
        sDescription = EventName

        If convertToKgs Then
            dScale = g_KgsToLbs
        Else
            dScale = 1.0#
        End If
        
        Select Case EventName
        		
			Case "ItemDetails"
				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>.*)",isIncludeName)
				
			Case "Description"
				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>.*)",isIncludeName)
				
'			Case "Weight_Entered"
'				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>.*)",isIncludeName)
				
			Case "ProduceScale"
				 sDescription += Str(dScale * Val(ProcessPattern(eventValues,EventName,"(?<value>.*)",isIncludeName)))
				
			Case "Matched_Weight"
				 sDescription += Str(dScale * Val(ProcessPattern(eventValues,EventName,"(?<value>[ ]+\d+)",isIncludeName)))
				
			Case "WLDB_Lookup"
				 sDescription += Str(dScale * Val(ProcessPattern(eventValues,EventName,"(?<value>.*)",isIncludeName)))
				
			Case "UnMatched_Weight"
				 sDescription += Str(dScale * Val(ProcessPattern(eventValues,EventName,"(?<value>[ ]+\d+)",isIncludeName)))
				
'			Case "SO_StableWeight"
'				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>.*)",isIncludeName)
				
'			Case "ScaleSent"
'				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>.*)",isIncludeName)
				 
			Case "StableWeight"
				 sDescription += Str(dScale * Val(ProcessPattern(eventValues,EventName,"(?<value>[ ]+\d+)",isIncludeName)))
				
'			Case "ScaleShift"
'				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>.*)",isIncludeName)
				
'			Case "SS_Event"
'				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>\w+)",isIncludeName)
'				
'			Case "Tab--StateChange"
'				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>\w+)",isIncludeName)
'				
'			Case "SetSoldItemInfo"
'				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>\w+)",isIncludeName)
'				
'			Case "TB_ItemSold"
'				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>\w+)",isIncludeName)
				
			Case "Expected_Wt"
				 sDescription += Str(dScale * Val(ProcessPattern(eventValues,EventName,"(?<value>.*)",isIncludeName)))
				
'			Case "PerfMon"	
'				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>\w+)",isIncludeName)
				
			Case "ScaleFilter@5"
				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>[ ]+\d+[, ]+\d+[, ]+\d+)",isIncludeName)
				
			Case "EndDrawContext"
				 isIncludeName = True
				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>\w+)",isIncludeName)
				
			Case "ButtonClick"
				 isIncludeName = True
				 sDescription += ProcessPattern(eventValues,EventName,"(?<value>\w+)",isIncludeName)
			Case Else
				
		End Select

		'MessageService.ShowInfo(sDescription)

        sSource = SourceType & "(" & Str(LineNo) & ")"
        FormatEvent = TimeOfDay_Renamed & "  " & TimeMs & "  " & sSource & "  " & sDescription

        dgr(1) = TimeOfDay_Renamed
        dgr(2) = TimeMs
        dgr(3) = SourceType
        dgr(4) = Str(LineNo)
        dgr(5) = sDescription
		
    End Function
    
    Public Function ProcessPattern(eVal As Dictionary(Of String, String),eventName As String, patternKey As String,isIncludePatternValue As Boolean) As String
    	Dim m As Match
    	Dim pattern As String = ""
    	Dim description As String =""
    	
    	If eVal.ContainsKey(eventName.Trim()) Then
				eVal.TryGetValue(eventName, pattern)				
				m = Regex.Match(FullLine, Regex.Escape(pattern) + patternKey, RegexOptions.IgnoreCase)
				If m.Success Then
					If isIncludePatternValue Then						
						description = pattern + "" + m.Groups("value").Value 
					Else
						description = m.Groups("value").Value
					End If
				End If
    	End If
    	Return description
    End Function
    
'    Public Function FormatEvent(ByRef dgr As String(), lst As List(Of String), Optional convertToKgs As Boolean = False) As Object
'        Dim sSource, sDescription As String
'        Dim i, j As Integer
'        Dim dScale As Double
'
'        sDescription = EventName
'
'        If convertToKgs Then
'            dScale = g_KgsToLbs
'        Else
'            dScale = 1.0#
'        End If
'
'        If (EventName = "ItemDetails") Then
'            i = InStr(1, FullLine, "szDescription:")
'            If (i > 0) Then
'                j = InStr(i, FullLine, ";")
'                sDescription = sDescription & " " & (Mid(FullLine, i + 14, j - i - 14))
'            End If
'        End If
'        If (EventName = "Description") Then
'            i = InStr(1, FullLine, "key=item-description.  value=")
'            If (i > 0) Then sDescription = sDescription & (Mid(FullLine, i + 29))
'        End If
'        If (EventName = "Weight_Entered") Then
'            i = InStr(1, FullLine, "io.lWeightEntered:")
'            If (i > 0) Then sDescription = sDescription & Str(dScale * Val(Mid(FullLine, i + 18)))
'        End If
'        If (EventName = "ProduceScale") Then
'            i = InStr(1, FullLine, "SMState::DMScale lDMScaleWeight")
'            If (i > 0) Then sDescription = sDescription & Str(dScale * Val(Mid(FullLine, i + 31)))
'        End If
'        If (EventName = "Matched_Weight") Then
'            i = InStr(1, FullLine, "wt:")
'            If (i > 0) Then sDescription = sDescription & Str(dScale * Val(Mid(FullLine, i + 3)))
'        End If
'        If (EventName = "WLDB_Lookup") Then
'            i = InStr(1, FullLine, "lexpectedWt:")
'            If (i > 0) Then sDescription = sDescription & Str(dScale * Val(Mid(FullLine, i + 12)))
'        End If
'
'        If (EventName = "UnMatched_Weight") Then
'            i = InStr(1, FullLine, "UnMatched: Weight increase of")
'            If (i > 0) Then sDescription = sDescription & Str(dScale * Val(Mid(FullLine, i + 29)))
'        End If
'
'        If (EventName = "SO_StableWeight") Then
'            i = InStr(1, FullLine, "Weight = ")
'            If (i > 0) Then sDescription = sDescription & Str(dScale * Val(Mid(FullLine, i + 9)))
'        End If
'
'        If (EventName = "ScaleSent") Then
'            i = InStr(1, FullLine, "Got wt: ")
'            If (i > 0) Then sDescription = sDescription & Str(dScale * Val(Mid(FullLine, i + 8)))
'        End If
'
'        If (EventName = "StableWeight") Then
'            i = InStr(1, FullLine, "returns ")
'            If (i > 0) Then sDescription = sDescription & Str(dScale * Val(Mid(FullLine, i + 8)))
'        End If
'        If (EventName = "ScaleShift") Then
'            i = InStr(1, FullLine, "Shift Factor is ")
'            If (i > 0) Then sDescription = sDescription & Str(dScale * Val(Mid(FullLine, i + 16)))
'        End If
'        If (EventName = "ScaleFilter@5") Then
'            i = InStr(1, FullLine, "mode")
'            If (i > 0) Then sDescription = sDescription & Mid(FullLine, i + 18)
'        End If
'        If (EventName = "SS_Event") Then
'            i = InStr(1, FullLine, "PostSS SS")
'            If (i > 0) Then sDescription = sDescription & Mid(FullLine, i + 10)
'        End If
'        If (EventName = "Tab--StateChange") Then
'            i = InStr(1, FullLine, "Transition")
'            If (i > 0) Then sDescription = sDescription & Mid(FullLine, i + 10)
'        End If
'        If (EventName = "SetSoldItemInfo") Then
'            i = InStr(1, FullLine, "#0: ")
'            If (i > 0) Then sDescription = sDescription & Str(dScale * Val(Mid(FullLine, i + 4)))
'        End If
'        If (EventName = "TB_ItemSold") Then
'            i = InStr(1, FullLine, "<")
'            If (i > 0) Then sDescription = sDescription & Mid(FullLine, i)
'        End If
'        If (EventName = "Expected_Wt") Then
'            i = InStr(1, FullLine, "lexpectedWt: ")
'            If (i > 0) Then sDescription = sDescription & Str(dScale * Val(Mid(FullLine, i + 13)))
'        End If
'        If (EventName = "PerfMon") Then
'            i = InStr(1, FullLine, "WSS=")
'            If (i > 0) Then sDescription = sDescription & Mid(FullLine, i)
'        End If
'        If (EventName = "EndDrawContext") Then
'            i = InStr(1, FullLine, "ContextName:")
'            If (i > 0) Then
'                j = InStr(i, FullLine, ",")
'                sDescription = sDescription & " " & (Mid(FullLine, i, j - i))
'            End If
'        End If
'        If (EventName = "ButtonClick") Then
'            i = InStr(1, FullLine, "ControlName:")
'            If (i > 0) Then
'                j = InStr(i, FullLine, ",")
'                sDescription = sDescription & " " & (Mid(FullLine, i, j - i))
'            End If
'        End If
'
'        sSource = SourceType & "(" & Str(LineNo) & ")"
'        FormatEvent = TimeOfDay_Renamed & "  " & TimeMs & "  " & sSource & "  " & sDescription
'
'        dgr(1) = TimeOfDay_Renamed
'        dgr(2) = TimeMs
'        dgr(3) = SourceType
'        dgr(4) = Str(LineNo)
'        dgr(5) = sDescription
'		logValues(EventName, FullLine, sDescription, lst)
'    End Function
'    
'    Sub logValues(eventname As String, line As String, desc As String, lst As List(Of String))
'    	If lst.Contains(eventname) Then
'    		Return
'    	End If
'    	lst.Add(eventname)
'    	LogHelper.Log(eventname + ": " + desc + Environment.NewLine + line, LogType.INFO)
'    End Sub
End Class	
'End Namespace	
