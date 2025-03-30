Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Net.Mime.MediaTypeNames
Imports System.Drawing.Imaging

<DefaultEvent("Click")>
Public Class amadyButton
    Public Property text As String = "amadyUI"
    Public Property IdleColor As Color = Color.FromArgb(30, 30, 30)
    Public Property HoverColor As Color = Color.FromArgb(45, 45, 45)
    Public Property ClickedColor As Color = Color.FromArgb(10, 10, 10)
    Public Property Icon As Drawing.Image = Nothing
    Public Property BackgroundImage As Drawing.Image = Nothing
    Public Property TextStroke As Integer = 1
    Public Property TextStrokeColor As Color = Color.Black

    Public Property selected As Boolean = False
    Dim gamma As Decimal = 1.0

    'Public Property IdleColor As Color = Color.FromArgb(255, 0, 0)
    'Public Property HoverColor As Color = Color.FromArgb(0, 255, 0)
    'Public Property ClickedColor As Color = Color.FromArgb(0, 0, 255)
    Public Property BorderRadius As Integer = 16
    Dim currentColor = IdleColor
    Dim actualColor = IdleColor
    Dim dasignloop As Task
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        init()
    End Sub
    Public Sub New(text)
        Me.text = text
        init()
    End Sub
    Public Sub New(text, IdleColor)
        Me.text = text
        Me.IdleColor = IdleColor
        actualColor = IdleColor
        currentColor = actualColor
        init()
    End Sub
    Public Sub New(text, IdleColor, HoverColor)
        Me.text = text
        Me.IdleColor = IdleColor
        Me.HoverColor = HoverColor
        actualColor = IdleColor
        currentColor = actualColor
        init()
    End Sub
    Public Sub New(text, IdleColor, HoverColor, ClickedColor)
        Me.text = text
        Me.IdleColor = IdleColor
        Me.HoverColor = HoverColor
        Me.ClickedColor = ClickedColor
        actualColor = IdleColor
        currentColor = actualColor
        init()
    End Sub
    Public Sub New(text, IdleColor, HoverColor, ClickedColor, BorderRadius)
        Me.text = text
        Me.IdleColor = IdleColor
        Me.HoverColor = HoverColor
        Me.ClickedColor = ClickedColor
        Me.BorderRadius = BorderRadius
        actualColor = IdleColor
        currentColor = actualColor
        init()
    End Sub


    Sub init()
        dasignloop = New Task(AddressOf dasignupdate)
        dasignloop.Start()
        MyBase.DoubleBuffered = True
        AddHandler MyBase.MouseEnter, AddressOf menter
        AddHandler MyBase.MouseLeave, AddressOf mleave
        AddHandler MyBase.MouseDown, AddressOf mdown
        AddHandler MyBase.MouseUp, AddressOf mup
    End Sub
    Dim baractualwidth As Integer = 0
    Private Sub amadyButton_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim brush As New SolidBrush(currentColor)
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
        Dim radius As Integer = BorderRadius
        Dim path As GraphicsPath = CreateRoundedRectangle(rect, radius)
        Me.Region = New Region(path)
        Dim textBrush As New SolidBrush(Color.White)
        Dim font As Font = Me.Font
        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        g.FillPath(brush, path)
        If BackgroundImage IsNot Nothing Then
            'e.Graphics.DrawImage(myImage, rect, 0, 0, 200, 200, GraphicsUnit.Pixel, imageAttr);  
            'ImageAttributes imageAttr = New ImageAttributes();
            'imageAttr.SetGamma(2.2F);
            Dim iattr As New ImageAttributes()
            iattr.SetGamma(gamma)
            g.DrawImage(BackgroundImage, New Rectangle(0, 0, Me.Width, Me.Height), 0, 0, BackgroundImage.Width, BackgroundImage.Height, GraphicsUnit.Pixel, iattr)
        End If
        If baractualwidth > 5 Then
            Dim w As Integer = baractualwidth
            Dim h As Integer = 5
            Dim x As Integer = Me.Width / 2 - w / 2
            Dim y As Integer = Me.Height - 5

            Dim rect2 As New Rectangle(x, y, w, h)
            Dim path2 As GraphicsPath = CreateRoundedRectangle(rect2, 2)
            Dim brushwhite As New SolidBrush(Color.White)
            g.FillPath(brushwhite, path2)
        End If
        If Icon IsNot Nothing Then
            g.DrawImage(Icon, 5, 5, Me.Height - 10, Me.Height - 10)
        End If
        Dim layoutRect As New Rectangle(If(Icon IsNot Nothing, Me.Height + 5, 0), 0, If(Icon IsNot Nothing, Me.Width - Me.Height - 5, Me.Width), Me.Height)
        If TextStroke > 0 Then
            Dim path2 As New Drawing2D.GraphicsPath()
            path2.AddString(text, font.FontFamily, CType(font.Style, Integer), font.Size, layoutRect, sf)
            Dim strokePen As New Pen(TextStrokeColor, TextStroke)
            g.DrawPath(strokePen, path2)
            g.FillPath(textBrush, path2)
        End If
        'g.DrawString(text, font, textBrush, layoutRect, sf)


        brush.Dispose()
        textBrush.Dispose()
        path.Dispose()
    End Sub
    Sub menter(ByVal sender As Object, e As EventArgs)
        actualColor = Color.FromArgb(HoverColor.R, HoverColor.G, HoverColor.B)
        ismouseover = True
    End Sub
    Sub mleave(ByVal sender As Object, e As EventArgs)
        ismouseover = False
    End Sub
    Sub mdown(ByVal sender As Object, e As EventArgs)
        ismousedown = True
    End Sub
    Sub mup(ByVal sender As Object, e As EventArgs)
        ismousedown = False
    End Sub
    Dim ismouseover As Boolean = False
    Dim ismousedown As Boolean = False
    Async Sub dasignupdate()
        While True
            'ok
            If ismousedown And ismouseover Then
                gamma += (1.4 - gamma) * 0.1
                If Not actualColor = Color.FromArgb(ClickedColor.R, ClickedColor.G, ClickedColor.B) Then actualColor = Color.FromArgb(ClickedColor.R, ClickedColor.G, ClickedColor.B)
            ElseIf ismouseover Then
                If Not actualColor = Color.FromArgb(HoverColor.R, HoverColor.G, HoverColor.B) Then actualColor = Color.FromArgb(HoverColor.R, HoverColor.G, HoverColor.B)
                gamma += (0.8 - gamma) * 0.1


            Else
                gamma += (1.0 - gamma) * 0.1
                If Not actualColor = Color.FromArgb(IdleColor.R, IdleColor.G, IdleColor.B) Then actualColor = Color.FromArgb(IdleColor.R, IdleColor.G, IdleColor.B)
            End If
            currentColor = Color.FromArgb(
                CInt(currentColor.R + (actualColor.R - currentColor.R) * 0.2),
                CInt(currentColor.G + (actualColor.G - currentColor.G) * 0.2),
                CInt(currentColor.B + (actualColor.B - currentColor.B) * 0.2)
)
            If selected Then
                baractualwidth += ((Me.Width - 40) - baractualwidth) * 0.1
            Else
                baractualwidth += ((0) - baractualwidth) * 0.1
            End If
            Me.Invalidate()
            Await Task.Delay(1)
        End While
    End Sub
End Class
