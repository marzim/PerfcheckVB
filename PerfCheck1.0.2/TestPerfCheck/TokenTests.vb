'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/16/2012
' Time: 9:31 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.IO

<TestFixture> _
Public Class TokenTests
	Private tToken As SignifEvent
	Private parserEvents As ParserEventValues
	Private sEvent As SignifEvents
	Dim parseValueDictionaryPath As String
	<SetUp()> _
	Public Sub SetUp()
		tToken = New SignifEvent()
		parserEvents = New ParserEventValues()
		parseValueDictionaryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\EventValues.dictionary"
		sEvent = New SignifEvents()
		sEvent.DicEventValues = parserEvents.Parsed(New ExtendedStreamReader(New FileStream(parseValueDictionaryPath,FileMode.Open,FileAccess.Read),System.Text.Encoding.Default))
		TestData.createDictionaryFiles()
		TestData.createEventLogFile()
		parseValueDictionaryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\EventValues.dictionary"
		MessageService.Attach(New ConsoleMessageProvider())
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()
		tToken = Nothing
		parserEvents = Nothing
		sEvent = Nothing
	End Sub
	<Test> _
	Public Sub TestTimeStampPositive()
		tToken.TimeOfDay_Renamed = "05/07 15:39:58"
		tToken.TimeMs = 174278709
		Assert.IsNotEmpty(tToken.TimeStamp,"This should be not empty")
		' TODO: Add your testToken.
	End Sub
	
	<Test> _
	Public Sub TestTimeStampNegative()
		tToken.TimeOfDay_Renamed = ""
		tToken.TimeMs = 0
		Assert.AreNotEqual(tToken.TimeStamp,Date.Now.ToString & " " & Date.Now.Millisecond.ToString,"This should not be equal")
		' TODO: Add your testToken.
	End Sub
	
	
	
	<Test> _
	Public Sub TestFormatEvent_UnMatched_Weight()
		Dim dgr(6) As String
		tToken.EventName = "UnMatched_Weight"
		tToken.FullLine = "SM: 05/09 01:00:26   587,995,873 00FC> UnMatched: Weight increase of  8020. App determining if allowed..."
		tToken.FormatEvent(dgr,sEvent.DicEventValues,True)
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/09 01:00:26"
'		tToken.TimeMs = 587995873
'		tToken.EventName = "UnMatched_Weight"
'		tToken.FullLine = "SM: 05/09 01:00:26   587,995,873 00FC> UnMatched: Weight increase of  8020. App determining if allowed..."
'		tToken.LineNo = 252
'		tToken.SourceType = "SM"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
'		Assert.AreSame("05/09 01:00:26",tToken.TimeOfDay_Renamed)
'		Assert.AreEqual(587995873,tToken.TimeMs)
'		Assert.AreSame("UnMatched_Weight",tToken.EventName)
'		Assert.AreSame("SM: 05/09 01:00:26   587,995,873 00FC> UnMatched: Weight increase of  8020. App determining if allowed...",tToken.FullLine)
'		Assert.AreEqual(252,tToken.LineNo)
'		Assert.AreEqual("SM",tToken.SourceType)
		' TODO: Add your testToken.
	End Sub
	<Test> _
	Public Sub TestFormatEvent_Description()
		Dim dgr(6) As String
		tToken.EventName = "Description"
		tToken.FullLine = "SM: 05/08 23:42:49   583,339,577 00FC> Parsing key=item-description.  value=KX DRINK 250ML *"
		tToken.FormatEvent(dgr,sEvent.DicEventValues,False)
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/08 23:42:49"
'		tToken.TimeMs = 583339577
'		tToken.EventName = "Description"
'		tToken.FullLine = "SM: 05/08 23:42:49   583,339,577 00FC> Parsing key=item-description.  value=KX DRINK 250ML *"
'		tToken.LineNo = 252
'		tToken.SourceType = "SM"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
'		Assert.AreSame("05/08 23:42:49",tToken.TimeOfDay_Renamed)
'		Assert.AreEqual(583339577,tToken.TimeMs)
'		Assert.AreSame("Description",tToken.EventName)
'		Assert.AreSame("SM: 05/08 23:42:49   583,339,577 00FC> Parsing key=item-description.  value=KX DRINK 250ML *",tToken.FullLine)
'		Assert.AreEqual(252,tToken.LineNo)
'		Assert.AreEqual("SM",tToken.SourceType)
		' TODO: Add your testToken.
	End Sub
