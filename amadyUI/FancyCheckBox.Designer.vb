<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FancyCheckBox
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.drawobj = New System.Windows.Forms.PictureBox()
        CType(Me.drawobj, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'drawobj
        '
        Me.drawobj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.drawobj.Location = New System.Drawing.Point(0, 0)
        Me.drawobj.Name = "drawobj"
        Me.drawobj.Size = New System.Drawing.Size(50, 50)
        Me.drawobj.TabIndex = 0
        Me.drawobj.TabStop = False
        '
        'FancyCheckBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.drawobj)
        Me.Name = "FancyCheckBox"
        Me.Size = New System.Drawing.Size(50, 50)
        CType(Me.drawobj, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Timer1 As Windows.Forms.Timer
    Friend WithEvents drawobj As Windows.Forms.PictureBox
End Class
