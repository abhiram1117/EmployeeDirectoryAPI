using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeDirectoryAPI.Data;
using EmployeeDirectoryAPI.Model;
using Microsoft.AspNetCore.Cors;

namespace EmployeeDirectoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeesController : ControllerBase
    {
        //    private static List<Employee> _employees = new List<Employee>
        //{
        //    new Employee { ID = 1, FirstName = "Anthony", LastName = "Morris", JobTitle = "SharePoint Practice Head", Department = "IT", Location = "Seattle" },
        //    new Employee { ID = 2, FirstName = "Helen", LastName = "Zimmerman", JobTitle = "Operations Manager", Department = "IT", Location = "Seattle" },
        //    new Employee { ID = 3, FirstName = "Joanthon", LastName = "Smith", JobTitle = "Product Manager", Department = "IT", Location = "Seattle" },
        //    new Employee { ID = 4, FirstName = "Tami", LastName = "Hopkins", JobTitle = "Lead Engineer", Department = "IT", Location = "Seattle" },
        //    new Employee { ID = 5, FirstName = "Franklin", LastName = "Humark", JobTitle = "Network Engineer", Department = "IT", Location = "Seattle" },
        //    new Employee { ID = 6, FirstName = "Angela", LastName = "Bailey", JobTitle = "Talent Manager", Department = "HR", Location = "Seattle" },
        //    new Employee { ID = 7, FirstName = "Robert", LastName = "Mitchell", JobTitle = "Software Engineer", Department = "IT", Location = "Seattle" },
        //    new Employee { ID = 8, FirstName = "Olivia", LastName = "Watson", JobTitle = "UI Designer", Department = "UX", Location = "India" },
        //};
        private readonly EmployeeDirectoryAPIContext _employee;

        public EmployeesController(EmployeeDirectoryAPIContext employee)
        {
            _employee = employee;
        }

        // GET: api/Employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployee()
        {
          
            return _employee.Employees.ToList();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _employee.Employees.FirstOrDefault(e => e.ID == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee updatedEmployee)
        {

            var existingEmployee = _employee.Employees.FirstOrDefault(e => e.ID == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.FirstName = updatedEmployee.FirstName;
            existingEmployee.LastName = updatedEmployee.LastName;
            existingEmployee.JobTitle = updatedEmployee.JobTitle;
            existingEmployee.Department = updatedEmployee.Department;
            existingEmployee.Location = updatedEmployee.Location;

            _employee.SaveChanges();

            return NoContent(); ;


            //existingEmployee.FirstName = updatedEmployee.FirstName;
            //existingEmployee.LastName = updatedEmployee.LastName;
            //existingEmployee.JobTitle = updatedEmployee.JobTitle;
            //existingEmployee.Department = updatedEmployee.Department;
            //existingEmployee.Location = updatedEmployee.Location;
            //return NoContent();
            //return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Employee> PostEmployee(Employee employee)
        {

            
            _employee.Employees.Add(employee);
            _employee.SaveChanges();
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.ID }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employee.Employees.FirstOrDefault(e => e.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            _employee.Remove(employee);
            return NoContent();
        }

       
    }
}
