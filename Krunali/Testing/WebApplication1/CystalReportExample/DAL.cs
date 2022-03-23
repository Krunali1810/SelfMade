using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using SqlConnection = System.Data.SqlClient.SqlConnection;
using SqlCommand = System.Data.SqlClient.SqlCommand;
using System.Configuration;
using SqlDataAdapter = Microsoft.Data.SqlClient.SqlDataAdapter;

namespace CystalReportExample
{
    public class DAL
    {
        SqlConnection cn = new SqlConnection();
        private const string CONNECTION_NAME = "Collage_MasterConnectionString";
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter();
        int result = 0;
        public DataSet GetData()
        {
          try
          {  
            using (DataClasses1DataContext obj = new DataClasses1DataContext())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[CONNECTION_NAME].ConnectionString;
                
                cmd.CommandText = "CountrySelectAll";
                cn.Open();
                //adp.SelectCommand = "";
                adp.Fill(ds);
                result= cmd.ExecuteNonQuery();
                cn.Close();
                return ds;
              }
           }     
           catch (Exception ex)
            {
                return ds;
            }
        }
    }
   
}