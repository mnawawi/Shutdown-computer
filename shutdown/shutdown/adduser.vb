Imports System.Data.OleDb

Public Class adduser

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim connshut As System.Data.OleDb.OleDbConnection
        connshut = New System.Data.OleDb.OleDbConnection
        connshut.ConnectionString = My.Settings.shutdowndbConnectionString
        Dim cmd As New OleDb.OleDbCommand
        Try
            connshut.Open()
            cmd.Connection = connshut
            cmd.CommandText = "insert into staffmember(nama,username,pass) values(@a,@b,@c);"
            cmd.Parameters.AddWithValue("@a", TextBox2.Text)
            cmd.Parameters.AddWithValue("@b", TextBox1.Text)
            cmd.Parameters.AddWithValue("@c", TextBox3.Text)
            cmd.ExecuteNonQuery()
            connshut.Close()
            MsgBox("Staff Added Into Database.")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        Catch ex As Exception
            MsgBox("Failed to save data.Please try again.")
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
 
End Class