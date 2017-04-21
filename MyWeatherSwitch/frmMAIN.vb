Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Configuration

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmMain
   Public urlInfo As clsURLInfo
   Public obs As clsObservation
   Public switch As clsSwitch
   Public utl As New clsUTILITIES
   Public stopCLICK As Boolean = False

   '* ********************************
   Public jsonCurOBS As String
   Public curRESP As Response
   Public curOBS As CurrentObservation
   Public curFORECAST As Forecast
   Public curASTRONOMY As Astronomy
   Public curHISTORY As History
   Public curPWS As PwsBootstrap
   '* ********************************
   Public SwitchLog As StreamWriter

   Public fERROR As StreamWriter
   Public ERR As clsERROR

   'Public responseFromServer As String
   'Public Shared jsonKeyValues As New Dictionary(Of String, String)()
   Public jo As JObject

   '* ***************************************** *
   '* Testing additions for GitHub for Learning *
   '* Bla Bla Bla *
   '* ***************************************** *
   
   Private Sub btnLoadURL_Click(sender As Object, e As EventArgs) Handles btnLoadURL.Click
      Dim PullStatus As String = ""
      urlInfo.PullData(jsonCurOBS, curRESP, curOBS, curFORECAST, curASTRONOMY, curHISTORY, curPWS, urlInfo, obs, PullStatus)
      Console.WriteLine("Stop Look!!!")
   End Sub

   Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      fERROR = New StreamWriter("C:\DLRStuff\MySwitchData\Errors\ErrorList" & DateTime.Now.ToString("yyyyMMdd") & ".txt", True)
      ERR = New clsERROR(Nothing, fERROR)
      urlInfo = New clsURLInfo(ERR)
      obs = New clsObservation(ERR)
      switch = New clsSwitch(ERR)
      pnlDailySchedule.Visible = True
      pnlAppRunning.Visible = False
      pnlAppRunningButtons.Visible = True
      btnStart.Enabled = True
      btnStop.Enabled = False
      btnExit.Enabled = True

      dtpMondayOn1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.MondayOn1)
      dtpMondayOn2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.MondayOn2)
      dtpMondayOn3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.MondayOn3)
      dtpMondayOn4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.MondayOn4)
      dtpMondayOn5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.MondayOn5)

      dtpMondayOff1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.MondayOff1)
      dtpMondayOff2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.MondayOff2)
      dtpMondayOff3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.MondayOff3)
      dtpMondayOff4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.MondayOff4)
      dtpMondayOff5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.MondayOff5)
      '******************************************************************************************************************************

      dtpTuesdayOn1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.TuesdayOn1)
      dtpTuesdayOn2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.TuesdayOn2)
      dtpTuesdayOn3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.TuesdayOn3)
      dtpTuesdayOn4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.TuesdayOn4)
      dtpTuesdayOn5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.TuesdayOn5)

      dtpTuesdayOff1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.TuesdayOff1)
      dtpTuesdayOff2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.TuesdayOff2)
      dtpTuesdayOff3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.TuesdayOff3)
      dtpTuesdayOff4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.TuesdayOff4)
      dtpTuesdayOff5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.TuesdayOff5)
      '******************************************************************************************************************************

      dtpWednesdayOn1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.WednesdayOn1)
      dtpWednesdayOn2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.WednesdayOn2)
      dtpWednesdayOn3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.WednesdayOn3)
      dtpWednesdayOn4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.WednesdayOn4)
      dtpWednesdayOn5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.WednesdayOn5)

      dtpWednesdayOff1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.WednesdayOff1)
      dtpWednesdayOff2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.WednesdayOff2)
      dtpWednesdayOff3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.WednesdayOff3)
      dtpWednesdayOff4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.WednesdayOff4)
      dtpWednesdayOff5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.WednesdayOff5)
      '******************************************************************************************************************************


      dtpThursdayOn1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.ThursdayOn1)
      dtpThursdayOn2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.ThursdayOn2)
      dtpThursdayOn3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.ThursdayOn3)
      dtpThursdayOn4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.ThursdayOn4)
      dtpThursdayOn5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.ThursdayOn5)

      dtpThursdayOff1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.ThursdayOff1)
      dtpThursdayOff2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.ThursdayOff2)
      dtpThursdayOff3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.ThursdayOff3)
      dtpThursdayOff4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.ThursdayOff4)
      dtpThursdayOff5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.ThursdayOff5)
      '******************************************************************************************************************************


      dtpFridayOn1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.FridayOn1)
      dtpFridayOn2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.FridayOn2)
      dtpFridayOn3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.FridayOn3)
      dtpFridayOn4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.FridayOn4)
      dtpFridayOn5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.FridayOn5)

      dtpFridayOff1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.FridayOff1)
      dtpFridayOff2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.FridayOff2)
      dtpFridayOff3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.FridayOff3)
      dtpFridayOff4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.FridayOff4)
      dtpFridayOff5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.FridayOff5)
      '******************************************************************************************************************************

      dtpSaturdayOn1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SaturdayOn1)
      dtpSaturdayOn2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SaturdayOn2)
      dtpSaturdayOn3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SaturdayOn3)
      dtpSaturdayOn4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SaturdayOn4)
      dtpSaturdayOn5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SaturdayOn5)

      dtpSaturdayOff1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SaturdayOff1)
      dtpSaturdayOff2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SaturdayOff2)
      dtpSaturdayOff3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SaturdayOff3)
      dtpSaturdayOff4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SaturdayOff4)
      dtpSaturdayOff5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SaturdayOff5)
      '******************************************************************************************************************************

      dtpSundayOn1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SundayOn1)
      dtpSundayOn2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SundayOn2)
      dtpSundayOn3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SundayOn3)
      dtpSundayOn4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SundayOn4)
      dtpSundayOn5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SundayOn5)

      dtpSundayOff1.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SundayOff1)
      dtpSundayOff2.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SundayOff2)
      dtpSundayOff3.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SundayOff3)
      dtpSundayOff4.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SundayOff4)
      dtpSundayOff5.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) + TimeSpan.FromMinutes(My.Settings.SundayOff5)
      '******************************************************************************************************************************

      'Set up Switch Log
      Dim tagYrMt As String = DateTime.Now.ToString("yyyyMM")
      Dim filename As String = "C:\DLRStuff\MySwitchData\MyWeatherSwitch_SwitchLog(" & tagYrMt & ").log"
      Dim fi As FileInfo = New FileInfo(filename)
      Dim curExists As Boolean = fi.Exists

      SwitchLog = New StreamWriter(filename, True)

      If Not curExists Then
         SwitchLog.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                                     "DateTime", _
                                     "Current Switch Status", _
                                     "Wind Action", _
                                     "Timer Status", _
                                     "Timer Action", _
                                     "Wind Speed", _
                                     "Wind Gusts")
      End If

   End Sub

   Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
      Dim frm As New frmSystemConfig
      frm.Show()
   End Sub

   Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
      SwitchLog.Flush()
      SwitchLog.Close()
      Me.Close()

      Application.Exit()
      End
   End Sub

   Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
      Dim WindSpeedOk As Boolean = False
      Dim TimerOn As Boolean = False
      pnlDailySchedule.Visible = False
      pnlAppRunning.Visible = True
      pnlAppRunningButtons.Visible = False
      btnStart.Enabled = False
      btnStop.Enabled = True
      btnExit.Enabled = False

      Dim PullStatus As String = ""

      stopCLICK = False

      While Not stopCLICK

         lblAppStatus.Text = "Pulling data from Internet..."
         Me.Refresh()
         urlInfo.PullData(jsonCurOBS, curRESP, curOBS, curFORECAST, curASTRONOMY, curHISTORY, curPWS, urlInfo, obs, PullStatus)
         lblAppStatus.Text = "Analyzing Wind Speed..."
         lblWindSpeed.Text = curOBS.wind_speed
         lblWindGustSpeed.Text = curOBS.wind_gust_speed
         lblWindDirection.Text = curOBS.wind_dir & "  " & curOBS.wind_dir_degrees
         lblWindVariable.Text = curOBS.wind_dir_variable

         Me.Refresh()
         WindSpeedOk = switch.isWindSpeedOK(curOBS)
         TimerOn = switch.isWithinTimers(Me)

         If TimerOn Then
            If WindSpeedOk Then
               If switch.isOn Then
                  switch.VerifySwitchOn()
                  lblSwitchStatus.Text = "ON"
                  lblSwitchStatus.BackColor = Color.Green
                  SwitchLog.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                                      DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _
                                      "ON", _
                                      "", _
                                      "ON", _
                                      "", _
                                      curOBS.wind_speed, _
                                      curOBS.wind_gust_speed)
               Else
                  switch.TurnSwitchON()
                  lblSwitchStatus.Text = "ON"
                  lblSwitchStatus.BackColor = Color.Green
                  SwitchLog.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                                      DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _
                                      "OFF", _
                                      "Turn ON", _
                                      "ON", _
                                      "", _
                                      curOBS.wind_speed, _
                                      curOBS.wind_gust_speed)
               End If
            Else 'Turn switch off because of Wind Speed
               If switch.isOn Then
                  switch.TurnSwitchOFF()
                  lblSwitchStatus.Text = "OFF (Wind Speed)"
                  lblSwitchStatus.BackColor = Color.Red
                  SwitchLog.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                                      DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _
                                      "ON", _
                                      "Turn OFF", _
                                      "ON", _
                                      "", _
                                      curOBS.wind_speed, _
                                      curOBS.wind_gust_speed)
               Else
                  switch.VerifySwitchOff()
                  lblSwitchStatus.Text = "OFF (Wind Speed)"
                  lblSwitchStatus.BackColor = Color.Red
                  SwitchLog.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                                      DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _
                                      "OFF", _
                                      "", _
                                      "ON", _
                                      "", _
                                      curOBS.wind_speed, _
                                      curOBS.wind_gust_speed)
               End If
            End If
         Else
            If switch.isOn Then
               switch.TurnSwitchOFF()
               lblSwitchStatus.Text = "OFF (Timer)"
               lblSwitchStatus.BackColor = Color.Red
               SwitchLog.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                                      DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _
                                      "ON", _
                                      "", _
                                      "OFF", _
                                      "Turn Off", _
                                      curOBS.wind_speed, _
                                      curOBS.wind_gust_speed)
            Else
               switch.VerifySwitchOff()
               lblSwitchStatus.Text = "OFF (Timer)"
               lblSwitchStatus.BackColor = Color.Red
               SwitchLog.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                                      DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _
                                      "OFF", _
                                      "", _
                                      "OFF", _
                                      "", _
                                      curOBS.wind_speed, _
                                      curOBS.wind_gust_speed)
            End If
         End If
         SwitchLog.Flush()

         Me.Refresh()
         lblAppStatus.Text = "Sleeping (" & (My.Settings.SleepTimer / 1000).ToString & " seconds)..."
         Me.Refresh()
         Application.DoEvents()

         If Not stopCLICK Then
            If DateTime.Now > DateTime.Parse(DateTime.Now.ToString("MM/dd/yyy") & " 23:57") Then
               obs.WriteDailyOBSLog(curHISTORY)
               'Output Second Station in Otis, OR
               urlInfo.PullData(jsonCurOBS, curRESP, curOBS, curFORECAST, curASTRONOMY, curHISTORY, curPWS, urlInfo, obs, PullStatus, (My.Settings.StationURLMain & My.Settings.StationID1))
               obs.WriteDailyOBSLog(curHISTORY, My.Settings.StationID1)

               'Output Station in Jerome, ID

               Dim lclStationID As String = Mid(My.Settings.StationJerome1, My.Settings.StationJerome1.Length - 9, 9)
               urlInfo.PullData(jsonCurOBS, curRESP, curOBS, curFORECAST, curASTRONOMY, curHISTORY, curPWS, urlInfo, obs, PullStatus, My.Settings.StationJerome1)
               obs.WriteDailyOBSLog(curHISTORY, lclStationID)
            End If
            utl.GoSleep(My.Settings.SleepTimer, stopCLICK)
         End If
      End While
      pnlDailySchedule.Visible = True
      pnlAppRunning.Visible = False
      pnlAppRunningButtons.Visible = True
      btnStart.Enabled = True
      btnStop.Enabled = False
      btnExit.Enabled = True
      lblAppStatus.Text = "Stopped process..."
   End Sub

   Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
      stopCLICK = True
   End Sub

   Private Sub dtpMondayOn1_LostFocus(sender As Object, e As EventArgs) Handles dtpMondayOn1.LostFocus
      My.Settings.MondayOn1 = (Integer.Parse(dtpMondayOn1.Value.ToString("HH")) * 60) + Integer.Parse(dtpMondayOn1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpMondayOff1_LostFocus(sender As Object, e As EventArgs) Handles dtpMondayOff1.LostFocus
      My.Settings.MondayOff1 = (Integer.Parse(dtpMondayOff1.Value.ToString("HH")) * 60) + Integer.Parse(dtpMondayOff1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpMondayOn2_LostFocus(sender As Object, e As EventArgs) Handles dtpMondayOn2.LostFocus
      My.Settings.MondayOn2 = (Integer.Parse(dtpMondayOn2.Value.ToString("HH")) * 60) + Integer.Parse(dtpMondayOn2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpMondayOff2_LostFocus(sender As Object, e As EventArgs) Handles dtpMondayOff2.LostFocus
      My.Settings.MondayOff2 = (Integer.Parse(dtpMondayOff2.Value.ToString("HH")) * 60) + Integer.Parse(dtpMondayOff2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpMondayOn3_LostFocus(sender As Object, e As EventArgs) Handles dtpMondayOn3.LostFocus
      My.Settings.MondayOn3 = (Integer.Parse(dtpMondayOn3.Value.ToString("HH")) * 60) + Integer.Parse(dtpMondayOn3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpMondayOff3_LostFocus(sender As Object, e As EventArgs) Handles dtpMondayOff3.LostFocus
      My.Settings.MondayOff3 = (Integer.Parse(dtpMondayOff3.Value.ToString("HH")) * 60) + Integer.Parse(dtpMondayOff3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpMondayOn4_LostFocus(sender As Object, e As EventArgs) Handles dtpMondayOn4.LostFocus
      My.Settings.MondayOn4 = (Integer.Parse(dtpMondayOn4.Value.ToString("HH")) * 60) + Integer.Parse(dtpMondayOn4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpMondayOff4_LostFocus(sender As Object, e As EventArgs) Handles dtpMondayOff4.LostFocus
      My.Settings.MondayOff4 = (Integer.Parse(dtpMondayOff4.Value.ToString("HH")) * 60) + Integer.Parse(dtpMondayOff4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpMondayOn5_LostFocus(sender As Object, e As EventArgs) Handles dtpMondayOn5.LostFocus
      My.Settings.MondayOn5 = (Integer.Parse(dtpMondayOn5.Value.ToString("HH")) * 60) + Integer.Parse(dtpMondayOn5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpMondayOff5_LostFocus(sender As Object, e As EventArgs) Handles dtpMondayOff5.LostFocus
      My.Settings.MondayOff5 = (Integer.Parse(dtpMondayOff5.Value.ToString("HH")) * 60) + Integer.Parse(dtpMondayOff5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   ' *****************************************************************************************************************************
   Private Sub dtpTuesdayOn1_LostFocus(sender As Object, e As EventArgs) Handles dtpTuesdayOn1.LostFocus
      My.Settings.TuesdayOn1 = (Integer.Parse(dtpTuesdayOn1.Value.ToString("HH")) * 60) + Integer.Parse(dtpTuesdayOn1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpTuesdayOff1_LostFocus(sender As Object, e As EventArgs) Handles dtpTuesdayOff1.LostFocus
      My.Settings.TuesdayOff1 = (Integer.Parse(dtpTuesdayOff1.Value.ToString("HH")) * 60) + Integer.Parse(dtpTuesdayOff1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpTuesdayOn2_LostFocus(sender As Object, e As EventArgs) Handles dtpTuesdayOn2.LostFocus
      My.Settings.TuesdayOn2 = (Integer.Parse(dtpTuesdayOn2.Value.ToString("HH")) * 60) + Integer.Parse(dtpTuesdayOn2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpTuesdayOff2_LostFocus(sender As Object, e As EventArgs) Handles dtpTuesdayOff2.LostFocus
      My.Settings.TuesdayOff2 = (Integer.Parse(dtpTuesdayOff2.Value.ToString("HH")) * 60) + Integer.Parse(dtpTuesdayOff2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpTuesdayOn3_LostFocus(sender As Object, e As EventArgs) Handles dtpTuesdayOn3.LostFocus
      My.Settings.TuesdayOn3 = (Integer.Parse(dtpTuesdayOn3.Value.ToString("HH")) * 60) + Integer.Parse(dtpTuesdayOn3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpTuesdayOff3_LostFocus(sender As Object, e As EventArgs) Handles dtpTuesdayOff3.LostFocus
      My.Settings.TuesdayOff3 = (Integer.Parse(dtpTuesdayOff3.Value.ToString("HH")) * 60) + Integer.Parse(dtpTuesdayOff3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpTuesdayOn4_LostFocus(sender As Object, e As EventArgs) Handles dtpTuesdayOn4.LostFocus
      My.Settings.TuesdayOn4 = (Integer.Parse(dtpTuesdayOn4.Value.ToString("HH")) * 60) + Integer.Parse(dtpTuesdayOn4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpTuesdayOff4_LostFocus(sender As Object, e As EventArgs) Handles dtpTuesdayOff4.LostFocus
      My.Settings.TuesdayOff4 = (Integer.Parse(dtpTuesdayOff4.Value.ToString("HH")) * 60) + Integer.Parse(dtpTuesdayOff4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpTuesdayOn5_LostFocus(sender As Object, e As EventArgs) Handles dtpTuesdayOn5.LostFocus
      My.Settings.TuesdayOn5 = (Integer.Parse(dtpTuesdayOn5.Value.ToString("HH")) * 60) + Integer.Parse(dtpTuesdayOn5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpTuesdayOff5_LostFocus(sender As Object, e As EventArgs) Handles dtpTuesdayOff5.LostFocus
      My.Settings.TuesdayOff5 = (Integer.Parse(dtpTuesdayOff5.Value.ToString("HH")) * 60) + Integer.Parse(dtpTuesdayOff5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   ' *****************************************************************************************************************************
   Private Sub dtpWednesdayOn1_LostFocus(sender As Object, e As EventArgs) Handles dtpWednesdayOn1.LostFocus
      My.Settings.WednesdayOn1 = (Integer.Parse(dtpWednesdayOn1.Value.ToString("HH")) * 60) + Integer.Parse(dtpWednesdayOn1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpWednesdayOff1_LostFocus(sender As Object, e As EventArgs) Handles dtpWednesdayOff1.LostFocus
      My.Settings.WednesdayOff1 = (Integer.Parse(dtpWednesdayOff1.Value.ToString("HH")) * 60) + Integer.Parse(dtpWednesdayOff1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpWednesdayOn2_LostFocus(sender As Object, e As EventArgs) Handles dtpWednesdayOn2.LostFocus
      My.Settings.WednesdayOn2 = (Integer.Parse(dtpWednesdayOn2.Value.ToString("HH")) * 60) + Integer.Parse(dtpWednesdayOn2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpWednesdayOff2_LostFocus(sender As Object, e As EventArgs) Handles dtpWednesdayOff2.LostFocus
      My.Settings.WednesdayOff2 = (Integer.Parse(dtpWednesdayOff2.Value.ToString("HH")) * 60) + Integer.Parse(dtpWednesdayOff2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpWednesdayOn3_LostFocus(sender As Object, e As EventArgs) Handles dtpWednesdayOn3.LostFocus
      My.Settings.WednesdayOn3 = (Integer.Parse(dtpWednesdayOn3.Value.ToString("HH")) * 60) + Integer.Parse(dtpWednesdayOn3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpWednesdayOff3_LostFocus(sender As Object, e As EventArgs) Handles dtpWednesdayOff3.LostFocus
      My.Settings.WednesdayOff3 = (Integer.Parse(dtpWednesdayOff3.Value.ToString("HH")) * 60) + Integer.Parse(dtpWednesdayOff3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpWednesdayOn4_LostFocus(sender As Object, e As EventArgs) Handles dtpWednesdayOn4.LostFocus
      My.Settings.WednesdayOn4 = (Integer.Parse(dtpWednesdayOn4.Value.ToString("HH")) * 60) + Integer.Parse(dtpWednesdayOn4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpWednesdayOff4_LostFocus(sender As Object, e As EventArgs) Handles dtpWednesdayOff4.LostFocus
      My.Settings.WednesdayOff4 = (Integer.Parse(dtpWednesdayOff4.Value.ToString("HH")) * 60) + Integer.Parse(dtpWednesdayOff4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpWednesdayOn5_LostFocus(sender As Object, e As EventArgs) Handles dtpWednesdayOn5.LostFocus
      My.Settings.WednesdayOn5 = (Integer.Parse(dtpWednesdayOn5.Value.ToString("HH")) * 60) + Integer.Parse(dtpWednesdayOn5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpWednesdayOff5_LostFocus(sender As Object, e As EventArgs) Handles dtpWednesdayOff5.LostFocus
      My.Settings.WednesdayOff5 = (Integer.Parse(dtpWednesdayOff5.Value.ToString("HH")) * 60) + Integer.Parse(dtpWednesdayOff5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   ' *****************************************************************************************************************************
   Private Sub dtpThursdayOn1_LostFocus(sender As Object, e As EventArgs) Handles dtpThursdayOn1.LostFocus
      My.Settings.ThursdayOn1 = (Integer.Parse(dtpThursdayOn1.Value.ToString("HH")) * 60) + Integer.Parse(dtpThursdayOn1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpThursdayOff1_LostFocus(sender As Object, e As EventArgs) Handles dtpThursdayOff1.LostFocus
      My.Settings.ThursdayOff1 = (Integer.Parse(dtpThursdayOff1.Value.ToString("HH")) * 60) + Integer.Parse(dtpThursdayOff1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpThursdayOn2_LostFocus(sender As Object, e As EventArgs) Handles dtpThursdayOn2.LostFocus
      My.Settings.ThursdayOn2 = (Integer.Parse(dtpThursdayOn2.Value.ToString("HH")) * 60) + Integer.Parse(dtpThursdayOn2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpThursdayOff2_LostFocus(sender As Object, e As EventArgs) Handles dtpThursdayOff2.LostFocus
      My.Settings.ThursdayOff2 = (Integer.Parse(dtpThursdayOff2.Value.ToString("HH")) * 60) + Integer.Parse(dtpThursdayOff2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpThursdayOn3_LostFocus(sender As Object, e As EventArgs) Handles dtpThursdayOn3.LostFocus
      My.Settings.ThursdayOn3 = (Integer.Parse(dtpThursdayOn3.Value.ToString("HH")) * 60) + Integer.Parse(dtpThursdayOn3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpThursdayOff3_LostFocus(sender As Object, e As EventArgs) Handles dtpThursdayOff3.LostFocus
      My.Settings.ThursdayOff3 = (Integer.Parse(dtpThursdayOff3.Value.ToString("HH")) * 60) + Integer.Parse(dtpThursdayOff3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpThursdayOn4_LostFocus(sender As Object, e As EventArgs) Handles dtpThursdayOn4.LostFocus
      My.Settings.ThursdayOn4 = (Integer.Parse(dtpThursdayOn4.Value.ToString("HH")) * 60) + Integer.Parse(dtpThursdayOn4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpThursdayOff4_LostFocus(sender As Object, e As EventArgs) Handles dtpThursdayOff4.LostFocus
      My.Settings.ThursdayOff4 = (Integer.Parse(dtpThursdayOff4.Value.ToString("HH")) * 60) + Integer.Parse(dtpThursdayOff4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpThursdayOn5_LostFocus(sender As Object, e As EventArgs) Handles dtpThursdayOn5.LostFocus
      My.Settings.ThursdayOn5 = (Integer.Parse(dtpThursdayOn5.Value.ToString("HH")) * 60) + Integer.Parse(dtpThursdayOn5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpThursdayOff5_LostFocus(sender As Object, e As EventArgs) Handles dtpThursdayOff5.LostFocus
      My.Settings.ThursdayOff5 = (Integer.Parse(dtpThursdayOff5.Value.ToString("HH")) * 60) + Integer.Parse(dtpThursdayOff5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   ' *****************************************************************************************************************************
   Private Sub dtpFridayOn1_LostFocus(sender As Object, e As EventArgs) Handles dtpFridayOn1.LostFocus
      My.Settings.FridayOn1 = (Integer.Parse(dtpFridayOn1.Value.ToString("HH")) * 60) + Integer.Parse(dtpFridayOn1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpFridayOff1_LostFocus(sender As Object, e As EventArgs) Handles dtpFridayOff1.LostFocus
      My.Settings.FridayOff1 = (Integer.Parse(dtpFridayOff1.Value.ToString("HH")) * 60) + Integer.Parse(dtpFridayOff1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpFridayOn2_LostFocus(sender As Object, e As EventArgs) Handles dtpFridayOn2.LostFocus
      My.Settings.FridayOn2 = (Integer.Parse(dtpFridayOn2.Value.ToString("HH")) * 60) + Integer.Parse(dtpFridayOn2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpFridayOff2_LostFocus(sender As Object, e As EventArgs) Handles dtpFridayOff2.LostFocus
      My.Settings.FridayOff2 = (Integer.Parse(dtpFridayOff2.Value.ToString("HH")) * 60) + Integer.Parse(dtpFridayOff2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpFridayOn3_LostFocus(sender As Object, e As EventArgs) Handles dtpFridayOn3.LostFocus
      My.Settings.FridayOn3 = (Integer.Parse(dtpFridayOn3.Value.ToString("HH")) * 60) + Integer.Parse(dtpFridayOn3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpFridayOff3_LostFocus(sender As Object, e As EventArgs) Handles dtpFridayOff3.LostFocus
      My.Settings.FridayOff3 = (Integer.Parse(dtpFridayOff3.Value.ToString("HH")) * 60) + Integer.Parse(dtpFridayOff3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpFridayOn4_LostFocus(sender As Object, e As EventArgs) Handles dtpFridayOn4.LostFocus
      My.Settings.FridayOn4 = (Integer.Parse(dtpFridayOn4.Value.ToString("HH")) * 60) + Integer.Parse(dtpFridayOn4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpFridayOff4_LostFocus(sender As Object, e As EventArgs) Handles dtpFridayOff4.LostFocus
      My.Settings.FridayOff4 = (Integer.Parse(dtpFridayOff4.Value.ToString("HH")) * 60) + Integer.Parse(dtpFridayOff4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpFridayOn5_LostFocus(sender As Object, e As EventArgs) Handles dtpFridayOn5.LostFocus
      My.Settings.FridayOn5 = (Integer.Parse(dtpFridayOn5.Value.ToString("HH")) * 60) + Integer.Parse(dtpFridayOn5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpFridayOff5_LostFocus(sender As Object, e As EventArgs) Handles dtpFridayOff5.LostFocus
      My.Settings.FridayOff5 = (Integer.Parse(dtpFridayOff5.Value.ToString("HH")) * 60) + Integer.Parse(dtpFridayOff5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   ' *****************************************************************************************************************************
   Private Sub dtpSaturdayOn1_LostFocus(sender As Object, e As EventArgs) Handles dtpSaturdayOn1.LostFocus
      My.Settings.SaturdayOn1 = (Integer.Parse(dtpSaturdayOn1.Value.ToString("HH")) * 60) + Integer.Parse(dtpSaturdayOn1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpSaturdayOff1_LostFocus(sender As Object, e As EventArgs) Handles dtpSaturdayOff1.LostFocus
      My.Settings.SaturdayOff1 = (Integer.Parse(dtpSaturdayOff1.Value.ToString("HH")) * 60) + Integer.Parse(dtpSaturdayOff1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpSaturdayOn2_LostFocus(sender As Object, e As EventArgs) Handles dtpSaturdayOn2.LostFocus
      My.Settings.SaturdayOn2 = (Integer.Parse(dtpSaturdayOn2.Value.ToString("HH")) * 60) + Integer.Parse(dtpSaturdayOn2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpSaturdayOff2_LostFocus(sender As Object, e As EventArgs) Handles dtpSaturdayOff2.LostFocus
      My.Settings.SaturdayOff2 = (Integer.Parse(dtpSaturdayOff2.Value.ToString("HH")) * 60) + Integer.Parse(dtpSaturdayOff2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpSaturdayOn3_LostFocus(sender As Object, e As EventArgs) Handles dtpSaturdayOn3.LostFocus
      My.Settings.SaturdayOn3 = (Integer.Parse(dtpSaturdayOn3.Value.ToString("HH")) * 60) + Integer.Parse(dtpSaturdayOn3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpSaturdayOff3_LostFocus(sender As Object, e As EventArgs) Handles dtpSaturdayOff3.LostFocus
      My.Settings.SaturdayOff3 = (Integer.Parse(dtpSaturdayOff3.Value.ToString("HH")) * 60) + Integer.Parse(dtpSaturdayOff3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpSaturdayOn4_LostFocus(sender As Object, e As EventArgs) Handles dtpSaturdayOn4.LostFocus
      My.Settings.SaturdayOn4 = (Integer.Parse(dtpSaturdayOn4.Value.ToString("HH")) * 60) + Integer.Parse(dtpSaturdayOn4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpSaturdayOff4_LostFocus(sender As Object, e As EventArgs) Handles dtpSaturdayOff4.LostFocus
      My.Settings.SaturdayOff4 = (Integer.Parse(dtpSaturdayOff4.Value.ToString("HH")) * 60) + Integer.Parse(dtpSaturdayOff4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpSaturdayOn5_LostFocus(sender As Object, e As EventArgs) Handles dtpSaturdayOn5.LostFocus
      My.Settings.SaturdayOn5 = (Integer.Parse(dtpSaturdayOn5.Value.ToString("HH")) * 60) + Integer.Parse(dtpSaturdayOn5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpSaturdayOff5_LostFocus(sender As Object, e As EventArgs) Handles dtpSaturdayOff5.LostFocus
      My.Settings.SaturdayOff5 = (Integer.Parse(dtpSaturdayOff5.Value.ToString("HH")) * 60) + Integer.Parse(dtpSaturdayOff5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   ' *****************************************************************************************************************************
   Private Sub dtpSundayOn1_LostFocus(sender As Object, e As EventArgs) Handles dtpSundayOn1.LostFocus
      My.Settings.SundayOn1 = (Integer.Parse(dtpSundayOn1.Value.ToString("HH")) * 60) + Integer.Parse(dtpSundayOn1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpSundayOff1_LostFocus(sender As Object, e As EventArgs) Handles dtpSundayOff1.LostFocus
      My.Settings.SundayOff1 = (Integer.Parse(dtpSundayOff1.Value.ToString("HH")) * 60) + Integer.Parse(dtpSundayOff1.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpSundayOn2_LostFocus(sender As Object, e As EventArgs) Handles dtpSundayOn2.LostFocus
      My.Settings.SundayOn2 = (Integer.Parse(dtpSundayOn2.Value.ToString("HH")) * 60) + Integer.Parse(dtpSundayOn2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpSundayOff2_LostFocus(sender As Object, e As EventArgs) Handles dtpSundayOff2.LostFocus
      My.Settings.SundayOff2 = (Integer.Parse(dtpSundayOff2.Value.ToString("HH")) * 60) + Integer.Parse(dtpSundayOff2.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpSundayOn3_LostFocus(sender As Object, e As EventArgs) Handles dtpSundayOn3.LostFocus
      My.Settings.SundayOn3 = (Integer.Parse(dtpSundayOn3.Value.ToString("HH")) * 60) + Integer.Parse(dtpSundayOn3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpSundayOff3_LostFocus(sender As Object, e As EventArgs) Handles dtpSundayOff3.LostFocus
      My.Settings.SundayOff3 = (Integer.Parse(dtpSundayOff3.Value.ToString("HH")) * 60) + Integer.Parse(dtpSundayOff3.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpSundayOn4_LostFocus(sender As Object, e As EventArgs) Handles dtpSundayOn4.LostFocus
      My.Settings.SundayOn4 = (Integer.Parse(dtpSundayOn4.Value.ToString("HH")) * 60) + Integer.Parse(dtpSundayOn4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpSundayOff4_LostFocus(sender As Object, e As EventArgs) Handles dtpSundayOff4.LostFocus
      My.Settings.SundayOff4 = (Integer.Parse(dtpSundayOff4.Value.ToString("HH")) * 60) + Integer.Parse(dtpSundayOff4.Value.ToString("mm"))
      My.Settings.Save()
   End Sub

   Private Sub dtpSundayOn5_LostFocus(sender As Object, e As EventArgs) Handles dtpSundayOn5.LostFocus
      My.Settings.SundayOn5 = (Integer.Parse(dtpSundayOn5.Value.ToString("HH")) * 60) + Integer.Parse(dtpSundayOn5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   Private Sub dtpSundayOff5_LostFocus(sender As Object, e As EventArgs) Handles dtpSundayOff5.LostFocus
      My.Settings.SundayOff5 = (Integer.Parse(dtpSundayOff5.Value.ToString("HH")) * 60) + Integer.Parse(dtpSundayOff5.Value.ToString("mm"))
      My.Settings.Save()
   End Sub
   ' *****************************************************************************************************************************

   Private Sub btnHistoryLog_Click(sender As Object, e As EventArgs) Handles btnHistoryLog.Click
      Dim PullStatus As String = ""
      urlInfo.PullData(jsonCurOBS, curRESP, curOBS, curFORECAST, curASTRONOMY, curHISTORY, curPWS, urlInfo, obs, PullStatus)
      obs.WriteDailyOBSLog(curHISTORY)

   End Sub

   Private Sub btnPullLocalDataFile_Click(sender As Object, e As EventArgs) Handles btnPullLocalDataFile.Click
      Dim PullStatus As String = ""
      urlInfo.getLocalDataFile(curOBS, PullStatus)

   End Sub

   Private Sub btnGetStation8Data_Click(sender As Object, e As EventArgs) Handles btnGetStation8Data.Click
      Dim PullStatus As String = ""
      Dim optURL As String = My.Settings.StationURLMain & My.Settings.StationID1

      urlInfo.PullData(jsonCurOBS, curRESP, curOBS, curFORECAST, curASTRONOMY, curHISTORY, curPWS, urlInfo, obs, PullStatus, optURL)
      obs.WriteDailyOBSLog(curHISTORY, My.Settings.StationID1)
   End Sub

   Private Sub btnOverrideOn_Click(sender As Object, e As EventArgs) Handles btnOverrideOn.Click
      stopCLICK = True
      If switch.isOn Then
         switch.VerifySwitchOn()
         lblSwitchStatus.Text = "ON"
         lblSwitchStatus.BackColor = Color.Green
         SwitchLog.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                             DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "ON", "Overide ON", "", "", "", "")
      Else
         switch.TurnSwitchON()
         lblSwitchStatus.Text = "ON"
         lblSwitchStatus.BackColor = Color.Green
         SwitchLog.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                             DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "OFF", "Overide ON", "", "", "", "")
      End If
   End Sub

   Private Sub btnOverrideOff_Click(sender As Object, e As EventArgs) Handles btnOverrideOff.Click
      stopCLICK = True
      If switch.isOn Then
         switch.TurnSwitchOFF()
         lblSwitchStatus.Text = "OFF"
         lblSwitchStatus.BackColor = Color.Red
         SwitchLog.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                             DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "ON", "Overide OFF", "", "", "", "")
      Else
         switch.TurnSwitchOFF()
         switch.VerifySwitchOff()
         lblSwitchStatus.Text = "OFF"
         lblSwitchStatus.BackColor = Color.Red
         SwitchLog.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                             DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "OFF", "Overide OFF", "", "", "", "")
      End If

   End Sub

   Private Sub btnJerome_Click(sender As Object, e As EventArgs) Handles btnJerome.Click
      Dim PullStatus As String = ""
      Dim optURL As String = My.Settings.StationJerome1
      Dim lclStationID As String = Mid(optURL, optURL.Length - 9, 9)

      urlInfo.PullData(jsonCurOBS, curRESP, curOBS, curFORECAST, curASTRONOMY, curHISTORY, curPWS, urlInfo, obs, PullStatus, optURL)
      obs.WriteDailyOBSLog(curHISTORY, lclStationID)
   End Sub
End Class
