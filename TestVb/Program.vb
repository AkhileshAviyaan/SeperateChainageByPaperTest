Imports System.Globalization
Imports System.Numerics
Imports System.Security.Cryptography.X509Certificates
Imports System.Text.RegularExpressions

Public Class ChainageElevationGroup
	Public Elevation As Double
	Public Chainage As Double
End Class
Public Class Program
	Public Shared paperLength = 4
	Public Shared paperHeight = 10
	Public Shared Sub Main()
		Dim group1 = New List(Of ChainageElevationGroup)()
		Dim seperatedGroup = New List(Of List(Of ChainageElevationGroup))()
		Dim array As Double(,) = {{0, 10}, {1, 12}, {2, 8}, {3, 16}, {4, 18}, {5, 10}, {6, 20}, {7, 22}, {8, 24}, {9, 20}, {10, 22}, {11, 24}}

		' Use a standard For loop to access rows properly
		For i As Integer = 0 To array.GetLength(0) - 1
			Dim obj = New ChainageElevationGroup()
			obj.Chainage = array(i, 0) ' Correctly access row elements
			obj.Elevation = array(i, 1)
			group1.Add(obj)
		Next

		SeperateByPaper(group1, seperatedGroup)
	End Sub
	Public Shared Sub SeperateByPaper(group1 As List(Of ChainageElevationGroup), ByRef seperatedgroup As List(Of List(Of ChainageElevationGroup)))

		Dim lastIndex = group1.Count() - 1

		For i As Integer = 0 To lastIndex Step 1
			Dim Index = Math.Min(ChainageListConsideringPaperHeight(group1, i), ChainageListConsideringPaperLength(group1, i))
			Dim sg = group1.GetRange(i, Index + 1 - i)
			seperatedgroup.Add(sg)
			i = Index
		Next

	End Sub
	Public Shared Function ChainageListConsideringPaperHeight(group1 As List(Of ChainageElevationGroup), startIndex As Integer) As Integer
		If group1.Count() < 2 Then Return startIndex
		Dim minElevation = group1(startIndex).Elevation
		Dim maxElevation = group1(startIndex).Elevation
		Dim lastIndex = group1.Count() - 1
		Dim EndIndex As Integer
		For i As Integer = startIndex To lastIndex - 1 Step 1
			Dim e1 = group1(i).Elevation
			Dim e2 = group1(i + 1).Elevation
			If e2 > e1 Then
				maxElevation = e2
			Else
				minElevation = e2
			End If
			Dim DiffElevation = Math.Abs(maxElevation - minElevation) 'After this scale it
			If maxElevation < paperLength Then
				EndIndex = i
				Exit For
			End If
		Next
		Return (EndIndex)
	End Function
	Public Shared Function ChainageListConsideringPaperLength(group1 As List(Of ChainageElevationGroup), startIndex As Integer) As Integer
		If group1.Count() < 2 Then Return startIndex
		Dim minChainage = group1(startIndex).Chainage
		Dim maxChainage = group1(startIndex).Chainage
		Dim lastIndex = group1.Count() - 1
		Dim EndIndex As Integer
		For i As Integer = startIndex To lastIndex Step 1
			maxChainage = group1(i).Chainage
			Dim diffChainage = maxChainage - minChainage 'After this scale it
			If diffChainage < paperLength Then
				EndIndex = i
				Exit For
			End If
		Next
		Return (EndIndex)
	End Function
End Class

