using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JavaScript_Based
{
    public partial class JavaScrriptTest_1 : System.Web.UI.Page
    {
        private const string CONNECTION_NAME = "Collage_MasterConnectionString";
        string connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_NAME].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           // LoadControls();
        }

        protected void LoadControls()
        {
            countySel.Dispose();
            countySel.DataSource = LoadData();
            countySel.DataTextField = "Country";
            countySel.DataValueField = "Country";
            countySel.DataBind();
        }

        protected List<CountrySelectAllResult> LoadData()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext(connectionString))
            {
                return db.CountrySelectAll().ToList();
            }
            
        }

    }
}