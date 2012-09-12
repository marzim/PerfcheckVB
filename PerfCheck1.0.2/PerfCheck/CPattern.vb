Option Strict Off
Option Explicit On
'Namespace PerfCheck
Public Class CPattern
	Implements System.Collections.IEnumerable
	
	'local variable to hold collection
	Private mCol As Collection
	Private m_sCategory As String
	Private m_sPatternName As String
	Private m_sKeyValPairs As String
    Private m_objStats As New CStatistics
    Private m_dAvgHiLim As Double
    Private m_dAvgLoLim As Double
    Private m_nMinHiLim As Integer
    Private m_nMinLoLim As Integer
    Private m_nMaxHiLim As Integer
    Private m_nMaxLoLim As Integer
    
	Public ReadOnly Property NMaxLoLim() As Integer
		Get
			Return m_nMaxLoLim
		End Get
	End Property
	Public ReadOnly Property NMaxHiLim() As Integer
		Get
			Return m_nMaxHiLim
		End Get
	End Property
    
	Public ReadOnly Property NMinLoLim() As Integer
		Get
			Return m_nMinLoLim
		End Get
	End Property
	Public ReadOnly Property NMinHiLim() As Integer
		Get
			Return m_nMinHiLim
		End Get
	End Property
    
	Public ReadOnly Property DAvgLoLim() As Double
		Get
			Return m_dAvgLoLim
		End Get
	End Property
    
	Public ReadOnly Property DAvgHiLim() As Double
		Get
			Return m_dAvgHiLim
		End Get
	End Property
	
    
    Private m_objPatternPointers As New CPatternPointers
    Private m_objPoisonStates As New CExclusions

    Const c As String = ","
	Const cs As String = ", "
	Private m_nIndex As Integer
	
	Public Sub AccumulateStats(ByRef LastDateTime As Date, ByRef NewDateTime As Date)
		Dim nPatternSeconds As Integer
		'x.1    nPatternSeconds = DateDiff("s", objLastAnchorState.objNextState.StateTime, objNewAnchorState.StateTime)
		'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
		'Try
			nPatternSeconds = DateDiff(Microsoft.VisualBasic.DateInterval.Second, LastDateTime, NewDateTime)
			m_objStats.Accumulate(nPatternSeconds)
			
		'Catch ex As InvalidCastException
			'Throw New InvalidCastException()
		'End Try
	End Sub
    Public Sub AccumulateStatsMs(ByRef LastDateTime As UInt64, ByRef NewDateTime As UInt64)
    	Dim dPatternSeconds As Double
    	'Try 
    		dPatternSeconds = CDbl(NewDateTime) - CDbl(LastDateTime)
    		 m_objStats.Accumulate(dPatternSeconds)
    		
    	'Catch ex As InvalidCastException
    		'Throw New InvalidCastException()
    	'End Try
       
    End Sub
	
	Public Function CSV_Labels() As String
        CSV_Labels = "Name,StateSequence,Category," & m_objStats.CSV_Labels
	End Function
	
	Public Function CSV_Data(ByRef InTrxCnt As Integer, ByRef InTrxProb As Single) As String
        CSV_Data = Me.PatternName & c & Me.StateList & c & Me.Category & c & m_objStats.CSV_Data
	End Function
    Public Function Report(ByVal dgr() As String, ByVal flags() As Integer) As String
    	'MsgBox(dgr(0))
        Report = Me.PatternName & cs & Me.Category & m_objStats.Report(dgr, flags, m_nMinHiLim, m_nMinLoLim, m_nMaxHiLim, m_nMaxLoLim, m_dAvgHiLim, m_dAvgLoLim)
        dgr(0) = Me.PatternName
        
    End Function
	
 
    Public Property StateList() As String
        Get
            Dim objPatternState As CPatternState
            Dim sData As String

            sData = ""
            For Each objPatternState In mCol
                sData = sData & objPatternState.StateName & "-"
            Next objPatternState
            If sData.Length > 0 Then
            	StateList = Left(sData, Len(sData) - 1)
            Else
            	StateList = ""
            End If
            

        End Get
        Set(ByVal Value As String)
            ParseStateList(Value, False)
        End Set
    End Property

    Public Property ExclusionList() As String
        Get
            Dim objPatternState As CPatternState
            Dim sData As String
            ExclusionList = ""

            sData = ""
            For Each objPatternState In Me.PoisonStates
                sData = sData & objPatternState.StateName & "-"
            Next objPatternState

            If (sData.Length > 0) Then
                ExclusionList = Left(sData, sData.Length - 1)
            End If

        End Get
        Set(ByVal Value As String)
            ParseStateList(Value, True)
        End Set
    End Property

    Public Function ParseStateList(ByVal value As String, ByVal bExclude As Boolean) As Integer
        Dim n As Integer
        Dim sState As String
		
        Do While (Len(value) > 0)
            n = InStr(1, value, "-")
            If (n = 0) Then n = Len(value) + 1 '??
            sState = Mid(value, 1, n - 1)
            If (n < Len(value)) Then
                value = LTrim(Mid(value, n + 1))
            Else
                value = ""
            End If
            n = StateName2Code(sState, False)
            If (n <> 0) Then                    'negative state codes are exclusion states
                If (bExclude) Then
                    Me.m_objPoisonStates.Add(n)
                Else
                    Me.Add(n)
                End If
            Else
            	Dim errpat As String = sState.Trim()
            	Dim found as Boolean = False
            	If g_errPatternsLoad.Length > 0 Then
            		For Each s As String In g_errPatternsLoad.ToString().Split(Environment.NewLine)
	            		If s.Trim().Equals(errpat) Then
	            			found = true
	            			Exit For	            		
	            		End If
	            	Next
	            	If Not found Then
	            		g_errPatternsLoad.Append(errpat & Environment.NewLine)
	            	End If
            	Else
            		g_errPatternsLoad.Append(errpat & Environment.NewLine)
            	End If           	
            End If
        Loop

    End Function
    Public Property KeyValPairs() As String
		Get
			KeyValPairs = m_sKeyValPairs
		End Get
		
		Set(ByVal Value As String)
		'Try
            m_sKeyValPairs = Value
            Dim sTmp As String
            Dim KVList As String() = Value.Split(c)
            For Each sTmp In KVList
                Dim KVPair As String() = sTmp.Split("=")
                If (Trim(KVPair(0)) = "AvgUprLim") Then m_dAvgHiLim = CDbl(KVPair(1))
                If (Trim(KVPair(0)) = "MaxUprLim") Then m_nMaxHiLim = CInt(KVPair(1))
                If (Trim(KVPair(0)) = "MinUprLim") Then m_nMinHiLim = CInt(KVPair(1))
                If (Trim(KVPair(0)) = "AvgLowLim") Then m_dAvgLoLim = CDbl(KVPair(1))
                If (Trim(KVPair(0)) = "MaxLowLim") Then m_nMaxLoLim = CInt(KVPair(1))
                If (Trim(KVPair(0)) = "MinLowLim") Then m_nMinLoLim = CInt(KVPair(1))
                If (Trim(KVPair(0)) = "Category") Then m_sCategory = KVPair(1)
            Next
		'Catch ex As NullReferenceException
			'Throw New NullReferenceException()
		'End Try
		End Set 
 		
	End Property

    Public Function keyValue(ByVal key As String) As String
        Dim sTmp As String
        keyValue = ""
        
        Dim KVList As String() = m_sKeyValPairs.Split(c)
        For Each sTmp In KVList
       
            Dim KVPair As String() = sTmp.Split("=")
            If (Trim(KVPair(0)) = key) Then
                keyValue = KVPair(1)
                Exit For
            End If
        Next
    End Function
	
	Public Property PatternName() As String
		Get
			PatternName = m_sPatternName
		End Get
		Set(ByVal Value As String)
			m_sPatternName = Value
			'    m_objStats.sName = vData
		End Set
	End Property
	
	
	Public Property Category() As String
		Get
			Category = m_sCategory
		End Get
		Set(ByVal Value As String)
			m_sCategory = Value
		End Set
	End Property
	
	
	Public Property nIndex() As Integer
		Get
			nIndex = m_nIndex
		End Get
		Set(ByVal Value As Integer)
			m_nIndex = Value
		End Set
    End Property

    Public ReadOnly Property PatternPointers() As CPatternPointers
        Get
            PatternPointers = m_objPatternPointers
        End Get
    End Property

    Public ReadOnly Property PoisonStates() As CExclusions
        Get
            PoisonStates = m_objPoisonStates
        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As CPatternState
        Get
            Item = mCol.Item(vntIndexKey)
        End Get
    End Property
	
	Public ReadOnly Property Count() As Integer
		Get
			Count = mCol.Count()
		End Get
	End Property
	

	Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        GetEnumerator = mCol.GetEnumerator
	End Function
	
	Public ReadOnly Property stats() As CStatistics
		Get
			stats = m_objStats
		End Get
	End Property
	
	Public Function Add(ByRef eStateName As Integer, Optional ByRef sKey As String = "") As CPatternState
		'create a new object
		Dim objNewMember As CPatternState
		objNewMember = New CPatternState
		
		'Try
		'set the properties passed into the method
		objNewMember.eStateName = eStateName
		objNewMember.StateName = StateCode2Name(eStateName)
		If Len(sKey) = 0 Then
			mCol.Add(objNewMember)
		Else
			mCol.Add(objNewMember, sKey)
		End If
		
		'return the object created
		Add = objNewMember
		objNewMember = Nothing
		
'		Catch ex As NullReferenceException
'			Throw New NullReferenceException()
'		End Try
		
	End Function
	
	Public Sub Remove(ByRef vntIndexKey As Object)
		mCol.Remove(vntIndexKey)
	End Sub
	
    Private Sub Class_Initialize_Renamed()
        'creates the collection when this class is created
        mCol = New Collection
    End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
    Private Sub Class_Terminate_Renamed()
        'destroys collection when this class is terminated
        Dim n As Integer
        For n = 1 To mCol.Count()
            mCol.Remove((1))
        Next
        mCol = Nothing
    End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
End Class
'End Namespace