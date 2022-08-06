using System.Collections.Generic;
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

        public bool AddClass(AcademicClass aClass)
        {
            if (aClass != null)
            {
                _academicClassDAL.AddClass(aClass);
                return true;
            }
            return false;
        }
    }
}