Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid

Namespace WindowsApplication53
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private fieldValueEnumerator As List(Of Object)
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			PopulateTable()
			pivotGridControl1.RefreshData()

			fieldYear.BestFit()
			fieldDate.BestFit()

		End Sub

		Private Function CreateFieldValueEnumerator(ByVal pivot As PivotGridControl, ByVal field As PivotGridField) As List(Of Object)
			Dim enumerator As New List(Of Object)()
			For columnIndex As Integer = 0 To pivot.Cells.ColumnCount - 1
				Dim columnValue As Object = pivot.GetFieldValue(field, columnIndex)
				If (Not enumerator.Contains(columnValue)) Then
					enumerator.Add(columnValue)
				End If
			Next columnIndex
			Return enumerator
		End Function
		Private Sub PopulateTable()
			Dim myTable As DataTable = dataSet1.Tables("Data")
			myTable.Rows.Add(New Object() {"Aaa", DateTime.Today, 7})
			myTable.Rows.Add(New Object() { "Aaa", DateTime.Today.AddDays(1), 4 })
			myTable.Rows.Add(New Object() { "Bbb", DateTime.Today, 12 })
			myTable.Rows.Add(New Object() { "Bbb", DateTime.Today.AddDays(1), 14 })
			myTable.Rows.Add(New Object() { "Ccc", DateTime.Today, 11 })
			myTable.Rows.Add(New Object() { "Ccc", DateTime.Today.AddDays(1), 10 })

			myTable.Rows.Add(New Object() { "Aaa", DateTime.Today.AddYears(1), 4 })
			myTable.Rows.Add(New Object() { "Aaa", DateTime.Today.AddYears(1).AddDays(1), 2 })
			myTable.Rows.Add(New Object() { "Bbb", DateTime.Today.AddYears(1), 3 })
			myTable.Rows.Add(New Object() { "Bbb", DateTime.Today.AddDays(1).AddYears(1), 1 })
			myTable.Rows.Add(New Object() { "Ccc", DateTime.Today.AddYears(1), 8 })
			myTable.Rows.Add(New Object() { "Ccc", DateTime.Today.AddDays(1).AddYears(1), 22 })

			myTable.Rows.Add(New Object() { "Aaa", DateTime.Today.AddYears(4), 4 })
			myTable.Rows.Add(New Object() { "Bbb", DateTime.Today.AddYears(4), 3 })
			myTable.Rows.Add(New Object() { "Ccc", DateTime.Today.AddYears(4), 8 })

			myTable.Rows.Add(New Object() { "Bbb", DateTime.Today.AddDays(1).AddYears(3), 1 })
			myTable.Rows.Add(New Object() { "Aaa", DateTime.Today.AddDays(1).AddYears(3), 2 })
			myTable.Rows.Add(New Object() { "Ccc", DateTime.Today.AddDays(1).AddYears(3), 22 })
		End Sub

		Private Sub pivotGridControl1_CustomAppearance(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotCustomAppearanceEventArgs) Handles pivotGridControl1.CustomAppearance
			If Object.ReferenceEquals(e.ColumnField, fieldDate) AndAlso fieldValueEnumerator IsNot Nothing Then
				If fieldValueEnumerator.IndexOf(e.GetFieldValue(fieldYear)) Mod 2 > 0 Then
					e.Appearance.BackColor = Color.GreenYellow
				Else
					e.Appearance.BackColor = Color.Gold
				End If
			End If
		End Sub

		Private Sub pivotGridControl1_GridLayout(ByVal sender As Object, ByVal e As EventArgs) Handles pivotGridControl1.GridLayout
			fieldValueEnumerator = CreateFieldValueEnumerator(pivotGridControl1, fieldYear)
		End Sub

	End Class
End Namespace