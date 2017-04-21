Public Class baseURL
   Private _URLMain, _StationIDMain, _URL1, _StationID1 As String


   Property URLMain As String
      Get
         Return _URLMain
      End Get
      Set(value As String)
         _URLMain = value
      End Set
   End Property
   Property StationIDMain As String
      Get
         Return _StationIDMain
      End Get
      Set(value As String)
         _StationIDMain = value
      End Set
   End Property
   Property URL1 As String
      Get
         Return _URL1
      End Get
      Set(value As String)
         _URL1 = value
      End Set
   End Property
   Property StationID1 As String
      Get
         Return _StationID1
      End Get
      Set(value As String)
         _StationID1 = value
      End Set
   End Property

End Class
