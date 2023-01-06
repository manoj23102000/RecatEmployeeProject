using Microsoft.EntityFrameworkCore;
using EmployeeWebAPI.Models;

namespace EmployeeWebAPI.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }  
    }
}
