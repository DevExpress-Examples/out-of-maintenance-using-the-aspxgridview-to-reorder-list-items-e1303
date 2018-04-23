Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Overrides Sub OnInit(ByVal e As EventArgs)
		MyBase.OnInit(e)
		grid.DataSource = Data
		grid.DataBind()
		If (Not IsPostBack) Then
			grid.Selection.SelectRow(3)
			grid.Selection.SelectRow(4)
			grid.Selection.SelectRow(8)
			grid.Selection.SelectRow(10)
		End If
	End Sub

	Private ReadOnly Property Data() As List(Of SampleDataItem)
		Get
			Const key As String = "4c92cd2e-241b-49e7-8a13-92a64132b16c"
			If Session(key) Is Nothing Then
				Session(key) = CreateData()
			End If
			Return CType(Session(key), List(Of SampleDataItem))
		End Get
	End Property

	Private Function CreateData() As List(Of SampleDataItem)
		Dim result As List(Of SampleDataItem) = New List(Of SampleDataItem)()
		result.Add(New SampleDataItem("Chai", 39))
		result.Add(New SampleDataItem("Chang", 17))
		result.Add(New SampleDataItem("Aniseed Syrup", 13))
		result.Add(New SampleDataItem("Chef Anton's Cajun Seasoning", 53))
		result.Add(New SampleDataItem("Chef Anton's Gumbo Mix", 0))
		result.Add(New SampleDataItem("Grandma's Boysenberry Spread", 120))
		result.Add(New SampleDataItem("Uncle Bob's Organic Dried Pears", 15))
		result.Add(New SampleDataItem("Northwoods Cranberry Sauce", 6))
		result.Add(New SampleDataItem("Mishi Kobe Niku", 29))
		result.Add(New SampleDataItem("Ikura", 31))
		result.Add(New SampleDataItem("Queso Cabrales", 22))
		result.Add(New SampleDataItem("Queso Manchego La Pastora", 86))
		result.Add(New SampleDataItem("Konbu", 24))
		result.Add(New SampleDataItem("Tofu", 35))
		result.Add(New SampleDataItem("Genen Shouyu", 39))
		result.Add(New SampleDataItem("Pavlova", 29))
		Return result
	End Function

	Protected Sub grid_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		If e.Parameters = "up" Then
			MoveSelection(-1)
		End If
		If e.Parameters = "down" Then
			MoveSelection(1)
		End If
	End Sub

	Private Sub MoveSelection(ByVal offset As Integer)
		If grid.Selection.Count < 1 Then
			Return
		End If
		If (Not CanMoveSelection(offset)) Then
			Return
		End If

		Dim count As Integer = Data.Count
		Dim temp(count - 1) As SampleDataItem
		For i As Integer = 0 To count - 1
			If grid.Selection.IsRowSelected(i) Then
				temp(i + offset) = Data(i)
			End If
		Next i
		Dim index As Integer = 0
		For i As Integer = 0 To count - 1
			If grid.Selection.IsRowSelected(i) Then
				Continue For
			End If
			Do While temp(index) IsNot Nothing
				index += 1
			Loop
			temp(index) = Data(i)
			index += 1
		Next i

		Data.Clear()
		Data.AddRange(temp)
		grid.DataBind()
		' Optionally persist the list
	End Sub
	Private Function CanMoveSelection(ByVal offset As Integer) As Boolean
		Dim minIndex As Integer = Integer.MaxValue
		Dim maxIndex As Integer = Integer.MinValue
		For i As Integer = 0 To grid.VisibleRowCount - 1
			If (Not grid.Selection.IsRowSelected(i)) Then
				Continue For
			End If
			If i < minIndex Then
				minIndex = i
			End If
			If i > maxIndex Then
				maxIndex = i
			End If
		Next i
		Return minIndex + offset > -1 AndAlso maxIndex + offset < grid.VisibleRowCount
	End Function
End Class
