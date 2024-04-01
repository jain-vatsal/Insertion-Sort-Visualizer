<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.InputBtn = New System.Windows.Forms.Button()
        Me.InsertionBtn = New System.Windows.Forms.Button()
        Me.ClearBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'InputBtn
        '
        Me.InputBtn.Location = New System.Drawing.Point(439, 68)
        Me.InputBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.InputBtn.Name = "InputBtn"
        Me.InputBtn.Size = New System.Drawing.Size(150, 53)
        Me.InputBtn.TabIndex = 2
        Me.InputBtn.Text = "Input"
        Me.InputBtn.UseVisualStyleBackColor = True
        '
        'InsertionBtn
        '
        Me.InsertionBtn.Location = New System.Drawing.Point(435, 158)
        Me.InsertionBtn.Name = "InsertionBtn"
        Me.InsertionBtn.Size = New System.Drawing.Size(163, 59)
        Me.InsertionBtn.TabIndex = 3
        Me.InsertionBtn.Text = "Pass of Insertion sort"
        Me.InsertionBtn.UseVisualStyleBackColor = True
        '
        'ClearBtn
        '
        Me.ClearBtn.Location = New System.Drawing.Point(438, 250)
        Me.ClearBtn.Name = "ClearBtn"
        Me.ClearBtn.Size = New System.Drawing.Size(169, 54)
        Me.ClearBtn.TabIndex = 4
        Me.ClearBtn.Text = "Clear"
        Me.ClearBtn.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1250, 529)
        Me.Controls.Add(Me.ClearBtn)
        Me.Controls.Add(Me.InsertionBtn)
        Me.Controls.Add(Me.InputBtn)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents InputBtn As System.Windows.Forms.Button
    Friend WithEvents InsertionBtn As System.Windows.Forms.Button
    Friend WithEvents ClearBtn As System.Windows.Forms.Button

End Class
