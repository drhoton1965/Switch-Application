Public Class baseSwitch
   Private zzzIsOn As Boolean

   Property isOn As Boolean
      Get
         Return zzzIsOn
      End Get
      Set(value As Boolean)
         zzzIsOn = value
      End Set
   End Property
End Class
