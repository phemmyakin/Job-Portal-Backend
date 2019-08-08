using Jobportal.Models;
using Jobportal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public Employee Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var employee = _context.Employees.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (employee == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, employee.PasswordHash, employee.PasswordSalt))
                return null;

            // authentication successful
            return employee;
        }

        public Employee CreateEmployee(Employee employee, string password)
        {

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (_context.Employees.Any(x => x.Username == employee.Username))
                throw new Exception("Username \"" + employee.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            employee.PasswordHash = passwordHash;
            employee.PasswordSalt = passwordSalt;

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return employee;
        }

        public Employee GetEmployee(int employeeId)
        {
            return _context.Employees.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
        }

        public ICollection<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public void UpdateEmployee(Employee employee, string password = null)
        {
            //_context.Update(employee);
            //return Save();

            var user = _context.Employees.Find(employee.EmployeeId);

            if (user == null)
                throw new Exception("User not found");

            if (employee.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (_context.Employees.Any(x => x.Username == employee.Username))
                    throw new Exception("Username " + employee.Username + " is already taken");
            }

            // update user properties
            user.FirstName = employee.FirstName;
            user.LastName = employee.LastName;
            user.Username = employee.Username;
            user.Address1 = employee.Address1;
            user.Address2 = employee.Address2;
            user.AlternatePhoneNumber = employee.AlternatePhoneNumber;
            user.Avalability = employee.Avalability;
            user.Country = employee.Country;
            user.CurrentJob = employee.CurrentJob;
            user.CV = employee.CV;
            user.DateOfBirth = employee.DateOfBirth;
            user.Email = employee.Email;
            user.Gender = employee.Gender;
            user.PhoneNumber = employee.PhoneNumber;
            user.State = employee.State;
            user.HighestQualification = employee.HighestQualification;
            user.YearsOfExperience = employee.YearsOfExperience;
            user.Passport = employee.Passport;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Employees.Update(user);
            _context.SaveChanges();
        }


        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
