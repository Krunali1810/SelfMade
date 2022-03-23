using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // Simple Sample web API

        //public IEnumerable<string> Get()
        //{
        //    IList<string> formatters = new List<string>();

        //    formatters.Add(GlobalConfiguration.Configuration.Formatters.JsonFormatter.GetType().FullName);
        //    formatters.Add(GlobalConfiguration.Configuration.Formatters.XmlFormatter.GetType().FullName);
        //    formatters.Add(GlobalConfiguration.Configuration.Formatters.FormUrlEncodedFormatter.GetType().FullName);

        //    return formatters.AsEnumerable<string>();
        //}

        public string Get_name()
        {
            int res = Convert.ToInt32(2 + 3);

            return "Hello:: we have values " + res;
        }

    }
}
