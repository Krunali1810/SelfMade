using StudentDemoWithDBMLClass.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentDemoWithDBMLClass.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your contact page.";
          
            Student_MasterDataContext model = new Student_MasterDataContext();
            List<Student_Master> students = model.Student_Masters.ToList();
            return View(students);
           
            //var students = from stds in sqlObj.Student_Masters
            //                       select new
            //                       {
            //                           stds.StdID,
            //                           stds.StdName,
            //                           stds.StdContactNo
            //                       };
            //return View(result);

            ////  var ivtfval = (from a in dbcontext.Employees
            ////               select new EmployeeModel { ID= a.id, Desciprion = a.descript, Group =a.grp, Price = a.price }).Take(16);
            ////return View(ivtfval.ToList());        
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}