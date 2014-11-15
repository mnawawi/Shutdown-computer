Public Class add
    Dim lab As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex = 0 Then
            lab = "win7"
        ElseIf ComboBox1.SelectedIndex = 1 Then
            lab = "lab2"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            lab = "lab3"
        End If
        Dim connshut As System.Data.OleDb.OleDbConnection
        connshut = New System.Data.OleDb.OleDbConnection
        connshut.ConnectionString = My.Settings.shutdowndbConnectionString
        Dim cmd As New OleDb.OleDbCommand
        Try
            connshut.Open()
            cmd.Connection = connshut
            cmd.CommandText = "insert into " + lab + "(ipaddr,pcname) values(@a,@b);"
            cmd.Parameters.AddWithValue("@a", TextBox2.Text)
            cmd.Parameters.AddWithValue("@b", TextBox1.Text)
            cmd.ExecuteNonQuery()
            connshut.Close()
            MsgBox("IP and PC Name Saved.")
            TextBox1.Text = ""
            TextBox2.Text = ""
            ComboBox1.SelectedIndex = -1
        Catch ex As Exception
            MsgBox("Failed to save data.Please try again.")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class