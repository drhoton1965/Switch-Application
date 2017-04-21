Public Class frmSystemConfig

 
   Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
      If tbWindSpeed.Text.Trim.Length > 0 Then
         My.Settings.WindSpeedOffSwitch = tbWindSpeed.Text
      End If

      If tbTimeON.Text.Trim.Length > 0 Then
         My.Settings.TimerOnTime = tbTimeON.Text
      End If

      If tbTimeOFF.Text.Trim.Length > 0 Then
         My.Settings.TimerOffTime = tbTimeOFF.Text
      End If

      My.Settings.Save()
      Me.Close()

   End Sub

   Private Sub tblCancel_Click(sender As Object, e As EventArgs) Handles tblCancel.Click
      Me.Close()
   End Sub

   Private Sub frmSystemConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      tbWindSpeed.Text = My.Settings.WindSpeedOffSwitch
      tbTimeON.Text = My.Settings.TimerOnTime
      tbTimeOFF.Text = My.Settings.TimerOffTime

   End Sub

   Private Sub tbWindSpeed_TextChanged(sender As Object, e As EventArgs) Handles tbWindSpeed.TextChanged

   End Sub
End Class