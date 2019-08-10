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
     
        public string Title { get; set; }
       
        public string Gender { get; set; }
      
        public string FirstName { get; set; }
     
        public string LastName { get; set; }
     
        public string Email { get; set; }
    
        public DateTime DateOfBirth { get; set; }
    
        public string Country { get; set; }
    
        public string State { get; set; }
  
        public int PhoneNumber { get; set; }
    
        public int AlternatePhoneNumber { get; set; }
        public string Address1 { get; set; }
 
        public string Address2 { get; set; }

        public string HighestQualification { get; set; }
 
        public string CurrentJob { get; set; }

        public string YearsOfExperience { get; set; }
   
        public string Avalability { get; set; }
        public string CV { get; set; }
       

    }
}
