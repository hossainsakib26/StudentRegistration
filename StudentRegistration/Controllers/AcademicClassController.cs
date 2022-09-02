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
        private AcademicClassBLL _classBll;
        private AcademicClass _aClass;
        private ValidationChecker _validation;

        public AcademicClassController()
        {
            _classBll = new AcademicClassBLL();
            _aClass = new AcademicClass();
            _validation = new ValidationChecker();
        }

        // GET: AcademicClass
        [HttpGet]
        public ActionResult ClassList()
        {
            var classes = _classBll.Classes();
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
                    if(!IsExistsCode(classData.Code) && !IsExistsName(classData.Name))
                    {
                        _classBll.AddClass(classData);
                        ViewBag.ClassData = classData;
                        ViewBag.SuccessMsg = "" + classData.Code + " & " + classData.Name + " is added";
                        ModelState.Clear();
                        return View(new AcademicClass());
                    }
                }
                else
                {
                    ViewBag.FailedMsg = "" + classData.Code + " & " + classData.Name + " isn't added";
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
            var dataList = _classBll.Classes();
            if (_validation.HasObjectInArray(dataList))
            {
                var singleData = dataList.FirstOrDefault(c => c.Code == code);
                return _validation.HasValueInObject(singleData);
            }
            return false;
        }

        //[NonAction]
        public bool IsExistsName(string name)
        {
            var dataList = _classBll.Classes();
            _validation.HasObjectInArray(dataList);
            var singleData = dataList.FirstOrDefault(c => c.Name == name);
            return _validation.HasValueInObject(singleData);
        }

    }
}