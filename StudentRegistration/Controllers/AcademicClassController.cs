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
        [HttpGet]
        public ActionResult ClassList()
        {
            var classes = _academicClassBll.Classes();
            return View(classes);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AcademicClass classData)
        {
            if (!ModelState.IsValid)
            {
                _academicClassBll.AddClass(classData);
                ViewBag.successMsg = "New data added.";
            }
            else
            {
                ViewBag.faildMsg = "New data add process failed!";
            }
            return View();
        }

    }
}