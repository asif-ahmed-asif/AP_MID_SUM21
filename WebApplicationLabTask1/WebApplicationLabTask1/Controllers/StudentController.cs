using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLabTask1.Models;
using WebApplicationLabTask1.Models.Database;

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
            if (ModelState.IsValid)
            {
                Database db = new Database();
                var login = db.Logins.ValidateLogin(l);
                if(login != null)
                {
                    TempData["Name"] = login.Name;
                    return RedirectToAction("Dashboard");
                }
                TempData["Failed"] = "Login Failed! Invalid User Name or Password";
                return View();
                
            }
            return View();
        }

        public ActionResult Dashboard()
        {

            return View();
        }

        public ActionResult ViewStudents()
        {
            Database db = new Database();
            var students = db.Students.GetAll();
            return View(students);
        }

        public ActionResult AddStudents()
        {
            Student s = new Student();
            return View(s);
        }

        [HttpPost]
        public ActionResult AddStudents(Student s)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Students.Insert(s);
                return RedirectToAction("ViewStudents");
            }
            return View();
        }

        public ActionResult ViewDepartments()
        {
            Database db = new Database();
            var departments = db.Departments.GetAll();
            return View(departments);
        }

        public ActionResult EditStudents(int id)
        {
            Database db = new Database();
            var student = db.Students.Get(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult EditStudents(Student s)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Students.Update(s);
                return RedirectToAction("ViewStudents");
            }
            return View(s);
           
        }

        public ActionResult DeleteStudent(int id)
        {
            Database db = new Database();
            db.Students.Delete(id);
            return RedirectToAction("ViewStudents");
        }
    }
}