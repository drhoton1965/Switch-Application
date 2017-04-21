Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Configuration

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class clsJSON
   'Private Sub ParseHTML(passedHTML() As String)

   '   'Local Variables
   '   Dim iDataStart, iDataEnd, iExtractStartPos, iDataLength As Integer
   '   Dim jsonInput As String = ""
   '   Try

   '      iDataStart = passedHTML(0).IndexOf("wui.bootstrapped.pwsdashboard")
   '      iDataEnd = passedHTML(0).IndexOf("};", (iDataStart + 1))

   '      iExtractStartPos = iDataStart + "wui.bootstrapped.pwsdashboard".Length + 3
   '      iDataLength = (iDataEnd - iDataStart - "wui.bootstrapped.pwsdashboard".Length - 2)

   '      jsonInput = passedHTML(0).Substring(iExtractStartPos, iDataLength)


   '      'JSON Serializer
   '      'Dim jSER As New JsonSerializer

   '      'JSON section
   '      jo = New JObject

   '      ' Parse json *OBJECT*
   '      jo = JObject.Parse(jsonInput)
   '      If My.Settings.WriteHTMLFile Then
   '         Dim outProp As New StreamWriter(My.Settings.HTMLOutFileLocation & "WeatherUndergroundPropList_" & DateTime.Now.ToString("yyyy-MM-dd_hhmmss") & ".txt")
   '         Dim reader As New JsonTextReader(New StringReader(jsonInput))
   '         While reader.Read()
   '            If reader.Value IsNot Nothing Then
   '               Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value)
   '               outProp.WriteLine("{0}| {1}", reader.TokenType, reader.Value)
   '            Else
   '               Console.WriteLine("Token: {0}", reader.TokenType)
   '            End If
   '         End While
   '         outProp.Flush()
   '         outProp.Close()
   '      End If

   '      Dim paramName As String = "DLRJson"
   '      'jsonKeyValues.Add(paramName, jsonInput)
   '      ParseJsonProperties(jo, paramName)

   '      Dim dLINE As String

   '      Dim curOBS = New MyWeatherSwitch.CurrentObservation()
   '      Dim jsonOBS As JToken
   '      Dim sJSON_OBS As String

   '      jsonOBS = jo("radarCamVars")("pws_bootstrap")("current_observation")
   '      sJSON_OBS = jsonOBS.ToString

   '      JsonConvert.PopulateObject(sJSON_OBS, curOBS)

   '      'Dim outFILE As New StreamWriter("C:\dlrstuff\WeatherUndergroundJSON_" & DateTime.Now.ToString("yyyy-MM-dd_hhmmss") & ".txt")

   '      For Each prop As JProperty In jsonOBS
   '         lstPropList.Items.Add(prop.Name.ToString() & "  |  " & prop.Value.ToString)
   '      Next

   '      For Each item As Object In jsonKeyValues
   '         ListBox1.Items.Add("Key: " & item.Key.ToString & vbTab & " ---> " & item.Value)
   '         dLINE = item.Key.ToString & " | " & item.Value
   '         'outFILE.WriteLine(dLINE)
   '      Next
   '      'outFILE.Flush()
   '      'outFILE.Close()

   '   Catch ex As Exception
   '      lblStackValue.Visible = True
   '      lblErrVal.Visible = False

   '      lblStackValue.Text = ex.StackTrace
   '      lblErrVal.Text = "Error: " & ex.Message
   '      Console.WriteLine()

   '      Console.WriteLine()

   '   End Try

   'End Sub




   'Public Shared Sub ParseJsonProperties(myJSONObject As JObject, paramName As String)
   '   Dim jObject_Properties As IEnumerable(Of JProperty) = myJSONObject.Properties()

   '   ' Build list of valid property and object types 
   '   Dim validPropertyValueTypes As JTokenType() = {JTokenType.[String], JTokenType.[Integer], JTokenType.Float, JTokenType.[Boolean], JTokenType.Null, JTokenType.[Date], _
   '       JTokenType.Bytes, JTokenType.Guid, JTokenType.Uri, JTokenType.TimeSpan}
   '   Dim propertyTypes As New List(Of JTokenType)(validPropertyValueTypes)

   '   Dim validObjectTypes As JTokenType() = {JTokenType.[String], JTokenType.Array, JTokenType.[Object]}
   '   Dim objectTypes As New List(Of JTokenType)(validObjectTypes)

   '   Dim currentParamName As String = paramName
   '   'Need to track where we are.
   '   For Each [property] As JProperty In jObject_Properties
   '      paramName = currentParamName

   '      Try
   '         If propertyTypes.Contains([property].Value.Type) Then
   '            ParseJsonKeyValue([property], (paramName & Convert.ToString(".")) + [property].Name.ToString())
   '         ElseIf objectTypes.Contains([property].Value.Type) Then
   '            'Arrays ex. { names: ["first": "John", "last" : "doe"]}
   '            If [property].Value.Type = JTokenType.Array AndAlso [property].Value.HasValues Then
   '               ParseJsonArray([property], paramName)
   '            End If

   '            'Objects ex. { name: "john"}
   '            If [property].Value.Type = JTokenType.[Object] Then
   '               Dim jo As New JObject()
   '               jo = JObject.Parse([property].Value.ToString())
   '               paramName = (paramName & Convert.ToString(".")) + [property].Name.ToString()

   '               jsonKeyValues.Add(paramName, [property].Value.ToString())

   '               If jo.HasValues Then
   '                  ParseJsonProperties(jo, paramName)

   '               End If
   '            End If
   '         End If
   '      Catch ex As Exception
   '         Throw
   '      End Try
   '   Next
   '   ' End of ForEach
   '   paramName = currentParamName

   'End Sub

   'Public Shared Sub ParseJsonKeyValue(item As JProperty, paramName As String)
   '   jsonKeyValues.Add(paramName, item.Value.ToString())
   'End Sub

   'Public Shared Sub ParseJsonArray(item As JProperty, paramName As String)
   '   Dim jArray As JArray = DirectCast(item.Value, JArray)

   '   paramName = (paramName & Convert.ToString("_")) + item.Name.ToString()
   '   jsonKeyValues.Add(paramName, item.Value.ToString())

   '   Dim currentParamName As String = paramName
   '   'Need track where we are
   '   Try
   '      For i As Integer = 0 To jArray.Count - 1
   '         paramName = currentParamName

   '         paramName = (paramName & Convert.ToString("_")) + i.ToString()
   '         jsonKeyValues.Add(paramName, jArray.Values().ElementAt(i).ToString())

   '         Dim jo As New JObject()
   '         jo = JObject.Parse(jArray(i).ToString())
   '         Dim jArrayEnum As IEnumerable(Of JProperty) = jo.Properties()

   '         For Each jaItem As JProperty In jArrayEnum
   '            ' Prior to JSON.NET VER 5.0, there was no Path property on JTokens. So we had to track the path on our own.
   '            Dim paramNameWithJaItem = (paramName & Convert.ToString("_")) + jaItem.Name.ToString()

   '            Dim itemValue = jaItem.Value.ToString(Formatting.None)
   '            If itemValue.Length > 0 Then
   '               Select Case itemValue.Substring(0, 1)
   '                  Case "["
   '                     'Recusion call to itself
   '                     ParseJsonArray(jaItem, paramNameWithJaItem)
   '                     Exit Select
   '                  Case "{"
   '                     'Create a new JObject and parse
   '                     Dim joObject As New JObject()
   '                     joObject = JObject.Parse(itemValue)

   '                     'For this value, reparse from the top
   '                     ParseJsonProperties(joObject, paramNameWithJaItem)
   '                     Exit Select
   '                  Case Else
   '                     ParseJsonKeyValue(jaItem, paramNameWithJaItem)
   '                     Exit Select
   '               End Select
   '            End If
   '         Next
   '      Next
   '      'end for loop
   '      paramName = currentParamName
   '   Catch ex As Exception
   '      Throw
   '   End Try
   'End Sub

   'Public Shared Sub JsonDotNetPathProperty()
   '    Dim json As String = vbCr & vbLf & "            {" & vbCr & vbLf & "                ""car"": {" & vbCr & vbLf & "                    ""type"": [{" & vbCr & vbLf & "                        ""sedan"": {" & vbCr & vbLf & "                            ""make"": ""honda""," & vbCr & vbLf & "                            ""model"": ""civic""" & vbCr & vbLf & "                        }" & vbCr & vbLf & "                    }," & vbCr & vbLf & "                    {" & vbCr & vbLf & "                        ""coupe"": {" & vbCr & vbLf & "                            ""make"": ""ford""," & vbCr & vbLf & "                            ""model"": ""escort""" & vbCr & vbLf & "                        }" & vbCr & vbLf & "                    }]" & vbCr & vbLf & "                }" & vbCr & vbLf & "            }"

   '    Dim obj As JObject = JObject.Parse(json)
   '    Dim token As JToken = obj("car")("type")(0)("sedan")("make")
   '    Console.WriteLine(token.Path + " -> " + token.ToString())
   'End Sub


End Class
