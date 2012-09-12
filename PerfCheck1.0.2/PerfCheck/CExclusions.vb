Option Strict Off
Option Explicit On
'Namespace PerfCheck
Public Class CExclusions
    Implements System.Collections.IEnumerable

    'local variable to hold collection
    Private mCol As Collection

 
    Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As CPatternState
        Get
            Item = mCol.Item(vntIndexKey)
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Count = mCol.Count()
        End Get
    End Property

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        GetEnumerator = mCol.GetEnumerator
    End Function

 
    Public Function Add(ByRef eStateName As Integer, Optional ByRef sKey As String = "") As CPatternState
    	'create a new object
    	Try
        Dim objNewMember As CPatternState
        objNewMember = New CPatternState
		
        'set the properties passed into the method
        objNewMember.eStateName = eStateName
        objNewMember.StateName = StateCode2Name(eStateName)
        If Len(sKey) = 0 Then
            mCol.Add(objNewMember)
        Else
            mCol.Add(objNewMember, sKey)
        End If

        'return the object created
        Add = objNewMember
        objNewMember = Nothing
    	Catch ex1 As NullReferenceException
    		Throw New NullReferenceException(ex1.Message)

		End Try
    End Function

    Public Sub Remove(ByRef vntIndexKey As Object)
        mCol.Remove(vntIndexKey)
    End Sub

    Private Sub Class_Initialize_Renamed()
        'creates the collection when this class is created
        mCol = New Collection
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    Private Sub Class_Terminate_Renamed()
        'destroys collection when this class is terminated
        Dim n As Integer
        For n = 1 To mCol.Count()
            mCol.Remove((1))
        Next
        mCol = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub

End Class
'End Namespace
