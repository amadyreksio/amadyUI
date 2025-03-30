Imports System.Drawing

Public Class Preview
    Private Sub AmadyButton1_Click(sender As Object, e As EventArgs)
        MsgBox("test")
    End Sub

    Private Sub Preview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Controls.Add(New amadyButton("reksio", Color.Red))
        'FlowLayoutPanel1.HorizontalScroll.Visible = False
        'FlowLayoutPanel1.VerticalScroll.Visible = False
        AmadyButton10.selected = True
    End Sub

    Private Sub AmadyButton8_Click(sender As Object, e As EventArgs) Handles AmadyButton8.Click
        FlowLayoutPanel1.Controls.Add(New amadyButton("reksioamboosh"))
    End Sub
End Class