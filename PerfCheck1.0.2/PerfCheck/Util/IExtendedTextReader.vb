'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/13/2012
' Time: 3:03 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Interface IExtendedTextReader
	
	ReadOnly Property Length() As Long
	
	ReadOnly Property Position() As Long
	
	Function ReadLine() As String
	
	Sub Close()
	
End Interface
