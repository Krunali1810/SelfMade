using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService_Demo
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int converttodaysweb(int day, int month, int year)
        {
            DateTime dt = new DateTime(year, month, day);
            int datetodays = DateTime.Now.Subtract(dt).Days;
            return datetodays;
        }

        [WebMethod]
        public string MyRequest(string someurl)
        {    
            string url = "https://stackoverflow.com/questions/2089868/redirecting-to-a-web-page-from-a-web-service-call";
            bool end = false;

            Server.Transfer(someurl, end);
           
            return "<retcode>somecode</retcode>";
        }
    }
}
