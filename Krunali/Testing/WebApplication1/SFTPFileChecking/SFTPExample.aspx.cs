using Polly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SFTPFileChecking
{
    public partial class SFTPExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void IsAvailableFile()
        {
            Policy rt ;
           

            //Policy retryPolicy = Policy.Handle&lt;IOException&gt;().WaitAndRetry(6, i = &gt; TimeSpan.FromSeconds(Math.Pow(2, i)));
            //retryPolicy.Execute(() = &gt;
            //{
            //    using (FileStream stream = File.OpenRead(filePath))
            //    {
            //        stream.Close();
            //    }

            //}); 
            //return true;
        }
    }
}