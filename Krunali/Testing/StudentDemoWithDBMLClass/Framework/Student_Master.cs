using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Text;
using StudentDemoWithDBMLClass.Models;

namespace StudentDemoWithDBMLClass.Framework
{
    public class Student_Master 
    {

        public void Select(string connectionstring,int stdid)
        {
            using (Student_MasterDataContext  db=new Student_MasterDataContext(connectionstring) )
            {
                var b= db.SelectAllStudentMaster(stdid).SingleOrDefault();
            }
        }

    }
}