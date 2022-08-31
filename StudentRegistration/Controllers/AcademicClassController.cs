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
        private readonly AcademicClassBLL classBll;
        private readonly AcademicClass aClass;
        private readonly ValidationChecker checker;

        public AcademicClassController(AcademicClassBLL academicClassBll, AcademicClass academicClass, ValidationChecker validation)
        {
            classBll = academicClassBll;
            aClass = academicClass;
            validation = checker;
        }

        // GET: AcademicClass
        [HttpGet]
        public ActionResult ClassList()
        {
            var classes = classBll.Classes();
            return View(classes);
        }
        public ActionResult Create(bool isSaveSuccess = false)
        {
            if (isSaveSuccess)
            {
                ViewBag.isSaveSuccess = true;
            }
            else
            {
                ViewBag.isSaveSuccess = false;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AcademicClass classData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (!IsExistsCode(classData.Code) && !IsExistsName(classData.Name))
                    {
                        classBll.AddClass(classData);
                        return View();
                    }

                    return View(classData);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return View();
        }

        //[NonAction]
        public bool IsExistsCode(string code)
        {
            var dataList = academicClassBll.Classes();
            //var singleData = new AcademicClass();
            var singleData = dataList.FirstOrDefault(c => c.Code == code);
            
            //if (singleData != null)
            //{
            //    return true;
            //}
            //return false;
            return checker.HasValueInObject(singleData);
        }

        //[NonAction]
        public bool IsExistsName(string name)
        { var dataList = academicClassBll.Classes();
            checker.HasObjectInArray(dataList); 
            var singleData = dataList.FirstOrDefault(c => c.Name == name);
            return checker.HasValueInObject(singleData);
        }

    }
}