'	
'	<Test> _
'	Public Sub TestFormatEvent_WeightEntered()
'		'Dim t As New SignifEvent
'		Dim dgr As String() = {"","","","","",""}
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/09 07:56:03"
'		tToken.TimeMs = 521605953
'		tToken.EventName = "Weight_Entered"
'		tToken.FullLine = "231546.11,05/09 07:56:03,521605953,SM:,70422,Weight_Entered 2006.2065842,"
'		tToken.LineNo = 70422
'		tToken.SourceType = "SM"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
'		Assert.AreSame("05/09 07:56:03",tToken.TimeOfDay_Renamed)
'		Assert.AreEqual(521605953,tToken.TimeMs)
'		Assert.AreSame("Weight_Entered",tToken.EventName)
'		Assert.AreSame("231546.11,05/09 07:56:03,521605953,SM:,70422,Weight_Entered 2006.2065842,",tToken.FullLine)
'		Assert.AreEqual(70422,tToken.LineNo)
'		Assert.AreEqual("SM",tToken.SourceType)
'		' TODO: Add your testToken.
'	End Sub
	<Test> _
	Public Sub TestFormatEvent_ProduceScale()
		Dim dgr(6) As String
		tToken.EventName = "ProduceScale"
		tToken.FullLine = "10141876) 05/09 07:47:38;0612451118 0A24> SM-SMStateDM@126  SMState::DMScale lDMScaleWeight 0"
		tToken.FormatEvent(dgr,sEvent.DicEventValues,False)
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/09 07:47:38"
'		tToken.TimeMs = 0612451118
'		tToken.EventName = "ProduceScale"
'		tToken.FullLine = "10141876) 05/09 07:47:38;0612451118 0A24> SM-SMStateDM@126  SMState::DMScale lDMScaleWeight 0"
'		tToken.LineNo = 2596
'		tToken.SourceType = "SM:"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
		
		' TODO: Add your testToken.
	End Sub
	<Test> _
	Public Sub TestFormatEvent_ItemDetails()
		Dim dgr(6) As String
		tToken.EventName = "ItemDetails"
		tToken.FullLine = "10115655) 05/09 07:26:19;0611171598 SM-SMtb@3880, 4, TBGetItemDetails--ItemDetail: lExtPrice:49; lUnitPrice:49; lQuantity:1; lWeight:0; lDealQuantity:0; fCoupon:0; fVoid:0; fNeedQuantity:0; fNeedWeight:0; fRestricted:0; fVisualVerify:0; nRestrictedAge:0; szDescription:HULA HOOPS     *; szItemCode:5000237060964; fNeedPrice:0; fNotFound:0; fNotForSale:0; lScanCodeType:104; bLinkedItem:0 lDepartment:99999, entryid:0; lRequireSecBagging:-1; lRequireSecSubstChk:-1; bSecurityTag:0; bZeroWeightItem:0, bPickListItem:0, szItemID:,szErrDescription :99999,G76DD"
		tToken.FormatEvent(dgr,sEvent.DicEventValues,False)
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "5/09 07:26:19"
'		tToken.TimeMs = 0611171598
'		tToken.EventName = "ItemDetails"
'		tToken.FullLine = "10115655) 05/09 07:26:19;0611171598 SM-SMtb@3880, 4, TBGetItemDetails--ItemDetail: lExtPrice:49; lUnitPrice:49; lQuantity:1; lWeight:0; lDealQuantity:0; fCoupon:0; fVoid:0; fNeedQuantity:0; fNeedWeight:0; fRestricted:0; fVisualVerify:0; nRestrictedAge:0; szDescription:HULA HOOPS     *; szItemCode:5000237060964; fNeedPrice:0; fNotFound:0; fNotForSale:0; lScanCodeType:104; bLinkedItem:0 lDepartment:99999, entryid:0; lRequireSecBagging:-1; lRequireSecSubstChk:-1; bSecurityTag:0; bZeroWeightItem:0, bPickListItem:0, szItemID:,szErrDescription :99999,G76DD"
'		tToken.LineNo = 4
'		tToken.SourceType = "App"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
		' TODO: Add your testToken.
	End Sub
	<Test> _
	Public Sub TestFormatEvent_Matched_Weight()
		Dim dgr(6) As String
		tToken.EventName = "Matched_Weight"
		tToken.FullLine = "SM: 05/09 00:00:32   584,400,463 00FC> //smart-scale/minimum-wt:  30"
		tToken.FormatEvent(dgr,sEvent.DicEventValues,False)
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/09 00:00:32"
'		tToken.TimeMs = 584400463
'		tToken.EventName = "Matched_Weight"
'		tToken.FullLine = "SM: 05/09 00:00:32   584,400,463 00FC> //smart-scale/minimum-wt:  30"
'		tToken.LineNo = 252
'		tToken.SourceType = "SM"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
		' TODO: Add your testToken.
	End Sub
	<Test> _
	Public Sub TestFormatEvent_WLDB_Lookup()
		Dim dgr(6) As String 
		tToken.EventName = "WLDB_Lookup"
		tToken.FullLine = "SM: 05/09 00:18:42   585,491,472 00FC> WLDB Entry 1, lexpectedWt: 31, linitWt 31, lppwu 0, lTally: 74, fApproved: 1, UPC: 50173686, Std Dev: 16"
		tToken.FormatEvent(dgr,sEvent.DicEventValues,False)
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/09 00:18:42"
'		tToken.TimeMs = 585491472
'		tToken.EventName = "WLDB_Lookup"
'		tToken.FullLine = "SM: 05/09 00:18:42   585,491,472 00FC> WLDB Entry 1, lexpectedWt: 31, linitWt 31, lppwu 0, lTally: 74, fApproved: 1, UPC: 50173686, Std Dev: 16"
'		tToken.LineNo = 252
'		tToken.SourceType = "SM"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
		' TODO: Add your testToken.
	End Sub
