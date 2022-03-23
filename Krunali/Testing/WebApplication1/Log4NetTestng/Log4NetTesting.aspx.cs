using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace Log4NetTestng
{
    public partial class Log4NetTesting : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.Config.BasicConfigurator.Configure();
            ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Testing();
        }

        internal static void Testing()
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            try
            {
                string str = String.Empty;
                string subStr = str.Substring(0, 4); //this line will create error as the string "str" is empty.  
            }
            catch (Exception ex)
            {
                log.Error("Error Message: " + ex.Message.ToString(), ex);
            }
        }
    }
}