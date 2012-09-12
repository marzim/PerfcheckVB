Option Strict Off
Option Explicit On

'ta185044 - function not use
Public Class PatternNode
	Implements System.Collections.IEnumerable
	
	'local variable to hold collection
	Private mCol As Collection
	'local variable(s) to hold property value(s)
	Private mvarAliasName As String 'local copy
	Private mvarLevel As Integer 'local copy
	Private mvarParent As PatternNode 'local copy
	Private mIdxMostRecentChild As Integer
	'local variable(s) to hold property value(s)
	Private mvarSearchAnchor As Integer 'local copy
	Private mvarSearchLimit As Integer
	
	' Timing variables
	Private mvarTally As Integer
	Private mvarSumDeltaTime As Double
	Private mvarSumDeltaTimeSquared As Double
	Private mvarMaxDeltaTime As Integer
	Private mvarMinDeltaTime As Integer
	
	'ta185044 - function not use
	Public Sub StoreStats(ByRef TraceEvents As SignifEvents)
        Dim RootNodeIndex As Integer
        Dim lDeltaTime As UInt64

		RootNodeIndex = FindRootNodeIndex()
		lDeltaTime = TraceEvents.Item(mvarSearchAnchor).TimeMs - TraceEvents.Item(RootNodeIndex).TimeMs
		If (lDeltaTime > 0) And (mvarMinDeltaTime = 0) Then
			mvarMaxDeltaTime = lDeltaTime
			mvarMinDeltaTime = lDeltaTime
		End If
		'    Debug.Print "Stats for: " & mvarAliasName & " (" & Str(mvarSearchAnchor) & "," & Str(RootNodeIndex) & " delta:" & Str(lDeltaTime)
		
		mvarTally = mvarTally + 1
		If (lDeltaTime > mvarMaxDeltaTime) Then mvarMaxDeltaTime = lDeltaTime
		If (lDeltaTime < mvarMinDeltaTime) Then mvarMinDeltaTime = lDeltaTime
		mvarSumDeltaTime = mvarSumDeltaTime + lDeltaTime
		mvarSumDeltaTimeSquared = mvarSumDeltaTimeSquared + CDbl(lDeltaTime) ^ 2
		
		If (Not mvarParent Is Nothing) Then 'we found the root; return node index
			mvarParent.StoreStats(TraceEvents)
		End If
		
	End Sub
	
	'ta185044 - function not use
	Public Function ClearStats() As Object
		' report our findings.  For each end node; report path and stats
		Dim pNode As PatternNode
        ClearStats = Nothing

		mvarTally = 0
		mvarSumDeltaTime = 0
		mvarSumDeltaTimeSquared = 0
		mvarMaxDeltaTime = 0
		mvarMinDeltaTime = 0
		For	Each pNode In mCol
			pNode.ClearStats()
		Next pNode
	End Function
	
	'ta185044 - function not use
    Public Function Report(ByRef bDetails As Boolean, ByRef objListBox As System.Windows.Forms.ListBox) As Object
        ' report our findings.  For each end node; report path and stats
        Dim pNode As PatternNode
        Dim dAvg As Double
        Report = Nothing

        '        objListBox.Items.Clear()

        If ((bDetails = True) Or (Count = 0)) Then
        	If (mvarTally = 0) Then dAvg = 0 
            objListBox.Items.Add(getFullPath() & "  cnt:" & Str(mvarTally) & " min:" & Str(mvarMinDeltaTime) & " max:" & Str(mvarMaxDeltaTime) & " avg:" & Str(dAvg))
        End If

        For Each pNode In mCol
            pNode.Report(bDetails, objListBox)
        Next pNode
    End Function
    
    'ta185044 - function not use
	Public Function FindRootNodeIndex() As Integer
		If (mvarParent Is Nothing) Then 'we found the root; return node index
			FindRootNodeIndex = mvarSearchAnchor
		Else
			FindRootNodeIndex = mvarParent.FindRootNodeIndex()
		End If
	End Function
	
	'ta185044 - function not use
	Public Function GetSearchLimit() As Integer
		Dim nParentSearchLimit As Integer
		
		nParentSearchLimit = 0
		If (Not mvarParent Is Nothing) Then nParentSearchLimit = mvarParent.GetSearchLimit()
		'Exit Function
			If (nParentSearchLimit > 0) Then
				GetSearchLimit = IIf((mvarSearchLimit > 0), IIf((mvarSearchLimit < nParentSearchLimit), mvarSearchLimit, nParentSearchLimit), nParentSearchLimit)
			Else
				GetSearchLimit = mvarSearchLimit
			End If
			
	End Function
	
	
	'ta185044 - function not use
	Public Function Search(ByRef TraceEvents As SignifEvents, ByRef bRestart As Boolean, ByRef objListBox As System.Windows.Forms.ListBox) As Boolean
        Dim pNode As PatternNode
		Dim iBegNode, nSearchLimit As Integer
		
		Search = True 'not false
		If (mvarParent Is Nothing) Then
			iBegNode = IIf(bRestart, 0, mvarSearchAnchor)
		Else
			iBegNode = mvarParent.SearchAnchor
		End If
		'    iBegNode = IIf((mvarParent Is Nothing), 1, mvarParent.SearchAnchor)
		mvarSearchLimit = 0
		mvarSearchAnchor = TraceEvents.FindEvent(AliasName, iBegNode)
		If (mvarSearchAnchor > 0) Then
			' validate search as not exceeding any previous limit
			
			nSearchLimit = GetSearchLimit()
			If ((nSearchLimit > 0) And (mvarSearchAnchor > nSearchLimit)) Then
				'            Debug.Print "Clearing SearchAnchor " & mvarAliasName & ":" & Str(mvarSearchAnchor)
				mvarSearchAnchor = 0
			End If
			
			If (mvarSearchAnchor > 0) Then
				' establish our own search limit
				mvarSearchLimit = TraceEvents.FindEvent(AliasName, mvarSearchAnchor)
				If (Count > 0) Then ' search for child nodes
					
					For	Each pNode In mCol
						Search = Search Or pNode.Search(TraceEvents, False, objListBox)
					Next pNode
				Else ' we been found and were an endnode
					'                Search = True
					'                Debug.Print "Found: " & getErrorString()
					StoreStats(TraceEvents)
				End If
			'Else
				'            Debug.Print "Cant find: " & getErrorString()
			End If
		Else
			If (mvarParent Is Nothing) Then Search = False
		End If
		
	End Function
	
    Public Function getFullPath() As String
        getFullPath = ""
        If (Not mvarParent Is Nothing) Then getFullPath = mvarParent.getFullPath()
        getFullPath = getFullPath & mvarAliasName & "->"
    End Function
    Public Function getErrorString() As String
        getErrorString = ""
        If (Not mvarParent Is Nothing) Then getErrorString = mvarParent.getErrorString()
        getErrorString = getErrorString & mvarAliasName & "(" & Str(mvarSearchAnchor) & "," & Str(mvarSearchLimit) & ") "
    End Function
	
	
	Public Property SearchAnchor() As Integer
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.SearchAnchor
			SearchAnchor = mvarSearchAnchor
		End Get
		Set(ByVal Value As Integer)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.SearchAnchor = 5
			mvarSearchAnchor = Value
		End Set
	End Property
	
	Public Property Parent() As Object
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.Parent
			Parent = mvarParent
		End Get
		Set(ByVal Value As Object)
			'used when assigning an Object to the property, on the left side of a Set statement.
			'Syntax: Set x.Parent = Form1
			mvarParent = Value
		End Set
	End Property
	
	Public Property Level() As Integer
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.Level
			Level = mvarLevel
		End Get
		Set(ByVal Value As Integer)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.Level = 5
			mvarLevel = Value
		End Set
	End Property
	
	Public Property AliasName() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.AliasName
			AliasName = mvarAliasName
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.AliasName = 5
			mvarAliasName = Value
		End Set
	End Property
	
	Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As PatternNode
		Get
			'used when referencing an element in the collection
			'vntIndexKey contains either the Index or Key to the collection,
			'this is why it is declared as a Variant
			'Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
			Item = mCol.Item(vntIndexKey)
		End Get
	End Property
	
	
	
	Public ReadOnly Property Count() As Integer
		Get
			'used when retrieving the number of elements in the
			'collection. Syntax: Debug.Print x.Count
			Count = mCol.Count()
		End Get
	End Property
	
	
	'UPGRADE_NOTE: NewEnum property was commented out. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B3FC1610-34F3-43F5-86B7-16C984F0E88E"'
	'Public ReadOnly Property NewEnum() As stdole.IUnknown
		'Get
			'this property allows you to enumerate
			'this collection with the For...Each syntax
			'NewEnum = mCol._NewEnum
		'End Get
	'End Property
	
	Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
		'UPGRADE_TODO: Uncomment and change the following line to return the collection enumerator. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="95F9AAD0-1319-4921-95F0-B9D3C4FF7F1C"'
        GetEnumerator = mCol.GetEnumerator
	End Function
	
	
	Public Function Add(ByRef NodeName As String, ByRef Level As Integer, ByRef Parent As Object, ByRef NodeString As String) As PatternNode
		'create a new object
		Dim objNewMember As PatternNode
        Dim Residue As String = ""

        Add = Nothing
		Trim(NodeName)
		If (Len(NodeName) > 0) Then
			mvarLevel = Level
			AliasName = NodeName
			If (Not Parent Is Nothing) Then
				mvarParent = Parent
			End If
		End If
		
		If (Len(NodeString) > 0) Then
			' isolate this name
			NextNodeName(NodeString, NodeName, Residue)
			If (Len(NodeName) > 0) Then
				
				' we have to add a new node
				objNewMember = New PatternNode
				mCol.Add(objNewMember)
				mIdxMostRecentChild = mCol.Count()
			Else
				objNewMember = mCol.Item(mIdxMostRecentChild)
			End If
			
			'return the object created
			objNewMember.Add(NodeName, Level + 1, Me, Residue)
			'         Set Add = objNewMember
			'UPGRADE_NOTE: Object objNewMember may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			objNewMember = Nothing
		End If
		
	End Function
	
	Public Sub NextNodeName(ByRef NodeString As String, ByRef NodeName As String, ByRef Residue As String)
		Dim i As Integer
		If (Len(NodeString) > 0) Then
			i = InStr(NodeString, ",")
			If (i <= 0) Then i = Len(NodeString) + 1
			NodeName = Trim(Left(NodeString, i - 1))
			Residue = Mid(NodeString, i + 1)
		End If
	End Sub
	
	'Function never called by others 
	Public Function Add2(ByRef NodeString As String, ByRef Level As Integer, ByRef Parent As Object) As PatternNode
		'create a new object
        Dim objNewMember As PatternNode = Nothing
		Dim i As Integer
		Dim TempName As String
		'UPGRADE_NOTE: Object Add2 may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Add2 = Nothing
		If (Len(NodeString) > 0) Then
			' isolate this name
			i = InStr(NodeString, ",")
			If (i <= 0) Then i = Len(NodeString) + 1
			TempName = Trim(Left(NodeString, i - 1))
			If (Len(TempName) > 0) Then
				
				mvarLevel = Level
				AliasName = TempName
				If (Not Parent Is Nothing) Then
					mvarParent = Parent
				End If
				
				'set the properties passed into the method
				If (Len(Mid(NodeString, i + 1)) > 0) Then
					objNewMember = New PatternNode
					mCol.Add(objNewMember)
					mIdxMostRecentChild = mCol.Count()
				End If
			Else
				objNewMember = mCol.Item(mIdxMostRecentChild)
				' retrieve AliasName from another Node; somewhere
				' AliasName = mCol.Item(mIdxMostRecentChild).AliasName
			End If
			
			'return the object created
			If (Not objNewMember Is Nothing) Then
				objNewMember.Add2(Mid(NodeString, i + 1), Level + 1, Me)
				Add2 = objNewMember
				'UPGRADE_NOTE: Object objNewMember may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				objNewMember = Nothing
			End If
		End If
		
	End Function
	
	
	Public Sub Remove(ByRef vntIndexKey As Object)
		'used when removing an element from the collection
		'vntIndexKey contains either the Index or Key, which is why
		'it is declared as a Variant
		'Syntax: x.Remove(xyz)
		mCol.Remove(vntIndexKey)
	End Sub
	
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		'creates the collection when this class is created
		mCol = New Collection
		'UPGRADE_NOTE: Object mvarParent may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mvarParent = Nothing
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		'destroys collection when this class is terminated
		'UPGRADE_NOTE: Object mCol may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mCol = Nothing
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
End Class