Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class Roundifier
    Inherits Component

    Public Property control As Control
    Public Property borderRadius As Integer = 16
    Private WithEvents Timer As Timer
    Private Shadows disposed As Boolean = False
    Public Sub New()
        InitializeTimer()
    End Sub

    Public Sub New(ctrl As Control)
        Me.control = ctrl
        InitializeTimer()
        AddHandler control.HandleCreated, AddressOf Control_HandleCreated
    End Sub

    Private Sub InitializeTimer()
        Timer = New Timer()
        Timer.Interval = 1000
        AddHandler Timer.Tick, AddressOf Timer_Tick
        Timer.Start()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        If Not disposed Then
            ApplyRoundedCorners()
        End If
    End Sub

    Private Sub Control_HandleCreated(sender As Object, e As EventArgs)
        ApplyRoundedCorners()
    End Sub

    Public Sub ApplyRoundedCorners()
        If control Is Nothing OrElse control.IsDisposed Then Exit Sub
        If control.IsHandleCreated Then
            Dim rect As New Rectangle(0, 0, control.Width, control.Height)
            Dim path As GraphicsPath = CreateRoundedRectangle(rect, borderRadius)
            control.Invoke(Sub() control.Region = New Region(path))
        End If
    End Sub
    Overloads Sub Dispose(disposing As Boolean, reksio As Boolean)
        If Not disposed Then
            If disposing Then
                If Timer IsNot Nothing Then
                    Timer.Stop()
                    Timer.Dispose()
                End If
                If control IsNot Nothing Then
                    RemoveHandler control.HandleCreated, AddressOf Control_HandleCreated
                End If
            End If
            disposed = True
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
