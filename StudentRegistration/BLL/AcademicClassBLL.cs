using System.Collections.Generic;
using StudentRegistration.DAL;
using StudentRegistration.Models;

namespace StudentRegistration.BLL
{
    public class AcademicClassBLL
    {
        private AcademicClassDAL academicClassDAL;

        public AcademicClassBLL()
        {
            academicClassDAL = new AcademicClassDAL();
        }

        public ICollection<AcademicClass> Classes()
        {
            return academicClassDAL.ClassList();
        }

        public bool AddClass(AcademicClass aClass)
        {
            if (aClass != null)
            {
                academicClassDAL.AddClass(aClass);
                return true;
            }
            return false;
        }

        public bool UpdateClass(AcademicClass aClass)
        {
            return academicClassDAL.UpdateClass(aClass);
        }

        public bool DeleteData(AcademicClass model)
        {
            return academicClassDAL.DeleteData(model);
        }
    }
}