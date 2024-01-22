
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EmployeeDirectoryAPI.Model;
using EmployeeDirectoryAPI.Services;
using EmployeeDirectoryAPI.Migrations;

namespace EmployeeDirectoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployee()
        {
            var employees = _employeeService.GetEmployees();
            var response = new ApiResponse<IEnumerable<Employee>> { 
                Success = true,
                Message ="Employees retrieved Successfully",
                Data = employees
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _employeeService.GetEmployee(id);

            if (employee == null)
                return NotFound(new ApiResponse<Employee> { 
                    Success = false,
                    Message = "Employee not found",
                    Data = null
                });

            return Ok(new ApiResponse<Employee> { 
                Success = true,
                Message = "Employees retrieved Successfully",
                Data = employee });
        }
        
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee updatedEmployee)
        {
            _employeeService.UpdateEmployee(id, updatedEmployee);

            if (id!= updatedEmployee.ID)
                return NotFound(new ApiResponse<Employee> { 
                    Success = false, 
                    Message = "Employee not found",
                    Data = null
                });

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Employee> PostEmployee(Employee employee)
        {
            var createdEmployee = _employeeService.CreateEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.ID },
                new ApiResponse<Employee> { Success = true, Data = createdEmployee });
        }

        
    }
}
