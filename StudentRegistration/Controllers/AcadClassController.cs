using StudentRegistration.BLL;
using StudentRegistration.Models;
using StudentRegistration.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentRegistration.Controllers
{
    public class AcadClassController : Controller
    {
        private AcademicClassBLL _bll;
        private ValidationChecker _checker;

        public AcadClassController()
        {
            _bll = new AcademicClassBLL();
            _checker = new ValidationChecker();
        }

        // GET: AcadClass
        public ActionResult Index()
        {
            ViewBag.IndexName = "Classes";
            var classes = _bll.Classes();
            return View(classes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.FormName = "Add Academic Class";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AcademicClass acadClass)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Object forResponseObject;
                    if (!IsCodeExists(acadClass.Code) && !IsNameExists(acadClass.Name))
                    {
                        _bll.AddClass(acadClass);
                        forResponseObject = new { acadClass };
                        return Json(forResponseObject, JsonRequestBehavior.AllowGet);
                    }
                    forResponseObject = new { acadClass, codeExists = IsCodeExists(acadClass.Code), nameExists = IsNameExists(acadClass.Name) };
                    return Json(forResponseObject, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Edit(long id)
        {
            ViewBag.FormName = "Edit Class";
            var dataList = _bll.Classes();
            var selectedData = (_checker.HasObjectInArray(dataList)) ? dataList.FirstOrDefault(c => c.ID == id) : null;
            return View(selectedData);
        }

        [HttpPost]
        public ActionResult Edit(AcademicClass model)
        {
            if (ModelState.IsValid)
            {
                _bll.UpdateClass(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(long id)
        {
            if (id > 0)
            {
                var dataList = _bll.Classes();
                if (_checker.HasObjectInArray(dataList))
                {
                    var singleData = dataList.FirstOrDefault(c => c.ID == id);
                    _bll.DeleteData(singleData);
                    return RedirectToAction("Index");
                }
            }

            return View("Index");
        }
        
        public bool IsCodeExists(string code)
        {
            var dataList = _bll.Classes();
            if (_checker.HasObjectInArray(dataList))
            {
                var singleData = dataList.Where(c => c.Code == code).FirstOrDefault();
                return _checker.HasValueInObject(singleData);
            }
            return false;
        }

        public bool IsNameExists(string name)
        {
            var dataList = _bll.Classes();
            if (_checker.HasObjectInArray(dataList))
            {
                var singleData = dataList.Where(c => c.Name == name).FirstOrDefault();
                return _checker.HasValueInObject(singleData);
            }
            return false;
        }

        //working with nare future inshaAllah
        public Tuple<string, bool> IsNameExistsTuple(string name)
        {
            var dataList = _bll.Classes();
            if (_checker.HasObjectInArray(dataList))
            {
                var singleData = dataList.Where(c => c.Name == name).FirstOrDefault();
                return Tuple.Create(name, _checker.HasValueInObject(singleData));
            }
            return Tuple.Create(name, false);
        }
        
    }
}