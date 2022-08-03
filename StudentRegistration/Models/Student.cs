using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    public class Student
    {
        [Key]
        public Int64 ID { get; set; }
        public string Name { get; set; }
        public float Age { get; set; }
        public int GenderID { get; set; }
        public DateTime RegistrationDate { get; set; }

        //foreign key
        [Display(Name = "Academic Class")]
        public virtual int AcademicClassId { get; set; }
        [ForeignKey("AcademicClassId")]
        public virtual AcademicClass AcademicClass { get; set; }

    }
}