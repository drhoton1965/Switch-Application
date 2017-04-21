Public Class clsPWS

End Class
Public Class CrossLinkingVars
   Public Property histType As Object
   Public Property locid As Object
End Class

Public Class Attribution
   Public Property image As String
   Public Property title As String
   Public Property link As String
End Class

Public Class Features
   Public Property labels As Integer
   Public Property astronomy10day As Integer
   Public Property conditions As Integer
   Public Property forecast10day As Integer
   Public Property history As Integer
   Public Property pwsidentity As Integer
End Class

Public Class Location
   Public Property name As String
   Public Property neighborhood As Object
   Public Property city As String
   Public Property state As String
   Public Property state_name As String
   Public Property country As String
   Public Property country_iso3166 As Object
   Public Property country_name As String
   Public Property zip As String
   Public Property magic As String
   Public Property wmo As String
   Public Property radarcode As String
   Public Property latitude As Double
   Public Property longitude As Double
   Public Property elevation As Integer
   Public Property l As String
End Class

Public Class pwsDate
   Public Property epoch As Integer
   Public Property pretty As String
   Public Property rfc822 As String
   Public Property iso8601 As DateTime
   Public Property year As Integer
   Public Property month As Integer
   Public Property day As Integer
   Public Property yday As Integer
   Public Property hour As Integer
   Public Property min As String
   Public Property sec As Integer
   Public Property monthname As String
   Public Property monthname_short As String
   Public Property weekday As String
   Public Property weekday_short As String
   Public Property ampm As String
   Public Property tz_short As String
   Public Property tz_long As String
   Public Property tz_offset_text As String
   Public Property tz_offset_hours As Double
End Class

Public Class Response
   Public Property version As String
   Public Property units As String
   Public Property termsofService As String
   Public Property attribution As Attribution
   Public Property features As Features
   Public Property location As Location
   Public Property [date] As pwsDate
End Class

Public Class Station
   Public Property id As String
   Public Property name As String
   Public Property city As String
   Public Property state As String
   Public Property state_name As String
   Public Property country As String
   Public Property country_name As String
   Public Property country_iso3166 As String
   Public Property latitude As Double
   Public Property longitude As Double
   Public Property elevation As Integer
End Class

Public Class Layer
   Public Property height As Object
   Public Property height_char As Object
   Public Property cover As Object
   Public Property cover_text As Object
   Public Property oktas As Object
   Public Property other As Object
End Class

Public Class CloudDescription
   Public Property highest_layer As String
   Public Property oktas As Integer
   Public Property layers As Layer()
End Class

Public Class CurrentObservation
   Public Property source As String
   Public Property station As Station
   Public Property estimated As Object
   Public Property [date] As pwsDate
   Public Property metar As String
   Public Property condition As String
   Public Property temperature As Double
   Public Property humidity As Integer
   Public Property wind_speed As Double
   Public Property wind_gust_speed As Object
   Public Property wind_dir As String
   Public Property wind_dir_degrees As Integer
   Public Property wind_dir_variable As Integer
   Public Property pressure As Double
   Public Property pressure_trend As String
   Public Property pressure_tendency As Double
   Public Property pressure_tendency_string As String
   Public Property dewpoint As Double
   Public Property heatindex As Object
   Public Property windchill As Object
   Public Property feelslike As Double
   Public Property visibility As Double
   Public Property cloud_description As CloudDescription
   Public Property solarradiation As Object
   Public Property uv_index As Double
   Public Property temperature_indoor As Object
   Public Property humidity_indoor As Object
   Public Property t1f As Object
   Public Property t2f As Object
   Public Property precip_1hr As Object
   Public Property precip_today As Double
   Public Property soil_temp As Object
   Public Property soil_moisture As Object
   Public Property leaf_wetness As Object
   Public Property icon As String
   Public Property icon_url As String
   Public Property forecast_url As String
   Public Property history_url As String
   Public Property ob_url As String
   Public Property nowcast As String
   Public Property pollen As Double
   Public Property flu As Object
   Public Property ozone_index As Object
   Public Property ozone_text As Object
   Public Property pm_index As Object
   Public Property pm_text As Object
   Public Property yesterday_max_temperature As Double
   Public Property yesterday_min_temperature As Double
   Public Property yesterday_precip_total As Double
