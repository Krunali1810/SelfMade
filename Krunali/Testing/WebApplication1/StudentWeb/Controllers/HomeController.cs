using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentWeb.Models;


namespace StudentWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(tblRegistration obj)

        {
            if (ModelState.IsValid)
            {
                Collage_MasterEntities db = new Collage_MasterEntities();
                db.tblRegistrations.Add(obj);
                db.SaveChanges();
            }
            return View(obj);
        }
    }
}