using Jobportal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobportal.Services
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options): base (options)
        {
            Database.Migrate(); 
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
