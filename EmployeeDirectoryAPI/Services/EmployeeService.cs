
using EmployeeDirectoryAPI.Data;
using EmployeeDirectoryAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDirectoryAPI.Services
{
    public class EmployeeService
    {
        private readonly EmployeeDirectoryAPIContext _employeeContext;

        public EmployeeService(EmployeeDirectoryAPIContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return _employeeContext.Employees.FirstOrDefault(e => e.ID == id);
        }

        public bool UpdateEmployee(int id, Employee updatedEmployee)
        {
            var existingEmployee = _employeeContext.Employees.FirstOrDefault(e => e.ID == id);

            if (existingEmployee == null)
            {
                return false;
            }

            existingEmployee.FirstName = updatedEmployee.FirstName;
            existingEmployee.LastName = updatedEmployee.LastName;
            existingEmployee.JobTitle = updatedEmployee.JobTitle;
            existingEmployee.Department = updatedEmployee.Department;
            existingEmployee.Location = updatedEmployee.Location;

            _employeeContext.SaveChanges();

            return true;
        }

        public Employee CreateEmployee(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();

            return employee;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeContext.Employees.FirstOrDefault(e => e.ID == id);

            if (employee == null)
                return false;

            _employeeContext.Remove(employee);
            _employeeContext.SaveChanges();

            return true;
        }
    }
}
