using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeWebAPI.Data;
using EmployeeWebAPI.Models;
using EmployeeWebAPI.Repository;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeesController(IEmployeeRepository repository)
        {
            _employeeRepo = repository;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _employeeRepo.GetAllAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeRepo.GetAsync(id);    

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }
            try
            {
                await _employeeRepo.UpdateAsync(employee);
            }
            catch (Exception ex)
            {
                if (!await _employeeRepo.EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex);
                }
            }
            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                await _employeeRepo.CreateAsync(employee);
                return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _employeeRepo.GetAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                await _employeeRepo.DeleteAsync(employee);
                return Ok("Employee deleted successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
