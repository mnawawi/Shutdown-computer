Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Management
Imports System.Net.Sockets
Imports System.Timers
Public Class Form1
    Private atimer As System.Timers.Timer
    Public Shared shutdown As Boolean = False
    Public Shared restart As Boolean = False
    Public Shared logoff As Boolean = False
    Public Shared jam As DateTime
    Public Shared multishut As New DataTable("shut")
    Dim Client As TcpClient
    Dim objMOS As ManagementObjectSearcher
    Dim objMOC As Management.ManagementObjectCollection
    Dim objMO As Management.ManagementObject
    Dim bit As String
    Dim VGA As String
    Dim ramsize As Integer

    Private objOS As Management.ManagementObjectSearcher
    Private objCS As Management.ManagementObjectSearcher
    Private objMgmt As Management.ManagementObject
    Private m_strComputerName As String
    Private m_strManufacturer As String
    Private m_StrModel As String
    Private m_strOSName As String
    Private m_strOSVersion As String
    Private m_strSystemType As String
    Private m_strTPM As String
    Private m_strWindowsDir As String
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        win7.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        multishut.Columns.Add("pcname", GetType(String))
        multishut.Columns.Add("ipaddr", GetType(String))
        Timer1.Start()
        'For Each nic As NetworkInformation.NetworkInterface In NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
        '    Label1.Text = String.Format("The MAC address of {0} is{1}{2}", nic.Description, Environment.NewLine, nic.GetPhysicalAddress())
        '    Exit For
        'Next
        detail()
    End Sub
    Public Sub detail()
        If My.Computer.Registry.LocalMachine.OpenSubKey("Hardware\Description\System\CentralProcessor\0").GetValue("Identifier").ToString.Contains("x86") Then
            bit = "32-bit"
        Else
            bit = "64-bit"
        End If
        Label4.Text = My.Computer.Info.OSFullName.ToString()
        Label6.Text = My.Computer.Info.OSPlatform.ToString()
        Label8.Text = My.Computer.Info.OSVersion.ToString()
        Label10.Text = bit
        Label16.Text = My.Computer.Name.ToString()
        Label12.Text = System.Globalization.CultureInfo.CurrentCulture.DisplayName
        Label14.Text = Date.Now.ToLongDateString + ", " + Date.Now.ToLongTimeString

        ramsize = My.Computer.Info.TotalPhysicalMemory / 1024 / 1024
        Label18.Text = ramsize.ToString & "MB RAM"

        Dim WmiSelect As New ManagementObjectSearcher _
        ("root\CIMV2", "SELECT * FROM Win32_VideoController")
        For Each WmiResults As ManagementObject In WmiSelect.Get()
            VGA = WmiResults.GetPropertyValue("Name").ToString
        Next
        Label20.Text = VGA

        Dim intX As Integer = Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Windows.Forms.Screen.PrimaryScreen.Bounds.Height
        Label22.Text = intX & " X " & intY

        Label24.Text = My.Computer.Info.TotalPhysicalMemory.ToString()
        Label26.Text = My.Computer.Info.TotalVirtualMemory.ToString()
        Label28.Text = My.Computer.Info.AvailableVirtualMemory.ToString()
        Label30.Text = My.Computer.Info.AvailablePhysicalMemory.ToString()
        Label32.Text = My.Computer.Network.IsAvailable.ToString()
    End Sub
    Public Sub win()
        objOS = New Management.ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem")
        objCS = New Management.ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem")
        For Each objMgmt In objOS.Get
            m_strOSName = objMgmt("name").ToString()
            m_strOSVersion = objMgmt("version").ToString()
            m_strComputerName = objMgmt("csname").ToString()
            m_strWindowsDir = objMgmt("windowsdirectory").ToString()
        Next
        For Each objMgmt In objCS.Get
            m_strManufacturer = objMgmt("manufacturer").ToString()
            m_StrModel = objMgmt("model").ToString()
            m_strSystemType = objMgmt("systemtype").ToString
            m_strTPM = objMgmt("totalphysicalmemory").ToString()
        Next
    End Sub

    Public ReadOnly Property ComputerName()
        Get
            ComputerName = m_strComputerName
        End Get
    End Property
    Public ReadOnly Property Manufacturer()
        Get
            Manufacturer = m_strManufacturer
        End Get
    End Property
    Public ReadOnly Property Model()
        Get
            Model = m_StrModel
        End Get
    End Property
    Public ReadOnly Property OsName()
        Get
            OsName = m_strOSName
        End Get
    End Property
    Public ReadOnly Property OSVersion()
        Get
            OSVersion = m_strOSVersion
        End Get
    End Property
    Public ReadOnly Property SystemType()
        Get
            SystemType = m_strSystemType
        End Get
    End Property
    Public ReadOnly Property TotalPhysicalMemory()
        Get
            TotalPhysicalMemory = m_strTPM
        End Get
    End Property
    Public ReadOnly Property WindowsDirectory()
        Get
            WindowsDirectory = m_strWindowsDir
        End Get
    End Property

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        add.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label33.Text = Format(Now, "hh:mm")

        If shutdown = True Then
            If Label33.Text = jam Then
                If win7.RadioButton1.Checked = True Then
                    Try
                        Client = New TcpClient(win7.Label4.Text, 8000)
                        Dim writer As New StreamWriter(Client.GetStream())
                        writer.Write("</> 1 </>")
                        writer.Flush()
                    Catch ex As Exception
                        ' MsgBox(ex.Message)
                    End Try
                ElseIf win7.RadioButton2.Checked = True Then
                    For q As Integer = 0 To multishut.Rows.Count - 1
                        Try
                            Client = New TcpClient(multishut.Rows(q).Item("ipaddr"), 8000)
                            Dim writer As New StreamWriter(Client.GetStream())
                            writer.Write("</> 1 </>")
                            writer.Flush()
                        Catch ex As Exception
                            '  MsgBox(ex.Message)
                        End Try
                    Next

                End If
            End If
        ElseIf restart = True Then
            If Label33.Text = jam Then
                If win7.RadioButton1.Checked = True Then
                    Try
                        Client = New TcpClient(win7.Label4.Text, 8000)
                        Dim writer As New StreamWriter(Client.GetStream())
                        writer.Write("</> 2 </>")
                        writer.Flush()
                    Catch ex As Exception
                        ' MsgBox(ex.Message)
                    End Try
                ElseIf win7.RadioButton2.Checked = True Then
                    For q As Integer = 0 To multishut.Rows.Count - 1
                        Try
                            Client = New TcpClient(multishut.Rows(q).Item("ipaddr"), 8000)
                            Dim writer As New StreamWriter(Client.GetStream())
                            writer.Write("</> 2 </>")
                            writer.Flush()
                        Catch ex As Exception
                            ' MsgBox(ex.Message)
                        End Try
                    Next
                End If
            End If
        ElseIf logoff = True Then
            If Label33.Text = jam Then
                If win7.RadioButton1.Checked = True Then
                    Try
                        Client = New TcpClient(win7.Label4.Text, 8000)
                        Dim writer As New StreamWriter(Client.GetStream())
                        writer.Write("</> 3 </>")
                        writer.Flush()
                    Catch ex As Exception
                        ' MsgBox(ex.Message)
                    End Try
                ElseIf win7.RadioButton2.Checked = True Then
                    For q As Integer = 0 To multishut.Rows.Count - 1
                        Try
                            Client = New TcpClient(multishut.Rows(q).Item("ipaddr"), 8000)
                            Dim writer As New StreamWriter(Client.GetStream())
                            writer.Write("</> 3 </>")
                            writer.Flush()
                        Catch ex As Exception
                            ' MsgBox(ex.Message)
                        End Try
                    Next
                End If
            End If
        End If
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        adduser.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        edituser.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        login.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Timer1.Stop()
        Timer1.Start()
        multishut.Clear()
        jam = Nothing
    End Sub
End Class
