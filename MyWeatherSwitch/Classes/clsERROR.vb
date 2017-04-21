Imports System.IO

Public Class clsERROR
   Inherits baseERROR

   Public errFILE As StreamWriter

   Sub New(Optional EX As Exception = Nothing, Optional txtFILE As StreamWriter = Nothing)
      If Not IsNothing(EX) Then
         Me.ErrorMessage = EX.Message
         Me.StackTrace = EX.StackTrace
         Me.MyException = EX
      End If
      errFILE = txtFILE

   End Sub

   Public Sub ShowError(Optional ByVal SubRoutineName As String = "")
      Dim errormsg As String = _
         "Stack Trace: " & Me.StackTrace & vbCrLf & vbCrLf & _
         "Error Message: " & Me.ErrorMessage

      If SubRoutineName.Length > 0 Then
         errormsg = "Routine: " & SubRoutineName & vbCrLf & vbCrLf & errormsg
      End If
      If IsNothing(errFILE) Then
         MsgBox(errormsg, vbCritical)
      Else
      End If

   End Sub

   Public Sub WriteFile()
      Try
         Me.errFILE.WriteLine("{0}|{1]|{2}|{3}{|4}", _
                              Me.VBFileName, _
                              Me.ClassName, _
                              Me.MyException.StackTrace, _
                              Me.MyException.Message, _
                              Me.DataString
                              )
         Me.errFILE.Flush()

      Catch ex As Exception
         Console.WriteLine("error in error handling...")
      End Try
   End Sub
End Class
