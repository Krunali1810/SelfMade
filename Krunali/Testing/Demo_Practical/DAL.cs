using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Demo_Practical
{
    public class DAL 
    {

		public int Delete(string connectionString, int CatID)
		{
			int? res=0;
			using (DataClasses1DataContext db = new DataClasses1DataContext(connectionString))
			{
			   return db.SP_Category_DeleteByID(CatID, ref res);
			}
		}
    }
}