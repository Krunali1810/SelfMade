using Microsoft.IdentityModel.Protocols.WSIdentity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static API_Service.AppService;

namespace API_Service
{
    public class SimpleApiServiceBharatMap : IApiService
    {
        private HttpClient client = new HttpClient();

        //private readonly ITokenService tokenService;

        public async Task<IList<string>> GetValues()
        {
            List<string> values = new List<string>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", "d3aylyUL5Zlfq63rnH9No9qv-1AO9nzzID9rLygJNCRVwMIvD7KFHwcQGbYZrmPZJpjZUQcgiHtXhobAMk1gmVFY-Nw6j6pQpbGFeLjayPw");
            var res = await client.GetAsync("https://bharatnetprogress.nic.in/wbhdcl176/rest/services/NetworkDataSet/AllindiaNetwork/NAServer");
            if (res.IsSuccessStatusCode)
            {
                var json = res.Content.ReadAsStringAsync().Result;
                values = JsonConvert.DeserializeObject<List<string>>(json);
            }
            else
            {
                values = new List<string> { res.StatusCode.ToString(), res.ReasonPhrase };
            }
            return values;
        }
    }    
  }