End Class

Public Class [Day]
   Public Property condition As String
   Public Property icon As String
   Public Property icon_url As String
   Public Property precip_type As String
   Public Property liquid_precip As Double
   Public Property snow As Double
   Public Property snow_range As Object
   Public Property pop As Integer
   Public Property title As String
   Public Property text As String
   Public Property text_metric As String
End Class


Public Class HistoryDay
   Public Property summary As HistorySummary
   Public Property observations As HistoryObservation()

End Class

Public Class HistoryObservation
   Public Property [date] As pwsDate
   Public Property temperature As Double
   Public Property dewpoint As Double
   Public Property humidity As Double
   Public Property wind_speed As Double
   Public Property wind_gust_speed As Double
   Public Property wind_dir_degrees As Integer
   Public Property wind_dir As String
   Public Property pressure As Double
   Public Property windchill As Double
   Public Property heatindex As Double
   Public Property precip As Double
   Public Property precip_rate As Double
   Public Property precip_1hr As Double
   Public Property precip_today As Double
   Public Property solarradiation As String
   Public Property uv_index As Double
   Public Property temperature_indoor As Double
   Public Property humidity_indoor As Double
   Public Property software_type As String
End Class
Public Class Night
   Public Property condition As String
   Public Property icon As String
   Public Property icon_url As String
   Public Property precip_type As String
   Public Property liquid_precip As Double
   Public Property snow As Double
   Public Property snow_range As Object
   Public Property pop As Integer
   Public Property title As String
   Public Property text As String
   Public Property text_metric As String
End Class

Public Class Summary
   Public Property [date] As pwsDate
   Public Property high As Integer
   Public Property low As Integer
   Public Property condition As String
   Public Property icon As String
   Public Property icon_url As String
   Public Property skyicon As Object
   Public Property precip_type As String
   Public Property pop As Integer
   Public Property liquid_precip As Double
   Public Property snow As Double
   Public Property snow_range As Object
   Public Property wind_max_speed As Integer
   Public Property wind_max_dir As String
   Public Property wind_max_dir_degrees As Integer
   Public Property wind_avg_speed As Integer
   Public Property wind_avg_dir As String
   Public Property wind_avg_dir_degrees As Integer
   Public Property humidity_avg As Integer
   Public Property humidity_min As Object
   Public Property humidity_max As Object
   Public Property weather_quickie As String
   Public Property day As Day
   Public Property night As Night
End Class

Public Class HistorySummary
   Public Property [date] As pwsDate
   Public Property max_temperature As Double
   Public Property min_temperature As Double
   Public Property temperature As Double
   Public Property max_dewpoint As Double
   Public Property min_dewpoint As Double
   Public Property dewpoint As Double
   Public Property max_humidity As Integer
   Public Property min_humidity As Integer
   Public Property humidity As Integer
   Public Property precip_today As Double
   Public Property wind_dir As String
   Public Property wind_dir_degrees As Integer
   Public Property max_wind_dir As String
   Public Property max_wind_dir_degrees As Integer
   Public Property max_wind_speed As Integer
   Public Property wind_speed As Integer
   Public Property max_gust_dir As String
   Public Property max_gust_dir_degrees As Integer
   Public Property max_wind_gust_speed As Integer
   Public Property wind_gust_speed As Integer
   Public Property max_pressure As Double
   Public Property min_pressure As Double
   Public Property pressure As Double




   Public Property condition As String
   Public Property icon As String
   Public Property icon_url As String
   Public Property skyicon As Object
   Public Property precip_type As String
   Public Property pop As Integer
   Public Property liquid_precip As Double
   Public Property snow As Double
   Public Property snow_range As Object
   Public Property wind_max_speed As Integer
   Public Property wind_max_dir As String
   Public Property wind_max_dir_degrees As Integer
   Public Property wind_avg_speed As Integer
   Public Property wind_avg_dir As String
   Public Property wind_avg_dir_degrees As Integer
   Public Property humidity_avg As Integer
   Public Property humidity_min As Object
   Public Property humidity_max As Object
   Public Property weather_quickie As String
   Public Property day As Day
   Public Property night As Night
