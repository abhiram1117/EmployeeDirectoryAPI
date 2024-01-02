using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeDirectoryAPI2.Models;
using System.Data;

namespace EmployeeDirectoryAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDirectoryAPIDataContext _context;

        public EmployeesController(EmployeeDirectoryAPIDataContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Employee>>>> GetEmployees()
        {
          var employees = await _context.Employees.ToListAsync();
          var response = new ApiResponse<IEnumerable<Employee>>
        {
            Success = true,
            Message = "Employees retrieved successfully",
            Data = employees
        };
            return response;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Employee>>> GetEmployee(int id)
        {
          
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                var notFoundResponse = new ApiResponse<Employee>
                {
                    Success = false,
                    Message = "Employee not Found",
                    Data = null
                };
                return notFoundResponse;
            }
            var successResponse = new ApiResponse<Employee>
            {
                Success = true,
                Message = "Employees retrieved successfully",
                Data = employee
            };

            return successResponse;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id) {
                var mismatchResponse = new ApiResponse<Employee>
                {
                    Success = false,
                    Message = "Employee Mismatch",
                    Data = null
                };
                return BadRequest(mismatchResponse);
            }

            _context.Entry(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DBConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    var notFoundresponse = new ApiResponse<Employee>
                    {
                        Success = false,
                        Message = "Employee not found",
                        Data = null
                    };
                    return NotFound(notFoundresponse) ;
                }
                else
                {
                    throw;
                }
            }
            var successResponse = new ApiResponse<Employee>
            {
                Success = true,
                Message = "Employees updated successfully",
                Data = employee
            };
            return Ok(successResponse);
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Employee>>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            var successResponse = new ApiResponse<Employee>
            {
                Success = true,
                Message = "Employee created Successfully",
                Data = employee
            };

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, successResponse);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
