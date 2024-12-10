using CollegeApp.Validator;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Model
{
    public class StudentDTO
    {
        [ValidateNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        [StringLength(100)]
        public string StudentName { get; set; }

        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }


        //[Range(10, 20)]
        //public int Age { get; set; }
        //public string Password { get; set; }
        //[Compare(nameof(Password))]
        //public string ConfirmPassword { get; set; }

        [DateCheckAttribute]
        public DateTime AdmissionDate { get; set; }
    }
}