End Class

Public Class sumDay
   Public Property summary As Summary
End Class

Public Class Forecast
   Public Property source As String
   Public Property days As [Day]()
End Class

Public Class LengthOfDayDiffNextday
   Public Property minutes As Integer?
   Public Property seconds As Integer?
   Public Property sign As String
End Class

Public Class Sunrise
   Public Property english_phrase As String
   Public Property [date] As pwsDate
End Class

Public Class Sunset
   Public Property english_phrase As String
   Public Property [date] As pwsDate
End Class

Public Class CivilSunrise
   Public Property english_phrase As String
   Public Property [date] As pwsDate
End Class

Public Class CivilSunset
   Public Property english_phrase As String
   Public Property [date] As pwsDate
End Class

Public Class NauticalSunrise
   Public Property english_phrase As String
   Public Property [date] As pwsDate
End Class

Public Class NauticalSunset
   Public Property english_phrase As String
   Public Property [date] As pwsDate
End Class

Public Class AstronomicalSunrise
   Public Property english_phrase As String
   Public Property [date] As pwsDate
End Class

Public Class AstronomicalSunset
   Public Property english_phrase As String
   Public Property [date] As pwsDate
End Class

Public Class Moonrise
   Public Property [date] As pwsDate
End Class

Public Class Moonset
   Public Property [date] As pwsDate
End Class

Public Class pwsDay
   Public Property length_of_day As String
   Public Property length_of_night As String
   Public Property length_of_twilight As String
   Public Property length_of_day_diff_nextday As LengthOfDayDiffNextday
   Public Property sunrise As Sunrise
   Public Property sunset As Sunset
   Public Property civilSunrise As CivilSunrise
   Public Property civilSunset As CivilSunset
   Public Property nauticalSunrise As NauticalSunrise
   Public Property nauticalSunset As NauticalSunset
   Public Property astronomicalSunrise As AstronomicalSunrise
   Public Property astronomicalSunset As AstronomicalSunset
   Public Property moonrise As Moonrise
   Public Property moonset As Moonset
   Public Property moon_age As String
   Public Property moon_phase As String
   Public Property moon_icon As String
   Public Property moon_percent_illuminated As Integer
End Class

Public Class MoonPhas
   Public Property [date] As pwsDate
   Public Property moon_age As Integer
   Public Property moon_phase As String
End Class

Public Class Astronomy
   Public Property days As Day()
   Public Property hemisphere As String
   Public Property moon_phases As MoonPhas()
End Class

Public Class StartDate
   Public Property epoch As Integer
   Public Property pretty As String
   Public Property rfc822 As String
   Public Property iso8601 As DateTime
   Public Property year As Integer
   Public Property month As Integer
   Public Property day As Integer
   Public Property yday As Integer
   Public Property hour As Integer
   Public Property min As String
   Public Property sec As Integer
   Public Property monthname As String
   Public Property monthname_short As String
   Public Property weekday As String
   Public Property weekday_short As String
   Public Property ampm As String
   Public Property tz_short As String
   Public Property tz_long As String
   Public Property tz_offset_text As String
   Public Property tz_offset_hours As Double
End Class

Public Class EndDate
   Public Property epoch As Integer
   Public Property pretty As String
   Public Property rfc822 As String
   Public Property iso8601 As DateTime
   Public Property year As Integer
   Public Property month As Integer
   Public Property day As Integer
   Public Property yday As Integer
   Public Property hour As Integer
   Public Property min As String
   Public Property sec As Integer
   Public Property monthname As String
   Public Property monthname_short As String
   Public Property weekday As String
   Public Property weekday_short As String
   Public Property ampm As String
   Public Property tz_short As String
   Public Property tz_long As String
   Public Property tz_offset_text As String
   Public Property tz_offset_hours As Double
