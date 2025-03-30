Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class FancyProgressBar
    Public Property backgroundColor As Color = Color.FromArgb(160, 160, 160)
    Public Property barColor As Color = Color.FromArgb(0, 50, 220)
    Public Property BorderRadius As Integer = 10
    Public Property Value As Integer = 50
    Public Property Min As Integer = 0
    Public Property Max As Integer = 100
    Dim currentval As Integer = Value
    Private Sub drawobj_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles drawobj.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias



        Dim brush2 As New SolidBrush(barColor)
        Dim rect2 As New Rectangle(0, 0, Math.Max((currentval / 100) * Me.Width, 0), Me.Height)
        Dim path2 As GraphicsPath = CreateRoundedRectangle(rect2, 4)

        Dim brush3 As New SolidBrush(backgroundColor)
        Dim rect3 As New Rectangle(0, 0, Me.Width, Me.Height)
        Dim path3 As GraphicsPath = CreateRoundedRectangle(rect3, 4)
        g.FillPath(brush3, path3)
        If Not Value = 0 Then g.FillPath(brush2, path2)

        brush2.Dispose()
        path2.Dispose()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        currentval += (Value - currentval) * 0.1
        If Math.Abs(Max - currentval) <= 5 Then
            currentval = Value
        End If
        drawobj.Invalidate()

    End Sub
End Class
