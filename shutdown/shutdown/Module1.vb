Imports System.Management
Module Module1
    'Author : Mohamed Shimran
    'Blog : http://www.ultimateprogrammingtutorials.blogspot.com

    Dim bit As String
    Dim VGA As String
    Sub Main()
        If My.Computer.Registry.LocalMachine.OpenSubKey("Hardware\Description\System\CentralProcessor\0").GetValue("Identifier").ToString.Contains("x86") Then
            bit = "32-bit"
        Else
            bit = "64-bit"
        End If
        ' label1.text = "System Information's"
        MsgBox("your system information's")
        MsgBox("")
        MsgBox(My.Computer.Info.OSFullName.ToString())
        MsgBox(My.Computer.Info.OSPlatform.ToString())
        MsgBox(My.Computer.Info.OSVersion.ToString())
        MsgBox("Windows bit version: " + bit)
        MsgBox("Computer Name: " & My.Computer.Name.ToString())
        MsgBox("Computer Language: " & System.Globalization.CultureInfo.CurrentCulture.DisplayName)
        MsgBox("Current Date/Time: " & Date.Now.ToLongDateString + ", " + Date.Now.ToLongTimeString)
        MsgBox("")
        'Dim objWMI As New win8()
        'With objWMI
        '    MsgBox("Computer Manufacturer = " & .Manufacturer)
        '    MsgBox("Computer Model = " & .Model)
        '    MsgBox("OS Version = " & .OSVersion)
        '    MsgBox("System Type = " & .SystemType)
        '    MsgBox("Windows Directory = " & .WindowsDirectory)
        'End With
        MsgBox("")
        MsgBox("Number of Processes: " & Environment.ProcessorCount.ToString)
        Dim moSearch As New ManagementObjectSearcher("Select * from Win32_Processor")
        Dim moReturn As ManagementObjectCollection = moSearch.Get
        For Each mo As ManagementObject In moReturn
            MsgBox("Processor: " & (mo("name")))
        Next
        Dim ramsize As Integer
        ramsize = My.Computer.Info.TotalPhysicalMemory / 1024 / 1024
        MsgBox("Memory: " & ramsize.ToString & "MB RAM")
        MsgBox("")
        Dim WmiSelect As New ManagementObjectSearcher _
        ("root\CIMV2", "SELECT * FROM Win32_VideoController")
        For Each WmiResults As ManagementObject In WmiSelect.Get()
            VGA = WmiResults.GetPropertyValue("Name").ToString
        Next
        MsgBox("Computer Display Info: " & VGA)
        Dim intX As Integer = Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Windows.Forms.Screen.PrimaryScreen.Bounds.Height
        MsgBox("Screen Resolution: " & intX & " X " & intY)
        MsgBox("")
        MsgBox("Total Physical Memory: " & My.Computer.Info.TotalPhysicalMemory.ToString())
        MsgBox("Total Virtual Memory: " & My.Computer.Info.TotalVirtualMemory.ToString())
        MsgBox("Available Virtual Memory: " & My.Computer.Info.AvailableVirtualMemory.ToString())
        MsgBox("Available Physical Memory: " & My.Computer.Info.AvailablePhysicalMemory.ToString())
        MsgBox("Network Available: " & My.Computer.Network.IsAvailable.ToString())
        MsgBox("")
        MsgBox("")
        MsgBox("Additional Info:")
        MsgBox("Scroll Lock " & My.Computer.Keyboard.ScrollLock)
        MsgBox("Num Lock " & My.Computer.Keyboard.NumLock)
        MsgBox("Caps Lock " & My.Computer.Keyboard.CapsLock)
        MsgBox("")
        MsgBox("Current Processes: ")
        MsgBox("")
        For Each p As Process In Process.GetProcesses
            MsgBox(p)
        Next
        Console.ReadKey()
    End Sub
End Module
