'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/23/2012
' Time: 6:07 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.Text
Imports System.IO

Public Class TestData
	
	Public Shared Function TraceDictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("PicklistSale," & Environment.NewLine) 
		sb.Append("To_EnterQuantity, Changing state to SMEnterQuantity," & Environment.NewLine)
		sb.Append("From_EnterQuantity, Changing state from SMEnterQuantity")
		sb.Append("Produce_Scale, SM-SMdmBase@5922 Scale weight =")
		sb.Append("GotoQuickPick, PSXEventHandler Event( ,QuickPickImage,QuickPickItems,Click" & Environment.NewLine)
		sb.Append(Environment.NewLine)
		sb.Append("ItemDetails, SetItemDetails--ItemDetail:" & Environment.NewLine)
		sb.Append("TB_Start, TBStart--szLanguageCode" & Environment.NewLine)
		sb.Append("PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext" & Environment.NewLine)
		sb.Append("App_Waiting, SMState::TBParse() and not ScanAndBag state," & Environment.NewLine) 
		sb.Append(Environment.NewLine)
		sb.Append("To_SMBagAndEAS, Changing state to SMBagAndEAS," & Environment.NewLine)
		sb.Append("From_SMBagAndEAS, Changing state from SMBagAndEAS" & Environment.NewLine)
		sb.Append("To_SMScanAndBag, Changing state to SMScanAndBag," & Environment.NewLine)
		sb.Append("From_SMScanAndBag, Changing state from SMScanAndBag" & Environment.NewLine)
		sb.Append("To_SMInProgress, Changing state to SMInProgress," & Environment.NewLine)
		sb.Append("From_SMInProgress, Changing state from SMInProgress" & Environment.NewLine)
		sb.Append("To_SMTransportItem, Changing state to SMTransportItem," & Environment.NewLine)
		sb.Append("From_SMTransportItem, Changing state from SMTransportItem" & Environment.NewLine)
		sb.Append("To_SMInSAProgress, Changing state to SMInSAProgress," & Environment.NewLine)
		sb.Append("From_SMInSAProgress, Changing state from SMInSAProgress" & Environment.NewLine)
		sb.Append(Environment.NewLine)
		sb.Append("To_SMFinish, Changing state to SMFinish" & Environment.NewLine)
		sb.Append("From_SMFinish, Changing state from SMFinish" & Environment.NewLine)
		sb.Append("To_SMSwipeCard, Changing state to SMSwipeCard," & Environment.NewLine)
		sb.Append("From_SMSwipeCard, Changing state from SMSwipeCard" & Environment.NewLine)
		sb.Append("To_SMCardProcessing, Changing state to SMCardProcessing," & Environment.NewLine)
		sb.Append("From_SMCardProcessing, Changing state from SMCardProcessing" & Environment.NewLine)
		sb.Append("To_SMRequestSig, Changing state to SMRequestSig," & Environment.NewLine)
		sb.Append("From_SMRequestSig, Changing state from SMRequestSig" & Environment.NewLine)
		sb.Append("To_SMTakeCard, Changing state to SMTakeCard," & Environment.NewLine)
		sb.Append("From_SMTakeCard, Changing state from SMTakeCard" & Environment.NewLine)
		sb.Append("To_SMTakeReceipt, Changing state to SMTakeReceipt," & Environment.NewLine)
		sb.Append("From_SMTakeReceipt, Changing state from SMTakeReceipt" & Environment.NewLine)
		sb.Append("To_SMThankYou, Changing state to SMThankYou," & Environment.NewLine)
		sb.Append("From_SMThankYou, Changing state from SMThankYou" & Environment.NewLine)
		sb.Append("To_SMAttract, Changing state to SMAttract," & Environment.NewLine)
		sb.Append("From_SMAttract, Changing state from SMAttract" & Environment.NewLine)
		sb.Append(Environment.NewLine)
		sb.Append("To_SMSecUnexpectedDecrease, Changing state to SMSecUnexpectedDecrease," & Environment.NewLine)
		sb.Append("From_SMSecUnexpectedDecrease, Changing state from SMSecUnexpectedDecrease" & Environment.NewLine)
		sb.Append("To_SMSecUnexpectedIncrease, Changing state to SMSecUnExpectedIncrease," & Environment.NewLine)
		sb.Append("From_SMSecUnexpectedIncrease, Changing state from SMSecUnExpectedIncrease" & Environment.NewLine)
		sb.Append("To_SMSecMisMatchWeight, Changing state to SMSecMisMatchWeight," & Environment.NewLine)
		sb.Append("From_SMSecMisMatchWeight, Changing state from SMSecMisMatchWeight" & Environment.NewLine)
		sb.Append(Environment.NewLine)
		sb.Append("To_SmAuthorization, Changing state to SMSmAuthorization," & Environment.NewLine)
		sb.Append("From_SmAuthorization, Changing state from SMSmAuthorization," & Environment.NewLine)
		sb.Append("To_SmSelectModeOfOperation, Changing state to SMSmSelectModeOfOperation," & Environment.NewLine)
		sb.Append("From_SmSelectModeOfOperation, Changing state from SMSmSelectModeOfOperation" & Environment.NewLine)
		sb.Append("To_SMSmSystemFunctions, Changing state to SMSmSystemFunctions," & Environment.NewLine)
		sb.Append("From_SMSmSystemFunctions, Changing state from SMSmSystemFunctions" & Environment.NewLine)
		sb.Append("To_SMProduceFavorites, Changing state to SMProduceFavorites," & Environment.NewLine)
		sb.Append("From_SMProduceFavorites, Changing state from SMProduceFavorites" & Environment.NewLine)
		sb.Append("To_SMEnterWeight, Changing state to SMEnterWeight," & Environment.NewLine)
		sb.Append("From_SMEnterWeight, Changing state from SMEnterWeight" & Environment.NewLine)
		sb.Append("To_SMSwipeCard, Changing state to SMSwipeCard," & Environment.NewLine)
		sb.Append("From_SMSwipeCard, Changing state from SMSwipeCard" & Environment.NewLine)
		sb.Append("To_SMProcessingTescoSCARD_WAIT, Changing state to SMProcessingTescoSCARD_WAIT," & Environment.NewLine)
		sb.Append("From_SMProcessingTescoSCARD_WAIT, Changing state from SMProcessingTescoSCARD_WAIT" & Environment.NewLine)
		sb.Append("From_TescoEXTMSG_02, Changing state from SMProcessingTescoEXTMSG_02" & Environment.NewLine)
		sb.Append("To_TescoEXTMSG_02, Changing state to SMProcessingTescoEXTMSG_02," & Environment.NewLine)
		sb.Append("From_SMCmDataEntry, Changing state from SMCmDataEntry" & Environment.NewLine)
		sb.Append("To_SMCmDataEntry, Changing state to SMCmDataEntry," & Environment.NewLine)
		sb.Append(Environment.NewLine)
		sb.Append("To_SMCashPayment, Changing state to SMCashPayment," & Environment.NewLine)
		sb.Append("From_SMCashPayment, Changing state from SMCashPayment" & Environment.NewLine)
		sb.Append("To_SMTakeChange, Changing state to SMTakeChange," & Environment.NewLine)
		sb.Append("From_SMTakeChange, Changing state from SMTakeChange" & Environment.NewLine)
		sb.Append("To_SMPickingUpItems, Changing state to SMPickingUpItems," & Environment.NewLine)
		sb.Append("From_SMPickingUpItems, Changing state from SMPickingUpItems" & Environment.NewLine)
		sb.Append("To_SMCmDataEntry, Changing state to SMCmDataEntry," & Environment.NewLine)
		sb.Append("From_SMCmDataEntry, Changing state from SMCmDataEntry" & Environment.NewLine)
		sb.Append(Environment.NewLine)
		sb.Append("To_SMSecUnexpectedDecrease, Changing state to SMSecUnexpectedDecrease," & Environment.NewLine)
		sb.Append("From_SMSecUnexpectedDecrease, Changing state from SMSecUnexpectedDecrease" & Environment.NewLine)
		sb.Append("To_SMSecMisMatchWeight, Changing state to SMSecMisMatchWeight," & Environment.NewLine)
		sb.Append("From_SMSecMisMatchWeight, Changing state from SMSecMisMatchWeight" & Environment.NewLine)
		sb.Append("To_SMSecUnExpectedIncrease, Changing state to SMSecUnExpectedIncrease," & Environment.NewLine)
		sb.Append("From_SMSecUnExpectedIncrease, Changing state from SMSecUnExpectedIncrease" & Environment.NewLine)
		sb.Append(Environment.NewLine)
		sb.Append("RED, +setTriColorLight, color = 3" & Environment.NewLine)
		sb.Append("YELLOW, +setTriColorLight, color = 2" & Environment.NewLine)
		sb.Append("GREEN, +setTriColorLight, color = 1" & Environment.NewLine)
		sb.Append("ItemScanned, Parse DM evt 0, dev 11," & Environment.NewLine)
		sb.Append("ScannerEnable, DM-DMp@3483 +DMp::Enable 11 1" & Environment.NewLine)
		sb.Append("EnterTender, TBEnterTender--nType:" & Environment.NewLine)
		sb.Append("BeginCashTender, type[text]=normal-item;description[text]=[SummaryX]Begin Cash Tender." & Environment.NewLine)
		sb.Append("Note_Inserted, type[text]=normal-item;description[text]=[SummaryX]£" & Environment.NewLine)
		sb.Append("Dispense, +CashChangerDispense - Amount" & Environment.NewLine)
		sb.Append("GetCashCounts, DMCashCount::GetCashCounts" & Environment.NewLine)
		sb.Append("Device_Error, +SMStateBase::GetDeviceErrorMnemonic()" & Environment.NewLine)
		
		createFile("config\NCR39\traces.dictionary", sb.ToString())
		Return sb.ToString()
	End Function
	
	Public Shared Function LogAnalTraceListStub() As String
		Dim sb As New StringBuilder()
		sb.Append("ADK Version : 4.04.00.0.000.339" & Environment.NewLine)
		sb.Append("Traces=Traces.log" & Environment.NewLine)
		sb.Append("PSX=psx_ScotAppU.log" & Environment.NewLine)
		sb.Append("TraceBak=Traces.log.bak" & Environment.NewLine)
		sb.Append("tbtrace=tbtrace.log" & Environment.NewLine)
		sb.Append("tbtraceBak=tbtrace.log.bak" & Environment.NewLine)
		sb.Append("paTrace=patrace.log" & Environment.NewLine)
		sb.Append("paTraceBak=patrace.log.bak" & Environment.NewLine)
		sb.Append("Sec Mgr=SM.log" & Environment.NewLine)
		sb.Append("Sec MgrBak=SM.log.bak" & Environment.NewLine)
		sb.Append("Bag Scale=OPOS_BagScale_Flintec.log" & Environment.NewLine)
		sb.Append("Bag ScaleBak=OPOS_BagScale_Flintec.log.bak" & Environment.NewLine)
		sb.Append("Scanner=OPOS_Scanner.log" & Environment.NewLine)
		sb.Append("ScannerBak=OPOS_Scanner.log.bak" & Environment.NewLine)
		sb.Append("Scanner=OPOS_Scanner.log" & Environment.NewLine)
		sb.Append("Coin Acceptor=OPOS_CoinAcceptor_CF9520.log" & Environment.NewLine)
		sb.Append("Coin AcceptorBak=OPOS_CoinAcceptor_CF9520.log.bak" & Environment.NewLine)		
		sb.Append("RCMBak=rcm.log.bak" & Environment.NewLine)
		sb.Append("RCM=rcm.log" & Environment.NewLine)
		sb.Append("DB Mgr=DbMgr.log" & Environment.NewLine)
		
		createFile("config\NCR39\LogAnalTraceList.txt", sb.ToString())
		
		Return sb.ToString()
	End Function
	
	Public Shared Function LogAnalTraceListStub2() As String
		Dim sb As New StringBuilder()
		sb.Append("ADK Version : 4.04.00.0.000.391" & Environment.NewLine)
		sb.Append("Traces=Traces.log" & Environment.NewLine)
		sb.Append("PSX=psx_ScotAppU.log" & Environment.NewLine)
		sb.Append("TraceBak=Traces.log.bak" & Environment.NewLine)
		sb.Append("tbtrace=tbtrace.log" & Environment.NewLine)
		sb.Append("tbtraceBak=tbtrace.log.bak" & Environment.NewLine)
		sb.Append("paTrace=patrace.log" & Environment.NewLine)
		sb.Append("paTraceBak=patrace.log.bak" & Environment.NewLine)
		sb.Append("Sec Mgr=SM.log" & Environment.NewLine)
		sb.Append("Sec MgrBak=SM.log.bak" & Environment.NewLine)
		sb.Append("Bag Scale=OPOS_BagScale_Flintec.log" & Environment.NewLine)
		sb.Append("Bag ScaleBak=OPOS_BagScale_Flintec.log.bak" & Environment.NewLine)
		sb.Append("Scanner=OPOS_Scanner.log" & Environment.NewLine)
		sb.Append("ScannerBak=OPOS_Scanner.log.bak" & Environment.NewLine)
		sb.Append("Scanner=OPOS_Scanner.log" & Environment.NewLine)
		sb.Append("Coin Acceptor=OPOS_CoinAcceptor_CF9520.log" & Environment.NewLine)
		sb.Append("Coin AcceptorBak=OPOS_CoinAcceptor_CF9520.log.bak" & Environment.NewLine)		
		sb.Append("RCMBak=rcm.log.bak" & Environment.NewLine)
		sb.Append("RCM=rcm.log" & Environment.NewLine)
		sb.Append("DB Mgr=DbMgr.log" & Environment.NewLine)
		
		createFile("config\NCR40\LogAnalTraceList.txt", sb.ToString())
		
		Return sb.ToString()
	End Function
	
	Public Shared Function SMDictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("Description, key=item-description.  value=" & Environment.NewLine)
		sb.Append("UnMatched_Weight, UnMatched: Weight increase of" & Environment.NewLine)
		sb.Append("Matched_Weight, << fastlane::CSecurityManager::OnMatchedWeight" & Environment.NewLine)
		sb.Append("Unexpected_Increase, UnMatched: App determined this increase of" & Environment.NewLine)
		sb.Append("Unexpected_Decrease, trace-description=Decrease not allowed" & Environment.NewLine)
		sb.Append("No_wLDB, No WLDB entries!" & Environment.NewLine)
		sb.Append("WLDB_Rqst, GetDBMgr().StartItemLookup()" & Environment.NewLine)
		sb.Append("WLDB_Resp, +/- OnDBLookupSuccess" & Environment.NewLine)
		
		createFile("config\NCR39\SM.dictionary", sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function DBMgrDictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("Update, Update for UPC:" & Environment.NewLine) 
		sb.Append("NoWldb, No WLDB Weight Info" & Environment.NewLine)
		sb.Append("NoExceptions, No Item Exception Info exists" & Environment.NewLine)
		
		createFile("config\NCR39\DBMgr.dictionary", sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function Motor1DictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("Motor1_Forward, +CNCRMotorCOCtrl::StartForward" & Environment.NewLine)
		sb.Append("Motor1_Stop, +CNCRMotorCOCtrl::Stop" & Environment.NewLine)
		sb.Append("Motor1_Reverse, +CNCRMotorCOCtrl::StartReverse" & Environment.NewLine)
		
		createFile("config\NCR39\Motor1.dictionary", sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function Motor2DictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("Motor2_Forward, +CNCRMotorCOCtrl::StartForward" & Environment.NewLine)
		sb.Append("Motor2_Stop, +CNCRMotorCOCtrl::Stop" & Environment.NewLine)
		
		createFile("config\NCR39\Motor2.dictionary", sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function NCRScannerDataCapDictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("ScannerEnable, +RequestScannerEnable" & Environment.NewLine)
		sb.Append("ScannerDisable, +RequestScannerDisable" & Environment.NewLine)
		sb.Append("ScannerScan, *EventMan::AddEvent" & Environment.NewLine)
		
		createFile("config\NCR39\NCRScannerDataCap.dictionary", sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function OPOS_ScannerNCR40DictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("ScannerEnable, +RequestScannerEnable" & Environment.NewLine)
		sb.Append("ScannerDisable, +RequestScannerDisable" & Environment.NewLine)
		sb.Append("ScannerScan, *EventMan::AddEvent" & Environment.NewLine)
		
		createFile("config\NCR39\OPOS_Scanner.dictionary", sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function OPOS_BagScale_FlintecDictionariesStub() As String
		Dim sb  As New StringBuilder()
		
		sb.Append("StableWeight, Rc = 0, RcEx = 0" & Environment.NewLine)
		sb.Append("UnStableWeight, Rc = 111, RcEx = 202" & Environment.NewLine)
		sb.Append("ScaleFilter@1, mode|raw|f1|f2, 1," & Environment.NewLine)
		sb.Append("ScaleFilter@2, mode|raw|f1|f2, 2," & Environment.NewLine)
		sb.Append("ScaleFilter@5, mode|raw|f1|f2, 5," & Environment.NewLine)
		
		createFile("config\NCR39\OPOS_BagScale_Flintec.dictionary",sb.ToString())
		
		Return sb.ToString()
	End Function
	
	Public Shared Function PatraceDictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("POS_ItemSold, [I]CPAApp@549:PAEventProc() data: <SellItemOut" & Environment.NewLine)
		sb.Append("CardDataToPOS, Operation:[PA_OP_CARD] - Data:[<CardEntryIn" & Environment.NewLine)
		sb.Append("CardMissingData, lEventCode=[2] PA_EV_DATA_MISSING  lOperationCode=[8] PA_OP_CARD" & Environment.NewLine)
		sb.Append("CardAmountToPOS, Operation:[PA_OP_CARD] - Data:[<CardEntryIn xmlns:xsi=http://www.w3.org/2001/XMLSchema-instance xsi:noNamespaceSchemaLocation=Schema\PA\CardEntryInv4.0.xsd><SaleType>normal</SaleType><TenderIn><SaleType>normal</SaleType><Amount>" & Environment.NewLine)
		sb.Append("CardEntryOut, </Description><IsCreditCard>1</IsCreditCard><SaleType>normal</SaleType></CardEntryOut>" & Environment.NewLine)
		sb.Append("CardReceipt, Operational data for msg [CARD_ENTRY_OUT_MSG] or [CLUBCARD_OUT_MSG]CardReceipt, lEventCode=[5] PA_EV_RECEIPT_DATA  lOperationCode=[8] PA_OP_CARD" & Environment.NewLine)
		sb.Append("ClubCardAcked, </Description><IsClubCard>1</IsClubCard><SaleType>normal</SaleType></CardEntryOut>" & Environment.NewLine)
		sb.Append("CardProcComplete, Processing PA_EV_OPERATION_COMPLETE - PA_OP_CARD" & Environment.NewLine)
		sb.Append("StaffDiscount, Description is STAFF DISCOUNT" & Environment.NewLine)
		sb.Append("C&P_Insert, <CardPeripherals xmlns:xsi=http://www.w3.org/2001/XMLSchema-instance><SessionId>" & Environment.NewLine)
		sb.Append("C&P_Amount, Operation:[PA_OP_CARD] - Data:[<CardEntryIn xmlns:xsi=http://www.w3.org/2001/XMLSchema-instance xsi:noNamespaceSchemaLocation=Schema\PA\CardEntryInv4.0.xsd><SessionId>2</SessionId><SaleType>normal</SaleType><TenderIn><SaleType>normal</SaleType><Amount>" & Environment.NewLine)
		sb.Append("C&P_Error, lEventCode=[3] PA_EV_ERROR  lOperationCode=[8] PA_OP_CARD" & Environment.NewLine)
		sb.Append("C&P_EndSession, Operation:[PA_OP_END_SESSION] - Data:[<EndSessionIn xmlns:xsi=http://www.w3.org/2001/XMLSchema-instance xsi:noNamespaceSchemaLocation=Schema\PA\EndSessionInv4.0.xsd><SessionId>" & Environment.NewLine)
		sb.Append("VisaCard, data: <TenderOut xmlns:xsi=http://www.w3.org/2001/XMLSchema-instance>" + "<SaleType>normal</SaleType><Description>VISA CREDIT" & Environment.NewLine)
		
		createFile("config\NCR39\patrace.dictionary",sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function PSXScotAppUDictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("EndDrawContext, EventName:ChangeContext," & Environment.NewLine)
		sb.Append("ButtonClick, EventName:Click," & Environment.NewLine)
		sb.Append("EnterQuantityDrawn, ContextName:EnterQuantity, EventName:ChangeContext," & Environment.NewLine)
		sb.Append("DrawAttract, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext," & Environment.NewLine)
		sb.Append("DrawQuickPick, RemoteConnectionName:, ControlName:Display, ContextName:QuickPickItems, EventName:ChangeContext," & Environment.NewLine)
		sb.Append("ClickPickList, RemoteConnectionName:, ControlName:ProductImage, ContextName:ProduceFavorites, EventName:Click," & Environment.NewLine)
		sb.Append("DrawContinueTrans, RemoteConnectionName:, ControlName:Display, ContextName:ContinueTrans, EventName:ChangeContext," & Environment.NewLine)
		sb.Append("ButtonClick_Attr1Lg, RemoteConnectionName:, ControlName:CMButton1Lg, ContextName:Attract, EventName:Click," & Environment.NewLine)
		
		createFile("config\NCR39\psx_ScotAppU.dictionary",sb.ToString())
		
		Return sb.ToString()
	End Function
	
	Public Shared Function SecMgrDictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("NoWts, No WLDB entries!" & Environment.NewLine)
		
		createFile("config\NCR39\SecMgr.dictionary",sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function SensorADictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("SensorA_Blocked, Status 1" & Environment.NewLine)
		sb.Append("SensorA_Clear, Status 2" & Environment.NewLine)
		
		createFile("config\NCR39\SensorA.dictionary",sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function SensorBDictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("SensorB_Blocked, Status 1" & Environment.NewLine)
		sb.Append("SensorB_Clear, Status 2" & Environment.NewLine)
		
		createFile("config\NCR39\SensorB.dictionary",sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function SensorCDictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("SensorC_Blocked, Status 1" & Environment.NewLine)
		sb.Append("SensorC_Clear, Status 2" & Environment.NewLine)
		
		createFile("config\NCR39\SensorC.dictionary",sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function SensorDDictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("SensorD_Blocked, Status 1" & Environment.NewLine)
		sb.Append("SensorD_Clear, Status 2" & Environment.NewLine)
		
		createFile("config\NCR39\SensorD.dictionary",sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function SmartScaleDictionariesStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("ScaleSent, Got wt:" & Environment.NewLine) 
		sb.Append("GotStableWeight, A STABLE weight of" & Environment.NewLine)
		sb.Append("GotScaleUnstable, A UNSTABLE weight of" & Environment.NewLine)
		sb.Append("StartSCT, In ProcessStableWeight  Wrong item was placed on the scale" & Environment.NewLine)
		sb.Append("FireUnMatchedWeight, In HandleSlowConclusionTimeout Fired Unmatched Event." & Environment.NewLine)
		sb.Append("FireMatchedWeight, In ProcessStableWeight  Fired Matched Event." & Environment.NewLine)
		sb.Append("SetSoldItemInfo_, Entering SetSoldItemInfo" & Environment.NewLine)
		sb.Append("SellingZeroWeightItem, In Detected a new zero weight item." & Environment.NewLine)
		
		createFile("config\NCR39\smartscale.dictionary",sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function TakeAwayBeltDCapDictionariesStub() As String
		Dim sb As New StringBuilder()
		
		' State Changes
		sb.Append("Tab--StateChange, Transition from" & Environment.NewLine)

		' Motor Control Actions
		sb.Append("Tab->Motor_StopBelt1, Firing Action Belt1Stop" & Environment.NewLine)
		sb.Append("Tab->Motor_StopBelt2, Firing Action Belt2Stop" & Environment.NewLine)
		sb.Append("Tab->Motor_ReverseBelt1, Firing Action Belt1Reverse" & Environment.NewLine)
		sb.Append("Tab->Motor_ForwardBelt1, Firing Action Belt1Forward" & Environment.NewLine)
		sb.Append("Tab->Motor_ForwardBelt2, Firing Action Belt2Forward" & Environment.NewLine)
		
		' Action codes from TAB SM for ScotApp
		sb.Append("Tab->App_ScannerDisable, Firing Action ScannerDisable," & Environment.NewLine)
		sb.Append("Tab->App_ScannerEnable, Firing Action EnablingScanner," & Environment.NewLine)
		sb.Append("Tab->App_BagAreaClear, Firing Action BagAreaClear," & Environment.NewLine)
		sb.Append("Tab->App_BagAreaBackup, Firing Action BagAreaBackup," & Environment.NewLine)
		sb.Append("Tab->App_RequestWeight, Firing Action RequestWeight," & Environment.NewLine)
		
		' Application Events
		sb.Append("Tab<-App_StableGoodWeight, Event 1(0x0001)," & Environment.NewLine)
		sb.Append("Tab<-App_StableBadWeight, Event 2(0x0002)," & Environment.NewLine)
		sb.Append("Tab<-App_LightItemExpected, Event 3(0x0003)," & Environment.NewLine)
		sb.Append("Tab<-App_ScaleReadsZero, Event 4(0x0004)," & Environment.NewLine)
		sb.Append("Tab<-App_ItemScan, Event 5(0x0005)," & Environment.NewLine)
		sb.Append("Tab<-App_Reset, Event 6(0x0006)," & Environment.NewLine)
		sb.Append("Tab<-App_SkipBagging, Event 7(0x0007)," & Environment.NewLine)
		sb.Append("Tab<-App_FlushAndFinish, Event 8(0x0008)," & Environment.NewLine)
		sb.Append("Tab<-App_HandleBagAreaBackup, Event 9(0x0009)," & Environment.NewLine)
		sb.Append("Tab<-App_AppRequestStopBelt, Event 10(0x000A)," & Environment.NewLine)
		
		' Sensor Events
		sb.Append("Tab<-Sensor_ARisingEdge, Event 32(0x0020)," & Environment.NewLine)
		sb.Append("Tab<-Sensor_BRisingEdge, Event 33(0x0021)," & Environment.NewLine)
		sb.Append("Tab<-Sensor_BFallingEdge, Event 34(0x0022)," & Environment.NewLine)
		sb.Append("Tab<-Sensor_CRisingEdge, Event 35(0x0023)," & Environment.NewLine)
		sb.Append("Tab<-Sensor_CFallingEdge, Event 36(0x0024)," & Environment.NewLine)
		
		' Timer definitions for TAB SM
		sb.Append("TabTimer_ItemPassByC, Event 2049(0x0801)," & Environment.NewLine)
		sb.Append("TabTimer_WaitForNextScan, Event 2050(0x0802)," & Environment.NewLine)
		sb.Append("TabTimer_BackupFlushDelay, Event 2051(0x0803)," & Environment.NewLine)
		sb.Append("TabTimer_ItemPassByB, Event 2052(0x0804)," & Environment.NewLine)
		sb.Append("TabTimer_NoItem, Event 2053(0x0805)," & Environment.NewLine)
		sb.Append("TabTimer_FlushBelts, Event 2054(0x0806)," & Environment.NewLine)
		sb.Append("TabTimer_ReverseBelt, Event 2055(0x0807)," & Environment.NewLine)
		sb.Append("TabTimer_IgnoreSensorB, Event 2056(0x0808)," & Environment.NewLine)
		sb.Append("TabTimer_Stabilize, Event 2057(0x0809)," & Environment.NewLine)
		sb.Append("TabTimer_FlushBelt2, Event 2058(0x080A)," & Environment.NewLine)
		sb.Append("TabTimer_FlatItem, Event 2059(0x080B)," & Environment.NewLine)
		sb.Append("TabTimer_DelayReadScale, Event 2060(0x080C)," & Environment.NewLine)
		sb.Append("TabTimer_WaitReadScale, Event 2061(0x080D)," & Environment.NewLine)
		sb.Append("TabTimer_FlushBelt1, Event 2062(0x080E)," & Environment.NewLine)
		sb.Append("TabTimer_UnReverseBelt, Event 2063(0x080F)," & Environment.NewLine)
		
		createFile("config\NCR39\TakeawayBeltDCap.dictionary",sb.ToString())
		
		Return sb.ToString()
	End Function
	
	Public Shared Function PatternStub_LogAnalINI() As String
		Dim sb As New StringBuilder()
		sb.Append("[AnchorStates]" & Environment.NewLine)
		sb.Append("ItemScanned" & Environment.NewLine)
		sb.Append("ClickPickList" & Environment.NewLine)
		sb.Append("To_SMFinish" & Environment.NewLine)
		sb.Append("DrawAttract" & Environment.NewLine)
		sb.Append("[Patterns]" & Environment.NewLine)
		sb.Append("Scan from Attract, ItemScanned-TB_Start-To_SMBagAndEAS, ButtonClick - RED , Category=Transaction Start,MinLowLim=3000, MinUprLim=3500, MaxLowLim=4000, MaxUprLim=5000, AvgLowLim=3000, AvgUprLim=3500" & Environment.NewLine)
		sb.Append("Start with Button, ButtonClick_Attr1Lg-TB_Start-DrawQuickPick, DrawContinueTrans - RED , Category=Transaction Start,MinLowLim=1000, MinUprLim=1500, MaxLowLim=1500, MaxUprLim=2000, AvgLowLim=1000, AvgUprLim=1500" & Environment.NewLine & Environment.NewLine)
		sb.Append("Scan Processing, ItemScanned - From_SMScanAndBag - App_Waiting, From_SMCmDataEntry - TB_Start - RED, Category=Normal Scan, MinLowLim=1000, MinUprLim=1200, MaxLowLim=3000, MaxUprLim=5000, AvgLowLim=1500, AvgUprLim=2000" & Environment.NewLine)
		sb.Append("Good Wt to Scan&Bag, Matched_Weight - To_SMScanAndBag, RED - App_Waiting , Category=Normal Scan, MinLowLim=100, MinUprLim=200, MaxLowLim=300, MaxUprLim=500, AvgLowLim=200, AvgUprLim=300" & Environment.NewLine & Environment.NewLine)
		sb.Append("PickList Display, GotoQuickPick-To_SMProduceFavorites, , Category=PickList, MinLowLim=400, MinUprLim=500, MaxLowLim=500, MaxUprLim=600, AvgLowLim=250, AvgUprLim=400" & Environment.NewLine)
		sb.Append("PickList Ask Quantity, From_SMProduceFavorites - EnterQuantityDrawn,To_SMSecUnExpectedIncrease-To_SMSecUnexpectedDecrease-To_SMSecMisMatchWeight , Category=PickList, MinLowLim=300, MinUprLim=400, MaxLowLim=500, MaxUprLim=600, AvgLowLim=400, AvgUprLim=500" & Environment.NewLine & Environment.NewLine)
		sb.Append("Quantity Item Sale, From_EnterQuantity - App_Waiting, RED, Category=Quantity Item Sale, MinLowLim=2500, MinUprLim=3500, MaxLowLim=3000, MaxUprLim=3500, AvgLowLim=2500, AvgUprLim=3000" & Environment.NewLine & Environment.NewLine)
		sb.Append("Weighted Item Sale, From_SMEnterWeight-App_Waiting, , Category=Weighted Item, MinLowLim=1000, MinUprLim=1500, MaxLowLim=2000, MaxUprLim=3500, AvgLowLim=1500, AvgUprLim=2000" & Environment.NewLine & Environment.NewLine)
		sb.Append("Weight Lookup Time, WLDB_Rqst - WLDB_Resp,From_EnterQuantity - To_SMEnterWeight , Category=Security, MinLowLim=200, MinUprLim=300, MaxLowLim=400, MaxUprLim=500, AvgLowLim=300, AvgUprLim=500" & Environment.NewLine & Environment.NewLine)
		sb.Append(Environment.NewLine & Environment.NewLine & Environment.NewLine & Environment.NewLine)
		sb.Append("Finish&Pay Display, From_SMScanAndBag-!From_SMScanAndBag-To_SMFinish, ButtonClick - To_SMScanAndBag - DrawContinueTrans , Category=Tender Select, MinLowLim=250, MinUprLim=300, MaxLowLim=300, MaxUprLim=400, AvgLowLim=300, AvgUprLim=350" & Environment.NewLine)
		sb.Append("Dispense Change, From_SMCashPayment-To_SMTakeCard-To_SMTakeChange, ButtonClick - RED , Category=Tender Cash, MinLowLim=2500, MinUprLim=3500, MaxLowLim=3500, MaxUprLim=4000, AvgLowLim=3000, AvgUprLim=3500" & Environment.NewLine)
		sb.Append("After Take Change, From_SMTakeChange - To_SMThankYou, , Category=Tender Cash, MinLowLim=100, MinUprLim=200, MaxLowLim=200, MaxUprLim=300, AvgLowLim=150, AvgUprLim=250" & Environment.NewLine)
		sb.Append("Back to Attract, From_SMThankYou-To_SMAttract, RED , Category=Transaction Finish, MinLowLim=250, MinUprLim=300, MaxLowLim=500, MaxUprLim=600, AvgLowLim=400, AvgUprLim=450" & Environment.NewLine & Environment.NewLine)
		sb.Append("Chip & Pin Processed, C&P_Insert - CardDataToPOS - CardMissingData - CardDataToPOS - CardEntryOut - CardProcComplete, C&P_Error, Category=Tender Card, MinLowLim=15000, MinUprLim=20000, MaxLowLim=30000, MaxUprLim=35000, AvgLowLim=20000, AvgUprLim=25000" & Environment.NewLine & Environment.NewLine)
		sb.Append("POS Item Sold, ItemScanned - POS_ItemSold, TB_Start - RED , Category=POS Functions, MinLowLim=1000, MinUprLim=1200, MaxLowLim=1500, MaxUprLim=2500, AvgLowLim=1500, AvgUprLim=2000" & Environment.NewLine)
		sb.Append("Club Card Processed, CardDataToPOS - ClubCardAcked - CardProcComplete , C&P_EndSession , Category=POS Functions, MinLowLim=1000, MinUprLim=1300, MaxLowLim=3000, MaxUprLim=5000, AvgLowLim=2500, AvgUprLim=3000" & Environment.NewLine)
		sb.Append("Staff Card Processed, CardDataToPOS - StaffDiscount , , Category=POS Functions,MinLowLim=3000, MinUprLim=4000, MaxLowLim=4000, MaxUprLim=5000, AvgLowLim=3500, AvgUprLim=4500" & Environment.NewLine)
		
		createFile("config\NCR39\LogAnal.ini",sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function EventValuesDictionary() As String
		Dim sb As New StringBuilder()
		
		sb.Append("ItemDetails ~ szDescription:" & Environment.NewLine)
		sb.Append("Description ~ key=item-description.  value=" & Environment.NewLine)
		sb.Append("Weight_Entered ~ io.lWeightEntered:" & Environment.NewLine)
		sb.Append("ProduceScale ~ SMState::DMScale lDMScaleWeight" & Environment.NewLine)
		sb.Append("Matched_Weight ~ wt:" & Environment.NewLine)
		sb.Append("WLDB_Lookup ~ lexpectedWt:" & Environment.NewLine)
		sb.Append("UnMatched_Weight ~ UnMatched: Weight increase of" & Environment.NewLine)
		sb.Append(";SO_StableWeight ~ Weight =" & Environment.NewLine)
		sb.Append("ScaleSent ~ Got wt:" & Environment.NewLine)
		sb.Append("StableWeight ~ Read Weight returns" & Environment.NewLine)
		sb.Append(";ScaleShift ~ Shift Factor is" & Environment.NewLine)
		sb.Append("ScaleFilter@5 ~ mode|raw|f1|f2, 5," & Environment.NewLine)
		sb.Append("SS_Event ~ PostSS SS" & Environment.NewLine)
		sb.Append("Tab--StateChange ~ Transition" & Environment.NewLine)
		sb.Append("SetSoldItemInfo ~ #0:" & Environment.NewLine)
		sb.Append("TB_ItemSold ~  <" & Environment.NewLine)
		sb.Append("Expected_Wt ~ lexpectedWt:" & Environment.NewLine)
		sb.Append("PerfMon ~ WSS=" & Environment.NewLine)
		sb.Append("EndDrawContext ~ ContextName:" & Environment.NewLine)
		sb.Append("ButtonClick ~ ControlName:" & Environment.NewLine)
		
		createFile("config\NCR39\EventValues.dictionary",sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function SummaryInfo() As String
		Dim sb As New StringBuilder()
		
		sb.Append("SOFTWARE VERSION" & Environment.NewLine)
		sb.Append("" & Environment.NewLine)
		sb.Append("Application               	: 4.04.00.0.000.339")
		
		createFile("logs\SummaryInfo.dat",sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function TerminalInfo() As String
		Dim sb As New StringBuilder()

		sb.Append("Physical Memory           	: 238 MB" & Environment.NewLine)
		sb.Append("Processor Type            	: x86 Family 15 Model 2 Stepping 9" & Environment.NewLine)
		sb.Append("Processor Speed           	: 2492 MHz" & Environment.NewLine)
		
		
		createFile("logs\TerminalInfo.dat",sb.ToString())
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function ParseEventsSample_TestReturnZero() As SignifEvents
		
		Dim parseEvent1 As New SignifEvents()
		Dim parseEvent2 As New SignifEvents()
		Dim mergeParseEvents As New SignifEvents()
		
		parseEvent1.ParseDictionary(New ExtendedStringReader(PSXScotAppUDictionariesStub()))
		parseEvent1.ParseEvents(New ExtendedStringReader(PsxStub1()))
		parseEvent2.ParseDictionary(New ExtendedStringReader(PSXScotAppUDictionariesStub()))
		parseEvent2.ParseEvents(New ExtendedStringReader(PsxStub2()))
		
'		parseEvent1.ParseDictionary(New ExtendedStringReader(TestData.PSXScotAppUDictionariesStub()))
'		parseEvent1.ParseEvents(New ExtendedStringReader("PSX_ScotAppU:05/02 05:47:58       485,568 0A24> -- PSX Start Tracing -- File version: 1.0.24.395 (continued)" & Environment.NewLine & "PSX_ScotAppU:05/05 17:25:23   301,517,919 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:QuickPickItems, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301517919)" & Environment.NewLine & _
'		"PSX_ScotAppU:05/05 17:25:41   301,536,436 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:BagAndEAS, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301536436)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:25:43   301,537,678 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:QuickPickItems, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301537678)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:25:54   301,549,104 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:CMButton4LgFinish, ContextName:QuickPickItems, EventName:Click, Param:, Consumed:0, TimeFired:301549104)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:25:56   301,551,077 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Finish, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301551077)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:26:21   301,575,833 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:TenderImage, ContextName:Finish, EventName:Click, Param:5, Consumed:0, TimeFired:301575833)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:26:21   301,576,203 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:ScanCard, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301576203)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:27:07   301,622,440 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:ButtonGoBack, ContextName:ScanCard, EventName:Click, Param:, Consumed:0, TimeFired:301622440)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:27:08   301,623,311 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Finish, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301623311)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:27:10   301,624,693 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:TenderImage, ContextName:Finish, EventName:Click, Param:2, Consumed:0, TimeFired:301624693)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:27:10   301,625,123 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:InsertCard, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301625123)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:27:13   301,628,098 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:SCARD_WAIT, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301628098)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:27:17   301,632,023 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EXTMSG_02, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301632023)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:27:27   301,641,978 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:ThankYou, EventName:ChangeContext, Param:, Consumed:0, TimeFired:30164197)" & Environment.NewLine))
'		
'		parseEvent2.ParseDictionary(New ExtendedStringReader(TestData.PSXScotAppUDictionariesStub()))
'		parseEvent2.ParseEvents(New ExtendedStringReader("PSX_ScotAppU:05/05 17:28:03   301,677,619 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301677609)" & Environment.NewLine & "PSX_ScotAppU:05/05 17:28:20   301,694,674 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:CMButton1Lg, ContextName:Attract, EventName:Click, Param:, Consumed:0, TimeFired:301694674)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:28:21   301,695,575 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:QuickPickItems, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301695575)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:28:31   301,705,679 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:BagAndEAS, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301705679)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:28:40   301,715,283 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:ButtonStoreLogIn, ContextName:BagAndEAS, EventName:Click, Param:, Consumed:0, TimeFired:301715283)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:28:40   301,715,373 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301715363)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:28:42   301,717,286 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:ButtonGoBack, ContextName:EnterID, EventName:Click, Param:, Consumed:0, TimeFired:301717286)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:28:42   301,717,296 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:BagAndEAS, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301717296)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:28:45   301,720,360 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:ButtonStoreLogIn, ContextName:BagAndEAS, EventName:Click, Param:, Consumed:0, TimeFired:301720360)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:28:45   301,720,421 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301720421)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:28:46   301,721,462 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:QuickPickItems, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301721462)" _ 
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:29:03   301,737,535 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:ThankYou, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301737535)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:29:04   301,738,777 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301738777)" _
'		& Environment.NewLine & "PSX_ScotAppU:05/05 17:30:08   301,802,589 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:CMButton1Lg, ContextName:Attract, EventName:Click, Param:, Consumed:0, TimeFired:301802589)" & Environment.NewLine))		
	
		mergeParseEvents.Merge(parseEvent1,parseEvent2) ' merge the events
		
		Return mergeParseEvents
		
	End Function
	
	Public Shared Function PsxScotAppUStub() As String
		Dim sb As New StringBuilder()
		
		sb.Append("PSX_ScotAppU:05/02 05:47:58       485,568 0A24> -- PSX Start Tracing -- File version: 1.0.24.395 (continued)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:25:23   301,517,919 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:QuickPickItems, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301517919)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:25:41   301,536,436 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:BagAndEAS, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301536436)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:25:43   301,537,678 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:QuickPickItems, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301537678)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:25:54   301,549,104 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:CMButton4LgFinish, ContextName:QuickPickItems, EventName:Click, Param:, Consumed:0, TimeFired:301549104)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:25:56   301,551,077 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Finish, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301551077)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:26:21   301,575,833 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:TenderImage, ContextName:Finish, EventName:Click, Param:5, Consumed:0, TimeFired:301575833)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:26:21   301,576,203 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:ScanCard, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301576203)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:07   301,622,440 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:ButtonGoBack, ContextName:ScanCard, EventName:Click, Param:, Consumed:0, TimeFired:301622440)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:08   301,623,311 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Finish, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301623311)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:10   301,624,693 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:TenderImage, ContextName:Finish, EventName:Click, Param:2, Consumed:0, TimeFired:301624693)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:10   301,625,123 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:InsertCard, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301625123)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:13   301,628,098 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:SCARD_WAIT, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301628098)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:17   301,632,023 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EXTMSG_02, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301632023)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:27   301,641,978 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:ThankYou, EventName:ChangeContext, Param:, Consumed:0, TimeFired:30164197)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:03   301,677,619 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301677609)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:20   301,694,674 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:CMButton1Lg, ContextName:Attract, EventName:Click, Param:, Consumed:0, TimeFired:301694674)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:21   301,695,575 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:QuickPickItems, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301695575)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:31   301,705,679 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:BagAndEAS, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301705679)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:40   301,715,283 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:ButtonStoreLogIn, ContextName:BagAndEAS, EventName:Click, Param:, Consumed:0, TimeFired:301715283)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:40   301,715,373 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301715363)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:42   301,717,286 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:ButtonGoBack, ContextName:EnterID, EventName:Click, Param:, Consumed:0, TimeFired:301717286)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:42   301,717,296 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:BagAndEAS, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301717296)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:45   301,720,360 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:ButtonStoreLogIn, ContextName:BagAndEAS, EventName:Click, Param:, Consumed:0, TimeFired:301720360)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:45   301,720,421 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301720421)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:46   301,721,462 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:QuickPickItems, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301721462)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:29:03   301,737,535 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:ThankYou, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301737535)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:29:04   301,738,777 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301738777)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:30:08   301,802,589 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:CMButton1Lg, ContextName:Attract, EventName:Click, Param:, Consumed:0, TimeFired:301802589)" & Environment.NewLine)		
		
		createFile("logs/psx_ScotAppU.log", sb.ToString())
		
		Return sb.ToString()
	End Function
	
	
	Public Shared Function PsxStub1() As String
		Dim sb As New StringBuilder()
		sb.Append("PSX_ScotAppU:05/02 05:47:58       485,568 0A24> -- PSX Start Tracing -- File version: 1.0.24.395 (continued)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:25:23   301,517,919 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:QuickPickItems, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301517919)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:25:41   301,536,436 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:BagAndEAS, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301536436)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:25:43   301,537,678 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:QuickPickItems, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301537678)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:25:54   301,549,104 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:CMButton4LgFinish, ContextName:QuickPickItems, EventName:Click, Param:, Consumed:0, TimeFired:301549104)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:25:56   301,551,077 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Finish, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301551077)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:26:21   301,575,833 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:TenderImage, ContextName:Finish, EventName:Click, Param:5, Consumed:0, TimeFired:301575833)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:26:21   301,576,203 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:ScanCard, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301576203)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:07   301,622,440 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:ButtonGoBack, ContextName:ScanCard, EventName:Click, Param:, Consumed:0, TimeFired:301622440)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:08   301,623,311 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Finish, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301623311)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:10   301,624,693 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:TenderImage, ContextName:Finish, EventName:Click, Param:2, Consumed:0, TimeFired:301624693)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:10   301,625,123 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:InsertCard, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301625123)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:13   301,628,098 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:SCARD_WAIT, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301628098)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:17   301,632,023 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EXTMSG_02, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301632023)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:27:27   301,641,978 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:ThankYou, EventName:ChangeContext, Param:, Consumed:0, TimeFired:30164197)" & Environment.NewLine)
		
		Return sb.ToString()
	End Function
	
	Public Shared Function PsxStub2() As String
		Dim sb As New StringBuilder()
		
		sb.Append("PSX_ScotAppU:05/05 17:28:03   301,677,619 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301677609)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:20   301,694,674 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:CMButton1Lg, ContextName:Attract, EventName:Click, Param:, Consumed:0, TimeFired:301694674)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:21   301,695,575 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:QuickPickItems, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301695575)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:31   301,705,679 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:BagAndEAS, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301705679)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:40   301,715,283 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:ButtonStoreLogIn, ContextName:BagAndEAS, EventName:Click, Param:, Consumed:0, TimeFired:301715283)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:40   301,715,373 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301715363)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:42   301,717,286 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:ButtonGoBack, ContextName:EnterID, EventName:Click, Param:, Consumed:0, TimeFired:301717286)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:42   301,717,296 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:BagAndEAS, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301717296)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:45   301,720,360 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:ButtonStoreLogIn, ContextName:BagAndEAS, EventName:Click, Param:, Consumed:0, TimeFired:301720360)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:45   301,720,421 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301720421)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:28:46   301,721,462 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:QuickPickItems, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301721462)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:29:03   301,737,535 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:ThankYou, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301737535)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:29:04   301,738,777 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext, Param:, Consumed:0, TimeFired:301738777)" & Environment.NewLine)
		sb.Append("PSX_ScotAppU:05/05 17:30:08   301,802,589 05A8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:CMButton1Lg, ContextName:Attract, EventName:Click, Param:, Consumed:0, TimeFired:301802589)" & Environment.NewLine)		
		
		Return sb.ToString()
	End Function
	
	Public Shared Function TracesAndSMStubs1BothNoDateNoMs() As String
		Dim sb As New StringBuilder()
		
		sb.Append("12352421) ; -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine)
		sb.Append("12355291) ; PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine)
		sb.Append("12355763) ; SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine)
		
		Return sb.ToString()
	End Function
	
	Public Shared Function TracesAndSMStubs2BothNoDateNoMs() As String
		Dim sb As New StringBuilder()
		
		sb.Append("SM:         0A24> --- Begin Data Capture --- (continued)" & Environment.NewLine)
		sb.Append("SM:     00FC> UnMatched: Weight increase of  5730. App determining if allowed..." & Environment.NewLine)
		sb.Append("SM:     00FC> Parsing key=item-description.  value=""" & Environment.NewLine)
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function TracesAndSMStubs1NoDate() As String
		Dim sb As New StringBuilder()
		
		sb.Append("12352421) ;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine)
		sb.Append("12355291) ;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine)
		sb.Append("12355763) ;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine)
		
		Return sb.ToString()
	End Function
	
	Public Shared Function TracesAndSMStubs2NoDate() As String
		Dim sb As New StringBuilder()
		
		sb.Append("SM:581,686 0A24> --- Begin Data Capture --- (continued)" & Environment.NewLine)
		sb.Append("SM:610,713,759 00FC> UnMatched: Weight increase of  5730. App determining if allowed..." & Environment.NewLine)
		sb.Append("SM:610,760,897 00FC> Parsing key=item-description.  value=""" & Environment.NewLine)
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function TracesAndSMStubs1() As String
		Dim sb As New StringBuilder()
		
		sb.Append("12352421) 06/02 21:27:04;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine)
		sb.Append("12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine)
		sb.Append("12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine)
		
		Return sb.ToString()
	End Function
	
	Public Shared Function TracesAndSMStubs2() As String
		Dim sb As New StringBuilder()
		
		sb.Append("SM: 05/02 05:49:34       581,686 0A24> --- Begin Data Capture --- (continued)" & Environment.NewLine)
		sb.Append("SM: 05/09 07:18:41   610,713,759 00FC> UnMatched: Weight increase of  5730. App determining if allowed..." & Environment.NewLine)
		sb.Append("SM: 05/09 07:19:28   610,760,897 00FC> Parsing key=item-description.  value=""" & Environment.NewLine)
		
		Return sb.ToString()
		
	End Function
	
	Public Shared Function ParseEventsSampleNoDate() As SignifEvents
		
		Dim parseEvent1 As New SignifEvents()
		Dim parseEvent2 As New SignifEvents()
		Dim mergeParseEvents As New SignifEvents()
	

		parseEvent1.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
		parseEvent1.ParseEvents(New ExtendedStringReader(TracesAndSMStubs1NoDate()))
		parseEvent2.ParseDictionary(New ExtendedStringReader(SMDictionariesStub()))
		parseEvent2.ParseEvents(New ExtendedStringReader(TracesAndSMStubs2NoDate()))
		mergeParseEvents.Merge(parseEvent1,parseEvent2)
		'MsgBox(mergeParseEvents.ListAllEvents().GetEvents(1).Item(1).Datetime.ToString())
		Return mergeParseEvents

	End Function
	
	Public Shared Function ParseEventsSampleNoDateNoMs() As SignifEvents
		
		Dim parseEvent1 As New SignifEvents()
		Dim parseEvent2 As New SignifEvents()
		Dim mergeParseEvents As New SignifEvents()
	

		parseEvent1.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
		parseEvent1.ParseEvents(New ExtendedStringReader(TracesAndSMStubs1BothNoDateNoMs()))
		parseEvent2.ParseDictionary(New ExtendedStringReader(SMDictionariesStub()))
		parseEvent2.ParseEvents(New ExtendedStringReader(TracesAndSMStubs2BothNoDateNoMs()))
		mergeParseEvents.Merge(parseEvent1,parseEvent2)

		Return mergeParseEvents

	End Function
	
	Public Shared Function ParseEventsSample() As SignifEvents
		
		Dim parseEvent1 As New SignifEvents()
		Dim parseEvent2 As New SignifEvents()
		Dim mergeParseEvents As New SignifEvents()
	

		parseEvent1.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
		parseEvent1.ParseEvents(New ExtendedStringReader(TracesAndSMStubs1()))
		parseEvent2.ParseDictionary(New ExtendedStringReader(SMDictionariesStub()))
		parseEvent2.ParseEvents(New ExtendedStringReader(TracesAndSMStubs2()))
		mergeParseEvents.Merge(parseEvent1,parseEvent2)

		Return mergeParseEvents

	End Function
	
	Public Shared Function ParseEventsSample_TestCreatesException() As SignifEvents
		
		Dim parseEvent1 As New SignifEvents()
		Dim parseEvent2 As New SignifEvents()
		Dim mergeParseEvents As New SignifEvents()
		
'		parseEvent1.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
'		parseEvent1.ParseEvents(New ExtendedStringReader("12352421) 06/02 21:27:04;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine & "12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext ) "  & Environment.NewLine & "12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine))
'		
'		parseEvent2.ParseDictionary(New ExtendedStringReader("Description, key=item-description.  value=" & Environment.NewLine & "UnMatched_Weight, UnMatched: Weight increase of" & Environment.NewLine))
'		parseEvent2.ParseEvents(New ExtendedStringReader(Nothing))
		parseEvent1.ParseDictionary(New ExtendedStringReader(TraceDictionariesStub()))
		parseEvent1.ParseEvents(New ExtendedStringReader(TracesAndSMStubs1()))
		parseEvent2.ParseDictionary(New ExtendedStringReader(SMDictionariesStub()))
		parseEvent2.ParseEvents(New ExtendedStringReader(""))
		mergeParseEvents.Merge(parseEvent1,parseEvent2)
		
		Return mergeParseEvents
	End Function
	
	Public Shared Function SampleFormLogAnalysisMain(Byval mergeEvent As SignifEvents) As formLogAnalysisMain
		Dim formLogMain As New formLogAnalysisMain
		'formLogMain.InitializeNextState(mergeEvent)
		'formLogMain.MergedTraceEvents = mergeEvent
		'formLogMain.EventsFound = mergeEvent
		formLogMain.ShowMergedTrace(mergeEvent)
		Return formLogMain
	End Function
	
	Public Shared Function createPathReports() As String
		Dim fpath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\reports\"
		If Not Directory.Exists(Path.GetDirectoryName(fpath)) Then	
			Directory.CreateDirectory(Path.GetDirectoryName(fpath))
		End If
		Return fpath
	End Function
	
	Public Shared Function createDiagPath() As String
		Dim fpath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs\"
		If Not Directory.Exists(Path.GetDirectoryName(fpath)) Then	
			Directory.CreateDirectory(Path.GetDirectoryName(fpath))
		End If
		Return fpath
	End Function
	
	Public Shared Sub createFile(filename As String, values As String)
		Dim fpath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\"	+ filename
		If Not Directory.Exists(Path.GetDirectoryName(fpath)) Then
			Directory.CreateDirectory(Path.GetDirectoryName(fpath))
		End If
		If Not File.Exists(fpath) Then
			Using sw As New StreamWriter(fpath)
				For Each line As String In values.Split(Environment.NewLine)
					sw.WriteLine(line)	
				Next				
			End Using		
		End If		
	End Sub
	
	Public Shared Sub createDictionaryFiles()
		TraceDictionariesStub()
		SmartScaleDictionariesStub()
		SMDictionariesStub()
		SecMgrDictionariesStub()
		SensorADictionariesStub()
		SensorBDictionariesStub()
		SensorCDictionariesStub()
		SensorDDictionariesStub()
		PSXScotAppUDictionariesStub()
		Motor1DictionariesStub()
		Motor2DictionariesStub()
		LogAnalTraceListStub()
		LogAnalTraceListStub2
		PatternStub_LogAnalINI()
		PatraceDictionariesStub()
		TakeAwayBeltDCapDictionariesStub()
		OPOS_BagScale_FlintecDictionariesStub()
		OPOS_ScannerNCR40DictionariesStub()
		EventValuesDictionary()
	End Sub
	
	Public Shared Sub createDictionaryFiles2()
		TraceDictionariesStub()
		SmartScaleDictionariesStub()
		SMDictionariesStub()
		SecMgrDictionariesStub()
		SensorADictionariesStub()
		SensorBDictionariesStub()
		SensorCDictionariesStub()
		SensorDDictionariesStub()
		PSXScotAppUDictionariesStub()
		Motor1DictionariesStub()
		Motor2DictionariesStub()
		LogAnalTraceListStub2()
		PatternStub_LogAnalINI()
		PatraceDictionariesStub()
		TakeAwayBeltDCapDictionariesStub()
		OPOS_BagScale_FlintecDictionariesStub()
		OPOS_ScannerNCR40DictionariesStub()
	End Sub
	
	Public Shared Sub createEventLogFile()
		PsxScotAppUStub()
	End Sub
	
	Public Shared Sub createSummaryAndTerminalInfoFiles()
		SummaryInfo()
		TerminalInfo()
	End Sub
	
	Public Shared Function ParseEventsSampleGenerateEmptyEvents() As SignifEvents
		
		Dim parseEvent1 As New SignifEvents()
		Dim parseEvent2 As New SignifEvents()
		Dim mergeParseEvents As New SignifEvents()
		
		parseEvent1.ParseDictionary(New ExtendedStringReader(SMDictionariesStub()))
		parseEvent1.ParseEvents(New ExtendedStringReader(TracesAndSMStubs1()))
		parseEvent2.ParseDictionary(New ExtendedStringReader(SMDictionariesStub()))
		parseEvent2.ParseEvents(New ExtendedStringReader(""))
		mergeParseEvents.Merge(parseEvent1,parseEvent2)
		
		Return mergeParseEvents
	End Function
	
'	End Function
End Class
