Public Class edituser
    Dim id As String
    Dim row As Integer
    Dim dtable As New DataTable("user")
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim connshut As System.Data.OleDb.OleDbConnection
        connshut = New System.Data.OleDb.OleDbConnection
        connshut.ConnectionString = My.Settings.shutdowndbConnectionString
        Dim cmd As New OleDb.OleDbCommand
        Try
            connshut.Open()
            cmd.Connection = connshut
            cmd.CommandText = "update staffmember set nama=@a,username=@b,pass=@c where ID=@d;"
            cmd.Parameters.AddWithValue("@a", TextBox1.Text)
            cmd.Parameters.AddWithValue("@b", TextBox2.Text)
            cmd.Parameters.AddWithValue("@c", TextBox3.Text)
            cmd.Parameters.AddWithValue("@d", id)
            cmd.ExecuteNonQuery()
            connshut.Close()
            MsgBox("Staff Details Updated.")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = "'"
            user()
        Catch ex As Exception
            MsgBox("Failed to save data.Please try again.")
        End Try
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        row = DataGridView1.CurrentRow.Index
        TextBox1.Text = dtable.Rows(row).Item("nama")
        TextBox2.Text = dtable.Rows(row).Item("username")
        TextBox3.Text = dtable.Rows(row).Item("pass")
        id = dtable.Rows(row).Item("ID")
    End Sub
    Public Sub user()

        dtable.Clear()
        Dim cnnect As System.Data.OleDb.OleDbConnection
        Dim dtadapter As OleDb.OleDbDataAdapter
        cnnect = New System.Data.OleDb.OleDbConnection
        cnnect.ConnectionString = My.Settings.shutdowndbConnectionString
        cnnect.Open()
        dtadapter = New OleDb.OleDbDataAdapter("SELECT * FROM staffmember", cnnect)
        dtadapter.Fill(dtable)
        cnnect.Close()
        DataGridView1.DataSource = dtable
        DataGridView1.Columns(0).Visible = False
    End Sub

    Private Sub edituser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        user()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim connshut As System.Data.OleDb.OleDbConnection
        connshut = New System.Data.OleDb.OleDbConnection
        connshut.ConnectionString = My.Settings.shutdowndbConnectionString
        Dim cmd As New OleDb.OleDbCommand
        connshut.Open()
        cmd.Connection = connshut
        cmd.CommandText = "DELETE FROM staffmember WHERE ID = " + id
        cmd.ExecuteNonQuery()
        connshut.Close()
        user()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class