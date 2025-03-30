Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class FancyCheckBox
    Property borderRadius As Integer = 8
    Public Property TextValue As String = "Ale button"
    Public Property IdleColor As Color = Color.FromArgb(0, 70, 200)
    Public Property HoverColor As Color = Color.FromArgb(0, 40, 170)
    Public Property ClickedColor As Color = Color.FromArgb(0, 20, 140)
    Dim currentColor = IdleColor
    Property checked As Boolean = False
    Dim tickSize As Integer = 50
    Dim currentTickSize As Integer = 50
    Private Sub drawobj_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles drawobj.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias



        Dim brush As New SolidBrush(currentColor)
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
        Dim path As GraphicsPath = CreateRoundedRectangle(rect, borderRadius)
        g.FillPath(brush, path)
        If Not tickSize = 0 Then

            Dim textBrush As New SolidBrush(Color.White)
            Dim tempticksize As Integer = currentTickSize / 2
            Dim font As New Font("Arial", tempticksize, FontStyle.Regular)
            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
            g.FillPath(brush, path)
            g.DrawString("✓", font, textBrush, rect, sf)
            textBrush.Dispose()
        End If
        brush.Dispose()
        path.Dispose()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not hovering Then currentColor = Color.FromArgb(CInt(currentColor.R + (IdleColor.R - currentColor.R) * 0.2), CInt(currentColor.G + (IdleColor.G - currentColor.G) * 0.2), CInt(currentColor.B + (IdleColor.B - currentColor.B) * 0.2))
        If hovering Then currentColor = Color.FromArgb(CInt(currentColor.R + (HoverColor.R - currentColor.R) * 0.2), CInt(currentColor.G + (HoverColor.G - currentColor.G) * 0.2), CInt(currentColor.B + (HoverColor.B - currentColor.B) * 0.2))
        If clicked Then currentColor = Color.FromArgb(currentColor.R + (ClickedColor.R - currentColor.R) * 0.2, currentColor.G + (ClickedColor.G - currentColor.G) * 0.2, currentColor.B + (ClickedColor.B - currentColor.B) * 0.2)
        currentTickSize += (tickSize - currentTickSize) * 0.1
        drawobj.Invalidate()
    End Sub

    Private Sub drawobj_Click(sender As Object, e As EventArgs) Handles drawobj.Click
        checked = Not checked
        If checked Then
            tickSize = Me.Width
        Else
            tickSize = 0
        End If
    End Sub
    Dim hovering As Boolean = False
    Dim clicked As Boolean = False

    Private Sub FancyCheckBox_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles drawobj.MouseDown
        clicked = True
    End Sub

    Private Sub FancyCheckBox_MouseUp(sender As Object, e As Windows.Forms.MouseEventArgs) Handles drawobj.MouseUp
        clicked = False
    End Sub

    Private Sub FancyCheckBox_MouseEnter(sender As Object, e As EventArgs) Handles drawobj.MouseEnter
        hovering = True
    End Sub

    Private Sub FancyCheckBox_MouseLeave(sender As Object, e As EventArgs) Handles drawobj.MouseLeave
        hovering = False
    End Sub
End Class
