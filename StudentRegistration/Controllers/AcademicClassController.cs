﻿using System;
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
        private AcademicClassBLL _academicClassBll = new AcademicClassBLL();
        private AcademicClass _class = new AcademicClass();

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
            try
            {
                ExistsCode(classData.Code);

                if (!ModelState.IsValid)
                {
                    _academicClassBll.AddClass(classData);
                    return View();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return View();
        }

        //[NonAction]
        public bool ExistsCode(string code)
        {

            var dataList = _academicClassBll.Classes();
            //var singleData = new AcademicClass();
            var singleData = dataList.FirstOrDefault(c => c.Code == code);

            if (singleData != null)
            {
                return true;
            }
            return false;
        }

    }
}