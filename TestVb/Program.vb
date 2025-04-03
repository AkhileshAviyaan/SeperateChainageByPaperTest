Imports System.Globalization
Imports System.Numerics
Imports System.Security.Cryptography.X509Certificates
Imports System.Text.RegularExpressions

Public Class ChainageElevationGroup
	Public Elevation As Double
	Public Chainage As Double
End Class
Public Class Program
	Public paperLength = 4
	Public paperHeight = 10
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

		Dim lastIndex = group1.Count()
		Dim minChainage As Double
		Dim maxChainage As Double
		Dim minElevation As Double
		Dim maxElevation As Double
		minChainage = group1(0).Chainage
		minChainage = group1(0).Chainage
		minElevation = group1(0).Elevation
		minElevation = group1(0).Elevation
		If group1.Count < 2 Then Return

		Dim startIndex As Integer = 0

		Dim listFromChainge = New List(Of ChainageElevationGroup)
		For i As Integer = startIndex To lastIndex - 1 Step 1
			maxChainage = group1(i).Chainage
			listFromChainge.Add(group1(i))
			If maxChainage > paperLength Then
				Exit For
			End If
		Next
	End Sub
	Public Function ChainageListConsideringPaperLength(group1 As List(Of ChainageElevationGroup), startIndex As Integer)
	End Function
End Class

