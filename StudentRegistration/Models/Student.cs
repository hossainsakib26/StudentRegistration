using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Age { get; set; }
        public int GenderID { get; set; }
        public DateTime RegistrationDate { get; set; }
        public AcademicClass ClassName { get; set; }

    }
}