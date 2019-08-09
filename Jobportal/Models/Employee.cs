using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jobportal.Models
{
    public class Employee
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
        public string CV { get; set; }
        public string Passport{get; set;}
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
