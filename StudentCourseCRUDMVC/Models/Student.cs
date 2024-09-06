using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StudentCourseCRUDMVC.Validators;

namespace StudentCourseCRUDMVC.Models
{
    public class Student
    {
        public virtual int Id { get; set; }
        [Required]
        [CorrectNameValidator]
        public virtual string Name { get; set; }
        [Required]
        [Range(18,24)]
        public virtual int Age { get; set; }
        [Required]
        [EmailAddress]
        public virtual string Email {  get; set; }
        public virtual Course Course { get; set; }

    }
}