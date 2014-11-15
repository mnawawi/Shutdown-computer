Option Explicit On
Imports System.Net
Imports System.IO
Imports System.Net.Sockets
Public Class win7
    Dim Client As TcpClient
    Dim row As Integer
    Dim row1 As Integer
    Dim dtable As New DataTable("lab1")
    Dim dtable2 As New DataTable("lab2")
    Dim dtable3 As New DataTable("lab3")
    'Public Shared form1.multishut As New DataTable("shut")

    Public Shared lab1 As Boolean = False
    Public Shared lab2 As Boolean = False
    Public Shared lab3 As Boolean = False
    Public Shared dabelklik As Boolean = False
    Dim add As Boolean = False
    Dim cannot As Boolean = False
    Public Shared id As Integer

    Private Sub win7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listboxview2()
        listboxview()
        listboxview3()
        DataGridView1.DataSource = Form1.multishut
        'form1.multishut.Columns.Add("pcname", GetType(String))
        'form1.multishut.Columns.Add("ipaddr", GetType(String))
    End Sub
    Public Sub listboxview()
        ListBox1.Items.Clear()
        dtable.Clear()
        Dim cnnect As System.Data.OleDb.OleDbConnection
        Dim dtadapter As OleDb.OleDbDataAdapter
        cnnect = New System.Data.OleDb.OleDbConnection
        cnnect.ConnectionString = My.Settings.shutdowndbConnectionString
        cnnect.Open()
        dtadapter = New OleDb.OleDbDataAdapter("SELECT * FROM win7", cnnect)
        dtadapter.Fill(dtable)
        cnnect.Close()

        'ListBox1.DataSource = dtable
        'ListBox1.DisplayMember = "ipaddr"
        'ListBox1.ValueMember = "pcname"
        For Each row As DataRow In dtable.Rows
            ListBox1.Items.Add(row("pcname"))
        Next
    End Sub
    Public Sub listboxview2()
        ListBox2.Items.Clear()
        dtable2.Clear()
        Dim cnnect As System.Data.OleDb.OleDbConnection
        Dim dtadapter As OleDb.OleDbDataAdapter
        cnnect = New System.Data.OleDb.OleDbConnection
        cnnect.ConnectionString = My.Settings.shutdowndbConnectionString
        cnnect.Open()
        dtadapter = New OleDb.OleDbDataAdapter("SELECT * FROM lab2", cnnect)
        dtadapter.Fill(dtable2)
        cnnect.Close()
        For Each row As DataRow In dtable2.Rows
            ListBox2.Items.Add(row("pcname"))
        Next
    End Sub
    Public Sub listboxview3()
        ListBox3.Items.Clear()
        dtable3.Clear()
        Dim cnnect As System.Data.OleDb.OleDbConnection
        Dim dtadapter As OleDb.OleDbDataAdapter
        cnnect = New System.Data.OleDb.OleDbConnection
        cnnect.ConnectionString = My.Settings.shutdowndbConnectionString
        cnnect.Open()
        dtadapter = New OleDb.OleDbDataAdapter("SELECT * FROM lab3", cnnect)
        dtadapter.Fill(dtable3)
        cnnect.Close()
        For Each row As DataRow In dtable3.Rows
            ListBox3.Items.Add(row("pcname"))
        Next
    End Sub
    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        dabelklik = True
        lab1 = True
        lab2 = False
        lab3 = False
        row = ListBox1.SelectedIndex
        Label4.Text = dtable.Rows(row).Item("ipaddr")

        Label2.Text = dtable.Rows(row).Item("pcname")
        id = dtable.Rows(row).Item("ID")
        Try
            If My.Computer.Network.Ping(Label4.Text) Then
                Label6.Text = "ON"
                Label6.BackColor = Color.GreenYellow
            Else
                Label6.Text = "OFF"
                Label6.BackColor = Color.Red

            End If
        Catch ex As Exception
            Label6.Text = "NOT SURE"
            Label6.BackColor = Color.Red
        End Try


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            Try
                Client = New TcpClient(Label4.Text, 8000)
                Dim writer As New StreamWriter(Client.GetStream())
                writer.Write("</> 1 </>")
                writer.Flush()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RadioButton2.Checked = True Then
            For q As Integer = 0 To form1.multishut.Rows.Count - 1
                Try
                    Client = New TcpClient(Form1.multishut.Rows(q).Item("ipaddr"), 8000)
                    Dim writer As New StreamWriter(Client.GetStream())
                    writer.Write("</> 1 </>")
                    writer.Flush()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If RadioButton1.Checked = True Then
            If My.Computer.Network.Ping(Label4.Text) Then
                Label6.Text = "ON"
                Label6.BackColor = Color.GreenYellow
            Else
                Label6.Text = "OFF"
                Label6.BackColor = Color.Red
            End If
        ElseIf RadioButton2.Checked = True Then
            For q As Integer = 0 To form1.multishut.Rows.Count - 1
                If My.Computer.Network.Ping(form1.multishut.Rows(q).Item("ipaddr")) Then
                    MsgBox("PC Name:" + form1.multishut.Rows(q).Item("pcname") + " is still online.")
                    Label6.Text = "ON"
                    Label6.BackColor = Color.GreenYellow
                Else
                    Label6.Text = "OFF"
                    Label6.BackColor = Color.Red
                End If
            Next
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        edit.digit = id
        edit.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If RadioButton1.Checked = True Then
            Try
                Client = New TcpClient(Label4.Text, 8000)
                Dim writer As New StreamWriter(Client.GetStream())
                writer.Write("</> 2 </>")
                writer.Flush()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RadioButton2.Checked = True Then
            For q As Integer = 0 To form1.multishut.Rows.Count - 1
                Try
                    Client = New TcpClient(form1.multishut.Rows(q).Item("ipaddr"), 8000)
                    Dim writer As New StreamWriter(Client.GetStream())
                    writer.Write("</> 2 </>")
                    writer.Flush()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If RadioButton1.Checked = True Then
            Try
                Client = New TcpClient(Label4.Text, 8000)
                Dim writer As New StreamWriter(Client.GetStream())
                writer.Write("</> 3 </>")
                writer.Flush()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RadioButton2.Checked = True Then
            For q As Integer = 0 To form1.multishut.Rows.Count - 1
                Try
                    Client = New TcpClient(form1.multishut.Rows(q).Item("ipaddr"), 8000)
                    Dim writer As New StreamWriter(Client.GetStream())
                    writer.Write("</> 3 </>")
                    writer.Flush()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        DataGridView1.Visible = True
        Button6.Visible = True
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If Label6.Text = "OFF" Then
            MsgBox("Cannot add PC because it is offline.")
        Else
            add = True
            Form1.multishut.Rows.Add(Label2.Text, Label4.Text)
            DataGridView1.DataSource = Form1.multishut
        End If
      
    End Sub
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        DataGridView1.Visible = False
        Button6.Visible = False
    End Sub
    Private Sub ListBox2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox2.DoubleClick
        dabelklik = True
        lab1 = False
        lab2 = True
        lab3 = False
        row = ListBox2.SelectedIndex
        Label4.Text = dtable2.Rows(row).Item("ipaddr")
        Label2.Text = dtable2.Rows(row).Item("pcname")
        id = dtable2.Rows(row).Item("ID")
        Try
            If My.Computer.Network.Ping(Label4.Text) Then
                Label6.Text = "ON"
                Label6.BackColor = Color.GreenYellow
            End If
        Catch ex As Exception
            'Label6.Text = "NOT SURE"
            'Label6.BackColor = Color.Red
            Label6.Text = "OFF"
            Label6.BackColor = Color.Red
        End Try
    End Sub

    Private Sub ListBox3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox3.DoubleClick
        dabelklik = True
        lab1 = False
        lab2 = False
        lab3 = True
        row = ListBox3.SelectedIndex
        Label4.Text = dtable3.Rows(row).Item("ipaddr")
        Label2.Text = dtable3.Rows(row).Item("pcname")
        id = dtable3.Rows(row).Item("ID")
        Try
            If My.Computer.Network.Ping(Label4.Text) Then
                Label6.Text = "ON"
                Label6.BackColor = Color.GreenYellow
            End If
        Catch ex As Exception
            Label6.Text = "OFF"
            Label6.BackColor = Color.Red
        End Try
    End Sub


    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        add = False
        row1 = DataGridView1.CurrentRow.Index
        form1.multishut.Rows(row1).Delete()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If Label6.Text = "OFF" Then
            MsgBox("Cannot set time when PC offline or select PC")
        Else

            If RadioButton1.Checked = True Then
                If dabelklik = False Then
                    MsgBox("Please select PC.")
                Else
                    operationmul.Show()
                End If
            ElseIf RadioButton2.Checked = True Then
                If add = True Then
                    If dabelklik = False Then
                        MsgBox("Please select PC.")
                    Else
                        operationmul.Show()
                    End If
                Else
                    MsgBox("Please add pc into table.")
                End If
            End If
        End If
       
    End Sub
End Class