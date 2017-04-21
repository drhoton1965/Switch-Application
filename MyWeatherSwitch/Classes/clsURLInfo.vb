Imports System.Net
Imports System.IO
Imports System.Configuration

Public Class clsURLInfo
   Inherits baseURL
   Public err As New clsERROR

   Sub New(errHandle As clsERROR)
      Me.StationIDMain = My.Settings.StationIDMain
      Me.StationID1 = My.Settings.StationID1

      Me.URLMain = My.Settings.StationURLMain & Me.StationIDMain
      Me.URL1 = My.Settings.StationURLMain & Me.StationID1
      err = errHandle
   End Sub

   ''' <summary>
   ''' Function to download a file from URL and save it to local drive
   ''' </summary>
   ''' <param name="_URL">URL address to download file</param>
   ''' 
   Public Function DownloadFile(ByVal _URL As String) As String()
      Dim rtnVAL(1) As String
      Dim _SaveAs As String
      Dim aURL As Array
      Dim sFILENAME As String

      Try


         Dim _WebClient As New System.Net.WebClient()

         ' Downloads the resource with the specified URI to a local file.
         If My.Settings.WriteHTMLFile Then
            aURL = Split(_URL, "/")
            sFILENAME = aURL(UBound(aURL)).ToString.Trim

            _SaveAs = My.Settings.HTMLOutFileLocation & "MyWeatherSwitch_" & _
               My.Settings.StationIDMain & "_" & _
               DateTime.Now().ToString("yyyy-MM-dd_hhmms") & ".txt"

            'fSAVE = fSAVE & sFILENAME.Substring(sFILENAME.Length - 4, 4)
            _SaveAs = _SaveAs.Replace("1/2", "half")
            _SaveAs = _SaveAs.Replace("'", "")
            _SaveAs = _SaveAs.Replace("/", "_")
            _SaveAs = _SaveAs.Replace(" ", "_")
            _WebClient.DownloadFile(_URL, _SaveAs)
         End If


         rtnVAL(0) = _WebClient.DownloadString(_URL)
         rtnVAL(1) = "Success"
         'Dim request As WebRequest = WebRequest.Create(_URL)

         '' If required by the server, set the credentials.
         'request.Credentials = CredentialCache.DefaultCredentials
         '' Get the response.
         'Dim response As WebResponse = request.GetResponse()
         '' Display the status.
         'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
         '' Get the stream containing content returned by the server.
         'Dim dataStream As Stream = response.GetResponseStream()
         '' Open the stream using a StreamReader for easy access.
         'Dim reader As New StreamReader(dataStream)
         '' Read the content.
         'rtnVAL(1) = reader.ReadToEnd()
         ''Dim responseFromServer As String = reader.ReadToEnd()
         ''Console.WriteLine(responseFromServer)
      Catch ex As Exception
         Err.MyException = ex
         Err.ErrorMessage = ex.Message
         Err.StackTrace = ex.StackTrace
         Err.DataString = rtnVAL(0).ToString
         err.ClassName = "DownloadFile"
         err.VBFileName = "clsURLInfo.vb"
         Err.WriteFile()
      Finally

      End Try
      Return rtnVAL
   End Function

   Public Sub PullData(ByRef jsonCurOBS As String, _
                       ByRef Resp As Response, _
                       ByRef OBS As CurrentObservation, _
                       ByRef ForeCast As Forecast, _
                       ByRef Astronomy As Astronomy, _
                       ByRef History As History, _
                       ByRef PWS As PwsBootstrap, _
                       ByVal urlInfo As clsURLInfo, _
                       ByVal classOBS As clsObservation, _
                       ByRef PullStatus As String, _
                       Optional optURL As String = ""
                       )
      Dim html() As String

      Try
         If optURL.Trim.Length = 0 Then
            html = urlInfo.DownloadFile(urlInfo.URLMain)
         Else
            html = urlInfo.DownloadFile(optURL)
         End If
         If html(1).Equals("Success") Then
            jsonCurOBS = getJSON(html)
            Resp = New MyWeatherSwitch.Response : Resp = classOBS.buildRESPClass(jsonCurOBS)
            OBS = New MyWeatherSwitch.CurrentObservation : OBS = classOBS.buildOBSClass(jsonCurOBS)
            ForeCast = New MyWeatherSwitch.Forecast : ForeCast = classOBS.buildFORECASTClass(jsonCurOBS)
            Astronomy = New MyWeatherSwitch.Astronomy : Astronomy = classOBS.buildASTRONOMYClass(jsonCurOBS)
            History = New MyWeatherSwitch.History : History = classOBS.buildHISTORYClass(jsonCurOBS)
            'PWS = New MyWeatherSwitch.PwsBootstrap : PWS = classOBS.buildPWSBOOTSTRAPClass(jsonCurOBS)
            PullStatus = "Success-WebUnderground"
            urlInfo.WriteCurrentConditions(OBS)
         Else
            urlInfo.getLocalDataFile(OBS, PullStatus)

         End If
      Catch ex As Exception
         PullStatus = "Failure:"
         err.MyException = ex
         err.ErrorMessage = ex.Message
         err.StackTrace = ex.StackTrace
         err.DataString = ""
         err.ClassName = "PullData"
         err.VBFileName = "clsURLInfo.vb"
         err.WriteFile()
      End Try

   End Sub

   Public Function getJSON(passedHTML() As String) As String
      getJSON = ""
      Dim iDataStart, iDataEnd, iExtractStartPos, iDataLength As Integer
      Try
         iDataStart = passedHTML(0).IndexOf("wui.bootstrapped.pwsdashboard")
         iDataEnd = passedHTML(0).IndexOf("};", (iDataStart + 1))

         iExtractStartPos = iDataStart + "wui.bootstrapped.pwsdashboard".Length + 3
         iDataLength = (iDataEnd - iDataStart - "wui.bootstrapped.pwsdashboard".Length - 2)

         getJSON = passedHTML(0).Substring(iExtractStartPos, iDataLength)

      Catch ex As Exception
         err.MyException = ex
         err.ErrorMessage = ex.Message
         err.StackTrace = ex.StackTrace
         err.DataString = passedHTML.ToString
         err.ClassName = "getJSON"
         err.VBFileName = "clsURLInfo.vb"
         err.WriteFile()
      End Try
   End Function

   Public Sub getLocalDataFile(ByRef curOBS As CurrentObservation, ByRef PullStatus As String)
      Dim filename As String
      Dim fiINFO As FileInfo
      Dim lines() As String
      Dim x As Integer
      curOBS = New CurrentObservation
      Dim aryDATA As Array
      Dim curDATA As String = Nothing
      Try
         filename = My.Settings.AccuriteDataFile
         fiINFO = New FileInfo(filename)
         If fiINFO.Exists() Then
            lines = IO.File.ReadAllLines(filename)
            x = UBound(lines)
            curDATA = lines(x)
            curDATA = curDATA.Replace("""", "")

            aryDATA = Split(curDATA, ",")
            curOBS.date = New pwsDate
            curOBS.date.iso8601 = DateTime.Parse(aryDATA(0))
            curOBS.dewpoint = aryDATA(1)
            curOBS.heatindex = aryDATA(2)
            curOBS.humidity_indoor = aryDATA(3)
            curOBS.temperature_indoor = aryDATA(4)
            curOBS.humidity = aryDATA(5)
            curOBS.temperature = aryDATA(6)
            curOBS.pressure = aryDATA(7)
            curOBS.precip_today = aryDATA(8)
            'curOBS.RainEventDateTime = aryDATA(9)
            curOBS.wind_dir_variable = aryDATA(10)
            curOBS.windchill = aryDATA(11)
            curOBS.wind_speed = aryDATA(12)
            curOBS.wind_dir_degrees = aryDATA(13)
            curOBS.wind_gust_speed = aryDATA(13)
            PullStatus = "Success-LocalDataFile"
         End If
      Catch ex As Exception
         err.MyException = ex
         err.ErrorMessage = ex.Message
         err.StackTrace = ex.StackTrace
         err.DataString = curDATA
         err.ClassName = "getLocalDataFile"
         err.VBFileName = "clsURLInfo.vb"
         err.WriteFile()
         PullStatus = "Failure"
      Finally

      End Try
   End Sub

   Public Sub WriteCurrentConditions(cOBS As CurrentObservation)
      Try

      Catch ex As Exception

      End Try
   End Sub
   'Function De_DupFile(xFileName As String) As String
   '   Dim xNewFileName As String = ""
   '   Dim tFName As Array
   '   Dim headerline As String

   '   Try
   '      Dim xFileInfo As New FileInfo(xFileName)
   '      Dim IsCleanUpFile As Boolean = InStr(xFileName, "Cleaned") > 0
   '      If Not IsCleanUpFile Then
   '         Console.WriteLine("De-Duplicating: " & xFileInfo.Name)
   '         tFName = Split(xFileInfo.Name, "_")

   '         xNewFileName = UCase(tFName(0)) & "_" & UCase(tFName(1)) & "_Cleaned_" & UCase(tFName(2)) & xFileInfo.Extension
   '         xNewFileName = xFileInfo.DirectoryName & "\" & xNewFileName

   '         Dim lines As String() = IO.File.ReadAllLines(xFileName)
   '         If UBound(lines) >= 0 Then
   '            If lines(0).ToString.Trim.Length > 0 Then
   '               headerline = lines(0)
   '            Else
   '               headerline = lines(1)
   '            End If
   '            Array.Sort(lines)

   '            Dim distinctLines As New HashSet(Of String)
   '            distinctLines.Add(headerline)

   '            For Each line As String In lines
   '               If line.Trim.Length > 0 Then
   '                  If line <> headerline Then
   '                     distinctLines.Add(line)
   '                  End If
   '               End If
   '            Next

   '            Array.Resize(lines, distinctLines.Count)

   '            distinctLines.CopyTo(lines)
   '            IO.File.WriteAllLines(xNewFileName, lines)

   '            If File.Exists(xFileName) Then
   '               Dim tEXT As String = xFileInfo.Extension
   '               Dim fNAME As String = xFileInfo.Name
   '               Dim tXXX As Array = Split(fNAME, ".")
   '               Dim yr As String = Year(DateTime.Now())
   '               Dim mt As String = Month(DateTime.Now())
   '               Dim dy As String = Day(DateTime.Now())
   '               If Len(mt) < 2 Then mt = "0" & mt
   '               If Len(dy) < 2 Then dy = "0" & dy
   '               Dim zzzTrgtFileName As String = procDIR & tXXX(0) & "_" & yr & mt & dy & tEXT
   '               If File.Exists(zzzTrgtFileName) Then
   '                  File.Delete(zzzTrgtFileName)
   '               End If
   '               'Create Encrypted File
   '               File.Move(xFileName, zzzTrgtFileName)

   '            End If
   '         Else
   '            xNewFileName = xFileName
   '         End If
   '      Else
   '         xNewFileName = xFileName
   '      End If
   '   Catch ex As Exception
   '      Dim Err As New clsERROR(ex, "ICCIS_Transformation", "De_DupExclusionFile", LineCNT, "")
   '      Err.ShowError()
   '   End Try

   '   Return xNewFileName
   'End Function
End Class
