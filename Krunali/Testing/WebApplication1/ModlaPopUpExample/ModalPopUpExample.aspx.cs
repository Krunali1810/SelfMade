using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ModlaPopUpExample
{
    public partial class ModalPopUpExample : System.Web.UI.Page
    {
        protected string strConnString = "Data Source=10.1.158.211;Initial Catalog=ModalExample;Persist Security Info=True;User ID=sa;Password=123456";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
            }

        }

        private void BindData()
        {
            string strQuery = "select CustomerID,ContactName,CompanyName" +
                               " from CompanyDetails";
            SqlCommand cmd = new SqlCommand(strQuery);
            GridView1.DataSource = GetData(cmd);
            GridView1.DataBind();
        }

        private DataTable GetData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    con.Open();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    return dt;
                }
            }
        }

        protected void Add(object sender, EventArgs e)
        {
            txtCustomerID.ReadOnly = false;
            txtCustomerID.Text = string.Empty;
            txtContactName.Text = string.Empty;
            txtCompany.Text = string.Empty;
            popup.Show();
        }

        protected void Save(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddUpdateCustomer";
                cmd.Parameters.AddWithValue("@in_CustomerID", txtCustomerID.Text);
                cmd.Parameters.AddWithValue("@in_ContactName", txtContactName.Text);
                cmd.Parameters.AddWithValue("@in_CompanyName", txtCompany.Text);
                GridView1.DataSource = this.GetData(cmd);
                GridView1.DataBind();
            }
        }
    }
}