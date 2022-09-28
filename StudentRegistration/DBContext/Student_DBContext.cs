using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using StudentRegistration.Models;

namespace StudentRegistration.DBContext
{
    public class Student_DBContext: DbContext
    {
        public Student_DBContext() : base("Student_DBContext")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<AcademicClass> AcademicClasses { get; set; }
    }
}