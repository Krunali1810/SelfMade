using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lat_Long_Scraper
{
    public partial class Lat_Long_Scraper : System.Web.UI.Page
    {
        private HttpClient client;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://pincode.p.rapidapi.com/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-rapidapi-host", "pincode.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "94d259ce9amshecd9c7c4954fb43p145442jsn4fa35ff1adf3");
            var body = @"{
" + "\n" +
            @"    ""searchBy"": ""pincode"",
" + "\n" +
            @"    ""value"": 110001
" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}