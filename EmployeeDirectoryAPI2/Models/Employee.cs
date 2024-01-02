using System;
using System.Collections.Generic;

namespace EmployeeDirectoryAPI2.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string? Location { get; set; }
    }
}
