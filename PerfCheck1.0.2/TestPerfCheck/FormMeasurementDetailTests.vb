'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/27/2012
' Time: 2:19 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.Reflection

<TestFixture> _
Public Class FormMeasurementDetailTests
	
	Private frmMeasurementDtl As formMeasurementDetail
	Private frmLogAnalSrch As formLogAnalSearch	
	
	<SetUp()> _
	Public Sub SetUp()
		MessageService.Attach(New ConsoleMessageProvider())		
						
		frmMeasurementDtl = New formMeasurementDetail()
		frmMeasurementDtl.DiagPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs"
		frmMeasurementDtl.SMeasure = "Scan Processing"
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()	
		frmMeasurementDtl = Nothing
	End Sub	
	
	<Test> _
	Public Sub TestMeasurementDetail()
		'Dim frmMeasurementDtl As New formMeasurementDetail()
		
		frmMeasurementDtl.FormMeasurementDetailLoad(Nothing, Nothing)
		frmMeasurementDtl.ReportMeasureTextBoxTextChanged(Nothing, Nothing)
		frmMeasurementDtl.Show()
		frmMeasurementDtl.Close()
	End Sub
	
	<Test> _
	Public Sub TestCancelButtonClick()
		
		' Get the constructor and create an instance of formMeasurementDetail
		Dim frmMeasurementDetail As formMeasurementDetail = New formMeasurementDetail()
		Dim type As Type = frmMeasurementDtl.GetType()
		Dim frmMeasurementDetailConstructor As ConstructorInfo = type.GetConstructor(Type.EmptyTypes)
        Dim frmMeasurementDetailClassObject As Object = frmMeasurementDetailConstructor.Invoke(New Object(){})

		' Get the Cancel_Button_Click method and invoke with a parameter value of Nothing
		Dim dynamicMethod As MethodInfo = type.GetMethod("Cancel_Button_Click", BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
        dynamicMethod.Invoke(frmMeasurementDetailClassObject, New Object(){Nothing, Nothing})

	End Sub
	
	'<Test> _
	'Public Sub TestdgMeasureDetails_CellDoubleClick()
		
	'	' Get the constructor and create an instance of formMeasurementDetail
	'	Dim frmMeasurementDetail As formMeasurementDetail = New formMeasurementDetail()
	'	Dim type As Type = frmMeasurementDtl.GetType()
	'	Dim frmMeasurementDetailConstructor As ConstructorInfo = type.GetConstructor(Type.EmptyTypes)
	'	Dim frmMeasurementDetailClassObject As Object = frmMeasurementDetailConstructor.Invoke(New Object(){})
	'	
	'	Dim mEvent As New DataGridViewCellEventArgs(7,7)
	'	Dim contcolumn As New DataGridViewTextBoxColumn

	'	Dim dg As New DataGridView()
		
	'	'dg.Columns.Insert(0,contcolumn)
	'	'dg.Columns.Insert(1,contcolumn)
		
	'	Dim data As String() = New String() {"1", "2", "3", "4"}
	'	dg.ColumnCount = 6

	'	dg.Rows.Add(data)
	'	dg.Refresh()
	'	dg.CurrentCell = dg.Item(1,0)

		'If (dg.CurrentCell.Value = "") Then
		'	MessageBox.Show(dg.CurrentCell.Value) 
	 	'Else
	 	'	Console.WriteLine("else false")  
 		'End If

		' Get the dgMeasureDetails_CellDoubleClick method and invoke with a parameter value of Nothing
	'	Dim dynamicMethod As MethodInfo = type.GetMethod("dgMeasureDetails_CellDoubleClick", BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
	'	dynamicMethod.Invoke(frmMeasurementDetailClassObject, New Object(){dg, mEvent})

	'End Sub
	
	<Test> _
	Public Sub TestEmptydgMeasureDetails_CellDoubleClick()
		
		' Get the constructor and create an instance of formMeasurementDetail
		Dim frmMeasurementDetail As formMeasurementDetail = New formMeasurementDetail()
		Dim type As Type = frmMeasurementDtl.GetType()
		Dim frmMeasurementDetailConstructor As ConstructorInfo = type.GetConstructor(Type.EmptyTypes)
		Dim frmMeasurementDetailClassObject As Object = frmMeasurementDetailConstructor.Invoke(New Object(){})
		
		Dim mEvent As New DataGridViewCellEventArgs(0, 0)
		Dim contcolumn As New DataGridViewTextBoxColumn

		Dim dg As New DataGridView()
		dg.Columns.Insert(0,contcolumn)
		dg.Rows.Add("")
		dg.Refresh()
		dg.CurrentCell = dg.Item(0,0)

		'If (dg.CurrentCell.Value = "") Then
		'	MessageBox.Show(dg.CurrentCell.Value) 
	 	'Else
	 	'	Console.WriteLine("else false")  
 		'End If

		' Get the dgMeasureDetails_CellDoubleClick method and invoke with a parameter value of Nothing
		Dim dynamicMethod As MethodInfo = type.GetMethod("dgMeasureDetails_CellDoubleClick", BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
		dynamicMethod.Invoke(frmMeasurementDetailClassObject, New Object(){dg, mEvent})

	End Sub
	
End Class
