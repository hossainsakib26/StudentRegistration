using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    public class AcademicClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}