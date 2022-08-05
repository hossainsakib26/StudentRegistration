using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistration.DBContext;
using StudentRegistration.Models;

namespace StudentRegistration.DAL
{
    public class AcademicClassDAL
    {
        private Student_DBContext _db = new Student_DBContext();

        public ICollection<AcademicClass> ClassList()
        {
            return _db.AcademicClasses.ToList();
        }
    }
}