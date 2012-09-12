'
' Created by SharpDevelop.
' User: mc185104
' Date: 8/2/2012
' Time: 10:50 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Class MeasurementDetailEventArgs
	Inherits EventArgs
	
	Public Sub New(i As Integer)
		Index = i
	End Sub
	
	Public ReadOnly Index As Integer
	
	
End Class
