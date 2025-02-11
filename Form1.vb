Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class Form1
    ' Import necessary WinAPI functions to make the form click-through
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Shared Function SetWindowLong(hWnd As IntPtr, nIndex As Integer, dwNewLong As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Shared Function GetWindowLong(hWnd As IntPtr, nIndex As Integer) As Integer
    End Function

    Private Const GWL_EXSTYLE As Integer = -20
    Private Const WS_EX_LAYERED As Integer = &H80000
    Private Const WS_EX_TRANSPARENT As Integer = &H20

    Private overlayForm As Form
    Private buttonForm As Form
    Private pictureBox As PictureBox
    Private hideButton As Button

    Public Sub New()
        ' Initialize the main form
        InitializeComponent()
        Me.Text = "Overlay Controller"
        Me.Size = New Size(300, 150)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Create the overlay form
        overlayForm = New Form()
        overlayForm.FormBorderStyle = FormBorderStyle.None
        overlayForm.TopMost = True
        overlayForm.StartPosition = FormStartPosition.Manual
        overlayForm.Bounds = Screen.PrimaryScreen.Bounds
        overlayForm.ShowInTaskbar = False
        overlayForm.BackColor = Color.Black ' Needed for transparency

        ' Create a PictureBox for the GIF
        pictureBox = New PictureBox()
        pictureBox.Dock = DockStyle.Fill
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        pictureBox.Image = Image.FromFile("twerk.gif") ' Replace with your GIF path
        overlayForm.Controls.Add(pictureBox)

        ' Show the overlay form
        overlayForm.Show()

        ' Make overlay click-through
        Dim exStyle As Integer = GetWindowLong(overlayForm.Handle, GWL_EXSTYLE)
        SetWindowLong(overlayForm.Handle, GWL_EXSTYLE, exStyle Or WS_EX_LAYERED Or WS_EX_TRANSPARENT)

        ' Create a separate top-most form for the button
        buttonForm = New Form()
        buttonForm.FormBorderStyle = FormBorderStyle.None
        buttonForm.TopMost = True
        buttonForm.StartPosition = FormStartPosition.Manual
        buttonForm.Size = New Size(30, 30)
        buttonForm.Location = New Point(10, Screen.PrimaryScreen.Bounds.Height - 40)
        buttonForm.ShowInTaskbar = False
        buttonForm.BackColor = Color.Magenta ' Set a transparency key color
        buttonForm.TransparencyKey = Color.Magenta ' Makes the form background fully transparent

        ' Create a button in the bottom-left corner
        hideButton = New Button()
        hideButton.Text = "."
        hideButton.Size = New Size(30, 20)
        hideButton.Location = New Point(0, 0)
        hideButton.FlatStyle = FlatStyle.Flat
        hideButton.BackColor = Color.FromArgb(&H8B, &HA0, &HA9)
        hideButton.ForeColor = Color.Gray
        hideButton.TabStop = False
        hideButton.FlatAppearance.BorderSize = 0

        AddHandler hideButton.Click, AddressOf HideOverlay
        buttonForm.Controls.Add(hideButton)

        ' Show the button form
        buttonForm.Show()
    End Sub

    Private Sub HideOverlay(sender As Object, e As EventArgs)
        overlayForm.Hide()
        buttonForm.Hide()
    End Sub

    ' Close both forms when the main form is closed
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
        overlayForm.Close()
        buttonForm.Close()
    End Sub
End Class
