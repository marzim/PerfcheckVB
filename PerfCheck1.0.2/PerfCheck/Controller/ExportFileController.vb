'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/26/2012
' Time: 11:40 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System.IO

Public Class ExportFileController
	Dim sFullFileName As String
	
	Public Function SummaryReport(dictionaryPath As String, diagPath As String, foundEvents As SignifEvents ) As Boolean
		Dim isSuccess As Boolean = False
		If CreateSummaryReport(dictionaryPath, diagPath, foundEvents) Then
			If My.Application.CommandLineArgs.Count >= 0 Then
				Dim isOpen As Boolean = MessageService.ShowYesNo("Done exporting file in " + sFullFileName + Environment.NewLine + " Do you want to open the file?","Exporting summary report to CSV")
		        If isOpen Then
		        	Process.Start(sFullFileName)
		     	End If
			End If
			isSuccess = True
		End If        
		    
        Return isSuccess
	End Function
	
	Public Function CreateSummaryReport(dictionaryPath As String, diagPath As String, foundEvents As SignifEvents ) As Boolean
		Dim m_Templates As New CTemplates
		Dim perfmeasures As PerfMeasures
		Dim isCreated As Boolean = False
        m_Templates.Initialize(New ExtendedStreamReader(New FileStream(dictionaryPath & "\LogAnal.ini", FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default))
        m_Templates.PatternMatch(foundEvents, Nothing)
        Dim di2 As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\reports")
        If Not di2.Exists Then
        	di2.Create()
        End If
        m_Templates.cmdMakeCSVFiles(di2.FullName & "\AllPatterns", True)
        m_Templates.AddPerfMeasuresData(m_Templates.TotalPatterns, m_Templates.Patterns)
       
        perfmeasures = m_Templates.Perfmeasures
        
        Dim logevents As LogEventsSummary = m_Templates.Report()			        
        
        If logevents.GetEvents().Count > 0 Then
	        Dim csvexporter As New CsvExporter()
	        Dim di As New DirectoryInfo(diagPath)			        		        
	        
	        sFullFileName = di2.FullName + "\" + di.name + "_" + DateTime.Now.ToString("MM-dd-yyHHmmssfff") + "Report.csv"
	        csvexporter.ExportSummaryEvents(logevents, sFullFileName, perfmeasures, diagPath)     
	    	isCreated = True   
	        	
        End If
        
        Return isCreated    
        
	End Function
	
	Public Function AllMergedEvents(diagDir As String, logevents As LogEvents) As Boolean				
        Dim isSuccess As Boolean = False
        If GenerateMergedEventReport(diagDir,logevents) Then
        	If My.Application.CommandLineArgs.Count >= 0 Then
	        	Dim isOpen As Boolean = MessageService.ShowYesNo("Done exporting file in " + sFullFileName + Environment.NewLine + " Do you want to open the file?","Exporting merged event to CSV")
		        If isOpen Then
		        	Process.Start(sFullFileName)
		        End If
		    End If
		        isSuccess = True
        End If
        Return isSuccess
	End Function
	
	Public Function GenerateMergedEventReport(diagDir As String, logevents As LogEvents) As Boolean
		Dim isGenerated As Boolean = False
		Dim csvexporter As New CsvExporter()
        Dim di As New DirectoryInfo(diagDir)
        Dim di2 As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\reports")
        If Not di2.Exists Then
        	di2.Create()
        End If
        If logevents.GetEvents().Count > 0 Then
        sFullFileName= di2.FullName + "\" + di.name + "_" + DateTime.Now.ToString("MM-dd-yyHHmmssfff") + "Merged.csv" 
        csvexporter.ExportMergeEvents(logevents,sFullFileName)
        isGenerated = True
       	End If
       	'MessageService.ShowInfo(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff") + " Done exporting file in " + di2.FullName + "\" + di.name + "_" + DateTime.Now.ToString("MM-dd-yyHHmmssfff") +  "Merged.csv")
       	Return isGenerated
	End Function
End Class
