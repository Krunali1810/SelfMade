using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudentDemoWithDBMLClass.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> student { get; set; }
    }
}