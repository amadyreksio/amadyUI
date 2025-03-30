<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class amadyScrollBar
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
        Me.thumb = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Roundifier1 = New amadyUI.Roundifier()
        Me.Roundifier2 = New amadyUI.Roundifier()
        Me.SuspendLayout()
        '
        'thumb
        '
        Me.thumb.BackColor = System.Drawing.Color.Black
        Me.thumb.Location = New System.Drawing.Point(0, 87)
        Me.thumb.Name = "thumb"
        Me.thumb.Size = New System.Drawing.Size(14, 100)
        Me.thumb.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'Roundifier1
        '
        Me.Roundifier1.borderRadius = 6
        Me.Roundifier1.control = Me
        '
        'Roundifier2
        '
        Me.Roundifier2.borderRadius = 6
        Me.Roundifier2.control = Me.thumb
        '
        'amadyScrollBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Controls.Add(Me.thumb)
        Me.Name = "amadyScrollBar"
        Me.Size = New System.Drawing.Size(14, 272)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Roundifier1 As Roundifier
    Friend WithEvents thumb As Windows.Forms.Panel
    Friend WithEvents Roundifier2 As Roundifier
    Friend WithEvents Timer1 As Windows.Forms.Timer
End Class
