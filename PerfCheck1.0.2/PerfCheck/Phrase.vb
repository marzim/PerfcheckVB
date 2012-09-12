Option Strict Off
Option Explicit On
Public Class Phrase
	
	'local variable(s) to hold property value(s)
	Private mvarPhrase As String 'local copy
	Private mvarAliasName As String 'local copy
	Private mvarNameIndex As Integer
	
	
	Public Property NameIndex() As Integer
		Get
			NameIndex = mvarNameIndex
		End Get
		Set(ByVal Value As Integer)
			mvarNameIndex = Value
		End Set
	End Property
	
	
	Public Property AliasName() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.AliasName
			AliasName = mvarAliasName
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.AliasName = 5
			mvarAliasName = Value
		End Set
	End Property
	
	
	
	
    'tom was here'
    Public Property Phrase() As String
        Get
            'used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.Phrase
            Phrase = mvarPhrase
        End Get
        Set(ByVal Value As String)
            'used when assigning a value to the property, on the left side of an assignment.
            'Syntax: X.Phrase = 5
            mvarPhrase = Value
        End Set
    End Property
End Class