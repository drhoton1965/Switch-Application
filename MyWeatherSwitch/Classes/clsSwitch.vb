Public Class clsSwitch
   Inherits baseSwitch
   Public err As clsERROR

   Sub New(errHandle As clsERROR)
      err = errHandle

      Me.isOn = False

   End Sub

   Public Function isWindSpeedOK(cOBS As CurrentObservation) As Boolean
      Dim lclWindSpeed As Double
      Dim lclWindGust As Double

      isWindSpeedOK = True
      Try
         lclWindSpeed = cOBS.wind_speed
         lclWindGust = cOBS.wind_gust_speed

         If lclWindSpeed >= My.Settings.WindSpeedOffSwitch Then
            isWindSpeedOK = False
         Else
            If lclWindGust >= My.Settings.WindSpeedOffSwitch Then
               isWindSpeedOK = False
            Else
               isWindSpeedOK = True
            End If
         End If
      Catch ex As Exception
         Dim err As New clsERROR(ex)
         err.ShowError("clsSwitch.isWindSpeedOk")
      End Try
      Return isWindSpeedOK

   End Function

   Public Sub TurnSwitchON()
      Me.isOn = True
   End Sub

   Public Sub TurnSwitchOFF()
      Me.isOn = False
   End Sub

   Public Sub VerifySwitchOn()
      Me.isOn = True
   End Sub

   Public Sub VerifySwitchOff()
      Me.isOn = False
   End Sub

   Public Function isWithinTimers(ByRef x As MyWeatherSwitch.frmMain) As Boolean
      Dim TimeOnOff(4, 1) As DateTime
      Dim dtpName As String
      Dim DailyTimerNumber As Integer
      Dim allDTP As List(Of Control)

      isWithinTimers = False
      Try
         allDTP = New List(Of Control)
         FindDaysTimerControls(allDTP, x, GetType(DateTimePicker))
         For Each dtp As DateTimePicker In allDTP
            dtpName = dtp.Name.ToString
            DailyTimerNumber = Integer.Parse(dtpName.Substring(dtpName.Length - 1), 1) - 1

            If dtp.Value <> #12:00:00 AM# Then
               If InStr(dtpName.ToUpper, "ON") Then
                  TimeOnOff(DailyTimerNumber, 0) = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyy") & " " & dtp.Value.ToString("HH:mm"))
               Else
                  TimeOnOff(DailyTimerNumber, 1) = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyy") & " " & dtp.Value.ToString("HH:mm"))
               End If
            Else
               TimeOnOff(DailyTimerNumber, 0) = Nothing
               TimeOnOff(DailyTimerNumber, 1) = Nothing
            End If
         Next

         If DateTime.Now >= TimeOnOff(0, 0) And DateTime.Now <= TimeOnOff(0, 1) Then
            isWithinTimers = True
         ElseIf DateTime.Now >= TimeOnOff(1, 0) And DateTime.Now <= TimeOnOff(1, 1) Then
            isWithinTimers = True
         ElseIf DateTime.Now >= TimeOnOff(2, 0) And DateTime.Now <= TimeOnOff(2, 1) Then
            isWithinTimers = True
         ElseIf DateTime.Now >= TimeOnOff(3, 0) And DateTime.Now <= TimeOnOff(3, 1) Then
            isWithinTimers = True
         ElseIf DateTime.Now >= TimeOnOff(4, 0) And DateTime.Now <= TimeOnOff(4, 1) Then
            isWithinTimers = True
         Else
            isWithinTimers = False
         End If

      Catch ex As Exception
         Dim err As New clsERROR(ex)
         err.ShowError("clsSwitch.isWithinTimers")
      End Try
      Return isWithinTimers
   End Function

   Public Shared Function FindDaysTimerControls(ByVal list As List(Of Control), ByVal parent As Control, ByVal ctrlType As System.Type) As List(Of Control)

      Dim dow As String = DateTime.Now.DayOfWeek.ToString.ToUpper


      If parent Is Nothing Then Return list
      If parent.GetType Is ctrlType Then
         If InStr(parent.Name.ToString.ToUpper, dow) Then
            list.Add(parent)
         End If
      End If
      For Each child As Control In parent.Controls
         FindDaysTimerControls(list, child, ctrlType)
      Next
      Return list
   End Function

End Class