'	<Test> _
'	Public Sub TestFormatEvent_SO_StableWeight()
'		'Dim t As New SignifEvent
'		Dim dgr As String() = {"","","","","",""}
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/09 00:27:11"
'		tToken.TimeMs = 494640671
'		tToken.EventName = "SO_StableWeight"
'		tToken.FullLine = "204580.828,05/09 00:27:11,494640671,FlintecScaleSO32-00,62,SO_StableWeight 49537.8702714,"
'		tToken.LineNo = 62
'		tToken.SourceType = "FlintecScaleSO32-00"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
'		' TODO: Add your testToken.
'	End Sub
'	<Test> _
'	Public Sub TestFormatEvent_ScaleSent()
'		'Dim t As New SignifEvent
'		Dim dgr As String() = {"","","","","",""}
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/09 00:27:11"
'		tToken.TimeMs = 494640671
'		tToken.EventName = "ScaleSent"
'		tToken.FullLine = "204580.828,05/09 00:27:11,494640671,FlintecScaleSO32-00,62,ScaleSent 49537.8702714,"
'		tToken.LineNo = 62
'		tToken.SourceType = "FlintecScaleSO32-00"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
'		' TODO: Add your testToken.
'	End Sub
	<Test> _
	Public Sub TestFormatEvent_StableWeight()
		Dim dgr(6) As String
		tToken.EventName = "StableWeight"
		tToken.FullLine = "FlintecScaleSO01-00 05/08 21:36:23   575,792,545 0958> Read Weight returns 750  Rc = 0, RcEx = 0"
		tToken.FormatEvent(dgr,sEvent.DicEventValues,False)
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/08 21:36:23"
'		tToken.TimeMs = 575792545
'		tToken.EventName = "StableWeight"
'		tToken.FullLine = "FlintecScaleSO01-00 05/08 21:36:23   575,792,545 0958> Read Weight returns 750  Rc = 0, RcEx = 0"
'		tToken.LineNo = 0958
'		tToken.SourceType = "FlintecScaleSO01-00"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
		' TODO: Add your testToken.
	End Sub
