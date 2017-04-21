Public Class baseObservation
   Private zzzSource, zzzMetar, zzzCondition, zzzWindDir, zzzPressureTrend, zzzPressureTendString As String
   Private zzzTemp, zzzWindSpeed, zzzGustSpeed, zzzPressure, zzzPressureTendency As Double
   Private zzzHumidity, zzzWindDirDeg, zzzWindDirvAR As Integer

   Private zzzEstimate

   Property source As String
      Get
         Return zzzSource
      End Get
      Set(value As String)
         zzzSource = value
      End Set
   End Property
   'Public Property station As Station
   '   Get

   '   End Get
   '   Set(value As Station)

   '   End Set
   'End Property
   Public Property estimated As Object
      Get
         Return zzzEstimate
      End Get
      Set(value As Object)
         zzzEstimate = value
      End Set
   End Property
   'Public Property [date] As pwsDate
   '   Get

   '   End Get
   '   Set(value As pwsDate)

   '   End Set
   'End Property
   Public Property metar As String
      Get
         Return zzzMetar
      End Get
      Set(value As String)
         zzzMetar = value
      End Set
   End Property
   Public Property condition As String
      Get
         Return zzzCondition
      End Get
      Set(value As String)
         zzzCondition = value
      End Set
   End Property
   Public Property temperature As Double
      Get
         Return zzzTemp
      End Get
      Set(value As Double)
         zzzTemp = value
      End Set
   End Property
   Public Property humidity As Integer
      Get
         Return zzzHumidity
      End Get
      Set(value As Integer)
         zzzHumidity = value
      End Set
   End Property
   Public Property wind_speed As Double
      Get
         Return zzzWindSpeed
      End Get
      Set(value As Double)
         zzzWindSpeed = value
      End Set
   End Property
   Public Property wind_gust_speed As Double
      Get
         Return zzzGustSpeed
      End Get
      Set(value As Double)
         zzzGustSpeed = value
      End Set
   End Property
   Public Property wind_dir As String
      Get
         Return zzzWindDir
      End Get
      Set(value As String)
         zzzWindDir = value
      End Set
   End Property
   Public Property wind_dir_degrees As Integer
      Get
         Return zzzWindDirDeg
      End Get
      Set(value As Integer)
         zzzWindDirDeg = value
      End Set
   End Property
   Public Property wind_dir_variable As Integer
      Get
         Return zzzWindDirvAR
      End Get
      Set(value As Integer)
         zzzWindDirVar = value
      End Set
   End Property
   Public Property pressure As Double
      Get
         Return zzzPressure
      End Get
      Set(value As Double)
         zzzPressure = value
      End Set
   End Property
   Public Property pressure_trend As String
      Get
         Return zzzPressureTrend
      End Get
      Set(value As String)
         zzzPressureTrend = value
      End Set
   End Property
   Public Property pressure_tendency As Double
      Get
         Return zzzPressureTendency
      End Get
      Set(value As Double)
         zzzPressureTendency = value
      End Set
   End Property
   Public Property pressure_tendency_string As String
      Get
         Return zzzPressureTendString
      End Get
      Set(value As String)
         zzzPressureTendString = value
      End Set
   End Property
   'Public Property dewpoint As Integer
   '   Get

   '   End Get
   '   Set(value As Integer)

   '   End Set
   'End Property
   'Public Property heatindex As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property windchill As Integer
   '   Get

   '   End Get
   '   Set(value As Integer)

   '   End Set
   'End Property
   'Public Property feelslike As Integer
   '   Get

   '   End Get
   '   Set(value As Integer)

   '   End Set
   'End Property
   'Public Property visibility As Double
   '   Get

   '   End Get
   '   Set(value As Double)

   '   End Set
   'End Property
   'Public Property cloud_description As CloudDescription
   '   Get

   '   End Get
   '   Set(value As CloudDescription)

   '   End Set
   'End Property
   'Public Property solarradiation As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property uv_index As Integer
   '   Get

   '   End Get
   '   Set(value As Integer)

   '   End Set
   'End Property
   'Public Property temperature_indoor As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property humidity_indoor As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property t1f As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property t2f As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property precip_1hr As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property precip_today As Double
   '   Get

   '   End Get
   '   Set(value As Double)

   '   End Set
   'End Property
   'Public Property soil_temp As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property soil_moisture As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property leaf_wetness As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property icon As String
   '   Get

   '   End Get
   '   Set(value As String)

   '   End Set
   'End Property
   'Public Property icon_url As String
   '   Get

   '   End Get
   '   Set(value As String)

   '   End Set
   'End Property
   'Public Property forecast_url As String
   '   Get

   '   End Get
   '   Set(value As String)

   '   End Set
   'End Property
   'Public Property history_url As String
   '   Get

   '   End Get
   '   Set(value As String)

   '   End Set
   'End Property
   'Public Property ob_url As String
   '   Get

   '   End Get
   '   Set(value As String)

   '   End Set
   'End Property
   'Public Property nowcast As String
   '   Get

   '   End Get
   '   Set(value As String)

   '   End Set
   'End Property
   'Public Property pollen As Double
   '   Get

   '   End Get
   '   Set(value As Double)

   '   End Set
   'End Property
   'Public Property flu As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property ozone_index As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property ozone_text As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property pm_index As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property pm_text As Object
   '   Get

   '   End Get
   '   Set(value As Object)

   '   End Set
   'End Property
   'Public Property yesterday_max_temperature As Double
   '   Get

   '   End Get
   '   Set(value As Double)

   '   End Set
   'End Property
   'Public Property yesterday_min_temperature As Double
   '   Get

   '   End Get
   '   Set(value As Double)

   '   End Set
   'End Property
   'Public Property yesterday_precip_total As Double
   '   Get

   '   End Get
   '   Set(value As Double)

   '   End Set
   'End Property

End Class
