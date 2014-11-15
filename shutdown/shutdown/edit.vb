Imports System.Management
Imports System.Drawing
Imports System.Windows
Imports System.Windows.Forms
Public Class edit
    Public Shared digit As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If win7.lab1 = True Then
            Dim connshut As System.Data.OleDb.OleDbConnection
            connshut = New System.Data.OleDb.OleDbConnection
            connshut.ConnectionString = My.Settings.shutdowndbConnectionString
            Dim cmd As New OleDb.OleDbCommand
            Try
                connshut.Open()
                cmd.Connection = connshut
                cmd.CommandText = "update win7 set ipaddr=@a,pcname=@b where ID=@c;"
                cmd.Parameters.AddWithValue("@a", TextBox2.Text)
                cmd.Parameters.AddWithValue("@b", TextBox1.Text)
                cmd.Parameters.AddWithValue("@c", digit)
                cmd.ExecuteNonQuery()
                connshut.Close()
                MsgBox("IP and PC Name Saved.")
                TextBox1.Text = ""
                TextBox2.Text = ""
                win7.ListBox1.Items.Clear()
                win7.listboxview()
            Catch ex As Exception
                MsgBox("Failed to save data.Please try again.")
            End Try
        ElseIf win7.lab2 = True Then
            Dim connshut As System.Data.OleDb.OleDbConnection
            connshut = New System.Data.OleDb.OleDbConnection
            connshut.ConnectionString = My.Settings.shutdowndbConnectionString
            Dim cmd As New OleDb.OleDbCommand
            Try
                connshut.Open()
                cmd.Connection = connshut
                cmd.CommandText = "update lab2 set ipaddr=@a,pcname=@b where ID=@c;"
                cmd.Parameters.AddWithValue("@a", TextBox2.Text)
                cmd.Parameters.AddWithValue("@b", TextBox1.Text)
                cmd.Parameters.AddWithValue("@c", digit)
                cmd.ExecuteNonQuery()
                connshut.Close()
                MsgBox("IP and PC Name Saved.")
                TextBox1.Text = ""
                TextBox2.Text = ""
                win7.ListBox1.Items.Clear()
                win7.listboxview()
            Catch ex As Exception
                MsgBox("Failed to save data.Please try again.")
            End Try
        ElseIf win7.lab3 = True Then
            Dim connshut As System.Data.OleDb.OleDbConnection
            connshut = New System.Data.OleDb.OleDbConnection
            connshut.ConnectionString = My.Settings.shutdowndbConnectionString
            Dim cmd As New OleDb.OleDbCommand
            Try
                connshut.Open()
                cmd.Connection = connshut
                cmd.CommandText = "update lab3 set ipaddr=@a,pcname=@b where ID=@c;"
                cmd.Parameters.AddWithValue("@a", TextBox2.Text)
                cmd.Parameters.AddWithValue("@b", TextBox1.Text)
                cmd.Parameters.AddWithValue("@c", digit)
                cmd.ExecuteNonQuery()
                connshut.Close()
                MsgBox("IP and PC Name Saved.")
                TextBox1.Text = ""
                TextBox2.Text = ""
                win7.ListBox1.Items.Clear()
                win7.listboxview()
            Catch ex As Exception
                MsgBox("Failed to save data.Please try again.")
            End Try
        End If
       
    End Sub

    Private Sub edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = win7.Label2.Text
        TextBox2.Text = win7.Label4.Text
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If win7.lab1 = True Then
            Dim connshut As System.Data.OleDb.OleDbConnection
            connshut = New System.Data.OleDb.OleDbConnection
            connshut.ConnectionString = My.Settings.shutdowndbConnectionString
            Dim cmd As New OleDb.OleDbCommand
            connshut.Open()
            cmd.Connection = connshut
            cmd.CommandText = "DELETE FROM win7 WHERE ID = " + digit
            cmd.ExecuteNonQuery()
            connshut.Close()
            TextBox1.Text = ""
            TextBox2.Text = ""
            win7.listboxview()
            Me.Close()
        ElseIf win7.lab2 = True Then
            Dim connshut As System.Data.OleDb.OleDbConnection
            connshut = New System.Data.OleDb.OleDbConnection
            connshut.ConnectionString = My.Settings.shutdowndbConnectionString
            Dim cmd As New OleDb.OleDbCommand
            connshut.Open()
            cmd.Connection = connshut
            cmd.CommandText = "DELETE FROM lab2 WHERE ID = " + digit
            cmd.ExecuteNonQuery()
            connshut.Close()
            TextBox1.Text = ""
            TextBox2.Text = ""
            win7.listboxview()
            Me.Close()
        ElseIf win7.lab3 = True Then
            Dim connshut As System.Data.OleDb.OleDbConnection
            connshut = New System.Data.OleDb.OleDbConnection
            connshut.ConnectionString = My.Settings.shutdowndbConnectionString
            Dim cmd As New OleDb.OleDbCommand
            connshut.Open()
            cmd.Connection = connshut
            cmd.CommandText = "DELETE FROM lab3 WHERE ID = " + digit
            cmd.ExecuteNonQuery()
            connshut.Close()
            TextBox1.Text = ""
            TextBox2.Text = ""
            win7.listboxview()
            Me.Close()
        End If
       
    End Sub
End Class



