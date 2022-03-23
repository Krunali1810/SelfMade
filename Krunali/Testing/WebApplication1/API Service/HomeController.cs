using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API_Service
{
    public class HomeController : Controller
    {
        SimpleApiServiceBharatMap sm = new SimpleApiServiceBharatMap();
        public IActionResult Index()
        {
            var values = (sm.GetValues());
            return View(values);
        }      
    }
}
