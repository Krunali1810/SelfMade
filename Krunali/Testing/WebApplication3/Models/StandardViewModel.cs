using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication3.Models
{
    public class StandardViewModel 
    {
        public int StandardId { get; set; }
        public string Name { get; set; }

        public ICollection<StudentViewModel> Students { get; set; }
    }
}
