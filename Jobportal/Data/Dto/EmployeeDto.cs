using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data.Dto
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public int AlternatePhoneNumber { get; set; }
        public string Address1 { get; set; }
        [Required]
        public string Address2 { get; set; }
        [Required]
        public string HighestQualification { get; set; }
        [Required]
        public string CurrentJob { get; set; }
        [Required]
        public string YearsOfExperience { get; set; }
        [Required]
        public string Avalability { get; set; }
        public Base64FormattingOptions CV { get; set; }
        public Base64FormattingOptions Passport { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