'	
'	<Test> _
'	Public Sub TestFormatEvent_ScaleShift()
'		'Dim t As New SignifEvent
'		Dim dgr As String() = {"","","","","",""}
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/09 00:27:05"
'		tToken.TimeMs = 494634906
'		tToken.EventName = "ScaleShift"
'		tToken.FullLine = "204575.063,05/09 00:27:05,494634906,FlintecScaleSO32-00,14,ScaleShift 41601.2288394,"
'		tToken.LineNo = 14
'		tToken.SourceType = "FlintecScaleSO32-00"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
'		' TODO: Add your testToken.
'	End Sub
'	
	<Test> _
	Public Sub TestFormatEvent_ScaleFilter5()
		Dim dgr(6) As String
		tToken.EventName = "ScaleFilter@5"
		tToken.FullLine = "FlintecScaleSO01-00 05/08 21:36:23   575,792,265 07A0> mode|raw|f1|f2, 5, 5774574, 5774909, 5775172"
		tToken.FormatEvent(dgr,sEvent.DicEventValues,False)
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/08 21:36:23"
'		tToken.TimeMs = 575792265
'		tToken.EventName = "ScaleFilter@5"
'		tToken.FullLine = "FlintecScaleSO01-00 05/08 21:36:23   575,792,265 07A0> mode|raw|f1|f2, 5, 5774574, 5774909, 5775172"
'		tToken.LineNo = 1952
'		tToken.SourceType = "FlintecScaleSO01-00"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
		' TODO: Add your testToken.
	End Sub
'	<Test> _
'	Public Sub TestFormatEvent_SS_Event()
'		'Dim t As New SignifEvent
'		Dim dgr As String() = {"","","","","",""}
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/09 00:27:10"
'		tToken.TimeMs = 494640562
'		tToken.EventName = "SS_Event"
'		tToken.FullLine = "204580.719,05/09 00:27:10,494640562,FlintecScaleSO32-00,58,SS_Event,"
'		tToken.LineNo = 58
'		tToken.SourceType = "FlintecScaleSO32"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
'		' TODO: Add your testToken.
'	End Sub
'	<Test> _
'	Public Sub TestFormatEvent_TabStateChange()
'		'Dim t As New SignifEvent
'		Dim dgr As String() = {"","","","","",""}
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/09 00:27:10"
'		tToken.TimeMs = 494640562
'		tToken.EventName = "Tab--StateChange"
'		tToken.FullLine = "204580.719,05/09 00:27:10,494640562,FlintecScaleSO32-00,58,Tab--StateChange,"
'		tToken.LineNo = 58
'		tToken.SourceType = "FlintecScaleSO32-00"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
'		' TODO: Add your testToken.
'	End Sub
'	<Test> _
'	Public Sub TestFormatEvent_SetSoldItemInfo()
'		'Dim t As New SignifEvent
'		Dim dgr As String() = {"","","","","",""}
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/08 01:17:22"
'		tToken.TimeMs = 208883448
'		tToken.EventName = "SetSoldItemInfo"
'		tToken.FullLine = "34604.739,05/08 01:17:22,208883448,SM:,5206,SetSoldItemInfo 12 ASST DONUTS,"
'		tToken.LineNo = 5206
'		tToken.SourceType = "SM:"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
'		' TODO: Add your testToken.
'	End Sub
	<Test> _
	Public Sub TestFormatEvent_Expected_Wt()
		Dim dgr(6) As String
		tToken.EventName = "Expected_Wt"
		tToken.FullLine = "SM: 05/09 01:06:11   588,340,719 00FC> WLDB Entry 1, lexpectedWt: 587, linitWt 589, lppwu 0, lTally: 106, fApproved: 1, UPC: 5000177464174, Std Dev: 13"
		tToken.FormatEvent(dgr,sEvent.DicEventValues,False)
