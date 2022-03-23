using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CystalReportExample
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DAL Data = new DAL();
        DataSet ds;
        private const string CONNECTION_NAME = "Collage_MasterConnectionString";
        string connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_NAME].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
        protected void LoadReport()
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Server.MapPath("~/CrystalReport1.rpt"));
            cryRpt.Refresh();
            //cryRpt.SetDatabaseLogon("sa", "123456", "10.1.158.211", "DICTPAR");
            ds= Data.GetData();
            cryRpt.Database.Tables[0].SetDataSource(ds);

            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
        }
    }
}