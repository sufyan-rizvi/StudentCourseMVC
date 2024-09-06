using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StudentCourseCRUDMVC.Validators;

namespace StudentCourseCRUDMVC.Models
{
    public class Course
    {
        public virtual int Id { get; set; }
        [Required]
        [CorrectNameValidator]
        [Display(Name="Course Name")]
        public virtual string Name { get; set; }
        [Required]
        [Range(0.1, 2)]
        [Display(Name="Course Duration")]
        public virtual int Duration { get; set; }
        public virtual Student Student { get; set; }

    }
}