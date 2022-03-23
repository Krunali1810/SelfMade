using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDemoWithDBMLClass.Models
{
    [Table("Student_Master")]
    public class Student
    {
        [Key]
        public int StdId { get; set; }
        public string stdName { get; set; }
        public string stdContactNo { get; set; }

    }
}