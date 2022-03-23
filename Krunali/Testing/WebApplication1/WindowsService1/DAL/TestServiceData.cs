using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1.DAL
{
   public class TestServiceData
    {
        public List<Student_Master> SelectActiveStudent(string connectionString,byte studentFlag)
        {
            using (TestWindowServiceDataContext db = new TestWindowServiceDataContext(connectionString))
            {
                return db.StudentMasterGetActive(studentFlag).ToList();
            }
        }
    }
}