'		tToken.TimeOfDay_Renamed = "05/09 01:06:11"
'		tToken.TimeMs = 588340719
'		tToken.EventName = "Expected_Wt"
'		tToken.FullLine = "SM: 05/09 01:06:11   588,340,719 00FC> WLDB Entry 1, lexpectedWt: 587, linitWt 589, lppwu 0, lTally: 106, fApproved: 1, UPC: 5000177464174, Std Dev: 13"
'		tToken.LineNo = 252
'		tToken.SourceType = "SM"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
		' TODO: Add your testToken.
	End Sub
'	<Test> _
'	Public Sub TestFormatEvent_PerfMon()
'		'Dim t As New SignifEvent
'		Dim dgr As String() = {"","","","","",""}
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = Date.Now.ToString
'		tToken.TimeMs = Date.Now.Millisecond
'		tToken.EventName = "PerfMon"
'		tToken.FullLine = "0.691,05/07 15:39:59,174279400,PSX_ScotAppU,4,PerfMon ContextName:PerfMon,"
'		tToken.LineNo = 3
'		tToken.SourceType = "Sample"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
'		' TODO: Add your testToken.
'	End Sub

'	
'	<Test> _
'	Public Sub TestFormatEvent_TB_ItemSold()
'		'Dim t As New SignifEvent
'		Dim dgr As String() = {"","","","","",""}
'		Dim obj As New Object
'		tToken.TimeOfDay_Renamed = "05/08 23:43:05"
'		tToken.TimeMs = 583356352
'		tToken.EventName = "TB_ItemSold"
'		tToken.FullLine = "05/08 23:43:05     583356352 0A24>     [I]CCustomerMHGenMsg@33:<message validate=0><fields><field name=PosState>CTLButtonEnable</field><field name=CTLButtonEnabled>false</field></fields></message>"
'		tToken.LineNo = 2596
'		tToken.SourceType = "TB"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
'		' TODO: Add your testToken.
'	End Sub
'	
	<Test> _
	Public Sub TestFormatEvent_EndDrawContext()
		Dim dgr(6) As String
		tToken.EventName = "EndDrawContext"
		tToken.FullLine = "0.691,05/07 15:39:59,174279400,PSX_ScotAppU,4,EndDrawContext ContextName:QuickPickItems,"
		tToken.FormatEvent(dgr,sEvent.DicEventValues,False)
		
'		tToken.TimeOfDay_Renamed = "05/07 15:39:59"
'		tToken.TimeMs = 174279400
'		tToken.EventName = "EndDrawContext"
'		tToken.FullLine = "0.691,05/07 15:39:59,174279400,PSX_ScotAppU,4,EndDrawContext ContextName:QuickPickItems,"
'		tToken.LineNo = 4
'		tToken.SourceType = "PSX_ScotAppU"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
		' TODO: Add your testToken.
	End Sub
	
	<Test> _
	Public Sub TestFormatEvent_ButtonClick()
		Dim dgr(6) As String
	    tToken.EventName = "ButtonClick"
		tToken.FullLine = "0,05/07 15:39:58,174278709,PSX_ScotAppU,3,ButtonClick ControlName:CMButton1Lg,"
		tToken.FormatEvent(dgr,sEvent.DicEventValues,False)
		
'		tToken.TimeOfDay_Renamed = "05/07 15:39:58"
'		tToken.TimeMs = 174278709
'		tToken.EventName = "ButtonClick"
'		tToken.FullLine = "0,05/07 15:39:58,174278709,PSX_ScotAppU,3,ButtonClick ControlName:CMButton1Lg,"
'		tToken.LineNo = 3
'		tToken.SourceType = "PSX_ScotAppU"
'		obj=tToken.FormatEvent(dgr)
'		Assert.IsNotEmpty(obj.ToString,"This should be empty")
		' TODO: Add your testToken.
	End Sub

End Class

