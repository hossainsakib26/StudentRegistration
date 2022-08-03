using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    public class AcademicClassController : Controller
    {
        // GET: AcademicClass
        public ActionResult ClassList()
        {

            return View();
        }
    }
}