End Class

Public Class Observation
   Public Property [date] As pwsDate
   Public Property temperature As Double
   Public Property dewpoint As Double
   Public Property humidity As Integer
   Public Property wind_speed As Double
   Public Property wind_gust_speed As Object
   Public Property wind_dir_degrees As Integer
   Public Property wind_dir As String
   Public Property pressure As Double
   Public Property windchill As Object
   Public Property heatindex As Object
   Public Property precip As Double?
   Public Property precip_rate As Object
   Public Property precip_1hr As Double
   Public Property precip_today As Double
   Public Property solarradiation As Object
   Public Property uv_index As Object
   Public Property temperature_indoor As Object
   Public Property humidity_indoor As Object
   Public Property software_type As Object
End Class

Public Class xDay
   Public Property summary As Summary
   Public Property observations As Observation()
End Class

Public Class History
   Public Property start_date As StartDate
   Public Property end_date As EndDate
   Public Property days As HistoryDay
End Class

Public Class StationErrors
End Class

Public Class SensorStatus
   Public Property temperature As String
   Public Property dewpoint As String
   Public Property humidity As String
   Public Property wind As String
   Public Property pressure As String
   Public Property rain As String
   Public Property solar_radiation As String
   Public Property uv As String
   Public Property indoor As String
   Public Property webcam As String
End Class

Public Class Pwsidentity
   Public Property qc_status As String
   Public Property id As String
   Public Property id_utf8 As String
   Public Property owner_name As String
   Public Property photohandle As String
   Public Property neighborhood As String
   Public Property organization As String
   Public Property stationtype As String
   Public Property stationsoftware As String
   Public Property city As String
   Public Property state As String
   Public Property zip As String
   Public Property country As String
   Public Property zmw As String
   Public Property lat As String
   Public Property lat_nice As String
   Public Property lat_hms As String
   Public Property lon As String
   Public Property lon_nice As String
   Public Property lon_hms As String
   Public Property elevation As String
   Public Property surface_type As String
   Public Property height As String
   Public Property linktext As String
   Public Property linkurl As String
   Public Property tzname As String
   Public Property tz_offset As String
   Public Property tz_offset_houronly As String
   Public Property tz_offset_decimal As String
   Public Property madis_shef_id As String
   Public Property has_status_message As String
   Public Property portrait As String
   Public Property portrait_url As String
   Public Property portrait_large_url As String
   Public Property portrait_banner_url As String
   Public Property portrait_thumb_url As String
   Public Property allow_messages As String
   Public Property inactivemsg As String
   Public Property allownews As String
   Public Property start_date As String
   Public Property start_month As String
   Public Property start_day As String
   Public Property start_year As String
   Public Property first_year As String
   Public Property last_update_epoch As String
   Public Property last_updated_string As String
   Public Property view_count As String
   Public Property view_count_date As String
   Public Property pws_status_message As String
   Public Property pws_status_message_epoch As String
   Public Property station_errors As StationErrors
   Public Property isrecent As String
   Public Property webcams As Object()
   Public Property sensor_status As SensorStatus
End Class

Public Class NotAvailable
   Public Property label As String
End Class

Public Class Place
   Public Property label As String
End Class

Public Class Elevation
   Public Property abbrev As String
   Public Property label As String
   Public Property units As String
End Class

Public Class Temperature
   Public Property abbrev As String
   Public Property label As String
   Public Property units_nosymbol As String
   Public Property units As String
End Class

Public Class Feelslike
   Public Property label As String
   Public Property units_nosymbol As String
   Public Property units As String
End Class

Public Class Windchill
   Public Property label As String
   Public Property units_nosymbol As String
   Public Property units As String
End Class

