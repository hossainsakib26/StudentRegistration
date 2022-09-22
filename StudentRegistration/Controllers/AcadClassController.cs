﻿using StudentRegistration.BLL;
using StudentRegistration.Models;
using StudentRegistration.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    public class AcadClassController : Controller
    {
        private AcademicClass _class;
        private AcademicClassBLL _bll;
        private ValidationChecker _checker;

        public AcadClassController()
        {
            _class = new AcademicClass();
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
            ViewBag.FormName = "Create Form";
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
                    if (!IsCodeExists(acadClass.Code) && !IsNameExists(acadClass.Name))
                    {
                        ViewBag.MSG = "Save Success";
                        _bll.AddClass(acadClass);
                        return View(acadClass);
                    }
                    ViewBag.FMSG = "Save OT Failed";
                    return View();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return View();
        }

        public ActionResult Details(long id)
        {
            return View();
        }

        public ActionResult Edit(long id)
        {
            return View();
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
                var singleData = dataList.Where(c => c.Code == name).FirstOrDefault();
                return _checker.HasValueInObject(singleData);
            }
            return false;
        }

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