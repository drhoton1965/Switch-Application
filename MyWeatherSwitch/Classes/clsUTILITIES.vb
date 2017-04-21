Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Configuration

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class clsUTILITIES
   Public Sub GoSleep(ByVal SleepTime As Integer, ByRef StopClick As Boolean)

      Dim actSLEEP As Integer = 500
      Dim lclTIMER As Integer = actSLEEP

      Try
         While lclTIMER <= SleepTime
            Thread.Sleep(actSLEEP)
            lclTIMER += actSLEEP
            Application.DoEvents()
            If StopClick Then
               Exit While
            End If
         End While
      Catch ex As Exception
         Console.WriteLine()
      End Try
   End Sub
End Class
