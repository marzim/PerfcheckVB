Option Strict Off
Option Explicit On
Public Class CStatistics
	
	'local variable(s) to hold property value(s)
    Private mvarvMax As Double 'local copy
    Private mvarvMin As Double 'local copy
	Private mvarsName As String
	Private mvardSumX As Double
	Private mvardSumXSq As Double
	Private mvarnCount As Integer
	Const c As String = ","
	
	Public Sub Clear()
		mvardSumX = 0#
		mvardSumXSq = 0#
		mvarnCount = 0
        mvarvMax = 0.0#
        mvarvMin = 0.0#
	End Sub
	
    Public Function Report() As String
        Report = " Cnt:" & Str(mvarnCount) & " Min:" & Str(Me.Min) & " Max:" & Str(Me.Max) & " Avg:" & Me.Average.ToString("F2") & " SD:" & Me.StdDev.ToString("F2")
    End Function
    Public Function Report(ByRef dgr() As String, ByRef flags() As Integer, ByVal nMinHiLim As Integer, ByVal nMinLoLim As Integer, ByVal nMaxHiLim As Integer, ByVal nMaxLoLim As Integer, ByVal dAvgHiLim As Double, ByVal dAvgLoLim As Double) As String
        Dim sMinFlg As String = ""
        Dim sMaxFlg As String = ""
        Dim sAvgFlg As String = ""
	Try
        dgr(1) = Str(mvarnCount)
        dgr(2) = Str(Me.Min)
        flags(2) = 0
        If (Me.Min > nMinLoLim) Then
            sMinFlg = "*"
            flags(2) = 1
        End If
        If (Me.Min > nMinHiLim) Then
            sMinFlg = "**"
            flags(2) = 2
        End If

        dgr(3) = Str(Me.Max)
        flags(3) = 0
        If (Me.Max > nMaxLoLim) Then
            sMaxFlg = "*"
            flags(3) = 1
        End If
        If (Me.Max > nMaxHiLim) Then
            sMaxFlg = "**"
            flags(3) = 2
        End If

        dgr(4) = Me.Average.ToString("F2")
        flags(4) = 0
        If (Me.Average > dAvgLoLim) Then
            sAvgFlg = "*"
            flags(4) = 1
        End If
        If (Me.Average > dAvgHiLim) Then
            sAvgFlg = "**"
            flags(4) = 2
        End If

        dgr(5) = Me.StdDev.ToString("F2")
        Report = " Cnt:" & Str(mvarnCount) & " Min:" & Str(Me.Min) & sMinFlg & " Max:" & Str(Me.Max) & sMaxFlg & " Avg:" & Me.Average.ToString("F2") & sAvgFlg & " SD:" & Me.StdDev.ToString("F2")
	Catch ex As IndexOutOfRangeException
		Throw New IndexOutOfRangeException()
	End Try
    End Function


    Public Function CSV_Labels() As String
        CSV_Labels = mvarsName & "Count," & mvarsName & "Min," & mvarsName & "Max," & mvarsName & "Mean," & mvarsName & "StdDev,"
    End Function
	
	Public Function CSV_Data() As String
		CSV_Data = Str(mvarnCount) & c & Str(Me.Min) & c & Str(Me.Max) & c & Str(Math.Floor(Me.Average)) & c & Str(Math.Floor(Me.StdDev)) & c
	End Function
    Public Function Accumulate(ByVal x As Double) As Boolean
        Dim dX As Double
        dX = CDbl(x)
        If (mvarnCount = 0) Then
            mvarvMax = x
            mvarvMin = x
        Else
            If (x > mvarvMax) Then mvarvMax = x
            If (x < mvarvMin) Then mvarvMin = x
        End If
        mvarnCount = mvarnCount + 1
        mvardSumX = mvardSumX + dX
        mvardSumXSq = mvardSumXSq + dX * dX
    End Function

    Public Sub LumpStats(ByRef obj As CStatistics)
        mvarvMax = mvarvMax + obj.Max
        mvarvMin = mvarvMin + obj.Min
        mvarnCount = mvarnCount + obj.Count
        mvardSumX = mvardSumX + obj.Sum
    End Sub
	
	Public ReadOnly Property Count() As Integer
		Get
			Count = mvarnCount
		End Get
	End Property
	Public ReadOnly Property StdDev() As Double
		Get
			If (mvarnCount > 1) Then
				StdDev = System.Math.Sqrt(((CDbl(mvarnCount) * mvardSumXSq) - (mvardSumX * mvardSumX)) / (CDbl(mvarnCount * (mvarnCount - 1))))				
			Else
				StdDev = 0#
			End If
		End Get
	End Property
	
	Public ReadOnly Property Average() As Double
		Get
            If (mvarnCount > 0) Then
                Average = mvardSumX / CDbl(mvarnCount)
            Else
                Average = 0.0#
            End If
		End Get
	End Property
	
	Public ReadOnly Property Min() As Object
		Get
            Min = mvarvMin
		End Get
	End Property
	
	Public ReadOnly Property Max() As Object
		Get
            Max = mvarvMax
		End Get
	End Property
	
	Public ReadOnly Property Sum() As Double
		Get
			Sum = mvardSumX
		End Get
	End Property
	
	Public WriteOnly Property sName() As String
		Set(ByVal Value As String)
			mvarsName = Value
		End Set
	End Property
End Class