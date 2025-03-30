Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class amadyScrollBar

    Dim dragging As Boolean = False
    Dim dragOffset As Integer
    Property control As ScrollableControl = Nothing
    Property thumbColor As Color = Color.FromArgb(5, 5, 5)
    Dim isknown As Boolean = False
    <DllImport("user32.dll")>
    Private Shared Function ShowScrollBar(hWnd As IntPtr, wBar As Integer, bShow As Boolean) As Boolean
    End Function

    Private Const SB_VERT As Integer = 1
    Private Const SB_HORZ As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If control Is Nothing Then

            Return
        Else
            ShowScrollBar(control.Handle, SB_VERT, False)
            If Not isknown Then
                isknown = True
                AddHandler control.Scroll, AddressOf COnScroll
                control.AutoScroll = True
                ShowScrollBar(control.Handle, SB_VERT, False)



            End If
        End If
        If control.VerticalScroll.Maximum > control.ClientSize.Height Then
            Dim thumbpercentage As Decimal = control.ClientSize.Height / control.VerticalScroll.Maximum
            thumb.Size = New Size(thumb.Size.Width, CInt(thumbpercentage * Me.Height))

            If Not dragging Then
                Dim scrollPercentage As Decimal = control.VerticalScroll.Value / (control.VerticalScroll.Maximum - control.ClientSize.Height)
                thumb.Location = New Point(thumb.Location.X, CInt(scrollPercentage * (Me.Height - thumb.Height)))
            End If
        End If
    End Sub
    Sub hidesb()
        While control IsNot Nothing
            Me.Invoke(Sub() ShowScrollBar(control.Handle, SB_VERT, False))
            Me.Invoke(Sub() ShowScrollBar(control.Handle, SB_HORZ, False))
        End While
    End Sub
    Private Sub thumb_MouseDown(sender As Object, e As MouseEventArgs) Handles thumb.MouseDown
        dragging = True
        dragOffset = e.Y
    End Sub

    Private Sub thumb_MouseUp(sender As Object, e As MouseEventArgs) Handles thumb.MouseUp
        dragging = False
    End Sub

    Private Sub thumb_MouseMove(sender As Object, e As MouseEventArgs) Handles thumb.MouseMove
        If dragging Then
            Dim newY As Integer = thumb.Top + (e.Y - dragOffset)
            newY = Math.Max(0, Math.Min(Me.Height - thumb.Height, newY))
            thumb.Location = New Point(thumb.Location.X, newY)
            Dim scrollPercentage As Double = newY / (Me.Height - thumb.Height)
            Dim maxScrollOffset As Integer = control.VerticalScroll.Maximum - control.ClientSize.Height
            ShowScrollBar(control.Handle, SB_VERT, False)
            control.AutoScrollPosition = New Point(0, CInt(scrollPercentage * maxScrollOffset))
            ShowScrollBar(control.Handle, SB_VERT, False)
            ShowScrollBar(control.Handle, SB_VERT, False)
        End If
    End Sub
    Private Sub COnScroll(sender As Object, e As ScrollEventArgs)
        Dim scrollPercentage As Decimal = control.VerticalScroll.Value / (control.VerticalScroll.Maximum - control.ClientSize.Height)
        thumb.Location = New Point(0, CInt(scrollPercentage * (Me.Height - thumb.Height)))
    End Sub

    Private Sub amadyScrollBar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
    End Sub

    Private Sub amadyScrollBar_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        thumb.BackColor = thumbColor
        thumb.Width = Me.Width
    End Sub
End Class
