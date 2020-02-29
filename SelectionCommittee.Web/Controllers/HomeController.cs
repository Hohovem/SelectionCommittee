using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SelectionCommittee.Entities.DataContexts;

namespace SelectionCommittee.Web.Controllers
{
    public class HomeController : Controller
    {
        private FacultyContext cont = new FacultyContext();

        public ActionResult Index()
        {
            return View(cont.Faculties);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}