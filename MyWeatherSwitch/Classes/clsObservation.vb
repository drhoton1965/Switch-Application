Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Configuration

Public Class clsObservation
   Inherits baseObservation

   Public err As clsERROR

   Sub New(errHandle As clsERROR)
      err = errHandle

   End Sub

   Public Function buildRESPClass(jsonOBSstring As String) As MyWeatherSwitch.Response
      buildRESPClass = New MyWeatherSwitch.Response

      Dim jobj As New JObject
      Dim sJSON_OBS As String = ""
      Dim jsonOBS As JToken

      Try
         jobj = JObject.Parse(jsonOBSstring)
         jsonOBS = jobj("radarCamVars")("pws_bootstrap")("response")
         sJSON_OBS = jsonOBS.ToString

         JsonConvert.PopulateObject(sJSON_OBS, buildRESPClass)
      Catch ex As Exception
         err.MyException = ex
         err.ErrorMessage = ex.Message
         err.StackTrace = ex.StackTrace
         err.DataString = sJSON_OBS
         err.ClassName = "buildRESPClass"
         err.VBFileName = "clsObservation.vb"
         err.WriteFile()
      End Try
   End Function

   Public Function buildFORECASTClass(jsonOBSstring As String) As MyWeatherSwitch.Forecast
      buildFORECASTClass = New MyWeatherSwitch.Forecast
      Dim clsDAY As MyWeatherSwitch.Day
      Dim clsSUMMARY As MyWeatherSwitch.Summary


      Dim jobj As New JObject
      Dim sJSON_OBS As String = ""
      Dim jsonOBS As JToken
      Dim intForeCastDays As Integer
      Try
         intForeCastDays = Integer.Parse(ConfigurationManager.AppSettings("Forecast Days").ToString())

         jobj = JObject.Parse(jsonOBSstring)
         ReDim buildFORECASTClass.days(intForeCastDays)


         For x = 0 To intForeCastDays
            clsSUMMARY = New MyWeatherSwitch.Summary
            clsDAY = New MyWeatherSwitch.Day

            'Build Summary portion
            clsSUMMARY.condition = jobj("radarCamVars")("pws_bootstrap")("forecast")("days")(x)("summary")("condition").ToString
            clsSUMMARY.high = jobj("radarCamVars")("pws_bootstrap")("forecast")("days")(x)("summary")("high").ToString

            'Build Day Portion
            clsDAY.condition = ""
            clsDAY.icon = jobj("radarCamVars")("pws_bootstrap")("forecast")("days")(x)("summary")("icon").ToString
            clsDAY.precip_type = jobj("radarCamVars")("pws_bootstrap")("forecast")("days")(x)("summary")("precip_type").ToString()
            clsDAY.liquid_precip = jobj("radarCamVars")("pws_bootstrap")("forecast")("days")(x)("summary")("liquid_precip").ToString()



            buildFORECASTClass.days(x) = clsDAY

         Next
         jsonOBS = jobj("radarCamVars")("pws_bootstrap")("forecast")
         sJSON_OBS = jsonOBS.ToString

         JsonConvert.PopulateObject(sJSON_OBS, buildFORECASTClass)
      Catch ex As Exception
         err.MyException = ex
         err.ErrorMessage = ex.Message
         err.StackTrace = ex.StackTrace
         err.DataString = sJSON_OBS
         err.ClassName = "buildFORECASTClass"
         err.VBFileName = "clsObservation.vb"
         err.WriteFile()
      End Try
   End Function

   Public Function buildASTRONOMYClass(jsonOBSstring As String) As MyWeatherSwitch.Astronomy
      buildASTRONOMYClass = New MyWeatherSwitch.Astronomy

      Dim jobj As New JObject
      Dim sJSON_OBS As String = ""
      Dim jsonOBS As JToken

      Try
         jobj = JObject.Parse(jsonOBSstring)
         jsonOBS = jobj("radarCamVars")("pws_bootstrap")("astronomy")
         sJSON_OBS = jsonOBS.ToString

         JsonConvert.PopulateObject(sJSON_OBS, buildASTRONOMYClass)
      Catch ex As Exception
         err.MyException = ex
         err.ErrorMessage = ex.Message
         err.StackTrace = ex.StackTrace
         err.DataString = sJSON_OBS
         err.ClassName = "buildASTRONOMYClass"
         err.VBFileName = "clsObservation.vb"
         err.WriteFile()
      End Try
   End Function

   Public Function buildHISTORYClass(jsonOBSstring As String) As MyWeatherSwitch.History
      buildHISTORYClass = New MyWeatherSwitch.History
      buildHISTORYClass.start_date = New MyWeatherSwitch.StartDate
      buildHISTORYClass.end_date = New MyWeatherSwitch.EndDate

      Dim jobj As New JObject
      Dim jsonOBS As JToken

      Try
         jobj = JObject.Parse(jsonOBSstring)
         jsonOBS = jobj("radarCamVars")("pws_bootstrap")("history")

         'Start_Date
         buildHISTORYClass.start_date.epoch = jsonOBS("start_date")("epoch").ToString
         buildHISTORYClass.start_date.pretty = jsonOBS("start_date")("pretty").ToString
         buildHISTORYClass.start_date.rfc822 = jsonOBS("start_date")("rfc822").ToString
         buildHISTORYClass.start_date.iso8601 = jsonOBS("start_date")("iso8601").ToString
         buildHISTORYClass.start_date.year = jsonOBS("start_date")("year").ToString
         buildHISTORYClass.start_date.month = jsonOBS("start_date")("month").ToString
         buildHISTORYClass.start_date.day = jsonOBS("start_date")("day").ToString
         buildHISTORYClass.start_date.yday = jsonOBS("start_date")("yday").ToString
         buildHISTORYClass.start_date.hour = jsonOBS("start_date")("hour").ToString
         buildHISTORYClass.start_date.min = jsonOBS("start_date")("min").ToString
         buildHISTORYClass.start_date.sec = jsonOBS("start_date")("sec").ToString
         buildHISTORYClass.start_date.monthname = jsonOBS("start_date")("monthname").ToString
         buildHISTORYClass.start_date.monthname_short = jsonOBS("start_date")("monthname_short").ToString
         buildHISTORYClass.start_date.weekday = jsonOBS("start_date")("weekday").ToString
         buildHISTORYClass.start_date.weekday_short = jsonOBS("start_date")("weekday_short").ToString
         buildHISTORYClass.start_date.ampm = jsonOBS("start_date")("ampm").ToString
         buildHISTORYClass.start_date.tz_short = jsonOBS("start_date")("tz_short").ToString
         buildHISTORYClass.start_date.tz_long = jsonOBS("start_date")("tz_long").ToString
         buildHISTORYClass.start_date.tz_offset_text = jsonOBS("start_date")("tz_offset_text").ToString
         buildHISTORYClass.start_date.tz_offset_hours = jsonOBS("start_date")("tz_offset_hours").ToString

         'End_Date
         buildHISTORYClass.end_date.epoch = jsonOBS("end_date")("epoch").ToString
         buildHISTORYClass.end_date.pretty = jsonOBS("end_date")("pretty").ToString
         buildHISTORYClass.end_date.rfc822 = jsonOBS("end_date")("rfc822").ToString
         buildHISTORYClass.end_date.iso8601 = jsonOBS("end_date")("iso8601").ToString
         buildHISTORYClass.end_date.year = jsonOBS("end_date")("year").ToString
         buildHISTORYClass.end_date.month = jsonOBS("end_date")("month").ToString
         buildHISTORYClass.end_date.day = jsonOBS("end_date")("day").ToString
         buildHISTORYClass.end_date.yday = jsonOBS("end_date")("yday").ToString
         buildHISTORYClass.end_date.hour = jsonOBS("end_date")("hour").ToString
         buildHISTORYClass.end_date.min = jsonOBS("end_date")("min").ToString
         buildHISTORYClass.end_date.sec = jsonOBS("end_date")("sec").ToString
         buildHISTORYClass.end_date.monthname = jsonOBS("end_date")("monthname").ToString
         buildHISTORYClass.end_date.monthname_short = jsonOBS("end_date")("monthname_short").ToString
         buildHISTORYClass.end_date.weekday = jsonOBS("end_date")("weekday").ToString
         buildHISTORYClass.end_date.weekday_short = jsonOBS("end_date")("weekday_short").ToString
         buildHISTORYClass.end_date.ampm = jsonOBS("end_date")("ampm").ToString
         buildHISTORYClass.end_date.tz_short = jsonOBS("end_date")("tz_short").ToString
         buildHISTORYClass.end_date.tz_long = jsonOBS("end_date")("tz_long").ToString
         buildHISTORYClass.end_date.tz_offset_text = jsonOBS("end_date")("tz_offset_text").ToString
         buildHISTORYClass.end_date.tz_offset_hours = jsonOBS("end_date")("tz_offset_hours").ToString

         'Summary
         Dim tknDAY As JToken = jsonOBS("days")
         buildHISTORYClass.days = New MyWeatherSwitch.HistoryDay
         buildHISTORYClass.days.summary = New MyWeatherSwitch.HistorySummary
         buildHISTORYClass.days.summary.date = New pwsDate

         buildHISTORYClass.days.summary.date.epoch = tknDAY(0)("summary")("date")("epoch")
         buildHISTORYClass.days.summary.date.pretty = tknDAY(0)("summary")("date")("pretty")
         buildHISTORYClass.days.summary.date.rfc822 = tknDAY(0)("summary")("date")("rfc822")
         buildHISTORYClass.days.summary.date.iso8601 = tknDAY(0)("summary")("date")("iso8601")
         buildHISTORYClass.days.summary.date.year = tknDAY(0)("summary")("date")("year")
         buildHISTORYClass.days.summary.date.month = tknDAY(0)("summary")("date")("month")
         buildHISTORYClass.days.summary.date.day = tknDAY(0)("summary")("date")("day")
         buildHISTORYClass.days.summary.date.yday = tknDAY(0)("summary")("date")("yday")
         buildHISTORYClass.days.summary.date.hour = tknDAY(0)("summary")("date")("hour")
         buildHISTORYClass.days.summary.date.min = tknDAY(0)("summary")("date")("min")
         buildHISTORYClass.days.summary.date.sec = tknDAY(0)("summary")("date")("sec")
         buildHISTORYClass.days.summary.date.monthname = tknDAY(0)("summary")("date")("monthname")
         buildHISTORYClass.days.summary.date.monthname_short = tknDAY(0)("summary")("date")("monthname_short")
         buildHISTORYClass.days.summary.date.weekday = tknDAY(0)("summary")("date")("weekday")
         buildHISTORYClass.days.summary.date.weekday_short = tknDAY(0)("summary")("date")("weekday_short")
         buildHISTORYClass.days.summary.date.ampm = tknDAY(0)("summary")("date")("ampm")
         buildHISTORYClass.days.summary.date.tz_short = tknDAY(0)("summary")("date")("tz_short")
         buildHISTORYClass.days.summary.date.tz_long = tknDAY(0)("summary")("date")("tz_long")
         buildHISTORYClass.days.summary.date.tz_offset_text = tknDAY(0)("summary")("date")("tz_offset_text")
         buildHISTORYClass.days.summary.date.tz_offset_hours = tknDAY(0)("summary")("date")("tz_offset_hours")

         buildHISTORYClass.days.summary.max_temperature = tknDAY(0)("summary")("max_temperature")
         buildHISTORYClass.days.summary.min_temperature = tknDAY(0)("summary")("min_temperature")
         buildHISTORYClass.days.summary.temperature = tknDAY(0)("summary")("temperature")
         buildHISTORYClass.days.summary.max_dewpoint = tknDAY(0)("summary")("max_dewpoint")
         buildHISTORYClass.days.summary.min_dewpoint = tknDAY(0)("summary")("min_dewpoint")
         buildHISTORYClass.days.summary.dewpoint = tknDAY(0)("summary")("dewpoint")
         buildHISTORYClass.days.summary.max_humidity = tknDAY(0)("summary")("max_humidity")
         buildHISTORYClass.days.summary.min_humidity = tknDAY(0)("summary")("min_humidity")
         buildHISTORYClass.days.summary.humidity = tknDAY(0)("summary")("humidity")
         buildHISTORYClass.days.summary.precip_today = tknDAY(0)("summary")("precip_today")
         buildHISTORYClass.days.summary.wind_dir = tknDAY(0)("summary")("wind_dir")
         buildHISTORYClass.days.summary.wind_dir_degrees = tknDAY(0)("summary")("wind_dir_degrees")
         buildHISTORYClass.days.summary.max_wind_dir = tknDAY(0)("summary")("max_wind_dir")
         buildHISTORYClass.days.summary.max_wind_dir_degrees = tknDAY(0)("summary")("max_wind_dir_degrees")
         buildHISTORYClass.days.summary.max_wind_speed = tknDAY(0)("summary")("max_wind_speed")
         buildHISTORYClass.days.summary.wind_speed = tknDAY(0)("summary")("wind_speed")
         buildHISTORYClass.days.summary.max_gust_dir = tknDAY(0)("summary")("max_gust_dir")
         buildHISTORYClass.days.summary.max_gust_dir_degrees = tknDAY(0)("summary")("max_gust_dir_degrees")
         buildHISTORYClass.days.summary.max_wind_gust_speed = tknDAY(0)("summary")("max_wind_gust_speed")
         buildHISTORYClass.days.summary.wind_gust_speed = tknDAY(0)("summary")("wind_gust_speed")
         buildHISTORYClass.days.summary.max_pressure = tknDAY(0)("summary")("max_pressure")
         buildHISTORYClass.days.summary.min_pressure = tknDAY(0)("summary")("min_pressure")
         buildHISTORYClass.days.summary.pressure = tknDAY(0)("summary")("pressure")



         'Dim jsnDAY As MyWeatherSwitch.HistoryDay

         Dim sumCNT As Integer = 0
         Dim sumOBS As Integer = 0
         Dim obsCNT As Integer = tknDAY(0)("observations").Count
         Dim jsnObservations(obsCNT) As MyWeatherSwitch.HistoryObservation

         For Each tknHistOBS As JToken In tknDAY(0)("observations")
            If UBound(jsnObservations) < sumOBS Then

               ReDim Preserve jsnObservations(sumOBS)
            End If
            jsnObservations(sumOBS) = New MyWeatherSwitch.HistoryObservation
            jsnObservations(sumOBS).date = New MyWeatherSwitch.pwsDate

            jsnObservations(sumOBS).date.epoch = tknHistOBS("date")("epoch")
            jsnObservations(sumOBS).date.iso8601 = tknHistOBS("date")("iso8601")
            jsnObservations(sumOBS).date.tz_offset_hours = tknHistOBS("date")("tz_offset_hours")
            jsnObservations(sumOBS).temperature = tknHistOBS("temperature")
            jsnObservations(sumOBS).dewpoint = tknHistOBS("dewpoint")
            jsnObservations(sumOBS).humidity = tknHistOBS("humidity")

            jsnObservations(sumOBS).wind_speed = tknHistOBS("wind_speed").ToString
            If tknHistOBS("wind_gust_speed").ToString.Length > 0 Then
               jsnObservations(sumOBS).wind_gust_speed = tknHistOBS("wind_gust_speed").ToString
            Else
               jsnObservations(sumOBS).wind_gust_speed = 0
            End If

            jsnObservations(sumOBS).wind_dir_degrees = tknHistOBS("wind_dir_degrees")
            jsnObservations(sumOBS).wind_dir = tknHistOBS("wind_dir")
            If tknHistOBS("pressure") Then
               jsnObservations(sumOBS).pressure = tknHistOBS("pressure")
            Else
               jsnObservations(sumOBS).pressure = 0
            End If

            If tknHistOBS("windchill").ToString.Length > 0 Then
               jsnObservations(sumOBS).windchill = tknHistOBS("windchill").ToString()
            Else
               jsnObservations(sumOBS).windchill = 0
            End If

            If tknHistOBS("heatindex").ToString.Length > 0 Then
               jsnObservations(sumOBS).heatindex = tknHistOBS("heatindex")
            Else
               jsnObservations(sumOBS).heatindex = 0
            End If

            If tknHistOBS("precip").ToString.Length > 0 Then
               jsnObservations(sumOBS).precip = tknHistOBS("precip")
            Else
               jsnObservations(sumOBS).precip = 0
            End If

            If tknHistOBS("precip_rate").ToString.Length > 0 Then
               jsnObservations(sumOBS).precip_rate = tknHistOBS("precip_rate")
            Else
               jsnObservations(sumOBS).precip_rate = 0
            End If


            jsnObservations(sumOBS).precip_1hr = tknHistOBS("precip_1hr")
            jsnObservations(sumOBS).precip_today = tknHistOBS("precip_today")

            If tknHistOBS("solarradiation").ToString.Length > 0 Then
               jsnObservations(sumOBS).solarradiation = tknHistOBS("solarradiation")
            Else
               jsnObservations(sumOBS).solarradiation = 0
            End If

            If tknHistOBS("uv_index").ToString.Length > 0 Then
               jsnObservations(sumOBS).uv_index = tknHistOBS("uv_index")
            Else
               jsnObservations(sumOBS).uv_index = 0
            End If

            If tknHistOBS("temperature_indoor").ToString.Length > 0 Then
               jsnObservations(sumOBS).temperature_indoor = tknHistOBS("temperature_indoor")
            Else
               jsnObservations(sumOBS).temperature_indoor = 0
            End If

            If tknHistOBS("humidity_indoor").ToString.Length > 0 Then
               jsnObservations(sumOBS).humidity_indoor = tknHistOBS("humidity_indoor")
            Else
               jsnObservations(sumOBS).humidity_indoor = 0
            End If

            jsnObservations(sumOBS).software_type = tknHistOBS("software_type")
            sumOBS += 1
         Next

         buildHISTORYClass.days.observations = jsnObservations

      Catch ex As Exception
         err.MyException = ex
         err.ErrorMessage = ex.Message
         err.StackTrace = ex.StackTrace
         err.DataString = jsonOBSstring
         err.ClassName = "buildHISTORYClass"
         err.VBFileName = "clsObservation.vb"
         err.WriteFile()

      End Try
   End Function

   Public Function buildEND_DATEClass(jsonOBSstring As String) As MyWeatherSwitch.EndDate
      buildEND_DATEClass = New MyWeatherSwitch.EndDate

      Dim jobj As New JObject
      Dim sJSON_OBS As String = ""
      Dim jsonOBS As JToken

      Try
         jobj = JObject.Parse(jsonOBSstring)
         jsonOBS = jobj("radarCamVars")("pws_bootstrap")("end_date")
         sJSON_OBS = jsonOBS.ToString

         JsonConvert.PopulateObject(sJSON_OBS, buildEND_DATEClass)
      Catch ex As Exception
         err.MyException = ex
         err.ErrorMessage = ex.Message
         err.StackTrace = ex.StackTrace
         err.DataString = sJSON_OBS
         err.ClassName = "buildEnd_DateClass"
         err.VBFileName = "clsObservation.vb"
         err.WriteFile()
      End Try
   End Function

   Public Function buildPWSBOOTSTRAPClass(jsonOBSstring As String) As MyWeatherSwitch.PwsBootstrap
      buildPWSBOOTSTRAPClass = New MyWeatherSwitch.PwsBootstrap

      Dim jobj As New JObject
      Dim sJSON_OBS As String = ""
      Dim jsonOBS As JToken

      Try
         jobj = JObject.Parse(jsonOBSstring)
         jsonOBS = jobj("radarCamVars")("pws_bootstrap")
         sJSON_OBS = jsonOBS.ToString

         JsonConvert.PopulateObject(sJSON_OBS, buildPWSBOOTSTRAPClass)
      Catch ex As Exception
         err.MyException = ex
         err.ErrorMessage = ex.Message
         err.StackTrace = ex.StackTrace
         err.DataString = sJSON_OBS
         err.ClassName = "buildPWSBOOTSTRAPClass"
         err.VBFileName = "clsObservation.vb"
         err.WriteFile()
      End Try
   End Function

   Public Function buildOBSClass(jsonOBSstring As String) As MyWeatherSwitch.CurrentObservation
      buildOBSClass = New MyWeatherSwitch.CurrentObservation

      Dim jobj As New JObject
      Dim sJSON_OBS As String = ""
      Dim jsonOBS As JToken

      Try
         jobj = JObject.Parse(jsonOBSstring)
         jsonOBS = jobj("radarCamVars")("pws_bootstrap")("current_observation")
         sJSON_OBS = jsonOBS.ToString

         JsonConvert.PopulateObject(sJSON_OBS, buildOBSClass)
      Catch ex As Exception
         err.MyException = ex
         err.ErrorMessage = ex.Message
         err.StackTrace = ex.StackTrace
         err.DataString = sJSON_OBS
         err.ClassName = "buildOBSClass"
         err.VBFileName = "clsObservation.vb"
         err.WriteFile()
      End Try
   End Function

   Public Sub WriteDailyOBSLog(obs As MyWeatherSwitch.History, Optional optStationID As String = "")
      Dim obsOUT As StreamWriter
      Try
         If optStationID.Trim.Length = 0 Then
            obsOUT = New StreamWriter("C:\DLRStuff\MySwitchData\MyWeatherSwitch_DailyObs_" & DateTime.Now.ToString("yyyy-MM-dd_hhmmss") & ".txt")
         Else
            obsOUT = New StreamWriter("C:\DLRStuff\MySwitchData\MyWeatherSwitch_DailyObs_" & optStationID & "_" & DateTime.Now.ToString("yyyy-MM-dd_hhmmss") & ".txt")
         End If
         obsOUT.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}", _
                          "date", _
                          "dewpoint", _
                           "heatindex", _
                           "humidity ", _
                           "precip", _
                           "precip_1hr", _
                           "precip_rate", _
                           "precip_today", _
                           "pressure", _
                           "solarradiation", _
                           "temperature", _
                           "temperature_indoor", _
                           "uv_index", _
                           "wind_dir", _
                           "wind_dir_degrees", _
                           "wind_gust_speed", _
                           "wind_speed", _
                           "windchill"
                          )
         For Each indvOBS As HistoryObservation In obs.days.observations
            If Not IsNothing(indvOBS) Then
               obsOUT.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}", _
                                indvOBS.date.iso8601.ToString("MM/dd/yyyy HH:mm:ss"), _
                                indvOBS.dewpoint, _
                                indvOBS.heatindex, _
                                indvOBS.humidity, _
                                indvOBS.precip, _
                                indvOBS.precip_1hr, _
                                indvOBS.precip_rate, _
                                indvOBS.precip_today, _
                                indvOBS.pressure, _
                                indvOBS.solarradiation, _
                                indvOBS.temperature, _
                                indvOBS.temperature_indoor, _
                                indvOBS.uv_index, _
                                indvOBS.wind_dir, _
                                indvOBS.wind_dir_degrees, _
                                indvOBS.wind_gust_speed, _
                                indvOBS.wind_speed, _
                                indvOBS.windchill
                                )
            End If
         Next
         obsOUT.Flush()
         obsOUT.Close()

      Catch ex As Exception
         err.MyException = ex
         err.ErrorMessage = ex.Message
         err.StackTrace = ex.StackTrace
         err.DataString = ""
         err.ClassName = "WriteDailyOBSLog"
         err.VBFileName = "clsObservation.vb"
         err.WriteFile()
      End Try
   End Sub
End Class

