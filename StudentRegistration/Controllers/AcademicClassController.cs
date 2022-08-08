using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistration.BLL;
using StudentRegistration.Models;
using StudentRegistration.Models.Enums;
using StudentRegistration.Services;

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
            AcademicClass singleData = null;
            var dataList = _academicClassBll.Classes();

            singleData = dataList.Where(c => c.Code == classData.Code).FirstOrDefault();
            if (singleData.Code != classData.Code || singleData.Name != classData.Name)
            {
                if (!ModelState.IsValid)
                {
                    _academicClassBll.AddClass(classData);
                    ViewBag.Alert = ServeAlert.ShowAlart(Alert.Success, "Data Added Bandhu..");
                    return View();
                }
                else
                {
                    ViewBag.Alert = ServeAlert.ShowAlart(Alert.Danger, "Data Add Process failed Bandhu..");
                }

            }
            ViewBag.Alert = ServeAlert.ShowAlart(Alert.Danger, "Your data was matching with another data");
            return View();
        }

    }
}