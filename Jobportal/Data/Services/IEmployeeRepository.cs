using Jobportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobportal.Services
{
    public interface IEmployeeRepository
    {
        //Employee Authenticate(string username, string password);
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
      //  Employee CreateEmployee(Employee employee, string password);
        void UpdateEmployee(Employee employee, string password = null);
      //  bool Save();
    }
}