Public Class Heatindex
   Public Property label As String
   Public Property units_nosymbol As String
   Public Property units As String
End Class

Public Class Dewpoint
   Public Property label As String
   Public Property units_nosymbol As String
   Public Property units As String
End Class

Public Class Humidity
   Public Property label As String
   Public Property units As String
End Class

Public Class Pressure
   Public Property label As String
   Public Property units As String
End Class

Public Class Wind
   Public Property label As String
End Class

Public Class WindSpeed
   Public Property label As String
   Public Property separator As String
   Public Property units As String
End Class

Public Class WindDirection
   Public Property label As String
   Public Property separator As String
End Class

Public Class WindGust
   Public Property label As String
   Public Property units As String
End Class

Public Class Variable
   Public Property label As String
End Class

Public Class Calm
   Public Property label As String
End Class

Public Class Moisture
   Public Property label As String
End Class

Public Class Rainfall
   Public Property label As String
   Public Property units As String
End Class

Public Class SnowDepth
   Public Property label As String
   Public Property units As String
End Class

Public Class Visibility
   Public Property label As String
   Public Property units As String
End Class

Public Class Clouds
   Public Property label As String
End Class

Public Class Health
   Public Property label As String
End Class

Public Class AirQuality
   Public Property label As String
End Class

Public Class FluTracker
   Public Property label As String
End Class

Public Class Ozone
   Public Property label As String
End Class

Public Class UvIndex
   Public Property label As String
   Public Property abbrev As String
   Public Property separator As String
End Class

Public Class Pollen
   Public Property label As String
   Public Property separator As String
End Class

Public Class Time
   Public Property label As String
End Class

Public Class Now
   Public Property label As String
End Class

Public Class Today
   Public Property label As String
End Class

Public Class Tomorrow
   Public Property label As String
End Class

Public Class Tomorrownight
   Public Property label As String
End Class

Public Class Sunday
   Public Property abbrev As String
   Public Property label As String
End Class

Public Class Monday
   Public Property abbrev As String
   Public Property label As String
End Class

Public Class Tuesday
   Public Property abbrev As String
   Public Property label As String
End Class

Public Class Wednesday
   Public Property abbrev As String
   Public Property label As String
End Class

Public Class Thursday
   Public Property abbrev As String
   Public Property label As String
End Class

Public Class Friday
   Public Property abbrev As String
   Public Property label As String
End Class

Public Class Saturday
   Public Property abbrev As String
   Public Property label As String
End Class

Public Class Sundaynight
   Public Property label As String
End Class

Public Class Mondaynight
   Public Property label As String
End Class

Public Class Tuesdaynight
   Public Property label As String
End Class

Public Class Wednesdaynight
   Public Property label As String
End Class

Public Class Thursdaynight
   Public Property label As String
End Class

Public Class Fridaynight
   Public Property label As String
End Class

Public Class Saturdaynight
   Public Property label As String
End Class

Public Class Moon
   Public Property label As String
End Class

Public Class Nomoonrise
   Public Property label As String
End Class

Public Class Nomoonset
   Public Property label As String
End Class

Public Class Weatherstation
   Public Property label As String
End Class

Public Class NoReporting
   Public Property label As String
End Class

Public Class Pws1
   Public Property label As String
End Class

Public Class Airport
   Public Property label As String
End Class

Public Class Updated
   Public Property label As String
End Class

Public Class Source
   Public Property label As String
End Class

Public Class Pop
   Public Property abbrev As String
   Public Property label As String
   Public Property units As String
End Class

Public Class Chancerain
   Public Property label As String
   Public Property units As String
End Class

Public Class Chancesnow
   Public Property label As String
   Public Property units As String
End Class

Public Class Precipitation
   Public Property abbrev As String
   Public Property label As String
End Class

Public Class Cloudcover
   Public Property label As String
   Public Property units As String
End Class

Public Class Conditions
   Public Property label As String
End Class

Public Class CurrentConditions
   Public Property label As String
