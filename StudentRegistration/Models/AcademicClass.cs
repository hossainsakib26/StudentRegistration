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
        [Key]
        public int ID { get; set; }
        [StringLength(10, ErrorMessage = "Maximum length will be 4")][Required]
        public string Code { get; set; }
        [Required] [StringLength(100, ErrorMessage = "Maximum length will be 100")]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}