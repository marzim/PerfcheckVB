'
' Created by SharpDevelop.
' User: mc185104
' Date: 5/29/2012
' Time: 11:11 PM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports Microsoft.VisualBasic.FileIO
Imports System.Collections.Generic

Namespace PerfCheck
	Public Class CsvImporter
		
		Public Function Import(ByVal fileName As String) as LogEvents
			Dim logevents As new LogEvents()
			Using reader As New TextFieldParser(fileName)
				reader.TextFieldType = FieldType.Delimited
				reader.SetDelimiters(","c)
				Dim currRow As String()
				While Not reader.EndOfData
					Try
						logevents = new LogEvents()
						Dim logevent as New LogEvent()
						currRow = reader.ReadFields()
						logevent.RelTime = currRow(0)
						logevent.Datetime = currRow(1)
						logevent.Millisec = currRow(2)
						logevent.Source = currRow(3)
						logevent.Lineno = currRow(4)
						logevent.Events = currRow(5)
						'add another row for the data column
						'logevent.Events = currRow(6)
						
						logevents.Add(logevent)
					Catch ex As MalformedLineException
						MessageService.ShowError("Line " & ex.Message & " is not valid and will be skipped.", "Error in Import()")						
					End Try
				End While
				
			End Using
			return logevents
		End Function
		
	End Class
End Namespace

