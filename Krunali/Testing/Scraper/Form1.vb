Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Text.RegularExpressions
Imports GoogleMaps.LocationServices

Public Class Form1
    Dim lines() As String
    Dim t As Thread
    Public filePath As String
    Public fileLog As String
    Public InputFilePath As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        createDirectory()
    End Sub
    Private Sub createDirectory()
        Try
            filePath = Application.StartupPath & "\APIData"
            fileLog = filePath & "\\" & "Log.txt"
            If Not Directory.Exists(filePath) Then
                MkDir(filePath)
            End If

            If Not File.Exists(filePath & "\\" & "APIData.txt") Then
                File.Create(filePath & "\\" & "APIData.txt")
            End If

            If Not Directory.Exists(fileLog) Then
                MkDir(fileLog)
            End If

            InputFilePath = filePath & "\\InputFile.txt"

            lines = File.ReadAllLines(InputFilePath.Replace(",", ""))

        Catch ex As Exception

        End Try
    End Sub
    Public Sub scrapeLocationUsingGService()
        Try
            For i As Integer = 0 To lines.Length - 1
                Try
                    Dim address As String = lines(i)
                    '   Dim address = "75 Ninth Avenue 2nd and 4th Floors New York, NY 10011"
                    Dim locationService = New GoogleLocationService(True)
                    Dim point = locationService.GetLatLongFromAddress(address)
                    Dim latitude = point.Latitude
                    Dim longitude = point.Longitude
                    Dim value As String = latitude & "," & longitude

                    Using writer As StreamWriter =
                New StreamWriter(filePath & "\\" & "APIData.txt", FileMode.OpenOrCreate)
                        writer.Write(lines(i) & "," & value)
                        writer.Write(Environment.NewLine)
                    End Using

                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try

    End Sub
    Public Sub scrapeLocationUsingHttpWeb()
        Try
            For i As Integer = 0 To lines.Length - 1
                Dim sr As String = ""
                Dim str = ""
                Dim currentPosition As String = i.ToString()
                Dim s1() As String
                Dim code As String = ""
                Dim value As String = ""
                Dim address As String = ""
                Dim city As String = ""
                Dim pincode As String = ""
                Dim result As Boolean
                Dim latitude As String = ""
                Dim longitude As String = ""
                Dim state As String = ""

                If lines(i).Contains(",") Then
                    s1 = Split(lines(i), ",")
                    city = s1(s1.Length - 2).Trim()
                    pincode = s1(s1.Length - 1).Trim()
                    address = s1(0) & "," & city
                Else Stop
                End If

                If address = "," Then
                    address = ""
                End If

                'If address.Contains(",") Then
                '    address = address.Replace(",", "")
                'End If

                If city = "," Then
                    city = ""
                End If

                If lines(i).Contains("==") Then
                    s1 = Split(lines(i), "==")
                    state = s1(1)
                    s1 = Split(s1(0), ",")
                    pincode = s1(2)
                End If

                'str = "https://www.google.com/maps/place/" & address
                str = "https://www.google.com/maps/search/" & address.Replace("���", "'") & ",Post Office"


                Label3.Text = "Extract Lat and Long From API: https://stevemorse.org"
                'Label2.Text = currentPosition

                Try
                    'win http request to get data
                    '===========================================
                    Dim req1 As WinHttp.WinHttpRequest = New WinHttp.WinHttpRequest

                    req1.Open("GET", "https://stevemorse.org/jcal/proxycode.php?&noCacheIE=1630567672249")
                    req1.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.159 Safari/537.36")
                    req1.SetRequestHeader("Origin", "https://stevemorse.org")
                    req1.Send()
                    sr = ""
                    sr = req1.ResponseText

                    'code split
                    If sr.Contains("CodeCallback('") Then
                        s1 = Split(sr, "CodeCallback('")
                        s1 = Split(s1(1), "'")
                        code = s1(0)
                    Else
                        Stop
                    End If

                    Dim DecodedAddress = WebUtility.UrlEncode(lines(i))
                    Dim DecodedCity = WebUtility.UrlEncode(city)

                    Dim Request_URL = "https://stevemorse.org/jcal/latlonlocal.php?cookie=&hidden=&doextra=&code=" & code & "&protocol=https%3A&time=1630567672249&addr2latlon=1&address=" & DecodedAddress & "&city=&state=Gujarat&zip=" & pincode & "&country=IN&latlon2addr=0&latitude=&longitude="
                    'Request URL: https://stevemorse.org/jcal/latlonlocal.php?cookie=&hidden=&doextra=&code=1802081&protocol=https%3A&time=1634370428173&addr2latlon=1&address=Haripura%2C+Asarwa%2C+Ahmedabad%2C+Gujarat+&city=Ahmedabad&state=Gujarat&zip=&country=IN&latlon2addr=0&latitude=&longitude=

                    req1.Open("GET", Request_URL)
                    req1.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.159 Safari/537.36")
                    req1.SetRequestHeader("Origin", "https://stevemorse.org")
                    req1.Send()
                    sr = ""
                    sr = req1.ResponseText
                Catch ex As Exception

                End Try

                '=====================================================================
                '' Splitting
                If address <> "" Then
                    If sr.Contains("[[2],[[null,null,") Then
                        s1 = sr.Split({"[[2],[[null,null,"}, StringSplitOptions.None)
                        s1 = Split(s1(1), "]")
                        value = s1(0)
                    ElseIf sr.Contains("INITIALIZATION_STATE=[[[") Then
                        s1 = sr.Split({"INITIALIZATION_STATE=[[["}, StringSplitOptions.None)
                        s1 = Split(s1(1), "],")
                        value = s1(0)
                    ElseIf sr.Contains(">yahoo</a>") Then
                        s1 = sr.Split({">yahoo</a>"}, StringSplitOptions.None)
                        s1 = s1(1).Split({"<td>decimal</td>"}, StringSplitOptions.None)
                        s1 = Split(s1(1), "</span>")
                        value = Regex.Replace(s1(0).Replace("</td><td>", ","), "<[^>]*>", String.Empty).TrimEnd(",")
                    ElseIf sr.Contains("<tr><td>decimal</td><td>") Then
                        s1 = sr.Split({"<tr><td>decimal</td><td>"}, StringSplitOptions.None)
                        s1 = Split(s1(1), "</span>")
                        value = Regex.Replace(s1(0).Replace("</td><td>", ","), "<[^>]*>", String.Empty).TrimEnd(",")
                    End If
                Else
                    If sr.Contains(">LocationIQ</a>") Then
                        s1 = sr.Split({">LocationIQ</a>"}, StringSplitOptions.None)
                        s1 = s1(1).Split({"<td>decimal</td>"}, StringSplitOptions.None)
                        s1 = Split(s1(1), "</span>")
                        value = Regex.Replace(s1(0).Replace("</td><td>", ","), "<[^>]*>", String.Empty).TrimEnd(",")
                    End If
                End If

                If value.Contains(",") Then
                    s1 = value.Split(",")
                    If (s1.Length > 2) Then
                        latitude = s1(1)
                        longitude = s1(2)
                    Else
                        latitude = s1(0)
                        longitude = s1(1)
                    End If
                End If

                If pincode = "" Then
                    ''yahoofeet'];</script>
                    If sr.Contains("'yahoofeet'];</script>") Then
                        s1 = sr.Split({"'yahoofeet'];</script>"}, StringSplitOptions.None)
                        s1 = Split(s1(1), "<br><br>")
                        pincode = s1(0).Trim()
                    End If
                End If

                If ReverseCheckingLat_Long(latitude, longitude, address) = True Then
                    Using writer As StreamWriter =
                     New StreamWriter(filePath & "\\" & "APIData.txt", FileMode.OpenOrCreate)
                        writer.Write(lines(i) & "," & value)
                        writer.Write(Environment.NewLine)
                        writer.Close()
                    End Using
                Else
                    Continue For
                End If

            Next
        Catch ex As Exception

        End Try
        Label2.Text = "Scrape Done"
        Application.Exit()
    End Sub
    Public Function ReverseCheckingLat_Long(ByVal Latitude As String, ByVal Longitude As String, ByVal city As String) As Boolean
        '' for reverse checking

        Dim source As String = ""
        Dim req2 As WinHttp.WinHttpRequest = New WinHttp.WinHttpRequest

        Try
            req2.Open("GET", "http://reversegeocoding.nic.in/GetVillageDetails/api/GeoData/getVillageDetails?lon=" & Longitude & "&lat=" & Latitude)
            req2.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.159 Safari/537.36")
            req2.Send()
            source = ""
            source = req2.ResponseText
            req2.Abort()
        Catch ex As Exception

        End Try

        'And source.Contains("districtname"":""" & district) 
        Dim state = "GUJARAT"
        If source.Contains("""statename"":""" & state) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        t = New System.Threading.Thread(AddressOf scrapeLocationUsingHttpWeb)
        t.Start()
        ' scrapeLocationUsingHttpWeb(sender)
    End Sub
End Class
