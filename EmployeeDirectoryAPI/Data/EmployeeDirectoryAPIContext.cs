using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeDirectoryAPI.Model;

namespace EmployeeDirectoryAPI.Data
{
    public class EmployeeDirectoryAPIContext : DbContext
    {
        public EmployeeDirectoryAPIContext(DbContextOptions<EmployeeDirectoryAPIContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeDirectoryAPI.Model.Employee> Employees { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Employee>().HasData(
                new Employee { ID = 1, FirstName = "Anthony", LastName = "Morris", JobTitle = "SharePoint Practice Head", Department = "IT", Location = "Seattle" },
                new Employee { ID = 2, FirstName = "Helen", LastName = "Zimmerman", JobTitle = "Operations Manager", Department = "IT", Location = "Seattle" },
            new Employee { ID = 3, FirstName = "Joanthon", LastName = "Smith", JobTitle = "Product Manager", Department = "IT", Location = "Seattle" },
            new Employee { ID = 4, FirstName = "Tami", LastName = "Hopkins", JobTitle = "Lead Engineer", Department = "IT", Location = "Seattle" },
            new Employee { ID = 5, FirstName = "Franklin", LastName = "Humark", JobTitle = "Network Engineer", Department = "IT", Location = "Seattle" },
            new Employee { ID = 6, FirstName = "Angela", LastName = "Bailey", JobTitle = "Talent Manager", Department = "HR", Location = "Seattle" },
            new Employee { ID = 7, FirstName = "Robert", LastName = "Mitchell", JobTitle = "Software Engineer", Department = "IT", Location = "Seattle" },
            new Employee { ID = 8, FirstName = "Olivia", LastName = "Watson", JobTitle = "UI Designer", Department = "UX", Location = "India" }
        
            );
        }
    }
    

}
