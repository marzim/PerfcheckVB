'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/27/2012
' Time: 3:02 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.Reflection
Imports System.IO

<TestFixture> _
Public Class FormLogAnalSearchTests
	
	Private frmLogAnalSrch As formLogAnalSearch
	Private _frm As formMeasurementDetail
	Private parserEventValues As ParserEventValues
	Dim les As New LogEventsSummary()
	Dim le As LogEventSummary
	Dim perfConfigData As PerfConfigData
	Dim frmLogMain As formLogAnalysisMain
	Dim parseValueDictionaryPath As String
	<SetUp()> _
	Public Sub SetUp()
		MessageService.Attach(New ConsoleMessageProvider())
		perfConfigData = New PerfConfigData()
		perfConfigData.DictionaryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\"
		perfConfigData.DiagFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs"
		TestData.createDictionaryFiles()
		TestData.createEventLogFile()	
		frmLogMain = New formLogAnalysisMain()
		frmLogMain.PerfConfigData = perfConfigData
		parseValueDictionaryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\EventValues.dictionary"
		parserEventValues = New ParserEventValues()
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()	
		frmLogAnalSrch.Dispose()
		parserEventValues = Nothing
	End Sub
	
	Public Sub SampleEvents()
		le = New LogEventSummary()
		le.Average = "12.0"		
		le.Col.Add(2)
		le.Count = "3"
		le.Flag.Add(1)
		le.Maximum = "123"
		le.Measure = "12"
		le.Minimum = "1"
		le.StdDev = "12.2"
		les = New LogEventsSummary(le)
		frmLogMain = New formLogAnalysisMain()
		Dim p1 As New SignifEvents()
		p1.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
		p1.ParseEvents(New ExtendedStringReader("12352421) 06/02 21:27:04;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine & "12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext ) "  & Environment.NewLine & "12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine))
		Dim p2 As New SignifEvents()
		p2.ParseDictionary(New ExtendedStringReader("Description, key=item-description.  value=" & Environment.NewLine & "UnMatched_Weight, UnMatched: Weight increase of" & Environment.NewLine))
		p2.ParseEvents(New ExtendedStringReader("SM: 05/02 05:49:34       581,686 0A24> --- Begin Data Capture --- (continued)" & Environment.NewLine & "SM: 05/09 07:18:41   610,713,759 00FC> UnMatched: Weight increase of  5730. App determining if allowed..." & Environment.NewLine & "SM: 05/09 07:19:28   610,760,897 00FC> Parsing key=item-description.  value=""" & Environment.NewLine))
		Dim p3 As New SignifEvents()
		p3.Merge(p1, p2)	
		p3.DicEventValues = parserEventValues.Parsed(New ExtendedStreamReader(New FileStream(parseValueDictionaryPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default))
		Dim logevents As LogEvents = p3.ListAllEvents()
		frmLogMain.PerfConfigData = perfConfigData
		frmLogMain.EventsFound = p3
		frmLogMain.addEventsToDataGridView()
		'frmLogMain.LoadMain()
		frmLogMain.AllPatterns()
		frmLogAnalSrch = New formLogAnalSearch(frmLogMain.EventsFound, les, perfConfigData, frmLogMain.Templates)
		frmLogAnalSrch.Subscribe(New formMeasurementDetail)
	End Sub
	
	<Test> _
	Public Sub TestLogAnalSearch()
		SampleEvents()
		frmLogAnalSrch.Show()
		frmLogAnalSrch.Close()
		frmLogAnalSrch.RemoveSubscription(New formMeasurementDetail)
	End Sub
	
	<Test> _
	Public Sub TestEmptyDataGridView1_CellDoubleClick()
		SampleEvents()
		' Get the constructor and create an instance of formMeasurementDetail
		Dim type As Type = frmLogAnalSrch.GetType()
		Dim frmLogAnalSrchConstructor As ConstructorInfo = type.GetConstructor(Type.EmptyTypes)
		Dim frmLogAnalSrchClassObject As Object = frmLogAnalSrchConstructor.Invoke(New Object(){})
		
		Dim mEvent As New DataGridViewCellEventArgs(0, 0)
		Dim contcolumn As New DataGridViewTextBoxColumn

		Dim dg As New DataGridView()
		dg.Columns.Insert(0,contcolumn)
		dg.Rows.Add("")
		dg.Refresh()
		dg.CurrentCell = dg.Item(0,0)
		
		' Get the dgMeasureDetails_CellDoubleClick method and invoke with a parameter value of Nothing
		Dim dynamicMethod As MethodInfo = type.GetMethod("DataGridView1_CellDoubleClick", BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
		dynamicMethod.Invoke(frmLogAnalSrchClassObject, New Object(){dg, mEvent})
		
	End Sub
	
	<Test> _
	Public Sub TestNotEmptyDataGridView1_CellDoubleClick()
		
		Dim logEventSummary As LogEventsSummary
		logEventSummary = getGeneratedEvents(getTraceList())
		frmLogAnalSrch = New formLogAnalSearch(frmLogMain.EventsFound,logEventSummary,perfConfigData,frmLogMain.Templates)
		frmLogAnalSrch.FormLogAnalSearchLoad(frmLogMain,Nothing)
		frmLogAnalSrch.DataGridView1.CurrentCell = frmLogAnalSrch.DataGridView1.Item(0,40)
		GenereteWithValueDataGridviewEvent(frmLogAnalSrch,"DataGridView1_CellDoubleClick",frmLogAnalSrch.DataGridView1)
	End Sub
	
'	<Test> _
'	Public Sub TestDataGridView1_CellDoubleClick_Exception()
'		
'		Dim logEventSummary As LogEventsSummary
''		Dim c As CPattern
'		'Dim dg As DataGridView
'		Dim contcolumn As New DataGridViewTextBoxColumn
'		'Dim mEvent As New DataGridViewCellEventArgs(0, 0)
'		
'		logEventSummary = getGeneratedEmptyEvents(TestData.ParseEventsSampleGenerateEmptyEvents())
'		frmLogAnalSrch = New formLogAnalSearch(frmLogMain.EventsFound,logEventSummary,perfConfigData,frmLogMain.Templates)
''		c = frmLogMain.Templates.Patterns.Item("Good Wt to Scan&Bag")
''		MsgBox(c.Count)
'		frmLogAnalSrch.FormLogAnalSearchLoad(frmLogMain,Nothing)
'		
'		frmLogAnalSrch.DataGridView1.CurrentCell = frmLogAnalSrch.DataGridView1.Item(0,40)
'		GenereteWithValueDataGridviewEvent(frmLogAnalSrch,"DataGridView1_CellDoubleClick",frmLogAnalSrch.DataGridView1)
'	End Sub
	
	
	Public Sub GenereteWithValueDataGridviewEvent(frmLogSearch As formLogAnalSearch, eventName As String , dgr As DataGridView)
		
		' Get the constructor and create an instance of formMeasurementDetail
		'Dim frmMeasurementDetail As formMeasurementDetail = New formMeasurementDetail()
		Dim type As Type = frmLogSearch.GetType()
		Dim frmLogSearchDetailConstructor As ConstructorInfo = type.GetConstructor(Type.EmptyTypes)
		Dim frmLogSearchDetailClassObject As Object = frmLogSearchDetailConstructor.Invoke(New Object(){})
		Dim mEvent As New DataGridViewCellEventArgs(dgr.CurrentCell.ColumnIndex, dgr.CurrentCell.RowIndex)
		' Get the dgMeasureDetails_CellDoubleClick method and invoke with a parameter value of Nothing
		Dim dynamicMethod As MethodInfo = type.GetMethod(eventName, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
		dynamicMethod.Invoke(frmLogSearchDetailClassObject, New Object(){dgr, mEvent})
		
	End Sub
	
'	<Test> _
'	Public Sub TestDataGridView1_CellDoubleClick()
'		
'		' Get the constructor and create an instance of formMeasurementDetail
'		Dim type As Type = frmLogAnalSrch.GetType()
'		Dim frmLogAnalSrchConstructor As ConstructorInfo = type.GetConstructor(Type.EmptyTypes)
'		Dim frmLogAnalSrchClassObject As Object = frmLogAnalSrchConstructor.Invoke(New Object(){})
'		Dim dg As New DataGridView()
'		
'		Dim mEvent As New DataGridViewCellEventArgs(0, 0)
'		Dim contcolumn As New DataGridViewTextBoxColumn
'
'		Dim data As String() = New String() {"1", "2", "3", "4"}
'		dg.ColumnCount = 6
'		dg.Columns(0).Name = "Measure"
'		dg.Columns(1).Name = "Count"
'		dg.Columns(2).Name = "Minimum"
'		dg.Columns(3).Name = "Maximum"
'		dg.Columns(4).Name = "Average"
'		dg.Columns(5).Name = "Std Dev"
'		dg.Rows.Add(data)
'		dg.Refresh()
'		dg.CurrentCell = dg.Item(1,0)
'
'		' Get the dgMeasureDetails_CellDoubleClick method and invoke with a parameter value of Nothing
'		Dim dynamicMethod As MethodInfo = type.GetMethod("DataGridView1_CellDoubleClick", BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
'		dynamicMethod.Invoke(frmLogAnalSrchClassObject, New Object(){dg, mEvent})
'		
'	End Sub

	<Test> _
	Public Sub testLoadMeasurementDetails()
		SampleEvents()
		'frmLogAnalSrch.loadFrmMeasurementDetails("Scan Processing")
	End Sub

	
	Public Sub TestEmptyColorThreadsHold()
		SampleEvents()
		Dim type As Type = frmLogAnalSrch.GetType()
		Dim lgEvntSummary As LogEventSummary = New LogEventSummary()

		' Get the dgMeasureDetails_CellDoubleClick method and invoke with a parameter value of Nothing
		Dim dynamicMethod As MethodInfo = type.GetMethod("ColorThreadsHold", BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
		dynamicMethod.Invoke(frmLogAnalSrch, New Object(){lgEvntSummary})
	End Sub
	
	Public Function getTraceList() As SignifEvents
		Dim i as Integer
    	Dim logfileController As New LogFileController()
    	Dim logEventsController As New LogEventsController()
    	logfileController.DiagPath = perfConfigData.DiagFilesPath
		logfileController.getTraceList(New ExtendedStringReader(TestData.LogAnalTraceListStub()))
    	frmLogMain.EventsFound = New SignifEvents()
    	
    	For Each keyval As KeyValuePair(Of String, FileInfo) In logFileController.DicTraceFile
    		If Not keyval.Value Is Nothing Then
    			logEventsController.ObjTraceEvents = New SignifEvents()
        		logEventsController.getEventsFromFile(keyval.Value, logfileController.m_cFormat(i), perfConfigData.DictionaryPath)
				i+=1		
    		End If
    	Next	
    	Return logEventsController.EventsFound
	End Function
	
	Public Function getGeneratedEvents(eventsFound As SignifEvents) As LogEventsSummary
		frmLogMain.EventsFound = eventsFound
		frmLogMain.ShowMergedTrace(frmLogMain.EventsFound)
		Assert.AreNotEqual(0,frmLogMain.DataGridView1.RowCount)
		Return frmLogMain.AllPatterns()
	End Function
	
'	Public Function getGeneratedEmptyEvents(eventsFound As SignifEvents) As LogEventsSummary
'		frmLogMain.EventsFound = eventsFound
'		frmLogMain.ShowMergedTrace(frmLogMain.EventsFound)
'		Assert.AreEqual(0,frmLogMain.DataGridView1.RowCount)
'		Return Nothing
'	End Function
	
End Class
