using Microsoft.EntityFrameworkCore;
using EmployeeWebAPI.Data;
using EmployeeWebAPI.Models;

namespace EmployeeWebAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContext;
        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task CreateAsync(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();    
        }

        public async Task DeleteAsync(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();    
        }

        public async Task<bool> EmployeeExists(int id)
        {
            return await _dbContext.Employees.AnyAsync(e => e.EmployeeId == id);
        }
    }
}
