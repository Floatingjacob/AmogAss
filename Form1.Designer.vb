<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        hideButton = New Button()
        SuspendLayout()
        ' 
        ' hideButton
        ' 
        hideButton.BackColor = Color.Transparent
        hideButton.FlatAppearance.BorderSize = 0
        hideButton.FlatAppearance.MouseDownBackColor = Color.Transparent
        hideButton.FlatAppearance.MouseOverBackColor = Color.Transparent
        hideButton.FlatStyle = FlatStyle.Flat
        hideButton.ForeColor = Color.Transparent
        hideButton.Location = New Point(5, 5)
        hideButton.Name = "hideButton"
        hideButton.Size = New Size(20, 20)
        hideButton.TabIndex = 0
        hideButton.TabStop = False
        hideButton.Text = "."
        hideButton.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(120, 125)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)

    End Sub

End Class
