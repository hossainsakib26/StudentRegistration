using StudentRegistration.BLL;
using StudentRegistration.Models;
using StudentRegistration.Services;
using System;
using System.Linq;
using System.Web.Mvc;

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
        public ActionResult Create()
        {
            ViewBag.test = "test";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AcademicClass classData)
        {
            if (!ModelState.IsValid)
            {
                if (!IsExistsCode(classData.Code) && !IsExistsName(classData.Name))
                {
                    _classBll.AddClass(classData);
                    //string sMsg = "" + classData.Code + " & " + classData.Name + " is added";
                    //ViewBag.SuccessMsg = Convert.ToString(sMsg);
                    ViewBag.isDataSave = "Data Save Successfully!";

                    return View(classData);
                }
            }
            else
            {
                string fMsg = "" + classData.Code + " & " + classData.Name + " isn't added";
                ViewBag.FailedMsg = Convert.ToString(fMsg);
            }
            return View();
        }

        //[NonAction]
        public bool IsExistsCode(string code)
        {
            var dataList = _classBll.Classes();
            if (_validation.HasObjectInArray(dataList))
            {
                var singleData = dataList.Where(c => c.Code == code).FirstOrDefault();
                return _validation.HasValueInObject(singleData);
            }
            return false;
        }

        //[NonAction]
        public bool IsExistsName(string name)
        {
            var dataList = _classBll.Classes();
            _validation.HasObjectInArray(dataList);
            var singleData = dataList.Where(c => c.Name == name).FirstOrDefault();
            return _validation.HasValueInObject(singleData);
        }

    }
}