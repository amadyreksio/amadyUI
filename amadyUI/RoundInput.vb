Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class RoundInput
    Property IdleColor As Color = Color.FromArgb(40, 40, 40)
    Property HoverColor As Color = Color.FromArgb(50, 50, 50)
    Property ClickedColor As Color = Color.FromArgb(30, 30, 30)
    Property textValue = ""
    Dim currentColor = Color.FromArgb(20, 20, 20)

    Property fontSize As Integer = 0
    Property BorderRadius As Integer = 8
    Private Sub drawobj_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles drawobj.Paint
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
        TextBox1.Left = Me.Width / 2 - TextBox1.Width / 2
        TextBox1.Top = Me.Height / 2 - TextBox1.Height / 2
        TextBox1.BackColor = currentColor 'me.height-32
        TextBox1.Font = If(fontSize = 0, New Font(TextBox1.Font.FontFamily, (Math.Max(Me.Height, 33) - 32) / 2), New Font(TextBox1.Font.FontFamily, fontSize))
        brush.Dispose()
        textBrush.Dispose()
        path.Dispose()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        textValue = TextBox1.Text
        If Not hovering Then currentColor = Color.FromArgb(CInt(currentColor.R + (IdleColor.R - currentColor.R) * 0.2), CInt(currentColor.G + (IdleColor.G - currentColor.G) * 0.2), CInt(currentColor.B + (IdleColor.B - currentColor.B) * 0.2))
        If hovering Then currentColor = Color.FromArgb(CInt(currentColor.R + (HoverColor.R - currentColor.R) * 0.2), CInt(currentColor.G + (HoverColor.G - currentColor.G) * 0.2), CInt(currentColor.B + (HoverColor.B - currentColor.B) * 0.2))
        If clicked Then currentColor = Color.FromArgb(currentColor.R + (ClickedColor.R - currentColor.R) * 0.2, currentColor.G + (ClickedColor.G - currentColor.G) * 0.2, currentColor.B + (ClickedColor.B - currentColor.B) * 0.2)
        drawobj.Invalidate()
    End Sub

    Private Sub drawobj_Click(sender As Object, e As EventArgs) Handles drawobj.Click

    End Sub

    Private Sub RoundInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Dim clicked As Boolean = False
    Dim hovering As Boolean = False
    Private Sub drawobj_MouseEnter(sender As Object, e As EventArgs) Handles drawobj.MouseEnter
        hovering = True
    End Sub

    Private Sub drawobj_MouseHover(sender As Object, e As EventArgs) Handles drawobj.MouseHover
        hovering = False
    End Sub

    Private Sub drawobj_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles drawobj.MouseDown
        clicked = True
    End Sub

    Private Sub drawobj_MouseUp(sender As Object, e As Windows.Forms.MouseEventArgs) Handles drawobj.MouseUp
        clicked = False
    End Sub
End Class
