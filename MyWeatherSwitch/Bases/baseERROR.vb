Public Class baseERROR
   Private _StackTrace, _Message, _VBFileName, _ClassName, _DataString As String
   Private _Exception As Exception

   Property StackTrace As String
      Get
         Return _StackTrace
      End Get
      Set(value As String)
         _StackTrace = value
      End Set
   End Property
   Property ErrorMessage As String
      Get
         Return _Message
      End Get
      Set(value As String)
         _Message = value
      End Set
   End Property
   Property MyException As Exception
      Get
         Return _Exception
      End Get
      Set(value As Exception)
         _Exception = value
      End Set
   End Property
   Property VBFileName As String
      Get
         Return _VBFileName
      End Get
      Set(value As String)
         _VBFileName = value
      End Set
   End Property
   Property ClassName As String
      Get
         Return _ClassName
      End Get
      Set(value As String)
         _ClassName = value
      End Set
   End Property
   Property DataString As String
      Get
         Return _DataString
      End Get
      Set(value As String)
         _DataString = value
      End Set
   End Property
End Class
