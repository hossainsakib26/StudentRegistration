using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models.Interfaces
{
    public interface IAcademicClass
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }
}