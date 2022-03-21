Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.IO.Path

Module client
  Dim log As StreamWriter
  Dim now As DateTime
  
  ' Function Debbuger - adds String information with DataStampem to log.txt location
  Public Function debbuger( Optional ByVal logmsg As String = "No comment") As String
    log = New StreamWriter("/home/owel/Documents/PROJEKTY/VB on Linux/vbAndNodeSrv/log.txt", True, Encoding.Unicode)
    log.Write(vbCrLf)
    log.Write(DateTime.now.ToString("yyyy-MM-dd HH:mm:ss"))
    log.Write(vbCrLf + "Log:" + " " + logmsg)
    log.Close()
  End Function

  ' GET function - to get the data from url
  Public Function getNode(ByVal url As String, ByVal encoder As String) As String
    Dim myWebClient As WebClient = New WebClient()
    Dim myDataBuffer As Byte() = myWebClient.DownloadData(url)
    Dim SourceCode As String = Encoding.GetEncoding(encoder).GetString(myDataBuffer)
    Return SourceCode
  End Function

  ' Main App
  Public Shared Sub Main()
    Dim answer As String
    
    debbuger("Start")
    
    Console.Write("Hello" + vbCrLf + "Choose 1 and press Enter to GET data:" + vbCrLf)
    answer = Console.ReadLine
    
    If answer = "1" Then
      Console.Write("Downloading...")
      Dim back As String = getNode("http://localhost:5000/get", "UTF-8")
      debbuger(back)
      Console.Write(vbCrLf + back)
    Else 
      Dim wrong As String = getNode("http://localhost:5000/", "UTF-8")
      debbuger(wrong)
      Console.Write("There is no option: " + answer)
      Console.Write(vbCrLf + wrong)
    End If
    
    Console.Write(vbCrLf + "Close APP")
    debbuger("End")
  End Sub
End Module