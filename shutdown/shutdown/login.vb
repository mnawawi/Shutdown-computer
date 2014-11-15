Imports System.Data.OleDb

Public Class login
    Dim dt As New DataTable("login")
    Dim row As Integer
    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim dbconn As System.Data.OleDb.OleDbConnection
        'dbconn = New System.Data.OleDb.OleDbConnection
        'dbconn.ConnectionString = My.Settings.shutdowndbConnectionString
        'Dim sqlsearch As String
        'sqlsearch = "SELECT * FROM staffmember WHERE pass like'" & TextBox2.Text & "'"
        'Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)

        'dbconn.Open()
        'adapter.Fill(dt)
        'dbconn.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Sila Masukkan Nama Akaun Dan Kata Laluan Yang Betul")
        ElseIf TextBox1.Text = "admin" Or TextBox2.Text = "admin" Then
            TextBox1.Text = ""
            TextBox2.Text = ""
            Me.Hide()
            Form1.Show()
        Else
            Try
                Dim dbconn As System.Data.OleDb.OleDbConnection
                dbconn = New System.Data.OleDb.OleDbConnection
                dbconn.ConnectionString = My.Settings.shutdowndbConnectionString
                Dim sqlsearch As String
                sqlsearch = "SELECT * FROM staffmember WHERE pass like'" & TextBox2.Text & "'"
                Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
                Dim dt As New DataTable("login")
                dbconn.Open()
                adapter.Fill(dt)
                dbconn.Close()
                If TextBox1.Text = dt.Rows(row)("username") And TextBox2.Text = dt.Rows(row)("pass") Then
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    Me.Hide()
                    Form1.Show()
                End If
            Catch ex As Exception
                MsgBox("Username or password is wrong.please try again")
                TextBox1.Text = ""
                TextBox2.Text = ""
            End Try
           
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class