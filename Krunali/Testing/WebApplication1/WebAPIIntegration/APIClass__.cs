using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Security.Cryptography.Xml;
using Newtonsoft.Json;

namespace WebAPIIntegration
{
    public class APIClass__
    {
        //https://coronavirus.m.pipedream.net/
        //https://apisetu.gov.in/certificate/v3/pan/pancr"
        //https://api.stormglass.io/v2/weather/point
        //http://api.weatherstack.com/current?access_key=424e1125e54c016579cfbdea6ad6e869&query=India
        //https://pfa.foreca.com/api/v1/forecast/daily/103128760'
        //https://api.stormglass.io/v2/weather/point?lat=58.7984&lng=17.8081&params=waveHeight,airTemperature
        //https://pfa.foreca.com/api/v1/location/search/Barcelona?lang=es'

        //@"{""txnId"":""f7f1469c-29b0-4325-9dfc-c567200a70f7"",""format"":""xml"",""certificateParameters"":{""panno"":""ABCD123EF"",""PANFullName"":""RAMESHWAR KUMAR SINGH"",""UID"":""123412341234"",""FullName"":""Sunil Kumar"",""DOB"":""31-12-1980"",""GENDER"":""M""},""consentArtifact"":{""consent"":{""consentId"":""ea9c43aa-7f5a-4bf3-a0be-e1caa24737ba"",""timestamp"":""2021-09-23T07:47:54.460Z"",""dataConsumer"":{""id"":""string""},""dataProvider"":{""id"":""string""},""purpose "":{ ""description"":""string""},""user "":{ ""idType"":""string"",""idNumber"":""string"",""mobile"":""string"",""email"":""string""},""data "":{ ""id"":""string""},""permission "":{""access"":""string"",""dateRange"":{""from"":""2021 - 09 - 23T07: 47:54.460Z"",""to"":""2021-09-23T07:47:54.460Z""},""frequency"":{""unit"":""string"",""value"":0,""repeats"":0}}},""signature"":{""signature"":""string""}}}";
        //eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9mbnc2LmZvcmVjYS5jb21cL2F1dGhvcml6ZVwvdG9rZW4iLCJpYXQiOjE1MjYzMDAzODAsImV4cCI6MTUyNjMwMzk4MCwibmJmIjoxNTI2MzAwMzgwLCJqdGkiOiJxSXl3WVlQNjc1NkczejBEIiwic3ViIjoibFFHa1Y4Z2pIeGUyZU1ibndUUUs4NktqVTY3RXJlS2htenY1IiwicHJ2IjoiYWY3YTAzOThkZGNiNWE3YTUzN2Q3YzdkMjU2NWEyZjgxZGM4ZTQxNCJ9.V8xg6L9yrY9__VH-jdrL_CqXisEpgcfdUa0NoxlGz0k
       
        private const string Host_URL = "api/v1/location/search/Ahmedabad?lang=";
        private const string DATA = @"{""user"": ""kyg_18"",""password"": ""GniAzc3BDt7j""}";
        private const string urlParameters = "?api_key=123";
        private const string baseAddress= "https://pfa.foreca.com/";
        private string Authn="";

        public dynamic CreateAPIHttpClient(string lang)
        {
            GETAPIDataHttpWebReq();
            HttpClient client = new HttpClient();
            HttpContent CP = null;
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9wZmEuZm9yZWNhLmNvbVwvYXV0aG9yaXplXC90b2tlbiIsImlhdCI6MTYzMjcyNzY2OSwiZXhwIjoxNjMyNzM0ODY5LCJuYmYiOjE2MzI3Mjc2NjksImp0aSI6IjVhNWQ4M2NmZDBiN2FkOTYiLCJzdWIiOiJreWdfMTgiLCJmbXQiOiJYRGNPaGpDNDArQUxqbFlUdGpiT2lBPT0ifQ.M2tcrwLkavEuthjhI_HEQyidjrEqCIdqjUsyV5dtLSo");

            // List data response.
            HttpResponseMessage response = client.GetAsync(Host_URL + lang).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            dynamic result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                double AirTemp = Convert.ToDouble(result["hours"][0]["airTemperature"]["dwd"]);
            }
            else
            {
            }
            client.Dispose();
            return result;
        }

        public static void GETAPIDataHttpWebReq()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://pfa.foreca.com/authorize/token?expire_hours=4");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = DATA.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(DATA);
            }
            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    Console.Out.WriteLine(response);
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }
        public static void CreateAPIHttpWebReq()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Host_URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = DATA.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(DATA);
            }
            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    Console.Out.WriteLine(response);
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }
    }
}
