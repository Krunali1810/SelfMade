using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ValuesController : ApiController
    {
        public IHttpActionResult GetAllStudents()
        {
            IList<StudentViewModel> std = null;
            using (var ctx = new tempdbEntities3())
            {
                std = ctx.COLLAGE_MASTER.Include("StdName")
                    .Select(s => new StudentViewModel()
                    {
                        Id = s.StdID,
                        FirstName = s.StdName,
                        Address = s.StdAddress
                    }).ToList<StudentViewModel>();
            }

            if (std.Count == 0)
            {
                return NotFound();
            }

            return Ok(std);
        }
       
    }
}
