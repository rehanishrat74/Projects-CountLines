Imports System.IO

Module Module1
    Dim Folder As String
    Sub Main()
        Dim BatchFilePath As String
        Console.WriteLine("Enter The Path : ")
        BatchFilePath = Console.ReadLine() 'DesiredDestPath & " \ " & VSSDBName
        For Each Dir As String In Directory.GetDirectories(BatchFilePath)
            For Each Dir2 As String In Directory.GetDirectories(Dir)
                If Not File.Exists(Dir2 & "\LineCount.bat") Then
                    File.Copy(My.Application.Info.DirectoryPath & "\LineCount.bat", Dir2 & "\LineCount.bat")
                End If
                Folder = Dir2
                If Not File.Exists(Dir2 & "\LineCountLog.txt") Then
                    FileToRun(Dir2 & "\LineCount.bat")
                End If
            Next
            'Console.WriteLine(Dir)
        Next
    End Sub
    Sub FileToRun(ByVal Path As String)
        'Dim psi As New ProcessStartInfo(Path)
        'psi.RedirectStandardError = True
        'psi.RedirectStandardOutput = True
        'psi.CreateNoWindow = True

        'psi.WindowStyle = ProcessWindowStyle.Maximized
        'psi.UseShellExecute = False
        'psi.Arguments = "*.*"
        'psi.Verb = "*.*"
        'Dim process As Process = process.Start(psi)

        Dim proc As New System.Diagnostics.Process()
        proc.StartInfo.UseShellExecute = True
        proc.StartInfo.FileName = Path

        'proc.StartInfo.Arguments = String.Format("{0},{1}", Path, "*.*")

        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
        proc.StartInfo.WorkingDirectory = Folder
        proc.Start()
        proc.WaitForExit()

    End Sub
End Module
