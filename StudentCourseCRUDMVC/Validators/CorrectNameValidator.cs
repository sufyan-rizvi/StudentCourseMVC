using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentCourseCRUDMVC.Validators
{
    public class CorrectNameValidator:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var invalidWords = @"!@#$%^&*(){}|\:;'<>'<>?/.,";
            if (value != null)
            {
                var value1 = value.ToString();
                if (!value1.Contains(invalidWords))
                {
                    return ValidationResult.Success;
                }
                
            }
            return new ValidationResult("This field cannot contain special characters!");
        }
    }
}