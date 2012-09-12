'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/27/2012
' Time: 2:33 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.Reflection

<TestFixture> _
Public Class FormSearchStringTests
	
	Private frmSearchStr As formSearchString
	Private KeyCode As Keys
	
	<SetUp()> _
	Public Sub SetUp()
		MessageService.Attach(New ConsoleMessageProvider())
		frmSearchStr = New formSearchString()
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()	
		frmSearchStr = Nothing
	End Sub
	
	<Test> _
	Public Sub TestFormSearchString()
		
		frmSearchStr.Show()
		Dim keyEvent  = New KeyEventArgs(Keys.Escape)		
		frmSearchStr.txtsearch_keydown(Nothing, keyEvent)
		keyEvent  = New KeyEventArgs(Keys.Enter)
		frmSearchStr.txtsearch_keydown(Nothing, keyEvent)
		Assert.IsEmpty(frmSearchStr.SearchText)
		frmSearchStr.Close()
	End Sub
	
	<Test> _
	Public Sub TestOKButton_Click()
		
		Dim type As Type = frmSearchStr.GetType()

		' Get the dgMeasureDetails_CellDoubleClick method and invoke with a parameter value of Nothing
		Dim dynamicMethod As MethodInfo = type.GetMethod("OKButton_Click", BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
		dynamicMethod.Invoke(frmSearchStr, New Object(){Nothing, Nothing})
		Assert.IsTrue(frmSearchStr.SearchOK)
	End Sub
	
	<Test> _
	Public Sub TestCancelButton_Click()
		
		Dim type As Type = frmSearchStr.GetType()

		' Get the dgMeasureDetails_CellDoubleClick method and invoke with a parameter value of Nothing
		Dim dynamicMethod As MethodInfo = type.GetMethod("CancelButton_Click", BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
		dynamicMethod.Invoke(frmSearchStr, New Object(){Nothing, Nothing})
		Assert.IsFalse(frmSearchStr.SearchOK)
	End Sub
	
	<Test> _
	Public Sub TestSearchText()	

		Dim type As Type = frmSearchStr.GetType()

		For Each prop As PropertyInfo in type.GetProperties
           Console.WriteLine(prop.Name)
           If Not prop.CanWrite
               Console.WriteLine("   (Read only)")
           End If
       Next prop
	End Sub
	
End Class
