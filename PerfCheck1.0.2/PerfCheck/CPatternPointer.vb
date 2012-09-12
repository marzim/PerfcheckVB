Option Strict On
Option Explicit On

Public Class CPatternPointer
    Private m_nCollectionIndex As Integer
    Private m_nDuration As Double

    Public Property CollectionIndex() As Integer
        Get
            CollectionIndex = m_nCollectionIndex
        End Get
        Set(ByVal Value As Integer)
            m_nCollectionIndex = Value
        End Set
    End Property

    Public Property TimeMs() As Double
        Get
            TimeMs = m_nDuration
        End Get
        Set(ByVal Value As Double)
            m_nDuration = Value
        End Set
    End Property

End Class
