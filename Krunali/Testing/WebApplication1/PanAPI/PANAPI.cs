using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
namespace PanAPI
{
    class MyPolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint,
        X509Certificate certificate, WebRequest request, int certificateProblem)
        {
            return true;
        }
    }
    public class PANAPI 
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
        private HttpClient client;
        private const string Host_URL = "api/v1/location/search/London?lang={0}";
        private const string DATA = @"{""user"": ""kyg_18"",""password"": ""GniAzc3BDt7j""}";
        private const string urlParameters = "?api_key=123";
        private const string baseAddress = "https://pfa.foreca.com/";
        private string Authn = "";
        dynamic result = "";

        //static PANAPI()
        //{
        //    client = new HttpClient()
        //    {
        //        BaseAddress = new Uri("https://date.nager.at")
        //    };
        //}

        public String SendSingleSMS(String username, String password, String
  senderid, String mobileNo, String message, String secureKey)

        {
            Stream dataStream;
            System.Net.ServicePointManager.SecurityProtocol =
SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 |
SecurityProtocolType.Tls;
            HttpWebRequest request =
            (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible;MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            // MyPolicy();
           // ServicePointManager.CertificatePolicy = new MyPolicy();
            String encryptedPassword = encryptedPasswod(password);
            string NewsecureKey = hashGenerator(username.Trim(),
            senderid.Trim(), message.Trim(), secureKey.Trim());
            string smsservicetype = "singlemsg"; //For single message.
            string query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
"&password=" + HttpUtility.UrlEncode(encryptedPassword) +
"&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
"&content=" + HttpUtility.UrlEncode(message.Trim()) +
"&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
"&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
"&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim());
            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }

        protected String encryptedPasswod(String password)
        {
            byte[] encPwd = Encoding.UTF8.GetBytes(password);
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
            byte[] pp = sha1.ComputeHash(encPwd);
            // static string result =
            System.Text.Encoding.UTF8.GetString(pp);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in pp)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        protected String hashGenerator(String Username, String sender_id,
String message, String secure_key)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
            byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
            byte[] sec_key = sha1.ComputeHash(genkey);
            StringBuilder sb1 = new StringBuilder();
            for (int i = 0; i < sec_key.Length; i++)
            {
                sb1.Append(sec_key[i].ToString("x2"));
            }
            return sb1.ToString();
        }

        public dynamic CreateAPIHttpClient(string lang)
        {
            GETAPIDataHttpWebReq();
            var content2="k";
            var url = string.Format(Host_URL, lang);
          //  client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9wZmEuZm9yZWNhLmNvbVwvYXV0aG9yaXplXC90b2tlbiIsImlhdCI6MTYzMjcyNzY2OSwiZXhwIjoxNjMyNzM0ODY5LCJuYmYiOjE2MzI3Mjc2NjksImp0aSI6IjVhNWQ4M2NmZDBiN2FkOTYiLCJzdWIiOiJreWdfMTgiLCJmbXQiOiJYRGNPaGpDNDArQUxqbFlUdGpiT2lBPT0ifQ.M2tcrwLkavEuthjhI_HEQyidjrEqCIdqjUsyV5dtLSo");
            client.DefaultRequestHeaders.Add("token", "d3aylyUL5Zlfq63rnH9No9qv-1AO9nzzID9rLygJNCRVwMIvD7KFHwcQGbYZrmPZJpjZUQcgiHtXhobAMk1gmVFY-Nw6j6pQpbGFeLjayPw");

            // List data response.
            HttpResponseMessage response = client.GetAsync("https://bharatnetprogress.nic.in/wbhdcl176/rest/services/NetworkDataSet/AllindiaNetwork/NAServer").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
            }
            else
            {   
                throw new HttpRequestException(response.ReasonPhrase);
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

        //public async Task<List<APIModel>> GetHolidays(string countryCode, int year)
        //{
        //  //  var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", year, countryCode);
        //    var result = new List<APIModel>();
        //    var response = await client.GetAsync(Host_URL);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var stringResponse = await response.Content.ReadAsStringAsync();

        //        result = System.Text.Json.JsonSerializer.Deserialize<List<APIModel>>(stringResponse,
        //            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        //    }
        //    else
        //    {
        //        throw new HttpRequestException(response.ReasonPhrase);
        //    }
        //    return result;
        //}
    }
}

