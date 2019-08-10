using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jobportal.ViewModel
{
    public class EmployeeViewModel
    {
        [Required]
        [EmailAddress]
        public string  Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password and Confirmation Password doesnot match.")]
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; internal set; }
    }
}
