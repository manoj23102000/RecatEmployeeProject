using Microsoft.EntityFrameworkCore;
using EmployeeWebAPI.Models;

namespace EmployeeWebAPI.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetAsync(int id);
        Task CreateAsync(Employee employee);    
        Task UpdateAsync(Employee employee);    
        Task DeleteAsync(Employee employee);
        Task<bool> EmployeeExists(int id); 
    }
}
