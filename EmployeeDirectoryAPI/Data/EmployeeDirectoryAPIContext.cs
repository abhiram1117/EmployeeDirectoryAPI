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
        public EmployeeDirectoryAPIContext (DbContextOptions<EmployeeDirectoryAPIContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeDirectoryAPI.Model.Employee> Employee { get; set; } = default!;
    }
}
