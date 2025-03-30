Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class RoundPanel
    Inherits UserControl

    Public Property BackgroundColor As Color = Color.FromArgb(20, 20, 20)
    Public Property BorderRadius As Integer = 16

    Public Sub New()
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        Me.BackColor = Color.Transparent
    End Sub

    Public ReadOnly Property ContainerControls() As Control.ControlCollection
        Get
            Return MyBase.Controls
        End Get
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
        Dim path As GraphicsPath = CreateRoundedRectangle(rect, BorderRadius)
        Using brush As New SolidBrush(BackgroundColor)
            g.FillPath(brush, path)
        End Using
        Me.Region = New Region(path)
        path.Dispose()
    End Sub
End Class
