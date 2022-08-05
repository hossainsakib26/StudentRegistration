using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistration.DAL;
using StudentRegistration.Models;

namespace StudentRegistration.BLL
{
    public class AcademicClassBLL
    {
        private AcademicClassDAL _academicClassDAL = new AcademicClassDAL();

        public ICollection<AcademicClass> Classes()
        {
            return _academicClassDAL.ClassList();
        }
    }
}