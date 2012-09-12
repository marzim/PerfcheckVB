'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/30/2012
' Time: 6:32 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Class ProgressEventArgs
	Inherits EventArgs
	Public Sub New(_min As Integer, _max As Long,_value As Long, optional _text As String="")
		value = _value
		min = _min
		max = _max
		text = _text
	End Sub
	Public ReadOnly value As Long
	Public ReadOnly max As Long
	Public ReadOnly min As Integer
	Public readonly text As String
	
End Class
