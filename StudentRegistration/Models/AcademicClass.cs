using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    public class AcademicClass
    {
        public int ID { get; set; }
        [StringLength(4, ErrorMessage = "Maximum length will be 4")][Required]
        public string Code { get; set; }
        [Required] [StringLength(10, ErrorMessage = "Maximum length will be 10")]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}