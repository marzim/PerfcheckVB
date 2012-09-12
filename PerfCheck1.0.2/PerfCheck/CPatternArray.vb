Option Strict Off
Option Explicit On
Public Class CPatternArray
	Private m_nPatternArray() As Integer
	Private m_nSize As Integer
	
	Public ReadOnly Property Item(ByVal vntIndexKey As Object) As Integer
		Get
			'UPGRADE_WARNING: Couldn't resolve default property of object vntIndexKey. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If (vntIndexKey < m_nSize) Then
				'UPGRADE_WARNING: Couldn't resolve default property of object vntIndexKey. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Item = m_nPatternArray(vntIndexKey)
			Else
				Item = 0
			End If
		End Get
	End Property
	
	'Public Function Item(nIdx As Long, nData As Long)
	'    m_nPatternArray(nIdx) = m_nPatternArray(nIdx) + nData
	'End Function
	
	'Public Property Let Size(ByVal vData As Long)
	'    m_nSize = vData
	'    ReDim m_nPatternArray(m_nSize)
	'
	'End Property
	
	Public ReadOnly Property Size() As Integer
		Get
			Size = m_nSize
		End Get
	End Property
	
	Public Sub Tally(ByRef nPatternIdx As Integer)
		Static g_nAllocSize As Integer
		If (nPatternIdx > m_nSize) Then
			If (nPatternIdx > g_nAllocSize) Then
				g_nAllocSize = nPatternIdx + 50
			End If
			ReDim Preserve m_nPatternArray(g_nAllocSize)
			m_nSize = g_nAllocSize
		End If
		m_nPatternArray(nPatternIdx) = m_nPatternArray(nPatternIdx) + 1
	End Sub
End Class