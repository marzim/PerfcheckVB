'
' Created by SharpDevelop.
' User: mc185104
' Date: 6/6/2012
' Time: 4:54 PM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
'Imports ICSharpCode.SharpZipLib.Zip
'Imports ICSharpCode.SharpZipLib.Zip.Compression.Streams
Imports System.IO
Imports System.Text.RegularExpressions
Imports Ionic.Zip

'Namespace PerfCheck
	Public Class ZipFileHelper
		
		Public Shared Sub Extract(ByVal fi As FileInfo, ByVal di As DirectoryInfo, ByVal listFilesToExtract As List(Of String))
			Using zip As ZipFile = ZipFile.Read(fi.FullName)				
				For Each filename As String In listFilesToExtract					
					For Each ze As ZipEntry In zip
						Dim filePath As String = Regex.Replace(fi.Name, fi.Extension, "") + "/" + filename
						Dim finfo As New FileInfo(di.FullName + "/" + filePath)
						If Not finfo.Exists Then
							If Regex.IsMatch(ze.FileName, filePath, RegexOptions.IgnoreCase) Then
								ze.Extract(di.FullName, True)								
							End If
						End If
					Next						
				Next
			End Using		
		End Sub
		
		Public Shared Sub Create(directoryName As String, listOfFiles As String(), optional directoryPathInArchive As String="")
			Using zip As ZipFile = New ZipFile()
				zip.AddFiles(listOfFiles, directoryPathInArchive)
				zip.Save(directoryName)
			End Using
		End Sub
		
	End Class
'End Namespace

