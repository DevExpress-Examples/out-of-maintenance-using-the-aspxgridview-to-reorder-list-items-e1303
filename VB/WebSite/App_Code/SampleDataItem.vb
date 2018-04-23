Imports Microsoft.VisualBasic
Imports System

Public Class SampleDataItem
	Private m_pos As Integer
	Private m_title As String
	Private m_quantity As Integer
	Private m_pk As Guid

	Public Sub New(ByVal title As String, ByVal quantity As Integer)
		m_pk = Guid.NewGuid()
		m_title = title
		m_quantity = quantity
	End Sub

	Public ReadOnly Property Pk() As Guid
		Get
			Return m_pk
		End Get
	End Property
	Public ReadOnly Property Title() As String
		Get
			Return m_title
		End Get
	End Property
	Public ReadOnly Property Quantity() As Integer
		Get
			Return m_quantity
		End Get
	End Property
End Class
