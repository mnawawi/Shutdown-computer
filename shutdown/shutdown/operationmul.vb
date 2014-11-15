Public Class operationmul
    Dim jam As String


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'jam = ComboBox1.Text + ":" + ComboBox2.Text
        'If Format(Now, "hh:mm:ss") = jam Then
        '    MsgBox("da smpai")
        'End If
        'Dim dtime As New datetime
        'Label1.Text = DateTime.Now.ToString("hh:mm tt")
        'If Label1.Text = Label2.Text Then
        '    MsgBox("da smpai")
        'End If
    End Sub

    Private Sub operation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Label1.Text = DateTime.Now.ToString("hh:mm tt")
        'Timer1.Start()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Plese select value.")
        Else
            Form1.jam = ComboBox1.Text + ":" + ComboBox2.Text
            If ComboBox3.SelectedIndex = 0 Then
                Form1.shutdown = True
            ElseIf ComboBox3.SelectedIndex = 1 Then
                Form1.restart = True
            ElseIf ComboBox3.SelectedIndex = 2 Then
                Form1.logoff = True
            End If
            win7.Close()
            Me.Close()
        End If
       

    End Sub
End Class