End Class

Public Class North
   Public Property abbrev As String
   Public Property label As String
End Class

Public Class East
   Public Property abbrev As String
   Public Property label As String
End Class

Public Class South
   Public Property abbrev As String
   Public Property label As String
End Class

Public Class West
   Public Property abbrev As String
   Public Property label As String
End Class

Public Class Distance
   Public Property label As String
   Public Property units As String
End Class

Public Class Labels
   Public Property not_available As NotAvailable
   Public Property place As Place
   Public Property elevation As Elevation
   Public Property temperature As Temperature
   Public Property feelslike As Feelslike
   Public Property windchill As Windchill
   Public Property heatindex As Heatindex
   Public Property dewpoint As Dewpoint
   Public Property humidity As Humidity
   Public Property pressure As Pressure
   Public Property wind As Wind
   Public Property wind_speed As WindSpeed
   Public Property wind_direction As WindDirection
   Public Property wind_gust As WindGust
   Public Property variable As Variable
   Public Property calm As Calm
   Public Property moisture As Moisture
   Public Property rainfall As Rainfall
   Public Property snow_depth As SnowDepth
   Public Property visibility As Visibility
   Public Property clouds As Clouds
   Public Property health As Health
   Public Property air_quality As AirQuality
   Public Property flu_tracker As FluTracker
   Public Property ozone As Ozone
   Public Property uv_index As UvIndex
   Public Property pollen As Pollen
   Public Property time As Time
   Public Property now As Now
   Public Property today As Today
   Public Property tomorrow As Tomorrow
   Public Property tomorrownight As Tomorrownight
   Public Property sunday As Sunday
   Public Property monday As Monday
   Public Property tuesday As Tuesday
   Public Property wednesday As Wednesday
   Public Property thursday As Thursday
   Public Property friday As Friday
   Public Property saturday As Saturday
   Public Property sundaynight As Sundaynight
   Public Property mondaynight As Mondaynight
   Public Property tuesdaynight As Tuesdaynight
   Public Property wednesdaynight As Wednesdaynight
   Public Property thursdaynight As Thursdaynight
   Public Property fridaynight As Fridaynight
   Public Property saturdaynight As Saturdaynight
   Public Property sunrise As Sunrise
   Public Property sunset As Sunrise
   Public Property moon As Moon
   Public Property nomoonrise As Nomoonrise
   Public Property nomoonset As Nomoonset
   Public Property weatherstation As Weatherstation
   Public Property no_reporting As NoReporting
   Public Property pws As pws
   Public Property airport As Airport
   Public Property updated As Updated
   Public Property source As Source
   Public Property pop As Pop
   Public Property chancerain As Chancerain
   Public Property chancesnow As Chancesnow
   Public Property precipitation As Precipitation
   Public Property cloudcover As Cloudcover
   Public Property conditions As Conditions
   Public Property current_conditions As CurrentConditions
   Public Property north As North
   Public Property east As East
   Public Property south As South
   Public Property west As West
   Public Property distance As Distance
End Class

Public Class PwsBootstrap
   Public Property response As Response
   Public Property current_observation As CurrentObservation
   Public Property forecast As Forecast
   Public Property astronomy As Astronomy
   Public Property history As History
   Public Property pwsidentity As Pwsidentity
   Public Property labels As Labels
End Class

Public Class RadarCamVars
   Public Property stationid As String
   Public Property units As String
   Public Property nwo As Boolean
   Public Property sda As Boolean
   Public Property cam As Boolean
   Public Property nim As Boolean
   Public Property pws_bootstrap As PwsBootstrap
   Public Property country As String
   Public Property mapTypeId As String
   Public Property lat As String
   Public Property lon As String
   Public Property isRecent As String
   Public Property lastUpdateEpoch As String
   Public Property mode As String
   Public Property scrollTo As Object
End Class

Public Class pws
   Public Property crossLinkingVars As CrossLinkingVars
   Public Property radarCamVars As RadarCamVars
End Class