Option Strict Off
Option Explicit On
Public Class CPatternState
	
	Private mvarStateName As String 'local copy
    Private mvareStateName As Integer 'local copy
    Private mvarTimeMs As UInt64  ' index of max if found
    Private mvarCollectionIndex As Integer  'index into events collection
	
    Public Property CollectionIndex() As Integer
        Get
            CollectionIndex = mvarCollectionIndex
        End Get
        Set(ByVal Value As Integer)
            mvarCollectionIndex = Value
        End Set
    End Property

    Public Property TimeMs() As UInt64
        Get
            TimeMs = mvarTimeMs
        End Get
        Set(ByVal Value As UInt64)
            mvarTimeMs = Value
        End Set
    End Property

	Public Property eStateName() As Integer
		Get
			eStateName = mvareStateName
		End Get
		Set(ByVal Value As Integer)
			mvareStateName = Value
		End Set
	End Property
	
	
    Public Property StateName() As String
        Get
            StateName = mvarStateName
        End Get
        Set(ByVal Value As String)
            mvarStateName = Value
        End Set
    End Property

End Class