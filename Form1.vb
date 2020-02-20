Option Strict Off
Option Explicit On

Public Class Form1
    Inherits System.Windows.Forms.Form
    Const GWL_EXSTYLE As Short = (-20)
    Const WS_EX_LAYERED As Integer = &H80000
    Const WS_EX_TRANSPARENT As Integer = &H20
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hwnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer

    Private Declare Function key Lib "user32" Alias "GetAsyncKeyState" (ByVal key As Keys) As Keys
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        If ComboBox1.Text = "Dot" Then
            Form4.BackColor = ColorDialog1.Color
        ElseIf ComboBox1.Text = "Inside" Then
2:          Form2.BackColor = ColorDialog1.Color
            Form3.BackColor = ColorDialog1.Color
        ElseIf ComboBox1.Text = "Outside" Then
            Form5.BackColor = ColorDialog1.Color
            Form6.BackColor = ColorDialog1.Color
            Form7.BackColor = ColorDialog1.Color
            Form8.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label7.Text = TimeOfDay
        Label8.Text = Today
        If key(Keys.Tab) And key(Keys.D1) Then
            Timer2.Start()
            Form2.Show()
            Form3.Show()
            Form4.Show()
            Form5.Show()
            Form6.Show()
            Form7.Show()
            Form8.Show()
            SetWindowLong(Form2.Handle.ToInt32, GWL_EXSTYLE, GetWindowLong(Form2.Handle.ToInt32, GWL_EXSTYLE) Or WS_EX_LAYERED Or WS_EX_TRANSPARENT)
            SetWindowLong(Form3.Handle.ToInt32, GWL_EXSTYLE, GetWindowLong(Form3.Handle.ToInt32, GWL_EXSTYLE) Or WS_EX_LAYERED Or WS_EX_TRANSPARENT)
            SetWindowLong(Form4.Handle.ToInt32, GWL_EXSTYLE, GetWindowLong(Form4.Handle.ToInt32, GWL_EXSTYLE) Or WS_EX_LAYERED Or WS_EX_TRANSPARENT)
            SetWindowLong(Form5.Handle.ToInt32, GWL_EXSTYLE, GetWindowLong(Form5.Handle.ToInt32, GWL_EXSTYLE) Or WS_EX_LAYERED Or WS_EX_TRANSPARENT)
            SetWindowLong(Form6.Handle.ToInt32, GWL_EXSTYLE, GetWindowLong(Form6.Handle.ToInt32, GWL_EXSTYLE) Or WS_EX_LAYERED Or WS_EX_TRANSPARENT)
            SetWindowLong(Form7.Handle.ToInt32, GWL_EXSTYLE, GetWindowLong(Form7.Handle.ToInt32, GWL_EXSTYLE) Or WS_EX_LAYERED Or WS_EX_TRANSPARENT)
            SetWindowLong(Form8.Handle.ToInt32, GWL_EXSTYLE, GetWindowLong(Form8.Handle.ToInt32, GWL_EXSTYLE) Or WS_EX_LAYERED Or WS_EX_TRANSPARENT)

            Me.Visible = False
        ElseIf key(Keys.Tab) And key(Keys.D2) Then
            Timer2.Stop()
            Form2.Visible = False
            Form3.Visible = False
            Form4.Visible = False
            Form5.Visible = False
            Form6.Visible = False
            Form7.Visible = False
            Form8.Visible = False
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Form2.Refresh()
        Form3.Refresh()
        Form4.Refresh()
        Form5.Refresh()
        Form6.Refresh()
        Form7.Refresh()
        Form8.Refresh()
        Form2.BringToFront()
        Form3.BringToFront()
        Form4.BringToFront()
        Form5.BringToFront()
        Form6.BringToFront()
        Form7.BringToFront()
        Form8.BringToFront()
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Form2.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 2 - Form2.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2)
        Form3.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - Form3.Height / 2)
        Form4.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 2 - 2, Screen.PrimaryScreen.Bounds.Height / 2 - 2)
        Form5.Location = New Point(Form3.Location.X + 2, Form3.Location.Y + Form5.Height / 2)
        Form6.Location = New Point(Form3.Location.X - 3, Form3.Location.Y + Form6.Height / 2)
        Form7.Location = New Point(Form2.Location.X + Form7.Width / 2, Form2.Location.Y + 2)
        Form8.Location = New Point(Form2.Location.X + Form8.Width / 2, Form2.Location.Y - 3)
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If Me.Visible = False Then
            Me.Visible = True
            Me.Show()
        ElseIf Me.Visible = True Then
            Me.Visible = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Application.Restart()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Me.Width = 350 Then
            Me.Width = 500
        ElseIf Me.Width = 500 Then
            Me.Width = 350
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Form2.Width = TextBox1.Text
        Form3.Height = TextBox1.Text
        Form5.Height = TextBox1.Text / 2
        Form6.Height = TextBox1.Text / 2
        Form7.Width = TextBox1.Text / 2
        Form8.Width = TextBox1.Text / 2
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox("Thanks for using my Program ^^ this program will not detected by GMs unless u released it, Credit by SnowReborn", MsgBoxStyle.Information, "Notice")
    End Sub
End Class
