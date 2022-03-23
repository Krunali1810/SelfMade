using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

namespace Demo_Practical
{
    public partial class Test : System.Web.UI.Page
    {
        DAL obj = new DAL();
        string connectionstring= "Data Source=DIT-DESKTOP-SER;Initial Catalog=demo_product;User ID=sa;Password=123456"; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
               
            }
        }

        protected void deleteData(string cnn)
        {
            int catId = Convert.ToInt32(txtCat1.Text);
            obj.Delete(cnn, catId);

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            alert.Visible = true;
            deleteData(connectionstring);
        }
    }
}