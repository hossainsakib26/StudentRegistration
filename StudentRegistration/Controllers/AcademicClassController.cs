using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistration.BLL;
using StudentRegistration.Models;

namespace StudentRegistration.Controllers
{
    public class AcademicClassController : Controller
    {
        public AcademicClassBLL _academicClassBll = new AcademicClassBLL();

        // GET: AcademicClass
        public ActionResult ClassList()
        {
            var classes =  _academicClassBll.Classes();
            return View(classes);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}