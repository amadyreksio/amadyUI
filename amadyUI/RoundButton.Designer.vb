﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RoundButton
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.drawobj = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.drawobj, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'drawobj
        '
        Me.drawobj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.drawobj.Location = New System.Drawing.Point(0, 0)
        Me.drawobj.Name = "drawobj"
        Me.drawobj.Size = New System.Drawing.Size(300, 70)
        Me.drawobj.TabIndex = 0
        Me.drawobj.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'RoundButton
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.drawobj)
        Me.Name = "RoundButton"
        Me.Size = New System.Drawing.Size(300, 70)
        CType(Me.drawobj, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents drawobj As Windows.Forms.PictureBox
    Friend WithEvents Timer1 As Windows.Forms.Timer
End Class
