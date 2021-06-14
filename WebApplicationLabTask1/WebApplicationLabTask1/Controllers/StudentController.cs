using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLabTask1.Models;

namespace WebApplicationLabTask1.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Login()
        {
            Login l = new Login();
            return View(l);
        }

        [HttpPost]
        public ActionResult Login(Login l)
        {
            
            return View(l);
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