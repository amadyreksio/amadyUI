Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Design
Public Class RoundButton
    Public Property TextValue As String = "amadyUI"
    Public Property IdleColor As Color = Color.FromArgb(0, 50, 120)
    Public Property HoverColor As Color = Color.FromArgb(0, 30, 90)
    Public Property ClickedColor As Color = Color.FromArgb(0, 10, 60)
    Dim currentColor = IdleColor
    Public Property BorderRadius As Integer = 16
    Dim hovering As Boolean
    Dim clicked As Boolean
    Private Sub drawobj_Click(sender As Object, e As EventArgs) Handles drawobj.Click
        Me.OnClick(e)
    End Sub

    Private Sub drawobj_Paint(sender As Object, e As PaintEventArgs) Handles drawobj.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim brush As New SolidBrush(currentColor)
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
        Dim radius As Integer = BorderRadius
        Dim path As GraphicsPath = CreateRoundedRectangle(rect, radius)
        Dim textBrush As New SolidBrush(Color.White)
        Dim font As New Font("Arial", 20, FontStyle.Regular)
        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        g.FillPath(brush, path)
        g.DrawString(TextValue, font, textBrush, rect, sf)
        brush.Dispose()
        textBrush.Dispose()
        path.Dispose()
    End Sub


    Private Sub RoundyButton_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub drawobj_MouseEnter(sender As Object, e As EventArgs) Handles drawobj.MouseEnter
        hovering = True
    End Sub

    Private Sub drawobj_MouseLeave(sender As Object, e As EventArgs) Handles drawobj.MouseLeave
        hovering = False
    End Sub

    Private Sub RoundyButton_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        hovering = True
    End Sub

    Private Sub RoundyButton_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        hovering = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not hovering Then currentColor = Color.FromArgb(currentColor.R + (IdleColor.R - currentColor.R) * 0.2, currentColor.G + (IdleColor.G - currentColor.G) * 0.2, currentColor.B + (IdleColor.B - currentColor.B) * 0.2)
        If hovering Then currentColor = Color.FromArgb(currentColor.R + (HoverColor.R - currentColor.R) * 0.2, currentColor.G + (HoverColor.G - currentColor.G) * 0.2, currentColor.B + (HoverColor.B - currentColor.B) * 0.2)
        If clicked Then currentColor = Color.FromArgb(currentColor.R + (ClickedColor.R - currentColor.R) * 0.2, currentColor.G + (ClickedColor.G - currentColor.G) * 0.2, currentColor.B + (ClickedColor.B - currentColor.B) * 0.2)
        drawobj.Invalidate()
    End Sub

    Private Sub drawobj_MouseDown(sender As Object, e As MouseEventArgs) Handles drawobj.MouseDown
        clicked = True
    End Sub

    Private Sub drawobj_MouseUp(sender As Object, e As MouseEventArgs) Handles drawobj.MouseUp
        clicked = False
    End Sub

    Private Sub RoundyButton_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
