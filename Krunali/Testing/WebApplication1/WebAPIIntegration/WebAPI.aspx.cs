using DevExpress.Utils.About;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.Web.Http;
using PanAPI;

namespace WebAPIIntegration
{
    public partial class WebAPI : Page
    {
        PanAPI.PANAPI AP = new PanAPI.PANAPI(); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string LangS = "en";
            dynamic Res=AP.CreateAPIHttpClient(LangS);
        }

        //public string AddEmployees(Employee Emp)
        //{
        //    //calling EmpRepository Class Method and storing Repsonse   
        //    var response = Emp;
        //    return response;

        //}

        //[System.Web.Http.HttpPost]
        //static async Task<Uri> CreateProductAsync()
        //{     
        //    using (var client = new HttpClient())
        //    {
        //        HttpResponseMessage response=null;
        //        try
        //        {
        //            HttpContent body=null;
        //            client.DefaultRequestHeaders.Add("", "");
        //            response = await client.PostAsync("https://apisetu.gov.in/certificate/v3/pan/pancr", body);
        //            response.EnsureSuccessStatusCode();

        //            return response.Headers.Location;
        //        }
        //        catch(Exception ex)
        //        {
        //            return response.Headers.Location;
        //        }
        //   }
        //}
    }
   
}